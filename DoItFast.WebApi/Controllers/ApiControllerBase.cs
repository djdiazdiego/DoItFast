using AutoMapper;
using DoItFast.Application.Command;
using DoItFast.Application.Dtos;
using DoItFast.Application.Exceptions;
using DoItFast.Application.Queries;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Commands;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Abstractions.Queries;
using DoItFast.Domain.Core.Abstractions.Wrappers;
using DoItFast.Infrastructure.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers
{
    /// <summary>
    /// Controller common operations.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected ApiControllerBase(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get origin.
        /// </summary>
        protected string Origin
        {
            get
            {
                try { return Request.Headers["origin"]; } catch { return String.Empty; }
            }
        }

        /// <summary>
        /// Generate ip address.
        /// </summary>
        protected string IpAddress
        {
            get
            {
                if (Request.Headers.ContainsKey("X-Forwarded-For"))
                    return Request.Headers["X-Forwarded-For"];
                else
                {
                    var ipAddress = HttpContext.Connection.RemoteIpAddress;
                    return ipAddress != null ? ipAddress.MapToIPv4().ToString() : throw new ApiException("Ip address not found");
                }
            }
        }
    }

    /// <summary>
    /// Read operations.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class ApiControllerBase<TKey, TResponse> : ApiControllerBase
        where TResponse : class, IDto
    {
        protected ApiControllerBase(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Get entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public virtual async Task<ActionResult<Response<TResponse>>> Get(TKey id, CancellationToken cancellationToken)
        {
            var type = typeof(Query<TResponse, TKey>).GetConcreteTypeFilterSpecificInterface();

            var query = Activator.CreateInstance(type, new object[] { id });
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        public virtual async Task<ActionResult<Response<TResponse[]>>> Get(CancellationToken cancellationToken)
        {
            var type = typeof(TResponse) != typeof(EnumerationDto) ?
                typeof(Query<TResponse[]>).GetConcreteTypeFilterSpecificInterface() :
                typeof(EnumerationQuery<TKey, TResponse[]>).GetConcreteTypeFilterSpecificInterface();

            var query = Activator.CreateInstance(type);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }

    /// <summary>
    /// Read operations, filter operations.
    /// </summary>
    /// <typeparam name="TFilterRequest"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TResponseDto"></typeparam>
    /// <typeparam name="TFilterQuery"></typeparam>
    public abstract class ApiSearchFilterControllerBase<TRequest, TResponse> : ApiControllerBase
        where TRequest : class, ISearchFilter, IDto
        where TResponse : class, IDto
    {
        protected ApiSearchFilterControllerBase(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Filter entities.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        public virtual async Task<ActionResult<Response<TResponse>>> Get([FromQuery] TRequest filter, CancellationToken cancellationToken)
        {
            var type = typeof(IQuery<Response<TResponse>>).GetConcreteTypeFilterSpecificInterface(assembly: typeof(Query<>).Assembly);
            var query = Activator.CreateInstance(type);
            _mapper.Map(filter, query);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }


    /// <summary>
    /// Read-Write operations.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TCreateRequest"></typeparam>
    /// <typeparam name="TUpdateRequest"></typeparam>
    [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
    public abstract class ApiControllerBase<TKey, TResponse, TCreateRequest, TUpdateRequest> : ApiControllerBase<TKey, TResponse>
            where TResponse : class, IDto
            where TCreateRequest : class, IDto
            where TUpdateRequest : class, IDto
    {
        protected ApiControllerBase(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Create entity.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost()]
        public virtual async Task<ActionResult<Response<TResponse>>> Post([FromBody] TCreateRequest dto, CancellationToken cancellationToken)
        {
            var type = typeof(Command<TResponse>).GetConcreteTypeFilterSpecificInterface();
            var command = Activator.CreateInstance(type);
            _mapper.Map(dto, command);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut()]
        public virtual async Task<ActionResult<Response<TResponse>>> Put([FromBody] TUpdateRequest dto, CancellationToken cancellationToken)
        {
            var type = typeof(UpdateCommand<TKey, TResponse>).GetConcreteTypeFilterSpecificInterface();
            var command = Activator.CreateInstance(type);
            _mapper.Map(dto, command);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete()]
        public virtual async Task<ActionResult<Response<TResponse>>> Delete([FromBody] TKey id, CancellationToken cancellationToken)
        {
            var type = typeof(Command<TKey, TResponse>).GetConcreteTypeFilterSpecificInterface();
            var command = Activator.CreateInstance(type, new object[] { id });
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }

}

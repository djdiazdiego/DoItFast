using AutoMapper;
using DoItFast.Application.Command;
using DoItFast.Application.Exceptions;
using DoItFast.Application.Extensions;
using DoItFast.Application.Queries;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Abstractions.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers
{
    /// <summary>
    /// Controller common operations
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected ApiControllerBase()
        {
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
    /// Read operations
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class ApiReadControllerBase<TKey, TResponse> : ApiControllerBase
        where TResponse : class, IDto
    {
        protected readonly IMediator _mediator;

        protected ApiReadControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<Response<TResponse>>> Get(TKey id, CancellationToken cancellationToken)
        {
            return await this.BuildGetDeleteAsync<TKey, TResponse>(id, _mediator, typeof(Query<TKey, TResponse>), cancellationToken);
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(), Route("all")]
        public virtual async Task<ActionResult<Response<TResponse[]>>> GetAll(CancellationToken cancellationToken)
        {
            return await this.BuildGetAllAsync<TKey, TResponse>(_mediator, cancellationToken);
        }
    }


    /// <summary>
    /// Filter operations
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TFilterResponse"></typeparam>
    public abstract class ApiFilterControllerBase<TRequest, TResponse, TFilterResponse> : ApiControllerBase
        where TRequest : class, IFilter, IDto
        where TResponse : class, IDto
        where TFilterResponse : class, IFilterResponseDto<TResponse>, IDto
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected ApiFilterControllerBase(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Filter entities.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(), Route("page")]
        public virtual async Task<ActionResult<Response<TFilterResponse>>> Page([FromQuery] TRequest filter, CancellationToken cancellationToken)
        {
            return await this.BuildFilterAsync<TRequest, TResponse, TFilterResponse>(filter, _mapper, _mediator, cancellationToken);
        }
    }

    /// <summary>
    /// Full read operations
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TFilterRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TFilterResponse"></typeparam>
    public abstract class ApiFullReadControllerBase<TKey, TFilterRequest, TResponse, TFilterResponse> : ApiReadControllerBase<TKey, TResponse>
        where TFilterRequest : class, IFilter, IDto
        where TResponse : class, IDto
        where TFilterResponse : class, IFilterResponseDto<TResponse>, IDto
    {
        protected readonly IMapper _mapper;

        protected ApiFullReadControllerBase(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Filter entities.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(), Route("page")]
        public virtual async Task<ActionResult<Response<TFilterResponse>>> Page([FromQuery] TFilterRequest filter, CancellationToken cancellationToken)
        {
            return await this.BuildFilterAsync<TFilterRequest, TResponse, TFilterResponse>(filter, _mapper, _mediator, cancellationToken);
        }
    }

    /// <summary>
    /// Read-Write operations
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TCreateRequest"></typeparam>
    /// <typeparam name="TUpdateRequest"></typeparam>
    public abstract class ApiReadWriteControllerBase<TKey, TResponse, TCreateRequest, TUpdateRequest> : ApiReadControllerBase<TKey, TResponse>
        where TResponse : class, IDto
        where TCreateRequest : class, IDto
        where TUpdateRequest : class, IDto
    {
        protected readonly IMapper _mapper;

        protected ApiReadWriteControllerBase(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost()]
        public virtual async Task<ActionResult<Response<TResponse>>> Post([FromBody] TCreateRequest dto, CancellationToken cancellationToken)
        {
            return await this.BuildPostPutAsync<TCreateRequest, TResponse>(dto, _mapper, _mediator, typeof(Command<TResponse>), cancellationToken);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut()]
        public virtual async Task<ActionResult<Response<TResponse>>> Put([FromBody] TUpdateRequest dto, CancellationToken cancellationToken)
        {
            return await this.BuildPostPutAsync<TUpdateRequest, TResponse>(dto, _mapper, _mediator, typeof(UpdateCommand<TKey, TResponse>), cancellationToken);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete()]
        public virtual async Task<ActionResult<Response<TResponse>>> Delete([FromBody] TKey id, CancellationToken cancellationToken)
        {
            return await this.BuildGetDeleteAsync<TKey, TResponse>(id, _mediator, typeof(Command<TKey, TResponse>), cancellationToken);
        }
    }


    /// <summary>
    /// Full operations
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TCreateRequest"></typeparam>
    /// <typeparam name="TUpdateRequest"></typeparam>
    /// <typeparam name="TFilterRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TFilterResponse"></typeparam>
    public abstract class ApiFullControllerBase<TKey, TCreateRequest, TUpdateRequest, TFilterRequest, TResponse, TFilterResponse> : ApiReadWriteControllerBase<TKey, TResponse, TCreateRequest, TUpdateRequest>
        where TCreateRequest : class, IDto
        where TUpdateRequest : class, IDto
        where TFilterRequest : class, IFilter, IDto
        where TResponse : class, IDto
        where TFilterResponse : class, IFilterResponseDto<TResponse>, IDto
    {
        protected ApiFullControllerBase(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Filter entities.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(), Route("page")]
        public virtual async Task<ActionResult<Response<TFilterResponse>>> Page([FromQuery] TFilterRequest filter, CancellationToken cancellationToken)
        {
            return await this.BuildFilterAsync<TFilterRequest, TResponse, TFilterResponse>(filter, _mapper, _mediator, cancellationToken);
        }
    }
}

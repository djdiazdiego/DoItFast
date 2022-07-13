using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Models.PlanAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PlanTypeController : ApiControllerBase<PlanTypeValues, EnumerationDto>
    {
        public PlanTypeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Get plan type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<EnumerationDto>), StatusCodes.Status200OK)]
        public override Task<ActionResult<Response<EnumerationDto>>> Get(PlanTypeValues id, CancellationToken cancellationToken)
        {
            return base.Get(id, cancellationToken);
        }

        /// <summary>
        /// Get plan types.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<EnumerationDto[]>), StatusCodes.Status200OK)]
        public override Task<ActionResult<Response<EnumerationDto[]>>> Get(CancellationToken cancellationToken)
        {
            return base.Get(cancellationToken);
        }
    }
}

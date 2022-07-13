using AutoMapper;
using DoItFast.Application.Dtos.Plan;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<PlanDto>), StatusCodes.Status200OK)]
    public class PlanController : ApiControllerBase<Guid, PlanDto, CreatePlanDto, UpdatePlanDto>
    {
        public PlanController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Get plan.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<PlanDto>>> Get(Guid id, CancellationToken cancellationToken) => base.Get(id, cancellationToken);

        /// <summary>
        /// Get all plan.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PlanDto[]>), StatusCodes.Status200OK)]
        public override Task<ActionResult<Response<PlanDto[]>>> Get(CancellationToken cancellationToken) => base.Get(cancellationToken);

        /// <summary>
        /// Create plan.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<PlanDto>>> Post([FromBody] CreatePlanDto dto, CancellationToken cancellationToken) => base.Post(dto, cancellationToken);

        /// <summary>
        /// Update plan.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<PlanDto>>> Put([FromBody] UpdatePlanDto dto, CancellationToken cancellationToken) => base.Put(dto, cancellationToken);

        /// <summary>
        /// Delete plan.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<PlanDto>>> Delete([FromBody] Guid id, CancellationToken cancellationToken)=> base.Delete(id, cancellationToken);
    }
}

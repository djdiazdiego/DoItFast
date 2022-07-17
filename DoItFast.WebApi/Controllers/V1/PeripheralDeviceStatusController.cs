using DoItFast.Application.Features.Dtos;
using DoItFast.Application.Features.Queries.PeripheralDeviceStatus;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Models.GatewayAggregate;
using DoItFast.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PeripheralDeviceStatusController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public PeripheralDeviceStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Peripheral Device status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [ProducesResponseType(typeof(Response<EnumerationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<Response<EnumerationDto>>> Get(PeripheralDeviceStatusValues id, CancellationToken cancellationToken) =>
            await this.BuildGetDeleteAsync<PeripheralDeviceStatusValues, EnumerationDto>(id, _mediator, typeof(PeripheralDeviceStatusGetQuery), cancellationToken);

        /// <summary>
        /// Get Peripheral Devices status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        [ProducesResponseType(typeof(Response<EnumerationDto[]>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<EnumerationDto[]>>> GetAll(CancellationToken cancellationToken) =>
            await this.BuildGetAllAsync<PeripheralDeviceStatusValues, EnumerationDto>(_mediator, cancellationToken);
    }
}

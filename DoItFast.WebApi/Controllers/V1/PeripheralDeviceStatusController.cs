using DoItFast.Application.Features.Dtos;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Models.GatewayAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PeripheralDeviceStatusController : ApiReadControllerBase<PeripheralDeviceStatusValues, EnumerationDto>
    {
        public PeripheralDeviceStatusController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get Peripheral Device status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<EnumerationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override async Task<ActionResult<Response<EnumerationDto>>> Get(PeripheralDeviceStatusValues id, CancellationToken cancellationToken) =>
            await base.Get(id, cancellationToken);

        /// <summary>
        /// Get Peripheral Devices status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<EnumerationDto[]>), StatusCodes.Status200OK)]
        public override async Task<ActionResult<Response<EnumerationDto[]>>> GetAll(CancellationToken cancellationToken) =>
            await base.GetAll(cancellationToken);
    }
}

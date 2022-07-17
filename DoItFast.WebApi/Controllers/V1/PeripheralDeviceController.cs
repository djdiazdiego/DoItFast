using AutoMapper;
using DoItFast.Application.Features.Dtos.Gateway;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PeripheralDeviceController : ApiFilterControllerBase<PeripheralDeviceFilterRequestDto, PeripheralDeviceWithGatewayResponseDto, PeripheralDeviceFilterResponseDto>
    {
        public PeripheralDeviceController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Search Peripheral Devices
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PeripheralDeviceFilterResponseDto>), StatusCodes.Status200OK)]
        public override async Task<ActionResult<Response<PeripheralDeviceFilterResponseDto>>> Page([FromQuery] PeripheralDeviceFilterRequestDto filter, CancellationToken cancellationToken)
        {
            return await base.Page(filter, cancellationToken);
        }
    }
}

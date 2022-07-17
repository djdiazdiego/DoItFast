using AutoMapper;
using DoItFast.Application.Extensions;
using DoItFast.Application.Features.Dtos.Gateway;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PeripheralDeviceController : ApiControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public PeripheralDeviceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Search Peripheral Devices
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet, Route("page")]
        [ProducesResponseType(typeof(Response<PeripheralDeviceFilterResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<PeripheralDeviceFilterResponseDto>>> Page([FromQuery] PeripheralDeviceFilterRequestDto filter, CancellationToken cancellationToken) =>
            await this.BuildFilterAsync<PeripheralDeviceFilterRequestDto, PeripheralDeviceWithGatewayResponseDto, PeripheralDeviceFilterResponseDto>(filter, _mapper, _mediator, cancellationToken);
    }
}

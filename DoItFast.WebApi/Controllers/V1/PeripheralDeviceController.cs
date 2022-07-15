using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PeripheralDeviceController : ApiFullReadControllerBase<Guid, PeripheralDeviceFilterRequestDto, PeripheralDeviceResponseDto, PeripheralDeviceFilterResponseDto>
    {
        public PeripheralDeviceController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Get Peripheral Device
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PeripheralDeviceResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override Task<ActionResult<Response<PeripheralDeviceResponseDto>>> Get(Guid id, CancellationToken cancellationToken)
        {
            return base.Get(id, cancellationToken);
        }

        /// <summary>
        /// Get Peripheral Devices
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PeripheralDeviceResponseDto[]>), StatusCodes.Status200OK)]
        public override Task<ActionResult<Response<PeripheralDeviceResponseDto[]>>> GetAll(CancellationToken cancellationToken)
        {
            return base.GetAll(cancellationToken);
        }

        /// <summary>
        /// Search Peripheral Devices
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PeripheralDeviceFilterResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override Task<ActionResult<Response<PeripheralDeviceFilterResponseDto>>> Page([FromQuery] PeripheralDeviceFilterRequestDto filter, CancellationToken cancellationToken)
        {
            return base.Page(filter, cancellationToken);
        }
    }
}

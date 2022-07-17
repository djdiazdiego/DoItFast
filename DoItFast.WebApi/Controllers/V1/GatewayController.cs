using AutoMapper;
using DoItFast.Application.Extensions;
using DoItFast.Application.Features.Command.Gateway;
using DoItFast.Application.Features.Dtos.Gateway;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class GatewayController : ApiFullControllerBase<string, GatewayCreateRequestDto, GatewayUpdateRequestDto, GatewayFilterRequestDto, GatewayResponseDto, GatewayFilterResponseDto>
    {
        public GatewayController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Search Gateways
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<GatewayFilterResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override async Task<ActionResult<Response<GatewayFilterResponseDto>>> Page([FromQuery] GatewayFilterRequestDto filter, CancellationToken cancellationToken)
        {
            return await base.Page(filter, cancellationToken);
        }

        /// <summary>
        /// Create Gateway
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<GatewayResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override async Task<ActionResult<Response<GatewayResponseDto>>> Post([FromBody] GatewayCreateRequestDto dto, CancellationToken cancellationToken)
        {
            return await base.Post(dto, cancellationToken);
        }

        /// <summary>
        /// Update Gateway
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<GatewayResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override async Task<ActionResult<Response<GatewayResponseDto>>> Put([FromBody] GatewayUpdateRequestDto dto, CancellationToken cancellationToken)
        {
            return await base.Put(dto, cancellationToken);
        }

        /// <summary>
        /// Delete Gateway
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<GatewayResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public override async Task<ActionResult<Response<GatewayResponseDto>>> Delete([FromBody] string id, CancellationToken cancellationToken)
        {
            return await base.Delete(id, cancellationToken);
        }

        /// <summary>
        /// Update Peripheral Device
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("update-device")]
        [ProducesResponseType(typeof(Response<PeripheralDeviceResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<Response<PeripheralDeviceResponseDto>>> UpdatePeripheralDevice([FromBody] GatewayUpdatePeripheralDeviceRequestDto dto, CancellationToken cancellationToken)
        {
            return await this.BuildGenericAsync<GatewayUpdatePeripheralDeviceRequestDto, PeripheralDeviceResponseDto>(dto, _mapper, _mediator, typeof(GatewayUpdatePeripheralDeviceCommand), cancellationToken);
        }

        /// <summary>
        /// Delete Peripheral Device
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete-device")]
        [ProducesResponseType(typeof(Response<PeripheralDeviceResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<Response<PeripheralDeviceResponseDto>>> DeletePeripheralDevice([FromBody] GatewayDeletePeripheralDeviceRequestDto dto, CancellationToken cancellationToken)
        {
            return await this.BuildGenericAsync<GatewayDeletePeripheralDeviceRequestDto, PeripheralDeviceResponseDto>(dto, _mapper, _mediator, typeof(GatewayDeletePeripheralDeviceCommand), cancellationToken);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<Response<GatewayResponseDto>>> Get(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<Response<GatewayResponseDto[]>>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PeripheralDevice
{
    public class PeripheralDeviceGetQueryHandler : GetQueryHandler<Domain.Models.GatewayAggregate.PeripheralDevice, PeripheralDeviceResponseDto, PeripheralDeviceGetQuery>
    {
        public PeripheralDeviceGetQueryHandler(IQueryRepository<Domain.Models.GatewayAggregate.PeripheralDevice> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

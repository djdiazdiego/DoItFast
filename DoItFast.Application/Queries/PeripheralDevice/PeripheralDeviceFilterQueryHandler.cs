using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PeripheralDevice
{
    public class PeripheralDeviceFilterQueryHandler : FilterQueryHandler<Domain.Models.GatewayAggregate.PeripheralDevice, PeripheralDeviceFilterResponseDto, PeripheralDeviceResponseDto, PeripheralDeviceFilterQuery>
    {
        public PeripheralDeviceFilterQueryHandler(IQueryRepository<Domain.Models.GatewayAggregate.PeripheralDevice> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

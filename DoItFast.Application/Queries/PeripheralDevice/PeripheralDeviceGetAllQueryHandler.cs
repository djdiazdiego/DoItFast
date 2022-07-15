using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PeripheralDevice
{
    public class PeripheralDeviceGetAllQueryHandler : GetAllQueryHandler<Domain.Models.GatewayAggregate.PeripheralDevice, PeripheralDeviceResponseDto, PeripheralDeviceGetAllQuery>
    {
        public PeripheralDeviceGetAllQueryHandler(IQueryRepository<Domain.Models.GatewayAggregate.PeripheralDevice> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

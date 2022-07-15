using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PeripheralDeviceStatus
{
    public class PeripheralDeviceStatusGetAllQueryHandler : GetAllQueryHandler<Domain.Models.GatewayAggregate.PeripheralDeviceStatus, EnumerationDto, PeripheralDeviceStatusGetAllQuery>
    {
        public PeripheralDeviceStatusGetAllQueryHandler(IQueryRepository<Domain.Models.GatewayAggregate.PeripheralDeviceStatus> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

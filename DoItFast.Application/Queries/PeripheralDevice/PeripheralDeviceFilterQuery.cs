using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PeripheralDevice
{
    public class PeripheralDeviceFilterQuery : FilterQuery<PeripheralDeviceFilterResponseDto, PeripheralDeviceResponseDto, Domain.Models.GatewayAggregate.PeripheralDevice>
    {
        public override IQueryable<IEntity> BuildFilter(IQueryRepository<Domain.Models.GatewayAggregate.PeripheralDevice> queryRepository)
        {
            var query = queryRepository.FindAll();

            return query;
        }
    }


}

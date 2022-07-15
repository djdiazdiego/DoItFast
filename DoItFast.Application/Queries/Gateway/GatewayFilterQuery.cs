using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DoItFast.Application.Queries.Gateway
{
    public class GatewayFilterQuery : FilterQuery<GatewayFilterResponseDto, GatewayResponseDto, Domain.Models.GatewayAggregate.Gateway>
    {
        public override IQueryable<IEntity> BuildFilter(IQueryRepository<Domain.Models.GatewayAggregate.Gateway> queryRepository)
        {
            var query = queryRepository.FindAll().Include(p => p.PeripheralDevices);

            return query;
        }
    }


}

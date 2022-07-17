using DoItFast.Application.Features.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DoItFast.Application.Features.Queries.Gateway
{
    public class GatewayFilterQuery : FilterQuery<GatewayFilterResponseDto, GatewayResponseDto,
        Domain.Models.GatewayAggregate.Gateway>
    {
        public override IQueryable<Domain.Models.GatewayAggregate.Gateway> BuildFilter(IQueryRepository<Domain.Models.GatewayAggregate.Gateway> queryRepository)
        {
            var query = queryRepository.FindAll().Include(p => p.PeripheralDevices);

            return query;
        }
    }


}

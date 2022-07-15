using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Gateway
{
    public class GatewayFilterQueryHandler : FilterQueryHandler<Domain.Models.GatewayAggregate.Gateway, GatewayFilterResponseDto, GatewayResponseDto, GatewayFilterQuery>
    {
        public GatewayFilterQueryHandler(IQueryRepository<Domain.Models.GatewayAggregate.Gateway> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

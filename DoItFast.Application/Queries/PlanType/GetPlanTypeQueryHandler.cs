using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PlanType
{
    public class GetPlanTypeQueryHandler : GetQueryHandler<Domain.Models.PlanAggregate.PlanType, EnumerationDto, GetPlanTypeQuery>
    {
        public GetPlanTypeQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.PlanType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

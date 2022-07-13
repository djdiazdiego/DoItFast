using AutoMapper;
using DoItFast.Application.Dtos.Plan;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Plan
{
    public class GetPlanQueryHandler : GetQueryHandler<Domain.Models.PlanAggregate.Plan, PlanDto, GetPlanQuery>
    {
        public GetPlanQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.Plan> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

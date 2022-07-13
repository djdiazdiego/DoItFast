using AutoMapper;
using DoItFast.Application.Dtos.Plan;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Plan
{
    public class GetAllPlanQueryHandler : GetAllQueryHandler<Domain.Models.PlanAggregate.Plan, PlanDto, GetAllPlanQuery>
    {
        public GetAllPlanQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.Plan> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

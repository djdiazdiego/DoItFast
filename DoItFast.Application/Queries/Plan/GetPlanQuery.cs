using DoItFast.Application.Dtos.Plan;

namespace DoItFast.Application.Queries.Plan
{
    public class GetPlanQuery : Query<PlanDto, Guid>
    {
        public GetPlanQuery(Guid id) : base(id)
        {
        }
    }
}

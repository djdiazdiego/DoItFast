using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.PlanType
{
    public class GetPlanTypeQuery : Query<EnumerationDto, PlanTypeValues>
    {
        public GetPlanTypeQuery(PlanTypeValues id) : base(id)
        {
        }
    }
}

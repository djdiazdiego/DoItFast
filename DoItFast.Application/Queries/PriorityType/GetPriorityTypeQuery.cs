using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.PriorityType
{
    public class GetPriorityTypeQuery : Query<EnumerationDto, PriorityTypeValues>
    {
        public GetPriorityTypeQuery(PriorityTypeValues id) : base(id)
        {
        }
    }
}

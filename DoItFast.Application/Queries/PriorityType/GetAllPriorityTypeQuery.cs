using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.PriorityType
{
    public class GetAllPriorityTypeQuery : EnumerationQuery<PriorityTypeValues, EnumerationDto[]>
    {
    }
}

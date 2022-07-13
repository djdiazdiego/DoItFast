using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.PlanType
{
    public class GetAllPlanTypeQuery : EnumerationQuery<PlanTypeValues, EnumerationDto[]>
    {
    }
}

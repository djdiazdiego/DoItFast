using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PlanType
{
    public class GetAllPlanTypeQueryHandler : GetAllQueryHandler<Domain.Models.PlanAggregate.PlanType, EnumerationDto, GetAllPlanTypeQuery>
    {
        public GetAllPlanTypeQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.PlanType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

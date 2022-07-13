using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.PriorityType
{
    public class GetPriorityTypeQueryHandler : GetQueryHandler<Domain.Models.PlanAggregate.PriorityType, EnumerationDto, GetPriorityTypeQuery>
    {
        public GetPriorityTypeQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.PriorityType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

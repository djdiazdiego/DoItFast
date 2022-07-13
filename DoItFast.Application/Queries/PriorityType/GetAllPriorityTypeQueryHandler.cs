using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.PriorityType
{
    public class GetAllPriorityTypeQueryHandler : GetAllQueryHandler<Domain.Models.PlanAggregate.PriorityType, EnumerationDto, GetAllPriorityTypeQuery>
    {
        public GetAllPriorityTypeQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.PriorityType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

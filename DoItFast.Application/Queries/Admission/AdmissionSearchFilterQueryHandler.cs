using AutoMapper;
using DoItFast.Application.Dtos.Admission;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Admission
{
    public class AdmissionSearchFilterQueryHandler :
        SearchFilterQueryHandler<Domain.Models.PlanAggregate.Admission, AdmissionFilterResponseDto, AdmissionDto, AdmissionSearchFilterQuery>
    {
        public AdmissionSearchFilterQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.Admission> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

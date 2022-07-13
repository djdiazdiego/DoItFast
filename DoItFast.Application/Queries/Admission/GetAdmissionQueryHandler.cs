using AutoMapper;
using DoItFast.Application.Dtos.Admission;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Admission
{
    public class GetAdmissionQueryHandler : GetQueryHandler<Domain.Models.PlanAggregate.Admission, AdmissionDto, GetAdmissionQuery>
    {
        public GetAdmissionQueryHandler(IQueryRepository<Domain.Models.PlanAggregate.Admission> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

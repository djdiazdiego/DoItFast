using DoItFast.Application.Dtos.Admission;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Queries;

namespace DoItFast.Application.Queries.Admission
{
    public class GetAllAdmissionQueryHandler : IQueryHandler<GetAllAdmissionQuery, Response<AdmissionDto[]>>
    {
        public Task<Response<AdmissionDto[]>> Handle(GetAllAdmissionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

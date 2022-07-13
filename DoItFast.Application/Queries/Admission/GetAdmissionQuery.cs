using DoItFast.Application.Dtos.Admission;

namespace DoItFast.Application.Queries.Admission
{
    public class GetAdmissionQuery : Query<AdmissionDto, Guid>
    {
        public GetAdmissionQuery(Guid id) : base(id)
        {
        }
    }
}

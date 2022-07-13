using DoItFast.Application.Dtos.Admission;
using DoItFast.Application.Wrappers;

namespace DoItFast.Application.Queries.Admission
{
    public class GetAllAdmissionQuery : Query<AdmissionDto[]>
    {
        public Guid PlanId { get; set; }
    }
}

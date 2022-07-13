using DoItFast.Domain.Core.Abstractions.Dtos;

namespace DoItFast.Application.Dtos.Admission
{
    public class AdmissionFilterResponseDto : SearchDto<AdmissionDto>, IDto
    {
        public AdmissionFilterResponseDto(List<AdmissionDto> entities, int total) : base(entities, total)
        {
        }
    }
}

using DoItFast.Domain.Core.Abstractions.Dtos;

namespace DoItFast.Application.Dtos.Gateway
{
    public class PeripheralDeviceFilterResponseDto : FilterResponseDto<PeripheralDeviceResponseDto>, IDto
    {
        public PeripheralDeviceFilterResponseDto(List<PeripheralDeviceResponseDto> entities, int total) : base(entities, total)
        {
        }
    }
}

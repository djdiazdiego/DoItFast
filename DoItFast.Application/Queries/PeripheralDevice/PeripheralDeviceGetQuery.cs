using DoItFast.Application.Dtos.Gateway;

namespace DoItFast.Application.Queries.PeripheralDevice
{
    public class PeripheralDeviceGetQuery : Query<Guid, PeripheralDeviceResponseDto>
    {
        public PeripheralDeviceGetQuery(Guid id) : base(id)
        {
        }
    }
}

using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Queries.PeripheralDeviceStatus
{
    public class PeripheralDeviceStatusGetQuery : Query<PeripheralDeviceStatusValues, EnumerationDto>
    {
        public PeripheralDeviceStatusGetQuery(PeripheralDeviceStatusValues id) : base(id)
        {
        }
    }
}

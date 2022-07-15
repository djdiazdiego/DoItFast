using DoItFast.Application.Dtos;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Queries.PeripheralDeviceStatus
{
    public class PeripheralDeviceStatusGetAllQuery : EnumerationQuery<PeripheralDeviceStatusValues, EnumerationDto[]>
    {
    }
}

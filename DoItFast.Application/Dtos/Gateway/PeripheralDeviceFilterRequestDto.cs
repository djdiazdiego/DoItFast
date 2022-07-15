using DoItFast.Application.Queries.PeripheralDevice;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Dtos.Gateway
{
    [FullMap(typeof(PeripheralDeviceFilterQuery))]
    public class PeripheralDeviceFilterRequestDto : Filter, IDto
    {
       
    }
}



using DoItFast.Application.Queries.Gateway;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Dtos.Gateway
{
    [FullMap(typeof(GatewayFilterQuery))]
    public class GatewayFilterRequestDto : Filter, IDto
    {
       
    }
}



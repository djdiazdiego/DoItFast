using DoItFast.Application.Features.Queries.Gateway;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Features.Dtos.Gateway
{
    [FullMap(typeof(GatewayFilterQuery))]
    public class GatewayFilterRequestDto : Filter, IDto
    {
       
    }
}



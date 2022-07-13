using AutoMapper;
using DoItFast.Application.Dtos.Product;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Domain.Core.Abstractions.Queries;

namespace DoItFast.Application.Queries.Product
{
    public class GetProductQueryHandler : GetQueryHandler<Domain.Models.Product, ProductDto, GetProductQuery>
    {
        public GetProductQueryHandler(IQueryRepository<Domain.Models.Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

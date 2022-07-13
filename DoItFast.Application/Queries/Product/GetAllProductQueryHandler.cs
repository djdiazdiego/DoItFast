using AutoMapper;
using DoItFast.Application.Dtos.Product;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Queries.Product
{
    public class GetAllProductQueryHandler : GetAllQueryHandler<Domain.Models.Product, ProductDto, GetAllProductQuery>
    {
        public GetAllProductQueryHandler(IQueryRepository<Domain.Models.Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

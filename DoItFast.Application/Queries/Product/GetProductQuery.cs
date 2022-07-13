using DoItFast.Application.Dtos.Product;

namespace DoItFast.Application.Queries.Product
{
    public class GetProductQuery : Query<ProductDto, Guid>
    {
        public GetProductQuery(Guid id) : base(id)
        {
        }
    }
}

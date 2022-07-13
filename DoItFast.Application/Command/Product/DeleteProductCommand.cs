using DoItFast.Application.Dtos.Product;

namespace DoItFast.Application.Command.Product
{
    public class DeleteProductCommand : Command<Guid, ProductDto>
    {
        public DeleteProductCommand(Guid id) : base(id)
        {
        }
    }
}

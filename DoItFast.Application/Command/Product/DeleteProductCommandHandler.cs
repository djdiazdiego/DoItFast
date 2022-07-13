using AutoMapper;
using DoItFast.Application.Dtos.Product;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Product
{
    public class DeleteProductCommandHandler : DeleteCommandHandler<Domain.Models.Product, ProductDto, DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IRepository<Domain.Models.Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

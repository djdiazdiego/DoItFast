using AutoMapper;
using DoItFast.Application.Dtos.Product;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Product
{
    public class CreateProductCommandHandler : CreateCommandHandler<Domain.Models.Product, ProductDto, CreateProductCommand>
    {
        public CreateProductCommandHandler(IRepository<Domain.Models.Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

using AutoMapper;
using DoItFast.Application.Dtos.Product;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Product
{
    public class UpdateProductCommandHandler : UpdateCommandHandler<Domain.Models.Product, ProductDto, UpdateProductCommand>
    {
        public UpdateProductCommandHandler(IRepository<Domain.Models.Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

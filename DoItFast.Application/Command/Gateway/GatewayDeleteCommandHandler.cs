using AutoMapper;
using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Gateway
{
    public class GatewayDeleteCommandHandler : DeleteCommandHandler<Domain.Models.GatewayAggregate.Gateway, GatewayResponseDto, GatewayDeleteCommand>
    {
        public GatewayDeleteCommandHandler(IRepository<Domain.Models.GatewayAggregate.Gateway> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

using AutoMapper;
using DoItFast.Application.Dtos.Plan;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Plan
{
    public class CreatePlanCommandHandler : CreateCommandHandler<Domain.Models.PlanAggregate.Plan, PlanDto, CreatePlanCommand>
    {
        public CreatePlanCommandHandler(IRepository<Domain.Models.PlanAggregate.Plan> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

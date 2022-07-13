using AutoMapper;
using DoItFast.Application.Dtos.Plan;
using DoItFast.Domain.Core.Abstractions.Persistence;

namespace DoItFast.Application.Command.Plan
{
    public class UpdatePlanCommandHandler : UpdateCommandHandler<Domain.Models.PlanAggregate.Plan, PlanDto, UpdatePlanCommand>
    {
        public UpdatePlanCommandHandler(IRepository<Domain.Models.PlanAggregate.Plan> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}

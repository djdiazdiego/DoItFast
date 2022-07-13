using DoItFast.Application.Dtos.Plan;

namespace DoItFast.Application.Command.Plan
{
    public class DeletePlanCommand : Command<Guid, PlanDto>
    {
        public DeletePlanCommand(Guid id) : base(id)
        {
        }
    }
}

using DoItFast.Application.Command.Plan;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Dtos.Plan
{
    [FullMap(typeof(Domain.Models.PlanAggregate.Plan), ReverseMap = true)]
    public class PlanDto : IDto
    {
        /// <summary>
        /// Plan identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Plan name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Plan type.
        /// </summary>
        public PlanTypeValues PlanTypeId { get; set; }

        /// <summary>
        /// Budget plan.
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// Planning start date.
        /// </summary>
        public DateTime PlanningStartDate { get; set; }

        /// <summary>
        /// Planning end date.
        /// </summary>
        public DateTime PlanningEndDate { get; set; }
    }
}

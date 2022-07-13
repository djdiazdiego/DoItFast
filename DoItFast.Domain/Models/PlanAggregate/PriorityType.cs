using DoItFast.Domain.Core.Abstractions.Entities;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using System;

namespace DoItFast.Domain.Models.PlanAggregate
{
    /// <summary>
    /// Priority seed.
    /// </summary>
    public class PriorityType : Enumeration<PriorityTypeValues, Guid?>, INotRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public PriorityType() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priorityTypeId"></param>
        /// <param name="name"></param>
        public PriorityType(PriorityTypeValues priorityTypeId, string name) : base(priorityTypeId, name) { }
    }
}

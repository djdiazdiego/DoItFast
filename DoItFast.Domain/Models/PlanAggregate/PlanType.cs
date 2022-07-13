using DoItFast.Domain.Core.Abstractions.Entities;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using System;

namespace DoItFast.Domain.Models.PlanAggregate
{
    /// <summary>
    /// Plan seed.
    /// </summary>
    public class PlanType : Enumeration<PlanTypeValues, Guid?>, INotRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public PlanType() : base() { }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="planTypeId"></param>
        /// <param name="name"></param>
        public PlanType(PlanTypeValues planTypeId, string name) : base(planTypeId, name) { }
    }
}

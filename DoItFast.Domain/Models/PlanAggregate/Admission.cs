using DoItFast.Domain.Core.Abstractions.Entities;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoItFast.Domain.Models.PlanAggregate
{
    public class Admission : Entity<Guid, Guid?>, INotRepository
    {
        /// <summary>
        /// Amount of a product to be entered.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Admission description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Priority type reference.
        /// </summary>
        public PriorityTypeValues PriorityTypeId { get; set; }

        /// <summary>
        /// Admission date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Product reference.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Full product price.
        /// </summary>
        public decimal TotalPrice { get { return Amount * Price; } set { } }

        #region navigation properties

        /// <summary>
        /// Product navigation reference.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// PriorityType navigation reference.
        /// </summary>
        public PriorityType PriorityType { get; set; }

        #endregion
    }
}

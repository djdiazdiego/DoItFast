using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Dtos.Admission
{
    public class AdmissionDto : IDto
    {
        /// <summary>
        /// Admission identifier.
        /// </summary>
        public Guid Id { get; set; }

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
        public decimal TotalPrice => this.Amount * Price;
    }
}

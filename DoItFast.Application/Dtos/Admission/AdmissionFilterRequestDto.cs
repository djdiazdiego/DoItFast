using DoItFast.Application.Queries.Admission;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Dtos.Admission
{
    [FullMap(typeof(AdmissionSearchFilterQuery))]
    public class AdmissionFilterRequestDto : SearchFilter, IDto
    {
        /// <summary>
        /// Max amount of a product to be entered.
        /// </summary>
        public int? AmountMax { get; set; }

        /// <summary>
        /// Min amount of a product to be entered.
        /// </summary>
        public int? AmountMin { get; set; }

        /// <summary>
        /// Max product price.
        /// </summary>
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Min product price.
        /// </summary>
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// Priority type reference.
        /// </summary>
        public PriorityTypeValues[]? PriorityTypeIds { get; set; }

        /// <summary>
        /// Max admission date.
        /// </summary>
        public DateTime? DateMax { get; set; }

        /// <summary>
        /// Min admission date.
        /// </summary>
        public DateTime? DateMin { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Max full product price.
        /// </summary>
        public decimal? TotalPriceMax { get; set; }

        /// <summary>
        /// Min full product price.
        /// </summary>
        public decimal? TotalPriceMin { get; set; }
    }
}



using DoItFast.Application.Dtos.Admission;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Queries.Admission
{
    public class AdmissionSearchFilterQuery : SearchFilterQuery<AdmissionFilterResponseDto, AdmissionDto, Domain.Models.PlanAggregate.Admission>
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

        public override IQueryable<IEntity> BuildFilter(IQueryRepository<Domain.Models.PlanAggregate.Admission> queryRepository)
        {
            var query = queryRepository.FindAll();

            if (AmountMin != null)
                query = query.Where(p => p.Amount >= AmountMin);
            if (AmountMax != null)
                query = query.Where(p => p.Amount <= AmountMin);
            if (PriceMin != null)
                query = query.Where(p => p.Price >= PriceMin);
            if (PriceMax != null)
                query = query.Where(p => p.Price <= PriceMax);
            if (PriorityTypeIds != null && PriorityTypeIds.Any())
                query = query.Where(p => PriorityTypeIds.Contains(p.PriorityTypeId));
            if (DateMin.HasValue)
                query = query.Where(p => p.Date.Date >= DateMin.Value.Date);
            if (DateMax.HasValue)
                query = query.Where(p => p.Date.Date <= DateMax.Value.Date);
            if (!string.IsNullOrEmpty(ProductName))
            {
                //var name = ProductName.Trim().RemoveAccent().ToUpper();
                var name = ProductName.Trim().ToUpper();
                query = query.Where(p => p.Product.Name.ToUpper().Contains(name));
            }
            if (TotalPriceMin != null)
                query = query.Where(p => p.TotalPrice >= TotalPriceMin);
            if (TotalPriceMax != null)
                query = query.Where(p => p.TotalPrice <= TotalPriceMax);

            return query;
        }
    }


}

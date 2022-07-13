using DoItFast.Domain.Core.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DoItFast.Domain.Models.PlanAggregate
{
    public class Plan : AggregateRoot<Guid, Guid?>
    {
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

        /// <summary>
        /// Spent budget.
        /// </summary>
        [NotMapped]
        public decimal SpentBudget => Admissions != null && Admissions.Any() ? Admissions.Sum(p => p.TotalPrice) : 0;

        /// <summary>
        /// Remaining budget.
        /// </summary>
        [NotMapped]
        public decimal RemainingBudget => Budget - SpentBudget;

        #region navigation properties
        /// <summary>
        /// Admissions navigation reference.
        /// </summary>
        public List<Admission> Admissions { get; set; }

        /// <summary>
        /// Plan type navigation reference.
        /// </summary>
        public PlanType PlanType { get; set; }

        #endregion

        /// <summary>
        /// Add addmission.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="productId"></param>
        /// <param name="priorityTypeId"></param>
        public void AddAdmission(int amount, decimal price, DateTime date, string description, Guid productId, PriorityTypeValues priorityTypeId)
        {
            if (Admissions == null)
                Admissions = new List<Admission>();

            var admission = new Admission
            {
                Amount = amount,
                Price = price,
                Date = date,
                Description = description,
                ProductId = productId,
                PriorityTypeId = priorityTypeId
            };

            Admissions.Add(admission);
        }

        /// <summary>
        /// Update addmission.
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="productId"></param>
        /// <param name="priorityTypeId"></param>
        public void UpdateAdmission(
            Guid admissionId,
            int amount,
            decimal price,
            DateTime date,
            string description,
            Guid productId,
            PriorityTypeValues priorityTypeId)
        {
            var index = Admissions.FindIndex(p => p.Id == admissionId);

            Admissions[index].Amount = amount;
            Admissions[index].Price = price;
            Admissions[index].Date = date;
            Admissions[index].Description = description;
            Admissions[index].ProductId = productId;
            Admissions[index].PriorityTypeId = priorityTypeId;
        }

        /// <summary>
        /// Delete addmission.
        /// </summary>
        /// <param name="admissionId"></param>
        public void DeleteAdmission(Guid admissionId)
        {
            var index = Admissions.FindIndex(p => p.Id == admissionId);
            Admissions.RemoveAt(index);
        }
    }
}

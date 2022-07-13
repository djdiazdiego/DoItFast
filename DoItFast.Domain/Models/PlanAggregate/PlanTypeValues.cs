using System.ComponentModel;

namespace DoItFast.Domain.Models.PlanAggregate
{
    /// <summary>
    /// Plan type.
    /// </summary>
    public enum PlanTypeValues
    {
        /// <summary>
        /// Daily.
        /// </summary>
        [Description("Daily")]
        Daily = 1,
        /// <summary>
        /// Weekly
        /// </summary>
        [Description("Weekly")]
        Weekly = 2,
        /// <summary>
        /// Monthly
        /// </summary>
        [Description("Monthly")]
        Monthly = 3,
        /// <summary>
        /// Quarterly
        /// </summary>
        [Description("Quarterly")]
        Quarterly = 4,
        /// <summary>
        /// Semi-Annually
        /// </summary>
        [Description("Semi-Annually")]
        Semi_Annually = 5,
        /// <summary>
        /// Yearly
        /// </summary>
        [Description("Yearly")]
        Yearly = 6,
        /// <summary>
        /// Custom
        /// </summary>
        [Description("Custom")]
        Custom = 7
    }
}

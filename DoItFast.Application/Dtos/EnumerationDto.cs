using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.PlanAggregate;

namespace DoItFast.Application.Dtos
{
    [FullMap(typeof(PlanType), ReverseMap = true)]
    [FullMap(typeof(PriorityType), ReverseMap = true)]
    public class EnumerationDto: IDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the field.
        /// </summary>
        public string Name { get; set; }
    }
}

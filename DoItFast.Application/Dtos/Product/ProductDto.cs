using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Dtos.Product
{
    [FullMap(typeof(Domain.Models.Product), ReverseMap = true)]
    public class ProductDto : IDto
    {
        /// <summary>
        /// Product identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product properties.
        /// </summary>
        public List<KeyValuePair<string, string>> Properties { get; set; }
    }
}

using DoItFast.Application.Command.Product;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Dtos.Product
{
    [FullMap(typeof(CreateProductCommand))]
    public class CreateProductDto : IDto
    {
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

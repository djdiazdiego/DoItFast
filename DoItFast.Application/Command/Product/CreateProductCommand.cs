using DoItFast.Application.Dtos.Product;
using DoItFast.Domain.Core.Attributes;

namespace DoItFast.Application.Command.Product
{
    [FullMap(typeof(Domain.Models.Product))]
    public class CreateProductCommand : Command<ProductDto>
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

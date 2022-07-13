using DoItFast.Domain.Core.Abstractions.Entities;
using System;
using System.Collections.Generic;

namespace DoItFast.Domain.Models
{
    public class Product : Entity<Guid, Guid?>
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

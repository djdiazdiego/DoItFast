using System;

namespace DoItFast.Domain.Core.Abstractions.Entities.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEnumeration : IEntity, IComparable
    {
        /// <summary>
        /// Name of the field.
        /// </summary>
        public string Name { get; set; }
    }
}

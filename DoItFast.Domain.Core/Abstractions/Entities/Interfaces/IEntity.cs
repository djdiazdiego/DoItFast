using System;

namespace DoItFast.Domain.Core.Abstractions.Entities.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntity : ICloneable
    {
        /// <summary>
        /// Entity identifier.
        /// </summary>
        object Id { get; }

        /// <summary>
        /// User identifier.
        /// </summary>
        object? UserId { get; }

        /// <summary>
        /// Creation date.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// Modification date.
        /// </summary>
        DateTime? LastModified { get; }

        /// <summary>
        /// Indicate is not initialized yet.
        /// </summary>
        /// <returns></returns>
        bool IsTransient();
    }
}

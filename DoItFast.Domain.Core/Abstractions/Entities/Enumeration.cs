using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DoItFast.Domain.Core.Abstractions.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Enumeration<TKey, TUserKey> : Entity<TKey, TUserKey>, IEnumeration, INotRepository
        where TKey : Enum
    {
        /// <summary>
        /// 
        /// </summary>
        protected Enumeration() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        protected Enumeration(TKey id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj) =>
            obj is Enumeration<TKey, TUserKey> otherValue && GetType().Equals(obj.GetType()) && Id.Equals(otherValue.Id);


        /// <inheritdoc />
        public override int GetHashCode() =>
            this.Id.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => Name;

        /// <inheritdoc />
        public int CompareTo(object other) => Id.CompareTo(((Enumeration<TKey, TUserKey>)other).Id);
    }
}

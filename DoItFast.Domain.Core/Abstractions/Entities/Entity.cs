using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using Force.DeepCloner;
using System;

namespace DoItFast.Domain.Core.Abstractions.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Entity<TKey, TUserKey> : IEntity
    {
        private int? _requestedHashCode;

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TKey Id { get; set; }

        /// <inheritdoc />
        object IEntity.Id => this.Id;

        /// <summary>
        /// User identifier.
        /// </summary>
        public TUserKey UserId { get; set; }

        /// <inheritdoc />
        object? IEntity.UserId
        {
            get
            {
                if ((typeof(TUserKey) == typeof(long) || typeof(TUserKey) == typeof(int) || typeof(TUserKey) == typeof(Guid)) && 
                    this.UserId.Equals(default(TUserKey)))
                    return null;

                return this.UserId;
            }
        }

        /// <inheritdoc />
        public DateTime Created { get; set; }

        /// <inheritdoc />
        public DateTime? LastModified { get; set; }

        /// <inheritdoc />
        public object Clone() => this.DeepClone();

        /// <inheritdoc />
        public bool IsTransient() =>
            (typeof(TKey) == typeof(long) || typeof(TKey) == typeof(int) ||
                typeof(TKey) == typeof(Guid)) &&
            this.Id.Equals(default(TKey));

        /// <inheritdoc />
        public override bool Equals(object obj) =>
            obj != null && obj is Entity<TKey, TUserKey> entity &&
            (ReferenceEquals(this, obj) || (GetType() == obj.GetType() && !entity.IsTransient() &&
                !this.IsTransient() && entity.Id.Equals(Id)));

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (this.IsTransient())
                return base.GetHashCode();

            if (!this._requestedHashCode.HasValue)
                this._requestedHashCode = new int?(this.Id.GetHashCode() ^ 31);

            return this._requestedHashCode.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<TKey, TUserKey> left, Entity<TKey, TUserKey> right) =>
            Object.Equals(left, null) ? Object.Equals(right, null) : left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity<TKey, TUserKey> left, Entity<TKey, TUserKey> right) =>
            !(left == right);
    }
}

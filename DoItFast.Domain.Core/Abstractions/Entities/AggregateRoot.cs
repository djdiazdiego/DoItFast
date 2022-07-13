using MediatR;
using System.Collections.Generic;

namespace DoItFast.Domain.Core.Abstractions.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class AggregateRoot<TKey, TUserKey> : Entity<TKey, TUserKey>, IAggregateRoot
    {
        private readonly List<INotification> _domainEvents;

        /// <summary>
        /// 
        /// </summary>
        protected AggregateRoot() => this._domainEvents = new List<INotification>();

        /// <inheritdoc />
        public void AddDomainEvent(INotification @event) => this._domainEvents.Add(@event);

        /// <inheritdoc />
        public void RemoveDomainEvent(INotification @event) => this._domainEvents.Remove(@event);

        /// <inheritdoc />
        public void ClearDomainEvents() => this._domainEvents.Clear();

        /// <inheritdoc />
        public IReadOnlyCollection<INotification> GetDomainEvents() => this._domainEvents;
    }
}

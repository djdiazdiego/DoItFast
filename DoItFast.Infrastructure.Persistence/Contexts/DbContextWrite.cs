using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Infrastructure.Persistence.Repositories;
using DoItFast.Infrastructure.Shared.Extensions;
using DoItFast.Infrastructure.Shared.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DoItFast.Infrastructure.Persistence.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DbContextWrite : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly ISqlGuidGenerator _sqlGuidGenerator;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="mediator"></param>
        /// <param name="sqlGuidGenerator"></param>
        /// <param name="authenticatedUserService"></param>
        public DbContextWrite(
            [NotNull] DbContextOptions<DbContextWrite> options,
            IMediator mediator,
            ISqlGuidGenerator sqlGuidGenerator,
            IAuthenticatedUserService authenticatedUserService)
            : base(options)
        {
            _mediator = mediator;
            _sqlGuidGenerator = sqlGuidGenerator;
            _authenticatedUserService = authenticatedUserService;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("DoItFast");
            builder.AddEntitiesAndConfiguration(typeof(Repository<>).Assembly);
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //List<INotification> events = new();

            foreach (var entry in ChangeTracker.Entries<IEntity>())
            {
                //if (entry.Entity.GetType()
                //    .GetInterfaces()
                //    .Any(p => p == typeof(IAggregateRoot)))
                //{
                //    var aggregate = (IAggregateRoot)entry.Entity;
                //    events.AddRange(aggregate.GetDomainEvents());
                //    aggregate.ClearDomainEvents();
                //}

                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.GetType()
                            .GetProperty(nameof(IEntity.Created))?
                            .SetValue(entry.Entity, DateTime.UtcNow, null);

                        var id = entry.Entity.GetType().GetProperty(nameof(IEntity.Id))?.GetValue(entry.Entity);
                        if (id == null || id == default)
                            entry.Entity.GetType()
                                .GetProperty(nameof(IEntity.Id))?
                                .SetValue(entry.Entity, _sqlGuidGenerator.NewGuid(), null);

                        entry.Entity.GetType()
                            .GetProperty(nameof(IEntity.UserId))?
                            .SetValue(entry.Entity, _authenticatedUserService.UserId, null);
                        break;
                    case EntityState.Modified:
                        entry.Entity.GetType()
                            .GetProperty(nameof(IEntity.LastModified))?
                            .SetValue(entry.Entity, DateTime.UtcNow, null);
                        entry.Entity.GetType()
                           .GetProperty(nameof(IEntity.UserId))?
                           .SetValue(entry.Entity, _authenticatedUserService.UserId, null);
                        break;
                }
            }

            //foreach (var @event in events)
            //    await _mediator.Publish(@event, cancellationToken);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

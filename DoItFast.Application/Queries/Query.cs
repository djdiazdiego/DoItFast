using DoItFast.Application.Dtos;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Domain.Core.Abstractions.Queries;

namespace DoItFast.Application.Queries
{
    /// <summary>
    /// Base query.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class Query<TResponse> : IQuery<Response<TResponse>>
        where TResponse : class
    {
        protected Query() { }
    }
    /// <summary>
    /// Query with entity identifier.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Query<TResponse, TKey> : IQuery<Response<TResponse>>
        where TResponse : class, IDto
    {
        protected Query(TKey id)
        {
            Id = id;
        }

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TKey Id { get; set; }
    }

    /// <summary>
    /// Base query.
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class EnumerationQuery<Tkey, TResponse> : IQuery<Response<TResponse>>
             where TResponse : class
    {
        protected EnumerationQuery() { }
    }

    /// <summary>
    /// Query with entity filter.
    /// </summary>
    /// <typeparam name="TFilter"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class SearchFilterQuery<TResponse, TDto, TModel> : SearchFilter, IQuery<Response<TResponse>>
        where TResponse : class, ISearchDto<TDto>
        where TDto : class, IDto
        where TModel : class, IEntity
    {
        /// <summary>
        /// To build filter.
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<IEntity> BuildFilter(IQueryRepository<TModel> queryRepository);
    }
}

using AutoMapper;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;
using DoItFast.Domain.Core.Abstractions.Persistence;
using DoItFast.Domain.Core.Abstractions.Queries;
using DoItFast.Domain.Core.Abstractions.Wrappers;
using DoItFast.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace DoItFast.Application.Queries
{
    public abstract class GetQueryHandler<TModel, TResponse, TGetQuery> : IQueryHandler<TGetQuery, Response<TResponse>>
        where TModel : class, IEntity
        where TResponse : class, IDto
        where TGetQuery : class, IQuery<Response<TResponse>>
    {
        private readonly IQueryRepository<TModel> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public GetQueryHandler(IQueryRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<TResponse>> Handle(TGetQuery request, CancellationToken cancellationToken)
        {
            var id = request.GetType().GetProperty("Id")?.GetValue(request, null);
            var entity = await _repository.FindAsync(new object[] { id }, cancellationToken);
            var entityDto = _mapper.Map<TResponse>(entity);
            return new Response<TResponse>(entityDto);
        }
    }

    public abstract class GetAllQueryHandler<TModel, TResponse, TGetAllQuery> : IQueryHandler<TGetAllQuery, Response<TResponse[]>>
          where TModel : class, IEntity
          where TResponse : class, IDto
          where TGetAllQuery : class, IQuery<Response<TResponse[]>>
    {
        private readonly IQueryRepository<TModel> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public GetAllQueryHandler(IQueryRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<TResponse[]>> Handle(TGetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.FindAll()
               .ToArrayAsync(cancellationToken);
            var entitiesDto = _mapper.Map<TResponse[]>(entities);
            return new Response<TResponse[]>(entitiesDto);
        }
    }

    public abstract class SearchFilterQueryHandler<TModel, TResponse, TDto, TFilterQuery> : IQueryHandler<TFilterQuery, Response<TResponse>>
        where TModel : class, IEntity
        where TResponse : class, ISearchDto<TDto>
        where TDto : class, IDto
        where TFilterQuery : SearchFilterQuery<TResponse, TDto, TModel>, ISearchFilter, IQuery<Response<TResponse>>
    {
        private readonly IQueryRepository<TModel> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public SearchFilterQueryHandler(IQueryRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<TResponse>> Handle(TFilterQuery request, CancellationToken cancellationToken)
        {
            var query = request.BuildFilter(_repository);
            var total = await query.CountAsync();

            ApplyIncludes(query, request.Include);
            ApplyOrder(query, request.Order);
            BuildPagging(query, request.Pagging);

            var entities = await query.ToListAsync(cancellationToken);
            var entitiesDto = _mapper.Map<List<TDto>>(entities);

            var response = Activator.CreateInstance(typeof(TResponse), new object[] { entitiesDto, total }) as TResponse;

            return new Response<TResponse>(response);
        }

        /// <summary>
        /// Apply orders.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="orders"></param>
        private void ApplyOrder(IQueryable<IEntity> query, IOrder? orders)
        {
            if (orders != null && typeof(TModel).GetProperties().Any(p => p.Name == orders.SortBy))
            {
                query = orders.SortOperation == SortOperation.ASC ?
                    query.OrderBy(o => orders.SortBy) :
                    query.OrderByDescending(o => orders.SortBy);
            }
        }

        /// <summary>
        /// Build paginator.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagging"></param>
        private void BuildPagging(IQueryable<IEntity> query, IPagging? pagging)
        {
            var page = 1;
            var pageSize = 10;

            if (pagging != null)
            {
                page = pagging.Page < 1 ? 1 : pagging.Page;
                pageSize = pagging.PageSize < 10 ? 10 : pagging.PageSize;
            }

            query = query.Skip(page - 1 * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Include navigation properties.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        private void ApplyIncludes(IQueryable<IEntity> query, string[]? navProperties)
        {
            if (navProperties != null && navProperties.Any())
            {
                foreach (var navProperty in navProperties)
                {
                    query = query.Include(navProperty);
                }
            }
        }
    }
}

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
    /// <summary>
    /// Get query handler
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TGetQuery"></typeparam>
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

    /// <summary>
    /// Get all query handler
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TGetAllQuery"></typeparam>
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

    /// <summary>
    /// Filter query handler
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TFilterResponse"></typeparam>
    /// <typeparam name="TResponseDto"></typeparam>
    /// <typeparam name="TFilterQuery"></typeparam>
    public abstract class FilterQueryHandler<TModel, TFilterResponse, TResponseDto, TFilterQuery> : IQueryHandler<TFilterQuery, Response<TFilterResponse>>
        where TModel : class, IEntity
        where TFilterResponse : class, IFilterResponseDto<TResponseDto>
        where TResponseDto : class, IDto
        where TFilterQuery : FilterQuery<TFilterResponse, TResponseDto, TModel>, IFilter, IQuery<Response<TFilterResponse>>
    {
        private readonly IQueryRepository<TModel> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public FilterQueryHandler(IQueryRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<TFilterResponse>> Handle(TFilterQuery request, CancellationToken cancellationToken)
        {
            var query = request.BuildFilter(_repository);
            var total = await query.CountAsync(cancellationToken);

            query = ApplyOrder(query, request.Order);
            query = BuildPagging(query, request.Pagging);

            var entities = await query.ToListAsync(cancellationToken);
            var entitiesDto = _mapper.Map<List<TResponseDto>>(entities);

            var response = Activator.CreateInstance(typeof(TFilterResponse), new object[] { entitiesDto, total }) as TFilterResponse;

            return new Response<TFilterResponse>(response);
        }

        /// <summary>
        /// Apply orders.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="orders"></param>
        private IQueryable<IEntity> ApplyOrder(IQueryable<IEntity> query, IOrder orders)
        {
            var sortBy = typeof(TModel).GetProperties().Any(p => p.Name == orders.SortBy) ?
                orders.SortBy : nameof(IEntity.Id);

            return orders.SortOperation == SortOperation.ASC ?
                query.OrderBy(o => sortBy) :
                query.OrderByDescending(o => sortBy);
        }

        /// <summary>
        /// Build paginator.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagging"></param>
        private IQueryable<IEntity> BuildPagging(IQueryable<IEntity> query, IPagging pagging)
        {
            var page = pagging.Page < 1 ? 1 : pagging.Page;
            var pageSize = pagging.PageSize < 10 ? 10 : pagging.PageSize;

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}

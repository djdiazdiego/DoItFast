using DoItFast.Domain.Core.Abstractions.Dtos;

namespace DoItFast.Application.Dtos
{
    public abstract class SearchDto<TDto> : ISearchDto<TDto>
        where TDto : class, IDto
    {
        protected SearchDto(List<TDto> entities, int total)
        {
            Entities = entities;
            Total = total;
        }

        ///<inheritdoc/>
        public int Total { get; set; }

        ///<inheritdoc/>
        public List<TDto> Entities { get; set; }
    }
}

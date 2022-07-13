using System.Collections.Generic;

namespace DoItFast.Domain.Core.Abstractions.Dtos
{
    public interface IDto
    {
    }

    public interface ISearchDto<TResponse> : IDto
       where TResponse : class, IDto
    {

        /// <summary>
        /// Total of records.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Entities list.
        /// </summary>
        public List<TResponse> Entities { get; }
    }
}

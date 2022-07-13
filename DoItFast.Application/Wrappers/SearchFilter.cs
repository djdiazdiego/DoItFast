using DoItFast.Domain.Core.Abstractions.Wrappers;
using DoItFast.Domain.Core.Enums;

namespace DoItFast.Application.Wrappers
{
    ///<inheritdoc/>
    public abstract class SearchFilter : ISearchFilter
    {
        /// <summary>
        /// Data to be include in query.
        /// </summary>
        public string[]? Include { get; set; }
        /// <summary>
        /// Contain page information.
        /// </summary>
        public PaggingModel? Pagging { get; set; }
        /// <summary>
        /// Array of column, the ordenation is in the order on the array.
        /// </summary>
        public ColumnNameModel? Order { get; set; }

        IPagging? ISearchFilter.Pagging => Pagging;

        IOrder? ISearchFilter.Order => Order;

        ///<inheritdoc/>
        public class PaggingModel : IPagging
        {
            ///<inheritdoc/>
            public int Page { get; set; }

            ///<inheritdoc/>
            public int PageSize { get; set; }
        }

        ///<inheritdoc/>
        public class ColumnNameModel : IOrder
        {
            ///<inheritdoc/>
            public string SortBy { get; set; }
            ///<inheritdoc/>
            public SortOperation SortOperation { get; set; }
        }
    }
}


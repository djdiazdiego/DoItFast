using DoItFast.Domain.Core.Enums;

namespace DoItFast.Domain.Core.Abstractions.Wrappers
{
    /// <summary>
    /// Search filter for pagination option.
    /// </summary>
    /// <typeparam name="TFilter"></typeparam>
    public interface ISearchFilter
    {
        /// <summary>
        /// Data to be include in query.
        /// </summary>
        public string[]? Include { get; }
        /// <summary>
        /// Page and page size.
        /// </summary>
        public IPagging? Pagging { get; }
        /// <summary>
        /// Column name and how is goint to sorting.
        /// </summary>
        public IOrder? Order { get; }
    }

    /// <summary>
    /// Page and page size.
    /// </summary>
    public interface IPagging
    {
        /// <summary>
        /// Current diplayed page.
        /// </summary>
        public int Page { get; }
        /// <summary>
        /// Amount of element displayed per page.
        /// </summary>
        public int PageSize { get; }
    }

    /// <summary>
    /// Column name and how is goint to sorting.
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Column's name.
        /// </summary>
        public string SortBy { get; }
        /// <summary>
        /// Indicate if is sorting ascending or descending.
        /// Allowed: 
        ///     Ascending -> ASC = 1
        ///     Descending -> DESC =2
        /// </summary>
        public SortOperation SortOperation { get; }
    }
}

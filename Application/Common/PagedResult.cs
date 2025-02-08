namespace Application.Common
{
    public sealed class PagedResult<T>
        where T : class
    {
        public PagedResult(IEnumerable<T> items, int totalCount, int page, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;
        }

        public IEnumerable<T> Items { get; } = Enumerable.Empty<T>();
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;

    }
}

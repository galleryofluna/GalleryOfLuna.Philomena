using System;

namespace GalleryOfLuna.Philomena.Parameters
{
    public record PagingOptions
    {
        public static PagingOptions Default => new PagingOptions();
        
        private readonly int _page;
        public int Page
        {
            get => _page;
            init => _page = value > 0 
                ? value 
                : throw new ArgumentOutOfRangeException(nameof(Page), "Page must be positive");
        }
        
        private readonly int _perPage;
        public int PerPage
        {
            get => _perPage;
            init => _perPage = value > 0 
                ? value 
                : throw new ArgumentOutOfRangeException(nameof(PerPage), "Per page count must be positive");
        }

        public PagingOptions(int page = 1, int perPage = 25)
        {
            Page = page;
            PerPage = perPage;
        }
    }
}
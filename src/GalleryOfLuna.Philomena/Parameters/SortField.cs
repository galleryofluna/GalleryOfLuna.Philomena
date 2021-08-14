namespace GalleryOfLuna.Philomena.Parameters
{
    public static class SortField
    {
        public enum Images
        {
            // This may be a default sorting field
            Id,
            
            // allowed_fields dictionary
            UpdatedAt,
            FirstSeenAt,
            AspectRatio,
            Faves,
            Downvotes,
            Upvotes,
            Width,
            Height,
            Score,
            CommentCount,
            TagCount,
            WilsonScore,
            Pixels,
            Size,
            Duration,
            
            // Internal fields (?)
            Random
            // gallery_id:
        }
    }
}
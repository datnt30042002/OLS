namespace OLS.DTO
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogContent { get; set; }
        public DateTime? PostDate { get; set; }
        public int? Status { get; set; }
        public TimeSpan? ReadTime { get; set; }
        public int BlogTopicBlogTopicId { get; set; }
        public int BlogTagBlogTagId { get; set; }
        public int UserUserId { get; set; }
    }
}

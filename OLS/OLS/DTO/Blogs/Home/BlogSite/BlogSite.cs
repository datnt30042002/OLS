﻿namespace OLS.DTO.Blogs.Home.BlogSite
{
    public class BlogSite
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogContent { get; set; }
        public DateTime? PostDate { get; set; }
        public int? Status { get; set; }
        public TimeSpan? ReadTime { get; set; }
        public string? BlogTag { get; set; }
        public string? BlogTopic { get; set; }
        public string? PosterName { get; set; }
        public string? PosterImage { get; set; }
    }
}

﻿namespace OLS.DTO.Blogs.Home
{
    public class BlogReadHomeDTO
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public DateTime? PostDate { get; set; }
        public TimeSpan? ReadTime { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
    }
}

namespace OLS.DTO.Chapters.Admin
{
    public class ChapterCreateAdminDTO
    {
        public string? ChapterName { get; set; }
        public int Course { get; set; } // Sẽ được add theo CourseId -> khi đó sẽ auto add CourseId theo các chapter của Course
    }
}

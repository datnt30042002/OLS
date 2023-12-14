namespace OLS.DTO.Notes.Home
{
    public class NoteCreateHomeDTO
    {
        public int NoteId { get; set; }
        public string? NoteContent { get; set; }
        public int ChapterChapterId { get; set; }
        public int UserUserId { get; set; }
    }
}

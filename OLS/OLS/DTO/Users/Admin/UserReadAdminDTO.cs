namespace OLS.DTO.Users.Admin
{
    public class UserReadAdminDTO
    {
        public string? Image { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; } // by date of birth
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? UserRole { get; set; }
        public string? Status { get; set; }
    }
}

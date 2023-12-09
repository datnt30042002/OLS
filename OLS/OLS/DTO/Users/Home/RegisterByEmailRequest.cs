using System.ComponentModel.DataAnnotations;

namespace OLS.DTO.Users.Home
{
    public class RegisterByEmailRequest
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}

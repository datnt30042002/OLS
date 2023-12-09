using System.ComponentModel.DataAnnotations;

namespace OLS.DTO.Users.Home
{
    public class ForgotByEmailRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}

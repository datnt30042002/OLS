using System.ComponentModel.DataAnnotations;

namespace OLS.DTO.Users.Home
{
    public class VerifyCodeRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? CodeVerify { get; set; }
    }
}

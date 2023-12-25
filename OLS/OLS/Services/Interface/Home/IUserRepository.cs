using OLS.DTO.Users.Home;

namespace OLS.Services.Interface.Home
{
    public interface IUserRepository
    {
        Task<LoginByEmailRequest> LoginByEmail(string email, string password);
        Task<bool> RegisterByEmail(RegisterByEmailRequest request);
        Task<bool> ForgotByEmail(ForgotByEmailRequest request);
        Task<bool> VerifyCode(VerifyCodeRequest request);
        Task<bool> ResetPassword(ResetPassByEmailRequest request);
    }
}
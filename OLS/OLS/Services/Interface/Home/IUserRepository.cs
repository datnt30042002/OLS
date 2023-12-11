using OLS.DTO.Users.Home;

namespace OLS.Services.Interface.Home
{
    public interface IUserRepository
    {
        Task<string> LoginByEmail(LoginByEmailRequest request);
        Task<bool> RegisterByEmail(RegisterByEmailRequest request);
        Task<bool> ForgotByEmail(ForgotByEmailRequest request);
        Task<bool> VerifyCode(VerifyCodeRequest request);
        Task<bool> ResetPassword(ResetPassByEmailRequest request);
    }
}
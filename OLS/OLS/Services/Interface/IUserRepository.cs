using OLS.DTO.Users;

namespace OLS.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<string> LoginByEmail(LoginByEmailRequest request);
        Task<bool> RegisterByEmail(RegisterByEmailRequest request);
    }
}
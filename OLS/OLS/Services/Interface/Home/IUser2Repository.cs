using OLS.DTO.Users.Home;

namespace OLS.Services.Interface.Home
{
    public interface IUser2Repository
    {
        Task<UserLoginHomeDTO> Login2(string email, string password);
        Task<UserReadHomeDTO> GetUserByUserId(int userId);
    }
}


using OLS.DTO.Courses;
using OLS.DTO.Users.Admin;

namespace OLS.Repositories.Interface.Admin
{
    public interface IUserManagerRepository
    {
        // User manager
        Task<List<UserReadAdminDTO>> GetAllUsers();
        Task<UserReadAdminDTO> GetUserByUserId(int userId);
        Task<List<UserReadAdminDTO>> SearchUserByFullName(string keyword);
        Task<List<UserReadAdminDTO>> FilterUsersByUserRole(string userRole);
        Task<List<UserReadAdminDTO>> FilterUsersByAddress(string address);
        Task<List<UserReadAdminDTO>> FilterUsersByStatus(int status);
        Task<List<UserReadAdminDTO>> GetAllUsersExceptCustomer();
        Task<UserCreateAdminDTO> CreateUserExceptCustomer(UserCreateAdminDTO userCreateAdminDTO);
    }
}

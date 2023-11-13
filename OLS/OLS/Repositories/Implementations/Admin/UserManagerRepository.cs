using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Courses;
using OLS.DTO.Users.Admin;
using OLS.Models;
using OLS.Repositories.Interface.Admin;
using System.Data;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace OLS.Repositories.Implementations.Admin
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public UserManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // List all users
        public async Task<List<UserReadAdminDTO>> GetAllUsers()
        {
            try
            {
                var users = await db.Users.Include(users => users.UserRoleRole).ToListAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(users);

                return userReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get user details by UserID
        public async Task<UserReadAdminDTO> GetUserByUserId(int userId)
        {
            try
            {
                // <Summary>
                // FirstOrDefault trả về phần tử đầu tiên của danh sách,  không quan tâm nếu danh sách đó có trống hay không.
                // SingleOrDefault tương tự, nhưng nó yêu cầu danh sách chỉ chứa duy nhất một phần tử. Nếu danh sách có nhiều hơn một phần tử, nó sẽ ném một Exception 
                // <Summary>
                var user = await db.Users.Where(user => user.UserId == userId).Include(user => user.UserRoleRole).FirstOrDefaultAsync();
                var userReadAdminDTO = mapper.Map<UserReadAdminDTO>(user);

                return userReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Search all user by FullName
        public async Task<List<UserReadAdminDTO>> SearchUserByFullName(string keyword)
        {
            try
            {
                var users = await db.Users.Where(users => users.FullName.Contains(keyword)).Include(users => users.UserRoleRole).ToListAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(users);

                return userReadAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter users by UserRole
        public async Task<List<UserReadAdminDTO>> FilterUsersByUserRole(string userRole)
        {
            try
            {
                var users = await db.Users.Where(users => users.UserRoleRole.RoleName == userRole).Include(users => users.UserRoleRole).ToListAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(users);

                return userReadAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter users by Address
        public async Task<List<UserReadAdminDTO>> FilterUsersByAddress(string address)
        {
            try
            {
                var users = await db.Users.Where(users => users.Address == address).Include(users => users.UserRoleRole).ToArrayAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(users);

                return userReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter users by Status - Ban status
        public async Task<List<UserReadAdminDTO>> FilterUsersByStatus(int status)
        {
            try
            {
                var users = await db.Users.Where(users => users.Status == status).Include(users => users.UserRoleRole).ToListAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(users);

                return userReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get all users all roles except customers
        public async Task<List<UserReadAdminDTO>> GetAllUsersExceptCustomer()
        {
            try
            {
                var usersExceptCustomer = await db.Users.Where(users => users.UserRoleRoleId != 2).Include(users => users.UserRoleRole).ToListAsync();
                var userReadAdminDTO = mapper.Map<List<UserReadAdminDTO>>(usersExceptCustomer);

                return userReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create users have role except customers
        public async Task<UserCreateAdminDTO> CreateUserExceptCustomer(UserCreateAdminDTO userCreateAdminDTO)
        {
            try
            {
                var newUser = mapper.Map<User>(userCreateAdminDTO);
                var createUser = await db.Users.AddAsync(newUser);
                await db.SaveChangesAsync();

                return mapper.Map<UserCreateAdminDTO>(newUser);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Details - Admin Profile


        // Update user by UserID have role != customer
        // Delete user by UserID have role != customer
        // Ban - Status Inactive
        // Up role

        // Get all customers
        // Details
        // Update
        // Delete
        // Ban - Status Inactive



        // <Later functon>
        // Sort when click title of any column
        // Ban user for how long? set time?
        // Pagging
        // <Later function>

        // <Summary>
        // Create new user
        // Img by folder, role combobox??? how to test?
        // Add iếc các thứ, Admin riêng, User riêng!
        // Không thể add người học, chỉ có thể add các roles, và phân chức cho nhân viên
        // Có nên nâng role từ customer lên các role khác không? - không
        // Admin, manager
        // Quyết định, không được phép create user
        // <Summary>
    }
}

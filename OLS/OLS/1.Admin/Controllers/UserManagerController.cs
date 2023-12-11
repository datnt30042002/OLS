using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Courses;
using OLS.DTO.Users.Admin;
using OLS.Services.Implementations.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IUserManagerRepository userManagerRepo;

        public UserManagerController(IUserManagerRepository userManagerRepo)
        {
            this.userManagerRepo = userManagerRepo;
        }

        // Get all users
        [HttpGet("/getAllUsers")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> GetAllUsers()
        {
            try
            {
                var users = await userManagerRepo.GetAllUsers();
                return Ok(users);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get user by UserId
        [HttpGet("/getUserByUserId")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> GetUserByUserId([FromQuery] int userId)
        {
            try
            {
                var user = await userManagerRepo.GetUserByUserId(userId);
                return Ok(user);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Search all users by FullName
        [HttpGet("/searchUsersByFullName")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> SearchUsersByFullName([FromQuery] string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return BadRequest();
                }

                var users = await userManagerRepo.SearchUserByFullName(keyword);
                return Ok(users);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Flter users by UserRole
        [HttpGet("/filterUsersByUserRole")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> FilterUsersByUserRole(string userRole)
        {
            try
            {
                var filteredUsers = await userManagerRepo.FilterUsersByUserRole(userRole);
                return Ok(filteredUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter users by Address
        [HttpGet("/filterUsersByAddress")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> FilterUsersByAddress(string address)
        {
            try
            {
                var filteredUsers = await userManagerRepo.FilterUsersByAddress(address);
                return Ok(filteredUsers);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter users by Status - Ban status
        [HttpGet("/filterUsersByStatus")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> FilterUsersByStatus(string status)
        {
            try
            {
                var conVertStatusToInt = HelperFunctions.HelperFunctions.ConvertStatusToValue(status);
                var filteredUsers = await userManagerRepo.FilterUsersByStatus(int.Parse(conVertStatusToInt));
                return Ok(filteredUsers);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all users all roles except customers
        [HttpGet("/getAllUsersExceptCustomers")]
        public async Task<ActionResult<IEnumerable<UserReadAdminDTO>>> GetAllUsersExceptCustomers()
        {
            try
            {
                var users = await userManagerRepo.GetAllUsersExceptCustomer();
                return users;
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new user have role except customers
        [HttpPost("/createUserExceptCustomer")]
        public async Task<ActionResult<IEnumerable<UserCreateAdminDTO>>> CreateUserExceptCustomer(UserCreateAdminDTO userCreateAdminDTO)
        {
            try
            {
                var user = await userManagerRepo.CreateUserExceptCustomer(userCreateAdminDTO);
                return Ok(user);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

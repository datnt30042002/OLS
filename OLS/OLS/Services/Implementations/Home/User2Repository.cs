using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Users.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class User2Repository : IUser2Repository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public User2Repository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Login 2
        public async Task<UserLoginHomeDTO> Login2(string email, string password)
        {
            try
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    return null;
                }

                if (user.Password == password)
                {
                    var userLoginDTO = mapper.Map<UserLoginHomeDTO>(user);
                    return userLoginDTO;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get user by userId
        public async Task<UserReadHomeDTO> GetUserByUserId(int userId)
        {
            try
            {
                var user = await db.Users.Where(user => user.UserId == userId).FirstOrDefaultAsync();
                var userReadHomeDTO = mapper.Map<UserReadHomeDTO>(user);

                return userReadHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

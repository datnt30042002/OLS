using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    }
}

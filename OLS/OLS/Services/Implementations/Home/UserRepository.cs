using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OLS.DTO.Users;
using OLS.Models;
using OLS.Ultils;
using OLS.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using OLS.DTO.Users.Home;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly OLSContext _context;
        private readonly HashPassMD5 _md5;
        private readonly Mailer _mailer;
        public UserRepository(IMapper mapper, OLSContext context, HashPassMD5 md5, Mailer mailer)
        {
            _mapper = mapper;
            _context = context;
            _md5 = md5;
            _mailer = mailer;
        }

        public async Task<bool> ForgotByEmail(ForgotByEmailRequest request)
        {
            var userMap = _mapper.Map<User>(request);
            var userCheck = await _context.Users.FirstOrDefaultAsync(x => x.Email == userMap.Email);
            if (userCheck == null) { return false; }
            string code = new Random().Next(10000).ToString();
            // update code verify in DB
            userCheck.CodeVerify = code;
            await _context.SaveChangesAsync();

            var _check = await _mailer.Send(userCheck.Email, "Verify Code Check", "Code Verify:" + code);

            if (_check != true) { return false; }
            return true;
        }

        public async Task<string> LoginByEmail(LoginByEmailRequest request)
        {
            var userMap = _mapper.Map<User>(request);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userMap.Email);
            if (user == null) { return null; }
            string hashedPassword = await _md5.MD5Create(request.Password);
            if (hashedPassword != user.Password)
            {
                return null;
            }

            return request.Email;
            //var roles = await _userManager.GetRolesAsync(user);
            //var claims = new[]
            //{
            //     new Claim(ClaimTypes.Email, user.Email),
            //     new Claim(ClaimTypes.Name, user.FullName),
            //     new Claim(ClaimTypes.Role, string.Join(";", roles))
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //var token = new JwtSecurityToken(
            //    _configuration["Tokens:Issuer"],
            //    _configuration["Tokens:Issuer"],
            //    claims,
            //    expires: DateTime.Now.AddHours(3),
            //    signingCredentials: creds);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }




        public async Task<bool> RegisterByEmail(RegisterByEmailRequest request)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                return false;
            }

            var user = _mapper.Map<User>(request);
            user.Password = await _md5.MD5Create(request.Password);
            user.UserRoleRoleId = 2;
            await _context.Users.AddAsync(user);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> VerifyCode(VerifyCodeRequest request)
        {
            var userMap = _mapper.Map<User>(request);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userMap.Email);
            if (user == null)
            {
                return false;
            }

            if (user.CodeVerify != request.CodeVerify)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ResetPassword(ResetPassByEmailRequest request)
        {
            var userMap = _mapper.Map<User>(request);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userMap.Email);
            if (user == null)
            {
                return false;
            }
            if (request.Password != request.RePassword)
            {
                return false;
            }
            user.Password = await _md5.MD5Create(request.Password);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
using System.Text;
using System.Security.Cryptography;

namespace OLS.Ultils
{
    public class HashPassMD5
    {
        public async Task<string> MD5Create(string password)
        {
            string hashedPassword;
            using (var md5 = MD5.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = md5.ComputeHash(passwordBytes);
                hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return hashedPassword;
        }
    }
}

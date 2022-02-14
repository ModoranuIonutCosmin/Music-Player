using System.Security.Cryptography;
using Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Application.Services
{
    public class PasswordHashGenerator : IPasswordHashGenerator
    {
        public const int SaltByteLength = 32;
        public string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes("salt");

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
        }

        public byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rncCsp = new();
            
            byte[] salt = new byte[SaltByteLength];
            rncCsp.GetBytes(salt);

            return salt;
        }
    }
}

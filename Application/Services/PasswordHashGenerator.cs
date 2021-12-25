using Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Application.Services
{
    public class PasswordHashGenerator : IPasswordHashGenerator
    {
        public string HashPassword(string password)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = Encoding.ASCII.GetBytes("n3xts@lt");

            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
        }
    }
}

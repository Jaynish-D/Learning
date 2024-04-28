using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Learning.Utility.PasswordHashServices
{
    public class PasswordHashService : IPasswordHashService
    {
        private readonly IConfiguration _configuration;
        private readonly int Salt = 0;

        public PasswordHashService(IConfiguration configuration)
        {
            _configuration = configuration;

            if (int.TryParse(_configuration["PasswordHash:Salt"], out int salt))
            {
                Salt = salt;
            }
        }

        public string HashPassword(string password)
        {
            var salt = GenerateSalt(Salt);
            string saltString = Convert.ToBase64String(salt);

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var combinedBytes = new byte[passwordBytes.Length + salt.Length];

            Array.Copy(passwordBytes, combinedBytes, passwordBytes.Length);
            Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            using var hmac = new HMACSHA256();

            var hashBytes = hmac.ComputeHash(combinedBytes);
            var hashString = Convert.ToBase64String(hashBytes);

            return $"{saltString}.{hashString}";
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var parts = hashedPassword.Split('.');
            if(parts.Length is not 2)
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[0]);
            var hashedPasswordBytes = Convert.FromBase64String(parts[1]);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[salt.Length + passwordBytes.Length];

            Array.Copy(salt, 0, combinedBytes, 0, salt.Length);
            Array.Copy(passwordBytes, 0, combinedBytes, salt.Length, passwordBytes.Length);

            using var hmac = new HMACSHA256();

            byte[] computedHashBytes = hmac.ComputeHash(combinedBytes);

            return StructuralComparisons
                .StructuralEqualityComparer
                .Equals(computedHashBytes, hashedPasswordBytes);
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            byte[] salt = new byte[saltSize];
            
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            return salt;
        }
    }
}

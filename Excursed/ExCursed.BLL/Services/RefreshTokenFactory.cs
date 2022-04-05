using System;
using System.Security.Cryptography;
using ExCursed.DAL.Interfaces;

namespace ExCursed.BLL.Services
{
    public class RefreshTokenFactory : IRefreshTokenFactory
    {
        public string GenerateRefreshToken()
        {
            const int tokenLengthInBytes = 32;
            var randomNumber = new byte[tokenLengthInBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

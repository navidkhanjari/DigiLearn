using System.Security.Cryptography;
using System.Text;

namespace Common.Application.SecurityUtilities
{
    public static class PasswordHasher
    {
        public static string HashToMd5(string password) //Encrypt using MD5   
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        public static string HashToSha256(string inputValue)
        {
            using var sha256 = SHA256.Create();

            var originalBytes = Encoding.Default.GetBytes(inputValue);

            var encodedBytes = sha256.ComputeHash(originalBytes);

            return Convert.ToBase64String(encodedBytes);
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace Sqlzor.Drivers.Services
{
    public static class MD5
    {
        public static string Calculate(string sourceText)
        {
            var bytes = ASCIIEncoding.ASCII.GetBytes(sourceText);
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(bytes);

            var builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }
}

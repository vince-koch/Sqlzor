using System.Security.Cryptography;
using System.Text;

namespace Sqlzor.DbSchema.Services
{
    public static class MD5
    {
        public static string Calculate(string sourceText)
        {
            var bytes = ASCIIEncoding.ASCII.GetBytes(sourceText);
            var hashBytes = System.Security.Cryptography.MD5.HashData(bytes);

            var builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }
}

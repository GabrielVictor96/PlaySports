using System.Security.Cryptography;
using System.Text;

namespace PlaySports.Domain.Core.Security
{
    public class PasswordEncryptor
    {
        public static string Md5Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            var result = md5.Hash;
            var strBuilder = new StringBuilder();

            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Utils
{
    public class MD5Util
    {
        public static string GetMd5Hash(string input)
        {
            byte[] data;
            StringBuilder sBuilder;
            using (MD5 md5Hash = MD5.Create())
            {
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            return sBuilder.ToString();
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            var inputHash = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(inputHash, hash);
        }
    }
}

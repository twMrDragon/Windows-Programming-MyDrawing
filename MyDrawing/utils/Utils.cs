using System;
using System.Text;

namespace MyDrawing.utils
{
    public class Utils
    {
        static public string GenerateRandomString()
        {
            Random random = new Random();
            int length = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                result.Append(chars[random.Next(chars.Length)]);

            return result.ToString();
        }
    }
}

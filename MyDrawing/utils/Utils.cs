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

        static public double CalculateStringWidth(string content)
        {
            if (string.IsNullOrEmpty(content))
                return 0;
            double eachSize = 7.5;
            return content.Length * eachSize;
        }

        static public double CalculateStringHeight(string content)
        {
            return 15;
        }
    }
}

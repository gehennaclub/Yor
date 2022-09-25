using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Models.Structure
{
    public class Magic
    {
        public static string Get(string path)
        {
            byte[] buffer =
            {
                0,
                0,
                0
            };
            string result = "";
            string hex = "";
            string none = "empty";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            int bytes_read = fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            if (bytes_read != buffer.Length)
            {
                return (none);
            }

            foreach (byte b in buffer)
            {
                hex += $"0x{b.ToString("X")}";
                if (b >= 32 && b <= 126)
                {
                    result += $"{(char)b}";
                } else
                {
                    result += ".";
                }
            }

            return ($"{result} [{hex}]");
        }
    }
}

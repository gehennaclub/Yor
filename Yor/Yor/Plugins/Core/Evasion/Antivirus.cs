using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.Evasion
{
    public class Antivirus
    {
        public static UInt32[] encode(UInt32[] payload)
        {
            List<UInt32> bytes = new List<UInt32>();

            for (int i = 0; i < payload.Length; i++)
            {
                bytes.Add((UInt32)(payload[i] + payload.Length));
            }

            return (bytes.ToArray());
        }

        public static UInt32[] decode(UInt32[] payload)
        {
            List<UInt32> bytes = new List<UInt32>();

            for (int i = 0; i < payload.Length; i++)
            {
                bytes.Add((UInt32)(payload[i] - payload.Length));
            }

            return (bytes.ToArray());
        }
    }
}

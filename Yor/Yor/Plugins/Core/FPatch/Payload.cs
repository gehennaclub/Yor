using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.Fpatch
{
    public class Payload
    {
        public static UInt32[] build(string data)
        {
            UInt32[] payload = new UInt32[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                payload[i] = (UInt32)data[i];
            }

            return (payload);
        }

        public static UInt32[] build(UInt32 character, UInt32 count)
        {
            UInt32[] payload = new UInt32[count];

            for (int i = 0; i < count; i++)
            {
                payload[i] = character;
            }

            return (payload);
        }

        public static UInt32[] build(UInt32 character, UInt32 start, UInt32 end)
        {
            UInt32 value = (end - start);
            UInt32[] payload = new UInt32[value];

            for (int i = 0; i < value; i++)
            {
                payload[i] = character;
            }

            return (payload);
        }
    }
}

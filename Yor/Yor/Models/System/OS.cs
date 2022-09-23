using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Models.System
{
    public class OS
    {
        public enum Version
        {
            x64,
            x86
        }

        public Version version { get; set; }
    }
}

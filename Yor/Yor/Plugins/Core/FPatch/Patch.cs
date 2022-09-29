using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yor.Plugins.Core.Memory;

namespace Yor.Plugins.Core.FPatch
{
    public class Patch
    {
        public enum States
        {
            patched = 0,
            not_patched = 1,
            patch_failed = 2
        };

        public string file { get; set; }
        public States status { get; set; }
        public Address payload { get; set; }
    }
}

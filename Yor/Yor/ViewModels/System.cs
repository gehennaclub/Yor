using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.ViewModels
{
    public class System
    {
        public Models.System.OS os { get; set; }

        public System()
        {
            Initialize();
        }

        private void Initialize()
        {
            os = new Models.System.OS();
        }

        private void Load()
        {
            Version();
        }

        private void Version()
        {
            if (Environment.Is64BitOperatingSystem == true)
            {
                os.version = Models.System.OS.Version.x64;
            } else
            {
                os.version = Models.System.OS.Version.x86;
            }
        }
    }
}

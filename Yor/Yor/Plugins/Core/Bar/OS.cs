using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yor.Models.System;

namespace Yor.Plugins.Core.Bar
{
    public class OS : BasePlugin
    {
        private Models.System.OS os { get; set; }
        public static new string name = "Core.Bar.OS";

        public OS(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            Initialize();
        }

        private async void Initialize()
        {
            os = new Models.System.OS();

            await Load();
        }

        private void _Load()
        {
            logger.Record("loading OS version");
            if (Environment.Is64BitOperatingSystem == true)
            {
                os.version = Models.System.OS.Version.x64;
            }
            else
            {
                os.version = Models.System.OS.Version.x86;
            }
            logger.Record("OS version loaded");
            logger.Force();
        }

        private void _Set()
        {
            mainWindow.os_version.Text = $"{os.version}";
        }

        public override async Task Set()
        {
            await this.Run(_Set);
        }

        public override async Task Load()
        {
            await this.Run(_Load);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.Bar
{
    public class Version : BasePlugin
    {
        public static new string name = "Core.Bar.Version";

        public Version(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
        }

        private void _Set()
        {
            mainWindow.yor_version.Text = $"{Assembly.GetExecutingAssembly().GetName().Version}";
        }

        public async Task Set()
        {
            await this.Run(_Set);
        }
    }
}

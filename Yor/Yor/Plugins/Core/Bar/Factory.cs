using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.Bar
{
    public class Factory : BaseFactory
    {
        private OS os { get; set; }
        private Version version { get; set; }
        private List<BasePlugin> plugins { get; set; }
        public static new string name = "Core.Bar.Factory";

        public Factory(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            Initialize();
        }

        private void Initialize()
        {
            os = new OS(mainWindow, name);
            version = new Version(mainWindow, name);

            plugins = new List<BasePlugin>()
            {
                os,
                version
            };

            Link(plugins);
        }

        public override async Task Set()
        {
            await os.Set();
            await version.Set();
        }

        public override async Task Load()
        {
            await os.Load();
            await version.Load();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core
{
    public abstract class BaseFactory : BasePlugin
    {
        private List<BasePlugin> plugins { get; set; }

        public BaseFactory(MainWindow window, string name) : base(window, name)
        {

        }

        public void Link(List<BasePlugin> plugins)
        {
            this.plugins = plugins;
        }
        
        public BasePlugin Search(string plugin_name)
        {
            foreach (BasePlugin plugin in plugins)
            {
                if (plugin.name == plugin_name)
                    return (plugin);
            }

            return (null);
        }

        public override async Task Load()
        {
            foreach (BasePlugin plugin in plugins)
            {
                await plugin.Load();
            }
        }

        public override async Task Set()
        {
            foreach (BasePlugin plugin in plugins)
            {
                await plugin.Set();
            }
        }
    }
}

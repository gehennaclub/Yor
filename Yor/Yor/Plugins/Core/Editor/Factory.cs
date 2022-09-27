using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.Editor
{
    public class Factory : BaseFactory
    {
        private Edit edit { get; set; }
        private Raw raw { get; set; }
        private List<BasePlugin> plugins { get; set; }
        public static new string name = "Core.Editor.Factory";

        public Factory(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            Initialize();
        }

        private void Initialize()
        {
            edit = new Edit(mainWindow, name);
            raw = new Raw(mainWindow, name);

            plugins = new List<BasePlugin>()
            {
                edit,
                raw
            };

            Link(plugins);
        }

        public override async Task Set()
        {
            await edit.Set();
            await raw.Set();
        }

        public override async Task Load()
        {
            await edit.Load();
            await raw.Load();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yor.Plugins.Core.File;

namespace Yor.Plugins.Core.Editor
{
    internal class Edit : BasePlugin
    {
        public static new string name = "Core.Editor.Edit";

        public Edit(MainWindow mainWindow, string name) : base(mainWindow, name)
        {

        }
    }
}

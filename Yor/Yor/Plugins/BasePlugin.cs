using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins
{
    public abstract class BasePlugin : ViewModels.BaseView
    {
        public BasePlugin(MainWindow mainWindow, string name) : base(mainWindow, name)
        {

        }

        public virtual async Task Load()
        {
            // Function to override by plugin's function
        }

        public virtual async Task Set()
        {
            // Function to override by plugin's function
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Yor.Plugins;

namespace Yor.ViewModels
{
    public class MainViewModel : BaseView
    {
        private MainWindow mainWindow { get; set; }
        public Plugins.Plugins plugins { get; set; }
        private string name { get; set; }

        public MainViewModel(MainWindow window, string name) : base(window, name)
        {
            this.mainWindow = window;
            this.name = name;

            Initialize();
        }

        private void Initialize()
        {
            plugins = new Plugins.Plugins(mainWindow);
        }

        public async Task WindowLoaded()
        {
            await plugins.CoreTreeItems.Load();
            await plugins.CoreBarOs.Set();
        }
    }
}

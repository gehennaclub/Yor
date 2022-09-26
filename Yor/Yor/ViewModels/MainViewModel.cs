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
        private new MainWindow mainWindow { get; set; }
        public Plugins.Plugins plugins { get; set; }
        private new string name { get; set; }
        private Ookii.Dialogs.Wpf.VistaFolderBrowserDialog folderDialog { get; set; }
        private Ookii.Dialogs.Wpf.VistaOpenFileDialog fileDialog { get; set; }
        private Views.SaveEditor saveEditor { get; set; }

        public MainViewModel(MainWindow window, string name) : base(window, name)
        {
            this.mainWindow = window;
            this.name = name;

            Initialize();
        }

        private void Initialize()
        {
            plugins = new Plugins.Plugins(mainWindow);
            folderDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            fileDialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
        }

        public async Task WindowLoaded()
        {
            await plugins.CoreTreeItems.Load();
            await plugins.CoreBarOs.Set();
            await plugins.CoreBarVersion.Set();
        }

        public async Task ClickMenuDirectory()
        {
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath != String.Empty)
            {
                mainWindow.root = folderDialog.SelectedPath;
                await plugins.CoreTreeItems.Load();
            }
        }

        public async Task ClickMenuSavefile()
        {
            fileDialog.ShowDialog();

            if (fileDialog.FileName != String.Empty)
            {
                mainWindow.savefile = fileDialog.FileName;
                saveEditor = new Views.SaveEditor(mainWindow.savefile);
                saveEditor.ShowDialog();
            }
        }
    }
}

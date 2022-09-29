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
        public Plugins.Plugins plugins { get; set; }
        private new MainWindow mainWindow { get; set; }
        private new string name { get; set; }

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

        public async Task ClickItemTreeView()
        {
            await plugins.Editor.raw.Load();
        }

        public async Task WindowLoaded()
        {
            await plugins.CoreTreeItems.Load();
            await plugins.Bar.Set();
        }

        public async Task ClickMenuDirectory()
        {
            if (folderDialog.ShowDialog() == true)
            {
                if (folderDialog.SelectedPath != String.Empty)
                {
                    mainWindow.root = folderDialog.SelectedPath;
                    await plugins.CoreTreeItems.Load();
                }
            }
        }

        public async Task ClickApplyEditor(object sender, RoutedEventArgs e)
        {
            if (mainWindow.TreeDirectory.SelectedItem != null)
            {
                await plugins.Editor.edit.Apply(((Models.TreeView.Item)mainWindow.TreeDirectory.SelectedItem).Path, mainWindow.content.Document);
            }
        }

        public async Task ClickSpoof(object sender, RoutedEventArgs e)
        {
            //await plugins.CoreEditorEdit.Apply(((Models.TreeView.Item)mainWindow.tree.SelectedItem).Path, mainWindow.content.Document);
        }

        public async Task ClickBuild(object sender, RoutedEventArgs e)
        {
            //await plugins.CoreEditorEdit.Apply(((Models.TreeView.Item)mainWindow.tree.SelectedItem).Path, mainWindow.content.Document);
        }
    }
}

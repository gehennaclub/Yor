using AdonisUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yor.ViewModels;
using MessageBox = System.Windows.MessageBox;

namespace Yor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        private List<Thread> threads { get; set; }
        private Thread input { get; set; }
        private ViewModels.Bar bar { get; set; }
        private Models.Logger.Manager logger { get; set; }
        private string root { get; set; }
        private ViewModels.Viewer viewer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            bar = new ViewModels.Bar(os_version);
            logger = new Models.Logger.Manager(log);
            //viewer = new Viewer(new FileInformations(itemType, itemPath, itemFormat, itemMagic), tree, logger, content);
            viewer = new Viewer(new FileInformations(itemType, itemPath, itemFormat), tree, logger, content, contentHex);
            threads = new List<Thread>();
            root = ".";
        }

        private void Build()
        {
            Models.Threads.Manager.Edit(Load);
        }

        private void Load()
        {
            logger.Record("Searching for game files");
            List<Models.TreeView.Item> items = Models.Structure.Manager.Build(root);
            logger.Record($"Total files found: '{items.Count()}'");

            if (tree.Items.Count > 0)
            {
                tree.Items.Clear();
            }
            bar.Refresh();
            foreach (Models.TreeView.Item item in items)
            {
                logger.Record($"File found: '{item.Name}'");
                tree.Items.Add(item);
            }
            logger.Force();
            logger.Record("Done");
        }

        private void Viewer()
        {
            viewer.Set();
        }

        private async Task Queue(ThreadStart function)
        {
            await Task.Run(() =>
            {
                threads.Add(new Thread(function));
                threads[threads.Count() - 1].Start();
            });
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Queue(Build);
        }

        private async void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await Queue(viewer.Set);
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog vistaFolderBrowserDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            vistaFolderBrowserDialog.ShowDialog();

            if (vistaFolderBrowserDialog.SelectedPath != String.Empty)
            {
                root = vistaFolderBrowserDialog.SelectedPath;
                await Queue(Build);
            }
        }

        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            Views.About about = new Views.About();

            about.Show();
        }
    }
}

using AdonisUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
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
        private Thread thread { get; set; }
        private Thread input { get; set; }
        private ViewModels.Bar bar { get; set; }
        private Models.Logger.Manager logger { get; set; }
        private string root { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            bar = new ViewModels.Bar(os_version);
            logger = new Models.Logger.Manager(log);
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
            Models.TreeView.Item item = null;
            string empty = "empty";
            string data = null;

            if (tree.SelectedItem != null)
            {
                item = tree.SelectedItem as Models.TreeView.Item;
                logger.Record("Analysing selected item");

                itemType.Text = $"{item.Type}";
                itemPath.Text = item.Path;
                content.Document.Blocks.Clear();
                if (item.Type == Models.System.File.Format.file)
                {
                    data = System.IO.File.ReadAllText(item.Path);
                    content.Document.Blocks.Add(new Paragraph(new Run(data)));
                    data = null;
                }
                logger.Force();
                logger.Record("Done");
            }
            else
            {
                logger.Record("No item selected");
                itemType.Text = empty;
                itemPath.Text = empty;
            }
        }

        private void Analyse()
        {
            Models.Threads.Manager.Edit(Viewer);
        }

        private void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(Build);

            thread.Start();
        }

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            thread = new Thread(Analyse);
            
            thread.Start();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog vistaFolderBrowserDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            vistaFolderBrowserDialog.ShowDialog();

            if (vistaFolderBrowserDialog.SelectedPath != String.Empty)
            {
                root = vistaFolderBrowserDialog.SelectedPath;
                thread = new Thread(Build);
                thread.Start();
            }
        }

        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            Views.About about = new Views.About();

            about.Show();
        }
    }
}

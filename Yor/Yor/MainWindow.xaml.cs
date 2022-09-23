using AdonisUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ViewModels.Bar bar { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            bar = new ViewModels.Bar(os_version);
        }

        private void Build()
        {
            Models.Threads.Manager.Edit(Load);
        }

        private void Load()
        {
            List<Models.TreeView.Item> items = Models.Structure.Manager.Build("../../");

            bar.Refresh();
            foreach (Models.TreeView.Item item in items)
                tree.Items.Add(item);
        }

        private void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(Build);

            thread.Start();
        }
    }
}

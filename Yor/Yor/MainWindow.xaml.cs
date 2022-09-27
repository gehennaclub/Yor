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
        public string root { get; set; }
        private MainViewModel mainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            mainViewModel = new MainViewModel(this, "Main");

            root = ".";
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await mainViewModel.WindowLoaded();
        }

        private async void RefreshClick(object sender, RoutedEventArgs e)
        {
            await mainViewModel.WindowLoaded();
        }

        private async void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await mainViewModel.plugins.CoreEditorRaw.Load();
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            await mainViewModel.ClickMenuDirectory();
        }

        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            Views.About about = new Views.About();

            about.Show();
        }

        private async void EditorApply(object sender, RoutedEventArgs e)
        {
            await mainViewModel.plugins.CoreEditorEdit.Apply(((Models.TreeView.Item)tree.SelectedItem).Path, content.Document);
        }
    }
}

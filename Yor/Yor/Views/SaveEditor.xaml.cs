using AdonisUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Yor.Views
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class SaveEditor : AdonisWindow
    {
        private string path { get; set; }

        public SaveEditor(string path)
        {
            this.path = path;

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {

        }

        private void TabControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

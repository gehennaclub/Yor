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
    public partial class About : AdonisWindow
    {
        public About()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            desc.Text = "Yor is currenly in development\nThe UI and the content will change in future updates";
            author.Text = "Neo: https://github.com/Neotoxic-off";
            repository.Text = "https://github.com/gehennaclub/Yor";
        }
    }
}

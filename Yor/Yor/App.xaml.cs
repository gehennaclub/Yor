using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Yor
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<string> folders { get; set; }

        public App()
        {
            folders = new List<string>()
            {
                "Logs",
                "Backup"
            };

            Build();
        }

        private void Build()
        {
            foreach (string folder in folders)
            {
                if (Directory.Exists(folder) == false)
                {
                    Directory.CreateDirectory(folder);
                }
            }
        }
    }
}

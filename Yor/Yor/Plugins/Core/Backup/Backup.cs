using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Yor.Plugins.Core.Backup
{
    public class Backup : BasePlugin
    {
        private string contentName { get; set; } 
        private static readonly string backupRoot = "Backup";
        public static readonly new string name = "Core.Backup.Backup";

        public Backup(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            
        }

        private void _Save()
        {
            string full = $"{backupRoot}/{Path.GetFileName(contentName)}.ylbak";

            if (Directory.Exists(backupRoot) == false)
            {
                Directory.CreateDirectory(backupRoot);
            }
            if (System.IO.File.Exists(full) == true)
            {
                System.IO.File.Delete(full);
            }
            System.IO.File.Copy(contentName, full);
        }

        public async Task Save(string name)
        {
            this.contentName = name;

            await Run(_Save);
        }
    }
}

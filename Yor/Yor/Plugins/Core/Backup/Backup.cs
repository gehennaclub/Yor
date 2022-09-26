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
        private static readonly new string backupRoot = "Backup";
        private string contentName { get; set; } 
        private string contentData { get; set; }
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
            System.IO.File.WriteAllText(full, contentData);
        }

        public async Task Save(string name, string content)
        {
            this.contentName = name;
            this.contentData = content;

            await Run(_Save);
        }
    }
}

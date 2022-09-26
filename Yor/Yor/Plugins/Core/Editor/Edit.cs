using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Yor.Plugins.Core.File;

namespace Yor.Plugins.Core.Editor
{
    public class Edit : BasePlugin
    {
        private Core.Backup.Backup CoreBackupBackup { get; set; }
        private string path { get; set; }
        private string content { get; set; }
        public static new string name = "Core.Editor.Edit";

        public Edit(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            CoreBackupBackup = new Core.Backup.Backup(mainWindow, Core.Backup.Backup.name);
        }

        private async void _Apply()
        {
            await CoreBackupBackup.Save(path);
            System.IO.File.WriteAllText(path, content);
        }

        public async Task Apply(string path, FlowDocument content)
        {
            this.path = path;
            this.content = new TextRange(content.ContentStart, content.ContentEnd).Text;

            await Run(_Apply);
        }
    }
}

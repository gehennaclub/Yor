using System;
using System.Threading.Tasks;
using System.Windows.Documents;

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
            logger.Record($"applying '{path}' changes");
            await CoreBackupBackup.Save(path);
            System.IO.File.WriteAllText(path, content);
            logger.Record("changes applied");
        }

        public async Task Apply(string path, FlowDocument content)
        {
            this.path = path;
            this.content = new TextRange(content.ContentStart, content.ContentEnd).Text;

            await Run(_Apply);
        }

        public async Task Set()
        {
            throw new NotImplementedException();
        }

        public async Task Load()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins
{
    public class Plugins
    {
        public Core.Bar.Factory Bar { get; set; }
        public Core.Editor.Factory Editor { get; set; }
        public Core.File.Informations CoreFileInformations { get; set; }
        public Core.Tree.Items CoreTreeItems { get; set; }
        public Core.Backup.Backup CoreBackupBackup { get; set; }

        public Plugins(MainWindow mainWindow)
        {
            Bar = new Core.Bar.Factory(mainWindow, Core.Bar.Factory.name);
            Editor = new Core.Editor.Factory(mainWindow, Core.Editor.Factory.name);
            //CoreFileInformations = new Core.File.Informations(mainWindow, Core.File.Informations.name);
            CoreTreeItems = new Core.Tree.Items(mainWindow, Core.Tree.Items.name);
            //CoreBackupBackup = new Core.Backup.Backup(mainWindow, Core.Backup.Backup.name);
        }
    }
}

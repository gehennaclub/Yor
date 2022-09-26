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
        public Core.Bar.OS CoreBarOs { get; set; }
        public Core.Editor.Raw CoreEditorRaw { get; set; }
        public Core.Editor.Edit CoreEditorEdit { get; set; }
        public Core.File.Informations CoreFileInformations { get; set; }
        public Core.Tree.Items CoreTreeItems { get; set; }
        public Core.Backup.Backup CoreBackupBackup { get; set; }

        public Plugins(MainWindow mainWindow)
        {
            CoreBarOs = new Core.Bar.OS(mainWindow, Core.Bar.OS.name);
            CoreEditorRaw = new Core.Editor.Raw(mainWindow, Core.Editor.Raw.name);
            CoreEditorEdit = new Core.Editor.Edit(mainWindow, Core.Editor.Edit.name);
            //CoreFileInformations = new Core.File.Informations(mainWindow, Core.File.Informations.name);
            CoreTreeItems = new Core.Tree.Items(mainWindow, Core.Tree.Items.name);
            //CoreBackupBackup = new Core.Backup.Backup(mainWindow, Core.Backup.Backup.name);
        }
    }
}

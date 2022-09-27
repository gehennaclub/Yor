using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using Yor.Models.TreeView;
using Yor.Plugins.Core.File;

namespace Yor.Plugins.Core.Tree
{
    public class Items : BasePlugin
    {
        public static new string name = "Core.Tree.Items";

        public Items(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            
        }

        private void _Load()
        {
            logger.Record("Searching for game files");
            List<Models.TreeView.Item> items = Models.Structure.Manager.Build(mainWindow.root);
            logger.Record($"Total files found: '{items.Count()}'");

            if (mainWindow.tree.Items.Count > 0)
            {
                mainWindow.tree.Items.Clear();
            }
            foreach (Models.TreeView.Item item in items)
            {
                logger.Record($"File found: '{item.Name}'");
                mainWindow.tree.Items.Add(item);
            }
            logger.Force();
            logger.Record("Done");
        }

        public override async Task Load()
        {
            await Run(_Load);
        }
    }
}

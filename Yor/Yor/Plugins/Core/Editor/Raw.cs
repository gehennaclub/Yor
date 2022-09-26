using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using Yor.Models.TreeView;

namespace Yor.Plugins.Core.Editor
{
    public class Raw : BasePlugin
    {
        private Models.TreeView.Item item { get; set; }
        private File.Informations informations { get; set; }
        private string data { get; set; }
        private static readonly string empty = "empty";
        private static readonly string unrawable = "For performance reasons only utf-8 readable files can be displayed";
        public static new string name = "Core.Editor.Raw";

        public Raw(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            informations = new File.Informations(mainWindow, "File.Informations")
            {
                type = mainWindow.itemType,
                path = mainWindow.itemPath,
                format = mainWindow.itemFormat,
            };
        }

        private async void _Load()
        {
            if (mainWindow.tree.SelectedItem != null)
            {
                logger.Record("Analysing selected item");
                item = (Models.TreeView.Item)mainWindow.tree.SelectedItem;
                await informations.Set($"{item.Type}", item.Name, $"{item.Format}");
                mainWindow.content.Document.Blocks.Clear();
                mainWindow.contentHex.Document.Blocks.Clear();
                if (item.Type == Models.System.File.Format.file)
                {
                    if (Models.Extensions.Manager.Rawable(item.Format) == true)
                    {
                        data = System.IO.File.ReadAllText(item.Path);
                        mainWindow.content.Document.Blocks.Add(new Paragraph(new Run(data)));
                        data = null;
                    }
                    else
                    {
                        mainWindow.content.Document.Blocks.Add(new Paragraph(new Run(unrawable)));
                    }
                }

                logger.Force();
                logger.Record("Done");
            }
            else
            {
                logger.Record("No item selected");
                await informations.Set(empty, empty, empty);
            }
        }

        public async Task Load()
        {
            await Run(_Load);
        }

        public async Task ReLoad()
        {
            await Run(_Load);
        }
    }
}

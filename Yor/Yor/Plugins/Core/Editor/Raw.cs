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
                if (mainWindow.content.Document.Blocks.Count() > 0)
                {
                    logger.Record($"cleanning previous blocks");
                    mainWindow.content.Document.Blocks.Clear();
                    logger.Record($"previous blocks cleanned");
                }
                if (item.Type == Models.System.File.Format.file)
                {
                    if (Models.Extensions.Manager.Rawable(item.Format) == true)
                    {
                        logger.Record($"loading raw");
                        logger.Record($"reading raw data");
                        data = System.IO.File.ReadAllText(item.Path);
                        logger.Record($"raw data read");
                        logger.Record($"adding data to block");
                        mainWindow.content.Document.Blocks.Add(new Paragraph(new Run(data)));
                        logger.Record($"block added");
                        data = null;
                    }
                    else
                    {
                        logger.Record($"loading unrawable");
                        mainWindow.content.Document.Blocks.Add(new Paragraph(new Run(unrawable)));
                        logger.Record($"unrawable loaded");
                    }
                }

                logger.Record("Done");
            }
            else
            {
                logger.Record("No item selected");
                await informations.Set(empty, empty, empty);
            }
            logger.Force();
        }

        public override async Task Load()
        {
            await Run(_Load);
        }
    }
}

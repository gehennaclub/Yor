using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;

namespace Yor.ViewModels
{
    public class Viewer
    {
        private TreeView tree { get; set; }
        public Models.TreeView.Item item { get; set; }
        private Models.Logger.Manager logger { get; set; }
        private RichTextBox content { get; set; }
        private RichTextBox contentHex { get; set; }
        private List<Thread> threads { get; set; }
        private string data = null;
        private string empty = "empty";
        private string unrawable = "For performance reasons only utf-8 readable files can be displayed";
        private FileInformations informations { get; set; }

        public Viewer(FileInformations informations, TreeView tree, Models.Logger.Manager logger, RichTextBox content, RichTextBox contentHex)
        {
            this.logger = logger;
            this.tree = tree;
            this.content = content;
            this.contentHex = contentHex;
            this.informations = informations;
            threads = new List<Thread>();
        }

        private async void Format()
        {
            foreach (char c in data)
            {
                if (c < 32 || c > 126)
                {
                    data = data.Replace(c, '.');
                }
            }
        }

        private async Task Queue(ThreadStart action)
        {
            await Task.Run(() =>
            {
                threads.Add(new Thread(action));
                threads[threads.Count() - 1].Start();
            });
        }

        private async void _Set()
        {
            if (tree.SelectedItem != null)
            {
                logger.Record("Analysing selected item");
                item = tree.SelectedItem as Models.TreeView.Item;
                informations.Set($"{item.Type}", item.Name, $"{item.Format}"/*, item.Magic*/);
                content.Document.Blocks.Clear();
                contentHex.Document.Blocks.Clear();
                if (item.Type == Models.System.File.Format.file)
                {
                    data = File.ReadAllText(item.Path);
                    if (Models.Extensions.Manager.Rawable(item.Format) == true)
                    {
                        content.Document.Blocks.Add(new Paragraph(new Run(data)));
                        data = null;
                    }
                    else
                    {
                        contentHex.Document.Blocks.Add(new Paragraph(new Run(unrawable)));
                    }
                }

                logger.Force();
                logger.Record("Done");
            }
            else
            {
                logger.Record("No item selected");
                informations.Set(empty, empty, empty/*, empty*/);
            }
        }

        public void LoadAssembly()
        {
            //System.Reflection.Assembly myDllAssembly = System.Reflection.Assembly.LoadFile("%MyDLLPath%\\MyDLL.dll");
            //System.Type MyDLLFormType = myDllAssembly.GetType("MyDLLNamespace.MyDLLForm");
        }

        public void Set()
        {
            Models.Threads.Manager.Edit(_Set);
        }
    }
}

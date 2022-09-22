using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Models.Structure
{
    public class Manager
    {
        public static List<TreeView.Item> Files(string root)
        {
            string[] files = Directory.GetFiles(root, "*.*");
            string name = null;
            string extension = null;
            List<TreeView.Item> items = new List<TreeView.Item>();

            foreach (string file in files)
            {
                name = Path.GetFileName(file);
                extension = Path.GetExtension(name);
                items.Add(new TreeView.Item()
                {
                    Name = name,
                    Path = file,
                    Image = Icons.Manager.Find(extension),
                    Type = Enum.System.Format.file,
                    Items = null
                });
            }

            return (items);
        }

        public static List<TreeView.Item> Folders(string root)
        {
            string[] files = Directory.GetDirectories(root, "*");
            string name = null;
            string extension = null;
            List<TreeView.Item> items = new List<TreeView.Item>();

            foreach (string file in files)
            {
                name = Path.GetFileName(file);
                extension = Path.GetExtension(name);
                items.Add(new TreeView.Item()
                {
                    Name = name,
                    Path = file,
                    Image = "/Assets/Icons/Folders/folder.png",
                    Type = Enum.System.Format.folder,
                    Items = Build(file)
                });
            }

            return (items);
        }

        public static List<TreeView.Item> Build(string root)
        {
            List<TreeView.Item> content = Folders(root);
            content.AddRange(Files(root));

            return (content);
        }
    }
}

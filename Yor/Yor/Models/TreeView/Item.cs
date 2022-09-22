using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Models.TreeView
{
    public class Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
        public Enum.System.Format Type { get; set; }
        public List<Item> Items { get; set; }
    }
}

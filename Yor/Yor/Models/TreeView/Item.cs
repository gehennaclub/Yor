using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Yor.Models.TreeView
{
    public class Item
    {
        private bool _IsExpanded;

        public bool IsExpanded
        {
            get
            {
                return _IsExpanded;
            }
            set
            {
                if (Equals(_IsExpanded, value))
                {
                    return;
                }

                _IsExpanded = value;
            }
        }

        private bool _IsSelected;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                if (Equals(_IsSelected, value))
                {
                    return;
                }

                _IsSelected = value;
            }
        }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
        public Models.System.File.Format Type { get; set; }
        public List<Item> Items { get; set; }
    }
}

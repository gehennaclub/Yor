using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Yor.Models.Structure;

namespace Yor.ViewModels
{
    public class FileInformations
    {
        public TextBlock type { get; set; }
        public TextBlock path { get; set; }
        public TextBlock format { get; set; }
        public TextBlock magic { get; set; }

        public FileInformations(TextBlock type, TextBlock path, TextBlock format/*, TextBlock magic*/)
        {
            this.type = type;
            this.path = path;
            this.format = format;
            //this.magic = magic;
        }

        public void Set(string type, string path, string format/*, string magic*/)
        {
            this.type.Text = type;
            this.path.Text = path;
            this.format.Text = format;
            //this.magic.Text = magic;
        }
    }
}

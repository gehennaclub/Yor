using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Yor.Plugins.Core.File
{
    public class Informations : BasePlugin
    {
        public TextBlock type { get; set; }
        public TextBlock path { get; set; }
        public TextBlock format { get; set; }

        private string value_type { get; set; }
        private string value_path { get; set; }
        private string value_format { get; set; }

        public Informations(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            this.type = type;
            this.path = path;
            this.format = format;
        }

        private void _Set()
        {
            this.type.Text = value_type;
            this.path.Text = value_path;
            this.format.Text = value_format;
        }

        public async Task Set(string type, string path, string format)
        {
            value_type = type;
            value_path = path;
            value_format = format;

            await Run(_Set);
        }
    }
}

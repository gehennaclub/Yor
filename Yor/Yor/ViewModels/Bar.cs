using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Yor.ViewModels
{
    public class Bar
    {
        private ViewModels.System system { get; set; }
        private TextBlock os_version { get; set; }

        public Bar(TextBlock os_version)
        {
            Initialize(os_version);
            Load();
        }

        private void Initialize(TextBlock os_version)
        {
            this.os_version = os_version;

            system = new System();
        }

        private void Load()
        {
            Images();
        }

        private void Images()
        {
            os_version.Text = $"{system.os.version}";
        }

        private void Update()
        {
            Images();
        }

        public void Refresh()
        {
            Models.Threads.Manager.Edit(Update);
        }
    }
}

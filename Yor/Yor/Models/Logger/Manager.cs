using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Yor.Models.Logger
{
    public class Manager
    {
        private TextBlock block { get; set; }
        private int limit { get; set; }
        private List<string> logs { get; set; }

        public Manager(TextBlock block)
        {
            this.block = block;

            Initialize();
        }

        private void Initialize()
        {
            limit = 10;

            logs = new List<string>();
        }

        private void Write()
        {
            block.Text = logs[logs.Count() - 1];
        }

        public void Record(string message)
        {
            Models.Threads.Manager.Edit(Write);
        }

        private void Dump()
        {
            if (Directory.Exists() == false)
            {

            }
        }
    }
}

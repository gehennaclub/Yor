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
        private string session { get; set; }
        private string folder { get; set; }
        private string message { get; set; }
        private string name { get; set; }
        private List<Action> queue { get; set; }

        public Manager(TextBlock block, string name)
        {
            this.block = block;
            this.name = name;

            Initialize();
        }

        private void Initialize()
        {
            limit = 10;
            session = $"{DateTime.Now.ToString("ddMMyyhh")}.yl";
            folder = "Logs";

            logs = new List<string>();
            queue = new List<Action>();
        }

        private void Write()
        {
            block.Text = message;
        }

        public void Record(string message)
        {
            string full = $"[{DateTime.Now.ToString("hh:mm:ss")}] | {message}";

            this.message = message;

            if (logs.Count >= limit)
            {
                Dump();
                logs.Clear();
            }
            logs.Add(full);
            Models.Threads.Manager.Edit(Write);
        }

        public void Force()
        {
            Dump();
        }

        private void Dump()
        {
            if (Directory.Exists(folder) == false)
            {
                Directory.CreateDirectory(folder);
            }
            if (Directory.Exists($"{folder}/{name}") == false)
            {
                Directory.CreateDirectory($"{folder}/{name}");
            }
            File.AppendAllLines($"{folder}/{name}/{session}", logs);
            logs.Clear();
        }
    }
}

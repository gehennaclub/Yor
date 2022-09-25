using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.ViewModels
{
    public class Threads
    {
        private List<Action> jobs { get; set; }

        public Threads()
        {
            jobs = new List<Action>();
        }

        public async Task Begin(Action action)
        {
            jobs.Add(action);
            await Queue();
        }

        private async Task Queue()
        {
            foreach (Action job in jobs)
            {
                await Task.Run(() => job());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yor.Models.Threads
{
    public class Manager
    {
        public static void Edit(Action action)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                action();
            });
        }
    }
}

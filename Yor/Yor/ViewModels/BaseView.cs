using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;
using Newtonsoft.Json;
using Yor.Plugins;
using static System.Collections.Specialized.BitVector32;

namespace Yor.ViewModels
{
    public abstract class BaseView
    {
        public MainWindow mainWindow { get; set; }
        public List<Action> queue { get; set; }
        public Dictionary<object, Action> actions { get; set; }
        public Models.Logger.Manager logger { get; set; }
        public Ookii.Dialogs.Wpf.VistaFolderBrowserDialog folderDialog { get; set; }
        public Ookii.Dialogs.Wpf.VistaOpenFileDialog fileDialog { get; set; }
        public string name { get; set; }

        public BaseView(MainWindow mainWindow, string name)
        {
            this.mainWindow = mainWindow;

            queue = new List<Action>();
            actions = new Dictionary<object, Action>();
            logger = new Models.Logger.Manager(this.mainWindow.log, name);
            folderDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            fileDialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
        }

        public async Task Run(Action action)
        {
            logger.Record($"running action {action.Method.Name}");

            queue.Add(action);
            await Wait();

            logger.Record($"action {action.Method.Name} runned");
            logger.Record("Done");
            logger.Force();
        }

        private async Task Wait()
        {
            logger.Record($"waiting for queue: {queue.Count()}");

            foreach (Action job in queue)
            {
                await Task.Run(() => Models.Threads.Manager.Edit(job));
            }
            queue.Clear();

            logger.Record("queue completed");
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.FPatch
{
    public class Writter
    {
        public void save(Model.Rootobject model)
        {
            string output = "Patch";

            if (Directory.Exists(output) == false)
            {
                Directory.CreateDirectory(output);
            }

            System.IO.File.WriteAllText($"{output}\\fpatch.fpp", JsonConvert.SerializeObject(model, Formatting.Indented));
        }
    }
}

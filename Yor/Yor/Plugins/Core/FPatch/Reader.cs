using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Plugins.Core.FPatch
{
    public class Reader
    {
        public Model.Rootobject load(string file)
        {
            return (JsonConvert.DeserializeObject<Model.Rootobject>(System.IO.File.ReadAllText(file)));
        }
    }
}

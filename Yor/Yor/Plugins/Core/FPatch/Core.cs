using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yor.Plugins.Core.Memory;

namespace Yor.Plugins.Core.FPatch
{
    public class Core : BasePlugin
    {
        private byte[] bytes { get; set; }
        private Model.Rootobject model { get; set; }
        private Reader reader { get; set; }
        private Writter writter { get; set; }

        public Core(MainWindow mainWindow, string name) : base(mainWindow, name)
        {
            reader = new Reader();
            writter = new Writter();
        }

        public void Setup(string author, string version)
        {
            model = init_model(author, version);
        }

        private Model.Rootobject init_model(string author, string version)
        {
            Model.Rootobject model = new Model.Rootobject()
            {
                settings = new Model.Settings()
                {
                    version = "Yor"
                },
                patch = new Model.Patch()
                {
                    author = author,
                    version = version,
                    content = new List<Patch>()
                }
            };

            return (model);
        }

        public Patch create(string file, UInt32 offset, UInt32[] payload, Address.Method method)
        {
            Patch patch = new Patch()
            {
                status = Patch.States.not_patched,
                file = file,
                payload = new Address(offset, payload, method)
            };

            return (patch);
        }

        public void create_and_add(string file, UInt32 offset, UInt32[] payload, Address.Method method)
        {
            add(create(file, offset, payload, method));
        }

        public void add(Patch patch)
        {
            model.patch.content.Add(patch);
        }

        public void load(string path)
        {
            model = reader.load(path);
        }

        public void restore()
        {
            foreach (Patch patch in model.patch.content)
            {
                recover(patch.file);
            }
        }

        public void recover(string file)
        {
            string backup_output = $"{file}.bak";

            if (System.IO.File.Exists(file) == true)
            {
                System.IO.File.Delete(file);
            }
            if (System.IO.File.Exists(backup_output) == true)
            {
                System.IO.File.Move(backup_output, file);
            }
        }

        public void save()
        {
            writter.save(model);
        }

        public void apply()
        {
            workplace();
        }

        private void workplace()
        {
            foreach (Patch patch in model.patch.content)
            {
                if (check_file(patch.file) == true)
                {
                    backup_file(patch.file);
                    load_bytes(patch.file);
                    apply_patch(patch);
                    save_bytes(patch.file);
                }
            }
        }

        private void apply_patch(Patch patch)
        {
            Mapper mapper = new Mapper(patch.payload);

            bytes = mapper.mapping[patch.payload.method](bytes);
            patch.status = Patch.States.patched;
        }

        private bool check_file(string file)
        {
            bool status = System.IO.File.Exists(file);

            return (status);
        }

        private void backup_file(string file)
        {
            
        }

        private void load_bytes(string file)
        {
            bytes = System.IO.File.ReadAllBytes(file);
        }

        private void save_bytes(string file)
        {
            System.IO.File.WriteAllBytes(file, bytes);
        }
    }
}

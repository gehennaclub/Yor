using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Yor.Properties;

namespace Yor.Models.Extensions
{
    public class Manager
    {
        public enum Format
        {
            archive,
            code,
            configuration,
            executable,
            library,
            resource,
            obj,
            folder,
            unknown,
            custom
        }

        private static Dictionary<List<string>, Format> mapping = new Dictionary<List<string>, Format>()
        {
            {
                new List<string>()
                {
                    "folder"
                },
                Format.folder
            },
            {
                new List<string>()
                {
                    ".7z",
                    ".arj",
                    ".deb",
                    ".pkg",
                    ".rar",
                    ".rpm",
                    ".tar.gz",
                    ".tar",
                    ".z",
                    ".zip"
                },
                Format.archive
            },
            {
                new List<string>()
                {
                    ".java",
                    ".py",
                    ".rb",
                    ".cpp",
                    ".c",
                    ".cs",
                    ".pl",
                    ".h",
                    ".sh",
                    ".swift",
                    ".bat",
                    ".vb",
                    ".php"
                },
                Format.code
            },
            {
                new List<string>()
                {
                    ".ini",
                    ".xml",
                    ".xaml",
                    ".json",
                    ".config",
                    ".info"
                },
                Format.configuration
            },
            {
                new List<string>()
                {
                    ".exe"
                },
                Format.executable
            },
            {
                new List<string>()
                {
                    ".dll",
                    ".so",
                    ".lib"
                },
                Format.library
            },
            {
                new List<string>()
                {
                    ".o",
                    ".obj"
                },
                Format.obj
            },
            {
                new List<string>()
                {
                    ".assets",
                    "metadata",
                    ".res",
                    ".resS"
                },
                Format.resource
            },
            {
                new List<string>()
                {
                    ".yl"
                },
                Format.custom
            }
        };

        private static Dictionary<Format, bool> raw = new Dictionary<Format, bool>()
        {
            { Format.archive, false },
            { Format.code, true },
            { Format.configuration, true },
            { Format.executable, false },
            { Format.library, false },
            { Format.resource, false },
            { Format.obj, false },
            { Format.folder, false },
            { Format.custom, true },
            { Format.unknown, false }
        };

        public static bool Rawable(Format format)
        {
            if (raw.ContainsKey(format) == true)
            {
                return (raw[format]);
            }

            return (false);
        }

        public static Format Get(string extension)
        {
            foreach (KeyValuePair<List<string>, Format> items in mapping)
            {
                if (items.Key.Contains(extension) == true)
                {
                    return (items.Value);
                }
            }

            return (Format.unknown);
        }
    }
}

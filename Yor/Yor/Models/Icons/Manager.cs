using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yor.Models.Icons
{
    public class Manager
    {
        private static Dictionary<List<string>, string> extensions = new Dictionary<List<string>, string>()
        {
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
                "/Assets/Icons/Files/Windows/archive.png"
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
                "/Assets/Icons/Files/Windows/code.png"
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
                "/Assets/Icons/Files/Windows/settings.png"
            },
            {
                new List<string>()
                {
                    ".exe"
                },
                "/Assets/Icons/Files/Windows/app.png"
            },
            {
                new List<string>()
                {
                    ".so",
                    ".lib"
                },
                "/Assets/Icons/Files/Windows/lib.png"
            },
            {
                new List<string>()
                {
                    ".dll"
                },
                "/Assets/Icons/Files/Windows/dll.png"
            },
            {
                new List<string>()
                {
                    ".o",
                    ".obj"
                },
                "/Assets/Icons/Files/Windows/obj.png"
            },
            {
                new List<string>()
                {
                    "metadata"
                },
                "/Assets/Icons/Files/Windows/metadata.png"
            },
            {
                new List<string>()
                {
                    ".assets"
                },
                "/Assets/Icons/Files/Windows/assets.png"
            },
            {
                new List<string>()
                {
                    ".res",
                    ".resS"
                },
                "/Assets/Icons/Files/Windows/res.png"
            },
            {
                new List<string>()
                {
                    ".yl"
                },
                "/Assets/Icons/Files/Windows/yl.png"
            }
        };

        private static Dictionary<List<string>, string> folders = new Dictionary<List<string>, string>()
        {
            {
                new List<string>()
                {
                    "Resources"
                },
                "/Assets/Icons/Folders/assets.png"
            },
            {
                new List<string>()
                {
                    "Managed"
                },
                "/Assets/Icons/Folders/library.png"
            },
            {
                new List<string>()
                {
                    "Mono"
                },
                "/Assets/Icons/Folders/mono.png"
            }
        };

        public static string File(string extension)
        {
            string default_image = "/Assets/Icons/Files/Windows/bin.png";

            foreach (KeyValuePair<List<string>, string> items in extensions)
            {
                if (items.Key.Contains(extension) == true)
                {
                    return (items.Value);
                }
            }

            return (default_image);
        }

        public static string Folder(string extension)
        {
            string default_image = "/Assets/Icons/Folders/folder.png";

            foreach (KeyValuePair<List<string>, string> items in folders)
            {
                if (items.Key.Contains(extension) == true)
                {
                    return (items.Value);
                }
            }

            return (default_image);
        }
    }
}

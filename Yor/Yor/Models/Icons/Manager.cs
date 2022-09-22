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
                    ".accdb",
                    ".csv",
                    ".dat",
                    ".db",
                    ".dbf",
                    ".log",
                    ".mdb",
                    ".pdb",
                    ".sav",
                    ".sql"
                },
                "/Assets/Icons/Files/database.png"
            },
            {
                new List<string>()
                {
                    ".txt"
                },
                "/Assets/Icons/Files/txt.png"
            },
            {
                new List<string>()
                {
                    ".aif",
                    ".cda",
                    ".iff",
                    ".mid",
                    ".midi",
                    ".mp3",
                    ".mpa",
                    ".wav",
                    ".wma",
                    ".wpl"
                },
                "/Assets/Icons/Files/audio.png"
            },
            {
                new List<string>()
                {
                    ".ai",
                    ".bmp",
                    ".ico",
                    ".gif",
                    ".jpeg",
                    ".jpg",
                    ".max",
                    ".obj",
                    ".png",
                    ".ps",
                    ".psd",
                    ".svg",
                    ".tif",
                    ".tiff",
                    ".3ds",
                    ".3dm"
                },
                "/Assets/Icons/Files/image.png"
            },
            {
                new List<string>()
                {
                    ".avi",
                    ".flv",
                    ".h264",
                    ".m4v",
                    ".mkv",
                    ".mov",
                    ".mp4",
                    ".mpg",
                    ".mpeg",
                    ".rm",
                    ".swf",
                    ".vob",
                    ".wmv",
                    ".3g2",
                    ".3gp"
                },
                "/Assets/Icons/Files/video.png"
            },
            {
                new List<string>()
                {
                    ".doc",
                    ".docx",
                    ".odt",
                    ".msg",
                    ".rtf",
                    ".tex",
                    ".txt",
                    ".wks",
                    ".wps",
                    ".wpd",
                    ".ods",
                    ".xlr",
                    ".xls",
                    ".xlsx",
                    ".key",
                    ".odp",
                    ".pps",
                    ".ppt",
                    ".pptx"
                },
                "/Assets/Icons/Files/document.png"
            },
            {
                new List<string>()
                {
                    ".pdf"
                },
                "/Assets/Icons/Files/pdf.png"
            },
            {
                new List<string>()
                {
                    ".htm",
                    ".html",
                    ".xhtml"
                },
                "/Assets/Icons/Files/html.png"
            },
            {
                new List<string>()
                {
                    ".css",
                    ".scss"
                },
                "/Assets/Icons/Files/css.png"
            },
            {
                new List<string>()
                {
                    ".js"
                },
                "/Assets/Icons/Files/js.png"
            },
            {
                new List<string>()
                {
                    ".asp",
                    ".aspx",
                    ".cer",
                    ".cfm",
                    ".cgi",
                    ".pl",
                    ".jsp",
                    ".part",
                    ".php",
                    ".rss"
                },
                "/Assets/Icons/Files/web.png"
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
                "/Assets/Icons/Files/archive.png"
            },
            {
                new List<string>()
                {
                    ".java"
                },
                "/Assets/Icons/Files/java.png"
            },
            {
                new List<string>()
                {
                    ".py"
                },
                "/Assets/Icons/Files/py.png"
            },
            {
                new List<string>()
                {
                    ".rb"
                },
                "/Assets/Icons/Files/rb.png"
            },
            {
                new List<string>()
                {
                    ".md"
                },
                "/Assets/Icons/Files/md.png"
            },
            {
                new List<string>()
                {
                    ".cpp"
                },
                "/Assets/Icons/Files/cpp.png"
            },
            {
                new List<string>()
                {
                    ".c",
                    ".pl",
                    ".cpp",
                    ".cs",
                    ".h",
                    ".java",
                    ".py",
                    ".sh",
                    ".swift",
                    ".bat",
                    ".vb",
                    ".rb",
                    ".php"
                },
                "/Assets/Icons/Files/code.png"
            },
            {
                new List<string>()
                {
                    ".ini",
                    ".xml",
                    ".xaml",
                    ".json"
                },
                "/Assets/Icons/Files/settings.png"
            }
        };

        public static string Find(string extension)
        {
            string default_image = "/Assets/Icons/Files/file.png";

            foreach (KeyValuePair<List<string>, string> items in extensions)
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

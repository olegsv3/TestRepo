using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWork
{
    static class FileWorker
    {
        static readonly private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static readonly private string _fileName = Path.Combine(_path, "words.txt");
        static readonly private string _tmpFileName = Path.Combine(_path, "tmpWords.txt");

        static private StreamReader _reader;
        static private StreamWriter _writer;

        static private List<string> _list;
        static private List<string> _tmpList;

        static public string ActiveLanguage { get; set; }

        static public void Start()
        {
            UpdateList();
        }

        static public void UpdateList()
        {
            _list = new List<string>();
            string line = string.Empty;

            _reader = new StreamReader(_fileName);

            while ((line = _reader.ReadLine()) != null)
            {
                _list.Add(line);
            }
            _reader.Close();
        }

        static public List<string> GetLanguages()
        {
            var langs = new List<string>();
            langs = (from lang in _list
                    where lang.StartsWith("#")
                    select lang.Remove(0,1)).ToList<string>();
            return langs;
        }

        static public bool AddLanguage(string lang)
        {
            string formatLang = $"#{lang}";
            if (_list.Contains(formatLang)) return false;

            _writer = new StreamWriter(_fileName, true);
            _writer.WriteLine(formatLang);
            _writer.Close();
            UpdateList();
            return true;
        }

        static public bool AddCategory(string cat)
        {
            int position = _list.IndexOf($"#{cat}");
            if (_list.Count < position + 2)
            {
                for (int i = position + 1; i < _list.Count; i++)
                {
                    if(_list[i].StartsWith("#") || _list[i].StartsWith("*"))
                    {
                        _list.Insert(i, cat);
                    }
                }
            }

            }
        }
        
    }
}

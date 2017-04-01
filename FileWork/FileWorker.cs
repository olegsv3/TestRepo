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

        static private List<DataItem> _list;

        static public string ActiveLanguage { get; set; }

        static public void Start()
        {
            UpdateList();
        }

        static public void UpdateList()
        {
            _list = new List<DataItem>();
            string line = string.Empty;

            _reader = new StreamReader(_fileName);

            while ((line = _reader.ReadLine()) != null)
            {
                
            }
            _reader.Close();
        }

        static public List<string> GetLanguages()
        {

        }        
    }
}

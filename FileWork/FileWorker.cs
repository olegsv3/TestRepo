﻿using System;
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
        static private List<DataItem> _ListData;

        static public string ActiveLanguage { get; set; }
        static public string ActiveCategory { get; set; }

        static public void Start()
        {
            File.Create(_fileName).Dispose();
            UpdateList();
        }

        static public void UpdateList()
        {
            _list = new List<string>();
            _ListData = new List<DataItem>();

            string line = string.Empty;

            _reader = new StreamReader(_fileName);

            while ((line = _reader.ReadLine()) != null)
            {
                _list.Add(line);
            }
            _reader.Close();

            foreach(var str in _list)
            {
                string[] tmp = str.Split('|');
                var dataItem = new DataItem() { Language = tmp.Length > 0 ? tmp[0] : "",
                                                Category = tmp.Length > 1 ? tmp[1] : "",
                                                Word1 = tmp.Length > 2 ? tmp[2] : "",
                                                Word2 = tmp.Length > 3 ? tmp[3] : "" };
                _ListData.Add(dataItem);
            }
        }

        static public List<string> GetLanguages()
        {
            return (from lang in _ListData
                    group lang by lang.Language
                    into tmp
                    select tmp.Key).ToList();
        }        

        static public bool AddLanguage(string lang)
        {
            if (GetLanguages().Contains(lang)) return false;
            _writer = new StreamWriter(_fileName, true);
            _writer.WriteLine(lang);
            _writer.Close();
            UpdateList();
            return true;
        }

        static public bool AddCategory(string cat)
        {
            var formatString = $"{ActiveLanguage}|{cat}";
            if (_list.Contains(formatString)) return false;
            _writer = new StreamWriter(_fileName, true);
            _writer.WriteLine(formatString);
            _writer.Close();
            UpdateList();
            return true;
        }

        static public List<string> GetCategories()
        {
            return (from cat in _ListData
                    where cat.Language == ActiveLanguage
                    group cat by cat.Category into tmp
                    select tmp.Key).ToList<string>();
        }

        static public bool AddWords(string word1, string word2)
        {
            string formatString = $"{ActiveLanguage}|{ActiveCategory}|{word1}|{word2}";

            _writer = new StreamWriter(_fileName, true);
            _writer.WriteLine(formatString);
            _writer.Close();

            UpdateList();
            return true;
        }

        static public List<Card> GetWords()
        {
            return (from card in _ListData
                    where card.Language == ActiveLanguage && card.Category == ActiveCategory
                    select new Card { Word1 = card.Word1, Word2 = card.Word2 }).ToList<Card>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker.Start();
            FileWorker.AddLanguage("English");
            FileWorker.AddLanguage("French");
        }
    }
}

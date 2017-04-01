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
            FileWorker.ActiveLanguage = "English";

            foreach(var i in FileWorker.GetLanguages())
            {
                Console.WriteLine(i);
            }
            FileWorker.AddCategory("Flat");
            FileWorker.AddCategory("Job");
            FileWorker.AddCategory("Hobby");

            FileWorker.ActiveLanguage = "French";

            FileWorker.AddCategory("Paris");
            FileWorker.AddCategory("Nature");
            FileWorker.AddCategory("Fruits");

            FileWorker.ActiveLanguage = "English";

            foreach (var i in FileWorker.GetCategories())
            {
                Console.WriteLine(i);
            }

            FileWorker.ActiveCategory = "Job";

            FileWorker.AddWords("Head", "Директор");
            FileWorker.AddWords("Office", "Офис");
            FileWorker.AddWords("Meeting", "Встреча");

            foreach (var i in FileWorker.GetWords())
            {
                Console.WriteLine($"{i.Word1}\t{i.Word2}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //  GetMaxList();

            FindFileFromDir("D:\\Distrib");
        }

        private static void FindFileFromDir(string DirPath)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            FileListEvents fileSelect = new FileListEvents();

            fileSelect.FileListSelected += (sender, fileF) =>
            {
                Console.WriteLine($"Файл найден: {fileF.FilePath}");
                
            };

            fileSelect.RoundDirectory(DirPath, token);
          //  if (((Console.ReadKey().Modifiers & ConsoleModifiers.Control) != 0) & (Console.ReadKey().Key.ToString() == "J"))
          //      cancelTokenSource.Cancel();

            cancelTokenSource.Dispose();

            Console.ReadKey();
        }

        private static void GetMaxList()
        {
            List<Book> books = new List<Book>()
            {
                new Book { Name = "Гамлет", CreateYear = 1930 },
                new Book { Name = "История древнего мира", CreateYear = 1945 },
                new Book { Name = "Математика 10 кл", CreateYear = 1975 }
            };
            Book oldestBook = books.GetMax(p => p.CreateYear);

            Console.WriteLine($"Самая новая книга : {oldestBook.Name}, год издания: {oldestBook.CreateYear}.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_Generic
{
    public class FileListEvents
        {
        public delegate void EventHandler(string directoryPath);

        public event EventHandler<FileFound> FileListSelected;
     
        public void RoundDirectory(string directoryPath,CancellationToken token)
        {
            // Проверить наличие каталога
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Каталог {directoryPath} не найден.");
            }

            // Обход каталога и файлов
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                // Вызвать событие для каждого файла
                OnFileListSelected(new FileFound(file));

            }

            // Обход подкаталогов
            string[] directories = Directory.GetDirectories(directoryPath);
            foreach (string directory in directories)
            {
                
                RoundDirectory(directory,token);
            }
        }

        protected virtual void OnFileListSelected(FileFound fileF)
        {
            FileListSelected?.Invoke(this, fileF);
        }
        
    }

    public class FileFound : EventArgs
    {
        public string FilePath { get; }

        public FileFound(string filePath)
        {
            FilePath = filePath;
        }
    }
   

}

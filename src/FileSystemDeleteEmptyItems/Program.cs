using System;
using System.IO;

namespace FileSystemDeleteEmptyItems
{
    // TODO: Move this project to separate solution!!!
    public class Program
    {
        public static void Main()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "_test");
            ForceDeleteEmptyItems(path);
        }

        public static void DeleteEmptyItems(string startPath)
        {
            DeleteEmptyItems(startPath, force: false);
        }

        public static void ForceDeleteEmptyItems(string startPath)
        {
            DeleteEmptyItems(startPath, force: true);
        }

        private static void DeleteEmptyItems(string startPath, bool force)
        {
            var currentDirectory = new DirectoryInfo(startPath);

            foreach (var file in currentDirectory.GetFiles())
            {
                try
                {
                    if (force)
                    {
                        file.ForceDeleteIfEmpty();
                    }
                    else
                    {
                        file.DeleteIfEmpty();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File '{file.FullName}' could not be deleted. {ex.Message}");
                }
            }

            foreach (var subDirectory in currentDirectory.GetDirectories())
            {
                DeleteEmptyItems(subDirectory.FullName, force);
            }

            currentDirectory.DeleteIfEmpty();
        }
    }
}

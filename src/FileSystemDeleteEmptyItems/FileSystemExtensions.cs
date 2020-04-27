using System;
using System.IO;
using System.Linq;

namespace FileSystemDeleteEmptyItems
{
    public static class FileSystemExtensions
    {
        public static void ForceDeleteIfEmpty(this FileInfo file)
        {
            if (file.Length == 0)
            {
                if (file.Attributes != FileAttributes.Normal)
                {
                    file.Attributes = FileAttributes.Normal;
                }

                file.Delete();
            }
        }

        public static void DeleteIfEmpty(this FileInfo file)
        {
            if (file.Length == 0)
            {
                file.Delete();
            }
        }

        public static void DeleteIfEmpty(this DirectoryInfo directory)
        {
            if (!directory.EnumerateFileSystemInfos().Any())
            {
                directory.Delete();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ItemNotFoundException : Exception { }
public class ItemNotEmptyException : Exception { }
public class NotAnItemException : Exception { }

public class FileSystem
{
    private readonly List<string> _existingItems = new List<string>();
    private readonly List<string> _deletedItems = new List<string>();

    public FileSystem()
    {
        _existingItems.AddRange(new[] {
          "root/level1folder1",
          "root/level1folder2",
          "root/level1folder2/level2folder1",
          "root/level1folder3",
          "root/level1folder3/level2folder2",
          "root/level1folder3/level2folder3",
          "root/level1folder3/level2folder4",
          "root/level1folder3/level2folder4/level3folder1",
          "root/level1folder3/level2folder4/level3folder2",
          "root/level1folder4",
          "root/level1folder4/level2folder5",
          "root/level1folder4/level2folder5/level3folder3",
          "root/level1folder4/level2folder5/level3folder3/level4folder1",
          "root/level1folder4/level2folder5/level3folder3/level4folder2",
      });
    }

    private void EnsureIsFileSystemItem(string path)
    {
        var pattern = @"^\/|(\/[a-zA-Z0-9_-]+)+$";
        if (string.IsNullOrEmpty(path) || !Regex.IsMatch(path, pattern))
        {
            throw new NotAnItemException();
        }
    }

    private void EnsureExists(string path)
    {
        if (string.IsNullOrEmpty(path) || !_existingItems.Contains(path))
        {
            throw new ItemNotFoundException();
        }
    }

    private void EnsureEmpty(string path)
    {
        EnsureExists(path);
        if (!IsEmpty(path))
        {
            throw new ItemNotEmptyException();
        }
    }

    public string[] GetExistingItems()
    {
        string[] result = null;
        lock (this)
        {
            result = _existingItems.ToArray();
        }
        return result;
    }

    /// <summary>
    /// Deletes the item on specified path
    /// </summary>
    /// <param name="path">Path to an item on the file system.</param>
    /// <exception cref="NotAnItemException">Thrown when specified path is not valid path for the file system.</exception>
    /// <exception cref="ItemNotFoundException">Thrown when specified path is path to unexisting item.</exception>
    /// <exception cref="ItemNotEmptyException">Thrown when specified path is path to non-empty item.</exception>
    public void Delete(string path)
    {
        EnsureIsFileSystemItem(path);
        EnsureExists(path);
        EnsureEmpty(path);
        _existingItems.Remove(path);
        _deletedItems.Add(path);
    }

    /// <summary>
    /// Indicates whether specified path is path to an empty item on the file system. 
    /// </summary>
    /// <param name="path">Path to an item on the file system.</param>
    /// <returns><see cref="true"/> is path is an empty item, <see cref="false"/> if item has child items.</returns>
    /// <exception cref="NotAnItemException">Thrown when specified path is not valid path for the file system.</exception>
    /// <exception cref="ItemNotFoundException">Thrown when specified path is path to unexisting item.</exception>
    public bool IsEmpty(string path)
    {
        EnsureIsFileSystemItem(path);
        EnsureExists(path);
        foreach (var existingItem in _existingItems)
        {
            if (existingItem != path && existingItem.StartsWith(path))
            {
                return false;
            }
        }
        return true;
    }
}



public class FileSystemCleaner
{
    private FileSystem _fileSystem;
    public FileSystemCleaner(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    private bool IsEmpty(string path)
    {
        return _fileSystem.IsEmpty(path);
    }

    private void Delete(string path)
    {
        _fileSystem.Delete(path);
    }

    /// <summary>
    /// Deletes empty items from the specified paths. 
    /// If deletion of an item makes another item specified in <paramref name="paths"/> empty, the latter is expected to be deleted as well.
    /// </summary>
    /// <param name="paths">List of paths to items on the file system.</param>   
    public void DeleteEmptyItems(List<string> paths)
    {
        var depthMap = new Dictionary<string, int>();

        foreach (var path in paths)
        {
            var depth = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Count();
            if (!depthMap.ContainsKey(path))
            {
                depthMap.Add(path, depth);
            }
        }

        foreach (var pathDepth in depthMap.OrderByDescending(dp => dp.Value))
        {
            var path = pathDepth.Key;

            try
            {
                if (IsEmpty(path))
                {
                    Delete(path);
                }
            }
            catch (Exception)
            {
                continue;
            }
        }
    }
}


class Solution
{
    public static void Main()
    {
        TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<string> paths = new List<string>();

        while (true)
        {
            var inputPath = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputPath))
            {
                paths.Add(inputPath);
            }
            else
            {
                break;
            }
        }

        var fs = new FileSystem();
        var fsCleaner = new FileSystemCleaner(fs);

        fsCleaner.DeleteEmptyItems(paths);

        var actual = fs.GetExistingItems();
        textWriter.WriteLine("File System Items After Cleanup:\n");
        textWriter.WriteLine(String.Join("\n", actual));

        textWriter.Flush();
        textWriter.Close();
    }
}

using System;
using System.IO;
using System.Collections.Generic;

public class DFS
{
    // Traverse a given directory using DFS to find specified file
    public static void folder_crawling(string start, string find)
    {
        // get the list of all files and directories in starting directory
        string[] list_of_files_and_directories = Directory.GetFileSystemEntries(start, "*", SearchOption.TopDirectoryOnly);

        // check whether list_of_files_and_directories is null or not
        if (list_of_files_and_directories != null)
        {
            // iterate every files and directories in the list_of_files_and_directories
            foreach (string path in list_of_files_and_directories)
            {
                // if the current path is a directory, recur for it
                if (Directory.Exists(path))
                {
                    folder_crawling(path,"asd");
                }
                else
                {
                    // if file found write "File found!", otherwise write "File not found!", äsda
                    if (find.Equals(path))
                    {
                        Console.WriteLine("File found!");
                    }
                    else
                    {
                        Console.WriteLine("File not found!");
                    }
                }
            }
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;

public class BFS
{
    // Traverse a given directory using BFS to find specified file
    public static void folder_crawling(string start, string find)
    {
        // Create queue to store directories
        Queue<string> queue = new Queue<string>();

        // initialize a boolean variable
        bool found = false;

        // add starting directory to queue
        queue.Enqueue(start);

        // loop until whether specified file is found or not
        do
        {
            // get the next file/directory from queue
            string current_dir = queue.Dequeue();

            // get the list of all files and directories in current_dir
            string[] list_of_files_and_directories = Directory.GetFileSystemEntries(current_dir, "*", SearchOption.TopDirectoryOnly);

            // check whether list_of_files_and_directories is null or not
            if (list_of_files_and_directories != null)
            {
                // iterate every files and directories in the list_of_files_and_directories
                foreach (string path in list_of_files_and_directories)
                {
                    // if the current path is a directory, add path to queue
                    if (Directory.Exists(path))
                    {
                        queue.Enqueue(path);
                    }
                    else
                    {
                        // if file found set found variable to true
                        if (find.Equals(path))
                        {
                            found = true;
                        }
                    }
                }
            }
        } while (!found);
        
        // if file found write "File found!", otherwise write "File not found!"
        if (found)
        {
            Console.WriteLine("File found!");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    } 
}

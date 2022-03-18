using System;
using System.IO;
using System.Collections.Generic;

namespace BFSFolderCrawler
{
    public class BFS
    {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private DirectoryInfo tail;
        private Microsoft.Msagl.Drawing.Graph graph;

        public BFS(string file_name, bool allOccurance)
        {
            this.file_name = file_name;
            this.found = false;
            this.allOccurance = allOccurance;
        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }

        public Microsoft.Msagl.Drawing.Graph buildGraph(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.startFullPath = dirpath;
            this.graph.AddNode(getFolderOfPath(dirpath));
            folder_crawling(dirpath);
            return this.graph;
        }

        // Traverse a given directory using BFS to find specified file
        public static void folder_crawling(string dirpath)
        {
            // Create queue to store directories
            Queue<string> queue = new Queue<string>();

            // initialize a boolean variable
            bool found = false;

            // add starting directory to queue
            queue.Enqueue(dirpath);

            // loop until whether specified file is found or not
            do
            {
                // get the next file/directory from queue
                string current_dir = queue.Dequeue();

                DirectoryInfo dir = new DirectoryInfo(current_dir);

                // get the list of all files and directories in current_dir
                string[] list_of_files_and_directories = Directory.GetFileSystemEntries(dir.FullName, "*", SearchOption.TopDirectoryOnly);

                // iterate every files and directories in the list_of_files_and_directories
                foreach (string path in list_of_files_and_directories)
                {
                    // if the current path is a directory, add path to queue
                    if (Directory.Exists(path))
                    {
                        queue.Enqueue(path);
                        this.graph.AddEdge(dir.Name, getFolderOfPath(path));
                        folder_crawling(path);
                    }
                    else
                    {
                        if (Path.GetFileName(path) == this.file_name)
                        {
                            this.graph.AddEdge(dir.Name, Path.GetFileName(path)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            this.graph.FindNode(Path.GetFileName(path)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            this.tail = dir;
                            while (this.tail.FullName != this.startFullPath)
                            {
                                this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                this.graph.AddEdge(this.tail.Parent.Name, this.tail.Name).Attr.Color= Microsoft.Msagl.Drawing.Color.Green; ;
                                this.tail = this.tail.Parent;
                            }
                            this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                            if (!this.allOccurance)
                            {
                                this.found = true;
                                return;
                            }
                        }
                        else
                        {
                            this.graph.AddEdge(dir.Name,Path.GetFileName(file));
                        }
                    }
                }
            } while (queue.Count() != 0 && !found);
        } 
    }
}
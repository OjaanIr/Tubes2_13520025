using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DFSFolderCrawler
{
    public class DFS
    {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private DirectoryInfo tail;
        private Microsoft.Msagl.Drawing.Graph graph;

        public DFS(string file_name, bool allOccurance)
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

        // Traverse a given directory using DFS to find specified file
        public static void folder_crawling(string dirpath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirpath);
            // get the list of all files and directories in starting directory
            string[] list_of_files_and_directories = Directory.GetFileSystemEntries(dir.FullName, "*", SearchOption.TopDirectoryOnly);

            // iterate every files and directories in the list_of_files_and_directories
            foreach (string path in list_of_files_and_directories)
            {
                // if the current path is a directory, recur for it
                if (Directory.Exists(path))
                {
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
        }
    }
}
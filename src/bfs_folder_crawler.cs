using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BFSFolderCrawler
{
        class Edge
        {
            private string start;
            private string end;
            private string color; // set either black or red or green

            public Edge(string start, string end)
            {
                this.start = start;
                this.end = end;
                this.color = "black"; //basic color is black (havent checked all)
            }

            public void setColorRed()
            {
                this.color = "red";
            }

            public void setColorGreen()
            {
                this.color = "green";
            }

            public void setColorBlack()
            {
                this.color = "black";
            }

            public string getEnd()
            {
                return this.end;
            }

            public string getStart()
            {
                return this.start;
            }

            public bool isEdgeInList(List<Edge> edges)
            {
                bool isFound = false;
                edges.ForEach(e =>
                {
                    if(e.start == this.start && e.end == this.end)
                    {
                        isFound = true;
                    }

                });

                return isFound;
            }

            public int getIdx(List<Edge> edges)
            {
                int i = 0;
                int idx = 0;
                bool isFound=false;
                edges.ForEach(e =>
                {
                    if (e.start == this.start && e.end == this.end)
                    {
                        i = idx;
                        isFound = true;

                    }
                    else
                    {
                        idx++;
                    }

                });
                if(isFound) return i ;
                else
                {
                    return -1;
                }
            }
        }

    public class FileDestination
    {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private DirectoryInfo tail;
        private List<Edge> redArr;
        private List<Edge> greenArr;
        private List<Edge> blackArr;
        private Microsoft.Msagl.Drawing.Graph graph;

        public FileDestination(string nama, bool semua) {
            file_name = nama;
            found = false;
            allOccurance = semua;
        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }

        public Microsoft.Msagl.Drawing.Graph BFS(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.startFullPath = dirpath;
            this.graph.AddNode(getFolderOfPath(dirpath));
            this.greenArr = new List<Edge>();
            this.redArr = new List<Edge>();
            this.blackArr = new List<Edge>();
            recBFS(dirpath);
            return this.printGraph();
        }

        // Traverse a given directory using BFS to find specified file
        public static void recBFS(string dirpath)
        {
            // Create queue to store directories
            Queue<string> queue = new Queue<string>();

            // List<bool> visited = new List<bool>(); 

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
                        // this.graph.AddEdge(dir.Name, getFolderOfPath(path));
                        // folder_crawling(path);
                    }
                    else
                    {
                        if (!this.found)
                        {
                            if (Path.GetFileName(path) == this.file_name)
                            {
                                Edge x = new Edge(dir.Name, Path.GetFileName(path));
                                this.greenArr.Add(x);
                                this.tail = dir;
                                while(this.tail.FullName != this.startFullPath)
                                {
                                    Edge y = new Edge(this.tail.Parent.Name, this.tail.Name);
                                    int idxInR = y.getIdx(this.redArr);
                                    if (idxInR != -1)
                                    {
                                        this.redArr.RemoveAt(idxInR);
                                    }
                                    int idxInB = y.getIdx(this.blackArr);
                                    if (idxInB!=-1)
                                    {
                                        this.blackArr.RemoveAt(idxInB);
                                    }
                                    this.greenArr.Add(y);

                                    this.tail = this.tail.Parent;

                                }
                                //this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                                if (!this.allOccurance)
                                {
                                    this.found = true;
                                }
                            }
                            else
                            {
                                // this.graph.AddEdge(dir.Name,Path.GetFileName(file));
                                Edge e = new Edge(dir.Name, Path.GetFileName(file));
                                this.redArr.Add(e);
                            }

                            this.tail = dir;
                            while (this.tail.FullName != this.startFullPath)
                            {
                                Edge y = new Edge(this.tail.Parent.Name, this.tail.Name);
                                if (!y.isEdgeInList(this.redArr))
                                {
                                    this.redArr.Add(y);
                                }

                                this.tail = this.tail.Parent;
                            }
                        }
                    }
                }
            } while (queue.Count() != 0 && !found);

            if (queue.Count() > 0)
            {
                foreach (string path in queue)
                {
                    DirectoryInfo path = new DirectoryInfo(path);
                    Edge e = new Edge(path.Parent.Name, path.Name);
                    this.blackArr.Add(e);
                }
            }
        }

        public Microsoft.Msagl.Drawing.Graph printGraph()
        {
            this.greenArr.ForEach(e =>
            {
                this.graph.AddEdge(e.getStart(), e.getEnd()).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            });

            this.redArr.ForEach(e =>
            {
                this.graph.AddEdge(e.getStart(), e.getEnd()).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            });
            return this.graph;
        } 
    }
}
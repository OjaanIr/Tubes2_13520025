using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dfsDavin
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
    class FileDestination {
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

        public Microsoft.Msagl.Drawing.Graph DFS(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.startFullPath = dirpath;
            this.graph.AddNode(getFolderOfPath(dirpath));
            this.greenArr = new List<Edge>();
            this.redArr = new List<Edge>();
            this.blackArr = new List<Edge>();

            recDFS(dirpath);

            return this.printGraph();
        }
        public void recDFS(string dirpath)
        {

            DirectoryInfo dir = new DirectoryInfo(dirpath);
            //Console.WriteLine(dir.FullName);
            string[] filePaths = Directory.GetFiles(dir.FullName, "*");
            if (filePaths.Length == 0) { 
            }
            foreach (string file in filePaths)
            {
                if (this.found != true)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        //Console.WriteLine(Path.GetFileName(file) + " ketemu");
                        Edge x = new Edge(dir.Name, Path.GetFileName(file));
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
                        //Console.WriteLine(Path.GetFileName(file));
                        Edge e = new Edge(dir.Name, Path.GetFileName(file));
                        this.redArr.Add(e);
                    }
                
                    if(this.found != true)
                    {
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
            string[] children = Directory.GetDirectories(dir.FullName, "*", SearchOption.TopDirectoryOnly);
            if (this.found != true)
            {
                foreach (string child in children)
                {
                    //this.graph.AddEdge(dir.Name, getFolderOfPath(child));
                    this.recDFS(child);
                }
                //if this.head in childern:
                //this.head = parent
                //coloring parent
            }
        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
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

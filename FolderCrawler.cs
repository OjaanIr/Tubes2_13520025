using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderCrawler
{
  
    class FileDestination {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private List<string> redArr;
        private List<string> greenArr;
        private List<string> blackArr;
        protected List<string> answer = new List<string>();
        private Microsoft.Msagl.Drawing.Graph graph;

        public List<string> getAnswer()
        {
            return answer;
        }

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
            this.greenArr = new List<string>();
            this.redArr = new List<string>();
            this.blackArr = new List<string>();

            recDFS(dirpath);

            return this.printGraph();
        }
        public void recDFS(string dirpath)
        {

            DirectoryInfo dir = new DirectoryInfo(dirpath);
            //Console.WriteLine(dir.FullName);
            string[] filePaths = Directory.GetFiles(dir.FullName, "*");

            foreach (string file in filePaths)
            {
                if (this.found != true)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        this.answer.Add(file);
                        this.greenArr.Add(file);
                        this.getGreenNode(dir.FullName);


                        if (!this.allOccurance)
                        {
                            this.found = true;
                        }
                    }
                    else
                    {

                        this.redArr.Add(file);
                    }
                
                    if(this.found != true)
                    {
                        this.getRedNode(dir.FullName);
                    }
                }
            }
            string[] children = Directory.GetDirectories(dir.FullName, "*", SearchOption.TopDirectoryOnly);
            if (this.found != true)
            {
                foreach (string child in children)
                {

                    this.blackArr.Add(child);
                    this.recDFS(child);
                }

            }
        }

        public Microsoft.Msagl.Drawing.Graph BFS(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.startFullPath = dirpath;
            this.graph.AddNode(getFolderOfPath(dirpath));

            this.greenArr = new List<string>();
            this.redArr = new List<string>();
            this.blackArr = new List<string>();

            solveBFS(dirpath);
            
            return this.printGraph();
        }
        public void solveBFS(string dirpath)
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(dirpath);

            do
            {
                string current_dir = queue.Dequeue();
                DirectoryInfo dir = new DirectoryInfo(current_dir);
                string[] filePaths = Directory.GetFiles(dir.FullName, "*");

                foreach (string file in filePaths)
                {
                    if (this.found != true)
                    {
                        if (Path.GetFileName(file) == this.file_name)
                        {
                            this.answer.Add(file);
                            this.greenArr.Add(file);
                            this.getGreenNode(dir.FullName);

                            if (!this.allOccurance)
                            {
                                this.found = true;
                            }
                        }
                        else
                        {
                            this.redArr.Add(file);
                        }

                        if (this.found != true)
                        {
                            this.getRedNode(dir.FullName);
                        }
                    }
                }
                string[] children = Directory.GetDirectories(@dir.FullName, "*", SearchOption.TopDirectoryOnly);
                foreach (string child in children)
                {
                    this.blackArr.Add(child);
                    queue.Enqueue(child);
                }
            } while (queue.Count() != 0 && !this.found);

            if (queue.Count() > 0)
            {
                foreach (string path in queue)
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    this.getBlackNode(dir.FullName);
                }
            }
        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }

        public void getBlackNode(string path)
        {

            while (!(this.greenArr.Contains(path) || this.blackArr.Contains(path)) && path!=this.startFullPath){
                this.blackArr.Add(path);
                DirectoryInfo p = new DirectoryInfo(@path);
                path = p.Parent.FullName;
            }
        }

        public void getRedNode(string path)
        {

            while (!(this.greenArr.Contains(path) || this.redArr.Contains(path)) && path != this.startFullPath)
            {
                if (this.blackArr.Contains(path))
                {
                    this.blackArr.Remove(path);
                }
                this.redArr.Add(path);
                DirectoryInfo pr = new DirectoryInfo(@path);
                 
            }
        }

        public void getGreenNode(string path)
        {
            while(!this.greenArr.Contains(path)&& this.startFullPath!= path)
            {
                if (this.redArr.Contains(path))
                {
                    this.redArr.Remove(path);
                }
                if (this.blackArr.Contains(path))
                {
                    this.blackArr.Remove(path);
                }
                this.greenArr.Add(path);
                DirectoryInfo p = new DirectoryInfo(@path);
                path = p.Parent.FullName;
            }
        }

        public Microsoft.Msagl.Drawing.Graph printGraph()
        {
            DirectoryInfo p = new DirectoryInfo((this.startFullPath));
            if (this.greenArr.Count != 0)
            {
                this.graph.AddNode(p.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            }
            this.greenArr.ForEach(p =>
            {

                DirectoryInfo s = new DirectoryInfo(@p);
                this.graph.AddEdge(s.Parent.Name, s.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                this.graph.FindNode(s.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            });

            this.redArr.ForEach(p =>
            {
                DirectoryInfo s = new DirectoryInfo(p);
                this.graph.AddEdge(s.Parent.Name, s.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            });

            this.blackArr.ForEach(p =>
            {
                DirectoryInfo s = new DirectoryInfo(p);
                this.graph.AddEdge(s.Parent.Name, s.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
            });
            return this.graph;
        }

    }
}
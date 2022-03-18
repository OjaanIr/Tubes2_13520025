using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dfsDavin
{
  
    class FileDestination {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private DirectoryInfo tail;
        private List<string> redArr;
        private List<string> greenArr;
        private List<string> blackArr;
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
            if (filePaths.Length == 0) { 
            }
            foreach (string file in filePaths)
            {
                if (this.found != true)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        //Console.WriteLine(Path.GetFileName(file) + " ketemu");
                        this.greenArr.Add(file);
                        this.tail = dir;
                        this.getGreenNode(dir.FullName);
                        //this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                        if (!this.allOccurance)
                        {
                            this.found = true;
                        }
                    }
                    else
                    {
                        //Console.WriteLine(Path.GetFileName(file));
                        this.redArr.Add(file);
                    }
                
                    if(this.found != true)
                    {
                        this.tail = dir;
                        while (!(this.redArr.Contains(dir.FullName) || this.greenArr.Contains(dir.FullName)))
                        {
                            this.redArr.Add(dir.FullName);

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
                    this.blackArr.Add(child);
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

        public void getBlackNode(string path)
        {

            while (!(this.greenArr.Contains(path) || this.blackArr.Contains(path) && path!=this.startFullPath)){
                this.blackArr.Add(path);
                DirectoryInfo p = new DirectoryInfo(@path);
                path = p.Parent.FullName;
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
            this.greenArr.ForEach(p =>
            {
                DirectoryInfo s = new DirectoryInfo(@p);
                this.graph.AddEdge(s.Parent.Name, s.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            });

            this.redArr.ForEach(p =>
            {
                DirectoryInfo s = new DirectoryInfo(p);
                this.graph.AddEdge(s.Parent.Name, s.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            });
            return this.graph;
        }

    }
   

    
    

}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bfsDavin
{
    class FileDestination {
        private string file_name;
        private string startFullPath;
        private bool found;
        private bool allOccurance;
        private DirectoryInfo tail;
        private Microsoft.Msagl.Drawing.Graph graph;

        public FileDestination(string nama, bool semua) {
            file_name = nama;
            found = false;
            allOccurance = semua;
        }

        public Microsoft.Msagl.Drawing.Graph BFS(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.startFullPath = dirpath;
            this.graph.AddNode(getFolderOfPath(dirpath));
            DirectoryInfo dir = new DirectoryInfo(dirpath);
            this.solveBFS(dir);
            recBFS(dirpath);
            return this.graph;
        }
        public void recBFS(string dirpath)
        {

            DirectoryInfo dir = new DirectoryInfo(dirpath);
            /*
            //Console.WriteLine(dir.FullName);
            string[] filePaths = Directory.GetFiles(dir.FullName, "*");
            foreach (string file in filePaths)
            {
                if (this.found != true)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        //Console.WriteLine(Path.GetFileName(file) + " ketemu");
                        this.graph.AddEdge(dir.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                        this.graph.FindNode(Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                        this.tail = dir;
                        while(this.tail.FullName != this.startFullPath)
                        {
                            this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            this.graph.AddEdge(this.tail.Parent.Name, this.tail.Name).Attr.Color= Microsoft.Msagl.Drawing.Color.Green; ;
                            this.tail = this.tail.Parent;
                        }
                        this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                        //
                        if (this.allOccurance == false)
                        {
                            this.found = true;
                            return;
                            //System.Environment.Exit(0);
                        }
                    }
                    else
                    {
                        //Console.WriteLine(Path.GetFileName(file));
                        this.graph.AddEdge(dir.Name,Path.GetFileName(file));

                    }
                }
            }*/
            string[] children = Directory.GetDirectories(dir.FullName, "*", SearchOption.TopDirectoryOnly);
            if (this.found != true)
            {
                foreach (string child in children)
                {
                    DirectoryInfo childdir = new DirectoryInfo(child);
                    this.solveBFS(childdir);
                    this.graph.AddEdge(dir.Name, getFolderOfPath(child));
                }
                foreach (string child in children)
                {
                    this.recBFS(child);
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

        public void solveBFS(DirectoryInfo dir){
            string[] filePaths = Directory.GetFiles(dir.FullName, "*");
            foreach (string file in filePaths)
            {
                if (this.found != true)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        //Console.WriteLine(Path.GetFileName(file) + " ketemu");
                        this.graph.AddEdge(dir.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                        this.graph.FindNode(Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                        this.tail = dir;
                        while(this.tail.FullName != this.startFullPath)
                        {
                            this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            this.graph.AddEdge(this.tail.Parent.Name, this.tail.Name).Attr.Color= Microsoft.Msagl.Drawing.Color.Green; ;
                            this.tail = this.tail.Parent;
                        }
                        this.graph.FindNode(this.tail.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                        //
                        if (this.allOccurance == false)
                        {
                            this.found = true;
                            return;
                            //System.Environment.Exit(0);
                        }
                    }
                    else
                    {
                        //Console.WriteLine(Path.GetFileName(file));
                        this.graph.AddEdge(dir.Name,Path.GetFileName(file));

                    }
                }
            }       
        }
    }
}
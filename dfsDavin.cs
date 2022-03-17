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
        private bool found;
        private bool allOccurance;
        private Microsoft.Msagl.Drawing.Graph graph;

        public FileDestination(string nama, bool semua) {
            file_name = nama;
            found = false;
            allOccurance = semua;
        }

        public Microsoft.Msagl.Drawing.Graph DFS(string dirpath)
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.graph.AddNode(getFolderOfPath(dirpath));


            recDFS(dirpath);
            return this.graph;
        }
        public void recDFS(string dirpath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirpath);
            //Console.WriteLine(dir.FullName);
            string[] filePaths = Directory.GetFiles(dir.FullName, "*");
            foreach (string file in filePaths)
            {
                if (this.found == false)
                {
                    if (Path.GetFileName(file) == this.file_name)
                    {
                        //Console.WriteLine(Path.GetFileName(file) + " ketemu");
                        this.graph.AddEdge(dir.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

                        //this.found = true;
                        if (this.allOccurance == false)
                        {
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
            string[] children = Directory.GetDirectories(dir.FullName, "*", SearchOption.TopDirectoryOnly);
            if (this.found == false)
            {
                foreach (string child in children)
                {
                    this.graph.AddEdge(dir.Name, getFolderOfPath(child));
                    this.DFS(child);
                }
            }
        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }
    }
   

    
    

}

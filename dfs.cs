using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dfs
{
    class FileDestination {
        public string file_name;
        public bool found;

        public FileDestination(string nama) {
            file_name = nama;
            found = false;
        }
    }
    static void DFS(string dirpath,FileDestination fl) {
        dir = new DirectoryInfo(dirpath);
        Console.WriteLine("cek "+dir.FullName);
        string[] filePaths = Directory.GetFiles(dir.FullName,"*.*");
        foreach(string file in filePaths) {
            if (fl.found == false) {
                if (Path.GetFileName(file) == fl.file_name) {
                    Console.WriteLine(Path.GetFileName(file) + " ketemu");
                    fl.found = true;
                    return;
                    //System.Environment.Exit(0);
                }
                else {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
        }
        string[] children = Directory.GetDirectories(dir.FullName,"*",SearchOption.TopDirectoryOnly);
        if (fl.found==false) {
            foreach (string child in children) {
                DFS(child, fl);
            }
        }
    }

    
    static void Main(string[] args) {
        Console.WriteLine("file dicari : ");
        string file_name = Console.ReadLine();
        FileDestination filed = new FileDestination(namafile);
        DFS(@"D:\for_testing", filed);
    }

}

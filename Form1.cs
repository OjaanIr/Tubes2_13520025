using System;
using System.IO;
using dfsDavin;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rootDir = label1.Text;
            string lookFor = textBox1.Text;
            bool isFindAll = isAllOccurance.Checked;
            string[] dirs = Directory.GetDirectories(@rootDir, "*", SearchOption.AllDirectories);
            string dirName = getFolderOfPath(rootDir);
            string[] filePaths = Directory.GetFiles(@rootDir, "*", SearchOption.TopDirectoryOnly);
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph;

            if (rootDir== "No Directory Selected")
            {
                return;
            }
            //string mode;
            if (radioBFS.Checked && lookFor!="")
            {
                //mode = "BFS";
            }
            else if(radioDFS.Checked && lookFor !="")
            {
                //mode = "DFS";
                
                

            }
            else
            {
                return;
            }
            FileDestination filed = new FileDestination(lookFor, isFindAll);
            graph = filed.DFS(rootDir);

            
            /*
            foreach (string dir in dirs)
            {
                string folderName = getFolderOfPath(dir);
                graph.AddEdge(dirName, folderName);
            }

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                graph.AddEdge(dirName, fileName);
            }
            */
            
            viewer.Graph = graph;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();


        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
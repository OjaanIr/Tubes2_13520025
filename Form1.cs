using System;
using System.IO;
using System.Text;
using dfsDavin;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private LinkLabel LinkLabel1;
        private string links;
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
            Form graphWin = new Form();
            string rootDir = label1.Text;
            string lookFor = textBox1.Text;
            bool isFindAll = isAllOccurance.Checked;
            string dirName = getFolderOfPath(rootDir);
            string[] filePaths = Directory.GetFiles(@rootDir, "*", SearchOption.TopDirectoryOnly);
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            if (rootDir== "No Directory Selected")
            {
                return;
            }
            var links = new List<LinkLabel.Link>();
            var stringBuilder = new StringBuilder();
            this.LinkLabel1 = new LinkLabel();
            this.LinkLabel1.AutoSize = true;
            //string mode;
            if (radioBFS.Checked && lookFor!="")
            {
                //mode = "BFS";
            }
            else if(radioDFS.Checked && lookFor !="")
            {
                FileDestination filed = new FileDestination(lookFor, isFindAll);
                graph = filed.DFS(rootDir);
                this.LinkLabel1.Text = "";
                int count = 0;
                filed.getAnswer().ForEach(x =>
                {
                    DirectoryInfo res = new DirectoryInfo(x);
                

                    count++;
                    this.LinkLabel1.Text += count + " ";
                    links.Add(new LinkLabel.Link(2*(count-1), 2*(count-1)+1, res.Parent.FullName));
                    
                });
                foreach(var link in links)
                {
                    this.LinkLabel1.Links.Add(link);
                }
                this.LinkLabel1.Location = new Point(10, graphWin.Height -100);
                this.LinkLabel1.LinkClicked += (s, e) => {
                    System.Diagnostics.Process.Start("explorer.exe", (string)e.Link.LinkData);
                };
                graphWin.Controls.Add(this.LinkLabel1);
                
            }
            else
            {
                return;
            }

            
         
            
            viewer.Graph = graph;
            graphWin.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            graphWin.Controls.Add(viewer);
            graphWin.ResumeLayout();
            graphWin.Show();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private string getFolderOfPath(string Path)
        {
            string dir = new DirectoryInfo(@Path).Name;
            return dir;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender,EventArgs e)
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
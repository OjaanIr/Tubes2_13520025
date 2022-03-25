namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBFS = new System.Windows.Forms.RadioButton();
            this.radioDFS = new System.Windows.Forms.RadioButton();
            this.isAllOccurance = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse Root";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchButton.Location = new System.Drawing.Point(183, 352);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(148, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "No Directory Selected";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(82, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 35);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search by Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // radioBFS
            // 
            this.radioBFS.AutoSize = true;
            this.radioBFS.Location = new System.Drawing.Point(199, 302);
            this.radioBFS.Name = "radioBFS";
            this.radioBFS.Size = new System.Drawing.Size(44, 19);
            this.radioBFS.TabIndex = 5;
            this.radioBFS.TabStop = true;
            this.radioBFS.Text = "BFS";
            this.radioBFS.UseVisualStyleBackColor = true;
            this.radioBFS.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioDFS
            // 
            this.radioDFS.AutoSize = true;
            this.radioDFS.Location = new System.Drawing.Point(275, 302);
            this.radioDFS.Name = "radioDFS";
            this.radioDFS.Size = new System.Drawing.Size(45, 19);
            this.radioDFS.TabIndex = 6;
            this.radioDFS.TabStop = true;
            this.radioDFS.Text = "DFS";
            this.radioDFS.UseVisualStyleBackColor = true;
            this.radioDFS.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // isAllOccurance
            // 
            this.isAllOccurance.AutoSize = true;
            this.isAllOccurance.Checked = true;
            this.isAllOccurance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAllOccurance.Location = new System.Drawing.Point(199, 167);
            this.isAllOccurance.Name = "isAllOccurance";
            this.isAllOccurance.Size = new System.Drawing.Size(142, 19);
            this.isAllOccurance.TabIndex = 7;
            this.isAllOccurance.Text = "Search All Possibilities";
            this.isAllOccurance.UseVisualStyleBackColor = true;
            this.isAllOccurance.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Haettenschweiler", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(182, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 50);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Crawler";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.isAllOccurance);
            this.Controls.Add(this.radioDFS);
            this.Controls.Add(this.radioBFS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button searchButton;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private RadioButton radioBFS;
        private RadioButton radioDFS;
        private CheckBox isAllOccurance;
        private Label label3;
    }
}
using TORServices.Forms;
using YoutubeDownloader.lib;

namespace YoutubeDownloader
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkAdd7 = new System.Windows.Forms.CheckBox();
            this.txtAddCri = new System.Windows.Forms.TextBox();
            this.chkAdd6 = new System.Windows.Forms.CheckBox();
            this.chkAdd5 = new System.Windows.Forms.CheckBox();
            this.chkAdd1 = new System.Windows.Forms.CheckBox();
            this.chkAdd2 = new System.Windows.Forms.CheckBox();
            this.chkAdd3 = new System.Windows.Forms.CheckBox();
            this.chkAdd4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SoundOnly = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new TORServices.Forms.DataGridViewProgressColumn();
            this.dataGridViewProgressColumn1 = new TORServices.Forms.DataGridViewProgressColumn();
            this.bkGetLink = new System.ComponentModel.BackgroundWorker();
            this.bkLoadFile = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myProgressBar1 = new YoutubeDownloader.lib.MyProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.chkAdd7);
            this.panel1.Controls.Add(this.txtAddCri);
            this.panel1.Controls.Add(this.chkAdd6);
            this.panel1.Controls.Add(this.chkAdd5);
            this.panel1.Controls.Add(this.chkAdd1);
            this.panel1.Controls.Add(this.chkAdd2);
            this.panel1.Controls.Add(this.chkAdd3);
            this.panel1.Controls.Add(this.chkAdd4);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.SoundOnly);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 115);
            this.panel1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::YoutubeDownloader.Properties.Resources._51266_mp3_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(1089, 8);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 45);
            this.button6.TabIndex = 28;
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = global::YoutubeDownloader.Properties.Resources.download;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(827, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 45);
            this.button2.TabIndex = 27;
            this.button2.Text = " load by mp3fromlink";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkAdd7
            // 
            this.chkAdd7.AutoSize = true;
            this.chkAdd7.Location = new System.Drawing.Point(595, 80);
            this.chkAdd7.Name = "chkAdd7";
            this.chkAdd7.Size = new System.Drawing.Size(48, 19);
            this.chkAdd7.TabIndex = 26;
            this.chkAdd7.Text = "Add";
            this.chkAdd7.UseVisualStyleBackColor = true;
            // 
            // txtAddCri
            // 
            this.txtAddCri.Location = new System.Drawing.Point(650, 77);
            this.txtAddCri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddCri.Name = "txtAddCri";
            this.txtAddCri.Size = new System.Drawing.Size(97, 23);
            this.txtAddCri.TabIndex = 25;
            // 
            // chkAdd6
            // 
            this.chkAdd6.AutoSize = true;
            this.chkAdd6.Location = new System.Drawing.Point(455, 78);
            this.chkAdd6.Name = "chkAdd6";
            this.chkAdd6.Size = new System.Drawing.Size(134, 19);
            this.chkAdd6.TabIndex = 24;
            this.chkAdd6.Text = "Add เพลงรวม/รวมเพลง";
            this.chkAdd6.UseVisualStyleBackColor = true;
            this.chkAdd6.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // chkAdd5
            // 
            this.chkAdd5.AutoSize = true;
            this.chkAdd5.Location = new System.Drawing.Point(367, 79);
            this.chkAdd5.Name = "chkAdd5";
            this.chkAdd5.Size = new System.Drawing.Size(82, 19);
            this.chkAdd5.TabIndex = 23;
            this.chkAdd5.Text = "Add Cover";
            this.chkAdd5.UseVisualStyleBackColor = true;
            this.chkAdd5.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // chkAdd1
            // 
            this.chkAdd1.AutoSize = true;
            this.chkAdd1.Location = new System.Drawing.Point(6, 81);
            this.chkAdd1.Name = "chkAdd1";
            this.chkAdd1.Size = new System.Drawing.Size(110, 19);
            this.chkAdd1.TabIndex = 22;
            this.chkAdd1.Text = "Add Official MV";
            this.chkAdd1.UseVisualStyleBackColor = true;
            this.chkAdd1.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // chkAdd2
            // 
            this.chkAdd2.AutoSize = true;
            this.chkAdd2.Location = new System.Drawing.Point(122, 81);
            this.chkAdd2.Name = "chkAdd2";
            this.chkAdd2.Size = new System.Drawing.Size(69, 19);
            this.chkAdd2.TabIndex = 21;
            this.chkAdd2.Text = "Add MV";
            this.chkAdd2.UseVisualStyleBackColor = true;
            this.chkAdd2.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // chkAdd3
            // 
            this.chkAdd3.AutoSize = true;
            this.chkAdd3.Location = new System.Drawing.Point(197, 80);
            this.chkAdd3.Name = "chkAdd3";
            this.chkAdd3.Size = new System.Drawing.Size(83, 19);
            this.chkAdd3.TabIndex = 20;
            this.chkAdd3.Text = "Add Audio";
            this.chkAdd3.UseVisualStyleBackColor = true;
            this.chkAdd3.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // chkAdd4
            // 
            this.chkAdd4.AutoSize = true;
            this.chkAdd4.Location = new System.Drawing.Point(286, 78);
            this.chkAdd4.Name = "chkAdd4";
            this.chkAdd4.Size = new System.Drawing.Size(75, 19);
            this.chkAdd4.TabIndex = 19;
            this.chkAdd4.Text = "Add Lyric";
            this.chkAdd4.UseVisualStyleBackColor = true;
            this.chkAdd4.Click += new System.EventHandler(this.checAdd_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(921, 79);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 19);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Create Folder";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::YoutubeDownloader.Properties.Resources.folder_music;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(1082, 76);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 27);
            this.button7.TabIndex = 17;
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::YoutubeDownloader.Properties.Resources._23227_broom_brush_clear_sweep_icon;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(1243, 14);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 45);
            this.button5.TabIndex = 15;
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(793, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 19);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "No More 5:00 min";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SoundOnly
            // 
            this.SoundOnly.AutoSize = true;
            this.SoundOnly.Location = new System.Drawing.Point(1147, 75);
            this.SoundOnly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SoundOnly.Name = "SoundOnly";
            this.SoundOnly.Size = new System.Drawing.Size(88, 19);
            this.SoundOnly.TabIndex = 10;
            this.SoundOnly.Text = "Sound Only";
            this.SoundOnly.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Out put:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(65, 12);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(673, 23);
            this.txtOutput.TabIndex = 8;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            this.txtOutput.Leave += new System.EventHandler(this.txtOutput_Leave);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::YoutubeDownloader.Properties.Resources.download;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(1243, 70);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 27);
            this.button4.TabIndex = 7;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::YoutubeDownloader.Properties.Resources.folder_music;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(746, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 27);
            this.button3.TabIndex = 6;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::YoutubeDownloader.Properties.Resources.search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(1025, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 27);
            this.button1.TabIndex = 4;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(65, 41);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(673, 23);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyDown);
            this.txtQuery.Leave += new System.EventHandler(this.txtQuery_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1366, 630);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Del";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Delete";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "File Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Link";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Duration";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Owner";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 180;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Progress..";
            this.Column5.Name = "Column5";
            this.Column5.ProgressBarColor = System.Drawing.Color.Red;
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 300;
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "Progress..";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ProgressBarColor = System.Drawing.Color.Red;
            this.dataGridViewProgressColumn1.ReadOnly = true;
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewProgressColumn1.Width = 300;
            // 
            // bkGetLink
            // 
            this.bkGetLink.WorkerReportsProgress = true;
            this.bkGetLink.WorkerSupportsCancellation = true;
            // 
            // bkLoadFile
            // 
            this.bkLoadFile.WorkerReportsProgress = true;
            this.bkLoadFile.WorkerSupportsCancellation = true;
            this.bkLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkLoadFile_DoWorkAsync);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myProgressBar1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 745);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 35);
            this.panel2.TabIndex = 2;
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.BackColor = System.Drawing.Color.White;
            this.myProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myProgressBar1.ForeColor = System.Drawing.Color.Blue;
            this.myProgressBar1.Location = new System.Drawing.Point(852, 0);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(504, 35);
            this.myProgressBar1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1356, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 35);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(852, 35);
            this.panel3.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(3, 1);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(24, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 780);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.Text = "Youtube Downloader by TOR";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutput;
        private DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.ComponentModel.BackgroundWorker bkGetLink;
        private System.ComponentModel.BackgroundWorker bkLoadFile;
        private System.Windows.Forms.CheckBox SoundOnly;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private DataGridViewProgressColumn Column5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private MyProgressBar myProgressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkAdd1;
        private System.Windows.Forms.CheckBox chkAdd2;
        private System.Windows.Forms.CheckBox chkAdd3;
        private System.Windows.Forms.CheckBox chkAdd4;
        private System.Windows.Forms.CheckBox chkAdd6;
        private System.Windows.Forms.CheckBox chkAdd5;
        private System.Windows.Forms.TextBox txtAddCri;
        private System.Windows.Forms.CheckBox chkAdd7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
    }
}
using YoutubeDownloader.lib;

namespace YoutubeDownloader
{
    partial class frmMp3Mng
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSetmp3gain = new System.Windows.Forms.Button();
            this.btnSetmp3tag = new System.Windows.Forms.Button();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArtis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpathS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myProgressBar1 = new MyProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnSetmp3gain);
            this.panel1.Controls.Add(this.btnSetmp3tag);
            this.panel1.Controls.Add(this.txtAlbum);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtArtis);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtpathS);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 214);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(553, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 25);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "เลือกตามโฟลเดอร์";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSetmp3gain
            // 
            this.btnSetmp3gain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetmp3gain.Location = new System.Drawing.Point(279, 177);
            this.btnSetmp3gain.Name = "btnSetmp3gain";
            this.btnSetmp3gain.Size = new System.Drawing.Size(145, 31);
            this.btnSetmp3gain.TabIndex = 9;
            this.btnSetmp3gain.Text = "set mp3gain";
            this.btnSetmp3gain.UseVisualStyleBackColor = true;
            this.btnSetmp3gain.Click += new System.EventHandler(this.btnSetmp3gain_Click);
            // 
            // btnSetmp3tag
            // 
            this.btnSetmp3tag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetmp3tag.Location = new System.Drawing.Point(127, 177);
            this.btnSetmp3tag.Name = "btnSetmp3tag";
            this.btnSetmp3tag.Size = new System.Drawing.Size(137, 31);
            this.btnSetmp3tag.TabIndex = 8;
            this.btnSetmp3tag.Text = "set mp3tag";
            this.btnSetmp3tag.UseVisualStyleBackColor = true;
            this.btnSetmp3tag.Click += new System.EventHandler(this.btnSetmp3tag_Click);
            // 
            // txtAlbum
            // 
            this.txtAlbum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAlbum.Location = new System.Drawing.Point(127, 90);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(404, 29);
            this.txtAlbum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(51, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Album";
            // 
            // txtArtis
            // 
            this.txtArtis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtArtis.Location = new System.Drawing.Point(127, 54);
            this.txtArtis.Name = "txtArtis";
            this.txtArtis.Size = new System.Drawing.Size(404, 29);
            this.txtArtis.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(63, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Artis";
            // 
            // txtpathS
            // 
            this.txtpathS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtpathS.Location = new System.Drawing.Point(127, 21);
            this.txtpathS.Name = "txtpathS";
            this.txtpathS.Size = new System.Drawing.Size(404, 29);
            this.txtpathS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path Source";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.myProgressBar1);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 176);
            this.panel2.TabIndex = 1;
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myProgressBar1.Location = new System.Drawing.Point(0, 127);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(907, 49);
            this.myProgressBar1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(24, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(19, 21);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "...";
            // 
            // frmMp3Mng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 390);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMp3Mng";
            this.Text = "Mp3Mng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private MyProgressBar myProgressBar1;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArtis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetmp3gain;
        private System.Windows.Forms.Button btnSetmp3tag;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox txtpathS;
    }
}
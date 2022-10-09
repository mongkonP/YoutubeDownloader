using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TORServices.Systems;

namespace YoutubeDownloader
{
    public partial class frmMp3Mng : Form
    {
        public frmMp3Mng()
        {
            InitializeComponent();
        }
        #region _Func


        void SetMp3tag()
        {

            lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file:"));
            List<string> lst = Directory.GetFiles(txtpathS.Text, "*.mp3", SearchOption.AllDirectories).ToList<string>();

            myProgressBar1.Invoke(new Action(() => { myProgressBar1.Minimum = 0; myProgressBar1.Value = 0; myProgressBar1.Maximum = lst.Count; }));

            // Create a scheduler that uses two threads.
            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(10);
            List<Task> tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();


            lst.ForEach(f =>
            {

                string _f = f;
                ID3.ID3Info iD3 = new ID3.ID3Info(f, true);

                string title = iD3.ID3v2Info.GetTextFrame("TIT2");

                if (string.IsNullOrEmpty(title) || title.Contains("๏"))
                {

                    lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file:" + _f));

                    iD3.ID3v2Info.SetTextFrame("TIT2", Path.GetFileNameWithoutExtension(_f));
                    iD3.ID3v2Info.SetTextFrame("TPE1", txtArtis.Text);
                    iD3.ID3v2Info.SetTextFrame("TALB", txtAlbum.Text);
                    iD3.Save(3);

                }


                myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value++; }));



            });




            lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file: complete"));
        }
        void _SetMP3Gain(string f)
        {
            if (!File.Exists(f)) return;
            lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file:" + f));
            string _f = f;
            /* try
             {*/
            Process process = new Process();
            process.StartInfo.FileName = Application.StartupPath + "mp3gain.exe";
            process.StartInfo.Arguments = "/c /r /d 5 \"" + f + "\"";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            /* process.StartInfo.CreateNoWindow = false;
             process.StartInfo.RedirectStandardOutput = true;
             process.StartInfo.RedirectStandardError = true;
             process.StartInfo.UseShellExecute = false;*/


            process.Start();
            process.WaitForExit();
            /*  }
                  catch { }*/
            if (myProgressBar1.Value < myProgressBar1.Maximum)
                myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value++; }));

            System.Threading.Thread.Sleep(1000);
        }
        void SetMP3Gain()
        {

            lblStatus.Invoke(new Action(() => lblStatus.Text = "SetMP3Gain file:"));
            List<string> lst = Directory.GetFiles(txtpathS.Text, "*.mp3", SearchOption.AllDirectories).ToList<string>();

            myProgressBar1.Invoke(new Action(() => { myProgressBar1.Minimum = 0; myProgressBar1.Value = 0; myProgressBar1.Maximum = lst.Count; }));

            // Create a scheduler that uses two threads.
            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(5);
            List<Task> tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();

            lst.ForEach(f =>
            {
                tasks.Add(Task.Factory.StartNew(() => _SetMP3Gain(f)));

            });
            // Wait for the tasks to complete before displaying a completion message.
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
            lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file: complete"));
        }


        void DeleteMp4File()
        {

            string pathS = txtpathS.Text;
            try
            {
                var files = (from fl in Directory.GetFiles(pathS, "*.mp4", SearchOption.AllDirectories)
                             where File.Exists(fl.Replace(".mp4", ".mp3"))
                             select fl)
                   .ToList<string>();
                if (files != null && files.Count > 0)
                {
                    files.ForEach(f =>
                    {
                        lblStatus.Invoke(new Action(() => lblStatus.Text = "Check:" + f));

                        try { File.Delete(f); } catch { }
                    });
                    lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file: complete"));

                }

                files = (from fl in Directory.GetFiles(pathS, "*.mkv", SearchOption.AllDirectories)
                         where File.Exists(fl.Replace(".mkv", ".mp3"))
                         select fl)
                   .ToList<string>();
                if (files != null && files.Count > 0)
                {
                    files.ForEach(f =>
                    {
                        lblStatus.Invoke(new Action(() => lblStatus.Text = "Check:" + f));

                        try { File.Delete(f); } catch { }
                    });
                    lblStatus.Invoke(new Action(() => lblStatus.Text = "Check file: complete"));

                }
            }
            catch { }



        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

            DeleteMp4File();


        }

        private void btnSetmp3gain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpathS.Text)) return;

            Task.Factory.StartNew(() => SetMP3Gain());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtAlbum.Text = Path.GetFileName(txtpathS.Text);

            }
            else
            {
                txtAlbum.Text = "";

            }
        }

        private void btnSetmp3tag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpathS.Text)) return;

            Task.Factory.StartNew(() => SetMp3tag());
        }
    }
}

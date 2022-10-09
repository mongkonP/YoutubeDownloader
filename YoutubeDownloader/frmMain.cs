using FFMpegCore;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

using Torservices.Network;
using TORServices.Forms;
using TORServices.PathFile;
using TORServices.Systems;
using VideoLibrary;
using YoutubeDownloader.lib;

namespace YoutubeDownloader
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        // int cTask;

        bool NoMore5Min = false; bool CheckAdd = false;
        private YouTube youTube = YouTube.Default;
        //  List<string> CriAll;
        int ir = 0; bool runLoad = false; string CriSong = "";
        long Alltotalbytes = 0;
        long Allcollectedbytes = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtQuery.Text = Properties.Settings.Default.LastQuery;
            txtOutput.Text = Properties.Settings.Default.OutputPath;
            // Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", "https://www.youtube.com//watch?v=iQS2hpS3T-M&list=PU1Typnbl8Q2Z6xPrDJPsuHw&index=311");
            // SoundOnly.Checked = true;
            // MessageBox.Show(Application.StartupPath + "\\Song-Artist\\Playlist song.txt");

            // Task.Factory.StartNew(()=>SetLoadLink())  ;
        }

        /* void SetLoadLink()
         {
             using (StreamReader reader = new StreamReader(Application.StartupPath + "Song-Artist\\Playlist song.txt"))
             {
                 foreach (var line in reader.ReadToEnd().Split('\n'))
                 {
                     lblStatus.Invoke(new Action(()=>lblStatus.Text =  "Add link:" + line)) ;
                     var youtubeLinks = YoutubeSearcher.GetYoutubeLinks(line);

                     lblStatus.Invoke(new Action(() =>lblStatus.Text = youtubeLinks.Count + "_/\\_" +  line))  ;
                     if (youtubeLinks != null)
                     {
                        //  MessageBox.Show(youtubeLinks.Count.ToString());
                         foreach (YoutubeLink link in youtubeLinks)
                         {
                                 TimeSpan timeSpan = link.Duration.ToTimeSpan();
                                 if (timeSpan.TotalMinutes < 5.50d && timeSpan.TotalMinutes > 2.00d)
                                 {
                                     this.dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add("delete", txtOutput.Text + "\\" + link.FileName, link.Link, link.Duration, link.OwnerName))); //+ ((query.Contains("http"))?"": cri + "\\")
                                     addIndext++;
                                 }

                         }
                     }

                     // getLoad(line);
                 }
                 lblStatus.Invoke(new Action(() =>  lblStatus.Text ="complete..."));
             }



         }*/
        #region _Setting
        private void txtQuery_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastQuery = txtQuery.Text;
            Properties.Settings.Default.Save();
        }



        private void txtOutput_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.OutputPath = txtOutput.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtOutput.Text = folder.SelectedPath;
                    Properties.Settings.Default.OutputPath = txtOutput.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }


        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text) || !Directory.Exists(txtOutput.Text)) return;
            Task.Factory.StartNew(() => CheckMakeValidFileName());

        }
        private void checAdd_Click(object sender, EventArgs e)
        {
            if (chkAdd1.Checked || chkAdd2.Checked || chkAdd3.Checked || chkAdd4.Checked
                  || chkAdd5.Checked || chkAdd6.Checked || chkAdd7.Checked)
            {
                CheckAdd = true;
            }
            else
            {
                CheckAdd = false;
            }
        }

        #endregion

        #region _get and load
        int addIndext = 1;
        void getLoadbyQuery(string query)
        {
            string _cri = Regex.Replace(query.Trim(), @"\r\n?|\n", "").Replace(Environment.NewLine, "");

            string pathFol = (checkBox2.Checked) ? txtOutput.Text + "\\" + TORServices.PathFile.FileTor.MakeValidFileName(_cri) : txtOutput.Text;
            if (!string.IsNullOrEmpty(_cri))
            {


                this.lblStatus.Write(" Add youtubeLinks = " + _cri);
                var youtubeLinks = new List<YoutubeLink>(); // YoutubeSearcher.GetYoutubeLinks(_cri);
                List<Task> tasks = new List<Task>();

                if (CheckAdd)
                {

                    if (chkAdd1.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} Official"))));
                    }
                    if (chkAdd2.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} MV"))));
                    }
                    if (chkAdd3.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} Audio"))));
                    }
                    if (chkAdd4.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} Lylic"))));
                    }
                    if (chkAdd5.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} Cover"))));
                    }
                    if (chkAdd6.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} รวมเพลง"))));
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} เพลงรวม"))));

                    }
                    if (chkAdd7.Checked)
                    {
                        tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks($"{_cri} {txtAddCri.Text}"))));
                    }


                }
                else
                {
                    tasks.Add(Task.Factory.StartNew(() => youtubeLinks.AddRange(YoutubeSearcher.GetYoutubeLinks(_cri))));
                }

                Task.WaitAll(tasks.ToArray());

                // MessageBox.Show("youtubeLinks = " + _cri + " cont:" + youtubeLinks.Count);
                this.lblStatus.Write("youtubeLinks = " + _cri + " cont:" + youtubeLinks.Count);
                addIndext = 1;
                // MessageBox.Show("" + youtubeLinks.Count);
                if (youtubeLinks.Count > 0)
                {
                    // MessageBox.Show(youtubeLinks.Count.ToString());
                    //  MessageBox.Show(NoMore5Min.ToString());

                    foreach (YoutubeLink link in youtubeLinks)
                    {

                        // MessageBox.Show(NoMore5Min.ToString());
                        /* if (!link.FileName.Contains(_cri))
                         {*/

                        if (NoMore5Min)
                        {

                            TimeSpan timeSpan = link.Duration.ToTimeSpan();
                            if (timeSpan.TotalMinutes < 6.50d && timeSpan.TotalMinutes > 2.00d)
                            {
                                this.dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add("delete", pathFol + "\\" + link.FileName, link.Link, link.Duration, link.OwnerName))); //+ ((query.Contains("http"))?"": cri + "\\")
                                addIndext++;
                            }
                        }
                        else
                        {
                            //  MessageBox.Show(link.FileName + "\n" + link.Link + "\nADD");
                            this.dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add("delete", pathFol + "\\" + link.FileName, link.Link, link.Duration, link.OwnerName))); //+ ((query.Contains("http"))?"": cri + "\\")
                            addIndext++;
                        }
                        // }
                    }
                }

            }


        }



        async Task getLoad(string query)
        {

            await Task.Factory.StartNew(() =>
            {

                NoMore5Min = checkBox1.Checked;
                if (string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Query cannot be empty");
                    return;
                }


                this.lblStatus.Write("Add link:" + query);

                //ถ้าค้นผ่านชื่อเว็บ หรือ url
                if (query.StartsWith("http"))
                {
                    //  getLoadbyQuery(query);

                    var youtubeLinks = YoutubeSearcher.GetYoutubeLinks(query);

                    if (youtubeLinks != null)
                    {
                        // MessageBox.Show(youtubeLinks.Count.ToString());
                        foreach (YoutubeLink link in youtubeLinks)
                        {



                            if (NoMore5Min)
                            {

                                TimeSpan timeSpan = link.Duration.ToTimeSpan();
                                if (timeSpan.TotalMinutes < 5.50d && timeSpan.TotalMinutes > 2.00d)
                                {
                                    this.dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add("delete", txtOutput.Text + "\\" + link.FileName, link.Link, link.Duration, link.OwnerName))); //+ ((query.Contains("http"))?"": cri + "\\")
                                    addIndext++;
                                }
                            }
                            else
                            {
                                //  MessageBox.Show(link.FileName + "\n" + link.Link + "\nADD");
                                this.dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add("delete", txtOutput.Text + "\\" + link.FileName, link.Link, link.Duration, link.OwnerName))); //+ ((query.Contains("http"))?"": cri + "\\")
                                addIndext++;
                            }
                        }
                    }

                }
                else //ค้นแบบคำค้น
                {
                    if (query.Contains(","))
                    {
                        var lst = query.Split(',');
                        if (lst != null || lst.Length > 0)
                        {
                            CriSong = "";
                            if (MessageBox.Show("ต้องการให้โหลดผ่าน IDM หรือไม่", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Load4SH(lst.ToList<string>());
                            }
                            else
                            {
                                myProgressBar1.Invoke(new Action(() => {
                                    myProgressBar1.Minimum = 0;
                                    myProgressBar1.Value = 0;
                                    myProgressBar1.Maximum = lst.Length;
                                }));
                                // Create a scheduler that uses two threads.
                                LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(10);
                                List<Task> tasks = new List<Task>();

                                // Create a TaskFactory and pass it our custom scheduler.
                                TaskFactory factory = new TaskFactory(lcts);
                                CancellationTokenSource cts = new CancellationTokenSource();


                                lst.ToList<string>()
                                         .ForEach(cri =>
                                         {
                                             tasks.Add(factory.StartNew(() => {
                                                 getLoadbyQuery(cri);
                                                 myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value++; }));
                                             }, cts.Token));
                                         });

                                //  this.lblStatus.Write("Add link complete");
                            }
                        }
                    }

                    else
                    {
                        getLoadbyQuery(query);

                    }
                }






                this.dataGridView1.Invoke(new Action(() => dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending)));
            });
            this.lblStatus.Write("Add complete :" + addIndext + " files");
        }

        void Load4SH(List<string> cris)
        {
            Ext.MusicPath = Ext._MusicPath();
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://4sh.xyz/%E0%B9%80%E0%B8%9E%E0%B8%A5%E0%B8%87.htm",
                UseShellExecute = true
            };
            string strThis = this.Text;
            this.myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value = 0; myProgressBar1.Minimum = 0; myProgressBar1.Maximum = cris.Count; }));
            Process.Start(psi);

            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(4);
            List<Task> tasks = new List<Task>();
            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();

            foreach (var cri in cris)
            {

                Task t = factory.StartNew(() => {

                    string _cri = cri.Replace(" ", "+");

                    for (int _i = 1; _i < 25; _i++)
                    {
                        //@"""white-space: nowrap""><a href=(https://.*?.mp3) title=""ดาวน์โหลด MP3 เพลง(.*?) คลิ๊กเลยครับ!!"" rel=nofollow onclick="
                        string html = TORServices.Network.WebHelper.getHTML("https://4sh.world/" + _cri + "-p" + _i + ".htm").Result;
                        foreach (Match myMatch in new Regex(@"white-space: nowrap""><a href=(https://.*?.mp3) title=""ดาวน์โหลด MP3 เพลง(.*?) คลิ๊กเลยครับ!!"" rel=nofollow onclick="".*?""color: #1265a8;"">([\d\s\.]+)[MBK]+</span></abbr", RegexOptions.None).Matches(html))
                        {
                            /* double size = double.Parse("0" + myMatch.Groups[2].Value.Trim());
                             if (size > 2.5 && size < 6.5)
                             */

                            string filesong = new Regex(@"(^[\d\.\s-_\)\(]+)", RegexOptions.Compiled).Replace(TORServices.PathFile.FileTor.MakeValidFileName(myMatch.Groups[2].Value.Trim()).Replace("\\", "_"), "").Trim() + ".mp3";//_FolSong + "\\" + 
                            string file = Ext.MusicPath + @"\" + cri + "\\" + filesong.Trim();//myMatch.Groups[2].Value.Trim()

                            if (!CriSong.Contains(filesong))
                            {
                                if (!File.Exists(file))
                                {
                                    this.Invoke(new Action(() => this.Text = file));
                                    lblStatus.Write(filesong);
                                    System.Diagnostics.Process.Start(Ext.IDMpath, "/a /n /d " + myMatch.Groups[1].Value.Replace(@"\/", "/") + "  /f \"" + cri + "\\" + filesong.Trim() + "\"");
                                    System.Threading.Thread.Sleep(1000);
                                    CriSong += "_" + filesong;
                                }
                                else
                                {
                                    this.Invoke(new Action(() => this.Text = file + " have File"));
                                }
                                filesong += "_" + filesong;
                            }



                            //}



                        }

                    }
                    this.myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value++; }));
                }, cts.Token);
                tasks.Add(t);



            }
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();

            this.Invoke(new Action(() => this.Text = strThis));
        }


        #endregion



        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getLoad(txtQuery.Text);
        }
        void LoadFile(DataGridViewRow r)
        {
            // MessageBox.Show(i.ToString());
            //  if (i > dataGridView1.RowCount - 1) return;

            DataGridViewRow row = r;
            lblStatus.Write("Load:" + row.Cells[1].Value.ToString());
            string name = row.Cells[1].Value.ToString() + ".mp4";
            string nameTemp = Path.GetTempPath() + "SongLoad\\" + Path.GetFileName(row.Cells[1].Value.ToString()) + ".mp4";
            string nameMP3 = row.Cells[1].Value.ToString() + ".mp3";

            //เช็คก่อนว่ามีไฟล์ไม๊
            if (File.Exists(name) || File.Exists(nameMP3))
            {
                dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 100));
                finish();
            }
            else
            {

                Directory.CreateDirectory(Path.GetDirectoryName(nameTemp));
                Directory.CreateDirectory(Path.GetDirectoryName(name));
                try
                {
                    var client = new HttpClient();
                    long? totalByte = 0;
                    var vid = youTube.GetVideo(row.Cells[2].Value.ToString());
                    dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 0));

                    long totalbytes = 0;
                    long collectedbytes = 0;


                    using (Stream output = File.OpenWrite(nameTemp))
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Head, vid.Uri))
                        {
                            totalByte = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result.Content.Headers.ContentLength;
                        }
                        totalbytes += (long)totalByte;
                        Alltotalbytes += (long)totalByte;
                        try
                        {
                            using (var input = client.GetStreamAsync(vid.Uri).Result)
                            {
                                byte[] buffer = new byte[16 * 1024];
                                int read;
                                int totalRead = 0;

                                while ((read = input.Read(buffer, 0, buffer.Length)) > 0 || collectedbytes < totalbytes)
                                {
                                    output.Write(buffer, 0, read);
                                    totalRead += read;
                                    collectedbytes += read;
                                    Allcollectedbytes += read;
                                    long x = collectedbytes * 80 / totalbytes;
                                    lblStatus.Write(TORServices.PathFile.FileTor.bytetobigger(Allcollectedbytes) + "/" + TORServices.PathFile.FileTor.bytetobigger(Alltotalbytes));
                                    try
                                    {
                                        dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = (int)x));
                                    }
                                    catch { }



                                }
                            }

                        }
                        catch
                        {
                            dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 100)); finish();
                        }

                    }
                    client.Dispose();
                    while (new FileInfo(nameTemp).Length < 10)
                    {
                        System.Threading.Thread.Sleep(10000);
                    }
                    if (SoundOnly.Checked)
                    {
                        //  _ = Task.Run(() => ConverttoMp3(nameTemp, nameMP3, rowIndex));

                        if (new FileInfo(nameTemp).Length < 10000) return;
                        try
                        {
                            System.Threading.Thread.Sleep(10000);

                            FFMpeg.ExtractAudio(nameTemp, nameTemp.Replace(".mp4", ".mp3"));
                            System.Threading.Thread.Sleep(10000);

                            File.Move(nameTemp.Replace(".mp4", ".mp3"), nameMP3);
                        }
                        catch { }
                        System.Threading.Thread.Sleep(1000);
                        Ext.fileDelete(nameTemp);
                        try
                        {

                            dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 100));
                            finish();
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {

                            File.Move(nameTemp, name);
                            dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 100));
                            finish();
                        }
                        catch { }
                    }

                }
                catch
                {
                    dataGridView1.Invoke((MethodInvoker)(() => row.Cells[5].Value = 100));
                    finish();
                }

                // finish();
            }



        }
        /* void LoadFile(int i)
         {
            // MessageBox.Show(i.ToString());
             if (i > dataGridView1.RowCount - 1 ) return;

            int rowIndex = i;
             lblStatus.Write("Load:" + dataGridView1[1, rowIndex].Value.ToString());
             string name = dataGridView1[1, rowIndex].Value.ToString() + ".mp4";
                 string nameTemp = Path.GetTempPath() + "SongLoad\\" + Path.GetFileName(dataGridView1[1, rowIndex].Value.ToString()) + ".mp4";
                 string nameMP3 = dataGridView1[1, rowIndex].Value.ToString() + ".mp3";

             //เช็คก่อนว่ามีไฟล์ไม๊
             if (File.Exists(name) || File.Exists(nameMP3))
                 {
                     dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = 100));
                     finish();
                 }
                 else
                 {

                     Directory.CreateDirectory(Path.GetDirectoryName(nameTemp));
                     Directory.CreateDirectory(Path.GetDirectoryName(name));
                     try
                     {
                             var client = new HttpClient();
                             long? totalByte = 0;
                             var vid = youTube.GetVideo(dataGridView1[2, rowIndex].Value.ToString());
                                 dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = 0));

                         long totalbytes = 0;
                         long collectedbytes = 0;


                         using (Stream output = File.OpenWrite(nameTemp))
                         {
                             using (var request = new HttpRequestMessage(HttpMethod.Head, vid.Uri))
                             {
                                 totalByte = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result.Content.Headers.ContentLength;
                             }
                             totalbytes += (long)totalByte;
                             Alltotalbytes += (long)totalByte;
                             try
                             {
                                 using (var input = client.GetStreamAsync(vid.Uri).Result)
                                 {
                                     byte[] buffer = new byte[16 * 1024];
                                     int read;
                                     int totalRead = 0;

                                     while ((read = input.Read(buffer, 0, buffer.Length)) > 0 || collectedbytes < totalbytes)
                                     {
                                         output.Write(buffer, 0, read);
                                         totalRead += read;
                                         collectedbytes += read;
                                         Allcollectedbytes += read;
                                         long x = collectedbytes * 80 / totalbytes;
                                         lblStatus.Write(TORServices.PathFile.FileTor.bytetobigger(Allcollectedbytes) + "/" + TORServices.PathFile.FileTor.bytetobigger(Alltotalbytes));
                                         try
                                         {
                                             dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = (int)x));
                                         }
                                         catch { }



                                     }
                                 }

                             }
                             catch 
                         { 
                             dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = 100)); finish();
                        }

                         }
                         client.Dispose();
                         while (new FileInfo(nameTemp).Length < 10)
                             {
                                 System.Threading.Thread.Sleep(10000);
                             }
                             if (SoundOnly.Checked)
                             {
                                 _ = Task.Run(() => ConverttoMp3(nameTemp, nameMP3, rowIndex));
                             }
                             else
                             {
                                 try
                                 {

                                     File.Move(nameTemp, name);
                                     dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = 100));
                         finish();
                     }
                                 catch { }
                             }

                     }
                     catch {
                     dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowIndex].Value = 100));
                     finish();
                 }

                    // finish();
                 }



         }*/
        private async void bkLoadFile_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.ReadOnly = true));
            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(10); //new LimitedConcurrencyLevelTaskScheduler((checkBox1.Checked)?10:4);
            List<Task> tasks = new List<Task>();
            // Create a TaskFactory and pass it our custom scheduler.
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();
            Alltotalbytes = 0;
            Allcollectedbytes = 0;

            myProgressBar1.Invoke(new Action(() => {
                myProgressBar1.Value = 0;
                myProgressBar1.Maximum = this.dataGridView1.RowCount;
            }));

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                runLoad = true;
                int index = i;
                tasks.Add(factory.StartNew(() => LoadFile(dataGridView1.Rows[index]), cts.Token));


            }


            Task.WaitAll(tasks.ToArray());
            cts.Dispose();


            dataGridView1.Invoke(new Action(() => dataGridView1.ReadOnly = false));
            runLoad = false;
        }

        void finish()
        {
            ir++;

            if (ir >= myProgressBar1.Maximum)
            {
                dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Clear()));
            }
            else
            {
                myProgressBar1.Invoke(new Action(() => myProgressBar1.Value++));
            }

        }
        /* void ConverttoMp3(string _nameTemp,string _nameMP3,int _rowindex = 0)
         {
             string nameTemp = _nameTemp, nameMP3= _nameMP3;
             int rowindex = _rowindex;
             if (new FileInfo(nameTemp).Length < 10000) return; 
             try
             {
                 System.Threading.Thread.Sleep(10000);

                 FFMpeg.ExtractAudio(nameTemp, nameTemp.Replace(".mp4", ".mp3"));
             System.Threading.Thread.Sleep(10000);

                 File.Move(nameTemp.Replace(".mp4", ".mp3"), nameMP3);
             }
             catch { }
             System.Threading.Thread.Sleep(1000);
             Ext.fileDelete(nameTemp);
             try
             {
                 if(rowindex < dataGridView1.RowCount)
                 dataGridView1.Invoke((MethodInvoker)(() => dataGridView1[5, rowindex].Value = 100));
             }
             catch { }

         }*/



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!runLoad)
                {
                    try
                    {

                        dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.RemoveAt(e.RowIndex)));
                        myProgressBar1.Invoke(new Action(() => { myProgressBar1.Maximum = this.dataGridView1.RowCount; }));
                    }
                    catch { }
                }
            }
        }


        #region _button Event

        private void button1_Click(object sender, EventArgs e)
        {
            getLoad(txtQuery.Text);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            lblStatus.Invoke(new Action(() => lblStatus.Text = "Start donwload files"));
            if (bkLoadFile.IsBusy != true)
            {

                bkLoadFile.RunWorkerAsync();
            }


        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => lib.Ext.DeleteMp4File(txtOutput.Text, this));
            Task.Factory.StartNew(() => CheckMakeValidFileName());
        }


        private void button7_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog file = new OpenFileDialog() { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" })
            {
                if (file.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader reader = new StreamReader(file.FileName))
                    {
                        getLoad(reader.ReadToEnd().Trim());
                    }
                }

            }


        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                myProgressBar1.Invoke(new Action(() => {
                    myProgressBar1.Value = 0;
                    myProgressBar1.Maximum = this.dataGridView1.RowCount;
                }));
                int c = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    runLoad = true;
                    int index = i;
                    if (!File.Exists(dataGridView1[1, i].Value.ToString()))
                    {
                        Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", dataGridView1[2, i].Value.ToString().Replace("www.youtube.com", "www.mp3fromlink.com"));
                        c++;
                        if (c >= 20)
                        {
                            System.Threading.Thread.Sleep(15000);
                            c = 0;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(3000);
                        }


                    }
                    myProgressBar1.Invoke(new Action(() => { myProgressBar1.Value++; }));
                }

            });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMp3Mng f = new frmMp3Mng();
            f.txtpathS.Text = txtOutput.Text;
            f.ShowDialog();

        }
        void CheckMakeValidFileName()
        {
            if (string.IsNullOrEmpty(txtOutput.Text.Trim())) return;
            lblStatus.Write("CheckMakeValidFileName");
            Directory.GetFiles(txtOutput.Text.Trim(), "*", SearchOption.AllDirectories).ToList<string>()
                .ForEach(f =>
                {
                    lblStatus.Write("Check:" + f);
                    string _f = Path.GetDirectoryName(f) + "\\" + TORServices.PathFile.FileTor.getFilerex(Path.GetFileNameWithoutExtension(f)) + Path.GetExtension(f);
                    if (_f != f)
                    {
                        try { File.Move(f, _f); } catch { File.Delete(f); }
                    }
                });
            lblStatus.Write("Check mp4 mp3");
            (from file in Directory.GetFiles(txtOutput.Text, "*.mp4")
             where File.Exists(file.Replace(".mp4", ".mp3"))
             select file)
             .ToList<string>()
             .ForEach(f =>
             {
                 lblStatus.Write("Check:" + f);
                 try { File.Delete(f); } catch { }
             });

            lblStatus.Write("Check: Complete");
        }
    }
}
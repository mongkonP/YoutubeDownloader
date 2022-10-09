using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader.lib
{
 public static   class Ext
    {
      public static  void DeleteMp4File(string pathS,Control control)
        {
            control.Invoke(new Action(() => control.Text = "DeleteMp4File"));

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

                        control.Invoke(new Action(() => control.Text = "Check:" + f));
                        try { File.Delete(f); } catch { }
                    });
                    control.Invoke(new Action(() => control.Text = "Check: complete"));
                }

                files = (from fl in Directory.GetFiles(pathS, "*.mkv", SearchOption.AllDirectories)
                         where File.Exists(fl.Replace(".mkv", ".mp3"))
                         select fl)
                   .ToList<string>();
                if (files != null && files.Count > 0)
                {
                    files.ForEach(f =>
                    {

                        control.Invoke(new Action(() => control.Text = "Check:" + f));
                        try { File.Delete(f); } catch { }
                    });
                    control.Invoke(new Action(() => control.Text = "Check: complete"));
                }
            }
            catch { }



        }
       public static string MusicPath = "";
        public static string _MusicPath()
        {
            string s = "";
            var bts = BitConverter.ToString((byte[])Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\DownloadManager\FoldersTree\Music", "pathW", true)).Trim();
            s = FromHexString(bts.Replace("-", ""));


            return s;

        }
        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }
        public static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
        public static byte[] FromHex(string hex)
        {

            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            MessageBox.Show(hex);
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        public static string IDMpath = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\DownloadManager", "ExePath", true).ToString();


       public static void fileDelete(string pa)
        {
            try
            {
                if (File.Exists(pa))
                    File.Delete(pa);
            }
            catch { }

        }
    }
}

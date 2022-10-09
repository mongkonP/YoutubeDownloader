using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TORServices.Systems;
using System.Threading;
using TORServices.PathFile;
using TORServices.Network;

namespace Torservices.Network
{
    public static class YoutubeSearcher
    {
        private const string URL = "http://www.youtube.com/results?search_query={0}&page={1}";

        private static string SongAll = "";

        private static int GetCountIndexPlaylist(string query)
        {
            try
            {
                string html = query.getHTML().Result;
                return int.Parse(new Regex(@"{""webCommandMetadata"":{""url"":""/playlist\?list=.{25,40}\.*?playnext=\d{1,}\.*?index=(\d{1,})"",""webPageType""", RegexOptions.None).Matches(html)[0].Groups[1].Value);

            }
            catch
            {
                return 0;
            }

        }

        private static string GetPlaylistName(string query)
        {
            string s = "";
            try
            {
                string html;
                if (query.StartsWith("http"))
                    html = query.getHTML().Result;
                else
                    html = query;
                s = new Regex(@"""playlist"":{""playlist"":{""title"":""(.*?)"",""contents""", RegexOptions.None).Matches(html)[0].Groups[1].Value;

            }
            catch
            {

            }
            return s.getFilerex();

        }
        private static string GetTitletName(string url)
        {
            string s = "title" + DateTime.Now.ToString("yyyyMMdd hhmmss ffff");
            MessageBox.Show(url);
            try
            {
                s = new Regex(@"<title>(.*?)</title>", RegexOptions.None).Matches(url.getHTML().Result)[0].Groups[1].Value;

            }
            catch
            {

            }
            return s.getFilerex();
        }

        private static string GetAuthorName(string url)
        {
            string s = "author" + DateTime.Now.ToString("yyyyMMdd hhmmss ffff");

            try
            {
                s = new Regex(@"""url"" href=""http://www.youtube.com/channel/.+""><link itemprop=""name"" content=""(.*?)""></span>", RegexOptions.None).Matches(url.getHTML().Result)[0].Groups[1].Value;//@"\\""author\\"":\\""(.*?)\\"",\\"""

            }
            catch
            {

            }
            return s.getFilerex();
        }

        private static List<string> ListPlaylist(string url)
        {
            List<string> lst = new List<string>();

            try
            {
                url.GetLinkByURL(@"{""webCommandMetadata"":{""url"":""(/watch\?v=.*?\\u0026list=PLis.*?)"",""webPageType""")//@"""url"":""(/watch\?v=.*?\\u0026list=.*?)"","   @"""gridPlaylistRenderer"":{""playlistId"":""(PLisp.*?)"",""thumbnail"""
                    .Result
                    .ForEach(_l =>
                    {
                        if (!SongAll.Contains(_l))
                        {
                            //  MessageBox.Show(_l);
                            lst.Add("https://www.youtube.com" + _l.Replace("\u0026", "&"));
                            SongAll += "___" + _l;
                        }

                    });
            }
            catch { }
            return lst;
        }

        /* private static bool CheckFile(string name)
         {
             if (!PlaylistAll.Contains(name)
                             && !name.Contains("แสดงสด")
                             && !name.Contains("รวมเพลง")
                             && !name.Contains("คอนเสิร์ต")
                             && !name.ToLower().Contains("ep")
                             && !name.ToLower().Contains("serie")
                             && !name.ToLower().Contains("live")
                             && !name.Contains("ซีรีส์")
                             && !name.Contains("คาราโอเกะ")
                             && !name.ToLower().Contains("karaoke")
                             && !name.Contains("รวมฮิต")
                             || name.Contains("mv")
                             || name.Contains("official")
                             || name.Contains("lyric")
                             || name.Contains("cover")
                             || name.Contains("audio")
                             )
             {
                 PlaylistAll += name + "\n";
                 return true;
             }
             else
             {
                 return false;
             }


         }*/

        private static string surl = "";
        public static List<YoutubeLink> GetYoutubeLinks(string query)
        {
            List<YoutubeLink> links = new List<YoutubeLink>();
            surl = "";

            //ถ้าค้นผ่านชื่อเว็บ หรือ url
            if (query.StartsWith("http"))
            {
                string _url = query;
                //links.Add(new YoutubeLink(query, GetTitletName(query), GetAuthorName(query)));
                if (_url.Contains("list=")) //ถ้าเว็บนั้นเป็นแบบ playlist
                {
                    //MessageBox.Show(_url);
                    links.AddRange(GetLinksFromUrlPlaylist(_url));

                }
                else////ถ้าเว็บนั้นไม่เป็นแบบ playlist
                {

                    AddLinksFromURL(query, links);

                }

            }
            else //ค้นแบบคำค้น
            {
                links.AddRange(GetLinkFromQueryAsync(query));
                //  links.AddRange(GetLinksFromQuery(query));
            }
            //  MessageBox.Show(query +"\n" +links.Count);
            return links;
        }

        private static List<YoutubeLink> GetLinksFromUrlPlaylist(string _url)
        {
            string url = _url.Replace(@"\u0026", "&");
            List<YoutubeLink> links = new List<YoutubeLink>();

            bool complete = false;
            // MessageBox.Show(_url);

            do
            {
                string html = url.getHTML().Result;

                string initialDataLine = html.Split('\n').FirstOrDefault((line) => line.Contains("window[\"ytInitialData\"] = ") || line.Contains("var ytInitialData = "));
                if (initialDataLine == null)
                {
                    return links;
                }
                string jsonData = initialDataLine
                    .Split(new[] { "window[\"ytInitialData\"] = " }, StringSplitOptions.None)
                    .Last()
                    .Split(new[] { "var ytInitialData = " }, StringSplitOptions.None)
                    .Last()
                    .Trim(' ')
                    .Trim(';');
                string vidioOwner = GetAuthorName(html);
                List<string> lstplaylistPanelVideoRenderer = html.Split(new[] { "playlistPanelVideoRenderer" }, StringSplitOptions.None).ToList();
                //  MessageBox.Show("" + lstplaylistPanelVideoRenderer.Count);
                // MessageBox.Show(vidioOwner);
                if (lstplaylistPanelVideoRenderer != null)
                {
                    lstplaylistPanelVideoRenderer.ForEach(l =>

                    {
                        string videoId = l.GetValueBystring(@"{""webCommandMetadata"":{""url"":""(/watch\?v=.*?index=\d+)"",""webPageType""").Result;
                        string videoTitle = l.GetValueBystring(@"""title"":{""accessibility"":{""accessibilityData"":{""label"":"".+""}},""simpleText"":""(.+)""},""longBylineText""").Result.getFilerex();
                        string videolengthText = l.GetValueBystring(@"""lengthText"":{""accessibility"":{""accessibilityData"":{""label"":"".*""}},""simpleText"":""(.*?)""}").Result;
                        // TimeSpan mn = TORServices.PathFile.FileTor.ToTimeSpan(videolengthText);

                        // MessageBox.Show(videoId);
                        if (videoId.Contains("index"))
                        {
                            string _url_ = "https://www.youtube.com/" + videoId.Replace(@"\u0026", "&");

                            url = _url_;
                            //   MessageBox.Show(_url_);

                            if (!SongAll.Contains(videoTitle))
                            {
                                //   if (mn.TotalMinutes < 5.00d && mn.TotalMinutes > 1.50)
                                //       { 
                                links.Add(new YoutubeLink(url, videoTitle, vidioOwner, videolengthText));
                                SongAll += "\n" + videoTitle;
                                //    }

                            }
                        }

                    });

                }

                int indexEnd = 0;
                try { indexEnd = int.Parse("0" + new Regex(@"index=(\d+)").Match(url).Groups[1].Value); } catch { indexEnd = 0; }
                if (surl == url.Trim() || indexEnd < 200)
                {
                    complete = true;
                    //  MessageBox.Show("complete+++");
                    return links;
                }
                else
                {
                    //  MessageBox.Show(url + " " + url.Length + "\n\n\n" + surl + " " + surl.Length);
                    surl = url.Trim();
                }





            }
            while (complete == false);


            //  MessageBox.Show(url + "\n" + links.Count);
            return links;
        }



        private static string All = "";
        private static List<YoutubeLink> GetLinkFromQueryAsync(string cri)
        {
            List<YoutubeLink> links = new List<YoutubeLink>();
            // MessageBox.Show(cri);
            // await Task.Factory.StartNew()
            string initialDataLine = "";
            for (int page = 1; page <= 20; page++)
            {
                string requestUrl = string.Format(URL, HttpUtility.UrlEncode(cri)?.Replace("%20", "+"), page);
                // string html = requestUrl.getHTML().Result;
                string html = requestUrl.getHTML().Result;
                //MessageBox.Show(html.IndexOf("ytInitialData").ToString());
                initialDataLine += "\n" + html.Split('\n').FirstOrDefault((line) => line.Contains("window[\"ytInitialData\"] = ") || line.Contains("var ytInitialData = "));
                // initialDataLine = html;//.Split('\n').FirstOrDefault((line) => line.Contains("window[\"ytInitialData\"] = ") || line.Contains("var ytInitialData = "));
                // initialDataLine = html.Split('\n').FirstOrDefault((line) =>  line.Contains("ytInitialData"));
            }
            if (initialDataLine != null)
            {
                string jsonData = initialDataLine;
                List<string> lstplaylistPanelVideoRenderer = jsonData.Split(new[] { "videoRenderer" }, StringSplitOptions.None).ToList();
                //  MessageBox.Show(lstplaylistPanelVideoRenderer.Count + "");
                if (lstplaylistPanelVideoRenderer != null)
                {
                    lstplaylistPanelVideoRenderer.ForEach(l =>
                    {
                        string videoId = l.GetValueBystring(@"{""webCommandMetadata"":{""url"":""(/watch\?v=.*?)"",""webPageType""").Result;
                        string videoTitle = l.GetValueBystring(@"""title"":{""runs"":\[{""text"":""(.*?)""}\],""accessibility"":").Result.getFilerex();
                        string videolengthText = l.GetValueBystring(@"""lengthText"":{""accessibility"":{""accessibilityData"":{""label"":"".*""}},""simpleText"":""(.*?)""}").Result;
                        string vidioOwnerText = l.GetValueBystring(@"""longBylineText"":{""runs"":\[{""text"":""(.*?)"",""navigationEndpoint"":").Result.getFilerex();

                        if (!All.Contains(videoTitle))
                        {
                            All += "_" + videoTitle;
                            string _url_ = "https://www.youtube.com" + videoId.Replace(@"\u0026", "&");
                            //  TimeSpan mn = TORServices.PathFile.FileTor.ToTimeSpan(videolengthText);

                            if (_url_ != "https://www.youtube.com")//|| !SongAll.Contains(videoTitle)
                            {
                                // MessageBox.Show(_url_);
                                /* if (mn.TotalMinutes < 5.00d && mn.TotalMinutes > 1.50)
                                 {*/
                                links.Add(new YoutubeLink(_url_, videoTitle, vidioOwnerText, videolengthText));
                                SongAll += "\n" + videoTitle;
                            }

                            // }

                        }


                    });

                }
            }


            //  MessageBox.Show(links.Count.ToString());
            return links;
        }
        private static void AddLinksFromURL(string url, List<YoutubeLink> lst)
        {
            // MessageBox.Show(url);

            string html = url.getHTML().Result;

            string videoTitle = new Regex(@"<title>(.*?)- YouTube</title>", RegexOptions.Compiled).Match(html).Groups[1].Value.getFilerex();

            string vidioOwnerText = new Regex(@"SureOfficial"", ""name"": ""(.*?)""}}", RegexOptions.Compiled).Match(html).Groups[1].Value.getFilerex();

            // MessageBox.Show(videoTitle + "\n" + vidioOwnerText);

            if (!SongAll.Contains(videoTitle))
            {
                lst.Add(new YoutubeLink(url, videoTitle, vidioOwnerText, ""));
                SongAll += "\n" + videoTitle;

            }



        }
        /*    private static  string GetWebPageCode(string url)
              {
                  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                  HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                  if (response.StatusCode == HttpStatusCode.OK)
                  {
                      Stream receiveStream = response.GetResponseStream();
                      if (receiveStream != null)
                      {
                          StreamReader readStream;
                          if (response.CharacterSet == null)
                          {
                              readStream = new StreamReader(receiveStream);
                          }
                          else
                          {
                              readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                          }
                          string data = readStream.ReadToEnd();
                          response.Close();
                          readStream.Close();
                          return data;
                      }

                      return null;
                  }
                  return null;
              }*/
    }

    public class YoutubeLink
    {


        public YoutubeLink(string u, string fn, string _ow, string _du)
        {
            Link = u.Replace("\\u0026", "&");
            // MessageBox.Show("YoutubeLink \n" + fn.Replace("u0026", "").Replace("\\", ""));
            FileName = fn.Replace("u0026", "").Replace("\\", "").MakeValidFileName();


            OwnerName = (_ow == null ? "" : _ow.Replace("u0026", "").Replace("\\", "")).MakeValidFileName();

            Duration = _du;

        }
        public string Duration { get; set; }
        public string FileName { get; set; }
        public string Link { get; set; }
        public string OwnerName { get; set; }
    }
}
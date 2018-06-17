using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace NijiWatcher.Browser
{
    public abstract class LiveSite
    {
        /// <summary>
        /// 元サイトのURL
        /// </summary>
        public string Url { get; protected set; }
        /// <summary>
        /// ライブ中のURL
        /// </summary>
        public string LiveUrl { get; set; }
        /// <summary>
        /// ユーザー用のサイトURL
        /// </summary>
        public string UserUrl { get; set; }

        public LiveSite()
        {
            LiveUrl = "";
            UserUrl = "";
        }

        public abstract Task<bool> ShowLive();
    }

    public class Youtube : LiveSite
    {
        /// <summary>
        /// ライブ配信を検索するためのブラウザー
        /// </summary>
        private static HttpClient hcLiveSite { get; set; } = new HttpClient();

        public Youtube()
        {
            Url = "https://www.youtube.com/";
        }

        public override async Task<bool> ShowLive()
        {
            if (UserUrl == "")
            {
                return false;
            }
            HttpResponseMessage response = null;
            string strHtml = "";
            string strHtmlFirstMovie = "";
            string strLiveUrl = "";
            response = await hcLiveSite.GetAsync(UserUrl);
            strHtml = await response.Content.ReadAsStringAsync();
            if (strHtml.Contains("ライブ配信中"))
            {
                using (StringReader stLine = new StringReader(strHtml))
                {
                    while (stLine.Peek() > -1)
                    {
                        string strLine = stLine.ReadLine();
                        if (strLine.Contains("<span class=\" spf-link  ux-thumb-wrap contains-addto\">"))
                        {
                            strHtmlFirstMovie = strLine;
                            break;
                        }
                    }
                }
                foreach (string strTemp in strHtmlFirstMovie.Split(' '))
                {
                    if (strTemp.Contains("href=\"/watch?"))
                    {
                        strLiveUrl = strTemp.Replace("\"", "").Replace("href=", "");
                        break;
                    }
                }
                if (LiveUrl != strLiveUrl)
                {
                    LiveUrl = strLiveUrl;
                    Process.Start("Chrome.exe", Url + "/" + LiveUrl);
                }
            }
            response.Dispose();
            return true;
        }
    }
}
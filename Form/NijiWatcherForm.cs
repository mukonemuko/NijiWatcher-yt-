using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NijiWatcher.NijisanjiLiver;

namespace NijiWatcher
{
    /// <summary>
    /// もっとうまくクラス作りたいけど頭回らな～い
    /// コメント書くのめんどくさーい
    /// </summary>
    public partial class NijiWatcher : Form
    {
        public const string version = "1.0.0.0";

        /// <summary>
        /// 全メンバーのコレクション
        /// </summary>
        private NijiMembers members;

        /// <summary>
        /// カレントディレクトリ
        /// </summary>
        public static string StrCurrentDir { get { return Directory.GetCurrentDirectory(); }  }
        /// <summary>
        /// メンバーフォルダのディレクトリ
        /// </summary>
        public static string StrMemberFileDir { get {return string.Format("{0}\\members", StrCurrentDir); } }

        #region メニューアイテム

        #endregion

        private bool isTask = false;

        public NijiWatcher()
        {
            InitializeComponent();
            members = new NijiMembers();
            NotifiIcon();
        }

        private void NotifiIcon()
        {
            ContextMenuStrip cmsNijiWatch = new ContextMenuStrip();

            ToolStripMenuItem tsmiNijiWatchVersion = new ToolStripMenuItem();
            tsmiNijiWatchVersion.Text = string.Format("にじうぉっちゃー v{0}",version);
            tsmiNijiWatchVersion.Enabled = false;
            ToolStripMenuItem tsmiNijiWatchClose = new ToolStripMenuItem();
            tsmiNijiWatchClose.Text = "&終了";
            tsmiNijiWatchClose.Click += new EventHandler(CloseClick);
            cmsNijiWatch.Items.Add(members.first.GetMenuItem());
            cmsNijiWatch.Items.Add(members.second.GetMenuItem());
            cmsNijiWatch.Items.Add(members.seeds.GetMenuItem());
            cmsNijiWatch.Items.Add(members.gamers.GetMenuItem());
            cmsNijiWatch.Items.Add(members.voiz.GetMenuItem());
            cmsNijiWatch.Items.Add(members.other.GetMenuItem());
            cmsNijiWatch.Items.Add("-");
            cmsNijiWatch.Items.Add(tsmiNijiWatchVersion);
            cmsNijiWatch.Items.Add("-");
            cmsNijiWatch.Items.Add(tsmiNijiWatchClose);
            niNijiWatcher.ContextMenuStrip = cmsNijiWatch;
        }

        private void CloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private async Task NijiWatcherStart()
        {

            if (isTask == false)
            {
                isTask = true;
                if (members.first.GetFileData())
                {
                    foreach (Liver liver in members.first.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                if (members.second.GetFileData())
                {
                    foreach (Liver liver in members.second.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                if (members.seeds.GetFileData())
                {
                    foreach (Liver liver in members.seeds.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                if (members.gamers.GetFileData())
                {
                    foreach (Liver liver in members.gamers.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                if (members.voiz.GetFileData())
                {
                    foreach (Liver liver in members.voiz.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                if (members.other.GetFileData())
                {
                    foreach (Liver liver in members.other.colLiver)
                    {
                        if (liver.GetFileData())
                        {
                            try
                            {
                                await liver.MyYoutube.ShowLive();
                                Thread.Sleep(1000);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                GC.Collect();
                isTask = false;
            }

        }

        private async void nijiTimer_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => NijiWatcherStart());
        }

        private async void NijiWatcher_Load(object sender, EventArgs e)
        {
            await Task.Run(() => NijiWatcherStart());
        }
    }
}

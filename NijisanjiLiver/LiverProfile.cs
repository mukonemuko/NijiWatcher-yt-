using System;
using System.IO;
using System.Windows.Forms;
using NijiWatcher.Browser;

namespace NijiWatcher.NijisanjiLiver
{
    public abstract class Liver
    {
        /// <summary>
        /// 配信者の名前
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 本人のファイルの名前
        /// </summary>
        public string FileName { get { return string.Format("{0}\\{1}.chr", NijiWatcher.StrMemberFileDir, Name); } }
        /// <summary>
        /// 配信しているかの判定フラグ
        /// </summary>
        public bool IsLive { get; set; }
        /// <summary>
        /// ツイッターURL
        /// </summary>
        public string TwitterUrl { get; protected set; }
        /// <summary>
        /// Youtubeのユーザー画面
        /// </summary>
        public Youtube MyYoutube { get; protected set; }

        public ToolStripMenuItem LiverMenuItem { protected get; set; }

        protected Liver()
        {
            IsLive = false;
            MyYoutube = new Youtube();
        }

        /// <summary>
        /// 読み込むかをファイルから取得
        /// </summary>
        /// <returns>true:読み込む false:読み込まない</returns>
        public bool GetFileData()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        string temp = sr.ReadToEnd();
                        if (temp == "false")
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// ファイルの情報を書き換える
        /// </summary>
        public void SetFileData()
        {
            try
            {
                if (!Directory.Exists(NijiWatcher.StrMemberFileDir))
                {
                    Directory.CreateDirectory(NijiWatcher.StrMemberFileDir);
                }
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                if (GetFileData() == true)
                {
                    File.WriteAllText(FileName, "false");
                }
                else
                {
                    File.WriteAllText(FileName, "true");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// ファイルの情報を取得する。
        /// </summary>
        /// <returns></returns>
        public ToolStripMenuItem GetMenuItem()
        {
            if (LiverMenuItem == null)
            {
                LiverMenuItem = new ToolStripMenuItem();
                LiverMenuItem.Text = Name;
                LiverMenuItem.Click += new EventHandler((object sender, EventArgs e) => {
                    SetFileData();
                    LiverMenuItem.Checked = GetFileData();
                });
                LiverMenuItem.Checked = GetFileData();

            }
            return LiverMenuItem;
        }


    }

    #region 一期生


    public class MitoTsukino : Liver
    {
        private static Liver _instance = new MitoTsukino();


        private MitoTsukino()
        {
            Name = "月ノ美兎";
            TwitterUrl = "https://twitter.com/MitoTsukino";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCD-miitqNY3nyukJ4Fnf4_A";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KaedeHiguchi : Liver
    {
        private static Liver _instance = new KaedeHiguchi();

        private KaedeHiguchi()
        {
            Name = "樋口楓";
            TwitterUrl = "https://twitter.com/HiguchiKaede";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCsg-YqdqQ-KFF0LNk23BY4A";

        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class RinShizuka : Liver
    {
        private static Liver _instance = new RinShizuka();

        private RinShizuka()
        {
            Name = "静凛";
            TwitterUrl = "https://twitter.com/ShizuRin23";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC6oDys1BGgBsIC3WhG1BovQ";

        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class Elu : Liver
    {
        private static Liver _instance = new Elu();

        private Elu()
        {
            Name = "える";
            TwitterUrl = "https://twitter.com/Elu_World";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCYKP16oMX9KKPbrNgo_Kgag";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class Moira : Liver
    {
        private static Liver _instance = new Moira();

        private Moira()
        {
            Name = "モイラ";
            TwitterUrl = "https://twitter.com/Moiramoimoimoi";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCvmppcdYf4HOv-tFQhHHJMA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class AkiSuzuya : Liver
    {
        private static Liver _instance = new AkiSuzuya();

        private AkiSuzuya()
        {
            Name = "鈴谷アキ";
            TwitterUrl = "https://twitter.com/aki_suzuya";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCt9qik4Z-_J-rj3bKKQCeHg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class HajimeShibuya : Liver
    {
        private static Liver _instance = new HajimeShibuya();

        private HajimeShibuya()
        {
            Name = "渋谷ハジメ";
            TwitterUrl = "https://twitter.com/sibuya_hajime";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCeK9HFcRZoTrvqcUCtccMoQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class ChihiroYuki : Liver
    {
        private static Liver _instance = new ChihiroYuki();

        private ChihiroYuki()
        {
            Name = "勇気ちひろ";
            TwitterUrl = "https://twitter.com/Chihiro_yuki23";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCLO9QDxVL4bnvRRsz6K4bsQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    #endregion

    #region 二期生
    public class ToyaKenmochi : Liver
    {
        private static Liver _instance = new ToyaKenmochi();

        private ToyaKenmochi()
        {
            Name = "​剣持刀也";
            TwitterUrl = "https://twitter.com/rei_Toya_rei";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCv1fFr156jc65EMiLbaLImw";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class RiriYuhi : Liver
    {
        private static Liver _instance = new RiriYuhi();

        private RiriYuhi()
        {
            Name = "夕陽リリ";
            TwitterUrl = "https://twitter.com/Yuuhi_Riri";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC48jH1ul-6HOrcSSfoR02fQ";
        }
        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class GakuFushimi : Liver
    {
        private static Liver _instance = new GakuFushimi();

        private GakuFushimi()
        {
            Name = "伏見ガク";
            TwitterUrl = "https://twitter.com/gaku_fushimi";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCXU7YYxy_iQd3ulXyO-zC2w";
        }
        public static Liver GetLiver()
        {
            return _instance;
        }

    }

    public class MugiIenaga : Liver
    {
        private static Liver _instance = new MugiIenaga();

        private MugiIenaga()
        {
            Name = "家長むぎ";
            TwitterUrl = "https://twitter.com/ienaga_mugi23";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC_GCs6GARLxEHxy1w40d6VQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class AliceMononobe : Liver
    {
        private static Liver _instance = new AliceMononobe();

        private AliceMononobe()
        {
            Name = "物述有栖";
            TwitterUrl = "https://twitter.com/AliceMononobe";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCt0clH12Xk1-Ej5PXKGfdPA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class IchigoUshimi : Liver
    {
        private static Liver _instance = new IchigoUshimi();

        private IchigoUshimi()
        {
            Name = "宇志海いちご";
            TwitterUrl = "https://twitter.com/ushimi_ichigo";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCmUjjW5zF1MMOhYUwwwQv9Q";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }
    public class TamakiFumino : Liver
    {
        private static Liver _instance = new TamakiFumino();

        private TamakiFumino()
        {
            Name = "文野環";
            TwitterUrl = "https://twitter.com/nekokan_chu";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCBiqkFJljoxAj10SoP2w2Cg";

        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class UtakoSuzuka : Liver
    {
        private static Liver _instance = new UtakoSuzuka();

        private UtakoSuzuka()
        {
            Name = "鈴鹿詩子";
            TwitterUrl = "https://twitter.com/suzukautako";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCwokZsOK_uEre70XayaFnzA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KazakiMorinaka : Liver
    {
        private static Liver _instance = new KazakiMorinaka();

        private KazakiMorinaka()
        {
            Name = "​森中花咲";
            TwitterUrl = "https://twitter.com/kazakimorinaka";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCtpB6Bvhs1Um93ziEDACQ8g";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class GilzarenThird : Liver
    {
        private static Liver _instance = new GilzarenThird();

        private GilzarenThird()
        {
            Name = "​​ギルザレンⅢ世";
            TwitterUrl = "https://twitter.com/Gilzaren_III";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCUzJ90o1EjqUbk2pBAy0_aw";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    #endregion

    #region ゲーマーズ

    public class Kanae : Liver
    {
        private static Liver _instance = new Kanae();

        private Kanae()
        {
            Name = "叶";
            TwitterUrl = "https://twitter.com/Kanae_2434";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCspv01oxUFf_MTSipURRhkA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class YokoAkabane : Liver
    {
        private static Liver _instance = new YokoAkabane();

        private YokoAkabane()
        {
            Name = "赤羽葉子";
            TwitterUrl = "https://twitter.com/Youko_Akabane";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCBi8YaVyZpiKWN3_Z0dCTfQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    #endregion

    #region SEEDs

    public class Dola : Liver
    {
        private static Liver _instance = new Dola();

        private Dola()
        {
            Name = "ドーラ";
            TwitterUrl = "https://twitter.com/___Dola";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC53UDnhAAYwvNO7j_2Ju1cQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class Umiyasyanokami : Liver
    {
        private static Liver _instance = new Umiyasyanokami();

        private Umiyasyanokami()
        {
            Name = "海夜叉神";
            TwitterUrl = "https://twitter.com/god_yaksa23";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCqEp6RdtsMbUNrCdCswr6pA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class AzumaNakao : Liver
    {
        private static Liver _instance = new AzumaNakao();

        private AzumaNakao()
        {
            Name = "名伽尾アズマ";
            TwitterUrl = "https://twitter.com/azuma_dazo";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCks41vQN-hN-1KHmpZyPY3A";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KasumiIzumo : Liver
    {
        private static Liver _instance = new KasumiIzumo();

        private KasumiIzumo()
        {
            Name = "出雲霞";
            TwitterUrl = "https://twitter.com/ikasumi_zzz";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCLpYMk5h1bq8_GAFVBgXhPQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KyokoTodoroki : Liver
    {
        private static Liver _instance = new KyokoTodoroki();

        private KyokoTodoroki()
        {
            Name = "轟京子";
            TwitterUrl = "https://twitter.com/KT_seeds";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCRV9d6YCYIMUszK-83TwxVA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class SisterCleaire : Liver
    {
        private static Liver _instance = new SisterCleaire();

        private SisterCleaire()
        {
            Name = "シスター・クレア";
            TwitterUrl = "https://twitter.com/SisterCleaire";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC1zFJrfEKvCixhsjNSb1toQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KizukuYashiro : Liver
    {
        private static Liver _instance = new KizukuYashiro();

        private KizukuYashiro()
        {
            Name = "社築";
            TwitterUrl = "https://twitter.com/846kizuQ";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCKMYISTJAQ8xTplUPHiABlA";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class MomoAduchi : Liver
    {
        private static Liver _instance = new MomoAduchi();

        private MomoAduchi()
        {
            Name = "安土桃";
            TwitterUrl = "https://twitter.com/momo_aduchi";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC6TfqY40Xt1Y0J-N18c85qQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class MasaruSuzuki : Liver
    {
        private static Liver _instance = new MasaruSuzuki();

        private MasaruSuzuki()
        {
            Name = "鈴木勝";
            TwitterUrl = "https://twitter.com/Darkness_Eater";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCaF-mODqAziHivqg0Q61XKQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class Ryushen : Liver
    {
        private static Liver _instance = new Ryushen();

        private Ryushen()
        {
            Name = "緑仙";
            TwitterUrl = "https://twitter.com/midori_2434";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCt5-0i4AVHXaWJrL8Wql3mw";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KouUduki : Liver
    {
        private static Liver _instance = new KouUduki();

        private KouUduki()
        {
            Name = "卯月コウ";
            TwitterUrl = "https://twitter.com/udukikohh";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC3lNFeJiTq6L3UWoz4g1e-A";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class YuzuHassaku : Liver
    {
        private static Liver _instance = new YuzuHassaku();

        private YuzuHassaku()
        {
            Name = "八朔ゆず";
            TwitterUrl = "https://twitter.com/839yuzu";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCFaDvgez8USXHiKidt0NtZg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class ChaikaHanabatake : Liver
    {
        private static Liver _instance = new ChaikaHanabatake();

        private ChaikaHanabatake()
        {
            Name = "花畑チャイカ";
            TwitterUrl = "https://twitter.com/ZulmIhP1nlMOT5y";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCsFn_ueskBkMCEyzCEqAOvg";        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    #endregion

    #region voiz
    public class AirHarusaki : Liver
    {
        private static Liver _instance = new AirHarusaki();

        private AirHarusaki()
        {
            Name = "春崎エアル";
            TwitterUrl = "https://twitter.com/harusakiair2434";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCtAvQ5U0aXyKwm2i4GqFgJg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class PoaroKaminari : Liver
    {
        private static Liver _instance = new PoaroKaminari();

        private PoaroKaminari()
        {
            Name = "神成ポアロ";
            TwitterUrl = "https://twitter.com/poaro_kaminari";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UC6CuqUPujM3-i2HHgr43JiQ";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class KurotoKurohane : Liver
    {
        private static Liver _instance = new KurotoKurohane();

        private KurotoKurohane()
        {
            Name = "黒羽黒兎";
            TwitterUrl = "https://twitter.com/kuroto_2434";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCzmpwcn4TGmtMIkJ2BY7jew";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class NaruNaruse : Liver
    {
        private static Liver _instance = new NaruNaruse();

        private NaruNaruse()
        {
            Name = "成瀬 鳴";
            TwitterUrl = "https://twitter.com/narusenaru_voiz";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCoM_XmK45j504hfUWvN06Qg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }


    #endregion

    #region その他

    public class RoomIwanaga : Liver
    {
        private static Liver _instance = new RoomIwanaga();

        private RoomIwanaga()
        {
            Name = "いわなが";
            TwitterUrl = "https://twitter.com/iwataiki";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCGCb4Dts1uYtciya3wvd6dg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    public class NijisanjiOfficial : Liver
    {
        private static Liver _instance = new NijisanjiOfficial();

        private NijisanjiOfficial()
        {
            Name = "にじさんじ";
            TwitterUrl = "https://twitter.com/nijisanji_app";
            MyYoutube.UserUrl = "https://www.youtube.com/channel/UCX7YkU9nEeaoZbkVLVajcMg";
        }

        public static Liver GetLiver()
        {
            return _instance;
        }
    }

    #endregion

}


using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace NijiWatcher.NijisanjiLiver
{
    #region ライバーコレクション

    public abstract class LiverCollection :Liver
    {
        public Collection<Liver> colLiver;

        public new ToolStripMenuItem GetMenuItem()
        {
            if(LiverMenuItem == null)
            {
                LiverMenuItem = new ToolStripMenuItem();
                LiverMenuItem.Text = Name;
                LiverMenuItem.Click += new EventHandler((object sender, EventArgs e) => {
                    SetFileData();
                    LiverMenuItem.Checked = GetFileData();
                });
                LiverMenuItem.Checked = GetFileData();
                foreach(Liver liver in colLiver)
                {
                    LiverMenuItem.DropDownItems.Add(liver.GetMenuItem());
                }
            }
            return LiverMenuItem;
        }
    }

    /// <summary>
    /// にじさんじ一期生
    /// </summary>
    public class NijiFirst : LiverCollection
    {

        public NijiFirst()
        {
            Name = "1期生";

            colLiver = new Collection<Liver>();

            colLiver.Add(MitoTsukino.GetLiver());
            colLiver.Add(KaedeHiguchi.GetLiver());
            colLiver.Add(RinShizuka.GetLiver());
            colLiver.Add(Elu.GetLiver());
            colLiver.Add(Moira.GetLiver());
            colLiver.Add(ChihiroYuki.GetLiver());
            colLiver.Add(AkiSuzuya.GetLiver());
            colLiver.Add(HajimeShibuya.GetLiver());

            foreach (Liver liver in colLiver)
            {

            }
        }
    }

    /// <summary>
    /// にじさんじ二期生
    /// </summary>
    public class NijiSecond : LiverCollection
    {

        public NijiSecond()
        {
            Name = "2期生";

            colLiver = new Collection<Liver>();

            colLiver.Add(ToyaKenmochi.GetLiver());
            colLiver.Add(GakuFushimi.GetLiver());
            colLiver.Add(RiriYuhi.GetLiver());
            colLiver.Add(MugiIenaga.GetLiver());
            colLiver.Add(AliceMononobe.GetLiver());
            colLiver.Add(IchigoUshimi.GetLiver());
            colLiver.Add(UtakoSuzuka.GetLiver());
            colLiver.Add(TamakiFumino.GetLiver());
            colLiver.Add(KazakiMorinaka.GetLiver());
            colLiver.Add(GilzarenThird.GetLiver());
        }
    }

    /// <summary>
    /// にじさんじゲーマーズ
    /// </summary>
    public class NijiGamers : LiverCollection
    {

        public NijiGamers()
        {
            Name = "ゲーマーズ";

            colLiver = new Collection<Liver>();

            colLiver.Add(Kanae.GetLiver());
            colLiver.Add(YokoAkabane.GetLiver());
        }
    }

    public class NijiSeeds : LiverCollection
    {

        public NijiSeeds()
        {
            Name = "SEEDs";

            colLiver = new Collection<Liver>();

            colLiver.Add(Dola.GetLiver());
            colLiver.Add(Umiyasyanokami.GetLiver());
            colLiver.Add(AzumaNakao.GetLiver());
            colLiver.Add(KasumiIzumo.GetLiver());
            colLiver.Add(KyokoTodoroki.GetLiver());
            colLiver.Add(SisterCleaire.GetLiver());
            colLiver.Add(ChaikaHanabatake.GetLiver());
            colLiver.Add(KizukuYashiro.GetLiver());
            colLiver.Add(MomoAduchi.GetLiver());
            colLiver.Add(MasaruSuzuki.GetLiver());
            colLiver.Add(Ryushen.GetLiver());
            colLiver.Add(KouUduki.GetLiver());
            colLiver.Add(YuzuHassaku.GetLiver());

        }
    }

    public class NijiVoiz : LiverCollection
    {

        public NijiVoiz()
        {
            Name = "Voiz";

            colLiver = new Collection<Liver>();

            colLiver.Add(AirHarusaki.GetLiver());
            colLiver.Add(PoaroKaminari.GetLiver());
            colLiver.Add(KurotoKurohane.GetLiver());
            colLiver.Add(NaruNaruse.GetLiver());
        }
    }

    public class NijiOther : LiverCollection
    {

        public NijiOther()
        {
            Name = "その他";

            colLiver = new Collection<Liver>();

            colLiver.Add(RoomIwanaga.GetLiver());
            colLiver.Add(NijisanjiOfficial.GetLiver());

        }
    }

    /// <summary>
    /// にじさんじ勢全員
    /// </summary>
    public class NijiMembers
    {
        public  NijiFirst first;
        public  NijiSecond second;
        public  NijiGamers gamers;
        public  NijiSeeds seeds;
        public  NijiVoiz voiz;
        public  NijiOther other;
        public Collection<Liver> colLiver;

        public NijiMembers()
        {
            first = new NijiFirst();
            second = new NijiSecond();
            gamers = new NijiGamers();
            seeds = new NijiSeeds();
            voiz = new NijiVoiz();
            other = new NijiOther();

            colLiver = new Collection<Liver>();

            foreach (Liver eTemp in first.colLiver)
            {
                colLiver.Add(eTemp);
            }

            foreach (Liver eTemp in second.colLiver)
            {
                colLiver.Add(eTemp);
            }

            foreach (Liver eTemp in gamers.colLiver)
            {
                colLiver.Add(eTemp);
            }

            foreach (Liver eTemp in seeds.colLiver)
            {
                colLiver.Add(eTemp);
            }

            foreach (Liver eTemp in voiz.colLiver)
            {
                colLiver.Add(eTemp);
            }

            foreach (Liver eTemp in other.colLiver)
            {
                colLiver.Add(eTemp);
            }

        }
    }
    #endregion

}

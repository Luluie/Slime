using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace ConsoleApp1
{

    class Program
    {
        public static string Name;
        public static int Food = 100;//食料 生きているだけで消費される：初期値は１００
        public static int Magic = 1;//魔素　多くなると魔物としての格が上がり人間に狙われやすくなる:初期値は１
        public static int Hate = 0;//危険度　高くなると他の魔物との戦闘が発生しやすくなる:初期値は0
        public static int Speed = 1;//素早さ　行動順を決める
        public static int Attack = 1;//攻撃力　相手に与えるダメージを決める
        public static int Defense = 1;//防御力　自分が受けるダメージを決める
        public static int Size = 10;//体積　HPとクリア目標
        public static int Critical = 0;
        public static int Day = 1;


        public const int UseFood = 5;//体積を成長させるのに消費する食料
        public const int UseMagic = 10;//ステータスを上昇させるのに使う魔力
        static void Main(string[] args)
        {
            Console.WindowWidth = 110;
            Console.WriteLine(@"

□□■■■■■■■■■■□□□□■■■■■■■■■■□□□□□□□□□□□□□■□□□□□□■□□□□□□□□□
□□□□□□□□□□□■□□□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□■□□□□□□□□□
□□□□□□□□□□□■□□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□■■□□□□□□□□□
□□□□□□□□□□■■□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□□■□□□□□□□□□□
□□□□□□□□□□■□□□□■■■■■■■■■■■■□□□□□□□■■■□□□□□□□□■□□□□□□□□□□
□□□□□□□□□■■□□□□□□□□□□□□□□□■□□□□□■■■□□□□□□□□□■■□□□□□□□□□□
□□□□□□□□■■□□□□□□□□□□□□□□□■■□□□■■■□■□□□□□□□□□■□□□□□■□□□□□
□□□□□□□■■■□□□□□□□□□□□□□□□■□■■■■□□□■□□□□□□□□□■□□□□□■□□□□□
□□□□□□■■□■■□□□□□□□□□□□□□■■□□□□□□□□■□□□□□□□□■■□□□□□■■□□□□
□□□□□■■□□□■■□□□□□□□□□□□■■□□□□□□□□□■□□□□□□□□■□□□□□□□■□□□□
□□□□■■□□□□□■■□□□□□□□□□■■□□□□□□□□□□■□□□□□□□□■□□□■■■■■■□□□
□□□■■□□□□□□□■■□□□□□□■■■□□□□□□□□□□□■□□□□□□□■■■■■■□□□□■□□□
□■■■□□□□□□□□□■■□□■■■■□□□□□□□□□□□□□■□□□□□■■■□□□□□□□□□■■□□
□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□■□□□□□□□□□□□□□□□□□□□□□
□□□■■■■■■■■■■□□□□□□□□□□□□□□□□□■□□□□□■■■■■■■■■■■■□□□□□□□□
□□□□□□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□□□□□□□□□□□■□□□□□□□□
□□□□□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□□□□□□□□□□□■■□□□□□□□□
□□□□□□□□□□□□□□□□□□□□□□□□□□□■■□□□□□□□□□□□□□□□□□■□□□□□□□□□
□□■■■■■■■■■■■■□□□□□□□□□□□■■■□□□□□□□□□□□□□□□□□■■□□□□□□□□□
□□□□□□□□□□□□□■□□□□□□□□□■■■□□□□□□□□□□□□□□□□□□□■□□□□□□□□□□
□□□□□□□□□□□□■■□□□□□□□■■■□■□□□□□□□□□□□□□□□□□□■■□□□□□□□□□□
□□□□□□□□□□□□■□□□□□■■■■□□□■□□□□□□□□□□□□□□□□□■■□□□□□□□□□□□
□□□□□□□□□□□■■□□□□□□□□□□□□■□□□□□□□□□□□□□□□□■■□□□□□□□□□□□□
□□□□□□□□□□■■□□□□□□□□□□□□□■□□□□□□□□□□□□□□□■■□□□□□□□□□□□□□
□□□□□□□□□■■□□□□□□□□□□□□□□■□□□□□□□□□□□□□■■■□□□□□□□□□□□□□□
□□□□□□□■■■□□□□□□□□□□□□□□□■□□□□□□□□□□□■■■□□□□□□□□□□□□□□□□
□□□□■■■■□□□□□□□□□□□□□□□□□■□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□
");
            Console.WriteLine("キーを押してください");
            Console.ReadKey();

            Console.WriteLine();
            // BattleSystem();


            Console.WriteLine(@"
    スライムの人生シミュレーションです。
    スライムの目的は、”水”になって世界の糧になり天国に行く事、
    もしくは誰にも負けない程の強さを手に入れ怯えることなく生きる事です。
    弱い魔物のままでは人間に駆除されたりより強い魔物に食べられてしまいます。
    その場合は天国には行けずまた弱いスライムとして生き返ってしまいます。
    理解したらキーを押してください。");
            Console.ReadKey();


            NameCheck();
            Console.WriteLine(@"
    ありがとうございます。
    このゲームは毎ターン、スライムの能力値を上昇させていき、
    体積を100まで上げて成長する事で水になる事が出来ます
    説明をするので読みながら遊んでみください");

            Console.WriteLine();

            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("【現在のステータス】");
            Console.WriteLine("食料:" + Food + "体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic + "脅威度:" + Hate);
            Console.WriteLine(" ");
            BasicComand();

            Console.WriteLine(@"
    さて、これがこのゲームの基本的なコマンドになります。
    まず用語の説明から、
    脅威度とは他の魔物からの狙われやすさを表します。高いほどターン毎に魔物との戦闘が発生しやすくなります。
    食料消費とは文字通り食料の消費量です。生きているだけで消費しますが、戦闘をしたり人間から逃げると多く消費します。
    魔素とは魔物としてのランクを表します。高いほど格の高い魔物として人間が退治しにやってきます。
    ですが、所詮スライムのあなたは人間には勝てません。逃げるのに体力を使い食料を大量に消費することでしょう。


    ではコマンドを選んでみてください。");
            ComandCheck();


            Console.WriteLine(@"
    はい、このように外に干渉するステータスを増減させるのがこの基本行動です。
    次は成長フェイズで自分の中身のステータスを変動させましょう。");
            Console.ReadKey();

            GrowthComand();

            Console.WriteLine(@"
    これが自分の内側のステータスです。
    体積とはスライムのサイズを表します。これを100まで成長させる事でスライムは自重を支えられなくなり水たまりになり、一生を終えます。
    このゲームの目標の数値ですが、同時にHPの役割も果たします。
    素早さとは戦闘で行動順番を決める時に使用する数値になります。
    攻撃力とは相手に与えるダメージに影響します。
    防御力は相手から与えられるダメージに影響します。
    ではコマンドを選んでみてください。");

            GrouthCheck();

            Console.WriteLine(@"
    毎ターンこれらの行動を選択した後に、脅威度や魔素によってイベントが発生することがあります");
            Console.ReadKey();

            EventCheck();

            Console.WriteLine(@"
    以上が1日の流れになります。
    神のお告げによると30日経ってしまうと魔王により人間との戦争に駆り出されてしまうので、
    30日以内に「水」になるか、
    誰にも負けないスライムになれるように助けてあげてください");
            Console.WriteLine();
            Console.WriteLine("食料:" + Food + "体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic + "脅威度:" + Hate);
            Day++;
            GamePlay();



        }


        static void GamePlay()
        {
            while (Size < 100 || Day == 31)
            {
                Console.WriteLine();
                Console.WriteLine(Day + "日目");
                Console.WriteLine("【げんざいのすてーたす】");
                Console.WriteLine("食料:" + Food + "体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic + "脅威度:" + Hate);

                BasicComand();
                ComandCheck();
                GrowthComand();
                GrouthCheck();
                EventCheck();
                Console.WriteLine();
                Console.WriteLine(@"
    今日の" + Name);
                Day++;
            }
            if (Size >= 100)
            {
                Console.WriteLine();
                Console.WriteLine("自分で支えきれないほど体積が大きくなった" + Name + "はまるで溶けるように地面に広がっていった。");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine("これで怯えながら暮らす日々から解放される…");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine(Name + "は意識を失いその体は地面に染み込んでいった。世界の糧になることで天国で幸せに暮らせるだろう。");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine("天国END");
                Environment.Exit(0);
            }
            if (Speed >= 100 && Attack >= 100 && Defense >= 100 && Size >= 90 && Day == 31)
            {
                Console.WriteLine("それはもはやスライムという枠に収まるモノではない");
                Console.ReadKey();
                Console.WriteLine("人間は成す術もなく一夜にして滅んだ。");
                Console.ReadKey();
                Console.WriteLine("この天災は人間だけでは満足せず魔王軍をも滅亡させた。");
                Console.ReadKey();
                Console.WriteLine("全てが滅んだ後に新しくスライムだけの国があったという。");
                Console.ReadKey();

                Console.WriteLine("新世界の神END");
                Environment.Exit(0);

            }
            if (Speed >= 100 && Attack >= 100 && Day == 31)
            {
                Console.WriteLine("素早さと攻撃力を極めた" + Name + "はもはや誰にも負けることはない。");
                Console.ReadKey();
                Console.WriteLine("目にもとまらぬ速度で人間を倒していく。");
                Console.ReadKey();
                Console.WriteLine("魔王軍と人間の戦争では一騎当千のスライムがいたという。");
                Console.ReadKey();
                Console.WriteLine("一騎当千END");
                Environment.Exit(0);
            }
            if (Defense >= 100 && Size >= 90 && Day == 31)
            {
                Console.WriteLine("防御力とサイズを限界まで極めた" + Name + "はもはや誰にも倒される事は無い。");
                Console.ReadKey();
                Console.WriteLine("人間の攻撃を全て無効化し、魔王城には一人も通さない");
                Console.ReadKey();
                Console.WriteLine("魔王城の前には絶対に越えられない壁があったという。");
                Console.ReadKey();
                Console.WriteLine("最強の盾END");
                Environment.Exit(0);
            }
            if (Food <= 0)
            {
                Console.WriteLine("食料が尽きた…今回の生では何かを成すことは残念ながら無かった");
                Console.WriteLine("次は何かをやり遂げたい…");
                Console.WriteLine("そう思いながら" + Name + "の意識は薄れていった");
                Environment.Exit(0);
            }


        }

        //イベントが発生するかどうか--------------------------------
        static void EventCheck()
        {
            Random Event = new System.Random();
            int Flag = Event.Next(0, 101);//0から100で発生確率を作る
            if (Magic > Flag)//魔素が確率を超えてたら
            {

                HumanSystem();
            }
            else if (Hate > Flag)//脅威度が確率を超えてたら
            {
                BattleSystem();
            }
        }

        //戦闘----------------------------------
        static void BattleSystem()
        {
            Console.WriteLine(@"
    他のスライムが襲い掛かってきた！");

            Random rnd = new System.Random();

            //敵のステータスを決める。0以下の場合は1にする
            int EnemySize = rnd.Next(Size - 10, Size + 10);
            int InitSize = EnemySize;
            int EnemyAttack = rnd.Next(Attack - 10, Attack + 10);
            int EnemyDefense = rnd.Next(Defense - 10, Defense + 10);
            int EnemySpeed = rnd.Next(Speed - 10, Speed + 10);
            if (EnemyAttack <= 0)
            {
                EnemyAttack = 1;
            }
            if (EnemySize <= 0)
            {
                EnemySize = 1;
            }
            if (EnemyDefense <= 0)
            {
                EnemyDefense = 1;
            }
            if (EnemySpeed <= 0)
            {
                EnemySpeed = 1;
            }
            Console.WriteLine(@"
    敵のステータス
    体積:" + EnemySize +
    @"素早さ:" + EnemySpeed +
    @"攻撃力:" + EnemyAttack +
    @"防御力:" + EnemyDefense);
            Console.WriteLine();

            //戦闘。どちらかの体積が0になるまでオートで続く
            Console.WriteLine(@"戦闘開始！");
            Console.WriteLine();
            int Damege = 0;

            while (Size > 0 || EnemySize < 1)
            {
                if (EnemySpeed > Speed)
                {
                    Damege = rnd.Next(EnemyAttack - Defense - 3, EnemyAttack - Defense + 3);
                    if (Damege < 0) Damege = 1;
                    Console.WriteLine("敵の攻撃！ " + Name + "に" + Damege + "のダメージ！");
                    Size -= Damege;
                    Console.ReadKey();
                    Console.WriteLine(Name + "の残り体積:" + Size);
                    Console.WriteLine();
                    if (Size <= 0)
                    {
                        Console.WriteLine(Name + "は死んでしまった…次はもっとうまくやりたい");
                        Environment.Exit(0);
                    }


                    if (Size > 0)
                    {
                        Damege = rnd.Next(Attack - EnemyDefense - 3, Attack - EnemyDefense + 3);
                        if (Damege < 0) Damege = 1;
                        Console.WriteLine(Name + "の攻撃！ 敵に" + Damege + "のダメージ！");
                        EnemySize -= Damege;
                        Console.ReadKey();
                        Console.WriteLine("敵の残り体積:" + EnemySize);
                        Console.WriteLine();
                        if (EnemySize <= 0)
                        {
                            Console.WriteLine("敵を倒してその体積を吸収した。");
                            Size += InitSize;
                            break;
                        }
                    }


                }
                else
                {
                    Damege = rnd.Next(Attack - EnemyDefense - 3, Attack - EnemyDefense + 3);
                    if (Damege < 0) Damege = 1;
                    Console.WriteLine(Name + "の攻撃！ 敵に" + Damege + "のダメージ！");
                    EnemySize -= Damege;
                    Console.ReadKey();
                    Console.WriteLine("敵の残り体積:" + EnemySize);
                    Console.WriteLine();
                    if (EnemySize <= 0)
                    {
                        Console.WriteLine("敵を倒してその体積を吸収した。");
                        Size += InitSize;
                        break;
                    }

                    if (Size > 0)
                    {
                        Damege = rnd.Next(EnemyAttack - Defense - 3, EnemyAttack - Defense + 3);
                        if (Damege < 0) Damege = 1;
                        Console.WriteLine("敵の攻撃！ " + Name + "に" + Damege + "のダメージ！");
                        Size -= Damege;
                        Console.ReadKey();
                        Console.WriteLine(Name + "の残り体積:" + Size);
                        Console.WriteLine();
                        if (Size <= 0)
                        {
                            Console.WriteLine(Name + "は死んでしまった…次はもっとうまくやりたい");
                            Environment.Exit(0);
                        }

                    }

                    if (Size <= 0)
                    {
                        Console.WriteLine(Name + "は死んでしまった…次はもっとうまくやりたい");
                        Environment.Exit(0);
                    }
                    if (EnemySize <= 0)
                    {
                        Console.WriteLine("敵を倒してその体積を吸収した。");
                        Size += InitSize;
                        break;
                    }
                }
            }
        }

        //襲ってくる人間から逃げる---------------------------------
        static void HumanSystem()
        {

            Console.WriteLine(@"
    人間が退治しに来た！全力で逃げなければ。");
            Console.ReadKey();
            Random rnd = new Random();
            int NumberOfPeople = rnd.Next(Magic - 10, Magic);
            Console.WriteLine(@"
    人間の人数は…" + NumberOfPeople + "人だ！"); Console.ReadKey();
            Console.WriteLine(@"
    なんとか逃げ切る事ができた…");
            Console.ReadKey();
            Console.WriteLine(@"
    とても疲れた、体内の食料が消費された");
            Console.ReadKey();
            Console.WriteLine(@"
    しかし必死に逃げたおかげで素早さが上がった");

            Food -= NumberOfPeople;
            Speed += Magic;
            Console.WriteLine("残り食料:" + Food + "素早さ:" + Speed);
        }

        //基本コマンドの表示-------------------------------------
        static void BasicComand()
        {
            Console.WriteLine();
            Console.WriteLine(@"1、じっとする:脅威度減少、食料消費:１、魔素吸収:小
2、深呼吸する:脅威度維持、食料消費１、魔素吸収:大
3、餌を探す:脅威度上昇:大、食料消費１．魔素吸収:中、食料採集1~5");
            Console.WriteLine();
        }

        //成長コマンドの表示--------------------------------------------
        static void GrowthComand()
        {
            Console.WriteLine();
            Console.WriteLine(@"1、体積を増やす:食料消費５、体積上昇
2、素早さを上げる:魔素消費10、素早さ上昇
3、攻撃力をあげる:魔素消費10、攻撃力上昇
4、防御力:魔素消費10、防御力上昇
5、何もしない:変化なし");
            Console.WriteLine();
        }

        //成長コマンドのチェック----------------------------------------
        static void GrouthCheck()
        {
            string key = Console.ReadLine();
            int Comand;
            bool result = int.TryParse(key, out Comand);
            if (result == true)
            {
                if (Comand == 1)
                {
                    if (Food > UseFood + 1)
                    {
                        Random rnd = new Random();
                        int UpSize = rnd.Next(5, 11);

                        Console.WriteLine("体積を成長させた");
                        Size += UpSize;
                        Food -= UseFood;
                        Console.WriteLine();
                        Console.WriteLine("食料:" + Food + "体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("食料が足りなくなってしまう…別のことをしよう。");
                        GrouthCheck();
                    }
                }
                else if (Comand == 2)
                {
                    if (Magic >= UseMagic)
                    {
                        Console.WriteLine("素早さを成長させた");

                        Random rnd = new Random();
                        int UpSpeed = rnd.Next(2, 10);

                        Speed += UpSpeed;
                        Magic -= UseMagic;
                        Console.WriteLine();
                        Console.WriteLine("体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("成長するための魔力が足りない…別のことをしよう。");
                        GrouthCheck();
                    }
                }
                else if (Comand == 3)
                {
                    if (Magic >= UseMagic)
                    {
                        Console.WriteLine("攻撃力を上昇させた");

                        Random rnd = new Random();
                        int UpAttack = rnd.Next(2, 10);

                        Attack += UpAttack;
                        Magic -= UseMagic;
                        Console.WriteLine();
                        Console.WriteLine("体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("成長するための魔力が足りない…別のことをしよう。");
                        GrouthCheck();
                    }
                }
                else if (Comand == 4)
                {
                    if (Magic >= UseMagic)
                    {
                        Console.WriteLine("防御力を上昇させた");

                        Random rnd = new Random();
                        int UpDefense = rnd.Next(2, 10);

                        Defense += UpDefense;
                        Magic -= UseMagic;
                        Console.WriteLine();
                        Console.WriteLine("体積:" + Size + "素早さ:" + Speed + "攻撃力:" + Attack + "防御力:" + Defense + "魔素:" + Magic);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("成長するための魔力が足りない…別のことをしよう。");
                        GrouthCheck();
                    }
                }
                else if (Comand == 5)
                {
                    Console.WriteLine("何もしない…時間だけが無駄に過ぎていく。");
                }
                else
                {
                    Console.WriteLine(@"
    コマンド入力失敗
    もう一度入力してください");
                    GrouthCheck();
                }

            }
            else
            {
                Console.WriteLine(@"
    コマンド入力失敗
    もう一度入力してください");
                GrouthCheck();
            }
        }

        //基本コマンドのチェック----------------------------------
        static void ComandCheck()
        {
            string key = Console.ReadLine();
            int Comand;
            bool result = int.TryParse(key, out Comand);
            if (result == true)
            {
                if (Comand == 1)
                {
                    Random rnd = new Random();
                    int UpMagic = rnd.Next(1, 6);
                    int DownHate = rnd.Next(1, 11);

                    Console.WriteLine();
                    Console.WriteLine("じっとしている・・・");
                    Hate -= DownHate;
                    if (Hate < 0) Hate = 0;
                    Food--;
                    Magic += UpMagic;
                    Console.WriteLine("食料:" + Food + "脅威度:" + Hate + "魔素:" + Magic);
                    Console.ReadKey();
                }
                else if (Comand == 2)
                {
                    Random rnd = new Random();
                    int UpMagic = rnd.Next(1, 16);

                    Console.WriteLine();
                    Console.WriteLine("深呼吸をした！");

                    Food--;
                    Magic += UpMagic;
                    Console.WriteLine("食料:" + Food + "脅威度:" + Hate + "魔素:" + Magic);
                    Console.ReadKey();
                }
                else if (Comand == 3)
                {
                    Random rnd = new Random();
                    int UpMagic = rnd.Next(1, 8);
                    int UpHate = rnd.Next(5, 16);
                    Console.WriteLine();
                    Console.WriteLine("餌を探し回った！");

                    Hate += UpHate;
                    Food--;
                    Magic += UpMagic;
                    int addFood = rnd.Next(1, 6);
                    Food += addFood;

                    Console.WriteLine("食料:" + Food + "脅威度:" + Hate + "魔素:" + Magic);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(@"
    コマンド入力失敗
    もう一度入力してください");
                    ComandCheck();
                }
            }
            else
            {
                Console.WriteLine(@"
    コマンド入力失敗
    もう一度入力してください");
                ComandCheck();
            }
        }

        //名前の入力---------------------------
        static void NameCheck()
        {
            Console.WriteLine(@"
    まずはスライムの名前を五文字以内で決めてください");
            Name = Console.ReadLine();
            if (Name.Length == 0 || Name.Length > 5)
            {
                Console.WriteLine("条件に合いません、もう一度考え直してください");
                Name = "";
                NameCheck();
            }
            else
            {
                Console.WriteLine(@"
    スライムの名前は'" + Name + "'になりました。");
            }
            Console.ReadKey();
        }

    }
}

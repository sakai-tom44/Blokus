using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Blokus
{
    class Block
    {
        //******************************
        // 右回転
        public static int[,] migiKaiten(int[,] b)
        {
            int r = b.GetLength(0);
            int[,] nb = new int[r, r];

            for (int x = 0; x < r; x++)
            {
                for (int y = 0; y < r; y++)
                {
                    nb[x, y] = b[y, r - 1 - x];
                }
            }
   
            return nb;
        }
        //******************************
        // 左回転
        public static int[,] hidariKaiten(int[,] b)
        {
            int r = b.GetLength(0);
            int[,] nb = new int[r, r];

            for (int x = 0; x < r; x++)
            {
                for (int y = 0; y < r; y++)
                {
                    nb[x, y] = b[y, x];
                }
            }

            return nb;
        }
        //******************************
        // 左右反転
        public static int[,] sayuuHanten(int[,] b)
        {
            int r = b.GetLength(0);
            int[,] nb = new int[r, r];


            for (int x = 0; x < r; x++)
            {
                for (int y = 0; y < r; y++)
                {
                    nb[x, y] = b[r - 1 - x, y];
                }
            }

            return nb;
        }
        //***********************************
        // はみ出さないか調べる
        public static bool hamidasanai(int[,] banmen, int[,] b, int x, int y)
        {
            int r = b.GetLength(0);
            for (int xi = 0; xi < r; xi++)
            {
                for (int yi = 0; yi < r; yi++)
                {
                    if ((b[xi, yi]) == 2 && (banmen[x + xi, y + yi] == 100))
                        return false;
                }
            }
            return true;
        }

        //******************************
        // 置けるかどうか判定する
        public static bool okerukana(int[,] banmen, int[,] b, int x, int y, int jibun)
        {
            int r = b.GetLength(0); // ブロックの大きさ
            bool ret = false;
            for(int xi=0; xi<r; xi++)
            {
                for(int yi=0; yi<r; yi++)
                {
                    int c = banmen[x + xi, y + yi];
                    int d = b[xi, yi];
                    if((c > 0) && d== 2) // 物理的に置けない場合
                    {
                        return false;
                    }
                    if((c == jibun) && d== -1) // 辺が接する場合
                    {
                        return false;
                    }
                    if((c == jibun) && d== 1) // 接する角が見つかった
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }
        //******************************
        // ブロック配列に-1とかを設定する
        private static void blockListSettei(List<int[,]> li)
        {
            foreach (int[,] x in li)
            {
                int r = x.GetLength(0);
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < r; j++)
                        x[i, j] = hairetsuSyuusei(x, i, j, r);
            }
        }

        //**********************
        // ブロックの総数を数える．点数計算に使う．　最大は89個．
        public static int nokoriNoKazu(List<int[,]> li)
        {
            int c = 0;
            foreach (int[,] x in li)
            {
                int r = x.GetLength(0);
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        if (x[i, j] == 2) c++;
                    }
                }
            }
            //Console.WriteLine("個数は {0}", c);
            return c;
        }

        //**********************
        // ブロックの角を数える
        public static int kadoNoKazu(int[,] x)
        {
            int c = 0;
            
            int r = x.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (x[i, j] == 1) c++;
                }
            }
            
            //Console.WriteLine("個数は {0}", c);
            return c;
        }

        //**********************
        // ブロックの面積を数える
        public static int mensekiNoKazu(int[,] x)
        {
            int c = 0;

            int r = x.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (x[i, j] == 2) c++;
                }
            }

            //Console.WriteLine("個数は {0}", c);
            return c;
        }

        //**********************
        // ブロックの幅を数える
        public static float habaNoKazu(int[,] x)
        {
            int top = 99;
            int bottom = 0;
            int rigth = 99;
            int left = 0;

            int r = x.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (x[i, j] == 2)
                    {
                        if (top > j) top = j;
                        if (bottom < j) bottom = j;
                        if (rigth > i) rigth = i;
                        if (left < i) left = i;
                    }
                }
            }
            float h = bottom - top;
            float w = left - rigth;
            float ans = (float)Math.Sqrt(h*h + w*w);

            //Console.WriteLine("個数は {0}", c);
            return ans;
        }

        //******************************
        // 読み込んだブロックのチェック，-1とかの設定    for debug   開発時に使っていた．もう使わない
        public static  void blockListCheck(List<int[,]> li)
        {
            foreach (int[,] x in li)
            {
                int r = x.GetLength(0);
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        x[i, j] = hairetsuSyuusei(x, i, j, r);
                        if (x[i, j] >= 2)
                        {
                            Console.Write("■");

                        }
                        else if (x[i, j] == 1)
                        {
                            Console.Write("〇");
                        }
                        else if (x[i, j] == -1)
                        {
                            Console.Write("×");
                        }
                        else
                        {
                            Console.Write("□");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("--------------");
            }
        }

        //*******************************
        // ブロック配列の値を修正する
        private static int hairetsuSyuusei(int[,] x, int i, int j, int r)
        {
            if (x[i, j] == 2)
            {
                return 2;
            }
            if (checkA(x, i - 1, j, r) == 2 || checkA(x, i + 1, j, r) == 2 ||
                checkA(x, i, j - 1, r) == 2 || checkA(x, i, j + 1, r) == 2)
            {
                return -1;
            }
            if (checkA(x, i - 1, j - 1, r) == 2 || checkA(x, i - 1, j + 1, r) == 2 ||
                checkA(x, i + 1, j - 1, r) == 2 || checkA(x, i + 1, j + 1, r) == 2)
            {
                return 1;
            }
            return 0;

        }
        //ブロック配列の範囲外の値の読み込みのために
        private static int checkA(int[,] x, int i, int j, int r)
        {
            if (i < 0 || i >= r || j < 0 || j >= r)
            {
                return 0;
            }
            return x[i, j];
        }
        //********************************************************
        // ファイル読み込み
        public static List<int[,]>  blockYomikomi()
        {
            List<int[,]> bl = new List<int[,]>();
            StreamReader sr = new StreamReader("data2.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int r = int.Parse(line);
                if (r > 9)
                {
                    break;
                }
                int[,] block = new int[r, r];
                for (int i = 0; i < r; i++)
                {
                    line = sr.ReadLine();
                    string[] data = line.Split('\t');
                    for (int j = 0; j < r; j++)
                    {
                        block[i, j] = int.Parse(data[j]);
                    }
                }

                //Console.ReadLine();
                // リストに追加する．
                bl.Add(block);
            }
            blockListSettei(bl); // -1とかを設定する
            bl.Reverse();
            return bl;
        }
    }

}

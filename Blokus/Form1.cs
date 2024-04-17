namespace Blokus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int[,]>[] gvBlocks = new List<int[,]>[5];

        int[,] banmen = new int[34, 34];

        Random rad = new Random();

        bool[] owatta = { false, false, false, false, false };

        float[,] aiP = { //コンピュータのAIのパラメータ
            {0, 0, 0},
            {3, 1, 1},
            {1, 3, 1},
            {1, 1, 3},
            {1, 1, 1},
        };

        int[,] playerData = {
            {100, 100, 100, 100},
            {27, 1, -1, 1},
            {27, 27, -1, -1},
            {1, 27, 1, -1},
            {1, 1, 1, 1}
        };

        Color[] colorTbl = {
            Color.LightGray,
            Color.Blue,
            Color.Green,
            Color.Red,
            Color.Orange,
            Color.LightBlue,
            Color.LightBlue,
            Color.LightBlue,
            Color.LightBlue,
            Color.Cyan,
            Color.Cyan,
            Color.Cyan,
            Color.Cyan
        };

        int myBx = 10;
        int myBy = 10;
        int myBn = 0;
        int[,] myB = null;
        int iam = 1;
        int gvPTern = 1;

        Bitmap canvas;
        Graphics g;

        bool isAuto = false;
        int winner = -1;
        int[] nokori = { -1, -1, -1, -1, -1 };

        private void reset()
        {
            gvBlocks = new List<int[,]>[5];
            banmen = new int[34, 34];
            for (int i = 0; i < owatta.Length; i++)
            {
                owatta[i] = false;
            }
            myBx = 10;
            myBy = 10;
            myBn = 0;
            myB = null;
            iam = 1;
            gvPTern = 1;

            winner = -1;
            for (int i = 0; i < nokori.Length; i++)
            {
                nokori[i] = -1;
            }

            for (int i = 1; i <= 4; i++)
            {
                gvBlocks[i] = Block.blockYomikomi();
            }
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 34; j++)
                {
                    banmen[i, j] = 100;
                    banmen[j, i] = 100;
                    banmen[33 - i, j] = 100;
                    banmen[j, 33 - i] = 100;
                }
            }

            banmen[6, 27] = 1;
            banmen[6, 6] = 2;
            banmen[27, 6] = 3;
            banmen[27, 27] = 4;
            displayBanmen();

            label1.Text = "Player 1 ";
            label2.Text = "Player 2 ";
            label3.Text = "Player 3 ";
            label4.Text = "Player 4 ";
            label5.Text = "試合中...";
            label7.Text = aiP[1, 0] + "  " + aiP[1, 1] + "  " + aiP[1, 2];
            label8.Text = aiP[2, 0] + "  " + aiP[2, 1] + "  " + aiP[2, 2];
            label9.Text = aiP[3, 0] + "  " + aiP[3, 1] + "  " + aiP[3, 2];
            label10.Text = aiP[4, 0] + "  " + aiP[4, 1] + "  " + aiP[4, 2];
        }
        private void displayBanmen()
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);
            Pen p = new Pen(Color.Black, 1);

            for (int x = 7; x <= 26; x++)
            {
                for (int y = 7; y <= 26; y++)
                {
                    SolidBrush brs = new SolidBrush(colorTbl[banmen[x, y]]);
                    g.FillRectangle(brs, (x - 7) * 30, (y - 7) * 30, 30, 30);
                    brs.Dispose();
                }
            }

            for (int i = 1; i <= 20; i++)
            {
                g.DrawLine(p, 0, i * 30, 600, i * 30);
                g.DrawLine(p, i * 30, 0, i * 30, 6000);
            }
            p.Dispose();
            g.Dispose();
            pictureBox1.Image.Dispose();
            pictureBox1.Image = canvas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void button_auto(object sender, EventArgs e)
        {
            isAuto = !isAuto;
        }

        private void button_reset(object sender, EventArgs e)
        {
            isAuto = false;
            reset();
        }

        private bool sagashiteOku(int pn, int[,] b, int bi, bool flag)
        {
            int r = b.GetLength(0);
            for (int xi = 0; xi < 27; xi++)
            {
                for (int yi = 0; yi < 27; yi++)
                {
                    int x = playerData[pn, 0] + playerData[pn, 2] * xi;
                    int y = playerData[pn, 1] + playerData[pn, 3] * yi;
                    if (Block.okerukana(banmen, b, x, y, pn))
                    {
                        if (flag)
                        {
                            for (int i = 0; i < r; i++)
                            {
                                for (int j = 0; j < r; j++)
                                {
                                    if (b[i, j] == 2)
                                    {
                                        banmen[x + i, y + j] = pn;
                                    }
                                }
                            }
                            gvBlocks[pn].RemoveAt(bi);
                        }
                        displayBanmen();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool playTern(int pn, bool flag)
        {
            if (owatta[pn])
            {
                return false;
            }

            sortBlocks(pn);

            for (int bi = 0; bi < gvBlocks[pn].Count; bi++)
            {
                int[,] b = gvBlocks[pn][bi];
                for (int kaiten = 0; kaiten < 4; kaiten++)
                {
                    if (sagashiteOku(pn, b, bi, flag))
                    {
                        return true;
                    }
                    b = Block.migiKaiten(b);
                }
                b = Block.sayuuHanten(b);
                for (int kaiten = 0; kaiten < 4; kaiten++)
                {
                    if (sagashiteOku(pn, b, bi, flag))
                    {
                        return true;
                    }
                    b = Block.migiKaiten(b);
                }
            }

            owatta[pn] = true;

            nokori[pn] = Block.nokoriNoKazu(gvBlocks[pn]);

            if (pn == 1)
            {
                label1.Text = "Player 1 投了 " + nokori[pn];
            }
            else if (pn == 2)
            {
                label2.Text = "Player 2 投了 " + nokori[pn];
            }
            else if (pn == 3)
            {
                label3.Text = "Player 3 投了 " + nokori[pn];
            }
            else if (pn == 4)
            {
                label4.Text = "Player 4 投了 " + nokori[pn];
            }

            if (owatta[1] && owatta[2] && owatta[3] && owatta[4])
            {
                int min = nokori[1];
                winner = 1;
                for (int i = 2; i <= 4; i++)
                {
                    if (min > nokori[i])
                    {
                        min = nokori[i];
                        winner = i;
                    }
                }
                label5.Text = "勝者 Player " + winner;
            }

            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isAuto)
            {
                next();

                label6.Text = "RUN";
            }
            else
            {
                label6.Text = "STOP";
            }
        }

        private void next()
        {
            if (winner > 0)
            {
                aiRefresh();
                reset();
            }
            else
            {
                do //すでに投了しているプレイヤーはスキップ（起こり得ないとは思うが、全員が投了している場合無限ループになる）
                {
                    gvPTern = gvPTern % 4 + 1;
                } while (owatta[gvPTern]);
                playTern(gvPTern, true);
            }
        }

        private void button_next(object sender, EventArgs e)
        {
            next();
        }

        private class BlockScore
        {
            public int number;
            public int score;

            public BlockScore(int number, int score)
            {
                number = this.number;
                score = this.score;
            }
        }

        private void sortBlocks(int pn) //ブロックを優先順位で並べ替え
        {
            gvBlocks[pn].Sort((a, b) => blockScore(b, pn).CompareTo(blockScore(a, pn)));
        }

        private float blockScore(int[,] x, int pn) //各ブロックのスコアを計算
        {
            float kado = Block.kadoNoKazu(x);
            float area = Block.mensekiNoKazu(x);
            float scale = Block.habaNoKazu(x);

            float score = kado * aiP[pn, 0] + area * aiP[pn, 1] + scale * aiP[pn, 2];

            return score;
        }

        private void aiRefresh()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i != winner)
                {
                    int c = rad.Next(3);
                    aiP[i, c] = Math.Max(Math.Min((aiP[i, c] + ((float)(rad.NextDouble()) - 0.5f)), 3), 0);
                }
            }
        }
    }
}
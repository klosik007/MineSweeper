using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private int m;//width and
        private int n; //height of board
        private int hmmines;
        private Button button;
        private int l = -1;
        //private double p; //probability of bomb existence
        private bool[,] mines; //board array: true - mine is on, false - mine is off
        private int[,] sol; //array for printing solution

        private List<Button> lb = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            m = 10;
            n = 10;
            hmmines = 10;
        }

        public void fillSolution()
        {
            sol = new int[m + 2, n + 2];

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                    for (int ii = i - 1; ii <= i + 1; ii++) //neighbor
                        for (int jj = j - 1; jj <= j + 1; jj++)
                            if (mines[ii, jj]) sol[i, j]++;
        }

        public void fillWithMines(int m, int n, int hmmines)
        {
            this.m = m;
            this.n = n;
            this.hmmines = hmmines;

            mines = new bool[m + 2, n + 2];

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    mines[i, j] = false;
                }

            Random rr = new Random();
            int x;
            int y;
            for (int i = 1; i <= hmmines; i++)
            {
                x = rr.Next(m);//shuffle position of each bomb
                y = rr.Next(n);
                mines[x, y] = true;//plant a bomb
            }
        }

        public void removeButtons(int m, int n)// it doesnt work as intended
        {
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    this.Controls.Remove(button);//.Remove(button);
                }
            }
        }

        public void CreateButtons(int m, int n, int hmmines)
        {
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    button = new Button();
                    l++;
                    button.Width = 20;
                    button.Height = 20;
                    button.Location = new Point(20 * i - 20, 20 * j + 10);
                    button.Click += new EventHandler(ButtonClickEvent);
                    button.Tag = 0;
                    this.Controls.Add(button);
                    button.ForeColor = SystemColors.ControlLight;
                    button.Text = Convert.ToString(sol[i, j]);
                    if (mines[i, j]) button.Text = "*";
                }
            }
        }

        /*  public Form1(int m, int n, double p)
          {
              this.m = m;
              this.n = n;
              this.p = p;
              mines = new bool[m + 2, n + 2];
              Random rr = new Random();
              for (int i = 0; i < m; i++)
                  for (int j = 0; j < n; j++)
                  {
                     // mines[i, j] = (rr.Next < p); //filling boolean values with probability p
                  }
              fillSolution();
          }*/

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ButtonClickEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                switch ((int)button.Tag)
                {
                        case 0:
                        button.ForeColor = SystemColors.ControlText;
                        if (button.Text == "*")
                        {
                            MessageBox.Show("Game over!");
                        }
                        break;
                }
            }
        }

        private void specifyBoardSizeAndBombsAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           fillWithMines(m, n, hmmines);
            fillSolution();
            CreateButtons(m, n, hmmines);
            this.Width = 20 * m + 20;
            this.Height = 20 * n + 70;
        }
    }
}

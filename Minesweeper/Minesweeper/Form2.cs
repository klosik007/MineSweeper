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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();

            frm1.m = Convert.ToInt32(textBox1.Text);
            frm1.n = Convert.ToInt32(textBox2.Text);
            frm1.hmmines = Convert.ToInt32(textBox3.Text);

            frm1.fillWithMines(frm1.m, frm1.n , frm1.hmmines);
            frm1.fillSolution();
            frm1.CreateButtons(frm1.m, frm1.n, frm1.hmmines);
            frm1.Width = 20 * frm1.m + 20;
            frm1.Height = 20 * frm1.n + 70;
            frm1.Load += Frm1_Load;
            this.Close();
        }

        private void Frm1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

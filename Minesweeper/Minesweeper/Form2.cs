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
        private Form1 frm1;
        public Form2(Form1 form)
        {
            InitializeComponent();
            frm1 = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1._m = Convert.ToInt32(textBox1.Text);
            frm1._n = Convert.ToInt32(textBox2.Text);
            frm1._hmmines = Convert.ToInt32(textBox3.Text);

            frm1.removeButtons(frm1._m, frm1._n);
            //frm1.Controls.Clear();
            frm1.fillWithMines(frm1._m, frm1._n, frm1._hmmines);
            frm1.fillSolution();
            frm1.CreateButtons(frm1._m, frm1._n, frm1._hmmines);
            frm1.Width = 20 * frm1._m + 20;
            frm1.Height = 20 * frm1._n + 70;
 
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public bool IsX { get; set; }
        Button[,] b = new Button[2, 2];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Location = new Point(i * 50, j * 50);
                    b[i, j].Size = new Size(50, 50);
                    b[i, j].Text = "";
                    b[i, j].Click += B_Click;
                    this.Controls.Add(b[i, j]);
                }
            }
            this.ClientSize = new Size(b.GetLength(0) * 50 + 3, b.GetLength(1) * 50 + 3);
        }
        public void Winner()
        {
            //диагонали
            for (int i = 1; i < b.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < b.GetLength(1) - 1; j++)
                {
                    if (b[i - 1, j + 1].Text == b[i, j].Text && b[i + 1, j - 1].Text == b[i, j].Text && b[i - 1, j + 1].Text != "" && b[i + 1, j - 1].Text != "")
                    {
                        b[i, j].BackColor = Color.Red;
                        b[i - 1, j + 1].BackColor = Color.Red;
                        b[i + 1, j - 1].BackColor = Color.Red;
                    }
                    else if (b[i - 1, j - 1].Text == b[i, j].Text && b[i + 1, j + 1].Text == b[i, j].Text && b[i - 1, j - 1].Text != "" && b[i + 1, j + 1].Text != "")
                    {
                        b[i, j].BackColor = Color.Red;
                        b[i - 1, j - 1].BackColor = Color.Red;
                        b[i + 1, j + 1].BackColor = Color.Red;
                    }
                }
            }
            //право-лево
            for (int i = 0; i < b.GetLength(0) ; i++)
            {
                for (int j = 1; j < b.GetLength(1) - 1; j++)
                {
                    if (b[i, j - 1].Text == b[i, j].Text && b[i, j + 1].Text == b[i, j].Text && b[i, j - 1].Text != "" && b[i, j + 1].Text != "")
                    {
                        b[i, j].BackColor = Color.Blue;
                        b[i, j - 1].BackColor = Color.Blue;
                        b[i, j + 1].BackColor = Color.Blue;
                    }
                }
            }
            //up - down
            for (int i = 1; i < b.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i - 1, j].Text == b[i, j].Text && b[i + 1, j].Text == b[i, j].Text && b[i - 1, j].Text != "" && b[i + 1, j].Text != "")
                    {
                        b[i, j].BackColor = Color.Yellow;
                        b[i - 1, j].BackColor = Color.Yellow;
                        b[i + 1, j].BackColor = Color.Yellow;
                    }
                }
            }
            WhoWins();

        }
        public void WhoWins()
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j].Text != "")
                        continue;
                    else
                        break;
                }
            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b.Text == "" && IsX == true)
            {
                b.Text = "X";
                IsX = !IsX;

            }
            else if (b.Text == "")
            {
                b.Text = "O";
                IsX = !IsX;
            }
            Winner();
        }
    }
}

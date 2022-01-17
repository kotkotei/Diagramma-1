using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Переносим_диаграмму_ьлин
{
    public partial class Form1 : Form
    {
        person[] p;
        public struct person
        {
            public int x;
            public int y;
            public int xy;
            public int xx;
            public int y2;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = 12;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1[1, 10].Value = ("Сумм");
            dataGridView1[1, 11].Value = ("k=");
            p = new person[dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.RowCount - 2; i++)
            {
                dataGridView1[0, i].Value = Convert.ToInt32(i + 1);
                p[i].x = i + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Random r = new Random();
                int xy1 = 0;
                int xy2 = 0;
                for (int i = 0; i < dataGridView1.RowCount - 2; i++)
                {

                    p[i].y = r.Next(10 * i, 10 * i + 10);
                    //p[i].y = r.Next(10 * i, 10 * i);
                    dataGridView1[1, i].Value = Convert.ToInt32(p[i].y);
                    p[i].xy = p[i].x * p[i].y;
                    dataGridView1[2, i].Value = Convert.ToInt32(p[i].xy);
                    p[i].xx = p[i].x * p[i].x;
                    dataGridView1[3, i].Value = Convert.ToInt32(p[i].xx);
                    xy1 = xy1 + p[i].xy;
                    xy2 = xy2 + p[i].xx;
                    dataGridView1[2, 10].Value = xy1;
                    dataGridView1[3, 10].Value = xy2;
                }
                int b = xy1 / xy2;
                dataGridView1[2, 11].Value = b;
                for (int i = 0; i < dataGridView1.RowCount - 2; i++)
                {
                    p[i].y2 = b * p[i].x;
                    dataGridView1[4, i].Value = Convert.ToInt32(p[i].y2);
                }
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                SolidBrush m = new SolidBrush(Color.Black);
                int d = 100;
                for (int i = 0; i < dataGridView1.RowCount - 2; i++)
                {

                    g.DrawString(Convert.ToString(d - (i * 10)), button1.Font, m, 10, i * 33);

                }
                for (int i = 0; i < dataGridView1.RowCount - 3; i++)
                {
                    g.DrawString(Convert.ToString(i + 2), button1.Font, m, (i + 1) * 45, 310);
                }

                double t = 3.4;
                double t1 = 0;
                for (int i = 1; i < dataGridView1.RowCount - 2; i++)
                {
                    t1 = p[i].y * t;
                    g.FillEllipse(m, (45 * i), 340 - Convert.ToInt32(t1), 8, 8);
                }
                Pen w = new Pen(Color.Red);
                Point p1 = new Point(45, 285);
                Point p2 = new Point(420, 40);
                g.DrawLine(w, p1, p2);
            }
        }
    }
}
        
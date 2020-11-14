using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = 5;
            float M = 0;
            float Cmx = 0;
            float Cmy = 0;
            Bitmap BM;
            Graphics Gr;
            float[] X, Y, m;
            Random rnd = new Random();
            int Lx = pictureBox1.Width;
            int Ly = pictureBox1.Height;
            SolidBrush Brush1 = new SolidBrush(Color.Gray);
            SolidBrush Brush2 = new SolidBrush(Color.Red);

            BM = new Bitmap(Lx, Ly);
            Gr = Graphics.FromImage(BM);
            X = new float[N];
            Y = new float[N];
            m = new float[N]; 
            // Задаем координаты и массы для тел в системе
            for (int i=0; i<N; i++)
            {
                X[i] = Convert.ToSingle(rnd.Next(Lx));
                Y[i] = Convert.ToSingle(rnd.Next(Ly));
                m[i] = rnd.Next(0, 1000);
            }
            // Находим массу всей системы
            for (int i = 0; i < N; i++)
            {
                M += m[i];  
            }
            // Находим центр масс
            for (int i = 0; i < N; i++)
            {
                Cmx += m[i] * X[i] / M;
                Cmy += m[i] * Y[i] / M;
            }
            // Отображаем материальные точки
            for (int i = 0; i < N; i++)
            {
                Gr.FillEllipse(Brush1, X[i], Y[i], 10, 10);
            }
            // Отображаем центр масс
            Gr.FillEllipse(Brush2, Cmx, Cmy, 10, 10);

            pictureBox1.Image = BM;
        }
    }
}

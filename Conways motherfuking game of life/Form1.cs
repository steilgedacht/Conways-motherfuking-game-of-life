using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conways_motherfuking_game_of_life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool[,] FettesArrayNumero1 = new bool[500, 500];
        bool[,] FettesArrayNumero2 = new bool[500, 500];
        Bitmap bmp = new Bitmap(500, 500);
        // Start Stop Control
        private void StartStop_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }
        // Kreislauf der Abfragen der Kacheln
        private void timer1_Tick(object sender, EventArgs e)
        {
            int nachbarn = 0;
            for (int y = 1; y < 500; y++)
            {
                for (int x = 1; x < 500; x++)
                {
                    bmp.SetPixel(x, y, Color.White);
                }
            }
            pictureBox1.Image = bmp;

            for (int y = 1; y < Convert.ToInt16(textBox1.Text); y++)
            {
                for (int x = 1; x < Convert.ToInt16(textBox1.Text); x++)
                {
                    nachbarn = 0;
                    if (FettesArrayNumero1[x - 1, y] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x - 1, y + 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x, y + 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x + 1, y + 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x + 1, y] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x + 1, y - 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x, y - 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (FettesArrayNumero1[x - 1, y - 1] == true)
                    {
                        nachbarn += 1;
                    }
                    if (nachbarn == 3)
                    {
                        FettesArrayNumero2[x, y] = true;
                        bmp.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        if (nachbarn != 2)
                        {
                            FettesArrayNumero2[x, y] = false;
                            bmp.SetPixel(x, y, Color.White);
                        }
                        else
                        {
                            if (FettesArrayNumero1[x,y]== false)
                            {
                                FettesArrayNumero2[x, y] = false;
                                bmp.SetPixel(x, y, Color.White);
                            }
                            if (FettesArrayNumero1[x,y ] == true)
                            {
                                FettesArrayNumero2[x, y] = true;
                                bmp.SetPixel(x, y, Color.Black);
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < 500; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                    FettesArrayNumero1[x, y] = FettesArrayNumero2[x, y];
                }
            }
            pictureBox1.Image = bmp;
        }

        private void Generieren_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < 500; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                    bmp.SetPixel(x, y, Color.White);
                    FettesArrayNumero1[x, y] = false;
                    FettesArrayNumero2[x, y] = false;
                }
            }
            Random rand = new Random();
            bool pixel;
            for (int y = 0; y < 500; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                    pixel = rand.Next(2) == 0 ? false : true;
                    if (pixel == true)
                    {
                        bmp.SetPixel(x, y, Color.Black);
                        FettesArrayNumero1[x, y] = true;
                        FettesArrayNumero2[x, y] = true;
                    }
                    else
                    {
                        FettesArrayNumero1[x, y] = false;
                        FettesArrayNumero2[x, y] = false;
                    }
                } 
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt16( 10 * trackBar1.Value);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (FettesArrayNumero1[e.X, e.Y] == false)
            {
                FettesArrayNumero1[e.X, e.Y] = true;
                bmp.SetPixel(e.X, e.Y, Color.Black);
            }
            else
            {
                FettesArrayNumero1[e.X, e.Y] = false;
                bmp.SetPixel(e.X, e.Y, Color.White);
            }
            pictureBox1.Image = bmp;
        }
    }
}

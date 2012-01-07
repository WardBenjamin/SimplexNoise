using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimplexNoise;

namespace NoiseTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateBitmapAtRuntime();
        }

        PictureBox pictureBox1 = new PictureBox();

        public void CreateBitmapAtRuntime()
        {
            pictureBox1.Size = new Size(510, 510);
            this.Controls.Add(pictureBox1);

            Bitmap flag = new Bitmap(500, 500);
            Graphics flagGraphics = Graphics.FromImage(flag);

            for (int x = 0; x < 500; ++x)
            {
                for (int y = 0 ; y < 500 ; ++y)
                {
                    int cval = (int)(Noise.Generate(x / 200f, y / 200f) * 128 + 128);
                    
                    Color col = Color.FromArgb(cval, cval, cval);
                    SolidBrush brush = new SolidBrush(col);

                    Rectangle rect = new Rectangle(x, y, 1, 1);
                    flagGraphics.FillRectangle(brush, rect);
                }
            }
            
            pictureBox1.Image = flag;

        }
    }
}

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
        PictureBox pictureBox1 = new PictureBox();

        public Form1()
        {
            InitializeComponent();

            this.GridSize.Value = 3;
            this.RecalculateNoise(null, null);

            this.Controls.Add(this.pictureBox1);
        }

        private int GetInt(TextBox textBox)
        {
            int i = 0;
            return int.TryParse(textBox.Text, out i) ? i : 0;
        }

        public void CreateBitmapAtRuntime(int gridSize)
        {
            int padding = this.ControlPanel.Top;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            this.pictureBox1.Top = this.ControlPanel.Bottom + padding;
            this.pictureBox1.Left = this.ControlPanel.Left;
            // this.Controls.Add(pictureBox1);

            int width = this.ClientSize.Width - padding * 2;
            int height = this.ClientSize.Height - this.ControlPanel.Bottom - padding * 2;

            pictureBox1.Size = new Size(width, height);

            stopwatch.Start();

            Bitmap flag = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Rectangle flagRect = new Rectangle(0, 0, width, height);
            Graphics flagGraphics = Graphics.FromImage(flag);

            System.Drawing.Imaging.BitmapData flagData = flag.LockBits(flagRect, System.Drawing.Imaging.ImageLockMode.ReadWrite, flag.PixelFormat);
            int imageByteSize = flagData.Stride * flagData.Height;
            byte[] destinationData = new byte[imageByteSize];
            int bitsPerPixelElement = 32 / 8;

            if (this.OverrideSeed.Checked && (GetInt(this.NewSeed) > 0))
            {
                Noise.Seed = GetInt(this.NewSeed);
            }
            else
            {
                Noise.Seed = 0;
            }

            float[,] values = Noise.Calc2D(width, height, 0.01f);

            for (int x = 0; x < width; x += gridSize)
            {
                for (int y = 0; y < height; y += gridSize)
                {
                    for (int i = 0; i < gridSize; i++)
                    {
                        if ((x + i) >= width) break;
                        for (int j = 0; j < gridSize; j++)
                        {
                            if ((y + j) >= height) break;
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement + 2] = (byte)(values[x,y] * 0.6); // R
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement + 1] = (byte)(values[x,y] * 0.6); // G
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement] = (byte)values[x,y]; // B
                        }
                    }

                    //Color col = Color.FromArgb((int)(cval*0.6f), (int)(cval*0.6f), cval);
                    //SolidBrush brush = new SolidBrush(col);

                    //Rectangle rect = new Rectangle(x, y, gridSize, gridSize);
                    //flagGraphics.FillRectangle(brush, rect);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(destinationData, 0, flagData.Scan0, destinationData.Length);
            flag.UnlockBits(flagData);

            stopwatch.Stop();

            pictureBox1.Image = flag;
            pictureBox1.Invalidate();

            this.TimeTakenLabel.Text = string.Format("Time taken to generate noise: {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private void RecalculateNoise(object sender, EventArgs e)
        {
            this.NewSeed.Enabled = this.OverrideSeed.Checked;
            int gridSize = this.GridSize.Value;
            CreateBitmapAtRuntime(gridSize);
        }

        private void RecalculateNoise(object sender, ScrollEventArgs e)
        {
            this.GridSizeLabel.Text = string.Format("Grid Size ({0}):", this.GridSize.Value);
            int gridSize = this.GridSize.Value;
            CreateBitmapAtRuntime(gridSize);
        }
    }
}

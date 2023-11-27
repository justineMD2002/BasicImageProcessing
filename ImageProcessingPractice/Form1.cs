using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using ImageProcessingPractice;

namespace ImageProcessingPractice
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Bitmap imageA, imageB;
        Device[] mgaDevice = DeviceManager.GetAllDevices();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            imageB = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = imageB;
        }

        private void copyPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel((loaded.Width - 1) - i, j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, (loaded.Height - 1) - j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void invertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            pictureBox2.Image = processed;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            byte gray;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    gray = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                    processed.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color sample;
            Color gray;
            Byte graydata;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    sample = loaded.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    loaded.SetPixel(x, y, gray);
                }
            }

            int[] histdata = new int[256];
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    sample = loaded.GetPixel(x, y);
                    histdata[sample.R]++;
                }
            }

            processed = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    processed.SetPixel(x, y, Color.White);
                }
            }

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, processed.Height - 1); y++)
                {
                    processed.SetPixel(x, (processed.Height - 1) - y, Color.Black);
                }
            }
            pictureBox2.Image = processed;
        }

        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width; x++)
                {
                    Color pixel = loaded.GetPixel(x, y);

                    int a = pixel.A;
                    int R = pixel.R;
                    int G = pixel.G;
                    int B = pixel.B;

                    int newRed = (int)(0.393 * R + 0.769 * G + 0.189 * B);
                    int newGreen = (int)(0.349 * R + 0.686 * G + 0.168 * B);
                    int newBlue = (int)(0.272 * R + 0.534 * G + 0.131 * B);


                    R = (newRed > 255) ? 255 : newRed;
                    G = (newGreen > 255) ? 255 : newGreen;
                    B = (newBlue > 255) ? 255 : newBlue;

                    processed.SetPixel(x, y, Color.FromArgb(a, R, G, B));
                }
            }
            pictureBox2.Image = processed;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Please open an image first.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|Bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Processed Image";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                processed.Save(saveFileDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Image saved successfully.");
            }
        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = imageA;
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mgaDevice.Length > 0)   
            {
                Device d = DeviceManager.GetDevice(0);
                d.ShowWindow(pictureBox1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap res = new Bitmap(imageB.Width, imageB.Height);
            Color mygreen = Color.FromArgb(0, 0, 255);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);

                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);

                    if (subtractvalue > threshold)
                        res.SetPixel(x, y, pixel);
                    else
                        res.SetPixel(x, y, backpixel);
                }
            }
            pictureBox3.Image = res;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Device d = DeviceManager.GetDevice(0);
            d.Stop();
        }
    }
}
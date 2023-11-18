using System.Drawing.Imaging;

namespace ImageProcessingPractice
{
    public partial class Form1 : Form
    {
        Bitmap loaded;
        Bitmap processed;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
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
            //Grayscale Convertion;
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

            //histogram 1d data;
            int[] histdata = new int[256]; // array from 0 to 255
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    sample = loaded.GetPixel(x, y);
                    histdata[sample.R]++; // can be any color property r,g or b
                }
            }

            // Bitmap Graph Generation
            // Setting empty Bitmap with background color
            processed = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    processed.SetPixel(x, y, Color.White);
                }
            }
            // plotting points based from histdata
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

                    // Calculate newRed, newGreen, newBlue
                    int newRed = (int)(0.393 * R + 0.769 * G + 0.189 * B);
                    int newGreen = (int)(0.349 * R + 0.686 * G + 0.168 * B);
                    int newBlue = (int)(0.272 * R + 0.534 * G + 0.131 * B);

                    // Check conditions
                    R = (newRed > 255) ? 255 : newRed;
                    G = (newGreen > 255) ? 255 : newGreen;
                    B = (newBlue > 255) ? 255 : newBlue;

                    // Set new RGB value
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
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageFlipper
{
    public partial class Form1 : Form
    {

        string[] files;
        public Form1()
        {
            InitializeComponent();
            //Image.FromFile(@"C:\Users\Connor\Desktop\UA-VR-Libraries\ImageFlipper\IamgeFlipper\test.jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("flippedOutput");
            //Bitmap bitmap = (Bitmap)pictureBox1.Image;
            Bitmap bitmap;
            string saveName; int lastSlash = 0;
            for (int i = 0; i < files.Length; i++)
            {
                saveName = "";
                for(int j = 0; j < files[i].Length; j++)
                {
                    if (files[i][j] == '\\')
                        lastSlash = j;
                }
                for (int j = lastSlash; j < files[i].Length; j++)
                    saveName += files[i][j];
                bitmap = (Bitmap)Image.FromFile(files[i]);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                bitmap.Save(@"flippedOutput\" + saveName, ImageFormat.Jpeg);
                bitmap.Dispose();
            }
            label1.Text += "\nDONE! CHECK THE OUTPUT FOLDER!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath);
                }
            }
            label1.Text = "This super awesome tool is made to flip images. \nSelect a folder then press flip!";
        }
    }
}

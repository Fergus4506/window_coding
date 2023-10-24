using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pic_edi
{
    public partial class Form1 : Form
    {
        private List<Bitmap> imageList = new List<Bitmap>();
        private List<Bitmap> originalImageList = new List<Bitmap>();
        private int currentImageIndex = 0;

        private Size defaultImagePicturebox;

        private bool isDrawing = false;
        private Point previousPoint;

        private Pen currentPen = new Pen(Color.Black, 2);

        private float minScaleFactor = 0.1f;
        private float maxScaleFactor = 2.0f;
        Point originalCenter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 600;

            //設定顏色選擇器的基礎顏色
            colorPicker.BackColor = Color.Black;

            //記住預設picturebox大小
            defaultImagePicturebox = imageGroupBox.Size;
            //imagePicturebox.BackColor = Color.Black;//用於方便查看PictureBox範圍

            //在 imageGroupBox 範圍裡可以使用滑鼠滾輪事件(圖片放大縮小)
            imageGroupBox.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);

            //計算 groupBox 中心點
            originalCenter = new Point(imageGroupBox.Width / 2, imageGroupBox.Height / 2);
        }

        private Bitmap ResizeImage(Image image, int width, int height) {
            Bitmap resizedImage = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(resizedImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, width, height);

            return resizedImage;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e) {
            float scaleFactor = 1.1f;
            float newWidth = imagePicturebox.Width;
            float newHeight = imagePicturebox.Height;
            if (e.Delta > 0 && newWidth <= originalImageList[currentImageIndex].Width * maxScaleFactor && newHeight <= originalImageList[currentImageIndex].Height * maxScaleFactor)
            {
                imagePicturebox.Width = (int)(imagePicturebox.Width * scaleFactor);
                imagePicturebox.Height = (int)(imagePicturebox.Height * scaleFactor);
            }
            else if (e.Delta < 0 && newWidth >= originalImageList[currentImageIndex].Width * minScaleFactor && newHeight >= originalImageList[currentImageIndex].Height * minScaleFactor)
            {
                imagePicturebox.Width = (int)(imagePicturebox.Width / scaleFactor);
                imagePicturebox.Height = (int)(imagePicturebox.Height / scaleFactor);
            }

            imagePicturebox.Left = originalCenter.X - imagePicturebox.Width / 2;
            imagePicturebox.Top = originalCenter.Y - imagePicturebox.Height / 2;


            imagePicturebox.Image = ResizeImage(imageList[currentImageIndex], imagePicturebox.Width, imagePicturebox.Height);

            imagePicturebox.Invalidate();
        }

        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "圖像文件|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK) { 
                    foreach(string fileName in openFileDialog.FileNames){
                        Bitmap newImage = new Bitmap(fileName);
                        imageList.Add(newImage);

                        originalImageList.Add(newImage);
                    }
                    currentImageIndex = 0;
                    ShowCurrentImage();
                }
            }
        }

        private void ShowCurrentImage() {
            float widthRatio = (float)imageList[currentImageIndex].Width / defaultImagePicturebox.Width;
            float HeightRatio = (float)imageList[currentImageIndex].Height / defaultImagePicturebox.Height;
            float maxRatio = Math.Max(widthRatio,HeightRatio);

            imagePicturebox.Width = (int)(imageList[currentImageIndex].Width /( maxRatio));
            imagePicturebox.Height = (int)(imageList[currentImageIndex].Height / (maxRatio));


            //Point originalCenter = new Point(imageGroupBox.Width / 2, imageGroupBox.Height / 2);
            imagePicturebox.Left = originalCenter.X - imagePicturebox.Width / 2;
            imagePicturebox.Top = originalCenter.Y - imagePicturebox.Height / 2;
            
            imagePicturebox.Image = ResizeImage(imageList[currentImageIndex],imagePicturebox.Width,imagePicturebox.Height);

            
        }

        private void filpHorizontalBtn_Click(object sender, EventArgs e)
        {
            if (imagePicturebox.Image != null) {
                imagePicturebox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                imagePicturebox.Image = imagePicturebox.Image;
                imageList[currentImageIndex] = new Bitmap(imagePicturebox.Image);
            }
        }

        private void flipVerticalbtn_Click(object sender, EventArgs e)
        {
            if (imagePicturebox.Image != null)
            {
                imagePicturebox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                imagePicturebox.Image = imagePicturebox.Image;
                imageList[currentImageIndex] = new Bitmap(imagePicturebox.Image);
            }
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if (imagePicturebox.Image != null)
            {
                imagePicturebox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                imagePicturebox.Image = imagePicturebox.Image;
                imageList[currentImageIndex] = new Bitmap(imagePicturebox.Image);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (imagePicturebox.Image != null) {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "JPEG圖像|*.jpg";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        imagePicturebox.Image.Save(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (imagePicturebox.Image != null) {
                imagePicturebox.Image = originalImageList[currentImageIndex];
                MessageBox.Show("已還原圖片");
            }
        }

        private void previousImageBtn_Click(object sender, EventArgs e)
        {
            if (currentImageIndex - 1 >= 0)
            {
                currentImageIndex -= 1;
            }
            else {
                currentImageIndex = imageList.Count - 1;
            }
            ShowCurrentImage();
        }

        private void nextImageBtn_Click(object sender, EventArgs e)
        {
            if (currentImageIndex + 1 < imageList.Count)
            {
                currentImageIndex += 1;
            }
            else {
                currentImageIndex = 0;
            }
            ShowCurrentImage();
        }

        private void imagePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (imagePicturebox.Image != null) {
                isDrawing = true;

                previousPoint = e.Location;
            }
        }

        private void imagePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void imagePicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && imagePicturebox.Image != null) {
                Bitmap bitmap = new Bitmap(imagePicturebox.Image);

                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(currentPen, previousPoint.X, previousPoint.Y, e.X, e.Y);

                imagePicturebox.Image = bitmap;
                imageList[currentImageIndex] = bitmap;

                imagePicturebox.Invalidate();
                previousPoint = e.Location;
            }
        }

       

    }
}

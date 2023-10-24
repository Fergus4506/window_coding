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


        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e) { 
        
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
            imagePicturebox.Image = imageList[currentImageIndex];
        }

        private void filpHorizontalBtn_Click(object sender, EventArgs e)
        {

        }

        private void flipVerticalbtn_Click(object sender, EventArgs e)
        {

        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void previousImageBtn_Click(object sender, EventArgs e)
        {

        }

        private void nextImageBtn_Click(object sender, EventArgs e)
        {

        }

       

    }
}

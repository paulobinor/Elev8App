using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elev8App
{
    public partial class frmAddEditTrainer : Form
    {
        public frmAddEditTrainer()
        {
            InitializeComponent();
        }

        trainer trn = null;
        private void frmAddEditTrainer_Load(object sender, EventArgs e)
        {
            trn = (trainer)this.Tag;
            trainerBindingSource.DataSource = trn;
        }

       
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PictureBox pictureBox = GetPictureBox(openFileDialog1.FileName, pictureBox1.Height, pictureBox1.Width);
                pictureBox1.Image = pictureBox.Image;
                pictureBox1.ImageLocation = pictureBox.ImageLocation;
                ImageFile = ReadFile(pictureBox1.ImageLocation);
                //   groupControl2.Width = pictureUpload.Width + 6;
                //   groupControl2.Height = pictureUpload.Height + 19;
                trn.signature = ImageFile;
            }
        }
        private byte[] ReadFile(string imagePath)
        {
            byte[] data = null;

            //use fileInfo object to get file size
            FileInfo fileInfo = new FileInfo(imagePath);
            long numBytes = fileInfo.Length;

            //open FileStream to read file
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            //use binary reader to read file stream into byte array
            BinaryReader br = new BinaryReader(fs);

            //    br.ReadBytes(data.Length);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        byte[] ImageFile = null;
        public PictureBox GetPictureBox(string imageLocation, int frameHeight, int frameWidth)
        {
            Image image = Image.FromFile(imageLocation);
            PictureBox pb = new PictureBox();
            pb.ImageLocation = imageLocation;
            decimal originalImageHeight = image.Height;
            decimal originalImageWidth = image.Width;
            decimal finalImageHeight = 0;
            decimal finalImageWidth = 0;

            if (originalImageHeight >= originalImageWidth)
            {
                if (frameHeight >= originalImageWidth)
                {
                    finalImageHeight = originalImageHeight;
                    finalImageWidth = (finalImageHeight * originalImageWidth) / originalImageHeight;
                    pb.Image = (Image)(new Bitmap(image, (int)finalImageWidth, (int)finalImageHeight));
                    //   pictureBox2.Image = finalImage;
                }
                if (frameHeight < originalImageHeight)
                {
                    finalImageHeight = frameHeight;
                    finalImageWidth = (finalImageHeight * originalImageWidth) / originalImageHeight;
                    pb.Image = (Image)(new Bitmap(image, (int)finalImageWidth, (int)finalImageHeight));
                    //   pictureBox2.Image = finalImage;
                }
            }
            else
            {
                if (frameWidth >= originalImageWidth)
                {
                    finalImageWidth = originalImageWidth;
                    finalImageHeight = (finalImageWidth * originalImageHeight) / originalImageWidth;
                    pb.Image = (Image)(new Bitmap(image, (int)finalImageWidth, (int)finalImageHeight));
                    //   pictureBox2.Image = finalImage;
                }
                if (frameWidth < originalImageWidth)
                {
                    finalImageWidth = frameWidth;
                    finalImageHeight = (finalImageWidth * originalImageHeight) / originalImageWidth;
                    pb.Image = (Image)(new Bitmap(image, (int)finalImageWidth, (int)finalImageHeight));
                    //  pictureBox2.Image = finalImage;
                }
            }
            try
            {
                string imageFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" +
                   System.Windows.Forms.Application.ProductName + "\\Images\\" + System.Guid.NewGuid().ToString() + ".jpg";
                FileInfo imageFileInfo = new FileInfo(imageFilePath);
                if (!imageFileInfo.Directory.Exists)
                {
                    imageFileInfo.Directory.Create();
                }
                pb.Image.Save(imageFileInfo.FullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    ImageFile = ReadFile(imageFilePath);
                pb.ImageLocation = imageFilePath;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pb;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            trn.FirstName = firstNameTextBox.Text;
            trn.LastName = LastNameTextBox.Text;
            trn.email = emailTextBox.Text;
            trn.fullname = firstNameTextBox.Text + " " + LastNameTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}

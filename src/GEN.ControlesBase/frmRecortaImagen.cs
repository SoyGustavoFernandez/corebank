using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.Funciones;
using GEN.PrintHelper;

namespace GEN.ControlesBase
{
    public partial class frmRecortaImagen : frmBase
    {
        public Image imgARecortar=null;
        public Image imgRecortado=null;

        private Image _imgCopia;
        public Image imgCopia
        {
            get { return (Image)imgARecortar.Clone(); }
            set { _imgCopia = value; }
        }

        bool seleccionar = false;

        int cropX,cropY,cropWidth,cropHeight;
        Pen cropPen;
        private Size OriginalImageSize;

        public frmRecortaImagen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (imgARecortar==null)
            {
                MessageBox.Show("No hay imagen a ser recortada", "Recortar imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Dispose();
                return;
            }
            else
            {
                cargarImagen();
                seleccionar = true;
            }
            
        }

        private void cargarImagen()
        {
            int imgWidth = imgARecortar.Width;
            int imghieght = imgARecortar.Height;
            ptbImgCrop.Width = imgWidth;
            ptbImgCrop.Height = imghieght;
            ptbImgCrop.Image = imgARecortar;
            PictureBoxLocation();
            OriginalImageSize = new Size(imgWidth, imghieght);

        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {

           
        }

        private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (splImg.Panel1.Width > ptbImgCrop.Width)
            {
                _x = (splImg.Panel1.Width - ptbImgCrop.Width) / 2;
            }
            if (splImg.Panel1.Height > ptbImgCrop.Height)
            {
                _y = (splImg.Panel1.Height - ptbImgCrop.Height) / 2;
            }
            ptbImgCrop.Location = new Point(_x, _y);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            imgRecortado = this.ptbImgCrop.Image;
            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            imgRecortado = null;
            this.ptbImgCrop.Image = imgCopia;
            this.ptbImgCrop.Refresh();
        }

        private void ptbImgCrop_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (seleccionar)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Cursor = Cursors.Cross;
                    cropX = e.X;
                    cropY = e.Y;

                    cropPen = new Pen(Color.Black, 1);
                    cropPen.DashStyle = DashStyle.DashDotDot;
                }
                this.ptbImgCrop.Refresh();
                
            }
        }

        private void ptbImgCrop_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (seleccionar)
            {
                    if (ptbImgCrop.Image == null)
                        return;

                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        ptbImgCrop.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                        ptbImgCrop.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                    }
            }
        }

        private void ptbImgCrop_MouseUp(object sender, MouseEventArgs e)
        {
            if (seleccionar)
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCortar1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;


            if (cropWidth < 1)
            {
                return;
            }
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            //definiendo el rectangulo inicial
            Bitmap OriginalImage = new Bitmap(ptbImgCrop.Image, ptbImgCrop.Width, ptbImgCrop.Height);

            //imagen original
            Bitmap _img = new Bitmap(cropWidth, cropHeight);

            // define la clase grafics para la nueva imagen
            Graphics g = Graphics.FromImage(_img);
            // crea el grafico

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

            ptbImgCrop.Image = _img;
            ptbImgCrop.Width = _img.Width;
            ptbImgCrop.Height = _img.Height;
            PictureBoxLocation();
        }

       
    }
}

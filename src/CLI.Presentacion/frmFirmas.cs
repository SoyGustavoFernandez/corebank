using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CLI.Presentacion
{
    public partial class frmFirmas : frmBase
    {
        clslisFirma lisfirmas = new clslisFirma();
        clsCNFirmas cnfirmas = new clsCNFirmas();

        string cRutaArchivos = "";

        public frmFirmas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);

            ptbFirma.Size= new Size(clsVarApl.dicVarGen["nAnchoImgFirma"],clsVarApl.dicVarGen["nAltImgFirma"]);
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderdialog = new FolderBrowserDialog();           

            if (folderdialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                cRutaArchivos = folderdialog.SelectedPath + @"\";
                string [] listaArchivos= Directory.GetFiles(folderdialog.SelectedPath);

               
                this.lstClientes.Items.Clear();
                foreach (var item in listaArchivos)
                {
                    FileInfo info = new FileInfo(item);
                    if (info.Extension.ToLower().In(".jpg",".jpeg"))
                    {
                        clsFirma firma = new clsFirma();
                        firma.cFirma = item.Replace(cRutaArchivos, "");
                        firma.dFechaReg = clsVarGlobal.dFecSystem;
                        firma.idCli = Convert.ToInt32(firma.cFirma.Substring(6, 7));
                        firma.idEstado = 1;
                        firma.idUsuReg = clsVarGlobal.User.idUsuario;

                        firma.imgFirma = ResizeImage(Image.FromFile(item), clsVarApl.dicVarGen["nAnchoImgFirma"], clsVarApl.dicVarGen["nAltImgFirma"]);
                        lstClientes.Items.Add(firma);
                    }                    
                }
                if (lstClientes.Items.Count > 0)
                {
                    btnCargarFile1.Enabled = false;
                    btnProcesar1.Enabled = true;
                    btnQuitar1.Enabled = true;
                    btnEditar1.Enabled = true;
                }
                else
                {
                    btnProcesar1.Enabled = false;
                    btnQuitar1.Enabled = false;
                    btnEditar1.Enabled = false;
                }
                
            }
            else
            {
                cRutaArchivos = "";
                btnCargarFile1.Enabled = true;
                btnProcesar1.Enabled = false;
                btnQuitar1.Enabled = false;
                btnEditar1.Enabled = false;
                return;
            }            
        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClientes.Items.Count>0)
            {
                if (lstClientes.SelectedItem!=null)
                {
                    ptbFirma.Image = ((clsFirma)lstClientes.SelectedItem).imgFirma;
                    ptbFirma.Refresh();
                }                
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (lstClientes.Items.Count>0)
            {
                if (lstClientes.SelectedItem == null)
                {

                    MessageBox.Show("Debe seleccionar una imagen de la lista por favor", "Firmas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                return;
            }            

            frmRecortaImagen frmrecimg = new frmRecortaImagen();
            frmrecimg.imgARecortar = ((clsFirma)lstClientes.SelectedItem).imgFirma;
            frmrecimg.ShowDialog();            

            if (frmrecimg.imgRecortado==null)
            {
                ((clsFirma)lstClientes.SelectedItem).imgFirma = frmrecimg.imgCopia;
                ptbFirma.Image = frmrecimg.imgCopia;
                ptbFirma.Refresh();
            }
            else
            {
                ((clsFirma)lstClientes.SelectedItem).imgFirma = frmrecimg.imgRecortado;
                ptbFirma.Image = frmrecimg.imgRecortado;
                ptbFirma.Refresh();
            }            
        }

        public Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(Convert.ToInt32(srcImage.HorizontalResolution), Convert.ToInt32(srcImage.HorizontalResolution));
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();

                    System.Drawing.Imaging.Encoder encode = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters encodParametros = new EncoderParameters(1);
                    EncoderParameter ecndparam = new EncoderParameter(encode, 100L);
                    encodParametros.Param[0]=ecndparam;
                    ImageCodecInfo icodeinf = GetEncoderInfo("image/jpeg");

                    imagenBitmap.Save(imagenMemoryStream, icodeinf, encodParametros);

                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnCargarFile1.Enabled = true;
            btnProcesar1.Enabled = false;
            btnQuitar1.Enabled = false;
            btnEditar1.Enabled = false;
            this.lstClientes.Items.Clear();
            this.ptbFirma.Image = null;
            this.ptbFirma.Refresh();
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(0, 0, "Inicio-Registro de firmas del cliente", this.btnProcesar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            if (this.lstClientes.Items.Count>0)
            {
                foreach (var item in this.lstClientes.Items)
                {
                    cnfirmas.insertarFirma((clsFirma)item);
                }
                MessageBox.Show("La carga de firmas se completo satisfactoriamente", "Carga de firmas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar1.Enabled = false;
                btnCancelar1.Enabled = true;
                btnEditar1.Enabled = false;
                btnQuitar1.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("No hay firmas a procesar por favor verificar ", "Proceso de carga de firmas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(0, 0, "Fin-Registro de firmas del cliente", this.btnProcesar1);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (this.lstClientes.Items.Count > 0)
            {
                var item = lstClientes.SelectedItem;
                if (item != null)
	            {
                    ptbFirma.Image = null;
                    this.lstClientes.Items.Remove(item);
                    this.lstClientes.Refresh();
	            }              
                
            }
        }

       

        
    }
}

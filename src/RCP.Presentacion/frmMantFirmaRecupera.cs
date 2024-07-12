using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using RCP.CapaNegocio;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace RCP.Presentacion
{
    public partial class frmMantFirmaRecupera : frmBase
    {
        #region Variables
        //N-->nuevo
        //E-->Editar
        string cEvento = "";
        clsCNCartaRecupera firma = new clsCNCartaRecupera();

        #endregion

        public frmMantFirmaRecupera()
        {
            InitializeComponent();
        }
        
        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarFirma();
        }        

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            cEvento = "N";
            btnEditar.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarcontroles();
            habilitarcontroles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.cboFirmaRecupera.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = "E";
            btnEditar.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarcontroles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            limpiarcontroles();
            cargarFirmaRecupera();
            habilitarcontroles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string cmensaje = "";
                if (cEvento == "N")
                {

                    this.firma.InsertarFirmaRecupera(txtDescripcion.Text.Trim(), this.pbxFirma.Image, rbtActivo.Checked);

                    cmensaje = "Se registro correctamente los datos ingresado";
                }
                else
                {
                    this.firma.ActualizarFirmaRecupera(txtDescripcion.Text.Trim(), pbxFirma.Image, rbtActivo.Checked, Convert.ToInt32(cboFirmaRecupera.SelectedValue));
                    cmensaje = "Se actualizaron correctamente los datos ingresados";
                }

                MessageBox.Show(cmensaje, "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar.Enabled = true;
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                cargarFirma();
                cargarFirmaRecupera();
                habilitarcontroles(false);
            }
        }        

        private void cboFirmaRecupera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFirmaRecupera();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir imagen";
            fDialog.Filter = "Archivos Jpg|*.jpg";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cArcImg = fDialog.FileName;

                FileInfo info = new FileInfo(cArcImg);
                if (info.Extension.ToLower().In(".jpg", ".jpeg"))
                {
                    pbxFirma.Image = ResizeImage(Image.FromFile(cArcImg), 300, 150);
                    pbxFirma.Refresh();
                }
            }
        }

        #endregion

        #region Metodos

        private void cargarFirma()
        {
            var dtfirma = firma.ListarFirmaRecupera();
            if (dtfirma.Rows.Count > 0)
            {
                cboFirmaRecupera.DataSource = dtfirma;
                cboFirmaRecupera.ValueMember = dtfirma.Columns[0].ToString();
                cboFirmaRecupera.DisplayMember = dtfirma.Columns[1].ToString();
            }
        }

        private void limpiarcontroles()
        {
            txtDescripcion.Text = "";
            pbxFirma.Image = null;
            pbxFirma.Refresh();
        }

        private void habilitarcontroles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            cboFirmaRecupera.Enabled = !estado;
            btnBuscar.Enabled = estado;
        }

        private void cargarFirmaRecupera()
        {
            if (this.cboFirmaRecupera.Items.Count > 0)
            {
                var contacto = (DataRowView)cboFirmaRecupera.SelectedItem;

                txtDescripcion.Text = contacto["cFirmaRecupera"].ToString();
                if (Convert.ToBoolean(contacto["lVigente"]) == false)
                {
                    rbtnInactivo.Checked = true;
                    rbtActivo.Checked = false;
                }
                else
                {
                    rbtnInactivo.Checked = false;
                    rbtActivo.Checked = true;
                }

                Byte[] data = new Byte[0];
                data = (Byte[])(contacto["imgFirma"]);
                MemoryStream mem = new MemoryStream(data);
                pbxFirma.Image = Image.FromStream(mem);
                mem.Flush();
                mem.Close();
            }
        }        

        private Image ResizeImage(Image srcImage, int newWidth, int newHeight)
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
                    encodParametros.Param[0] = ecndparam;
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

        private bool validar()
        {
            bool lVal = false;

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor debe ingresar una descripción de la firma", "Validación firma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (pbxFirma.Image == null)
            {
                MessageBox.Show("Por favor debe seleccionar una imagen con la firma", "Validación firma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;

            return lVal;
        }

        #endregion
    }
}

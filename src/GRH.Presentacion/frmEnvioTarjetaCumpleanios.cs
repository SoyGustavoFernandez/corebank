#region Referencias
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
#endregion

namespace GRH.Presentacion
{
    public partial class frmEnvioTarjetaCumpleanios : frmBase
    {
        #region Variables Globales
        private string cNombrePlantilla = "Tarjeta de Cumpleaños";
        private string cRutaPlantilla = @"\plantillaCumpleaños.jpg";
        private string cRutaTarjeta = @"\TarjetaCumpleaños.jpg";
        private string cRutaCarpeta = @"\ImagenesTmp";
        private int nDias = 1;//dias antes cumpleaños
        private int nAncho = 2778;
        private int nAlto = 1389;
        private long nCalidad = 50L;
        private DateTime dFecha;
        private clsCNPersonal objCNPersonal;
        private clsCNPlantillaBinario objCNPlantillaBinario;
        private clsCNAprobacion objCNAprobacion;
        #endregion

        #region Metodos
        public frmEnvioTarjetaCumpleanios()
        {
            InitializeComponent();
            this.objCNPersonal = new clsCNPersonal();
            this.objCNPlantillaBinario = new clsCNPlantillaBinario();
            this.objCNAprobacion = new clsCNAprobacion();
            this.cRutaPlantilla = Directory.GetCurrentDirectory() + this.cRutaCarpeta + this.cRutaPlantilla;
            this.cRutaTarjeta = Directory.GetCurrentDirectory() + this.cRutaCarpeta + this.cRutaTarjeta;
            this.cRutaCarpeta = Directory.GetCurrentDirectory() + this.cRutaCarpeta;
            if (!Directory.Exists(cRutaCarpeta))
            {
                DirectoryInfo objInfo = Directory.CreateDirectory(cRutaCarpeta);
            }
        }

        private void iniciarFormulario()
        {
            this.dtpFecha.Enabled = false;
            this.btnCargarFile1.Enabled = false;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.btnEnviar1.Enabled = false;
            this.txtEmail.Enabled = false;
            this.dFecha = clsVarGlobal.dFecSystem.AddDays(nDias);
            this.dtpFecha.Value = dFecha;
            string cEmail = this.obtenerCorreoTTHH();
            this.txtEmail.Text = cEmail;
            this.obtenerPlantilla();
            this.obtenerListaPersonal();
        }

        private void obtenerListaPersonal()
        {
            this.dtgListaPersonal.Columns.Clear();
            DataTable dtListaPersonal = this.objCNPersonal.listarCumpleaPersonal(this.dFecha);
            if (dtListaPersonal.Rows.Count > 0)
            {
                this.dtgListaPersonal.DataSource = dtListaPersonal.DefaultView;
                for (int i = 0; i < this.dtgListaPersonal.ColumnCount; i++)
                {
                    this.dtgListaPersonal.Columns[i].Visible = false;
                }
                this.dtgListaPersonal.Columns["cApellidoPaterno"].HeaderText = "Paterno";
                this.dtgListaPersonal.Columns["cApellidoPaterno"].Visible = true;
                this.dtgListaPersonal.Columns["cApellidoMaterno"].HeaderText = "Materno";
                this.dtgListaPersonal.Columns["cApellidoMaterno"].Visible = true;
                this.dtgListaPersonal.Columns["cNombre"].HeaderText = "1er. Nombre";
                this.dtgListaPersonal.Columns["cNombre"].Visible = true;
                this.dtgListaPersonal.Columns["CNombreSeg"].HeaderText = "2do. Nombre";
                this.dtgListaPersonal.Columns["CNombreSeg"].Visible = true;
                this.dtgListaPersonal.Columns["cEmailInst"].HeaderText = "Correo";
                this.dtgListaPersonal.Columns["cEmailInst"].Visible = true;
                this.dtgListaPersonal.Columns["cGrupoCorreoB"].HeaderText = "Grupo";
                this.dtgListaPersonal.Columns["cGrupoCorreoB"].Visible = true;
                DataGridViewImageColumn objColumnaNueva = new DataGridViewImageColumn();
                objColumnaNueva.Name = "Enviado";
                objColumnaNueva.ValuesAreIcons = true;
                this.dtgListaPersonal.Columns.Add(objColumnaNueva);
                Image imgInicio = Properties.Resources.warning;
                Icon iconInicio= Icon.FromHandle(((Bitmap)imgInicio).GetHicon());
                this.dtgListaPersonal.Columns["Enviado"].DefaultCellStyle.NullValue = iconInicio;
                this.dtgListaPersonal.Columns["Enviado"].Width = 50;
                foreach (DataGridViewColumn objColumna in this.dtgListaPersonal.Columns)
                {
                    objColumna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                this.actualizarTarjeta();
            }
        }

        private void obtenerPlantilla()
        {
            if (File.Exists(this.cRutaPlantilla))
                File.Delete(this.cRutaPlantilla);
            if (File.Exists(this.cRutaTarjeta))
                File.Delete(this.cRutaTarjeta);
            DataTable dtPlantilla = this.objCNPlantillaBinario.obtenerPlantilla(cNombrePlantilla);
            if (dtPlantilla.Rows.Count > 0)
            {
                if (dtPlantilla.Rows[0]["bPlantillaBinario"] != DBNull.Value)
                {
                    byte[] bImagen = ((byte[])dtPlantilla.Rows[0]["bPlantillaBinario"]);
                    FileStream objFlujoImagen = new FileStream(this.cRutaPlantilla, FileMode.Create);
                    objFlujoImagen.Write(bImagen, 0, Convert.ToInt32(bImagen.Length));
                    objFlujoImagen.Close();
                }
            }
        }

        private void actualizarTarjeta()
        {
            this.pbxTarjeta.ImageLocation = null;
            if (this.dtgListaPersonal.Rows.Count > 0)
            {
                DataGridViewRow objFila = this.dtgListaPersonal.CurrentRow;
                if(objFila != null)
                    this.editarImagen(objFila.Cells["cNombre"].Value.ToString() + " " + objFila.Cells["CNombreSeg"].Value.ToString(), objFila.Cells["cApellidoPaterno"].Value.ToString() + " " + objFila.Cells["cApellidoMaterno"].Value.ToString(), dFecha.ToString("dd MMMM", new CultureInfo("es-ES")));
                else
                    this.editarImagen(this.dtgListaPersonal.Rows[0].Cells["cNombre"].Value.ToString() + " " + this.dtgListaPersonal.Rows[0].Cells["CNombreSeg"].Value.ToString(), this.dtgListaPersonal.Rows[0].Cells["cApellidoPaterno"].Value.ToString() + " " + this.dtgListaPersonal.Rows[0].Cells["cApellidoMaterno"].Value.ToString(), dFecha.ToString("dd MMMM", new CultureInfo("es-ES")));
            }
            else
            {
                this.editarImagen("Nombre Nombres", "Apellido Apellidos", dFecha.ToString("dd MMMM", new CultureInfo("es-ES")));
            }
            if (File.Exists(this.cRutaTarjeta))
                this.pbxTarjeta.ImageLocation = cRutaTarjeta;
        }

        private string MayusculizarTexto(string cText)
        {
            TextInfo objTmp = CultureInfo.CurrentCulture.TextInfo;
            cText = cText.ToLower().Trim();
            string[] aTexto = cText.Split(' ');
            for (int i = 0; i < aTexto.Length; i++)
            {
                if (aTexto[i].Length > 2)
                {
                    aTexto[i] = objTmp.ToTitleCase(aTexto[i]);
                }
            }
            return string.Join(" ", aTexto);
        }

        private void editarImagen(string cNombres, string cApellidos, string cDiaMes)
        {
            if (File.Exists(cRutaPlantilla))
            {
                using (Image objPlantilla = Image.FromFile(cRutaPlantilla))
                {
                    using (Graphics objPaletaPlantilla = Graphics.FromImage(objPlantilla))
                    {
                        byte[] bFont1;
                        using (MemoryStream msFont1 = new MemoryStream(Properties.Resources.HapticPro_Black))
                        {
                            bFont1 = msFont1.ToArray();
                        }
                        PrivateFontCollection pfcFont1 = new PrivateFontCollection();
                        IntPtr ipFont1 = Marshal.AllocCoTaskMem(bFont1.Length);
                        Marshal.Copy(bFont1, 0, ipFont1, bFont1.Length);
                        pfcFont1.AddMemoryFont(ipFont1, bFont1.Length);
                        FontFamily ffFront1 = pfcFont1.Families[0];


                        byte[] bFont2;
                        using (MemoryStream msFont2 = new MemoryStream(Properties.Resources.HapticPro_Regular))
                        {
                            bFont2 = msFont2.ToArray();
                        }
                        PrivateFontCollection pfcFont2 = new PrivateFontCollection();
                        IntPtr ipFont2 = Marshal.AllocCoTaskMem(bFont2.Length);
                        Marshal.Copy(bFont2, 0, ipFont2, bFont2.Length);
                        pfcFont2.AddMemoryFont(ipFont2, bFont2.Length);
                        FontFamily ffFront2 = pfcFont2.Families[0];

                        cNombres = MayusculizarTexto(cNombres);
                        cApellidos = MayusculizarTexto(cApellidos);

                        Color objColor1 = ColorTranslator.FromHtml("#FF287A");
                        Color objColor2 = ColorTranslator.FromHtml("#FF287A");
                        Font objEstilo1 = new Font(ffFront1, 100, FontStyle.Bold);
                        Font objEstilo2 = new Font(ffFront2, 70, FontStyle.Bold);

                        SizeF objMedidaNombre = objPaletaPlantilla.MeasureString(cNombres, objEstilo1);
                        objPaletaPlantilla.DrawString(cNombres, objEstilo1, new SolidBrush(objColor1), new Point(1000 - (int)(objMedidaNombre.Width / 2), 650));
                        SizeF objMedidaApellidos = objPaletaPlantilla.MeasureString(cApellidos, objEstilo1);
                        objPaletaPlantilla.DrawString(cApellidos, objEstilo1, new SolidBrush(objColor1), new Point(1000 - (int)(objMedidaApellidos.Width / 2), 800));
                        SizeF objMedidaMesDia = objPaletaPlantilla.MeasureString(cDiaMes, objEstilo2);
                        objPaletaPlantilla.DrawString(cDiaMes, objEstilo2, new SolidBrush(objColor2), new Point(1000 - (int)(objMedidaMesDia.Width / 2), 950));

                        EncoderParameters objParametros = new EncoderParameters(1);
                        objParametros.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, nCalidad);
                        objPlantilla.Save(cRutaTarjeta, obtenerCodificador(ImageFormat.Jpeg), objParametros);
                    }
                }
            }
        }

        private void enviarMasivoEmail()
        {
            int nContador = 0;
            string cTitulo = "Envío Masivo de Tarjetas";
            if (this.dtgListaPersonal.Rows.Count == 0)
            {
                MessageBox.Show("La lista de personal que cumplen años en la fecha específica está vacía.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea enviar los correos de feliz cumpleaños a toda la lista?", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow objFila in this.dtgListaPersonal.Rows)
                {
                    Image imgCarga = Properties.Resources.loading;
                    Icon iconCarga = Icon.FromHandle(((Bitmap)imgCarga).GetHicon());
                    objFila.Cells["Enviado"].Value = iconCarga;
                    this.editarImagen(objFila.Cells["cNombre"].Value.ToString() + " " + objFila.Cells["CNombreSeg"].Value.ToString(), objFila.Cells["cApellidoPaterno"].Value.ToString() + " " + objFila.Cells["cApellidoMaterno"].Value.ToString(), dFecha.ToString("dd MMMM", new CultureInfo("es-ES")));
                    this.pbxTarjeta.ImageLocation = cRutaTarjeta;
                    List<string> lstCorreoDestino = new List<string>();
                    if (objFila.Cells["cEmailInst"].Value.ToString().Trim() != "")
                        lstCorreoDestino.Add(objFila.Cells["cEmailInst"].Value.ToString());
                    if (objFila.Cells["cGrupoCorreoB"].Value.ToString().Trim() != "")
                    {
                        string[] aCorreos = objFila.Cells["cGrupoCorreoB"].Value.ToString().Split(';');
                        foreach (string cCorreo in aCorreos)
                        {
                            if (cCorreo.Trim() != "")
                            {
                                lstCorreoDestino.Add(cCorreo);
                            }
                        }
                    }
                    if (this.enviarMensaje(lstCorreoDestino, "¡FELIZ CUMPLEAÑOS " + objFila.Cells["cNombre"].Value.ToString() + " " + objFila.Cells["cApellidoPaterno"].Value.ToString() + "!", "<img src=\"cid:imagen\" />", cRutaTarjeta))
                    {
                        Image imgSi= Properties.Resources.success;
                        Icon iconSi= Icon.FromHandle(((Bitmap)imgSi).GetHicon());
                        objFila.Cells["Enviado"].Value = iconSi;
                        objFila.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d4edda");
                        objFila.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                    }
                    else
                    {
                        Image imgNo= Properties.Resources.delete;
                        Icon iconNo= Icon.FromHandle(((Bitmap)imgNo).GetHicon());
                        objFila.Cells["Enviado"].Value = iconNo;
                        objFila.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8d7da");
                        objFila.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#721c24");
                        nContador++;
                    }
                }
                if (nContador > 0)
                    MessageBox.Show("Los correos de feliz cumpleaños fueron enviados con el siguiente detalle:\n" + nContador + " no enviados", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Los correos de feliz cumpleaños fueron enviados a toda la lista.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool enviarMensaje(List<string> lstCorreoDestino, string cAsuntoMensaje, string cCuerpoMensaje, string cAdjunto)
        {
            try
            {
                if (lstCorreoDestino.Count > 0)
                {
                    string cSmtpCliente = "mail.cajalosandes.pe";
                    string cCorreoEnvio = this.txtEmail.Text.Trim();
                    string cCorreoNombre = "TALENTO HUMANO";
                    string cClave = this.txtClave.Text.Trim();
                    int nPuertoSmtp = clsVarApl.dicVarGen["nPuertoSmtpCliente"];
                    using (SmtpClient objSmtpCliente = new SmtpClient(cSmtpCliente, nPuertoSmtp))
                    {
                        NetworkCredential objCredenciales = new NetworkCredential(cCorreoEnvio, cClave);
                        objSmtpCliente.UseDefaultCredentials = false;
                        objSmtpCliente.Credentials = objCredenciales;
                        using (MailMessage objMensaje = new MailMessage())
                        {
                            MailAddress objCorreoOrigen = new MailAddress(cCorreoEnvio, cCorreoNombre);
                            objMensaje.From = objCorreoOrigen;
                            cCuerpoMensaje = cCuerpoMensaje + "</br></br>";
                            foreach (string cCorreo in lstCorreoDestino)
                            {
                                objMensaje.To.Add(new MailAddress(cCorreo));
                            }
                            objMensaje.Priority = MailPriority.Normal;
                            objMensaje.Subject = cAsuntoMensaje;
                            objMensaje.SubjectEncoding = Encoding.UTF8;
                            objMensaje.IsBodyHtml = true;
                            AlternateView objHtmlCuerpo = AlternateView.CreateAlternateViewFromString(cCuerpoMensaje, Encoding.UTF8, MediaTypeNames.Text.Html);
                            LinkedResource objVincularImagen = new LinkedResource(cAdjunto, MediaTypeNames.Image.Jpeg);
                            objVincularImagen.ContentId = "imagen";
                            objHtmlCuerpo.LinkedResources.Add(objVincularImagen);
                            objMensaje.AlternateViews.Add(objHtmlCuerpo);
                            objSmtpCliente.Send(objMensaje);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private ImageCodecInfo obtenerCodificador(ImageFormat objFormato)
        {
            ImageCodecInfo[] aCodecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo objCodec in aCodecs)
            {
                if (objCodec.FormatID == objFormato.Guid)
                {
                    return objCodec;
                }
            }
            return null;
        }

        private string obtenerCorreoTTHH()
        {
            DataTable dtVariable = objCNAprobacion.CNExtractTipoVariable("cCorreoTTHH");
            if (dtVariable.Rows.Count > 0)
                return dtVariable.Rows[0]["cValVar"].ToString();
            return null;
        }

        private bool validarCorreoClaveDA()
        {
            bool lValido = false;
            string cDominioDA = "cajalosandes.pe";
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match matchEmail = regexEmail.Match(this.txtEmail.Text.Trim());
            if (!matchEmail.Success)
            {
                return false;
            }
            else if (this.txtClave.Text.Trim().Length < 5)
            {
                return false;
            }
            using (PrincipalContext objContexto = new PrincipalContext(ContextType.Domain, cDominioDA))
            {
                bool isValid = objContexto.ValidateCredentials(this.txtEmail.Text.Trim(), this.txtClave.Text.Trim());
                if (isValid)
                {
                    lValido = true;
                }
                else
                {
                    lValido = false;
                }
            }
            return lValido;
        }
        #endregion

        #region Eventos
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            this.btnEnviar1.Enabled = false;
            this.btnEditar1.Enabled = false;
            this.enviarMasivoEmail();
            this.btnEnviar1.Enabled = true;
            this.btnEditar1.Enabled = true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.btnCargarFile1.Enabled = true;
            this.btnGrabar1.Enabled = true;
            this.btnCancelar1.Enabled = true;
            this.btnEnviar1.Enabled = false;
            this.btnEditar1.Enabled = false;
            this.btnValidar1.Enabled = false;
            this.dtpFecha.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtClave.Enabled = true;
            this.btnMiniVer.Enabled = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.btnGrabar1.Enabled = false;
            if(File.Exists(cRutaPlantilla))
            {
                FileInfo objInfo = new FileInfo(cRutaPlantilla);
                long nCantidadBytes = objInfo.Length;
                FileStream objImagen = new FileStream(cRutaPlantilla, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(objImagen);
                byte[] bImagen = br.ReadBytes((int)nCantidadBytes);
                objImagen.Flush();
                objImagen.Close();
                br.Close();
                this.objCNPlantillaBinario.registrarPlantilla(cNombrePlantilla, bImagen, 1, true);
            }
            this.dFecha = dtpFecha.Value;
            this.obtenerPlantilla();
            this.obtenerListaPersonal();
            this.btnCargarFile1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.btnEditar1.Enabled = true;
            this.btnValidar1.Enabled = true;
            this.dtpFecha.Enabled = false;
            this.txtEmail.Enabled = false;
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            this.btnCargarFile1.Enabled = false;
            if (File.Exists(this.cRutaPlantilla))
                File.Delete(this.cRutaPlantilla);
            if (File.Exists(this.cRutaTarjeta))
                File.Delete(this.cRutaTarjeta);
            OpenFileDialog objDialogo = new OpenFileDialog();
            objDialogo.Title = "Abrir Imagen";
            objDialogo.Multiselect = false;
            objDialogo.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (objDialogo.ShowDialog() == DialogResult.OK)
            {
                FileInfo objInfo = new FileInfo(objDialogo.FileName);
                if (objInfo.Length > clsVarApl.dicVarGen["cMaxFile"])
                {
                    MessageBox.Show("El archivo es de " + objInfo.Length + " bytes, excedió el límite máximo del tamaño, límite máximo para el archivo es " + clsVarApl.dicVarGen["cMaxFile"] + " bytes", "Abrir Imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (Image objImagenOrigen = Bitmap.FromFile(objDialogo.FileName))
                    {
                        using (Image objImagenDestino = new Bitmap(objImagenOrigen, nAncho, nAlto))
                        {
                            EncoderParameters objParametros = new EncoderParameters(1);
                            objParametros.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, nCalidad);
                            objImagenDestino.Save(cRutaPlantilla, obtenerCodificador(ImageFormat.Jpeg), objParametros);
                        }
                    }
                    this.actualizarTarjeta();
                }
            }
            this.btnCargarFile1.Enabled = true;
        }

        private void dtgBase1_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarTarjeta();
        }
        
        private void btnValidar1_Click(object sender, EventArgs e)
        {
            this.btnValidar1.Enabled = false;
            string cTitulo = "Correo de Validación";
            if (!File.Exists(cRutaTarjeta))
            {
                MessageBox.Show("Necesita subir una imagen de plantilla antes de enviar el correo de validación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.validarCorreoClaveDA())
            {
                MessageBox.Show("Correo y/o contraseña incorrectas.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Enabled = true;
                this.btnMiniVer.Enabled = true;
                this.txtEmail.Enabled = true;
            }
            else if (MessageBox.Show("¿Desea enviar el correo de validación?\nSerá enviado a: " + this.txtEmail.Text.Trim(), cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> lstCorreoDestino = new List<string>();
                lstCorreoDestino.Add(this.txtEmail.Text.Trim());

                if (enviarMensaje(lstCorreoDestino, "Correo de Validación - Tarjeta de Cumpleaños", "<img src=\"cid:imagen\" />", cRutaTarjeta))
                {
                    MessageBox.Show("El correo de validación se envió correctamente a:\n" + this.txtEmail.Text.Trim() + ",\nPara continuar con el envío de Tarjetas de Cumpleaños \nrevise que le haya llegado el correo de validación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtClave.Enabled = false;
                    this.btnMiniVer.Enabled = false;
                    this.txtEmail.Enabled = false; 
                    this.btnEnviar1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo enviar el correo de validación por el siguiente motivo:\n* Correo y/o contraseña incorrectas.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtClave.Enabled = true;
                    this.btnMiniVer.Enabled = true;
                    this.txtEmail.Enabled = true;
                    this.btnEnviar1.Enabled = false;
                }
            }
            this.btnValidar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtpFecha.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtClave.Enabled = true;
            this.btnMiniVer.Enabled = true;
            this.dtpFecha.Value = dFecha;
            this.iniciarFormulario();
            this.btnEditar1.Enabled = true;
            this.btnValidar1.Enabled = true;
            this.btnEnviar1.Enabled = false;
            this.btnCargarFile1.Enabled = false;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (clsVarGlobal.dFecSystem.AddDays(-3) > this.dtpFecha.Value || this.dtpFecha.Value > clsVarGlobal.dFecSystem.AddDays(5))
            {
                MessageBox.Show("Las tarjetas de cumpleaños se pueden enviar con un atraso de 3 días y un adelanto de 5 días a la fecha actual. Seleccione una fecha válida dentro de este rango.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtpFecha.Value = clsVarGlobal.dFecSystem;
            }
        }

        private void frmEnvioTarjetaCumpleanios_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            this.iniciarFormulario();
        }

        private void btnMiniVer_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtClave.PasswordChar = '\0';
        }

        private void btnMiniVer_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtClave.PasswordChar = '*';
        }
        #endregion
    }
}

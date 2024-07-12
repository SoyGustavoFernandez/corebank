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
using System.IO;
using GEN.Funciones;
using GEN.CapaNegocio;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Runtime.Serialization.Json;

namespace CLI.Servicio
{
    public partial class frmMensajeSustento : Form
    {
        #region Variables globales
        private int idBiometriaExcep;
        private string cMensaje;
        private bool lAcepta = false;
        private DataTable dtMotivo;
        private byte[] bArchivo;
        private string cNombreDocumento;
        private string cExtencion;
        private int idMotivo;
        private string cMotivo;

        private List<clsUsuAprobBiometrico> lstUsuAprobBiometrico { get; set; }
        private clsConfigBiometricoAutorizacion objConfigbioAutorizacion { get; set; }

        private int idTipoArchivo { get; set; }
        private bool lDerivacionDirecta { get; set; }
        private BindingSource bsPersonalAprobacion { get; set; }
        public int idTipoOperacion { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idMoneda { get; set; }
        public Image objImage { get; set; }
        public string cDocumentoID { get; set; }

        public string cDocAutorizado { get; set; }
        public clsProcesaDatosRen objProcesaDatosRen { get; set; }
        public string cIdModulo { get; set; }
        public string cIdUsuario { get; set; }
        #endregion

        #region Constructor
        public frmMensajeSustento()
        {
            InitializeComponent();

            visualizarPDF();
            cargarComponentes();

        }

        public frmMensajeSustento(int _idBiometriaExcep)
        {
            InitializeComponent();
            this.idBiometriaExcep = _idBiometriaExcep;
            btnCargarFile1.Enabled = false;
        }
        #endregion

        #region Metodos
        public void iniciarMensaje(DataTable _dt)
        {
            this.dtMotivo = _dt;
            comboBox1.ValueMember = "idMotivoBiometriaExcep";
            comboBox1.DisplayMember = "cMotivoBiometriaExcep";
            comboBox1.DataSource = this.dtMotivo;

            comboBox1.SelectedIndex = -1;
        }

        public string getMensaje()
        {
            return cMensaje;
        }

        public string getNombreArchivo()
        {
            return (String.IsNullOrWhiteSpace(this.cNombreDocumento)) ? String.Empty : this.cNombreDocumento;
        }

        public byte[] getArchivo()
        {
            return (this.bArchivo == null) ? new byte[] { 0x20 } : this.bArchivo ;
        }

        public string getExtencion()
        {
            return (String.IsNullOrWhiteSpace(this.cExtencion)) ? String.Empty : this.cExtencion;
        }

        public int getIdMotivo()
        {
            return this.idMotivo;
        }

        public string getMotivo()
        {
            return this.cMotivo;
        }

        public bool obtenerAceptacion()
        {
            return this.lAcepta;
        }

        public List<clsUsuAprobBiometrico> obtenerUsuariosVerificadores()
        {
            return this.lstUsuAprobBiometrico;
        }

        public string obtenerXMLUsuariosVerificadores()
        {
            return this.lstUsuAprobBiometrico.GetXml();
        }

        public int obtenerTipoArchivo()
        {
            return this.idTipoArchivo;
        }

        public bool obtenerDerivacionDirecta()
        {
            return this.lDerivacionDirecta;
        }

        public bool validar()
        {
            if (Convert.ToInt32(this.comboBox1.SelectedIndex) == -1)
            {
                MessageBox.Show("Seleccione un motivo de excepción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MessageBox.Show("Ingrese sustento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lstUsuAprobBiometrico.Count <= objConfigbioAutorizacion.nMinimoAprobadores)
            {
                MessageBox.Show("Necesita por lo menos " + Convert.ToString(objConfigbioAutorizacion.nMinimoAprobadores)+ ((objConfigbioAutorizacion.nMinimoAprobadores == 1) ? " aprobador" : " aprobadores")  +", para registrar la excepción excepción biométrica.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.cNombreDocumento) && nMontoOperacion > objConfigbioAutorizacion.nMontoUmbral)
            {
                MessageBox.Show("No se ha cargado el documento o imagen de sustento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.cMensaje = txtSustento.Text;
            this.idMotivo = Convert.ToInt32(comboBox1.SelectedValue);
            this.cMotivo = comboBox1.Text;

            return true;
        }

        private void visualizarPDF()
        {
            if (string.IsNullOrEmpty(lblDocumento.Text))
            {
                btnExporPdf1.Visible = false;
                btnImagen.Visible = false;
            }
            else
            {
                btnExporPdf1.Visible = true;
                btnImagen.Visible = false;
            }
        }

        private void visualizarImagen()
        {
            if(String.IsNullOrWhiteSpace(lblDocumento.Text))
            {
                btnImagen.Visible = false;
                btnExporPdf1.Visible = false;
            }
            else
            {
                btnImagen.Visible = true;
                btnExporPdf1.Visible = false;
            }
        }

        private void cargaDatos()
        {
            clsCNAprobacion oApro = new clsCNAprobacion();

            DataTable dt = oApro.CNObtenerExcepcionBiometrica(this.idBiometriaExcep);

            this.cNombreDocumento = Convert.ToString(dt.Rows[0]["cNombreArchivo"]);
            this.cMensaje = Convert.ToString(dt.Rows[0]["cBiometriaExcep"]);
            this.cExtencion = Convert.ToString(dt.Rows[0]["cExtencion"]);
            this.bArchivo = (byte[])dt.Rows[0]["bArchivo"];
            this.idMotivo = Convert.ToInt32(dt.Rows[0]["idMotivoBiometriaExcep"]);

            comboBox1.SelectedValue = this.idMotivo;
            txtSustento.Text = cMensaje;
            lblDocumento.Text = cNombreDocumento;

        }

        private void cargarComponentes()
        {
            this.lstUsuAprobBiometrico = new List<clsUsuAprobBiometrico>();
            this.bsPersonalAprobacion = new BindingSource();
            this.bsPersonalAprobacion.DataSource = this.lstUsuAprobBiometrico;
            this.dtgPersonalAprobacion.DataSource = this.bsPersonalAprobacion;
            
            idTipoArchivo = 0;
            lDerivacionDirecta = false;
            objConfigbioAutorizacion = new clsConfigBiometricoAutorizacion();

            this.cDocAutorizado = String.Empty;
            this.objProcesaDatosRen = new clsProcesaDatosRen();
            this.cIdModulo = clsVarGlobal.idModulo.ToString().Trim();
            cIdUsuario = clsVarGlobal.User.idUsuario.ToString().Trim();
            ObtenerDniAut();

            formatearGridPersonalAprobacion();
        }

        private void formatearGridPersonalAprobacion()
        {
            this.dtgPersonalAprobacion.AllowUserToAddRows = false;
            this.dtgPersonalAprobacion.AllowUserToDeleteRows = false;
            this.dtgPersonalAprobacion.AllowUserToResizeRows = false;
            this.dtgPersonalAprobacion.MultiSelect = false;
            this.dtgPersonalAprobacion.ReadOnly = true;
            this.dtgPersonalAprobacion.RowHeadersVisible = false;
            this.dtgPersonalAprobacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPersonalAprobacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPersonalAprobacion.AllowUserToResizeColumns = false;
            this.dtgPersonalAprobacion.AllowUserToResizeRows = false;

            foreach(DataGridViewColumn columna in dtgPersonalAprobacion.Columns)
            {
                columna.Visible = false;
                columna.HeaderText = columna.Name;
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgPersonalAprobacion.Columns["cDocumentoID"].Visible = true;
            this.dtgPersonalAprobacion.Columns["cNombres"].Visible = true;
            this.dtgPersonalAprobacion.Columns["cPerfil"].Visible = true;
            this.dtgPersonalAprobacion.Columns["lConfirmaAprobacion"].Visible = true;

            this.dtgPersonalAprobacion.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            this.dtgPersonalAprobacion.Columns["cNombres"].HeaderText = "Nombres";
            this.dtgPersonalAprobacion.Columns["cPerfil"].HeaderText = "Perfil";
            this.dtgPersonalAprobacion.Columns["lConfirmaAprobacion"].HeaderText = "Verificado";

        }

        private bool autenticarPersonalSolicitud()
        {
            bool lValidaUsuario = false;

            frmCredencialesBiometrico frmCredencialBiometrico = new frmCredencialesBiometrico(clsVarGlobal.User.lAutBiometricaAgencia);
            frmCredencialBiometrico.cWinUser = clsVarGlobal.User.cWinUser;
            frmCredencialBiometrico.cMensaje = "He validado plenamente la identidad del cliente bajo responsabilidad, autorizo la presente operación.";
            frmCredencialBiometrico.lMostrarMensaje = true;
            frmCredencialBiometrico.ShowDialog();

            clsUsuAprobBiometrico objUsuarioSolicitud = new clsUsuAprobBiometrico();

            clsCNAprobacion objAprobacion = new clsCNAprobacion();
            lValidaUsuario = frmCredencialBiometrico.lValido;
            if (lValidaUsuario)
            {
                objUsuarioSolicitud = objAprobacion.CNObtenerUsuarioAutBiometrico(clsVarGlobal.User.idCli);
                objUsuarioSolicitud.lConfirmaAprobacion = true;
                lstUsuAprobBiometrico.Add(objUsuarioSolicitud);
                bsPersonalAprobacion.ResetBindings(true);

                objConfigbioAutorizacion = objAprobacion.CNObtenerConfigBioAutorizacion(clsVarGlobal.nIdAgencia, clsVarGlobal.User.idEstablecimiento, idTipoOperacion, idMoneda);
            }

            return lValidaUsuario;
        }

        #endregion

        #region Evento
        private void frmMensajeSustento_Load(object sender, EventArgs e)
        {
            if (!autenticarPersonalSolicitud())
            {
                MessageBox.Show("No se logro autenticar el usuario para la solicitud de Excepcion.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            if (nMontoOperacion > objConfigbioAutorizacion.nMontoUmbral)
            {
                chcDerivacionDirecta.Checked = true;
                chcDerivacionDirecta.Enabled = false;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            this.lAcepta = true;

            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro de cancelar la solicitud de excepción biométrica?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
            {
                return;
            }

            this.Dispose();
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;
            fDialog.Filter = "PDF Documents|*.pdf";

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(fDialog.FileName);
                long fileSize = fi.Length;
                int maxSize = clsVarApl.dicVarGen["cMaxFile"];
                if (fileSize > maxSize)
                {
                    MessageBox.Show("El archivo es de " + fileSize + "bytes, excedió el límite de subida de archivos, máximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.bArchivo = null;
                    cNombreDocumento = "";
                    cExtencion = "";
                    lblDocumento.Text = "";
                }
                else
                {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    string nameFile = cArchivo;
                    string cDocumentoSesion = fInfo.Name;
                    byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                    string cExtension = fInfo.Extension;
                    fStream.Flush();
                    fStream.Close();
                    br.Close();
                    this.bArchivo = Compresion.CompressedByte(vDocumentoSesion);
                    cNombreDocumento = cDocumentoSesion;
                    cExtencion = cExtension;
                    lblDocumento.Text = cDocumentoSesion;
                    idTipoArchivo = 3;
                }

            }
            else
            {
                this.bArchivo = null;
                cNombreDocumento = "";
                cExtencion = "";
                lblDocumento.Text = "";
            }
            visualizarPDF();

        }

        private void btnExporPdf1_Click(object sender, EventArgs e)
        {
            frmDisplayPDF oFrm = new frmDisplayPDF(this.cNombreDocumento, this.cExtencion, Compresion.DescompressedByte(this.bArchivo));
            oFrm.ShowDialog();

        }

        private void chcDerivacionDirecta_CheckedChanged(object sender, EventArgs e)
        {
            lDerivacionDirecta = (chcDerivacionDirecta.Checked) ? true : false;
        }

        private void btnMiniAgregarPersonal_Click(object sender, EventArgs e)
        {
            frmBusUsuarioAprobacion frmAgregarUsuario = new frmBusUsuarioAprobacion();
            frmAgregarUsuario.idAgencia = clsVarGlobal.nIdAgencia;
            frmAgregarUsuario.idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            frmAgregarUsuario.idTipoOperacion = idTipoOperacion;
            frmAgregarUsuario.ShowDialog();

            if (frmAgregarUsuario.objUsuSeleccionado.idUsuario == 0) return;

            clsUsuAprobBiometrico objNuevoUsuario = frmAgregarUsuario.objUsuSeleccionado;

            if (this.lstUsuAprobBiometrico.Any(item => item.idUsuario == objNuevoUsuario.idUsuario))
            {
                MessageBox.Show("El colaborador ya se registro su aprobacion de la solicitud.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objNuevoUsuario.lConfirmaAprobacion = true;
            lstUsuAprobBiometrico.Add(objNuevoUsuario);

            bsPersonalAprobacion.ResetBindings(true);

        }

        private void btnMiniQuitarPersonal_Click(object sender, EventArgs e)
        {
            clsUsuAprobBiometrico objUsuarioSeleccionado = new clsUsuAprobBiometrico();

            if (dtgPersonalAprobacion.SelectedRows.Count == 0) return;

            objUsuarioSeleccionado = (clsUsuAprobBiometrico)dtgPersonalAprobacion.SelectedRows[0].DataBoundItem;

            if (objUsuarioSeleccionado.idUsuario == clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("La Solicitud de excepcion requiere de la aprobacion del usuario que la genera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstUsuAprobBiometrico.Remove(objUsuarioSeleccionado);
            bsPersonalAprobacion.ResetBindings(true);
        }
        
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir Imagen";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;
            fDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(fDialog.FileName);
                long fileSize = fi.Length;
                int maxSize = clsVarApl.dicVarGen["cMaxFile"];
                if (fileSize > maxSize)
                {
                    MessageBox.Show("El archivo es de " + fileSize + "bytes, excedió el límite de subida de archivos, máximo de " + maxSize + " bytes", "Adjuntar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.bArchivo = null;
                    cNombreDocumento = String.Empty;
                    cExtencion = String.Empty;
                }
                else
                {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    string nameFile = cArchivo;
                    string cImagenSesion = fInfo.Name;
                    byte[] vImagenSesion = br.ReadBytes((int)numBytes);
                    string cExtensionImg = fInfo.Extension;
                    objImage = Image.FromFile(nameFile);
                    fStream.Flush();
                    fStream.Close();
                    br.Close();
                    this.bArchivo = Compresion.CompressedByte(vImagenSesion);
                    cNombreDocumento = cImagenSesion;
                    cExtencion = cExtensionImg;
                    lblDocumento.Text = cImagenSesion;
                    idTipoArchivo = 1;
                }
            }
            else
            {
                this.bArchivo = null;
                cNombreDocumento = String.Empty;
                cExtencion = String.Empty;
            }
            visualizarImagen();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            frmMostrarImagen frmImagen = new frmMostrarImagen(this.cNombreDocumento, this.cExtencion, Compresion.DescompressedByte(this.bArchivo));
            frmImagen.ShowDialog();
        }

        private void btnConsultaReniec_Click(object sender, EventArgs e)
        {

            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string dFecOpe = clsVarGlobal.dFecSystem.ToString();
            string cTitulo = "CONSULTA DNI RENIEC";


            if (!GetReniec(this.cDocumentoID))
            {
                DataTable dtBusLog = new clsCNConsultaDatos().CNBuscaLog(this.cDocumentoID);
                if (dtBusLog.Rows.Count > 0)
                {
                    string cErrorLog = dtBusLog.Rows[0]["cError"].ToString();
                    string cDescripcion = dtBusLog.Rows[0]["cDescripcion"].ToString();

                    MessageBox.Show("No se obtuvo la consulta debido a:  " + cErrorLog + " - " + cDescripcion, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("No se obtuvo la consulta.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return;
            }

            clsCNConsultaDatos ConsultaDatos = new clsCNConsultaDatos();

            DataTable dtData = ConsultaDatos.CNConsultaDatosReporte(this.cDocumentoID);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("DataSet1", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cDocumentoID", this.cDocumentoID.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe, false));

                string reportPath = "rptConsultaReniec.rdlc";
                new frmReporteServicio(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta Consulta.", cTitulo + "- REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool GetReniec(string cNroDni)
        {
            string dicto = "{\"cNroDni\":\"" + cNroDni + "\",\"cDocAutorizado\":\"" + cDocAutorizado + "\",\"cIdUsu\":\"" + cIdUsuario + "\"}";

            string cServicio = clsVarApl.dicVarGen["cServicioWCFRen"];

            byte[] bBytes = Encoding.ASCII.GetBytes(dicto);
            byte[] response;

            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            string serviceURL = string.Format(cServicio + "/ConsultaIndInfPerReniec", dicto);

            try
            {
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                Stream stream = new MemoryStream(response);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                clsProcesaDatosRen resultPersona = obj.ReadObject(stream) as clsProcesaDatosRen;
                objProcesaDatosRen = resultPersona;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void ObtenerDniAut()
        {
            clsCNConsultaDatos objConsultaDNI = new clsCNConsultaDatos();
            DataTable dtDniAut = objConsultaDNI.CNConsultaDatosDniAut(Convert.ToInt32(this.cIdModulo));
            cDocAutorizado =Convert.ToString(dtDniAut.Rows[0]["cDocumentoID"]);
        }
        #endregion
    }
}

#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using GEN.Funciones;

using EntityLayer;
using System.IO;
using SER.CapaNegocio;
using GEN.BotonesBase;
using CLI.Servicio;
# endregion


namespace SER.Presentacion
{
    public partial class frmSolDesbloqGiro : frmBase
    {
        #region Variables 
        public int idServicioGiro { get; set; }
        public int idEstadoSol { get; set; }
        public int idSolAproba { get; set; }
        public int idProducto { get; set; }

        public bool lEditable { get; set; }

        private int idTipoArchivo;
        private byte[] bArchivo;
        public string cNombreDocumento;
        private string cExtencion;
        private int idMotivo;
        public string cMotivo;

        private clsPagoGiro objPagoGiro { get; set; }
        private clsCNAprobacion objCNAprobacion = new clsCNAprobacion();

        DataTable dtGiroDesbloqueo = new DataTable();

        #endregion

        #region Constructores
        public frmSolDesbloqGiro()
        {
            InitializeComponent();

            idTipoArchivo = 3;
            cNombreDocumento = String.Empty;
            cExtencion = String.Empty;
            idMotivo = 0;
            cMotivo = String.Empty;
            lEditable = true;
        }
        #endregion

        #region Eventos
        private void frmSolDesbloqGiro_Load(object sender, EventArgs e)
        {

            CargarDatosComponente();
            txtMotivoSolicitud.Focus();
            txtNroGiro.Text = idServicioGiro.ToString();
            lEditable = (idSolAproba == 0) ? true : false ;            

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtNroGiro.Text))
            {
                MessageBox.Show("El Número de Giro, esta Vacio, por Favor Registrar ", "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(this.txtMotivoSolicitud.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento de la solicitud de Desbloqueo de Contraseña", "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMotivoSolicitud.Focus();
                return;
            }

            if (this.txtMotivoSolicitud.Text.Trim().Length < 20)
            {
                MessageBox.Show("Debe Ingresar en el Sustento por lo menos 20 caracteres", "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMotivoSolicitud.Focus();
                return;
            }

            //===================================================================
            //--Guardar Solicitud de Desbloqueo de Clave
            //===================================================================

            clsCNControlServ objCNControlServ = new clsCNControlServ();

            cMotivo = txtMotivoSolicitud.Text;

            int idTipoOpeGiro = 0;
            clsVarGen objVarTipoOpeGiro = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIdTipOpeGiroDesblClave"));
            idTipoOpeGiro = Convert.ToInt32(objVarTipoOpeGiro.cValVar);

            DataTable dtResultadoSolApr = objCNAprobacion.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, 0, idTipoOpeGiro, 1,
                                                                objPagoGiro.idMoneda, idProducto, objPagoGiro.nMontoGiro,
                                                               objPagoGiro.idServicioGiro, clsVarGlobal.dFecSystem, 0,
                                                                getMotivo(), 1, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (Convert.ToInt32(dtResultadoSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {   
                int idSolAprob = Convert.ToInt32(dtResultadoSolApr.Rows[0]["idSolAproba"]);
                DataTable dtResultadoArchivo = objCNControlServ.CNGuardarSolicitudDesbloqueoContra(objPagoGiro.idServicioGiro, idSolAprob, getArchivo(), cNombreDocumento, idTipoArchivo, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dtResultadoSolApr.Rows[0]["idEstadoSol"]) == 1)
                {
                    MessageBox.Show(dtResultadoSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtResultadoSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEnviar.Enabled = false;
                    txtMotivoSolicitud.Enabled = false;
                    lEditable = false;
                    this.Close();
                    return;
                }
                if (Convert.ToInt32(dtResultadoSolApr.Rows[0]["idEstadoSol"]) == 4)
                {
                    MessageBox.Show(dtResultadoSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtResultadoSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lEditable = false;
                    return;
                }
                
            }
            else
            {
                MessageBox.Show(dtResultadoSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Desbloqueo Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idServicioGiro = 0;
            this.bArchivo = null;
            cNombreDocumento = "";
            cExtencion = "";
            lblNombreArchivo.Text = "";
            idTipoArchivo = 3;
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            if(lEditable)
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
                        lblNombreArchivo.Text = "";
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
                        lblNombreArchivo.Text = cDocumentoSesion;
                        idTipoArchivo = 3;
                    }

                }
                else
                {
                    this.bArchivo = null;
                    cNombreDocumento = "";
                    cExtencion = "";
                    lblNombreArchivo.Text = "";
                }
            }
            else
            {

                if (dtGiroDesbloqueo.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron el Archivo de Susteno de la Solicitud de Debloqueo de Giro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToInt32(dtGiroDesbloqueo.Rows[0]["idTipoArchivo"]) == 3)
                {
                    if(dtGiroDesbloqueo.Rows[0]["cNombreArchivo"].ToString().Length > 0)
                    { 
                        frmDisplayPDF pdf = new frmDisplayPDF(dtGiroDesbloqueo.Rows[0]["cNombreArchivo"].ToString(), dtGiroDesbloqueo.Rows[0]["cExtencion"].ToString(), Compresion.DescompressedByte((byte[])dtGiroDesbloqueo.Rows[0]["bArchivo"]));
                        pdf.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("La solicitud no cuenta con ningún archivo adjunto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }
        #endregion

        #region Metodos
        public void CargarDatosGiro(clsPagoGiro _objPagoGiro)
        {
            objPagoGiro = _objPagoGiro;
        }

        public void CargarDatosComponente()
        {
            idServicioGiro = objPagoGiro.idServicioGiro;
            cboEstadoSolic.SelectedValue = 1;

            dtGiroDesbloqueo = objCNAprobacion.CNObtenerGiroSolDesblContra(idServicioGiro, idSolAproba);

            if (idSolAproba != 0)
            {
                cboEstadoSolic.SelectedValue = idEstadoSol;
                cboEstadoSolic.Enabled = false;
                txtMotivoSolicitud.Text = cMotivo;
                txtMotivoSolicitud.Enabled = false;
                lblNombreArchivo.Text = (dtGiroDesbloqueo.Rows.Count > 0) ? Convert.ToString(dtGiroDesbloqueo.Rows[0]["cNombreArchivo"]) : String.Empty;
                btnEnviar.Enabled = false;
                txtNroGiro.Enabled = false;
            }
            else
            {
                cboEstadoSolic.Enabled = false;
                txtMotivoSolicitud.Enabled = true;
                txtMotivoSolicitud.Text = String.Empty;
                btnEnviar.Enabled = true;
                lblNombreArchivo.Text = "-";
                txtNroGiro.Enabled = false;
            }
        }

        public string getNombreArchivo()
        {
            return (String.IsNullOrWhiteSpace(this.cNombreDocumento)) ? String.Empty : this.cNombreDocumento;
        }

        public byte[] getArchivo()
        {
            return (this.bArchivo == null) ? new byte[] { 0x20 } : this.bArchivo;
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
        #endregion

    }
}

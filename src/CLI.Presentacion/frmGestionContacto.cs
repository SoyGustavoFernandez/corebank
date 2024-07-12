
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CLI.Presentacion
{
    public partial class frmGestionContacto : frmBase
    {
        clsCNCliente Cliente = new clsCNCliente();
        clsGestionContactoCliente gestionContactoCli = new clsGestionContactoCliente();
        clsDataImprime datoImpresion = new clsDataImprime();
        DataTable dtGestionContactoCli = new DataTable();
        DataTable dtPropietarioRecursoTel = new DataTable();
        DataTable dtPropietarioRecursoCorreo = new DataTable();
        public int AlertaActualizacion = 0;
        public bool lAlertaImprimir = false;


        public frmGestionContacto()
        {
            InitializeComponent();
            btnCargaArhivos.Enabled = false;
            btnGrabar1.Enabled = false;
            btnImprimir1.Enabled = false;
            txtTelefCel1.Enabled = false;
            txtTelefCel2.Enabled = false;
            txtEmail1.Enabled = false;
            txtEmail2.Enabled = false;
            txtEmail2.MaxLength = 50;
            cboActualizarTelef.Enabled = false;
            cboActualizarCorr.Enabled = false;
            cboPropietTelef.Enabled = false;
            cboPropietCorreo.Enabled = false;
            grbDecisionTD.Enabled = false;
        }

        public void llenarBusqueda()
        {
            this.conBusCli1.txtCodCli.Text = Convert.ToString(gestionContactoCli.idCli);
            this.conBusCli1.txtNroDoc.Text = gestionContactoCli.cDocumentoID;
            this.conBusCli1.txtNombre.Text = gestionContactoCli.cNombre;
            this.conBusCli1.txtDireccion.Text = gestionContactoCli.cDireccion;
        }
        public frmGestionContacto(String cDocumentoID_)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(cDocumentoID_.Trim()))
            {
                return;
            }
            label1.Text = "";
            label2.Text = "";
            gestionContactoCli.cDocumentoID = cDocumentoID_;
            RellenarDatos();
            txtEmail2.MaxLength = 50;
            btnImprimir1.Enabled = false;

        }
        private void conBusCli1_ChangeDocumentoID(object sender, EventArgs e)
        {
            
            gestionContactoCli.idCli = Convert.ToInt32(this.conBusCli1.txtCodCli.Text);
            gestionContactoCli.cDocumentoID = this.conBusCli1.txtNroDoc.Text;
            gestionContactoCli.cNombre = Convert.ToString(this.conBusCli1.txtNombre.Text);
            gestionContactoCli.cDireccion = Convert.ToString(this.conBusCli1.txtDireccion.Text);
            gestionContactoCli.cCodCliente = Convert.ToString(this.conBusCli1.txtCodInst.Text) + Convert.ToString(this.conBusCli1.txtCodAge.Text) + Convert.ToString(this.conBusCli1.txtCodCli.Text);

            RellenarDatos();

            if (dtGestionContactoCli.Rows.Count == 0)
            {
                btnCargaArhivos.Enabled = false;
                btnGrabar1.Enabled = false;
                return;
            }

            btnCargaArhivos.Enabled = true;
            btnGrabar1.Enabled = true;
            grbDecisionTD.Enabled = true;
            cboActualizarTelef.Enabled = true;
            cboActualizarCorr.Enabled = true;
        }
        public void RellenarDatos()
        {

            txtTelefCel2.Enabled = false;
            cboPropietTelef.Enabled = false;
            txtEmail2.Enabled = false;
            cboPropietCorreo.Enabled = false;
            txtTelefCel1.Enabled = false;
            txtEmail1.Enabled = false;
            txtTelefCel2.MaxLength = 9;

            dtGestionContactoCli = Cliente.CNListarDatosGestionContacto(gestionContactoCli.idCli, 1, gestionContactoCli.cDocumentoID, "0", 0, 1, 0, 0, 0);

            if (dtGestionContactoCli.Rows.Count == 0)
            {
                return;
            }
            else
            {

                gestionContactoCli.cTelefonoPrincipal = Convert.ToString(dtGestionContactoCli.Rows[0]["cNumeroTelefonico"].ToString());
                gestionContactoCli.cCorreoPrincipal = Convert.ToString(dtGestionContactoCli.Rows[0]["cCorreoCli"].ToString());
                gestionContactoCli.cNombre = Convert.ToString(dtGestionContactoCli.Rows[0]["cNombre"].ToString());
                gestionContactoCli.cDireccion = Convert.ToString(dtGestionContactoCli.Rows[0]["cDireccion"].ToString());
                gestionContactoCli.idCli = Convert.ToInt32(dtGestionContactoCli.Rows[0]["idCli"].ToString());

                gestionContactoCli.dFechaUltimaMod = Convert.ToDateTime(dtGestionContactoCli.Rows[0]["dFechaUltimaMod"].ToString());
                gestionContactoCli.nAlertaActualizacion = Convert.ToInt32(dtGestionContactoCli.Rows[0]["nAlertaActualizacion"].ToString());
                AlertaActualizacion = Convert.ToInt32(dtGestionContactoCli.Rows[0]["nAlertaActualizacion"].ToString());
                gestionContactoCli.idPropietarioTelefonoPrincipal = Convert.ToInt32(dtGestionContactoCli.Rows[0]["idPropietarioTelefono"].ToString());
                gestionContactoCli.idPropietarioCorreoPrincipal = Convert.ToInt32(dtGestionContactoCli.Rows[0]["idPropietarioCorreo"].ToString());
                gestionContactoCli.idUsuarioReg = clsVarGlobal.User.idUsuario;
                gestionContactoCli.idTipoTel = 1;

                txtTelefCel1.Text = datoImpresion.cTelefonoPrincipal = gestionContactoCli.cTelefonoPrincipal;
                txtEmail1.Text = datoImpresion.cCorreoPrincipal = gestionContactoCli.cCorreoPrincipal;

                var ValoresMantieneTel = new List<clsMantieneDatos>();
                ValoresMantieneTel.Add(new clsMantieneDatos() { Index = "1", Value = "SI" });
                ValoresMantieneTel.Add(new clsMantieneDatos() { Index = "0", Value = "NO" });

                var ValoresMantieneCorreo = new List<clsMantieneDatos>();
                ValoresMantieneCorreo.Add(new clsMantieneDatos() { Index = "1", Value = "SI" });
                ValoresMantieneCorreo.Add(new clsMantieneDatos() { Index = "0", Value = "NO" });

                cboActualizarTelef.DataSource = ValoresMantieneTel;
                cboActualizarTelef.DisplayMember = "Value";
                cboActualizarTelef.ValueMember = "Index";

                cboActualizarCorr.DataSource = ValoresMantieneCorreo;
                cboActualizarCorr.DisplayMember = "Value";
                cboActualizarCorr.ValueMember = "Index";

                cboActualizarTelef.SelectedIndex = 1;
                cboActualizarCorr.SelectedIndex = 1;

                dtPropietarioRecursoTel = Cliente.CNListarPropietarioRecurso();
                cboPropietTelef.DataSource = dtPropietarioRecursoTel;
                cboPropietTelef.DisplayMember = "cPropietarioRecurso";
                cboPropietTelef.ValueMember = "idPropietarioRecurso";
                cboPropietTelef.SelectedValue = gestionContactoCli.idPropietarioTelefonoPrincipal;

                dtPropietarioRecursoCorreo = Cliente.CNListarPropietarioRecurso();
                cboPropietCorreo.DataSource = dtPropietarioRecursoCorreo;
                cboPropietCorreo.DisplayMember = "cPropietarioRecurso";
                cboPropietCorreo.ValueMember = "idPropietarioRecurso";
                cboPropietCorreo.SelectedValue = gestionContactoCli.idPropietarioCorreoPrincipal;

                if (gestionContactoCli.nAlertaActualizacion == 1)
                {
                    label1.Text = "Última actualización del Cliente: " + Convert.ToString(gestionContactoCli.dFechaUltimaMod.ToShortDateString() + " - REQUIERE ACTUALIZAR");
                    label1.ForeColor = Color.Red;
                    
                }
                else
                {
                    label1.Text = "Última actualización del Cliente: " + Convert.ToString(gestionContactoCli.dFechaUltimaMod.ToShortDateString());
                    label1.ForeColor = Color.Navy;
                    
                }

                llenarBusqueda();
            }

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtGrabarTelefono = new DataTable();
            DataTable dtGrabarCorreo = new DataTable();
            DataTable dtGrabarTratamientoDatos = new DataTable();

            gestionContactoCli.cNuevoTelefonoPrincipal = txtTelefCel2.Text;
            gestionContactoCli.cNuevoCorreoPrincipal = txtEmail2.Text;
            gestionContactoCli.idPropietarioTelefonoPrincipal = Convert.ToInt32(cboPropietTelef.SelectedValue);
            gestionContactoCli.idPropietarioCorreoPrincipal = Convert.ToInt32(cboPropietCorreo.SelectedValue);

            if (cboActualizarTelef.SelectedIndex == 1 && cboActualizarCorr.SelectedIndex == 1)
            {
                MessageBox.Show("Para grabar debe actualizar el número de teléfono o correo electrónico con formato válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboActualizarTelef.SelectedIndex == 0)
            {
                Regex xrTelefono = new Regex(@"^9\d{8}$");
                if (!xrTelefono.IsMatch((txtTelefCel2.Text)) || String.IsNullOrEmpty(txtTelefCel2.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el número de teléfono con un formato válido.", "Número de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTelefCel2.Focus();
                    return;
                }
            }
            if (cboActualizarCorr.SelectedIndex == 0)
            {
                Regex xrEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                if (!xrEmail.IsMatch(txtEmail2.Text) || String.IsNullOrEmpty(txtEmail2.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el correo electrónico con un formato válido.", "Correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmail2.Focus();
                    return;
                }
            }

            if(rbSi.Checked == false && rbNo.Checked == false)
            {
                MessageBox.Show("Seleccione una decisión en la autorización de envío de publicidad.", "Autorización de envío de publicidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboActualizarTelef.SelectedIndex == 0)
            {
                if (txtTelefCel1.Text.Equals(txtTelefCel2.Text))
                {
                    MessageBox.Show("El número de teléfono ingresado ya está registrado, ingrese otro número.", "Número de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefCel2.Focus();
                    return;
                }
            }
            if (cboActualizarCorr.SelectedIndex == 0)
            {
                if (txtEmail1.Text.Equals(txtEmail2.Text))
                {
                    MessageBox.Show("El correo electrónico ingresado ya está registrado, ingrese otro correo.", "Correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail2.Focus();
                    return;
                }
            }

            dtGrabarTelefono = Cliente.CNGrabarGestionContactoTelefono(gestionContactoCli.idCli, (cboActualizarTelef.SelectedIndex == 0) ? gestionContactoCli.cNuevoTelefonoPrincipal : gestionContactoCli.cTelefonoPrincipal, gestionContactoCli.idTipoTel, gestionContactoCli.idUsuarioReg, gestionContactoCli.idPropietarioTelefonoPrincipal);
            dtGrabarCorreo = Cliente.CNGrabarGestionContactoCorreo(gestionContactoCli.idCli, gestionContactoCli.idUsuarioReg, (cboActualizarCorr.SelectedIndex == 0) ? gestionContactoCli.cNuevoCorreoPrincipal : gestionContactoCli.cCorreoPrincipal, gestionContactoCli.idPropietarioCorreoPrincipal);
            
            if (Convert.ToInt32(dtGrabarTelefono.Rows[0]["idRespuesta"].ToString()) == 1 && Convert.ToInt32(dtGrabarCorreo.Rows[0]["idRespuesta"].ToString()) == 1)
            {
                MessageBox.Show("Guardado Correctamente, proceda a imprimir el documento de Política de Privacidad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cliente.ActualizarModulo(gestionContactoCli.cDocumentoID, clsVarGlobal.idModulo, clsVarGlobal.idMenu);
                lAlertaImprimir = true;
                btnImprimir1.Enabled = true;
                RellenarDatos();
            }
            
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if(lAlertaImprimir == true)
            {
                MessageBox.Show("Debe imprimir el documento de Política de Privacidad.", "Imprimir formato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Dispose();
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(gestionContactoCli.idCli) != "")
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(gestionContactoCli.idCli, false, "Política Privacidad");
                frmCargaArchivo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Cliente.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            datoImpresion.idCliente = gestionContactoCli.idCli;
            datoImpresion.cNombreTipoAut = "_POLITICA DE PRIVACIDAD_" + gestionContactoCli.cNombre;
            datoImpresion.cNombre = gestionContactoCli.cNombre;
            datoImpresion.cDireccion = gestionContactoCli.cDireccion;
            datoImpresion.idTipoPersona = 1;
            datoImpresion.cDocumentoID = gestionContactoCli.cDocumentoID;
            datoImpresion.cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            datoImpresion.idEstadoConcentimiento = (rbSi.Checked == true) ? 1 : 2;
            datoImpresion.cTipoAutorizacion = "Autorización de tratamiento de datos personales";
            datoImpresion.cArchivo = "";
            string cNombreArchivo = datoImpresion.idCliente.ToString() + datoImpresion.cNombreTipoAut;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombre", datoImpresion.cNombre, false));
            paramlist.Add(new ReportParameter("cDireccion", datoImpresion.cDireccion, false));
            paramlist.Add(new ReportParameter("IdTipoPersona", datoImpresion.idTipoPersona.ToString(), false));
            paramlist.Add(new ReportParameter("cDocumentoID", datoImpresion.cDocumentoID, false));
            paramlist.Add(new ReportParameter("cRutaLogo", datoImpresion.cRutaLogo, false));
            paramlist.Add(new ReportParameter("idEstadoConcentimiento", datoImpresion.idEstadoConcentimiento.ToString(), false));
            paramlist.Add(new ReportParameter("cTelefonoPrincipal", datoImpresion.cTelefonoPrincipal, false));
            paramlist.Add(new ReportParameter("cCorreoPrincipal", datoImpresion.cCorreoPrincipal, false));
            paramlist.Add(new ReportParameter("cTipoAutorizacion", datoImpresion.cTipoAutorizacion, false));
            string cOficina = clsVarGlobal.cNomAge.Trim();
            string cDia = clsVarGlobal.dFecSystem.Date.Day.ToString();
            CultureInfo culture = new CultureInfo("es-ES");
            string cMes = clsVarGlobal.dFecSystem.ToString("MMMM", culture);
            string cAño = clsVarGlobal.dFecSystem.Date.Year.ToString();
            string cDescripcionFecha = String.Format("En la {0} a los {1} días del mes de {2} del año {3}.", cOficina, cDia, cMes, cAño);
            paramlist.Add(new ReportParameter("cDescripcionFecha", cDescripcionFecha, false));
            frmVerPdfGestContact frmVerPdfGC = new frmVerPdfGestContact();
            byte[] bArchivoBinary = null;
            bArchivoBinary = GenerarDocumento("rptPoliticaPrivacidadCli.rdlc", cNombreArchivo, paramlist, dtslist, ref datoImpresion.cArchivo);

            frmVerPdfGC.cArchivo = datoImpresion.cArchivo;
            frmVerPdfGC.bArchivoBinary = (byte[])bArchivoBinary;

            frmVerPdfGC.ShowDialog();
            lAlertaImprimir = false;
        }
        public static byte[] GenerarDocumento(string reportpath, string cNombreArchivo, List<ReportParameter> paramlist, List<ReportDataSource> dtslist, ref string cArchivoFin)
        {
            string cPathRoot = clsVarGlobal.cRutPathApp;
            string cPathAnioMes = clsVarGlobal.dFecSystem.ToString("yyyyMMdd");

            string cRuta = Path.Combine(cPathRoot, cPathAnioMes);

            new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cRuta, cNombreArchivo);
            string cArchivo = cRuta + "\\" + cNombreArchivo + ".pdf";

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

            cArchivoFin = cDocumentoSesion;
            return Compresion.CompressedByte(vDocumentoSesion);
        }

        private void cboActualizarTelef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActualizarTelef.SelectedIndex == 1)
            {
                txtTelefCel2.Text = "";
                txtTelefCel2.Enabled = false;
                cboPropietTelef.Enabled = false;
            }
            else
            {
                txtTelefCel2.Enabled = true;
                cboPropietTelef.Enabled = true;
                txtTelefCel2.Focus();
            }
        }

        private void cboActualizarCorr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActualizarCorr.SelectedIndex == 1)
            {
                txtEmail2.Text = "";
                txtEmail2.Enabled = false;
                cboPropietCorreo.Enabled = false;
            }
            else
            {
                txtEmail2.Enabled = true;
                cboPropietCorreo.Enabled = true;
                txtEmail2.Focus();
            }
        }
    }
}

public class clsMantieneDatos
{
    public string Value { get; set; }
    public string Index { get; set; }
}
public class clsGestionContactoCliente
{
    public int idCli { get; set; }
    public String cDocumentoID { get; set; }
    public String cNombre { get; set; }
    public String cDireccion { get; set; }
    public String cCodCliente { get; set; }

    public String cTelefonoPrincipal { get; set; }
    public String cCorreoPrincipal { get; set; }

    public String cNuevoTelefonoPrincipal { get; set; }
    public String cNuevoCorreoPrincipal { get; set; }
    public bool lNuevoTratamientoDatos { get; set; }

    public int idPropietarioTelefonoPrincipal { get; set; }
    public int idPropietarioCorreoPrincipal { get; set; }

    public bool lMantieneTelefono { get; set; }
    public bool lMantieneCorreo { get; set; }

    public int idTipoTel { get; set; }

    public DateTime dFechaUltimaMod { get; set; }
    public int nAlertaActualizacion { get; set; }

    public int idUsuarioReg { get; set; }

}
public class clsDataImprime{
    public int idCliente;
    public string cNombreTipoAut;
    public string cNombre;
    public string cDireccion;
    public int idTipoPersona;
    public string cDocumentoID;
    public string cRutaLogo;
    public int idEstadoConcentimiento;
    public string cTipoAutorizacion;
    public string cDescripcionFecha;
    public string cArchivo;

    public string cTelefonoPrincipal;
    public string cCorreoPrincipal;
}

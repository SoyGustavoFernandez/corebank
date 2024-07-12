using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Servicio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmDesafiliacionPaqueteSeguro : frmBase
    {

        private clsCNCreditoCargaSeguro _cnCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        clsDesafiliarPaqueteSeguro clsDesafiliarPaqueteSeguro = new clsDesafiliarPaqueteSeguro();
        private readonly string TituloForm = "Desafiliación Planes de Seguro";
        private int idSeguroOpcional = 0;

        public frmDesafiliacionPaqueteSeguro()
        {
            InitializeComponent();
        }

        private void frmDesafiliacionPaqueteSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            LimpiarTodo();
            dtgPrimaSeguro.AutoGenerateColumns = false;
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCliente.idCli != 0)
            {
                btnCancelar.Enabled = true;
                conBusCliente.Enabled = false;
                CargarInformacionPaqueteSeguro();
            }
        }

        private void btnDesafiliarSeguro_Click(object sender, EventArgs e)
        {
            string pregunta = "¿Está seguro de desafiliar el plan de seguro?";
            string fraseDestacada = "ESTA OPERACIÓN ES IRREVERSIBLE";
            using (Form form = new Form())
            {
                form.Text = TituloForm;
                form.ClientSize = new Size(300, 120);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false; // Desactiva el botón de maximizar
                form.MinimizeBox = false; // Desactiva el botón de minimizar
                form.StartPosition = FormStartPosition.CenterScreen;

                Label lblPregunta = new Label();
                lblPregunta.Text = pregunta;
                lblPregunta.AutoSize = true;
                lblPregunta.Location = new Point(45, 20);
                lblPregunta.TextAlign = ContentAlignment.MiddleCenter;

                Label lblFraseDestacada = new Label();
                lblFraseDestacada.Text = fraseDestacada;
                lblFraseDestacada.Font = new Font(lblFraseDestacada.Font, FontStyle.Bold);
                lblFraseDestacada.ForeColor = Color.Red;
                lblFraseDestacada.AutoSize = true;
                lblFraseDestacada.Location = new Point(45, 50);

                PictureBox pictureBoxIcono = new PictureBox();
                pictureBoxIcono.Image = SystemIcons.Warning.ToBitmap();
                pictureBoxIcono.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxIcono.Location = new Point(10, 30);

                Button btnSi = new Button();
                btnSi.Text = "Sí";
                btnSi.DialogResult = DialogResult.Yes;
                btnSi.Location = new Point(70, 80);

                Button btnNo = new Button();
                btnNo.Text = "No";
                btnNo.DialogResult = DialogResult.No;
                btnNo.Location = new Point(170, 80);

                form.Controls.Add(lblPregunta);
                form.Controls.Add(lblFraseDestacada);
                form.Controls.Add(pictureBoxIcono);
                form.Controls.Add(btnSi);
                form.Controls.Add(btnNo);

                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Yes)
                    DesafiliarSeguro();
                else if (result == DialogResult.No)
                    return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        /// <summary>
        /// Limpia la opcion
        /// </summary>
        private void LimpiarTodo()
        {
            conBusCliente.Enabled = false;
            btnCancelar.Enabled = false;
            btnDesafiliarSeguro.Enabled = false;
            dtgPrimaSeguro.Enabled = true;
            btnImprimir1.Enabled = false;

            conBusCliente.limpiarControles();
            txtNumeroCuenta.Text = string.Empty;
            txtPaqueteSeguro.Text = string.Empty;
            txtPrimaMensual.Text = string.Empty;
            dtgPrimaSeguro.DataSource = null;

            conBusCliente.Enabled = true;

            idSeguroOpcional = 0;
        }

        /// <summary>
        /// Carga la informacion en los controles
        /// </summary>
        private void CargarInformacionPaqueteSeguro()
        {
            List<clsDesafiliarPaqueteSeguro> lista = _cnCreditoCargaSeguro.CNConsultaDesafiliacionPaqueteSeguro(conBusCliente.idCli);
            if (!lista.Any())
            {
                MessageBox.Show("El cliente no tiene contratado algún plan de seguro", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodo();
                return;
            }
            clsDesafiliarPaqueteSeguro=lista.FirstOrDefault();
            dtgPrimaSeguro.DataSource = lista;
            txtNumeroCuenta.Text = lista.First().idCuenta.ToString();
            txtPaqueteSeguro.Text = lista.First().cPaqueteSeguroCompleto;
            txtPrimaMensual.Text = lista.First().nMontoPrima.ToString();
            idSeguroOpcional = lista.First().idSeguroOpcional;
            btnDesafiliarSeguro.Enabled = true;
        }

        /// <summary>
        /// Ejecuta la desafiliacion del paquete seguro
        /// </summary>
        private void DesafiliarSeguro()
        {
            if (!ValidarParaDesafiliarSeguro())
                return;

            var dFechaSistema = clsVarGlobal.dFecSystem;
            var idUsuario = clsVarGlobal.User.idUsuario;
            clsDBResp respuesta = _cnCreditoCargaSeguro.CNDesafiliarSeguroOpcional(idSeguroOpcional, idUsuario, dFechaSistema);
            if (respuesta.nMsje == 0)
            {
                MessageBox.Show(respuesta.cMsje, TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsProcesoExp.guardarCopiaExpediente("Desafiliación de seguros", clsDesafiliarPaqueteSeguro.idSolicitud, this);
                btnImprimir1.Enabled = true;
                conBusCliente.Enabled = false;
                btnCancelar.Enabled = false;
                btnDesafiliarSeguro.Enabled = false;
                btnSalir1.Enabled = false;
            }
            else
            {
                MessageBox.Show(respuesta.cMsje, TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarParaDesafiliarSeguro()
        {
            return idSeguroOpcional != 0;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (clsDesafiliarPaqueteSeguro.idSolicitud == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente con solicitud vigente", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtPpgCred = new clsRPTCNPlanPagos().CNCronogramaCreditoGastosSeguros(clsDesafiliarPaqueteSeguro.idSolicitud);
            int idcli = Convert.ToInt32(dtPpgCred.Rows[0]["idCli"]);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idCliente", idcli.ToString(), false));
            paramlist.Add(new ReportParameter("nNumCredito", clsDesafiliarPaqueteSeguro.idCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(clsDesafiliarPaqueteSeguro.idCuenta)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNDireccion(clsDesafiliarPaqueteSeguro.idCuenta)));

            string reportpath = "RptCalendarioCreditoSeguros.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
            LimpiarTodo();
            btnSalir1.Enabled = true;
        }
    }
}

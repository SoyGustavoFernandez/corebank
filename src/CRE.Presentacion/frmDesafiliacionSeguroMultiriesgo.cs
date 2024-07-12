using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Servicio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmDesafiliacionSeguroMultiriesgo : frmBase
    {

        private clsCNCreditoCargaSeguro _cnCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private readonly string TituloForm = "Desafiliación Seguro Multiriesgo";
        clsDesafiliarSeguroMultiriesgo clsDesafiliarSeguroMultiriesgo = new clsDesafiliarSeguroMultiriesgo();
        private int idSeguroOpcional = 0;

        public frmDesafiliacionSeguroMultiriesgo()
        {
            InitializeComponent();
        }

        private void frmDesafiliacionSeguroMultiriesgo_Load(object sender, EventArgs e)
        {
            LimpiarTodo();
            dtgPrimaSeguro.AutoGenerateColumns = false;
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCliente.idCli != 0)
            {
                btnCancelar.Enabled = true;
                conBusCliente.Enabled = false;
                CargarInformacionSeguroMultiriesgo();
            }
        }

        private void btnDesafiliarSeguro_Click(object sender, EventArgs e)
        {
            string pregunta = "¿Está seguro de desafiliar el seguro multiriesgo?";
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
            txtPrimaMensual.Text = string.Empty;
            dtgPrimaSeguro.DataSource = null;

            conBusCliente.Enabled = true;

            idSeguroOpcional = 0;
        }

        /// <summary>
        /// Carga la informacion en los controles
        /// </summary>
        private void CargarInformacionSeguroMultiriesgo()
        {
            // TODO: ejecutar el metodo para cargar la informacion del seguro multiriesgo
            List<clsDesafiliarSeguroMultiriesgo> lista = _cnCreditoCargaSeguro.CNConsultaDesafiliacionSeguroMultiriesgo(conBusCliente.idCli);
            if (!lista.Any())
            {
                MessageBox.Show("El cliente no tiene contratado el seguro multiriesgo", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodo();
                return;
            }
            clsDesafiliarSeguroMultiriesgo = lista.FirstOrDefault();
            dtgPrimaSeguro.DataSource = lista;
            txtNumeroCuenta.Text = lista.First().idCuenta.ToString();
            txtPrimaMensual.Text = lista.First().nMontoPrima.ToString();
            idSeguroOpcional = lista.First().idSeguroOpcional;
            btnDesafiliarSeguro.Enabled = true;
        }

        /// <summary>
        /// Ejecuta la desafiliacion del seguro multiriesgo
        /// </summary>
        private void DesafiliarSeguro()
        {
            if (!ValidarParaDesafiliarSeguro())
                return;

            var dFechaSistema = clsVarGlobal.dFecSystem;
            var idUsuario = clsVarGlobal.User.idUsuario;
            clsDBResp respuesta = _cnCreditoCargaSeguro.CNDesafiliarSeguroMultiriesgo(idSeguroOpcional, idUsuario, dFechaSistema);
            if (respuesta.nMsje == 0)
            {
                MessageBox.Show(respuesta.cMsje, TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsProcesoExp.guardarCopiaExpediente("Desafiliación de seguros", clsDesafiliarSeguroMultiriesgo.idSolicitud, this);
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
            if (clsDesafiliarSeguroMultiriesgo.idSolicitud == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente con solicitud vigente", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtPpgCred = new clsRPTCNPlanPagos().CNCronogramaCreditoGastosSeguros(clsDesafiliarSeguroMultiriesgo.idSolicitud);
            int idcli = Convert.ToInt32(dtPpgCred.Rows[0]["idCli"]);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idCliente", idcli.ToString(), false));
            paramlist.Add(new ReportParameter("nNumCredito", clsDesafiliarSeguroMultiriesgo.idCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(clsDesafiliarSeguroMultiriesgo.idCuenta)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNDireccion(clsDesafiliarSeguroMultiriesgo.idCuenta)));

            string reportpath = "RptCalendarioCreditoSeguros.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
            LimpiarTodo();
            btnSalir1.Enabled = true;
        }
    }
}

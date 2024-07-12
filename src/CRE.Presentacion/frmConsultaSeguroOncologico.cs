using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmConsultaSeguroOncologico : frmBase
    {
        clsCNSiniestros objCNSiniestros = new clsCNSiniestros();

        public frmConsultaSeguroOncologico()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            limpiar();
            Dispose();
        }

        private void limpiar()
        {
            conBusCli.limpiarControles();
            this.txtEstablecimiento.Text = clsVarGlobal.cNomAge;
            this.cboSiniestro.SelectedValue = 0;
            tmpIniCobertura.Value = clsVarGlobal.dFecSystem;
            tmpFinCobertura.Value = clsVarGlobal.dFecSystem.AddYears(1);
            cboSiniestro.Enabled = false;

        }

        private void frmConsultaSeguroOncologico_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            inicializarVariables();
        }

        private void inicializarVariables()
        {
            txtEstablecimiento.Enabled = false;
            txtEstablecimiento.Text = clsVarGlobal.cNomAge;
            tmpIniCobertura.Value = clsVarGlobal.dFecSystem;
            tmpFinCobertura.Value = clsVarGlobal.dFecSystem.AddYears(1);
            cboSiniestro.Enabled = false;
            tmpIniCobertura.Enabled = false;
            tmpFinCobertura.Enabled = false;

            //Llena el combo de siniestros con valores predeterminados
            DataTable tblSeguros = new DataTable();
            tblSeguros.Columns.Add("idTipoSeguro", typeof(int));
            tblSeguros.Columns.Add("cTipoSeguro", typeof(string));
            tblSeguros.Rows.Add(1, "SI");
            tblSeguros.Rows.Add(0, "NO");
            cboSiniestro.DataSource = tblSeguros;
            cboSiniestro.DisplayMember = "cTipoSeguro";
            cboSiniestro.ValueMember = "idTipoSeguro";
            cboSiniestro.SelectedValue = 0;
        }

        private void conBusCli_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
                return;

            DataTable dtSeguro = objCNSiniestros.CargarDatosSeguroIndividual(clsVarApl.dicVarGen["nIdSeguroOncologico"], Convert.ToInt32(conBusCli.txtCodCli.Text));
            //llena el dtgsiniestros
            if (dtSeguro.Rows.Count > 0)
            {
                    tmpIniCobertura.Value = Convert.ToDateTime(dtSeguro.Rows[0]["dFechaInicioVigencia"]);
                    tmpFinCobertura.Value = Convert.ToDateTime(dtSeguro.Rows[0]["dFechaFinVigencia"]);
                    txtEstablecimiento.Text = dtSeguro.Rows[0]["cAgencia"].ToString();
                    cboSiniestro.SelectedValue = string.IsNullOrEmpty(dtSeguro.Rows[0]["cAgencia"].ToString()) ? 1 : 0;
            }
            else
            {
                //Muestro mensaje que no existe registros para dicho cliente
                MessageBox.Show("No existe registros para el cliente seleccionado", "Consulta de Seguro Oncológico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
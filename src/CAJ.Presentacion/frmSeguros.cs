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
using CRE.CapaNegocio;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmSeguros : frmBase
    {
        private clsCNSeguros clsSeguros = new clsCNSeguros();
        private DataTable dtMonto;
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        public frmSeguros()
        {
            InitializeComponent();
        }

        public void cboSeguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeses.SelectedItem != null)
            {
                DataRowView filaSeleccionada = cboMeses.SelectedItem as DataRowView;

                if (filaSeleccionada != null)
                {
                    int idTipoPlanSeleccionado = Convert.ToInt32(filaSeleccionada["idTipoPlan"]);

            dtMonto = clsSeguros.obtenerPrecioPlanSeguro(idTipoPlanSeleccionado, 0);

            txtMonto.Text = dtMonto.Rows[0]["nPrecioTotal"].ToString();
        }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cboTipoSeguro.SelectedItem == null || cboMeses.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor escoja un plan de Seguro", "Validación de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (conBusCli.idCli == 0)
            {
                MessageBox.Show("Por favor escoja un cliente", "Validación de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!ValidarSeguros(Convert.ToInt32(this.conBusCli.txtCodCli.Text), Convert.ToInt32(dtMonto.Rows[0]["nMeses"]), (int)cboTipoSeguro.SelectedValue))
            {
                return;
            }
            else
            {
                decimal nMonto = Convert.ToDecimal(txtMonto.Text);
                int idCli = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
                int idConcepto = Convert.ToInt32(dtMonto.Rows[0]["idConcepto"]);
                int nMeses = Convert.ToInt32(dtMonto.Rows[0]["nMeses"]);
                int idTipoPlan = Convert.ToInt32(dtMonto.Rows[0]["idTipoPlan"]);
                string cSustento = "VENTA DE MICRO" + ((clsSolicitudCreditoSeguro)cboTipoSeguro.SelectedItem).cTipoSeguro + " POR " + nMeses + " MESES, DNI: " + conBusCli.txtNroDoc.Text + " - " + conBusCli.txtNombre.Text;

                frmEmisionRecibos frmRecibos = new frmEmisionRecibos(nMonto, idCli, idConcepto, cSustento, nMeses, idTipoPlan);
                frmRecibos.objFrmSemaforo = this.objFrmSemaforo;
                frmRecibos.ShowDialog();

                if (frmRecibos.lGrabarSeguro == true)
                {
                    this.btnGrabar.Enabled = false;
                    this.cboMeses.Enabled = false;
                    this.conBusCli.btnBusCliente.Enabled = false;
                }
            }
        }

        private bool ValidarSeguros(int idCli, int nMeses, int idSeguro)
        {
            DataTable dtResultado;
            if (idSeguro == Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]))
            {
                #region SeguroVida
                string xmlSeguros = "<?xml version='1.0'?><ArrayOfXElement xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><XElement><idTipoSeguro>2</idTipoSeguro></XElement></ArrayOfXElement>";
                dtResultado = objCNCreditoCargaSeguro.CNValidarSeguros(
                    idCli,
                    xmlSeguros,
                    nMeses,
                    0);
                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                #endregion
            }
            else if (idSeguro == Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]))
            {
                #region SeguroOncologico
                dtResultado = objCNCreditoCargaSeguro.CNValidarSeguroOncologico(idCli, nMeses, 0);
                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                #endregion
            }
            return true;
        }

        private void frmSeguros_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
        }
      
        private void conBusCli_Load(object sender, EventArgs e)
        {
            if (this.conBusCli.txtNombre.Text != "")
            {
                this.conBusCli.txtCodCli.Enabled = false;
                clsCNBuscarCli listarCli = new clsCNBuscarCli();
                DataTable tablaCli = listarCli.ListarclixIdCli(conBusCli.idCli);
            }

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.conBusCli.txtCodInst.Clear();
            this.conBusCli.txtCodAge.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtDireccion.Clear();
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.btnBusCliente.Enabled = true;
            this.cboMeses.Enabled = true;
            this.txtMonto.Text = " ";
            this.btnGrabar.Enabled = true;
            cboMeses.SelectedIndexChanged -= cboSeguros_SelectedIndexChanged;
            cboMeses.SelectedIndex = -1;
            cboMeses.SelectedIndexChanged += cboSeguros_SelectedIndexChanged;

            cboTipoSeguro.SelectedIndexChanged -= cboTipoSeguro_SelectedIndexChanged;
            cboTipoSeguro.SelectedIndex = -1;
            cboTipoSeguro.SelectedIndexChanged += cboTipoSeguro_SelectedIndexChanged;
        }

        private void cboTipoSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeguro.SelectedItem != null)
            {
                DataTable dtSeguro = new clsCNSeguros().LisSeguro();

                int idTipoSeguroSeleccionado = ((clsSolicitudCreditoSeguro)cboTipoSeguro.SelectedItem).idTipoSeguro;

                if (idTipoSeguroSeleccionado == -1)
                {
                    cboMeses.DataSource = null;
                    txtMonto.Text = "0";
                    return;
                }

                var filasFiltradas = dtSeguro.AsEnumerable().Where(row => row.Field<int>("idTipoSeguro") == idTipoSeguroSeleccionado).CopyToDataTable();

                if (dtSeguro.Rows.Count > 0)
                {
                    cboMeses.DataSource = filasFiltradas;
                    cboMeses.ValueMember = dtSeguro.Columns["idTipoPlan"].ToString();
                    cboMeses.DisplayMember = dtSeguro.Columns["cDescripcion"].ToString();
                }
            }
        }
    }
}
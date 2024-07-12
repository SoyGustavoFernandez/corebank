using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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
    public partial class frmCargarGastosJudiciales : frmBase
    {

        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        DataTable dtCredito;
        public frmCargarGastosJudiciales()
        {
            InitializeComponent();
        }

        private void frmCargarGastosJudiciales_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "C";
            this.conBusCuentaCli1.cEstado = "[5]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            habilitarControles(false);
        }


        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text))
            {

                dtCredito = CNGastosJudiciales.ObtenerDatosCredito(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));
                if (Convert.ToInt32(dtCredito.Rows[0]["idCondContableNormal"]) != 4 || Convert.ToInt32(dtCredito.Rows[0]["nCuotas"]) != 1)
                {
                    MessageBox.Show("El crédito debe estar con estado contable Judicial y el plan de pagos debe estar consolidado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCuentaCli1.LiberarCuenta();
                    limpiar();
                    habilitarControles(false);
                    return;
                }
                habilitarControles(true);
                cargar();
            }
        }

        private void cargar()
        {
            DataTable dtGastos = CNGastosJudiciales.ListarPendientes(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));
            if (dtGastos.Rows.Count > 0)
            {
                dtgCargosJudiciales.DataSource = dtGastos;
                dtGastos.Columns["lCargar"].ReadOnly = false;
                formteardtgCargosJudiciales();
            }
            else
            {
                MessageBox.Show("El crédito no tiene gastos pendientes a cargar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCuentaCli1.LiberarCuenta();
                limpiar();
                habilitarControles(false);
                return;
            }
        }

        private void formteardtgCargosJudiciales()
        {

            foreach (DataGridViewColumn column in dtgCargosJudiciales.Columns)
            {
                column.Visible = false;
            }

            dtgCargosJudiciales.Columns["lCargar"].Visible = true;
            dtgCargosJudiciales.Columns["dFechaRegistra"].Visible = true;
            dtgCargosJudiciales.Columns["cConcepto"].Visible = true;
            dtgCargosJudiciales.Columns["nMonto"].Visible = true;
            dtgCargosJudiciales.Columns["cObservacion"].Visible = true;
            dtgCargosJudiciales.Columns["cNombre"].Visible = true;
            dtgCargosJudiciales.Columns["cMoneda"].Visible = true;

            dtgCargosJudiciales.Columns["dFechaRegistra"].HeaderText = "Fecha Reg.";
            dtgCargosJudiciales.Columns["cConcepto"].HeaderText = "Concepto";
            dtgCargosJudiciales.Columns["nMonto"].HeaderText = "Monto";
            dtgCargosJudiciales.Columns["cObservacion"].HeaderText = "Observación";
            dtgCargosJudiciales.Columns["cNombre"].HeaderText = "Usuario Reg.";
            dtgCargosJudiciales.Columns["cMoneda"].HeaderText = "Mon.";
            dtgCargosJudiciales.Columns["lCargar"].HeaderText = "Cargar";

            dtgCargosJudiciales.Columns["dFechaRegistra"].Width = 70;
            dtgCargosJudiciales.Columns["cConcepto"].Width = 100;
            dtgCargosJudiciales.Columns["nMonto"].Width = 70;
            dtgCargosJudiciales.Columns["cObservacion"].Width = 100;
            dtgCargosJudiciales.Columns["cNombre"].Width = 100;
            dtgCargosJudiciales.Columns["cMoneda"].Width = 25;
            dtgCargosJudiciales.Columns["lCargar"].Width = 50;

            dtgCargosJudiciales.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgCargosJudiciales.Columns)
            {
                column.ReadOnly = true;
            }
            dtgCargosJudiciales.Columns["lCargar"].ReadOnly = false;
        }

        private void limpiar()
        {
            rbtSentenciaJudicial.Checked = true;
            rbtAcuerdoCliente.Checked = false;
            dtgCargosJudiciales.DataSource = null;
            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();
        }

        public void habilitarControles(bool lHabilitar)
        {
            btnCancelar1.Enabled = lHabilitar;
            btnGrabar1.Enabled = lHabilitar;
            dtgCargosJudiciales.Enabled = lHabilitar;
            gbxDatosCarga.Enabled = lHabilitar;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
            limpiar();
            habilitarControles(false);
        }

        private void frmCargarGastosJudiciales_FormClosing(object sender, FormClosingEventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguró de cargar los gastos judiciales?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            DataTable dtGastosJudiciales = (DataTable)dtgCargosJudiciales.DataSource;
            int cont = 0;
            foreach (DataRow row in dtGastosJudiciales.Rows)
            {
                if (Convert.ToBoolean(row["lCargar"]))
                {
                    cont++;
                }
            }

            if (cont <= 0)
            {
                MessageBox.Show("Al menos debe seleccionar un gasto a aplicar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataSet ds = new DataSet("dsGastosJudiciales");
            ds.Tables.Add(dtGastosJudiciales);

            string XMLGastosJudiciales = ds.GetXml();

            string cMotivoCarga = (rbtSentenciaJudicial.Checked ? rbtSentenciaJudicial.Text : rbtAcuerdoCliente.Text);

            DataTable dtResultado = CNGastosJudiciales.CargarGastosJudiciales(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                                                                Convert.ToInt32(dtCredito.Rows[0]["idPlanPagos"]),
                                                                                Convert.ToInt32(dtCredito.Rows[0]["idProducto"]),
                                                                                cMotivoCarga,
                                                                                Convert.ToInt32(dtCredito.Rows[0]["idMoneda"]),
                                                                                XMLGastosJudiciales,
                                                                                clsVarGlobal.User.idUsuario,
                                                                                clsVarGlobal.nIdAgencia,
                                                                                clsVarGlobal.dFecSystem);

            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("La Carga de Gastos Judiciales se ha registrado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCuentaCli1.LiberarCuenta();
                limpiar();
                habilitarControles(false);
            }
            else
            {
                MessageBox.Show("Error al cargar de Gastos Judiciales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

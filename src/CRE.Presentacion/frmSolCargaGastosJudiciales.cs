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
    public partial class frmSolCargaGastosJudiciales : frmBase
    {
        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        DataTable dtCredito;
        public frmSolCargaGastosJudiciales()
        {
            InitializeComponent();
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            frmAgregarGastoJudicial fromAgregarGastoJudicial = new frmAgregarGastoJudicial();
            fromAgregarGastoJudicial.ShowDialog();
            if (fromAgregarGastoJudicial.lAceptar)
            {
                DataTable dtResultado = CNGastosJudiciales.RegistrarSolicitud(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                                                                Convert.ToInt32(fromAgregarGastoJudicial.cboTipoGasto1.SelectedValue),
                                                                                Convert.ToInt32(fromAgregarGastoJudicial.cboMoneda1.SelectedValue),
                                                                                Convert.ToDecimal(fromAgregarGastoJudicial.txtMonto.Text),
                                                                                fromAgregarGastoJudicial.txtObservacion.Text.Trim(),
                                                                                clsVarGlobal.User.idUsuario,
                                                                                clsVarGlobal.dFecSystem);

                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se registro solicitud de gasto correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar solicitud de gasto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cargar();
                fromAgregarGastoJudicial.Dispose();
            }
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgCargosJudiciales.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dtgCargosJudiciales.SelectedRows[0].Cells["idEstado"].Value) == 1)
                {
                    DataGridViewRow rowSeleccionada = dtgCargosJudiciales.SelectedRows[0];

                    DataTable dtResultado = CNGastosJudiciales.EliminarSolGastoJud(Convert.ToInt32(rowSeleccionada.Cells["idSolCargaGastosJudiciales"].Value),
                                                                                    clsVarGlobal.User.idUsuario,
                                                                                    clsVarGlobal.dFecSystem);
                    if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Se eliminó solicitud de gasto correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar solicitud de gasto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    cargar();
                }
                else
                {
                    MessageBox.Show("Solo se pueden eliminar gastos en estado solicitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmSolCargaGastosJudiciales_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "C";
            this.conBusCuentaCli1.cEstado = "[5]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;

            btnCancelar1.Enabled = false;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            groupBox2.Enabled = false;
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
                    conBusCuentaCli1.limpiarControles();
                    conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    return;
                }
                cargar();
            }
            btnCancelar1.Enabled = true;
            btnMiniAgregar1.Enabled = true;
            btnMiniQuitar1.Enabled = true;
            groupBox2.Enabled = true;
        }

        private void cargar()
        {
            DataTable dtGastos = CNGastosJudiciales.Listar(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));
            if (dtGastos.Rows.Count > 0)
            {
                dtgCargosJudiciales.DataSource = dtGastos;
                formteardtgCargosJudiciales();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtgCargosJudiciales.DataSource = null;
            conBusCuentaCli1.LiberarCuenta();
            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();

            btnCancelar1.Enabled = false;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void frmSolCargaGastosJudiciales_FormClosing(object sender, FormClosingEventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
        }

        private void formteardtgCargosJudiciales()
        {
            foreach (DataGridViewColumn column in dtgCargosJudiciales.Columns)
            {
                column.Visible = false;
            }

            dtgCargosJudiciales.Columns["dFechaRegistra"].Visible = true;
            dtgCargosJudiciales.Columns["cConcepto"].Visible = true;
            dtgCargosJudiciales.Columns["nMonto"].Visible = true;
            dtgCargosJudiciales.Columns["cObservacion"].Visible = true;
            dtgCargosJudiciales.Columns["cEstadoSolCarGastJud"].Visible = true;
            dtgCargosJudiciales.Columns["cNombre"].Visible = true;
            dtgCargosJudiciales.Columns["cMoneda"].Visible = true;

            dtgCargosJudiciales.Columns["dFechaRegistra"].HeaderText = "Fecha Reg.";
            dtgCargosJudiciales.Columns["cConcepto"].HeaderText = "Concepto";
            dtgCargosJudiciales.Columns["nMonto"].HeaderText = "Monto";
            dtgCargosJudiciales.Columns["cObservacion"].HeaderText = "Observación";
            dtgCargosJudiciales.Columns["cEstadoSolCarGastJud"].HeaderText = "Estado";
            dtgCargosJudiciales.Columns["cNombre"].HeaderText = "Usuario Reg.";
            dtgCargosJudiciales.Columns["cMoneda"].HeaderText = "Mon.";

            dtgCargosJudiciales.Columns["dFechaRegistra"].Width = 70;
            dtgCargosJudiciales.Columns["cConcepto"].Width = 100;
            dtgCargosJudiciales.Columns["nMonto"].Width = 70;
            dtgCargosJudiciales.Columns["cObservacion"].Width = 100;
            dtgCargosJudiciales.Columns["cEstadoSolCarGastJud"].Width = 100;
            dtgCargosJudiciales.Columns["cNombre"].Width = 100;
            dtgCargosJudiciales.Columns["cMoneda"].Width = 25;
        }
    }
}

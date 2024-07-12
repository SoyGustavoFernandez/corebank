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
using LOG.CapaNegocio;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using CNT.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmAsientoContableBienes : frmBase
    {
        #region Variables Globales

        clsCNCatalogo cncatalogo = new clsCNCatalogo();
        clsCNControlOpe cncontrolope = new clsCNControlOpe();
        DataTable dtCuentas=new DataTable();
        Transaccion eoperacion = Transaccion.Selecciona;

        #endregion

        public frmAsientoContableBienes()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
            cargarCuentasGrupo();
            cargarTipoOperacion();
            cargarDestino();
            cboTipoTransaccion1.SelectedValue = 1;
        }

        private void dtgGrupoBien_SelectionChanged(object sender, EventArgs e)
        {
            cargarCuentasGrupo();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            eoperacion = Transaccion.Nuevo;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            grbCuentaContable.Enabled = true;

            limpiarControles();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            eoperacion = Transaccion.Selecciona;
            if (dtgCuentaCtb.Rows.Count > 0)
            {
                btnEditar1.Enabled = true;
            }
            else
            {
                btnEditar1.Enabled = false;
            }

            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;

            grbCuentaContable.Enabled = false;
            dtgCuentaCtb.Enabled = true;

            limpiarControles();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            eoperacion = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = true;

            grbCuentaContable.Enabled = true;
            dtgCuentaCtb.Enabled = false;

            cargarDatosCuenta();           
        }
        
        private void dtgCuentaCtb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosCuenta();
        }

        private void dtgCuentaCtb_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatosCuenta();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idGrupoActivo = Convert.ToInt32(dtgCuentaCtb.SelectedRows[0].Cells["idGrupoActivo"].Value);
                string cDescripcion = txtDescripcion.Text.Trim();
                int idTipoOperacion = Convert.ToInt32(this.cboTipoOperacion1.SelectedValue);
                int idTipoIngresoEgreso = Convert.ToInt32(this.cboTipoTransaccion1.SelectedValue);
                int idTipoBien = Convert.ToInt32(this.cboTipoBien1.SelectedValue);
                int idDestino = Convert.ToInt32(this.cboDestino.SelectedValue);
                int idEstado = Convert.ToInt32(this.cboModalidadOperac.SelectedValue);
                string cDebe = txtDebe.Text.Trim();
                string cHaber = txtHaber.Text.Trim();

                cncatalogo.InsActCuentaCtbGrupoBien(idGrupoActivo, cDescripcion, idTipoOperacion, idTipoIngresoEgreso, idTipoBien,
                    idDestino, idEstado, cDebe, cHaber);

                MessageBox.Show("Los datos se guardaron correctamente", "Registro de cuenta contable", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                eoperacion = Transaccion.Selecciona;  
                cargarCuentasGrupo();
                btnGrabar1.Enabled = false;
                btnNuevo1.Enabled = true;
                btnCancelar1.PerformClick();
            }
        }

        private void btnDebe_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
            frmBscCtaCtb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
            txtDebe.Text = frmBscCtaCtb.pcCtaCtb;
        }

        private void btnHaber_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
            frmBscCtaCtb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
            txtHaber.Text = frmBscCtaCtb.pcCtaCtb;
        }

        #endregion

        #region Metodos

        private bool validar()
        {
            bool lVal = false;

            if (string.IsNullOrEmpty(txtDebe.Text))
            {
                MessageBox.Show("Debe de ingresar la cuenta del DEBE", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDebe.Focus();
                return lVal;
            }

            if (string.IsNullOrEmpty(this.txtHaber.Text))
            {
                MessageBox.Show("Debe de ingresar la cuenta del HABER", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHaber.Focus();
                return lVal;
            }

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Debe de ingresar descripción de la cuenta", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            if (ValidarCtaCtb(txtDebe.Text))
            {
                MessageBox.Show("La cuenta del DEBE tiene que ser del último nivel", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDebe.Focus();
                return lVal;
            }

            if (ValidarCtaCtb(txtHaber.Text))
            {
                MessageBox.Show("La cuenta del HABER tiene que ser del último nivel", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHaber.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }


        private Boolean ValidarCtaCtb(string pcCodCtb)
        {
            clsCtaContable objctactb = new clsCNCtaContable().detallectactb(pcCodCtb);
            if (objctactb.nHijos > 0)
            {
                return true;
            }
            if (string.IsNullOrEmpty(objctactb.cDescripcion))
            {
                return true;
            }
            return false;
        }

        private void limpiarControles()
        {
            foreach (Control item in grbCuentaContable.Controls)
            {
                if (item is TextBox && item.Name != "cboTipoBien1")
                {
                    item.Text = "";
                }
            }
        }

        private void cargarCuentasGrupo()
        {
            var idGrupoActivo = 0;
            dtCuentas = cncatalogo.RetornaCuentaCtbGrupoBien(idGrupoActivo);

            if (dtCuentas.Rows.Count > 0)
            {
                dtgCuentaCtb.DataSource = dtCuentas;
                formatoGridCuentas();

                btnEditar1.Enabled = true;
            }
            else
            {
                dtgCuentaCtb.DataSource = null;
                btnEditar1.Enabled = false;
            }
        }

        private void formatoGridCuentas()
        {
            foreach (DataGridViewColumn item in this.dtgCuentaCtb.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgCuentaCtb.Columns["cDebe"].Visible = true;
            dtgCuentaCtb.Columns["cHaber"].Visible = true;

            dtgCuentaCtb.Columns["cDescripcion"].Visible = true;
            dtgCuentaCtb.Columns["cTipoOperacion"].Visible = true;
            dtgCuentaCtb.Columns["cTipoBien"].Visible = true;
            dtgCuentaCtb.Columns["cTipoTransaccion"].Visible = true;
            dtgCuentaCtb.Columns["cDestino"].Visible = true;
            dtgCuentaCtb.Columns["cEstadoKardex"].Visible = true;

            dtgCuentaCtb.Columns["cDebe"].HeaderText = "DEBE";
            dtgCuentaCtb.Columns["cHaber"].HeaderText = "HABER";
            dtgCuentaCtb.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgCuentaCtb.Columns["cTipoOperacion"].HeaderText = "Operación";
            dtgCuentaCtb.Columns["cTipoBien"].HeaderText = "Tipo Bien";
            dtgCuentaCtb.Columns["cTipoTransaccion"].HeaderText = "Movimiento";
            dtgCuentaCtb.Columns["cDestino"].HeaderText = "Destino";
            dtgCuentaCtb.Columns["cEstadoKardex"].HeaderText = "Estado";

            dtgCuentaCtb.Columns["cDebe"].FillWeight = 10;
            dtgCuentaCtb.Columns["cHaber"].FillWeight = 10;
            dtgCuentaCtb.Columns["cDescripcion"].FillWeight = 30;
            dtgCuentaCtb.Columns["cTipoOperacion"].FillWeight = 14;
            dtgCuentaCtb.Columns["cTipoTransaccion"].FillWeight = 10;
            dtgCuentaCtb.Columns["cDestino"].FillWeight = 10;
            dtgCuentaCtb.Columns["cEstadoKardex"].FillWeight = 6;
            dtgCuentaCtb.Columns["cTipoBien"].FillWeight = 10;
        }

        private void cargarTipoOperacion()
        {
            cboTipoOperacion1.LisTipoOperacModulo(clsVarGlobal.idModulo);
        }

        private void cargarDestino()
        {
            DataTable dtDestino = new DataTable("dtDestino");
            dtDestino.Columns.Add("idDestino", typeof(int));
            dtDestino.Columns.Add("cDestino", typeof(string));

            var drDestino = dtDestino.NewRow();
            drDestino["idDestino"] = 1;
            drDestino["cDestino"] = "OPERATIVOS";

            dtDestino.Rows.Add(drDestino);

            cboDestino.DataSource = dtDestino;
            cboDestino.ValueMember = "idDestino";
            cboDestino.DisplayMember = "cDestino";

        }

        private void cargarDatosCuenta()
        {
            if (dtgCuentaCtb.SelectedRows.Count > 0)
            {
                var drCuenta = dtgCuentaCtb.SelectedRows[0];
                this.cboTipoOperacion1.SelectedValue = Convert.ToInt32(drCuenta.Cells["idTipoOperacion"].Value);
                this.cboTipoTransaccion1.SelectedValue = Convert.ToInt32(drCuenta.Cells["idTipoIngresoEgreso"].Value);
                this.cboTipoBien1.SelectedValue = Convert.ToInt32(drCuenta.Cells["idTipoBien"].Value);
                this.cboDestino.SelectedValue = Convert.ToInt32(drCuenta.Cells["idDestino"].Value);
                this.cboModalidadOperac.SelectedValue = Convert.ToInt32(drCuenta.Cells["idEstado"].Value);
                this.txtDescripcion.Text = drCuenta.Cells["cDescripcion"].Value.ToString().Trim();
                this.txtDebe.Text = drCuenta.Cells["cDebe"].Value.ToString().Trim();
                this.txtHaber.Text = drCuenta.Cells["cHaber"].Value.ToString().Trim();
            }
        }

        #endregion

        
    }
}

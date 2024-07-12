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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmActualizaDatosOpe : frmBase
    {
        private DataTable tbValoradosPendientes;
        clsCNValorados Valorizar = new clsCNValorados();


        public frmActualizaDatosOpe()
        {
            InitializeComponent();
        }

        private void frmActualizaDatosOpe_Load(object sender, EventArgs e)
        {
            CargarValorados();
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            cboTipoValorado.SelectedValue = 4;
            cboTipoValorado.Enabled = false;
            if (dtgValoradosPend.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                CargarDatos(0);
            }
            dtpFechaEmi.Value = clsVarGlobal.dFecSystem;
        }

        private void CargarValorados()
        {
            int x_idAgencia= Convert.ToInt16(cboAgencia.SelectedValue);

            tbValoradosPendientes = Valorizar.ListaValoradosPendActualizar(x_idAgencia);

            dtgValoradosPend.DataSource = tbValoradosPendientes;

            FormatoDgtValorados();


            if (dtgValoradosPend.Rows.Count > 0)
                dtgValoradosPend.CurrentCell = dtgValoradosPend.Rows[0].Cells[3];

        }

        private void FormatoDgtValorados()
        {

            dtgValoradosPend.Columns["idkardex"].Visible = false;
            dtgValoradosPend.Columns["idTipoValorado"].Visible = false;

            dtgValoradosPend.Columns["idMoneda"].Visible = false;
            dtgValoradosPend.Columns["cProducto"].Visible = false;
            dtgValoradosPend.Columns["IdProducto"].Visible = false;
            dtgValoradosPend.Columns["cTipoCuenta"].Visible = false;
            dtgValoradosPend.Columns["idTipoCuenta"].Visible = false;
            dtgValoradosPend.Columns["dFechaEmiDoc"].Visible = false;
            dtgValoradosPend.Columns["cTipoPersona"].Visible = false;

            dtgValoradosPend.Columns["cTipoOperacion"].Visible = false;
            dtgValoradosPend.Columns["dFechaOpe"].Visible = false;

            dtgValoradosPend.Columns["cValorado"].Width = 60;
            dtgValoradosPend.Columns["cValorado"].HeaderText = "Tipo de Valorado";
            dtgValoradosPend.Columns["cValorado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["NroDocAux"].Width = 80;
            dtgValoradosPend.Columns["NroDocAux"].HeaderText = "N° de Documento";
            dtgValoradosPend.Columns["NroDocAux"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["cNroDocumento"].Visible = false;

            dtgValoradosPend.Columns["cSerieDocumento"].Visible = false;

            dtgValoradosPend.Columns["nMontoOperacion"].Width = 60;
            dtgValoradosPend.Columns["nMontoOperacion"].HeaderText = "Monto a Valorizar";
            dtgValoradosPend.Columns["nMontoOperacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["nMontoCapital"].Visible = false;

            dtgValoradosPend.Columns["cNombreCorto"].Width = 150;
            dtgValoradosPend.Columns["cNombreCorto"].HeaderText = "Entidad Financiera";
            dtgValoradosPend.Columns["cNombreCorto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["dFechaReg"].Width = 100;
            dtgValoradosPend.Columns["dFechaReg"].HeaderText = "Fecha de Registro";
            dtgValoradosPend.Columns["dFechaReg"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["idAgencia"].Visible = false;

            dtgValoradosPend.Columns["cNombreAge"].Width = 110;
            dtgValoradosPend.Columns["cNombreAge"].HeaderText = "Agencia que Registró";
            dtgValoradosPend.Columns["cNombreAge"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgValoradosPend.Columns["idCuenta"].Width = 65;
            dtgValoradosPend.Columns["idCuenta"].HeaderText = "N° Cuenta";
            dtgValoradosPend.Columns["idCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarDatos(int r)
        {
            txtTipCuenta.Text = dtgValoradosPend.Rows[r].Cells["cTipoCuenta"].Value.ToString();
            txtProducto.Text = dtgValoradosPend.Rows[r].Cells["cProducto"].Value.ToString();
            cboMoneda.SelectedValue = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["idMoneda"].Value.ToString());
            txtFechaDocumento.Text = Convert.ToDateTime(dtgValoradosPend.Rows[r].Cells["dFechaEmiDoc"].Value).Date.ToString("dd/MM/yyyy");
            txtTipoPersona.Text = dtgValoradosPend.Rows[r].Cells["cTipoPersona"].Value.ToString();

            txtNroOpe.Text = dtgValoradosPend.Rows[r].Cells["idkardex"].Value.ToString();
            txtTipoOpe.Text = dtgValoradosPend.Rows[r].Cells["cTipoOperacion"].Value.ToString();
            txtFecOpe.Text = Convert.ToDateTime(dtgValoradosPend.Rows[r].Cells["dFechaOpe"].Value).Date.ToString("dd/MM/yyyy");
        }

        private void HabDesabilitaCtrls(bool Val)
        {
            dtpFechaEmi.Enabled = Val;
            txtNroDocu.Enabled = Val;
            txtSerie.Enabled = Val;
        }

        private void LimpiarCtrls()
        {
            dtpFechaEmi.Value = clsVarGlobal.dFecSystem;
            txtNroDocu.Clear();
            txtSerie.Clear();
        }
        private bool ValidarDatos()
        {
            if (dtpFechaEmi.Value>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha de emisión, no puede ser posterior a la fecha del sistema...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaEmi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNroDocu.Text))
            {
                MessageBox.Show("Debe registrar el número de operación...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroDocu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Debe registrar el número de serie de la operación...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSerie.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNroOpe.Text))
            {
                MessageBox.Show("El número de operación no es válido...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaEmi.Focus();
                return false;
            }
            return true;
        }

        private void dtgValoradosPend_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            CargarDatos(r);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgValoradosPend.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Datos para modificar...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LimpiarCtrls();
            HabDesabilitaCtrls(true);
            dtpFechaEmi.Focus();
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            cboAgencia.Enabled = false;
            dtgValoradosPend.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCtrls();
            HabDesabilitaCtrls(false);
            dtgValoradosPend.Focus();
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            cboAgencia.Enabled = true;
            dtgValoradosPend.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            
            int filaseleccionada = Convert.ToInt32(this.dtgValoradosPend.CurrentRow.Index);

            int x_idKardex = Convert.ToInt32(dtgValoradosPend.Rows[filaseleccionada].Cells["idkardex"].Value);
            int x_idCuenta = Convert.ToInt32(dtgValoradosPend.Rows[filaseleccionada].Cells["idCuenta"].Value);
            string cNroDoc=txtNroDocu.Text,
                cSerieDoc=txtSerie.Text;
            //---------------------------------------------------------------------------
            //---Actualizar Datos de la Operación
            //---------------------------------------------------------------------------
            DataTable tbActDatos = Valorizar.ActualizarDatosOperacion(x_idKardex, x_idCuenta, dtpFechaEmi.Value, cNroDoc, cSerieDoc,clsVarGlobal.dFecSystem,clsVarGlobal.User.idUsuario);
            if (Convert.ToInt16(tbActDatos.Rows[0]["idRpta"]) == 0)
            {
                MessageBox.Show(tbActDatos.Rows[0]["cMensaje"].ToString(), "Actualización de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbActDatos.Rows[0]["cMensaje"].ToString(), "Actualización de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            HabDesabilitaCtrls(false);
            LimpiarCtrls();
            CargarValorados();
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            cboAgencia.Enabled = true;
            dtgValoradosPend.Enabled = true;
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarValorados();
        }

    }
}

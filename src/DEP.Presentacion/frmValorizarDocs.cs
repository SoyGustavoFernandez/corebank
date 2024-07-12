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
    public partial class frmValorizarDocs : frmBase
    {
        private DataTable tbValoradosPendientes;
        clsCNValorados Valorizar = new clsCNValorados();
        int idTipoValorados = 0;
        int IdProducto = 0;
        int idTipoPesona = 0;
        int idAgencia = 0;
        public frmValorizarDocs()
        {
            InitializeComponent();
        }

        private void frmValorizarDocs_Load(object sender, EventArgs e)
        {
            CargarValorados();
            cboAgencia.SelectedIndex = -1;
            cboTipoValorado.SelectedIndex = 0;
            cboTipoValorado.Enabled = false;
            if (dtgValoradosPend.Rows.Count > 0)
            {
                CardarDatos(0);
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarValores();
            if (cboAgencia.SelectedIndex > 0)
            {
                int idAgen = Convert.ToInt32(this.cboAgencia.SelectedValue);
                tbValoradosPendientes.DefaultView.RowFilter = ("idAgencia = '" + idAgen + "'");
            }
            else
            {
                tbValoradosPendientes.DefaultView.RowFilter = String.Empty;
                rbtAceptValorado.Checked = false;
                rbtRechazaValord.Checked = false;
                cboTipoComision.SelectedIndex = -1;
                txtComision.Clear();
            }
        }
        private void cboTipoValorado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            limpiarValores();
            if (cboTipoValorado.SelectedIndex >= 0)
            {

                int idTipVal = Convert.ToInt32(this.cboTipoValorado.SelectedValue);
                tbValoradosPendientes.DefaultView.RowFilter = ("idTipoValorado = '" + idTipVal + "'");
            }
            else
            {
                tbValoradosPendientes.DefaultView.RowFilter = String.Empty;
                rbtAceptValorado.Checked = false;
                rbtRechazaValord.Checked = false;
                cboTipoComision.SelectedIndex = -1;
                txtComision.Clear();
            }
        }

        private void CargarValorados()
        {

            clsCNValorados ListaValorados = new clsCNValorados();
            tbValoradosPendientes = ListaValorados.ListaValoradosPend();

            if (dtgValoradosPend.ColumnCount > 0)
            {
                //dtgValoradosPend.Columns.Remove("idkardex");
                //dtgValoradosPend.Columns.Remove("idTipoValorado");
                //dtgValoradosPend.Columns.Remove("cValorado");
                //dtgValoradosPend.Columns.Remove("NroDocAux");
                //dtgValoradosPend.Columns.Remove("cNroDocumento");
                //dtgValoradosPend.Columns.Remove("cSerieDocumento");
                //dtgValoradosPend.Columns.Remove("nMontoOperacion");
                //dtgValoradosPend.Columns.Remove("nMontoCapital");
                //dtgValoradosPend.Columns.Remove("cNombreCorto");
                //dtgValoradosPend.Columns.Remove("dFechaReg");
                //dtgValoradosPend.Columns.Remove("idAgencia");
                //dtgValoradosPend.Columns.Remove("cNombreAge");
                //dtgValoradosPend.Columns.Remove("idCuenta");
                //dtgValoradosPend.Columns.Remove("idMoneda");

                //dtgValoradosPend.Columns.Remove("cProducto");
                //dtgValoradosPend.Columns.Remove("IdProducto");
                //dtgValoradosPend.Columns.Remove("cTipoCuenta");
                //dtgValoradosPend.Columns.Remove("idTipoCuenta");
                //dtgValoradosPend.Columns.Remove("dFechaEmiDoc");
            }


            int n = 0;
            foreach (DataRow fila in tbValoradosPendientes.Rows)
            {
                n += 1;
                if (Convert.ToString(tbValoradosPendientes.Rows[n - 1]["cSerieDocumento"]).Trim() != "")
                    tbValoradosPendientes.Rows[n - 1]["NroDocAux"] = Convert.ToString(tbValoradosPendientes.Rows[n - 1]["cSerieDocumento"]).Trim().PadLeft(7, '0') + " - " + Convert.ToString(tbValoradosPendientes.Rows[n - 1]["cNroDocumento"]).Trim().PadLeft(8, '0');
                else
                    tbValoradosPendientes.Rows[n - 1]["NroDocAux"] = Convert.ToString(tbValoradosPendientes.Rows[n - 1]["cNroDocumento"]).Trim().PadLeft(8, '0');
            }

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

            dtgValoradosPend.Columns["cValorado"].Width = 50;
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
        private string ValidarDatos()
        {

            if (dtgValoradosPend.Rows.Count == 0)
            {
                MessageBox.Show("No existe ningún Valorado Pendiente ", "Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }
            if (txtMotivo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el Motivo de Aceptación o Rechazo del Valorado ", "Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivo.Focus();
                return "ERROR";
            }
            if (txtMotivo.Text.Trim().Length < 11)
            {
                MessageBox.Show("La descripción del Motivo de Aceptación o Rechazo del Valorado debe tener como mínimo 10 caracteres ", "Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivo.Focus();
                return "ERROR";
            }
            if (rbtAceptValorado.Checked == false && rbtRechazaValord.Checked == false)
            {
                MessageBox.Show("Debe elegir si se acepta o rechaza el valorado.", "Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }
            //if (cboTipoComision.Items.Count <= 0)
            //{
            //    MessageBox.Show(" No existe comisión para el valorado...\n Debe de configurar en el módulo de administración", "Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return "ERROR";
            //}
            return "OK";


        }

        private void rbtAceptValorado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAceptValorado.Checked)
            {
                lblMotivo.Text = "Motivo de aceptación : ";
                //idTipoOperacion = 119;
                cargarPlaza();
            }
        }

        private void rbtRechazaValord_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRechazaValord.Checked)
            {
                lblMotivo.Text = "Motivo de rechazo : ";
                //idTipoOperacion = 102;
                cargarPlaza();
            }
        }

        private void dtgValoradosPend_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            CardarDatos(r);
        }
        private void CardarDatos(int r)
        {
            txtTipCuenta.Text = dtgValoradosPend.Rows[r].Cells["cTipoCuenta"].Value.ToString();
            txtProducto.Text = dtgValoradosPend.Rows[r].Cells["cProducto"].Value.ToString();
            cboMoneda.SelectedValue = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["idMoneda"].Value.ToString());
            txtFechaDocumento.Text = Convert.ToDateTime(dtgValoradosPend.Rows[r].Cells["dFechaEmiDoc"].Value).Date.ToString("dd/MM/yyyy");
            IdProducto = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["IdProducto"].Value.ToString());
            idTipoPesona = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["IdProducto"].Value.ToString());
            idAgencia = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["idAgencia"].Value.ToString());
            txtTipoPersona.Text = dtgValoradosPend.Rows[r].Cells["cTipoPersona"].Value.ToString();
            idTipoValorados = Convert.ToInt32(dtgValoradosPend.Rows[r].Cells["idTipoValorado"].Value.ToString());
            txtComision.Text = "0.00";
            cargarPlaza();

        }

        private void limpiarValores()
        {
            txtTipCuenta.Clear();
            txtProducto.Clear();
            cboMoneda.SelectedIndex = -1;
            txtFechaDocumento.Clear();
            txtTipoPersona.Clear();
            rbtRechazaValord.Checked = false;
            rbtAceptValorado.Checked = false;
            cboTipoComision.SelectedIndex =-1;
            txtComision.Clear();
            txtMotivo.Clear();
        }
        private void cargarPlaza()
        {
            int idConcepto = 0;
            if (clsVarGlobal.nIdAgencia == idAgencia)
            {
                idConcepto = 73;
            }
            else
            {
                idConcepto = 9;
            }
            bool lAprobar;
            if (!rbtAceptValorado.Checked && !rbtRechazaValord.Checked)
            {
                return;
            }
            lAprobar = rbtAceptValorado.Checked;

            DataTable dtTipoPlaza = Valorizar.CNListarPlaza(IdProducto, idTipoValorados, lAprobar, clsVarGlobal.nIdAgencia, idConcepto);
            cboTipoComision.DataSource = dtTipoPlaza;
            cboTipoComision.ValueMember = "idConcepto";
            cboTipoComision.DisplayMember = "cConcepto";
            if (dtTipoPlaza.Rows.Count <= 0)
            {
                txtComision.Text = "0.00";
                return;
            }
            txtComision.Text = dtTipoPlaza.Rows[0]["nValorAplica"].ToString();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            int filaseleccionada = Convert.ToInt32(this.dtgValoradosPend.CurrentRow.Index);
            bool idAceptRechaza=true;
            if (rbtAceptValorado.Checked)
            {
                idAceptRechaza=true;
            }
            if (rbtRechazaValord.Checked)
            {
                 idAceptRechaza=false;
            }

            decimal nMontoComision = Convert.ToDecimal(txtComision.Text);

            int idKarde = Convert.ToInt32(dtgValoradosPend.Rows[filaseleccionada].Cells["idkardex"].Value);
            int idCuenta = Convert.ToInt32(dtgValoradosPend.Rows[filaseleccionada].Cells["idCuenta"].Value);
            decimal nMontoCapital = Convert.ToDecimal(dtgValoradosPend.Rows[filaseleccionada].Cells["nMontoCapital"].Value);
            int idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            string cMotivo = txtMotivo.Text;
            string cNroDocumento = Convert.ToString(dtgValoradosPend.Rows[filaseleccionada].Cells["cNroDocumento"].Value);
            string cSerieDocumento = Convert.ToString(dtgValoradosPend.Rows[filaseleccionada].Cells["cSerieDocumento"].Value);
            int idConcepto = Convert.ToInt32(cboTipoComision.SelectedValue);//tipo de comision
            DataTable dtRsultado = Valorizar.ValorizarValPend(idAceptRechaza, idKarde, idCuenta, nMontoCapital, idUsuario, clsVarGlobal.dFecSystem, cMotivo, cNroDocumento, cSerieDocumento, nMontoComision, clsVarGlobal.nIdAgencia,
                                                                    idTipoValorados, idConcepto);
            if (dtRsultado.Rows[0]["nResp"].ToString().Equals("1"))
            {
                if (rbtAceptValorado.Checked)
                {
                    MessageBox.Show(dtRsultado.Rows[0]["mResp"].ToString(), "Aceptar Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rbtRechazaValord.Checked)
                {
                    MessageBox.Show("El Valorado ha sido Rechazado...", "Rechazar Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (rbtAceptValorado.Checked)
                {
                    MessageBox.Show(dtRsultado.Rows[0]["mResp"].ToString(), "Aceptar Valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (rbtRechazaValord.Checked)
                {
                    MessageBox.Show(dtRsultado.Rows[0]["mResp"].ToString(), "Rechazar Valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            txtMotivo.Text = "";
            txtComision.Text = "0.00";
            CargarValorados();
        }
    }
}

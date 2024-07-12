using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBusCtaAho : frmBase
    {
        #region Variables

        public int idCli, idMon, pTipBus=0, nTipOpe, idestado=1;  //Parametros de Ingreso        
        public string pnCta, pcNroCta, pcEstdo, pcProd, pnMonDisp, pcNomCli;
        public int idProducto;

        #endregion

        public frmBusCtaAho()
        {            
            InitializeComponent();
        }

        #region Eventos

        private void frmBusCtaAho_Load(object sender, EventArgs e)
        {
            if (nTipOpe == 9)
            {
                idestado = 4;
            }
            CargarDatos(idCli, idestado, idMon, nTipOpe);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgCtasAho.RowCount > 0)
            {
                pnCta = dtgCtasAho.SelectedRows[0].Cells["idNum"].Value.ToString();
                pcNroCta = dtgCtasAho.SelectedRows[0].Cells["cNroCuenta"].Value.ToString();
                pcEstdo = dtgCtasAho.SelectedRows[0].Cells["cEstado"].Value.ToString();
                pcProd = dtgCtasAho.SelectedRows[0].Cells["cProducto"].Value.ToString();
                pnMonDisp = dtgCtasAho.SelectedRows[0].Cells["nMonto"].Value.ToString();
                pcNomCli = dtgCtasAho.SelectedRows[0].Cells["cNomCli"].Value.ToString();
                idMon = Convert.ToInt32(dtgCtasAho.SelectedRows[0].Cells["idMoneda"].Value.ToString());
                idProducto = Convert.ToInt32(dtgCtasAho.SelectedRows[0].Cells["IdProducto"].Value.ToString());
            }
            else
            {
                idCli = 0;
                pnCta = "";
                pcNroCta = "";
                pcEstdo = "";
                pnMonDisp = "";
                pnMonDisp = "";
                idMon = 0;
                pcNomCli = "";
            }

            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            idCli = 0;
            pnCta = "";
            pcNroCta = "";
            pcEstdo = "";
            pnMonDisp = "";
            pnMonDisp = "";
            idMon = 0;
            pcNomCli = "";
        }

        private void dtgCtasAho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dtgCtasAho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                btnCopiarCuenta.PerformClick();
            }
        }

        #endregion

        #region Metodos

        private void CargarDatos(int nIdCliente, int nEstadoCta, int idMon, int x_nTipOpe)
        {
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(nIdCliente, nEstadoCta, idMon, x_nTipOpe);
            if (dtgCtasAho.Columns.Count > 0)
            {
                dtgCtasAho.Columns.Clear();
            }
            dtgCtasAho.DataSource = dtbNumCuentas;
            this.formatoGrid();
            ColorFilasGrid();
        }

        public void formatoGrid()
        {
            //dtgCtasAho.Columns["cNroCuenta"].Visible = false;
            dtgCtasAho.Columns["cNombre"].Visible = false;
            dtgCtasAho.Columns["idCli"].Visible = false;
            dtgCtasAho.Columns["cCodCliente"].Visible = false;
            dtgCtasAho.Columns["cDocumentoID"].Visible = false;
            dtgCtasAho.Columns["idMoneda"].Visible = false;
            dtgCtasAho.Columns["nidTipoPersona"].Visible = false;
            dtgCtasAho.Columns["cNomCli"].Visible = false;
            dtgCtasAho.Columns["nMonto"].Visible = false;
            dtgCtasAho.Columns["IdProducto"].Visible = false;
            dtgCtasAho.Columns["idTipoDocumento"].Visible = false;
            dtgCtasAho.Columns["cDireccion"].Visible = false;
            dtgCtasAho.Columns["cTelefono"].Visible = false;

            dtgCtasAho.Columns["idNum"].HeaderText = "Cod.Cuenta";
            dtgCtasAho.Columns["cNroCuenta"].HeaderText = "N°Cuenta";
            dtgCtasAho.Columns["cEstado"].HeaderText = "Estado";
            dtgCtasAho.Columns["Fecha_Desembolso"].HeaderText = "Fec.Apertura";
            dtgCtasAho.Columns["cProducto"].HeaderText = "Producto";
            dtgCtasAho.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCtasAho.Columns["cTipoCuenta"].HeaderText = "Tipo Cuenta";
            dtgCtasAho.Columns["idCuentaRel"].HeaderText = "Cuenta Relacionada";

            dtgCtasAho.Columns["idNum"].Width = 70;
            dtgCtasAho.Columns["cNroCuenta"].Width = 160;
            dtgCtasAho.Columns["cEstado"].Width = 70;
            dtgCtasAho.Columns["Fecha_Desembolso"].Width = 75;
            dtgCtasAho.Columns["cProducto"].Width = 150;
            dtgCtasAho.Columns["cMoneda"].Width = 85;
            dtgCtasAho.Columns["cTipoCuenta"].Width = 110;
            dtgCtasAho.Columns["idCuentaRel"].Width = 70;

            dtgCtasAho.Columns["idNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgCtasAho.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgCtasAho.Columns["nMonto"].DefaultCellStyle.Format = "N2";
            dtgCtasAho.Columns["Fecha_Desembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCtasAho.Columns["cTipoCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCtasAho.Columns["idCuentaRel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ColorFilasGrid()
        {
            foreach (DataGridViewRow row in dtgCtasAho.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private void btnCopiarCuenta_Click(object sender, EventArgs e)
        {
            if (this.dtgCtasAho.RowCount > 0)
            {
                try
                {
                    Clipboard.SetDataObject(Convert.ToString(dtgCtasAho.SelectedRows[0].Cells["cNroCuenta"].Value), true);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error, debe seleccionar un registro: " +
                        Environment.NewLine + err.Message, "Error al copiar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        #endregion

    }
}

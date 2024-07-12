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
    public partial class frmBusCtaAhoVinculacion : frmBase
    {
        #region Variables

        public int idCli, idMon, pTipBus = 0, nTipOpe, idestado = 1;  //Parametros de Ingreso        
        public string pnCta, pcNroCta, pcEstdo, pcProd, pnMonDisp, pcNomCli;
        public bool lCuentaAutomatica { get; set; }
        public string cNroCuentaVinculada { get; set; }
        public int idCuentaVinculada { get; set; }
        public bool lHabilitarSeleccion { get; set; }
        public bool lSeleccion { get; set; }

        public int idProducto;
        public int idTipoPersona { get; set; }
        

        #endregion

        public frmBusCtaAhoVinculacion()
        {
            InitializeComponent();
            CargarValoresPorDefecto();
        }

        private void frmBusCtaAhoVinculacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bool lCancelarCierre = false;
            if (lCuentaAutomatica == false && String.IsNullOrEmpty(pnCta) && idCuentaVinculada == 0)//
            {
                DialogResult drResult = MessageBox.Show("No seleccionó una cuenta, ¿Está seguro de salir?", "Vincular Cuenta Ahorro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                lCancelarCierre = (drResult == DialogResult.Yes) ? false : true ;
                lCuentaAutomatica = (drResult == DialogResult.Yes) ? false : true;
            }
            e.Cancel = lCancelarCierre;
        }

        #region Eventos

        private void frmBusCtaAhoVinculacion_Load(object sender, EventArgs e)
        {
            if (nTipOpe == 9)
            {
                idestado = 4;
            }
            CargarDatos(idCli, idestado, idMon, nTipOpe);
            if (idCuentaVinculada != 0)
            {
                lblCuentaVinculada.Visible      = true;
                lblNroCuentaVinculada.Visible   = true;
                lblNroCuentaVinculada.Text      = cNroCuentaVinculada;
            }
            else
            {
                lblCuentaVinculada.Visible = false;
                lblNroCuentaVinculada.Visible = false;
                lblNroCuentaVinculada.Text = String.Empty;
            }

            if(idTipoPersona == 2 || idTipoPersona == 3)
            {
                btnMiniNuevo.Enabled = false;
            }
            else
            {
                btnMiniNuevo.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgCtasAho.RowCount > 0)
            {
                int idCuentaTemporal = Convert.ToInt32(dtgCtasAho.SelectedRows[0].Cells["idNum"].Value);
                if (idCuentaVinculada == 0 && idCuentaVinculada != idCuentaTemporal)
                {
                    DialogResult drResult = MessageBox.Show("El desembolso se vinculara con la cuenta seleccionada, ¿Está seguro de continuar?", "Vincular Cuenta Ahorro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }

                pnCta = dtgCtasAho.SelectedRows[0].Cells["idNum"].Value.ToString();
                pcNroCta = dtgCtasAho.SelectedRows[0].Cells["cNroCuenta"].Value.ToString();
                pcEstdo = dtgCtasAho.SelectedRows[0].Cells["cEstado"].Value.ToString();
                pcProd = dtgCtasAho.SelectedRows[0].Cells["cProducto"].Value.ToString();
                pnMonDisp = dtgCtasAho.SelectedRows[0].Cells["nMonto"].Value.ToString();
                pcNomCli = dtgCtasAho.SelectedRows[0].Cells["cNomCli"].Value.ToString();
                idMon = Convert.ToInt32(dtgCtasAho.SelectedRows[0].Cells["idMoneda"].Value.ToString());
                idProducto = Convert.ToInt32(dtgCtasAho.SelectedRows[0].Cells["IdProducto"].Value.ToString());
                lSeleccion = true;
                
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
                lSeleccion = false;
            }

            this.Dispose();
        }
        private void btnMiniNuevo_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("Se procedera a crear una cuenta automatica, ¿Está seguro de continuar?", "Vincular Cuenta Ahorro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(drResult == DialogResult.No)
            {
                return;
            }

            idCli = 0;
            pnCta = "";
            pcNroCta = "";
            pcEstdo = "";
            pnMonDisp = "";
            pnMonDisp = "";
            idMon = 0;
            pcNomCli = "";
            lCuentaAutomatica = true;
            lSeleccion = false;

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
            lSeleccion = false;
        }

        private void dtgCtasAho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }

        #endregion

        #region Metodos
        private void CargarValoresPorDefecto()
        {
            lCuentaAutomatica       = false;
            cNroCuentaVinculada     = String.Empty;
            idCuentaVinculada       = 0;
            lHabilitarSeleccion     = false;

            lSeleccion              = false;
        }
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

        #endregion
    }
}

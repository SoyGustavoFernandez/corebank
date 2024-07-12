using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class FrmCobroMasivo : frmBase
    {
        private DataTable dtLisCrexAna;
        int nIdAse = -1;

        public FrmCobroMasivo()
        {
            InitializeComponent();
        }

        private void FrmCobroMasivo_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            //--Validar si ya Realizó su corte Fraccionario
            if (ValidarCorteFracc() == "ERROR")
            {
                this.Dispose();
                return;
            }
        }

        private string ValidarCorteFracc()
        {
            string cRpta = "OK";
            string msge = "";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFracc(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge);
            if (msge == "OK")
            {
                if (cCorFra == "0")
                {
                    MessageBox.Show("Primero debe Realizar su Corte Fraccionario... por Favor..", "Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cRpta = "ERROR";
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        public void FormatoGrid()
        {
            dtgBase1.Columns["nCuotasVen"].Visible = false;
            this.dtgBase1.Columns["idCli"].Visible = false;
            this.dtgBase1.Columns["idUsuario"].Visible = false;
            this.dtgBase1.Columns["idAgencia"].Visible = false;


            dtgBase1.Columns["lSeleCta"].Width = 20;
            dtgBase1.Columns["idCuenta"].Width = 40;
            dtgBase1.Columns["cNombre"].Width = 150;
            dtgBase1.Columns["nAtraso"].Width = 30;
            dtgBase1.Columns["nCuoPen"].Width = 30;
            dtgBase1.Columns["nAtrCuoPen"].Width = 30;
            dtgBase1.Columns["nFechProg"].Width = 50;
            dtgBase1.Columns["nSaldoTot"].Width = 50;
            dtgBase1.Columns["nSalAPagar"].Width = 50;
            dtgBase1.Columns["nSalMora"].Width = 50;
            dtgBase1.Columns["nMonPagCuota"].Width = 50;
            dtgBase1.Columns["nMonPagMora"].Width = 50;
            dtgBase1.Columns["nNumeroTelefono"].Width = 150;

            dtgBase1.Columns["lSeleCta"].HeaderText ="Sel." ;
            dtgBase1.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["nMonCuoIni"].HeaderText = "Cuota Ini.";
            dtgBase1.Columns["nAtraso"].HeaderText = "Atr.Cre";
            dtgBase1.Columns["nCuoPen"].HeaderText = "Cuo.Pend";
            dtgBase1.Columns["nAtrCuoPen"].HeaderText = "Atr.Cuo";
            dtgBase1.Columns["nFechProg"].HeaderText = "Fec.Prog";
            dtgBase1.Columns["nSaldoTot"].HeaderText = "Sal.Tot.Cre";
            dtgBase1.Columns["nSalAPagar"].HeaderText = "Sal.Cuo";
            dtgBase1.Columns["nSalMora"].HeaderText = "Sal.Mora";
            dtgBase1.Columns["nMonPagCuota"].HeaderText = "Pago Cuota";
            dtgBase1.Columns["nMonPagMora"].HeaderText = "Pago Mora";
            dtgBase1.Columns["nNumeroTelefono"].HeaderText = "Teléfono";
            dtgBase1.Columns["nMonPagCuota"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgBase1.Columns["nMonPagCuota"].DefaultCellStyle.ForeColor = Color.White;
            dtgBase1.Columns["nMonPagMora"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgBase1.Columns["nMonPagMora"].DefaultCellStyle.ForeColor = Color.White;
        }
        public void HabilitarGrid(Boolean bVal)
        {
            this.dtgBase1.ReadOnly = !bVal;
           
            this.dtgBase1.Columns["lSeleCta"].ReadOnly = !bVal;

            this.dtgBase1.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgBase1.Columns["cNombre"].ReadOnly = bVal;
            this.dtgBase1.Columns["nAtraso"].ReadOnly = bVal;
            this.dtgBase1.Columns["nCuoPen"].ReadOnly = bVal;
            this.dtgBase1.Columns["nAtrCuoPen"].ReadOnly = bVal;
            this.dtgBase1.Columns["nFechProg"].ReadOnly = bVal;
            this.dtgBase1.Columns["nSaldoTot"].ReadOnly = bVal ;
            this.dtgBase1.Columns["nSalAPagar"].ReadOnly = bVal;
            this.dtgBase1.Columns["nSalMora"].ReadOnly = bVal;
            this.dtgBase1.Columns["nMonPagCuota"].ReadOnly = !bVal;
            this.dtgBase1.Columns["nMonPagMora"].ReadOnly = !bVal;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            Int32 nIdAsesor = Convert.ToInt32(this.cboPersonalCreditos1.SelectedValue.ToString());
            clsCNCredito Credito = new clsCNCredito();
            dtLisCrexAna = Credito.LisCrexAna(nIdAsesor, clsVarGlobal.User.idUsuario);
            this.txtNumRea4.Text = dtLisCrexAna.Rows.Count.ToString();
            if (dtLisCrexAna.Rows.Count <= 0)
            {
                MessageBox.Show("El Asesor no tiene créditos asignados", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtLisCrexAna.Columns["nMonPagCuota"].ReadOnly = false;
            dtLisCrexAna.Columns["nMonPagMora"].ReadOnly = false;
            dtLisCrexAna.Columns["lSeleCta"].ReadOnly = false;

            nIdAse = nIdAsesor;
            
            dtgBase1.DataSource = dtLisCrexAna;
            this.dtgBase1.Enabled = true;
            this.dtgBase1.ReadOnly = false;
            this.FormatoGrid();
            this.HabilitarGrid(true);
            this.cboPersonalCreditos1.Enabled = false;
            //this.cboMoneda1.Enabled = false;
            if (dtLisCrexAna.Rows.Count > 0)
            {
                this.btnGrabar1.Enabled = true;
            }            
            this.btnCancelar1.Enabled = true;
            this.btnProcesar1.Enabled = false;

            this.txtNumRea1.Visible = false;
            this.txtNumRea2.Visible = false;
            this.txtNumRea3.Visible = false;
            this.txtNumRea5.Visible = false;

            //Restringir la cantidad de dígitos a 10
            ((DataGridViewTextBoxColumn)dtgBase1.Columns["nMonPagCuota"]).MaxInputLength = 9;
            ((DataGridViewTextBoxColumn)dtgBase1.Columns["nMonPagMora"]).MaxInputLength  = 9;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtgBase1.Enabled = false;
            this.dtgBase1.ReadOnly = true;
            this.cboPersonalCreditos1.Enabled = true;
            //this.cboMoneda1.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.btnProcesar1.Enabled = true;
            this.dtgBase1.DataSource = "";
            this.txtNumRea4.Text = "";
            this.txtNumRea1.Text = "";
            this.txtNumRea2.Text = "";
            this.txtNumRea3.Text = "";
            this.txtNumRea5.Text = "";

            this.txtNumRea1.Visible = true;
            this.txtNumRea2.Visible = true;
            this.txtNumRea3.Visible = true;
            this.txtNumRea5.Visible = true;
            LiberarCuenta();
        }

        private void dtgBase1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);
            dtgBase1.CurrentCell = dtgBase1.Rows[fila].Cells["nMonPagCuota"];
            Decimal nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nSaldoTot"]);
            Decimal nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nMonPagCuota"]);
            if (nPagaDeuda > nTotDeuda)
            {
                dtgBase1.CurrentCell = dtgBase1.Rows[fila].Cells["nMonPagCuota"];
                MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nSalMora"]);
            nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nMonPagMora"]);
            if (nPagaDeuda > nTotDeuda)
            {
                dtgBase1.CurrentCell = dtgBase1.Rows[fila].Cells["nMonPagMora"];
                MessageBox.Show("Monto a pagar de Mora no puede superar a la deuda de Mora", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            SumaPagos();
           
        }
     
        private void SumaPagos()
        {
            Decimal nTotPagadoCuo = 0;
            Decimal nTotPagadoMora = 0;
            int nNumCrePagados = 0;
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (lSeleCta)
                {
                    //dtgBase1.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                    nTotPagadoCuo += Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                    nTotPagadoMora += Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagMora"]);
                    if ((Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]) + Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagMora"])) > 0.00m)
                    {
                        nNumCrePagados++;
                    }
                }
                else
                {
                    //dtgBase1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            this.txtNumRea1.Text = nTotPagadoCuo.ToString();
            this.txtNumRea2.Text = nTotPagadoMora.ToString();
            this.txtNumRea3.Text = (nTotPagadoCuo + nTotPagadoMora).ToString();
            this.txtNumRea5.Text = nNumCrePagados.ToString();
        }
        private bool validapago()
        {
            bool lvalida = true;
            Decimal nTotDeuda = 0.00m;
            Decimal nPagaDeuda = 0.00m;
            
            if (this.txtNumRea3.Text.Trim() == "" || Convert.ToDecimal (this.txtNumRea3.Text) <= 0)
            {
                MessageBox.Show("No hay montos a ser pagados", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nSaldoTot"]);
                nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                if (nPagaDeuda > nTotDeuda)
                {
                    MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                   
                    dtgBase1.CurrentCell = dtgBase1.Rows[i].Cells["nMonPagCuota"];
                    lvalida = false;
                    break;
                }
                nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nSalMora"]);
                nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagMora"]);
                if (nPagaDeuda > nTotDeuda)
                {
                    MessageBox.Show("Monto a pagar de Mora no puede superar a la deuda de Mora", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Seleccionar la celda errada
                    dtgBase1.CurrentCell = dtgBase1.Rows[i].Cells["nMonPagMora"];
                    lvalida = false;
                    break;
                }               
            }
            return lvalida;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable dtPlanPago = new DataTable("dtPlanPago");
            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            Decimal nPagaMora = 0.00m;
            Decimal nPagaDeuda = 0.00m;
            int nNumCredito = 0;

            if (!validapago())
            {
                return;
            }
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nPagaMora = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagMora"]);
                nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                if ((nPagaMora + nPagaDeuda) <= 0)
                {
                    continue;
                }
                nNumCredito = Convert.ToInt32(dtLisCrexAna.Rows[i]["idCuenta"]);
                dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
                if (nPagaDeuda + nPagaMora > 0)
                {
                    dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nPagaDeuda, false);
                    DataSet ds = new DataSet("dsPlanPagos");
                    ds.Tables.Add(dtPlanPago);
                    string xmlPpg = ds.GetXml();
                    Decimal nMonRedondeo = 0.00m;
                    Decimal nImpuesto    = 0.00m;
                    decimal nITFNormal   = 0.00m;
                    int idTipPago = 1, idEntidad = 0, idCtaEntidad = 0;
                    string cNroTrx = "";
                    //DataTable TablaUpPpg = PlanPago.UpCobroPpg(xmlPpg, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nPagaMora, nNumCredito, clsVarGlobal.idCanal, nMonRedondeo, nImpuesto, nITFNormal, idTipPago, idEntidad, idCtaEntidad, cNroTrx,idMotivoOperacion);
                    //MessageBox.Show("Cobro satisfactorio con kardesx N°: " + TablaUpPpg.Rows[0][0].ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Dispose();            
                }
            }
            MessageBox.Show("Cobro en Lote Realizado Satisfactoriamente", "Cobro en Lote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnGrabar1.Enabled = false;
            this.txtNumRea1.Visible = true;
            this.txtNumRea2.Visible = true;
            this.txtNumRea3.Visible = true;
            this.txtNumRea5.Visible = true;

        }

        private void dtgBase1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void cboPersonalCreditos1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LiberarCuenta()
        {
            if (nIdAse != -1)
            {
                new clsCNCredito().DesbMasByAse(nIdAse, clsVarGlobal.User.idUsuario);
            }
            //if (cboPersonalCreditos1.SelectedItem != null )
            //{
            //    new clsCNCredito().DesbMasByAse(Convert.ToInt32(cboPersonalCreditos1.SelectedValue), clsVarGlobal.User.idUsuario);
            //}
        }

        private void FrmCobroMasivo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        private void dtgBase1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}

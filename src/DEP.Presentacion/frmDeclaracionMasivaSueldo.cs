using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace DEP.Presentacion
{
    public partial class frmDeclaracionMasivaSueldo : frmBase
    {
        private clsCNDeposito Deposito = new clsCNDeposito();
        private DataTable dtCtasCtsEmpleador;

        public frmDeclaracionMasivaSueldo()
        {
            InitializeComponent();
            cboPeriodoCTS.cargarPeriodoCTS(clsVarGlobal.dFecSystem);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            int nIdUsuario = clsVarGlobal.User.idUsuario;
            int idEmpleador = conBusCli1.idCli;
            if (idEmpleador==0)
            {
                MessageBox.Show("Debe elegir una empresa con cuenta CTS vigentes", "Declaración Masiva de Remuneraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtCtasCtsEmpleador = Deposito.CNListaCtasCtsEmpleador(idEmpleador, 0, nIdUsuario, false);
            txtNumCtas.Text = dtCtasCtsEmpleador.Rows.Count.ToString();

            if (dtCtasCtsEmpleador.Rows.Count <= 0)
            {
                MessageBox.Show("La empresa no tiene cuentas CTS vigentes", "Declaración Masiva de Remuneraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtCtasCtsEmpleador.Columns["nMonto"].ReadOnly = false;
            dtCtasCtsEmpleador.Columns["lSelCta"].ReadOnly = false;

            dtgDepositosCTS.DataSource = dtCtasCtsEmpleador;
            dtgDepositosCTS.Enabled = true;
            dtgDepositosCTS.ReadOnly = false;

            FormatoGrid();
            HabilitarGrid(true);

            conBusCli1.Enabled = false;
            cboPeriodoCTS.Enabled = false;

            if (dtCtasCtsEmpleador.Rows.Count > 0)
            {
                this.btnGrabar.Enabled = true;
            }

            this.btnCancelar.Enabled = true;
            this.btnAceptar.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataRow[] dtRowEmp = dtCtasCtsEmpleador.Select("lSelCta=0");
            if (dtCtasCtsEmpleador.Rows.Count == dtRowEmp.Count())
            {
                MessageBox.Show("Debe elegir por lo menos una cuenta", "Declaración de remuneración CTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;       
            }
            DataRow[] dtRow = dtCtasCtsEmpleador.Select("lSelCta=1 AND nMonto=0");
            if (dtRow.Count()>0)
            {
                MessageBox.Show("Debe ingresar el monto mayor a cero", "Declaración de remuneración CTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }
            clsCNDeposito DepAbono = new clsCNDeposito();
            decimal nMonto = 0;
            int idCuentaCts = 0;
            int idMoneda = 0;
            int idPeriodoCts = (int)cboPeriodoCTS.SelectedValue;

            for (int i = 0; i < dtCtasCtsEmpleador.Rows.Count; i++)
            {
                bool lSelCta = Convert.ToBoolean(dtCtasCtsEmpleador.Rows[i]["lSelCta"]);
                if (!lSelCta)
                {
                    dtCtasCtsEmpleador.Rows[i]["nMonto"] = 0;
                    continue;
                }
                nMonto = Convert.ToDecimal(dtCtasCtsEmpleador.Rows[i]["nMonto"]);
                if (nMonto <= 0)
                {
                    dtCtasCtsEmpleador.Rows[i]["nMonto"] = 0;
                    continue;
                }
                idCuentaCts = Convert.ToInt32(dtCtasCtsEmpleador.Rows[i]["idCuenta"]);
                idMoneda = Convert.ToInt32(dtCtasCtsEmpleador.Rows[i]["idMoneda"]);
                if (nMonto > 0)
                {
                    DepAbono.CNDeclaracionRemuneracionCTS(idCuentaCts, idPeriodoCts, nMonto,idMoneda);
                }
            }
            MessageBox.Show("Declaración Masiva de Remuneraciones Realizado Satisfactoriamente", "Declaración Masiva de Remuneraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnGrabar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtgDepositosCTS.Enabled = false;
            this.dtgDepositosCTS.ReadOnly = true;
            this.conBusCli1.Enabled = true;
            this.cboPeriodoCTS.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnAceptar.Enabled = true;
            this.dtgDepositosCTS.DataSource = "";
            this.txtNumCtas.Text = "";
        }

        public void FormatoGrid()
        {
            dtgDepositosCTS.Columns["idEmpleador"].Visible = false;
            dtgDepositosCTS.Columns["idCli"].Visible = false;
            dtgDepositosCTS.Columns["idMoneda"].Visible = false;

            dtgDepositosCTS.Columns["idCuenta"].Width = 30;
            dtgDepositosCTS.Columns["cNombre"].Width = 100;
            dtgDepositosCTS.Columns["nMonto"].Width = 50;
            dtgDepositosCTS.Columns["lSelCta"].Width = 30;
            
            dtgDepositosCTS.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgDepositosCTS.Columns["cNombre"].HeaderText = "Cliente";
            dtgDepositosCTS.Columns["nMonto"].HeaderText = "Suma ultimas remuneraciones";
            dtgDepositosCTS.Columns["lSelCta"].HeaderText = "Chk";

            dtgDepositosCTS.Columns["nMonto"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgDepositosCTS.Columns["nMonto"].DefaultCellStyle.ForeColor = Color.White;

            dtgDepositosCTS.Columns["nMonto"].DefaultCellStyle.Format = "N2" ; //'Numero con 2 decimales

        }

        public void HabilitarGrid(Boolean bVal)
        {
            this.dtgDepositosCTS.ReadOnly = !bVal;

            this.dtgDepositosCTS.Columns["lSelCta"].ReadOnly = !bVal;
            this.dtgDepositosCTS.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgDepositosCTS.Columns["cNombre"].ReadOnly = bVal;
            this.dtgDepositosCTS.Columns["nMonto"].ReadOnly = true;
        }

        private void frmDeclaracionMasivaSueldo_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
                
            }
            conBusCli1.lblBase2.Text = "Empleador : ";
            cboPeriodoCTS.Enabled = false;
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.nidTipoPersona == 0)
            {
                return;
            }
            if (conBusCli1.nidTipoPersona == 1)
            {
                MessageBox.Show("Debe elegir una persona jurídica", "Deposito masivo cts.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli1.limpiarControles();
                return;
            }
            cboPeriodoCTS.Enabled = true;
        }

        private void dtgDepositosCTS_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            //{
            //    e.Handled = true;
            //}
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgDepositosCTS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dtgDepositosCTS.Columns["lSelCta"].Index && e.RowIndex>-1)
            //{
            //    DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            //    chk = (DataGridViewCheckBoxCell)dtgDepositosCTS.Rows[dtgDepositosCTS.CurrentRow.Index].Cells["lSelCta"];
            //    if (Convert.ToBoolean(chk.Value) == false)
            //    {
            //        this.dtgDepositosCTS.Columns["nMonto"].ReadOnly = true;
            //        dtCtasCtsEmpleador.Rows[e.RowIndex]["nMonto"] = 0.00;
            //    }
            //    else
            //    {
            //        this.dtgDepositosCTS.Columns["nMonto"].ReadOnly = false;
            //    }
            //}
        }

        private void dtgDepositosCTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgDepositosCTS.Columns["lSelCta"].Index && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
                chk = (DataGridViewCheckBoxCell)dtgDepositosCTS.Rows[dtgDepositosCTS.CurrentRow.Index].Cells["lSelCta"];
                if (Convert.ToBoolean(chk.Value) == false)
                {
                    this.dtgDepositosCTS["nMonto",e.RowIndex].ReadOnly = false;
                    
                }
                else
                {
                    dtCtasCtsEmpleador.Rows[e.RowIndex]["nMonto"] = 0.0;
                    dtCtasCtsEmpleador.Rows[e.RowIndex]["lSelCta"] = false;
                    this.dtgDepositosCTS["nMonto", e.RowIndex].ReadOnly = true;
                    //dtCtasCtsEmpleador.Rows[e.RowIndex]["nMonto"] = 0.0;
                }
                //this.dtgDepositosCTS.EndEdit();
            }
        }
    }
}

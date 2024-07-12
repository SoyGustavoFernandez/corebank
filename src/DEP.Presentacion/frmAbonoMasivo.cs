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
using GEN.LibreriaOffice;
using CAJ.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmAbonoMasivo : frmBase
    {
        private DataTable dtCtaxAse;
        private clsCNDeposito Deposito = new clsCNDeposito();
        public frmAbonoMasivo()
        {
            InitializeComponent();
            clsCNProducto ListaProductoMasivo = new clsCNProducto();
            DataTable dt = ListaProductoMasivo.CNListarProductoAbonoMasivo();
            this.cboProductoMasivo.DataSource = dt;
            this.cboProductoMasivo.ValueMember = dt.Columns[0].ToString();
            this.cboProductoMasivo.DisplayMember = dt.Columns[1].ToString();
            this.cboProductoMasivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmAbonoMasivo_Load(object sender, EventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Int32 nIdAsesor = clsVarGlobal.User.idUsuario;
            dtCtaxAse = Deposito.CNLisCuentaAbonoMasivo(nIdAsesor, (int)this.cboMoneda1.SelectedValue, (int)this.cboProductoMasivo.SelectedValue);
            this.txtNumCtas.Text = dtCtaxAse.Rows.Count.ToString();

            if (dtCtaxAse.Rows.Count <= 0)
            {
                MessageBox.Show("El Asesor no tiene cuentas asignados", "Abono Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtCtaxAse.Columns["nMonAbono"].ReadOnly = false;
            dtCtaxAse.Columns["lSeleCta"].ReadOnly = false;

            dtgBase1.DataSource = dtCtaxAse;
            this.dtgBase1.Enabled = true;
            this.dtgBase1.ReadOnly = false;

            this.FormatoGrid();

            this.HabilitarGrid(true);
            this.cboMoneda1.Enabled = false;

            if (dtCtaxAse.Rows.Count > 0)
            {
                this.btnGrabar.Enabled = true;
            }

            this.btnCancelar.Enabled = true;
            this.btnAceptar.Enabled = false;

            this.txtTotAbono.Visible = false;
            this.txtCtasAbonadas.Visible = false;

        }

        public void HabilitarGrid(Boolean bVal)
        {
            this.dtgBase1.ReadOnly = !bVal;

            this.dtgBase1.Columns["lSeleCta"].ReadOnly = !bVal;

            this.dtgBase1.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgBase1.Columns["cNombre"].ReadOnly = bVal;
            this.dtgBase1.Columns["nSalAPagar"].ReadOnly = bVal;
            this.dtgBase1.Columns["nMonAbono"].ReadOnly = !bVal;
        }

        public void FormatoGrid()
        {
            dtgBase1.Columns["idAgencia"].Visible = false;

            dtgBase1.Columns["lSeleCta"].Width = 20;
            dtgBase1.Columns["idCuenta"].Width = 40;
            dtgBase1.Columns["cNombre"].Width = 150;
            dtgBase1.Columns["nSalAPagar"].Width = 50;
            dtgBase1.Columns["nMonAbono"].Width = 50;
            dtgBase1.Columns["nNumeroTelefono"].Width = 150;

            dtgBase1.Columns["lSeleCta"].HeaderText = "Sel.";
            dtgBase1.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["nSalAPagar"].HeaderText = "Sal.Abono";
            dtgBase1.Columns["nMonAbono"].HeaderText = "Abono";
            dtgBase1.Columns["nNumeroTelefono"].HeaderText = "Teléfono";

            dtgBase1.Columns["nMonAbono"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgBase1.Columns["nMonAbono"].DefaultCellStyle.ForeColor = Color.White;
        }

        private void dtgBase1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);
            dtgBase1.CurrentCell = dtgBase1.Rows[fila].Cells["nMonAbono"];

            Decimal nTotAbono = Convert.ToDecimal (dtCtaxAse.Rows[fila]["nMonAbono"]);
            Decimal nAbonoDeuda = Convert.ToDecimal (dtCtaxAse.Rows[fila]["nSalAPagar"]);
            if (nTotAbono > nAbonoDeuda)
            {
                dtgBase1.CurrentCell = dtgBase1.Rows[fila].Cells["nMonAbono"];
                MessageBox.Show("Monto a abonar no puede superar al maximo de la campaña", "Abono Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            SumaPagos();

        }

        private void SumaPagos()
        {
            Decimal nTotPagadoCuo = 0;
            int nNumCrePagados = 0;
            for (int i = 0; i < dtCtaxAse.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtCtaxAse.Rows[i]["lSeleCta"]);
                if (lSeleCta)
                {
                    nTotPagadoCuo += Convert.ToDecimal (dtCtaxAse.Rows[i]["nMonAbono"]);
                    if (Convert.ToDecimal (dtCtaxAse.Rows[i]["nMonAbono"]) > 0.00m)
                    {
                        nNumCrePagados++;
                    }
                }
            }
            this.txtTotAbono.Text = nTotPagadoCuo.ToString();
            this.txtCtasAbonadas.Text = nNumCrePagados.ToString();
        }

        private bool validapago()
        {
            bool lvalida = true;
            Decimal nTotDeuda = 0.00m;
            Decimal nPagaDeuda = 0.00m;

            if (this.txtCtasAbonadas.Text.Trim() == "" || Convert.ToDecimal (this.txtTotAbono.Text) <= 0)
            {
                MessageBox.Show("No hay montos a ser abonados", "Abono Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            for (int i = 0; i < dtCtaxAse.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtCtaxAse.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nTotDeuda = Convert.ToDecimal (dtCtaxAse.Rows[i]["nSalAPagar"]);
                nPagaDeuda = Convert.ToDecimal (dtCtaxAse.Rows[i]["nMonAbono"]);
                if (nPagaDeuda > nTotDeuda)
                {
                    MessageBox.Show("Monto a Abonar no puede superar el Maximo aporte de campaña", "Abono Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgBase1.CurrentCell = dtgBase1.Rows[i].Cells["nMonAbono"];
                    lvalida = false;
                    break;
                }
            }
            return lvalida;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            clsCNDeposito DepAbono = new clsCNDeposito();
            decimal nPagaDeuda = 0;
            int nNumCredito = 0;

            if (!validapago())
            {
                return;
            }
            for (int i = 0; i < dtCtaxAse.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtCtaxAse.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    dtCtaxAse.Rows[i]["nMonAbono"]=0;
                    continue;
                }
                nPagaDeuda = Convert.ToDecimal(dtCtaxAse.Rows[i]["nMonAbono"]);
                if (nPagaDeuda <= 0)
                {
                    dtCtaxAse.Rows[i]["nMonAbono"] = 0;
                    continue;
                }
                nNumCredito = Convert.ToInt32(dtCtaxAse.Rows[i]["idCuenta"]);
                if (nPagaDeuda> 0)
                {
                    switch ((int)this.cboProductoMasivo.SelectedValue)
                    {
                        case 17:
                            /*idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago*/
                            DepAbono.CNAbonoCuenta(nNumCredito, clsVarGlobal.dFecSystem,clsVarGlobal.User.idUsuario,nPagaDeuda,clsVarGlobal.nIdAgencia,0,0,1,0);
                            break;
                        case 25:
                            DataTable dtPlanDepo= DepAbono.CNDistribuir(DepAbono.CNRetornaPlanDep(nNumCredito), nPagaDeuda);
                            DataSet ds = new DataSet("dsPlanDeposito");
                            ds.Tables.Add(dtPlanDepo);
                            String XmlPlanDepo = ds.GetXml();
                            XmlPlanDepo = clsCNFormatoXML.EncodingXML(XmlPlanDepo);
                            DepAbono.CNAbonoDepProg(nNumCredito, nPagaDeuda, XmlPlanDepo,clsVarGlobal.dFecSystem,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia,0,0,1,0);
                            break;
                        default:
                            break;
                    }
                }
            }
            MessageBox.Show("Abono en Lote Realizado Satisfactoriamente", "Abono en Lote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnGrabar.Enabled = false;
            this.txtTotAbono.Visible = true;
            this.txtCtasAbonadas.Visible = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtgBase1.Enabled = false;
            this.dtgBase1.ReadOnly = true;
            this.cboMoneda1.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnAceptar.Enabled = true;
            this.dtgBase1.DataSource = "";
            this.txtCtasAbonadas.Text = "";
            this.txtNumCtas.Text = "";
            this.txtTotAbono.Text = "";

            this.txtCtasAbonadas.Visible = true;
            this.txtTotAbono.Visible = true;
            LiberarCuenta();
       }

        public void LiberarCuenta()
        {
            Deposito.CNUpdNoUsoCuentaMasivo(clsVarGlobal.User.idUsuario);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        private void frmAbonoMasivo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

    }
}

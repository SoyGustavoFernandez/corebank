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
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRegistroValorados : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();

        public frmRegistroValorados()
        {
            InitializeComponent();
        }

        private void frmRegistroValorados_Load(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            if (!ValidarDatos())
            {
                return;
            }
            DataTable dtValiaLote = clsOpeValorado.CNNroMaximoLoteFolio(Convert.ToInt16(cboTipoValorado.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue));
            nudLote.Value = Convert.ToInt32(dtValiaLote.Rows[0]["nNroMaxLote"].ToString());
            nudIniValorado.Value = Convert.ToInt32(dtValiaLote.Rows[0]["nNroMaxFolio"].ToString());
            nudFinValorado.Value = nudIniValorado.Value + nudCantidad.Value-1;
            DetalleValorado();
            if (dtgValorado.Rows.Count>0)
            {
                btnGrabar.Enabled = true;
                btnProcesar.Enabled = false;
                HabDeshabCtrls(false);
                dtgValorado.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
                btnProcesar.Enabled = true;
                btnCancelar.Enabled = false;
                LimpiarCtrls();
            }
            
        }

        private bool ValidarDatos()
        {
            if (cboTipoValorado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Valorado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoValorado.Focus();
                return false;
            }
            if (cboMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar la Moneda", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(nudCantidad.Value.ToString()))
            {
                MessageBox.Show("Debe Registrar la Cantidad de Valorados", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudCantidad.Focus();
                nudCantidad.Select();
                return false;
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("Debe Registrar la Cantidad de Valorados a Registrar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudCantidad.Focus();
                nudCantidad.Select();
                return false;
            }
            return true;
        }

        private void CalcularTotal()
        {
            int nTotOK = 0,
                nTotErr = 0;
            txtTotalValorado.Text = "0";
            txtValoradoErr.Text = "0";
            for (int i = 0; i < dtgValorado.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgValorado.Rows[i].Cells["lEstado"].Value))
                {
                    nTotOK = nTotOK + 1;
                    dtgValorado.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    dtgValorado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            nTotErr = Convert.ToInt32(nudCantidad.Value)- nTotOK;
            txtTotalValorado.Text  =nTotOK.ToString();
            txtValoradoErr.Text = nTotErr.ToString();
        }
                
        private void DetalleValorado()
        {
            DataTable dtTablaDetVal = new DataTable();
            dtTablaDetVal.Columns.Add("nFolio", typeof(int));
            dtTablaDetVal.Columns.Add("nTipVal", typeof(int));
            dtTablaDetVal.Columns.Add("nTipMon", typeof(int));
            dtTablaDetVal.Columns.Add("cDesVal", typeof(string));
            dtTablaDetVal.Columns.Add("lEstado",typeof(bool));

            int n = Convert.ToInt32(nudIniValorado.Value);

            for (int i = 0; n <= nudFinValorado.Value; n++)
            {
                DataRow drfila = dtTablaDetVal.NewRow();
                drfila[0] = n;
                drfila[1] = Convert.ToInt16(cboTipoValorado.SelectedValue.ToString());
                drfila[2] = Convert.ToInt16(cboMoneda.SelectedValue.ToString());
                drfila[3] = cboTipoValorado.Text;
                drfila[4] = 1;
                dtTablaDetVal.Rows.Add(drfila);
            }
            
            dtgValorado.ReadOnly = false;
            dtgValorado.DataSource=dtTablaDetVal;
            dtgValorado.Columns["nTipVal"].Visible = false;
            dtgValorado.Columns["nTipMon"].Visible = false;

            dtgValorado.Columns["nFolio"].HeaderText = "Nro. de Folio";
            dtgValorado.Columns["nFolio"].Width = 60;
            dtgValorado.Columns["cDesVal"].HeaderText = "Descripción del Valorado";
            dtgValorado.Columns["cDesVal"].Width = 150;
            dtgValorado.Columns["lEstado"].HeaderText = "Estado";
            dtgValorado.Columns["lEstado"].Width = 80;

            dtgValorado.Columns["nFolio"].ReadOnly = true;
            dtgValorado.Columns["cDesVal"].ReadOnly = true;
            dtTablaDetVal.Columns["lEstado"].ReadOnly = false;
            dtgValorado.Columns["lEstado"].ReadOnly = false;
            CalcularTotal();
        }

        private void HabDeshabCtrls(bool Val)
        {
            cboTipoValorado.Enabled = Val;
            cboMoneda.Enabled = Val;
            nudCantidad.Enabled = Val;
            dtgValorado.Enabled = Val;
            btnProcesar.Enabled = Val;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            if (dtgValorado.Rows.Count<=0)
            {
                MessageBox.Show("No hay Detalle de Valorados para Registrar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //===================================================================
            //--Generar XML del Detalle de Valorados
            //===================================================================
            DataTable dtVal = (DataTable)dtgValorado.DataSource;
            DataSet dsValorado = new DataSet("dsValorado");
            dsValorado.Tables.Add(dtVal);
            string xmlDetValorado = clsCNFormatoXML.EncodingXML(dsValorado.GetXml());

            //===================================================================
            //--Datos Para el registro del Valorado
            //===================================================================
            int x_idTipVal=Convert.ToInt16(cboTipoValorado.SelectedValue),
                x_idMoneda=Convert.ToInt16(cboMoneda.SelectedValue),
                x_nNumLote=Convert.ToInt32(nudLote.Value),                
                x_nInicio=Convert.ToInt32(nudIniValorado.Value),
                x_nfin=Convert.ToInt32(nudFinValorado.Value),
                x_nTotalLote=Convert.ToInt32(nudCantidad.Value),
                x_nTotalMal=Convert.ToInt32(txtValoradoErr.Text);

            //===================================================================
            //--Registro de los Valorados
            //===================================================================
            DataTable tbRegVal = clsOpeValorado.CNRegistrarValorados(x_idTipVal, x_idMoneda, x_nNumLote, x_nInicio, x_nfin, x_nTotalLote,x_nTotalMal,
                                                                        clsVarGlobal.dFecSystem,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia, xmlDetValorado);
            if (Convert.ToInt32(tbRegVal.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegVal.Rows[0]["cMensage"].ToString(), "Registro de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabDeshabCtrls(false);
            }
            else
            {
                MessageBox.Show(tbRegVal.Rows[0]["cMensage"].ToString(), "Registro de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void LimpiarCtrls()
        {
            cboTipoValorado.SelectedValue = 1;
            cboMoneda.SelectedValue = 1;
            nudCantidad.Value = 0;
            nudLote.Value = 0;
            nudIniValorado.Value = 0;
            nudFinValorado.Value = 0;
            txtTotalValorado.Text = "0";
            txtValoradoErr.Text = "0";
            if (dtgValorado.Rows.Count > 0)
            {
                ((DataTable)dtgValorado.DataSource).Rows.Clear();
            }
            dtgValorado.Refresh();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            LimpiarCtrls();
            HabDeshabCtrls(true);
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void dtgValorado_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dtgValorado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
             
        }

        private void dtgValorado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgValorado.Columns[e.ColumnIndex].Name == "lEstado")
            {
                CalcularTotal();
            }

        }

        private void dtgValorado_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgValorado.IsCurrentCellDirty)
            {
                dtgValorado.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabDeshabCtrls(true);
            LimpiarCtrls();
            cboTipoValorado.Focus();
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void cboTipoValorado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMoneda.Enabled = true;
            if (cboTipoValorado.SelectedIndex>0)
            {
                if (Convert.ToInt16(cboTipoValorado.SelectedValue)==2)
                {
                    cboMoneda.SelectedValue = 1;
                    cboMoneda.Enabled = false;
                }
                else
                {
                    cboMoneda.Enabled = true;
                }
                
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
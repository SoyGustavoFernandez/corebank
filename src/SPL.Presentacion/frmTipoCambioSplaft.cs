using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmTipoCambioSplaft : frmBase
    {
        clsCNTipoCambioSPL cntipocambio = new clsCNTipoCambioSPL();
        DataTable dtTipCambio = new DataTable();
        Transaccion operacion = Transaccion.Selecciona;

        public frmTipoCambioSplaft()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtTipCambio.Rows.Clear();
            dtTipCambio = cntipocambio.ListarTipoCambio(0);
            if (dtTipCambio.Rows.Count>0)
            {
                dtgTipoCambioSplaft.DataSource = dtTipCambio;
                formatoGrid();
            }

            DateTime dFecNueIni;
            DateTime dFecNueFin;
            dFecNueIni =Convert.ToDateTime( @"1/" + clsVarGlobal.dFecSystem.Month.ToString() + @"/"+clsVarGlobal.dFecSystem.Year.ToString());                            
            dFecNueFin = dFecNueIni.AddMonths(1).AddDays(-1);
            dtpFechaInicial.Value = dFecNueIni;
            dtpFechaFinal.Value = dFecNueFin;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;
            DateTime dFecNueIni;
            DateTime dFecNueFin;
            if (dtTipCambio.Rows.Count>0)
            {
                dFecNueIni = Convert.ToDateTime(dtTipCambio.Rows[0]["dIniTipoCambio"]);                             
            }
            else
            {
                dFecNueIni =Convert.ToDateTime( @"1/" + clsVarGlobal.dFecSystem.Month.ToString() + @"/"+clsVarGlobal.dFecSystem.Year.ToString());                
            }
            dFecNueIni = dFecNueIni.AddMonths(1);
            dFecNueFin = dFecNueIni.AddMonths(1).AddDays(-1);  
            dtpFechaInicial.Value = dFecNueIni;
            dtpFechaFinal.Value = dFecNueFin;
            grbTipoCambio.Enabled = true;
            txtTipoCamioSplaft.Focus();
            btnGrabar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            dtgTipoCambioSplaft.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (txtTipoCamioSplaft.nDecValor<=0)
            {
                 MessageBox.Show("Ingrese un valor Mayor a Cero para el tipo de cambio", "Validar tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            if (operacion== Transaccion.Nuevo)
            {
                cntipocambio.insertarTipoCambioSPL(dtpFechaInicial.Value, dtpFechaFinal.Value, txtTipoCamioSplaft.nDecValor);
                MessageBox.Show("Se registro correctamente el tipo de cambio", "Registro tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }

            if (operacion == Transaccion.Edita)
            {
                cntipocambio.actualizarTipoCambioSPL(Convert.ToInt32(dtgTipoCambioSplaft.CurrentRow.Cells["idTipoCambio"].Value), txtTipoCamioSplaft.nDecValor);
                MessageBox.Show("Se actualizó correctamente el tipo de cambio", "Actualiza tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
                      
            
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            grbTipoCambio.Enabled = false;
            

            dtTipCambio.Rows.Clear();
            dtTipCambio = cntipocambio.ListarTipoCambio(0);
            if (dtTipCambio.Rows.Count > 0)
            {
                dtgTipoCambioSplaft.DataSource = dtTipCambio;
                formatoGrid();
            }
            dtgTipoCambioSplaft.Enabled = true;
            operacion = Transaccion.Selecciona;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgTipoCambioSplaft.Rows.Count > 0)
            {
                dtgTipoCambioSplaft.Select();
                operacion = Transaccion.Edita;
                grbTipoCambio.Enabled = true;
                btnEditar1.Enabled = false;
                btnGrabar1.Enabled = true;
                btnNuevo1.Enabled = false;

                var drSele = dtgTipoCambioSplaft.CurrentRow;
                txtTipoCamioSplaft.Text = drSele.Cells["nValor"].Value.ToString();
                dtpFechaInicial.Value = Convert.ToDateTime(drSele.Cells["dIniTipoCambio"].Value);
                dtpFechaFinal.Value = Convert.ToDateTime(drSele.Cells["dFinTipoCambio"].Value);

                dtgTipoCambioSplaft.Enabled = false;
            }
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgTipoCambioSplaft.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTipoCambioSplaft.Columns["dFecha"].Visible = false;
            dtgTipoCambioSplaft.Columns["idTipoCambio"].Visible = false;

            dtgTipoCambioSplaft.Columns["nValor"].HeaderText = "Tipo Cambio";
            dtgTipoCambioSplaft.Columns["dIniTipoCambio"].HeaderText = "Fecha Inical";
            dtgTipoCambioSplaft.Columns["dFinTipoCambio"].HeaderText = "Fecha Final";
            dtgTipoCambioSplaft.Columns["lEstado"].HeaderText = "Activo";


            
            dtgTipoCambioSplaft.Columns["dIniTipoCambio"].DisplayIndex = 1;
            dtgTipoCambioSplaft.Columns["dFinTipoCambio"].DisplayIndex = 2;
            dtgTipoCambioSplaft.Columns["nValor"].DisplayIndex = 3;
            dtgTipoCambioSplaft.Columns["lEstado"].DisplayIndex = 4;

            dtgTipoCambioSplaft.Columns["nValor"].DefaultCellStyle.Format = "N4";

            dtgTipoCambioSplaft.Columns["dIniTipoCambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["dFinTipoCambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["nValor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["lEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTipoCambioSplaft.Columns["nValor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["dIniTipoCambio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["dFinTipoCambio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTipoCambioSplaft.Columns["lEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            grbTipoCambio.Enabled = false;
            txtTipoCamioSplaft.Text = "0.0";
            btnGrabar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            dtgTipoCambioSplaft.Enabled = true;
        }
    }
}

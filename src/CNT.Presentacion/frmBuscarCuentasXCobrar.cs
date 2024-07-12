using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmBuscarCuentasXCobrar : frmBase
    {
        public DataRow dtRows=null;
        public frmBuscarCuentasXCobrar()
        {
            InitializeComponent();
        }
        public frmBuscarCuentasXCobrar(DataTable dtListaCxC)
        {
            InitializeComponent();
            dtgCuentasCobrar.DataSource = dtListaCxC;
            dtgCuentasCobrar.Columns["idCuentasxCobrar"].HeaderText = "Cod CxC";
            //dtgCuentasCobrar.Columns["idCuentasxCobrar"].Width = 50;
            dtgCuentasCobrar.Columns["idCli"].Visible = false;
            dtgCuentasCobrar.Columns["cCliente"].HeaderText = "Cliente";
            //dtgCuentasCobrar.Columns["cCliente"].ReadOnly = false;
            //dtgCuentasCobrar.Columns["cCliente"].Width = 200;
            //dtgCuentasCobrar.Columns["cCliente"].ReadOnly = true;
            dtgCuentasCobrar.Columns["nSaldo"].Visible = false;
            dtgCuentasCobrar.Columns["idTipoCuentaxCobrar"].Visible = false;
            dtgCuentasCobrar.Columns["cTipoCuentasCobrar"].HeaderText = "Tipo CxC";
            dtgCuentasCobrar.Columns["nMonto"].HeaderText = "Monto";
            dtgCuentasCobrar.Columns["nTotalPago"].Visible = false;         
            dtgCuentasCobrar.Columns["dFechaIniOpera"].HeaderText = "Fecha Inicio Ope";
            dtgCuentasCobrar.Columns["cObservacion"].Visible = false;         
            dtgCuentasCobrar.Columns["lVigente"].Visible = false;
            dtgCuentasCobrar.Columns["idEstadoCxC"].Visible = false;
            
        
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgCuentasCobrar.RowCount > 0)
            {
                dtRows = ((DataRowView)dtgCuentasCobrar.CurrentRow.DataBoundItem).Row;
            }
            this.Dispose();

        }
    }
}

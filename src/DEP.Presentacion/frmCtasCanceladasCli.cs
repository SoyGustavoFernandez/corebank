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
using GEN.CapaNegocio;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmCtasCanceladasCli : frmBase
    {
        public string pc_idCli;
        public DataTable p_dtCtascanceladas = new DataTable();

        public frmCtasCanceladasCli()
        {
            InitializeComponent();
        }

        private void frmCtasCanceladasCli_Load(object sender, EventArgs e)
        {
            clsCNDeposito clsDep = new clsCNDeposito();
            DataTable dtCtasCan = clsDep.CNCuentasCanceladasCli(pc_idCli);
            dtgCtasCanceladas.DataSource = dtCtasCan;
            p_dtCtascanceladas = dtCtasCan.Clone();
            if (dtCtasCan.Rows.Count>0)
            {
                btnAceptar.Enabled = true;
            }
            dtgCtasCanceladas.ReadOnly = false;
            dtgCtasCanceladas.Columns["lMarca"].HeaderText = "Sel";
            dtgCtasCanceladas.Columns["lMarca"].Width = 20;
            dtgCtasCanceladas.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCtasCanceladas.Columns["idCuenta"].Width = 60;
            dtgCtasCanceladas.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCtasCanceladas.Columns["cMoneda"].Width = 60;
            dtgCtasCanceladas.Columns["cProducto"].HeaderText = "Producto";
            dtgCtasCanceladas.Columns["cProducto"].Width = 100;
            dtgCtasCanceladas.Columns["cTipoCuenta"].HeaderText = "Tipo Cuenta";
            dtgCtasCanceladas.Columns["cTipoCuenta"].Width = 80;
            dtgCtasCanceladas.Columns["dFechaCancelacion"].HeaderText = "Fecha Cancelación";
            dtgCtasCanceladas.Columns["dFechaCancelacion"].Width = 100;
            
            dtgCtasCanceladas.Columns["idCuenta"].ReadOnly = true;
            dtgCtasCanceladas.Columns["cMoneda"].ReadOnly = true;
            dtgCtasCanceladas.Columns["cProducto"].ReadOnly = true;
            dtgCtasCanceladas.Columns["cTipoCuenta"].ReadOnly = true;
            dtgCtasCanceladas.Columns["dFechaCancelacion"].ReadOnly = true;
            
            dtCtasCan.Columns["lMarca"].ReadOnly = false;
            dtgCtasCanceladas.Columns["lMarca"].ReadOnly = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int nSel = 0;
            for (int i = 0; i < dtgCtasCanceladas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.dtgCtasCanceladas.Rows[i].Cells["lMarca"].Value))
                {
                    nSel++;
                    break;
                }
            }

            if (nSel<=0)
            {
                MessageBox.Show("Debe Seleccionar por lo Menos una Cuenta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            p_dtCtascanceladas = (DataTable)this.dtgCtasCanceladas.DataSource;
            this.Dispose();
        }
    }
}

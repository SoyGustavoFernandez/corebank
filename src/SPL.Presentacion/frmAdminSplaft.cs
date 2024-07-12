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
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmAdminSplaft : frmBase
    {
        private clsCNUmbralSPL umbral = new clsCNUmbralSPL();
        private clsCNTipoCambioSPL tipoCambio = new clsCNTipoCambioSPL();

        public frmAdminSplaft()
        {
            InitializeComponent();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {            
            if(Validar("umbral"))
            {
                //umbral.insertarUmbral(Convert.ToDecimal(txtUmbral.Text), Convert.ToDateTime(txtFechaUmbral.Text));            
            }
        }

        private Boolean Validar(String tipo)
        {
            Boolean res;
            
            switch (tipo)
            {
                case "umbral":
                    if (txtUmbral.Text == "")
                    {
                        MessageBox.Show("error");
                        return res=false;
                    }

                break;
                
                default:
                    break;
            }
            return res=true;
        }

        private void frmAdminSplaft_Load(object sender, EventArgs e)
        {
            DataTable dsUmbral = new DataTable();
            dsUmbral=umbral.ListarUmbral(1, 0);
            txtUmbral.Text = dsUmbral.Rows[0]["nValor"].ToString();
            txtFechaUmbral.Text = dsUmbral.Rows[0]["dFecha"].ToString();

            DataTable dsTc = new DataTable();
            dsTc = tipoCambio.ListarTipoCambio(1);
            txtTipoCambio.Text = dsTc.Rows[0]["nValor"].ToString();
            txtFechaTipoCambio.Text = dsTc.Rows[0]["dFecha"].ToString();
        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            //tipoCambio.insertarTipoCambioSPL(Convert.ToDecimal(txtTipoCambio.Text), Convert.ToDateTime(txtFechaTipoCambio.Text));
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            txtUmbral.Text = ""; txtFechaUmbral.Text = "";
            txtUmbral.Enabled = true; txtFechaUmbral.Enabled = true;
            txtUmbral.Focus();
            btnGrabar1.Enabled = true;
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            txtTipoCambio.Text = ""; txtFechaTipoCambio.Text = "";
            txtTipoCambio.Enabled = true; txtFechaTipoCambio.Enabled = true;
            txtTipoCambio.Focus();
            btnGrabar2.Enabled = true;
        }
    }
}

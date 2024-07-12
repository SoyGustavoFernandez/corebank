using CNT.CapaNegocio;
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
    public partial class frmReplicaCtaCtb : frmBase
    {
        #region Eventos
        public frmReplicaCtaCtb()
        {
            InitializeComponent();
        }

        private void frmReplicaCtaCtb_Load(object sender, EventArgs e)
        {
            cboModulo1.LisModuloBaseNegativa();
            cboTipoCredito.SelectedIndex = -1;
        }

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idtipCre =Convert.ToInt32(cboTipoCredito.SelectedValue);
            int idmodulo = Convert.ToInt32(cboModulo1.SelectedValue);
            cboSubProductoOrigen.SubProductoxTipoCredito(idtipCre, idmodulo);
            cboSubProductoDestino.SubProductoxTipoCredito(idtipCre, idmodulo);
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                cboSubProductoDestino.Enabled = false;
            }
            else
            {
                cboSubProductoDestino.Enabled = true;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            btnGrabar1.Enabled = false;
            int idProdOri = Convert.ToInt32(cboSubProductoOrigen.SelectedValue),
                idProDes = chcTodos.Checked?0:Convert.ToInt32(cboSubProductoDestino.SelectedValue),
                idTipCre = Convert.ToInt32(cboTipoCredito.SelectedValue), 
                idModulo = Convert.ToInt32(cboModulo1.SelectedValue);
            DataTable dtResultado = new clsCNCtaContable().ReplicaCuentas(idProdOri, idProDes, idTipCre, idModulo);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"])==1)
            {
                MessageBox.Show("Cuentas replicadas correctamente", "Replica de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR en replicadas de cuentas", "Replica de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnGrabar1.Enabled = true;
        }

        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoCredito.CargarProductoModNivel(Convert.ToInt32(cboModulo1.SelectedValue),1);
        }
        #endregion
    }
}

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
using ADM.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmSelTipoPlantillaImp : frmBase
    {
        #region Variables Globales
        clsCNConfigPlantillaImp objTipoPlanImpr = new clsCNConfigPlantillaImp();
        #endregion

        public frmSelTipoPlantillaImp()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmSelTipoPlantillaImp_Load(object sender, EventArgs e)
        {
            DataTable dtTipoPlanImp = objTipoPlanImpr.CNListarTipoPlantillaImpresion();
            cboTipoPlantillaImpresion.DisplayMember = Convert.ToString(dtTipoPlanImp.Columns["cTipoPlantillaImpresion"]);
            cboTipoPlantillaImpresion.ValueMember = Convert.ToString(dtTipoPlanImp.Columns["idTipoPlantillaImpresion"]);
            cboTipoPlantillaImpresion.DataSource = dtTipoPlanImp;
            this.cboTipoPlantillaImpresion.SelectedValue = clsVarGlobal.idTipoPlantillaImpresion;
            this.Text = "Configuración Plantilla Voucher";
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            int idRegistro = clsVarGlobal.idRegistroPC;
            int idTipoPlantImpresion = Convert.ToInt32(cboTipoPlantillaImpresion.SelectedValue);

            DataTable dtResultado = objTipoPlanImpr.CNActualizarTipoPlantillaImpresion(idRegistro, idTipoPlantImpresion);
            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
                {
                    clsVarGlobal.idTipoPlantillaImpresion = idTipoPlantImpresion;
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ocurrion un error en la actualizacion, intentelo nuevamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
        #endregion

        #region Metodos
        private bool validar()
        {
            bool lValida = true;
            if (cboTipoPlantillaImpresion.SelectedIndex == -1)
            {
                lValida = false;
                MessageBox.Show("Debe seleccionar un tipo de plantilla de impresion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValida;
            }
            return lValida;
        }
        #endregion
        

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class conActividad : UserControl
    {
        #region Variables Globales
        #endregion
        #region Métodos
        public conActividad()
        {
            InitializeComponent();

            cboActividadEco.CargarActivEconomica(0);
            cboGrupoCiiu.SelectedIndex = -1;
            cboCIIU.SelectedIndex = -1;
        }
        #endregion

        private void cboActividadEco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadEco.SelectedValue is DataRowView) return;
            if (cboActividadEco.SelectedIndex > 0)
            {
                cboGrupoCiiu.CargarActivEconomica((int)cboActividadEco.SelectedValue);
            }
            else
            {
                if (Convert.ToInt32(cboActividadEco.SelectedValue) > 0)
                {
                    cboGrupoCiiu.SelectedValue = 0;
                }
                else
                {
                    cboGrupoCiiu.SelectedIndex = -1;
                }
            }
        }

        private void cboGrupoCiiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoCiiu.SelectedValue is DataRowView) return;

            if (cboGrupoCiiu.SelectedIndex > -1)
            {
                if (cboGrupoCiiu.SelectedValue is DataRowView) return;

                this.cboCIIU.CargarActivEconomica((int)cboGrupoCiiu.SelectedValue);
            }
            else
            {
                if (Convert.ToInt32(cboGrupoCiiu.SelectedValue) > 0)
                {
                    cboCIIU.SelectedValue = 0;
                }
                else
                {
                    cboCIIU.SelectedIndex = -1;
                }
            }
        }

        #region Eventos
        #endregion
    }
}

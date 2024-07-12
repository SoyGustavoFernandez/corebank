using EntityLayer;
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

namespace RCP.Presentacion
{
    public partial class frmSeleccionaAccion : frmBase
    {
        public bool lAceptar = false;
        public int idTipoIntev;

        public frmSeleccionaAccion()
        {
            InitializeComponent();            
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.lAceptar = true;
            this.Hide();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.lAceptar = false;
            this.Dispose();
        }

        private void frmSeleccionaAccion_Load(object sender, EventArgs e)
        {
            cboTipoNotificacion1.cargar(Convert.ToInt32(txtDiasAtraso.Text), idTipoIntev);
            cboAccion1.cargarDatosPorPerfil(clsVarGlobal.PerfilUsu.idPerfil);            
        }

        private void cboAccion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAccion1.SelectedIndex >= 0)
            {
                if (cboAccion1.SelectedValue != null && !(cboAccion1.SelectedValue is DataRowView))
                {
                    DataRowView dr = (DataRowView)cboAccion1.SelectedItem;
                    var rowSugerido = ((DataTable)cboTipoNotificacion1.DataSource).AsEnumerable().FirstOrDefault(x => Convert.ToInt32(x["idTipoNotificacionEnRango"]) != 0);
                    int idSugerido = rowSugerido == null ? 0 : Convert.ToInt32(rowSugerido["idTipoNotificacion"]);

                    bool lNotificacion = Convert.ToBoolean(dr["lNotificacion"]);
                    cboTipoNotificacion1.Enabled = lNotificacion;
                    cboTipoNotificacion1.SelectedValue = lNotificacion ? idSugerido : 0;               
                }
            }
        }
    }
}

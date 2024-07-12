#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.Funciones;
using EntityLayer;
#endregion


namespace GEN.ControlesBase
{
    public partial class frmConfigurarParametroArchivo : frmBase
    {
        #region
        private clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
        #endregion

        #region Constructores
        public frmConfigurarParametroArchivo()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmConfigurarParametroArchivo_Load(object sender, EventArgs e)
        {
            DataTable dtParametros = clsConfiguracion.CNObtenerParametros();
            if (dtParametros.Rows.Count > 0)
            {
                DataRow drExposicionNatural = dtParametros.AsEnumerable().FirstOrDefault(item => item.Field<int>("idTipoPersona") == 1);
                DataRow drExposicionJuridica = dtParametros.AsEnumerable().FirstOrDefault(item => item.Field<int>("idTipoPersona") == 2);
                txtMontoExposicionNatural.Text = Convert.ToString(drExposicionNatural["nMontoExposicion"]);
                txtMontoExposicionJuridica.Text = Convert.ToString(drExposicionJuridica["nMontoExposicion"]);
            }
        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            DataTable dtRes = clsConfiguracion.CNGuardarParametros(Convert.ToDecimal(txtMontoExposicionNatural.Text), Convert.ToDecimal(txtMontoExposicionJuridica.Text), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtRes.Rows[0]["idMsg"]) == 1)
            {
                MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

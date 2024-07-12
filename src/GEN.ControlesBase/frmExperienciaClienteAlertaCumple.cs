using ADM.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmExperienciaClienteAlertaCumple : frmBase
    {
        public string cDocumentoID;
        public string cNombreCliente;
        public string cFechaCumpleaños;
        public string cSegmento;

        public frmExperienciaClienteAlertaCumple()
        {
            InitializeComponent();
        }

        private void frmExperienciaClienteAlertaCumple_Load(object sender, EventArgs e)
        {

            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtExpCliente = cnExpCliente.ListaModulosAlertaCumple();

            if (Convert.ToString(dtExpCliente.Rows[0]["cValVar"]).Contains(Convert.ToString(clsVarGlobal.idModulo)) == false)
            {
                this.Close();          
            }

            string cSegmentoFinal;
            if (cSegmento.Trim() == "")
            {
                cSegmentoFinal = "No Registrado.";
            }
            else 
            {
                string delimitador = ".";
                int indiceDelimitador = cSegmento.IndexOf(delimitador);
                cSegmentoFinal = cSegmento.Substring(indiceDelimitador + delimitador.Length);            
            }

            lblNombres.Text = cNombreCliente;
            lblFechaCumpleaños.Text = cFechaCumpleaños;
            lblSegmento.Text = cSegmentoFinal;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtExpCliente = cnExpCliente.RegistraAlertaCumpleExpCliente(clsVarGlobal.dFecSystem, cSegmento, clsVarGlobal.nIdAgencia, cDocumentoID, clsVarGlobal.User.idUsuario, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
            if (Convert.ToInt32(dtExpCliente.Rows[0]["idRpta"]) == 0)
            {
                MessageBox.Show(dtExpCliente.Rows[0]["cMensage"].ToString(), "Registro Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}

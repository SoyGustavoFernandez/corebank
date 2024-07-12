using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ConEmpConvenio : UserControl
    {
        int idEmpresaConv;
        public ConEmpConvenio()
        {
            InitializeComponent();
            limpiar();
        }

        private void cboEmpresasConvenio1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmpresasConvenio1.SelectedIndex < 0)
            {
                limpiar();
                return;
            }

            int idSelec = cboEmpresasConvenio1.SelectedIndex;
            DataTable dt = ((DataTable)cboEmpresasConvenio1.DataSource);

            lblRazSocial.Text = dt.Rows[idSelec]["cRazonSocial"].ToString();
            lblRuc.Text = dt.Rows[idSelec]["cNroDocumento"].ToString();
            lblDireccion.Text = dt.Rows[idSelec]["cDirección"].ToString();
            lblSector.Text = dt.Rows[idSelec]["cSectorEmp"].ToString();
            idEmpresaConv = Convert.ToInt32(dt.Rows[idSelec]["idEmpresaConv"]);
            
        }

        public void limpiar()
        {
            lblRazSocial.Text = "";
            lblRuc.Text = "";
            lblDireccion.Text = "";
            lblSector.Text = "";
            idEmpresaConv = 0;
            cboEmpresasConvenio1.SelectedIndex = -1;
        }

        public clsMsjError ValidarObj()
        {
            clsMsjError obj = new clsMsjError();

            if (cboEmpresasConvenio1.SelectedIndex < 0)
            {
                obj.AddError("Seleccione la empresa con la cual se tiene el convenio");
            }

            return obj;
        }

        public int obtenerEmpresa()
        { 
            return Convert.ToInt32(cboEmpresasConvenio1.SelectedValue);
        }

        public void SetIdEmpresa(int idEmpre)
        {
            idEmpresaConv = idEmpre;
            cboEmpresasConvenio1.SelectedValue = idEmpresaConv;
        }

        private void ConEmpConvenio_Load(object sender, EventArgs e)
        {
            cboEmpresasConvenio1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cboEmpresasConvenio1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            cboEmpresasConvenio1.cargarEmpresasConv();
        }


    }
}

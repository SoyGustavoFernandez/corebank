using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conDirecPrincipal : UserControl
    {
        public DataTable lisdirecs = null;

        public conDirecPrincipal()
        {
            InitializeComponent();
        }

        private void conDirecPrincipal_Load(object sender, EventArgs e)
        {
            this.conBusUbiCli.cargar();
        }

        /// <summary>
        /// id del cliente
        /// </summary>
        /// <param name="idCli"></param>
        public void cargarDireccion(int idCli)
        {
            clsCNDirecCli dircli = new clsCNDirecCli();

            lisdirecs = dircli.ListaDirCli(idCli);
            if (lisdirecs.Rows.Count>0)
            {
                DataRow dirprin = (DataRow)(lisdirecs.AsEnumerable().Where(x => Convert.ToBoolean(x["lDirPrincipal"]) == true).ToList()[0]);
                this.txtDireccion.Text = dirprin["cDireccion"].ToString();
                this.txtReferencia.Text = dirprin["cReferenciaDireccion"].ToString();
                this.cboTipoZona.SelectedValue = Convert.ToInt32(dirprin["idTipoZona"]);
                this.cboTipoVia.SelectedValue = Convert.ToInt32(dirprin["idTipoVia"]);
                this.textNro.Text = dirprin["cNumero"].ToString();
                this.textKm.Text = dirprin["cKilometro"].ToString();
                this.textZona.Text = dirprin["cDesZona"].ToString();
                this.textVia.Text = dirprin["cDesVia"].ToString();
                this.textDpto.Text = dirprin["cDepartamento"].ToString();
                this.textMz.Text = dirprin["cManzana"].ToString();
                this.textInt.Text = dirprin["cInterior"].ToString();
                this.textLote.Text = dirprin["cLote"].ToString();
                this.conBusUbiCli.cargarUbigeo(Convert.ToInt32(dirprin["idUbigeo"]));
            }
            
        }

        /// <summary>
        /// limpia los controles del control personalizado.
        /// </summary>
        public void limpiarControles()
        {
            this.textNro.Text = "";
            this.textKm.Text ="";
            this.textZona.Text ="";
            this.textVia.Text = "";
            this.textDpto.Text ="";
            this.textMz.Text = "";
            this.textInt.Text = "";
            this.textLote.Text = "";
            this.txtDireccion.Text = "";
            this.txtReferencia.Text = "";
            lisdirecs = null;
        }
    }
}

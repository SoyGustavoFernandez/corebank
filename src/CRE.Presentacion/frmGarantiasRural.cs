using CRE.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmGarantiasRural : frmBase
    {
        private int idEvalCred = 0;
        private decimal nMontoInmueble = 0m;

        public frmGarantiasRural()
        {
            InitializeComponent();
        }

        public frmGarantiasRural(int idEvalCred, decimal nMontoInmueble)
        {
            this.idEvalCred = idEvalCred;
            this.nMontoInmueble = nMontoInmueble;
            InitializeComponent();
            CargaData();
        }

        void CargaData()
        {
            clsCNGarantiaRural cnGarantia = new clsCNGarantiaRural();
            DataTable dtGarantia = cnGarantia.ListarGarantiaRuralid(this.idEvalCred);

            if (this.nMontoInmueble > 0 && dtGarantia.Rows.Count == 0)
            {
                txtDescripcion.Text = "";
                txtTipoDocumento.Text = "CONSTANCIA DE POSESIÓN";
                txtValor.Text = this.nMontoInmueble.ToString();
            }
            else if (this.nMontoInmueble > 0 && dtGarantia.Rows.Count > 0)
            {
                txtDescripcion.Text = dtGarantia.Rows[0]["cDescripcion"].ToString();
                txtTipoDocumento.Text = dtGarantia.Rows[0]["cTipoDocumento"].ToString();
                txtValor.Text = dtGarantia.Rows[0]["nValor"].ToString();
            }
            else if(this.nMontoInmueble == 0 && dtGarantia.Rows.Count > 0)
            {
                txtDescripcion.Text = dtGarantia.Rows[0]["cDescripcion"].ToString();
                txtTipoDocumento.Text = dtGarantia.Rows[0]["cTipoDocumento"].ToString();
                txtValor.Text = dtGarantia.Rows[0]["nValor"].ToString();
            }
            else
            {
                txtDescripcion.Text = string.Empty;
                txtTipoDocumento.Text = string.Empty;
                txtValor.Text = string.Empty;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            clsCNGarantiaRural cnGarantia = new clsCNGarantiaRural();
            DataTable dtGarantia = cnGarantia.ListarGarantiaRuralid(this.idEvalCred);
            if(dtGarantia.Rows.Count > 0)
                cnGarantia.ActualizarGarantiaRural(Convert.ToInt32(dtGarantia.Rows[0]["idGarantia"]), this.idEvalCred, txtDescripcion.Text, txtTipoDocumento.Text, Convert.ToDecimal(txtValor.Text), clsVarGlobal.User.idUsuario, DateTime.Now);
            else
                cnGarantia.InsertarGarantiaRural(this.idEvalCred, txtDescripcion.Text, txtTipoDocumento.Text, Convert.ToDecimal(txtValor.Text), clsVarGlobal.User.idUsuario, DateTime.Now);

            btnGrabar1.Enabled = false;
        }
    }
}

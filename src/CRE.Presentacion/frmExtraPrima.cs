using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExtraPrima : frmBase
    {
        #region Variables
        private clsCNSolicitud clsSolicitud = new clsCNSolicitud();
        public int idSolicitud = 0;
        public double nExtraPrima = 0;
        public bool lAceptar = false;
        #endregion
        #region Metodos
        public frmExtraPrima()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmExtraPrima_Load(object sender, EventArgs e)
        {
            DataTable dtExtraPrima = clsSolicitud.CNObtenerExtraPrima(idSolicitud);
            if (dtExtraPrima.Rows.Count > 0)
            {
                if (Convert.ToDecimal(dtExtraPrima.Rows[0]["nValor"]) != 0)
                {
                    txtExtraPrima.Text = dtExtraPrima.Rows[0]["nValor"].ToString();
                    txtSustento.Text = dtExtraPrima.Rows[0]["cSustento"].ToString();
                }
                else
                {
                    txtExtraPrima.Text = "";
                    txtSustento.Text = "";
                }
            }
            else
            {
                txtExtraPrima.Text = "";
                txtSustento.Text = "";
            }
            lAceptar = false;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtExtraPrima.Text) <= 0)
            {
                MessageBox.Show("El monto de la Extra Prima debe ser mayor a cero", "Extra Prima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSustento.Text == "")
            {
                MessageBox.Show("Se debe registrar un sustento", "Extra Prima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtResultado = clsSolicitud.CNGuardarExtraPrima(
                Convert.ToDecimal(txtExtraPrima.Text),
                txtSustento.Text,
                idSolicitud,
                clsVarGlobal.PerfilUsu.idUsuario,
                clsVarGlobal.PerfilUsu.idPerfil
                );

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Extra Prima", MessageBoxButtons.OK, Convert.ToInt32(dtResultado.Rows[0]["idResultado"])==1?MessageBoxIcon.Information:MessageBoxIcon.Warning);
                if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 0)
                {
                    return;
                }
            }

            nExtraPrima = Convert.ToDouble(txtExtraPrima.Text);
            lAceptar = true;
            this.Dispose();
        }
        #endregion
    }
}

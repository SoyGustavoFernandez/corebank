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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmExcepcionSobreendeudamiento : frmBase
    {
        public int idSolicitud;
        public int idCliente;
        public int idTipoOpe;

        public frmExcepcionSobreendeudamiento()
        {
            InitializeComponent();
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            clsCNEvalConsumo cnEvalConsumo = new clsCNEvalConsumo();
            DataTable tbSolApr = cnEvalConsumo.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, idCliente, 2, 1,
                                                                1, 1, 0, Convert.ToInt32(idSolicitud), clsVarGlobal.dFecSystem, 3,
                                                                txtMotivo.Text, 0, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, clsVarGlobal.PerfilUsu.idPerfil);

            DataTable dtResultado = cnEvalConsumo.CNExepcion(Convert.ToInt32(idSolicitud), clsVarGlobal.User.idUsuario, idTipoOpe);

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show("Se registró SOLICITUD Excepcion : "+Convert.ToString(dtResultado.Rows[0]["idSolaproba"].ToString()), "Excepción Sobreendeudamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEnviar1.Enabled = false;
            }

        }
    }
}

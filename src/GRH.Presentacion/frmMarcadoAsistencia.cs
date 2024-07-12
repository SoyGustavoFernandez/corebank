using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmMarcadoAsistencia : frmBase
    {
        public frmMarcadoAsistencia()
        {
            InitializeComponent();
        }

        private void frmMarcadoAsistencia_Load(object sender, EventArgs e)
        {
            int idUsuario = clsVarGlobal.PerfilUsu.idUsuario;

            conBusPersonal.txtCod.Text = idUsuario.ToString();
            conBusPersonal.BusPerByCod();
            conBusPersonal.HabilitarControles(false);
        }

        private void btnMarcarAsistencia_Click(object sender, EventArgs e)
        {
            clsCNControlAsistencia objControlAsistencia = new clsCNControlAsistencia();

            DataTable dtMarcarAsistencia = objControlAsistencia.CNMarcarAsistenciaPC(Convert.ToInt32(conBusPersonal.txtCod.Text));
            MessageBox.Show(dtMarcarAsistencia.Rows[0]["cMensaje"].ToString(), "Marcado de Asistencia", MessageBoxButtons.OK, ((int)dtMarcarAsistencia.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtMarcarAsistencia.Rows[0]["idError"] != 0) return;
        }
    }
}

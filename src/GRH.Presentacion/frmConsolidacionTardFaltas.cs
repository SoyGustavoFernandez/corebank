using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;


namespace GRH.Presentacion
{ 
    public partial class frmConsolidacionTardFaltas : frmBase
    {
        private DataTable dtConsulta;
        private int permiso = 0;
        public frmConsolidacionTardFaltas()
        {
            InitializeComponent();
        }

        private void frmConsolidacionTardFaltas_Load(object sender, EventArgs e)
        {
            cboPeriodo.ListarPeriodoVigenteTipoPlanilla(1);
            permiso = 1;
            cboPeriodo.SelectedIndex = -1;
        }
        

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (cboPeriodo.Text == "") {
                MessageBox.Show("Debe Seleccionar el Periodo ", "Consolidación de Tardanzas y Faltas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;            
            }
            int idPeriodo=Convert.ToInt32(cboPeriodo.SelectedValue);
            clsCNProcesosGenerales ConsolidacionTardanFaltas = new clsCNProcesosGenerales();
            if (dtConsulta.Rows.Count == 0){

                ConsolidacionTardanFaltas.Consolidar(0, idPeriodo,clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem );                           
                MessageBox.Show("El proceso de Consolidación de Tardanzas y Faltas se realizó correctamente  ", "Consolidación de Tardanzas y Faltas", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            
            }
            if (dtConsulta.Rows.Count > 0)   {

                ConsolidacionTardanFaltas.Consolidar(1, idPeriodo,clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem );         
                MessageBox.Show("El Re-proceso de Consolidación de Tardanzas y Faltas se realizó correctamente  ", "Consolidación de Tardanzas y Faltas", MessageBoxButtons.OK, MessageBoxIcon.Information);                     
            }
            cboPeriodo.SelectedIndex = -1;
            cboPeriodo.SelectedValue = idPeriodo;
        }

        private void cboPeriodo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (permiso == 1 && cboPeriodo.Text != "")
            {
                clsCNProcesosGenerales ConsolidacionTardanFaltas = new clsCNProcesosGenerales();
                dtConsulta = ConsolidacionTardanFaltas.ConsultaConsolidacion(Convert.ToInt32(cboPeriodo.SelectedValue));

                if (dtConsulta.Rows.Count == 0)
                {
                    lblMensaje.Text = "Todavía no se ha realizado la consolidación de Tardanzas y Faltas para este Periodo";
                    lblMensaje.ForeColor = System.Drawing.Color.Navy;
                }
                if (dtConsulta.Rows.Count > 0)
                {
                    lblMensaje.Text = "El día " + (Convert.ToDateTime(dtConsulta.Rows[0]["dFechaRegistro"])).ToShortDateString() + " se realizó la consolidación de Tardanzas y Faltas para este Periodo, si desea puede Re-procesar la Consolidación";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

    }
}

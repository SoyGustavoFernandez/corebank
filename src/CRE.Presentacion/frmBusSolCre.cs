using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmBusSolCre : frmBase
    {
        Int32 nNumCliente;
        Int32 nNumEvalCons;
        public Int32 nNumSolicitud;
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        DataTable dtLisSolEstSol = new DataTable();
        public Int16 nFormCall = 0;//1 eval consumo  2 eval empresarial
        DataTable dtRegRelEvaConSol;

        public frmBusSolCre()
        {
            InitializeComponent();              
        }
              
        public void cargadatos(Int32 nIdCliente, Int32 nIdEvalCons)
        {
            nNumCliente     = nIdCliente;
            nNumEvalCons    = nIdEvalCons;
            //dtLisSolEstSol = Solicitud.CNdtLisSolEstSol(nNumCliente);
            if (nFormCall == 1)
            {
                dtLisSolEstSol = Solicitud.CNdtLisSolEstSolxTipoEva(nNumCliente, 1);
                dtLisSolEstSol.DefaultView.RowFilter = ("nTipCre=3");
            }
            else if (nFormCall == 2)
            {
                dtLisSolEstSol = Solicitud.CNdtLisSolEstSolxTipoEva(nNumCliente, 2);
                dtLisSolEstSol.DefaultView.RowFilter = ("nTipCre in (2,10,11,12,13)");
            }
            this.dtgSolCreditos.DataSource = dtLisSolEstSol;
        }

        private void frmBusSolCre_Load(object sender, EventArgs e)
        {
            dtgSolCreditos.Columns["idSolicitud"].HeaderText = "Solicitud";
            dtgSolCreditos.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolCreditos.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgSolCreditos.Columns["nTasaCompensatoria"].HeaderText = "Tasa";
            dtgSolCreditos.Columns["dFechaRegistro"].HeaderText = "Fecha Reg";
            dtgSolCreditos.Columns["nTipCre"].Visible = false;
            dtgSolCreditos.Columns["nSubPro"].Visible = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dtgSolCreditos.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar un crédito para vincular con la evaluación.", "Vinculacion de Evaluacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Int32 nFilaActual = Convert.ToInt32(this.dtgSolCreditos.SelectedCells[0].RowIndex);
            nNumSolicitud = Convert.ToInt32(this.dtgSolCreditos.Rows[nFilaActual].Cells["idSolicitud"].Value);
            
            if (nFormCall == 1)
            {
                dtRegRelEvaConSol = Solicitud.CNdtRegRelEvaConSol(nNumSolicitud, nNumEvalCons, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            }
            else if (nFormCall == 2)
            {
                dtRegRelEvaConSol = Solicitud.CNdtRegRelEvaEmprSol(nNumSolicitud, nNumEvalCons, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            }
            
            if (dtRegRelEvaConSol.Rows.Count > 0)
            {
                MessageBox.Show("Relación Registrada Correctamente", "Vinculacion de Evaluacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo registrar la relación", "Vinculacion de Evaluacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Dispose();
        }      
    }
}

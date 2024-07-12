using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using GEN.CapaNegocio;



namespace CRE.Presentacion
{
    public partial class FrmBusEvaConsumo : frmBase
    {
        Int32 nNumCliente;
        Int32 nNumSolCre;
		public Int32 nNumEvalCons;
        clsCNEvalConsumo EvalConCre = new clsCNEvalConsumo();
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        clsCNSolicitud EstadoSolicituCre = new clsCNSolicitud();
        DataTable dtLisEvaConCre = new DataTable();
        DataTable dtEstadoSolicituCre = new DataTable();

        public FrmBusEvaConsumo()
        {
            InitializeComponent();
        }
        public void cargadatos(Int32 nIdCliente, Int32 nIdSolCre, Int32 TipoCred)
        {
            nNumCliente = nIdCliente;
            nNumSolCre = nIdSolCre;
            dtEstadoSolicituCre = EstadoSolicituCre.CNListaEstadoSolCre(nNumSolCre);

            if (Convert.ToInt32(dtEstadoSolicituCre.Rows[0]["idEstado"])== 1)
            {
                if (TipoCred == 3)
                {
                    dtLisEvaConCre = EvalConCre.CNdtListEvalConCre(nNumCliente);
                    if (dtLisEvaConCre.Rows.Count>0)
                    {
                        this.dtgEvaConCredit.DataSource = dtLisEvaConCre;
                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Solicitud YA VINCULADA O NO EXISTE Evaluación para Vincular", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (TipoCred.In(2, 11, 12, 13))
                {
                    MessageBox.Show("Vicular con una evaluacion EMPRESARIA", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("El tipo de credito no necesita evaluación", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El Estado de la solicitud diferente a SOLICITADO", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
            
        }
        private void FrmBusEvaConsumo_Load(object sender, EventArgs e)
        {
            dtgEvaConCredit.Columns["IdEvalConsumo"].HeaderText = "N° Evaluac.";
            dtgEvaConCredit.Columns["IngTotal"].HeaderText = "Ingreso";
            dtgEvaConCredit.Columns["EgrTotal"].HeaderText = "Egreso";
            dtgEvaConCredit.Columns["nPorCenIngReal"].HeaderText = "% Ingr. Real";
            dtgEvaConCredit.Columns["IdMoneda"].HeaderText = "Moneda";
            dtgEvaConCredit.Columns["dFechaReg"].HeaderText = "Fecha Reg";
            

        }
        private void btnGrabarEvaCon_Click(object sender, EventArgs e)
        {
            Int32 nFilaActual = Convert.ToInt32(this.dtgEvaConCredit.SelectedCells[0].RowIndex);
            nNumEvalCons = Convert.ToInt32(this.dtgEvaConCredit.Rows[nFilaActual].Cells["idEvalConsumo"].Value);
            DataTable dtRegRelEvaConSol = Solicitud.CNdtRegRelEvaConSol(nNumSolCre, nNumEvalCons, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (dtRegRelEvaConSol.Rows.Count > 0)
            {
                MessageBox.Show("Relación Registrada Correctamente", "Registra Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo registrar la relación", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Dispose();
        }
    }
}

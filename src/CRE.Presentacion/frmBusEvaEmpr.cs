using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

using GEN.ControlesBase;
using CRE.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmBusEvaEmpr : frmBase
    {
        Int32 nNumCliente;
        Int32 nNumSolCre;
		public Int32 nNumEvalCons;
        clsCNEvalEmp EvalEmpr = new clsCNEvalEmp();
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        clsCNSolicitud EstadoSolicituCre = new clsCNSolicitud();
        DataTable dtLisEvaEmprCre = new DataTable();
        DataTable dtEstadoSolicituCre = new DataTable();

        public frmBusEvaEmpr()
        {
            InitializeComponent();
        }
        public void cargadatos(Int32 nIdCliente, Int32 nIdSolCre, Int32 TipoCred)
        {
            nNumCliente = nIdCliente;
            nNumSolCre = nIdSolCre;
            dtEstadoSolicituCre = EstadoSolicituCre.CNListaEstadoSolCre(nNumSolCre);

            if (Convert.ToInt32(dtEstadoSolicituCre.Rows[0]["idEstado"]) == 1)
            {
                if (TipoCred == 3)
                {
                    MessageBox.Show("Vincular con una evaluacion CONSUMO", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TipoCred.In(2, 11, 12, 13))
                {
                    dtLisEvaEmprCre = EvalEmpr.CNdtListEvalEmprCre(nNumCliente);
                    if (dtLisEvaEmprCre.Rows.Count>0)
                    {
                        this.dtgEvaEmprCredit.DataSource = dtLisEvaEmprCre;
                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Solicitud YA VINCULADA O NO EXISTE Evaluación para Vincular", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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

        private void frmBusEvaEmpr_Load(object sender, EventArgs e)
        {
            dtgEvaEmprCredit.Columns["IdEvalEmp"].HeaderText = "N° Evaluac.";
            dtgEvaEmprCredit.Columns["nDeuSisFin"].HeaderText = "Deuda Sist. Fin.";
            dtgEvaEmprCredit.Columns["nMonPropuesto"].HeaderText = "Monto Propuesto";
            dtgEvaEmprCredit.Columns["nCuotaAprox"].HeaderText = "Cuota Aprox ";
            dtgEvaEmprCredit.Columns["IdMoneda"].HeaderText = "Moneda";
            dtgEvaEmprCredit.Columns["dFechaReg"].HeaderText = "Fecha Reg";
        }

        private void btnGrabarEvaCon_Click(object sender, EventArgs e)
        {
            Int32 nFilaActual = Convert.ToInt32(this.dtgEvaEmprCredit.SelectedCells[0].RowIndex);
            nNumEvalCons = Convert.ToInt32(this.dtgEvaEmprCredit.Rows[nFilaActual].Cells["IdEvalEmp"].Value);
            DataTable dtRegRelEvaEmprSol = Solicitud.CNdtRegRelEvaEmprSol(nNumSolCre, nNumEvalCons, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (dtRegRelEvaEmprSol.Rows.Count > 0)
            {
                MessageBox.Show("Relación Registrada Correctamente", "Registro de Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo registrar la relación", "Valida Evaluación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Dispose();
        }
    }
}

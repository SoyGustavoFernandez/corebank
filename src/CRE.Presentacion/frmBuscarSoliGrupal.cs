using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;



namespace CRE.Presentacion
{
    public partial class frmBuscarSoliGrupal : frmBase
    {
        #region Variables Globales
        int idGrupoSolidario = 0;
        public int idSolicitudGS = 0;
        public int idModalidadCredito = 0;
        clsCNPlanPago BuscarSoli = new clsCNPlanPago();
        

        #endregion


        public frmBuscarSoliGrupal()
        {
            InitializeComponent();
        }
        
        public frmBuscarSoliGrupal(int idGrupoSol)
        {
            InitializeComponent();
            idGrupoSolidario = idGrupoSol;
            ConsultaSolic(idGrupoSolidario);
        }

        public frmBuscarSoliGrupal(int idGrupoSol,int nIdentificador)
        {
            InitializeComponent();
            idGrupoSolidario = idGrupoSol;
            ConsultaSolicBuscar(idGrupoSolidario);
        }

        public void ConsultaSolic(int idGS)
        {
            
            DataTable DatosGS1 = BuscarSoli.CNdtBuscarSoliGrupal(idGS);

           dtgBase2.DataSource = DatosGS1;
            
           FormatearDataGrid();
         
        }

        public void ConsultaSolicBuscar(int idGS)
        {

            DataTable DatosGS1 = BuscarSoli.CNdtBuscarSoliGrupal2(idGS);

            dtgBase2.DataSource = DatosGS1;

            FormatearDataGrid2();

        }

        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgBase2.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgBase2.Columns["idSolicitudCredGrupoSol"].DisplayIndex = 0;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].DisplayIndex = 1;
            dtgBase2.Columns["nCapAprob"].DisplayIndex = 2;
            dtgBase2.Columns["nCuotas"].DisplayIndex = 3;
            dtgBase2.Columns["nSaldoCap"].DisplayIndex = 4;
      

            dtgBase2.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].Visible = true;
            dtgBase2.Columns["nCapAprob"].Visible = true;
            dtgBase2.Columns["nCuotas"].Visible = true;
            dtgBase2.Columns["nSaldoCap"].Visible = true;

            dtgBase2.Columns["idSolicitudCredGrupoSol"].HeaderText = "N° Solicitud de Grupo";
            dtgBase2.Columns["dFechaDesembolsoSugerido"].HeaderText = "Fecha Desembolso";
            dtgBase2.Columns["nCapAprob"].HeaderText = "Capital Aprobado";
            dtgBase2.Columns["nCuotas"].HeaderText = "N° de Cuotas";
            dtgBase2.Columns["nSaldoCap"].HeaderText = "Saldo Capital";

            dtgBase2.Columns["idSolicitudCredGrupoSol"].FillWeight = 30;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].FillWeight = 30;
            dtgBase2.Columns["nCapAprob"].FillWeight = 30;
            dtgBase2.Columns["nCuotas"].FillWeight = 20;
            dtgBase2.Columns["nSaldoCap"].FillWeight = 30;
          

        }

        private void FormatearDataGrid2()
        {
            foreach (DataGridViewColumn column in this.dtgBase2.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgBase2.Columns["idSolicitudCredGrupoSol"].DisplayIndex = 0;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].DisplayIndex = 1;
            dtgBase2.Columns["nCapAprob"].DisplayIndex = 2;
            dtgBase2.Columns["nCuotas"].DisplayIndex = 3;
            dtgBase2.Columns["nSaldoCap"].DisplayIndex = 4;
            dtgBase2.Columns["cEstado"].DisplayIndex = 5;


            dtgBase2.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].Visible = true;
            dtgBase2.Columns["nCapAprob"].Visible = true;
            dtgBase2.Columns["nCuotas"].Visible = true;
            dtgBase2.Columns["nSaldoCap"].Visible = true;
            dtgBase2.Columns["cEstado"].Visible = true;

            dtgBase2.Columns["idSolicitudCredGrupoSol"].HeaderText = "N° Solicitud de Grupo";
            dtgBase2.Columns["dFechaDesembolsoSugerido"].HeaderText = "Fecha Desembolso";
            dtgBase2.Columns["nCapAprob"].HeaderText = "Capital Aprobado";
            dtgBase2.Columns["nCuotas"].HeaderText = "N° de Cuotas";
            dtgBase2.Columns["nSaldoCap"].HeaderText = "Saldo Capital";
            dtgBase2.Columns["cEstado"].HeaderText = "Estado";

            dtgBase2.Columns["idSolicitudCredGrupoSol"].FillWeight = 30;
            dtgBase2.Columns["dFechaDesembolsoSugerido"].FillWeight = 30;
            dtgBase2.Columns["nCapAprob"].FillWeight = 30;
            dtgBase2.Columns["nCuotas"].FillWeight = 20;
            dtgBase2.Columns["nSaldoCap"].FillWeight = 30;
            dtgBase2.Columns["cEstado"].FillWeight = 30;


        }





        private void btnAceptar1_Click(object sender, System.EventArgs e)
        {
            if (dtgBase2.RowCount >= 1)
            {
                int idSoliGS = Convert.ToInt32(dtgBase2.Rows[dtgBase2.SelectedCells[0].RowIndex].Cells["idSolicitudCredGrupoSol"].Value.ToString());
                idSolicitudGS = idSoliGS;
                this.idModalidadCredito = Convert.ToInt32(dtgBase2.Rows[dtgBase2.SelectedCells[0].RowIndex].Cells["idModalidadCredito"].Value);
                this.Dispose();
            }
            else 
            {
                idSolicitudGS = 0;
                this.idModalidadCredito = 0;
                this.Dispose();
            }

        }

        private void dtgBase1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }







    }
}

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
using System.Collections;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CRE.CapaNegocio;
namespace CRE.Presentacion
{
    public partial class frmBuscarEstadoPagoGrupal : frmBase
    {
        #region Variables Globales
        int idCli = 0;
        int idSolGS;
        string cTitulo = "Buscar estado Pago Grupal";
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        int nElimina = 0;
        DataTable dtPagos;
        #endregion

        #region Funciones

        public frmBuscarEstadoPagoGrupal()
        {
            InitializeComponent();
            this.conBusGrupoSol1.LimpiarControl();
            this.conBusGrupoSol1.Enabled = true;

        }
        private void btnGrupo1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.RowCount >= 1)
            {
                int idCuenta = Convert.ToInt32(dtgBase1.Rows[dtgBase1.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString());

                DataTable dtCliente = new clsCNPlanPago().CNdtCiente(idCuenta);

                FrmPosicionCli frmposicioncli = new FrmPosicionCli(Convert.ToInt32(dtCliente.Rows[0]["idCli"].ToString()), Convert.ToString(conBusGrupoSol1.txtIdGrupoSolidario.Text), Convert.ToString(conBusGrupoSol1.txtNombreGrupo.Text));
                frmposicioncli.ShowDialog();

            }

            
        }
              
        
        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            int idGrupoSol;


            idGrupoSol = this.conBusGrupoSol1.idGrupoSolidario;

            BuscarSoli(idGrupoSol);

        }

        #endregion

       

        #region Metodos

     
        public void BuscarSoli(int idGrupo)
        {
            if (idGrupo != 0)
            {
                frmBuscarSoliGrupal Buscar = new frmBuscarSoliGrupal(idGrupo,1);
                Buscar.ShowDialog();
                idSolGS = Buscar.idSolicitudGS;

                CargarPlanGrupal(idGrupo, idSolGS);

            }
            else
            {
                MessageBox.Show("El N° de Grupo debe de ser diferente a 0.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void CargarPlanGrupal(int idGrupoSol, int idSolicitudGS)
        {
            if (idSolicitudGS == 0)
            {
                MessageBox.Show("El grupo no tiene alguna solicitud activa o no se selecciono una solicitud.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtPlanPagosGrupal = new clsCNPlanPago().CNdtPlanPagoGrupal(idGrupoSol, idSolicitudGS);

            this.dtgBase1.DataSource = dtPlanPagosGrupal;
            dtPagos = dtPlanPagosGrupal;
            
            FormatearDataGrid();

            DataTable dtDatosAsesor = new clsCNPlanPago().CNdtPlanPagoGrupalDatos(idSolGS);
            this.txtBase1.Text = Convert.ToString(dtDatosAsesor.Rows[0]["cNombreAsesor"].ToString());

            this.conBusGrupoSol1.btnBusqueda.Enabled = false;
            this.btnImprimir1.Enabled = true;
            this.btnGrupo1.Enabled = true;
            contarIntegrantes();

        }
    
        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgBase1.Columns["idCuenta"].DisplayIndex = 0;
            dtgBase1.Columns["cNombre"].DisplayIndex = 1;
            dtgBase1.Columns["nCapitalDesembolso"].DisplayIndex = 2;
            dtgBase1.Columns["nMonto"].DisplayIndex = 3;
            dtgBase1.Columns["nCuotasPagadas"].DisplayIndex = 4;
            dtgBase1.Columns["nAtraso"].DisplayIndex = 5;
            dtgBase1.Columns["nCapitalPagado"].DisplayIndex = 6;
            dtgBase1.Columns["nCapitalxPagar"].DisplayIndex = 7;
            dtgBase1.Columns["cEstado"].DisplayIndex = 8;

         //   dtgBase1.Columns["chk"].DisplayIndex = 8;

            dtgBase1.Columns["idCuenta"].Visible = true;
            dtgBase1.Columns["cNombre"].Visible = true;
            dtgBase1.Columns["nCapitalDesembolso"].Visible = true;
            dtgBase1.Columns["nMonto"].Visible = true;
            dtgBase1.Columns["nCuotasPagadas"].Visible = true;
            dtgBase1.Columns["nAtraso"].Visible = true;
            dtgBase1.Columns["nCapitalPagado"].Visible = true;
            dtgBase1.Columns["nCapitalxPagar"].Visible = true;
            dtgBase1.Columns["cEstado"].Visible = true;

          //  dtgBase1.Columns["chk"].Visible = true;


            dtgBase1.Columns["idCuenta"].HeaderText = "N° Cuenta";
            dtgBase1.Columns["cNombre"].HeaderText = "Nombre de Cliente";
            dtgBase1.Columns["nCapitalDesembolso"].HeaderText = "Cap. Desemb.";
            dtgBase1.Columns["nMonto"].HeaderText = "Monto a Pagar";
            dtgBase1.Columns["nCuotasPagadas"].HeaderText = "Cuotas Pagadas";
            dtgBase1.Columns["nAtraso"].HeaderText = "Atraso";
            dtgBase1.Columns["nCapitalPagado"].HeaderText = "Cap. Pagado";
            dtgBase1.Columns["nCapitalxPagar"].HeaderText = "Saldo Capital";
            dtgBase1.Columns["cEstado"].HeaderText = "Estado";

          //  dtgBase1.Columns["chk"].HeaderText = "Sel.";


            dtgBase1.Columns["idCuenta"].FillWeight = 30;
            dtgBase1.Columns["cNombre"].FillWeight = 100;
            dtgBase1.Columns["nCapitalDesembolso"].FillWeight = 35;
            dtgBase1.Columns["nMonto"].FillWeight = 35;
            dtgBase1.Columns["nCuotasPagadas"].FillWeight = 30;
            dtgBase1.Columns["nAtraso"].FillWeight = 20;
            dtgBase1.Columns["nCapitalPagado"].FillWeight = 35;
            dtgBase1.Columns["nCapitalxPagar"].FillWeight = 35;
            dtgBase1.Columns["cEstado"].FillWeight = 35;

           // dtgBase1.Columns["chk"].FillWeight = 15;

           // dtgBase1.Columns["chk"].Selected = true;
            //dtgBase1.Columns["nMonto"].DefaultCellStyle.Format = "### ### ##0.00";
            //dtgBase1.Columns["nTea"].DefaultCellStyle.Format = "##0.00";
            //dtgBase1.Columns["nTasaMoratoria"].DefaultCellStyle.Format = "##0.00";
            //
            dtgBase1.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }


        
        
        
        #endregion

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.conBusGrupoSol1.LimpiarControl();
            this.dtgBase1.DataSource = null;
            idCli = 0;
            idSolGS=0;
            this.dtPagos=null;
            this.btnImprimir1.Enabled = false;
            this.btnGrupo1.Enabled = false;
            this.txtBase2.Text = null;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void contarIntegrantes()
        {
            string nFilas = Convert.ToString(this.dtgBase1.RowCount);
            this.txtBase2.Text = nFilas;
        }

        private void Imprimir()
        {
           

            if (dtPagos.Rows.Count > 0)
            {
                DataTable dtDatos = new clsCNPlanPago().CNdtPlanPagoGrupalDatos(idSolGS);
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("DataSet1", dtPagos));
                dtsList.Add(new ReportDataSource("DataSet2", dtDatos));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idGrupo", Convert.ToString(0), false));
                paramlist.Add(new ReportParameter("idSoliGS", idSolGS.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", clsVarGlobal.dFecSystem.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

                string reportPath = "rptPagosPorGrupo.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta Solicitud de Excepcion No Contemplada.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }


    }
}

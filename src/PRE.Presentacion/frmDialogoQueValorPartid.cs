using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using PRE.CapaNegocio;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRE.Presentacion
{
    public partial class frmDialogoQueValorPartid : frmBase
    {
        #region Variables Globales
        int idPeriodo = 0;
        String cPeriodo = String.Empty;
        String cEstructura = String.Empty;
        private String cTituloMensaje = "Reporte detalle de partidas";
        #endregion
        public frmDialogoQueValorPartid()
        {
            InitializeComponent();                 
        }
        #region Eventos
        private void frmDialogoQueValorPartid_Load(object sender, EventArgs e)
        {
            cargaComboCriterio();
        }
        private void cboPeriodoPresupuestal1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            verificarEstadoPeriodo();
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            this.idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            this.cPeriodo = Convert.ToString(((DataRowView)this.cboPeriodoPresupuestal1.SelectedItem)[this.cboPeriodoPresupuestal1.DisplayMember]);
            this.cEstructura = Convert.ToString(((DataRowView)this.cboEstructuraPresupuesto.SelectedItem)[this.cboEstructuraPresupuesto.ValueMember]);
            String cNombreValor = Convert.ToString(((DataRowView)this.cboQueValor.SelectedItem)["cDes"]);
            int idCriterio = Convert.ToInt32(this.cboQueValor.SelectedValue);
            int idMes = Convert.ToInt32(this.cboMes.SelectedValue);
            if (cEstructura.Length == 0) cEstructura = " ";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idPeriodo", idPeriodo.ToString(), false));
            paramlist.Add(new ReportParameter("cAnioPres", cPeriodo, false));
            paramlist.Add(new ReportParameter("idMesInicio", this.cboMes.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("cEstructura", cEstructura, false));
            paramlist.Add(new ReportParameter("idCriterioValor", idCriterio.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreValor", cNombreValor, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            clsRPTCNPresupuestos rptcnpresupuestos = new clsRPTCNPresupuestos();
            DataTable dtDetalle = rptcnpresupuestos.listarDetallePartida(idPeriodo, cEstructura, idCriterio, idMes);
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para esos filtros", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtslist.Add(new ReportDataSource("DataSet1", dtDetalle));
            string reportpath = "rptDetallePartidasPres.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        
        #endregion
        #region Metodos
        private void cargaComboCriterio()
        {
            DataTable dtQueValor = new DataTable();
            dtQueValor.Columns.Add("id", typeof(int));
            dtQueValor.Columns.Add("cDes", typeof(String));
            DataRow drValor1 = dtQueValor.NewRow();
            drValor1["id"] = 1;
            drValor1["cDes"] = "Presupuesto Apertura";
            dtQueValor.Rows.Add(drValor1);
            DataRow drValor2 = dtQueValor.NewRow();
            drValor2["id"] = 2;
            drValor2["cDes"] = "Presupuesto Modificado";
            dtQueValor.Rows.Add(drValor2);
            DataRow drValor3 = dtQueValor.NewRow();
            drValor3["id"] = 3;
            drValor3["cDes"] = "Presupuesto Ejecutado";
            DataRow drValor4 = dtQueValor.NewRow();
            dtQueValor.Rows.Add(drValor3);
            drValor4["id"] = 4;
            drValor4["cDes"] = "Saldo";
            dtQueValor.Rows.Add(drValor4);

            this.cboQueValor.DataSource = dtQueValor;
            this.cboQueValor.ValueMember = "id";
            this.cboQueValor.DisplayMember = "cDes";
            
        }
        private void verificarEstadoPeriodo()
        {
            int idEstadoPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "idEstado"));
            this.lblPlanificacion.Text = this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "cEstado");
            if (idEstadoPeriodo == 1)   // 1 = planificacion
            {
                this.lblPlanificacion.ForeColor = Color.DarkGreen;                
            }
            else if (idEstadoPeriodo == 2)
            {
                this.lblPlanificacion.ForeColor = Color.RoyalBlue;               
            }
            else
            {
                this.lblPlanificacion.ForeColor = Color.Gray;                
            }
        }
        #endregion              
    }
}

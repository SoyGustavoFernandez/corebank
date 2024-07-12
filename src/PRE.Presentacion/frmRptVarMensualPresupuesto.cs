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
using GEN.BotonesBase;
using PRE.CapaNegocio;
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace PRE.Presentacion
{
    public partial class frmRptVarMensualPresupuesto : frmBase
    {
        #region Variables Globales
        int idPeriodoSelec;
        bool lEsEjecucion;
        clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        #endregion
        #region Eventos
        public frmRptVarMensualPresupuesto()
        {
            InitializeComponent();
        }
        private void frmRptVarMensualPresupuesto_Load(object sender, EventArgs e)
        {
            verificarPeriodo();
            habilitarImprimir();            
            formatoCboTipoModificacion();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }
        private void cboPeriodoPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarPeriodo();
            habilitarImprimir();
        }
        #endregion
        #region Metodos
        private void verificarPeriodo()
        {
            if (cboPeriodoPresupuestal.SelectedItem == null)
            {
                return;
            }
            else
            {
                idPeriodoSelec = Convert.ToInt32(this.cboPeriodoPresupuestal.SelectedValue);
                DataTable dtPeriodoSelect = new clsCNPeriodos().PeriodosPresupuesto(idPeriodoSelec);
                this.lblEstado.Text = Convert.ToString(dtPeriodoSelect.Rows[0]["cEstado"]);
                int nEstado = Convert.ToInt32(dtPeriodoSelect.Rows[0]["idEstado"]);
                if (nEstado == 2)
                {
                    this.lblEstado.ForeColor = Color.RoyalBlue;
                    lEsEjecucion = true;
                }
                else if (nEstado == 1)
                {
                    this.lblEstado.ForeColor = Color.DarkGreen;
                    lEsEjecucion = false;
                }
                else
                {
                    this.lblEstado.ForeColor = Color.Gray;
                    lEsEjecucion = false;
                }
            }
        }
        private void imprimirReporte()
        {
            clsRPTCNPresupuestos rptcnpresupuestos = new clsRPTCNPresupuestos();
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cPeriodo = cboPeriodoPresupuestal.Text.ToString();
            int nPeriodo = Convert.ToInt16(cboPeriodoPresupuestal.SelectedValue);
            string cEstructura = cboEstructuraPresupuesto.SelectedValue.ToString();

            if (cEstructura.Length == 0)cEstructura = " ";

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idPeriodo", cPeriodo, false));
            paramlist.Add(new ReportParameter("cEstructura", cEstructura, false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            int nTipoModificacion = Convert.ToInt16(cboTipoModificacion.SelectedValue);
            DataTable dtVariacionMensual = rptcnpresupuestos.listarVariacionMensual(nPeriodo, cEstructura, nTipoModificacion);
            dtslist.Add(new ReportDataSource("dsVariacionPresMensual", dtVariacionMensual));
            if (nTipoModificacion == 1)
            {
                string reportpath = "rptVariacionMensualReasig.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else 
            {
                string reportpath = "rptVariacionMensualAmpl.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }

        }
        private void habilitarImprimir()
        {
            if (lEsEjecucion)
            {
                btnImprimir.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
            }
            
        }
        private void formatoCboTipoModificacion()
        {
            DataTable dtTipoModificacion = new DataTable();
            dtTipoModificacion.Columns.Add("value", typeof(int));
            dtTipoModificacion.Columns.Add("index", typeof(String));
            DataRow drTipoModificacion = dtTipoModificacion.NewRow();
            drTipoModificacion["value"] = 1;
            drTipoModificacion["index"] = "Reasignación";
            dtTipoModificacion.Rows.Add(drTipoModificacion);
            DataRow drEstructura3 = dtTipoModificacion.NewRow();
            drEstructura3["value"] = 2;
            drEstructura3["index"] = "Ampliación";
            dtTipoModificacion.Rows.Add(drEstructura3);

            this.cboTipoModificacion.DataSource = dtTipoModificacion;
            cboTipoModificacion.ValueMember = "value";
            cboTipoModificacion.DisplayMember = "index";
        }
        #endregion
    }
}
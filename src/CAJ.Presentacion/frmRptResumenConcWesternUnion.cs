using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRptResumenConcWesternUnion : frmBase
    {
        #region Variables
        public DataTable dtListaAgencias;
        public clsCNRegionZona listOficina = new clsCNRegionZona();
        #endregion

        #region Eventos
        public frmRptResumenConcWesternUnion()
        {
            InitializeComponent();
            this.cboZona1.cargarZona(true, false);
        }

        private void frmRptResumenConcWesternUnion_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            clsCNControlOpe cn = new clsCNControlOpe();

            List<ReportParameter> paramList = new List<ReportParameter>();

            if (dtpFechaInicio.Value <= dtpFechaFin.Value && dtpFechaFin.Value <= Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
            {

                DataTable dt = cn.ResumenConciliacionWesternUnion(Convert.ToInt32(cboAgencia.SelectedValue), dtpFechaInicio.Value, dtpFechaFin.Value);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte", "Resumen Conciliación Western Union", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    paramList.Add(new ReportParameter("x_cAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idAgencia", cboAgencia.SelectedValue.ToString(), false));
                    paramList.Add(new ReportParameter("dFechaIni", dtpFechaInicio.Value.Date.ToString("yyyy-MM-dd"), false));
                    paramList.Add(new ReportParameter("dFechaFin", dtpFechaFin.Value.Date.ToString("yyyy-MM-dd"), false));
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsResumenConciliacionWesternUnion", dt));

                    string reportPath = "rptResumenConciliacionWesternUnion.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("La fecha inicial debe de ser menor a la fecha final, ó, las fechas deben de ser menores o iguales al día de hoy.", "Resumen Conciliación Western Union", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        private void cboZona1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cboAgencia.SelectedValue = 0;
            if (this.cboZona1.SelectedValue != null && this.cboZona1.SelectedValue != DBNull.Value)
            {
                if (Convert.ToInt32(this.cboZona1.SelectedValue) == 0)
                {
                    cargarAgencias(0);
                }
                else
                {
                    cargarAgencias(Convert.ToInt32(cboZona1.SelectedValue));
                }
            }
        }
        #endregion

        #region Métodos
        public void cargarAgencias(int v)
        {
            this.dtListaAgencias = listOficina.CNListarOficinaByZona(v);
            DataRow row = dtListaAgencias.NewRow();
            row["idAgencia"] = 0;
            row["cNombreAge"] = "TODAS LAS AGENCIAS";
            dtListaAgencias.Rows.InsertAt(row, 0);
            this.cboAgencia.ValueMember = dtListaAgencias.Columns[0].ToString();
            this.cboAgencia.DisplayMember = dtListaAgencias.Columns[1].ToString();

            this.cboAgencia.DataSource = dtListaAgencias;
        }
        #endregion        
    }
}

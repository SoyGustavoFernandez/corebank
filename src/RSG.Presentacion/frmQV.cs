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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmQV : frmBase
    {
        #region Variable Globales

        string cTitulo = "Reporte quick view";
        clsRPTCNRiesgos cnRiesgos = new clsRPTCNRiesgos();
        int nNumReport = 1;

        #endregion

        public frmQV()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            
            DateTime dFecha = dtpFecha.Value.Date;

            int nPeriodo = Convert.ToInt32(cboPeriodoRiegos1.SelectedValue);
            string cPeriodo = ((DataTable)cboPeriodoRiegos1.DataSource).Rows[Convert.ToInt32(cboPeriodoRiegos1.SelectedIndex)]["cPeriodo"].ToString();
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            string reportpath = String.Empty;
            string cNomRep = "";

            DataTable dtData = null;
            
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramlist.Add(new ReportParameter("cPeriodo", cPeriodo));

            switch (nNumReport)
            {
                case 1: 
                    reportpath = "rptQVAgencia.rdlc";
                    dtData = cnRiesgos.CNQVAgencia(dFecha, nPeriodo);
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " - " + cPeriodo + " REPORTE QUICK VIEW OFICINA";
                    break;
                case 2: 
                    reportpath = "rptQVProducto.rdlc";
                    dtData = cnRiesgos.CNQVProducto(dFecha, nPeriodo);
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " - " + cPeriodo + " REPORTE QUICK VIEW PRODUCTO";
                    break;
                case 3: 
                    reportpath = "rptClientesRiesgoPotencial.rdlc";
                    dtData = cnRiesgos.CNQVCarteraPotencial(dFecha, nPeriodo);
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " - " + cPeriodo + " REPORTE QUICK VIEW CARTERA RIESGO POTENCIAL";
                    break;
                default:
                    break;
            }

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsQV", dtData));

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.LocalReport.DisplayName = cNomRep;
            frmReporte.ShowDialog();

        }

        private void rbtOficina_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 1;
        }

        private void rbtProducto_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 2;
        }

        private void rbtCarteraPotencial_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 3;
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (!rbtOficina.Checked && !rbtProducto.Checked && !rbtCarteraPotencial.Checked)
            {
                MessageBox.Show("Seleccione el reporte a imprimir", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }
            if (dtpFecha.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha seleccionado no puede ser mayor o igual a la fecha del sistema", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            if (cboPeriodoRiegos1.SelectedIndex <0)
            {
                MessageBox.Show("Seleccione el periodo", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }
            return true;
        }
        #endregion
    }
}

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
    public partial class frmCarteraPorAnalista : frmBase
    {
        #region Variable Globales

        int nNroReporte;
        string cRutaReporte;
        
        string cTituloMsjes = "Reporte de Concentración por Analista";

        #endregion

        public frmCarteraPorAnalista()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarDatos();
        }

        private void rbtnCart_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 1;
            cRutaReporte = "rptBasicoCarteraPorAnalista.rdlc";            
            activarControles(true);
        }
        private void rbtnCartOfi_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 2;
            cRutaReporte = "rptBasicoCarteraPorAnalistaOficina.rdlc";            
            activarControles(true);
        }

        private void rbtnHistCap_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 3;
            cRutaReporte = "rptConcHistorialCarteraAnalista.rdlc";
            activarControles(false);
        }

        private void rbtnHistCapMora_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 4;
            cRutaReporte = "rptConcHistorialCarteraAnalistaMorar.rdlc";
            activarControles(false);
        }

        private void rbtnHistMora_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 5;
            cRutaReporte = "rptConcHistorialCarteraAnalistaPorcentajeMora.rdlc";            
            activarControles(false);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            DateTime dFecha = dtpFecha.Value.Date;
            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cNomRep = "";
            string reportpath = String.Empty;

            DataTable dtData = null;

            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            clsRPTCNRiesgos cnRiesgos = new clsRPTCNRiesgos();
            switch (nNroReporte)
            {
                case 1:
                    dtData = cnRiesgos.CNRptConcCartAnalista(dFecha);
                    paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy")));
                    dtslist.Add(new ReportDataSource("dsRptCarteraAnalista", dtData));
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE CARTERA POR ASESOR";
                    break;
                case 2: 
                    dtData = cnRiesgos.CNRptConcCartAnalista(dFecha);
                    paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy")));
                    dtslist.Add(new ReportDataSource("dsRptCarteraAnalista", dtData));
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE CARTERA POR ASESOR POR OFICINA";
                    break;
                case 3:
                    dtData = cnRiesgos.CNHistoricoConCarteraAnalista(dFecIni, dFecFin);
                    dtslist.Add(new ReportDataSource("dsCartera", dtData));
                    cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR ASESOR";
                    break;
                case 4:
                    dtData = cnRiesgos.CNHistoricoConCarteraAnalista(dFecIni, dFecFin);
                    dtslist.Add(new ReportDataSource("dsCartera", dtData));
                    cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA VENCIDA POR ASESOR";
                    break;
                case 5:
                    dtData = cnRiesgos.CNHistoricoConCarteraAnalista(dFecIni, dFecFin);
                    dtslist.Add(new ReportDataSource("dsCartera", dtData));
                    cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA EN MORA POR ASESOR ";
                    break;
                default:
                    break;
            }

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, cRutaReporte, paramlist);
            frmReporte.rpvReporteLocal.LocalReport.DisplayName = cNomRep;
            frmReporte.ShowDialog();
        }
        #endregion

        #region Métodos

        private void activarControles(Boolean lActiva) 
        {
            if (lActiva)
            {
                grbFecha.Enabled = true;
                grbRango.Enabled = false;
            }
            else
            {
                grbFecha.Enabled = false;
                grbRango.Enabled = true;
            }
        }

        private void cargarDatos()
        {
            limpiar();
            nNroReporte = 1;
            activarControles(true);
            cRutaReporte = "rptBasicoCarteraPorAnalista.rdlc";
        }

        private bool validar()
        {
            if (!rbtnCart.Checked && !rbtnCartOfi.Checked && !rbtnHistCap.Checked && !rbtnHistCapMora.Checked && !rbtnHistMora.Checked)
            {
                MessageBox.Show("Seleccione el reporte a mostrar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rbtnHistCap.Checked || rbtnHistCapMora.Checked || rbtnHistMora.Checked)
            {
                if (dtpFecIni.Value.Date > dtpFecFin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha final.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void formatoGrid()
        {

        }

        private void limpiar()
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
            dtpFecIni.Value = clsVarGlobal.dFecSystem.AddYears(-1).Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }

        #endregion

       
    }
}

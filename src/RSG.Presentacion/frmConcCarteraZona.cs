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
    public partial class frmConcCarteraZona : frmBase
    {
        #region Variable Globales

        int nNroReporte;
        string cRutaReporte;
        string cTituloMsjes = "Reporte de concentración por zona geográfica";

        #endregion

        public frmConcCarteraZona()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarDatos();
            activarControles(true);
            activarGrafico(false);
        }

        private void rbtnCart_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 1;
            cRutaReporte = "rptBasicosConcCarteraZona.rdlc";

            activarControles(true);
            activarGrafico(false);
            
        }

        private void rbtnHistCap_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 2;
            activarControles(false);
            activarGrafico(true);
        }

        private void rbtnHistCapMora_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 3;            
            activarControles(false);
            activarGrafico(true);
        }

        private void rbtnHistMora_CheckedChanged(object sender, EventArgs e)
        {
            nNroReporte = 4;
            activarControles(false);
            activarGrafico(true);
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

            string reportpath = String.Empty;
            string cNomRep = "";
            DataTable dtData = null;

            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            clsRPTCNRiesgos cnRiesgos = new clsRPTCNRiesgos();
            switch (nNroReporte)
            {
                case 1:
                    dtData = cnRiesgos.CNRptBasicosConcetracionCarteraPorZona(dFecha);
                    paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy")));
                    dtslist.Add(new ReportDataSource("dsConcCarteZona", dtData));
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " CONCENTRACIÓN DE CARTERA POR ZONA GEOGRÁFICA";
                    break;
                case 2:
                    dtData = cnRiesgos.CNRptBasicosHistoConcetracionCarteraPorZona(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        cRutaReporte = "rptBasicosHistoConcCarteraZona.rdlc";
                        dtslist.Add(new ReportDataSource("dsCartera", dtData));
                        cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR ZONA GEOGRÁFICA";
                    }
                    else
                    {
                        cRutaReporte = "rptGraHistCapZona.rdlc";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                        cNomRep = dFecIni.ToString("yyyy_MM_dd")+"-" +dFecFin.ToString("yyyy_MM_dd")+ " GRÁFICO - HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR ZONA GEOGRÁFICA";
                    }
                    break;
                case 3:
                    dtData = cnRiesgos.CNRptBasicosHistoConcetracionCarteraPorZona(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        cRutaReporte = "rptBasicosHistoConcCarteraMoraZona.rdlc";
                        dtslist.Add(new ReportDataSource("dsCartera", dtData));
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA VENCIDA POR ZONA GEOGRÁFICA";
                    }
                    else
                    {
                        cRutaReporte = "rptGraHistCapVencidoZona.rdlc";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " GRÁFICO - HISTÓRICO DE CONCENTRACIÓN DE CARTERA VENCIDA POR ZONA GEOGRÁFICA";
                    }
                    break;
                case 4:
                    dtData = cnRiesgos.CNRptBasicosHistoConcetracionCarteraPorZona(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        cRutaReporte = "rptBasicosHistoConcCarteraPorcentajeMoraZona.rdlc";
                        dtslist.Add(new ReportDataSource("dsCartera", dtData));
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO ÍNDICE MORA POR ZONA GEOGRÁFICA";
                    }
                    else
                    {
                        cRutaReporte = "rptGraHistIndiceMoraZona.rdlc";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " GRÁFICO - HISTÓRICO ÍNDICE MORA POR ZONA GEOGRÁFICA";
                    }
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
        private void activarGrafico(Boolean lBol)
        {
            grbBase2.Enabled = lBol;
            if (!lBol)
                rbtDetalle.Checked = true;
        }
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
            cRutaReporte = "rptBasicosConcCarteraZona.rdlc";
        }

        private bool validar()
        {
            if (!rbtnCart.Checked && !rbtnHistCap.Checked && !rbtnHistCapMora.Checked && !rbtnHistMora.Checked)
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

        private void limpiar()
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
            dtpFecIni.Value = clsVarGlobal.dFecSystem.AddYears(-1).Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }
        #endregion
    }
}

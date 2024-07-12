using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using RPT.CapaNegocio;
using System.Reflection;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmRouRom : frmBase
    {
        #region Variables Globales
        DateTime dFechaDesde, dFechaHasta;
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Registro de Operaciones Únicas y Múltiples";
        clsRPTCNSplaft CNRegistroOperacionesUnicas = new clsRPTCNSplaft();
        clsRPTCNSplaft CNRegistroOperacionesMultiples = new clsRPTCNSplaft();
        #endregion
        #region Eventos
        public frmRouRom()
        {
            InitializeComponent();
            this.datePicker1.Value = dFechaHoy;
            this.datePicker2.Value = dFechaHoy;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            ReporteROU();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            ReporteROM();
        }
        #endregion
        #region Metodos
        private void ReporteROU()
        {
            dFechaDesde = Convert.ToDateTime(this.datePicker1.Value);
            dFechaHasta = Convert.ToDateTime(this.datePicker2.Value);


            if (dFechaHasta <= dFechaHoy && dFechaDesde <= dFechaHoy)
            {
                if (dFechaDesde <= dFechaHasta)
                {

                    DataTable dtData = CNRegistroOperacionesUnicas.CNRegistroOperacionesUnicas(dFechaDesde, dFechaHasta);//(dFechaDesde, dFechaHasta);
                    if (dtData.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsRegOpe", dtData));

                        List<ReportParameter> paramlist = new List<ReportParameter>();


                        paramlist.Add(new ReportParameter("x_dFechaInicio", dFechaDesde.ToString(), false));
                        paramlist.Add(new ReportParameter("x_dFechaFinal", dFechaHasta.ToString(), false));

                        string reportPath = "rptRegOpeUnico.rdlc";//
                        new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.datePicker1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Las fechas no puede ser mayor a la de hoy", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.datePicker1.Focus();
            }
        }
    
        private void ReporteROM()
        {
            dFechaDesde = Convert.ToDateTime(this.datePicker1.Value);
            dFechaHasta = Convert.ToDateTime(this.datePicker2.Value);


            if (dFechaHasta <= dFechaHoy && dFechaDesde <= dFechaHoy)
            {
                if (dFechaDesde <= dFechaHasta)
                {

                    DataTable dtData = CNRegistroOperacionesMultiples.CNRegistroOperacionesMultiples(dFechaDesde, dFechaHasta);//(dFechaDesde, dFechaHasta);
                    if (dtData.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsRegOpe", dtData));

                        List<ReportParameter> paramlist = new List<ReportParameter>();


                        paramlist.Add(new ReportParameter("dFechaOpe", dFechaDesde.ToString(), false));
                        paramlist.Add(new ReportParameter("dFechaFin", dFechaHasta.ToString(), false));

                        string reportPath = "rptRegOpeMulti.rdlc";//
                        new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.datePicker1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Las fechas no puede ser mayor a la de hoy", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.datePicker1.Focus();
            }
        }

        #endregion

    }
}

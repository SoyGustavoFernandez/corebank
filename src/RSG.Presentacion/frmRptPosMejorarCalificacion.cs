﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
//using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmRptPosMejorarCalificacion : frmBase
    {
        #region Variables Globales   
            string cTituloMsjes = "Clientes con posibilidad de mejorar su calificación";
            DateTime dFechaHoy = clsVarGlobal.dFecSystem;
            DateTime dFechaConsulta;
            clsCNCro cnRptRsg = new clsCNCro();
        #endregion
        #region Eventos
            public frmRptPosMejorarCalificacion()
            {
                InitializeComponent();
                this.datePicker1.Value = dFechaHoy;
            }
            private void btnImprimir1_Click(object sender, EventArgs e)
            {
                Reporte();
            }

        #endregion
        #region Metodos


        private void Reporte()
        {

            dFechaConsulta = Convert.ToDateTime(this.datePicker1.Value);
            string dFecOpe = Convert.ToString(dFechaHoy);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();

            if (dFechaConsulta <= dFechaHoy)
            {


                DataTable dtData = cnRptRsg.cliMejorarCalificacion(dFechaConsulta);
                    if (dtData.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsMejorarCali", dtData));

                        List<ReportParameter> paramlist = new List<ReportParameter>();

                        paramlist.Add(new ReportParameter("dFechaConsulta", dFechaConsulta.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                        paramlist.Add(new ReportParameter("dFecOpe", dFecOpe, false));

                        string reportPath = "rptCliMejorarCalificacion.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                        new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para esta fecha.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

            }
            else
            {
                MessageBox.Show("La fecha no puede ser mayor a la de hoy", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.datePicker1.Focus();
            }

        }
        
        #endregion

    }
}
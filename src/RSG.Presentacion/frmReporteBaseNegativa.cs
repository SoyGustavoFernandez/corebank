﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.ControlesBase;
using EntityLayer;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmReporteBaseNegativa : frmBase
    {
        private clsCNBaseNegativa objCNBaseNegativa = new clsCNBaseNegativa();
        private DataTable dtBaseNegativa = new DataTable();

        public frmReporteBaseNegativa()
        {
            InitializeComponent();
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void frmReporteBaseNegativa_Load(object sender, EventArgs e)
        {
            cboZona1.AgregarTodos();
            cboZona1.SelectedValue = 0;
            cboAgencias1.SelectedValue = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > clsVarGlobal.dFecSystem || dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha no puede ser mayor a la fecha del coreBank.", "Reporte Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final.", "Reporte Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaIni = fechaIni = Convert.ToDateTime(clsVarGlobal.dFecSystem.AddYears(-5));

            if (dtpFechaInicio.Value < fechaIni)
            {
                MessageBox.Show("No se puede generar un reporte que exceda los 5 años de antigüedad", "Reporte Riesgo Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            { 
                dtBaseNegativa = objCNBaseNegativa.BaseNegativa(dtpFechaInicio.Value, dtpFechaFin.Value, 1, Convert.ToInt32(cboZona1.SelectedValue), Convert.ToInt32(cboAgencias1.SelectedValue), Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsBaseNegativa", dtBaseNegativa));
                string reportpath = "rptBaseNegativa.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAgencias1.FiltrarPorZonaTodos(Convert.ToInt32(cboZona1.SelectedValue));
        }
    }
}
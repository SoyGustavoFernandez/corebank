using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmRPTPermisos : frmBase
    {
        public frmRPTPermisos()
        {
            InitializeComponent();
        }

        private void frmRPTPermisos_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarApl.dicVarGen["dFechaGRH"];
            dtpFecFin.Value = clsVarApl.dicVarGen["dFechaGRH"];
            cboEstadoSolic1.EstadosPermisos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no puede ser mayor que la Fecha Final", "Reporte de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAgencias1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Reporte de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFecInicio = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idAge = Convert.ToInt16(cboAgencias1.SelectedValue);
            string cAgencias = cboAgencias1.Text.Trim();
            int idEstadoPerm = Convert.ToInt32(cboEstadoSolic1.SelectedValue);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];


            DataTable dtRpt = new clsRPTCNRecurHum().CNListarPermisos(dFecInicio, dFecFin, idAge, idEstadoPerm);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_idAgencia", idAge.ToString(), false));
                paramlist.Add(new ReportParameter("x_cAgencias", cAgencias, false));
                paramlist.Add(new ReportParameter("x_dFecIni", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsPermiso", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "RptPermisoPers.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}

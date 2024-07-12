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
    public partial class frmRptVacacionesPendientes : frmBase
    {
        public frmRptVacacionesPendientes()
        {
            InitializeComponent();
        }

        private void freRptVacaciones_Load(object sender, EventArgs e)
        {
            cboAgencias1.SelectedIndex = -1;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencias1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Reporte de Vacaciones Pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idAge = Convert.ToInt16(cboAgencias1.SelectedValue);
          
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];


            DataTable dtRpt = new clsRPTCNRecurHum().CNListarVacacionesPend(idAge);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsVacacionesPend", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "rptVacacionesPendientes.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Vacaciones Pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptActivaCajBill : frmBase
    {
        public frmRptActivaCajBill()
        {
            InitializeComponent();
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFechaIni = this.dtpFecIni.Value;
            DateTime dFechaFin = this.dtpFecFin.Value;
            int idAge = Convert.ToInt32(cboAgencia1.SelectedValue);
            int idColaboradorSolicita = Convert.ToInt32(cboColaboradorSolicita.SelectedValue);
            int idColaboradorAutoriza = Convert.ToInt32(cboColAutoriza.SelectedValue);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreAge", cboAgencia1.Text, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFecIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAge.ToString(), false));

            paramlist.Add(new ReportParameter("idColaborador", idColaboradorSolicita.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsActivaCajBill", new clsRPTCNCaja().CNRptListaActivaCajBill(idAge, dFechaIni, dFechaFin, idColaboradorSolicita, idColaboradorAutoriza)));
            string reportpath = "rptActivarCajaBilletaje.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void frmRptActivaCajBill_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            cargarColaborador();
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            cargarColaborador();
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia1.SelectedIndex >-1 )
            {
                cargarColaborador();
            }
        }
        private void cargarColaborador()
        {
            DateTime dFechaIni = this.dtpFecIni.Value;
            DateTime dFechaFin = this.dtpFecFin.Value;
            int idAge = Convert.ToInt32(cboAgencia1.SelectedValue);

            DataTable dts = new clsRPTCNCaja().CNRptListaColaboradorActivaCajBill(idAge, dFechaIni, dFechaFin,2);
            cboColaboradorSolicita.DataSource = dts;
            cboColaboradorSolicita.ValueMember = "idUsuAutoriza";
            cboColaboradorSolicita.DisplayMember = "cNombre";

            DataTable dta = new clsRPTCNCaja().CNRptListaColaboradorActivaCajBill(idAge, dFechaIni, dFechaFin, 1);
            cboColAutoriza.DataSource = dta;
            cboColAutoriza.ValueMember = "idUsuAutoriza";
            cboColAutoriza.DisplayMember = "cNombre";
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CNT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;

namespace CNT.Presentacion
{
    public partial class frmLibroCajaBco : frmBase
    {
        public frmLibroCajaBco()
        {
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
        }
        Boolean Validar()
        {
            if (this.dtpFecIni.Value.Date>this.dtpFecFin.Value.Date)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial");
                return false;
            }
            else
	        {
            return true;
	        }
        }
        private void frmLibroDia_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboMoneda.CargaDatosContaTodos();
        }

        private void btnLibCaja_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string pcCuenta = "1101%";
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                decimal nSaldoCta = 0;
                DataTable dtSaldoCta = new clsRPTCNContabilidad().CNSaldoCtaCtb(dFecIni.AddDays(-1), pcCuenta, idMoneda);
                nSaldoCta = Convert.ToDecimal(dtSaldoCta.Rows[0][0]);

                paramlist.Add(new ReportParameter("x_dFechaFinal", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cCuenta", pcCuenta, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_nSaldoCta", nSaldoCta.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsLibroCaja", new clsRPTCNContabilidad().CNLibroCaja(dFecIni, dFecFin, pcCuenta,idMoneda)));

                string reportpath = "RptLibroCajaCNT.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnLibBco_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                string pcCuenta = "1103%";
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

                decimal nSaldoCta = 0;
                DataTable dtSaldoCta = new clsRPTCNContabilidad().CNSaldoCtaCtb(dFecIni.AddDays(-1), pcCuenta, idMoneda);
                nSaldoCta = Convert.ToDecimal(dtSaldoCta.Rows[0][0]);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsLibroBcos", new clsRPTCNContabilidad().CNLibroBancos(dFecIni, dFecFin, idMoneda)));

                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_nSaldoCta", nSaldoCta.ToString(), false));

                string reportpath = "RptLibroBcos.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            string codLibro = "010100";//Identificador del libro = 11;//Identificador del libro
            DataTable dtLibro = new clsCNAsiento().CNPLELibroGeneral(dFecIni, dFecFin, idMoneda, codLibro,"");
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\" + new clsCNAsiento().cNomArcPLELibro(idMoneda.ToString(), dFecFin, codLibro, dtLibro.Rows.Count);
                new clsCNAsiento().ExportarArchivo(dtLibro,@cNomArc);
                MessageBox.Show("El archivo " + cNomArc + " se generó correctamente", "PLE - Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnExportar2_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            string codLibro = "010200"; ;//Identificador del libro
            DataTable dtLibro = new clsCNAsiento().CNPLELibroGeneral(dFecIni, dFecFin, idMoneda, codLibro,"");
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\" + new clsCNAsiento().cNomArcPLELibro(idMoneda.ToString(), dFecFin, codLibro, dtLibro.Rows.Count);
                new clsCNAsiento().ExportarArchivo(dtLibro, @cNomArc);
                MessageBox.Show("El archivo " + cNomArc + " se generó correctamente", "PLE - Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

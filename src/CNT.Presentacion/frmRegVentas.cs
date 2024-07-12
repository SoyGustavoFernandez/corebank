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
    public partial class frmRegVentas : frmBase
    {
        public frmRegVentas()
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
        }

        private void btnLibCaja_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsRegVentas", new clsRPTCNContabilidad().CNRegVentas(dFecIni, dFecFin)));

                string reportpath = "RptRegistroVentas.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnExporTxt1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;

            DataTable dtRegComPLE = new clsCNAsiento().CNPLERegVentas(dFecIni, dFecFin);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;
            DateTime dFecha = dtpFecFin.Value;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\LE" + clsVarApl.dicVarGen["cRUC"] +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            "00140100001111.txt";
                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena;

                for (int i = 0; i < dtRegComPLE.Rows.Count; i++)
                {
                    pcCadena = dtRegComPLE.Rows[i]["cCadena"].ToString();
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " se genero correctamente", "PLE - Registro Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

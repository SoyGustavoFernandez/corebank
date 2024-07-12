using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace RPT.Presentacion
{
    public partial class frmAnexo03 : frmBase
    {
        DateTime dFecha;
        public frmAnexo03()
        {
            InitializeComponent();
        }

        private void frmAnexo03_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnValidar1_Click(object sender, EventArgs e)
        {
            txtSalConsumo.Text = "0";
            txtSalHipoteca.Text = "0";
            txtSalOtros.Text = "0";
            txtCreConsumo.Text = "0";
            txtCreHipo.Text = "0";
            txtCreOtros.Text = "0";

            dFecha = this.dtpFecha.Value.Date;
            DataTable dtSaldoCNT = new clsRPTCNCredito().CNSaldosCNTAnexo03(dFecha);
            DataTable dtSaldoCre = new clsRPTCNCredito().CNSaldoAnexo03(dFecha);
            if (dtSaldoCNT.Rows.Count > 0)
        	{
            this.txtSalConsumo.Text = dtSaldoCNT.Rows[0]["nSalConsumo"].ToString() ;
            this.txtSalHipoteca.Text = dtSaldoCNT.Rows[0]["nSalHipo"].ToString();
            this.txtSalOtros.Text = dtSaldoCNT.Rows[0]["nSalOtros"].ToString();
            }
            else
        	{
                MessageBox.Show("No existen saldos contables para la fecha seleccionada", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
        	}

            if (dtSaldoCre.Rows.Count > 0)
            {
                this.txtCreConsumo.Text = dtSaldoCre.Rows[0]["nSaldoConsumo"].ToString();
                this.txtCreHipo.Text = dtSaldoCre.Rows[0]["nSaldoHipo"].ToString();
                this.txtCreOtros.Text = dtSaldoCre.Rows[0]["nSaldoOtr"].ToString();
            }
            else
            {
                MessageBox.Show("No existen saldos contables para la fecha seleccionada", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToDecimal(dtSaldoCNT.Rows[0]["nSalConsumo"]) != Convert.ToDecimal(dtSaldoCre.Rows[0]["nSaldoConsumo"]) ||
                Convert.ToDecimal(dtSaldoCNT.Rows[0]["nSalHipo"]) != Convert.ToDecimal(dtSaldoCre.Rows[0]["nSaldoHipo"]) ||
                Convert.ToDecimal(dtSaldoCNT.Rows[0]["nSalOtros"]) != Convert.ToDecimal(dtSaldoCre.Rows[0]["nSaldoOtr"]))
            {
                MessageBox.Show("No cuadra los Saldos de Creditos con los Saldos Contables", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtValida = new clsRPTCNCredito().CNValidaAnexo03(dFecha);
            if (dtValida.Rows.Count > 0)
            {
                MessageBox.Show("Existen solicitudes con Sector Economico Errado", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsRegistroErrados", dtValida));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptErrorAnexo03.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                this.btnExportar.Enabled = false;
                this.btnImprimir.Enabled = false;
                return;
            }
            else
            {
                this.btnExportar.Enabled = true;
                this.btnImprimir.Enabled = true;
            }
        }

        private void btnTransferir1_Click(object sender, EventArgs e)
        {
            dFecha = this.dtpFecha.Value.Date;
            DataTable dtAnexo03 = new clsRPTCNCredito().CNAnexo03(dFecha);
            if (dtAnexo03.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo03", dtAnexo03));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));

                string reportpath = "rptAnexo03.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
                this.btnExportar.Enabled = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            dFecha = this.dtpFecha.Value.Date;
            DataTable dtAnexo03 = new clsRPTCNCredito().CNAnexo03(dFecha);
            if (dtAnexo03.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo03", dtAnexo03));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));

                string reportpath = "RptAnexo03.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
                this.btnExportar.Enabled = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            dFecha = this.dtpFecha.Value.Date;
            DataTable dtAnexo03 = new clsRPTCNCredito().CNAnexo03(dFecha);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\01" +
                            dFecha.Year.ToString().Substring(2, 2) +
                            dFecha.Month.ToString("00") +
                            dFecha.Day.ToString("00") + ".103";

                StreamWriter sr = new StreamWriter(@cNomArc,false, Encoding.ASCII);
                string pcCadena;

                pcCadena = "010301" + clsVarApl.dicVarGen["cCodInst"] +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            dFecha.Day.ToString("00") + "012";
                sr.WriteLine(pcCadena);

                for (int i = 0; i < dtAnexo03.Rows.Count; i++)
                {
                    pcCadena = dtAnexo03.Rows[i]["idFila"].ToString().PadLeft(6, ' ') +
                           dtAnexo03.Rows[i]["cDivCiiuSucave"].ToString().PadLeft(4, ' ') +
                           dtAnexo03.Rows[i]["nNumCli"].ToString().PadLeft(18, ' ') +
                        (Math.Round(Convert.ToDecimal(dtAnexo03.Rows[i]["nSaldoMN"]) * 100, 0)).ToString().PadLeft(18, ' ') +
                        (Math.Round(Convert.ToDecimal(dtAnexo03.Rows[i]["nSaldoME"]) * 100, 0)).ToString().PadLeft(18, ' ') +
                        (Math.Round((Convert.ToDecimal(dtAnexo03.Rows[i]["nSaldoMN"]) + Convert.ToDecimal(dtAnexo03.Rows[i]["nSaldoME"])) * 100, 0)).ToString().PadLeft(18, ' ') +
                        dtAnexo03.Rows[i]["nNumDes"].ToString().PadLeft(18, ' ') +
                        (Math.Round(Convert.ToDecimal(dtAnexo03.Rows[i]["nDesMN"]) * 100, 0)).ToString().PadLeft(18, ' ') +
                        (Math.Round(Convert.ToDecimal(dtAnexo03.Rows[i]["nDesME"]) * 100, 0)).ToString().PadLeft(18, ' ');
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " se genero correctamente", "Valida Anexo 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

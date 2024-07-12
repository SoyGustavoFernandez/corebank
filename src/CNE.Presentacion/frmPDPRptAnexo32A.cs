using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmPDPRptAnexo32A : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();
        DateTime dFecSystem = clsVarGlobal.dFecSystem;

        public frmPDPRptAnexo32A()
        {
            InitializeComponent();

            this.dtpFechaInicial.Value = dFecSystem.Date;
            this.dtpFechaFinal.Value = dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicial.Value.Date > this.dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFecInicial = this.dtpFechaInicial.Value.Date;
            DateTime dFecFinal = this.dtpFechaFinal.Value.Date;

            DataTable dtAnexo32A = cnRptPdp.ObtenerReporte32A(dFecInicial, dFecFinal);
            if (dtAnexo32A.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));                
                paramlist.Add(new ReportParameter("dFechaInicial", dFecInicial.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFinal", dFecFinal.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosAnexo32A", dtAnexo32A));

                string reportpath = "RptReporte32A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicial.Value.Date > this.dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Se exportara la información con la Fecha Final: " + this.dtpFechaFinal.Value.Date.ToString("dd/MM/yyyy"), "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //DateTime dFecInicial = this.dtpFechaInicial.Value.Date;
            DateTime dFecFinal = this.dtpFechaFinal.Value.Date;

            DataTable dtAnexo32A = cnRptPdp.ObtenerReporte32A(dFecFinal, dFecFinal);
            if (dtAnexo32A.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta, cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;

                    cNomArc = "\\REPORTE32A-CRANDES-" +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Year.ToString() +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Month.ToString("00") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Day.ToString("00") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Hour.ToString("00") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Minute.ToString("00") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Second.ToString("00") + ".txt";

                    StreamWriter sr = new StreamWriter(cRuta + @cNomArc, false, Encoding.ASCII);
                    string pcCadena = String.Empty;

                    pcCadena += dtAnexo32A.Rows[0]["cCodFormato"].ToString().Trim().PadLeft(4, '0'); //Codigo Formato "0232"
                    pcCadena += dtAnexo32A.Rows[0]["cAnexo"].ToString().Trim().PadLeft(2, '0');   //Anexo "03"
                    pcCadena += dtAnexo32A.Rows[0]["cEntidad"].ToString().Trim().PadLeft(5, '0'); //Entidad "00169"
                    pcCadena += Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Year.ToString("0000") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Month.ToString("00") +
                                Convert.ToDateTime(dtAnexo32A.Rows[0]["dFecha"].ToString()).Day.ToString("00");
                    pcCadena += dtAnexo32A.Rows[0]["cCodigoExpMonto"].ToString().Trim().PadLeft(3, '0'); //Codigo Expresion "012"
                    pcCadena += dtAnexo32A.Rows[0]["nDatosControl"].ToString().Trim().PadLeft(15, '0'); //Datos Control "000000000000000"
                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtAnexo32A.Rows.Count; i++)
                    {
                        pcCadena = dtAnexo32A.Rows[i]["nCodigoFila"].ToString().Trim().PadLeft(6, '0') +
                                    (Convert.ToInt32(Convert.ToDecimal(dtAnexo32A.Rows[i]["nTotalDECirculacion"]) * 100)).ToString().Trim().PadLeft(18, '0') +
                                    (Convert.ToInt32(Convert.ToDecimal(dtAnexo32A.Rows[i]["nValorPatriFide"]) * 100)).ToString().Trim().PadLeft(18, '0') +
                                    (Convert.ToInt32(Convert.ToDecimal(dtAnexo32A.Rows[i]["nValorDepDispInm"]) * 100)).ToString().Trim().PadLeft(18, '0') +
                                    (Convert.ToInt32(Convert.ToDecimal(dtAnexo32A.Rows[i]["nToValGar"]) * 100)).ToString().Trim().PadLeft(18, '0');
                        sr.WriteLine(pcCadena);
                    }
                    sr.Flush();
                    sr.Close();

                    MessageBox.Show("El Archivo " + cNomArc + " se generó correctamente", "Anexo 32A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }        
        }
    }
}

using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
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

namespace RPT.Presentacion
{
    public partial class frmAnexo13 : frmBase
    {
        decimal nFSD = 0;
        public frmAnexo13()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            ValorFSD(dtpFecha.Value);
        }

        private void ValorFSD(DateTime dFecha)
        {
            DataTable dtFSD = new clsRPTCNReporte().CNRetornaValorFSD(dFecha);
            if (dtFSD.Rows.Count==0)
            {
                nFSD = 0;
            }
            else
            {
                nFSD = Convert.ToDecimal(dtFSD.Rows[0]["nMaxCoberFSD"]);
            }
            txtFSD.Text = Convert.ToString(nFSD);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (nFSD==0)
            {
                MessageBox.Show("No existe parámetro del FSD", "Anexo 13", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataSet dsAnexo13 = new clsRPTCNContabilidad().CNAnexo13(dtpFecha.Value.Date, nFSD, "0113", "01");
            DataTable dtAnexo13 = dsAnexo13.Tables[0];
            if (dtAnexo13.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Anexo", "Anexo 13", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dtpFecha.Value.Date.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsAnexo13", dtAnexo13));

                string reportpath = "RptAnexo13.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ValorFSD(dtpFecha.Value);
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            Anexo13(dtpFecha.Value.Date, "0113", "01");
        }
        private void Anexo13(DateTime dFechaProceso, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexos = DatoSucaveAnexo13(dFechaProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private DataSet DatoSucaveAnexo13(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo13 = new clsRPTCNContabilidad().CNAnexo13(dFecha, nFSD, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo13.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo13.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }

        private StreamWriter GeneraArchivoSucave(string cNomArc)
        {
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            StreamWriter sr;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + cNomArc;
                sr = new StreamWriter(@cNomArc);
            }
            else
            {
                sr = null;
            }
            return sr;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "012";
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }
        private void CierreArchivo(StreamWriter Archivo, string cNombreArchivo)
        {
            Archivo.Flush();
            Archivo.Close();
            MessageBox.Show("El archivo " + cNombreArchivo + " se genero correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

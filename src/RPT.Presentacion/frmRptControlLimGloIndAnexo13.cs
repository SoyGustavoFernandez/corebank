using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;

namespace RPT.Presentacion
{
    public partial class FrmrptControlLimGloIndAnexo13 : frmBase
    {
        string cReporteSBS = "0213", cAnexoSbs = "01";
        public FrmrptControlLimGloIndAnexo13()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            DateTime dfechaPro = dtpFecha.Value.Date;
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dfechaPro.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            DataSet dsReporte13 = new clsRPTCNCredito().retornarLimGlobalIndividualAnexo13(dfechaPro, cReporteSBS, cAnexoSbs);
            DataTable dtreporte13 = dsReporte13.Tables[0];

            dtslist.Add(new ReportDataSource("dtsReporte13", dtreporte13));

            string reportpath = "rptControlLimGloIndAnexo13.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void frmRptAportesSocio_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFecha.Value.Date;
            DataSet dsAnexos = DatoSucaveReporte13(dFecProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFecProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecProceso, 6))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private DataSet DatoSucaveReporte13(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte13 = new clsRPTCNCredito().retornarLimGlobalIndividualAnexo13(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte13.Tables[1];
            T1.TableName = "Tab101";
            dsReporte13.Tables.Remove(T1);
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
                sr = new StreamWriter(@cNomArc, false, Encoding.ASCII);
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

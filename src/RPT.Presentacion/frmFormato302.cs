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
    public partial class frmFormato302 : frmBase
    {
        public frmFormato302()
        {
            InitializeComponent();
            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataSet dsAnexo11 = new clsRPTCNDeposito().CNFormato302(dtpFecProceso.Value, "0302", "01");
            DataTable dtAnexo11 = dsAnexo11.Tables[0];
            if (dtAnexo11.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Formato", "Formato 302", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dtpFecProceso.Value.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsFormato302", dtAnexo11));

                string reportpath = "RptFormato302.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
        private void Formato302(DateTime dFechaProceso, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexos = DatoSucaveformato302(dFechaProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private DataSet DatoSucaveformato302(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsFormato302 = new clsRPTCNDeposito().CNFormato302(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsFormato302.Tables[1];
            T1.TableName = "Tab101";
            dsFormato302.Tables.Remove(T1);

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
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "010";
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]))).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
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

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            Formato302(dtpFecProceso.Value.Date, "0302", "01");
        }
    }
}

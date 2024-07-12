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
using System.IO;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
namespace RPT.Presentacion
{
    public partial class frmAnexo11 : frmBase
    {
        public frmAnexo11()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataSet dsAnexo11 = new clsRPTCNDeposito().CNAnexo11(dtpFechaProceso.Value, "0111", "01");
            DataTable dtAnexo11 = dsAnexo11.Tables[0];
            if (dtAnexo11.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Anexo", "Anexo 11", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dtpFechaProceso.Value.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_Empresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_CodIns", clsVarApl.dicVarGen["cCodInst"], false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsAnexo11", dtAnexo11));

                string reportpath = "RptAnexoNro11.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Anexo11(dtpFechaProceso.Value.Date, "0111", "01");
        }
        private void Anexo11(DateTime dFechaProceso, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexos = DatoSucaveAnexo11(dFechaProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private DataSet DatoSucaveAnexo11(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo11 = new clsRPTCNDeposito().CNAnexo11(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo11.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo11.Tables.Remove(T1);

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

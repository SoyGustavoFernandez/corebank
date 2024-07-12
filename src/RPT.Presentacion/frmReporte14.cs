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
    public partial class frmReporte14 : frmBase
    {
        public frmReporte14()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataSet dsReporte14 = new clsRPTCNCredito().CNReporte14(dFecProceso, "0214", "01");
            DataTable dtReporte14 = dsReporte14.Tables[1];
            if (dtReporte14.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 14", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsReporte14", dtReporte14));

                string reportpath = "RptReporte14.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void frmReporte14_Load(object sender, EventArgs e)
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaProceso.Value.Date;
            string cReporteSBS = "0214";
            string cAnexoSbs = "01";
            DataSet dsReporte14 = new clsRPTCNCredito().CNReporte14(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte14 = dsReporte14.Tables[0];
            dtReporte14.TableName = "Tab1";
            dsReporte14.Tables.Remove(dtReporte14);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { dtReporte14 });

            string cNomArc = "\\" + cAnexoSbs + dFecha.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecha))
            {
                CierreArchivo(Archivo, cNomArc);
            }


            //if (dtReporte14.Rows.Count == 0)
            //{
            //    MessageBox.Show("No existen datos para el reporte", "Reporte 14", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else
            //{
            //    DataTable dtMaestro = new DataTable("DatosMae");

            //    dtMaestro.Columns.Add("idTipo", dtReporte14.Columns["idRep14"].DataType);
            //    dtMaestro.Columns.Add("idSubTipo", dtReporte14.Columns["idSubTipo"].DataType);
            //    dtMaestro.Columns.Add("nReg", dtReporte14.Columns["nReg"].DataType);

            //    int idrep = 0;
            //    int idSubTip = 0;

            //    int idrep1 = 0;
            //    int idSubTip1 = 0;
            //    DataRow dr;

            //    for (int i = 0; i < dtReporte14.Rows.Count; i++)
            //    {
            //        if ((idrep == 0 || idSubTip == 0) || (idrep != idrep1 || idSubTip != idSubTip1))
            //        {
            //            idrep = Convert.ToInt16(dtReporte14.Rows[i]["idRep14"]);
            //            idSubTip = Convert.ToInt16(dtReporte14.Rows[i]["idSubTipo"]);

            //            dr = dtMaestro.NewRow();
            //            dr["idTipo"] = idrep;
            //            dr["idSubTipo"] = idSubTip;
            //            dr["nReg"] = dtReporte14.Rows[i]["nReg"].ToString();

            //            dtMaestro.Rows.Add(dr);
            //        }
            //        idrep1 = Convert.ToInt16(dtReporte14.Rows[i]["idRep14"]);
            //        idSubTip1 = Convert.ToInt16(dtReporte14.Rows[i]["idSubTipo"]);
            //    }

            //    DataTable dtInserta;
            //    DataRow[] Registro;
            //    decimal nsaldo;

            //    dtInserta = dtReporte14.Clone();
            //    DialogResult result;
            //    result = folderBrowserDialog1.ShowDialog();
            //    string cRuta;
            //    string cNomArc;

            //    if (result == DialogResult.OK)
            //    {
            //        cRuta = folderBrowserDialog1.SelectedPath;
            //        cNomArc = cRuta + "\\01" +
            //                    clsVarGlobal.dFecSystem.Year.ToString().Substring(2, 2) +
            //                    clsVarGlobal.dFecSystem.Month.ToString("00") +
            //                    clsVarGlobal.dFecSystem.Day.ToString("00") + ".214";

            //        StreamWriter sr = new StreamWriter(@cNomArc);
            //        string pcCadena;

            //        pcCadena = "021401" + clsVarApl.dicVarGen["cCodInst"] +
            //                    clsVarGlobal.dFecSystem.Year.ToString() +
            //                    clsVarGlobal.dFecSystem.Month.ToString("00") +
            //                    clsVarGlobal.dFecSystem.Day.ToString("00") + "012";
            //        sr.WriteLine(pcCadena);

            //        for (int i = 0; i < dtMaestro.Rows.Count; i++)
            //        {
            //            string cidrep = dtMaestro.Rows[i]["idTipo"].ToString();
            //            string cidSubTip = dtMaestro.Rows[i]["idSubTipo"].ToString(); ;
            //            Registro = dtReporte14.Select("idRep14 = " + cidrep + " AND idSubTipo = " + cidSubTip, "idRangoAtr");
            //            pcCadena = dtMaestro.Rows[i]["nReg"].ToString().PadLeft(6, ' ');
            //            nsaldo = 0;
            //            foreach (DataRow dRow in Registro)
            //            {
            //                pcCadena = pcCadena + Math.Round(Convert.ToDecimal(dRow["nsaldo"]) * 100, 0).ToString().PadLeft(18, ' ');
            //                if (Convert.ToInt16(dRow["idGrpAtraso"])==2)
            //                {
            //                    pcCadena = pcCadena + Math.Round(Convert.ToDecimal(dRow["nnoamor"]) * 100, 0).ToString().PadLeft(18, ' ');
            //                }
            //                nsaldo = nsaldo + Convert.ToDecimal(dRow["nsalTotal"]);
            //            }
            //            pcCadena = pcCadena + Math.Round(nsaldo * 100, 0).ToString().PadLeft(18, ' ');
            //            sr.WriteLine(pcCadena);
            //        }
            //        sr.Close();

            //        MessageBox.Show("Archivo generado correctamente", "Reporte 14", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            int pnFila = 1;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "012";
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = ((pnFila * 100).ToString()).PadLeft(6, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                    if (pnFila == 47)
                    {
                        pnFila = pnFila + 2;
                    }
                    else
                    {
                        pnFila = pnFila + 1;
                    }
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

    }

}

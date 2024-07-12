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
    public partial class frmReporte25 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmReporte25()
        {
            InitializeComponent();
        }

        private void frmReporte25_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0225";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFecha.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        Reporte25A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte25_I(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte25B(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "03":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte25_III(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "04":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatoSucaveReporte25_III(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte25_III = new clsRPTCNContabilidad().CNReporte25_III(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte25_III.Tables[1];
            T1.TableName = "Tab101";
            dsReporte25_III.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte25_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte25_I = new clsRPTCNContabilidad().CNReporte25_I(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte25_I.Tables[1];
            T1.TableName = "Tab101";
            dsReporte25_I.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte25B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte25B = new clsRPTCNContabilidad().CNReporte25B(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte25B.Tables[1];
            T1.TableName = "Tab101";
            dsReporte25B.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
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

        private void dtgListaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cAnexoSbs = Convert.ToString(dtgListaReporte.CurrentRow.Cells["cAnexo"].Value);
            string cReporteSBS = Convert.ToString(dtgListaReporte.CurrentRow.Cells["cCodigoSBS"].Value);
            if (dtgListaReporte.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgListaReporte.Columns[e.ColumnIndex].DisplayIndex) == 3)
            {
                Boolean lFisico = Convert.ToBoolean(dtgListaReporte.CurrentRow.Cells["lFisico"].Value);
                if (lFisico)
                {
                    Procesa(cAnexoSbs, lFisico, false, cReporteSBS, cAnexoSbs);
                }
                else
                {
                    MessageBox.Show("Reporte no configurado para impresión física", "Reporte Regulatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (dtgListaReporte.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgListaReporte.Columns[e.ColumnIndex].DisplayIndex) == 4)
            {
                Boolean lSucave = Convert.ToBoolean(dtgListaReporte.CurrentRow.Cells["lSucave"].Value);
                if (lSucave)
                {
                    Procesa(cAnexoSbs, false, lSucave, cReporteSBS, cAnexoSbs);
                }
                else
                {
                    MessageBox.Show("Reporte no configurado para generar archivo SUCAVE", "Reporte Regulatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
        private void Reporte25A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte25B = new clsRPTCNContabilidad().CNReporte25B(dFecha, cReporteSBS, "02");
            DataTable dtReporte25B = dsReporte25B.Tables[0];

            DataSet dsReporte25_III = new clsRPTCNContabilidad().CNReporte25_III(dFecha, cReporteSBS, "03");
            DataTable dtReporte25_III = dsReporte25_III.Tables[0];

            DataSet dsReporte25_I = new clsRPTCNContabilidad().CNReporte25_I(dFecha, cReporteSBS, "01");
            DataTable dtReporte25_I = dsReporte25_I.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte25_I", dtReporte25_I));
            dtslist.Add(new ReportDataSource("dtsReporte25", dtReporte25B));
            dtslist.Add(new ReportDataSource("dtsReporte25_III", dtReporte25_III));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte25.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
    }
}

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
    public partial class frmReporte04 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmReporte04()
        {
            InitializeComponent();
        }

        private void frmReporte25_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            dtpRegPro.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0204";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFecha.Value.Date;
            decimal nLimGlo = Convert.ToDecimal(txtLimGlo.Text);
            DateTime dFecProc = dtpRegPro.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        Reporte4A1(dFechaProceso, cReporteSBS, cAnexoSbs, nLimGlo);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4A1(dFechaProceso, cReporteSBS, cAnexoSbs, nLimGlo);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "06":
                    if (lFisico)
                    {
                        Reporte4B1(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4B1(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "07":
                    if (lFisico)
                    {
                        Reporte4B2(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4B2(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "08":
                    if (lFisico)
                    {
                        Reporte4B3(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4B3(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "10":
                    if (lFisico)
                    {
                        Reporte4C(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4C(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "11":
                    if (lFisico)
                    {
                        Reporte4D(dFechaProceso, cReporteSBS, cAnexoSbs, dFecProc);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte4D(dFechaProceso, cReporteSBS, cAnexoSbs, dFecProc);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatoSucaveReporte4A1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo)
        {
            DataSet dsReporte4A1 = new clsRPTCNContabilidad().CNReporte4A1(dFecha, cReporteSBS, cAnexoSbs, nLimGlo);
            DataTable T1 = dsReporte4A1.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4A1.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte4B1(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte4B1 = new clsRPTCNContabilidad().CNReporte4B1(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte4B1.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4B1.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte4B2(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte4B2 = new clsRPTCNContabilidad().CNReporte4B2(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte4B2.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4B2.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte4B3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte4B3 = new clsRPTCNContabilidad().CNReporte4B3(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte4B3.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4B3.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte4C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte4C = new clsRPTCNContabilidad().CNReporte4C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte4C.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4C.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte4D(DateTime dFecha, string cReporteSBS, string cAnexoSbs, DateTime dFecProc)
        {
            DataSet dsReporte4D = new clsRPTCNContabilidad().CNReporte4D(dFecha, cReporteSBS, cAnexoSbs, dFecProc);
            DataTable T1 = dsReporte4D.Tables[1];
            T1.TableName = "Tab101";
            dsReporte4D.Tables.Remove(T1);
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
                sr = new StreamWriter(@cNomArc,false, Encoding.ASCII);
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
        private void Reporte4A1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo)
        {
            DataSet dsReporte04A1 = new clsRPTCNContabilidad().CNReporte4A1(dFecha, cReporteSBS, cAnexoSbs, nLimGlo);
            DataTable dtReporte04A1 = dsReporte04A1.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4A1", dtReporte04A1));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4A1.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte4B1(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte04B1 = new clsRPTCNContabilidad().CNReporte4B1(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte04B1 = dsReporte04B1.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4B1", dtReporte04B1));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4B1.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte4B2(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte04B2 = new clsRPTCNContabilidad().CNReporte4B2(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte04B2 = dsReporte04B2.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4B2", dtReporte04B2));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4B2.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte4B3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte04B3 = new clsRPTCNContabilidad().CNReporte4B3(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte04B3 = dsReporte04B3.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4B3", dtReporte04B3));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4B3.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte4C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte04C = new clsRPTCNContabilidad().CNReporte4C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte04C = dsReporte04C.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4C", dtReporte04C));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4C.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte4D(DateTime dFecha, string cReporteSBS, string cAnexoSbs, DateTime dFecProc)
        {
            DataSet dsReporte04D = new clsRPTCNContabilidad().CNReporte4D(dFecha, cReporteSBS, cAnexoSbs, dFecProc);
            DataTable dtReporte04D = dsReporte04D.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte4D", dtReporte04D));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte4D.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
    }
}

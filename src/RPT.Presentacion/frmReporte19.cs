using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmReporte19 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmReporte19()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0219";
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
                        Reporte19_I(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte19I(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        Reporte19_II(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte19II(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        Reporte19A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte19A(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private void Reporte19_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19I = new clsRPTCNContabilidad().CNReporte19_I(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte19I = dsReporte19I.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte19A", dtReporte19I));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "rptReporte19.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte19_II(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19II = new clsRPTCNContabilidad().CNReporte19_II(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte19II = dsReporte19II.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte19_II", dtReporte19II));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptReporte19_II.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private void Reporte19A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19A = new clsRPTCNContabilidad().CNReporte19A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtReporte19A = dsReporte19A.Tables[0];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsReporte19A", dtReporte19A));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "rptReporte19A.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }
        private DataSet DatoSucaveReporte19I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19_I = new clsRPTCNContabilidad().CNReporte19_I(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte19_I.Tables[1];
            T1.TableName = "Tab101";
            dsReporte19_I.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte19II(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19_II = new clsRPTCNContabilidad().CNReporte19_II(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte19_II.Tables[1];
            T1.TableName = "Tab101";
            dsReporte19_II.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte19A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte19A = new clsRPTCNContabilidad().CNReporte19A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte19A.Tables[1];
            T1.TableName = "Tab101";
            dsReporte19A.Tables.Remove(T1);
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
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "010";
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
    }
}

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
    public partial class frmReporte6 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        clsRPTCNContabilidad cnDatos = new clsRPTCNContabilidad();
    public frmReporte6()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0206";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }

        private void frmReporte6A_Load(object sender, EventArgs e)
        {
            this.dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void dtgListaReporte_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void Reporte06A(DateTime dFecProceso, string cCodSBS, string cCodAnexo)
        {
            DataSet dsReporte06A = cnDatos.CNReporte6A(dFecProceso, cCodSBS, cCodAnexo);
            DataTable dtReporte6A = dsReporte06A.Tables[0];
            if (dtReporte6A.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Reporte 6A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dfecha", dFecProceso.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte6A", dtReporte6A));

                string reportpath = "rptReporte6A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }
        private void Reporte06B(DateTime dFecProceso, string cCodSBS, string cCodAnexo)
        {
            DataSet dsReporte06B = cnDatos.CNReporte6B(dFecProceso, cCodSBS, cCodAnexo);
            DataTable dtReporte6B = dsReporte06B.Tables[0];
            if (dtReporte6B.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 6B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte6B", dtReporte6B));

                string reportpath = "rptReporte6B.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }
        private void Reporte06DSUCAVE(DateTime dFecProceso)
        {
            DataTable dtReporte06D = new clsRPTCNCredito().CNReporte06(dFecProceso);
            if (dtReporte06D.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 06 D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataTable dtReporte06DSoles;
                DataTable dtReporte06DDolar;
                DataRow[] Registro;

                dtReporte06DSoles = dtReporte06D.Clone();
                dtReporte06DDolar = dtReporte06D.Clone();

                Registro = dtReporte06D.Select("idMoneda = 1", "nIdReporte");
                foreach (DataRow dr in Registro)
                {
                    dtReporte06DSoles.ImportRow(dr);
                }
                Registro = dtReporte06D.Select("idMoneda = 2", "nIdReporte");
                foreach (DataRow dr in Registro)
                {
                    dtReporte06DDolar.ImportRow(dr);
                }

                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;
                    cNomArc = cRuta + "\\04" +
                                dFecProceso.Year.ToString().Substring(2, 2) +
                                dFecProceso.Month.ToString("00") +
                                dFecProceso.Day.ToString("00") + ".206";

                    StreamWriter sr = new StreamWriter(@cNomArc);
                    string pcCadena;

                    pcCadena = "020604" + clsVarApl.dicVarGen["cCodInst"] +
                                dFecProceso.Year.ToString() +
                                dFecProceso.Month.ToString("00") +
                                dFecProceso.Day.ToString("00") + "012";
                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtReporte06DSoles.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nNivel"]) == 1)
                        {
                            pcCadena = (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nIdReporte"]) * 100).ToString().PadLeft(6, ' ');

                        }
                        else
                        {
                            pcCadena = (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nIdReporte"]) * 100).ToString().PadLeft(6, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMontoTEA"])*100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMonOpe"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMontoTCEA"])*100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMontoTEA"])*100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMonOpe"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMontoTCEA"])*100, 0).ToString().PadLeft(18, ' ');
                        }
                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se genero correctamente", "Reporte 06 D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
        }
        private void Reporte06E(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsReporte06E = new clsRPTCNDeposito().CNReporte6E(dFecProceso, cCodSBS, cAnexo);
            DataTable dtReporte6E = dsReporte06E.Tables[0];
            if (dtReporte6E.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 6E", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte6E", dtReporte6E));

                string reportpath = "RptReporte6E.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }
        private void Reporte06D(DateTime dFecProceso)
        {
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataTable dtReporte06D = new clsRPTCNCredito().CNReporte06(dFecProceso);
            if (dtReporte06D.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 06D", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dtslist.Add(new ReportDataSource("dsReporte06D", dtReporte06D));

                string reportpath = "RptReporte06D.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFechaProceso.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        Reporte06A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte06A(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso,6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                        Reporte06B(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte06B(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso,4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;

                case "03":
                    if (lFisico)
                    {
                        MessageBox.Show("Reporte no aplica a la Entidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (lSucave)
                    {
                        MessageBox.Show("Reporte no aplica a la Entidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case "04":
                    if (lFisico)
                    {
                        Reporte06D(dFechaProceso);
                    }
                    if (lSucave)
                    {
                        Reporte06DSUCAVE(dFechaProceso);
                    }
                    break;
                case "05":
                    if (lFisico)
                    {
                        Reporte06E(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte06E(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso,4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatoSucaveReporte06A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte06_01 = cnDatos.CNReporte6A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte06_01.Tables[1];
            T1.TableName = "Tab101";
            dsReporte06_01.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte06B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte06_02 = cnDatos.CNReporte6B(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsReporte06_02.Tables[1];
            T1.TableName = "Tab101";
            dsReporte06_02.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte06E(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsReporte6E = new clsRPTCNDeposito().CNReporte6E(dFecProceso, cCodSBS, cAnexo);
            DataTable T1 = dsReporte6E.Tables[1];
            T1.TableName = "Tab101";
            dsReporte6E.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd");
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt16((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
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

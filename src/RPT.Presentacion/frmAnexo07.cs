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
    public partial class frmAnexo07 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo07()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0107";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
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
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFecha.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        DataSet dsAnexo07 = new clsRPTCNContabilidad().CNAnexo07A(dFechaProceso, 1 , cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07 = dsAnexo07.Tables[0];
                        if (dtAnexo07.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            string cTitulo = "A. MEDICION DEL RIESGO DE TASA DE INTERES EN MONEDA NACIONAL – GANANCIAS EN RIESGO";
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));
                            paramlist.Add(new ReportParameter("x_cTitulo", cTitulo, false));
                            paramlist.Add(new ReportParameter("x_idMoneda", "1", false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07A", dtAnexo07));

                            string reportpath = "RptAnexo07A.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07A(dFechaProceso,1, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                        DataSet dsAnexo07 = new clsRPTCNContabilidad().CNAnexo07A(dFechaProceso, 2, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07 = dsAnexo07.Tables[0];
                        if (dtAnexo07.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            string cTitulo = "B. MEDICION DEL RIESGO DE TASA DE INTERES EN MONEDA EXTRANJERA – GANANCIAS EN RIESGO";
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));
                            paramlist.Add(new ReportParameter("x_cTitulo", cTitulo, false));
                            paramlist.Add(new ReportParameter("x_idMoneda", "2", false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07A", dtAnexo07));

                            string reportpath = "RptAnexo07A.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07A(dFechaProceso, 2, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "03":
                    if (lFisico)
                    {
                        DataSet dsAnexo07C = new clsRPTCNContabilidad().CNAnexo07C(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07C = dsAnexo07C.Tables[0];
                        if (dtAnexo07C.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07 C", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07C", dtAnexo07C));

                            string reportpath = "RptAnexo07C.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07C(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "04":
                    if (lFisico)
                    {
                        DataSet dsAnexo07B = new clsRPTCNContabilidad().CNAnexo07B(dFechaProceso, 1, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07B = dsAnexo07B.Tables[0];
                        if (dtAnexo07B.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));
                            paramlist.Add(new ReportParameter("x_idMoneda", "1", false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07B", dtAnexo07B));

                            string reportpath = "RptAnexo07B.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07B(dFechaProceso, 1, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "05":
                    if (lFisico)
                    {
                        DataSet dsAnexo07B = new clsRPTCNContabilidad().CNAnexo07B(dFechaProceso, 2, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07B = dsAnexo07B.Tables[0];
                        if (dtAnexo07B.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));
                            paramlist.Add(new ReportParameter("x_idMoneda", "2", false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07B", dtAnexo07B));

                            string reportpath = "RptAnexo07B.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07B(dFechaProceso, 2, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "06":
                    if (lFisico)
                    {
                        DataSet dsAnexo07BC = new clsRPTCNContabilidad().CNAnexo07BC(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo07BC = dsAnexo07BC.Tables[0];
                        if (dtAnexo07BC.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 07", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                            paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo07BC", dtAnexo07BC));

                            string reportpath = "RptAnexo07BC.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo07BC(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatoSucaveAnexo07A(DateTime dFecha, int idMoneda, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo07 = new clsRPTCNContabilidad().CNAnexo07A(dFecha, idMoneda, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo07.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo07.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo07C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo07C = new clsRPTCNContabilidad().CNAnexo07C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo07C.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo07C.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo07B(DateTime dFecha, int idMoneda, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo07B = new clsRPTCNContabilidad().CNAnexo07B(dFecha, idMoneda, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo07B.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo07B.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo07BC(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo07BC = new clsRPTCNContabilidad().CNAnexo07BC(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo07BC.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo07BC.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
    }
}

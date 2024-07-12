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
    public partial class frmAnexo08 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo08()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0108";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
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
                        DataSet dsAnexo08_01 = new clsRPTCNContabilidad().CNAnexo08_01(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo08_01 = dsAnexo08_01.Tables[0];

                        DataSet dsAnexo08_02 = new clsRPTCNContabilidad().CNAnexo08_02(dFechaProceso, cReporteSBS, "02");
                        DataTable dtAnexo08_02 = dsAnexo08_02.Tables[0];

                        DataSet dsAnexo08_03 = new clsRPTCNContabilidad().CNAnexo08_03(dFechaProceso, cReporteSBS, "03");
                        DataTable dtAnexo08_03 = dsAnexo08_03.Tables[0];

                        DataSet dsAnexo08_04 = new clsRPTCNContabilidad().CNAnexo08_04(dFechaProceso, cReporteSBS, "04");
                        DataTable dtAnexo08_04 = dsAnexo08_04.Tables[0];

                        DataSet dsAnexo08_05 = new clsRPTCNContabilidad().CNAnexo08_05(dFechaProceso, cReporteSBS, "05");
                        DataTable dtAnexo08_05 = dsAnexo08_05.Tables[0];

                        DataSet dsAnexo08_06 = new clsRPTCNContabilidad().CNAnexo08_06(dFechaProceso, cReporteSBS, "06");
                        DataTable dtAnexo08_06 = dsAnexo08_06.Tables[0];

                        DataSet dsAnexo08_07 = new clsRPTCNContabilidad().CNAnexo08_07(dFechaProceso, cReporteSBS, "07");
                        DataTable dtAnexo08_07 = dsAnexo08_07.Tables[0];

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                        paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));

                        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                        dtslist.Clear();

                        dtslist.Add(new ReportDataSource("dtsAnexo08_01", dtAnexo08_01));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_02", dtAnexo08_02));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_03", dtAnexo08_03));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_04", dtAnexo08_04));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_05", dtAnexo08_05));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_06", dtAnexo08_06));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_07", dtAnexo08_07));

                        string reportpath = "RptAnexo08A.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_01(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_02(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_03(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_04(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1,3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "05":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_05(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_06(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_07(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        DataSet dsAnexo08_08 = new clsRPTCNContabilidad().CNAnexo08_08(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo08_08 = dsAnexo08_08.Tables[0];

                        DataSet dsAnexo08_09 = new clsRPTCNContabilidad().CNAnexo08_09(dFechaProceso, cReporteSBS, "09");
                        DataTable dtAnexo08_09 = dsAnexo08_09.Tables[0];

                        DataSet dsAnexo08_10 = new clsRPTCNContabilidad().CNAnexo08_10(dFechaProceso, cReporteSBS, "10");
                        DataTable dtAnexo08_10 = dsAnexo08_10.Tables[0];

                        DataSet dsAnexo08_11 = new clsRPTCNContabilidad().CNAnexo08_11(dFechaProceso, cReporteSBS, "11");
                        DataTable dtAnexo08_11 = dsAnexo08_11.Tables[0];

                        DataSet dsAnexo08_12 = new clsRPTCNContabilidad().CNAnexo08_12(dFechaProceso, cReporteSBS, "12");
                        DataTable dtAnexo08_12 = dsAnexo08_12.Tables[0];

                        DataSet dsAnexo08_13 = new clsRPTCNContabilidad().CNAnexo08_13(dFechaProceso, cReporteSBS, "13");
                        DataTable dtAnexo08_13 = dsAnexo08_13.Tables[0];

                        DataSet dsAnexo08_14 = new clsRPTCNContabilidad().CNAnexo08_14(dFechaProceso, cReporteSBS, "14");
                        DataTable dtAnexo08_14 = dsAnexo08_14.Tables[0];

                        DataSet dsAnexo08_15 = new clsRPTCNContabilidad().CNAnexo08_15(dFechaProceso, cReporteSBS, "15");
                        DataTable dtAnexo08_15 = dsAnexo08_15.Tables[0];

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                        paramlist.Add(new ReportParameter("cCodEmpresa", clsVarApl.dicVarGen["cCodInst"], false));

                        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                        dtslist.Clear();

                        dtslist.Add(new ReportDataSource("dtsAnexo08_08", dtAnexo08_08));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_09", dtAnexo08_09));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_10", dtAnexo08_10));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_11", dtAnexo08_11));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_12", dtAnexo08_12));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_13", dtAnexo08_13));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_14", dtAnexo08_14));
                        dtslist.Add(new ReportDataSource("dtsAnexo08_15", dtAnexo08_15));

                        string reportpath = "RptAnexo08B.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_08(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "09":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_09(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_10(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_11(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "12":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_12(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "13":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_13(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "14":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_14(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "15":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo08_15(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveAnexo08_01(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_01 = new clsRPTCNContabilidad().CNAnexo08_01(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_01.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_01.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_02(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_02 = new clsRPTCNContabilidad().CNAnexo08_02(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_02.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_02.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_03(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_03 = new clsRPTCNContabilidad().CNAnexo08_03(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_03.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_03.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_04(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_04 = new clsRPTCNContabilidad().CNAnexo08_04(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_04.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_04.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_05(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_05 = new clsRPTCNContabilidad().CNAnexo08_05(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_05.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_05.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_06(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_06 = new clsRPTCNContabilidad().CNAnexo08_06(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_06.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_06.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_07(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_07 = new clsRPTCNContabilidad().CNAnexo08_07(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_07.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_07.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_08(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_08 = new clsRPTCNContabilidad().CNAnexo08_08(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_08.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_08.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_09(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_09 = new clsRPTCNContabilidad().CNAnexo08_09(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_09.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_09.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_10(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_10 = new clsRPTCNContabilidad().CNAnexo08_10(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_10.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_10.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_11(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_11 = new clsRPTCNContabilidad().CNAnexo08_11(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_11.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_11.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_12(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_12 = new clsRPTCNContabilidad().CNAnexo08_12(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_12.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_12.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_13(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_13 = new clsRPTCNContabilidad().CNAnexo08_13(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_13.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_13.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_14(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_14 = new clsRPTCNContabilidad().CNAnexo08_14(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_14.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_14.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo08_15(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo08_15 = new clsRPTCNContabilidad().CNAnexo08_15(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo08_15.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo08_15.Tables.Remove(T1);

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
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "016";
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
    }
}

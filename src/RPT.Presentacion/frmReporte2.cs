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
    public partial class frmReporte2 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmReporte2()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0202";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFecha.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            decimal nLimGlo = Convert.ToDecimal(txtLimGlo.Text);
            decimal nFacAju = Convert.ToDecimal(txtFacAju.Text);
            decimal nPatEfeAdi = Convert.ToDecimal(txtPatEfeAdi.Text);
            switch (cAnexoSBS)
            {
                case "02":
                    if (lFisico)
                    {
                        Reporte2A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte2A(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        DataSet dsAnexos = DatoSucaveReporte2AII(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        DataSet dsAnexos = DatoSucaveReporte2AIII(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "21":
                    if (lFisico)
                    {
                        Reporte2B1An3(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte2B1An3(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "22":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte2B1An3II(dFechaProceso, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "41":
                    if (lFisico)
                    {
                        Reporte2C1(dFechaProceso, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte2C1(dFechaProceso, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "50":
                    if (lFisico)
                    {
                        Reporte2D(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte2D(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveReporte2A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2A = new clsRPTCNCredito().CNReporte2A(dFecha, cReporteSBS, "02","03","04");
            DataTable T1 = dsReporte2A.Tables[3];
            T1.TableName = "Tab101";
            dsReporte2A.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2AII(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2A = new clsRPTCNCredito().CNReporte2A(dFecha, cReporteSBS, "02", "03", "04");
            DataTable T2 = dsReporte2A.Tables[4];
            T2.TableName = "Tab102";
            dsReporte2A.Tables.Remove(T2);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T2 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2AIII(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2A = new clsRPTCNCredito().CNReporte2A(dFecha, cReporteSBS, "02", "03", "04");
            DataTable T3 = dsReporte2A.Tables[5];
            T3.TableName = "Tab101";
            dsReporte2A.Tables.Remove(T3);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T3 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2B1An3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2B1An3 = new clsRPTCNCredito().CNReporte2B1An3(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T3 = dsReporte2B1An3.Tables[1];
            T3.TableName = "Tab101";
            dsReporte2B1An3.Tables.Remove(T3);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T3 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2B1An3II(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju)
        {
            DataSet dsReporte2B1An3II = new clsRPTCNCredito().CNReporte2B1An3II(dFecha, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju);
            DataTable T3 = dsReporte2B1An3II.Tables[1];
            T3.TableName = "Tab101";
            dsReporte2B1An3II.Tables.Remove(T3);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T3 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2C1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju, decimal nPatEfeAdi)
        {
            DataSet dsReporte2C1 = new clsRPTCNCredito().CNReporte2C1(dFecha, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);
            DataTable T3 = dsReporte2C1.Tables[1];
            T3.TableName = "Tab101";
            dsReporte2C1.Tables.Remove(T3);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T3 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte2D(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2D = new clsRPTCNCredito().CNReporte2D(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T3 = dsReporte2D.Tables[1];
            T3.TableName = "Tab101";
            dsReporte2D.Tables.Remove(T3);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T3 });
            return dsAnexos;
        }
        private void Reporte2B1An3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            decimal nLimGlo = Convert.ToDecimal(txtLimGlo.Text);
            decimal nFacAju = Convert.ToDecimal(txtFacAju.Text);

            DataSet dsReporte2B1An3 = new clsRPTCNCredito().CNReporte2B1An3(dFecha, cReporteSBS, cAnexoSbs);
            DataSet dsReporte2B1An3II = new clsRPTCNCredito().CNReporte2B1An3II(dFecha, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju);

            DataTable dtReporte2B1An3 = dsReporte2B1An3.Tables[0];
            DataTable dtReporte2B1An3II = dsReporte2B1An3II.Tables[0];
            if (dtReporte2B1An3.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsReporte2ABan3", dtReporte2B1An3));
                dtslist.Add(new ReportDataSource("dtsReporte2ABan3II", dtReporte2B1An3II));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_nLimGlo", nLimGlo.ToString(), false));
                paramlist.Add(new ReportParameter("x_nFacAju", nFacAju.ToString(), false));

                string reportpath = "RptReporte2B1An3.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte 02", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Reporte2C1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju, decimal nPatEfeAdi)
        {
            DataSet dsReporte2C1 = new clsRPTCNCredito().CNReporte2C1(dFecha, cReporteSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);

            DataTable dtReporte2C1 = dsReporte2C1.Tables[0];
            if (dtReporte2C1.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsReporte2C1", dtReporte2C1));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_nLimGlo", nLimGlo.ToString(), false));
                paramlist.Add(new ReportParameter("x_nFacAju", nFacAju.ToString(), false));
                paramlist.Add(new ReportParameter("x_nPatEfeAdi", nFacAju.ToString(), false));

                string reportpath = "RptReporte2C1.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte 02D", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Reporte2D(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2D = new clsRPTCNCredito().CNReporte2D(dFecha, cReporteSBS, cAnexoSbs);

            DataTable dtReporte2D = dsReporte2D.Tables[0];
            if (dtReporte2D.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsReporte2D", dtReporte2D));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                string reportpath = "RptReporte2D.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte 02D", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Reporte2A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsReporte2A = new clsRPTCNCredito().CNReporte2A(dFecha, cReporteSBS, "02", "03", "04");
            DataTable dtReporte2AI = dsReporte2A.Tables[0];
            DataTable dtReporte2AII = dsReporte2A.Tables[1];
            DataTable dtReporte2AIII = dsReporte2A.Tables[2];
            if (dtReporte2AI.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsReporte2A", dtReporte2AI));
                dtslist.Add(new ReportDataSource("dtsReporte2A_II", dtReporte2AII));
                dtslist.Add(new ReportDataSource("dtsReporte2A_III", dtReporte2AIII));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dfecha", dFecha.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                string reportpath = "RptReporte2A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos", "Valida Anexo F", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "012";
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"])*100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }

        private void frmReporte2_Load(object sender, EventArgs e)
        {
            txtLimGlo.Text = Convert.ToString(clsVarApl.dicVarGen["nLimGloReqPat"]);
            txtLimGloBC.Text = Convert.ToString(clsVarApl.dicVarGen["nLimGloReqPatAD"]);
        }
    }
}

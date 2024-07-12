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
    public partial class frmAnexo15 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo15()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
        }

        private void frmAnexo15B_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0115";
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
                        Anexo15A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo15A(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo15AOtr(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 7))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "03":
                    if (lFisico)
                    {
                        Anexo15C(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo15C(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        Anexo15B(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo15B(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveAnexo15AOtr(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15AOtr = new clsRPTCNContabilidad().CNAnexo15AOtr(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo15AOtr.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo15AOtr.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo15C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15C = new clsRPTCNContabilidad().CNAnexo15C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo15C.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo15C.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo15B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15B = new clsRPTCNContabilidad().CNAnexo15B(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo15B.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo15B.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }

        private void Anexo15A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15A = new clsRPTCNContabilidad().CNAnexo15A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo15A = dsAnexo15A.Tables[0];

            DataSet dsAnexo15AOtr = new clsRPTCNContabilidad().CNAnexo15AOtr(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo15AOtr = dsAnexo15AOtr.Tables[0];
            
            if (dtAnexo15A.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo15A", dtAnexo15A));
                dtslist.Add(new ReportDataSource("dtsOtrOpe", dtAnexo15AOtr));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                string reportpath = "RptAnexo15A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 15 A", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Anexo15B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15B = new clsRPTCNContabilidad().CNAnexo15B(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo15B = dsAnexo15B.Tables[0];

            if (dtAnexo15B.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo15B", dtAnexo15B));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptAnexo15B1.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 15 B", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataSet DatoSucaveAnexo15A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15A = new clsRPTCNContabilidad().CNAnexo15A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo15A.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo15A.Tables.Remove(T1);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private void Anexo15C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo15C = new clsRPTCNContabilidad().CNAnexo15C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo15C = dsAnexo15C.Tables[0];
            if (dtAnexo15C.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo15C", dtAnexo15C));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                string reportpath = "RptAnexo15C.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 15 B", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

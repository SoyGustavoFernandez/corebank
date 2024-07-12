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
using GEN.ControlesBase;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmAnexo12 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo12()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0112";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }

        private void frmAnexo12II_Load(object sender, EventArgs e)
        {

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
                        DataSet dsAnexo12I = new clsRPTCNCredito().CNAnexo12_I(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo12I = dsAnexo12I.Tables[0];
                        if (dtAnexo12I.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 12", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo12I", dtAnexo12I));

                            string reportpath = "RptAnexo12I.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo12I(dFechaProceso, 1, cReporteSBS, cAnexoSbs);

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
                        DataSet dsAnexo12II = new clsRPTCNCredito().CNAnexo12II(dFechaProceso, cReporteSBS, cAnexoSbs);
                        DataTable dtAnexo12II = dsAnexo12II.Tables[0];
                        if (dtAnexo12II.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el Anexo", "Anexo 12 II", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.Date.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo12II", dtAnexo12II));

                            string reportpath = "RptAnexo12II.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo12II(dFechaProceso, 1, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveAnexo12I(DateTime dFecha, int idMoneda, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo12I = new clsRPTCNCredito().CNAnexo12_I(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo12I.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo12I.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo12II(DateTime dFecha, int idMoneda, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo12I = new clsRPTCNCredito().CNAnexo12II(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo12I.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo12I.Tables.Remove(T1);

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

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
    public partial class frmAnexoF : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexoF()
        {
            InitializeComponent();
        }

        private void rptAnexoF_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0500";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
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
                        AnexoB(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexoB(dFechaProceso, cReporteSBS, cAnexoSbs);
                        if (dsAnexos.Tables.Count==0)
                        {
                            return;
                        }
                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6,"000"))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                        AnexoF(cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexoF(cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6,"012"))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private void AnexoF(string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexoF = new clsRPTCNCredito().CNAnexoF(cReporteSBS, cAnexoSbs);
            DataTable dtAnexoF = dsAnexoF.Tables[0];
            if (dtAnexoF.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsAnexoF", dtAnexoF));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodEmpresa", clsVarApl.dicVarGen["cCodInstFin"], false));

                string reportpath = "rptAnexoF.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos", "Valida Anexo F", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AnexoB(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexoB = new clsRPTCNCredito().CNAnexoB(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexoB = dsAnexoB.Tables[0];
            if (dtAnexoB.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsMovOfi", dtAnexoB));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInstFin"], false));

                string reportpath = "rptAnexoB.rdlc";
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
        private DataSet DatoSucaveAnexoB(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexoB = new clsRPTCNCredito().CNAnexoB(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexoB.Tables[1];
            T1.TableName = "Tab101";
            DataSet dsAnexos = new DataSet();
            if (T1.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para generar archivo SUCAVE", "Reporte Regulatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return dsAnexos;
            }
            dsAnexoB.Tables.Remove(T1);
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexoF(string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexoF = new clsRPTCNCredito().CNAnexoF(cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexoF.Tables[1];
            T1.TableName = "Tab101";
            dsAnexoF.Tables.Remove(T1);
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
                sr = new StreamWriter(@cNomArc,false,Encoding.ASCII);
            }
            else
            {
                sr = null;
            }
            return sr;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila, string cRedondeo)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + cRedondeo;
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]))).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }
    }
}

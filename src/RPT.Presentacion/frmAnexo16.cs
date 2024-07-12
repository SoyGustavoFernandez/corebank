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
    public partial class frmAnexo16 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        decimal nFSD = 0, nPatrimonio = 0;

        public frmAnexo16()
        {
            InitializeComponent();
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
            string cCodigoSBS = "0116";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }
        private void ValorFSD(DateTime dFecha)
        {
            DataTable dtFSD = new clsRPTCNReporte().CNRetornaValorFSD(dFecha);
            if (dtFSD.Rows.Count == 0)
            {
                nFSD = 0;
            }
            else
            {
                nFSD = Convert.ToDecimal(dtFSD.Rows[0]["nMaxCoberFSD"]);
            }
        }

        private decimal ValorPatrimonio(DateTime dFecha, int idMoneda, string cCuenta)
        {
            DataTable dtSaldoPatrimonio = new clsRPTCNContabilidad().CNSaldoCtaCnt(dFecha, idMoneda, cCuenta);
            if (dtSaldoPatrimonio.Rows.Count == 0)
            {
                nPatrimonio = 0;
            }
            else
            {
                nPatrimonio = Convert.ToDecimal(dtSaldoPatrimonio.Rows[0]["nValorFinal"]);
            }
            return nPatrimonio;
        }


        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFecha.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            ValorFSD(dtpFecha.Value);
            nPatrimonio = 0;

            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        Anexo16_1(dFechaProceso, nFSD, 1, nPatrimonio, cReporteSBS, cAnexoSbs, "ANEXO N° 16-A - MONEDA NACIONAL");
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo16(dFechaProceso, 1, cReporteSBS, cAnexoSbs);

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
                        Anexo16_1(dFechaProceso, nFSD, 2, nPatrimonio, cReporteSBS, cAnexoSbs, "ANEXO N° 16-A - MONEDA EXTRANJERA");
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo16(dFechaProceso, 2, cReporteSBS, cAnexoSbs);

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
                        Anexo16_1(dFechaProceso, nFSD, 0, nPatrimonio, cReporteSBS, cAnexoSbs, "ANEXO N° 16-A - TOTAL");
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo16(dFechaProceso, 0, cReporteSBS, cAnexoSbs);

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
                        Anexo16_4(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo164(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveAnexo16(DateTime dFecha, int idMoneda, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo16 = new clsRPTCNCredito().CNAnexo16(dFecha, nFSD, idMoneda, nPatrimonio, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo16.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo16.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo164(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo164 = new clsRPTCNCredito().CNAnexoInd16(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo164.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo164.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }

        private void Anexo16_4(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            DataSet dsAnexo16_4 = new clsRPTCNCredito().CNAnexoInd16(dFecha, cCodSBS, cAnexo);
            DataTable dtAnexo16_4 = dsAnexo16_4.Tables[0];
            if (dtAnexo16_4.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Anexo", "Anexo 16-4", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsAnexo16A4", dtAnexo16_4));

                string reportpath = "RptAnexo16A4.rdlc";
                new frmReporteLocal(dtslist, reportpath).ShowDialog();
            }
        }

        private void Anexo16_1(DateTime dFecha, decimal nFSD, int idMoneda, decimal nPatrimonio, string cCodSBS, string cAnexo, string cTitulo)
        {
            DataSet dsAnexo16_1 = new clsRPTCNCredito().CNAnexo16(dFecha, nFSD, idMoneda, nPatrimonio, cCodSBS, cAnexo);
            DataTable dtAnexo16_1 = dsAnexo16_1.Tables[0];
            if (dtAnexo16_1.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Anexo", "Anexo 16", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.Date.ToString(), false));
                paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("x_cTitulo", cTitulo, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsAnexo16", dtAnexo16_1));

                string reportpath = "rptAnexo16.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
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
    }
}

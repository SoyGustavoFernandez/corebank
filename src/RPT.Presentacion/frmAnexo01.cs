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
    public partial class frmAnexo01 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo01()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0101";
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
                        DataTable dtAnexo01 = new clsRPTCNCredito().ADAnexo01A(dFechaProceso);
                        if (dtAnexo01.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el reporte", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Clear();

                            paramlist.Add(new ReportParameter("x_dFecha", dFechaProceso.ToString("dd/MM/yyyy"), false));
                            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo01A", dtAnexo01));

                            string reportpath = "RptAnexo01A.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataTable dtAnexo01 = new clsRPTCNCredito().ADAnexo01A(dFechaProceso);
                        if (dtAnexo01.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el reporte", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            DialogResult result;
                            result = folderBrowserDialog1.ShowDialog();
                            string cRuta, cNomArc;

                            if (result == DialogResult.OK)
                            {
                                cRuta = folderBrowserDialog1.SelectedPath;
                                cNomArc = "\\010101" +
                                            dFechaProceso.Year.ToString().Substring(2, 2) +
                                            dFechaProceso.Month.ToString("00") +
                                            dFechaProceso.Day.ToString("00") + ".101";

                                StreamWriter sr = new StreamWriter(cRuta + @cNomArc, false, Encoding.ASCII);
                                string pcCadena;

                                pcCadena = "010101" + clsVarApl.dicVarGen["cCodInst"] +
                                            dFechaProceso.Year.ToString() +
                                            dFechaProceso.Month.ToString("00") +
                                            dFechaProceso.Day.ToString("00") + "016";
                                sr.WriteLine(pcCadena);

                                for (int i = 0; i < dtAnexo01.Rows.Count; i++)
                                {
                                    pcCadena = dtAnexo01.Rows[i]["nidFila"].ToString().PadLeft(6, ' ') +
                                                dtAnexo01.Rows[i]["cCtaCtbS"].ToString().PadLeft(14, ' ') +
                                                dtAnexo01.Rows[i]["cCodISIN"].ToString().PadLeft(20, ' ') +
                                                dtAnexo01.Rows[i]["cCatCtbS"].ToString().PadLeft(4, ' ') +
                                                dtAnexo01.Rows[i]["cTipInsS"].ToString().PadLeft(10, ' ') +
                                                dtAnexo01.Rows[i]["cPlaza"].ToString().PadLeft(40, ' ') +
                                                dtAnexo01.Rows[i]["cTipEmiS"].ToString().PadLeft(3, ' ') +
                                                dtAnexo01.Rows[i]["cEmisor"].ToString().PadLeft(50, ' ') +
                                                dtAnexo01.Rows[i]["cPaisS"].ToString().PadLeft(2, ' ') +
                                                dtAnexo01.Rows[i]["cAmbitoS"].ToString().PadLeft(2, ' ') +
                                                dtAnexo01.Rows[i]["cMonedaS"].ToString().PadLeft(3, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nTipCam"]) * 10000, 0).ToString().PadLeft(8, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nNumUni"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                dtAnexo01.Rows[i]["dFecNegS"].ToString().PadLeft(8, ' ') +
                                                dtAnexo01.Rows[i]["dFecLiqS"].ToString().PadLeft(8, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nCosTot"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValRaz"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                dtAnexo01.Rows[i]["cFuente"].ToString().PadLeft(40, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nToVaRa"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nFluVal"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nDetVal"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValLib"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                dtAnexo01.Rows[i]["cClaRie"].ToString().PadLeft(10, ' ') +
                                                dtAnexo01.Rows[i]["cEmpCla"].ToString().PadLeft(40, ' ') +
                                                dtAnexo01.Rows[i]["cCustod"].ToString().PadLeft(40, ' ') +
                                                dtAnexo01.Rows[i]["cClaCus"].ToString().PadLeft(10, ' ');
                                    sr.WriteLine(pcCadena);
                                }
                                sr.Flush();
                                sr.Close();

                                MessageBox.Show("El Archivo " + cNomArc + " se generó correctamente", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                        DataTable dtAnexo01 = new clsRPTCNCredito().ADAnexo01B(dFechaProceso);
                        if (dtAnexo01.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el reporte", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Clear();

                            paramlist.Add(new ReportParameter("dFecha", dFechaProceso.ToString("dd/MM/yyyy"), false));
                            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsAnexo01B", dtAnexo01));

                            string reportpath = "RptAnexo01B.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                    }
                    if (lSucave)
                    {
                        DataTable dtAnexo01 = new clsRPTCNCredito().ADAnexo01B(dFechaProceso);
                        if (dtAnexo01.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el reporte", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            DialogResult result;
                            result = folderBrowserDialog1.ShowDialog();
                            string cRuta, cNomArc;

                            if (result == DialogResult.OK)
                            {
                                cRuta = folderBrowserDialog1.SelectedPath;
                                cNomArc = "\\010102" +
                                            dFechaProceso.Year.ToString().Substring(2, 2) +
                                            dFechaProceso.Month.ToString("00") +
                                            dFechaProceso.Day.ToString("00") + ".101";

                                StreamWriter sr = new StreamWriter(cRuta + @cNomArc, false, Encoding.ASCII);
                                string pcCadena;

                                pcCadena = "010102" + clsVarApl.dicVarGen["cCodInst"] +
                                            dFechaProceso.Year.ToString() +
                                            dFechaProceso.Month.ToString("00") +
                                            dFechaProceso.Day.ToString("00") + "016";
                                sr.WriteLine(pcCadena);

                                for (int i = 0; i < dtAnexo01.Rows.Count; i++)
                                {
                                    pcCadena = dtAnexo01.Rows[i]["nidFila"].ToString().PadLeft(6, ' ') +
                                                dtAnexo01.Rows[i]["cCtaCtb"].ToString().PadLeft(14, ' ') +
                                                dtAnexo01.Rows[i]["ISINIdentif"].ToString().PadLeft(20, ' ') +
                                                dtAnexo01.Rows[i]["cCatCntS"].ToString().PadLeft(4, ' ') +
                                                dtAnexo01.Rows[i]["cTipIns"].ToString().PadLeft(10, ' ') +
                                                dtAnexo01.Rows[i]["cTipEmisorS"].ToString().PadLeft(3, ' ') +
                                                dtAnexo01.Rows[i]["Emisor"].ToString().PadLeft(50, ' ') +
                                                dtAnexo01.Rows[i]["cPaisS"].ToString().PadLeft(2, ' ') +
                                                dtAnexo01.Rows[i]["cAmbito"].ToString().PadLeft(2, ' ') +
                                                dtAnexo01.Rows[i]["FEmision"].ToString().PadLeft(8, ' ') +
                                                dtAnexo01.Rows[i]["FVencimiento"].ToString().PadLeft(8, ' ') +
                                                dtAnexo01.Rows[i]["cFacAct"].ToString().PadLeft(10, ' ') +
                                                dtAnexo01.Rows[i]["cTipTas"].ToString().PadLeft(20, ' ') +
                                                dtAnexo01.Rows[i]["cFecRep"].ToString().PadLeft(8, ' ') +
                                                dtAnexo01.Rows[i]["cOpcionS"].ToString().PadLeft(2, ' ') +
                                                dtAnexo01.Rows[i]["Moneda"].ToString().PadLeft(3, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["cTipCam"]) * 10000, 0).ToString().PadLeft(8, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nNroUni"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValNom"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                dtAnexo01.Rows[i]["dFecNeg"].ToString().PadLeft(8, ' ') +
                                                dtAnexo01.Rows[i]["dFecLiq"].ToString().PadLeft(8, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nCosTot"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["TIRCompra"]) * 100000000, 0).ToString().PadLeft(9, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nInteres"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nCosAmo"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["TasValRaz"]) * 100000000, 0).ToString().PadLeft(9, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValRazUni"]) * 1000000, 0).ToString().PadLeft(9, ' ') +
                                                dtAnexo01.Rows[i]["cFuente"].ToString().PadLeft(40, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValRazTot"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nFluVal"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nDetVal"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nValLib"]) * 1000000, 0).ToString().PadLeft(18, ' ') +
                                                dtAnexo01.Rows[i]["cClasifica"].ToString().PadLeft(10, ' ') +
                                                dtAnexo01.Rows[i]["cEmpCalRiw"].ToString().PadLeft(40, ' ') +
                                                dtAnexo01.Rows[i]["cCustodio"].ToString().PadLeft(40, ' ') +
                                                dtAnexo01.Rows[i]["cClasificaCus"].ToString().PadLeft(10, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nDuraMac"]) * 1000000, 0).ToString().PadLeft(9, ' ') +
                                                Math.Round(Convert.ToDecimal(dtAnexo01.Rows[i]["nDurMod"]) * 1000000, 0).ToString().PadLeft(9, ' ');
                                    sr.WriteLine(pcCadena);
                                }
                                sr.Flush();
                                sr.Close();

                                MessageBox.Show("El Archivo " + cNomArc + " se generó correctamente", "Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                
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

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
    public partial class frmFormatoEEFF : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        clsRPTCNContabilidad cnDatos = new clsRPTCNContabilidad();
    public frmFormatoEEFF()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0100";
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
        private void FormaF(DateTime dFecProceso, string cCodSBS, string cCodAnexo)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            DateTime dFecha = dtpFechaProceso.Value.Date;
            int idMoneda = 0; // siempre se procesa para el integrado
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsBalanceComprobacion", new clsRPTCNContabilidad().CNBalanceComprobacionEEFF(dFecha)));

            string reportpath = "RptBalanceComprobacion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        private void FormaB2(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsFormaB2 = cnDatos.CNFormaF(dFecProceso, cCodSBS, cAnexo);
            DataTable dtFormaB2 = dsFormaB2.Tables[0];
            if (dtFormaB2.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 6E", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsFormaB2", dtFormaB2));

                string reportpath = "RptFormaB2.rdlc";
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
                        FormaF(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DateTime dFecha = dtpFechaProceso.Value.Date;
                        int idMoneda = 0;

                        DataTable dtBalance = new clsRPTCNContabilidad().CNBalanceComprobacionSucave(dFecha, idMoneda);
                        if (dtBalance.Rows.Count == 0)
                        {
                            MessageBox.Show("No existen datos para el reporte", "Balance comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            DialogResult result;
                            result = folderBrowserDialog1.ShowDialog();
                            string cRuta;
                            string cNomArc;

                            if (result == DialogResult.OK)
                            {
                                cRuta = folderBrowserDialog1.SelectedPath;
                                cNomArc = cRuta + "\\01" +
                                            dFecha.Year.ToString().Substring(2, 2) +
                                            dFecha.Month.ToString("00") +
                                            dFecha.Day.ToString("00") + ".100";

                                StreamWriter sr = new StreamWriter(@cNomArc);
                                string pcCadena;
                                for (int i = 0; i < dtBalance.Rows.Count; i++)
                                {
                                    pcCadena = dFecha.Year.ToString("0000") + dFecha.Month.ToString("00") +
                                                clsVarApl.dicVarGen["cCodInst"].ToString().Substring(2, 3) +
                                                dtBalance.Rows[i]["cCuentaContable"].ToString().PadRight(20, '0') +
                                                Math.Round(Convert.ToDecimal(dtBalance.Rows[i]["nValorInicial"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtBalance.Rows[i]["nDebe"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtBalance.Rows[i]["nHaber"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                                Math.Round(Convert.ToDecimal(dtBalance.Rows[i]["nValorFinal"]) * 100, 0).ToString().PadLeft(18, ' ');
                                    sr.WriteLine(pcCadena);
                                }
                                sr.Close();
                                MessageBox.Show("El archivo se genero correctamente", "Balance comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                case "04":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                        frmRegUtiPerBasDil frmRegistro = new frmRegUtiPerBasDil(dtpFechaProceso.Value);
                        frmRegistro.ShowDialog();

                        DataSet dsAnexos = DatoEEFFAnexo04(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6,"016"))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }

                    }
                    break;

                case "06":
                    if (lFisico)
                    {
                        MessageBox.Show("Reporte no aplica a la Entidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (lSucave)
                    {
                        MessageBox.Show("Reporte no aplica a la Entidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case "05":
                    if (lFisico)
                    {
                        MessageBox.Show("Reporte en el módulo de contabilidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = SucaveCamPat(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 4, "012"))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "08":
                    if (lFisico)
                    {
                        FormaB2(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveFormaB2(dFechaProceso, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso,6,"012"))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatoEEFFAnexo04(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataTable T1 = new clsRPTCNContabilidad().CNEEFF04(dFecha, cReporteSBS, cAnexoSbs);
            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }

        private DataSet DatoSucaveFormaF(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataTable dtBalCom = cnDatos.CNBalanceComprobacionSucave(dFecha, 0);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { dtBalCom });
            return dsAnexos;
        }
        private DataSet DatoSucaveFormaB2(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsFormaB2 = cnDatos.CNFormaF(dFecProceso, cCodSBS, cAnexo);
            DataTable T1 = dsFormaB2.Tables[1];
            T1.TableName = "Tab101";
            dsFormaB2.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet SucaveCamPat(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsCamPat = cnDatos.CNRptCambioPatrimonio(dFecProceso, 0, cCodSBS, cAnexo);
            DataTable T1 = dsCamPat.Tables[1];
            T1.TableName = "Tab101";
            dsCamPat.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila, string cDecimal)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + cDecimal;
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

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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmAnexo05 : frmBase
    {
        clsRPTCNProvision cnprovision = new clsRPTCNProvision();
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        DataTable T1, T2, T3, T4, T5, T6, T7, T71, T8, T9, T10, T11, T12, T13, T14;

        public frmAnexo05()
        {
            InitializeComponent();
            dtpFechaSis.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0105";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
        }
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFechaSis.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lFisico)
                    {
                        Anexo5(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DateTime dFecha = dtpFechaSis.Value;
                        DataSet dsAnexos = DatosSucave(dFecha, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFecha.ToString("yyMMdd") + "." + cReporteSBS.Substring(1,3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecha);
                        CierreArchivo(Archivo, cNomArc);
                    }
                    break;
                case "02":
                    if (lFisico)
                    {
                    }
                    if (lSucave)
                    {
                        DateTime dFecha = dtpFechaSis.Value;
                        DataSet dsAnexos = DatosSucave02(dFecha, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFecha.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecha))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;

                case "03":
                    if (lFisico)
                    {
                        Anexo5A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DateTime dFecha = dtpFechaSis.Value;
                        DataSet dsAnexos = DatosSucaveAnexo5A(dFecha, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFecha.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecha))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "04":
                    if (lFisico)
                    {
                        Anexo5B(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DateTime dFecha = dtpFechaSis.Value;
                        DataSet dsAnexos = DatosSucaveAnexo5B(dFecha, cReporteSBS, cAnexoSbs);

                        string cNomArc = "\\" + cAnexoSbs + dFecha.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
                        StreamWriter Archivo;
                        Archivo = GeneraArchivoSucave(cNomArc);
                        if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecha))
                        {
                            CierreArchivo(Archivo, cNomArc);
                        }
                    }
                    break;
                case "05":
                    if (lFisico)
                    {
                        MessageBox.Show("Reporte no aplica a la Entidad", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case "07":
                    if (lFisico)
                    {
                        Anexo5D(dFechaProceso);
                    }
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private DataSet DatosSucaveAnexo5B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo05B = cnprovision.CNAnexo05B_C(dFecha, cReporteSBS, cAnexoSbs);
            T1 = dsAnexo05B.Tables[0];
            T1.TableName = "Tab104";
            dsAnexo05B.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatosSucaveAnexo5A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo05A = cnprovision.CNAnexo05A(dFecha, cReporteSBS, cAnexoSbs);
            T1 = dsAnexo05A.Tables[0];
            T1.TableName = "Tab103";
            dsAnexo05A.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatosSucave02(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo05_V = cnprovision.CNAnexo05_V(dFecha, cReporteSBS, cAnexoSbs);
            T1 = dsAnexo05_V.Tables[0];
            T1.TableName = "Tab102";
            dsAnexo05_V.Tables.Remove(T1);

            DataSet dsAnexo05_V2 = cnprovision.CNAnexo05CredInd_V(dFecha, cReporteSBS, cAnexoSbs);
            T2 = dsAnexo05_V2.Tables[0];
            T2.TableName = "Tab202";
            dsAnexo05_V2.Tables.Remove(T2);

            DataSet dsAnexo05_W = cnprovision.CNAnexo05_W(dFecha, cReporteSBS, cAnexoSbs);
            T3 = dsAnexo05_W.Tables[0];
            T3.TableName = "Tab302";
            dsAnexo05_W.Tables.Remove(T3);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] {T1,T2,T3});
            return dsAnexos;
        }
        private DataSet DatosSucave(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo05A = cnprovision.CNAnexo05_A(dFecha, cReporteSBS, cAnexoSbs);
            T1 = dsAnexo05A.Tables[0];
            T1.TableName = "Tab1";
            dsAnexo05A.Tables.Remove(T1);

            DataSet dsAnexo05AP = cnprovision.CNAnexo05_AP(dFecha, cReporteSBS, cAnexoSbs);
            T2 = dsAnexo05AP.Tables[0];
            T2.TableName = "Tab2";
            dsAnexo05AP.Tables.Remove(T2);

            DataSet dsAnexo05_B = cnprovision.CNAnexo05_B(dFecha, cReporteSBS, cAnexoSbs);
            T3 = dsAnexo05_B.Tables[0];
            T3.TableName = "Tab3";
            dsAnexo05_B.Tables.Remove(T3);

            DataSet dsAnexo05_C = cnprovision.CNAnexo05_C(dFecha, cReporteSBS, cAnexoSbs);
            T4 = dsAnexo05_C.Tables[0];
            T4.TableName = "Tab4";
            dsAnexo05_C.Tables.Remove(T4);

            DataSet dsAnexo05_CP = cnprovision.CNAnexo05_CP(dFecha, cReporteSBS, cAnexoSbs);
            T5 = dsAnexo05_CP.Tables[0];
            T5.TableName = "Tab5";
            dsAnexo05_CP.Tables.Remove(T5);

            DataSet dsAnexo05_D = cnprovision.CNAnexo05_D(dFecha, cReporteSBS, cAnexoSbs);
            T6 = dsAnexo05_D.Tables[0];
            T6.TableName = "Tab6";
            dsAnexo05_D.Tables.Remove(T6);

            DataSet dsAnexo05_DP = cnprovision.CNAnexo05_DP(dFecha, cReporteSBS, cAnexoSbs);
            T7 = dsAnexo05_DP.Tables[0];
            T7.TableName = "Tab7";
            dsAnexo05_DP.Tables.Remove(T7);

            DataSet dsAnexo05_DPP = cnprovision.CNAnexo05_DPP(dFecha, cReporteSBS, cAnexoSbs);
            T71 = dsAnexo05_DPP.Tables[0];
            T71.TableName = "Tab71";
            dsAnexo05_DPP.Tables.Remove(T71);

            DataSet dsAnexo05_E = cnprovision.CNAnexo05_E(dFecha, cReporteSBS, cAnexoSbs);
            T8 = dsAnexo05_E.Tables[0];
            T8.TableName = "Tab8";
            dsAnexo05_E.Tables.Remove(T8);

            DataSet dsAnexo05_F = cnprovision.CNAnexo05_F(dFecha, cReporteSBS, cAnexoSbs);
            T9 = dsAnexo05_F.Tables[0];
            T9.TableName = "Tab9";
            dsAnexo05_F.Tables.Remove(T9);

            DataSet dsAnexo05_G = cnprovision.CNAnexo05_G(dFecha, cReporteSBS, cAnexoSbs);
            T10 = dsAnexo05_G.Tables[0];
            T10.TableName = "Tab10";
            dsAnexo05_G.Tables.Remove(T10);

            DataSet dsAnexo05_H = cnprovision.CNAnexo05_H(dFecha, cReporteSBS, cAnexoSbs);
            T11 = dsAnexo05_H.Tables[0];
            T11.TableName = "Tab11";
            dsAnexo05_H.Tables.Remove(T11);

            DataSet dsAnexo05_I = cnprovision.CNAnexo05_I(dFecha, cReporteSBS, cAnexoSbs);
            T12 = dsAnexo05_I.Tables[0];
            T12.TableName = "Tab12";
            dsAnexo05_I.Tables.Remove(T12);

            DataSet dsAnexo05_J = cnprovision.CNAnexo05_J(dFecha, cReporteSBS, cAnexoSbs);
            T13 = dsAnexo05_J.Tables[0];
            T13.TableName = "Tab13";
            dsAnexo05_J.Tables.Remove(T13);

            DataSet dsAnexo05_K = cnprovision.CNAnexo05_K(dFecha, cReporteSBS, cAnexoSbs);
            T14 = dsAnexo05_K.Tables[0];
            T14.TableName = "Tab14";
            dsAnexo05_K.Tables.Remove(T14);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1, T2, T3, T4, T5, T6, T7, T71, T8, T9, T10, T11, T12, T13, T14 });
            return dsAnexos;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha)
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
                    pcCadena = (Convert.ToInt32(Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString().PadLeft(6, ' ') + dtDato.Rows[j]["cTexto"].ToString();
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

        #region Anexos
        private void Anexo5(DateTime dFecha, string cReporteSBS,string cAnexoSbs)
        {
            DataSet dsAnexo05A = cnprovision.CNAnexo05_A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_A = dsAnexo05A.Tables[1];

            DataSet dsAnexo05AP = cnprovision.CNAnexo05_AP(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_AP = dsAnexo05AP.Tables[1];

            DataSet dsAnexo05_B = cnprovision.CNAnexo05_B(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_B = dsAnexo05_B.Tables[1];

            DataSet dsAnexo05_C = cnprovision.CNAnexo05_C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_C = dsAnexo05_C.Tables[1];

            DataSet dsAnexo05_CP = cnprovision.CNAnexo05_CP(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_CP = dsAnexo05_CP.Tables[1];

            DataSet dsAnexo05_D = cnprovision.CNAnexo05_D(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_D = dsAnexo05_D.Tables[1];

            DataSet dsAnexo05_DP = cnprovision.CNAnexo05_DP(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_DP = dsAnexo05_DP.Tables[1];

            DataSet dsAnexo05_E = cnprovision.CNAnexo05_E(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_E = dsAnexo05_E.Tables[1];

            DataSet dsAnexo05_F = cnprovision.CNAnexo05_F(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_F = dsAnexo05_F.Tables[1];

            DataSet dsAnexo05_G = cnprovision.CNAnexo05_G(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_G = dsAnexo05_G.Tables[1];

            DataSet dsAnexo05_H = cnprovision.CNAnexo05_H(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_H = dsAnexo05_H.Tables[1];

            DataSet dsAnexo05_I = cnprovision.CNAnexo05_I(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_I = dsAnexo05_I.Tables[1];

            DataSet dsAnexo05_J = cnprovision.CNAnexo05_J(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_J = dsAnexo05_J.Tables[1];

            DataSet dsAnexo05_K = cnprovision.CNAnexo05_K(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_K = dsAnexo05_K.Tables[1];

            DataSet dsAnexo05_V = cnprovision.CNAnexo05_V(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_V = dsAnexo05_V.Tables[1];

            DataSet dsAnexo05_V2 = cnprovision.CNAnexo05CredInd_V(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_V2 = dsAnexo05_V2.Tables[1];

            DataSet dsAnexo05_W = cnprovision.CNAnexo05_W(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05_W = dsAnexo05_W.Tables[1];

            if (dtAnexo05_A.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo05A", dtAnexo05_A));
                dtslist.Add(new ReportDataSource("dtsAnexo05AP", dtAnexo05_AP));
                dtslist.Add(new ReportDataSource("dtsAnexo05B", dtAnexo05_B));
                dtslist.Add(new ReportDataSource("dtsAnexo05C", dtAnexo05_C));
                dtslist.Add(new ReportDataSource("dtsAnexo05CP", dtAnexo05_CP));
                dtslist.Add(new ReportDataSource("dtsAnexo05D", dtAnexo05_D));
                dtslist.Add(new ReportDataSource("dtsAnexo05DP", dtAnexo05_DP));
                dtslist.Add(new ReportDataSource("dtsAnexo05E", dtAnexo05_E));
                dtslist.Add(new ReportDataSource("dtsAnexo05F", dtAnexo05_F));
                dtslist.Add(new ReportDataSource("dtsAnexo05G", dtAnexo05_G));
                dtslist.Add(new ReportDataSource("dtsAnexo05H", dtAnexo05_H));
                dtslist.Add(new ReportDataSource("dtsAnexo05I", dtAnexo05_I));
                dtslist.Add(new ReportDataSource("dtsAnexo05J", dtAnexo05_J));
                dtslist.Add(new ReportDataSource("dtsAnexo05K", dtAnexo05_K));
                dtslist.Add(new ReportDataSource("dtsAnexo05V", dtAnexo05_V));
                dtslist.Add(new ReportDataSource("dtsAnexo05V2", dtAnexo05_V2));
                dtslist.Add(new ReportDataSource("dtsAnexo05W", dtAnexo05_W));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                string reportpath = "RPTAnexo05.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 05", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Anexo5B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataTable dtAnexo05A_A = cnprovision.CNAnexo05B_A(dFecha);
            DataTable dtAnexo05A_B = cnprovision.CNAnexo05B_B(dFecha);
            DataSet dsAnexo05A_C = cnprovision.CNAnexo05B_C(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05A_C = dsAnexo05A_C.Tables[1];

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsAnexo05B_A", dtAnexo05A_A));
            dtslist.Add(new ReportDataSource("dtsAnexo05B_B", dtAnexo05A_B));
            dtslist.Add(new ReportDataSource("dtsAnexo05B_C", dtAnexo05A_C));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

            string reportpath = "RPTAnexo05B.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            return;
        }

        private void Anexo5A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo05A = cnprovision.CNAnexo05A(dFecha, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo05A = dsAnexo05A.Tables[1];

            if (dtAnexo05A.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo05A", dtAnexo05A));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                string reportpath = "RPTAnexo05A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 05", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Anexo5D(DateTime dFecha)
        {
            DataTable dtAnexo05D_A = cnprovision.CNAnexo05D_A(dFecha);
            DataTable dtAnexo05D_B = cnprovision.CNAnexo05D_B(dFecha);
            DataTable dtAnexo05D_C = cnprovision.CNAnexo05D_C(dFecha);
            DataTable dtAnexo05D_D = cnprovision.CNAnexo05D_D(dFecha);
            DataTable dtAnexo05D_E = cnprovision.CNAnexo05D_E(dFecha);

            if (dtAnexo05D_A.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo05D_A", dtAnexo05D_A));
                dtslist.Add(new ReportDataSource("dtsAnexo05D_B", dtAnexo05D_B));
                dtslist.Add(new ReportDataSource("dtsAnexo05D_C", dtAnexo05D_C));
                dtslist.Add(new ReportDataSource("dtsAnexo05D_D", dtAnexo05D_D));
                dtslist.Add(new ReportDataSource("dtsAnexo05D_E", dtAnexo05D_E));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptAnexo05D.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 05", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

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

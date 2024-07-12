using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace RPT.Presentacion
{
    public partial class frmSbsAnexo17A : frmBase
    {
        private string InitialDirectory = "C:\\";
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmSbsAnexo17A()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
            string cCodigoSBS = "0117";
            DataTable dtReportes = cnDatoGenericos.CNListaReportesSBS(cCodigoSBS);
            dtgListaReporte.DataSource = dtReportes;
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
        private void Procesa(string cAnexoSBS, Boolean lFisico, Boolean lSucave, string cReporteSBS, string cAnexoSbs)
        {
            DateTime dFechaProceso = dtpFechaProceso.Value.Date;
            Cursor.Current = Cursors.WaitCursor;
            switch (cAnexoSBS)
            {
                case "01":
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo17_G(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                        Anexo17A(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo17A(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo17B(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo17C(dFechaProceso, cReporteSBS, cAnexoSbs);

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
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveAnexo17D(dFechaProceso, cReporteSBS, cAnexoSbs);

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
        private DataSet DatoSucaveAnexo17D(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo17D = new clsRPTCNDeposito().CNSBSAnexo17AParteD(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo17D.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo17D.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo17C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo17C = new clsRPTCNDeposito().CNSBSAnexo17AParteC(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo17C.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo17C.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo17B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo17B = new clsRPTCNDeposito().CNSBSAnexo17AParteB(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo17B.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo17B.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveAnexo17A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo17A = new clsRPTCNDeposito().CNSBSAnexo17AParteA(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo17A.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo17A.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private void Anexo17A(DateTime dFecha, string cReporteSBS, string cAnexo)
        {
            // Validación
            if (dFecha != dFecha.AddDays((dFecha.Day - 1) * -1).AddMonths(1).AddDays(-1))
            {
                dtpFechaProceso.Focus();
                MessageBox.Show("Elegir último día del Mes", "Anexo 17A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtFSD = cnDatoGenericos.CNRetornaValorFSD(dFecha);

            DataSet dsAnexo17A = new clsRPTCNDeposito().CNSBSAnexo17AParteA(dFecha, cReporteSBS, cAnexo);
            DataTable dtAnexo17A = dsAnexo17A.Tables[0];

            DataSet dsAnexo17G = new clsRPTCNDeposito().CNSBSAnexo17_G(dFecha, cReporteSBS, "01");
            DataTable dtAnexo17G = dsAnexo17G.Tables[0];

            DataSet dsAnexo17B = new clsRPTCNDeposito().CNSBSAnexo17AParteB(dFecha, cReporteSBS, "03");
            DataTable dtAnexo17B = dsAnexo17B.Tables[0];

            DataSet dsAnexo17C = new clsRPTCNDeposito().CNSBSAnexo17AParteC(dFecha, cReporteSBS, "04");
            DataTable dtAnexo17C = dsAnexo17C.Tables[0];

            DataSet dsAnexo17D = new clsRPTCNDeposito().CNSBSAnexo17AParteD(dFecha, cReporteSBS, "05");
            DataTable dtAnexo17D = dsAnexo17D.Tables[0];

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Clear();

            paramList.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramList.Add(new ReportParameter("x_cFSD", dtFSD.Rows[0]["nMaxCoberFSD"].ToString(), false));

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Clear();

            dtsList.Add(new ReportDataSource("dtsAnexo17A", dtAnexo17A));
            dtsList.Add(new ReportDataSource("dtsAnexo17G", dtAnexo17G));
            dtsList.Add(new ReportDataSource("dtsAnexo17B", dtAnexo17B));
            dtsList.Add(new ReportDataSource("dtsAnexo17C", dtAnexo17C));
            dtsList.Add(new ReportDataSource("dtsAnexo17D", dtAnexo17D));

            string reportPath = "RptAnexo17A.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
        private DataSet DatoSucaveAnexo17_G(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo17_G = new clsRPTCNDeposito().CNSBSAnexo17_G(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo17_G.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo17_G.Tables.Remove(T1);

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

        #region Eventos
        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFechaProceso.Value;
            if (dFecha != dFecha.AddDays((dFecha.Day - 1) * -1).AddMonths(1).AddDays(-1))
            {
                dtpFechaProceso.Focus();
                MessageBox.Show("Elegir último día del Mes", "Anexo 17A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cDelimitador = ",";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = this.InitialDirectory;
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.FileName = string.Format("FSD {0} - {1}.csv", this.dtpFechaProceso.Value.ToString("yyyy-MM"), DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                DataTable dtAfecciones = new clsRPTCNDeposito().CNAnexo17Afeciones(this.dtpFechaProceso.Value);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(@"Código" + cDelimitador + "Nombres / Rázon Social" + cDelimitador + "Documento" + cDelimitador + "Tipo Contraparte" + cDelimitador + "Tipo Cliente" + cDelimitador +
                    "Fines Lucro" + cDelimitador + "Persona" + cDelimitador + "Saldo Soles" + cDelimitador + "Int Soles" + cDelimitador + "Monto Cober" + cDelimitador + "Nro. Cuenta" + cDelimitador +
                    "Moneda" + cDelimitador + "Saldo Capital" + cDelimitador + "Int Deven" + cDelimitador + "Tipo Cuenta" + cDelimitador + "Tipo Deposito" + cDelimitador + "Bloqueo" + cDelimitador +
                    "Motivo Bloqueo" + cDelimitador + "Empleador" + cDelimitador + "Representante");

                foreach (DataRow row in dtAfecciones.Rows)
                {
                    string cCSV = "";
                    foreach (DataColumn column in dtAfecciones.Columns)
                    {
                        string cCampo = row[column].ToString();
                        if (cCampo.Contains(",") || cCampo.Contains("\""))
                        {
                            cCSV = cCSV + "\"" + cCampo.Replace("\"", "\"\"") + "\"" + cDelimitador;
                        }
                        else
                        {
                            cCSV = cCSV + cCampo + cDelimitador;
                        }
                    }
                    sb.AppendLine(cCSV.Substring(0, cCSV.Length - 1));
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
            }
        }
        #endregion
    }
}

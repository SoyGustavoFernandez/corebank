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
    public partial class frmReporte5 : frmBase
    {
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        clsRPTCNContabilidad cnDatos = new clsRPTCNContabilidad();
        public frmReporte5()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void frmReporte5_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            string cCodigoSBS = "0205";
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
        private DataSet DatoSucaveReporte501(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataSet dsReporte5 = new clsRPTCNCredito().CNReporte5(dFecProceso, cCodSBS, cAnexo);
            DataTable T1 = dsReporte5.Tables[1];
            T1.TableName = "Tab101";
            dsReporte5.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }
        private DataSet DatoSucaveReporte502(DateTime dFecProceso, string cCodSBS, string cAnexo)
        {
            DataTable dtReporte502 = new clsRPTCNCredito().CNReporte502(dFecProceso, cCodSBS, cAnexo);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { dtReporte502 });
            return dsAnexos;
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
                        Reporte501(dFechaProceso, cReporteSBS, cAnexoSbs);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte501(dFechaProceso, cReporteSBS, cAnexoSbs);
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
                        MessageBox.Show("Reporte no aplica el formato", "Anexo SBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (lSucave)
                    {
                        DataSet dsAnexos = DatoSucaveReporte502(dFechaProceso, cReporteSBS, cAnexoSbs);
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
                    pcCadena = (Convert.ToInt16((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') +dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }
        private void Reporte501(DateTime dFecProceso, string cCodSBS, string cCodAnexo)
        {
            DataSet dsReporte5 = new clsRPTCNCredito().CNReporte5(dFecProceso, cCodSBS, cCodAnexo);
            DataTable dtReporte5 = dsReporte5.Tables[0];
            if (dtReporte5.Rows.Count == 0)
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte 5", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte5", dtReporte5));

                string reportpath = "RptSBSReporte5.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

    }
}

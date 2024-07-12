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
using Excel = Microsoft.Office.Interop.Excel;
using GEN.CapaNegocio;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmAnexo09 : frmBase
    {
        private DataTable tmpdtImpDatBco = new DataTable();
        string cReporteSBS = "0109", cAnexoSbs = "03";
        public frmAnexo09()
        {
            InitializeComponent();
        }

        private void frmAnexo09_Load(object sender, EventArgs e)
        {
            tmpdtImpDatBco.Columns.Add("dFecha", typeof(DateTime));
            tmpdtImpDatBco.Columns.Add("nTipoCambio", typeof(Decimal));
            DataTable dtTipoCambio = new clsRPTCNReporte().CNExtraeFechaTipoCambioCNT();
            if (dtTipoCambio.Rows.Count>0)
            {
                txtUltFec.Text =Convert.ToDateTime(dtTipoCambio.Rows[0]["dFecTipCambio"]).ToString("dd/MM/yyyy");
            }
            else
            {
                txtUltFec.Text = "";
            } 
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFecha.Value.Date;

            DataSet dsAnexo09 = new clsRPTCNCredito().CNAnexo9(dFecProceso, cReporteSBS, cAnexoSbs);
            DataTable dtAnexo9 = dsAnexo09.Tables[0];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));
            paramlist.Add(new ReportParameter("x_cCodEmp", clsVarApl.dicVarGen["cCodInst"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsAnexo9", dtAnexo9));

            string reportpath = "RptSBSAnexo9.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void LLenarGrid(string archivo)
        {
            Cursor = Cursors.WaitCursor;

            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook oWorkBook = oExcel.Workbooks.Open(archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            string cFecha;
            decimal nTipoCambio;

            int i = 2;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                cFecha = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value);
                nTipoCambio = Convert.ToDecimal((oWorkSheet.Cells[i, 2] as Excel.Range).Value);
                if (string.IsNullOrEmpty(cFecha))
                {
                    lIndValCelda = false;
                }
                else
                {
                    tmpdtImpDatBco.Rows.Add(Convert.ToDateTime(cFecha), nTipoCambio);
                }
                i = i + 1;
            }

            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);

            dtgSeriesTC.DataSource = tmpdtImpDatBco; //le asignamos al DataGridView el contenido del dataSet
            btnImportar1.Enabled = true;

            Cursor = Cursors.Default;

        }
        private void liberarObjecto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
                int id = GetIDProcces("EXCEL");
                if (id != -1)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(id).Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        private int GetIDProcces(string nameProcces)
        {
            try
            {
                System.Diagnostics.Process[] asProccess = System.Diagnostics.Process.GetProcessesByName(nameProcces);

                foreach (System.Diagnostics.Process pProccess in asProccess)
                {
                    if (pProccess.MainWindowTitle == "")
                    {
                        return pProccess.Id;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private void btnExporExcel1_Click_1(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtArchivo.Text = dialog.FileName;
                LLenarGrid(txtArchivo.Text); //se manda a llamar al metodo
                dtgSeriesTC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
            }
            btnImportar1.Enabled = true;
        }

        private void btnImportar1_Click(object sender, EventArgs e)
        {
            DataSet dsDetalle = new DataSet(); // creamos la instancia del objeto DataSet
            dsDetalle.Tables.Add(tmpdtImpDatBco);
            string XmlDetalle = "";
            XmlDetalle = dsDetalle.GetXml();
            XmlDetalle = clsCNFormatoXML.EncodingXML(XmlDetalle);
            DataTable dtResultado = new clsRPTCNReporte().CNInsMuestraAnexo9(XmlDetalle);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"])==1)
            {
                MessageBox.Show("Datos almacenados correctamente", "Historico tipos de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtUltFec.Text = Convert.ToDateTime(dtResultado.Rows[0]["dFecTipCambio"]).ToString("dd/MM/yyyy");
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFecha.Value.Date;
            DataSet dsAnexos = DatoSucaveAnexo9(dFecProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFecProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFecProceso, 4))
            {
                CierreArchivo(Archivo, cNomArc);
            }

        }
        private DataSet DatoSucaveAnexo9(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexo9 = new clsRPTCNCredito().CNAnexo9(dFecha, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsAnexo9.Tables[1];
            T1.TableName = "Tab101";
            dsAnexo9.Tables.Remove(T1);
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
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }

    }
}

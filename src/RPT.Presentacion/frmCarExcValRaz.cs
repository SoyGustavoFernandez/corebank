using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RPT.Presentacion
{
    public partial class frmCarExcValRaz : frmBase
    {
        private DataTable tmpdtImpDatAn = new DataTable();
        private DataTable tmpdtImpDatTes = new DataTable();
        public frmCarExcValRaz()
        {
            InitializeComponent();
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            //Creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtArchivo.Text = dialog.FileName;
                LLenarGrid(txtArchivo.Text); //se manda a llamar al metodo
                dtgDatoExl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //se ajustan las
            }
        }
        private void LLenarGrid(string archivo)
        {
            if (tmpdtImpDatAn.Rows.Count>0)
            {
                tmpdtImpDatAn.Clear();
            }
            Cursor = Cursors.WaitCursor;

            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook oWorkBook = oExcel.Workbooks.Open(archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            string Nemonico, ISINIdentif, Emisor, Moneda, Origen, RatingEmision;
            DateTime FEmision, FVencimiento, UltCupon, ProxCupon;
            float PorPLimpio, TIR, Spreads, PLimpio, PSucio, IC, Cupon, MargenLibor, TIRSOpc, Duracion, VarPLimpio, VarPSucio, VarTir; 

            int i = 3;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                Nemonico = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value);
                if (string.IsNullOrEmpty(Nemonico))
                {
                    lIndValCelda = false;
                }
                else
                {
                    Nemonico = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value);
                    ISINIdentif = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value);
                    Emisor = Convert.ToString((oWorkSheet.Cells[i, 3] as Excel.Range).Value);
                    Moneda = Convert.ToString((oWorkSheet.Cells[i, 4] as Excel.Range).Value);
                    PorPLimpio = (float)Convert.ToDouble((oWorkSheet.Cells[i, 5] as Excel.Range).Value);
                    TIR = (float)Convert.ToDouble((oWorkSheet.Cells[i, 6] as Excel.Range).Value);
                    Origen = Convert.ToString((oWorkSheet.Cells[i, 7] as Excel.Range).Value);
                    Spreads = (float)Convert.ToDouble((oWorkSheet.Cells[i, 8] as Excel.Range).Value);
                    PLimpio = (float)Convert.ToDouble((oWorkSheet.Cells[i, 9] as Excel.Range).Value);
                    PSucio = (float)Convert.ToDouble((oWorkSheet.Cells[i, 10] as Excel.Range).Value);
                    IC = (float)Convert.ToDouble((oWorkSheet.Cells[i, 11] as Excel.Range).Value);
                    FEmision = Convert.ToDateTime((oWorkSheet.Cells[i, 12] as Excel.Range).Value);
                    FVencimiento = Convert.ToDateTime((oWorkSheet.Cells[i, 13] as Excel.Range).Value == null ? null : (oWorkSheet.Cells[i, 13] as Excel.Range).Value);
                    Cupon = (float)Convert.ToDouble((oWorkSheet.Cells[i, 14] as Excel.Range).Value);
                    MargenLibor = (float)Convert.ToDouble((oWorkSheet.Cells[i, 15] as Excel.Range).Value);
                    TIRSOpc = (float)Convert.ToDouble((oWorkSheet.Cells[i, 16] as Excel.Range).Value);
                    RatingEmision = Convert.ToString((oWorkSheet.Cells[i, 17] as Excel.Range).Value);
                    UltCupon = Convert.ToDateTime((oWorkSheet.Cells[i, 18] as Excel.Range).Value);
                    ProxCupon = Convert.ToDateTime((oWorkSheet.Cells[i, 19] as Excel.Range).Value);
                    Duracion = (float)Convert.ToDouble((oWorkSheet.Cells[i, 20] as Excel.Range).Value);
                    VarPLimpio = (float)Convert.ToDouble((oWorkSheet.Cells[i, 21] as Excel.Range).Value);
                    VarPSucio = (float)Convert.ToDouble((oWorkSheet.Cells[i, 22] as Excel.Range).Value);
                    VarTir = (float)Convert.ToDouble((oWorkSheet.Cells[i, 23] as Excel.Range).Value);

                    tmpdtImpDatAn.Rows.Add(Nemonico,ISINIdentif,Emisor,Moneda,PorPLimpio,TIR,Origen,Spreads,PLimpio
                        ,PSucio,IC,FEmision,FVencimiento,Cupon,MargenLibor,TIRSOpc,RatingEmision
                        ,UltCupon,ProxCupon,Duracion,VarPLimpio,VarPSucio,VarTir);
                }
                i = i + 1;
            }

            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);
            dtgDatoExl.DataSource = tmpdtImpDatAn; //le asignamos al DataGridView el contenido del dataSet

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

        private void frmCargaExcel_Load(object sender, EventArgs e)
        {
            tmpdtImpDatAn.Columns.Add("Nemonico", typeof(string));
            tmpdtImpDatAn.Columns.Add("ISINIdentif", typeof(string));
            tmpdtImpDatAn.Columns.Add("Emisor", typeof(string));
            tmpdtImpDatAn.Columns.Add("Moneda", typeof(string));
            tmpdtImpDatAn.Columns.Add("PorPLimpio", typeof(float));
            tmpdtImpDatAn.Columns.Add("TIR", typeof(float));
            tmpdtImpDatAn.Columns.Add("Origen", typeof(string));
            tmpdtImpDatAn.Columns.Add("Spreads", typeof(float));
            tmpdtImpDatAn.Columns.Add("PLimpio", typeof(float));
            tmpdtImpDatAn.Columns.Add("PSucio", typeof(float));
            tmpdtImpDatAn.Columns.Add("IC", typeof(float));
            tmpdtImpDatAn.Columns.Add("FEmision", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("FVencimiento", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("Cupon", typeof(float));
            tmpdtImpDatAn.Columns.Add("MargenLibor", typeof(float));
            tmpdtImpDatAn.Columns.Add("TIRSOpc", typeof(float));
            tmpdtImpDatAn.Columns.Add("RatingEmision", typeof(string));
            tmpdtImpDatAn.Columns.Add("UltCupon", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("ProxCupon", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("Duracion", typeof(float));
            tmpdtImpDatAn.Columns.Add("VarPLimpio", typeof(float));
            tmpdtImpDatAn.Columns.Add("VarPSucio", typeof(float));
            tmpdtImpDatAn.Columns.Add("VarTir", typeof(float));

            tmpdtImpDatTes.Columns.Add("CodValor", typeof(string));
            tmpdtImpDatTes.Columns.Add("Clasificacion", typeof(string));
            tmpdtImpDatTes.Columns.Add("Tasa", typeof(float));
            tmpdtImpDatTes.Columns.Add("PRECIO", typeof(float));
            tmpdtImpDatTes.Columns.Add("PrecioPor", typeof(float));
            tmpdtImpDatTes.Columns.Add("VALORCD", typeof(float));
            tmpdtImpDatTes.Columns.Add("ValorActual", typeof(float));
            tmpdtImpDatTes.Columns.Add("INTERES", typeof(float));
            tmpdtImpDatTes.Columns.Add("COSTOAMORTIZADO", typeof(float));
            tmpdtImpDatTes.Columns.Add("FECHAINICIO", typeof(DateTime));
            tmpdtImpDatTes.Columns.Add("FECHAFINAL", typeof(DateTime));
            tmpdtImpDatTes.Columns.Add("FechaCalculo", typeof(DateTime));
            tmpdtImpDatTes.Columns.Add("interesCalculado", typeof(float));

            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImportar1_Click(object sender, EventArgs e)
        {
            if (tmpdtImpDatTes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos a cargar de tesoreria", "Inversiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImportar1.Enabled = true;
                return;
            }
            if (tmpdtImpDatAn.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos a cargar", "Inversiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImportar1.Enabled = true;
                return;
            }
            else
            {
                btnImportar1.Enabled = false;
            }
            DateTime dFecha = dtpFecProceso.Value.Date;
            DataSet dsDetalle = new DataSet(); // creamos la instancia del objeto DataSet
            dsDetalle.Tables.Add(tmpdtImpDatAn);
            string XmlDetalle = "";
            XmlDetalle = dsDetalle.GetXml();
            XmlDetalle = clsCNFormatoXML.EncodingXML(XmlDetalle);

            DataSet dsDetalleTes = new DataSet(); // creamos la instancia del objeto DataSet
            dsDetalleTes.Tables.Add(tmpdtImpDatTes);
            string XmlDetalleTes = "";
            XmlDetalleTes = dsDetalleTes.GetXml();
            XmlDetalleTes = clsCNFormatoXML.EncodingXML(XmlDetalleTes);

            DataTable dtResultado = new clsRPTCNReporte().ADInsDatInvValRaz(XmlDetalle, XmlDetalleTes, dFecha, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show("Datos almacenados correctamente", "Inversiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en carga de datos", "Inersiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExporExcel2_Click(object sender, EventArgs e)
        {
            //Creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog2 = new OpenFileDialog();
            dialog2.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog2.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog2.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            if (dialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtXlsTeso.Text = dialog2.FileName;
                LLenarGridTes(txtXlsTeso.Text); //se manda a llamar al metodo
                dtgDatoExlTes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //se ajustan las
            }
        }

        private void LLenarGridTes(string archivo)
        {
            if (tmpdtImpDatAn.Rows.Count > 0)
            {
                tmpdtImpDatTes.Clear();
            }
            Cursor = Cursors.WaitCursor;

            Excel.Application oExcelTes = new Excel.Application();
            Excel.Workbook oWorkBookTes = oExcelTes.Workbooks.Open(archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet oWorkSheetTes = (Excel.Worksheet)oWorkBookTes.Worksheets.get_Item(1);

            string CodValor, Clasificacion;
            DateTime FECHAINICIO, FECHAFINAL, FechaCalculo;
            float Tasa, PRECIO, PrecioPor, VALORCD, ValorActual, INTERES, COSTOAMORTIZADO, interesCalculado;

            int i = 7;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                Clasificacion = Convert.ToString((oWorkSheetTes.Cells[i, 1] as Excel.Range).Value);
                if (string.IsNullOrEmpty(Clasificacion))
                {
                    lIndValCelda = false;
                }
                else
                {
                    CodValor = Convert.ToString((oWorkSheetTes.Cells[i, 1] as Excel.Range).Value);
                    Clasificacion = Convert.ToString((oWorkSheetTes.Cells[i, 2] as Excel.Range).Value);
                    Tasa = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 3] as Excel.Range).Value);
                    PRECIO = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 4] as Excel.Range).Value);
                    PrecioPor = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 5] as Excel.Range).Value);
                    VALORCD = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 6] as Excel.Range).Value);
                    ValorActual = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 7] as Excel.Range).Value);
                    INTERES = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 8] as Excel.Range).Value);
                    COSTOAMORTIZADO = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 9] as Excel.Range).Value);
                    FECHAINICIO = Convert.ToDateTime((oWorkSheetTes.Cells[i, 10] as Excel.Range).Value);
                    FECHAFINAL = Convert.ToDateTime((oWorkSheetTes.Cells[i, 11] as Excel.Range).Value);
                    FechaCalculo = Convert.ToDateTime((oWorkSheetTes.Cells[i, 12] as Excel.Range).Value);
                    interesCalculado = (float)Convert.ToDouble((oWorkSheetTes.Cells[i, 13] as Excel.Range).Value);

                    tmpdtImpDatTes.Rows.Add(CodValor, Clasificacion, Tasa, PRECIO, PrecioPor, VALORCD,
                        ValorActual, INTERES, COSTOAMORTIZADO, FECHAINICIO, FECHAFINAL, FechaCalculo,
                        interesCalculado);
                }
                i = i + 1;
            }

            oWorkBookTes.Close(true, null, null);
            oExcelTes.Quit();
            liberarObjecto(oWorkSheetTes);
            liberarObjecto(oWorkBookTes);
            liberarObjecto(oExcelTes);
            dtgDatoExlTes.DataSource = tmpdtImpDatTes; //le asignamos al DataGridView el contenido del dataSet

            Cursor = Cursors.Default;
        }
    }
}

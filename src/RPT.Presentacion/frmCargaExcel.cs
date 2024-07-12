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
    public partial class frmCargaExcel : frmBase
    {
        private DataTable tmpdtImpDatAn = new DataTable();
        public frmCargaExcel()
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

            string cCtaCtb, cTipIns, cEmisor, cClaRie, cEmpCla;
            DateTime dFecNeg,dFecLiq;
            decimal nCosTot; 

            int i = 3;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                cCtaCtb = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value);
                if (string.IsNullOrEmpty(cCtaCtb))
                {
                    lIndValCelda = false;
                }
                else
                {
                    cCtaCtb = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value);
                    cTipIns = Convert.ToString((oWorkSheet.Cells[i, 3] as Excel.Range).Value);
                    cEmisor = Convert.ToString((oWorkSheet.Cells[i, 4] as Excel.Range).Value);
                    dFecNeg = Convert.ToDateTime((oWorkSheet.Cells[i, 5] as Excel.Range).Value);
                    dFecLiq = Convert.ToDateTime((oWorkSheet.Cells[i, 6] as Excel.Range).Value);
                    nCosTot = Convert.ToDecimal((oWorkSheet.Cells[i, 7] as Excel.Range).Value);
                    cClaRie = Convert.ToString((oWorkSheet.Cells[i, 8] as Excel.Range).Value);
                    cEmpCla = Convert.ToString((oWorkSheet.Cells[i, 9] as Excel.Range).Value);

                    tmpdtImpDatAn.Rows.Add(cCtaCtb, cTipIns, cEmisor, dFecNeg, dFecLiq, nCosTot, cClaRie, cEmpCla);
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
            tmpdtImpDatAn.Columns.Add("cCtaCtb", typeof(string));
            tmpdtImpDatAn.Columns.Add("cTipIns", typeof(string));
            tmpdtImpDatAn.Columns.Add("cEmisor", typeof(string));
            tmpdtImpDatAn.Columns.Add("dFecNeg", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("dFecLiq", typeof(DateTime));
            tmpdtImpDatAn.Columns.Add("nCosTot", typeof(decimal));
            tmpdtImpDatAn.Columns.Add("cClaRie", typeof(string));
            tmpdtImpDatAn.Columns.Add("cEmpCla", typeof(string));

            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImportar1_Click(object sender, EventArgs e)
        {
            if (tmpdtImpDatAn.Rows.Count==0)
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

            DataTable dtResultado = new clsRPTCNReporte().CNInsDatosInversion(XmlDetalle, dFecha, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show("Datos almacenados correctamente", "Inversiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en carga de datos", "Inersiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

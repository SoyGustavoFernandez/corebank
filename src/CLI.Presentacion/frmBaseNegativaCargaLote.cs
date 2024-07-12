using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace CLI.Presentacion
{
    public partial class frmBaseNegativaCargaLote : frmBase
    {
        clsCNBaseNegativaClientes objBaseNegativa = new clsCNBaseNegativaClientes();
        DataTable dtDatosBaseNegativa = new DataTable();        
        Excel.Application oExcel = null;
        Excel.Workbook oWorkBook = null;
        Excel.Worksheet oWorkSheet = null;
        string ruta="";
        int idUsuario=clsVarGlobal.User.idUsuario;
        string xmlLisCtasAho="";
        
        public frmBaseNegativaCargaLote()
        {
            InitializeComponent();
            iniciarlizaDgvBaseNegativa();
        }

        private void frmBaseNegativaCargaLote_Load(object sender, EventArgs e)
        {

        }

        private void iniciarlizaDgvBaseNegativa()
        {
            dtDatosBaseNegativa.Columns.Add("cModulo", typeof(string));            
            dtDatosBaseNegativa.Columns.Add("cTipoPersona", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cTipoDocumento", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cNroDoc", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cRazonSocial", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cNombres", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cPaterno", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cMaterno", typeof(string));
            dtDatosBaseNegativa.Columns.Add("dMotivo", typeof(int));
            dtDatosBaseNegativa.Columns.Add("cDescripcion", typeof(string));
            dtDatosBaseNegativa.Columns.Add("lVigente", typeof(string));
            dtDatosBaseNegativa.Columns.Add("cObservacion", typeof(string));
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            DataTable dtBaseNegativa = (DataTable)dtgClientesBaseNegativa.DataSource;

            DataSet dsLisCtasAho = new DataSet("dsLisPerBN");
            dsLisCtasAho.Tables.Add(dtBaseNegativa);
            this.xmlLisCtasAho = dsLisCtasAho.GetXml();
            this.xmlLisCtasAho = clsCNFormatoXML.EncodingXML(xmlLisCtasAho);
            
            DataTable dtInsertarBaseNegativa = objBaseNegativa.CNRegPersonaBaseNegativa(idUsuario,clsVarGlobal.dFecSystem, xmlLisCtasAho);
            if (Convert.ToInt32(dtInsertarBaseNegativa.Rows[0]["idRpta"]) == 0)
            {
                MessageBox.Show(Convert.ToString(dtInsertarBaseNegativa.Rows[0]["cMensage"]), "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtInsertarBaseNegativa.Rows[0]["cMensage"]), "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dsLisCtasAho.Tables.Clear();
            dsLisCtasAho.Dispose();

            btnProcesar.Enabled = false;
            btnImportar.Enabled = false;
            btnCancelar.Enabled = true;                    
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadDialogo = new OpenFileDialog();

            this.txtUbicacion.Text = "";            

            var result = loadDialogo.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (loadDialogo.SafeFileName != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", "Base Negativa Carga por Lote", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ruta = loadDialogo.FileName;
                        this.txtUbicacion.Text = ruta;
                        this.CargarArchivo(ref oExcel, ref oWorkBook, ref oWorkSheet);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        txtUbicacion.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó una direccion correcta", "Base Negativa Carga por Lote", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                dtDatosBaseNegativa.Clear();
                if (dtgClientesBaseNegativa.Rows.Count>0)
                {
                    dtgClientesBaseNegativa.Rows.Clear();
                    dtgBNError.Rows.Clear();
                }
                return;
            }

            dtDatosBaseNegativa.Clear();            
         
        }

        private void habilitarControles(bool lHabilitar)
        {
            this.dtgClientesBaseNegativa.Enabled = lHabilitar;
            this.btnProcesar.Enabled = lHabilitar;
            this.btnImportar.Enabled = lHabilitar;
            this.btnSalir.Enabled = lHabilitar;            
        }

        private void CargarArchivo(ref Excel.Application oExcel, ref Excel.Workbook oWorkBook, ref Excel.Worksheet oWorkSheet)
        {
            oExcel = new Excel.Application();
            oWorkBook = oExcel.Workbooks.Open(ruta, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            int i = 5;            

            string cModulo;            
            string cTipoPersona;
            string cTipoDocumento;
            string cNroDoc;
            string cRazonSocial;
            string cNombres;
            string cPaterno;
            string cMaterno;
            int dMotivo;
            string cDescripcion;
            string cVigente;

            bool lIndValCelda = true;            

            while (lIndValCelda)
            {
                cModulo = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value2);                
                cTipoPersona = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value2);
                cTipoDocumento = Convert.ToString((oWorkSheet.Cells[i, 3] as Excel.Range).Value2);
                cNroDoc = Convert.ToString((oWorkSheet.Cells[i, 4] as Excel.Range).Value2);
                cRazonSocial = Convert.ToString((oWorkSheet.Cells[i, 5] as Excel.Range).Value2);
                cNombres = Convert.ToString((oWorkSheet.Cells[i, 6] as Excel.Range).Value2);
                cPaterno = Convert.ToString((oWorkSheet.Cells[i, 7] as Excel.Range).Value2);
                cMaterno = Convert.ToString((oWorkSheet.Cells[i, 8] as Excel.Range).Value2);
                dMotivo = Convert.ToInt32((oWorkSheet.Cells[i, 9] as Excel.Range).Value2);
                cDescripcion = Convert.ToString((oWorkSheet.Cells[i, 10] as Excel.Range).Value2);
                cVigente = Convert.ToString((oWorkSheet.Cells[i, 11] as Excel.Range).Value2);

                if (cModulo != null)
                {
                    dtDatosBaseNegativa.Rows.Add(cModulo, cTipoPersona, cTipoDocumento, cNroDoc, cRazonSocial, cNombres, cPaterno, cMaterno, dMotivo, cDescripcion, cVigente);
                }
                else
                {
                    lIndValCelda = false;
                }
                
                i = i + 1;
            }

            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);

            ValidarRegistros();      
        }

        private void ValidarRegistros()
        {
            //--====================================================
            //--Validamos Registros Duplicados (Docs Duplicados)
            //--====================================================
            string x_cNroDoc = "";
            int nDuplicado = 0;
            for (int i = 0; i < dtDatosBaseNegativa.Rows.Count; i++)
            {
                nDuplicado = 0;
                x_cNroDoc = dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString();
                if (string.IsNullOrEmpty(x_cNroDoc))
                {
                    continue;
                }
                for (int J = 0; J < dtDatosBaseNegativa.Rows.Count-i; J++)
                {
                    if (i != J)
                    {
                        if (string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[J]["cNroDoc"].ToString()))
                        {
                            continue;
                        }
                        if (dtDatosBaseNegativa.Rows[J]["cNroDoc"].ToString().Trim() == x_cNroDoc.Trim())
                        {
                            nDuplicado = nDuplicado + 1;
                        }
                        if (nDuplicado > 1)
                        {
                            break;
                        }
                    }
                }
                if (nDuplicado > 1)
                {
                    break;
                }
            }

            if (nDuplicado>1)
            {
                MessageBox.Show("Existen Números de documentos duplicados, por Favor Revisar...", "Validar Datos Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //--====================================================
            //--Validamos los Registros
            //--====================================================
            DataTable dtCliBNok = dtDatosBaseNegativa.Clone();
            DataTable dtCliBNError = dtDatosBaseNegativa.Clone();
            for (int i = 0; i < dtDatosBaseNegativa.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cTipoPersona"].ToString()) || string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cTipoDocumento"].ToString()) ||
                    string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString()) || string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["dMotivo"].ToString()) ||
                    string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cModulo"].ToString()))
                {
                    dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Datos Incompletos";
                    dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                    
                    continue;
                }
                else 
                {
                    switch (dtDatosBaseNegativa.Rows[i]["cTipoDocumento"].ToString())
	                {
                        case "1": //--DNI
                            if (dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString().Trim().Length!=8)
	                        {
                                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Longitud del DNI no Valido";
		                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                                
                                continue;
	                        }
                            if (string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cNombres"].ToString().Trim()))
                            {
                                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "El Nombre esta vacio";
                                dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                                
                                continue;
                            }
                            break;
                        case "4": //--RUC
                            if (dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString().Length != 11)
                            {
                                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Longitud del RUC no Valido";
                                dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                                
                                continue;
                            }
                            if (string.IsNullOrEmpty(dtDatosBaseNegativa.Rows[i]["cRazonSocial"].ToString().Trim()))
                            {
                                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Razón Social esta vacio";
                                dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                                
                                continue;
                            }
                            break;
                        case "11": //--DNI MENOR
                            if (dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString().Length != 8)
                            {
                                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Longitud del DNI no Valido";
                                dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                                
                                continue;
                            }
                            break;
		                default:
                            break;
	                }

                    //-------------------------------------------------------------------
                    //---Validamos los Tipos de datos
                    //-------------------------------------------------------------------
                    long r = 0; //--Valida si tipo de datos numerico
                    if (!long.TryParse(dtDatosBaseNegativa.Rows[i]["cModulo"].ToString().Trim(), out r))
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Tipo dato No Valido Modulo";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                    if (!long.TryParse(dtDatosBaseNegativa.Rows[i]["cNroDoc"].ToString().Trim(), out r))
	                {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Tipo dato No Valido Documento";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
	                }
                    if (!long.TryParse(dtDatosBaseNegativa.Rows[i]["cTipoPersona"].ToString().Trim(), out r))
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Tipo dato No Valido TipoPersona";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                    if (Convert.ToInt64(dtDatosBaseNegativa.Rows[i]["cTipoPersona"]) == 0 || Convert.ToInt64(dtDatosBaseNegativa.Rows[i]["cTipoPersona"])>3)
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "ID No Valido";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                    if (!long.TryParse(dtDatosBaseNegativa.Rows[i]["cTipoDocumento"].ToString().Trim(), out r))
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Tipo dato No Valido Tipo Documento";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                    if (Convert.ToInt64(dtDatosBaseNegativa.Rows[i]["cTipoDocumento"]) == 0 || Convert.ToInt64(dtDatosBaseNegativa.Rows[i]["cTipoDocumento"]) > 14)
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "ID No Valido";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                    if (!long.TryParse(dtDatosBaseNegativa.Rows[i]["dMotivo"].ToString().Trim(), out r))
                    {
                        dtDatosBaseNegativa.Rows[i]["cObservacion"] = "Tipo dato No Valido dMotivo";
                        dtCliBNError.ImportRow(dtDatosBaseNegativa.Rows[i]);                        
                        continue;
                    }
                     
                }
                dtDatosBaseNegativa.Rows[i]["cObservacion"] = "OK";
                dtCliBNok.ImportRow(dtDatosBaseNegativa.Rows[i]);                
            }
            dtgBNError.ForeColor = Color.Red;
            dtgClientesBaseNegativa.DataSource = dtCliBNok;
            dtgClientesBaseNegativa.Refresh();
            dtgBNError.DataSource = dtCliBNError;
            dtgBNError.Refresh();

            if (dtCliBNok.Rows.Count>0)
            {
                btnImportar.Enabled = false;
                btnProcesar.Enabled = true;
                btnCancelar.Enabled = true;
                btnProcesar.Focus();
            }
            else
            {
                btnImportar.Enabled = false;
                btnProcesar.Enabled = false;
                btnCancelar.Enabled = true;
                btnCancelar.Focus();
            }                      
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtDatosBaseNegativa.Clear();             
            DataTable dtbn = (DataTable)dtgClientesBaseNegativa.DataSource;
            DataTable dtError = (DataTable)dtgBNError.DataSource;
            dtbn.Clear();
            dtError.Clear();
            txtUbicacion.Clear();
            btnProcesar.Enabled = false;
            btnImportar.Enabled = true;
            btnCancelar.Enabled = false;
            btnImportar.Focus();
        }
    }
}

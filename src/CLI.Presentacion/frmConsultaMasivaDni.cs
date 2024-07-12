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
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.BotonesBase;
using Microsoft.Reporting.WinForms;
using System.IO;
using WCF.Reniec;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections;
using CLI.Servicio;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Serialization;
using GEN.Funciones;
using CLI.CapaNegocio;
using System.Text.RegularExpressions;

namespace CLI.Presentacion
{
    public partial class frmConsultaMasivaDni : frmBase
    {

        #region Variables Globales
        
        clsProcesaDatosRen objCliente;
        string cDireccionRuta = "";
        string cTituloMsje = "Consulta Masiva Reniec";
        int nLote = 0;
        clsCNConsultaDatos ConsultaDatos = new clsCNConsultaDatos();
        DateTime dFechaSistema = Convert.ToDateTime(clsVarGlobal.dFecSystem);

        #endregion
        
        #region Eventos
        public frmConsultaMasivaDni()
        {
            InitializeComponent();
            HabilitarBtns(false);
            rbtBase1.Checked = true;
            datePicker2.Value = dFechaSistema;
        }

        private void btnImportar1_Click(object sender, EventArgs e)
        {
            string cMuestra = "";
            cMuestra = cMuestra + "_____________\n";
            cMuestra = cMuestra + "__|____A_____|\n";
            cMuestra = cMuestra + "1_|___DNI____|\n";
            cMuestra = cMuestra + "2_| 87654321 |\n";
            cMuestra = cMuestra + "3_| 12345678 |\n";
            cMuestra = cMuestra + "4_| 12345679 |\n";

            MessageBox.Show("Para la consulta masiva se debe de seleccionar un archivo Excel del tipo *.xls ó *.xlsx.\nSolo en la columna A se debe de ingresar todos los números de DNI que se consultarán, sin filas en blanco intermedias, como se muestra en el ejemplo.\n"+cMuestra, cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Office Files|*.xls;*.xlsx";
            objOpenFileDialog.InitialDirectory = @"C:\";
            objOpenFileDialog.Title = "Selección del archivo con los números de DNI";

            DialogResult drResultado = objOpenFileDialog.ShowDialog();

            if (drResultado == DialogResult.OK)
            {
                if (objOpenFileDialog.SafeFileName != String.Empty)
                {
                    DialogResult drConsulta = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (drConsulta == DialogResult.Yes)
                    {
                        cDireccionRuta = objOpenFileDialog.FileName;
                        this.txtRutaArchivo.Text = cDireccionRuta;
                        CargarDatosEnDataGrid();
                        
                    }
                    else
                    {
                        txtRutaArchivo.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó un archivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * REGISTRO DE RASTREO - INICIO
            ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(clsVarGlobal.User.idCli), Convert.ToInt32(clsVarGlobal.User.idUsuario), "Inicio - Consulta Masiva Reniec", btnConsultar1);

            DataTable dtData = ConsultaDatos.CNRegistrarLote(cDireccionRuta);

            nLote = Convert.ToInt32(dtData.Rows[0]["idLote"].ToString());

            foreach (DataGridViewRow row in dtgBase1.Rows)
            {
                string cDni =  row.Cells["Documento"].Value.ToString();
                row.Cells[1].Value = GestionarConsultaReniec(cDni);
            }

            MessageBox.Show("Se ha terminado con la consulta masiva, a continuación se mostrará el reporte de consultas para este lote.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ImprimirReporte(1,nLote);

            while (MessageBox.Show("¿Desea volver a generar el reporte de consultas para este lote?", cTituloMsje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ImprimirReporte(1, nLote);
            }
                                              
            /*========================================================================================
            * REGISTRO DE RASTREO - FIN
            ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(clsVarGlobal.User.idCli), Convert.ToInt32(clsVarGlobal.User.idUsuario), "Fin - Consulta Masiva Reniec", btnConsultar1);

            btnConsultar1.Enabled = false;
            btnImprimir2.Enabled = true;

        }
              
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            HabilitarBtns(false);
            dtgBase1.DataSource = null;
            txtRutaArchivo.Text = "";
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(datePicker2.Value) > dFechaSistema)
            {
                MessageBox.Show("La fecha seleccionada es mayor a la de hoy.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            ImprimirReporte(2, 0);

        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            if (nLote > 0)
            {
                ImprimirReporte(1, nLote);
            }
            else
                return;

        }


        #endregion
        
        #region Métodos
        private string GestionarConsultaReniec(string cDocumento)
        {
            if (cDocumento.Length != 8)
            {
                return "Dígitos de DNI diferente a 8";
            }
            
            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDocumento, clsVarGlobal.User.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
            
            clsReniec obj = new clsReniec(objParam, objReniec);
            
            objCliente = obj.GetReniec();
            DataTable dtData1 = ConsultaDatos.CNRegistrarLogMasivo(cDocumento, Convert.ToInt32(clsVarGlobal.User.idUsuario), nLote, Convert.ToString(objCliente.cErrorF.Trim()));
                                   
            string cDescEstado = dtData1.Rows[0]["cDescEstado"].ToString();

            return cDescEstado;
        }
        
        private void CargarDatosEnDataGrid()
        {
            
            dtgBase1.DataSource = ImportarExcelADataTable(cDireccionRuta);
            QuitarDuplicados();
            FormatearDataGrid();

            
            string cNumDnis = dtgBase1.RowCount.ToString();


            if (Convert.ToInt32(cNumDnis) > 0)
            {
                MessageBox.Show("Se ha importado correctamente, (" + cNumDnis + ") números de DNI, quitando los duplicados.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnImportar1.Enabled = false;
                btnConsultar1.Enabled = true;
            

            }
            else
            {
                MessageBox.Show("No se ha encontrado números de DNI en el documento.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);

                HabilitarBtns(false);
                dtgBase1.DataSource = null;
                txtRutaArchivo.Text = "";
            
            }

        }

        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgBase1.Columns["Documento"].DisplayIndex = 0;
            dtgBase1.Columns["Estado"].DisplayIndex = 1;

            dtgBase1.Columns["Documento"].Visible = true;
            dtgBase1.Columns["Estado"].Visible = true;


            dtgBase1.Columns["Documento"].HeaderText = "N° DNI";
            dtgBase1.Columns["Estado"].HeaderText = "Estado Consulta";

            dtgBase1.Columns["Documento"].FillWeight = 35;
            dtgBase1.Columns["Estado"].FillWeight = 100;
            
        }

        public DataTable ImportarExcelADataTable(String path)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
            
            int nIndice = 0;
            object objRowIndex = 2;

            DataTable dtExcelImportado = new DataTable();
            dtExcelImportado.Columns.Add("Documento");
            dtExcelImportado.Columns.Add("Estado");
            DataRow row;
            
            int nError = 0;
            string cError = "";
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[objRowIndex, 1]).Value2 != null)
            {

                    objRowIndex = 2 + nIndice;
                    row = dtExcelImportado.NewRow();
                    
                    string cFilaDato = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[objRowIndex, 1]).Value2);

                    if (ValidarDato(cFilaDato))
                    {
                        cFilaDato.Trim();
                        cFilaDato.Replace(" ", "");
                        cFilaDato = Regex.Replace(cFilaDato, @"\s", "");
                        row[0] = cFilaDato;

                        dtExcelImportado.Rows.Add(row);
                    }
                    else if ((!string.IsNullOrEmpty(cFilaDato) || !string.IsNullOrWhiteSpace(cFilaDato)) && cFilaDato.Length > 0)
                    {
                        string cFilaDato1 = cFilaDato + " \n";
                        cError = cError + cFilaDato1;
                        nError++;
                    
                    }
                    
                nIndice++;
                   
            }

            if (nError > 0)
            {
                MessageBox.Show("Se ha encontrado números de DNI incorrectos, que no se han tomado en cuenta para la importación: \n" + cError, cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            app.Workbooks.Close();
            app.Quit();
            LiberarObjeto(workSheet);
            LiberarObjeto(workBook);
            LiberarObjeto(app);

            return dtExcelImportado;
        }
        private void QuitarDuplicados()
        {
            DataView dv = new DataView((DataTable)dtgBase1.DataSource);
            dtgBase1.DataSource = dv.ToTable(true, "Documento", "Estado");

        }

        public bool ValidaNumero(object objExpresion)
        {

            bool lEsNum;

            double dRetNum;

            lEsNum = Double.TryParse(Convert.ToString(objExpresion), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out dRetNum);

            return lEsNum;

        }

        private bool ValidarDato(string cDato)
        {
            if (string.IsNullOrEmpty(cDato) || string.IsNullOrWhiteSpace(cDato))
            {
                return false;
            }
            
            cDato.Trim();
            cDato.Replace(" ", "");
            cDato = Regex.Replace(cDato, @"\s", "");

            if (ValidaNumero(cDato) == true && cDato.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }

        
        }

        private void LiberarObjeto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = nObtenerIdProceso("EXCEL");

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
        
        private int nObtenerIdProceso(string cNombreProceso)
        {
            try
            {
                System.Diagnostics.Process[] asProcess = System.Diagnostics.Process.GetProcessesByName(cNombreProceso);
                foreach (System.Diagnostics.Process pProcess in asProcess)
                {
                    if (pProcess.MainWindowTitle == "")
                        return pProcess.Id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        
        private void HabilitarBtns(bool lActiva)
        {
            if (tbcBase1.SelectedIndex == 0)
            {
                btnConsultar1.Enabled = lActiva;
                btnImprimir2.Enabled = lActiva;
                btnImportar1.Enabled = true;
            }

        }
        
        private void ImprimirReporte(int idTipoConsulta, int idLote)
        {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                DataTable dsConsultaMasivaRen = ConsultaDatos.CNReporteLogMasivo(idTipoConsulta, idLote, Convert.ToDateTime(datePicker2.Value));

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.cNomUsu, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", Convert.ToString(clsVarGlobal.dFecSystem), false));
                
                paramlist.Add(new ReportParameter("nTipoConsulta", Convert.ToString(idTipoConsulta), false));
                paramlist.Add(new ReportParameter("idLote", Convert.ToString(idLote), false));
                paramlist.Add(new ReportParameter("dFechaConsulta", Convert.ToString(datePicker2.Value), false));

                dtslist.Add(new ReportDataSource("dsConsultaMasivaRen", dsConsultaMasivaRen));

                string reportpath = "rptConsultaMasivaReniec.rdlc";
            
                if (rbtBase1.Checked)
                {
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else if (rbtBase2.Checked)
                {
                    frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel);
                    frmReporte.ShowDialog();
                }
        }

        #endregion
        
    }
}

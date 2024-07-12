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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CAJ.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;
using CRE.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmVincCredAdeudados : frmBase
    {

        #region Variables Globales

        private const string cTituloMsjes = "Vinculación de créditos con adeudados";
        private DataTable dtAdeudo_;
        private DataTable dtCredAdeudado;
        private int idAdeudado = 0;

        #endregion

        #region Eventos
        
        private void Form_Load(object sender, EventArgs e)
        {
            CargarCombosIniciales();
            LimpiarAdeudado();
            dtpHistorico.Enabled = false;
            dtpHistorico.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void cboTipCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipCred.SelectedValue != null && !(cboTipCred.SelectedValue is DataRowView))
            {
                cboSubTipCred.SelectedIndexChanged -= cboSubTipCred_SelectedIndexChanged;
                cboSubTipCred.CargarProducto(Convert.ToInt32(cboTipCred.SelectedValue), true);
                cboSubTipCred.SelectedIndexChanged += cboSubTipCred_SelectedIndexChanged;
            }
        }

        private void cboSubTipCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipCred.SelectedValue != null && !(cboSubTipCred.SelectedValue is DataRowView))
            {
                cboProducto.SelectedIndexChanged -= cboProducto_SelectedIndexChanged;
                cboProducto.CargarProducto(Convert.ToInt32(cboSubTipCred.SelectedValue), true);
                cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedValue != null && !(cboProducto.SelectedValue is DataRowView))
            {
                cboSubProducto.CargarProducto(Convert.ToInt32(cboProducto.SelectedValue), true);
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            cboTipCred.Enabled = !chcTodos.Checked;
            cboSubTipCred.Enabled = !chcTodos.Checked;
            cboProducto.Enabled = !chcTodos.Checked;
            cboSubProducto.Enabled = !chcTodos.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            chcVerCredVinc.Checked = true;
            frmBuscarAdeudado buscarAdeudado = new frmBuscarAdeudado();
            buscarAdeudado.ShowDialog();
            if (buscarAdeudado.dtExternoAdeudado != null)
            {
                dtAdeudo_ = buscarAdeudado.dtExternoAdeudado;
                
                AsignarDatosAdeudado();

                dtCredAdeudado = new clsCNVincCredAdeudado().CNGetCtasAdeudado(idAdeudado);
                dtCredAdeudado.Columns["lVincular"].ReadOnly = false;
                chcVerCredVinc.Checked = true;

                CalcularMontosAdeudado();
                btnGrabar.Enabled = true;
            }
            else
            {
                LimpiarAdeudado();
                btnGrabar.Enabled = false;
            }
        }

        private void btnExporExcel_Click(object sender, EventArgs e)
        {
            if (!ValidarExportar())
                return;

            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            int idProducto = chcTodos.Checked ? 0 : Convert.ToInt32(cboSubProducto.SelectedValue);
            int nAtrasoMin = Convert.ToInt32(nudAtrasoMin.Value);
            int nAtrasoMax = Convert.ToInt32(nudAtrasoMax.Value);

            GenerarArchivo(idProducto: idProducto,
                            idMoneda: idMoneda,
                            nAtrasoMin: nAtrasoMin,
                            nAtrasoMax: nAtrasoMax);         
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            chcVerCredVinc.Checked = false;
            ImportarData();
        }

        private void chcVerCredVinc_CheckedChanged(object sender, EventArgs e)
        {
            if (chcVerCredVinc.Checked && idAdeudado > 0)
            {
                dtgCreditos.DataSource = dtCredAdeudado;
                FormatoGrid();
            }
            else
            {
                dtgCreditos.DataSource = null;
            }
            CalcularTotalesGrid();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            btnGrabar.Enabled = false;
            int idAdeudado = Convert.ToInt32(txtCodigoAdeudo.Text);
            int lHistorico = chcHistorico.Checked? 1:0;
            DateTime dFechaHistorico = dtpHistorico.Value;

            DataSet dsCredAdeudado = new DataSet("dsCredAdeudado");

            DataTable dtCredAdeudo = (DataTable)dtgCreditos.DataSource;

            if (!chcVerCredVinc.Checked)
            {
                dtCredAdeudo = dtCredAdeudo.AsEnumerable().Where(x => Convert.ToBoolean(x["lVincular"])).CopyToDataTable();
            }

            dtCredAdeudo.TableName = "dtCredAdeudado";

            dsCredAdeudado.Tables.Add(dtCredAdeudo);

            string xmlCredAdeudado = dsCredAdeudado.GetXml();
            xmlCredAdeudado = clsCNFormatoXML.EncodingXML(xmlCredAdeudado);

            dsCredAdeudado.Tables.Clear();

            clsDBResp objDbResp = new clsCNVincCredAdeudado().CNVincularCredAdeudado(xmlCredAdeudado, idAdeudado, lHistorico, dFechaHistorico);
            if (objDbResp.nMsje == 0)
            {
                chcVerCredVinc.Checked = false;
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCredAdeudado = new clsCNVincCredAdeudado().CNGetCtasAdeudado(idAdeudado);
                dtCredAdeudado.Columns["lVincular"].ReadOnly = false;
                chcVerCredVinc.Checked = true;

                CalcularMontosAdeudado();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGrabar.Enabled = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarAdeudado();
            LimpiarControles();
            btnGrabar.Enabled = true;
        }

        #endregion

        #region Metodos

        public frmVincCredAdeudados()
        {
            InitializeComponent();
            txtCodigoAdeudo.Text = "0";

            cboMonFilter.MonedasYTodos();
            cboMonFilter.SelectedIndex = -1;

            cboTipCred.CargarProductoModNivel(1, 1);
            cboTipCred.SelectedIndex = -1;
        }

        private bool Validar()
        {
            if(String.IsNullOrEmpty(txtCodigoAdeudo.Text))
            {
                MessageBox.Show("Seleccione el adeudado al que se vinculará los créditos.", cTituloMsjes, 
                                                                                    MessageBoxButtons.OK, 
                                                                                    MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if(Convert.ToInt32(txtCodigoAdeudo.Text)<=0)
                {
                    MessageBox.Show("Seleccione el adeudado al que se vinculará los créditos.", cTituloMsjes, 
                                                                                    MessageBoxButtons.OK, 
                                                                                    MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (dtgCreditos.RowCount == 0)
            {
                MessageBox.Show("Debe importar los datos de las cuentas a vincular.", cTituloMsjes, 
                                                                                    MessageBoxButtons.OK, 
                                                                                    MessageBoxIcon.Warning);
                return false;
            }

            if (!chcVerCredVinc.Checked)
            {
                if (dtgCreditos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["lVincular"].Value)) == 0)
                {
                    MessageBox.Show("Seleccione por lo menos una cuenta a vincular.", cTituloMsjes,
                                                                                        MessageBoxButtons.OK,
                                                                                        MessageBoxIcon.Warning);
                    return false;
                }
            }

            decimal nMontoAsignado = String.IsNullOrEmpty(txtMontoAsignado.Text) ? 0 : Convert.ToDecimal(txtMontoAsignado.Text);
            decimal nMontoNoAsignado = String.IsNullOrEmpty(txtMontoNoAsignado.Text) ? 0 : Convert.ToDecimal(txtMontoNoAsignado.Text);
            decimal nSumSaldoCapital = String.IsNullOrEmpty(txtSumSaldoCapital.Text) ? 0 : Convert.ToDecimal(txtSumSaldoCapital.Text);
            decimal nSaldoAdeudado = String.IsNullOrEmpty(txtSaldoAdeudado.Text) ? 0 : Convert.ToDecimal(txtSaldoAdeudado.Text);

            if (nMontoAsignado > nSaldoAdeudado)
            {
                MessageBox.Show("Debe desvincular créditos del adeudado.\nSe superó el saldo del adedado.", cTituloMsjes, 
                                                                                            MessageBoxButtons.OK, 
                                                                                            MessageBoxIcon.Warning);
                return false;
            }

            //if (nSumSaldoCapital > nMontoNoAsignado)
            //{
            //    MessageBox.Show("La suma de saldo de los créditos seleccionados, supera el monto no asignado del adeudado.", cTituloMsjes,
            //                                                                                MessageBoxButtons.OK,
            //                                                                                MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }

        private void LimpiarControles()
        {
            cboTipCred.SelectedIndex = -1;
            cboSubTipCred.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            cboSubProducto.SelectedIndex = -1;

            chcTodos.Checked = false;

            cboMonFilter.SelectedIndex = -1;
            nudAtrasoMin.Value = 0;
            nudAtrasoMax.Value = 0;

            txtNroCreditos.Text = String.Empty;
            txtSumSaldoCapital.Text = String.Empty;

            dtgCreditos.DataSource = String.Empty;

            chcHistorico.Checked = false;
            dtpHistorico.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void FormatoGrid()
        {
            dtgCreditos.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgCreditos.Columns)
            {
                column.ReadOnly = true;
            }

            dtgCreditos.Columns["lVincular"].HeaderText = "Vincular";
            dtgCreditos.Columns["idCuenta"].HeaderText = "Cod. cuenta";
            dtgCreditos.Columns["nMontoDesembolsado"].HeaderText = "Monto desembolsado";
            dtgCreditos.Columns["nSaldoCapital"].HeaderText = "Saldo capital";

            dtgCreditos.Columns["nMontoDesembolsado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSaldoCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCreditos.Columns["nMontoDesembolsado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSaldoCapital"].DefaultCellStyle.Format = "#,0.00";

            dtgCreditos.Columns["lVincular"].ReadOnly = false;
        }

        private bool ValidarExportar()
        {
            if (cboMonFilter.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la moneda para realizar la generación del archivo.", cTituloMsjes, 
                                                                                                MessageBoxButtons.OK, 
                                                                                                MessageBoxIcon.Warning);
                return false;
            }

            if (!chcTodos.Checked)
            {
                if (cboSubProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el sub producto para realizar la generación del archivo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void AsignarDatosAdeudado()
        {
            if (dtAdeudo_.Rows.Count > 0)
            {
                DataRow drAdeudo = dtAdeudo_.AsEnumerable().First();
                idAdeudado = Convert.ToInt32(drAdeudo["idAdeudado"]);
                txtCodigoAdeudo.Text = Convert.ToString(drAdeudo["idAdeudado"]);
                //txtNroPagare.Text = Convert.ToString(drAdeudo["cNroPagre"]);
                cboTipoEntidad.cargarTipoDeEntidad("%");
                cboTipoEntidad.SelectedValue = Convert.ToInt32(drAdeudo["idTipoEntidad"]);
                cboEntidad.CargarEntidades(Convert.ToInt32(cboTipoEntidad.SelectedValue));
                cboEntidad.SelectedValue = Convert.ToInt32(drAdeudo["idEntidad"]);
                cboMoneda.SelectedValue = Convert.ToInt32(drAdeudo["idMoneda"]);
                cboEstado.SelectedValue = Convert.ToInt32(drAdeudo["idEstado"]);
                txtMontoFinanciado.Text = Convert.ToString(drAdeudo["nMonFinanciado"]);
                txtSaldoAdeudado.Text = Convert.ToString(drAdeudo["nSaldo"]);
            }
        }

        private void CargarCombosIniciales()
        {
            clsCNControlOpe Adeudo = new clsCNControlOpe();

            //cargando estado de adeudados
            DataTable dtListarEstadiAdeudo = Adeudo.listarEstadoAdeudado();
            cboEstado.ValueMember = "idEstado";
            cboEstado.DisplayMember = "cDescripcion";
            cboEstado.DataSource = dtListarEstadiAdeudo;
        }

        private void GenerarArchivo(int idProducto, int idMoneda, int nAtrasoMin, int nAtrasoMax)
        {
            Excel._Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Range range = null;
            Excel.Range rangeData = null;
            Excel.Range columns = null;

            try
            {
                pbCargando.Visible = true;
                btnExporExcel.Enabled = false;
                xlApp = new Excel.Application();

                xlApp.Visible = false;
                xlApp.ScreenUpdating = false;

                xlWorkBooks = xlApp.Workbooks;

                xlWorkBook = xlWorkBooks.Add();

                xlWorkSheet = (Excel.Worksheet)xlApp.ActiveSheet;

                DataTable dtData = new clsCNVincCredAdeudado().CNGetCtasPosiblesAdeudos(idProducto: idProducto,
                                                                                        idMoneda: idMoneda,
                                                                                        nAtrasoMin: nAtrasoMin,
                                                                                        nAtrasoMax: nAtrasoMax);


                //Convertimos el datatable en un array de dos dimensiones, con la data 
                object[,] arrayData = new object[dtData.Rows.Count + 1, dtData.Columns.Count];

                for (var column = 0; column < dtData.Columns.Count; column++)
                {
                    arrayData[0, column] = dtData.Columns[column].ColumnName;
                }

                for (var row = 0; row < dtData.Rows.Count; row++)
                {
                    for (var column = 0; column < dtData.Columns.Count; column++)
                    {
                        arrayData[row + 1, column] = dtData.Rows[row][column];
                    }
                }

                range = xlWorkSheet.Range["1:1"];
                rangeData = range.get_Resize(dtData.Rows.Count + 1, dtData.Columns.Count);
                rangeData.Value2 = arrayData;

                columns = rangeData.EntireColumn;
                columns.AutoFit();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.AddExtension = true;
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Archivos de excel (*.xls,*.xlsx)|*.xls;*.xlsx" /*|All Files(*.*)|*.*"*/;
                saveDialog.FilterIndex = 0;
                saveDialog.InitialDirectory = @"C:\";

                DialogResult result = saveDialog.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                xlWorkBook.SaveAs(Filename: saveDialog.FileName, FileFormat: Excel.XlFileFormat.xlWorkbookNormal, AccessMode: Excel.XlSaveAsAccessMode.xlExclusive);
                pbCargando.Visible = false;
                btnExporExcel.Enabled = true;
            }
            catch
            {

                MessageBox.Show("Se produjo un error al generar el archivo excel.", cTituloMsjes,
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Warning);
                pbCargando.Visible = false;
                btnExporExcel.Enabled = true;
            }
            finally
            {
                if (range != null)
                    releaseObject(range);

                if (rangeData != null)
                    releaseObject(rangeData);

                if (columns != null)
                    releaseObject(columns);

                if (xlWorkSheet != null)
                    releaseObject(xlWorkSheet);

                if (xlWorkBook != null)
                {
                    xlWorkBook.Close(false);
                    releaseObject(xlWorkBook);
                }

                if (xlWorkBooks != null)
                {
                    xlWorkBooks.Close();
                    releaseObject(xlWorkBooks);
                }

                if (xlApp != null)
                {
                    xlApp.Quit();
                    releaseObject(xlApp);
                }
            }
        }

        private void ImportarData()
        {
            Excel._Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Sheets xlWorkSheets = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Range range = null;
            

            DataTable dtData = null;

            string cPathFiles = clsVarApl.dicVarGen["cPathFilesAdeudados"];
            string cNomFileGuardado = String.Empty;

            object[,] arrayData = null;

            //Importación del archivo

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.AddExtension = true;
            openDialog.Multiselect = false;
            openDialog.Filter = "Archivos de excel (*.xls,*.xlsx)|*.xls;*.xlsx" /*|All Files(*.*)|*.*"*/;
            openDialog.FilterIndex = 0;
            openDialog.InitialDirectory = @"C:\";

            DialogResult result = openDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                chcVerCredVinc.Checked = true;
                return;
            }

            if (!System.IO.Directory.Exists(cPathFiles))
            {
                System.IO.Directory.CreateDirectory(cPathFiles);
            }

            string cExtFile = System.IO.Path.GetExtension(openDialog.FileName);

            cNomFileGuardado = String.Format("{0}_{1}_{2}{3}", clsVarGlobal.dFecSystem.ToString("yyyyMMdd"),
                                                        DateTime.Now.ToString("yyyyMMddhhmmss"),
                                                        clsVarGlobal.User.cWinUser,
                                                        cExtFile);


            System.IO.File.Copy(openDialog.FileName, String.Format("{0}{1}", cPathFiles, cNomFileGuardado));

            //Extracción de datos del archivo
            try
            {
                pbCargando.Visible = true;
                btnImportar.Enabled = false;

                xlApp = new Excel.Application();

                xlApp.Visible = false;
                xlApp.ScreenUpdating = false;

                xlWorkBooks = xlApp.Workbooks;

                xlWorkBook = xlWorkBooks.Open(Filename: String.Format("{0}{1}", cPathFiles, cNomFileGuardado));

                xlWorkSheets = xlApp.Worksheets;
                xlWorkSheet = xlWorkSheets[1];

                range = xlWorkSheet.UsedRange;

                arrayData = range.get_Value();
            }
            catch
            {

                MessageBox.Show("Se produjo un error al importar los datos del archivo excel.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                pbCargando.Visible = false;
                btnImportar.Enabled = true;
            }
            finally
            {
                if (range != null)
                    releaseObject(range);

                if (xlWorkSheet != null)
                    releaseObject(xlWorkSheet);

                if (xlWorkSheets != null)
                    releaseObject(xlWorkSheets);

                if (xlWorkBook != null)
                {
                    xlWorkBook.Close(false);
                    releaseObject(xlWorkBook);
                }

                if (xlWorkBooks != null)
                {
                    xlWorkBooks.Close();
                    releaseObject(xlWorkBooks);
                }

                if (xlApp != null)
                {
                    xlApp.Quit();
                    releaseObject(xlApp);
                }
            }

            DataTable dtTemp = new DataTable();
            dtData = new DataTable();

            //Creamos la estructura de las dos tablas
            for (int i = 1; i <= arrayData.GetLength(1); i++)
            {
                dtTemp.Columns.Add(Convert.ToString(arrayData[1, i]), typeof(string));
            }

            for (int i = 1; i <= arrayData.GetLength(1); i++)
            {
                if (i == 1)
                {
                    dtData.Columns.Add("lVincular", typeof(bool));
                    continue;
                }
                if (i == 2)
                {
                    dtData.Columns.Add("idCuenta", typeof(int));
                    continue;
                }
                if (i == 3)
                {
                    dtData.Columns.Add("nMontoDesembolsado", typeof(decimal));
                    continue;
                }
                if (i == 4)
                {
                    dtData.Columns.Add("nSaldoCapital", typeof(decimal));
                    continue;
                }
                dtData.Columns.Add(Convert.ToString(arrayData[1, i]), typeof(string));
            }

            //Pasamos la data a la tabla temporal
            for (int x = 2; x <= arrayData.GetLength(0); x++)
            {
                DataRow dr = dtTemp.NewRow();
                for (int y = 1; y <= arrayData.GetLength(1); y++)
                {
                    dr[y - 1] = arrayData[x, y];
                }
                dtTemp.Rows.Add(dr);
            }

            /*Fltrando valores que se vincularan*/
            var queryResult = dtTemp.AsEnumerable().Where(x => !String.IsNullOrEmpty(Convert.ToString(x[0]))
                                                    && !String.IsNullOrEmpty(Convert.ToString(x[1]))
                                                    && !String.IsNullOrEmpty(Convert.ToString(x[2]))
                                                    && !String.IsNullOrEmpty(Convert.ToString(x[3]))
                                                    && Convert.ToString(x[0]).Trim().Equals("1"));

            if (queryResult.Any())
            {
                dtTemp = queryResult.CopyToDataTable();
            }
            else
            {
                dtTemp.Clear();
            }

            foreach (DataRow dr in dtTemp.Rows)
            {
                dr[0] = true;
            }

            foreach (DataRow row in dtTemp.Rows)
            {
                dtData.Rows.Add(row.ItemArray);
            }

            dtgCreditos.DataSource = dtData;
            FormatoGrid();
            CalcularTotalesGrid();
            pbCargando.Visible = false;
            btnImportar.Enabled = true;
        }

        private void releaseObject(object obj)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0) ;
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw (ex);
            }
            finally
            {
                obj = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void CalcularMontosAdeudado()
        {
            decimal nMontoAsignado = 0M;
            decimal nMontoNoAsignado = 0M;
            decimal nSaldoAdeudado = 0M;

            nMontoAsignado = dtCredAdeudado.AsEnumerable().Sum(x => Convert.ToDecimal(x["nSaldoCapital"]));
            nSaldoAdeudado = String.IsNullOrEmpty(txtSaldoAdeudado.Text) ? 0 : Convert.ToDecimal(txtSaldoAdeudado.Text);

            nMontoNoAsignado = nSaldoAdeudado - nMontoAsignado;

            txtMontoAsignado.Text = String.Format("{0:#,0.00}", nMontoAsignado);
            txtMontoNoAsignado.Text = String.Format("{0:#,0.00}", nMontoNoAsignado);
        }

        private void CalcularTotalesGrid()
        {         
            int nNroCred = 0;
            decimal nSumSaldoCapital = 0M;
 
            nNroCred = dtgCreditos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["lVincular"].Value));
            nSumSaldoCapital = dtgCreditos.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["lVincular"].Value))
                                                                        .Sum(x => Convert.ToDecimal(x.Cells["nSaldoCapital"].Value));
            txtNroCreditos.Text = Convert.ToString(nNroCred);
            txtSumSaldoCapital.Text = String.Format("{0:#,0.00}", nSumSaldoCapital);
        }

        private void LimpiarAdeudado()
        {
            idAdeudado = 0;
            txtCodigoAdeudo.Text = "0";
            txtNroPagare.Text = String.Empty;
            cboTipoEntidad.SelectedIndex = -1;
            cboEntidad.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            txtMontoFinanciado.Text = String.Empty;
            txtSaldoAdeudado.Text = String.Empty;
            txtMontoAsignado.Text = String.Empty;
            txtMontoNoAsignado.Text = String.Empty;

            dtCredAdeudado = null;
            dtpHistorico.Enabled = false;
        }

        #endregion

        private void dtgCreditos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            CalcularTotalesGrid();
        }

        private void dtgCreditos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgCreditos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void chcHistorico_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHistorico.Checked)
            {
                dtpHistorico.Enabled = true;
            }
            else
                dtpHistorico.Enabled = false;
        }

        private void dtpHistorico_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpHistorico.Value) >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Fecha no puede ser mayor o igual a la fecha del sistema", "Vinculacion de creditos con adeudados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpHistorico.Value = clsVarGlobal.dFecSystem.AddDays(-1);
                return;
            }
        }

    }
}

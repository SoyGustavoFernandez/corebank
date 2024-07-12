using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using PRE.CapaNegocio;
using EntityLayer;
using GEN.LibreriaOffice;

namespace PRE.Presentacion
{
    public partial class frmRegistroValorPartida : frmBase
    {
        #region Variables Globales
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();

        private DataTable dtValoresPartidas;

        private int nFilaPartida;
        private int nFilaClick;
        private int nEnero = 5;
        private int nDiciembre = 16;
        private int idPeriodoSelec;

        private bool lEsPlanificacion;
        private bool lModoEdicion;

        private string cTituloMensaje = "Carga valor de partida";

        OpenFileDialog OpenDialog;
        Dictionary<string, Dictionary<string, int>> dColumns = new Dictionary<string, Dictionary<string, int>>
            {
                {"cCodigoPresupuestal",	new Dictionary<string, int> { {"Codigo pres.", 1}}},
                {"cNombre",	new Dictionary<string, int> { {"Nombre", 1}}},
                {"Enero",	new Dictionary<string, int> { {"Enero", 1}}},
                {"Febrero",	new Dictionary<string, int> { {"Febrero", 1}}},
                {"Marzo",	new Dictionary<string, int> { {"Marzo", 1}}},
                {"Abril",	new Dictionary<string, int> { {"Abril", 1}}},
                {"Mayo",	new Dictionary<string, int> { {"Mayo", 1}}},
                {"Junio",	new Dictionary<string, int> { {"Junio", 1}}},
                {"Julio",	new Dictionary<string, int> { {"Julio", 1}}},
                {"Agosto",	new Dictionary<string, int> { {"Agosto", 1}}},
                {"Setiembre",	new Dictionary<string, int> { {"Setiembre", 1}}},
                {"Octubre",	new Dictionary<string, int> { {"Octubre", 1}}},
                {"Noviembre",	new Dictionary<string, int> { {"Noviembre", 1}}},
                {"Diciembre",	new Dictionary<string, int> { {"Diciembre", 1}}},
                //{"nPresupuestoApertura",	new Dictionary<string, int> { {"Presupuesto Apertura", 1}}},
                //{"cNacionalidad", new Dictionary<string, int> { {"Nacionalidad", 0}}},
                //{"cCodPais", new Dictionary<string, int> { {"Código de País", 1}}},
                //{"cCodUbigeo", new Dictionary<string, int> { {"Cod Ubigeo", 1}}},
                //{"cDepartamento", new Dictionary<string, int> { {"Departamento", 1}}},
                //{"cProvincia", new Dictionary<string, int> { {"Provincia", 1}}},
                //{"cDistrito", new Dictionary<string, int> { {"Distrito", 1}}},
                //{"cGenero", new Dictionary<string, int> { {"Genero", 1}}}
            };
        #endregion
        #region Eventos
        public frmRegistroValorPartida()
        {
            InitializeComponent();
        }
        private void frmRegistroValorPartida_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (verificarEstadoPeriodo())
            {
                listarValoresDePartidas();
            }
            else
            {
                bloquearTodo();
            }
            
        }
        private void frmRegistroValorPartida_Shown(object sender, EventArgs e)
        {
            mostrarMensajeVerificacionSuma();
        }
        private void frmRegistroValorPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgValoresDePartidas.CancelEdit();
            limpiarDatos();
        }

        private void cboPeriodoPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
                verificarEstadoPeriodo();
                dtgValoresDePartidas.DataSource = null;
                listarValoresDePartidas();
                mostrarMensajeVerificacionSuma();
                lModoEdicion = false;
        }

        private void dtgValoresDePartidas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgValoresDePartidas.Rows[e.RowIndex].ErrorText = String.Empty;
            int nColumnaActual = e.ColumnIndex;
            int nFilaActual = e.RowIndex;
            actualizarCeldas(nFilaActual, nColumnaActual);
        }
        private void dtgValoresDePartidas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Convert.ToInt32(e.ColumnIndex) >= nEnero && Convert.ToInt32(e.ColumnIndex) <= nDiciembre)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresDePartidas.CancelEdit();
                    return;
                }
                else if (verificarDecimal(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("No es un número correcto", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresDePartidas.CancelEdit();
                    return;
                }
                else if (Convert.ToDecimal(e.FormattedValue) < 0)
                {
                    MessageBox.Show("No puede ser negativo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresDePartidas.CancelEdit();
                    return;
                }
            }
        }
        private void dtgValoresDePartidas_Click(object sender, EventArgs e)
        {
            if (dtgValoresDePartidas.CurrentCell != null)
            {
                txtReplicar.Clear();
                nFilaClick = Convert.ToInt32(dtgValoresDePartidas.CurrentCell.RowIndex);
                txtPartida.Text = Convert.ToString(dtgValoresDePartidas.Rows[nFilaClick].Cells["cDescripcion"].Value).Trim();
                if (Convert.ToInt16(dtgValoresDePartidas.Rows[nFilaClick].Cells["editable"].Value) == 1 && lModoEdicion == true && lEsPlanificacion == true)
                {
                    habilitarControlesReplicar(true);
                }
                else
                {
                    habilitarControlesReplicar(false);
                }
            }

        }
        private void dtgValoresDePartidas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
            }
        }
        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || Convert.ToInt32(e.KeyChar).In(8, 13, 46))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lModoEdicion = true;
            habilitarCeldas();
            habilitarControlesAlEditar();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            insertarValoresPartidas(idPeriodoSelec);
            limpiarDatos();
            listarValoresDePartidas();
            bloquearCeldas();
            lModoEdicion = false;
            habilitarControles(true);
            habilitarControlesReplicar(false);
            mostrarMensajeVerificacionSuma();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            listarValoresDePartidas();
            habilitarControles(true);
            habilitarControlesReplicar(false);
        }
        private void btnMiniReplicar_Click(object sender, EventArgs e)
        {
            decimal d;
            if (decimal.TryParse(txtReplicar.Text, out d))
            {
                decimal nReplicar = Convert.ToDecimal(String.Format("{0:#,0.00}",txtReplicar.Text));
                txtReplicar.Text = nReplicar.ToString();
                replicarValores(nReplicar);
            }
            else
            {
                MessageBox.Show("No es un número correcto", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void txtReplicar_Enter(object sender, EventArgs e)
        {
            txtReplicar.nNumDecimales = 2;
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Al cargar desde un Excel, se remplazarán los montos de las partidas existentes ¿Desea continuar?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();
            txtPath.Text = OpenDialog.FileName;

            try
            {
                ExcelHandler ex = new ExcelHandler();
                DataTable dtTabla = ex.ImportExcelToDataTable(txtPath.Text);
                //dtTabla.Columns.Add("cCuentasContables", typeof(string));

                //tabla = renombrarColumnas(tabla);
                if (ValidarHojaExcel(dtTabla))
                {
                    if (validarFormatoExcel(dtTabla))
                    {
                        // Verificar formato del excel                     
                        //dtgPartidas.DataSource = dtTabla;
                        //formatoDTGPArtidas();
                        //validarFormatoCtasEnDTG();                                      
                        cargarDeExcelADTG(dtTabla);
                        //btnGrabar1.Enabled = false;    
                    }                                       
                }
            }
            catch
            {
                MessageBox.Show("No se ha podido cargar la hoja de Excel.", "Carga de Partidas presupuestales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
                //limpiar();
            }
        }
        #endregion
        #region Metodos
        private bool verificarEstadoPeriodo()
        {
            if (cboPeriodoPresupuestal.SelectedItem == null)
            {
                return false;
            }
            else
            {
                idPeriodoSelec = Convert.ToInt32(this.cboPeriodoPresupuestal.SelectedValue);
                DataTable dtPeriodoSelect = new clsCNPeriodos().PeriodosPresupuesto(idPeriodoSelec);
                this.lblPlanificacion.Text = Convert.ToString(dtPeriodoSelect.Rows[0]["cEstado"]);
                int nEstado = Convert.ToInt32(dtPeriodoSelect.Rows[0]["idEstado"]);
                if (nEstado == 1) 
                {
                    this.lblPlanificacion.ForeColor = Color.DarkGreen;
                    lEsPlanificacion = true;
                }
                else if(nEstado == 2)
                {
                    this.lblPlanificacion.ForeColor = Color.RoyalBlue;
                    lEsPlanificacion = true;
                }
                else
                {
                    this.lblPlanificacion.ForeColor = Color.Gray;
                    lEsPlanificacion = false;
                }
                return true;
            }

        }
        private void listarValoresDePartidas()
        {
            dtValoresPartidas = new DataTable();
            dtValoresPartidas = cnpartidaspres.ListarValoresDePartidas(idPeriodoSelec);
            if (dtValoresPartidas.Rows.Count > 0)
            {
               dtgValoresDePartidas.DataSource = dtValoresPartidas;
               formatearGrid();
               habilitarControles(lEsPlanificacion);
               habilitarControlesReplicar(false);
            }
            else
            {
                habilitarControles(false);
                habilitarControlesReplicar(false);
                return;
            }
        }
        private void formatearGrid()
        {
            dtValoresPartidas.Columns["Enero"].ReadOnly = false;
            dtValoresPartidas.Columns["Febrero"].ReadOnly = false;
            dtValoresPartidas.Columns["Marzo"].ReadOnly = false;
            dtValoresPartidas.Columns["Abril"].ReadOnly = false;
            dtValoresPartidas.Columns["Mayo"].ReadOnly = false;
            dtValoresPartidas.Columns["Junio"].ReadOnly = false;
            dtValoresPartidas.Columns["Julio"].ReadOnly = false;
            dtValoresPartidas.Columns["Agosto"].ReadOnly = false;
            dtValoresPartidas.Columns["Setiembre"].ReadOnly = false;
            dtValoresPartidas.Columns["Octubre"].ReadOnly = false;
            dtValoresPartidas.Columns["Noviembre"].ReadOnly = false;
            dtValoresPartidas.Columns["Diciembre"].ReadOnly = false;

            dtValoresPartidas.Columns.Add("Modificado", typeof(bool));

            foreach (DataRow row in dtValoresPartidas.Rows)
            {
                row["Modificado"] = false;
            }

            dtgValoresDePartidas.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgValoresDePartidas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }

            for (int i = nEnero - 1; i < nEnero + 13; i++)
            {
                dtgValoresDePartidas.Columns[i].Visible = true;
                if (i >= nEnero)
                {
                    dtgValoresDePartidas.Columns[i].DefaultCellStyle.Format = "N2";
                    dtgValoresDePartidas.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dtgValoresDePartidas.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgValoresDePartidas.Columns[nEnero + 12].HeaderText = "Total";
            dtgValoresDePartidas.Columns["cDescripcion"].Frozen = true;
            panel2.Height = ((dtgValoresDePartidas.Rows.Count + 2) * dtgValoresDePartidas.RowTemplate.Height);
            dtgValoresDePartidas.Height = (dtgValoresDePartidas.Rows.Count + 4) * dtgValoresDePartidas.RowTemplate.Height;

            if ((dtgValoresDePartidas.Rows.Count + 1) * dtgValoresDePartidas.RowTemplate.Height > 370)
            {
                dtgValoresDePartidas.ScrollBars = ScrollBars.Both;
                panel2.Height = 370;
            }
            else
            {
                dtgValoresDePartidas.ScrollBars = ScrollBars.Horizontal;
            }
            int nAltura = Convert.ToInt32(((dtgValoresDePartidas.Rows.Count + 1) * dtgValoresDePartidas.RowTemplate.Height) + 230);
            this.Size = new Size(1000, nAltura);
        }
        private void habilitarCeldas()
        {
            if (lEsPlanificacion)
            {
                for (int i = 0; i < dtgValoresDePartidas.Rows.Count; i++)
                {
                    int editable = Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["Editable"].Value);
                    for (int j = nEnero; j <= nDiciembre; j++)
                    {
                        if (editable == 1)
                        {
                            dtgValoresDePartidas.Rows[i].Cells[j].ReadOnly = false;
                        }
                        else
                        {
                            dtgValoresDePartidas.Rows[i].Cells[j].Style.BackColor = Color.Gainsboro;
                        }
                    }
                }
            }
        }
        private void bloquearCeldas()
        {
            for (int i = 0; i < dtgValoresDePartidas.Rows.Count; i++)
            {
                int editable = Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["Editable"].Value);
                for (int j = nEnero; j <= nDiciembre; j++)
                {
                    if (editable == 1)
                    {
                        dtgValoresDePartidas.Rows[i].Cells[j].ReadOnly = true;
                    }
                    else
                    {
                        dtgValoresDePartidas.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }
        }
        private void bloquearTodo()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;            
            habilitarControles(false);
            this.btnImportExcel.Enabled = false;
        }
        private void habilitarControles(bool lVal)
        {
            if (lVal)
            {
                txtReplicar.Enabled = false;
                btnMiniReplicar.Enabled = false;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                txtReplicar.Enabled = false;
                btnMiniReplicar.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;                
            }
            this.btnImportExcel.Enabled = false;
        }
        private void habilitarControlesAlEditar()
        {
            if (lModoEdicion)
            {
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                this.btnImportExcel.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                this.btnImportExcel.Enabled = false;
            }
        }
        private void habilitarControlesReplicar(bool lVal)
        {
            if (lVal && lEsPlanificacion && lModoEdicion)
            {
                btnMiniReplicar.Enabled = true;
                txtReplicar.Enabled = true;
            }
            else
            {
                btnMiniReplicar.Enabled = false;
                txtReplicar.Enabled = false;
                txtReplicar.Clear();
            }
        }
        private void limpiarDatos()
        {
            lModoEdicion = false;
            txtReplicar.Clear();
            dtgValoresDePartidas.DataSource = null;
        }
        private void actualizarCeldas(int nFilaActual, int nColumnaActual)
        {
            decimal sumaMeses = 0;

            for (int i = nEnero; i <= nDiciembre; i++)
            {
                sumaMeses += Convert.ToDecimal(dtgValoresDePartidas.Rows[nFilaActual].Cells[i].Value);
            }
            dtgValoresDePartidas.Rows[nFilaActual].Cells["nPresupuestoApertura"].Value = sumaMeses;
            dtgValoresDePartidas.Rows[nFilaActual].Cells["Modificado"].Value = true;

            int idPartida = Convert.ToInt32(dtgValoresDePartidas.Rows[nFilaActual].Cells["idPartida"].Value);
            nFilaPartida = devolverFilaCelda(idPartida);
            int idPartidaPadre = devolverPadre(idPartida);

            while (idPartidaPadre != 0)
            {
                nFilaPartida = devolverFilaCelda(idPartidaPadre);
                decimal nSuma = verificarHermanoPartida(idPartidaPadre, nColumnaActual);
                dtgValoresDePartidas.Rows[nFilaPartida].Cells[nColumnaActual].Value = nSuma;

                sumaMeses = 0;
                for (int i = nEnero; i <= nDiciembre; i++)
                {
                    sumaMeses += Convert.ToDecimal(dtgValoresDePartidas.Rows[nFilaPartida].Cells[i].Value);
                }

                dtgValoresDePartidas.Rows[nFilaPartida].Cells["nPresupuestoApertura"].Value = sumaMeses;
                dtgValoresDePartidas.Rows[nFilaPartida].Cells["Modificado"].Value = true;

                idPartidaPadre = devolverPadre(idPartidaPadre);
            }

        }
        private int devolverPadre(int idPartida)
        {
            int idPartidaPadre = Convert.ToInt32(dtgValoresDePartidas.Rows[nFilaPartida].Cells["idPartidaPadre"].Value);
            return idPartidaPadre;
        }
        private int devolverFilaCelda(int idPartida)
        {
            for (int i = 0; i < dtgValoresDePartidas.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["idPartida"].Value) == idPartida)
                {
                    nFilaPartida = i;
                }
            }
            return nFilaPartida;
        }
        private decimal verificarHermanoPartida(int idPartidaPadre, int nColumnaActual)
        {
            decimal nValorHermano = 0;
            for (int i = 0; i < dtgValoresDePartidas.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["idPartidaPadre"].Value) == idPartidaPadre)
                {
                    nValorHermano += Convert.ToDecimal(dtgValoresDePartidas.Rows[i].Cells[nColumnaActual].Value);
                }
            }
            return nValorHermano;
        }
        private void insertarValoresPartidas(int idPeriodo)
        {
            DataSet dsValoresPartidas = new DataSet("DSValoresPartidas");

            for (int i = 0; i <= dtValoresPartidas.Rows.Count - 1; i++)
            {
                DataRow dtFila = dtValoresPartidas.Rows[i];
                if (Convert.ToBoolean(dtFila["Modificado"]) == false)
                {
                    dtFila.Delete();
                }
            }
            dtValoresPartidas.AcceptChanges();
            if (dtValoresPartidas.Rows.Count > 0)
            {
                dsValoresPartidas.Tables.Add(dtValoresPartidas);
                string xmlValoresPartidas = dsValoresPartidas.GetXml();
                xmlValoresPartidas = clsCNFormatoXML.EncodingXML(xmlValoresPartidas);
                dsValoresPartidas.Tables.Clear();

                int idUsuMod = clsVarGlobal.User.idUsuario;
                DateTime dFechaMod = clsVarGlobal.dFecSystem;
                DataTable dtResultado = cnpartidaspres.InsertarValoresPartidas(idPeriodo, idUsuMod, dFechaMod, xmlValoresPartidas);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else
            {
                MessageBox.Show("No existen modificaciones para guardar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }
        private void replicarValores(decimal nReplicar)
        {
            for (int i = nEnero; i <= nDiciembre; i++)
            {
                dtgValoresDePartidas.Rows[nFilaClick].Cells[i].Value = nReplicar;
                actualizarCeldas(nFilaClick, i);
            }
        }
        private bool verificarCeldasAlCargar()
        {
            bool lSumaCorrecta = true;
            for (int i = 0; i < dtgValoresDePartidas.RowCount; i++)
            {
                int editable = Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["Editable"].Value);
                if (editable == 1)
                {
                    for (int j = nEnero; j <= nDiciembre; j++)
                    {
                        int idPartida = Convert.ToInt32(dtgValoresDePartidas.Rows[i].Cells["idPartida"].Value);
                        nFilaPartida = devolverFilaCelda(idPartida);
                        int idPartidaPadre = devolverPadre(idPartida);
                        while (idPartidaPadre != 0)
                        {
                            nFilaPartida = devolverFilaCelda(idPartidaPadre);
                            decimal nSuma = verificarHermanoPartida(idPartidaPadre, j);
                            if (Convert.ToDecimal(dtgValoresDePartidas.Rows[nFilaPartida].Cells[j].Value) != nSuma)
                            {
                                lSumaCorrecta = false;
                                dtgValoresDePartidas.Rows[nFilaPartida].Cells[j].Style.BackColor = Color.MistyRose;
                            }
                            idPartidaPadre = devolverPadre(idPartidaPadre);
                        }

                    }
                }
            }
            return lSumaCorrecta;
        }
        private void mostrarMensajeVerificacionSuma()
        {
            if (!verificarCeldasAlCargar())
            {
                MessageBox.Show("Existe suma incorrecta en los valores presupuestales.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool verificarDecimal(string nValue)
        {
            decimal d;
            if (decimal.TryParse(nValue, out d))
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        private bool ValidarHojaExcel(DataTable dt)
        {
            string cColumnasFaltantes = "";
            bool lValido = true;
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                if (!dt.Columns.Contains(item.Key))
                {
                    foreach (KeyValuePair<string, int> item2 in item.Value)
                    {
                        cColumnasFaltantes += "\t" + item2.Key + "\n";
                        lValido = false;
                    }
                }
            }

            if (!lValido)
            {
                MessageBox.Show("La tabla no tiene las siguientes columnas:" + cColumnasFaltantes + " ", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPath.Text = "";
            }            
            return lValido;
        }
        private void cargarDeExcelADTG(DataTable dt)
        {
            foreach (DataGridViewRow item in this.dtgValoresDePartidas.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Editable"].Value))
                {
                    foreach (DataRow itemEx in dt.Rows)
                    {
		                if (String.Compare(item.Cells["cCodigoPresupuestal"].Value.ToString(), itemEx["cCodigoPresupuestal"].ToString()) == 0)
                        {                            
                            item.Cells["Enero"].Value = itemEx["Enero"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Enero"]));
                            item.Cells["Febrero"].Value = itemEx["Febrero"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Febrero"]));
                            item.Cells["Marzo"].Value = itemEx["Marzo"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Marzo"]));
                            item.Cells["Abril"].Value = itemEx["Abril"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Abril"]));
                            item.Cells["Mayo"].Value = itemEx["Mayo"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Mayo"]));
                            item.Cells["Junio"].Value = itemEx["Junio"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Junio"]));
                            item.Cells["Julio"].Value = itemEx["Julio"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Julio"]));
                            item.Cells["Agosto"].Value = itemEx["Agosto"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Agosto"]));
                            item.Cells["Setiembre"].Value = itemEx["Setiembre"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Setiembre"]));
                            item.Cells["Octubre"].Value = itemEx["Octubre"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Octubre"]));
                            item.Cells["Noviembre"].Value = itemEx["Noviembre"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Noviembre"]));
                            item.Cells["Diciembre"].Value = itemEx["Diciembre"];
                            actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["Diciembre"]));
                            //item.Cells["nPresupuestoApertura"].Value = itemEx["nPresupuestoApertura"];
                            //actualizarCeldas(item.Index, this.dtgValoresDePartidas.Columns.IndexOf(this.dtgValoresDePartidas.Columns["nPresupuestoApertura"]));
                        }
                    }
                }
            }
            mostrarMensajeVerificacionSuma();
        }
        private Boolean validarFormatoExcel(DataTable dtTabla)
        {            
            decimal d;
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                for (int j = 0; j < dtTabla.Columns.Count; j++)
                {
                    if (String.IsNullOrEmpty(dtTabla.Rows[i][j].ToString()))
                    {
                        MessageBox.Show("La tabla tiene campos obligatorios en blanco", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (dtTabla.Columns.IndexOf("Enero") <= j)
                    {
                        if (!decimal.TryParse(dtTabla.Rows[i][j].ToString(), out d))
                        {
                            MessageBox.Show("Los montos deben ser de formato numérico", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }                               
                if (dtTabla.Rows[i]["cCodigoPresupuestal"].ToString().Length % 2 != 0)
                {
                    MessageBox.Show("Existen datos inconsistentes en la columna cCodigoPresupuestal", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        #endregion        
    }
}
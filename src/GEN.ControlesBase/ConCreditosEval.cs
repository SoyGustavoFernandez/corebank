using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ConCreditosEval : UserControl
    {
        #region Variables
        private int idEvalCre = 0;
        clsCNEvalConsumo cnEvalCon = new clsCNEvalConsumo();
        DataTable dtCreditosDirectos;
        DataTable dtCreditosIndirectos;
        string cTituloMensaje = "Créditos evaluación";
        public Boolean lEstadoCargaDeuda = false;

        private Decimal nTipoCambio;
        public event EventHandler eClickCargarDeudas;
        public event DataGridViewCellEventHandler eCellEndEdit;
        private ComboBox cmbItem;

        private bool lCargaFormFirst = true;

        private DataTable dtUtilizada;
        private DataTable dtTipoInterv;
        #endregion
        
        public ConCreditosEval()
        {
            InitializeComponent();
            //cargarDeudaRegistrada();
        }

        #region Metodos 
        public void limpiar()
        {
            this.idEvalCre = 0;

            if(dtCreditosDirectos != null)
                dtCreditosDirectos.Clear();

            if (dtCreditosIndirectos != null)
                dtCreditosIndirectos.Clear();

            lEstadoCargaDeuda = false;
            btnCargarDeudaRcc.Enabled = true;
            nTipoCambio = 0;

        }
        
        public void cargarDeudaRegistrada(DataTable dt, bool lCargaRcc, int idEvaCre, Decimal nTipCambio) 
        {
            nTipoCambio = nTipCambio;
            idEvalCre = idEvaCre;
            separarPorTipoDeuda(dt);

            foreach (DataColumn item in dtCreditosDirectos.Columns)
            {
                item.ReadOnly = false;
            }

            foreach (DataColumn item in dtCreditosIndirectos.Columns)
            {
                item.ReadOnly = false;
            }

            dtCreditosDirectos.Columns["cProducto"].MaxLength = 100;
            dtCreditosDirectos.Columns["cEntidadFin"].MaxLength = 100;

            dtCreditosIndirectos.Columns["cProducto"].MaxLength = 100;
            dtCreditosIndirectos.Columns["cEntidadFin"].MaxLength = 100;

            dtgCre.DataSource = dtCreditosDirectos;
            dtgCreInd.DataSource = dtCreditosIndirectos;

            /* ----------------------------------------------------------------------------------------
             * Insertando el combobox tipo deuda
             * ----------------------------------------------------------------------------------------*/
            // DataTable dtTipoDeuda = cnEvalCon.CNListaTipoDeuda(1);
            DataTable dtDeuda = new DataTable();
            dtDeuda.Columns.Add("idDeudaCA", typeof(int));
            dtDeuda.Columns.Add("cDeudaCA", typeof(string));
            

            dtDeuda.Rows.Add(1, "Normal");
            dtDeuda.Rows.Add(2, "Compra Deuda");
            dtDeuda.Rows.Add(3, "Ampliación");
            dtDeuda.Rows.Add(4, "Reprogramación");
            dtDeuda.Rows.Add(5, "Refinanciamiento");

            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dtMoneda = ListadoMoneda.listarMoneda();

            this.dtUtilizada = new DataTable();
            this.dtUtilizada.Columns.Add("lUtilizada", typeof(bool));
            this.dtUtilizada.Columns.Add("cUtilizada", typeof(string));
            this.dtUtilizada.Columns.Add("cAbreviatura", typeof(string));
            this.dtUtilizada.Rows.Add(1, "Utilizada", "U");
            this.dtUtilizada.Rows.Add(0, "No Utilizada", "NU");

            this.dtTipoInterv = new DataTable();
            this.dtTipoInterv.Columns.Add("idTipoInterv", typeof(int));
            this.dtTipoInterv.Columns.Add("cTipoInterv", typeof(string));
            this.dtTipoInterv.Columns.Add("cAbreviatura", typeof(string));
            this.dtTipoInterv.Rows.Add(1, "TITULAR", "TI");
            this.dtTipoInterv.Rows.Add(2, "CONYUGE TITULAR", "CTI");
            this.dtTipoInterv.Rows.Add(3, "FIADOR SOLIDARIO", "FS");
            this.dtTipoInterv.Rows.Add(4, "CONYUGE DE FIADOR SOLIDARIO", "CFS");
            this.dtTipoInterv.Rows.Add(5, "CODEUDOR", "CO");
            this.dtTipoInterv.Rows.Add(9, "REPRESENTANTE LEGAL", "RL");
            this.dtTipoInterv.Rows.Add(11, "CONSORCIO", "CN");
            this.dtTipoInterv.Rows.Add(12, "CONYUGE DE CODEUDOR", "CCO");
            this.dtTipoInterv.Rows.Add(0, "...Seleccione...", "--");

            agregarCbosAGrid(dtgCre, dtDeuda, dtMoneda);
            agregarCbosAGrid(dtgCreInd, dtDeuda, dtMoneda);
            
            formatoGrid(dtgCre, 1);
            formatoGrid(dtgCreInd, 2);
            lEstadoCargaDeuda = lCargaRcc;
            ValidaActualizaDiseño();
            
            if (lCargaRcc)
            {
                btnCargarDeudaRcc.Enabled = false;
            }
            else
            {
                btnCargarDeudaRcc.Enabled = true;
            }            
        }
        public void actualizarDiseño()
        {
            dtgCre.CellValueChanged -= dtgCre_CellValueChanged;

            actualizarCombosGridValue(dtgCre);
            actualizarCombosGridValue(dtgCreInd);

            bloquearEditarGrid(dtgCre);
            bloquearEditarGrid(dtgCreInd);

            dtgCre.CellValueChanged += dtgCre_CellValueChanged;
   
        }

        public int obtNroCuotasMaxPendienteCompraDeuda()
        {
            int nNroCuotaMax = -1; // ESTO PARA VALIDAR EN BASE DE DATOS SI ES 1 NO HAY COMPRA DEUDA Y SI MAYOR QUE -1 HAY COMPRA DEUDA
            foreach (DataGridViewRow item in dtgCre.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboDeudaCA"].Value) == 2) //compra deuda
                {
                    nNroCuotaMax = (Convert.ToInt32(item.Cells["nNroCuotasPorPagar"].Value) > nNroCuotaMax) ? Convert.ToInt32(item.Cells["nNroCuotasPorPagar"].Value) : nNroCuotaMax;
                }
            }
            return nNroCuotaMax;
        }

        private void cargarDeudaRcc()
        {
            DataTable dtResDeuda = cnEvalCon.CNCargarDeudaRegistrada(idEvalCre, 1);
            cargarDeudaRegistrada(dtResDeuda, true, idEvalCre, nTipoCambio);
        }

        private void agregarCbosAGrid(DataGridView dtg, DataTable dtDeudaCA, DataTable dtMoneda)
        {
            DataGridViewComboBoxColumn dtgCboTipoDeuda = new DataGridViewComboBoxColumn();
            dtgCboTipoDeuda.HeaderText = "Acción";
            dtgCboTipoDeuda.Name = "cboDeudaCA";
            dtgCboTipoDeuda.MaxDropDownItems = 3;
            dtgCboTipoDeuda.DisplayMember = dtDeudaCA.Columns[1].ToString();
            dtgCboTipoDeuda.ValueMember = dtDeudaCA.Columns[0].ToString();
            dtgCboTipoDeuda.DataSource = dtDeudaCA;
            dtg.Columns.Add(dtgCboTipoDeuda);

            /* ----------------------------------------------------------------------------------------
             * Insertando el combobox moneda
             * ----------------------------------------------------------------------------------------*/
            
            DataGridViewComboBoxColumn dtgCboMoneda = new DataGridViewComboBoxColumn();
            dtgCboMoneda.HeaderText = "M.";
            dtgCboMoneda.Name = "cboMoneda";
            dtgCboMoneda.MaxDropDownItems = 3;
            dtgCboMoneda.DisplayMember = dtMoneda.Columns[5].ToString();
            dtgCboMoneda.ValueMember = dtMoneda.Columns[0].ToString();
            dtgCboMoneda.DataSource = dtMoneda;

            dtg.Columns.Add(dtgCboMoneda);

            DataGridViewComboBoxColumn dgcboUtilizada = new DataGridViewComboBoxColumn();
            dgcboUtilizada.DisplayStyleForCurrentCellOnly = true;
            dgcboUtilizada.FlatStyle = FlatStyle.Popup;
            dgcboUtilizada.Name = "dgcboUtilizada";
            dgcboUtilizada.DataPropertyName = "lUtilizada";
            dgcboUtilizada.DataSource = this.dtUtilizada;
            dgcboUtilizada.DisplayMember = this.dtUtilizada.Columns["cAbreviatura"].ToString();
            dgcboUtilizada.ValueMember = this.dtUtilizada.Columns["lUtilizada"].ToString();
            dtg.Columns.Add(dgcboUtilizada);

            DataGridViewComboBoxColumn dgcboTipoInterv = new DataGridViewComboBoxColumn();
            dgcboTipoInterv.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoInterv.FlatStyle = FlatStyle.Popup;
            dgcboTipoInterv.Name = "dgcboTipoInterv";
            dgcboTipoInterv.DataPropertyName = "idTipoInterv";
            dgcboTipoInterv.DataSource = this.dtTipoInterv;
            dgcboTipoInterv.DisplayMember = this.dtTipoInterv.Columns["cTipoInterv"].ToString();
            dgcboTipoInterv.ValueMember = this.dtTipoInterv.Columns["idTipoInterv"].ToString();
            dtg.Columns.Add(dgcboTipoInterv);
        }

        private void separarPorTipoDeuda(DataTable dt)
        {
            if (dtCreditosDirectos == null)
            {
                dtCreditosDirectos = dt.Clone();
            }
            if (dtCreditosIndirectos == null)
            {
                dtCreditosIndirectos = dt.Clone();
            }
            

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["idTipoDeuda"]) == 1)
                {
                    dtCreditosDirectos.ImportRow(item);
                }
                else
                {
                    dtCreditosIndirectos.ImportRow(item);    
                }

            }
        }
        private void formatoGrid(DataGridView dtg, int idTipoDeuda)
        {
            dtg.ReadOnly = false;
            foreach (DataGridViewColumn item in dtg.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = true;
            }

            if (idTipoDeuda == 1)
            {
                dtg.Columns["cboDeudaCA"].Visible = true;
                dtg.Columns["nCuotaMensual"].Visible = true;
                dtg.Columns["nNroCuotasPorPagar"].Visible = true;
            }

            dtg.Columns["cProducto"].Visible = true;
            dtg.Columns["cEntidadFin"].Visible = true;
            dtg.Columns["nSaldoObtenido"].Visible = true;
            dtg.Columns["nSaldo"].Visible = true;
            dtg.Columns["cboMoneda"].Visible = true;

            dtg.Columns["dgcboUtilizada"].Visible = true;
            dtg.Columns["dgcboTipoInterv"].Visible = true;

            dtg.Columns["cProducto"].HeaderText = "Producto";
            dtg.Columns["cEntidadFin"].HeaderText = "Entidad Financiera";
            dtg.Columns["nSaldoObtenido"].HeaderText = "Saldo Obtenido";
            dtg.Columns["nSaldo"].HeaderText = "Saldo Actual";
            dtg.Columns["nCuotaMensual"].HeaderText = "Cuota Mensual";
            dtg.Columns["nNroCuotasPorPagar"].HeaderText = "C.por pagar";

            dtg.Columns["dgcboUtilizada"].HeaderText = "Línea";
            dtg.Columns["dgcboTipoInterv"].HeaderText = "Tp.Interv";

            ((DataGridViewTextBoxColumn)dtg.Columns["cProducto"]).MaxInputLength = 100;
            ((DataGridViewTextBoxColumn)dtg.Columns["cEntidadFin"]).MaxInputLength = 100;

            dtg.Columns["nSaldoObtenido"].DefaultCellStyle.Format = "N2";
            dtg.Columns["nSaldo"].DefaultCellStyle.Format = "N2";
            dtg.Columns["nCuotaMensual"].DefaultCellStyle.Format = "N2";
            dtg.Columns["nNroCuotasPorPagar"].DefaultCellStyle.Format = "N0";

            dtg.Columns["cboDeudaCA"].DisplayIndex = 7;
            dtg.Columns["cboMoneda"].DisplayIndex = 9;

            dtg.Columns["cboDeudaCA"].Width = 80;
            dtg.Columns["cboMoneda"].Width = 40;
            dtg.Columns["nSaldoObtenido"].Width = 80;
            dtg.Columns["nCuotaMensual"].Width = 60;
            dtg.Columns["nSaldo"].Width = 80;
            dtg.Columns["nNroCuotasPorPagar"].Width = 40;
        }

        private void actualizarCombosGridValue(DataGridView dtg) 
        {
            foreach (DataGridViewRow item in dtg.Rows)
            {
                if (Convert.ToInt32(item.Cells["nDeudaCA"].Value) > 0) 
                {
                    dtg.Rows[item.Index].Cells["cboDeudaCA"].Value = Convert.ToInt32(item.Cells["nDeudaCA"].Value);
                }

                if (Convert.ToInt32(item.Cells["idMoneda"].Value) > 0)
                {
                    dtg.Rows[item.Index].Cells["cboMoneda"].Value = Convert.ToInt32(item.Cells["idMoneda"].Value);
                }
            }
        }

        public clsMsjError validarCreditosEval()
        {
            clsMsjError obj = new clsMsjError();
            foreach (DataGridViewRow item in dtgCre.Rows)
            {
                if (String.IsNullOrEmpty(item.Cells["cEntidadFin"].Value.ToString()))
                {
                    obj.AddError("Ingrese la entidad financiera - Deudas directas");
                }
                if (String.IsNullOrEmpty(item.Cells["cProducto"].Value.ToString()))
                {
                    obj.AddError("Ingrese el producto de la deuda - Deudas directas");
                }
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) <= 0)
                {
                    obj.AddError("Ingrese la moneda de la deuda - Deudas directas");
                }
                if (String.IsNullOrEmpty(item.Cells["nSaldo"].Value.ToString()))
                {
                    obj.AddError("Ingrese el saldo de la deuda - Deudas directas");
                }
                if (String.IsNullOrEmpty(item.Cells["nCuotaMensual"].Value.ToString()))
                {
                    obj.AddError("Ingrese la cuota mensual de la deuda - Deudas directas");
                }
            }

            foreach (DataGridViewRow item in dtgCreInd.Rows)
            {
                if (String.IsNullOrEmpty(item.Cells["cEntidadFin"].Value.ToString()))
                {
                    obj.AddError("Ingrese la entidad financiera - Deudas indirectas");
                }
                if (String.IsNullOrEmpty(item.Cells["cProducto"].Value.ToString()))
                {
                    obj.AddError("Ingrese el producto de la deuda - Deudas indirectas");
                }
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) <= 0)
                {
                    obj.AddError("Ingrese la moneda de la deuda - Deudas indirectas");
                }
                if (String.IsNullOrEmpty(item.Cells["nSaldo"].Value.ToString()))
                {
                    obj.AddError("Ingrese el saldo de la deuda - Deudas indirectas");
                }
            }
            return obj;
        }

        private void bloquearEditarGrid(DataGridView dtg)
        {
            foreach (DataGridViewRow fila in dtg.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["lCargaDeRcc"].Value))
                {

                    fila.Cells["nSaldo"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nSaldo"].ReadOnly = false;

                    //Monto de Cuota mensual
                    fila.Cells["nCuotaMensual"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nCuotaMensual"].ReadOnly = false;

                    // Nro de Cuotas por pagar
                    fila.Cells["nNroCuotasPorPagar"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nNroCuotasPorPagar"].ReadOnly = false;

                    fila.Cells["cboDeudaCA"].ReadOnly = false;
                }
                else if (Convert.ToInt32(fila.Cells["idEntidadFin"].Value)
                        == Convert.ToInt32(clsVarApl.dicVarGen["idInstFin"]))
                {
                    fila.Cells["cboDeudaCA"].ReadOnly = false;
                    fila.DefaultCellStyle.BackColor = Color.Blue;
                    fila.DefaultCellStyle.ForeColor = Color.White;

                    if (fila.Cells["cboDeudaCA"].Value.In(3, 4, 5))
                    {
                        fila.Cells["nCuotaMensual"].Style.BackColor = Color.White;
                        fila.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                        fila.Cells["nCuotaMensual"].Value = 0.0M;
                        fila.Cells["nCuotaMensual"].ReadOnly = true;
                    }
                    else if (fila.Cells["cboDeudaCA"].Value.In(1))
                    {
                        fila.Cells["nCuotaMensual"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                        fila.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                        fila.Cells["nCuotaMensual"].ReadOnly = false;

                        fila.Cells["nNroCuotasPorPagar"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                        fila.Cells["nNroCuotasPorPagar"].Style.ForeColor = Color.Black;
                        fila.Cells["nNroCuotasPorPagar"].ReadOnly = false;
                    }                    
                }
                else
                {
                    
                    fila.Cells["cEntidadFin"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["cEntidadFin"].ReadOnly = false;

                    fila.Cells["cProducto"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["cProducto"].ReadOnly = false;

                    fila.Cells["nSaldo"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nSaldo"].ReadOnly = false;

                    fila.Cells["nNroCuotasPorPagar"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nNroCuotasPorPagar"].Style.ForeColor = Color.Black;
                    fila.Cells["nNroCuotasPorPagar"].ReadOnly = false;


                    if(fila.Cells["cboDeudaCA"].Value.In(2))
                    {
                            fila.Cells["nCuotaMensual"].Style.BackColor = Color.White;
                            fila.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                            fila.Cells["nCuotaMensual"].ReadOnly = true;
                    }
                    else if (fila.Cells["cboDeudaCA"].Value.In(1))
                    {
                        fila.Cells["nCuotaMensual"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                        fila.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                        fila.Cells["nCuotaMensual"].ReadOnly = false;
                    }
                    else
                    {
                    fila.Cells["nCuotaMensual"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    fila.Cells["nCuotaMensual"].ReadOnly = false;
                    }
                    

                    fila.Cells["cboDeudaCA"].ReadOnly = false;
                    fila.Cells["cboMoneda"].ReadOnly = false;
                    fila.Cells["dgcboUtilizada"].ReadOnly = false;
                    fila.Cells["dgcboTipoInterv"].ReadOnly = false;
                }
            }
            dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void bloquearCargaRcc()
        { 

        }
        private void cargarNuevaFila(DataGridView dtg, DataTable dt, int idTipoDeuda)
        {
            DataRow dr = dt.NewRow();
            dr["idDeuda"] = 0;
            dr["idEvalCre"] = idEvalCre;
            dr["nDeudaCA"] = 0;
            dr["idTipoDeuda"] = idTipoDeuda;
            dr["idProducto"] = 0;
            dr["cProducto"] = "";
            dr["idEntidadFin"] = 0;
            dr["cEntidadFin"] = "";
            dr["idMoneda"] = 0;
            dr["nSaldoObtenido"] = 0;
            dr["nSaldo"] = 0;
            dr["nCuotaMensual"] = 0;
            dr["lCargaDeRcc"] = 0;
            dr["lVigente"] = 1;
            dr["nNroCuotasPorPagar"] = 0;
            dr["lUtilizada"] = true;
            dr["idTipoInterv"] = 0;
            dt.Rows.Add(dr);
            formatoGrid(dtg, idTipoDeuda);
            bloquearEditarGrid(dtg);
        }

        public void bloquearControl(Boolean lBol)
        {
            dtgCre.Enabled = lBol;
            btnAgregaTarjetaCre.Enabled = lBol;
            btnQuitaTarjetaCre.Enabled = lBol;
            btnCargarDeudaRcc.Enabled = lBol;
        }

        #endregion

        #region Eventos

        private void btnQuitaTarjetaCre_Click(object sender, EventArgs e)
        {
            int nFila = Convert.ToInt32(dtgCre.SelectedCells[0].RowIndex);

            if (this.dtgCre.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (Convert.ToInt32(dtgCre.Rows[nFila].Cells["idEntidadFin"].Value)
                        == Convert.ToInt32(clsVarApl.dicVarGen["idInstFin"]))
            {
                MessageBox.Show("No se puede eliminar las deudas de la Institución", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (Convert.ToBoolean(dtgCre.Rows[nFila].Cells["lCargaDeRcc"].Value))
                {
                    MessageBox.Show("No se puede eliminar un registro obtenido automáticamente, si la deuda ha sido cancelada ingrese como 'Saldo Actual' = 0 y 'Cuota Mensual' = 0", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    dtgCre.Rows.RemoveAt(nFila);
                    dtCreditosDirectos.AcceptChanges();
                    actualizarCombosGridValue(dtgCre);
                    formatoGrid(dtgCre, 1);
                    bloquearEditarGrid(dtgCre);
                    if (eClickCargarDeudas != null)
                    {
                        eClickCargarDeudas(sender, e);
                    }
                }
            }
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgCreInd.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                int nFila = Convert.ToInt32(dtgCreInd.SelectedCells[0].RowIndex);
                if (Convert.ToBoolean(dtgCreInd.Rows[nFila].Cells["lCargaDeRcc"].Value))
                {
                    MessageBox.Show("No se puede eliminar un registro obtenido automáticamente, si la deuda ha sido cancelada ingrese como 'Saldo Actual' = 0 y 'Cuota Mensual' = 0", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    dtgCreInd.Rows.RemoveAt(nFila);
                    dtCreditosIndirectos.AcceptChanges();
                    actualizarCombosGridValue(dtgCreInd);
                    formatoGrid(dtgCreInd, 2);
                    bloquearEditarGrid(dtgCreInd);
                    if (eClickCargarDeudas != null)
                    {
                        eClickCargarDeudas(sender, e);  
                    }
                }

            }
        }

        private void dtgCre_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            currentCellDirty(dtgCre);
        }

        private void dtgCre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCre.RowCount > 0)
            {
                if (dtgCre.Columns[e.ColumnIndex].Name == "cboDeudaCA" && Convert.ToInt32(dtgCre.Rows[e.RowIndex].Cells["cboDeudaCA"].Value) != 1)
                {
                    validarCompraAmpliacion(dtgCre.Rows[e.RowIndex]);
                }
                else if (dtgCre.Columns[e.ColumnIndex].Name == "cboDeudaCA" && Convert.ToInt32(dtgCre.Rows[e.RowIndex].Cells["cboDeudaCA"].Value) == 1)
                {
                    // dtgCre.Rows[e.RowIndex].Cells["nCuotaMensual"].Value = 0.00M;
                    dtgCre.Rows[e.RowIndex].Cells["nCuotaMensual"].ReadOnly = false;
                    dtgCre.Rows[e.RowIndex].Cells["nCuotaMensual"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    dtgCre.Rows[e.RowIndex].Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void btnCargarDeudaRcc_Click(object sender, EventArgs e)
        {
            this.lCargaFormFirst = true;
            this.Cursor = Cursors.WaitCursor;
            cargarDeudaRcc();
            this.Cursor = Cursors.Default;
            this.lEstadoCargaDeuda = true;

            if (eClickCargarDeudas != null)
            {
                eClickCargarDeudas(sender, e);
            }
        }

        private void btnAgregaTarjetaCre_Click(object sender, EventArgs e)
        {
            cargarNuevaFila(dtgCre, dtCreditosDirectos, 1);
            if (eClickCargarDeudas != null)
            {
                eClickCargarDeudas(sender, e);
            }
        }
        
        /// <summary>
        /// Obtener total de deuda indirecta provicionado de acuerdo a las variables declaradas en el sistema
        /// </summary>
        /// <returns>retorna un datatable con idMoneda y el monto en su moneda provisionado</returns>
        public DataTable obtenerTotalDeudaIndirectaProv()
        {
            DataTable dtTotalDeudaInd  = new DataTable();
            dtTotalDeudaInd.Columns.Add("idMoneda", typeof(int));
            dtTotalDeudaInd.Columns.Add("nMonto", typeof(decimal));

            DataRow dr1 = dtTotalDeudaInd.NewRow();
            dr1["idMoneda"]  = 1;
            dr1["nMonto"] = 0m;
            dtTotalDeudaInd.Rows.Add(dr1);
            DataRow dr2 = dtTotalDeudaInd.NewRow();
            dr2["idMoneda"] = 2;
            dr2["nMonto"] = 0m;
            dtTotalDeudaInd.Rows.Add(dr2);

            //validando tipo de cambio seteado
            //if (nTipoCambio == 0)
            //    return dtTotalDeudaInd;

            //obteniendo la suma de deudas en sus respectivas monedas
            
            foreach (DataGridViewRow item in dtgCreInd.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 1) //moneda soles
                {
                    dtTotalDeudaInd.Rows[0]["nMonto"] = Convert.ToDecimal(dtTotalDeudaInd.Rows[0]["nMonto"]) + Convert.ToDecimal(item.Cells["nSaldo"].Value);
                }
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 2) //moneda dolares
                {
                    dtTotalDeudaInd.Rows[1]["nMonto"] = Convert.ToDecimal(dtTotalDeudaInd.Rows[1]["nMonto"]) + Convert.ToDecimal(item.Cells["nSaldo"].Value);
                }
            }

            //obtener la provision de deudas 
            decimal nMontoLimite = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopProvEvalConsumo"]);
            decimal nMontoLimiteMA = decimal.Zero;

            foreach (DataRow item in dtTotalDeudaInd.Rows)
            {
                if (Convert.ToInt32(item["idMoneda"]) == 2)
                {
                    nMontoLimiteMA = (nTipoCambio != 0) ? nMontoLimite / nTipoCambio : nMontoLimite;
                }

                if (Convert.ToDecimal(item["nMonto"]) <= nMontoLimiteMA)
                {
                    item["nMonto"] = Convert.ToDecimal(item["nMonto"]) * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"]) / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoHasta"]);
                }
                else
                {
                    item["nMonto"] = Convert.ToDecimal(item["nMonto"]) * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"]) / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor"]);
                }
                
            }

            return dtTotalDeudaInd;
        }

        public DataTable obtenerCuotaDeudaDirecta()
        { 
            // variables
            decimal nMonto,
                    nCuotaMensual;
                    

            DataTable dtTotalCuota  = new DataTable();
            dtTotalCuota.Columns.Add("idMoneda", typeof(int));
            dtTotalCuota.Columns.Add("nMonto", typeof(decimal));

            DataRow dr1 = dtTotalCuota.NewRow();
            dr1["idMoneda"]  = 1;
            dr1["nMonto"] = 0m;
            dtTotalCuota.Rows.Add(dr1);
            DataRow dr2 = dtTotalCuota.NewRow();
            dr2["idMoneda"] = 2;
            dr2["nMonto"] = 0m;
            dtTotalCuota.Rows.Add(dr2);

            //obteniendo la suma de deudas en sus respectivas monedas

            dtgCre.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow item in dtgCre.Rows)
            {
                nMonto = (dtTotalCuota.Rows[0]["nMonto"] == DBNull.Value) ? 0 : Convert.ToDecimal(dtTotalCuota.Rows[0]["nMonto"]);
                nCuotaMensual = (item.Cells["nCuotaMensual"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(item.Cells["nCuotaMensual"].Value);

                if (Convert.ToInt32(item.Cells["cboDeudaCA"].Value) == 1) // Solo hay cuando la accion no es Compra de deuda o ampliación
                {
                    if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 1) //moneda soles
                    {
                        dtTotalCuota.Rows[0]["nMonto"] = nMonto + nCuotaMensual;
                    }
                    if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 2) //moneda dolares
                    {
                        dtTotalCuota.Rows[1]["nMonto"] = nMonto + nCuotaMensual;
                    }
                }
            }
            return dtTotalCuota;
        }

        public decimal obtenerTotalDeudaIndirectaProvSum()
        {
            decimal nMontoProvisionDeudaInd = decimal.Zero;
            decimal nMontoDeudaIndirecTotal = decimal.Zero;
            decimal nMontoDolaresTmp = decimal.Zero;

            foreach (DataGridViewRow item in dtgCreInd.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 1) //moneda soles
                {
                    nMontoDeudaIndirecTotal += Convert.ToDecimal(item.Cells["nSaldo"].Value);
                }
                else if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 2) //moneda dolares
                {
                    nMontoDolaresTmp = Convert.ToDecimal(item.Cells["nSaldo"].Value);
                    nMontoDeudaIndirecTotal += nMontoDolaresTmp * nTipoCambio;
                }
            }

            decimal nMontoLimite = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopProvEvalConsumo"]);

            if (nMontoDeudaIndirecTotal <= nMontoLimite)
            {
                nMontoProvisionDeudaInd = nMontoDeudaIndirecTotal * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"]) / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoHasta"]);
            }
            else
            {
                nMontoProvisionDeudaInd = nMontoDeudaIndirecTotal * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"]) / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor"]);
            }

            return nMontoProvisionDeudaInd;
        }

        public Decimal obtenerCuotaTotalOtrosCreditos()
        {
            Decimal nTotalCuota = 0.00m,
                    nCuotaMensual = 0.00m;
            int nTipoDeudaCA = 0;
            foreach (DataGridViewRow item in dtgCre.Rows)
            {
                nCuotaMensual = (item.Cells["nCuotaMensual"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(item.Cells["nCuotaMensual"].Value);
                nTipoDeudaCA = Convert.ToInt32(item.Cells["cboDeudaCA"].Value != null? item.Cells["cboDeudaCA"].Value : 1) ;
                if (nTipoDeudaCA == 1) // Solo hay cuando la accion no es Compra de deuda o ampliación, reprogramacion o refinanciamiento
                {
                    nTotalCuota += (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 1) ? nCuotaMensual :
                        (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 2) ? nCuotaMensual * nTipoCambio
                        : nCuotaMensual;
                }
            }

            return nTotalCuota;
        }

        public DataTable obtDeudasTotales()
        { 
            DataTable dtDeudas = dtCreditosDirectos.Clone();
            actualizandoDataTableConGrid(dtgCre, dtCreditosDirectos);
            actualizandoDataTableConGrid(dtgCreInd, dtCreditosIndirectos);
            
            //importando filas de creditos directos
            foreach (DataRow item in dtCreditosDirectos.Rows)
            {
                dtDeudas.ImportRow(item);
            }
            
            // importando filas de créditos indirectos
            foreach (DataRow item in dtCreditosIndirectos.Rows)
            {
                dtDeudas.ImportRow(item);
            }

            return dtDeudas;
        }

        public void actualizandoDataTableConGrid(DataGridView dtg, DataTable dt)
        {
            foreach (DataGridViewRow item in dtg.Rows)
            {
                dt.Rows[item.Index]["idMoneda"] = Convert.ToInt32(item.Cells["cboMoneda"].Value);
                dt.Rows[item.Index]["nDeudaCA"] = Convert.ToInt32(item.Cells["cboDeudaCA"].Value);
                dt.Rows[item.Index]["lUtilizada"] = Convert.ToBoolean(item.Cells["dgcboUtilizada"].Value);
                dt.Rows[item.Index]["idTipoInterv"] = Convert.ToInt32(item.Cells["dgcboTipoInterv"].Value);
            }
        }

        private void validarCompraAmpliacion(DataGridViewRow dtgRow)
        {
            if (Convert.ToInt32(dtgRow.Cells["idEntidadFin"].Value) == Convert.ToInt32(clsVarApl.dicVarGen["idInstFin"]))
            {
                if (Convert.ToInt32(dtgRow.Cells["cboDeudaCA"].Value) == 2)
                {
                    MessageBox.Show("No puede comprar deuda de la nuestra institución", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgCre.CellValueChanged -= dtgCre_CellValueChanged;
                    dtgRow.Cells["cboDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgRow.Cells["nDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgCre.CellValueChanged += dtgCre_CellValueChanged;
                    return;
                }
                else
                {
                    dtgRow.Cells["nCuotaMensual"].Value = 0.00M;
                    dtgRow.Cells["nCuotaMensual"].ReadOnly = true;
                    dtgRow.Cells["nCuotaMensual"].Style.BackColor = Color.White;
                    dtgRow.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
            }
            }
            else
            {
                if (Convert.ToInt32(dtgRow.Cells["cboDeudaCA"].Value) == 2)
                {
                    dtgRow.Cells["nCuotaMensual"].Value = 0.00M;
                    dtgRow.Cells["nCuotaMensual"].ReadOnly = true;
                    dtgRow.Cells["nCuotaMensual"].Style.BackColor = Color.White;
                    dtgRow.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
                }

                if (Convert.ToInt32(dtgRow.Cells["cboDeudaCA"].Value) == 3)
                {
                    MessageBox.Show("No puede ampliar deudas de otras instituciones", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgCre.CellValueChanged -= dtgCre_CellValueChanged;
                    dtgRow.Cells["cboDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgRow.Cells["nDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgCre.CellValueChanged += dtgCre_CellValueChanged;
                    return;
                }

                else if (Convert.ToInt32(dtgRow.Cells["cboDeudaCA"].Value) == 4)
                {
                    MessageBox.Show("No puede reprogramar deudas de otras instituciones", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgCre.CellValueChanged -= dtgCre_CellValueChanged;
                    dtgRow.Cells["cboDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgRow.Cells["nDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgCre.CellValueChanged += dtgCre_CellValueChanged;
                    return;
                }

                else if (Convert.ToInt32(dtgRow.Cells["cboDeudaCA"].Value) == 5)
                {
                    MessageBox.Show("No puede refinanciar deudas de otras instituciones", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgCre.CellValueChanged -= dtgCre_CellValueChanged;
                    dtgRow.Cells["cboDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgRow.Cells["nDeudaCA"].Value = 1; // retornando la deuda a normal
                    dtgCre.CellValueChanged += dtgCre_CellValueChanged;
                    return;
                }
                else
                {
                    dtgRow.Cells["nCuotaMensual"].Value = 0.00M;
                    dtgRow.Cells["nCuotaMensual"].ReadOnly = true;
                    dtgRow.Cells["nCuotaMensual"].Style.BackColor = Color.White;
                    dtgRow.Cells["nCuotaMensual"].Style.ForeColor = Color.Black;
            }
        }
        }

        #endregion

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            cargarNuevaFila(dtgCreInd, dtCreditosIndirectos, 2);
            if (eClickCargarDeudas != null)
            {
                eClickCargarDeudas(sender, e);
            }
        }

        private void dtgCreInd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCreInd.Columns[e.ColumnIndex].Name == "nSaldo")
            {
                if (dtgCreInd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
                {
                    MessageBox.Show("Campo vacio, se cancelará la edición");
                    dtgCreInd.CancelEdit();
                    
                }
            }

            if (dtgCreInd.Columns[e.ColumnIndex].Name == "cboMoneda")
            {
                if (dtgCreInd.Rows[e.RowIndex].Cells["cboMoneda"].Value != null)
                    dtgCreInd.Rows[e.RowIndex].Cells["idMoneda"].Value = dtgCreInd.Rows[e.RowIndex].Cells["cboMoneda"].Value;
                // return;
            }

            if (eCellEndEdit != null)
            {
                eCellEndEdit(sender, e);
            }
        }

        private void dtgCreInd_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            currentCellDirty(dtgCreInd);
        }

        private void currentCellDirty(DataGridView dtg)
        {
            // if (dtg.IsCurrentCellDirty)
            // {
            //     dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            // }
        }

        private void dtgCre_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCre.Columns[e.ColumnIndex].Name == "cboDeudaCA")
            {
                if(dtgCre.Rows[e.RowIndex].Cells["cboDeudaCA"].Value != null)
                    dtgCre.Rows[e.RowIndex].Cells["nDeudaCA"].Value = dtgCre.Rows[e.RowIndex].Cells["cboDeudaCA"].Value;
                // return;
            }

            if (dtgCre.Columns[e.ColumnIndex].Name == "cboMoneda")
            {
                if (dtgCre.Rows[e.RowIndex].Cells["cboMoneda"].Value != null)
                    dtgCre.Rows[e.RowIndex].Cells["idMoneda"].Value = dtgCre.Rows[e.RowIndex].Cells["cboMoneda"].Value;
                // return;
            }

            if (dtgCre.Columns[e.ColumnIndex].Name == "nCuotaMensual")
            {
                if (dtgCre.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
                {
                    MessageBox.Show("Campo vacio, se cancelará la edición");
                    dtgCre.CancelEdit(); 
                }
            }

            if (eCellEndEdit != null)
            {
                eCellEndEdit(sender, e);
            }
        }

        private void dtgCre_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ValidaActualizaDiseño();
        }

        public void ValidaActualizaDiseño()
        {
            if (lCargaFormFirst)
            {
            actualizarDiseño();
                lCargaFormFirst = false;
            }
        }

        public void CambiarEstadoLCargaFormFirst(bool lBol)
        {
            this.lCargaFormFirst = lBol;
        }

        private void dtg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nSaldo") ||
                dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nCuotaMensual") ||
                dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nNroCuotasPorPagar"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            // -- 
            if (dtg.CurrentCell.OwningColumn.Name.Equals("cboDeudaCA"))
            {
                cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    //cmbItem.DropDown -= new EventHandler(cboDeudaCA_DropDown);
                    cmbItem.DropDown += new EventHandler(cboDeudaCA_DropDown);
                }
            }
        }
        private void cboDeudaCA_DropDown(object sender, EventArgs e)
        {
            // if (string.IsNullOrEmpty(dtgCre.CurrentRow.Cells[""].FormattedValue.ToString()))
            //     return;
            // 
            
            if (Convert.ToInt32(dtgCre.CurrentRow.Cells["idEntidadFin"].Value) != Convert.ToInt32(clsVarApl.dicVarGen["idInstFin"]))
            {
                DataTable dtDeuda = new DataTable();
                dtDeuda.Columns.Add("idDeudaCA", typeof(int));
                dtDeuda.Columns.Add("cDeudaCA", typeof(string));


                dtDeuda.Rows.Add(1, "Normal");
                dtDeuda.Rows.Add(2, "Compra Deuda");

                cmbItem.DisplayMember = "cDeudaCA";
                cmbItem.ValueMember = "idDeudaCA";
                cmbItem.DataSource = dtDeuda;
            }
            else
            {
                DataTable dtDeuda = new DataTable();
                dtDeuda.Columns.Add("idDeudaCA", typeof(int));
                dtDeuda.Columns.Add("cDeudaCA", typeof(string));


                dtDeuda.Rows.Add(1, "Normal");
                dtDeuda.Rows.Add(2, "Compra Deuda");
                dtDeuda.Rows.Add(3, "Ampliación");
                dtDeuda.Rows.Add(4, "Reprogramación");
                dtDeuda.Rows.Add(5, "Refinanciamiento");

                cmbItem.DisplayMember = "cDeudaCA";
                cmbItem.ValueMember = "idDeudaCA";
                cmbItem.DataSource = dtDeuda;
            }

        }
        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dtgCre_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbItem != null)
            {
                cmbItem.DropDown -= new EventHandler(cboDeudaCA_DropDown);
            }
        }


    }
}

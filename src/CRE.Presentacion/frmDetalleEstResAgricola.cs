using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmDetalleEstResAgricola : frmBase
    {
        public bool lGuardado = false;

        public List<clsDetEstResEval> lstGastosFamiliares = new List<clsDetEstResEval>();
        public List<clsDetEstResEval> lstGastosOperativos = new List<clsDetEstResEval>();
        public List<clsDetEstResEval> lstOtrosEgresos = new List<clsDetEstResEval>();
        public List<clsDetEstResEval> lstOtrosIngresos = new List<clsDetEstResEval>();

        private List<clsDescripcionEval> lstDescripcionEval = new List<clsDescripcionEval>();
        private List<clsDescripcionEval> lstDescripcionGastosFamiliares = new List<clsDescripcionEval>();
        private List<clsDescripcionEval> lstDescripcionGastosOperativos = new List<clsDescripcionEval>();

        private BindingSource bindingGastosFamiliares= new BindingSource();
        private BindingSource bindingGastosOperativos = new BindingSource();
        private BindingSource bindingOtrosIngresos = new BindingSource();
        private BindingSource bindingOtrosEgresos = new BindingSource();

        private clsEvalCred objEvalCred;

        private DataTable dtMoneda;
        
        private bool lEditable = false;

        public frmDetalleEstResAgricola()
        {
            InitializeComponent();
        }

        public frmDetalleEstResAgricola(List<clsDescripcionEval> lstDescripcionEval, clsEvalCred objEvalCred, bool lEditable)
        {
            InitializeComponent();

            this.objEvalCred = objEvalCred;
            this.lstDescripcionEval = lstDescripcionEval;
            this.lEditable = lEditable;

            this.dtMoneda = Evaluacion.DataTableMoneda;

            this.cargarFormulario();
        }

        #region métodos públicos - gastos familiares
        private decimal nTotalMAGastosFamiliares()
        {
            return this.lstGastosFamiliares.Sum(x => x.nTotalMA);
        }
        #endregion

        #region métodos públicos - gastos operativos
        private decimal nTotalMAGastosOperativos()
        {
            return this.lstGastosOperativos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region métodos públicos - otros ingresos
        private decimal nTotalMAOtrosIngresos()
        {
            return this.lstOtrosIngresos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region métodos públicos - otros egresos
        private decimal nTotalMAOtrosEgresos()
        {
            return this.lstOtrosEgresos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region métodos privados
        private void cargarFormulario()
        {
            DataSet ds = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEval(this.objEvalCred.idEvalCred);

            List<clsDetEstResEval> listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;

            this.dtgGFamiliares.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGastosFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgGOperativos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGastosOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgOtrosIngresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosIngresos_DataBindingComplete);
            this.dtgOtrosIngresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgOtrosEgresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosEgresos_DataBindingComplete);
            this.dtgOtrosEgresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);

            this.lstGastosFamiliares = (from p in listDetEstResEval where p.idEEFF == EEFF.GastosFamiliares select p).ToList();
            this.lstGastosOperativos = (from p in listDetEstResEval where p.idEEFF == EEFF.GastosOperativos select p).ToList();
            this.lstOtrosIngresos = (from p in listDetEstResEval where p.idEEFF == EEFF.OtrosIngresos select p).ToList();
            this.lstOtrosEgresos = (from p in listDetEstResEval where p.idEEFF == EEFF.OtrosEgresos select p).ToList();

            this.lstDescripcionGastosFamiliares = this.lstDescripcionEval.Where(x => x.idTipoDescripcion == TipoDescripcion.GastosFamiliares).ToList();
            this.lstDescripcionGastosOperativos = this.lstDescripcionEval.Where(x => x.idTipoDescripcion == TipoDescripcion.GastosOperativos).ToList();

            this.bindingGastosFamiliares.DataSource = this.lstGastosFamiliares;
            this.dtgGFamiliares.DataSource = this.bindingGastosFamiliares;
            this.formatearGastosFamiliares();

            this.bindingGastosOperativos.DataSource = this.lstGastosOperativos;
            this.dtgGOperativos.DataSource = this.bindingGastosOperativos;
            this.formatearGastosOperativos();

            this.bindingOtrosEgresos.DataSource = this.lstOtrosEgresos;
            this.dtgOtrosEgresos.DataSource = this.bindingOtrosEgresos;
            this.formatearOtrosEgresos();

            this.bindingOtrosIngresos.DataSource = this.lstOtrosIngresos;
            this.dtgOtrosIngresos.DataSource = this.bindingOtrosIngresos;
            this.formatearOtrosIngresos();
            this.estilosOtrosIngresos();

            this.labelTotaldtgGFamiliares.Text = "Total " + Evaluacion.MonedaSimbolo ;
            this.labelTotaldtgGOperativos.Text = "Total " + Evaluacion.MonedaSimbolo;
            this.labelTotaldtgOtrosIngresos.Text = "Total " + Evaluacion.MonedaSimbolo;
            this.labelTotaldtgOtrosEgresos.Text = "Total " + Evaluacion.MonedaSimbolo;

            this.dtgGFamiliares.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGastosFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgGOperativos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGastosOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgOtrosIngresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosIngresos_DataBindingComplete);
            this.dtgOtrosIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgOtrosEgresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosEgresos_DataBindingComplete);
            this.dtgOtrosEgresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);

            if (this.lEditable)
            {
                this.btnEditar.Visible = true;
                this.btnGrabar.Visible = true;
                this.btnCancelar.Visible = true;
                this.accionFormulario(clsAcciones.VISTA);
            }
            else
            {
                this.btnEditar.Visible = false;
                this.btnGrabar.Visible = false;
                this.btnCancelar.Visible = false;
            }
        }

        private DataGridViewComboBoxColumn dgcboTipoMoneda()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = Evaluacion.DataTableMoneda;
            dgcboTipoMoneda.DisplayMember = "cCodSBS";
            dgcboTipoMoneda.ValueMember = "idMoneda";
            return dgcboTipoMoneda;
        }

        private DataGridViewComboBoxColumn dgcboFrecuencia()
        {
            DataGridViewComboBoxColumn dgcboFrecuencia = new DataGridViewComboBoxColumn();
            dgcboFrecuencia.DisplayStyleForCurrentCellOnly = true;
            dgcboFrecuencia.FlatStyle = FlatStyle.Popup;
            dgcboFrecuencia.Name = "dgcboFrecuencia";
            dgcboFrecuencia.DataPropertyName = "nFrecuencia";
            dgcboFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            dgcboFrecuencia.DisplayMember = "cFrecuencia";
            dgcboFrecuencia.ValueMember = "idFrecuencia";
            return dgcboFrecuencia;
        }

        private void agregarItemDtg(DataGridView dtg, List<clsDetEstResEval> lst, BindingSource binding, clsDetEstResEval objDetBalGenEval)
        {
            dtg.EndEdit();
            lst.Add(objDetBalGenEval);
            binding.ResetBindings(false);

            foreach (DataGridViewColumn column in dtg.Columns)
            {
                if (column.Visible)
                {
                    dtg.CurrentCell = dtg[column.Index, lst.Count - 1];
                    break;
                }
            }
        }

        private void quitarItemDtg(DataGridView dtg, List<clsDetEstResEval> lst, BindingSource binding)
        {
            if (dtg.RowCount == 0 || dtg.Enabled == false || dtg.SelectedCells.Count <= 0)
                return;

            int rowIndex = dtg.SelectedCells[0].RowIndex;
            lst.RemoveAt(rowIndex);
            binding.ResetBindings(false);

            dtg.CurrentCell = null;
        }

        private void accionFormulario(int nAccion)
        {
            if (nAccion == clsAcciones.VISTA)
            {
                this.panel1.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (nAccion == clsAcciones.EDITAR)
            {
                this.panel1.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private string xmlDetalleEstRes(List<clsDetEstResEval> listDetalleEstRes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetEstResEval", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));

            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));

            foreach (var detEstRes in listDetalleEstRes)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
                row["idEEFF"] = detEstRes.idEEFF;
                row["cDescripcion"] = detEstRes.cDescripcion;
                row["idDescripcion"] = detEstRes.idDescripcion;
                row["idMoneda"] = detEstRes.idMoneda;
                row["idUnidMedida"] = detEstRes.idUnidMedida;
                row["nCantidad"] = detEstRes.nCantidad;
                row["nPUnitario"] = detEstRes.nPUnitario;
                row["nTotal"] = detEstRes.nTotal;
                row["idMonedaMA"] = detEstRes.idMonedaMA;
                row["nTotalMA"] = detEstRes.nTotalMA;

                row["nFrecuencia"] = detEstRes.nFrecuencia;
                row["dMesVenta"] = detEstRes.dMesVenta;
                row["nMesVenta"] = detEstRes.nMesVenta;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
        }

        private void formatearColumna(DataGridViewColumn dtgc, string cCampo, int nIndex, int? nFillWeight)
        {
            dtgc.DisplayIndex = nIndex;
            dtgc.Visible = true;
            dtgc.FillWeight = nFillWeight ?? 100;
            switch (cCampo)
            {
                case "DESCRIPCION":
                    dtgc.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                    dtgc.HeaderText = "Descripción";
                    break;
                case "FRECUENCIA":
                    dtgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtgc.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                    dtgc.HeaderText = "Frecuencia";
                    break;
                case "MONEDA":
                    dtgc.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                    dtgc.HeaderText = "Mon";
                    break;
                case "PRECIO_UNITARIO":
                    dtgc.DefaultCellStyle.Format = "n2";
                    dtgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgc.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                    dtgc.HeaderText = "Total";
                    break;
                case "EVALUACION_ALTERNA":
                    dtgc.HeaderText = "...";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region métodos privados - gastos familiares
        private void formatearGastosFamiliares()
        {
            this.dtgGFamiliares.Columns.Add(this.dgcboTipoMoneda());
            this.dtgGFamiliares.Columns.Add(this.dgcboFrecuencia());

            foreach (DataGridViewColumn column in this.dtgGFamiliares.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.formatearColumna(dtgGFamiliares.Columns["cDescripcion"], "DESCRIPCION", 0, 150);
            this.formatearColumna(dtgGFamiliares.Columns["dgcboFrecuencia"], "FRECUENCIA", 1, 75);
            this.formatearColumna(dtgGFamiliares.Columns["dgcboTipoMoneda"], "MONEDA", 2, 25);
            this.formatearColumna(dtgGFamiliares.Columns["nPUnitario"], "PRECIO_UNITARIO", 3, 50);
        }
        #endregion

        #region métodos privados - gastos operativos
        private void formatearGastosOperativos()
        {
            this.dtgGOperativos.Columns.Add(this.dgcboTipoMoneda());
            this.dtgGOperativos.Columns.Add(this.dgcboFrecuencia());

            foreach (DataGridViewColumn column in this.dtgGOperativos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.formatearColumna(dtgGOperativos.Columns["cDescripcion"], "DESCRIPCION", 0, 200);
            this.formatearColumna(dtgGOperativos.Columns["dgcboFrecuencia"], "FRECUENCIA", 1, 75);
            this.formatearColumna(dtgGOperativos.Columns["dgcboTipoMoneda"], "MONEDA", 2, 25);
            this.formatearColumna(dtgGOperativos.Columns["nPUnitario"], "PRECIO_UNITARIO", 3, 50);
        }
        #endregion

        #region métodos privados - otros ingresos
        private void formatearOtrosIngresos()
        {
            this.dtgOtrosIngresos.Columns.Add(this.dgcboFrecuencia());
            this.dtgOtrosIngresos.Columns.Add(this.dgcboTipoMoneda());

            DataGridViewButtonColumn dgbtnEvalAlterna = new DataGridViewButtonColumn();
            dgbtnEvalAlterna.Name = "dgbtnEvalAlterna";
            dgbtnEvalAlterna.Text = "...";
            dgbtnEvalAlterna.UseColumnTextForButtonValue = true;
            this.dtgOtrosIngresos.Columns.Add(dgbtnEvalAlterna);

            foreach (DataGridViewColumn column in this.dtgOtrosIngresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.formatearColumna(dtgOtrosIngresos.Columns["cDescripcion"], "DESCRIPCION", 0, 150);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgcboFrecuencia"], "FRECUENCIA", 1, 75);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgcboTipoMoneda"], "MONEDA", 2, 25);
            this.formatearColumna(dtgOtrosIngresos.Columns["nPUnitario"], "PRECIO_UNITARIO", 3, 50);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgbtnEvalAlterna"], "EVALUACION_ALTERNA", 4, 20);
        }

        private void resetearFormatoOtrosIngresos()
        {
            this.formatearColumna(dtgOtrosIngresos.Columns["cDescripcion"], "DESCRIPCION", 0, 150);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgcboFrecuencia"], "FRECUENCIA", 1, 75);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgcboTipoMoneda"], "MONEDA", 2, 25);
            this.formatearColumna(dtgOtrosIngresos.Columns["nPUnitario"], "PRECIO_UNITARIO", 3, 50);
            this.formatearColumna(dtgOtrosIngresos.Columns["dgbtnEvalAlterna"], "EVALUACION_ALTERNA", 4, 20);
        }


        private void estilosOtrosIngresos()
        {
            int idEvalCredAlterna = 0;
            foreach (DataGridViewRow row in this.dtgOtrosIngresos.Rows)
            {
                idEvalCredAlterna = Convert.ToInt32(row.Cells["idEvalCredAlterna"].Value);

                if (idEvalCredAlterna > 0)
                {
                    row.Cells["nPUnitario"].Style.BackColor = System.Drawing.Color.White;
                    row.Cells["nPUnitario"].ReadOnly = true;
                }
                else
                {
                    row.Cells["nPUnitario"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    row.Cells["nPUnitario"].ReadOnly = false;
                }
            }
        }
        #endregion

        #region métodos privados - otros egresos
        private void formatearOtrosEgresos()
        {
            this.dtgOtrosEgresos.Columns.Add(this.dgcboTipoMoneda());
            this.dtgOtrosEgresos.Columns.Add(this.dgcboFrecuencia());

            foreach (DataGridViewColumn column in this.dtgOtrosEgresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.formatearColumna(dtgOtrosEgresos.Columns["cDescripcion"], "DESCRIPCION", 0, 150);
            this.formatearColumna(dtgOtrosEgresos.Columns["dgcboFrecuencia"], "FRECUENCIA", 1, 75);
            this.formatearColumna(dtgOtrosEgresos.Columns["dgcboTipoMoneda"], "MONEDA", 2, 25);
            this.formatearColumna(dtgOtrosEgresos.Columns["nPUnitario"], "PRECIO_UNITARIO", 3, 50);
        }
        #endregion

        #region eventos - gastos familiares
        private void dtgGastosFamiliares_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalGFamiliares.Text = this.nTotalMAGastosFamiliares().ToString("N2");
        }

        private void tsmAgregarGastosFamiliares_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgGFamiliares, this.lstGastosFamiliares, this.bindingGastosFamiliares, new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosFamiliares,
                idMonedaMA = this.objEvalCred.idMoneda,
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCantidad = 1,
                nFrecuencia = 1,
                dFechaInicio = this.objEvalCred.dFechaDesembolso,
            });
        }

        private void tsmQuitarGastosFamiliares_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgGFamiliares, this.lstGastosFamiliares, this.bindingGastosFamiliares);
            this.tsmQuitarGFam.Enabled = false;
        }

        private void dtgGastosFamiliares_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarGFam.Enabled = true;
        }
        #endregion

        #region eventos - gastos operativos
        private void dtgGastosOperativos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalGOperativos.Text = this.nTotalMAGastosOperativos().ToString("N2");
        }

        private void tsmAgregarGastosOperativos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgGOperativos, this.lstGastosOperativos, this.bindingGastosOperativos, new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosOperativos,
                idMonedaMA = this.objEvalCred.idMoneda,
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCantidad = 1,
                nFrecuencia = 1,
                dFechaInicio = this.objEvalCred.dFechaDesembolso,
            });
        }

        private void tsmQuitarGastosOperativos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgGOperativos, this.lstGastosOperativos, this.bindingGastosOperativos);
            this.tsmQuitarGOpe.Enabled = false;
        }

        private void dtgGastosOperativos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarGOpe.Enabled = true;
        }
        #endregion

        #region eventos - otros ingresos
        private void dtgOtrosIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtOtrosIngresos.Text = this.nTotalMAOtrosIngresos().ToString("N2");
            this.resetearFormatoOtrosIngresos();
            this.estilosOtrosIngresos();
        }

        private void tsmAgregarOtrosIngresos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgOtrosIngresos, this.lstOtrosIngresos, this.bindingOtrosIngresos, new clsDetEstResEval()
            {
                idEEFF = EEFF.OtrosIngresos,
                idMonedaMA = this.objEvalCred.idMoneda,
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCantidad = 1,
                nFrecuencia = 1,
                dFechaInicio = this.objEvalCred.dFechaDesembolso,
                idEvalCred = this.objEvalCred.idEvalCred,
            });
        }

        private void tsmQuitarOtrosIngresos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgOtrosIngresos, this.lstOtrosIngresos, this.bindingOtrosIngresos);
            this.tsmQuitarOIng.Enabled = false;
        }

        private void dtgOtrosIngresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarOIng.Enabled = true;
        }

        private void dtgOtrosIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dtg = ((DataGridView)sender);

            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgbtnEvalAlterna"))
            {
                if (String.IsNullOrWhiteSpace(this.lstOtrosIngresos[e.RowIndex].cDescripcion))
                {
                    MessageBox.Show("Ingrese una descripción", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmEvalAlterna frmEvalAlterna = new frmEvalAlterna(this.lstOtrosIngresos[e.RowIndex]);
                frmEvalAlterna.ShowDialog();

                clsDetEstResEval objDetEstResEval = frmEvalAlterna.OtroIngreso();

                this.lstOtrosIngresos[e.RowIndex].idDetEstResEval = objDetEstResEval.idDetEstResEval;
                this.lstOtrosIngresos[e.RowIndex].nPUnitario = objDetEstResEval.nPUnitario;
                this.lstOtrosIngresos[e.RowIndex].idEvalCredAlterna = objDetEstResEval.idEvalCredAlterna;

                frmEvalAlterna.Dispose();

                this.bindingOtrosIngresos.ResetBindings(false);
            }
        }
        #endregion

        #region eventos - otros egresos
        private void dtgOtrosEgresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtOtrosEgresos.Text = this.nTotalMAOtrosEgresos().ToString("N2");
        }

        private void tsmAgregarOtrosEgresos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgOtrosEgresos, this.lstOtrosEgresos, this.bindingOtrosEgresos, new clsDetEstResEval()
            {
                idEEFF = EEFF.OtrosEgresos,
                idMonedaMA = this.objEvalCred.idMoneda,
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCantidad = 1,
                nFrecuencia = 1,
                dFechaInicio = this.objEvalCred.dFechaDesembolso,
            });
        }

        private void tsmQuitarOtrosEgresos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgOtrosEgresos, this.lstOtrosEgresos, this.bindingOtrosEgresos);
            this.tsmQuitarOEgr.Enabled = false;
        }

        private void dtgOtrosEgresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarOEgr.Enabled = true;
        }
        #endregion

        #region eventos
        private void dtg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nCantidad"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEntero);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }
        }

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Column_KeyPressEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<clsDetEstResEval> lstDetalleEstRes = new List<clsDetEstResEval>();

            lstDetalleEstRes.AddRange(this.lstGastosFamiliares);
            lstDetalleEstRes.AddRange(this.lstGastosOperativos);
            lstDetalleEstRes.AddRange(this.lstOtrosEgresos);
            lstDetalleEstRes.AddRange(this.lstOtrosIngresos);

            foreach (clsDetEstResEval obj in lstDetalleEstRes)
            {
                if (string.IsNullOrEmpty(obj.cDescripcion) || string.IsNullOrEmpty(obj.cDescripcion.Trim()))
                {
                    MessageBox.Show("Debe agregar una descripción a los items", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string xmlDetalleEstRes = this.xmlDetalleEstRes(lstDetalleEstRes);
            string xmlDetalleVenCos = clsUtils.ConvertToXML(new DataTable(), "VentasCostos", "Item");
            string xmlDetalleCosteo = clsUtils.ConvertToXML(new DataTable(), "Costeo", "Item");
            string xmlDetalleVarFCaja = clsUtils.ConvertToXML(new DataTable(), "VarFlujoCajaEval", "Item");

            (new clsCNEvalPyme()).ActDetalleEstadosResultadoslEval(this.objEvalCred.idEvalCred, xmlDetalleEstRes, xmlDetalleVenCos, xmlDetalleCosteo, xmlDetalleVarFCaja);

            this.lGuardado = true;
            this.cargarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.accionFormulario(clsAcciones.EDITAR);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cargarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalleEstResAgricola_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }
        #endregion
    }
}

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
    public partial class frmDetalleBalGenAgricola : frmBase
    {
        private clsEvalCred objEvalCred;
        public List<clsDetBalGenEval> lstInventario;
        public List<clsDetBalGenEval> lstActivosBiologicos;
        public List<clsDetBalGenEval> lstMaquinariasEquipos;
        public List<clsDetBalGenEval> lstInmuebles;
        public List<clsDetBalGenEval> lstVehiculos;

        public bool lGuardado = false;

        private DataTable dtTiposInventario;
        private DataTable dtUnidadesMedida;

        private BindingSource bindingInventario = new BindingSource();
        private BindingSource bindingActivosBiologicos = new BindingSource();
        private BindingSource bindingMaquinariasEquipos = new BindingSource();
        private BindingSource bindingInmuebles = new BindingSource();
        private BindingSource bindingVehiculos = new BindingSource();

        private bool lEditable = false;

        public frmDetalleBalGenAgricola(clsEvalCred objEvalCred, bool lEditable)
        {
            InitializeComponent();

            this.objEvalCred = objEvalCred;
            this.lEditable = lEditable;
            this.lstInventario = new List<clsDetBalGenEval>();
            this.lstActivosBiologicos = new List<clsDetBalGenEval>();
            this.lstMaquinariasEquipos = new List<clsDetBalGenEval>();
            this.lstInmuebles = new List<clsDetBalGenEval>();
            this.lstVehiculos = new List<clsDetBalGenEval>();

            this.cargarFormulario();
        }

        #region metodos privados
        private void cargarFormulario()
        {
            this.dtgInventario.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInventario_DataBindingComplete);
            this.dtgInventario.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgActivosBiologicos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInmuebles_DataBindingComplete);
            this.dtgActivosBiologicos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgMaquinariasEquipos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaquinariasEquipos_DataBindingComplete);
            this.dtgMaquinariasEquipos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgInmuebles.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInmuebles_DataBindingComplete);
            this.dtgInmuebles.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgVehiculos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgVehiculos_DataBindingComplete);
            this.dtgVehiculos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);

            DataSet ds = (new clsCNEvalPyme()).RecuperarDetalleBalGeneralEval(this.objEvalCred.idEvalCred);
            List<clsDetBalGenEval> lstDetBalGenEval = DataTableToList.ConvertTo<clsDetBalGenEval>(ds.Tables[0]) as List<clsDetBalGenEval>;
            this.dtTiposInventario = ds.Tables[2].AsEnumerable().Where(
                item => item.Field<int>("nCodigo") == 4 || item.Field<int>("nCodigo") == 5 || item.Field<int>("nCodigo") == 6
            ).CopyToDataTable();
            this.dtUnidadesMedida = ds.Tables[3];

            this.lstInventario = (
                from elem in lstDetBalGenEval where elem.idEEFF == EEFF.Insumos || elem.idEEFF == EEFF.ProductosProceso || elem.idEEFF == EEFF.ProductosTerminado select elem
            ).ToList();
            this.bindingInventario.DataSource = this.lstInventario;
            this.dtgInventario.DataSource = this.bindingInventario;
            formatearDtgInvetario();
            
            this.lstActivosBiologicos = (from elem in lstDetBalGenEval where elem.idEEFF == EEFF.ActBiologico select elem).ToList();
            this.bindingActivosBiologicos.DataSource = this.lstActivosBiologicos;
            this.dtgActivosBiologicos.DataSource = this.bindingActivosBiologicos;
            formatearDtgActivosBiologicos();

            this.lstMaquinariasEquipos = (from elem in lstDetBalGenEval where elem.idEEFF == EEFF.MaqEquipos select elem).ToList();
            this.bindingMaquinariasEquipos.DataSource = this.lstMaquinariasEquipos;
            this.dtgMaquinariasEquipos.DataSource = this.bindingMaquinariasEquipos;
            formatearDtgMaquinariasEquipos();

            this.lstInmuebles = (from elem in lstDetBalGenEval where elem.idEEFF == EEFF.Inmuebles select elem).ToList();
            this.bindingInmuebles.DataSource = this.lstInmuebles;
            this.dtgInmuebles.DataSource = this.bindingInmuebles;
            formatearDtgInmuebles();

            this.lstVehiculos = (from elem in lstDetBalGenEval where elem.idEEFF == EEFF.Vehiculos select elem).ToList();
            this.bindingVehiculos.DataSource = this.lstVehiculos;
            this.dtgVehiculos.DataSource = this.bindingVehiculos;
            formatearDtgVehiculos();

            this.dtgInventario.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInventario_DataBindingComplete);
            this.dtgInventario.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgActivosBiologicos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgActivosBiologicos_DataBindingComplete);
            this.dtgActivosBiologicos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgMaquinariasEquipos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaquinariasEquipos_DataBindingComplete);
            this.dtgMaquinariasEquipos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgInmuebles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInmuebles_DataBindingComplete);
            this.dtgInmuebles.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgVehiculos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgVehiculos_DataBindingComplete);
            this.dtgVehiculos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);

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

        private void formatearDtg(DataGridView dtg)
        {
            dtg.Columns.Add(this.dgcboTipoMoneda());

            foreach (DataGridViewColumn column in dtg.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtg.Columns["cDescripcion"].DisplayIndex = 0;
            dtg.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtg.Columns["cUnidMedida"].DisplayIndex = 2;
            dtg.Columns["nCantidad"].DisplayIndex = 3;
            dtg.Columns["nPUnitario"].DisplayIndex = 4;
            dtg.Columns["nTotal"].DisplayIndex = 5;

            dtg.Columns["cDescripcion"].Visible = true;
            dtg.Columns["nPUnitario"].Visible = true;
            dtg.Columns["nCantidad"].Visible = true;
            dtg.Columns["dgcboTipoMoneda"].Visible = true;
            dtg.Columns["cUnidMedida"].Visible = true;
            dtg.Columns["nTotal"].Visible = true;

            dtg.Columns["cDescripcion"].HeaderText = "Descripción";
            dtg.Columns["nPUnitario"].HeaderText = "P/Unitario";
            dtg.Columns["nCantidad"].HeaderText = "Cantidad";
            dtg.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtg.Columns["cUnidMedida"].HeaderText = "Unidad";
            dtg.Columns["nTotal"].HeaderText = "Total";

            dtg.Columns["cDescripcion"].FillWeight = 110;
            dtg.Columns["nPUnitario"].FillWeight = 40;
            dtg.Columns["nCantidad"].FillWeight = 37;
            dtg.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtg.Columns["cUnidMedida"].FillWeight = 50;
            dtg.Columns["nTotal"].FillWeight = 50;

            dtg.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.Columns["cUnidMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtg.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtg.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtg.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtg.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["cUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["nTotal"].ReadOnly = true;
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

        private DataGridViewComboBoxColumn dgcboUnidadMedida()
        {
            DataGridViewComboBoxColumn dgcboUnidadMedida = new DataGridViewComboBoxColumn();
            dgcboUnidadMedida.DisplayStyleForCurrentCellOnly = true;
            dgcboUnidadMedida.FlatStyle = FlatStyle.Popup;
            dgcboUnidadMedida.DropDownWidth = 250;
            dgcboUnidadMedida.Name = "dgcboUnidadMedida";
            dgcboUnidadMedida.DataPropertyName = "idUnidMedida";
            dgcboUnidadMedida.DataSource = this.dtUnidadesMedida;
            dgcboUnidadMedida.DisplayMember = "cUnidadMedida";
            dgcboUnidadMedida.ValueMember = "idUnidadMedida";
            return dgcboUnidadMedida;
        }

        private void agregarItemDtg(DataGridView dtg, List<clsDetBalGenEval> lst, BindingSource binding, clsDetBalGenEval objDetBalGenEval)
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

        private void quitarItemDtg(DataGridView dtg, List<clsDetBalGenEval> lst, BindingSource binding)
        {
            if (dtg.RowCount == 0 || dtg.Enabled == false || dtg.SelectedCells.Count <= 0)
                return;

            int rowIndex = dtg.SelectedCells[0].RowIndex;
            lst.RemoveAt(rowIndex);
            binding.ResetBindings(false);

            dtg.CurrentCell = null;
        }

        private string cDetalleBalGenXML(List<clsDetBalGenEval> listDetalleBalGen)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetBalGenEval", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("cUnidMedida", typeof(string));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nCodigoInv", typeof(int));

            foreach (var detBalGen in listDetalleBalGen)
            {
                DataRow row = dt.NewRow();

                row["idDetBalGenEval"] = detBalGen.idDetBalGenEval;
                row["idEEFF"] = detBalGen.idEEFF;
                row["cDescripcion"] = detBalGen.cDescripcion;
                row["idDescripcion"] = detBalGen.idDescripcion;
                row["idMoneda"] = detBalGen.idMoneda;
                row["idUnidMedida"] = detBalGen.idUnidMedida;
                row["cUnidMedida"] = detBalGen.cUnidMedida;
                row["nCantidad"] = detBalGen.nCantidad;
                row["nPUnitario"] = detBalGen.nPUnitario;
                row["nTotal"] = detBalGen.nTotal;
                row["idMonedaMA"] = detBalGen.idMonedaMA;
                row["nTotalMA"] = detBalGen.nTotalMA;
                row["nCodigoInv"] = detBalGen.nCodigoInv;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetBalGenEval", "Item");
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
        #endregion

        #region metodos publicos - inventario
        public decimal nTotalMAInsumos()
        {
            return this.lstInventario.Where(x => x.nCodigoInv == TipoInventario.InsumosMateriasPrimas).Sum(x => x.nTotalMA);
        }

        public decimal nTotalMAProductosProceso()
        {
            return this.lstInventario.Where(x => x.nCodigoInv == TipoInventario.ProductosProceso).Sum(x => x.nTotalMA);
        }

        public decimal nTotalMAProductosTerminado()
        {
            return this.lstInventario.Where(x => x.nCodigoInv == TipoInventario.ProductosTerminados).Sum(x => x.nTotalMA);
        }

        public decimal nTotalMAInventario()
        {
            return this.lstInventario.Sum(x => x.nTotalMA);
        }
        #endregion

        #region metodos publicos - activos biologicos
        public decimal nTotalMAActivosBiologicos()
        {
            return this.lstActivosBiologicos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region metodos publicos - maquinarias y equipos
        public decimal nTotalMAMaquinariasEquipos()
        {
            return this.lstMaquinariasEquipos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region metodos publicos - inmuebles
        public decimal nTotalMAInmuebles()
        {
            return this.lstInmuebles.Sum(x => x.nTotalMA);
        }
        #endregion

        #region metodos publicos - vehiculos
        public decimal nTotalMAVehiculos()
        {
            return this.lstVehiculos.Sum(x => x.nTotalMA);
        }
        #endregion

        #region metodos privados - inventario
        private void formatearDtgInvetario()
        {
            this.dtgInventario.Columns.Add(this.dgcboTipoMoneda());

            DataGridViewComboBoxColumn dgcboTipoInventario = new DataGridViewComboBoxColumn();
            dgcboTipoInventario.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoInventario.FlatStyle = FlatStyle.Popup;
            dgcboTipoInventario.DropDownWidth = 250;
            dgcboTipoInventario.Name = "dgcboTipoInventario";
            dgcboTipoInventario.DataPropertyName = "nCodigoInv";
            dgcboTipoInventario.DataSource = this.dtTiposInventario;
            dgcboTipoInventario.DisplayMember = "cDescripcion";
            dgcboTipoInventario.ValueMember = "nCodigo";
            this.dtgInventario.Columns.Add(dgcboTipoInventario);

            //this.dtgInventario.Columns.Add(this.dgcboUnidadMedida());

            foreach (DataGridViewColumn column in this.dtgInventario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgInventario.Columns["dgcboTipoInventario"].DisplayIndex = 0;
            dtgInventario.Columns["cDescripcion"].DisplayIndex = 1;
            dtgInventario.Columns["dgcboTipoMoneda"].DisplayIndex = 2;
            dtgInventario.Columns["cUnidMedida"].DisplayIndex = 3;
            dtgInventario.Columns["nCantidad"].DisplayIndex = 4;
            dtgInventario.Columns["nPUnitario"].DisplayIndex = 5;
            dtgInventario.Columns["nTotal"].DisplayIndex = 6;

            dtgInventario.Columns["dgcboTipoInventario"].Visible = true;
            dtgInventario.Columns["cDescripcion"].Visible = true;
            dtgInventario.Columns["cUnidMedida"].Visible = true;
            dtgInventario.Columns["nPUnitario"].Visible = true;
            dtgInventario.Columns["nCantidad"].Visible = true;
            dtgInventario.Columns["dgcboTipoMoneda"].Visible = true;
            dtgInventario.Columns["nTotal"].Visible = true;

            dtgInventario.Columns["dgcboTipoInventario"].HeaderText = "Tipo Inventario";
            dtgInventario.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgInventario.Columns["cUnidMedida"].HeaderText = "Unidad";
            dtgInventario.Columns["nPUnitario"].HeaderText = "P/Unitario";
            dtgInventario.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgInventario.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgInventario.Columns["nTotal"].HeaderText = "Total";

            dtgInventario.Columns["dgcboTipoInventario"].FillWeight = 60;
            dtgInventario.Columns["cDescripcion"].FillWeight = 100;
            dtgInventario.Columns["cUnidMedida"].FillWeight = 40;
            dtgInventario.Columns["nPUnitario"].FillWeight = 40;
            dtgInventario.Columns["nCantidad"].FillWeight = 37;
            dtgInventario.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgInventario.Columns["nTotal"].FillWeight = 50;

            dtgInventario.Columns["cUnidMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgInventario.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgInventario.Columns["dgcboTipoInventario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["cUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgInventario.Columns["nTotal"].ReadOnly = true;
        }
        #endregion

        #region metodos privados - activos biologicos
        private void formatearDtgActivosBiologicos()
        {
            this.formatearDtg(this.dtgActivosBiologicos);
        }
        #endregion

        #region metodos privados - maquinarias y equipos
        private void formatearDtgMaquinariasEquipos()
        {
            this.formatearDtg(this.dtgMaquinariasEquipos);
        }
        #endregion

        #region metodos privados - inmuebles
        private void formatearDtgInmuebles()
        {
            this.formatearDtg(this.dtgInmuebles);
        }
        #endregion

        #region metodos privados - vehiculos
        private void formatearDtgVehiculos()
        {
            this.formatearDtg(this.dtgVehiculos);
        }
        #endregion

        #region eventos - inventario
        private void dtgInventario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalInventario.Text = this.nTotalMAInventario().ToString("N2");
        }

        private void tsmAgregarInventario_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgInventario, this.lstInventario, this.bindingInventario, new clsDetBalGenEval()
            {
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCodigoInv = TipoInventario.InsumosMateriasPrimas,
            });
        }

        private void tsmQuitarInventario_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgInventario, this.lstInventario, this.bindingInventario);
            this.tsmQuitarInventario.Enabled = false;
        }

        private void dtgInventario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarInventario.Enabled = true;
        }
        #endregion

        #region eventos - activos biologicos
        private void dtgActivosBiologicos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalActivosBiologicos.Text = this.nTotalMAActivosBiologicos().ToString("N2");
        }

        private void tsmAgregarActivosBiologicos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgActivosBiologicos, this.lstActivosBiologicos, this.bindingActivosBiologicos, new clsDetBalGenEval()
            {
                idEEFF = EEFF.ActBiologico,                
                nTipoCambio = this.objEvalCred.nTipoCambio,
            });
        }

        private void tsmQuitarActivosBiologicos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgActivosBiologicos, this.lstActivosBiologicos, this.bindingActivosBiologicos);
            this.tsmQuitarActivo.Enabled = false;
        }

        private void dtgActivosBiologicos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarActivo.Enabled = true;
        }
        #endregion

        #region eventos - maquinarias y equipos
        private void dtgMaquinariasEquipos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalMaquinariasEquipos.Text = this.nTotalMAMaquinariasEquipos().ToString("N2");
        }

        private void tsmAgregarMaquinariasEquipos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgMaquinariasEquipos, this.lstMaquinariasEquipos, this.bindingMaquinariasEquipos, new clsDetBalGenEval()
            {
                idEEFF = EEFF.MaqEquipos,                
                nTipoCambio = this.objEvalCred.nTipoCambio,
            });
        }

        private void tsmQuitarMaquinariasEquipos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgMaquinariasEquipos, this.lstMaquinariasEquipos, this.bindingMaquinariasEquipos);
            this.tsmQuitarMaquinaria.Enabled = false;
        }

        private void dtgMaquinariasEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarMaquinaria.Enabled = true;
        }
        #endregion

        #region eventos - inmuebles
        private void dtgInmuebles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalInmuebles.Text = this.nTotalMAInmuebles().ToString("N2");
        }

        private void tsmAgregarInmuebles_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgInmuebles, this.lstInmuebles, this.bindingInmuebles, new clsDetBalGenEval()
            {
                idEEFF = EEFF.Inmuebles,                
                nTipoCambio = this.objEvalCred.nTipoCambio,
                nCantidad = 1,
                cUnidMedida = ""
            });
        }

        private void tsmQuitarInmuebles_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgInmuebles, this.lstInmuebles, this.bindingInmuebles);
            this.tsmQuitarInmueble.Enabled = false;
        }

        private void dtgInmuebles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarInmueble.Enabled = true;
        }
        #endregion

        #region eventos - vehiculos
        private void dtgVehiculos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.txtTotalVehiculos.Text = this.nTotalMAVehiculos().ToString("N2");
        }

        private void tsmAgregarVehiculos_Click(object sender, EventArgs e)
        {
            this.agregarItemDtg(this.dtgVehiculos, this.lstVehiculos, this.bindingVehiculos, new clsDetBalGenEval()
            {
                idEEFF = EEFF.Vehiculos,                
                nTipoCambio = this.objEvalCred.nTipoCambio,
            });
        }

        private void tsmQuitarVehiculos_Click(object sender, EventArgs e)
        {
            this.quitarItemDtg(this.dtgVehiculos, this.lstVehiculos, this.bindingVehiculos);
            this.tsmQuitarVehiculo.Enabled = false;
        }

        private void dtgVehiculos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitarVehiculo.Enabled = true;
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
            foreach (clsDetBalGenEval obj in this.lstInventario)
            {
                if (obj.nCodigoInv == TipoInventario.InsumosMateriasPrimas) obj.idEEFF = EEFF.Insumos;
                else if (obj.nCodigoInv == TipoInventario.ProductosProceso) obj.idEEFF = EEFF.ProductosProceso;
                else if (obj.nCodigoInv == TipoInventario.ProductosTerminados) obj.idEEFF = EEFF.ProductosTerminado;
            }

            List<clsDetBalGenEval> lstDetBalGenEval = new List<clsDetBalGenEval>();
            lstDetBalGenEval.AddRange(lstInventario);
            lstDetBalGenEval.AddRange(lstActivosBiologicos);
            lstDetBalGenEval.AddRange(lstMaquinariasEquipos);
            lstDetBalGenEval.AddRange(lstInmuebles);
            lstDetBalGenEval.AddRange(lstVehiculos);

            foreach (clsDetBalGenEval obj in lstDetBalGenEval)
            {
                if (string.IsNullOrEmpty(obj.cDescripcion) || string.IsNullOrEmpty(obj.cDescripcion.Trim()))
                {
                    MessageBox.Show("Debe agregar una descripción a los items", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            (new clsCNEvalPyme()).ActDetalleBalanceGeneralEval(this.objEvalCred.idEvalCred, 0, this.cDetalleBalGenXML(lstDetBalGenEval));
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

        private void frmDetalleBalGenAgricola_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }
        #endregion
    }
}

using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;
using System.Reflection;
using GEN.BotonesBase;

namespace GEN.ControlesBase
{
    public partial class ConEgresosEstacionales : UserControl
    {
        #region Variables

        private List<clsProyeccionIngresos> listaProyeccionIngresos;
        private List<clsEgresosEstacionales> listaEgresosEstacionales;
        private List<clsPeriodoCuotas> listaPeriodos;

        private BindingSource bsIngresosEstacionales;
        private BindingSource bsEgresosEstacionales;

        private int nCuotas;
        private DateTime dFechaDesembolso;

        #endregion


        #region Metodos Publicos

        public ConEgresosEstacionales()
        {
            InitializeComponent();
        }

        public void inicializarControl(int _cuotas, DateTime _fechaDesembolso)
        {
            this.listaPeriodos = new List<clsPeriodoCuotas>();
            this.listaProyeccionIngresos = new List<clsProyeccionIngresos>();
            this.listaEgresosEstacionales = new List<clsEgresosEstacionales>();

            this.nCuotas = _cuotas;
            this.dFechaDesembolso = _fechaDesembolso;

            ObtenerLisPeriodos();
            AgregarComboBoxFechaDataGridViewEgresosEstacionales();
            InicializaTablaIngresosEstacionales();
            InicializaTablaEgresosEstacionales();
            FormatearDataGridView();
        }

        public void AsignarDatos(List<clsProyeccionIngresos> _lstIngresosEstacionales, List<clsEgresosEstacionales> _lstEgresosEstacionales)
        {
            this.dtgvEgresosEstacionales.SelectionChanged -= new System.EventHandler(this.dtgvEgresosEstacionales_SelectionChanged);
            this.dtgvIngresosEstacionales.SelectionChanged -= new System.EventHandler(this.dtgvIngresosEstacionales_SelectionChanged);
            this.dtgvEgresosEstacionales.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvEgresosEstacionales_EditingControlShowing);

            this.listaProyeccionIngresos.Clear();
            this.listaEgresosEstacionales.Clear();

            foreach (var item in _lstIngresosEstacionales)
            {
                this.listaProyeccionIngresos.Add(item);
            }

            foreach (var item in _lstEgresosEstacionales)
            {
                item.nFecha = listaPeriodos.FirstOrDefault(x => x.nFecha == item.nFecha) != null ? item.nFecha : listaPeriodos[1].nFecha;
                this.listaEgresosEstacionales.Add(item);
            }

            this.bsIngresosEstacionales.ResetBindings(false);

            this.bsEgresosEstacionales.ResetBindings(false);

            this.dtgvEgresosEstacionales.SelectionChanged += new System.EventHandler(this.dtgvEgresosEstacionales_SelectionChanged);
            this.dtgvIngresosEstacionales.SelectionChanged += new System.EventHandler(this.dtgvIngresosEstacionales_SelectionChanged);
            this.dtgvEgresosEstacionales.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvEgresosEstacionales_EditingControlShowing);
        }

        public void AgregarComboBoxFechaDataGridViewEgresosEstacionales()
        {
            DataGridViewComboBoxColumn fechaColumn = new DataGridViewComboBoxColumn();
            fechaColumn.DisplayStyleForCurrentCellOnly = true;
            fechaColumn.FlatStyle = FlatStyle.Popup;
            fechaColumn.Name = "cboFecha";
            fechaColumn.DataPropertyName = "nFecha";
            fechaColumn.DataSource = this.listaPeriodos;
            fechaColumn.DisplayMember = "cdescripcion";
            fechaColumn.ValueMember = "nFecha";

            this.dtgvEgresosEstacionales.Columns.Add(fechaColumn);

            if (this.listaEgresosEstacionales.Count <= 0)
                this.dtgvEgresosEstacionales.Columns["cboFecha"].Visible = false;
        }

        #endregion


        #region Métodos Privados

        private void InicializaTablaIngresosEstacionales()
        {
            this.bsIngresosEstacionales = new BindingSource();
            this.bsIngresosEstacionales.DataSource = this.listaProyeccionIngresos;
            this.dtgvIngresosEstacionales.DataSource = this.bsIngresosEstacionales;

            this.bsIngresosEstacionales.ResetBindings(false);
            this.dtgvIngresosEstacionales.Refresh();

            foreach (DataGridViewColumn column in this.dtgvIngresosEstacionales.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgvIngresosEstacionales.Columns["cCultivo"].Visible = true;
            this.dtgvIngresosEstacionales.Columns["cVariedad"].Visible = true;
            this.dtgvIngresosEstacionales.Columns["cParcela"].Visible = true;
            this.dtgvIngresosEstacionales.Columns["nExtension"].Visible = true;

            this.dtgvIngresosEstacionales.Columns["cCultivo"].HeaderText = "Cultivo";
            this.dtgvIngresosEstacionales.Columns["cVariedad"].HeaderText = "Variedad";
            this.dtgvIngresosEstacionales.Columns["cParcela"].HeaderText = "Parcela";
            this.dtgvIngresosEstacionales.Columns["nExtension"].HeaderText = "Extensión";

            this.dtgvIngresosEstacionales.Columns["cCultivo"].FillWeight = 50;
            this.dtgvIngresosEstacionales.Columns["cVariedad"].FillWeight = 50;
            this.dtgvIngresosEstacionales.Columns["cParcela"].FillWeight = 50;
            this.dtgvIngresosEstacionales.Columns["nExtension"].FillWeight = 50;
        }

        private void InicializaTablaEgresosEstacionales()
        {
            this.bsEgresosEstacionales = new BindingSource();
            this.bsEgresosEstacionales.DataSource = this.listaEgresosEstacionales;
            this.dtgvEgresosEstacionales.DataSource = this.bsEgresosEstacionales;

            this.bsEgresosEstacionales.ResetBindings(false);
            this.dtgvEgresosEstacionales.Refresh();
            
            dtgvEgresosEstacionales.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgvEgresosEstacionales.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgvEgresosEstacionales.Columns["idEgresoEstacional"].Visible = false;
            this.dtgvEgresosEstacionales.Columns["cNombreInsumo"].Visible = true;
            this.dtgvEgresosEstacionales.Columns["nExtension"].Visible = true;
            this.dtgvEgresosEstacionales.Columns["nCantidad"].Visible = true;
            this.dtgvEgresosEstacionales.Columns["nPrecio"].Visible = true;
            this.dtgvEgresosEstacionales.Columns["nGasto"].Visible = true;
            this.dtgvEgresosEstacionales.Columns["cboFecha"].Visible = true;


            this.dtgvEgresosEstacionales.Columns["cNombreInsumo"].HeaderText = "Insumo";
            this.dtgvEgresosEstacionales.Columns["nExtension"].HeaderText = "Extensión";
            this.dtgvEgresosEstacionales.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgvEgresosEstacionales.Columns["nPrecio"].HeaderText = "Precio";
            this.dtgvEgresosEstacionales.Columns["nGasto"].HeaderText = "Gasto";
            this.dtgvEgresosEstacionales.Columns["cboFecha"].HeaderText = "Fecha";

            dtgvEgresosEstacionales.Columns["cNombreInsumo"].DisplayIndex = 1;
            dtgvEgresosEstacionales.Columns["nExtension"].DisplayIndex = 2;
            dtgvEgresosEstacionales.Columns["nCantidad"].DisplayIndex = 3;
            dtgvEgresosEstacionales.Columns["nPrecio"].DisplayIndex = 4;
            dtgvEgresosEstacionales.Columns["nGasto"].DisplayIndex = 5;
            dtgvEgresosEstacionales.Columns["cboFecha"].DisplayIndex = 6;


            dtgvEgresosEstacionales.Columns["cNombreInsumo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvEgresosEstacionales.Columns["nExtension"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvEgresosEstacionales.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvEgresosEstacionales.Columns["nPrecio"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvEgresosEstacionales.Columns["cboFecha"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            this.dtgvEgresosEstacionales.Columns["nGasto"].ReadOnly = true;
        }

        private void FormatearDataGridView()
        {
            this.dtgvIngresosEstacionales.Margin = new System.Windows.Forms.Padding(0);
            this.dtgvIngresosEstacionales.MultiSelect = false;
            this.dtgvIngresosEstacionales.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvIngresosEstacionales.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvIngresosEstacionales.RowHeadersVisible = false;
            this.dtgvIngresosEstacionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dtgvEgresosEstacionales.Margin = new System.Windows.Forms.Padding(0);
            this.dtgvEgresosEstacionales.MultiSelect = false;
            this.dtgvEgresosEstacionales.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvEgresosEstacionales.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvEgresosEstacionales.RowHeadersVisible = false;
            this.dtgvEgresosEstacionales.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void CalcularTotalInsumos(Guid idIngresoEstacional)
        {
            var listaSumaGastos = this.listaEgresosEstacionales.Where(t => t.idIngresoEstacional == idIngresoEstacional).ToList();
            this.txtTotalInsumos.Text = listaSumaGastos.Sum(t => t.nGasto).ToString();
            this.txtTotalInsumos.Refresh();
        }

        public void ObtenerListaIngresos(List<clsProyeccionIngresos> listaProyeccionIngresos_)
        {
            List<clsEgresosEstacionales> nuevalistaEgrEst = new List<clsEgresosEstacionales>();

            if(this.listaProyeccionIngresos.Count != listaProyeccionIngresos_.Count)
            {
                foreach (var item in listaProyeccionIngresos_)
                {
                    List<clsEgresosEstacionales> lstEgrEst = new List<clsEgresosEstacionales>();
                    lstEgrEst = this.listaEgresosEstacionales.FindAll(x => x.idIngresoEstacional == item.idIngresoEstacional);
                    nuevalistaEgrEst.AddRange(lstEgrEst);
                }
                this.listaEgresosEstacionales = nuevalistaEgrEst;
            }

            this.listaProyeccionIngresos.Clear();

            foreach (var item in listaProyeccionIngresos_)
            {
                this.listaProyeccionIngresos.Add(item);
            }

            this.bsIngresosEstacionales.ResetBindings(false);
            this.dtgvIngresosEstacionales.Refresh();

            this.bsEgresosEstacionales.ResetBindings(false);
            this.dtgvEgresosEstacionales.Refresh();

            this.dtgvIngresosEstacionales.Columns["idIngresoEstacional"].Visible = false;
        }

        private void ObtenerLisPeriodos()
        {
            int nCuotas = Convert.ToInt32(clsVarApl.dicVarGen["nPlazoMaxEvalRural"]);

            clsPeriodoCuotas oPeriodoCuotas = new clsPeriodoCuotas();

            // Agregar opción Mensual al combo
            clsPeriodoCuotas oMensual = new clsPeriodoCuotas()
            {
                nFecha = 999999,
                cdescripcion = "Mensual"
            };

            this.listaPeriodos.Add(oMensual);

            for (int x = 0; x < nCuotas; x++)
            {
                DateTime dFechaTmp = this.dFechaDesembolso.AddMonths(x);
                oPeriodoCuotas = new clsPeriodoCuotas();
                oPeriodoCuotas.nFecha = Convert.ToInt32(dFechaTmp.ToString("yyyyMM"));
                oPeriodoCuotas.cdescripcion = dFechaTmp.ToString("MMM - yy");
                listaPeriodos.Add(oPeriodoCuotas);
            }

        }

        public List<clsEgresosEstacionales> ExportarListaEgresos(List<clsProyeccionIngresos> listaProyeccionIngresos_)
        {
            List<clsEgresosEstacionales> nuevalistaEgrEst = new List<clsEgresosEstacionales>();

            foreach (var item in listaProyeccionIngresos_)
            {
                List<clsEgresosEstacionales> lstEgrEst = new List<clsEgresosEstacionales>();
                lstEgrEst = this.listaEgresosEstacionales.FindAll(x => x.idIngresoEstacional == item.idIngresoEstacional);
                nuevalistaEgrEst.AddRange(lstEgrEst);
            }
            this.listaEgresosEstacionales = nuevalistaEgrEst;

            return nuevalistaEgrEst;
        }

        #endregion


        #region Eventos

        private void tsmAgregarEgresoEstacional_Click(object sender, EventArgs e)
        {
            this.dtgvEgresosEstacionales.SelectionChanged -= new System.EventHandler(this.dtgvEgresosEstacionales_SelectionChanged);

            this.listaEgresosEstacionales.Add(new clsEgresosEstacionales()
            {
                idEgresoEstacional = Guid.NewGuid(),
                cNombreInsumo = "",
                nExtension = 0,
                nCantidad = 0,
                nPrecio = 0,
                nFecha = this.listaPeriodos.FirstOrDefault().nFecha,
                idIngresoEstacional = (Guid)this.dtgvIngresosEstacionales.SelectedRows[0].Cells["idIngresoEstacional"].Value
            });

            var idIngresoEstacional = (Guid)this.dtgvIngresosEstacionales.SelectedRows[0].Cells["idIngresoEstacional"].Value;
            var oEgresoEstacional = this.listaEgresosEstacionales.FindAll(x => x.idIngresoEstacional == idIngresoEstacional);
            this.bsEgresosEstacionales.DataSource = oEgresoEstacional;
            this.bsEgresosEstacionales.ResetBindings(false);
            this.dtgvEgresosEstacionales.Refresh();
            this.dtgvEgresosEstacionales.DataSource = this.bsEgresosEstacionales;

            this.tsmQuitarInsumo.Enabled = (this.dtgvEgresosEstacionales.RowCount > 0);
            this.dtgvEgresosEstacionales.SelectionChanged += new System.EventHandler(this.dtgvEgresosEstacionales_SelectionChanged);
        }

        private void tsmQuitarInsumo_Click(object sender, EventArgs e)
        {
            if (this.dtgvEgresosEstacionales.RowCount == 0 || this.dtgvEgresosEstacionales.Enabled == false ||
                this.dtgvEgresosEstacionales.SelectedCells.Count <= 0) return;

            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            // Obtener la celda seleccionada
            var selectedCell = this.dtgvEgresosEstacionales.SelectedCells[0];

            // Obtener el fila asociado a la celda seleccionada
            var selectedRow = selectedCell.OwningRow;

            // Obtener el objeto asociado a la fila seleccionada
            var selectedObject = selectedRow.DataBoundItem;

            // Buscar el objeto en la lista y eliminarlo
            var index = this.listaEgresosEstacionales.FindIndex(x => x.idEgresoEstacional == ((clsEgresosEstacionales)selectedObject).idEgresoEstacional);
            if (index >= 0)
            {
                this.listaEgresosEstacionales.RemoveAt(index);

                var idIngresoEstacional = ((clsEgresosEstacionales)selectedObject).idIngresoEstacional;

                var oEgresoEstacional = this.listaEgresosEstacionales.FindAll(x => x.idIngresoEstacional == idIngresoEstacional);
                this.bsEgresosEstacionales.DataSource = oEgresoEstacional;

                // Actualizar el origen de datos y refrescar el DataGridView
                this.bsEgresosEstacionales.ResetBindings(false);
                this.dtgvEgresosEstacionales.Refresh();
            }

            this.tsmQuitarInsumo.Enabled = (this.dtgvEgresosEstacionales.RowCount > 0);
        }

        private void ActualizarEgresos(Guid idIngresoEstacional)
        {
            List<clsEgresosEstacionales> oEgresoEstacional = new List<clsEgresosEstacionales>();

            if (this.listaProyeccionIngresos.Count > 0)
                oEgresoEstacional = this.listaEgresosEstacionales.FindAll(x => x.idIngresoEstacional == idIngresoEstacional);

            this.bsEgresosEstacionales.DataSource = oEgresoEstacional;
            this.dtgvEgresosEstacionales.DataSource = this.bsEgresosEstacionales;

            this.bsEgresosEstacionales.ResetBindings(false);
            this.dtgvEgresosEstacionales.Refresh();

            this.tsmQuitarInsumo.Enabled = (this.dtgvEgresosEstacionales.RowCount > 0);
        }

        private void dtgvIngresosEstacionales_SelectionChanged(object sender, EventArgs e)
        {
            dtgBase dtg = (dtgBase)sender;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            if (dtg.SelectedRows.Count > 0)
            {
                dataGridViewRow = dtg.SelectedRows[0];

                DataGridViewRow selectedRow = dataGridViewRow;
                var idIngresoEstacional = Guid.Parse(selectedRow.Cells["idIngresoEstacional"].Value.ToString());
                ActualizarEgresos(idIngresoEstacional);
                CalcularTotalInsumos(idIngresoEstacional);
            }
        }

        private void dtgvEgresosEstacionales_SelectionChanged(object sender, EventArgs e)
        {
            dtgBase dtg = (dtgBase)sender;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            if (dtg.SelectedCells.Count > 0)
            {
                int rowIndex = this.dtgvEgresosEstacionales.SelectedCells[0].RowIndex;
                dataGridViewRow = this.dtgvEgresosEstacionales.Rows[rowIndex];
                var idIngresoEstacional = Guid.Parse(dataGridViewRow.Cells["idIngresoEstacional"].Value.ToString());
                CalcularTotalInsumos(idIngresoEstacional);
            }
        }

        private void dtgvEgresosEstacionales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 12;
            }
        }

        private void dtgvEgresosEstacionales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgvEgresosEstacionales.Refresh();
        }

        #endregion
    }
}

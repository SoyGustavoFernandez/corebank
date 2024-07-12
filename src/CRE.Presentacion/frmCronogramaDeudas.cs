using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CRE.Presentacion
{
    public partial class frmCronogramaDeudas : frmBase
    {
        private clsDeudasEval obDeudasEval;
        private List<clsCuotaPago> listCronograma;

        private DateTime dFechaBase;
        private ComboBox cmbItem;

        public bool lCancelar;
        private int indexCategory = -1;

        public frmCronogramaDeudas()
        {
            InitializeComponent();
        }

        public frmCronogramaDeudas(clsDeudasEval _obDeudasEval)
        {
            InitializeComponent();
            FormatearDataGridView();

            this.obDeudasEval = _obDeudasEval;
            this.txtCuotasPend.Text = this.obDeudasEval.nCuotasPen.ToString("n0");

            this.listCronograma = this.obDeudasEval.listCuotaPago;

            /*if (String.IsNullOrWhiteSpace(this.obDeudasEval.cCronograma))
            {
                this.listCronograma = new List<clsCuotaPago>();
            }
            else
            {
                var xDoc = XDocument.Parse(this.obDeudasEval.cCronograma);

                this.listCronograma = (from x in xDoc.Root.Elements("clsCuotaPago")
                                       select new clsCuotaPago()
                                           {
                                               idDeudasEval = this.obDeudasEval.idDeudasEval,
                                               nContador = (int)x.Element("nContador"),
                                               nMes = (int)x.Element("nMes"),
                                               nMonto = (decimal)x.Element("nMonto"),
                                               nFrecuencia = (int)x.Element("nFrecuencia"),
                                               dFechaInicio = (DateTime)x.Element("dFechaInicio")
                                               //cGUID = this.obDeudasEval.cGUID
                                           }).ToList();
            }*/

            string cSimbolo = "";

            var aMoneda = (from p in Evaluacion.DataTableMoneda.AsEnumerable()
                           where p.Field<int>("idMoneda") == this.obDeudasEval.idMoneda
                           select new
                           {
                               cSimbolo = p.Field<string>("cSimbolo"),
                               idMoneda = p.Field<int>("idMoneda")
                           }).ToList().FirstOrDefault();

            if (aMoneda != null)
                cSimbolo = aMoneda.cSimbolo;

            this.label3.Text = this.obDeudasEval.cNombreEmpresa + " (" + cSimbolo + ")";
            this.txtMontoPrestado.Text = this.obDeudasEval.nMontoAprobado.ToString("n2");
            this.txtSaldoActual.Text = this.obDeudasEval.nSCapTotal.ToString("n2");

            AsignarDataTable();
            AsignarDatos(this.listCronograma);     //40 años por 12 meses = 480
            this.cboTipoFrecuencia.SelectedIndex = 0;

            this.lCancelar = true;
        }

        #region Métodos Públicos
        public string ObtenerCronogramaXML()
        {
            string cXml;

            if (this.lCancelar == false)
                cXml = this.listCronograma.GetXml();
            else
            {
                cXml = this.obDeudasEval.cCronograma;
            }

            return cXml;
        }

        public List<clsCuotaPago> ListCuotaPago()
        {
            return listCronograma;
        }

        public decimal PromedioCuota()
        {
            /*decimal nPromedio = 0;

            if (this.lCancelar == false)
                nPromedio = (this.listCronograma.Count > 0) ? this.listCronograma.Average(x => x.nMonto) : 0;
            else
            {
                if (String.IsNullOrWhiteSpace(this.obDeudasEval.cCronograma))
                    nPromedio = 0;
                else
                {
                    var xDoc = XDocument.Parse(this.obDeudasEval.cCronograma);

                    try
                    {
                        nPromedio = (from x in xDoc.Root.Elements("clsCuotaPago")
                                     select new clsCuotaPago()
                                         {
                                             nMonto = (decimal)x.Element("nMonto"),
                                         }).ToList().Average(x => x.nMonto);
                    }
                    catch
                    {
                        nPromedio = 0;
                    }
                }
            }

            return nPromedio;
             * */

            return (this.listCronograma.Count > 0) ? this.listCronograma.Average(x => x.nMonto) : 0;
        }
        #endregion

        #region Métodos Privados
        private void AsignarDataTable()
        {
            this.cboTipoFrecuencia.DisplayMember = "cFrecuencia";
            this.cboTipoFrecuencia.ValueMember = "idFrecuencia";
            this.cboTipoFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            this.cboTipoFrecuencia.SelectedIndex = -1;

            this.cboFechaInicio.DisplayMember = "cFechaLargo";
            this.cboFechaInicio.ValueMember = "nMes";
            this.cboFechaInicio.DataSource = Evaluacion.listMesFechasEval;
            this.cboFechaInicio.SelectedIndex = -1;

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);
        }

        private void AsignarDatos(List<clsCuotaPago> _listCronograma)
        {
            this.dtgCronograma.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCronograma_EditingControlShowing);
            this.dtgCronograma.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCronograma_CellLeave);
            this.cboTipoFrecuencia.SelectedIndexChanged -= new System.EventHandler(this.cboTipoFrecuencia_SelectedIndexChanged);

            this.listCronograma = _listCronograma;

            this.bindingCronograma.DataSource = listCronograma;
            this.dtgCronograma.DataSource = this.bindingCronograma;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();

            this.cboTipoFrecuencia.SelectedIndexChanged += new System.EventHandler(this.cboTipoFrecuencia_SelectedIndexChanged);
            this.dtgCronograma.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCronograma_CellLeave);
            this.dtgCronograma.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCronograma_EditingControlShowing);
        }

        private void FormatearDataGridView()
        {
            this.dtgCronograma.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCronograma.MultiSelect = false;
            this.dtgCronograma.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgCronograma.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCronograma.RowHeadersVisible = false;
        }

        private void AgregarComboBoxColumnsDataGridView()
        {
            DataGridViewComboBoxColumn dgcboMesPago = new DataGridViewComboBoxColumn();
            dgcboMesPago.DisplayStyleForCurrentCellOnly = true;
            dgcboMesPago.FlatStyle = FlatStyle.Popup;
            dgcboMesPago.Name = "dgcboMesPago";
            dgcboMesPago.DataPropertyName = "nMes";
            dgcboMesPago.DataSource = Evaluacion.listMesFechasEval;
            dgcboMesPago.DisplayMember = "cFechaCorto";
            dgcboMesPago.ValueMember = "nMes";
            this.dtgCronograma.Columns.Add(dgcboMesPago);
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgCronograma.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCronograma.Columns["nContador"].DisplayIndex = 0;
            dtgCronograma.Columns["dgcboMesPago"].DisplayIndex = 1;
            dtgCronograma.Columns["nMonto"].DisplayIndex = 2;

            dtgCronograma.Columns["nContador"].Visible = true;
            dtgCronograma.Columns["dgcboMesPago"].Visible = true;
            dtgCronograma.Columns["nMonto"].Visible = true;

            dtgCronograma.Columns["nContador"].HeaderText = "#";
            dtgCronograma.Columns["dgcboMesPago"].HeaderText = "Fecha";
            dtgCronograma.Columns["nMonto"].HeaderText = "Monto";

            dtgCronograma.Columns["nContador"].FillWeight = 30;
            dtgCronograma.Columns["dgcboMesPago"].FillWeight = 70;
            dtgCronograma.Columns["nMonto"].FillWeight = 100;

            dtgCronograma.Columns["nContador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCronograma.Columns["dgcboMesPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCronograma.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCronograma.Columns["nContador"].DefaultCellStyle.Format = "D2";
            dtgCronograma.Columns["dgcboMesPago"].DefaultCellStyle.Format = "MMM/yy";
            dtgCronograma.Columns["nMonto"].DefaultCellStyle.Format = "n2";

            dtgCronograma.Columns["dgcboMesPago"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCronograma.Columns["nMonto"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgCronograma.Columns["nContador"].ReadOnly = true;

            this.indexCategory = dtgCronograma.Columns.IndexOf(dtgCronograma.Columns["dgcboMesPago"]);
        }
        #endregion

        #region Eventos
        private void dtgCronograma_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            // --
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMonto"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            // -- 
            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboMesPago"))
            {
                cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    cmbItem.DropDown += new EventHandler(cboMesPago_DropDown);
                }
            }
        }

        public void cboMesPago_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtgCronograma.CurrentRow.Cells[indexCategory].FormattedValue.ToString()))
                return;

            int nMes = Convert.ToInt32(this.cboFechaInicio.SelectedValue);
            int nFrecuencia = Convert.ToInt32(this.cboTipoFrecuencia.SelectedValue);
            int nCuotasPend = Convert.ToInt32(this.txtCuotasPend.Text);
            int nNroMeses = nCuotasPend * nFrecuencia;

            cmbItem.DisplayMember = "cFechaCorto";
            cmbItem.ValueMember = "nMes";
            cmbItem.DataSource = Evaluacion.listMesFechasEval.Where(x => x.nMes >= nMes && x.nMes <= nNroMeses).ToList();
        }

        private void dtgCronograma_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbItem != null)
            {
                cmbItem.DropDown -= new EventHandler(cboMesPago_DropDown);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.lCancelar = false;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.lCancelar = true;
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.dtgCronograma.DataSource = null;
            this.listCronograma = null;
            this.listCronograma = new List<clsCuotaPago>();

            int nMes = Convert.ToInt32(this.cboFechaInicio.SelectedValue);
            int nFrecuencia = Convert.ToInt32(this.cboTipoFrecuencia.SelectedValue);

            for (int i = 1; i <= this.obDeudasEval.nCuotasPen; i++)
            {
                this.listCronograma.Add(new clsCuotaPago()
                {
                    nContador = this.listCronograma.Count + 1,
                    nMes = (i == 1) ? nMes : (this.listCronograma.Last()).nMes + nFrecuencia,
                    nMonto = this.txtCuota.Value,
                    nFrecuencia = nFrecuencia,
                    dFechaInicio = this.dFechaBase,
                    idMoneda = this.obDeudasEval.idMoneda,
                    idMonedaMA = this.obDeudasEval.idMonedaMA,
                    nTipoCambio = this.obDeudasEval.nTipoCambio
                });
            }

            AsignarDatos(this.listCronograma);
        }

        private void txtCuota_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnGenerar.PerformClick();
            }
        }

        private void txtCuota_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCuota.Text)) this.txtCuota.Text = "0";
        }

        private void cboTipoFrecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoFrecuencia.SelectedItem == null) return;

            this.cboFechaInicio.DataSource = null;

            int nFrecuencia = Convert.ToInt32(this.cboTipoFrecuencia.SelectedValue);
            if (this.listCronograma != null)
            {
                List<clsMesFechasEval> listMesFechas = Evaluacion.listMesFechasEval.Where(x => x.nMes <= nFrecuencia).ToList();

                this.cboFechaInicio.DisplayMember = "cFechaLargo";
                this.cboFechaInicio.ValueMember = "nMes";
                this.cboFechaInicio.DataSource = listMesFechas;
                this.cboFechaInicio.SelectedIndex = 0;
            }
        }
        #endregion

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

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
    }
}

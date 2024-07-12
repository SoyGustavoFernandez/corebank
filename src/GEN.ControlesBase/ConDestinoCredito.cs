using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class ConDestinoCredito : UserControl
    {
        private List<clsDestCredProp> listDestCredProp;
        private List<clsTipDestCred> listTipDestCred = null;
        private List<clsTipDestCred> listTipDestCredDetalle = null;

        public event EventHandler ChangeCapitalTrabajo;

        private decimal nMontoProp = 0;

        private bool lNuevoRegistro;
        private int nIndiceEditado;
        private int idTipDestCredEditado;
        public int idEvalCre = 0;

        private string cMsjCaption = "Error de Validación";

        public ConDestinoCredito()
        {
            InitializeComponent();
            FormatearDataGridView();

            HabilitarFormulario(false);

            this.lNuevoRegistro = true;
            this.nIndiceEditado = -1;
            this.idTipDestCredEditado = 999;
        }

        #region Métodos Públicos

        public void AsignarDataTable(DataTable _dtTipDestCred, DataTable _dtTipDestCredDetalle)
        {
            this.listTipDestCred = DataTableToList.ConvertTo<clsTipDestCred>(_dtTipDestCred) as List<clsTipDestCred>;
            this.listTipDestCredDetalle = DataTableToList.ConvertTo<clsTipDestCred>(_dtTipDestCredDetalle) as List<clsTipDestCred>;

            this.listTipDestCred.Insert(0, new clsTipDestCred() { idTipDestCred = 999, cDestino = "-- Seleccione --" });
            this.listTipDestCredDetalle.Insert(0, new clsTipDestCred() { idTipDestCred = 999, cDestino = "", idPadre = 999 });

            this.cboTipDestCred.DisplayMember = "cDestino";
            this.cboTipDestCred.ValueMember = "idTipDestCred";
            this.cboTipDestCred.DataSource = this.listTipDestCred.Where(x => x.idPadre == 0 || x.idPadre == 999).ToList<clsTipDestCred>();
        }

        public void AsignarDatos(decimal _nMontoProp, List<clsDestCredProp> _listDestCredProp)
        {
            this.nMontoProp = _nMontoProp;
            this.listDestCredProp = _listDestCredProp;
            this.bindingDestCredProp.DataSource = this.listDestCredProp;
            this.dtgDestCredProp.DataSource = this.bindingDestCredProp;
            //this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();

            CalcularTotalesDestCredito();
        }

        public decimal MontoCapitalTrabajo()
        {
            decimal nMonto = this.listDestCredProp.Where(x => x.idTipDestCred == Evaluacion.CapitalTrabajo).Sum(x => x.nMonto);
            return nMonto;
        }

        public decimal ObtenerActivoAdquirir()
        {
            return String.IsNullOrWhiteSpace(this.txtActivoAdquirir.Text) ? 0 : Convert.ToDecimal(this.txtActivoAdquirir.Text);
        }

        public void EstablacerActivoAdquirir(decimal nActivoAdquirir)
        {
            this.txtActivoAdquirir.Text = nActivoAdquirir.ToString("n2");
        }
        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgDestCredProp.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDestCredProp.MultiSelect = false;
            this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDestCredProp.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgDestCredProp.RowHeadersVisible = false;
            this.dtgDestCredProp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgDestCredProp.ReadOnly = true;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgDestCredProp.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDestCredProp.Columns["cDestinoCredito"].DisplayIndex = 0;
            dtgDestCredProp.Columns["nPorcentaje"].DisplayIndex = 1;
            dtgDestCredProp.Columns["nMonto"].DisplayIndex = 2;
            dtgDestCredProp.Columns["cDetalle"].DisplayIndex = 3;

            dtgDestCredProp.Columns["cDestinoCredito"].Visible = true;
            dtgDestCredProp.Columns["nPorcentaje"].Visible = true;
            dtgDestCredProp.Columns["nMonto"].Visible = true;
            dtgDestCredProp.Columns["cDetalle"].Visible = true;

            dtgDestCredProp.Columns["cDestinoCredito"].HeaderText = "Destino del Crédito";
            dtgDestCredProp.Columns["nPorcentaje"].HeaderText = "%";
            dtgDestCredProp.Columns["nMonto"].HeaderText = "Monto";
            dtgDestCredProp.Columns["cDetalle"].HeaderText = "Detalle";

            dtgDestCredProp.Columns["cDestinoCredito"].FillWeight = 60;
            dtgDestCredProp.Columns["nPorcentaje"].FillWeight = 25;
            dtgDestCredProp.Columns["nMonto"].FillWeight = 35;
            dtgDestCredProp.Columns["cDetalle"].FillWeight = 120;

            dtgDestCredProp.Columns["nPorcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDestCredProp.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDestCredProp.Columns["nPorcentaje"].DefaultCellStyle.Format = "p0";
            dtgDestCredProp.Columns["nMonto"].DefaultCellStyle.Format = "n2";
        }

        public void Actualizar(decimal nMontoProp)
        {
            this.nMontoProp = nMontoProp;
            if (this.listDestCredProp == null) return;

            foreach (clsDestCredProp dc in this.listDestCredProp)
                dc.nMontoProp = this.nMontoProp;

            this.ActualizarBindingDestCreditoYTotales();
        }

        private void ActualizarBindingDestCreditoYTotales()
        {
            this.CalcularTotalesDestCredito();
            this.bindingDestCredProp.ResetBindings(false);
        }

        private void CalcularTotalesDestCredito()
        {
            decimal nTotalPorcentaje = 0, nTotalMonto = 0;
            if (this.listDestCredProp != null)
            {
                nTotalPorcentaje = this.listDestCredProp.Sum(x => x.nPorcentaje);
                nTotalMonto = this.listDestCredProp.Sum(x => x.nMonto);
            }

            this.txtTotalPorcentaje.Text = String.Format("{0:p0}", nTotalPorcentaje);
            this.txtTotalMonto.Text = String.Format("{0:n2}", nTotalMonto);

            /*if (nTotalPorcentaje > 1)
            {
                this.txtTotalPorcentaje.BackColor = Color.Red;
                this.txtTotalPorcentaje.ForeColor = Color.White;
                this.txtTotalMonto.BackColor = Color.Red;
                this.txtTotalMonto.ForeColor = Color.White;
            }
            else
            {
                this.txtTotalPorcentaje.BackColor = SystemColors.Window;
                this.txtTotalPorcentaje.ForeColor = SystemColors.WindowText;
                this.txtTotalMonto.BackColor = SystemColors.Window;
                this.txtTotalMonto.ForeColor = SystemColors.WindowText;
            }*/
        }

        public void HabilitarFormulario(bool lHabilitado)
        {
            this.cboTipDestCred.Enabled = lHabilitado;
            this.txtPorcentaje.Enabled = lHabilitado;

            this.tsmAgregar.Enabled = lHabilitado;
            this.tsmCancelar.Enabled = lHabilitado;

            if (lHabilitado)
                this.cboTipDestCred.Focus();
            else
                this.btnNuevo.Focus();
        }

        public void LimpiarFormulario()
        {
            this.cboTipDestCred.SelectedIndex = -1;
            this.txtPorcentaje.Text = "0";
            this.txtPorcentajeMonto.Text = "0.00";
            this.cboTipDestCredDetalle.SelectedIndex = -1;

            this.errorProvider.SetError(this.cboTipDestCred, String.Empty);
            this.errorProvider.SetError(this.txtPorcentaje, String.Empty);
            this.errorProvider.SetError(this.cboTipDestCredDetalle, String.Empty);

            this.nIndiceEditado = -1;
            this.lNuevoRegistro = false;
            this.idTipDestCredEditado = 999;


        }

        public void limpiarControl()
        {
            nMontoProp = 0;
            listDestCredProp = null;
            listTipDestCred = null;
            listTipDestCredDetalle = null;

            if (this.listDestCredProp != null)
                this.listDestCredProp.Clear();

            this.bindingDestCredProp.ResetBindings(false);

            if (this.bindingDestCredProp != null)
            {
                if (this.dtgDestCredProp.DataSource != null)
                    ((BindingSource)this.dtgDestCredProp.DataSource).Clear();
            }
            this.LimpiarFormulario();

        }

        private bool EsDestCreditoValido()
        {
            bool lValido = true;
            /*if ((int)(this.cboTipDestCred.SelectedValue) == 999)
                lValido = false;*/

            if (this.cboTipDestCred.SelectedValue != null)
            {
                if (this.cboTipDestCred.SelectedIndex != -1)
                {
                    if ((int)(this.cboTipDestCred.SelectedValue) == 999)
                        lValido = false;
                }
            }

            return lValido;
        }

        private bool EsDestCreditoDuplicado()
        {
            bool lValido = true;
            if (this.cboTipDestCred.SelectedValue != null)
            {
                int idTipDestCred = (int)(this.cboTipDestCred.SelectedValue);

                if (this.idTipDestCredEditado != idTipDestCred)
                {
                    var count = this.listDestCredProp.Where(x => x.idTipDestCred == idTipDestCred).Count();
                    if (count > 0)
                        lValido = false;
                }
            }

            return lValido;
        }

        private bool EsPorcentajeValido()
        {
            bool lValido = true;
            if (String.IsNullOrWhiteSpace(this.txtPorcentaje.Text) || this.txtPorcentaje.Value == 0) lValido = false;
            return lValido;
        }

        private bool EsDetalleValido()
        {
            bool lValido = true;

            if (this.cboTipDestCredDetalle.Enabled == true)
            {
                if (this.cboTipDestCredDetalle.SelectedIndex != -1)
                {
                    if ((int)(this.cboTipDestCredDetalle.SelectedValue) == 999)
                        lValido = false;
                }
            }

            return lValido;
        }

        private clsMsjError ValidarFormulario()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsDestCreditoValido())
                objMsjError.AddError("Destino del Crédito: Seleccione una opción de la lista.");

            if (!EsDestCreditoDuplicado())
                objMsjError.AddError("Destino del Crédito: Seleccione otra opción distinta a la tabla.");

            if (!EsPorcentajeValido())
                objMsjError.AddError("Porcentaje: Ingrese un valor mayor a cero.");

            if (!EsDetalleValido())
                objMsjError.AddError("Detalle: Seleccione una opción de la lista.");

            /*if (!EsTotalPorcentajeValido())
                objMsjError.AddError("No se puede registrar por que el \"Porcentaje Total\" es mayor al 100%.");
            */

            return objMsjError;
        }

        private bool validarPorcentaje(int nIndiceFila, decimal nPorNuevo)
        {
            decimal nTotalPorcentaje = 0m;
            nTotalPorcentaje = sumarPorcentaje(nIndiceFila, nPorNuevo);
            if (nTotalPorcentaje > 1.00m)
            {
                MessageBox.Show("El porcentaje total no debe ser mayor que el 100, ahora es: " + (nTotalPorcentaje * 100).ToString(),
                    "Destino de crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Decimal sumarPorcentaje(int nIndiceFila, decimal nPorNuevo)
        {
            decimal nTotalPorcentaje = 0m;
            if (nIndiceFila >= 0) //registro existente
            {
                for (int i = 0; i < listDestCredProp.Count; i++)
                {
                    if (nIndiceFila != i)
                    {
                        nTotalPorcentaje += listDestCredProp[i].nPorcentaje;
                    }

                }
                nTotalPorcentaje += nPorNuevo / 100;
            }
            else // nuevo registro
            {
                foreach (clsDestCredProp item in listDestCredProp)
                {
                    nTotalPorcentaje += item.nPorcentaje;
                }
                nTotalPorcentaje += nPorNuevo / 100;
            }
            return nTotalPorcentaje;
        }

        public decimal sumarPorcentaje()
        {
            decimal nTotalPor = 0.00m;
            foreach (clsDestCredProp item in listDestCredProp)
            {
                nTotalPor += item.nPorcentaje;
            }
            return nTotalPor;
        }

        private void RegistrarDestCredito()
        {
            clsMsjError objMsjError = ValidarFormulario();

            if (objMsjError.HasErrors)
            {
                cboTipDestCred_Validated(null, null);
                txtPorcentaje_Validating(null, null);
                cboTipDestCredDetalle_Validating(null, null);

                MessageBox.Show(objMsjError.GetErrors(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tsmAgregar.Select();
                return;
            }

            if (this.nIndiceEditado != -1)
                this.dtgDestCredProp.CurrentCell = this.dtgDestCredProp.Rows[this.nIndiceEditado].Cells["cDestinoCredito"];

            if (this.lNuevoRegistro)
            {
                if (!validarPorcentaje(this.nIndiceEditado, Convert.ToDecimal(this.txtPorcentaje.Text)))
                {
                    return;
                }

                //---
                int idTipDestCred = this.cboTipDestCred.SelectedIndex < 0 ? 0 : Convert.ToInt32(this.cboTipDestCred.SelectedValue);

                clsTipDestCred oTipDestCred = (from p in this.listTipDestCred
                                              where p.idTipDestCred == idTipDestCred
                                              select p).First();
                //---

                this.listDestCredProp.Add(new clsDestCredProp()
                {
                    idTipDestCred = Convert.ToInt32(this.cboTipDestCred.SelectedValue),
                    cDestinoCredito = this.cboTipDestCred.Text,
                    nPorcentaje = this.txtPorcentaje.Value / 100,
                    idDetalle = ((this.cboTipDestCredDetalle.Enabled == true) ? Convert.ToInt32(this.cboTipDestCredDetalle.SelectedValue) : 0),
                    cDetalle = ((this.cboTipDestCredDetalle.Enabled == true) ? this.cboTipDestCredDetalle.Text : ""),
                    nMontoProp = this.nMontoProp,
                    idEvalCred = idEvalCre,
                    nCodigo = oTipDestCred.nCodigo
                });
            }
            else
            {
                //if (this.dtgRefCliente.SelectedRows.Count == 0 || this.dtgRefCliente.CurrentRow == null) return;
                if (!validarPorcentaje(this.nIndiceEditado, Convert.ToDecimal(this.txtPorcentaje.Text)))
                {
                    return;
                }
                int rowIndex = this.dtgDestCredProp.CurrentRow.Index;
                this.listDestCredProp[rowIndex].idTipDestCred = Convert.ToInt32(this.cboTipDestCred.SelectedValue);
                this.listDestCredProp[rowIndex].cDestinoCredito = this.cboTipDestCred.Text;
                this.listDestCredProp[rowIndex].nPorcentaje = Convert.ToDecimal(this.txtPorcentaje.Text) / 100;
                this.listDestCredProp[rowIndex].idDetalle = ((this.cboTipDestCredDetalle.Enabled == true) ? Convert.ToInt32(this.cboTipDestCredDetalle.SelectedValue) : 0);
                this.listDestCredProp[rowIndex].cDetalle = ((this.cboTipDestCredDetalle.Enabled == true) ? this.cboTipDestCredDetalle.Text : "");
            }

            //this.bindingDestCredProp.ResetBindings(false);
            ActualizarBindingDestCreditoYTotales();

            //-----
            if (this.lNuevoRegistro == true && this.dtgDestCredProp.Rows.Count > 1)
            {
                int rows = this.dtgDestCredProp.Rows.Count;
                this.dtgDestCredProp.CurrentCell = this.dtgDestCredProp.Rows[rows - 1].Cells["cDestinoCredito"];
            }

            LimpiarFormulario();
            HabilitarFormulario(false);

            // -- Evento cuando se asigna Capital de Trabajo
            /*int count = this.listDestCredProp.Where(x => x.idTipDestCred == Evaluacion.CapitalTrabajo).Count();
            if (count == 1)
            {
                if (ChangeCapitalTrabajo != null) 
                    ChangeCapitalTrabajo(null, null);
            }*/

            if (ChangeCapitalTrabajo != null)
                ChangeCapitalTrabajo(null, null);

        }

        public clsMsjError ValidarDestino()
        {
            clsMsjError obj = new clsMsjError();
            decimal nPor = 0.00m;
            nPor = sumarPorcentaje();
            if (listDestCredProp.Count == 0)
            {
                obj.AddError("Al menos debe registrar 1 destino de crédito");
            }
            else if (nPor != 1.0m)
            {
                obj.AddError("El porcentaje del destino de crédito debe ser el 100% ahora esta al: " + nPor.ToString("P2"));
            }
            return obj;
        }

        #endregion

        #region Eventos
        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            if (this.dtgDestCredProp.Rows.Count >= 2)
            {
                MessageBox.Show("¡El crédito no puede tener más de 2 destinos!", "LIMITE DE DESTINOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            RegistrarDestCredito();
        }

        private void tsmQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgDestCredProp.Enabled == false ||
                            this.dtgDestCredProp.SelectedRows.Count == 0 ||
                            this.dtgDestCredProp.CurrentRow == null) return;

            int rowIndex = this.dtgDestCredProp.CurrentRow.Index;
            this.listDestCredProp.RemoveAt(rowIndex);
            //this.bindingRefCliente.ResetBindings(false);
            ActualizarBindingDestCreditoYTotales();

            if (this.nIndiceEditado == rowIndex)
            {
                this.nIndiceEditado = -1;
                this.lNuevoRegistro = true;
                this.idTipDestCredEditado = 999;
            }

            if (this.dtgDestCredProp.SelectedRows.Count == 0)
                this.tsmQuitar.Enabled = false;

            if (ChangeCapitalTrabajo != null)
                ChangeCapitalTrabajo(null, null);
        }

        private void tsmCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(true);

            this.cboTipDestCred.SelectedIndex = 0;

            this.lNuevoRegistro = true;
        }

        private void dtgDestCredProp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HabilitarFormulario(true);

            decimal nPorcentaje = this.listDestCredProp[e.RowIndex].nPorcentaje;
            int idTipDestCred = this.listDestCredProp[e.RowIndex].idTipDestCred;

            this.cboTipDestCred.SelectedValue = idTipDestCred;
            this.txtPorcentaje.Text = (nPorcentaje * 100).ToString("n2");
            this.txtPorcentajeMonto.Text = (this.nMontoProp * nPorcentaje).ToString("n2");
            this.cboTipDestCredDetalle.SelectedValue = this.listDestCredProp[e.RowIndex].idDetalle;

            this.nIndiceEditado = e.RowIndex;
            this.lNuevoRegistro = false;
            this.idTipDestCredEditado = idTipDestCred;
        }

        private void dtgDestCredProp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void dtgDestCredProp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitar.Enabled = true;
        }

        private void cboTipDestCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTipDestCredDetalle.DataSource = null;
            this.cboTipDestCredDetalle.Enabled = false;

            int idTipDestCred = Convert.ToInt32(this.cboTipDestCred.SelectedValue);
            if (idTipDestCred != 999 && this.listTipDestCredDetalle != null)
            {
                List<clsTipDestCred> list = this.listTipDestCredDetalle.Where(x => x.idPadre == idTipDestCred).ToList<clsTipDestCred>();

                if (list.Count > 0)
                {
                    list.Insert(0, new clsTipDestCred() { idTipDestCred = 999, cDestino = "-- Seleccione --", idPadre = 999 });

                    this.cboTipDestCredDetalle.DisplayMember = "cDestino";
                    this.cboTipDestCredDetalle.ValueMember = "idTipDestCred";
                    this.cboTipDestCredDetalle.DataSource = list;
                    this.cboTipDestCredDetalle.SelectedIndex = 0;

                    this.cboTipDestCredDetalle.Enabled = true;
                }
            }
        }

        private void txtPorcentaje_Leave(object sender, EventArgs e)
        {
            decimal porcentaje = clsNumerico.StringToDecimal(this.txtPorcentaje.Text);
            this.txtPorcentajeMonto.Text = (this.nMontoProp * (porcentaje / 100)).ToString("n2");
        }

        private void txtPorcentaje_DragEnter(object sender, DragEventArgs e)
        {
            int nLonTex = this.txtPorcentaje.Value.ToString().Length;
            this.txtPorcentaje.Select(0, nLonTex);
        }

        private void cboTipDestCred_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                this.cboTipDestCred.DroppedDown = true;
        }

        private void cboTipDestCredDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                this.cboTipDestCredDetalle.DroppedDown = true;
        }

        private void cboTipDestCred_Validated(object sender, EventArgs e)
        {
            if (this.cboTipDestCred.Enabled == true)
            {
                bool destCreditoVal = EsDestCreditoValido();
                bool destCreditoDuplicadoVal = EsDestCreditoDuplicado();

                if (!destCreditoVal || !destCreditoDuplicadoVal)
                {
                    if (!destCreditoVal)
                        errorProvider.SetError(this.cboTipDestCred, "Seleccione una opción de la lista.");

                    if (!destCreditoDuplicadoVal)
                        errorProvider.SetError(this.cboTipDestCred, "Seleccione otra opción distinta a la tabla.");
                }
                else
                    errorProvider.SetError(this.cboTipDestCred, String.Empty);
            }
            else
                errorProvider.SetError(this.cboTipDestCred, String.Empty);
        }

        private void txtPorcentaje_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtPorcentaje.Enabled == true && !EsPorcentajeValido())
            {
                /*bool porcentajeValido = EsPorcentajeValido();
                bool totalPorcentajeValido = EsTotalPorcentajeValido();

                if (!porcentajeValido || !totalPorcentajeValido)
                {
                    if (!porcentajeValido)
                        errorProvider.SetError(this.txtPorcentaje, "Ingrese un valor mayor a cero.");

                    if (!totalPorcentajeValido)
                        errorProvider.SetError(this.txtPorcentaje, "El porcentaje Total es mayor al 100% con el valor registrado.");
                }
                else
                    errorProvider.SetError(this.txtPorcentaje, String.Empty);
                */

                errorProvider.SetError(this.txtPorcentaje, "Ingrese un valor mayor a cero.");
            }
            else
                errorProvider.SetError(this.txtPorcentaje, String.Empty);
        }

        private void cboTipDestCredDetalle_Validating(object sender, CancelEventArgs e)
        {
            if (this.cboTipDestCredDetalle.Enabled == true && !EsDetalleValido())
                errorProvider.SetError(this.cboTipDestCredDetalle, "Seleccione una opción de la lista.");
            else
                errorProvider.SetError(this.cboTipDestCredDetalle, String.Empty);
        }
        #endregion
    }
}

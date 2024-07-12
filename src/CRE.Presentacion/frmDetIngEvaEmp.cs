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
using CRE.CapaNegocio;
using EntityLayer;
using System.Xml;
using System.IO;

namespace CRE.Presentacion
{
    public partial class frmDetIngEvaEmp : frmBase
    {
        Transaccion enuOperacion;
        DataRow drIngreso;
        DataTable dtCosteoDetalle, dtMaestro;
        clsCNEvalEmp cnevalemp = new clsCNEvalEmp();
        const Decimal nCero = 0.00m;

        public frmDetIngEvaEmp()
        {
            InitializeComponent();
        }

        public frmDetIngEvaEmp(DataRow _drIngreso, DataTable _dtCosteoDetalle, DataTable _dtMaestro, Transaccion _enuOperacion)
        {
            InitializeComponent();
            drIngreso = _drIngreso;
            dtCosteoDetalle = _dtCosteoDetalle;
            dtMaestro = _dtMaestro;
            enuOperacion = _enuOperacion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            cargarComboBoxs();
            cboTipoGiro.Focus();
            dtgCosteo.DataSource = dtCosteoDetalle;
            FormatoGridCosteo();
            cargarValores();
        }      

        private void cboFrecPagEva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFrecPagEva.SelectedIndex > -1)
            {
                if (!(cboFrecPagEva.SelectedValue is DataRowView))
                {
                    cargarDiaSemanaMes();
                }                
            }            
        }

        private void cargarDiaSemanaMes()
        {
            var idPeriodo = Convert.ToInt32(cboFrecPagEva.SelectedValue);
            switch (idPeriodo)
            {
                case 1:
                    grbDiario.Visible = true;
                    grbSemana.Visible = false;
                    grbQuincena.Visible = false;
                    grbMes.Visible = false;
                    txtRepeticiones.Text = "30";
                    break;
                case 2:
                    grbDiario.Visible = false;
                    grbSemana.Visible = true;
                    grbQuincena.Visible = false;
                    grbMes.Visible = false;
                    grbSemana.Location = new Point(560, 240);
                    grbSemana.Size=new Size(200,156);
                    txtRepeticiones.Text = "4";
                    break;
                case 3:
                    grbDiario.Visible = false;
                    grbSemana.Visible = false;
                    grbQuincena.Visible = true;
                    grbMes.Visible = false;
                    grbQuincena.Location = new Point(560, 240);
                    grbQuincena.Size = new Size(200, 156);
                    txtRepeticiones.Text = "2";
                    break;
                case 4:
                    grbDiario.Visible = false;
                    grbSemana.Visible = false;
                    grbQuincena.Visible = false;
                    grbMes.Visible = true;
                    grbMes.Location = new Point(560, 240);
                    grbMes.Size = new Size(200, 156);
                    txtRepeticiones.Text = "1";
                    break;
                default:
                    grbDiario.Visible = false;
                    grbSemana.Visible = false;
                    grbQuincena.Visible = false;
                    grbMes.Visible = false;
                    txtRepeticiones.Text = "0";
                    break;
            }
        }

        private void txtDiasBuenos_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
        }

        private void txtCantidadDiasBuenos_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void txtDiasMalos_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void txtCantidadDiasMalos_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalMercaderia();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }
        
        private void txtRepeticiones_TextChanged(object sender, EventArgs e)
        {
            calcularSubTotalCompras();
            calcularSubTotalVentas();
            calcularSubTotalIngresos();
            calcularMargenUtilidad();
        }

        private void cboTipoGiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoGiro.SelectedIndex > -1)
            {
                if (!(cboTipoGiro.SelectedValue is DataRowView))
                {
                    txtPrecioCompra.Text = "0.00";
                    if (enuOperacion == Transaccion.Nuevo)
                    {
                        dtCosteoDetalle.Rows.Clear();
                    }
                    else
                    {                        
                        TotalFinalCosteo();
                        CalcularCostoUnit();
                    }
                    if (Convert.ToInt32(cboTipoGiro.SelectedValue) == 1)
                    {
                        grbCostoProduccion.Enabled = false;
                        txtPrecioCompra.Enabled = true;
                    }
                    else
                    {
                        grbCostoProduccion.Enabled = true;
                        txtPrecioCompra.Enabled = false;
                    }
                }
            }
        }

        private void dtgCosteo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nCantiUtiMatIns") ||
                dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nCantiMatInsStock"))
            {
                CalcularTotalFilaCosteo(e.RowIndex);
            }
        }

        private void dtgCosteo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                ComboBox cboUnidadMedCosteo = e.Control as ComboBox;
                if (cboUnidadMedCosteo != null)
                {
                    cboUnidadMedCosteo.DropDown -= new EventHandler(cboUnidadMedCosteo_DropDown);
                    cboUnidadMedCosteo.DropDown += new EventHandler(cboUnidadMedCosteo_DropDown);

                    cboUnidadMedCosteo.DropDownClosed -= new EventHandler(cboUnidadMedCosteo_DropDownClosed);
                    cboUnidadMedCosteo.DropDownClosed += new EventHandler(cboUnidadMedCosteo_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                ComboBox cboMonedaCosteo = e.Control as ComboBox;
                if (cboMonedaCosteo != null)
                {
                    cboMonedaCosteo.DropDown -= new EventHandler(cboMonedaCosteo_DropDown);
                    cboMonedaCosteo.DropDown += new EventHandler(cboMonedaCosteo_DropDown);

                    cboMonedaCosteo.DropDownClosed -= new EventHandler(cboMonedaCosteo_DropDownClosed);
                    cboMonedaCosteo.DropDownClosed += new EventHandler(cboMonedaCosteo_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgCosteo_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgCosteo_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgCosteo_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgCosteo_Leave);
                }
            }
        }

        private void txtboxNumdtgCosteo_Leave(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgCosteo.CurrentCell != null)
                    {
                        dtgCosteo.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void txtboxRealesdtgCosteo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    e.Handled = false;
                }
                else
                {
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
                               where L.ToString() == "."
                               select L).Count();

                    if (fff <= 0 && e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void cboMonedaCosteo_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMonedaCosteo = sender as DataGridViewComboBoxEditingControl;
                int index = cboMonedaCosteo.SelectedIndex;
                if (cboMonedaCosteo != null)
                {
                    cboMonedaCosteo.DisplayMember = "cSimbolo";
                    cboMonedaCosteo.SelectedIndex = index;
                }
            }
        }

        private void cboMonedaCosteo_DropDown(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMonedaCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboMonedaCosteo != null)
                    cboMonedaCosteo.DisplayMember = "cMoneda";
            }
        }

        private void cboUnidadMedCosteo_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMedCosteo = sender as DataGridViewComboBoxEditingControl;
                int index = cboUnidadMedCosteo.SelectedIndex;
                if (cboUnidadMedCosteo != null)
                {
                    cboUnidadMedCosteo.DisplayMember = "cDesCorTipoUniMed";
                    cboUnidadMedCosteo.SelectedIndex = index;
                }
            }
        }

        private void cboUnidadMedCosteo_DropDown(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMedCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboUnidadMedCosteo != null)
                    cboUnidadMedCosteo.DisplayMember = "cDesTipoUniMed";
            }
        }

        private void dtgCosteo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgCosteo.Focus();
            dtgCosteo["cDescriMatIns", e.RowIndex].Selected = true;
        }

        private void dtgCosteo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == @"Value '' cannot be converted to type 'System.String'.")
            {
                e.Cancel = true;
            }
        }

        private void btnAgrItemCosteo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUnidProd.Text))
            {
                MessageBox.Show("Ingrese la cantidad de unidades a ser costeadas", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidProd.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(this.txtUnidProd.Text))
            {
                if (Convert.ToDecimal(this.txtUnidProd.Text) <= 0)
                {
                    MessageBox.Show("La cantidad de unidades a ser costeadas debe ser mayor a 0", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnidProd.Focus();
                    return;
                }
            }

            DataRow dr = dtCosteoDetalle.NewRow();
            dr["IdCosteo"] = -1;
            dr["IdDetalleEvaEmp"] = Convert.ToInt32(drIngreso["IdDetalleEvaEmp"]);
            dr["cDescriMatIns"] = "";
            dr["IdMoneda"] = Convert.ToInt32(cboMoneda.SelectedValue);
            dr["nCantiUtiMatIns"] = 0;
            dr["IdUnidadMedida"] = 1;
            dr["nPrecioCompMatIns"] = 0.00;
            dr["nCantiMatInsStock"] = 0;
            dr["nSubTotCostoProdu"] = 0.00;
            dr["nSubTotMatInsStock"] = 0.00;
            dr["lVigente"] = 1;
            dr["IdInterno"] = Convert.ToInt32(drIngreso["IdInterno"]);
            dtCosteoDetalle.Rows.Add(dr);
            dtgCosteo.DataSource = dtCosteoDetalle;
        }

        private void btnQuitItemCosteo_Click(object sender, EventArgs e)
        {
            if (this.dtgCosteo.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgCosteo.SelectedCells[0].RowIndex);
                dtgCosteo["cDescriMatIns", nFilaActual].Selected = true;
                if (Convert.ToInt32(dtgCosteo.Rows[nFilaActual].Cells["IdDetalleEvaEmp"].Value) == -1)
                {
                    dtgCosteo.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgCosteo.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgCosteo.Focus();
                ProcessTabKey(true);
                dtCosteoDetalle.AcceptChanges();//Elimina definitivamente las filas de costeo que han sido borradas
                TotalFinalCosteo();
            }
        }

        private void txtCostUnit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCostUnit.Text))
                return;
            txtCostUnit.Text = string.Format("{0:0.00}", txtCostUnit.nvalor);
            txtPrecioCompra.Text = txtCostUnit.Text;
        }

        private void txtTotCostProd_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotCostProd.Text))
            {
                drIngreso["nSubTotCosProdu"] = txtTotCostProd.nDecValor;
            }
        }

        private void calcularSubTotalVentas()
        {
            txtSubTotalVentas.Text = string.Format("{0:0.00}",
                ((txtDiasBuenos.nvalor *
                txtCantidadDiasBuenos.nvalor *
                txtRepeticiones.nvalor)
                +
                (txtDiasMalos.nvalor *
                txtCantidadDiasMalos.nvalor *
                txtRepeticiones.nvalor))
                *
                txtPrecioVenta.nvalor);
        }

        private void calcularSubTotalCompras()
        {
            txtsubTotalCompras.Text = string.Format("{0:0.00}",
                ((txtDiasBuenos.nvalor *
                txtCantidadDiasBuenos.nvalor *
                txtRepeticiones.nvalor)
                +
                (txtDiasMalos.nvalor *
                txtCantidadDiasMalos.nvalor *
                txtRepeticiones.nvalor))
                *
                txtPrecioCompra.nvalor);
        }

        private void calcularSubTotalIngresos()
        {
            txtSubTotalIngresos.Text = string.Format("{0:0.00}", txtSubTotalVentas.nvalor - txtsubTotalCompras.nvalor);
        }

        private void calcularMargenUtilidad()
        {
            if (txtPrecioVenta.nvalor > 0.00)
            {
                txtMargenUtilidad.Text = string.Format("{0:0.00}", ((txtPrecioVenta.nvalor - txtPrecioCompra.nvalor) / txtPrecioVenta.nvalor)*100.00);
                
            }
        }

        private void calcularSubTotalMercaderia()
        {
            txtSubTotalMercaderia.Text = string.Format("{0:0.00}", txtStock.nvalor * txtPrecioCompra.nvalor);
        }

        private bool validar()
        {
            bool lVal = false;

            if (this.txtDiasBuenos.nDecValor <= nCero)
            {
                MessageBox.Show("La cantidad de días debe de ser mayor a cero(0)", "Validación de costeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiasBuenos.Focus();
                return lVal;
            }

            if (this.txtCantidadDiasBuenos.nDecValor <= nCero)
            {
                MessageBox.Show("La cantidad vendida debe de ser mayor a cero(0)", "Validación de costeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadDiasBuenos.Focus();
                return lVal;
            }

            if (this.txtPrecioCompra.nDecValor <= nCero)
            {
                MessageBox.Show("El precio de compra debe de ser mayor a cero(0)", "Validación de costeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return lVal;
            }

            if (this.txtPrecioVenta.nDecValor <= nCero)
            {
                MessageBox.Show("El precio de venta debe de ser mayor a cero(0)", "Validación de costeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void formatoGrid()
        {

        }

        private void limpiarControles()
        {
            txtDescripcion.Clear();
            txtDiasBuenos.Text = "0";
            txtCantidadDiasBuenos.Text = "0.00";
            txtDiasMalos.Text = "0";
            txtCantidadDiasMalos.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            txtPrecioCompra.Text = "0.00";
            txtStock.Text = "0";
            txtTotCostProd.Text = "0.00";
            txtTotStock.Text = "0.00";
            txtCostUnit.Text = "0.00";
            txtTotInv.Text = "0.00";
            txtUnidProd.Text = "0.00";
            dtgCosteo.DataSource = null;

            foreach (Control item in grbDiario.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
            }

            foreach (Control item in this.grbSemana.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
            }

            foreach (Control item in this.grbQuincena.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
            }

            foreach (Control item in this.grbMes.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
            }
        }

        private void habilitarControles()
        {

        }

        private void cargarComboBoxs()
        {
            DataTable dtTipGiro = cnevalemp.CNdtLstTipoGiro();
            cboTipoGiro.DataSource = dtTipGiro;
            cboTipoGiro.DisplayMember = dtTipGiro.Columns["cDesTipoGiroNego"].ToString();
            cboTipoGiro.ValueMember = dtTipGiro.Columns["IdTipoGiroNego"].ToString();

            DataTable dtTipIngr = cnevalemp.CNdtLstTipoIngresos();
            cboTipoIngr.DataSource = dtTipIngr;
            cboTipoIngr.DisplayMember = dtTipIngr.Columns["cDesTipoIng"].ToString();
            cboTipoIngr.ValueMember = dtTipIngr.Columns["IdTipoIng"].ToString();

            DataTable dtMetCosteo = cnevalemp.CNdtLstMetCosteo();
            cboMetCosteo.DataSource = dtMetCosteo;
            cboMetCosteo.DisplayMember = dtMetCosteo.Columns["cDescrMetodoCosteo"].ToString();
            cboMetCosteo.ValueMember = dtMetCosteo.Columns["IdMetCosteo"].ToString();

            DataTable dtUnidadMed = cnevalemp.CNdtLstUnidadMed();
            cboUnidadMed.DataSource = dtUnidadMed;
            cboUnidadMed.DisplayMember = dtUnidadMed.Columns["cDesTipoUniMed"].ToString();
            cboUnidadMed.ValueMember = dtUnidadMed.Columns["IdUnidadMedida"].ToString();

            DataTable dtMoneda = cnevalemp.CNdtLstMoneda();
            cboMoneda.DataSource = dtMoneda;
            cboMoneda.DisplayMember = dtMoneda.Columns["cMoneda"].ToString();
            cboMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();

            DataGridViewComboBoxColumn cboUnidadMedCosteo = new DataGridViewComboBoxColumn();
            cboUnidadMedCosteo.HeaderText = "Uni. Med.";
            cboUnidadMedCosteo.ToolTipText = "Unidad de Medida";
            cboUnidadMedCosteo.Name = "cboUnidadMedCosteo";
            cboUnidadMedCosteo.DataPropertyName = "IdUnidadMedida";
            cboUnidadMedCosteo.MaxDropDownItems = 4;
            cboUnidadMedCosteo.DropDownWidth = 50;
            cboUnidadMedCosteo.DataSource = dtUnidadMed;
            cboUnidadMedCosteo.DisplayMember = dtUnidadMed.Columns["cDesCorTipoUniMed"].ToString();
            cboUnidadMedCosteo.ValueMember = dtUnidadMed.Columns["IdUnidadMedida"].ToString();
            this.dtgCosteo.Columns.Add(cboUnidadMedCosteo);

            DataGridViewComboBoxColumn cboMonedaCosteo = new DataGridViewComboBoxColumn();
            cboMonedaCosteo.HeaderText = "Mon.";
            cboMonedaCosteo.ToolTipText = "Moneda";
            cboMonedaCosteo.Name = "cboMonedaCosteo";
            cboMonedaCosteo.DataPropertyName = "IdMoneda";
            cboMonedaCosteo.MaxDropDownItems = 4;
            cboMonedaCosteo.DropDownWidth = 100;
            cboMonedaCosteo.DataSource = dtMoneda;
            cboMonedaCosteo.DisplayMember = dtMoneda.Columns["cSimbolo"].ToString();
            cboMonedaCosteo.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            cboMonedaCosteo.ReadOnly = true;
            this.dtgCosteo.Columns.Add(cboMonedaCosteo);

        }
        
        private void CalcularTotalFilaCosteo(int index)
        {
            if (dtgCosteo.RowCount > 0)
            {
                decimal nPrecioCompMatIns = 0.00M;
                decimal nCantiUtiMatIns = 0.00M;
                decimal nCantiMatInsStock = 0.00M;

                if (dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value = 0;
                }
                if (dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value = 0;
                }
                if (dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value = 0;
                }

                nPrecioCompMatIns = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value); ;
                nCantiUtiMatIns = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value); ;
                nCantiMatInsStock = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value);
                dtgCosteo.Rows[index].Cells["nSubTotCostoProdu"].Value = nPrecioCompMatIns * nCantiUtiMatIns;
                dtgCosteo.Rows[index].Cells["nSubTotMatInsStock"].Value = nPrecioCompMatIns * nCantiMatInsStock;
            }
            else
            {
                txtTotCostProd.Text = "0.00";
                txtTotStock.Text = "0.00";
                txtCostUnit.Text = "0.00";
            }
            TotalFinalCosteo();
        }

        private void TotalFinalCosteo()
        {
            decimal nSubTotCostoProdu = 0.00M;
            decimal nSubTotMatInsStock = 0.00M;
            decimal nTotalInventario = 0.00M;

            foreach (DataGridViewRow row in dtgCosteo.Rows)
            {
                nSubTotCostoProdu += Convert.ToDecimal(row.Cells["nSubTotCostoProdu"].Value);
                nSubTotMatInsStock += Convert.ToDecimal(row.Cells["nSubTotMatInsStock"].Value);
            }

            foreach (DataRow row in dtCosteoDetalle.Rows)
            {
                if (Convert.ToBoolean(row["lVigente"].ToString()))
                {
                    if (Convert.ToInt32(row["IdMoneda"].ToString()) == Convert.ToInt32(cboMoneda.SelectedValue))
                    {
                        nTotalInventario += Convert.ToDecimal(row["nSubTotMatInsStock"].ToString());
                    }
                    else
                    {
                        nTotalInventario += CambioMoneda(Convert.ToInt32(row["IdMoneda"].ToString()), Convert.ToDecimal(row["nSubTotMatInsStock"].ToString()));
                    }
                }
            }

            txtTotCostProd.Text = nSubTotCostoProdu.ToString("##,##0.00");
            txtTotStock.Text = nSubTotMatInsStock.ToString("##,##0.00");
            txtTotInv.Text = nTotalInventario.ToString("##,##0.00");
            try
            {
                if (string.IsNullOrEmpty(txtTotCostProd.Text)) txtTotCostProd.Text = "0.00";
                if (string.IsNullOrEmpty(txtUnidProd.Text)) txtUnidProd.Text = "1";

                txtCostUnit.Text = (txtTotCostProd.nDecValor/ txtUnidProd.nDecValor).ToString("##,##0.00");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Debe ingresar el NÚMERO DE UNIDADES COSTEADAS para los giros de Negocio tipo: SERVICIO ó PRODUCCIÓN.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnidProd.Focus();
            }
        }

        private void CalcularCostoUnit()
        {
            if (string.IsNullOrEmpty(txtUnidProd.Text)) return;
            if (dtgCosteo.Rows.Count <= 0) return;
            if (txtUnidProd.nDecValor > 0M)
            {
                txtCostUnit.Text = (txtTotCostProd.nDecValor / txtUnidProd.nDecValor).ToString("##,##0.00");
            }
        }

        private decimal CambioMoneda(int idMoneda, decimal nMonto)
        {
            decimal nMontConvert = 0.00M;
            decimal nTipoCambio = Convert.ToDecimal(dtMaestro.Rows[0]["nTipoCambio"]);

            if (idMoneda == 1)
            {
                nMontConvert = nMonto / nTipoCambio;
                return nMontConvert;
            }
            else
            {
                nMontConvert = nMonto * nTipoCambio;
                return nMontConvert;
            }
        }

        private void FormatoGridCosteo()
        {
            foreach (DataGridViewColumn column in dtgCosteo.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Visible = false;
            }

            dtgCosteo.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgCosteo.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgCosteo.ReadOnly = false;

            dtgCosteo.Columns["cDescriMatIns"].Visible = true;
            dtgCosteo.Columns["cboMonedaCosteo"].Visible = true;
            dtgCosteo.Columns["cboUnidadMedCosteo"].Visible = true;
            dtgCosteo.Columns["nCantiUtiMatIns"].Visible = true;
            dtgCosteo.Columns["nPrecioCompMatIns"].Visible = true;
            dtgCosteo.Columns["nCantiMatInsStock"].Visible = true;
            dtgCosteo.Columns["nSubTotCostoProdu"].Visible = true;
            dtgCosteo.Columns["nSubTotMatInsStock"].Visible = true;

            dtgCosteo.Columns["cDescriMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nCantiUtiMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nPrecioCompMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nCantiMatInsStock"].ReadOnly = false;
            dtgCosteo.Columns["nSubTotCostoProdu"].ReadOnly = true;
            dtgCosteo.Columns["nSubTotMatInsStock"].ReadOnly = true;

            dtgCosteo.Columns["cDescriMatIns"].HeaderText = "Descripción";
            dtgCosteo.Columns["nCantiUtiMatIns"].HeaderText = "Cant. Util.";
            dtgCosteo.Columns["nPrecioCompMatIns"].HeaderText = "Prec. Compra";
            dtgCosteo.Columns["nCantiMatInsStock"].HeaderText = "Cant. Mat. Stock";
            dtgCosteo.Columns["nSubTotCostoProdu"].HeaderText = "SubTotal Costo Prod";
            dtgCosteo.Columns["nSubTotMatInsStock"].HeaderText = "SubTotal Stock ";

            dtgCosteo.Columns["cDescriMatIns"].ToolTipText = "Descripción";
            dtgCosteo.Columns["nCantiUtiMatIns"].ToolTipText = "Cantidad Utilizada";
            dtgCosteo.Columns["nPrecioCompMatIns"].ToolTipText = "Precio Compra";
            dtgCosteo.Columns["nCantiMatInsStock"].ToolTipText = "Cantidad Materiales en Stock";
            dtgCosteo.Columns["nSubTotCostoProdu"].ToolTipText = "SubTotal Costo Produccion";
            dtgCosteo.Columns["nSubTotMatInsStock"].ToolTipText = "SubTotal Mateiales en Stock";

            dtgCosteo.Columns["nCantiUtiMatIns"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nPrecioCompMatIns"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nCantiMatInsStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCosteo.Columns["cDescriMatIns"].FillWeight = 60;
            dtgCosteo.Columns["cboMonedaCosteo"].FillWeight = 25;
            dtgCosteo.Columns["cboUnidadMedCosteo"].FillWeight = 25;
            dtgCosteo.Columns["nCantiUtiMatIns"].FillWeight = 20;
            dtgCosteo.Columns["nPrecioCompMatIns"].FillWeight = 30;
            dtgCosteo.Columns["nCantiMatInsStock"].FillWeight = 30;
            dtgCosteo.Columns["nSubTotCostoProdu"].FillWeight = 28;
            dtgCosteo.Columns["nSubTotMatInsStock"].FillWeight = 28;

            dtgCosteo.Columns["cDescriMatIns"].DisplayIndex = 1;
            dtgCosteo.Columns["cboMonedaCosteo"].DisplayIndex = 2;
            dtgCosteo.Columns["nCantiUtiMatIns"].DisplayIndex = 3;
            dtgCosteo.Columns["cboUnidadMedCosteo"].DisplayIndex = 4;
            dtgCosteo.Columns["nPrecioCompMatIns"].DisplayIndex = 5;
            dtgCosteo.Columns["nCantiMatInsStock"].DisplayIndex = 6;
            dtgCosteo.Columns["nSubTotCostoProdu"].DisplayIndex = 7;
            dtgCosteo.Columns["nSubTotMatInsStock"].DisplayIndex = 8;

            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgCosteo.Columns["nCantiUtiMatIns"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nPrecioCompMatIns"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nCantiMatInsStock"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.Format = "##,##0.00";

            
        }

        private void cargarValores()
        {
            txtUnidProd.Text = drIngreso["nUniCosteadas"].ToString();
            cboTipoGiro.SelectedValue = Convert.ToInt32(drIngreso["IdTipoGiroNego"]);
            cboTipoIngr.SelectedValue = Convert.ToInt32(drIngreso["IdTipoIng"]);
            cboMoneda.SelectedValue = Convert.ToInt32(drIngreso["IdMoneda"]);
            txtDescripcion.Text = drIngreso["cDescriProdSer"].ToString();
            txtDiasBuenos.Text = drIngreso["nNumDiaBue_Est"].ToString();
            txtDiasMalos.Text = drIngreso["nNumDiaMalos"].ToString();
            txtCantidadDiasBuenos.Text = drIngreso["nCantiVenDiaBue_Est"].ToString();
            txtCantidadDiasMalos.Text = drIngreso["nCantiVenDiaMalos"].ToString();
            if (drIngreso["idMetCosteo"] != System.DBNull.Value)
            {
                cboUnidadMed.SelectedValue = Convert.ToInt32(drIngreso["idMetCosteo"]);
            }           
            cboUnidadMed.SelectedValue = Convert.ToInt32(drIngreso["IdUnidadMedida"]);
            if (drIngreso["nNumRepitexFrec"].ToString() == "0")
            {
                cboFrecPagEva.SelectedValue = 1;
            }
            else
            {
                txtRepeticiones.Text = drIngreso["nNumRepitexFrec"].ToString();
            }
            txtPrecioCompra.Text = drIngreso["nPreUniCompra_Prod"].ToString();
            txtStock.Text = drIngreso["nCantiProduTerm"].ToString();
            txtPrecioVenta.Text = drIngreso["nPrecioVenta"].ToString();
            txtPorcParticipacion.Text = string.Format("{0:0.00}", Convert.ToDecimal (drIngreso["nPorcenPartiProdSer"]) * 100.00m);

            asignarDetallePeriodo(drIngreso["cDetallePeriodo"].ToString());
            
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                drIngreso["IdDetalleEvaEmp"] = -1;
                drIngreso["IdTipoGiroNego"] = Convert.ToInt32(cboTipoGiro.SelectedValue); ;
                drIngreso["IdTipoIng"] = Convert.ToInt32(cboTipoIngr.SelectedValue);
                drIngreso["IdMoneda"] = Convert.ToInt32(cboMoneda.SelectedValue);
                drIngreso["cDescriProdSer"] = txtDescripcion.Text.Trim();
                drIngreso["nNumDiaBue_Est"] = Convert.ToInt32(txtDiasBuenos.nvalor);
                drIngreso["nNumDiaMalos"] = Convert.ToInt32(txtDiasMalos.nvalor);
                drIngreso["nCantiVenDiaBue_Est"] = Convert.ToInt32(txtCantidadDiasBuenos.nvalor);
                drIngreso["nCantiVenDiaMalos"] = Convert.ToInt32(txtCantidadDiasMalos.nvalor);
                drIngreso["idMetCosteo"] = Convert.ToInt32(cboMetCosteo.SelectedValue);
                drIngreso["IdUnidadMedida"] = Convert.ToInt32(cboUnidadMed.SelectedValue);
                drIngreso["nNumRepitexFrec"] = Convert.ToInt32(txtRepeticiones.nvalor);
                drIngreso["nPreUniCompra_Prod"] = txtPrecioCompra.nvalor;
                drIngreso["nCantiProduTerm"] = txtStock.nvalor;
                drIngreso["nPrecioVenta"] = txtPrecioVenta.nvalor;
                drIngreso["nSubTotCostoCompra_Prod"] = txtsubTotalCompras.nvalor;
                drIngreso["nSubTotVentas"] = txtSubTotalVentas.nvalor;
                drIngreso["nSubTotIngresos"] = txtSubTotalIngresos.nvalor;
                drIngreso["nMargenUtiProdSer"] = txtMargenUtilidad.nvalor / 100.00;
                drIngreso["nPorcenPartiProdSer"] = txtPorcParticipacion.nvalor;
                drIngreso["nSubTotMercaderia"] = txtSubTotalMercaderia.nvalor;
                drIngreso["nSubTotMatPrimaIns"] = txtTotCostProd.nvalor;
                drIngreso["nUniCosteadas"] = txtUnidProd.nvalor;
                drIngreso["lVigente"] = 1;
                drIngreso["cDetallePeriodo"] = retornarDetallePeriodo();
                this.Close();
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            if (enuOperacion == Transaccion.Nuevo)
            {
                drIngreso.Delete();
            }
        }

        private string retornarDetallePeriodo()
        {
            string xmlDetalle = "";
            DataTable dtDetallePeriodo = new DataTable("dtDetallePeriodo");
            DataSet dsDetallePeriodo = new DataSet("dsDetallePeriodo");
            dtDetallePeriodo.Columns.Add("idFrecPagEva", typeof(int));
            dtDetallePeriodo.Columns.Add("nOrden", typeof(int));
            dtDetallePeriodo.Columns.Add("nValor", typeof(Decimal));

            var idFrecPagEva = Convert.ToInt32(cboFrecPagEva.SelectedValue);
            DataRow drDetalle;

            switch (idFrecPagEva)
            {
                case 1:

                    #region diario

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 1;
                    drDetalle["nValor"] = txtLunes.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 2;
                    drDetalle["nValor"] = this.txtMartes.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 3;
                    drDetalle["nValor"] = this.txtMiercoles.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 4;
                    drDetalle["nValor"] = this.txtJueves.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 5;
                    drDetalle["nValor"] = this.txtViernes.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 6;
                    drDetalle["nValor"] = this.txtSabado.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 7;
                    drDetalle["nValor"] = this.txtDomingo.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    #endregion

                    break;
                case 2:

                    #region Semanal

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 1;
                    drDetalle["nValor"] = this.txtSemana1.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 2;
                    drDetalle["nValor"] = this.txtSemana2.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 3;
                    drDetalle["nValor"] = this.txtSemana3.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"]=idFrecPagEva;
                    drDetalle["nOrden"] = 4;
                    drDetalle["nValor"] = this.txtSemana4.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    #endregion

                    break;

                case 3:

                    #region Quincena

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"] = idFrecPagEva;
                    drDetalle["nOrden"] = 1;
                    drDetalle["nValor"] = this.txtQuinSemana1.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"] = idFrecPagEva;
                    drDetalle["nOrden"] = 2;
                    drDetalle["nValor"] = this.txtQuinSemana2.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    #endregion
                    break;

                case 4:

                    #region Mes

                    drDetalle = dtDetallePeriodo.NewRow();
                    drDetalle["idFrecPagEva"] = idFrecPagEva;
                    drDetalle["nOrden"] = 1;
                    drDetalle["nValor"] = this.txtMes.nvalor;
                    dtDetallePeriodo.Rows.Add(drDetalle);

                    #endregion
                    break;
                default:
                    break;
            }

            dsDetallePeriodo.Tables.Add(dtDetallePeriodo);
            xmlDetalle = dsDetallePeriodo.GetXml();

            return xmlDetalle;
        }

        private void asignarDetallePeriodo(string xmlDetalle)
        {
            if (string.IsNullOrEmpty(xmlDetalle)) return;

            DataSet dsDetalle= new DataSet();
            dsDetalle.ReadXml(XmlReader.Create(new StringReader(xmlDetalle)));

            if (dsDetalle.Tables.Count == 0) return;

            var dtDetalle = dsDetalle.Tables[0];

            if (dtDetalle.Rows.Count == 0) return;

            var idFrecPagEva = Convert.ToInt32(dtDetalle.Rows[0]["idFrecPagEva"]);

            cboFrecPagEva.SelectedValue = idFrecPagEva;

            switch (idFrecPagEva)
            {
                case 1:

                    #region diario

                    txtLunes.Text       = dtDetalle.Rows[0]["nValor"].ToString();
                    txtMartes.Text      = dtDetalle.Rows[1]["nValor"].ToString();
                    txtMiercoles.Text   = dtDetalle.Rows[2]["nValor"].ToString();
                    txtJueves.Text      = dtDetalle.Rows[3]["nValor"].ToString();
                    txtViernes.Text     = dtDetalle.Rows[4]["nValor"].ToString();
                    txtSabado.Text      = dtDetalle.Rows[5]["nValor"].ToString();
                    txtDomingo.Text     = dtDetalle.Rows[6]["nValor"].ToString();
                    
                    #endregion

                    break;
                case 2:

                    #region Semanal

                    txtSemana1.Text = dtDetalle.Rows[0]["nValor"].ToString();
                    txtSemana2.Text = dtDetalle.Rows[1]["nValor"].ToString();
                    txtSemana3.Text = dtDetalle.Rows[2]["nValor"].ToString();
                    txtSemana4.Text = dtDetalle.Rows[3]["nValor"].ToString();                    

                    #endregion

                    break;

                case 3:

                    #region Quincena

                    txtQuinSemana1.Text = dtDetalle.Rows[0]["nValor"].ToString();
                    txtQuinSemana2.Text = dtDetalle.Rows[1]["nValor"].ToString();

                    #endregion
                    break;

                case 4:

                    #region Mes

                    txtMes.Text = dtDetalle.Rows[0]["nValor"].ToString();

                    #endregion
                    break;
                default:
                    break;
            }

        }
    }
}

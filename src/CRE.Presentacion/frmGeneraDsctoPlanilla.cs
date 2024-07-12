using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmGeneraDsctoPlanilla : frmBase
    {

        #region Variables

        clsCNConvenios Convenio = new clsCNConvenios();

        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboConvenio.Text))
            {
                MessageBox.Show("Seleccione un Convenio", "Archivo Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int idConvenio = Convert.ToInt16(cboConvenio.SelectedValue);
            DateTime dFechaVen = dtpFechaVen.Value;
            dtgDetalleDscto.DataSource = null;

            DataTable dtDscto;
            dtDscto = Convenio.CNClientesxPagarConvenio(dFechaVen, idConvenio);
            if (dtDscto.Rows.Count == 0)
            {
                btnGenerar.Enabled = false;
                txtTotal.Text = "0.00";
                MessageBox.Show("No existen datos para el convenio y fecha seleccionada", "Archivo Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnGenerar.Enabled = true;
            dtDscto.Columns["nSaldo"].ReadOnly = false;
            dtDscto.Columns["lPago"].ReadOnly = false;
            dtgDetalleDscto.DataSource = dtDscto;
            FormatoGrid();
            calcularTotal();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleDscto.RowCount < 1)
            {
                MessageBox.Show("No hay registros para la generación del archivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfdCarpetaDestiono = new SaveFileDialog();
            sfdCarpetaDestiono.Title = "Exportar Planilla convenio";
            sfdCarpetaDestiono.Filter = "Archivo txt (*.txt)|*.txt";
            sfdCarpetaDestiono.RestoreDirectory = true;
            var cResultado = sfdCarpetaDestiono.ShowDialog();

            if (cResultado == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(sfdCarpetaDestiono.FileName))
                {
                    MessageBox.Show("El archivo ya existe, cambie de nombre o ruta de destino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StreamWriter swPlanilla = new StreamWriter(sfdCarpetaDestiono.FileName);

                foreach (DataGridViewRow item in dtgDetalleDscto.Rows)
                {
                    swPlanilla.WriteLine(item.Cells["cCodEmpleado"].Value.ToString() + "|" +
                                          item.Cells["cNombre"].Value.ToString().PadRight(40, ' ') + "|" +
                                          string.Format("{0:0.00}", item.Cells["nSaldo"].Value).Replace(".", "").PadLeft(8, ' '));
                }
                swPlanilla.Flush();
                swPlanilla.Close();
                MessageBox.Show("El archivo se genero correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgDetalleDscto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgDetalleDscto.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgDetalleDscto.CurrentCell;
                bool isChecked = (bool)checkbox.EditedFormattedValue;
                if (!isChecked)
                {
                    dtgDetalleDscto.Rows[e.RowIndex].Cells["nSaldo"].Value = 0;
                }

                this.dtgDetalleDscto.CurrentCell = dtgDetalleDscto.Rows[e.RowIndex].Cells["nSaldo"];
                this.dtgDetalleDscto.CurrentCell.Selected = true;
                calcularTotal();
            }
        }

        private void dtgDetalleDscto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotal();
        }

        private void cboConvenio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgDetalleDscto.DataSource = null;
            txtTotal.Text = "0.00";
        }

        private void dtgDetalleDscto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
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
                var fff = (from L in this.Text.ToString()
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

        #endregion

        #region Métodos

        public frmGeneraDsctoPlanilla()
        {
            InitializeComponent();
        }

        private void calcularTotal()
        {
            var nTotal = ((DataTable)dtgDetalleDscto.DataSource).AsEnumerable().Where(x => Convert.ToBoolean(x["lPago"]) == true).Sum(x => Convert.ToDecimal(x["nSaldo"]));

            txtTotal.Text = nTotal.ToString();

        }

        public void FormatoGrid()
        {
            dtgDetalleDscto.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgDetalleDscto.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = true;
            }
            dtgDetalleDscto.Columns["nSaldo"].ReadOnly = false;
            dtgDetalleDscto.Columns["lPago"].ReadOnly = false;

            dtgDetalleDscto.Columns["cCodEmpleado"].Visible = false;
            dtgDetalleDscto.Columns["idCuenta"].Visible = false;

            dtgDetalleDscto.Columns["cNombre"].Width = 145;
            dtgDetalleDscto.Columns["dFechaDesembolso"].Width = 30;
            dtgDetalleDscto.Columns["nCapDes"].Width = 30;
            dtgDetalleDscto.Columns["nSaldoDeuda"].Width = 30;
            dtgDetalleDscto.Columns["nSaldo"].Width = 30;
            dtgDetalleDscto.Columns["lPago"].Width = 25;

            dtgDetalleDscto.Columns["cNombre"].HeaderText = "Nombre";
            dtgDetalleDscto.Columns["dFechaDesembolso"].HeaderText = "Fec.Des.";
            dtgDetalleDscto.Columns["nCapDes"].HeaderText = "Desemb";
            dtgDetalleDscto.Columns["nSaldoDeuda"].HeaderText = "Sal. Deuda";
            dtgDetalleDscto.Columns["nSaldo"].HeaderText = "Dscto";
            dtgDetalleDscto.Columns["lPago"].HeaderText = "Sel.";

            dtgDetalleDscto.Columns["nCapDes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleDscto.Columns["nSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleDscto.Columns["nSaldoDeuda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

    }
}

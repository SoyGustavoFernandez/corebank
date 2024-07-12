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

namespace GEN.ControlesBase
{
    public partial class frmConfigCantOP : frmBase
    {
        public DataTable dtConfigOOP = new DataTable();
        int nGrupo = 0;
        int nOpcionG = 0;
        public int nNumImpresion = 0;
        public frmConfigCantOP()
        {
            InitializeComponent();
        }
        public frmConfigCantOP(int nOpcion)
        {
            InitializeComponent();
            nOpcionG = nOpcion;
        }
        private void frmConfigCantOP_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            //Agregando las columnas 
            dtConfigOOP.Columns.Add("idGrupo", typeof(int));
            dtConfigOOP.Columns.Add("nCant", typeof(int));
            int nTotalGrupo = 0;
            int nNumImpGrup = nNumImpresion;
            int nDivid = nNumImpresion / 4;
            nTotalGrupo = nNumImpresion / 4 + nNumImpresion % 4;
            for (int i = 0; i < nTotalGrupo; i++)
            {
                DataRow dr = dtConfigOOP.NewRow();
                dr["idGrupo"] = nGrupo + 1;
                dr["nCant"] = (nNumImpGrup == 0 && nDivid == 0) ? 1 : (nNumImpGrup - nNumImpresion % 4) / nDivid;
                nNumImpGrup = nNumImpGrup - ((nNumImpGrup == 0 && nDivid == 0) ? 0 : (nNumImpGrup / nDivid));
                dtConfigOOP.Rows.Add(dr);

                nDivid--;
                nGrupo++;
            }
            dtgConfigOP.DataSource = dtConfigOOP;

            dtgConfigOP.Columns["idGrupo"].HeaderText = "GRUPO";
            dtgConfigOP.Columns["nCant"].HeaderText = "CANTIDAD";
            dtgConfigOP.Columns["idGrupo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgConfigOP.Columns["nCant"].SortMode = DataGridViewColumnSortMode.NotSortable;
            txtTotal.Text = Suma().ToString();

            dtgConfigOP.ReadOnly = false;
            dtgConfigOP.Columns["idGrupo"].ReadOnly = true;
            dtgConfigOP.Columns["nCant"].ReadOnly = false;
        }
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            DataRow dr = dtConfigOOP.NewRow();
            if (!string.IsNullOrEmpty(txtNumImpresion.Text))
            {
                int nNumImpre = Convert.ToInt32(txtNumImpresion.Text);
                if (nNumImpre > 0 && nNumImpre <= 4)
                {
                    //Validación
                    int nSumCant = Suma();
                    if (nSumCant + Convert.ToInt32(txtNumImpresion.Text) > nNumImpresion)
                    {
                        MessageBox.Show("La suma de la cantidad por grupo no puede exceder al siguiente valor: " + nNumImpresion.ToString(), "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //
                    dr["idGrupo"] = nGrupo + 1;
                    dr["nCant"] = Convert.ToInt32(txtNumImpresion.Text);
                    dtConfigOOP.Rows.Add(dr);
                    nGrupo++;
                    txtNumImpresion.Clear();
                    txtNumImpresion.Focus();
                    txtTotal.Text = Suma().ToString();
                }
                else
                {
                    MessageBox.Show("Valor incorrecto", "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumImpresion.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para el número de órdenes para el grupo", "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumImpresion.Focus();
                return;
            }

        }
        private int Suma()
        {
            int nSuma = 0;
            for (int i = 0; i < dtConfigOOP.Rows.Count; i++)
            {
                nSuma = nSuma + Convert.ToInt32(dtConfigOOP.Rows[i]["nCant"]);
            }
            return nSuma;
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {

            if (dtConfigOOP.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para eliminar", "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtgConfigOP.SelectedRows.Count > 0)
                {
                    Int32 nFila = Convert.ToInt32(this.dtgConfigOP.SelectedCells[0].RowIndex);
                    if (nGrupo - 1 == nFila)
                    {
                        dtConfigOOP.Rows.RemoveAt(nFila);
                        nGrupo--;
                        txtTotal.Text = Suma().ToString();
                    }
                    else
                    {
                        MessageBox.Show("la eliminación de filas es a partir de la última fila", "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila a eliminar", "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


            }
        }
        private bool ValNumImpre()
        {
            int nTotal = 0;
            for (int i = 0; i < dtConfigOOP.Rows.Count; i++)
            {
                nTotal = nTotal + Convert.ToInt32(dtConfigOOP.Rows[i]["nCant"]);
            }
            if (nTotal > nNumImpresion)
            {
                MessageBox.Show("La suma de la cantidad por grupo no puede exceder al siguiente valor: " + nNumImpresion.ToString(), "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (nTotal == nNumImpresion)
            {
                return true;
            }
            else
            {
                MessageBox.Show("La suma de la cantidad por grupo no puede ser menor al siguiente valor: " + nNumImpresion.ToString(), "Impresión de órdenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void frmConfigCantOP_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nOpcionG == 2)
            {
                if (!ValNumImpre())
                {
                    return;
                }
                else
                {
                    this.Dispose();
                }
            }

            else
            {
                this.Dispose();
            }
        }

        private void dtgConfigOP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            txtbox.MaxLength = 1;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 49 && e.KeyChar <= 52) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgConfigOP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgConfigOP.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgConfigOP.Rows[fila].Cells["nCant"].Value.ToString()))
            {
                this.dtgConfigOP.Rows[fila].Cells["nCant"].Value = 0;
            }
            txtTotal.Text = Suma().ToString();
        }
    }
}

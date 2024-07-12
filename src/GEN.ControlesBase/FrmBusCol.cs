using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using System.Text.RegularExpressions;


namespace GEN.ControlesBase
{
    public partial class FrmBusCol : frmBase
    {
        /// <summary>
        /// Indica el estado del personal a buscar, 0=>Todos, 1=>Activos, 2=>Cesados
        /// </summary>
        public String cEstado = "0";

        public string idUsu, idCliPer, cNom, cDocID, idRelLab, idCargoPer, cCargoPer, idEstUsu, nidAgencia, nidArea;
        public int nPorLibVia;

        public FrmBusCol()
        {
            InitializeComponent();
            this.cboCriBusCol.Focus();
        }

        private void FrmBusquedaCli_Load(object sender, EventArgs e)
        {
            lblCriterio.Text = "Ape. y Nombres:";
        }

        private void cboCriBusCli1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusCol.SelectedValue.ToString();
            if (cCriBus == "1")
            {
                lblCriterio.Text = "DNI:";
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Ape. y Nombres:";
            }
            txtDniNom.Clear();
            txtDniNom.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgColaborador.CurrentRow != null && dtgColaborador.Rows.Count > 0)
            {
                idUsu = Convert.ToString(dtgColaborador.CurrentRow.Cells["idUsuario"].Value);
                idCliPer = Convert.ToString(dtgColaborador.CurrentRow.Cells["idCli"].Value);
                cNom = Convert.ToString(dtgColaborador.CurrentRow.Cells["cNombre"].Value);
                cDocID = Convert.ToString(dtgColaborador.CurrentRow.Cells["cDocumentoID"].Value);
                idRelLab = Convert.ToString(dtgColaborador.CurrentRow.Cells["idRelacionLab"].Value);
                idCargoPer = Convert.ToString(dtgColaborador.CurrentRow.Cells["idCargo"].Value);
                cCargoPer = Convert.ToString(dtgColaborador.CurrentRow.Cells["cCargo"].Value);
                idEstUsu = Convert.ToString(dtgColaborador.CurrentRow.Cells["idEstado"].Value);
                nPorLibVia = Convert.ToInt32(dtgColaborador.CurrentRow.Cells["nPorcenLibreVia"].Value);
                nidAgencia = Convert.ToString(dtgColaborador.CurrentRow.Cells["idAgencia"].Value);
                nidArea = Convert.ToString(dtgColaborador.CurrentRow.Cells["idArea"].Value);
            }
            else
            {
                CleanData();
            }

            this.Dispose();

        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusqueda1.PerformClick();
                e.Handled = true;
            }

            if (Convert.ToInt32(this.cboCriBusCol.SelectedValue) == 1)
            {
                if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) || this.txtDniNom.Text.Length >= 8))
                {
                    e.Handled = true;
                }
            }
            else if ((Convert.ToInt32(this.cboCriBusCol.SelectedValue) == 2))
            {
                string cPatronNombre = @"([A-Z]|[a-z]| )";
                Regex expReg = new Regex(cPatronNombre);
                if (!char.IsControl(e.KeyChar) && !expReg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }

        private void dtgClientes_DoubleClick(object sender, EventArgs e)
        {
            btnAceptar.PerformClick();
        }

        private void dtgClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAceptar.PerformClick();
            }
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            string cCriBus, cDatoIngr;
            cCriBus = cboCriBusCol.SelectedValue.ToString();
            cDatoIngr = txtDniNom.Text.Trim();

            if (cCriBus == "")
            {
                MessageBox.Show("Debe Seleccionar El Criterio de Búsqueda", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCol.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe Ingresar los Datos a Buscar", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            clsCNBuscaPersonal lisPer = new clsCNBuscaPersonal();
            DataTable dtPer = lisPer.BusPerByDNIName(cCriBus, cDatoIngr, Convert.ToInt32(cEstado));
            dtgColaborador.DataSource = dtPer;
            formatoGrid();

            if (dtgColaborador.RowCount == 0)
            {
                MessageBox.Show("No Existen Datos con el criterio de Búsqueda", "Búsqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
            this.dtgColaborador.Focus();
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgColaborador.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgColaborador.Columns["cDocumentoID"].Visible = true;
            dtgColaborador.Columns["cNombre"].Visible = true;

            dtgColaborador.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            dtgColaborador.Columns["cNombre"].HeaderText = "Nombres";

            dtgColaborador.Columns["cDocumentoID"].Width = 100;

        }

        private void CleanData()
        {
            idUsu = "";
            idCliPer = "";
            cNom = "";
            cDocID = "";
            idRelLab = "";
            idCargoPer = "";
            cCargoPer = "";
            idEstUsu = "";
            nPorLibVia = 0;
            nidAgencia = "";
            nidArea = "";
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private void dtgColaborador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBusSolAhoPen : frmBase
    {
        clsCNDeposito objDeposito = new clsCNDeposito();
        public string cNrocuenta, cCodCliente, cDocCli, cNombre;
        public int idcuenta=0,pidAgencia, pIdTipoPersona=0, pIdTipoDocumento=0; 

        public frmBusSolAhoPen()
        {
            InitializeComponent();
        }

        private void frmBusSolAhoPen_Load(object sender, EventArgs e)
        {
            DataTable dtSolAho = objDeposito.CNListaSolPenAho(pidAgencia);
            if (dtSolAho.Rows.Count>0)
            {
                dtgSolAhoPend.DataSource = dtSolAho;
                formatoGrid();
                ColorFilasGrid();
            }
        }

        private void ColorFilasGrid()
        {
            foreach (DataGridViewRow row in dtgSolAhoPend.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                    //row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private void Aceptar()
        {
            if (dtgSolAhoPend.RowCount > 0)
            {
                cNrocuenta = dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["cNroCuenta"].Value.ToString();
                cCodCliente = dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                cDocCli = dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["cNumeroDoc"].Value.ToString();
                cNombre = dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                idcuenta = Convert.ToInt32(dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["idCuenta"].Value);

                pIdTipoPersona = Convert.ToInt32(dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["IdTipoPersona"].Value);
                pIdTipoDocumento = Convert.ToInt32(dtgSolAhoPend.Rows[dtgSolAhoPend.SelectedCells[0].RowIndex].Cells["idTipoDocumento"].Value);
            }
            else
            {
                cNrocuenta = "";
                cCodCliente = "";
                cDocCli = "";
                cNombre = "";
                idcuenta = 0;
                pIdTipoPersona = 0;
                pIdTipoDocumento = 0;
            }
            this.Close();
        }
        private void formatoGrid()
        {
            dtgSolAhoPend.Columns["idCuenta"].Visible = true;
            dtgSolAhoPend.Columns["cNombre"].Visible = true;
            dtgSolAhoPend.Columns["cCodCliente"].Visible = false;
            dtgSolAhoPend.Columns["cNumeroDoc"].Visible = false;           
            dtgSolAhoPend.Columns["cNroCuenta"].Visible = false;
            dtgSolAhoPend.Columns["idMoneda"].Visible = false;
            dtgSolAhoPend.Columns["cMoneda"].Visible = true;


            dtgSolAhoPend.Columns["idTipoDocumento"].Visible = false;
            dtgSolAhoPend.Columns["IdTipoPersona"].Visible = true;

            dtgSolAhoPend.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolAhoPend.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgSolAhoPend.Columns["cMoneda"].HeaderText = "Moneda";

            dtgSolAhoPend.Columns["idCuenta"].Width = 100;
            dtgSolAhoPend.Columns["cNombre"].Width = 250;
            dtgSolAhoPend.Columns["cMoneda"].Width = 100;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgSolAhoPend_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dtgSolAhoPend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }
        }
    }
}

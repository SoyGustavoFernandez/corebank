using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmChequePorCliente : frmBase
    {
        public int idMotOpeBco = 0, idEntidad, idMoneda,idTipoFondo=0;
        public string idCli = "", cNumeroCuenta, nNroCheque, nSerie, cNroDNI = "";
        public decimal nMontoCheque;
        clsCNRetiroChequeGer clsOpe = new clsCNRetiroChequeGer();
        public frmChequePorCliente()
        {
            InitializeComponent();
        }

        private void frmChequePorCliente_Load(object sender, EventArgs e)
        {
            DataTable dtChequePorCli = clsOpe.CNListaChequesByCli(idCli, idMotOpeBco, idMoneda,idTipoFondo,cNroDNI);
            if (dtChequePorCli.Rows.Count>0)
            {
                dtgChequesByCLi.DataSource = dtChequePorCli;
                FormatoGrid();
            }
            else
            {
                MessageBox.Show("No se encontró cheque(s) relacionado(s) a Cliente", "Validación de Cheques por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        private void FormatoGrid()
        {
            dtgChequesByCLi.Columns["cNumeroCuenta"].Visible = true;
            dtgChequesByCLi.Columns["nNroCheque"].Visible = true;
            dtgChequesByCLi.Columns["nSerie"].Visible = true;
            dtgChequesByCLi.Columns["idEntidad"].Visible = false;
            dtgChequesByCLi.Columns["idMoneda"].Visible = false;
            dtgChequesByCLi.Columns["nMonto"].Visible = true;
            dtgChequesByCLi.Columns["cNombreCorto"].Visible = true;
            dtgChequesByCLi.Columns["cMoneda"].Visible = true;
            dtgChequesByCLi.Columns["cNombreCorto"].HeaderText = "Entidad";
            dtgChequesByCLi.Columns["cNumeroCuenta"].HeaderText = "Nro.Cuenta";
            dtgChequesByCLi.Columns["cMoneda"].HeaderText = "Moneda";
            dtgChequesByCLi.Columns["nSerie"].HeaderText = "Serie";
            dtgChequesByCLi.Columns["nNroCheque"].HeaderText = "Nro.Cheque";
            dtgChequesByCLi.Columns["nMonto"].HeaderText = "Monto";
            dtgChequesByCLi.Columns["cNombreCorto"].Width = 100;
            dtgChequesByCLi.Columns["cNumeroCuenta"].Width = 100;
            dtgChequesByCLi.Columns["cMoneda"].Width = 80;
            dtgChequesByCLi.Columns["nSerie"].Width = 50;
            dtgChequesByCLi.Columns["nNroCheque"].Width = 50;
            dtgChequesByCLi.Columns["nMonto"].Width = 50;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgChequesByCLi.RowCount > 0)
            {
                cNumeroCuenta = dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["cNumeroCuenta"].Value.ToString();
                nNroCheque = dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["nNroCheque"].Value.ToString();
                nSerie = dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["nSerie"].Value.ToString();
                idEntidad = Convert.ToInt32(dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["idEntidad"].Value);
                idMoneda = Convert.ToInt32(dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["idMoneda"].Value);
                nMontoCheque = Convert.ToDecimal(dtgChequesByCLi.Rows[dtgChequesByCLi.SelectedCells[0].RowIndex].Cells["nMonto"].Value);
            }
            else
            {
                cNumeroCuenta="";
                nNroCheque = "";
                nSerie = "";
                idEntidad = 0;
                idMoneda = 0;
            }
            this.Close();
        }
    }
}

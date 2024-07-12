using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;

namespace CAJ.Presentacion
{
    public partial class frmConsultaBilHab : frmBase
    {
        clsCNControlOpe LisConOpe = new clsCNControlOpe();
        public frmConsultaBilHab()
        {
            InitializeComponent();
        }
        public frmConsultaBilHab(DateTime dFecProc, int idMoneda, int idHab)
        {
            InitializeComponent();
            //--Reiniciar Valores
            this.txtMonMoneda.Text = "0.00";
            this.txtMonBillete.Text = "0.00";
            this.txtMonTotal.Text = "0.00";
            //--Cargar Datos del Billetaje
            ListarMonedaSoles(dFecProc, idMoneda, idHab);
            ListarBilleteSoles(dFecProc, idMoneda, idHab);
            SumaMonSol();
        }
        
        private void ListarMonedaSoles(DateTime dFecProc, int idMoneda, int idHab)
        {
            string msge = "";

            DataTable tbMon = LisConOpe.ListarBilletajeXHab(dFecProc, idMoneda, 1, idHab, ref msge);
            if (msge == "OK")
            {
                this.dtgMonedas.DataSource = tbMon;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtMonMoneda.Text = tbMon.Compute("SUM(nTotal)", "").ToString();
        }

        private void ListarBilleteSoles(DateTime dFecProc,int idMoneda, int idHab)
        {
            
            string msge = "";

            DataTable tbBill = LisConOpe.ListarBilletajeXHab(dFecProc, idMoneda, 2, idHab, ref msge);
            if (msge == "OK")
            {
                this.dtgBilletes.DataSource = tbBill;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de Billetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtMonBillete.Text = tbBill.Compute("SUM(nTotal)", "").ToString();
        }

        private void SumaMonSol()
        {
            this.txtMonMoneda.Text = (this.txtMonMoneda.Text.Trim().Equals("")) ? "0.00" : this.txtMonMoneda.Text;
            this.txtMonBillete.Text = (this.txtMonBillete.Text.Trim().Equals("")) ? "0.00" : this.txtMonBillete.Text;
            this.txtMonTotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtMonMoneda.Text) + Convert.ToDecimal (this.txtMonBillete.Text)), 2));
        }

        private void frmConsultaBilHab_Load(object sender, EventArgs e)
        {
            dtgMonedas.Columns["cDescripcionM"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgMonedas.Columns["nCantidadM"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgMonedas.Columns["nTotalM"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgMonedas.Columns["nTotalM"].DefaultCellStyle.Format = "N2";
            dtgBilletes.Columns["cDescripcionB"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["nCantidadB"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["nTotalB"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["nTotalB"].DefaultCellStyle.Format = "N2";
        }

    }
}

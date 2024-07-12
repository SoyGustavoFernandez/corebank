using GEN.ControlesBase;
using System.Data;
using System.Windows.Forms;

namespace CAJ.Presentacion
{
    public partial class frmDetalleCargaComprobantesMasivo : frmBase
    {
        private string cSerie;
        private string cNumero;
        private DataTable dtDetalle;

        public frmDetalleCargaComprobantesMasivo(string cSerie, string cNumero, DataTable dtDetalle)
        {
            InitializeComponent();
            this.cSerie = cSerie;
            this.cNumero = cNumero;
            this.dtDetalle = dtDetalle;
        }

        private void frmDetalleCargaComprobantesMasivo_Load(object sender, System.EventArgs e)
        {
            this.txtSerie.Text = this.cSerie;
            this.txtNumero.Text = this.cNumero;

            this.dtgDetalle.DataSource = this.dtDetalle;

            foreach (DataGridViewColumn col in this.dtgDetalle.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}

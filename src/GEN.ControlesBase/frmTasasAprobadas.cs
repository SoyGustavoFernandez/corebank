using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmTasasAprobadas : frmBase
    {
        private List<clsTasaNegociable> listaTasasNegociables;

        public frmTasasAprobadas()
        {
            InitializeComponent();
        }

        public frmTasasAprobadas(List<clsTasaNegociable> _listaTasasNegociables)
        {
            InitializeComponent();
            FormatearDataGridView();

            this.dtgTasasAprobadas.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgTasasAprobadas_DataBindingComplete);

            this.listaTasasNegociables = _listaTasasNegociables;
            this.dtgTasasAprobadas.DataSource = this.listaTasasNegociables;
            FormatearColumnasDGV();

            this.dtgTasasAprobadas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgTasasAprobadas_DataBindingComplete);

        }

        private void FormatearDataGridView()
        {
            this.dtgTasasAprobadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgTasasAprobadas.Margin = new System.Windows.Forms.Padding(0);
            this.dtgTasasAprobadas.MultiSelect = false;
            this.dtgTasasAprobadas.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgTasasAprobadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTasasAprobadas.RowHeadersVisible = false;
            this.dtgTasasAprobadas.ReadOnly = true;
        }

        private void FormatearColumnasDGV()
        {
            foreach (DataGridViewColumn column in this.dtgTasasAprobadas.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgTasasAprobadas.Columns["idTasa"].DisplayIndex = 1;
            //dtgTasasAprobadas.Columns["nSolicitud"].DisplayIndex = 2;
            //dtgTasasAprobadas.Columns["idEstado"].DisplayIndex = 0;

            dtgTasasAprobadas.Columns["idSolicitud"].DisplayIndex = 0;
            dtgTasasAprobadas.Columns["dFechaReg"].DisplayIndex = 1;
            dtgTasasAprobadas.Columns["cUsuAprueba"].DisplayIndex = 2;
            dtgTasasAprobadas.Columns["nTasaSolicitada"].DisplayIndex = 3;
            dtgTasasAprobadas.Columns["nTasaPreAprobada"].DisplayIndex = 4; //
            dtgTasasAprobadas.Columns["nTasaAprobada"].DisplayIndex = 5;
            dtgTasasAprobadas.Columns["nTasaMoratoriaSol"].DisplayIndex = 6;
            dtgTasasAprobadas.Columns["cDescEstado"].DisplayIndex = 7;
            dtgTasasAprobadas.Columns["cProducto"].DisplayIndex = 8;
            dtgTasasAprobadas.Columns["cMoneda"].DisplayIndex = 9;
            dtgTasasAprobadas.Columns["nCapitalSolicitado"].DisplayIndex = 10;
            dtgTasasAprobadas.Columns["nCuotas"].DisplayIndex = 11;
            dtgTasasAprobadas.Columns["cDescripTipoPeriodo"].DisplayIndex = 12;
            dtgTasasAprobadas.Columns["nPlazoCuota"].DisplayIndex = 13;
            dtgTasasAprobadas.Columns["nDiasGracia"].DisplayIndex = 14;
            dtgTasasAprobadas.Columns["nCuotasGracia"].DisplayIndex = 15;
            dtgTasasAprobadas.Columns["FechaDesembolso"].DisplayIndex = 16;

            dtgTasasAprobadas.Columns["idSolicitud"].Visible = true;
            dtgTasasAprobadas.Columns["dFechaReg"].Visible = true;
            dtgTasasAprobadas.Columns["cUsuAprueba"].Visible = true;
            dtgTasasAprobadas.Columns["nTasaSolicitada"].Visible = true;
            dtgTasasAprobadas.Columns["nTasaPreAprobada"].Visible = true; //
            dtgTasasAprobadas.Columns["nTasaAprobada"].Visible = true;
            dtgTasasAprobadas.Columns["nTasaMoratoriaSol"].Visible = true;
            dtgTasasAprobadas.Columns["cDescEstado"].Visible = true;
            dtgTasasAprobadas.Columns["cProducto"].Visible = true;
            dtgTasasAprobadas.Columns["cMoneda"].Visible = true;
            dtgTasasAprobadas.Columns["nCapitalSolicitado"].Visible = true;
            dtgTasasAprobadas.Columns["nCuotas"].Visible = true;
            dtgTasasAprobadas.Columns["cDescripTipoPeriodo"].Visible = true;
            dtgTasasAprobadas.Columns["nPlazoCuota"].Visible = true;
            dtgTasasAprobadas.Columns["nDiasGracia"].Visible = true;
            dtgTasasAprobadas.Columns["nCuotasGracia"].Visible = true;
            dtgTasasAprobadas.Columns["FechaDesembolso"].Visible = true;

            dtgTasasAprobadas.Columns["idSolicitud"].HeaderText = "Cod. Solicitud";
            dtgTasasAprobadas.Columns["dFechaReg"].HeaderText = "Fecha Reg";
            dtgTasasAprobadas.Columns["cUsuAprueba"].HeaderText = "Aprobador";
            dtgTasasAprobadas.Columns["nTasaSolicitada"].HeaderText = "Tasa Solicitada(%)";
            dtgTasasAprobadas.Columns["nTasaPreAprobada"].HeaderText = "Tasa PreAprobada(%)"; //
            dtgTasasAprobadas.Columns["nTasaAprobada"].HeaderText = "Tasa Aprobada(%)";
            dtgTasasAprobadas.Columns["nTasaMoratoriaSol"].HeaderText = "Tasa Moratoria(%)";
            dtgTasasAprobadas.Columns["cDescEstado"].HeaderText = "Estado";
            dtgTasasAprobadas.Columns["cProducto"].HeaderText = "SubProducto";
            dtgTasasAprobadas.Columns["cMoneda"].HeaderText = "Moneda";
            dtgTasasAprobadas.Columns["nCapitalSolicitado"].HeaderText = "Capital Solicitado";
            dtgTasasAprobadas.Columns["nCuotas"].HeaderText = "Nro. Cuotas";
            dtgTasasAprobadas.Columns["cDescripTipoPeriodo"].HeaderText = "Tipo Periodo";
            dtgTasasAprobadas.Columns["nPlazoCuota"].HeaderText = "Frecuencia / Dia pago";
            dtgTasasAprobadas.Columns["nDiasGracia"].HeaderText = "Dias Gracia";
            dtgTasasAprobadas.Columns["nCuotasGracia"].HeaderText = "Cuotas Gracia";
            dtgTasasAprobadas.Columns["FechaDesembolso"].HeaderText = "Fecha Desemb.";

            dtgTasasAprobadas.Columns["nTasaSolicitada"].DefaultCellStyle.Format = "n4";
            dtgTasasAprobadas.Columns["nTasaPreAprobada"].DefaultCellStyle.Format = "n4";
            dtgTasasAprobadas.Columns["nTasaAprobada"].DefaultCellStyle.Format = "n4";
            dtgTasasAprobadas.Columns["nTasaMoratoriaSol"].DefaultCellStyle.Format = "n4";
            dtgTasasAprobadas.Columns["nCapitalSolicitado"].DefaultCellStyle.Format = "n2";
        }

        private void dtgTasasAprobadas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int idEstado = 0;
            foreach (DataGridViewRow row in this.dtgTasasAprobadas.Rows)
            {
                idEstado = Convert.ToInt32(row.Cells["idEstado"].Value);

                if (idEstado.In(2, 3))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtgDetalleAprobacion(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgTasasAprobadas.Rows.Count > 0 && dtgTasasAprobadas.SelectedRows.Count > 0)
            {
                clsTasaNegociable objNegociable = (clsTasaNegociable)dtgTasasAprobadas.SelectedRows[0].DataBoundItem;

                int idSolicitudCre = objNegociable.idSolicitud;
                int idTasaNegociable = objNegociable.idTasaNegociada;
                int idUsuario = clsVarGlobal.User.idUsuario;

                conRastreoTasaNegociable.cargarDatos(idSolicitudCre, idTasaNegociable, idUsuario);
            }            
        }

        private void dtgTasasAprobadas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void frmTasasAprobadas_Load(object sender, EventArgs e)
        {
            if (dtgTasasAprobadas.Rows.Count > 0 && dtgTasasAprobadas.SelectedRows.Count > 0)
            {
                clsTasaNegociable objNegociable = (clsTasaNegociable)dtgTasasAprobadas.SelectedRows[0].DataBoundItem;

                int idSolicitudCre = objNegociable.idSolicitud;
                int idTasaNegociable = objNegociable.idTasaNegociada;
                int idUsuario = clsVarGlobal.User.idUsuario;

                conRastreoTasaNegociable.cargarDatos(idSolicitudCre, idTasaNegociable, idUsuario);
            }
        }
    }
}

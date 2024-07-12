#region Referencias
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
using GEN.CapaNegocio;
using GEN.Funciones;
#endregion


namespace GEN.ControlesBase
{
    public partial class conRastreoTasaNegociable : UserControl
    {
        #region Variables Globales
        public int idSolicitud { get; set; }
        public int idTasaNegociada { get; set; }
        public int idUsuario { get; set; }
        private clsTasaNegociable objTasaNegociable { get; set; }

        public List<clsRastreoTasaNegociable> lstRastreoTasaNegociable { get; set; }
        public BindingSource bsRastreoTasaNegociable { get; set; }
        private clsCNSolicitud objCNSolicitud { get; set; }
        public string cTipoMotivo = "P";
        #endregion

        #region Constructores
        public conRastreoTasaNegociable()
        {
            InitializeComponent();
            cargarComponentes();
        }
        #endregion

        #region Metodos
        public void cargarDatos(int _idSolicitud, int _idTasaNegociada, int _idUsuario)
        {
            this.idSolicitud = _idSolicitud;
            this.idTasaNegociada = _idTasaNegociada;
            this.idUsuario = _idUsuario;

            List<clsRastreoTasaNegociable> lstRastreo = objCNSolicitud.CNObtenerRastreoTasaNegociable(this.idSolicitud, this.idTasaNegociada, this.idUsuario).ToList<clsRastreoTasaNegociable>() as List<clsRastreoTasaNegociable>;
            lstRastreoTasaNegociable.Clear();
            lstRastreoTasaNegociable.AddRange(lstRastreo);
            bsRastreoTasaNegociable.DataSource = lstRastreoTasaNegociable;
            dtgRastreoTasaNegociable.DataSource = bsRastreoTasaNegociable;
            formatearGridRasteroTasaNegociable();
            bsRastreoTasaNegociable.ResetBindings(true);
            dtgRastreoTasaNegociable.Refresh();
            foreach (DataGridViewColumn column in dtgRastreoTasaNegociable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void cargarComponentes()
        {
            this.idSolicitud = 0;
            this.idTasaNegociada = 0;
            this.idUsuario = 0;
            objCNSolicitud = new clsCNSolicitud();
            objTasaNegociable = new clsTasaNegociable();
            lstRastreoTasaNegociable = new List<clsRastreoTasaNegociable>();
            bsRastreoTasaNegociable = new BindingSource();
        }

        public void formatearGridRasteroTasaNegociable()
        {
            dtgRastreoTasaNegociable.ReadOnly = true;
            dtgRastreoTasaNegociable.ShowCellToolTips = true;

            foreach (DataGridViewColumn dgvColumna in dtgRastreoTasaNegociable.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgRastreoTasaNegociable.Columns["nOrden"].Visible                  = true;
            dtgRastreoTasaNegociable.Columns["cEstado"].Visible                 = true;
            dtgRastreoTasaNegociable.Columns["cNivelAprRanOpe"].Visible         = true;
            dtgRastreoTasaNegociable.Columns["cWinUser"].Visible                = true;
            dtgRastreoTasaNegociable.Columns["cOpinion"].Visible                = true;
            dtgRastreoTasaNegociable.Columns["cTipoTasa"].Visible               = true;
            dtgRastreoTasaNegociable.Columns["nTasaPropuesta"].Visible          = true;
            dtgRastreoTasaNegociable.Columns["cAgenciaUsuarioOpinion"].Visible  = true;
            dtgRastreoTasaNegociable.Columns["cPerfilEmiteOpinion"].Visible     = true;
            dtgRastreoTasaNegociable.Columns["dFechaHoraEmiteOpinion"].Visible  = true;

            dtgRastreoTasaNegociable.Columns["nOrden"].HeaderText                   = "Nro.";
            dtgRastreoTasaNegociable.Columns["cEstado"].HeaderText                  = "Estado";
            dtgRastreoTasaNegociable.Columns["cNivelAprRanOpe"].HeaderText          = "Nivel";
            dtgRastreoTasaNegociable.Columns["cWinUser"].HeaderText                 = "Usuario";
            dtgRastreoTasaNegociable.Columns["cPerfilEmiteOpinion"].HeaderText      = "Perfil";
            dtgRastreoTasaNegociable.Columns["nTasaPropuesta"].HeaderText           = "Tasa";
            dtgRastreoTasaNegociable.Columns["cOpinion"].HeaderText                 = "Opinión / Justificación";
            dtgRastreoTasaNegociable.Columns["cAgenciaUsuarioOpinion"].HeaderText   = "Agencia";
            dtgRastreoTasaNegociable.Columns["cTipoTasa"].HeaderText                = "Tipo de Tasa";
            dtgRastreoTasaNegociable.Columns["dFechaHoraEmiteOpinion"].HeaderText   = "Fecha y Hora";

            dtgRastreoTasaNegociable.Columns["nOrden"].Width                    = 30;
            dtgRastreoTasaNegociable.Columns["cEstado"].Width                   = 85;
            dtgRastreoTasaNegociable.Columns["cNivelAprRanOpe"].Width           = 150;
            dtgRastreoTasaNegociable.Columns["cWinUser"].Width                  = 125;
            dtgRastreoTasaNegociable.Columns["cOpinion"].Width                  = 200;
            dtgRastreoTasaNegociable.Columns["cTipoTasa"].Width                 = 125;
            dtgRastreoTasaNegociable.Columns["nTasaPropuesta"].Width            = 60;
            dtgRastreoTasaNegociable.Columns["cAgenciaUsuarioOpinion"].Width    = 150;
            dtgRastreoTasaNegociable.Columns["cPerfilEmiteOpinion"].Width       = 150;
            dtgRastreoTasaNegociable.Columns["dFechaHoraEmiteOpinion"].Width    = 125;

            dtgRastreoTasaNegociable.Columns["nOrden"].DisplayIndex                 = 1;
            dtgRastreoTasaNegociable.Columns["cEstado"].DisplayIndex                = 2;
            dtgRastreoTasaNegociable.Columns["cNivelAprRanOpe"].DisplayIndex        = 3;
            dtgRastreoTasaNegociable.Columns["cWinUser"].DisplayIndex               = 4;
            dtgRastreoTasaNegociable.Columns["cPerfilEmiteOpinion"].DisplayIndex    = 5;
            dtgRastreoTasaNegociable.Columns["nTasaPropuesta"].DisplayIndex         = 6;
            dtgRastreoTasaNegociable.Columns["cOpinion"].DisplayIndex               = 7;
            dtgRastreoTasaNegociable.Columns["cAgenciaUsuarioOpinion"].DisplayIndex = 8;
            dtgRastreoTasaNegociable.Columns["cTipoTasa"].DisplayIndex              = 9;
            dtgRastreoTasaNegociable.Columns["dFechaHoraEmiteOpinion"].DisplayIndex = 10;

        }

        private void mostrarDetalleRastreo()
        {
            if (dtgRastreoTasaNegociable.SelectedRows.Count > 0)
            {
                int nIndex = (dtgRastreoTasaNegociable.SelectedRows.Count > 0) ? dtgRastreoTasaNegociable.SelectedRows[0].Index : -1;
                clsRastreoTasaNegociable objRastreo = (clsRastreoTasaNegociable)dtgRastreoTasaNegociable.SelectedRows[0].DataBoundItem;
                
                if (nIndex != -1)
                {
                    frmRastreoTasaNegociable frmRastreoNegociable = new frmRastreoTasaNegociable();
                    frmRastreoNegociable.cargarRastreoTasaNegociable(objRastreo);
                    frmRastreoNegociable.cTipoMotivo = cTipoMotivo;
                    frmRastreoNegociable.ShowDialog();
                }
            }
        }

        public void limpiar()
        {
            this.idSolicitud        = 0;
            this.idTasaNegociada    = 0;
            this.idUsuario          = 0;

            lstRastreoTasaNegociable.Clear();
            bsRastreoTasaNegociable.ResetBindings(true);
            dtgRastreoTasaNegociable.Refresh();
        }
        #endregion

        #region Eventos
        private void dtgRastreoTasaNegociable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarDetalleRastreo();
        }

        private void btnMiniDetalle_Click(object sender, EventArgs e)
        {
            mostrarDetalleRastreo();
        }
        private void dtgRastreoTasaNegociable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    // Dibujar el texto centrado en la celda de cabecera
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds, format);
                }
                e.Handled = true;
            }
        }
        #endregion


    }
}

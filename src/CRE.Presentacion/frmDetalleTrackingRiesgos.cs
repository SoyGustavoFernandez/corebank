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
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using System.Xml.Linq;
using GEN.Funciones;
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDetalleTrackingRiesgos : frmBase
    {
        private clsCNInformeRiesgos objRiesgos = new clsCNInformeRiesgos();
        private clsCNExcepcionesCreditos objCNExcepciones = new clsCNExcepcionesCreditos();
        private clsCNExcepcionesCreditos cnexcepcionesCreditos = new clsCNExcepcionesCreditos();
        private List<clsConfigDataGridView> listConfigDtg = new List<clsConfigDataGridView>();
        private List<clsExcepcionReglaNeg> lstExcepcionRegla = new List<clsExcepcionReglaNeg>();
        private List<clsExcepcionReglaNeg> lstRegularizacion = new List<clsExcepcionReglaNeg>();
        public int idSolicitud;
        public string cModo;

        public frmDetalleTrackingRiesgos()
        {
            InitializeComponent();
            this.cModo = "Opinion";
        }

        private void frmDetalleTrackingRiesgos_Load(object sender, EventArgs e)
        {
            switch (this.cModo)
            {
                case "Opinion":
                    CargarObservacionesOpinion();
                    ConfigDataGridViewOpinion();
                    break;
                case "Excepcion":
                    CargarObservacionesExcep();
                    ConfigDataGridViewExcepcion();
                    DescripDetalle();
                    break;
                default:
                    break;
            }
            this.lblSolicitud.Text = this.idSolicitud.ToString();
        }

        private void CargarObservacionesOpinion()
        {
            DataTable dtOpinion = objRiesgos.CNObtenerTrakingOpinionRiesgo(this.idSolicitud, 1);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtOpinion;
            this.dtgTrakingRiesgos.DataSource = bindingSource;
        }

        private void CargarObservacionesExcep()
        {
            DataTable dtExcep = objRiesgos.CNObtenerTrakingOpinionRiesgo(this.idSolicitud, 2);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtExcep;
            this.dtgTrakingRiesgos.DataSource = bindingSource;
        }

        private void ConfigDataGridViewOpinion()
        {
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cAnalista", cNombre = "USUARIO", nWidth = 280 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEstado", cNombre = "ESTADO", nWidth = 110 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cDetalle", cNombre = "DETALLE", nWidth = 150 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cFecha", cNombre = "FECHA", nWidth = 120 });

            foreach (DataGridViewColumn columna in this.dtgTrakingRiesgos.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgTrakingRiesgos.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgTrakingRiesgos.Columns[columna.Index].Width = objItemConfig.nWidth;
                }
                else
                {
                    this.dtgTrakingRiesgos.Columns[columna.Index].Visible = false;
                }
            }

            for (int i = 0; i < dtgTrakingRiesgos.Rows.Count; i++)
            {
                dtgTrakingRiesgos.Rows[i].Cells["cDetalle"].Style.WrapMode = DataGridViewTriState.True;
                dtgTrakingRiesgos.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgTrakingRiesgos.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }

        private void ConfigDataGridViewExcepcion()
        {
            this.dtgTrakingRiesgos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgTrakingRiesgos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cUsuReg", cNombre = "USU. REG.", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cUsuAprob", cNombre = "USU. APROB.", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEstado", cNombre = "ESTADO", nWidth = 90 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cComentarioAprobador", cNombre = "COMENTARIO", nWidth = 110 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cSustento", cNombre = "SUSTENTO", nWidth = 110 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFecHraRegistro", cNombre = "FECHA REG.", nWidth = 100 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFechaIniRev", cNombre = "FECHA INI.", nWidth = 100 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFechaFinRev", cNombre = "FECHA FIN.", nWidth = 100 });

            foreach (DataGridViewColumn columna in this.dtgTrakingRiesgos.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgTrakingRiesgos.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgTrakingRiesgos.Columns[columna.Index].Width = objItemConfig.nWidth;
                }
                else
                {
                    this.dtgTrakingRiesgos.Columns[columna.Index].Visible = false;
                }
            }
        }

        private void DescripDetalle()
        {
            for (int i = 0; i < dtgTrakingRiesgos.Rows.Count; i++)
            {
                dtgTrakingRiesgos.Rows[i].Cells["cComentarioAprobador"].Style.WrapMode = DataGridViewTriState.True;
                dtgTrakingRiesgos.Rows[i].Cells["cSustento"].Style.WrapMode = DataGridViewTriState.True;
                dtgTrakingRiesgos.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgTrakingRiesgos.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }

        private void dtgTrakingRiesgos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                using (Font font = new Font(this.dtgTrakingRiesgos.Font, FontStyle.Bold))
                {
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        using (Brush backBrush = new SolidBrush(Color.Blue))
                        {
                            e.PaintBackground(e.CellBounds, true);
                            e.Graphics.FillRectangle(backBrush, e.CellBounds);
                            e.Graphics.DrawString(e.Value.ToString(), font, textBrush, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void dtgTrakingRiesgos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dtgTrakingRiesgos.Rows[e.RowIndex];
                if (this.cModo == "Opinion") { 
                    if ((row.Cells["cFecha"].Value != null ? (row.Cells["cFecha"].Value).ToString() : "") == "")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.FromArgb(204, 255, 204);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                    }
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(204, 255, 204);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                }
            }
        }
    }
}

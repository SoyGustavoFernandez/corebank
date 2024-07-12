using System;
using CRE.CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using System.Xml.Linq;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmDetProcesObserv : frmBase
    {
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private List<clsConfigDataGridView> listConfigDtg = new List<clsConfigDataGridView>();
        public int idRegistroObs;
        public int idSolicitud;

        public frmDetProcesObserv()
        {
            InitializeComponent();
        }

        private void frmDetProcesObserv_Load(object sender, EventArgs e)
        {
            CargarObservaciones();
            ConfigDataGridView();
            this.lblSolicitud.Text = this.idSolicitud.ToString();
        }

        private void CargarObservaciones()
        {
            DataTable dtObserv = objCNGestionObservaciones.DetalleObservCredito(this.idRegistroObs);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtObserv;
            this.dtgObservaciones.DataSource = bindingSource;
        }

        private void ConfigDataGridView()
        {
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cDescripcion", cNombre = "DESCRIPCIÓN", nWidth = 315 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cWinUser", cNombre = "USUARIO", nWidth = 110 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cPerfil", cNombre = "PERFIL", nWidth = 150 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEtapa", cNombre = "ETAPA", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEstado", cNombre = "ESTADO", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFechaReg", cNombre = "FECHA", nWidth = 110 });

            foreach (DataGridViewColumn columna in this.dtgObservaciones.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgObservaciones.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgObservaciones.Columns[columna.Index].Width = objItemConfig.nWidth;
                }
                else
                {
                    this.dtgObservaciones.Columns[columna.Index].Visible = false;
                }
            }

            for (int i = 0; i < dtgObservaciones.Rows.Count; i++)
            {
                dtgObservaciones.Rows[i].Cells["cDescripcion"].Style.WrapMode = DataGridViewTriState.True;
                dtgObservaciones.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgObservaciones.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }

        }

        private void dtgObservaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                using (Font font = new Font(this.dtgObservaciones.Font, FontStyle.Bold))
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

    }
}

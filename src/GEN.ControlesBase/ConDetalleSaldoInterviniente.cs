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
#endregion

namespace GEN.ControlesBase
{
    public partial class ConDetalleSaldoInterviniente : UserControl
    {
        #region Variables Globales
        List<clsDetalleSaldoInterviniente> lstDetalleSaldo { get; set; }
        BindingSource bsDetalleSaldo { get; set; }
        #endregion

        #region Constructores
        public ConDetalleSaldoInterviniente()
        {
            InitializeComponent();

            lstDetalleSaldo = new List<clsDetalleSaldoInterviniente>();
            bsDetalleSaldo = new BindingSource();
        }
        #endregion

        #region Métodos
        public void AsignarDatos(List<clsDetalleSaldoInterviniente> _lstDetalleInterviniente)
        {
            lstDetalleSaldo = _lstDetalleInterviniente;

            this.bsDetalleSaldo.DataSource = lstDetalleSaldo;
            this.dtgDetalleInterviniente.DataSource = this.bsDetalleSaldo;

            FormatearDataGricViewDetalleInterviniente();
            this.dtgDetalleInterviniente.Refresh();
        }

        private void FormatearDataGricViewDetalleInterviniente()
        {
            dtgDetalleInterviniente.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;

            foreach (DataGridViewColumn column in this.dtgDetalleInterviniente.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgDetalleInterviniente.Columns["idCliente"].DisplayIndex = 0;
            dtgDetalleInterviniente.Columns["cNombre"].DisplayIndex = 1;
            dtgDetalleInterviniente.Columns["cTipoIntervencionCre"].DisplayIndex = 2;
            dtgDetalleInterviniente.Columns["lParticipa"].DisplayIndex = 3;
            dtgDetalleInterviniente.Columns["cClasificacionInterna"].DisplayIndex = 4;
            dtgDetalleInterviniente.Columns["cCalificativoSBS"].DisplayIndex = 5;
            dtgDetalleInterviniente.Columns["nSaldoRCC"].DisplayIndex = 6;
            dtgDetalleInterviniente.Columns["cSaldoMaxRCC"].DisplayIndex = 7;
            dtgDetalleInterviniente.Columns["cCalifivativoAvaladoSBS"].DisplayIndex = 8;
            dtgDetalleInterviniente.Columns["nMoraMax"].DisplayIndex = 9;
            dtgDetalleInterviniente.Columns["nMoraPromedio"].DisplayIndex = 10;
            dtgDetalleInterviniente.Columns["cAvanceDeudaInt"].DisplayIndex = 11;
            dtgDetalleInterviniente.Columns["cProductoDestAnt"].DisplayIndex = 12;
            dtgDetalleInterviniente.Columns["cProductoDestAct"].DisplayIndex = 13;

            dtgDetalleInterviniente.Columns["idCliente"].Visible = true;
            dtgDetalleInterviniente.Columns["cNombre"].Visible = true;
            dtgDetalleInterviniente.Columns["lParticipa"].Visible = true;
            dtgDetalleInterviniente.Columns["cTipoIntervencionCre"].Visible = true;
            dtgDetalleInterviniente.Columns["cClasificacionInterna"].Visible = true;
            dtgDetalleInterviniente.Columns["cCalificativoSBS"].Visible = true;
            dtgDetalleInterviniente.Columns["nSaldoRCC"].Visible = true;
            dtgDetalleInterviniente.Columns["cSaldoMaxRCC"].Visible = true;
            dtgDetalleInterviniente.Columns["cCalifivativoAvaladoSBS"].Visible = true;
            dtgDetalleInterviniente.Columns["nMoraMax"].Visible = true;
            dtgDetalleInterviniente.Columns["nMoraPromedio"].Visible = true;
            dtgDetalleInterviniente.Columns["cAvanceDeudaInt"].Visible = true;
            dtgDetalleInterviniente.Columns["cProductoDestAnt"].Visible = true;
            dtgDetalleInterviniente.Columns["cProductoDestAct"].Visible = true;

            dtgDetalleInterviniente.Columns["idCliente"].HeaderText = "Cod. Cliente";
            dtgDetalleInterviniente.Columns["cNombre"].HeaderText = "Interviniente";
            dtgDetalleInterviniente.Columns["cTipoIntervencionCre"].HeaderText = "Tipo";
            dtgDetalleInterviniente.Columns["lParticipa"].HeaderText = "Participa";
            dtgDetalleInterviniente.Columns["idClasificacionInterna"].HeaderText = "idClasificacionInterna";
            dtgDetalleInterviniente.Columns["cClasificacionInterna"].HeaderText = "Clasificación";
            dtgDetalleInterviniente.Columns["cCalificativoSBS"].HeaderText = "Cal. SBS";
            dtgDetalleInterviniente.Columns["nSaldoRCC"].HeaderText = "Saldo RCC";
            dtgDetalleInterviniente.Columns["nSaldoMaxRCC"].HeaderText = "nSaldoMaxRCC";
            dtgDetalleInterviniente.Columns["cSaldoMaxRCC"].HeaderText = "Saldo RCC Max";
            dtgDetalleInterviniente.Columns["cCalifivativoAvaladoSBS"].HeaderText = "SBS Avalado";
            dtgDetalleInterviniente.Columns["nMoraMax"].HeaderText = "Mora Max";
            dtgDetalleInterviniente.Columns["nMoraPromedio"].HeaderText = "Mora Prom.";
            dtgDetalleInterviniente.Columns["cAvanceDeudaInt"].HeaderText = "Avance (Cuota/Saldo Cap.)";
            dtgDetalleInterviniente.Columns["cProductoDestAnt"].HeaderText = "Prod/Dest Ant";
            dtgDetalleInterviniente.Columns["cProductoDestAct"].HeaderText = "Prod/Dest Act";

            dtgDetalleInterviniente.Columns["idCliente"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cNombre"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["lParticipa"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cTipoIntervencionCre"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["idClasificacionInterna"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cClasificacionInterna"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cCalificativoSBS"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["nSaldoRCC"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["nSaldoMaxRCC"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cSaldoMaxRCC"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cCalifivativoAvaladoSBS"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["nMoraMax"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["nMoraPromedio"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cAvanceDeudaInt"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cProductoDestAnt"].FillWeight = 80;
            dtgDetalleInterviniente.Columns["cProductoDestAct"].FillWeight = 80;

            dtgDetalleInterviniente.Columns["idCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["lParticipa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cTipoIntervencionCre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["idClasificacionInterna"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cClasificacionInterna"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cCalificativoSBS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["nSaldoRCC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["nSaldoMaxRCC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cSaldoMaxRCC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cCalifivativoAvaladoSBS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["nMoraMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["nMoraPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cAvanceDeudaInt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cProductoDestAnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalleInterviniente.Columns["cProductoDestAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgDetalleInterviniente.Columns["nSaldoRCC"].DefaultCellStyle.Format = "N2";
            dtgDetalleInterviniente.Columns["nMoraMax"].DefaultCellStyle.Format = "N0";
            dtgDetalleInterviniente.Columns["nMoraPromedio"].DefaultCellStyle.Format = "N0";

        }



        #endregion

        #region Eventos

        private void dtgDetalleInterviniente_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Se ingresó un valor invalido en la celda.\nVer Columna \""
                    + dtg.CurrentCell.OwningColumn.HeaderText + "\" y fila " + (e.RowIndex + 1) + ".",
                    "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if ((e.Exception) is ConstraintException)
            {
                dtg.Rows[e.RowIndex].ErrorText = "an error";
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }
        #endregion

        private void dtgDetalleInterviniente_SelectionChanged(object sender, EventArgs e)
        {
            dtgDetalleInterviniente.ClearSelection();
        }
    }
}


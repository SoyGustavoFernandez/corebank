using System;
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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmTransfIngresoAlmacen : frmBase
    {
        #region Variables Globales

        clsCNAlmacen cnalmacen = new clsCNAlmacen();
        public clsTransferenciaAlmacen objTransf;
        private List<clsTransferenciaAlmacen> lstTransferencia = new List<clsTransferenciaAlmacen>();
        private const string cTituloMsjes = "Busqueda Transferencias";


        #endregion

        #region Eventos
        
        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboAgencias.SelectedIndex = -1;
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            if (clsVarGlobal.nIdAgencia != 1)
            {
                cboAgencias.Enabled = false;
            }
            
            ListarTransferencias();
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt32(cboAgencias.SelectedValue));
            }
        }

       

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            ListarTransferencias();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una transferencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;
            objTransf.lstDetTransf = (List<clsDetTranfAlmacen>)dtgDetalleTransferencia.DataSource;
            if (objTransf.lstDetTransf.Where(x => x.nPorEntregar > 0).ToList().Count == 0)
            {
                MessageBox.Show("Todos los items de la orden de compra ya fueron entregados.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Dispose();
        }

        #endregion

        #region Metodos

        public frmTransfIngresoAlmacen()
        {
            InitializeComponent();
        }

        private void ListarTransferencias()
        {
            LimpiarGridViews();
            int idAlmacenDes = 0;            
            if (cboAlmacen.SelectedIndex >= 0)
            {
                idAlmacenDes = Convert.ToInt32(cboAlmacen.SelectedValue);
                lstTransferencia = new clsCNAlmacen().CNListaSolicitudTransferencia(dtpFecIni.Value, dtpFecFin.Value, -1,idAlmacenDes, Convert.ToInt16(EstLog.APROBADO));
            }
            dtgTransferencias.DataSource = lstTransferencia;
            FormatoTransferencia();
            if (lstTransferencia.Count > 0)
            {
                ListarDetalleTransferencia();
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }

        private void ListarDetalleTransferencia()
        {
            if (dtgTransferencias.SelectedRows.Count > 0)
            {
                var objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;

                var lstDetTrans = cnalmacen.ListaDetalleTransferencia(objTransf.idTrasferencias);
                dtgDetalleTransferencia.DataSource = lstDetTrans.Where(x => x.lVigente == true).ToList();
                FormatoDetalle();
                dtgDetalleTransferencia.ReadOnly = true;

                //if (objTransf.lstDetTransf.Count == 0)
                //{
                //    //dtgDetalleTransferencia.DataSource = objTransf.lstDetTransf.Where(x => x.lVigente == true).ToList();
                //    //FormatoDetalle();
                //    return;
                //}

                //var lstDetTrans = cnalmacen.ListarDetTransfIngresoAlmacen(objTransf.idTrasferencias);
                //dtgDetalleTransferencia.DataSource = objTransf.lstDetTransf.Where(x => x.lVigente == true).ToList();
                //FormatoDetalle();
                //dtgDetalleTransferencia.ReadOnly = true;

                if (objTransf.idEstado == Convert.ToInt16(EstLog.APROBADO))
                {
                    btnAceptar.Enabled = true;
                }
                else
                {
                    btnAceptar.Enabled = false;
                }
            }
        }

        private void FormatoTransferencia()
        {
            foreach (DataGridViewColumn item in dtgTransferencias.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTransferencias.Columns["idTrasferencias"].Visible = true;
            dtgTransferencias.Columns["dFechaRegistro"].Visible = true;
            dtgTransferencias.Columns["cAlmacenOri"].Visible = true;

            dtgTransferencias.Columns["idTrasferencias"].HeaderText = "N°";
            dtgTransferencias.Columns["dFechaRegistro"].HeaderText = "Fecha";
            dtgTransferencias.Columns["cAlmacenOri"].HeaderText = "Almacén Origen";

            dtgTransferencias.Columns["idTrasferencias"].FillWeight = 10;
            dtgTransferencias.Columns["dFechaRegistro"].FillWeight = 30;
            dtgTransferencias.Columns["cAlmacenOri"].FillWeight = 60;
        }

        private void FormatoDetalle()
        {
            foreach (DataGridViewColumn column in dtgDetalleTransferencia.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleTransferencia.Columns["nItem"].Visible = true;
            dtgDetalleTransferencia.Columns["cProducto"].Visible = true;
            dtgDetalleTransferencia.Columns["nCantidad"].Visible = true;
            dtgDetalleTransferencia.Columns["nPrecUni"].Visible = true;
            dtgDetalleTransferencia.Columns["nPorEntregar"].Visible = true;

            dtgDetalleTransferencia.Columns["nItem"].HeaderText = "N°";
            dtgDetalleTransferencia.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleTransferencia.Columns["nCantidad"].HeaderText = "Cant. Enviada";
            dtgDetalleTransferencia.Columns["nPorEntregar"].HeaderText = "Por Entregar";
            dtgDetalleTransferencia.Columns["nPrecUni"].HeaderText = "P.U.";

            dtgDetalleTransferencia.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleTransferencia.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleTransferencia.Columns["nCantidad"].DisplayIndex = 2;
            dtgDetalleTransferencia.Columns["nPorEntregar"].DisplayIndex = 3;
            dtgDetalleTransferencia.Columns["nPrecUni"].DisplayIndex = 4;

            dtgDetalleTransferencia.Columns["nItem"].FillWeight = 6;
            dtgDetalleTransferencia.Columns["cProducto"].FillWeight = 38;
            dtgDetalleTransferencia.Columns["nCantidad"].FillWeight = 11;
            dtgDetalleTransferencia.Columns["nPorEntregar"].FillWeight = 10;
            dtgDetalleTransferencia.Columns["nPrecUni"].FillWeight = 12;

            dtgDetalleTransferencia.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleTransferencia.Columns["nPorEntregar"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleTransferencia.Columns["nPrecUni"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleTransferencia.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleTransferencia.Columns["nPorEntregar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleTransferencia.Columns["nPrecUni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
        }

        private void LimpiarGridViews()
        {
            dtgTransferencias.DataSource = typeof(List<clsTransferenciaAlmacen>);
            dtgDetalleTransferencia.DataSource = typeof(List<clsDetTranfAlmacen>);
        }

        #endregion

        private void dtgTransferencias_SelectionChanged(object sender, EventArgs e)
        {
            ListarDetalleTransferencia();
        }

    }
}

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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmListadoPreSolictud : frmBase
    {
        #region Variable Globales

        public int idPreSolicitud { get; set; }
        public DataRowView drPreSolicitud { get; set; }
        public int idUsuario { get; set; }
        clsCNPreSolicitud cnpresolicitud = new clsCNPreSolicitud();

        #endregion

        public frmListadoPreSolictud()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lista las presolicitudes de crédito
        /// </summary>
        /// <param name="idUsuario_">código del usuario que realiza la consulta</param>
        public frmListadoPreSolictud(int idUsuario_)
        {
            InitializeComponent();
            idUsuario = idUsuario_;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            cargarPresolicitudes();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgPreSolicitud.CurrentCell != null)
            {
                idPreSolicitud = Convert.ToInt32(dtgPreSolicitud.CurrentRow.Cells["idPreSolicitud"].Value);
                drPreSolicitud = (DataRowView)dtgPreSolicitud.CurrentRow.DataBoundItem;
                this.Dispose();
            }
            else
            {
                idPreSolicitud = 0;
            }
        }

        #endregion

        #region Métodos

        private void cargarPresolicitudes()
        {
            var dtPreSolicitud = cnpresolicitud.CNListarPreSolicitud(0,clsVarGlobal.User.idUsuario);

            if (dtPreSolicitud.Rows.Count > 0)
            {
                dtgPreSolicitud.DataSource = dtPreSolicitud;
                formatoGrid();
            }
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgPreSolicitud.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPreSolicitud.Columns["idPreSolicitud"].Visible = true;
            dtgPreSolicitud.Columns["cNombreCompleto"].Visible = true;
            dtgPreSolicitud.Columns["nMontoSolicitado"].Visible = true;
            dtgPreSolicitud.Columns["nCuotas"].Visible = true;
            dtgPreSolicitud.Columns["dFechaRegistro"].Visible = true;
            dtgPreSolicitud.Columns["cEstado"].Visible = true; 
            dtgPreSolicitud.Columns["cMoneda"].Visible = true;

            dtgPreSolicitud.Columns["idPreSolicitud"].HeaderText = "N°";
            dtgPreSolicitud.Columns["cNombreCompleto"].HeaderText = "Nombres/Razón Social";
            dtgPreSolicitud.Columns["nMontoSolicitado"].HeaderText = "Monto";
            dtgPreSolicitud.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgPreSolicitud.Columns["dFechaRegistro"].HeaderText = "Fecha Reg";
            dtgPreSolicitud.Columns["cEstado"].HeaderText = "Estado";
            dtgPreSolicitud.Columns["cMoneda"].HeaderText = "Moneda";
        }

        #endregion

        
    }
}

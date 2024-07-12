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
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmEntregasRendirAprobados : frmBase
    {
        #region Variables
        public int idUsuario;
        public string cCargo;
        public string cNombre;
        public decimal nMonto;
        public int idConcepto;
        public int idMoneda;
        public string cMotivo;
        public int idEntrega;
        public string cTipoEntrega;
        public int idConceptoDevolucion;
        private clsCNCuentasPorPagar cnCuentasPorPagar = new clsCNCuentasPorPagar();
        #endregion

        #region Metodos
        public frmEntregasRendirAprobados()
        {
            InitializeComponent();
        }

        private void formatoDtg()
        {
            foreach (DataGridViewColumn column in dtgSolicitud.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolicitud.Columns["idEntrega"].Visible = true;
            dtgSolicitud.Columns["cTipoEntrega"].Visible = true;
            dtgSolicitud.Columns["cSimbolo"].Visible = true;
            dtgSolicitud.Columns["nMonto"].Visible = true;
            dtgSolicitud.Columns["cMotivo"].Visible = true;

            dtgSolicitud.Columns["idEntrega"].HeaderText = "Solicitud";
            dtgSolicitud.Columns["cTipoEntrega"].HeaderText = "Tipo";
            dtgSolicitud.Columns["cSimbolo"].HeaderText = "";
            dtgSolicitud.Columns["nMonto"].HeaderText = "Monto";
            dtgSolicitud.Columns["cMotivo"].HeaderText = "Motivo";

            dtgSolicitud.Columns["nMonto"].DefaultCellStyle.Format = "N2";

            dtgSolicitud.Columns["idEntrega"].FillWeight = 10;
            dtgSolicitud.Columns["cTipoEntrega"].FillWeight = 25;
            dtgSolicitud.Columns["cSimbolo"].FillWeight = 5;
            dtgSolicitud.Columns["nMonto"].FillWeight = 15;
            dtgSolicitud.Columns["cMotivo"].FillWeight = 45;

            dtgSolicitud.Columns["idEntrega"].DisplayIndex = 0;
            dtgSolicitud.Columns["cTipoEntrega"].DisplayIndex = 1;
            dtgSolicitud.Columns["cSimbolo"].DisplayIndex = 2;
            dtgSolicitud.Columns["nMonto"].DisplayIndex = 3;
            dtgSolicitud.Columns["cMotivo"].DisplayIndex = 4;
        }

        private void limpiarControles()
        {
            this.conBusCol.LimpiarDatos();
            this.conBusCol.HabilitarControles(true);

            this.dtgSolicitud.DataSource = null;
            this.dtgSolicitud.Rows.Clear();
            this.dtgSolicitud.Columns.Clear();
            this.dtgSolicitud.Refresh();
        }
        #endregion
        
        #region Eventos
        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            if (this.conBusCol.txtNom.Text != "")
            {
                this.conBusCol.txtCod.Enabled = false;
                DataTable dtSolicitudAprob = cnCuentasPorPagar.listarSolicitudesCuentasPagarAprobados(Convert.ToInt32(this.conBusCol.txtCod.Text));
                dtgSolicitud.DataSource = dtSolicitudAprob;
                formatoDtg();
            }
            else
            {
                limpiarControles();
            }            
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitud.SelectedRows.Count > 0)
            {
                idConcepto = Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idConcepto"].Value);
                nMonto = Convert.ToDecimal(dtgSolicitud.SelectedRows[0].Cells["nMonto"].Value);
                idMoneda = Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idMoneda"].Value);
                cMotivo = Convert.ToString(dtgSolicitud.SelectedRows[0].Cells["cMotivo"].Value);
                idEntrega = Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idEntrega"].Value);
                idUsuario = Convert.ToInt32(this.conBusCol.txtCod.Text);
                idConceptoDevolucion = Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idConceptoDevolucion"].Value);
                this.Dispose();
            }
            else
            {
                idConcepto = 0;
                nMonto = -1;
                idUsuario = 0;
                idEntrega = 0;
                idConceptoDevolucion = 0;
            }
            
        }

        private void frmCuentasPorPagarAprobados_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
            if (cTipoEntrega == "EntregasRendir")
            {
                this.Text = "Entregas a Rendir y Viáticos Aprobados";
                this.conBusCol.txtCod.Enabled = true;
                this.conBusCol.btnConsultar.Visible = true;
                this.conBusCol.txtCod.Focus();
                this.btnCancelar1.Visible = true;
            }
            else if (cTipoEntrega == "Rendicion")
            {
                this.Text = "Rendición de Cuentas Aprobadas";
                this.conBusCol.txtCod.Text = idUsuario.ToString();
                this.conBusCol.txtCargo.Text = cCargo;
                this.conBusCol.txtNom.Text = cNombre;
                this.conBusCol.txtCod.Enabled = false;
                this.conBusCol.btnConsultar.Visible = false;
                this.btnCancelar1.Visible = false;
                DataTable dtSolicitudAprob = cnCuentasPorPagar.listarRendicionesAprobadas(idUsuario);
                dtgSolicitud.DataSource = dtSolicitudAprob;
                formatoDtg();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }
        #endregion
    }
}

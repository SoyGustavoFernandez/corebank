#region Referencias
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
using RCP.CapaNegocio;
using EntityLayer;
#endregion

namespace RCP.Presentacion
{
    public partial class frmSeleccionarClientePlanTrabajo : frmBase
    {
        #region Variables Globales
        private List<clsDatosCreditoCliente> lstDatosCreditoCliente { get; set; }
        public List<clsDatosCreditoCliente> lstDatosCreditoClienteSeleccionado { get; set; }
        private BindingSource bsDatosCreditoCliente { get; set; }
        private clsCNPlanTrabajo cnPlanTrabajo { get; set; }
        public int idResumenObjetivoGeneral { get; set; }
        public int idResumenObjetivoEspecifico { get; set; }
        #endregion

        public frmSeleccionarClientePlanTrabajo()
        {
            InitializeComponent();
            cargarComponentesDefecto();
            formatoGridCuetaCliente();
        }
                                
        public frmSeleccionarClientePlanTrabajo(int idObjetivoGeneral, int idObjetivoEspecifico)
        {
            InitializeComponent();
            cargarComponentesDefecto();
            idResumenObjetivoEspecifico = idObjetivoEspecifico;
            idResumenObjetivoGeneral = idObjetivoGeneral;
            formatoGridCuetaCliente();
        }

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lstDatosCreditoClienteSeleccionado = new List<clsDatosCreditoCliente>();
            this.Dispose();
        }
        #endregion

        #region Metodos

        private void cargarComponentesDefecto()
        {
            cnPlanTrabajo                       = new clsCNPlanTrabajo();

            lstDatosCreditoCliente              = new List<clsDatosCreditoCliente>();
            bsDatosCreditoCliente               = new BindingSource();
            bsDatosCreditoCliente.DataSource    = lstDatosCreditoCliente;
            dtgCuentaDetalleAccion.DataSource   =  bsDatosCreditoCliente;

            lstDatosCreditoClienteSeleccionado = new List<clsDatosCreditoCliente>();

        }

        public void cargarDatos(int idUsuario)
        {
            List<clsDatosCreditoCliente> lstDatos = cnPlanTrabajo.CNListarDatosCreditoClienteCartera(idUsuario);

            lstDatosCreditoCliente.AddRange(lstDatos);
            bsDatosCreditoCliente.ResetBindings(false);

            dtgCuentaDetalleAccion.Refresh();
        }

        public void cargarDatos(int idUsuario, int idAgencia, int idResumenObjetivoGeneral, int idResumenObjetivoEspecifico)
        {
            List<clsDatosCreditoCliente> lstDatos = cnPlanTrabajo.CNListarDatosCreditoClienteTramoObjetivo(idUsuario, idAgencia, idResumenObjetivoGeneral, idResumenObjetivoEspecifico);

            lstDatosCreditoCliente.AddRange(lstDatos);
            bsDatosCreditoCliente.ResetBindings(false);

            dtgCuentaDetalleAccion.Refresh();
        }


        private void formatoGridCuetaCliente()
        {
            dtgCuentaDetalleAccion.ReadOnly = false;

            foreach (DataGridViewColumn dgvColumna in dtgCuentaDetalleAccion.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.ReadOnly = true;
            }

            dtgCuentaDetalleAccion.Columns["idCuenta"].Visible          = true;
            dtgCuentaDetalleAccion.Columns["cEstado"].Visible           = true;
            dtgCuentaDetalleAccion.Columns["cContable"].Visible         = true;
            dtgCuentaDetalleAccion.Columns["cNombre"].Visible           = true;
            dtgCuentaDetalleAccion.Columns["idCliente"].Visible         = true;
            dtgCuentaDetalleAccion.Columns["dFechaDesembolso"].Visible  = true;
            dtgCuentaDetalleAccion.Columns["nFrecuencia"].Visible       = true;
            dtgCuentaDetalleAccion.Columns["nMonto"].Visible            = true;
            dtgCuentaDetalleAccion.Columns["nCuotas"].Visible           = true;
            dtgCuentaDetalleAccion.Columns["cProducto"].Visible         = true;
            dtgCuentaDetalleAccion.Columns["nMontoCuota"].Visible       = true;
            dtgCuentaDetalleAccion.Columns["nAtraso"].Visible           = true;
            dtgCuentaDetalleAccion.Columns["cDocumentoID"].Visible      = true;
            dtgCuentaDetalleAccion.Columns["cDireccion"].Visible        = true;
            dtgCuentaDetalleAccion.Columns["cCodCliente"].Visible       = true;
            dtgCuentaDetalleAccion.Columns["cMoneda"].Visible           = true;
            dtgCuentaDetalleAccion.Columns["lSeleccionado"].Visible     = true;

            dtgCuentaDetalleAccion.Columns["idCuenta"].HeaderText           = "Nro. Cuenta";
            dtgCuentaDetalleAccion.Columns["cEstado"].HeaderText            = "Estado";
            dtgCuentaDetalleAccion.Columns["cContable"].HeaderText          = "Estado Contable";
            dtgCuentaDetalleAccion.Columns["cNombre"].HeaderText            = "Nombre";
            dtgCuentaDetalleAccion.Columns["idCliente"].HeaderText          = "Cod. Cliente";
            dtgCuentaDetalleAccion.Columns["dFechaDesembolso"].HeaderText   = "Fecha Desembolso";
            dtgCuentaDetalleAccion.Columns["nFrecuencia"].HeaderText        = "Frecuencia";
            dtgCuentaDetalleAccion.Columns["nMonto"].HeaderText             = "Monto";
            dtgCuentaDetalleAccion.Columns["nCuotas"].HeaderText            = "Cuotas";
            dtgCuentaDetalleAccion.Columns["cProducto"].HeaderText          = "Producto";
            dtgCuentaDetalleAccion.Columns["nMontoCuota"].HeaderText        = "Monto de cuota";
            dtgCuentaDetalleAccion.Columns["nAtraso"].HeaderText            = "Atraso";
            dtgCuentaDetalleAccion.Columns["cDocumentoID"].HeaderText       = "Nro. Documento";
            dtgCuentaDetalleAccion.Columns["cDireccion"].HeaderText         = "Dirección";
            dtgCuentaDetalleAccion.Columns["cCodCliente"].HeaderText        = "Cod. Comp. Cliente";
            dtgCuentaDetalleAccion.Columns["cMoneda"].HeaderText            = "Moneda";
            dtgCuentaDetalleAccion.Columns["lSeleccionado"].HeaderText      = "Seleccionado";

            dtgCuentaDetalleAccion.Columns["lSeleccionado"].DisplayIndex        = 1;
            dtgCuentaDetalleAccion.Columns["idCliente"].DisplayIndex            = 2;
            dtgCuentaDetalleAccion.Columns["cNombre"].DisplayIndex              = 3;
            dtgCuentaDetalleAccion.Columns["cDocumentoID"].DisplayIndex         = 4;
            dtgCuentaDetalleAccion.Columns["idCuenta"].DisplayIndex             = 5;
            dtgCuentaDetalleAccion.Columns["cContable"].DisplayIndex            = 6;
            dtgCuentaDetalleAccion.Columns["nMonto"].DisplayIndex               = 7;
            dtgCuentaDetalleAccion.Columns["cMoneda"].DisplayIndex              = 8;
            dtgCuentaDetalleAccion.Columns["nCuotas"].DisplayIndex              = 9;
            dtgCuentaDetalleAccion.Columns["cProducto"].DisplayIndex            = 10;
            dtgCuentaDetalleAccion.Columns["nMontoCuota"].DisplayIndex          = 11;
            dtgCuentaDetalleAccion.Columns["nAtraso"].DisplayIndex              = 12;
            dtgCuentaDetalleAccion.Columns["dFechaDesembolso"].DisplayIndex     = 13;
            dtgCuentaDetalleAccion.Columns["nFrecuencia"].DisplayIndex          = 14;
            dtgCuentaDetalleAccion.Columns["cEstado"].DisplayIndex              = 15;
            dtgCuentaDetalleAccion.Columns["cDireccion"].DisplayIndex           = 16;
            dtgCuentaDetalleAccion.Columns["cCodCliente"].DisplayIndex          = 17;

            dtgCuentaDetalleAccion.Columns["lSeleccionado"].ReadOnly            = false;

            dtgCuentaDetalleAccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void aceptar()
        {
            if ((lstDatosCreditoCliente.Count(item => item.lSeleccionado == true)) > 0)
            {
                lstDatosCreditoClienteSeleccionado = lstDatosCreditoCliente.Where(item => item.lSeleccionado == true).ToList();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un crédito a agregar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstDatosCreditoClienteSeleccionado = new List<clsDatosCreditoCliente>();
                return;
                
            }
        }
        #endregion
    }
}


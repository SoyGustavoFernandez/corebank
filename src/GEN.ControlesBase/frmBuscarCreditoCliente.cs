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
using EntityLayer;
using GEN.CapaNegocio;
#endregion

namespace GEN.ControlesBase
{
    public partial class frmBuscarCreditoCliente : frmBase
    {
        #region Variables Globales
        public clsDatosCreditoCliente datosCreditoCliente { get; set; }
        private List<clsDatosCreditoCliente> lstDatosCreditoCliente { get; set; }
        private BindingSource bsDatosCreditoCliente { get; set; }
        private clsCNCreditoCliente cnCreditoCliente { get; set; }

        #endregion

        public frmBuscarCreditoCliente()
        {
            InitializeComponent();
            cargarComponentesDefecto();
            formatearGridDatosCreditoCliente();
        }

        #region Eventos
        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            cargarDatos(conBusCli.idCli);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lstDatosCreditoCliente = new List<clsDatosCreditoCliente>();
            this.Dispose();
        }
        #endregion

        #region Metodos
        private void cargarComponentesDefecto()
        {
            datosCreditoCliente     = new clsDatosCreditoCliente();
            lstDatosCreditoCliente  = new List<clsDatosCreditoCliente>();
            bsDatosCreditoCliente   = new BindingSource();
            cnCreditoCliente        = new clsCNCreditoCliente();

            bsDatosCreditoCliente.DataSource    = lstDatosCreditoCliente;
            dtgDatosCreditoCliente.DataSource   = bsDatosCreditoCliente;
        }

        private void cargarDatos(int idCliente)
        {
            List<clsDatosCreditoCliente> lstDatos = cnCreditoCliente.CNListarDatosCreditoCliente(idCliente);
            lstDatosCreditoCliente.AddRange(lstDatos);
            bsDatosCreditoCliente.ResetBindings(false);
            dtgDatosCreditoCliente.Refresh();

            if (lstDatosCreditoCliente.Count > 0)
            {
                conBusCli.txtCodInst.Text       = lstDatosCreditoCliente[0].cCodCliente.Substring(0, 3);
                conBusCli.txtCodAge.Text        = lstDatosCreditoCliente[0].cCodCliente.Substring(3, 3);
                conBusCli.txtCodCli.Text        = lstDatosCreditoCliente[0].cCodCliente.Substring(6);
                conBusCli.txtCodCli.Enabled     = false;
                conBusCli.txtNroDoc.Text        = lstDatosCreditoCliente[0].cDocumentoID;
                conBusCli.txtNombre.Text        = lstDatosCreditoCliente[0].cNombre;
                conBusCli.txtDireccion.Text     = lstDatosCreditoCliente[0].cDireccion;
            }
        }
        public void formatearGridDatosCreditoCliente()
        {
            foreach( DataGridViewColumn dgvColumna in dtgDatosCreditoCliente.Columns )
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
            }

            dtgDatosCreditoCliente.Columns["idCuenta"].Visible          = true;
            dtgDatosCreditoCliente.Columns["cEstado"].Visible           = true;
            dtgDatosCreditoCliente.Columns["cNombre"].Visible           = true;
            dtgDatosCreditoCliente.Columns["idCliente"].Visible         = true;
            dtgDatosCreditoCliente.Columns["dFechaDesembolso"].Visible  = true;
            dtgDatosCreditoCliente.Columns["nFrecuencia"].Visible       = true;
            dtgDatosCreditoCliente.Columns["nMonto"].Visible            = true;
            dtgDatosCreditoCliente.Columns["nCuotas"].Visible           = true;
            dtgDatosCreditoCliente.Columns["cProducto"].Visible         = true;
            dtgDatosCreditoCliente.Columns["nMontoCuota"].Visible       = true;
            dtgDatosCreditoCliente.Columns["nAtraso"].Visible           = true;
            dtgDatosCreditoCliente.Columns["cDocumentoID"].Visible      = true;
            dtgDatosCreditoCliente.Columns["cDireccion"].Visible        = true;
            dtgDatosCreditoCliente.Columns["cCodCliente"].Visible       = true;
            dtgDatosCreditoCliente.Columns["cMoneda"].Visible           = true;
            
            dtgDatosCreditoCliente.Columns["idCuenta"].HeaderText           = "Nro. Cuenta";
            dtgDatosCreditoCliente.Columns["cEstado"].HeaderText            = "Estado";
            dtgDatosCreditoCliente.Columns["cNombre"].HeaderText            = "Nombre";
            dtgDatosCreditoCliente.Columns["idCliente"].HeaderText          = "Cod. Cliente";
            dtgDatosCreditoCliente.Columns["dFechaDesembolso"].HeaderText   = "Fecha Desembolso";
            dtgDatosCreditoCliente.Columns["nFrecuencia"].HeaderText        = "Frecuencia";
            dtgDatosCreditoCliente.Columns["nMonto"].HeaderText             = "Monto";
            dtgDatosCreditoCliente.Columns["nCuotas"].HeaderText            = "Cuotas";
            dtgDatosCreditoCliente.Columns["cProducto"].HeaderText          = "Producto";
            dtgDatosCreditoCliente.Columns["nMontoCuota"].HeaderText        = "Monto de cuota";
            dtgDatosCreditoCliente.Columns["nAtraso"].HeaderText            = "Atraso";
            dtgDatosCreditoCliente.Columns["cDocumentoID"].HeaderText       = "Nro. Documento";
            dtgDatosCreditoCliente.Columns["cDireccion"].HeaderText         = "Dirección";
            dtgDatosCreditoCliente.Columns["cCodCliente"].HeaderText        = "Cod. Comp. Cliente";
            dtgDatosCreditoCliente.Columns["cMoneda"].HeaderText            = "Moneda";

            dtgDatosCreditoCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        }

        private void aceptar()
        {
            if(dtgDatosCreditoCliente.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un crédito a agregar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(dtgDatosCreditoCliente.RowCount > 0)
            {
                datosCreditoCliente = (clsDatosCreditoCliente)dtgDatosCreditoCliente.CurrentRow.DataBoundItem;
            }
            else
            {
                datosCreditoCliente = new clsDatosCreditoCliente();
            }
            this.Dispose();
        }

        #endregion
    }
}

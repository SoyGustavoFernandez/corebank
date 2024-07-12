#region
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
using GEN.Funciones;
#endregion

namespace RCP.Presentacion
{
    public partial class frmPlanTrabajoDetalleAccion : frmBase
    {
        #region Variables Globales
        public clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion { get; set; }
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoEspecifico { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoGeneral { get; set; }
        private List<clsDatosCreditoCliente> lstDatosCreditoCliente { get; set; }
        List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculado { get; set; }
        private BindingSource bsDatosCreditosCliente { get; set; }
        private int idUsuarioPlanTrabajo { get; set; }
        private int idUsuarioRevisionPlanTrabajo { get; set; }
        private int idPlanTrabajoRecuperacion { get; set; }
        private int idPlanTrabajoDetalleAccion { get; set; }
        private bool lBloqueoEdicion { get; set; }
        #endregion
        public frmPlanTrabajoDetalleAccion()
        {
            InitializeComponent();
            cargarComponentes();
            formatearGridDatosCreditoCliente();
        }

        public frmPlanTrabajoDetalleAccion(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoEspecifico, int _idUsuarioPlanTrabajo, int _idUsuarioRevisionPlanTrabajo, List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral, bool _lBloqueoEdicion = false)
        {
            InitializeComponent();
            cargarComponentes(_idPlanTrabajoRecuperacion, _lstObjetivoEspecifico, _idUsuarioPlanTrabajo, _idUsuarioRevisionPlanTrabajo, _lstObjetivoGeneral);
            formatearGridDatosCreditoCliente();
            lBloqueoEdicion = _lBloqueoEdicion;
        }


        #region Eventos
        private void frmPlanTrabajoDetalleAccion_Load(object sender, EventArgs e)
        {
            if (objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion == 0)
            {
                limpiar();
            }
            else
            {
                asignarDatos();
            }
            if(lBloqueoEdicion)
            {
                bloquearEdicion();
            }
        }
        private void cboObjetivoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPlanTrabajoObjetivo objPlanTrabajoObjetivoSeleccionado = (cboObjetivoEspecifico.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoEspecifico.SelectedItem;
            dtpFechaAccion.Value = (cboObjetivoEspecifico.SelectedItem == null) ? clsVarGlobal.dFecSystem : objPlanTrabajoObjetivoSeleccionado.dFechaEspecifica ;

            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void dtpFechaAccion_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void cboAccionResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void txtDetalleAccion_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                objPlanTrabajoDetalleAccion = obtenerDetalleAccion();

                string xmlPlanTrabajoDetalleAccion = objPlanTrabajoDetalleAccion.GetXml();
                string xmlPlanTrabajoCliente = lstClienteVinculado.GetXml();

                DataTable dtResultado = objCNPlanTrabajo.CNRegistrarActualizarDetalleAccionPlanTrabajo( objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion, objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                                                                                                        xmlPlanTrabajoDetalleAccion, xmlPlanTrabajoCliente, objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                                                                                                        clsVarGlobal.dFecSystem);
                if (dtResultado.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        idPlanTrabajoDetalleAccion      = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoDetalleAccion"]);
                        objPlanTrabajoDetalleAccion     = obtenerDetalleAccion();
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al momento de registrar el detalle de acción del plan de trabajo, inténtelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = new clsPlanTrabajoDetalleAccion();
            this.Dispose();
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            frmSeleccionarClientePlanTrabajo frmSeleccionarClientePlanTrabajo = new frmSeleccionarClientePlanTrabajo();
            frmSeleccionarClientePlanTrabajo.cargarDatos(idUsuarioPlanTrabajo);
            List<clsDatosCreditoCliente> _lstDatosCreditoCliente = new List<clsDatosCreditoCliente>();

            frmSeleccionarClientePlanTrabajo.ShowDialog();

            if(frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado.Count > 0)
            {
                _lstDatosCreditoCliente = frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado;
                agregarDetalleCreditoCliente(_lstDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniDetalle_Click(object sender, EventArgs e)
        {
            clsPlanTrabajoObjetivo objObjetivoEspecificoSeleccionado    = (cboObjetivoEspecifico.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoEspecifico.SelectedItem ;
            clsPlanTrabajoObjetivo objObjetivoGeneralSeleccionado       = lstObjetivoGeneral.FirstOrDefault(item => item.idPlanTrabajoObjetivo == objObjetivoEspecificoSeleccionado.idPlanTrabajoObjetivoPadre);
            List<clsDatosCreditoCliente> _lstDatosCreditoCliente        = new List<clsDatosCreditoCliente>();
            objObjetivoGeneralSeleccionado  = (objObjetivoGeneralSeleccionado == null) ? new clsPlanTrabajoObjetivo() : objObjetivoGeneralSeleccionado;
            frmSeleccionarClientePlanTrabajo frmSeleccionarClientePlanTrabajo = new frmSeleccionarClientePlanTrabajo();
            frmSeleccionarClientePlanTrabajo.cargarDatos(idUsuarioPlanTrabajo, clsVarGlobal.nIdAgencia, objObjetivoGeneralSeleccionado.idPlanTrabajoResumenObjetivo, objObjetivoEspecificoSeleccionado.idPlanTrabajoResumenObjetivo);
            frmSeleccionarClientePlanTrabajo.ShowDialog();

            if (frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado.Count > 0)
            {
                _lstDatosCreditoCliente = frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado;
                agregarDetalleCreditoCliente(_lstDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarCreditoCliente frmBuscarCreditoCliente = new frmBuscarCreditoCliente();
            clsDatosCreditoCliente objDatosCreditoCliente = new clsDatosCreditoCliente();
            frmBuscarCreditoCliente.ShowDialog();

            if(frmBuscarCreditoCliente.datosCreditoCliente.idCuenta != 0)
            {
                objDatosCreditoCliente = frmBuscarCreditoCliente.datosCreditoCliente;
                agregarDetalleCreditoCliente(objDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            eliminarDetalleCreditoCliente();
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        #endregion
        #region Metodos
        public void cargarDatos(clsPlanTrabajoDetalleAccion _objPlanTrabajoDetalleAccion)
        {
            objPlanTrabajoDetalleAccion = _objPlanTrabajoDetalleAccion;
        }

        private void cargarComponentes()
        {
            habilitarEventHandler(false);
            idPlanTrabajoRecuperacion               = 0;
            objCNPlanTrabajo                         = new clsCNPlanTrabajo();
            objPlanTrabajoDetalleAccion             = new clsPlanTrabajoDetalleAccion();
            lstObjetivoEspecifico                   = new List<clsPlanTrabajoObjetivo>();

            lstDatosCreditoCliente                  = new List<clsDatosCreditoCliente>();
            bsDatosCreditosCliente                  = new BindingSource();
            bsDatosCreditosCliente.DataSource       = lstDatosCreditoCliente;
            dtgDetalleAccionCliente.DataSource      = bsDatosCreditosCliente;


            cboObjetivoEspecifico.DataSource        = lstObjetivoEspecifico;
            cboObjetivoEspecifico.DisplayMember     = "cPlanTrabajoResumenObjetivo";
            cboObjetivoEspecifico.ValueMember       = "idPlanTrabajoObjetivo";
            habilitarEventHandler(true);

            DataTable dtResumenAccion       = objCNPlanTrabajo.CNListarAccion();
            cboAccionResumen.DataSource     = dtResumenAccion;
            cboAccionResumen.DisplayMember  = dtResumenAccion.Columns["cPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.ValueMember    = dtResumenAccion.Columns["idPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.SelectedIndex  = -1;
        }

        private void cargarComponentes(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoEspecifico, int _idUsuarioPlanTrabajo, int _idUsuarioRevisionPlanTrabajo, List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral)
        {
            habilitarEventHandler(false);
            idPlanTrabajoRecuperacion       = _idPlanTrabajoRecuperacion;
            idPlanTrabajoDetalleAccion      = 0;
            objCNPlanTrabajo                   = new clsCNPlanTrabajo();
            objPlanTrabajoDetalleAccion     = new clsPlanTrabajoDetalleAccion();
            lstObjetivoEspecifico           = _lstObjetivoEspecifico;
            lstObjetivoGeneral              = _lstObjetivoGeneral;

            idUsuarioPlanTrabajo            = _idUsuarioPlanTrabajo;
            idUsuarioRevisionPlanTrabajo    = _idUsuarioRevisionPlanTrabajo;

            lstDatosCreditoCliente                  = new List<clsDatosCreditoCliente>();
            bsDatosCreditosCliente                  = new BindingSource();
            bsDatosCreditosCliente.DataSource       = lstDatosCreditoCliente;
            dtgDetalleAccionCliente.DataSource      = bsDatosCreditosCliente;

            cboObjetivoEspecifico.DataSource       = lstObjetivoEspecifico;
            cboObjetivoEspecifico.DisplayMember    = "cPlanTrabajoResumenObjetivo";
            cboObjetivoEspecifico.ValueMember      = "idPlanTrabajoObjetivo";
            
            DataTable dtResumenAccion       = objCNPlanTrabajo.CNListarAccion();
            cboAccionResumen.DataSource     = dtResumenAccion;
            cboAccionResumen.DisplayMember  = dtResumenAccion.Columns["cPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.ValueMember    = dtResumenAccion.Columns["idPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.SelectedIndex  = -1;

            habilitarEventHandler(true);
        }

        private void limpiar()
        {
            cboObjetivoEspecifico.SelectedIndex    = -1;
            dtpFechaAccion.Value                    = clsVarGlobal.dFecSystem;
            txtDetalleAccion.Text                   = String.Empty;
        }

        private void habilitarEventHandler(bool lValor)
        {
            if (!lValor)
            {
                cboObjetivoEspecifico.SelectedIndexChanged  -= new EventHandler(cboObjetivoEspecifico_SelectedIndexChanged);
                dtpFechaAccion.Leave                        -= new EventHandler(dtpFechaAccion_Leave);
                cboAccionResumen.SelectedIndexChanged       -= new EventHandler(cboAccionResumen_SelectedIndexChanged);
                txtDetalleAccion.Leave                      -= new EventHandler(txtDetalleAccion_Leave);
            }
            else
            {
                cboObjetivoEspecifico.SelectedIndexChanged  += new EventHandler(cboObjetivoEspecifico_SelectedIndexChanged);
                dtpFechaAccion.Leave                        += new EventHandler(dtpFechaAccion_Leave);
                cboAccionResumen.SelectedIndexChanged       += new EventHandler(cboAccionResumen_SelectedIndexChanged);
                txtDetalleAccion.Leave                      += new EventHandler(txtDetalleAccion_Leave);
            }
        }

        private clsPlanTrabajoDetalleAccion obtenerDetalleAccion()
        {
            clsPlanTrabajoObjetivo objObjetivoDetalleAccion = ((clsPlanTrabajoObjetivo)cboObjetivoEspecifico.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoEspecifico.SelectedItem;

            objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion           = (objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion != 0) ? objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion : idPlanTrabajoRecuperacion;
            objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion          = (objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion != 0) ? objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion : idPlanTrabajoDetalleAccion;
            objPlanTrabajoDetalleAccion.cPlanTrabajoDetalleAccion           = txtDetalleAccion.Text;
            objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo               = objObjetivoDetalleAccion.idPlanTrabajoObjetivo;
            objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral        = objObjetivoDetalleAccion.idPlanTrabajoObjetivoPadre;
            objPlanTrabajoDetalleAccion.idPlanTrabajoAccion                 = Convert.ToInt32(cboAccionResumen.SelectedValue);
            objPlanTrabajoDetalleAccion.cPlanTrabajoObjetivo                = Convert.ToString(cboObjetivoEspecifico.Text);
            objPlanTrabajoDetalleAccion.cPlanTrabajoAccion                  = cboAccionResumen.Text;
            objPlanTrabajoDetalleAccion.dFechaAccion                        = dtpFechaAccion.Value;
            objPlanTrabajoDetalleAccion.lVigente                            = true;
            objPlanTrabajoDetalleAccion.lstDatosCreditoCliente              = lstDatosCreditoCliente;

            lstClienteVinculado = lstDatosCreditoCliente.OfType<clsDatosCreditoCliente>().Select(item => new clsDatosCreditoClientePlanTrabajo
            {
                idCuenta                            = item.idCuenta,
                idCliente                           = item.idCliente,
                idPlanTrabajoRecuperacion           = objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion,
                idPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                idPlanTrabajoObjetivoGeneral        = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral,
                idPlanTrabajoObjetivoEspecifico     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                dFechaAccion                        = objPlanTrabajoDetalleAccion.dFechaAccion,

                idEstado                            = item.idEstado,
                cEstado                             = item.cEstado,
                cNombre                             = item.cNombre,
                dFechaDesembolso                    = item.dFechaDesembolso,
                nFrecuencia                         = item.nFrecuencia,
                nMonto                              = item.nMonto,
                nCuotas                             = item.nCuotas,
                idMoneda                            = item.idMoneda,
                idProducto                          = item.idProducto,
                cProducto                           = item.cProducto,
                nMontoCuota                         = item.nMontoCuota,
                nAtraso                             = item.nAtraso,
                cDocumentoID                        = item.cDocumentoID,
                cDireccion                          = item.cDireccion,
                cCodCliente                         = item.cCodCliente,
                cMoneda                             = item.cMoneda,
                idTipoDocumento                     = item.idTipoDocumento,
                lCoberturaSegDesg                   = item.lCoberturaSegDesg,
                lSeleccionado                       = item.lSeleccionado,
                
            }).ToList();
            return objPlanTrabajoDetalleAccion;
        }

        private void asignarDatos()
        {
            habilitarEventHandler(false);
            cboObjetivoEspecifico.SelectedValue     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo;
            dtpFechaAccion.Value                    = objPlanTrabajoDetalleAccion.dFechaAccion;
            cboAccionResumen.SelectedValue          = objPlanTrabajoDetalleAccion.idPlanTrabajoAccion;
            txtDetalleAccion.Text                   = objPlanTrabajoDetalleAccion.cPlanTrabajoDetalleAccion;
            lstDatosCreditoCliente.Clear();
            lstDatosCreditoCliente.AddRange(objPlanTrabajoDetalleAccion.lstDatosCreditoCliente);
            bsDatosCreditosCliente.ResetBindings(false);
            dtgDetalleAccionCliente.Refresh();
            habilitarEventHandler(true);
        }

        private bool validar()
        {
            DateTime dFechaInicio = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin = dFechaInicio.AddMonths(1).AddDays(-1);
            bool lValor = true;
            if (cboObjetivoEspecifico.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un objetivo específico asociado a los detalles de acción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if(cboAccionResumen.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un resumen de detalle de acción del Objetivo Específico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (String.IsNullOrEmpty(txtDetalleAccion.Text))
            {
                MessageBox.Show("Ingrese una descripción del detalle de acción del Objetivo Específico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            return lValor;
        }

        private void agregarDetalleCreditoCliente(List<clsDatosCreditoCliente> _lstDatosCreditoCliente)
        {
            List<clsDatosCreditoCliente> lstClienteFiltrado = _lstDatosCreditoCliente.Except(lstDatosCreditoCliente, new clsDatosCreditoClienteComparer()).ToList();

            lstDatosCreditoCliente.AddRange(_lstDatosCreditoCliente);
            bsDatosCreditosCliente.ResetBindings(false);
            dtgDetalleAccionCliente.Refresh();
        }

        private void agregarDetalleCreditoCliente(clsDatosCreditoCliente _objDatosCreditoCliente)
        {
            bool lValida = lstDatosCreditoCliente.Any(item => item.idCliente == _objDatosCreditoCliente.idCliente && item.idCuenta == _objDatosCreditoCliente.idCuenta);
            if (!lValida)
            {
                lstDatosCreditoCliente.Add(_objDatosCreditoCliente);
            }
            bsDatosCreditosCliente.ResetBindings(false);
            dtgDetalleAccionCliente.Refresh();
        }

        private void eliminarDetalleCreditoCliente()
        {
            if(dtgDetalleAccionCliente.SelectedRows.Count > 0)
            {
                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(drRespuesta == DialogResult.No)
                {
                    return;
                }
                foreach(DataGridViewRow dgvfila in dtgDetalleAccionCliente.SelectedRows)
                {
                    dtgDetalleAccionCliente.Rows.RemoveAt(dgvfila.Index);
                }
                dtgDetalleAccionCliente.Refresh();
            }
        }

        public void formatearGridDatosCreditoCliente()
        {
            foreach( DataGridViewColumn dgvColumna in dtgDetalleAccionCliente.Columns )
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
            }

            dtgDetalleAccionCliente.Columns["idCuenta"].Visible             = true;
            dtgDetalleAccionCliente.Columns["cEstado"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cNombre"].Visible              = true;
            dtgDetalleAccionCliente.Columns["idCliente"].Visible            = true;
            dtgDetalleAccionCliente.Columns["dFechaDesembolso"].Visible     = true;
            dtgDetalleAccionCliente.Columns["nFrecuencia"].Visible          = true;
            dtgDetalleAccionCliente.Columns["nMonto"].Visible               = true;
            dtgDetalleAccionCliente.Columns["nCuotas"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cProducto"].Visible            = true;
            dtgDetalleAccionCliente.Columns["nMontoCuota"].Visible          = true;
            dtgDetalleAccionCliente.Columns["nAtraso"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cDocumentoID"].Visible         = true;
            dtgDetalleAccionCliente.Columns["cDireccion"].Visible           = true;
            dtgDetalleAccionCliente.Columns["cCodCliente"].Visible          = true;
            dtgDetalleAccionCliente.Columns["cMoneda"].Visible              = true;
            
            dtgDetalleAccionCliente.Columns["idCuenta"].HeaderText          = "Nro. Cuenta";
            dtgDetalleAccionCliente.Columns["cEstado"].HeaderText           = "Estado";
            dtgDetalleAccionCliente.Columns["cNombre"].HeaderText           = "Nombre";
            dtgDetalleAccionCliente.Columns["idCliente"].HeaderText         = "Cod. Cliente";
            dtgDetalleAccionCliente.Columns["dFechaDesembolso"].HeaderText  = "Fecha Desembolso";
            dtgDetalleAccionCliente.Columns["nFrecuencia"].HeaderText       = "Frecuencia";
            dtgDetalleAccionCliente.Columns["nMonto"].HeaderText            = "Monto";
            dtgDetalleAccionCliente.Columns["nCuotas"].HeaderText           = "Cuotas";
            dtgDetalleAccionCliente.Columns["cProducto"].HeaderText         = "Producto";
            dtgDetalleAccionCliente.Columns["nMontoCuota"].HeaderText       = "Monto de cuota";
            dtgDetalleAccionCliente.Columns["nAtraso"].HeaderText           = "Atraso";
            dtgDetalleAccionCliente.Columns["cDocumentoID"].HeaderText      = "Nro. Documento";
            dtgDetalleAccionCliente.Columns["cDireccion"].HeaderText        = "Dirección";
            dtgDetalleAccionCliente.Columns["cCodCliente"].HeaderText       = "Cod. Comp. Cliente";
            dtgDetalleAccionCliente.Columns["cMoneda"].HeaderText           = "Moneda";

            dtgDetalleAccionCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void bloquearEdicion()
        {
            cboObjetivoEspecifico.Enabled   = false;
            dtpFechaAccion.Enabled          = false;
            cboAccionResumen.Enabled        = false;
            txtDetalleAccion.Enabled        = false;
            dtgDetalleAccionCliente.Enabled = false;
            btnMiniBusq.Enabled             = false;
            btnMiniDetalle.Enabled          = false;
            btnMiniAgregar.Enabled          = false;
            btnMiniQuitar.Enabled           = false;
            btnAceptar.Enabled              = false;

        }
        #endregion
    }
}

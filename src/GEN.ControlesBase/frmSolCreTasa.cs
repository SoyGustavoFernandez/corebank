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
using GEN.CapaNegocio;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class frmSolCreTasa : frmBase
    {
        public clsTasaCredSimp objTasaCredSimp = new clsTasaCredSimp();
        public int idTasa { get; set; }
        public decimal nTasa { get; set; }
        public decimal nTasaMoratoria { get; set; }
        private clsSolicitudCredSimp objSolicitud = new clsSolicitudCredSimp();
        private clsCliente objCliente = new clsCliente();
        private clsCNTasaCredito objCNTasaCredito = new clsCNTasaCredito();
        private clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
        private BindingSource bsTasa = new BindingSource();
        private List<clsTasaCredSimp> lstTasa = new List<clsTasaCredSimp>();
        private decimal nTasaSeleccionada { get; set; }
        private bool lEditable { get; set; }

        public frmSolCreTasa()
        {
            InitializeComponent();

            this.nTasaSeleccionada = 0;
        }

        public void CargarDatos(clsSolicitudCredSimp _objSolicitud, clsCliente _objCliente)
        {
            this.objSolicitud = _objSolicitud;
            this.objCliente = _objCliente;
            this.lblSolicitud.Text = Convert.ToString(objSolicitud.idSolicitud);
            this.objTasaCredSimp = _objSolicitud.objTasaCredSimp;
            this.nTasaSeleccionada = objSolicitud.objTasaCredSimp.nTasaSeleccionada;
        }

        public void RecuperarTasaDisponible()
        {
            if (objSolicitud.nCuotas != 0 && objSolicitud.idTipoPeriodo != 0 && objSolicitud.nPlazoCuota != 0)
            {
                cboTipoTasa.DataSource = null;
                int nPlazo = obtenerTotalDias(objSolicitud.dFechaDesembolsoSugerido, objSolicitud.nCuotas, objSolicitud.nDiasGracia, objSolicitud.idTipoPeriodo, objSolicitud.nPlazoCuota, objSolicitud.dFechaPrimeraCuota, objSolicitud.nCuotasGracia);
                int idProducto = objSolicitud.idProducto;
                decimal nMonto = objSolicitud.nCapitalSolicitado;
                int idMoneda = objSolicitud.idMoneda;
                int idAgencia = clsVarGlobal.nIdAgencia;

                if (objSolicitud.lConTasaNegociable)
                {
                    lstTasa = objCNTasaCredito.CNListaTasaNegocibleSimp(nPlazo, idProducto, nMonto, idMoneda, idAgencia, objSolicitud.idSolicitud, objCliente.idClasifInterna);
                }
                else
                {
                    lstTasa = objCNTasaCredito.CNListaTasaCreditoSimp(nPlazo, idProducto, nMonto, idMoneda, idAgencia, objSolicitud.idOperacion, objCliente.idClasifInterna);
                }

                if (lstTasa.Count > 0)
                {
                    bsTasa.DataSource = lstTasa;


                    cboTipoTasa.DataSource = bsTasa.DataSource;
                    cboTipoTasa.DisplayMember = "cTipoTasa";
                    cboTipoTasa.ValueMember = "idTasa";

                    var idTipoTasaCredito = lstTasa[0].idTipoTasa;

                    
                    if (lstTasa[0].nTasaCompensatoria == lstTasa[0].nTasaCompensatoriaMax)
                    {
                        txtTEAMin.Text = Convert.ToString(lstTasa[0].nTasaCompensatoria);
                        txtTEAMax.Text = Convert.ToString(lstTasa[0].nTasaCompensatoriaMax);
                        txtTIM.Text = Convert.ToString(lstTasa[0].nTasaMoratoria);
                        idTasa = lstTasa[0].idTasa;
                        txtTEA.Enabled = false;
                        txtTEA.Text = Convert.ToString(lstTasa[0].nTasaCompensatoriaMax);
                    }
                    else
                    {
                        txtTEA.Enabled = true;

                        if (objSolicitud.idSolicitud != 0)
                        {
                            bool lValidarRangoSolicitud =   objSolicitud.nTasaCompensatoria  >= lstTasa[0].nTasaCompensatoria &&
                                                            objSolicitud.nTasaCompensatoria <= lstTasa[0].nTasaCompensatoriaMax;
                            decimal nTasaActual = (!String.IsNullOrEmpty(txtTEA.Text)) ? Convert.ToDecimal(txtTEA.Text) : 0;
                            bool lValidaRangoActual = nTasaActual >= lstTasa[0].nTasaCompensatoria &&
                                                        nTasaActual <= lstTasa[0].nTasaCompensatoriaMax;
                            txtTEA.Text = (lValidarRangoSolicitud) ? Convert.ToString(objSolicitud.nTasaCompensatoria) : (lValidaRangoActual) ? txtTEA.Text : "";
                            txtTIM.Text = Convert.ToString(objSolicitud.nTasaMoratoria);
                        }
                        else if (objSolicitud.objTasaCredSimp.nTasaSeleccionada != 0)
                        {
                            txtTEA.Text = objSolicitud.objTasaCredSimp.nTasaSeleccionada.ToString("N2");
                            txtTEA.Enabled = true;
                            txtTEA.ReadOnly = false;
                        }
                        else
                        {
                            txtTEA.Text = "";
                            txtTEA.Enabled = true;
                            txtTEA.ReadOnly = false;
                        }
                    }
                }
                else
                {
                    txtTEAMin.Text = "";
                    txtTEAMax.Text = "";
                    txtTEA.Text = "";
                    txtTIM.Text = "";
                }
            }
        }

        private int obtenerTotalDias(DateTime dFechaDesembolso, int nCuotas, int nDiasGracia, int idTipoPeriodo, int nPlazoCuota, DateTime dFechaPrimeraCuota, int nCuotasGracia = 0)
        {
            DataTable dtPlanPagoSimulado = objCNSolicitud.CNObtienePlanPagoSimulado(dFechaDesembolso, nCuotas, nDiasGracia, Convert.ToInt16(idTipoPeriodo), nPlazoCuota, dFechaPrimeraCuota, nCuotasGracia);
            return (dtPlanPagoSimulado.Rows.Count > 0) ? dtPlanPagoSimulado.AsEnumerable().Sum(item => item.Field<int>("dias")) : 0 ;
        }

        private void btnTasaNegociable_Click(object sender, EventArgs e)
        {
            frmSolCreTasaNegSimp frmTasaNegociada = new frmSolCreTasaNegSimp(objCliente.idCli, objSolicitud.idSolicitud);
            frmTasaNegociada.lSolicitudCargado = true;
            frmTasaNegociada.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            if (cboTipoTasa.SelectedIndex > -1)
            {
                objTasaCredSimp = (clsTasaCredSimp)cboTipoTasa.SelectedItem;
                objTasaCredSimp.nTasaSeleccionada = Convert.ToDecimal(txtTEA.Text);
                this.Close();
            }
        }

        private bool Validar()
        {
            bool lValida = false;
            if (cboTipoTasa.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Tasa Compensatoria", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValida;
            }
            if (string.IsNullOrEmpty(txtTEA.Text))
            {
                MessageBox.Show("Debe registrar Tasa Compensatoria", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValida;
            }

            if (objSolicitud.idOperacion != 3 && (string.IsNullOrEmpty(txtTEA.Text) || txtTEA.nDecValor > txtTEAMax.nDecValor || txtTEA.nDecValor < txtTEAMin.nDecValor))
            {
                MessageBox.Show("Debe registrar Tasa Compensatoria según Rango de Tasas", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            lValida = true;
            return lValida;
        }

        private void cboTipoTasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTasa.SelectedIndex > -1)
            {
                objTasaCredSimp = (clsTasaCredSimp)cboTipoTasa.SelectedItem;
                objTasaCredSimp.nTasaSeleccionada = (nTasaSeleccionada != 0) ? nTasaSeleccionada : 0 ;

                txtTEAMin.Text = Convert.ToString(objTasaCredSimp.nTasaCompensatoria);
                txtTEAMax.Text = Convert.ToString(objTasaCredSimp.nTasaCompensatoriaMax);
                txtTIM.Text = Convert.ToString(objTasaCredSimp.nTasaMoratoria);

                if (txtTEAMin.Text == txtTEAMax.Text)
                {
                    txtTEA.Enabled = false;
                    txtTEA.Text = txtTEAMax.Text;
                }
                else
                {
                    txtTEA.Text = (nTasaSeleccionada != 0) ? Convert.ToString(nTasaSeleccionada) : txtTEAMax.Text;
                    txtTEA.Focus();
                    txtTEA.SelectAll();
                    txtTEA.Enabled = true;
                }

                if (objSolicitud.lConTasaNegociable)
                {
                    if (objTasaCredSimp.nTasaNegAprobada > 0)
                    {
                        txtTEA.Text = Convert.ToString(objTasaCredSimp.nTasaNegAprobada);
                        txtTEA.Enabled = false;
                    }
                    else
                    {
                        txtTEA.Enabled = true;
                    }
                }

                txtTEA.ReadOnly = false;
                if ( objSolicitud.idOperacion  == 2 || objSolicitud.idOperacion == 6)
                {
                    txtTEA.ReadOnly = true;
                }
            }
        }

        private void frmSolCreTasa_Load(object sender, EventArgs e)
        {
            btnTasaNegociable.Enabled = (objSolicitud.idSolicitud != 0) ? true : false ;
            RecuperarTasaDisponible();
        }

        private void txtTEA_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(this.txtTEA.Text))
            {
                decimal nValorTEA = Convert.ToDecimal(this.txtTEA.Text);
                decimal nTem = clsMathFinanciera.TEM(Convert.ToDouble(nValorTEA));
                txtTEM.Text = nTem.ToString("N4");
            }
        }

        private void txtTEA_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtTEA.Text))
            {
                decimal nValorTEA = Convert.ToDecimal(this.txtTEA.Text);
                this.txtTEA.Text = nValorTEA.ToString("N4");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.nTasaSeleccionada = 1;
        }
    }
}
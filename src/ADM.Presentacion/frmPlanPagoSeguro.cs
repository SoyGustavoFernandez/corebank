using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmPlanPagoSeguro : frmBase
    {
        public clsMantenimientoPlanSeguroVida objPlanPagoActual = new clsMantenimientoPlanSeguroVida();
        public List<clsMantenimientoPlanSeguroVida> lstPlanPagoActual = new List<clsMantenimientoPlanSeguroVida>();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        clsHistoricoSegurosOptativos objFrmEditarSeguroOptativo = new clsHistoricoSegurosOptativos();
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt = new clsMantenimientoSeguroOptativo();
        private string frmTxt = "Plan de pago Seguros";

        public frmPlanPagoSeguro(clsMantenimientoPlanSeguroVida _objPlanPagoActual, clsHistoricoSegurosOptativos _objFrmEditarSeguroOptativo, clsMantenimientoSeguroOptativo _clsDatosSeguroOpt)
        {
            objPlanPagoActual = _objPlanPagoActual;
            objFrmEditarSeguroOptativo = _objFrmEditarSeguroOptativo;
            clsDatosSeguroOpt = _clsDatosSeguroOpt;
            InitializeComponent();
        }

        private void frmPlanPagoSeguro_Load(object sender, System.EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            cboAsociarCredito.DataSource = LlenarComboSiNo();
            cboAsociarCredito.DisplayMember = "Descripcion";
            cboAsociarCredito.ValueMember = "Codigo";

            txtTipoSeguro.Enabled = false;
            txtNombrePlan.Focus();
            LlenarDatos();
        }

        private void LlenarDatos()
        {
            txtTipoSeguro.Text = objPlanPagoActual.cTipoSeguro;
            txtNombrePlan.Text = objPlanPagoActual.cDescripcion;
            txtMesesMinimo.Text = objPlanPagoActual.nMinMes.ToString();
            txtMesesMaximo.Text = objPlanPagoActual.nMaxMes.ToString();
            txtMeses.Text = objPlanPagoActual.nMeses.ToString();
            txtPrecio.Text = objPlanPagoActual.nPrecioMensual.ToString();
            cboAsociarCredito.SelectedValue = Convert.ToInt32(objPlanPagoActual.lSolicitud);
            chkVigente.Checked = objPlanPagoActual.lFijo;
            chkRedondear.Checked = true;
        }


        public List<clsBooleanPlanSeguro> LlenarComboSiNo()
        {
            List<clsBooleanPlanSeguro> lista = new List<clsBooleanPlanSeguro>
            {
                new clsBooleanPlanSeguro { Codigo = 0, Descripcion = "No" },
                new clsBooleanPlanSeguro { Codigo = 1, Descripcion = "Si" },
            };
            return lista;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro())
            {
                string mensajeHistorico = objPlanPagoActual.idTipoPlan == 0 ? "REGISTRO DE PLAN AGREGADO" : "REGISTRO DE PLAN MODIFICADO";
                AccionHistorico accion = objPlanPagoActual.idTipoPlan == 0 ? AccionHistorico.AGREGAR : AccionHistorico.EDITAR;
                string mensaje = objPlanPagoActual.idTipoPlan == 0 ? "Se agregó el plan de pago de manera exitosa" : "Se modificó el plan de pago manera exitosa";

                objPlanPagoActual.cDescripcion = txtNombrePlan.Text;
                objPlanPagoActual.nMinMes = Convert.ToInt32(txtMesesMinimo.Text);
                objPlanPagoActual.nMaxMes = Convert.ToInt32(txtMesesMaximo.Text);
                objPlanPagoActual.nMeses = Convert.ToInt32(txtMeses.Text);
                objPlanPagoActual.nPrecioMensual = Convert.ToDecimal(txtPrecio.Text);
                objPlanPagoActual.lSolicitud = Convert.ToBoolean(cboAsociarCredito.SelectedValue);
                objPlanPagoActual.lFijo = chkVigente.Checked;
                objPlanPagoActual.lRedondear = true;
                //Si lRedondear es verdadero, se redondea el precio total
                if (objPlanPagoActual.lRedondear)
                    objPlanPagoActual.nPrecioTotal = Math.Round(objPlanPagoActual.nPrecioMensual * objPlanPagoActual.nMeses);
                else
                    objPlanPagoActual.nPrecioTotal = objPlanPagoActual.nPrecioMensual * objPlanPagoActual.nMeses;

                try
                {
                    clsDatosSeguroOpt.listaValseguro = DataTableToList.ConvertTo<clsMantenimientoPlanSeguroVida>(new clsCNPlanPagoSeguro().InsUpdPlanPagoSeguro(objPlanPagoActual)).ToList<clsMantenimientoPlanSeguroVida>();

                    if (accion == AccionHistorico.AGREGAR)
                        objPlanPagoActual = clsDatosSeguroOpt.listaValseguro.OrderByDescending(x => x.idTipoPlan).FirstOrDefault();

                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPlanes(mensajeHistorico, accion, objPlanPagoActual, objFrmEditarSeguroOptativo);

                    MessageBox.Show(mensaje, frmTxt, MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error en la transacción: " + ex.Message, frmTxt, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Dispose();
            }
        }

        private bool ValidarRegistro()
        {
            if (string.IsNullOrWhiteSpace(txtNombrePlan.Text))
                return ShowErrorMessage("Debe ingresar un nombre para el plan de pago", txtNombrePlan);

            int mesesMinimo;
            int mesesMaximo;

            if (!IsValidInteger(txtMesesMinimo.Text, out mesesMinimo) || !IsValidInteger(txtMesesMaximo.Text, out mesesMaximo))
                return ShowErrorMessage("Debe ingresar números válidos para los meses mínimos y máximos", txtMesesMinimo);

            if (mesesMinimo > mesesMaximo)
                return ShowErrorMessage("El número de meses mínimo no puede ser mayor al número de meses máximo", txtMesesMinimo);

            int meses;
            if (!IsValidInteger(txtMeses.Text, out meses) || meses < mesesMinimo || meses > mesesMaximo)
                return ShowErrorMessage("El número de meses debe estar entre el número de meses mínimo y máximo", txtMeses);

            decimal precio;
            if (!IsValidDecimal(txtPrecio.Text, out precio) || precio <= 0)
                return ShowErrorMessage("El precio debe ser un número mayor a cero", txtPrecio);

            if (cboAsociarCredito.SelectedValue == null)
                return ShowErrorMessage("Debe seleccionar si se asociará a un crédito", cboAsociarCredito);

            return true;
        }

        private bool ShowErrorMessage(string message, Control control)
        {
            MessageBox.Show(message, frmTxt, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private bool IsValidInteger(string text, out int result)
        {
            return int.TryParse(text, out result);
        }

        private bool IsValidDecimal(string text, out decimal result)
        {
            return decimal.TryParse(text, out result);
        }

    }
}
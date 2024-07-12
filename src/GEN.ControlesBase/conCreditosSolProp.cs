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
namespace GEN.ControlesBase
{
    public partial class conCreditosSolProp : UserControl
    {
        /// <summary>
        /// cuando la cuota aproximada cambia
        /// </summary>
        public event EventHandler eCambioCuotaAprox;

        public conCreditosSolProp()
        {
            InitializeComponent();
            conCreditoTasa.MonedaEnabled = false;
            conCreditoTasa.NivelesProductoEnabled = false;
            tbcCredito.SelectedTab = tbpCredProp;
        }

        #region "Properties"
        public bool lMostrarTodoNiveles
        {
            set {
                conCreditoTasa.lMostrarTodosNivCred = value;
            }
            get { return conCreditoTasa.lMostrarTodosNivCred;  }
        }

        /// <summary>
        /// Carga datos de la solicitud de crédito
        /// </summary>
        /// <param name="eCredProp">objeto de credito solicitado</param>
        public void cargarCreditoSol(clsCreditoProp eCredProp)
        {
            if (eCredProp != null)
            {
                cboMoneda.SelectedValue = eCredProp.idMoneda;
                txtMonto.Text = eCredProp.nMonto.ToString("N2");
                nudCuotas.Maximum= 132;
                nudCuotas.Value = eCredProp.nCuotas;
                cboTipoPeriodo.SelectedValue = eCredProp.idTipoPeriodo;
                nudPlazoCuota.Value = eCredProp.nPlazoCuota;
                nudDiasGracia.Value = eCredProp.nDiasGracia;
                dtFechaDesembolso.Value = eCredProp.dFechaDesembolso;
                txtTEA.Text = (eCredProp.nTea/100.00M).ToString("P2");
            }
        }

        public void cargarCreditoPropuesto(clsCreditoProp eCredProp)
        {
            conCreditoTasa.AsignarDatos(eCredProp);
            txtCuotaAprox.Text = conCreditoTasa.CuotaAprox().ToString("N2");
        }

        public void limpiar()
        {
            cboMoneda.SelectedIndex = -1;
            txtMonto.Text = "0";
            nudCuotas.Value = 0;
            cboTipoPeriodo.SelectedIndex = -1;
            nudPlazoCuota.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            txtTEA.Clear();
            conCreditoTasa.LimpiarFormulario();
            txtCuotaAprox.Clear();
        }

        public clsCreditoProp obtenerCreditoPropuesto()
        {
            return conCreditoTasa.ObtenerCreditoPropuesto();
        }

        public Decimal obtenerMontoPropuesto()
        {
            return conCreditoTasa.MontoPropuesto;
        }

        public Decimal obtenerCuotaAproximada()
        {
            return conCreditoTasa.CuotaAprox();
        }

        private void actualizarCuotaAprox(object sender, EventArgs e)
        {
            conCreditoTasa.ObtenerCreditoPropuesto();
            txtCuotaAprox.Text = conCreditoTasa.CuotaAprox().ToString("N2");
            if (eCambioCuotaAprox != null)
                eCambioCuotaAprox(sender, e);
        }
        #endregion

        private void conCreditoTasa_ChangeCuotaAprox(object sender, EventArgs e)
        {
            actualizarCuotaAprox(sender, e);
        }

        private void conCreditoTasa_ChangeMonto(object sender, EventArgs e)
        {
            actualizarCuotaAprox(sender, e);
        }

        private void conCreditoTasa_ChangeMoneda(object sender, EventArgs e)
        {
            actualizarCuotaAprox(sender, e);
        }
        public int PlazoTotal()
        {
            return conCreditoTasa.nPlazoTotal;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            var objCreditoTasaMsjError = this.conCreditoTasa.Validar();

            if (objCreditoTasaMsjError.HasErrors)
            {
                foreach (var err in objCreditoTasaMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            return objMsjError;
        }
    }
}

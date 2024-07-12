using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmProyeCancel : frmBase
    {
        #region Variables Globales

        public DataTable dtCredito = new DataTable("dtCredito");
        private frmCancelacionAnticipada frmCancelacionAnticipada;
        clsCNCredito Credito = new clsCNCredito();
        clsFunUtiles objFunciones = new clsFunUtiles();

        #endregion

        #region Eventos

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            if (conBusCuentaCli.nValBusqueda != 0)
            {
                dFechaProyec.Enabled = true;
                btnProcesar.Enabled = true;
                btnCancelar.Enabled = true;

                Procesar();
            }
        }

        private void frmProyeCancel_Load(object sender, EventArgs e)
        {
            dFechaProyec.Value = clsVarGlobal.dFecSystem;

            int idCuenta = 0;
            idCuenta = this.conBusCuentaCli.nValBusqueda;
            if (idCuenta > 0)
            {
                Procesar();
            }
        }

        private void frmProyeCancel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.conBusCuentaCli.lFrmProyeCancel = false;
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
            conBusCuentaCli.LiberarCuenta();

            this.Dispose();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (dtCredito.Rows.Count > 0)   //si hay datos 
            {

                if (dFechaProyec.Value < clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("Seleccione fecha de proyección posterior a la del Sistema", "Proyección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dFechaProyec.Value = clsVarGlobal.dFecSystem;

                    return;
                }

                if (dFechaProyec.Value > Convert.ToDateTime(dtCredito.Rows[0]["dFechaCulminacion"])) //fecha del ultimo pago
                {
                    MessageBox.Show("Seleccione fecha de proyección hasta la fecha de pago de la ultima cuota", "Proyección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dFechaProyec.Value = clsVarGlobal.dFecSystem;
                    return;
                }
                Procesar();
            }
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();

            dFechaProyec.Value = clsVarGlobal.dFecSystem;
            conBusCuentaCli.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
            conBusCuentaCli.LiberarCuenta();
            btnProcesar.Enabled = false;
            dFechaProyec.Enabled = false;


        }
        private void dFechaProyec_ValueChanged(object sender, EventArgs e)
        {

    

        }
        #endregion

        #region Metodos
        public frmProyeCancel()
        {
            InitializeComponent();

            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";
            this.conBusCuentaCli.lFrmProyeCancel = true;

        }
        public frmProyeCancel(int idCli,frmCancelacionAnticipada form,int numCredito, string ccodCli,string cNumDoc,string cNombre)
        {
            InitializeComponent();
            this.frmCancelacionAnticipada = form;


            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            this.conBusCuentaCli.buscarCuentasPorClienteRef(idCli, numCredito, ccodCli, cNumDoc, cNombre);

            btnCancelar.Visible = false;
            btnSalir.Visible = false;
            btnProcesar.Enabled = true;
            dFechaProyec.Enabled = true;

        }

        private void LimpiarDatos()
        {
            //Datos del cliente
            conBusCuentaCli.txtCodIns.Text = string.Empty;
            conBusCuentaCli.txtCodAge.Text = string.Empty;
            conBusCuentaCli.txtCodMod.Text = string.Empty;
            conBusCuentaCli.txtCodMon.Text = string.Empty;
            conBusCuentaCli.txtNroBusqueda.Text = string.Empty;

            conBusCuentaCli.txtCodCli.Text = string.Empty;

            conBusCuentaCli.txtNroDoc.Text = string.Empty;
            conBusCuentaCli.txtEstado.Text = string.Empty;

            conBusCuentaCli.txtNombreCli.Text = string.Empty;


            //Detalles Deuda
            txtCapital.Text = string.Empty;
            txtInteres.Text = string.Empty;
            txtIntComp.Text = string.Empty;
            txtMoraCredito.Text = string.Empty;
            txtOtros.Text = string.Empty;

            txtMontoNeto.Text = string.Empty;
            txtImpuestos.Text = string.Empty;
            txtRedondeo.Text = string.Empty;
            txtTotalAPagar.Text = string.Empty;
        }
        public void Procesar()
        {
            dtCredito = Credito.CNdtDataCreditoCobro(this.conBusCuentaCli.nValBusqueda);
            GEN.CapaNegocio.clsCNRetornaNumCuenta objProy = new GEN.CapaNegocio.clsCNRetornaNumCuenta();

            DataTable dtDatos = objProy.ProyecCuenta(dFechaProyec.Value.ToString("yyyy-MM-dd"), this.conBusCuentaCli.nValBusqueda);
            txtCapital.Text = dtDatos.Rows[0][0].ToString();
            txtInteres.Text = dtDatos.Rows[0][1].ToString();
            txtIntComp.Text = dtDatos.Rows[0][2].ToString();
            txtMoraCredito.Text = dtDatos.Rows[0][3].ToString();
            txtOtros.Text = dtDatos.Rows[0][4].ToString();
            txtMontoNeto.Text = dtDatos.Rows[0][5].ToString();
            txtTotalAPagar.Text = CalcularImpuestosYRedondeo(1);
        }

        private string CalcularImpuestosYRedondeo(int idtipoPago) //1-Efectivo
        {
            Decimal nMonPago = (!String.IsNullOrWhiteSpace(this.txtMontoNeto.Text)) ? Convert.ToDecimal(this.txtMontoNeto.Text) : Decimal.Zero;
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()));
            Decimal nMonFavCli = 0.00m;
            Decimal nMonRedBcr = 0m;

            if (idtipoPago == 1)
            {
                nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()), true, true);
            }
            else
            {
                nMonRedBcr = (nMonPago + nITF);
            }
            this.txtRedondeo.Text = String.Format("{0:#,0.00}", Math.Round(nMonFavCli, 2));
            this.txtImpuestos.Text = String.Format("{0:#,0.00}", Math.Round(nITF, 2));
            return String.Format("{0:#,0.00}", nMonRedBcr);
        }
        #endregion

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (conBusCuentaCli.nValBusqueda != 0)
                {
                    dFechaProyec.Enabled = true;
                    btnProcesar.Enabled = true;
                    btnCancelar.Enabled = true;

                    Procesar();
                } 
               
            }
         
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;

         
            this.Dispose();
        }

    }
}

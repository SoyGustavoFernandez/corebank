using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
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
    public partial class frmCongelarTasaInteres : frmBase
    {
        #region Variables
        clsCNAprobacion cnAprobacion = new clsCNAprobacion();
        CRE.CapaNegocio.clsCNCredito cnCredito = new CRE.CapaNegocio.clsCNCredito();
        DataTable dtCredito = new DataTable();
        decimal nTasaCompensatoria = 0.00M;
        decimal nTCEA = 0.00M;
        int idSolAproba = 0;
        #endregion


        public frmCongelarTasaInteres()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmCongelarTasaInteres_Load(object sender, EventArgs e)
        {
            conBusCuentaCli1.cTipoBusqueda = "C";
            limpiar();
        }

        private void frmCongelarTasaInteres_FormClosed(object sender, FormClosedEventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
            limpiar();
        }

        private void btnCongelar1_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = cnCredito.congelarTasaInteres(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                            idSolAproba,
                                            Convert.ToDecimal(txtTasaInteres.Text),
                                            nTasaCompensatoria,
                                            Convert.ToDecimal(txtTasaMoratoria.Text),
                                            nTCEA,
                                            clsVarGlobal.dFecSystem,
                                            clsVarGlobal.User.idUsuario);

            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("Se realizó correctamente el congelamiento de la tasas de interes de la cuenta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCuentaCli1.LiberarCuenta();
                limpiar();
            }
            else
            {
                MessageBox.Show("Error el congelamiento de tasas de interes: " + dtResultado.Rows[0]["cMensaje"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargar();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            cargar();
        }

        private void btnSolicitar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = cnAprobacion.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, this.conBusCuentaCli1.nIdCliente, 131, 1, Convert.ToInt32(dtCredito.Rows[0]["idMoneda"]), Convert.ToInt32(dtCredito.Rows[0]["idProducto"]), Convert.ToDecimal /*era ToDouble*/(txtTotalDeuda.Text), Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), clsVarGlobal.dFecSystem, 11, txtMotivo.Text.Trim(), 1, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0]["idEstadoSol"]) == 1)
                {
                    MessageBox.Show("Se realizó la solicitud para la aprobación de congelamiento de tasas de interes,\nCódigo solicitud: " + dtResultado.Rows[0][0].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }
                else
                {
                    MessageBox.Show("Error al realizar la solicitud de aprobacion de congelamiento de tasas de interes: " + dtResultado.Rows[0]["cMensaje"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validar()
        {
            if (txtMotivo.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar el motivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivo.Focus();
                return false;
            }

            int nVarDiasAtraso = 0;
            try
            {
                nVarDiasAtraso = Convert.ToInt32(clsVarApl.dicVarGen["nAtrasoParaCongelar"]);
            }
            catch (Exception e)
            {
                nVarDiasAtraso = 150;
            }

            if (Convert.ToInt32(txtDiasAtraso.Text) < nVarDiasAtraso)
            {
                MessageBox.Show("El crédito no puede ser solicitado, porque los días de atraso son insuficientes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Metodos

        private void cargar()
        {
            if (!String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                int idCuenta = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);

                dtCredito = cnCredito.obtenerCreditoParaCongelarTasa(idCuenta);
                if (dtCredito.Rows.Count > 0)
                {
                    txtMoneda.Text = dtCredito.Rows[0]["cMoneda"].ToString();
                    txtEstadoCredito.Text = dtCredito.Rows[0]["cEstado"].ToString();

                    txtSaldoCapital.Text = dtCredito.Rows[0]["nSaldoCapital"].ToString();
                    txtSaldoInteres.Text = dtCredito.Rows[0]["nSaldoInteres"].ToString();
                    txtSaldoIntComp.Text = dtCredito.Rows[0]["nSaldoIntComp"].ToString();
                    txtSaldoMora.Text = dtCredito.Rows[0]["nSaldoMora"].ToString();
                    txtSaldoOtros.Text = dtCredito.Rows[0]["nSaldoOtros"].ToString();

                    txtTotalDeuda.Text = dtCredito.Rows[0]["nTotalDeuda"].ToString();

                    txtTasaInteres.Text = dtCredito.Rows[0]["nTasaInteres"].ToString();
                    txtTasaMoratoria.Text = dtCredito.Rows[0]["nTasaCompen"].ToString();
                    txtDiasAtraso.Text = dtCredito.Rows[0]["nAtraso"].ToString();
                    txtAsesor.Text = dtCredito.Rows[0]["cNombreAsesor"].ToString();

                    txtEstadoSolicitud.Text = dtCredito.Rows[0]["cEstadoApro"].ToString();
                    txtMotivo.Text = dtCredito.Rows[0]["cMotivo"].ToString();

                    nTasaCompensatoria = Convert.ToDecimal(dtCredito.Rows[0]["nTasaCompen"]);
                    nTCEA = Convert.ToDecimal(dtCredito.Rows[0]["nTasaECA"]);

                    idSolAproba = Convert.ToInt32(dtCredito.Rows[0]["idSolAproba"].ToString());
                    int idEstadoAproba = Convert.ToInt32(dtCredito.Rows[0]["idEstadoApro"].ToString());
                    if (idEstadoAproba == 0)
                    {
                        btnSolicitar1.Enabled = true;
                        btnCongelar1.Enabled = false;
                        txtMotivo.Enabled = true;
                    }
                    else
                    {
                        btnCongelar1.Enabled = (idEstadoAproba == 2);
                        btnSolicitar1.Enabled = false;
                        txtMotivo.Enabled = false;
                    }
                    btnCancelar1.Enabled = true;
                    conBusCuentaCli1.Enabled = false;

                    if (Convert.ToDouble(dtCredito.Rows[0]["nTasaInteres"]) == 0.00 &&
                        Convert.ToDouble(dtCredito.Rows[0]["nTasaCompen"]) == 0.00 &&
                        Convert.ToDouble(dtCredito.Rows[0]["nTasaMora"]) == 0.00)
                    {
                        MessageBox.Show("El crédito tiene las tasas congeladas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnSolicitar1.Enabled = false;
                        btnCongelar1.Enabled = false;
                        txtMotivo.Enabled = false;
                    }
                }
            }
        }

        private void limpiar()
        {
            txtMotivo.Text = "";
            txtMoneda.Text = "";
            txtEstadoCredito.Text = "";

            txtSaldoCapital.Text = "";
            txtSaldoInteres.Text = "";
            txtSaldoIntComp.Text = "";
            txtSaldoMora.Text = "";
            txtSaldoOtros.Text = "";

            txtTotalDeuda.Text = "";

            txtTasaInteres.Text = "";
            txtTasaMoratoria.Text = "";
            txtDiasAtraso.Text = "";
            txtAsesor.Text = "";

            txtEstadoSolicitud.Text = "";

            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();

            btnSolicitar1.Enabled = false;
            btnCongelar1.Enabled = false;
            btnCancelar1.Enabled = false;
            txtMotivo.Enabled = false;
        }

        #endregion

    }
}

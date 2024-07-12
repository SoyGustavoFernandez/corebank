using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using SER.CapaNegocio;

using EntityLayer;

namespace SER.Presentacion
{
    public partial class frmExtornoGiro : frmBase
    {
        #region Variables Globales

        public int idSol;
        int idTipoIngresoEgreso = 0;
        int idTipoPago = 0;
        int idModalidadPagoGiro = 0;
        clsCNControlServ cncontrolserv = new clsCNControlServ();
        
        #endregion
        public frmExtornoGiro()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmExtornoGiro_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            btnExtorno.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            habilitarBotones(false);
            this.btnBusqueda.Focus();
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        { //--Pendiente por Revisar
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 9;
            frmExtPen.pidTipOpe = "13,14,15";
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            idSol = frmExtPen.pidSolExt;
            LimpiarControles();
            if (nidKar != 0)
            {
                this.txtNroKar.Text = nidKar.ToString();
            }
            else
            {
                this.txtNroKar.Text = String.Empty;
                btnExtorno.Enabled = false;
                return;
            }

            if (nidKar > 0)
            {

                DataTable tbGiros = cncontrolserv.RetDatosGiroExt(nidKar, "", "", clsVarGlobal.nIdAgencia, 1);

                if (tbGiros.Rows[0]["idEstado"].ToString() == "1" || tbGiros.Rows[0]["idEstado"].ToString() == "2" || tbGiros.Rows[0]["idEstado"].ToString() == "5")//enviado, cobrado y devuelto
                {
                    this.txtNroGiro.Text = tbGiros.Rows[0]["idServGiro"].ToString();
                    this.txtTipOpe.Text = tbGiros.Rows[0]["cTipOperacion"].ToString();
                    //Datos Remitente
                    this.txtNomCliRem.Text = tbGiros.Rows[0]["cNombreRem"].ToString();
                    this.txtDniRem.Text = tbGiros.Rows[0]["cNroDniRem"].ToString();
                    this.cboEstablecimientoGiroRem.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeRem"]);
                    //Datos Beneficiario
                    this.txtNomCliBen.Text = tbGiros.Rows[0]["cNombreDes"].ToString();
                    this.txtDniBen.Text = tbGiros.Rows[0]["cNroDniDes"].ToString();
                    this.cboEstablecimientoGiroDes.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeDes"]);

                    this.cboMoneda.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idMoneda"]);
                    this.txtMonGiro.Text = tbGiros.Rows[0]["nMontoGiro"].ToString();

                    idTipoIngresoEgreso = Convert.ToInt32(tbGiros.Rows[0]["idTipoIngresoEgreso"]);
                    idTipoPago = Convert.ToInt32(tbGiros.Rows[0]["idTipoPago"]);
                    this.idModalidadPagoGiro = Convert.ToInt32(tbGiros.Rows[0]["idModalidadPagoGiro"]);

                    habilitarBotones(true);
                }
                else
                {
                    MessageBox.Show("EL GIRO SE ENCUENTRA EN ESTADO " + tbGiros.Rows[0]["cNomEstado"].ToString() + ": " + tbGiros.Rows[0]["cMotivoEstado"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusqueda.Focus();
                    LimpiarControles();
                    return;
                }
            }
        }
        private void btnExtorno_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(0, 0, "Inicio - Registro de Extorno de Giros", btnExtorno);


            var Msg = MessageBox.Show("¿Estas Seguro de EXTORNAR el Giro?", "Extorno de Giros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }
            //===================================================================
            //--Guardar Extorno del Giro
            //===================================================================
            int idKar = Convert.ToInt32(this.txtNroKar.Text);
            int idGiro = Convert.ToInt32(this.txtNroGiro.Text);
            Decimal nMontoGir = Convert.ToDecimal(txtMonGiro.nvalor);
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue);

            bool lModificaSaldoLinea = true;
            int idTipoTransac;

            if (idModalidadPagoGiro == 1) // SI ES EFECTIVO
            {
                int idTipoIngresoEgresoNew = idTipoIngresoEgreso == 1 ? 2 : 1;               
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, idTipoIngresoEgresoNew, nMontoGir))
                {
                    habilitarBotones(false);
                    return;
                }

                idTipoTransac = idTipoIngresoEgresoNew;

                DataTable tbGiro = cncontrolserv.RegExtornoGiros(idKar, idGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nMontoGir, idSol, lModificaSaldoLinea, idMon, idTipoTransac);
                
                if (Convert.ToInt32(tbGiro.Rows[0]["idRpta"].ToString()) == 0)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();
                    
                    MessageBox.Show(tbGiro.Rows[0]["cMensage"].ToString(), "Extorno de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotones(false);
                    this.btnBusqueda.Focus();
                    //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->              
                    int idKardex = Convert.ToInt32(tbGiro.Rows[0]["nNroOperacion"]);
                    ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
                }
                else
                {
                    MessageBox.Show(tbGiro.Rows[0]["cMensage"].ToString(), "Extorno de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.objFrmSemaforo.ValidarSaldoSemaforo();
            }
            else if (idModalidadPagoGiro == 2) // SI ES CON CARGO A CUENTA
            {
                DataTable dtExtornoCuenta = cncontrolserv.RegExtornoGiroAcuenta(idKar, idGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nMontoGir, idSol);
                if (Convert.ToInt32(dtExtornoCuenta.Rows[0]["idRpta"].ToString()) == 0)
                {
                    MessageBox.Show(dtExtornoCuenta.Rows[0]["cMensage"].ToString(), "Extorno de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotones(false);
                    this.btnBusqueda.Focus();
                    //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->              
                    int idKardex = Convert.ToInt32(dtExtornoCuenta.Rows[0]["nNroOperacion"]);
                    ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
                }
                else
                {
                    MessageBox.Show(dtExtornoCuenta.Rows[0]["cMensage"].ToString(), "Extorno de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }            
            
            this.registrarRastreo(0, idKar, "Fin - Registro de Extorno de giros", btnExtorno);
            this.btnCancelar.Enabled = false;
        }
        #endregion
        #region Metodos
        private void LimpiarControles()
        {
            this.txtNroKar.Clear();
            this.txtNroGiro.Clear();
            this.txtTipOpe.Clear();
            this.txtNomCliRem.Clear();
            this.txtDniRem.Clear();
            this.cboEstablecimientoGiroRem.SelectedValue = -1;
            this.txtNomCliBen.Clear();
            this.txtDniBen.Clear();
            this.cboEstablecimientoGiroDes.SelectedValue = -1;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGiro.Text = "0.00";
        }
        private void habilitarBotones(Boolean val)
        {
            this.btnExtorno.Enabled = val;
            this.btnCancelar.Enabled = val;
            this.btnBusqueda.Enabled = !val;
        }
        #endregion                
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmExtornoOpeSocio : frmBase
    {
        clsCNSocio Socio = new clsCNSocio();
        int pidPago = 0, pidTipPago = 0;
        //pidPago puede ser: idAporte, idInscripción ó idFondoDeSeguro, según lo que se desee extornar
        string cTipoOperacSocio = "";//Contedrá todos los tipos de operaciones de socios con los que se podrá realizar los extornos de operaciones
        DataTable dtTipoOperacSocio = new DataTable();

        public frmExtornoOpeSocio()
        {
            InitializeComponent();
        }

        private void frmExtornoOpeSocio_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            conSolesDolar.iMagenMoneda(1);
            CargarComboModalidad(true);
        }

        private void LimpiarControles()
        {
            txtDocIdePerson.Clear();
            txtNombrePerson.Clear();
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
            this.cboTipoOperacion.SelectedValue = 1;
            this.cboMoneda.SelectedValue        = 1;
            this.txtMonOpe.Text                 = "0.00";
        }

        private bool ValiDatos()
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor VErificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.nudNroKardex.Value <= 0)
            {
                MessageBox.Show("El Numero de Kardex no es Válido, VERIFICAR ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Realizar el Extorno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value  = 0;
            txtEstadoOpe.Text   = "";
            LimpiarControles();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            pidPago                     = 0;
            pidTipPago                  = 0;
            btnExtorno.Enabled          = false;
            frmBuscarSolExt frmExtPen   = new frmBuscarSolExt();
            frmExtPen.pidMod            = 4;//SOCIOS         
            dtTipoOperacSocio           = Socio.ObtenerTipoOperacSocios();//Obtiene el tipo de operaciones para: PAGO DE APORTE, PAGO DE FONDO DE SEGURO, PAGO DE INSCRIPCIÓN DE SOCIO, DEVOLUCIÓN DE APORTES
            cTipoOperacSocio            = RetornarCadenaTiposDeOperacion(dtTipoOperacSocio);
            frmExtPen.pidTipOpe         = cTipoOperacSocio;
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar > 0)
            {
                nudNroKardex.Value      = nidKar;
                this.txtEstadoOpe.Text  = frmExtPen.pcEstKardex;
            }
            else
            {
                nudNroKardex.Value      = 0;
                this.txtEstadoOpe.Text  = "";
                return;
            }

            clsCNAprobacion objApr  = new clsCNAprobacion();
            DataTable dtDatExt      = objApr.RetornaDatosOperacionExt(Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia,
                                                                clsVarGlobal.User.idUsuario, 4, cTipoOperacSocio);
            if (dtDatExt.Rows.Count > 0)
            {
                this.txtDocIdePerson.Text           = dtDatExt.Rows[0]["cNroDNI"].ToString();
                this.txtNombrePerson.Text           = dtDatExt.Rows[0]["cNomCliente"].ToString();
                this.txtFechaOpe.Text               = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                this.txtModulo.Text                 = dtDatExt.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue        = dtDatExt.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text                 = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                this.cboModalidad.SelectedValue     = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());

                //--Asignando Valores
                pidPago     = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                pidTipPago  = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());

                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private string RetornarCadenaTiposDeOperacion(DataTable dtTipoOperacSocio)
        {
            string cTipoOperacion = "";
            if (dtTipoOperacSocio.Columns.Count > 0)
            {
                for (int c = 0; c < dtTipoOperacSocio.Columns.Count; c++)
                {
                    cTipoOperacion = cTipoOperacion + dtTipoOperacSocio.Rows[0][c];
                    if (c+1!=dtTipoOperacSocio.Columns.Count)
                    {
                        cTipoOperacion = cTipoOperacion + ",";
                    }
                }                
            }
            else
            {
                cTipoOperacion = "0";
            }
            return cTipoOperacion;
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extorno Operacion de Socio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int idKar       = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idTipOpe    = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon       = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe= Convert.ToDecimal (this.txtMonOpe.Text);

            clsCNAporte ObjAporte = new clsCNAporte();

            DataTable tbExt = new DataTable();

            int idTipoOperacion = Convert.ToInt32(cboTipoOperacion.SelectedValue);

            bool lModificaSaldoLinea = false;

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
                lModificaSaldoLinea = true;

            int idTipoTransac = 1; //ingreso

            for (int f = 0; f < dtTipoOperacSocio.Rows.Count; f++)
			{
                if (idTipoOperacion == Convert.ToInt32(dtTipoOperacSocio.Rows[f]["idTipoOpePAGO_APORTE"]) ||
                    idTipoOperacion == Convert.ToInt32(dtTipoOperacSocio.Rows[f]["idTipoOpePAGO_FONDO_SEG"]) ||
                    idTipoOperacion == Convert.ToInt32(dtTipoOperacSocio.Rows[f]["idTipoOpePAGO_INSCR_SOCIO"]))//PAGO DE APORTE, PAGO DE FONDO DE SEGURO, PAGO DE INSCRIPCIÓN DE SOCIO 
                {
                    /*=========================      REALIZA MONITOREO DE SALDOS   ==========================*/

                    if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)//TRANSFERENCIA A CUENTA
                    {
                        if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 2, nMontoOpe))
                        {
                            return;
                        }
                    }
                    /*==========================     FIN MONITOREO DE SALDOS    ===============================*/

                    tbExt = ObjAporte.RegistraExtornoPagoAportes(idKar, pidPago, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
                }
                if (idTipoOperacion == Convert.ToInt32(dtTipoOperacSocio.Rows[f]["idTipoOpeDEVOL_APORTE"]))//DEVOLUCIÓN DE APORTES
                {
                    /*=========================      REALIZA MONITOREO DE SALDOS   ==========================*/            
                    if (Convert.ToInt32(cboModalidad.SelectedValue) == 1 )//TRANSFERENCIA A CUENTA
                    {
                        if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 1, nMontoOpe))
                        {
                            return;
                        }
                    }
                    /*==========================     FIN MONITOREO DE SALDOS    ===============================*/

                    tbExt = ObjAporte.RegistraExtornoDevolucAportes(idKar, pidPago, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
                }                
			}     

            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) != 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show(tbExt.Rows[0]["msg"].ToString(), "Extorno de Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.nudNroKardex.Enabled = false;
                this.btnExtorno.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["msg"].ToString(), "Extorno de Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CargarComboModalidad(Boolean lEsClienteInstitucion)
        {
            //====================== Cargar Modalidad =================================>
            cboModalidad.DataSource = Socio.ListarModalidadPagoAportesFondo(lEsClienteInstitucion);
            cboModalidad.ValueMember = "idModPagoAporteFondoSeg";
            cboModalidad.DisplayMember = "cModPagoAporteFondoSeg";            
            //========================================================================>
        }
    }
}

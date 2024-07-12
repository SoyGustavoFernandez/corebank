using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;

namespace CAJ.Presentacion
{
    public partial class frmConverDineroElectr : frmBase
    {
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNCliente cnCliente = new clsCNCliente(); 
        clsCNControlOpe cnControlOpe = new clsCNControlOpe();
        DataTable dtConcep;
        private int nTipoOperacion = 5;
        private int nTipoRecibo = 1;
        private int nTamDocumento = 8;
        private int idCli = 0;
        private int idNoCli = 0;
        private int nIndAfecITF = 0;
        private int nConceptoPonerDinero;
        private int nConceptoSacarDinero;

        public frmConverDineroElectr()
        {
            InitializeComponent();
        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void frmConverDineroElectr_Load(object sender, EventArgs e)
        {
            DatosUsuario();            
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpeSoloCaja() != "A")
            {
                this.Dispose();
                return;
            }
            
            CargarConceptos();
            limpiar();
            cboTipoDocumento1.cargarTipDocEspecificos("1,2");
        }

        private void CargarConceptos()
        {
            /*C.idConcepto,C.cConcepto,C.cTipMonto,C.nMontoCon,C.nAfectoITF*/
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            this.nConceptoPonerDinero = Convert.ToInt32(clsVarApl.dicVarGen["nConceptoPonerDinero"]);
            this.nConceptoSacarDinero = Convert.ToInt32(clsVarApl.dicVarGen["nConceptoSacarDinero"]);            

            dtConcep = LisConcep.ListaConceptosEspecificos(nConceptoSacarDinero.ToString() + "," + nConceptoPonerDinero.ToString());

            cboConcepto.DataSource = dtConcep;
            cboConcepto.ValueMember = dtConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = dtConcep.Columns["cConcepto"].ToString();
            if (dtConcep.Rows.Count > 1)
            {
                cboConcepto.SelectedIndex = 1;
            }
            else
            {
                cboConcepto.SelectedIndex = 0;
            }
        }

        private void txtNroDoc_Leave(object sender, EventArgs e)
        {
            cargar();
        }

        private void cboTipoDocumento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento1.SelectedIndex >= 0)
            {
                int idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);
                this.txtNroDoc.Text = string.Empty;

                switch (idTipoDocumento)
                {
                    case 1:
                        nTamDocumento = 8;
                        this.txtNroDoc.MaxLength = 8;
                        break;
                    case 2:
                        nTamDocumento = 12;
                        this.txtNroDoc.MaxLength = 12;
                        break;
                    case 3:
                        nTamDocumento = 12;
                        this.txtNroDoc.MaxLength = 12;
                        break;
                    case 4:
                        nTamDocumento = 11;
                        this.txtNroDoc.MaxLength = 11;
                        break;                    
                    default:
                        nTamDocumento = 0;
                        this.txtNroDoc.MaxLength = 0;
                        break;
                }
                cargar();
            }
        }

        private void alertaOfertas()
        {
            if (this.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.txtNroDoc.Text.Trim());
            }
        }

        private void cargar()
        {
            if (cboTipoDocumento1.SelectedIndex < 0 || txtNroDoc.Text.Trim().Length < 6)
            {
                return;
            }
            DataTable dtPersonas = cnCliente.BuscarPersonaPorDocumento(Convert.ToInt32(cboTipoDocumento1.SelectedValue),
                                                                           txtNroDoc.Text.Trim());
            if (dtPersonas.Rows.Count > 0)
            {
                this.txtNroDoc.Leave -= new System.EventHandler(this.txtNroDoc_Leave);
                txtNombres.Text = dtPersonas.Rows[0]["cNombres"].ToString();
                txtNombres.Enabled = true;
                txtNroDoc.Enabled = false;
                cboTipoDocumento1.Enabled = false;
                txtTelefCel1.Text = dtPersonas.Rows[0]["cCelular"].ToString();
                idCli = Convert.ToInt32(dtPersonas.Rows[0]["idCliente"]);
                idNoCli = Convert.ToInt32(dtPersonas.Rows[0]["idNoCliente"]);
                this.alertaOfertas();
                this.txtNroDoc.Leave += new System.EventHandler(this.txtNroDoc_Leave);
            }
            else 
            {
                txtNombres.Enabled = true;
                txtNroDoc.Enabled = true;
                cboTipoDocumento1.Enabled = true;
                idCli = 0;
                idNoCli = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            txtNombres.Enabled = true;
            txtNroDoc.Enabled = true;
            cboTipoDocumento1.Enabled = true;
        }

        private void limpiar()
        {
            cboTipoDocumento1.SelectedIndex = 0;
            txtNroDoc.Clear();
            txtNombres.Clear();
            cboConcepto.SelectedIndex = -1;
            cboMoneda1.SelectedIndex = 0;
            txtMonto.Clear();
            txtTelefCel1.Clear();

            conCalcVuelto.limpiar();
            nTipoRecibo = 0;
            nTamDocumento = 8;
            idCli = 0;
            idNoCli = 0;
        }

        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);
            x_idCliente = clsVarGlobal.User.idCli;
            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas2 = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas2 = ValidaReglasDinamicas2.ValidarReglas(ArmarTablaParametros(), //dtTablaParametros
                                                                    this.Name,            //cNombreFormulario
                                                                    clsVarGlobal.nIdAgencia,//idAgencia
                                                                    x_idCliente,            //idCliente
                                                                    1,                      //idEstadoOperac
                                                                    Convert.ToInt32(nMoneda),//idMoneda
                                                                    idProd,                 //idProducto
                                                                    Decimal.Parse(nMonto),  //nValAproba
                                                                    0,                      //idDocument
                                                                    clsVarGlobal.dFecSystem,//FechaSolici
                                                                    2,                      //idMotivo
                                                                    1,                      //idEstadoSOl
                                                                    clsVarGlobal.User.idUsuario,//idUsuRegist
                                                                    ref nNivAuto);          //idSolAprob
            if (cCumpleReglas2.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDni";
            drfila[1] = Convert.ToString(this.txtNroDoc.Text);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(Convert.ToDecimal(this.txtMonto.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                nTipoRecibo = Convert.ToInt32(dtConcep.Rows[cboConcepto.SelectedIndex]["idTipRecibo"]);
                if (ValidaSaldoLinea(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda1.SelectedValue), nTipoRecibo, Convert.ToDecimal(txtMonto.Text)))
                {
                    return;
                }

                /*========================================================================================
               * Validar Regla Eob con autorizacion
                ========================================================================================*/
                if (!ValidarReglasAprob(Convert.ToString(this.txtMonto.Text), Convert.ToString(1)))
                {
                    //MessageBox.Show("Error, Businnes Rules aren´t aprobated");
                    return;
                }
                /*========================================================================================
                * FIN -  Validar Regla Eob con autorizacion
                ========================================================================================*/

                bool lModificaSaldoLinea = true;

                DataTable dtResultado = cnControlOpe.GuardarReciboDinElec(nTipoRecibo, Convert.ToInt32(cboConcepto.SelectedValue), idCli, idNoCli,
                    Convert.ToInt32(cboTipoDocumento1.SelectedValue), txtNroDoc.Text.Trim(), txtNombres.Text.Trim(), txtTelefCel1.Text.Trim(),
                    Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToDecimal(txtMonto.Text), 0.00M, Convert.ToDecimal(txtMonto.Text),
                    cboConcepto.Text, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.nIdAgencia,
                    lModificaSaldoLinea);
                
                if (dtResultado.Rows.Count > 0)
                {
                    int idCodigoRecibo = Convert.ToInt32(dtResultado.Rows[0]["cCodRec"]);
                    int idKardex = Convert.ToInt32(dtResultado.Rows[0]["idKardex"]);

                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    MessageBox.Show("El Recibo se Registro Correctamente, NRO RECIBO: " + idCodigoRecibo.ToString(), "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //--Imprimir Voucher 
                    
                    ImpresionVoucher(idKardex, 3, nTipoOperacion, 1, Convert.ToDecimal(conCalcVuelto.txtMonEfectivo.Text), Convert.ToDecimal(conCalcVuelto.txtMonDiferencia.Text), 0, 1);

                    limpiar();
                    txtNombres.Enabled = true;
                    txtNroDoc.Enabled = true;
                    cboTipoDocumento1.Enabled = true;
                    cboTipoDocumento1.Focus();

                }
                
            }
        }

        private bool validar()
        {            
            if((int)cboTipoDocumento1.SelectedValue == 1 && (txtNroDoc.Text.Trim().Length  != nTamDocumento && nTamDocumento != 0))
            {
                MessageBox.Show("Debe ingresar un numero de documento valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if ((int)cboTipoDocumento1.SelectedValue == 2 && (txtNroDoc.Text.Trim().Length > nTamDocumento && nTamDocumento != 0))
            {
                MessageBox.Show("Debe ingresar un numero de documento valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtNombres.Text.Trim().Length <= 6)
            {
                MessageBox.Show("Debe ingresar los nombres del cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTelefCel1.Text.Trim().Length != 9)
            {
                MessageBox.Show("Debe ingresar un número de celular valido (9 Digitos)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboConcepto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la operación a realizar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboMoneda1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar moneda", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtMonto.Text.Trim().Length <= 0 || Convert.ToDecimal(txtMonto.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar el monto para realizar la operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(txtMonto.Text.Trim()) <= 0 || Convert.ToDecimal(txtMonto.Text.Trim()) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaxOpePonerSacarDE"]))
            {
                MessageBox.Show("Debe ingresar un monto mayor a 0 y menor igual a " + clsVarApl.dicVarGen["nMontoMaxOpePonerSacarDE"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTelefCel1.Text.Trim().Length != 9)
            {
                MessageBox.Show("Debe ingresar un número de celular valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            

            //if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(conCalcVuelto.txtMonEfectivo))
            //{
            //    MessageBox.Show("El monto recibido no puede ser menor a monto total.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            return true;
        }

        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcepto.SelectedIndex >= 0)
            {
                nIndAfecITF = (int)dtConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
                conCalcVuelto.Visible = (cboConcepto.SelectedValue.ToString() == this.nConceptoPonerDinero.ToString()); //DINERO ELECTRONICO INGRESOS
            }
        }

        private void Calcular()
        {
          
            if (!string.IsNullOrEmpty(this.txtMonto.Text.Trim()))
            {
                if (this.txtMonto.Text.Trim() == ".")
                {
                    this.txtMonto.Text = "0.00";
                    return;
                }

                if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMonto.Text.Trim()))
                {
                    conCalcVuelto.limpiar();
                }
                if (cboConcepto.SelectedValue.ToString() == this.nConceptoPonerDinero.ToString()) //DINERO ELECTRONICO INGRESOS
                {
                    conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMonto.Text.Trim());
                    conCalcVuelto.Enabled = true;
                    conCalcVuelto.CalculoDirecto(Convert.ToDecimal(txtMonto.Text.Trim()));
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                }

            }
            else
            {
                this.txtMonto.Text = "0.00";
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Calcular();
            }
        }

        private void txtMonto_Validated(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cargar();
            }
        }
    }
}

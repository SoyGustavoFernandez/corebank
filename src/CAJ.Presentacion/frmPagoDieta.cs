using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.Funciones;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmPagoDieta : frmBase
    {
        private int nIndAfecITF = 0;
        private DataTable  tbConcep;
        private int x_nTipOpe = 0;
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNControlOpe cnPagoDieta = new clsCNControlOpe();
        int IdCentroCosto = 0;

        public frmPagoDieta()
        {
            InitializeComponent();
        }

        private void frmPagoDieta_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            x_nTipOpe = 5;
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            //======================================================
            //--Cargar Datos
            //======================================================
            CargarTiporecibos();

            if(CargarConceptos())
            {
                this.Dispose();
                return;
            }
            cargarDetalleConcepto();

            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            HabilitarControles(false);
            
        }

        private string ValidarDatIng()
        {            
            if (string.IsNullOrEmpty(txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("Debe Existir un Codigo de Usuario Para Registrar el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodUsu.Select();
                txtCodUsu.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(conBusCol.txtCod.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar al Director", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboTipRec.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir un Tipo de Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipRec.Select();
                cboTipRec.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboConcepto.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir un Concepto para el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboConcepto.Select();
                cboConcepto.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboMoneda.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir la Moneda para el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Select();
                cboMoneda.Focus();
                return "ERROR";
            }
            
            if (string.IsNullOrEmpty(txtMonRec.Text.Trim()) )
            {
                MessageBox.Show("Debe Ingresar el Monto del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtMonRec.Text) <= 0)
            {
                MessageBox.Show("El Monto del Recibo no debe Ser Cero(0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtTotRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el MOnto del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtTotRec.Text)<=0)
            {
                MessageBox.Show("El Monto Total del Recibo no debe Ser Cero(0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSustento.Select();
                txtSustento.Focus();
                return "ERROR";
            }
            //===========================================================
            //--Valida Monto Maximo de Operacion del concepto de operacion
            //===========================================================
            clsCNControlOpe LisMonto = new clsCNControlOpe();
            DataTable tbMontoConcep = LisMonto.LisMonConcep(clsVarGlobal.nIdAgencia,Convert.ToInt32(this.cboConcepto.SelectedValue));

            if (tbMontoConcep.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Monto de Validacion para el Concepto Registrado", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboConcepto.Select();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtMonRec.Text.Trim()) > Convert.ToDecimal (tbMontoConcep.Rows[0]["nMontoMax"].ToString()))
            {
                MessageBox.Show("El Monto Maximo permitido es:  " + tbMontoConcep.Rows[0]["nMontoMax"].ToString()+" .Verique ", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (cboAgencias.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Debe seleccionar una agencia destino", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Select();
                cboAgencias.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(txtBase1.Text.Trim()))
            {
                MessageBox.Show("Debe seleccionar un Centro de Costo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCentroCosto.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 2;
            cboTipRec.Enabled = false;
        }

        private bool CargarConceptos()
        {
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            //DataTable tbConcep = new DataTable();
            //PAGO DE DIETAS
            tbConcep = LisConcep.CNBuscarIdPagoDieta( Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            cboConcepto.Enabled = false;
            if (tbConcep.Rows.Count <= 0)
            {
                MessageBox.Show("Perfil no Tiene Asignado el Concepto : PAGO DE DIETAS", "Validar Pago de Dietas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = false;
                chcBuscar.Enabled = false;
                return true;
            }
            return false;

        }


        private int ValNivAut()
        {
            clsCNControlOpe ValNivAuto = new clsCNControlOpe();
            return ValNivAuto.RetNivelAutorizacion(1, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
        }

        private int RetParamConfig()
        {
            clsCNControlOpe ParamConfig = new clsCNControlOpe();
            return ParamConfig.RetParamConfiguracion(1);
        }

        private string ValidaInicioOpe()
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpe(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()),clsVarGlobal.nIdAgencia);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada            
            return cEstCie;
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

        private void LimpiarControles()
        {
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
           
            this.txtMonRec.Text = "0.00";
            this.txtRta4ta.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtMonItf.Text = "0.00";
            this.txtSustento.Clear();
            this.txtBase1.Clear();
            chcRent4ta.Checked = false;
        }

        private void HabilitarControles(Boolean Val)
        {
           // this.cboTipRec.Enabled = Val;
            //this.cboConcepto.Enabled = Val;
            this.cboMoneda.Enabled = Val;
            this.cboAgencias.Enabled = false;
            this.conBusCol.txtCod.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = Val;
            this.txtMonRec.Enabled = Val;
            this.txtSustento.Enabled = Val;
        }
        

        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.txtNroRec.Clear();
            HabilitarControles(true);            
            this.txtMonRec.BackColor = Color.White;
            this.chcBuscar.Enabled = false;
            this.chcBuscar.Checked=false;
            this.txtNroRec.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.conBusCol.btnConsultar.Enabled = true;
          
          //  cargarDetalleConcepto();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //======================================================================
            //--Validar Datos Ingresados
            //======================================================================
            if (ValidarDatIng()=="ERROR")
            {
                return;
            }
            if(Convert.ToDecimal (txtMonRec.Text) <= 0)
            {
                MessageBox.Show("El Monto de Recibo Debe Ser Mayor a Cero...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // txtMonRec.Select();
                txtMonRec.Focus();
                return;
            }
            //======================================================================
            //--Obtener Datos Generales
            //======================================================================
            int TipRec = Convert.ToInt32(this.cboTipRec.SelectedValue.ToString());
            int TipCon = Convert.ToInt32(this.cboConcepto.SelectedValue.ToString());
            int idCol;
            int idCli;
           // int nSubItem;

            //======================================================================
            //--Valida, que Mínimo Registre un Colaborador o Cliente
            //======================================================================
            if (string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar por lo Menos un Colaborador", "Pago de Dietas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            idCli = 0;
            idCol = 0;
            
                if (string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Colaborador", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (string.IsNullOrEmpty(this.conBusCol.txtNom.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Colaborador...VERIFICAR", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                idCol = Convert.ToInt32(this.conBusCol.txtCod.Text.Trim());
                idCli = Convert.ToInt32(conBusCol.idCliPer);

            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglas())
            {
                return;
            }

            int TipMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMonRec = Convert.ToDecimal (this.txtMonRec.Text);
            Decimal nMonItf = Convert.ToDecimal (this.txtMonItf.Text);
            Decimal nMonTot = Convert.ToDecimal (this.txtTotRec.Text);
            string cSust = this.txtSustento.Text.Trim();
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text.Trim());

            int idAgeOri=clsVarGlobal.nIdAgencia;
            int idAgeDest = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            if (ValidaSaldoLinea(idUsu, idAgeOri, TipMon, TipRec, nMonTot))
            {
                return;
            }
            string msg="";
            clsCNImpresion Imprimir = new clsCNImpresion();           
            // clsCNControlOpe GuardarRec = new clsCNControlOpe();


            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(idCli, 0, "Inicio - Pago de Dietas", btnGrabar);
            //==============================================================================

            bool lModificaSaldoLinea = true;

            DataTable dtResul = cnPagoDieta.GuardarRecibo(TipRec, TipCon, idCol, idCli, TipMon, nMonRec, nMonItf, nMonTot, cSust, dtpFechaSis.Value, idUsu, idAgeOri, idAgeDest, 0, ref msg,
                                                        IdCentroCosto, lModificaSaldoLinea);

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(idCli, 0, "Fin - Pago de Dietas", btnGrabar);
            //============================================================================

            if (dtResul.Rows.Count >0)
            {
                this.txtNroRec.Text = dtResul.Rows[0]["cCodRec"].ToString();
                //Grabar Pago de Dieta
                cnPagoDieta.CNGrabarPagoDieta(Convert.ToInt32(txtNroRec.Text), Convert.ToDecimal(txtMonRec.Text), Convert.ToDecimal(txtRta4ta.Text), Convert.ToDecimal(txtTotRec.Text));
                
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show("El Recibo se Registro Correctamente, NRO RECIBO: " + dtResul.Rows[0]["cCodRec"].ToString(), "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //--Imprimir Voucher de apertura
                int nIdKardex = Convert.ToInt32(dtResul.Rows[0]["idKardex"]);
                DataTable dtDatosOperacion = Imprimir.CNDatosOperacion(nIdKardex, clsVarGlobal.idModulo, 0, 0, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
                if (dtDatosOperacion.Rows.Count > 0)
                {
                    if (!Imprimir.CNImpresionVoucher(clsVarGlobal.idModulo, x_nTipOpe, dtDatosOperacion, 1))
                    {
                        MessageBox.Show("Ocurrió un problema al intentar imprimir", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show(msg, "Error al Registrar el Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            HabilitarControles(false);
            this.chcBuscar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;       
            this.conBusCol.btnConsultar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarControles();
            
            this.cboConcepto.SelectedIndex = 0;
            this.chcBuscar.Enabled = true;
            this.chcBuscar.Checked = false;
            this.txtNroRec.Enabled = false;
            this.txtMonRec.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void chcBuscar_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarControles();
            this.txtNroRec.Clear();
            if (this.chcBuscar.Checked)
            {
                this.txtNroRec.Enabled = true;
                this.btnBusRec.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.txtNroRec.Select();
                this.txtNroRec.Focus();
            }
            else
            {
                this.txtNroRec.Enabled = false;
                this.btnBusRec.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = clsVarGlobal.User.idCli;
            

            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), 121,
                                                   Decimal.Parse(txtMonRec.Text), 0, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private void BuscarRecibo()
        {
            LimpiarControles();
            if (string.IsNullOrEmpty(this.txtNroRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Número de Recibo a Buscar...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.SelectAll();
                this.txtNroRec.Focus();
                return;
            }

            string msge = "";
            clsCNControlOpe DatosRecibo = new clsCNControlOpe();
            DataTable tbRec = DatosRecibo.CNBuscarPagoDieta(Convert.ToInt32(txtNroRec.Text.Trim()), ref msge);
            if (msge == "OK")
            {
                if (tbRec.Rows.Count == 0)
                {
                    MessageBox.Show("El Nro de Recibo Buscado no Existe...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.SelectAll();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (tbRec.Rows[0]["cEstadoRec"].ToString() == "X")
                {
                    MessageBox.Show("El Nro de Recibo Buscado Esta ELIMINADO...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.Select();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (RetParamConfig() == 1)
                {
                    if (tbRec.Rows[0]["idUsuOpe"].ToString().Trim() != this.txtCodUsu.Text.Trim())
                    {
                        MessageBox.Show("El Recibo fue Generado por Otro Usuario: NO PUEDE ELIMINARLO...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtNroRec.Select();
                        this.txtNroRec.Focus();
                        this.btnCancelar.Enabled = true;
                        return;
                    }
                }

                if (tbRec.Rows[0]["dFechaReg"].ToString() != this.dtpFechaSis.Value.ToString())
                {
                    MessageBox.Show("El Recibo fue Generado En Otra Fecha...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.Select();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (RetParamConfig() == 1)
                {
                    if (Convert.ToInt32(tbRec.Rows[0]["idAgencia"].ToString()) != clsVarGlobal.nIdAgencia)
                    {
                        MessageBox.Show("El Recibo fue Generado En Otra Agencia...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtNroRec.Select();
                        this.txtNroRec.Focus();
                        this.btnCancelar.Enabled = true;
                        return;
                    }
                }

                //============================================================
                //--Cargar Datos del Recibo
                //============================================================
                this.cboTipRec.SelectedValue = tbRec.Rows[0]["idTipRecibo"];
                this.cboMoneda.SelectedValue = tbRec.Rows[0]["idMoneda"];
                this.cboConcepto.SelectedValue = tbRec.Rows[0]["idConcepto"];
                

                this.cboAgencias.SelectedValue = tbRec.Rows[0]["idAgeDestino"];
              //  this.lblAge.Text = (tbRec.Rows[0]["idTipRecibo"].ToString() == "1" ? "Ag. Origen" : "Ag. Destino");


                if (tbRec.Rows[0]["idColaborador"].ToString() != "0")
                {
                    //this.chcColab.Checked = true;
                    this.conBusCol.txtCod.Text = tbRec.Rows[0]["idColaborador"].ToString();
                    this.conBusCol.txtCargo.Text = tbRec.Rows[0]["cCargo"].ToString();
                    this.conBusCol.txtNom.Text = tbRec.Rows[0]["NombreCol"].ToString();
                }
                else
                {
                    this.conBusCol.txtCod.Clear();
                    this.conBusCol.txtCargo.Clear();
                    this.conBusCol.txtNom.Clear();
                }

                //Asignar=tbRec.Rows[0]["idColaborador"];
                this.txtMonRec.Text = tbRec.Rows[0]["nMontoRec"].ToString();
                this.txtMonItf.Text = tbRec.Rows[0]["nMontoITF"].ToString();
                this.txtRta4ta.Text = tbRec.Rows[0]["nMontoRta4ta"].ToString();
                this.txtTotRec.Text = tbRec.Rows[0]["nMontoTot"].ToString();
                this.txtSustento.Text = tbRec.Rows[0]["cSustento"].ToString();
                this.txtBase1.Text = tbRec.Rows[0]["cCentroCosto"].ToString();
                txtMonRec.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.conBusCol.btnConsultar.Enabled = false;
                this.cboAgencias.Enabled = false;

                if (Convert.ToDecimal(txtRta4ta.Text) > 0)
                {
                    chcRent4ta.Checked = true;
                }
                else
                {
                    chcRent4ta.Checked = false;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatoMonto()
        {
           if (!string.IsNullOrEmpty(this.txtMonRec.Text.Trim()))
           {
               this.txtMonItf.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtMonItf.Text));
               this.txtMonRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtMonRec.Text));
               this.txtTotRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtTotRec.Text));
               this.txtRta4ta.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtRta4ta.Text));
           }
           else
           {
                  this.txtMonItf.Text = "0.00";
                  this.txtMonRec.Text = "0.00";
                  this.txtTotRec.Text = "0.00";
                  this.txtRta4ta.Text = "0.00";
           }
            
        }

        private void btnBusRec_Click(object sender, EventArgs e)
        {
            BuscarRecibo();
        }


        private void cargarDetalleConcepto()
        {
            //int nItem;
            txtMonRec.Text = "0.00";
            this.txtMonItf.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            if (cboConcepto.SelectedIndex > 0)
            {
                //Validando la Afectacion de ITF
                if (Convert.ToDecimal (tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"]) > 0)
                {
                    this.txtMonRec.Enabled = false;
                    this.txtMonRec.BackColor = Color.FromName("Control");
                    this.txtMonRec.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
                    this.Calcular();
                }
                else
                {
                    this.txtMonRec.Enabled = true;
                    this.txtMonRec.BackColor = Color.White;
                }
            }

            if (this.cboConcepto.SelectedValue.ToString() != "5")
            {
                this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            }
        }
        

        private void txtNroRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                BuscarRecibo();
            }
        }

    
        private void Calcular()
        {
            if (!string.IsNullOrEmpty(this.txtMonRec.Text.Trim()))
            {
                if (this.txtMonRec.Text.Trim()==".")
                {
                    this.txtTotRec.Text = "0.00";
                    return;
                }
                Decimal nITF;
                if (nIndAfecITF == 1)
                {
                    nITF = nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * Convert.ToDecimal (this.txtMonRec.Text.ToString().Trim()), 2, (Int32)this.cboMoneda.SelectedValue);
                }
                else
                {
                    nITF = 0;
                }
                this.txtMonItf.Text = string.Format("{0:#,#0.00}", nITF);
                if (chcRent4ta.Checked )
                {
                    Decimal nSuma = Convert.ToDecimal (this.txtMonRec.Text) + Convert.ToDecimal (this.txtMonItf.Text);
                    this.txtRta4ta.Text = string.Format("{0:#,#0.00}", nSuma * Convert.ToDecimal (clsVarApl.dicVarGen["nRta4ta"]));
                    nSuma = nSuma - Convert.ToDecimal (this.txtRta4ta.Text);

                    this.txtMonRec.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtMonRec.Text));
                    this.txtRta4ta.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtRta4ta.Text));
                    this.txtTotRec.Text = string.Format("{0:#,#0.00}", nSuma);
                }
                else
                {
                    Decimal nSuma = Convert.ToDecimal (this.txtMonRec.Text) + Convert.ToDecimal (this.txtMonItf.Text);
                    this.txtRta4ta.Text = string.Format("{0:#,#0.00}", nSuma * 0);
                    nSuma = nSuma - Convert.ToDecimal (this.txtRta4ta.Text);

                    this.txtMonRec.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtMonRec.Text));
                    this.txtRta4ta.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtRta4ta.Text));
                    this.txtTotRec.Text = string.Format("{0:#,#0.00}", nSuma);
                }
                
                
            }
            else
            {
                this.txtTotRec.Text = "0.00";
                this.txtRta4ta.Text = "0.00";
                this.txtMonRec.SelectAll();
                this.txtMonRec.Focus();
                chcRent4ta.Checked = false;
            }
        }
        private void txtMonRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Calcular();
            }
        }

        private void txtMonRec_Validated(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void txtMonRec_TextChanged(object sender, EventArgs e)
        {

        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idColaborador";
            drfila[1] = conBusCol.txtCod.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);
                        
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipRecibo";
            drfila[1] = cboTipRec.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgeDestino";
            drfila[1] = cboAgencias.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);
            
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idConcepto";
            drfila[1] = cboConcepto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRec";
            drfila[1] = txtMonRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);            

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtMonItf.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoTotal";
            drfila[1] = txtTotRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);            

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cSustento";
            drfila[1] = txtSustento.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(conBusCol.idUsu))
            {
                return;
            }
            DataTable dt= cnPagoDieta.CNValidaTipoRelacion(Convert.ToInt32(conBusCol.idUsu));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("El Colaborador Debe Ser Director...","Valida Pago de Dieta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.conBusCol.txtCod.Clear();
                this.conBusCol.txtCargo.Clear();                
                this.conBusCol.txtNom.Clear();
            }

            clsCNCliente ClsCliente = new clsCNCliente();

            DataTable dtValidaRuc = ClsCliente.CNBuscaDocumentoCliente(Convert.ToInt32(conBusCol.idCliPer));
            if (dtValidaRuc.Rows.Count <= 0)
            {
                MessageBox.Show("Debe registrar el RUC del Director...", "Valida Pago de Dieta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.conBusCol.txtCod.Clear();
                this.conBusCol.txtCargo.Clear();
                this.conBusCol.txtNom.Clear();
            }

            DataTable dtBuscaSocio = ClsCliente.CNBuscaClienteSocio(Convert.ToInt32(conBusCol.idCliPer));
            if (dtBuscaSocio.Rows.Count <= 0)
            {
                MessageBox.Show("Debe estar registrado como Socio...", "Valida Pago de Dieta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.conBusCol.txtCod.Clear();
                this.conBusCol.txtCargo.Clear();
                this.conBusCol.txtNom.Clear();
            } 
        }

        private void txtSustento_TextChanged(object sender, EventArgs e)
        {
            txtSustento.CharacterCasing = CharacterCasing.Upper;
        }

        private void chcRent4ta_CheckedChanged(object sender, EventArgs e)
        {           
            //txtRta4ta.Enabled = chcRent4ta.Checked;
            Calcular();

            if (!chcRent4ta.Checked)
            {
                txtRta4ta.Text = "";
                Calcular();
            }
        }

        private void btnCentroCosto_Click(object sender, EventArgs e)
        {
            frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto();
            frmBuscaCtrCosto.ShowDialog();
            IdCentroCosto = frmBuscaCtrCosto.pnidCentroCosto;
            txtBase1.Text = frmBuscaCtrCosto.pcNombreCentroCosto;
        }    
    }
}

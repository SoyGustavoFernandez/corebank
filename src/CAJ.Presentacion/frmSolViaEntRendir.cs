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
using DEP.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmSolViaEntRendir : frmBase
    {
        private int nIndAfecITF = 0;
        private DataTable  tbConcep;
        private int x_nTipOpe = 0;
        DataTable dtbNumCuentas = null;
        clsFunUtiles FunTruncar = new clsFunUtiles();

        public frmSolViaEntRendir()
        {
            InitializeComponent();
        }

        private void frmEmisionRecibos_Load(object sender, EventArgs e)
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
            if (this.cboTipRec.SelectedIndex<0)  //(string.IsNullOrEmpty(txtCodUsu.Text.Trim()))
            {
               CargarConceptos(0); 
            }
            else
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue.ToString().Trim()));
            }
            this.conBusCol.Visible = true;
            this.conBusCli.Visible = false;
            this.chcCliente.Visible = false;
            HabilitarControles(false);
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.rbtLocal.Checked = false;
            this.txtCiudad.Enabled = false;
            this.btnBusCiudad.Enabled = false;
            this.txtTotalComision.Enabled = false;
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
            
            if (string.IsNullOrEmpty(txtMonVia.Text.Trim()) )//&& Convert.ToInt32(txtMonRec.Text.Trim()) == 0)
            {
                MessageBox.Show("Debe Ingresar el Monto del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonVia.Select();
                txtMonVia.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtTotRec.Text.Trim()) )//&& Convert.ToInt32(txtTotRec.Text.Trim()) == 0)
            {
                MessageBox.Show("El Monto Total del Recibo no debe Ser Cero(0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonVia.Select();
                txtMonVia.Focus();
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

            if (Convert.ToDecimal (txtMonVia.Text.Trim()) > Convert.ToDecimal (tbMontoConcep.Rows[0]["nMontoMax"].ToString()))
            {
                MessageBox.Show("El Monto Maximo permitido es:  " + tbMontoConcep.Rows[0]["nMontoMax"].ToString()+" .Verique ", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonVia.Select();
                txtMonVia.Focus();
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
        }

        private void CargarConceptos(int nTipRec)
        {
            clsCNControlViaticos LisConcep = new clsCNControlViaticos();
            tbConcep = LisConcep.CNListadoConcepViatico();
            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            this.cboConcepto.SelectedIndex = 0;
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

        private void LimpiarCliCol()
        {
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtCodAge.Clear();
            this.conBusCli.txtCodInst.Clear();
            this.conBusCli.txtDireccion.Clear();
        }

        private void LimpiarControles()
        {
            this.txtNroRec.Clear();
            cboMoneda.SelectedValue = 1;
            cboConcepto.SelectedValue = 0;
            cboFinalidadVia.SelectedValue = 0;
            
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtCodAge.Clear();
            this.conBusCli.txtCodInst.Clear();
            this.conBusCli.txtDireccion.Clear();

            this.rbtLocal.Checked = false;
            this.rbtNacional.Checked = false;
            this.rbtExtranjero.Checked = false;
            txtCiudad.Text = "";
            nudPorLibVa.Value = 0;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            nudDias.Value = 1;
            this.txtMonVia.Text = "0.00";
            this.txtTotalComision.Text = "0.00";
            this.txtPasaje.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
           
        }

        private void LimpiarControlesBus()
        {
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.txtMonVia.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
        }
        private void HabilitarControles(Boolean Val)
        {
            this.cboConcepto.Enabled = Val;
            this.cboMoneda.Enabled = Val;
            this.conBusCol.txtCod.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = Val;
            this.conBusCli.btnBusCliente.Enabled = Val;
            
            this.cboFinalidadVia.Enabled = Val;
            this.txtSustento.Enabled = Val;                                 
        }

        private void HabCtrlsViaticos(Boolean Val)
        {
            this.grbTipDes.Enabled = Val;
            this.txtCiudad.Enabled = Val;
            dtpFecFin.Enabled = Val;
        }
        
        private void cboTipRec_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

       
        private void cboTipRec_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles(true);
            HabCtrlsViaticos(false);
            this.cboConcepto.SelectedIndex = 0;
            this.txtMonVia.BackColor = Color.White;
            this.chcBuscar.Enabled = false;
            this.chcBuscar.Checked=false;
            this.txtNroRec.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnBusCiudad.Enabled = false;

            this.conBusCol.Visible = true;
            this.conBusCli.Visible = false;
            this.chcCliente.Visible = false;
            chcCliente.Checked = false;

            this.conBusCol.btnConsultar.Enabled = false;
            this.conBusCli.btnBusCliente.Enabled = false;
            this.cboTipRec.SelectedValue = 2;
            //--Datos de la Cuenta
            if (dtgCtasAho.Rows.Count > 0)
            {
                dtbNumCuentas.Rows.Clear();
            }
            dtgCtasAho.Refresh();

            this.cboMoneda.Focus();
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
            if(Convert.ToDecimal (txtMonVia.Text) <= 0)
            {
                MessageBox.Show("El Monto de Recibo Debe Ser Mayor a Cero...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // txtMonRec.Select();
                txtMonVia.Focus();
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
            if (string.IsNullOrEmpty(this.conBusCli.txtCodCli.Text.Trim()) && string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar por lo Menos un Colaborador o Cliente", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //---Validar dato del Cliente
            if (string.IsNullOrEmpty(this.conBusCli.txtCodCli.Text.Trim()))
            {
                idCli = 0;
            }
            else
	        {
                idCli = Convert.ToInt32(this.conBusCli.txtCodCli.Text.Trim());
	        }
            //--Validar dato del colaborador
            if (string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
            {
                idCol = 0;
            }
            else
            {
                idCol = Convert.ToInt32(this.conBusCol.txtCod.Text.Trim());
                idCli = Convert.ToInt32(conBusCol.idCliPer);
            }


            int TipMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMonRec = Convert.ToDecimal (this.txtMonVia.Text);
            Decimal nMonItf = Convert.ToDecimal (clsVarGlobal.nITF);
            Decimal nMonTot = Convert.ToDecimal (this.txtTotRec.Text);
            string cSust = this.txtSustento.Text.Trim();
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text.Trim());

            int idAgeOri=clsVarGlobal.nIdAgencia;
            int idAgeDest = clsVarGlobal.nIdAgencia;

            if ( ValidaSaldoLinea(idUsu, idAgeOri, TipMon, TipRec, nMonTot))
            {
                return;
            }

            string msg="";
            clsCNImpresion Imprimir = new clsCNImpresion();           
            clsCNControlOpe GuardarRec = new clsCNControlOpe();

            bool lModificaSaldoLinea = true;

            DataTable dtResul = GuardarRec.GuardarRecibo(TipRec, TipCon, idCol, idCli, TipMon, nMonRec, nMonItf, nMonTot, cSust, dtpFechaSis.Value, idUsu, idAgeOri, idAgeDest, 0, ref msg, 0, lModificaSaldoLinea);
            if (dtResul.Rows.Count > 0)
            {
                this.txtNroRec.Text = dtResul.Rows[0]["cCodRec"].ToString();

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

            this.objFrmSemaforo.ValidarSaldoSemaforo();
            HabilitarControles(false);
            HabCtrlsViaticos(false);
            this.chcBuscar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnBusCiudad.Enabled = false;
            this.chcCliente.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = false;
            this.conBusCli.btnBusCliente.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            HabCtrlsViaticos(false);
            LimpiarControles();
            conBusCli.Enabled = false;
            this.cboConcepto.SelectedIndex = 0;
            this.chcBuscar.Enabled = true;
            this.chcBuscar.Checked = false;
            this.txtNroRec.Enabled = false;
            this.txtMonVia.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnBusCiudad.Enabled = false;

            this.conBusCol.Visible = true;
            this.conBusCol.Enabled = false;
            this.conBusCli.Visible = false;
            this.chcCliente.Visible = false;
            chcCliente.Checked = false;
            //--Datos de la Cuenta
            if (dtgCtasAho.Rows.Count > 0)
            {
                dtbNumCuentas.Rows.Clear();
            }
            dtgCtasAho.Refresh();
        }

        private void chcBuscar_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarControles();
            if (this.chcBuscar.Checked)
            {
                this.txtNroRec.Enabled = true;
                this.btnBusRec.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
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

        private void BuscarRecibo()
        {
            LimpiarControlesBus();
            this.chcCliente.Checked = false;
            if (string.IsNullOrEmpty(this.txtNroRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Número de Recibo a Buscar...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.SelectAll();
                this.txtNroRec.Focus();
                return;
            }

            string msge = "";
            clsCNControlOpe DatosRecibo = new clsCNControlOpe();
            DataTable tbRec = DatosRecibo.BuscarRecibo(Convert.ToInt32(txtNroRec.Text.Trim()), ref msge);
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

                if (tbRec.Rows[0]["idColaborador"].ToString() != "0")
                {
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

                //--datos del Cliente
                if (tbRec.Rows[0]["idCli"].ToString() != "0")
                {
                    this.chcCliente.Checked = true;
                    this.conBusCli.txtCodCli.Text = tbRec.Rows[0]["idCli"].ToString();
                    this.conBusCli.txtNroDoc.Text = tbRec.Rows[0]["cDocumentoID"].ToString();
                    this.conBusCli.txtNombre.Text = tbRec.Rows[0]["cNombre"].ToString();
                }
                else
                {
                    this.conBusCli.txtCodCli.Clear();
                    this.conBusCli.txtNroDoc.Clear();
                    this.conBusCli.txtNombre.Clear();
                }

                //Asignar=tbRec.Rows[0]["idColaborador"];
                this.txtMonVia.Text = tbRec.Rows[0]["nMontoRec"].ToString();
                this.txtTotRec.Text = tbRec.Rows[0]["nMontoTot"].ToString();
                this.txtSustento.Text = tbRec.Rows[0]["cSustento"].ToString();
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.conBusCol.btnConsultar.Enabled = false;
                this.conBusCli.btnBusCliente.Enabled = false;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatoMonto()
        {
           if (!string.IsNullOrEmpty(this.txtMonVia.Text.Trim()))
           {
               //this.txtMonItf.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal(this.txtMonItf.Text));
               this.txtMonVia.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtMonVia.Text));
               this.txtTotRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtTotRec.Text));
           }
           else
           {
                  //this.txtMonItf.Text = "0.00";
                  this.txtMonVia.Text = "0.00";
                  this.txtTotRec.Text = "0.00";
           }
            
        }

        private void btnBusRec_Click(object sender, EventArgs e)
        {
            BuscarRecibo();
        }

        private void LimpiarDatosViaCli()
        {
            //--Datos de la Cuenta
            if (dtgCtasAho.Rows.Count > 0)
            {
                for (int i = 0; i < dtgCtasAho.Rows.Count; i++)
                {
                    dtgCtasAho.Rows.Remove(dtgCtasAho.Rows[i]);
                }
            }
            dtgCtasAho.Refresh();

            this.conBusCol.Visible = true;
            this.conBusCli.Visible = false;
            this.chcCliente.Visible = false;
            this.chcCliente.Checked = false;
            this.rbtLocal.Checked = false;
            this.rbtNacional.Checked = false;
            this.rbtExtranjero.Checked = false;
            this.grbTipDes.Enabled = false;
            this.txtTotalComision.Enabled = false;
            this.txtPasaje.Enabled = false;

            this.txtCiudad.Text = "";
            this.txtMonVia.Text = "0.00"; ;
            this.txtTotRec.Text = "0.00";
            this.nudDias.Value = 1;
            this.txtTotalComision.Text = "0.00";
            this.txtPasaje.Text = "0.00";
            this.txtSustento.Clear();

        }

        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nItem;
            LimpiarCliCol();
            LimpiarDatosViaCli();
            this.dtgCtasAho.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = true;
            this.chcCliente.Checked = false;

            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            if (cboConcepto.SelectedIndex >= 0)
            {
                if (Convert.ToInt32(tbConcep.Rows[this.cboConcepto.SelectedIndex]["idConcepto"]) == clsVarApl.dicVarGen["nConcepViatico"])  //--Viaticos
                {
                    this.chcCliente.Visible = false;
                    
                }
                else  // Entrega a Rendir y Otros
                {
                    this.chcCliente.Visible = true;
                    this.chcCliente.Enabled = true;
                }
            }           
        }

        private void txtNroRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                BuscarRecibo();
            }
        }



        private void chcColab_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chcCliente_CheckedChanged(object sender, EventArgs e)
        {
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtNombre.Clear();

            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();

            if (this.chcCliente.Checked)
            {
                this.conBusCli.Visible = true;
                this.conBusCol.Visible = false;

                this.conBusCli.Enabled = true;              
                this.conBusCli.btnBusCliente.Enabled = true;
                this.conBusCol.btnConsultar.Enabled = false;
            }
            else
            {
                this.conBusCli.Visible = false;
                this.conBusCol.Visible = true;
                this.conBusCli.Enabled = false;
                this.conBusCol.btnConsultar.Enabled = true;
                this.conBusCli.btnBusCliente.Enabled = false;
            }
        }


        private void Calcular()
        {
            if (!string.IsNullOrEmpty(this.txtMonVia.Text.Trim()))
            {
                Decimal nITF;
                if (nIndAfecITF == 1)
                {
                    nITF = nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * Convert.ToDecimal (this.txtMonVia.Text.ToString().Trim()), 2, (Int32)this.cboMoneda.SelectedValue);
                }
                else
                {
                    nITF = 0;
                }
                //this.txtMonItf.Text = string.Format("{0:#,#0.00}", nITF);
                Decimal nSuma = Convert.ToDecimal (this.txtMonVia.Text) + 0.00m;
                this.txtMonVia.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtMonVia.Text));
                this.txtTotRec.Text = string.Format("{0:#,#0.00}", nSuma);
            }
            else
            {
                this.txtTotRec.Text = "0.00";
                this.txtMonVia.SelectAll();
                this.txtMonVia.Focus();
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

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            LimpiarDatosViaCli();
            nudPorLibVa.Value = 0;
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                return;
            }
            int nIdCliente = 0,
                idMon = 0;
            idMon = Convert.ToInt16(cboMoneda.SelectedValue);
            nIdCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);
            CargarDatos(nIdCliente, 1, idMon, 20);

            this.dtgCtasAho.Enabled = true;
            dtgCtasAho.Columns["lCheck"].ReadOnly = false;
            this.grbTipDes.Enabled = true;
            dtpFecFin.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void CargarDatos(int nIdCliente, int nEstadoCta, int idMon, int nTipOpe)
        {
            clsCNDeposito objDeposito = new clsCNDeposito();
            dtbNumCuentas = objDeposito.CNCuentasAhorros(nIdCliente, nEstadoCta, idMon, nTipOpe);
            dtbNumCuentas.Columns["lCheck"].ReadOnly = false;
            dtgCtasAho.DataSource = dtbNumCuentas;
            ColorFilasGrid();
        }

        private void ColorFilasGrid()
        {
            foreach (DataGridViewRow row in dtgCtasAho.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private void btnBusCiudad_Click(object sender, EventArgs e)
        {
            frmDestinoViatico frmVia = new frmDestinoViatico();
            if (rbtLocal.Checked)
            {
                frmVia.pnTibBus = 0;
            }
            if (rbtNacional.Checked)
            {
                frmVia.pnTibBus = 1;
            }
            if (rbtExtranjero.Checked)
            {
                frmVia.pnTibBus = 2;
            }            
            frmVia.ShowDialog();
            if (frmVia.xnidUbigeo==0)
            {
                txtCiudad.Text = "";
            }
            else
            {
                txtCiudad.Text = frmVia.x_cNomDestino;
                if (Convert.ToInt32(cboConcepto.SelectedValue) == clsVarApl.dicVarGen["nConcepViatico"])  //--Viaticos
                {
                    txtMonVia.Text = string.Format("{0:#,#0.00}", frmVia.x_nMonVia);
                    this.txtPasaje.Enabled = true;
                    this.txtTotalComision.Enabled = false;
                    CalculaMontoVia();
                }
                else  // Entrega a Rendir y Otros
                {
                    txtMonVia.Text = string.Format("{0:#,#0.00}", 0.00);
                    this.txtTotalComision.Enabled = true;
                    this.txtPasaje.Enabled = true;
                }                             
            }

        }

        private void nudDias_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbtLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboConcepto.SelectedIndex<=0)
            {
                return;
            }
            if (rbtLocal.Checked)
            {
                InicializarMontos();
                if (Convert.ToDecimal (txtMonVia.Text)==0)
                {
                    this.txtTotalComision.Enabled = true;
                }
                else
                {
                    this.txtTotalComision.Enabled = false;
                }
                this.txtPasaje.Enabled = true;
                btnBusCiudad.Enabled = false;
                txtCiudad.Enabled = true;
                txtCiudad.Clear();
                txtCiudad.Focus();
            }
        }

        private void rbtNacional_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboConcepto.SelectedIndex <= 0)
            {
                return;
            }
            if (rbtNacional.Checked)
            {
                InicializarMontos();
                this.txtTotalComision.Enabled = false;
                btnBusCiudad.Enabled = true;
                txtCiudad.Enabled = false;
                txtCiudad.Clear();
                btnBusCiudad.Focus();
            }
        }

        private void rbtExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboConcepto.SelectedIndex <= 0)
            {
                return;
            }
            if (rbtExtranjero.Checked)
            {
                InicializarMontos();
                this.txtTotalComision.Enabled = false;
                btnBusCiudad.Enabled = true;
                txtCiudad.Enabled = false;
                txtCiudad.Clear();
                btnBusCiudad.Focus();
            }
        }

        private void InicializarMontos()
        {
            this.txtMonVia.Text = "0.00";
            this.txtTotalComision.Text = "0.00";
            this.txtPasaje.Text = "0.00";
            this.txtTotRec.Text = "0.00";
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            LimpiarDatosViaCli();
            nudPorLibVa.Value = 0;
            if (string.IsNullOrEmpty(conBusCol.txtCod.Text))
            {
                return;
            }
            if (Convert.ToInt32(conBusCol.txtCod.Text)<=0)
            {
                return;
            }
            int nIdCliente = 0,
                idMon = 0;
            idMon = Convert.ToInt16(cboMoneda.SelectedValue);
            nIdCliente = Convert.ToInt32(conBusCol.idCliPer);
            nudPorLibVa.Value = Convert.ToInt32(conBusCol.nPorLibVia);

            CargarDatos(nIdCliente, 1, idMon, 20);
            this.dtgCtasAho.Enabled = true;
            //dtgCtasAho.Columns["lCheck"].ReadOnly = false;
            this.grbTipDes.Enabled = true;
            dtpFecFin.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            nudDias.Value = 1;
            txtTotalComision.Text = "0.00";
            if (dtpFecFin.Value<dtpFecIni.Value)
            {
                MessageBox.Show("La Fecha Fin, NO puede ser Menor a la Fecha Inicial", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecFin.Value = clsVarGlobal.dFecSystem;
                return;
            }
            CalculaMontoVia();
        }

        private void CalculaMontoVia()
        {
            if (string.IsNullOrEmpty(txtPasaje.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtTotalComision.Text))
            {
                return;
            }
            if (Convert.ToDecimal (txtPasaje.Text) < 0)
            {
                txtPasaje.Text = "0.00";
                return;
            }
            if (Convert.ToDecimal (txtTotalComision.Text) < 0)
            {
                txtTotalComision.Text = "0.00";
                return;
            }
            int nDias = (dtpFecFin.Value - dtpFecIni.Value).Days + 1;
            nudDias.Value = nDias;
            if (Convert.ToDecimal (txtMonVia.Text)>0)
            {
                txtTotalComision.Text = string.Format("{0:#,#0.00}", nDias * Convert.ToDecimal (txtMonVia.Text));
            }            
            this.txtTotRec.Text = string.Format("{0:#,#0.00}", (Convert.ToDecimal (txtTotalComision.Text) + Convert.ToDecimal (txtPasaje.Text)));
        }

        private void txtPasaje_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoVia();
        }

        private void txtTotalComision_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoVia();
        }

        private void txtPasaje_Leave(object sender, EventArgs e)
        {
            txtPasaje.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (txtPasaje.Text));
        }

        private void txtTotalComision_Leave(object sender, EventArgs e)
        {
            txtTotalComision.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (txtTotalComision.Text));
        }

        private void dtgCtasAho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCtasAho.Rows.Count == 1)
            {
                //dtgCtasAho.Rows[0].Cells["lCheck"].Value = true;
                if (Convert.ToBoolean(dtgCtasAho.Rows[0].Cells["lCheck"].Value))
                {
                    dtgCtasAho.Rows[0].Cells["lCheck"].Value = false;
                }
                else
                {
                    dtgCtasAho.Rows[0].Cells["lCheck"].Value = true;
                }
                return;
            }

            int index = dtgCtasAho.CurrentRow.Index;
            for (int i = 0; i < dtgCtasAho.Rows.Count; i++)
            {
                dtgCtasAho.Rows[i].Cells["lCheck"].Value = false;
            }
            dtgCtasAho.Rows[index].Cells["lCheck"].Value = true;
        }
    }
}

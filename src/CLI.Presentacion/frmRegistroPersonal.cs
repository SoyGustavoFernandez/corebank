using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using EntityLayer;
using CLI.CapaNegocio;
using System.Text.RegularExpressions;

namespace CLI.Presentacion
{
    public partial class frmRegistroPersonal : frmBase
    {
        #region Variables Globales

        clsCNGuardaPersonal cnguardapersonal = new clsCNGuardaPersonal();
        string pcTipoOpe = "N";//Puede ser N-->Nuevo o A-->Actualizar
        string TipOpeFamiliares = "N";
        string TipOpeHistorial = "N";
        DataTable dtbBuscaPersonal;
        DataTable dtHistorial;
        DataTable dtFamiliares;
        int idUsuario = 0;
        int permiso = 0;
        int permiso2 = 0;
        int ContNuevos = 999999;
        int ContNuevosFAM = 999999;

        #endregion

        #region Eventos

        public frmRegistroPersonal()
        {
            InitializeComponent();
        }
        private void frmRegistroPersonal_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            conBusUbiCli.cargar();
            conBusUbig2.cargar();
            cboProcedPais.CargarUbigeo(0);
            cboTipDocumento1.CargarDocumentos("H");
            CargarDatos();
            CleanData();
            CleanHistorial();
            CleanFamiliares();
            HabilitarControles(false);
            HabilitarCtrlHistorial(false);
            HabilitarCtrlFamiliares(false);
            tbcBase1.SelectedIndex = 2;
            CargarFamiliares(0);            
            tbcBase1.SelectedIndex = 0;
            permiso = 1;
            conBusCli.txtCodCli.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarData())
                return;
            //===================================================================
            //Obtener Datos Generales
            //======================================================================
            int tcIdCliente = Convert.ToInt32(conBusCli.txtCodCli.Text.Trim());
            int nidAgencia = (int)cboAgencia1.SelectedValue;
            int nidEstablecimiento = (int)cboEstablecimiento1.SelectedValue;
            int nidArea = (int)cboArea1.SelectedValue;            
            int idCargoPer = (int)cboCargoPersonal.SelectedValue;
            int idTipContrato = (int)cboTipContratoPersonal1.SelectedValue;
            int idTipoContratoTiempo = (int)cboTipoContratoTiempo.SelectedValue;
            string cEmailInst = txtEmailInst.Text;
            string cTelCelPer = txtTelCelPer.Text;
            DateTime dfechaReg = DateTime.Today; //Fecha de registro o modificacion
            int idUsuReg = clsVarGlobal.User.idUsuario; //Usuario que registra o que modifica
            
            int idTipoRegimen = 0;
            if(cboTipoRegimenPens1.Text!="")
                idTipoRegimen = (int)cboTipoRegimenPens1.SelectedValue;
            int idRegimen = 0;
            if (cboRegimenPens.Text!="")    
                idRegimen = (int)cboRegimenPens.SelectedValue;
            int idEsqComAFP = 0;
            if (cboEsqComAFP1.Text != "")
                idEsqComAFP = (int)cboEsqComAFP1.SelectedValue;

            string cRegPensiones = txtRegistroReg.Text;
            DateTime dInicioPensiones = dFecIniReg.Value;
            
            int lDepSalarioPropio = 0;
            int idCodInstSalario = 0;
            string cCtaSalario="";
            
            int lDepCTSPropio = 0;
            int idCodInstCTS = 0;
            string cCtaCTS="";            
                     

            if (CBDepPropioSalario.Checked == true) {
                lDepSalarioPropio = 1;
                cCtaSalario = txtCodIns.Text.Trim() + txtCodAge.Text.Trim() + txtCodMod.Text.Trim() + txtCodMon.Text.Trim() + txtCodCta.Text.Trim();                                          
            }
            else if (CBDepPropioSalario.Checked == false){
                lDepSalarioPropio = 0;
                cCtaSalario =txtCtaAhorroExterno.Text.Trim();              
                if (cboEntidad1.Text.Trim() != "")
                    idCodInstSalario = Convert.ToInt32(cboEntidad1.SelectedValue);                
            }
                        
            if (CBDepPropioCTS.Checked == true)
            {
                lDepCTSPropio = 1;
                cCtaCTS = txtCodInsCTS.Text.Trim() + txtCodAgeCTS.Text.Trim() + txtCodModCTS.Text.Trim() + txtCodMonCTS.Text.Trim() + txtCodCtaCTS.Text.Trim();                
            }
            else if (CBDepPropioCTS.Checked == false)
            {
                lDepCTSPropio = 0;
                cCtaCTS = txtCtaCTSExterno.Text.Trim();                
                if (cboEntidad2.Text.Trim() != "")
                    idCodInstCTS = Convert.ToInt32(cboEntidad2.SelectedValue);
            }      
            

            string cAutogenerado = txtNroAutogenerado.Text;

            int idGrupSanguineo = 0;
            if (cboGrupoSanguineo1.Text.Trim() != "")
                idGrupSanguineo = (int)cboGrupoSanguineo1.SelectedValue;

            int lDiscapacidad = Convert.ToInt32(CBDiscapacidad.Checked);

            //===================================================================
            //Guardar Datos de Historial de Relaciones Laborales Mediante XML
            //===================================================================  

            DataSet dsLab = new DataSet("dsRelLaboral");
            dsLab.Tables.Add(dtHistorial);
            string xmlRelLab = dsLab.GetXml();
            xmlRelLab = clsCNFormatoXML.EncodingXML(xmlRelLab);
            dsLab.Tables.Clear();

            //===================================================================
            //Guardar Datos de Historial de Relaciones Laborales Mediante XML
            //===================================================================  

            DataSet dsFam = new DataSet("dsFamiliares");
            dsFam.Tables.Add(dtFamiliares);
            string xmlFamiliares = dsFam.GetXml();
            xmlFamiliares = clsCNFormatoXML.EncodingXML(xmlFamiliares);
            dsFam.Tables.Clear();

            var idCategoria = Convert.ToInt32(cboCategoriaPersonal1.SelectedValue);

            var cWinUser = txtidUsuario.Text.Trim();
            //===================================================================
            //Guardar Datos del Cliente
            //===================================================================
            
            if (pcTipoOpe == "N")
            {
                //=================  Registro Inicio Rastreo ======================
                this.registrarRastreo(conBusCli.idCli, 0, "Inicio  - Registro Personal", btnGrabar);
                //=================================================================

                DataTable dtbPersonal = cnguardapersonal.GuardaPersonal(tcIdCliente, nidAgencia,
                                               idCargoPer, idTipContrato, idTipoRegimen, idRegimen, idEsqComAFP,cRegPensiones,
                                              dInicioPensiones, cCtaSalario, cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento,idTipoContratoTiempo,lDiscapacidad,
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS, xmlRelLab, xmlFamiliares, idCategoria, cWinUser, dfechaReg, idUsuReg, cEmailInst, cTelCelPer);
                MessageBox.Show("Los Datos se Registraron Correctamente", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtidUsuario.Text = dtbPersonal.Rows[0]["idPersonal"].ToString();
                this.txtidUsuario.Enabled = false;
                //=================   Registro Fin Rastreo    ================================
                this.registrarRastreo(conBusCli.idCli, 0, "Fin - Registro Personal", btnGrabar);
                //============================================================================
            }
            else if (pcTipoOpe == "A")
            {
                //=================  Registro Inicio Rastreo ================================
                this.registrarRastreo(conBusCli.idCli, 0, "Inicio  - Actualización Personal", btnGrabar);
                //===========================================================================

                cnguardapersonal.ActualizaPersonal(idUsuario, nidAgencia, idCargoPer, idTipContrato, idTipoRegimen, idRegimen, idEsqComAFP, cRegPensiones,
                                              dInicioPensiones, cCtaSalario, cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento, idTipoContratoTiempo, lDiscapacidad,
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS, xmlRelLab, xmlFamiliares, idCategoria, dfechaReg, idUsuReg, cEmailInst, cTelCelPer);
                
                MessageBox.Show("Los Datos se Actualizaron Correctamente", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //=================   Registro Fin Rastreo    ================================
                this.registrarRastreo(conBusCli.idCli, 0, "Fin - Actualización Personal", btnGrabar);
                //===========================================================================
            }
            this.BuscaPersonal(Convert.ToInt32(conBusCli.txtCodCli.Text.Trim()));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanData();
            CleanHistorial();
            if (dtgHistorial.Rows.Count > 0)
                dtHistorial.Rows.Clear();
            if (dtgFamiliares.Rows.Count > 0)
                dtFamiliares.Rows.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtDireccion.Clear();
            this.conBusCli.txtCodInst.Clear();
            this.conBusCli.txtCodAge.Clear();
                  

            HabilitarControles(false);
            HabilitarCtrlHistorial(false);

            this.btnMiniNuevo.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniOK.Enabled = false;
            this.btnMiniEliminar.Enabled = false;

            this.btnNuevoFAM.Enabled = false;
            this.btnEditarFAM.Enabled = false;
            this.btnOKFAM.Enabled = false;
            this.btnEliminarFAM.Enabled = false;

            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnGrabar.Enabled = false;

            this.conBusCli.btnBusCliente.Enabled = true;
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();
            txtidUsuario.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);

            if (cboEsqComAFP1.Text == "")
                cboEsqComAFP1.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            

            //sobre el Historial de las relaciones laborales
            this.btnMiniNuevo.Enabled = true;
            this.btnMiniEditar.Enabled = true;
            this.btnMiniOK.Enabled = false;
            this.btnMiniEliminar.Enabled = true;

            if (dtgHistorial.Rows.Count == 0) {
                this.btnMiniEditar.Enabled = false;
                this.btnMiniEliminar.Enabled = false;            
            }
            
            //sobre las cuentas de depositos
            if (CBDepPropioSalario.Checked == true)
            {
                this.cboTipoEntidad1.Enabled = false;
                this.cboEntidad1.Enabled = false;
                this.txtCtaAhorroExterno.Enabled = false;
            }
            if (CBDepPropioSalario.Checked == false)
            {                
                this.btnBuscarCta.Enabled = false;
            }
                
            if (CBDepPropioCTS.Checked == true)
            {                
                this.cboTipoEntidad2.Enabled = false;
                this.cboEntidad2.Enabled = false;
                this.txtCtaCTSExterno.Enabled = false;
            }
            if (CBDepPropioCTS.Checked == false)
            {               
                this.btnBuscarCtaCTS.Enabled = false;
            }

            if (Convert.ToInt32(clsVarApl.dicVarGen["lPermiteCtaSalarioExterna"]) == 0) {
                CBDepPropioSalario.Enabled = false;
            }
            if (Convert.ToInt32(clsVarApl.dicVarGen["lPermiteCtaCTSExterna"]) == 0)
            {
                CBDepPropioCTS.Enabled = false;
            }

            
            //sobre los familiares
            this.btnNuevoFAM.Enabled = true;
            this.btnEditarFAM.Enabled = true;             
            this.btnOKFAM.Enabled = false;
            this.btnEliminarFAM.Enabled = true;

            if (dtgFamiliares.Rows.Count == 0)
            {
                this.btnEditarFAM.Enabled = false;
                this.btnEliminarFAM.Enabled = false;
            }

            if (pcTipoOpe.ToUpper()=="N")
            {
                txtidUsuario.Enabled = true;
                asignarNuevoUsuario();
            }
        }         

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.txtCodCli.Text.Trim() == "")
            {
                CleanData();
                CleanHistorial();
                if (dtgHistorial.Rows.Count > 0)
                    dtHistorial.Rows.Clear();
                conBusCli.txtCodCli.Focus();
                return;
            }

            if (Convert.ToInt32(conBusCli.nidTipoPersona) == 2)
            {
                MessageBox.Show("No se puede asignar como personal a una Persona Jurídica", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCli.txtCodCli.Enabled = true;
                this.conBusCli.txtCodCli.Focus();
                this.conBusCli.txtCodInst.Text = "";
                this.conBusCli.txtCodAge.Text = "";
                this.conBusCli.txtCodCli.Text = "";
                this.conBusCli.txtNombre.Text = "";
                this.conBusCli.txtNroDoc.Text = "";
                this.conBusCli.txtDireccion.Text = "";

                CleanData();
                return;
            }

            Int32 nidCliente = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
            this.BuscaPersonal(nidCliente);
        }        

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1 && cboAgencia1.Text.Trim() != "")
            {
                this.cboArea1.CargarArea(Convert.ToInt32(cboAgencia1.SelectedValue));
                this.cboArea1.SelectedIndex = -1;
                this.cboEstablecimiento1.CargarEstablecimiento(Convert.ToInt32(cboAgencia1.SelectedValue));
                this.cboEstablecimiento1.SelectedIndex = -1;
                permiso2 = 1;
            }
        }        

        private void btnBuscarCta_Click(object sender, EventArgs e)
        {
            frmListaPerslCtasSalario frmListaCtas = new frmListaPerslCtasSalario();
            frmListaCtas.idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text.Trim());
            frmListaCtas.ShowDialog();
            if (frmListaCtas.idCuenta != 0)
            {
                this.txtCodIns.Text = frmListaCtas.cNroCuenta.Substring(0, 3);
                this.txtCodAge.Text = frmListaCtas.cNroCuenta.Substring(3, 3);
                this.txtCodMod.Text = frmListaCtas.cNroCuenta.Substring(6, 3);
                this.txtCodMon.Text = frmListaCtas.cNroCuenta.Substring(9, 1);
                this.txtCodCta.Text = frmListaCtas.cNroCuenta.Substring(10, 12);

            }
            if (frmListaCtas.idCuenta == 0)
            {
                this.txtCodIns.Clear();
                this.txtCodAge.Clear();
                this.txtCodMod.Clear();
                this.txtCodMon.Clear();
                this.txtCodCta.Clear();

            }
        }

        private void btnBuscarCtaCTS_Click(object sender, EventArgs e)
        {
            frmListaPersCtasCTS frmListaCtas = new frmListaPersCtasCTS();
            frmListaCtas.idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text.Trim());
            frmListaCtas.ShowDialog();
            if (frmListaCtas.idCuenta != 0)
            {
                this.txtCodInsCTS.Text = frmListaCtas.cNroCuenta.Substring(0, 3);
                this.txtCodAgeCTS.Text = frmListaCtas.cNroCuenta.Substring(3, 3);
                this.txtCodModCTS.Text = frmListaCtas.cNroCuenta.Substring(6, 3);
                this.txtCodMonCTS.Text = frmListaCtas.cNroCuenta.Substring(9, 1);
                this.txtCodCtaCTS.Text = frmListaCtas.cNroCuenta.Substring(10, 12);

            }
            if (frmListaCtas.idCuenta == 0)
            {
                this.txtCodInsCTS.Clear();
                this.txtCodAgeCTS.Clear();
                this.txtCodModCTS.Clear();
                this.txtCodMonCTS.Clear();
                this.txtCodCtaCTS.Clear();

            }
        }

        private void cboTipoRegimenPens1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1 && cboTipoRegimenPens1.Text.Trim().ToString() != "")
            {
                cboRegimenPens.CargarRegimenPens(Convert.ToInt32(cboTipoRegimenPens1.SelectedValue));
                if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 2)
                {
                    cboEsqComAFP1.Enabled = true;
                }
                else
                {
                    cboEsqComAFP1.Enabled = false;
                    cboEsqComAFP1.SelectedIndex = -1;
                }
            }
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso2 == 1 && cboArea1.Text.Trim().ToString() != "")
            {
                cboCargoPersonal.CargarCargo(Convert.ToInt32(cboArea1.SelectedValue));
                cboCargoPersonal.SelectedIndex = -1;
            }
        }

        private void cboTipoEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoEntidad1.SelectedValue) > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad1.SelectedValue);
                cboEntidad1.CargarEntidades(nTipEnt);
            }
        }

        private void cboTipoEntidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoEntidad2.SelectedValue) > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad2.SelectedValue);
                cboEntidad2.CargarEntidades(nTipEnt);
            }
        }

        private void CBDepPropioSalario_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDepPropioSalario.Checked == true) 
            {
                
                this.btnBuscarCta.Enabled = true;

                this.cboTipoEntidad1.Enabled = false;
                this.cboEntidad1.Enabled = false;
                this.txtCtaAhorroExterno.Enabled = false;
                this.cboTipoEntidad1.SelectedValue = -1;
                this.cboEntidad1.SelectedValue = -1;
                this.txtCtaAhorroExterno.Clear();
            }
            if (CBDepPropioSalario.Checked == false)
            {               
                this.btnBuscarCta.Enabled = false;

                this.txtCodIns.Clear();
                this.txtCodAge.Clear();
                this.txtCodMod.Clear();
                this.txtCodMon.Clear();
                this.txtCodCta.Clear();
               
                this.cboTipoEntidad1.Enabled = true;
                this.cboEntidad1.Enabled = true;
                this.txtCtaAhorroExterno.Enabled = true;
            }
        }

        private void CBDepPropioCTS_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDepPropioCTS.Checked == true)
            {               
                this.btnBuscarCtaCTS.Enabled = true;

                this.cboTipoEntidad2.Enabled = false;
                this.cboEntidad2.Enabled = false;
                this.txtCtaCTSExterno.Enabled = false;
                this.cboTipoEntidad2.SelectedValue = -1;
                this.cboEntidad2.SelectedValue = -1;
                this.txtCtaCTSExterno.Clear();
            }
            if (CBDepPropioCTS.Checked == false)
            {               
                this.btnBuscarCtaCTS.Enabled = false;

                this.txtCodInsCTS.Clear();
                this.txtCodAgeCTS.Clear();
                this.txtCodModCTS.Clear();
                this.txtCodMonCTS.Clear();
                this.txtCodCtaCTS.Clear();

                this.cboTipoEntidad2.Enabled = true;
                this.cboEntidad2.Enabled = true;
                this.txtCtaCTSExterno.Enabled = true;
            }
        }

        private void dtgHistorial_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosHistorial();
        }

        private void btnMiniNuevo_Click(object sender, EventArgs e)
        {
            int cont = 0;
            foreach (DataGridViewRow fila in dtgHistorial.Rows)
            {
                if (Convert.ToInt32(fila.Cells["lActivo"].Value) == 1)
                    cont = cont + 1;
            }

            if (cont >= 1)
            {
                MessageBox.Show("No se puede generar un nuevo Historial, ya que existe uno en Estado: ACTIVO, primero debe cambiarlo a estado: CESADO y después agregar uno nuevo.", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TipOpeHistorial = "N";
            CleanHistorial();
            HabilitarCtrlHistorial(true);
            this.dtpCesePersonal.Enabled = false;
            this.txtMotCese.Enabled = false;
            this.cboMotivoCesePer.Enabled = false;
            this.CBLiquidacion.Enabled = false;

            this.btnMiniNuevo.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniOK.Enabled = true;
            this.btnMiniEliminar.Enabled = false;
        }        

        private void btnMiniEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dtgHistorial.Rows.Count) >= 1)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgHistorial.CurrentRow.Index);

                //SOLO SE PUEDEN EDITAR LOS REGISTROS EN ESTADO "NUEVO" O LA ULTIMA RELACIÓN LABORAL REGISTRADO ANTERIORMENTE

                if (pcTipoOpe == "A")
                {
                    if (Convert.ToString(dtgHistorial.Rows[filaseleccionada].Cells["Est"].Value) == "N" || Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idRelacionLab"].Value) == Convert.ToInt32(dtbBuscaPersonal.Rows[0]["idRelacionLab"]))
                    {
                        TipOpeHistorial = "A";
                        HabilitarCtrlHistorial(true);
                        this.btnMiniNuevo.Enabled = false;
                        this.btnMiniEditar.Enabled = false;
                        this.btnMiniOK.Enabled = true;
                        this.btnMiniEliminar.Enabled = false;
                        if (txtMotCese.Text.Trim() == "")
                        {
                            this.dtpCesePersonal.Enabled = false;
                            this.cboMotivoCesePer.Enabled = false;
                            this.txtMotCese.Enabled = false;
                            this.CBLiquidacion.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sólo se puede editar la Última Relación Laboral guardada o las recientemente agregadas.", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else//CUANDO SE REGISTRARÁ A UN NUEVO PERSONAL POR PRIMERA VEZ
                {
                    TipOpeHistorial = "A";
                    HabilitarCtrlHistorial(true);
                    this.btnMiniNuevo.Enabled = false;
                    this.btnMiniEditar.Enabled = false;
                    this.btnMiniOK.Enabled = true;
                    this.btnMiniEliminar.Enabled = false;
                }
            }
        }

        private void btnMiniOK_Click(object sender, EventArgs e)
        {
            clsCNGuardaPersonal GuardaHistorial = new clsCNGuardaPersonal();
            if (cboEstPersonal.Text.Trim()=="")
            {
                MessageBox.Show("Debe seleccionar el Estado", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstPersonal.Focus();
                return;
            }
            if (cboTipoRelacionLaboral.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Relación Laboral con la Institución", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoRelacionLaboral.Focus();
                return;
            }
            
            if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 2)
            {
                    if (chcDatosCese.Checked == false) {
                        MessageBox.Show("Indique los Datos del Cese", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chcDatosCese.Focus();
                        return; 
                    }

                    if (dtpCesePersonal.Value.Date > clsVarGlobal.dFecSystem.Date)
                    {
                        MessageBox.Show("Si el Personal se encuentra en estado: CESADO, la fecha de Cese no puede ser posterior a la de Hoy", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEstPersonal.Focus();
                        return;
                    }
            }
            if (cboSeguroSalud.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Seguro Médico con el que cuenta", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSeguroSalud.Focus();
                return;
            }
            if (chcDatosCese.Checked == true)
            {
                if (dtpCesePersonal.Value < dtpInicioPersonal.Value)
                {
                    MessageBox.Show("La Fecha de Cese no puede ser mayor a la Fecha de Inicio de Trabajo", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpCesePersonal.Focus();
                    return;
                }
                if (dtpCesePersonal.Value.Date == dtpInicioPersonal.Value.Date)
                {
                    MessageBox.Show("La Fecha de Inicio y la Fecha de Cese no pueden ser iguales", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpCesePersonal.Focus();
                    return;
                }
                if ((dtpCesePersonal.Value.Date <= clsVarGlobal.dFecSystem.Date) && Convert.ToInt32(cboEstPersonal.SelectedValue) == 1)
                {
                    MessageBox.Show("Si el Personal se encuentra en estado: ACTIVO, la fecha de Cese no puede ser anterior o igual a la de Hoy", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEstPersonal.Focus();
                    return;
                }
                if (cboMotivoCesePer.Text.Trim() == "")
                {
                    MessageBox.Show("Indique el motivo de Cese", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMotivoCesePer.Focus();
                    return;
                }

                if (txtMotCese.Text.Trim() == "")
                {
                    MessageBox.Show("Detalle el motivo de Cese", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMotCese.Focus();
                    return;
                } 
            }
                        
            dtHistorial.Columns["idEstado"].ReadOnly = false;
            dtHistorial.Columns["idTipoRelLab"].ReadOnly = false;
            dtHistorial.Columns["lLiquidacion"].ReadOnly = false;
            dtHistorial.Columns["idSeguroMedico"].ReadOnly = false;
            dtHistorial.Columns["idMotivoCese"].ReadOnly = false;
            dtHistorial.Columns["Est"].ReadOnly = false;

            //VALIDAR QUE NO HAYA INTERVALOS DE TIEMPO REPETIDOS
            if (TipOpeHistorial == "N")
            {
                if (dtgHistorial.Rows.Count > 0)
                {
                    int NroFila = 0;
                    for (int i = 0; i < dtgHistorial.Rows.Count; i++)
                    {
                        DateTime FecIngAnterior = Convert.ToDateTime(dtgHistorial.Rows[NroFila].Cells["dFechaIngreso"].Value).Date;
                        DateTime FecFinalAnterior = Convert.ToDateTime(dtgHistorial.Rows[NroFila].Cells["dFechaCese"].Value).Date;
                        DateTime FecIngreso = Convert.ToDateTime(dtpInicioPersonal.Value).Date;
                        DateTime FecFinal = Convert.ToDateTime("01/01/2500");
                        if (chcDatosCese.Checked == true)
                            FecFinal = Convert.ToDateTime(dtpCesePersonal.Value).Date;

                        if (FecIngAnterior == FecIngreso && FecFinalAnterior == FecFinal)
                        {
                            MessageBox.Show("Ya existe un registro con el mismo periodo de Trabajo.Verifique ", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if ((FecIngreso <= FecIngAnterior && FecFinal >= FecIngAnterior) || (FecIngreso <= FecFinalAnterior && FecFinal >= FecFinalAnterior) || (FecIngAnterior < FecIngreso && FecFinalAnterior > FecFinal))
                        {
                            MessageBox.Show("El periodo de trabajo indicado o parte de el está incluido en la Relación Laboral con periodo: " + FecIngAnterior.ToShortDateString() + "- " + FecFinalAnterior.ToShortDateString(), "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        NroFila = NroFila + 1;
                    }
                }

                ContNuevos = ContNuevos + 1;
                DataRow dr = dtHistorial.NewRow();

                dr["idRelacionLab"] = ContNuevos;
                dr["dFechaIngreso"] = Convert.ToDateTime(dtpInicioPersonal.Value);
                if (chcDatosCese.Checked == false)//----------------- si esta en estado :ACTIVO
                {
                    dr["dFechaCese"] = Convert.ToDateTime("01/01/1900");
                    dr["idMotivoCese"] = 0;
                }
                else//----------------------------------------------- si esta en estado :PASIVO
                {
                    dr["dFechaCese"] = Convert.ToDateTime(dtpCesePersonal.Value);
                    dr["idMotivoCese"] = Convert.ToInt32(cboMotivoCesePer.SelectedValue);
                }
                dr["idTipoRelLab"] = Convert.ToInt32(cboTipoRelacionLaboral.SelectedValue);  
                dr["cRelLaboral"] = Convert.ToString(cboTipoRelacionLaboral.Text);
                dr["idEstado"] = Convert.ToInt32(cboEstPersonal.SelectedValue);
                dr["cMotCese"] = Convert.ToString(txtMotCese.Text.Trim());
                dr["lLiquidacion"] = Convert.ToBoolean(CBLiquidacion.Checked);
                dr["idSeguroMedico"] = Convert.ToInt32(cboSeguroSalud.SelectedValue);
               
                              
                dr["Est"] = "N";                
                if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 1)
                    dr["lActivo"] = 1;
                if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 2)
                    dr["lActivo"] = 0;
                

                dtHistorial.Rows.Add(dr);
                dtgHistorial.DataSource = dtHistorial.DefaultView;

                int n = 0;
                foreach (DataGridViewRow fila in dtgHistorial.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idRelacionLab"].Value) == ContNuevos)
                    {
                        dtgHistorial.CurrentCell = dtgHistorial.Rows[n - 1].Cells["dFechaIngreso"];
                        MostrarDatosHistorial();
                    }
                }
            }
            if (TipOpeHistorial == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgHistorial.CurrentRow.Index);

                if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 1)
                {
                    int cont = 0;
                    for (int i=0;i< dtgHistorial.Rows.Count; i++)
                        if (i != filaseleccionada && Convert.ToInt32(dtgHistorial.Rows[i].Cells["lActivo"].Value) == 1)                        
                                cont = cont + 1;
                    if (cont >= 1)
                    {
                        MessageBox.Show("Ya existe una Relación Laboral en estado: ACTIVO", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                //VALIDAR QUE NO HAYA INTERVALOS DE TIEMPO REPETIDOS
                int NroFila = 0;
                for (int i = 0; i < dtgHistorial.Rows.Count; i++)
                {
                    if (NroFila != filaseleccionada)
                    {
                        DateTime FecIngAnterior = Convert.ToDateTime(dtgHistorial.Rows[NroFila].Cells["dFechaIngreso"].Value).Date;
                        DateTime FecFinalAnterior = Convert.ToDateTime(dtgHistorial.Rows[NroFila].Cells["dFechaCese"].Value).Date;
                        DateTime FecIngreso = Convert.ToDateTime(dtpInicioPersonal.Value).Date;
                        DateTime FecFinal = Convert.ToDateTime("01/01/2500");
                        if (chcDatosCese.Checked == true)
                            FecFinal = Convert.ToDateTime(dtpCesePersonal.Value).Date;
                        if (FecIngAnterior == FecIngreso && FecFinalAnterior == FecFinal)
                        {
                            MessageBox.Show("Ya existe un registro con el mismo periodo de Trabajo.Verifique ","Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if ((FecIngreso <= FecIngAnterior && FecFinal >= FecIngAnterior) || (FecIngreso <= FecFinalAnterior && FecFinal >= FecFinalAnterior) || (FecIngAnterior < FecIngreso && FecFinalAnterior > FecFinal))
                        {
                            MessageBox.Show("El periodo de trabajo indicado o parte de el está incluido en la Relación Laboral con periodo: " + FecIngAnterior.ToShortDateString() + "- " + FecFinalAnterior.ToShortDateString(), "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    NroFila = NroFila + 1;
                }
                
                int idRelacionLaboral = Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idRelacionLab"].Value);

                dtHistorial.Rows[filaseleccionada]["dFechaIngreso"] = Convert.ToDateTime(dtpInicioPersonal.Value);
                if (chcDatosCese.Checked == false)
                {
                    dtHistorial.Rows[filaseleccionada]["dFechaCese"] = Convert.ToDateTime("01/01/1900");
                    dtHistorial.Rows[filaseleccionada]["idMotivoCese"] = 0;
                }
                else
                {
                    dtHistorial.Rows[filaseleccionada]["dFechaCese"] = Convert.ToDateTime(dtpCesePersonal.Value);
                    dtHistorial.Rows[filaseleccionada]["idMotivoCese"] = Convert.ToInt32(cboMotivoCesePer.SelectedValue);
                }
                dtHistorial.Rows[filaseleccionada]["idTipoRelLab"] = Convert.ToInt32(cboTipoRelacionLaboral.SelectedValue);
                dtHistorial.Rows[filaseleccionada]["cRelLaboral"] = Convert.ToString(cboTipoRelacionLaboral.Text);
                dtHistorial.Rows[filaseleccionada]["idEstado"] = Convert.ToInt32(cboEstPersonal.SelectedValue);
                dtHistorial.Rows[filaseleccionada]["cMotCese"] = Convert.ToString(txtMotCese.Text.Trim());
                dtHistorial.Rows[filaseleccionada]["lLiquidacion"] = Convert.ToBoolean(CBLiquidacion.Checked);
                dtHistorial.Rows[filaseleccionada]["idSeguroMedico"] = Convert.ToInt32(cboSeguroSalud.SelectedValue);
                
                if (Convert.ToString(dtHistorial.Rows[filaseleccionada]["Est"]) != "N")
                    dtHistorial.Rows[filaseleccionada]["Est"] = "A";
                
                if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 1)
                    dtHistorial.Rows[filaseleccionada]["lActivo"] = 1;
                if (Convert.ToInt32(cboEstPersonal.SelectedValue) == 2)
                    dtHistorial.Rows[filaseleccionada]["lActivo"] = 0;
                              
                
                //CARGAR NUEVAMENTE Y VOLVER A SELECCIONAR LA FILA ANTEIORMENTE SELECCIONADA
                dtgHistorial.DataSource = dtHistorial.DefaultView;                
                int n = 0;
                foreach (DataGridViewRow fila in dtgHistorial.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idRelacionLab"].Value) == idRelacionLaboral)
                    {
                        dtgHistorial.CurrentCell = dtgHistorial.Rows[n - 1].Cells["dFechaIngreso"];
                        MostrarDatosHistorial();
                    }
                }
            }

            HabilitarCtrlHistorial(false);
            this.btnMiniNuevo.Enabled = true;
            this.btnMiniEditar.Enabled = true;
            this.btnMiniOK.Enabled = false;
            this.btnMiniEliminar.Enabled = true;
            TipOpeHistorial = "N";

        }

        private void btnMiniEliminar_Click(object sender, EventArgs e)
        {
            if (dtgHistorial.SelectedRows.Count > 0)             
            {
                int filaseleccionada = Convert.ToInt32(this.dtgHistorial.CurrentRow.Index);

                if (Convert.ToString(dtgHistorial.Rows[filaseleccionada].Cells["Est"].Value) != "N")
                {
                    MessageBox.Show("Los registros de Relaciones Laborales anteriores no se pueden Eliminar, sólo se puede eliminar los agregados recientemente", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                dtHistorial.Rows.RemoveAt(filaseleccionada);
                if (dtgHistorial.Rows.Count > 0)
                    dtgHistorial.CurrentCell = dtgHistorial.Rows[0].Cells["dFechaIngreso"];
                              
            }
        }

        private void cboTipoRelacionLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1 && cboTipoRelacionLaboral.Text.Trim()!="")
            {
                if (Convert.ToInt32(cboTipoRelacionLaboral.SelectedValue) == 2)
                {
                    cboSeguroSalud.SelectedValue = 1;
                    cboSeguroSalud.Enabled = false;
                }
                else {
                    cboSeguroSalud.SelectedValue = 0;
                    cboSeguroSalud.Enabled = true;
                }
            }
        }              

        private void chcDatosCese_CheckedChanged(object sender, EventArgs e)
        {
            if (chcDatosCese.Checked == true) {
                dtpCesePersonal.Enabled = true;
                CBLiquidacion.Enabled = true;
                cboMotivoCesePer.Enabled = true;
                txtMotCese.Enabled = true;            
            }
            if (chcDatosCese.Checked == false)
            {
                dtpCesePersonal.Value = clsVarGlobal.dFecSystem;
                CBLiquidacion.Checked = false;
                cboMotivoCesePer.SelectedIndex = -1;
                txtMotCese.Text = "";

                dtpCesePersonal.Enabled = false;
                CBLiquidacion.Enabled = false;
                cboMotivoCesePer.Enabled = false;
                txtMotCese.Enabled = false;
            }
        }
        
        private void dtgFamiliares_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosFAM();
        }       

        private void btnNuevoFAM_Click(object sender, EventArgs e)
        {            
            TipOpeFamiliares = "N";
            CleanFamiliares();
            HabilitarCtrlFamiliares(true);

            this.cboProcedPais.Enabled = false;
            this.cboMeses1.Enabled = false;
            this.txtAnio.Enabled = false;

            this.conBusUbiCli.cboPais.SelectedValue = 173;
            this.conBusUbig2.cboPais.SelectedValue = 173;

            this.dtBAJA.Enabled = false;
            this.cboMotivoBAJA.Enabled = false;

            this.btnNuevoFAM.Enabled = false;
            this.btnEditarFAM.Enabled = false;
            this.btnOKFAM.Enabled = true;
            this.btnEliminarFAM.Enabled = false;
        }

        private void btnEditarFAM_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dtgFamiliares.Rows.Count) >= 1)
            { 
                    TipOpeFamiliares = "A";
                    HabilitarCtrlFamiliares(true);

                    if (Convert.ToInt32(cboTipVinculo.SelectedValue) != 3)
                    {
                        this.cboMeses1.Enabled = false;
                        this.txtAnio.Enabled = false;
                    }
                    if (Convert.ToInt32(cboTipDocumento1.SelectedValue) == 1)
                    {
                        this.cboProcedPais.Enabled = false;
                    }
                    if (CBDadoBaja.Checked == false) {
                        this.dtBAJA.Enabled = false;
                        this.cboMotivoBAJA.Enabled = false;
                    }
                                        
                    this.btnNuevoFAM.Enabled = false;
                    this.btnEditarFAM.Enabled = false;
                    this.btnOKFAM.Enabled = true;
                    this.btnEliminarFAM.Enabled = false;                 
            }
        }

        private void btnGrabarFAM_Click(object sender, EventArgs e)
        {
            clsCNGuardaPersonal GuardaFamiliares = new clsCNGuardaPersonal();
            if (cboTipVinculo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Vínculo", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipVinculo.Focus();
                return;
            }
            if (cboTipDocumento1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de documento del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipDocumento1.Focus();
                return;
            }
            if (Convert.ToInt32(cboTipDocumento1.SelectedValue) != 1 && cboProcedPais.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el país de procedencia del Documento de Identidad del familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProcedPais.Focus();
                return;
            }
            if (txtNroDocumentos1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de Documento del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocumentos1.Focus();
                return;
            }
            if (txtApePat.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Apellido Paterno del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApePat.Focus();
                return;
            }
            if (txtNom1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNom1.Focus();
                return;
            }
            if (dFecNacimiento.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de Nacimiento no puede ser mayor a la Fecha de Hoy", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dFecNacimiento.Focus();
                return;
            }
            if (cboSexo1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el sexo del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSexo1.Focus();
                return;
            }
            if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 3 && cboMeses1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el mes de Concepción del bebe", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMeses1.Focus();
                return;
            }
            if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 3 && txtAnio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el año de Concepción del bebe", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnio.Focus();
                return;
            }
            if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 3 && Convert.ToInt32(txtAnio.Text.Trim()) > clsVarGlobal.dFecSystem.Year)
            {
                MessageBox.Show("El año de Concepción del bebe no puede ser posterior al año actual", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnio.Focus();
                return;
            }
            if (txtTelefCel1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Número Telefónico actual del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefCel1.Focus();
                return;
            }
            if (txtEmail1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Correo Electrónico del Familiar", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail1.Focus();
                return;
            }
            if (cboTipDocVinculo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de documento que acredite el Vínculo", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipDocVinculo.Focus();
                return;
            }
            if (txtNroDocVinculo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Numero de documento  que acredite el Vínculo", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocVinculo.Focus();
                return;
            }
            //----------------------------------------------------------------------------------
            //INFORMACIÓN DE ALTAS Y BAJAS
            //-----------------------------------------------------------------------------------
            if (dtALTA.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de ALTA no puede ser mayor a la fecha de Hoy", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtALTA.Focus();
                return;
            }
            if (CBDadoBaja.Checked == true && dtBAJA.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de BAJA no puede ser mayor a la fecha de Hoy", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtBAJA.Focus();
                return;
            }
            if (CBDadoBaja.Checked == true && cboMotivoBAJA.Text.Trim()=="")
            {
                MessageBox.Show("Seleccione el Motivo de la Baja", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoBAJA.Focus();
                return;
            }
            //-----------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------

            if (conBusUbiCli.cboDistrito.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el distrito de la Dirección(1) ", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                conBusUbiCli.cboDistrito.Focus();
                return;
            }
            if (cboTipoZona.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Zona de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                cboTipoZona.Focus();
                return;
            }
            if (cboTipoVia.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Vía de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                cboTipoVia.Focus();
                return;
            }
            if (textZonas.Text.Trim() == "" && textVia.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese el nombre de la Zona o de la Vía de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                textZonas.Focus();
                return;
            }
            if (textNro.Text.Trim() == "" && textDpto.Text.Trim() == "" && textInt.Text.Trim() == "" && textMz.Text.Trim() == "" && textLote.Text.Trim() == "" && textKm.Text.Trim() == "" && textBlock.Text.Trim() == "" && textEtapa.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar al menos uno de los siguientes datos: Nro, Dpto, Int, Mz, Lote, Km, Block o Etapa de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                textNro.Focus();
                return;
            }
            if (textReferencia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese una referencia de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 0;
                textReferencia.Focus();
                return;
            }

            if (conBusUbig2.cboDistrito.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el distrito de la Dirección(2) ", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                conBusUbig2.cboDistrito.Focus();
                return;
            }
            if (cboTipoZona2.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Zona de la Dirección(2)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                cboTipoZona2.Focus();
                return;
            }
            if (cboTipoVia2.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Vía de la Dirección(2)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                cboTipoVia2.Focus();
                return;
            }
            if (textZonas2.Text.Trim() == "" && textVia2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre de la Zona o de la Vía de la Dirección(2)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                textZonas2.Focus();
                return;
            }
            if (textNro2.Text.Trim() == "" && textDpto2.Text.Trim() == "" && textInt2.Text.Trim() == "" && textMz2.Text.Trim() == "" && textLote2.Text.Trim() == "" && textKm2.Text.Trim() == "" && textBlock2.Text.Trim() == "" && textEtapa2.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar al menos uno de los siguientes datos: Nro, Dpto, Int, Mz, Lote, Km, Block o Etapa de la Dirección(2)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                textNro2.Focus();
                return;
            }
            if (textReferencia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese una referencia de la Dirección(2)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase2.SelectedIndex = 1;
                textReferencia.Focus();
                return;
            }


            dtFamiliares.Columns["Est"].ReadOnly = false;
            dtFamiliares.Columns["dFechaAlta"].ReadOnly = false;
            dtFamiliares.Columns["lDadoBaja"].ReadOnly = false;
            dtFamiliares.Columns["dFechaBaja"].ReadOnly = false;
            dtFamiliares.Columns["idMotivoBaja"].ReadOnly = false;

            if (TipOpeFamiliares == "N")
            {
                ContNuevosFAM = ContNuevosFAM + 1;

                DataRow dr = dtFamiliares.NewRow();

                dr["idFamiliares"] = ContNuevosFAM;
                dr["idVinculoFamiliar"] = Convert.ToInt32(cboTipVinculo.SelectedValue);
                dr["cVinculoFam"] = Convert.ToString(cboTipVinculo.Text.Trim());
                dr["idTipoDoc"] = Convert.ToInt32(cboTipDocumento1.SelectedValue);
                dr["idPaisEmisorDoc"] = Convert.ToInt32(cboProcedPais.SelectedValue);
                dr["cNroDoc"] = Convert.ToString(txtNroDocumentos1.Text.Trim());
                dr["cApellidoPat"] = Convert.ToString(txtApePat.Text.Trim());
                dr["cApellidoMat"] = Convert.ToString(txtApeMat.Text.Trim());
                dr["cNombres"] = Convert.ToString(txtNom1.Text.Trim());
                dr["dFechaNac"] = Convert.ToDateTime(dFecNacimiento.Value);
                dr["idSexo"] = Convert.ToInt32(cboSexo1.SelectedValue);

                dr["idMesConcepcion"] = 0;
                dr["cAnioConcepcion"] = "";
                if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 3)
                {
                    dr["idMesConcepcion"] = Convert.ToInt32(cboMeses1.SelectedValue);
                    dr["cAnioConcepcion"] = Convert.ToString(txtAnio.Text);
                }

                dr["idTipoDocAcredite"] = Convert.ToInt32(cboTipDocVinculo.SelectedValue);
                dr["cNroDocAcredite"] = Convert.ToString(txtNroDocVinculo.Text.Trim());

                dr["idUbigeo"] = Convert.ToInt32(conBusUbiCli.cboDistrito.SelectedValue);
                dr["idTipoZona"] = Convert.ToInt32(cboTipoZona.SelectedValue);
                dr["cNombreZona"] = Convert.ToString(textZonas.Text.Trim());
                dr["idTipoVia"] = Convert.ToInt32(cboTipoVia.SelectedValue);
                dr["cNombreVia"] = Convert.ToString(textVia.Text.Trim());
                dr["cNumero"] = Convert.ToString(textNro.Text.Trim());
                dr["cDepartamente"] = Convert.ToString(textDpto.Text.Trim());
                dr["cInterior"] = Convert.ToString(textInt.Text.Trim());
                dr["cManzana"] = Convert.ToString(textMz.Text.Trim());
                dr["cLote"] = Convert.ToString(textLote.Text.Trim());
                dr["cKilometro"] = Convert.ToString(textKm.Text.Trim());
                dr["cBlock"] = Convert.ToString(textBlock.Text.Trim());
                dr["cEtapa"] = Convert.ToString(textEtapa.Text.Trim());
                dr["cReferencia"] = Convert.ToString(textReferencia.Text.Trim());

                dr["idUbigeo2"] = Convert.ToInt32(conBusUbig2.cboDistrito.SelectedValue);
                dr["idTipoZona2"] = Convert.ToInt32(cboTipoZona2.SelectedValue);
                dr["cNombreZona2"] = Convert.ToString(textZonas2.Text.Trim());
                dr["idTipoVia2"] = Convert.ToInt32(cboTipoVia2.SelectedValue);
                dr["cNombreVia2"] = Convert.ToString(textVia2.Text.Trim());
                dr["cNumero2"] = Convert.ToString(textNro2.Text.Trim());
                dr["cDepartamente2"] = Convert.ToString(textDpto2.Text.Trim());
                dr["cInterior2"] = Convert.ToString(textInt2.Text.Trim());
                dr["cManzana2"] = Convert.ToString(textMz2.Text.Trim());
                dr["cLote2"] = Convert.ToString(textLote2.Text.Trim());
                dr["cKilometro2"] = Convert.ToString(textKm2.Text.Trim());
                dr["cBlock2"] = Convert.ToString(textBlock2.Text.Trim());
                dr["cEtapa2"] = Convert.ToString(textEtapa2.Text.Trim());
                dr["cReferencia2"] = Convert.ToString(textReferencia2.Text.Trim());

                dr["cTelefono"] = Convert.ToString(txtTelefCel1.Text.Trim());
                dr["cEmail"] = Convert.ToString(txtEmail1.Text.Trim());
                dr["dFechaAlta"] = Convert.ToDateTime(dtALTA.Value);
                dr["lDadoBaja"] = Convert.ToBoolean(CBDadoBaja.Checked);
                dr["dFechaBaja"] = Convert.ToDateTime(dtBAJA.Value);
                dr["idMotivoBaja"] = Convert.ToInt32(cboMotivoBAJA.SelectedValue);

                dr["lVigente"] = 1;                
                dr["Est"] = "N";

                dtFamiliares.Rows.Add(dr);
                dtgFamiliares.DataSource = dtFamiliares.DefaultView;

                int n = 0;
                foreach (DataGridViewRow fila in dtgFamiliares.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idFamiliares"].Value) == ContNuevosFAM)
                    {
                        dtgFamiliares.CurrentCell = dtgFamiliares.Rows[n - 1].Cells["cVinculoFam"];
                        MostrarDatosFAM();
                    }
                }
            }
            if (TipOpeFamiliares == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgFamiliares.CurrentRow.Index);

                int idFamiliar = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idFamiliares"].Value);

                dtFamiliares.Rows[filaseleccionada]["idVinculoFamiliar"] = Convert.ToInt32(cboTipVinculo.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cVinculoFam"] = Convert.ToString(cboTipVinculo.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["idTipoDoc"] = Convert.ToInt32(cboTipDocumento1.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["idPaisEmisorDoc"] = Convert.ToString(cboProcedPais.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNroDoc"] = Convert.ToString(txtNroDocumentos1.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cApellidoPat"] = Convert.ToString(txtApePat.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cApellidoMat"] = Convert.ToString(txtApeMat.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cNombres"] = Convert.ToString(txtNom1.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["dFechaNac"] = Convert.ToDateTime(dFecNacimiento.Value);
                dtFamiliares.Rows[filaseleccionada]["idSexo"] = Convert.ToInt32(cboSexo1.SelectedValue);                
                dtFamiliares.Rows[filaseleccionada]["idMesConcepcion"] = Convert.ToInt32(cboMeses1.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cAnioConcepcion"] = Convert.ToString(txtAnio.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["idTipoDocAcredite"] = Convert.ToInt32(cboTipDocVinculo.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNroDocAcredite"] = Convert.ToString(txtNroDocVinculo.Text.Trim());
                
                dtFamiliares.Rows[filaseleccionada]["idUbigeo"] = Convert.ToInt32(conBusUbiCli.cboDistrito.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["idTipoZona"] = Convert.ToInt32(cboTipoZona.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNombreZona"] = Convert.ToString(textZonas.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["idTipoVia"] = Convert.ToInt32(cboTipoVia.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNombreVia"] = Convert.ToString(textVia.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cNumero"] = Convert.ToString(textNro.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cDepartamente"] = Convert.ToString(textDpto.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cInterior"] = Convert.ToString(textInt.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cManzana"] = Convert.ToString(textMz.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cLote"] = Convert.ToString(textLote.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cKilometro"] = Convert.ToString(textKm.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cBlock"] = Convert.ToString(textBlock.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cEtapa"] = Convert.ToString(textEtapa.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cReferencia"] = Convert.ToString(textReferencia.Text.Trim());

                dtFamiliares.Rows[filaseleccionada]["idUbigeo2"] = Convert.ToInt32(conBusUbig2.cboDistrito.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["idTipoZona2"] = Convert.ToInt32(cboTipoZona2.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNombreZona2"] = Convert.ToString(textZonas2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["idTipoVia2"] = Convert.ToInt32(cboTipoVia2.SelectedValue);
                dtFamiliares.Rows[filaseleccionada]["cNombreVia2"] = Convert.ToString(textVia2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cNumero2"] = Convert.ToString(textNro2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cDepartamente2"] = Convert.ToString(textDpto2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cInterior2"] = Convert.ToString(textInt2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cManzana2"] = Convert.ToString(textMz2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cLote2"] = Convert.ToString(textLote2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cKilometro2"] = Convert.ToString(textKm2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cBlock2"] = Convert.ToString(textBlock2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cEtapa2"] = Convert.ToString(textEtapa2.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cReferencia2"] = Convert.ToString(textReferencia2.Text.Trim());

                dtFamiliares.Rows[filaseleccionada]["cTelefono"] = Convert.ToString(txtTelefCel1.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["cEmail"] = Convert.ToString(txtEmail1.Text.Trim());
                dtFamiliares.Rows[filaseleccionada]["dFechaAlta"] = Convert.ToDateTime(dtALTA.Value);
                dtFamiliares.Rows[filaseleccionada]["lDadoBaja"] = Convert.ToBoolean(CBDadoBaja.Checked);
                dtFamiliares.Rows[filaseleccionada]["dFechaBaja"] = Convert.ToDateTime(dtBAJA.Value);
                dtFamiliares.Rows[filaseleccionada]["idMotivoBaja"] = Convert.ToInt32(cboMotivoBAJA.SelectedValue);

                if (Convert.ToString(dtFamiliares.Rows[filaseleccionada]["Est"]) != "N")
                    dtFamiliares.Rows[filaseleccionada]["Est"] = "A";

                //CARGAR NUEVAMENTE Y VOLVER A SELECCIONAR LA FILA ANTEIORMENTE SELECCIONADA
                dtgFamiliares.DataSource = dtFamiliares.DefaultView;
                int n = 0;
                foreach (DataGridViewRow fila in dtgFamiliares.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idFamiliares"].Value) == idFamiliar)
                    {
                        dtgFamiliares.CurrentCell = dtgFamiliares.Rows[n - 1].Cells["cVinculoFam"];
                        MostrarDatosFAM();
                    }
                }
            }

            HabilitarCtrlFamiliares(false);
            this.btnNuevoFAM.Enabled = true;
            this.btnEditarFAM.Enabled = true;
            this.btnOKFAM.Enabled = false;
            this.btnEliminarFAM.Enabled = true; 
            TipOpeFamiliares = "N";             
        }

        private void btnEliminarFAM_Click(object sender, EventArgs e)
        {
            if (dtgFamiliares.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgFamiliares.CurrentRow.Index);

                dtFamiliares.Columns["Est"].ReadOnly = false;
                if (Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["Est"].Value) == "N")
                {
                    int i = 0;
                    foreach (DataRow fila in dtFamiliares.Rows)
                    {
                        if (Convert.ToInt32(dtFamiliares.Rows[i]["idFamiliares"]) == Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idFamiliares"].Value))
                        {
                            dtgFamiliares.Rows.RemoveAt(filaseleccionada);
                            if (dtgFamiliares.Rows.Count > 0)
                                dtgFamiliares.CurrentCell = dtgFamiliares.Rows[0].Cells["cVinculoFam"];
                            return;
                        }
                        i = i + 1;
                    }
                   
                }
                else if (Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["Est"].Value) != "N")
                {                   
                    int i = 0;
                    foreach (DataRow fila in dtFamiliares.Rows)
                    {
                        if (Convert.ToInt32(dtFamiliares.Rows[i]["idFamiliares"]) == Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idFamiliares"].Value))
                        {
                            dtFamiliares.Rows[i]["Est"] = "A";        
                            dtFamiliares.Rows[i]["lVigente"] = 0;
                            if (dtgFamiliares.Rows.Count > 0)
                                dtgFamiliares.CurrentCell = dtgFamiliares.Rows[0].Cells["cVinculoFam"];                
                            return;
                        }
                        i = i + 1;
                    }
                    
                }
            }
        }

        private void cboTipDocumento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1) {
                if (Convert.ToInt32(cboTipDocumento1.SelectedValue) == 2 || Convert.ToInt32(cboTipDocumento1.SelectedValue) == 3)
                {
                    this.cboProcedPais.SelectedValue = 0;
                    this.cboProcedPais.Enabled = true;
                }
                else
                {                    
                    this.cboProcedPais.SelectedValue = 173;
                    this.cboProcedPais.Enabled = false;
                }

                this.txtNroDocumentos1.ValidarTipoDoc(Convert.ToString(this.cboTipDocumento1.SelectedValue));
                if (cboTipDocumento1.Text != "")
                    lblDocumento.Text = cboTipDocumento1.Text + ":";
                else
                    lblDocumento.Text = "Nro de Documento:";
            }
        }

        private void cboTipVinculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1)
            {
                if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 3)//Tipo de vinculo = Gestante
                {                    
                    this.cboMeses1.Enabled = true;
                    this.txtAnio.Enabled = true;
                }
                else
                {
                    this.cboMeses1.SelectedValue = 0;
                    this.cboMeses1.Enabled = false;
                    this.txtAnio.Text = "";
                    this.txtAnio.Enabled = false;
                }
                
                CargarDocumAcrediteVinculo(Convert.ToInt32(cboTipVinculo.SelectedValue));

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (conBusUbiCli.cboDistrito.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el distrito de la Dirección(1) ", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;                    
                    conBusUbiCli.cboDistrito.Focus();
                    return;
                }
                if (cboTipoZona.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Tipo de Zona de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;                    
                    cboTipoZona.Focus();
                    return;
                }
                if (cboTipoVia.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Tipo de Vía de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;                    
                    cboTipoVia.Focus();
                    return;
                }
                if (textZonas.Text.Trim() == "" && textVia.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el nombre de la Zona o de la Vía de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;
                    textZonas.Focus();
                    return;
                }
                if (textNro.Text.Trim() == "" && textDpto.Text.Trim() == "" && textInt.Text.Trim() == "" && textMz.Text.Trim() == "" && textLote.Text.Trim() == "" && textKm.Text.Trim() == "" && textBlock.Text.Trim() == "" && textEtapa.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar al menos uno de los siguientes datos: Nro, Dpto, Int, Mz, Lote, Km, Block o Etapa de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;                    
                    textNro.Focus();
                    return;
                }
                if (textReferencia.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese una referencia de la Dirección(1)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.checkBox1.Checked = false;
                    tbcBase2.SelectedIndex = 0;
                    textReferencia.Focus();
                    return;
                }
                this.conBusUbig2.cboPais.SelectedValue = this.conBusUbiCli.cboPais.SelectedValue;
                this.conBusUbig2.cboDepartamento.SelectedValue = this.conBusUbiCli.cboDepartamento.SelectedValue;
                this.conBusUbig2.cboProvincia.SelectedValue = this.conBusUbiCli.cboProvincia.SelectedValue;
                this.conBusUbig2.cboDistrito.SelectedValue = this.conBusUbiCli.cboDistrito.SelectedValue;
                this.cboTipoZona2.SelectedValue = this.cboTipoZona.SelectedValue;
                this.textZonas2.Text = this.textZonas.Text;
                this.cboTipoVia2.SelectedValue = this.cboTipoVia.SelectedValue;
                this.textVia2.Text = this.textVia.Text;
                this.textNro2.Text = this.textNro.Text;
                this.textDpto2.Text = this.textDpto.Text;
                this.textInt2.Text = this.textInt.Text;
                this.textMz2.Text = this.textMz.Text;
                this.textLote2.Text = this.textLote.Text;
                this.textKm2.Text = this.textKm.Text;
                this.textBlock2.Text = this.textBlock.Text;
                this.textEtapa2.Text = this.textEtapa.Text;
                this.textReferencia2.Text = this.textReferencia.Text;
            }
            else {
                this.conBusUbig2.cboPais.SelectedIndex = -1;
                this.conBusUbig2.cboDepartamento.SelectedIndex = -1;
                this.conBusUbig2.cboProvincia.SelectedIndex = -1;
                this.conBusUbig2.cboDistrito.SelectedIndex = -1;
                this.cboTipoZona2.SelectedIndex = -1;
                this.textZonas2.Clear();
                this.cboTipoVia2.SelectedIndex = -1;
                this.textVia2.Clear();
                this.textNro2.Clear();
                this.textDpto2.Clear();
                this.textInt2.Clear();
                this.textMz2.Clear();
                this.textLote2.Clear();
                this.textKm2.Clear();
                this.textBlock2.Clear();
                this.textEtapa2.Clear();
                this.textReferencia2.Clear();

                this.checkBox1.Checked = false;
            
            }
        }

        private void CBDadoBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDadoBaja.Checked == true)
            {
                this.dtBAJA.Enabled = true;
                this.cboMotivoBAJA.Enabled = true;
            }
            if (CBDadoBaja.Checked == false)
            {
                this.dtBAJA.Value = Convert.ToDateTime("01/01/1900");
                this.dtBAJA.Enabled = false;
                this.cboMotivoBAJA.SelectedIndex = -1;
                this.cboMotivoBAJA.Enabled = false;
            }
        }

        private void cboCargoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCargoPersonal.SelectedIndex > -1)
            {
                if (this.cboCargoPersonal.SelectedValue is DataRowView) return;

                cboCategoriaPersonal1.cargarCategoria((int)this.cboCargoPersonal.SelectedValue);
            }
        }

        #endregion

        #region Metodos

        private void CargarDatos()
        {
            DataTable dtContrato = new clsCNBuscaPersonal().ListarTipoContrato();
            cboTipoContratoTiempo.DataSource = dtContrato;
            cboTipoContratoTiempo.ValueMember = dtContrato.Columns[0].ToString();
            cboTipoContratoTiempo.DisplayMember = dtContrato.Columns[1].ToString();    

            DataTable dtSalud = new clsCNBuscaPersonal().ListarSeguroSalud();
            cboSeguroSalud.DataSource = dtSalud;
            cboSeguroSalud.ValueMember = dtSalud.Columns[0].ToString();
            cboSeguroSalud.DisplayMember = dtSalud.Columns[1].ToString();            

            DataTable dt = new clsCNBuscaPersonal().ListarTipoVinculo();
            cboTipVinculo.DataSource = dt;
            cboTipVinculo.ValueMember = dt.Columns[0].ToString();
            cboTipVinculo.DisplayMember = dt.Columns[1].ToString();

            DataTable dtMotivo = new clsCNBuscaPersonal().ListarMotivosBAJAS();
            cboMotivoBAJA.DataSource = dtMotivo;
            cboMotivoBAJA.ValueMember = dtMotivo.Columns[0].ToString();
            cboMotivoBAJA.DisplayMember = dtMotivo.Columns[1].ToString();   

            DataTable dtMotivoCese = new clsCNBuscaPersonal().ListarMotivosCese();
            cboMotivoCesePer.DataSource = dtMotivoCese;
            cboMotivoCesePer.ValueMember = dtMotivoCese.Columns[0].ToString();
            cboMotivoCesePer.DisplayMember = dtMotivoCese.Columns[1].ToString();             
        }

        private void CargarDocumAcrediteVinculo(int idVinculo) 
        {
            DataTable dtDoc = new clsCNBuscaPersonal().ListarDocAcrediteVinc(idVinculo);
            cboTipDocVinculo.DataSource = dtDoc;
            cboTipDocVinculo.ValueMember = dtDoc.Columns[0].ToString();
            cboTipDocVinculo.DisplayMember = dtDoc.Columns[1].ToString(); 
        }

        private void HabilitarControles(bool bVal)
        {
            this.cboCargoPersonal.Enabled = bVal;
            this.cboAgencia1.Enabled = bVal;
            this.cboArea1.Enabled = bVal;
            this.cboEstablecimiento1.Enabled = bVal;
            this.cboTipContratoPersonal1.Enabled = bVal;
            this.txtEmailInst.Enabled = bVal;
            this.txtTelCelPer.Enabled = bVal;
            this.cboTipoRegimenPens1.Enabled = bVal;
            this.cboEsqComAFP1.Enabled = bVal;
            this.cboRegimenPens.Enabled = bVal;
            this.txtRegistroReg.Enabled = bVal;
            this.dFecIniReg.Enabled = bVal;
            this.txtNroAutogenerado.Enabled = bVal;
            this.cboGrupoSanguineo1.Enabled = bVal;
            this.cboTipoContratoTiempo.Enabled = bVal;
            this.CBDiscapacidad.Enabled = bVal;
            this.btnBuscarCta.Enabled = bVal;
            this.btnBuscarCtaCTS.Enabled = bVal;

            this.CBDepPropioSalario.Enabled = bVal;
            this.CBDepPropioCTS.Enabled = bVal;
            this.cboTipoEntidad1.Enabled = bVal;
            this.cboEntidad1.Enabled = bVal;
            this.txtCtaAhorroExterno.Enabled = bVal;
            this.cboTipoEntidad2.Enabled = bVal;            
            this.cboEntidad2.Enabled = bVal;            
            this.txtCtaCTSExterno.Enabled = bVal;

            this.btnMiniNuevo.Enabled = bVal;
            this.btnMiniEditar.Enabled = bVal;
            this.btnMiniOK.Enabled = bVal;
            this.btnMiniEliminar.Enabled = bVal;

            this.btnNuevoFAM.Enabled = bVal;
            this.btnEditarFAM.Enabled = bVal;
            this.btnOKFAM.Enabled = bVal;
            this.btnEliminarFAM.Enabled = bVal;
            this.cboCategoriaPersonal1.Enabled = bVal;

        }

        private void HabilitarCtrlHistorial(Boolean bVal)
        {
            this.cboEstPersonal.Enabled = bVal;
            this.cboTipoRelacionLaboral.Enabled = bVal;
            this.dtpInicioPersonal.Enabled = bVal;
            this.chcDatosCese.Enabled = bVal;
            this.dtpCesePersonal.Enabled = bVal;
            this.txtMotCese.Enabled = bVal;
            this.CBLiquidacion.Enabled = bVal;
            this.cboSeguroSalud.Enabled = bVal;
            this.cboMotivoCesePer.Enabled = bVal;
        }

        private void HabilitarCtrlFamiliares(Boolean bVal)
        {
            this.cboTipVinculo.Enabled = bVal;
            this.cboTipDocumento1.Enabled = bVal;
            this.cboProcedPais.Enabled = bVal;
            this.txtNroDocumentos1.Enabled = bVal;
            this.txtApePat.Enabled = bVal;
            this.txtApeMat.Enabled = bVal;
            this.txtNom1.Enabled = bVal;
            this.dFecNacimiento.Enabled = bVal;
            this.cboSexo1.Enabled = bVal;
            this.cboMeses1.Enabled = bVal;
            this.txtAnio.Enabled = bVal;
            this.cboTipDocVinculo.Enabled = bVal;
            this.txtNroDocVinculo.Enabled = bVal;

            this.txtTelefCel1.Enabled = bVal;
            this.txtEmail1.Enabled = bVal;
            this.dtALTA.Enabled = bVal;
            this.CBDadoBaja.Enabled = bVal;
            this.dtBAJA.Enabled = bVal;
            this.cboMotivoBAJA.Enabled = bVal;
            
            this.conBusUbiCli.Enabled = bVal;
            this.cboTipoZona.Enabled = bVal;
            this.textZonas.Enabled = bVal;
            this.cboTipoVia.Enabled = bVal;
            this.textVia.Enabled = bVal;
            this.textNro.Enabled = bVal;
            this.textDpto.Enabled = bVal;
            this.textInt.Enabled = bVal;
            this.textMz.Enabled = bVal;
            this.textLote.Enabled = bVal;
            this.textKm.Enabled = bVal;
            this.textBlock.Enabled = bVal;
            this.textEtapa.Enabled = bVal;
            this.textReferencia.Enabled = bVal;

            this.conBusUbig2.Enabled = bVal;
            this.cboTipoZona2.Enabled = bVal;
            this.textZonas2.Enabled = bVal;
            this.cboTipoVia2.Enabled = bVal;
            this.textVia2.Enabled = bVal;
            this.textNro2.Enabled = bVal;
            this.textDpto2.Enabled = bVal;
            this.textInt2.Enabled = bVal;
            this.textMz2.Enabled = bVal;
            this.textLote2.Enabled = bVal;
            this.textKm2.Enabled = bVal;
            this.textBlock2.Enabled = bVal;
            this.textEtapa2.Enabled = bVal;
            this.textReferencia2.Enabled = bVal;

            this.checkBox1.Enabled = bVal;
            
        }

        private void BuscaPersonal(Int32 nIdCliente)
        {
            clsCNBuscaPersonal BuscaPersonal = new clsCNBuscaPersonal();
            dtbBuscaPersonal = BuscaPersonal.BuscaCliente(nIdCliente);
            //========================================================================
            //--Asignando Valores
            //========================================================================
            if (dtbBuscaPersonal.Rows.Count > 0)
            {
                pcTipoOpe = "A";

                idUsuario = (int)dtbBuscaPersonal.Rows[0]["idUsuario"];
                this.txtidUsuario.Text = dtbBuscaPersonal.Rows[0]["cWinUser"].ToString();
                this.cboAgencia1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idAgencia"];
                this.cboEstablecimiento1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idEstablecimiento"];
                this.cboArea1.SelectedValue = dtbBuscaPersonal.Rows[0]["idArea"].ToString();
                this.cboCargoPersonal.SelectedValue = dtbBuscaPersonal.Rows[0]["idCargo"].ToString();
                this.cboCategoriaPersonal1.SelectedValue = dtbBuscaPersonal.Rows[0]["idCategoria"].ToString();

                this.cboTipContratoPersonal1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idTipContrato"];
                this.cboTipoContratoTiempo.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idTipoContratoTiempo"];
                this.txtEmailInst.Text = dtbBuscaPersonal.Rows[0]["cEmailInst"].ToString();
                this.txtTelCelPer.Text = dtbBuscaPersonal.Rows[0]["cTelCelPer"].ToString();
                this.cboTipoRegimenPens1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idTipoRegimen"];
                this.cboRegimenPens.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idRegimenPens"];
                this.cboEsqComAFP1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idEsqComAFP"];
                
                this.txtRegistroReg.Text = dtbBuscaPersonal.Rows[0]["cRegPensiones"].ToString();
                if (Convert.ToString(dtbBuscaPersonal.Rows[0]["dInicioPensiones"]) != "")
                    this.dFecIniReg.Value = Convert.ToDateTime(dtbBuscaPersonal.Rows[0]["dInicioPensiones"]);

                this.txtNroAutogenerado.Text = dtbBuscaPersonal.Rows[0]["cAutogenerado"].ToString();
                this.cboGrupoSanguineo1.SelectedValue = (int)dtbBuscaPersonal.Rows[0]["idGrupSanguineo"];
                this.CBDiscapacidad.Checked = Convert.ToBoolean(dtbBuscaPersonal.Rows[0]["lDiscapacidad"]);
                this.CBDepPropioSalario.Checked = Convert.ToBoolean(dtbBuscaPersonal.Rows[0]["lDepSalarioIntsPropia"]);
                this.CBDepPropioCTS.Checked = Convert.ToBoolean(dtbBuscaPersonal.Rows[0]["lDepCTSIntsPropia"]);

                if (CBDepPropioSalario.Checked == true)
                {
                    if (dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString() != "")
                    {
                        this.txtCodIns.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString().Substring(0, 3);
                        this.txtCodAge.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString().Substring(3, 3);
                        this.txtCodMod.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString().Substring(6, 3);
                        this.txtCodMon.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString().Substring(9, 1);
                        this.txtCodCta.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString().Substring(10, 12);
                    }
                }
                if (CBDepPropioSalario.Checked == false)
                {
                    this.txtCtaAhorroExterno.Text = dtbBuscaPersonal.Rows[0]["cCtaSalario"].ToString();
                    this.cboTipoEntidad1.SelectedValue = dtbBuscaPersonal.Rows[0]["idTipoEntidadSalario"].ToString();
                    this.cboEntidad1.SelectedValue = dtbBuscaPersonal.Rows[0]["idInstFinSalario"].ToString();                        
                }

                if (CBDepPropioCTS.Checked == true) { 
                    if (dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString() != "")
                    {
                        this.txtCodInsCTS.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString().Substring(0, 3);
                        this.txtCodAgeCTS.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString().Substring(3, 3);
                        this.txtCodModCTS.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString().Substring(6, 3);
                        this.txtCodMonCTS.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString().Substring(9, 1);
                        this.txtCodCtaCTS.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString().Substring(10, 12);
                    }
                }
                if (CBDepPropioCTS.Checked == false)
                {
                    this.txtCtaCTSExterno.Text = dtbBuscaPersonal.Rows[0]["cNroCuentaCTS"].ToString();
                    this.cboTipoEntidad2.SelectedValue = dtbBuscaPersonal.Rows[0]["idTipoEntidadCTS"].ToString();
                    this.cboEntidad2.SelectedValue = dtbBuscaPersonal.Rows[0]["idInstFinCTS"].ToString();                                           
                }                
            }
            else
            {
                MessageBox.Show("Dicha Persona todavía no está registrada como Personal de la Empresa. \nPara registrarlo presione el botón EDITAR", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pcTipoOpe = "N";
                CleanData();
                CleanHistorial();
                CleanFamiliares();
                
            }

            CargarHistorial(nIdCliente);
            CargarFamiliares(nIdCliente);
            HabilitarControles(false);
            HabilitarCtrlHistorial(false);
            HabilitarCtrlFamiliares(false);

            this.conBusCli.btnBusCliente.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniNuevo.Enabled = false;
            this.btnMiniOK.Enabled = false;
            this.btnMiniEliminar.Enabled = false;

            this.btnEditarFAM.Enabled = false;
            this.btnNuevoFAM.Enabled = false;
            this.btnOKFAM.Enabled = false;
            this.btnEliminarFAM.Enabled = false;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void CargarHistorial(int nIdCliente)
        {
            clsCNBuscaPersonal BuscaPersonal = new clsCNBuscaPersonal();
            dtHistorial = BuscaPersonal.DatosHistorial(nIdCliente);
            dtHistorial.Columns.Add("lActivo", typeof(Boolean));


            for (int i = 0; i < dtHistorial.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtHistorial.Rows[i]["idEstado"]) == 1)
                    dtHistorial.Rows[i]["lActivo"] = 1;
                else
                    dtHistorial.Rows[i]["lActivo"] = 0;
            }

            if (dtgHistorial.ColumnCount > 0)
            {
                dtgHistorial.Columns.Remove("idRelacionLab");
                dtgHistorial.Columns.Remove("dFechaIngreso");
                dtgHistorial.Columns.Remove("dFechaCese");
                dtgHistorial.Columns.Remove("idTipoRelLab");
                dtgHistorial.Columns.Remove("cRelLaboral");
                dtgHistorial.Columns.Remove("idEstado");
                dtgHistorial.Columns.Remove("cMotCese");
                dtgHistorial.Columns.Remove("lLiquidacion");
                dtgHistorial.Columns.Remove("idSeguroMedico");
                dtgHistorial.Columns.Remove("idMotivoCese");    
                dtgHistorial.Columns.Remove("Est");
                dtgHistorial.Columns.Remove("lActivo");
                
            }
            dtgHistorial.DataSource = dtHistorial.DefaultView;

            dtgHistorial.Columns["idRelacionLab"].Visible = false;
            dtgHistorial.Columns["dFechaIngreso"].Width = 25;
            dtgHistorial.Columns["dFechaIngreso"].HeaderText = "F. Ingr.";
            dtgHistorial.Columns["dFechaIngreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgHistorial.Columns["dFechaCese"].Width = 25;
            dtgHistorial.Columns["dFechaCese"].HeaderText = "F. Cese";
            dtgHistorial.Columns["dFechaCese"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgHistorial.Columns["idTipoRelLab"].Visible = false;
            dtgHistorial.Columns["cRelLaboral"].Width = 25;
            dtgHistorial.Columns["cRelLaboral"].HeaderText = "R. Lab.";
            dtgHistorial.Columns["cRelLaboral"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgHistorial.Columns["idEstado"].Visible = false;
            dtgHistorial.Columns["cMotCese"].Visible = false;
            dtgHistorial.Columns["lLiquidacion"].Visible = false;
            dtgHistorial.Columns["idSeguroMedico"].Visible = false;
            dtgHistorial.Columns["idMotivoCese"].Visible = false;
            dtgHistorial.Columns["Est"].Visible = false;
            dtgHistorial.Columns["lActivo"].Width = 20;
            dtgHistorial.Columns["lActivo"].HeaderText = "Act";
            dtgHistorial.Columns["lActivo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            if (dtgHistorial.Rows.Count > 0)
                dtgHistorial.CurrentCell = dtgHistorial.Rows[0].Cells["dFechaIngreso"];
        }

        private void CargarFamiliares(int nIdCliente)
        {            
            clsCNBuscaPersonal BuscaFamiliares = new clsCNBuscaPersonal();
            dtFamiliares = BuscaFamiliares.DatosFamiliares(nIdCliente);

            if (dtgFamiliares.ColumnCount > 0)
            {
                dtgFamiliares.Columns.Remove("idFamiliares");
                dtgFamiliares.Columns.Remove("idVinculoFamiliar");
                dtgFamiliares.Columns.Remove("cVinculoFam");
                dtgFamiliares.Columns.Remove("idTipoDoc");                
                dtgFamiliares.Columns.Remove("cNroDoc");
                dtgFamiliares.Columns.Remove("idPaisEmisorDoc");
                dtgFamiliares.Columns.Remove("cApellidoPat");
                dtgFamiliares.Columns.Remove("cApellidoMat");
                dtgFamiliares.Columns.Remove("cNombres");
                dtgFamiliares.Columns.Remove("dFechaNac");
                dtgFamiliares.Columns.Remove("idSexo");
                dtgFamiliares.Columns.Remove("idMesConcepcion");
                dtgFamiliares.Columns.Remove("cAnioConcepcion");
                dtgFamiliares.Columns.Remove("idTipoDocAcredite");
                dtgFamiliares.Columns.Remove("cNroDocAcredite");

                dtgFamiliares.Columns.Remove("idUbigeo");
                dtgFamiliares.Columns.Remove("idTipoZona");
                dtgFamiliares.Columns.Remove("cNombreZona");
                dtgFamiliares.Columns.Remove("idTipoVia");
                dtgFamiliares.Columns.Remove("cNombreVia");
                dtgFamiliares.Columns.Remove("cNumero");
                dtgFamiliares.Columns.Remove("cDepartamente");
                dtgFamiliares.Columns.Remove("cInterior");
                dtgFamiliares.Columns.Remove("cManzana");
                dtgFamiliares.Columns.Remove("cLote");
                dtgFamiliares.Columns.Remove("cKilometro");
                dtgFamiliares.Columns.Remove("cBlock");
                dtgFamiliares.Columns.Remove("cEtapa");
                dtgFamiliares.Columns.Remove("cReferencia");

                dtgFamiliares.Columns.Remove("idUbigeo2");
                dtgFamiliares.Columns.Remove("idTipoZona2");
                dtgFamiliares.Columns.Remove("cNombreZona2");
                dtgFamiliares.Columns.Remove("idTipoVia2");
                dtgFamiliares.Columns.Remove("cNombreVia2");
                dtgFamiliares.Columns.Remove("cNumero2");
                dtgFamiliares.Columns.Remove("cDepartamente2");
                dtgFamiliares.Columns.Remove("cInterior2");
                dtgFamiliares.Columns.Remove("cManzana2");
                dtgFamiliares.Columns.Remove("cLote2");
                dtgFamiliares.Columns.Remove("cKilometro2");
                dtgFamiliares.Columns.Remove("cBlock2");
                dtgFamiliares.Columns.Remove("cEtapa2");
                dtgFamiliares.Columns.Remove("cReferencia2");

                dtgFamiliares.Columns.Remove("cTelefono");
                dtgFamiliares.Columns.Remove("cEmail");
                dtgFamiliares.Columns.Remove("dFechaAlta");
                dtgFamiliares.Columns.Remove("lDadoBaja");
                dtgFamiliares.Columns.Remove("dFechaBaja");
                dtgFamiliares.Columns.Remove("idMotivoBaja");
                dtgFamiliares.Columns.Remove("lVigente");
                dtgFamiliares.Columns.Remove("Est");
            }
            
            dtFamiliares.DefaultView.RowFilter = ("lVigente = 'true'");
            dtgFamiliares.DataSource = dtFamiliares.DefaultView;
           
            dtgFamiliares.Columns["idFamiliares"].Visible = false;
            dtgFamiliares.Columns["idVinculoFamiliar"].Visible = false;
            dtgFamiliares.Columns["cVinculoFam"].Width = 40;
            dtgFamiliares.Columns["cVinculoFam"].HeaderText = "Tipo de Vínculo";
            dtgFamiliares.Columns["cVinculoFam"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFamiliares.Columns["idTipoDoc"].Visible = false;
            dtgFamiliares.Columns["idPaisEmisorDoc"].Visible = false;
            dtgFamiliares.Columns["cNroDoc"].Width = 40;
            dtgFamiliares.Columns["cNroDoc"].HeaderText = "Nro Documento";
            dtgFamiliares.Columns["cNroDoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFamiliares.Columns["cApellidoPat"].Width = 40;
            dtgFamiliares.Columns["cApellidoPat"].HeaderText = "A. Paterno";
            dtgFamiliares.Columns["cApellidoPat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFamiliares.Columns["cApellidoMat"].Width = 40;
            dtgFamiliares.Columns["cApellidoMat"].HeaderText = "A. Materno";
            dtgFamiliares.Columns["cApellidoMat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFamiliares.Columns["cNombres"].Width = 40;
            dtgFamiliares.Columns["cNombres"].HeaderText = "Nombre";
            dtgFamiliares.Columns["cNombres"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFamiliares.Columns["dFechaNac"].Visible = false;
            dtgFamiliares.Columns["idSexo"].Visible = false;
            dtgFamiliares.Columns["idMesConcepcion"].Visible = false;
            dtgFamiliares.Columns["cAnioConcepcion"].Visible = false;
            dtgFamiliares.Columns["idTipoDocAcredite"].Visible = false;
            dtgFamiliares.Columns["cNroDocAcredite"].Visible = false;

            dtgFamiliares.Columns["idUbigeo"].Visible = false;
            dtgFamiliares.Columns["idTipoZona"].Visible = false;
            dtgFamiliares.Columns["cNombreZona"].Visible = false;
            dtgFamiliares.Columns["idTipoVia"].Visible = false;
            dtgFamiliares.Columns["cNombreVia"].Visible = false;
            dtgFamiliares.Columns["cNumero"].Visible = false;
            dtgFamiliares.Columns["cDepartamente"].Visible = false;
            dtgFamiliares.Columns["cInterior"].Visible = false;
            dtgFamiliares.Columns["cManzana"].Visible = false;
            dtgFamiliares.Columns["cLote"].Visible = false;
            dtgFamiliares.Columns["cKilometro"].Visible = false;
            dtgFamiliares.Columns["cBlock"].Visible = false;
            dtgFamiliares.Columns["cEtapa"].Visible = false;
            dtgFamiliares.Columns["cReferencia"].Visible = false;

            dtgFamiliares.Columns["idUbigeo2"].Visible = false;
            dtgFamiliares.Columns["idTipoZona2"].Visible = false;
            dtgFamiliares.Columns["cNombreZona2"].Visible = false;
            dtgFamiliares.Columns["idTipoVia2"].Visible = false;
            dtgFamiliares.Columns["cNombreVia2"].Visible = false;
            dtgFamiliares.Columns["cNumero2"].Visible = false;
            dtgFamiliares.Columns["cDepartamente2"].Visible = false;
            dtgFamiliares.Columns["cInterior2"].Visible = false;
            dtgFamiliares.Columns["cManzana2"].Visible = false;
            dtgFamiliares.Columns["cLote2"].Visible = false;
            dtgFamiliares.Columns["cKilometro2"].Visible = false;
            dtgFamiliares.Columns["cBlock2"].Visible = false;
            dtgFamiliares.Columns["cEtapa2"].Visible = false;
            dtgFamiliares.Columns["cReferencia2"].Visible = false;

            dtgFamiliares.Columns["cTelefono"].Visible = false;
            dtgFamiliares.Columns["cEmail"].Visible = false;
            dtgFamiliares.Columns["dFechaAlta"].Visible = false;
            dtgFamiliares.Columns["lDadoBaja"].Visible = false;
            dtgFamiliares.Columns["dFechaBaja"].Visible = false;
            dtgFamiliares.Columns["idMotivoBaja"].Visible = false;
            dtgFamiliares.Columns["lVigente"].Visible = false;
            dtgFamiliares.Columns["Est"].Visible = false;

            if (dtgFamiliares.Rows.Count > 0)
                dtgFamiliares.CurrentCell = dtgFamiliares.Rows[0].Cells["cVinculoFam"];
                                    
        }

        private void MostrarDatosHistorial()
        {
            if (Convert.ToInt32(this.dtgHistorial.Rows.Count) > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgHistorial.CurrentRow.Index);

                this.cboEstPersonal.SelectedValue = dtgHistorial.Rows[filaseleccionada].Cells["idEstado"].Value.ToString();
                this.cboTipoRelacionLaboral.SelectedValue = dtgHistorial.Rows[filaseleccionada].Cells["idTipoRelLab"].Value.ToString();
                this.dtpInicioPersonal.Value = Convert.ToDateTime(dtgHistorial.Rows[filaseleccionada].Cells["dFechaIngreso"].Value.ToString());
                this.cboSeguroSalud.SelectedValue = Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idSeguroMedico"].Value.ToString());
                
                if (Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idMotivoCese"].Value) != 0)
                {
                    this.chcDatosCese.Checked = true;
                    this.dtpCesePersonal.Value = Convert.ToDateTime(dtgHistorial.Rows[filaseleccionada].Cells["dFechaCese"].Value);
                    this.cboMotivoCesePer.SelectedValue = Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idMotivoCese"].Value.ToString());
                    this.txtMotCese.Text = dtgHistorial.Rows[filaseleccionada].Cells["cMotCese"].Value.ToString();
                    this.CBLiquidacion.Checked = Convert.ToBoolean(dtgHistorial.Rows[filaseleccionada].Cells["lLiquidacion"].Value);
                }
                if (Convert.ToInt32(dtgHistorial.Rows[filaseleccionada].Cells["idMotivoCese"].Value) == 0)
                {
                    this.chcDatosCese.Checked = false;
                    this.dtpCesePersonal.Value = clsVarGlobal.dFecSystem;
                    this.cboMotivoCesePer.SelectedValue = 0;
                    this.txtMotCese.Text = "";
                    this.CBLiquidacion.Checked = false;
                }

                if (btnEditar.Enabled == false)
                {
                    btnMiniNuevo.Enabled = true;
                    btnMiniEditar.Enabled = true;                    
                    btnMiniOK.Enabled = false;
                    btnMiniEliminar.Enabled = true;
                }
                
                HabilitarCtrlHistorial(false);
            }
            else
            {
                CleanHistorial();
                btnMiniNuevo.Enabled = true;
                btnMiniEditar.Enabled = false;                
                btnMiniOK.Enabled = false;
                btnMiniEliminar.Enabled = false;
            }
        }

        private void MostrarDatosFAM()
        {
            if (Convert.ToInt32(this.dtgFamiliares.Rows.Count) > 0)
            {
                clsCNRetDatosCliente RetUbigeo = new clsCNRetDatosCliente();//Para obtener el Ubigeo

                int filaseleccionada = Convert.ToInt32(this.dtgFamiliares.CurrentRow.Index);

                this.cboTipVinculo.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idVinculoFamiliar"].Value);
                this.cboTipDocumento1.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoDoc"].Value);
                this.cboProcedPais.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idPaisEmisorDoc"].Value);
                this.txtNroDocumentos1.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNroDoc"].Value);
                this.txtApePat.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cApellidoPat"].Value);
                this.txtApeMat.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cApellidoMat"].Value);
                this.txtNom1.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNombres"].Value);
                this.dFecNacimiento.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["dFechaNac"].Value);
                this.cboSexo1.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idSexo"].Value);
                this.cboMeses1.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idMesConcepcion"].Value);
                this.txtAnio.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cAnioConcepcion"].Value);
                this.cboTipDocVinculo.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoDocAcredite"].Value);
                this.txtNroDocVinculo.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNroDocAcredite"].Value);

                this.txtTelefCel1.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cTelefono"].Value);
                this.txtEmail1.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cEmail"].Value);

                this.dtALTA.Value = Convert.ToDateTime(dtgFamiliares.Rows[filaseleccionada].Cells["dFechaAlta"].Value);                
                this.dtBAJA.Value = Convert.ToDateTime(dtgFamiliares.Rows[filaseleccionada].Cells["dFechaBaja"].Value);
                this.cboMotivoBAJA.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idMotivoBaja"].Value);
                this.CBDadoBaja.Checked = Convert.ToBoolean(dtgFamiliares.Rows[filaseleccionada].Cells["lDadoBaja"].Value);

                Int32 idUbigeo = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idUbigeo"].Value);
                DataTable tbDatUbi = RetUbigeo.RetUbiCli(idUbigeo);
                conBusUbiCli.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                conBusUbiCli.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                conBusUbiCli.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                conBusUbiCli.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                               
                this.cboTipoZona.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoZona"].Value);
                this.textZonas.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNombreZona"].Value);
                this.cboTipoVia.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoVia"].Value);
                this.textVia.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNombreVia"].Value);
                this.textNro.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNumero"].Value);
                this.textDpto.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cDepartamente"].Value);
                this.textInt.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cInterior"].Value);
                this.textMz.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cManzana"].Value);
                this.textLote.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cLote"].Value);
                this.textKm.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cKilometro"].Value);
                this.textBlock.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cBlock"].Value);
                this.textEtapa.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cEtapa"].Value);
                this.textReferencia.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cReferencia"].Value);

                Int32 idUbigeo2 = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idUbigeo2"].Value);
                DataTable tbDatUbi2 = RetUbigeo.RetUbiCli(idUbigeo2);
                conBusUbig2.cboPais.SelectedValue = tbDatUbi2.Rows[3]["idUbigeo"].ToString();
                conBusUbig2.cboDepartamento.SelectedValue = tbDatUbi2.Rows[2]["idUbigeo"].ToString();
                conBusUbig2.cboProvincia.SelectedValue = tbDatUbi2.Rows[1]["idUbigeo"].ToString();
                conBusUbig2.cboDistrito.SelectedValue = tbDatUbi2.Rows[0]["idUbigeo"].ToString();
          
                this.cboTipoZona2.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoZona2"].Value);
                this.textZonas2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNombreZona2"].Value);
                this.cboTipoVia2.SelectedValue = Convert.ToInt32(dtgFamiliares.Rows[filaseleccionada].Cells["idTipoVia2"].Value);
                this.textVia2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNombreVia2"].Value);
                this.textNro2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cNumero2"].Value);
                this.textDpto2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cDepartamente2"].Value);
                this.textInt2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cInterior2"].Value);
                this.textMz2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cManzana2"].Value);
                this.textLote2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cLote2"].Value);
                this.textKm2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cKilometro2"].Value);
                this.textBlock2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cBlock2"].Value);
                this.textEtapa2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cEtapa2"].Value);
                this.textReferencia2.Text = Convert.ToString(dtgFamiliares.Rows[filaseleccionada].Cells["cReferencia2"].Value);

                tbcBase2.SelectedIndex = 0;
              
                if (btnEditar.Enabled == false)
                {
                    btnEditarFAM.Enabled = true;
                    btnNuevoFAM.Enabled = true;
                    btnOKFAM.Enabled = false;
                    btnEliminarFAM.Enabled = true;
                }
                HabilitarCtrlFamiliares(false);
            }
            else
            {
                CleanFamiliares();
                this.btnNuevoFAM.Enabled = true;
                this.btnEditarFAM.Enabled = false;
                this.btnOKFAM.Enabled = false;
                this.btnEliminarFAM.Enabled = false;                
            }
        }

        private bool ValidarData()
        {
            if (txtidUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Debe asignar un usuario válido para el/la compañero(a)", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidUsuario.Focus();
                return false;
            }


            if (cboAgencia1.Text.Trim()=="" || (int)cboAgencia1.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboAgencia1.Focus();
                return false;
            }
            if (cboEstablecimiento1.Text.Trim()=="")
            {
                MessageBox.Show("Debe seleccionar el Establecimiento", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboEstablecimiento1.Focus();
                return false;
            }
            if (cboArea1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Área", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboArea1.Focus();
                return false;
            }
            if (cboCargoPersonal.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Cargo", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboCargoPersonal.Focus();
                return false;
            }

            if (this.cboCategoriaPersonal1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la categoría", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboCategoriaPersonal1.Focus();
                return false;
            }

            if (cboTipContratoPersonal1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Condición de su Contrato", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboTipContratoPersonal1.Focus();
                return false;
            }
            if (cboTipoContratoTiempo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Contrato", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboTipoContratoTiempo.Focus();
                return false;
            }
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match matchEmail = regexEmail.Match(this.txtEmailInst.Text.Trim());
            if (!matchEmail.Success)
            {
                MessageBox.Show("Debe ingresar un Correo institucional válido del personal.\nEjemplo: ejemplo@cajalosandes.pe", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmailInst.Focus();
                return false;
            }
            Regex regexTelCel = new Regex(@"^([0-9]{6,15})?$");
            Match mathTelCel = regexTelCel.Match(this.txtTelCelPer.Text.Trim());
            if (!mathTelCel.Success)
            {
                MessageBox.Show("Debe ingresar un número de teléfono o celular válido.", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelCelPer.Focus();
                return false;
            }
            if (cboTipoRegimenPens1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Régimen", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboTipoRegimenPens1.Focus();
                return false;
            }
            if (cboRegimenPens.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Régimen", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                cboRegimenPens.Focus();
                return false;
            }

            //DATOS DE LA RELACION LABORAL
            if (dtgHistorial.Rows.Count == 0)
            {
                MessageBox.Show("Debe Registrar los datos de la Relación Laboral que el personal tiene con la Financiera", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                return false;
            }
            int cont = 0;
            foreach (DataGridViewRow fila in dtgHistorial.Rows)
            {
                if (Convert.ToInt32(fila.Cells["lActivo"].Value) == 1)
                    cont = cont + 1;
            }
            if (cont > 1)
            {
                MessageBox.Show("No pueden Existir 2 o mas Relaciones Laborales en Estado: ACTIVO, por favor corrija", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcBase1.SelectedIndex = 0;
                return false;
            }

            int idRelLaboral = 999999;
            for (int i = 0; i < dtHistorial.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtHistorial.Rows[i]["lActivo"]) == 1)
                    idRelLaboral = Convert.ToInt32(dtHistorial.Rows[i]["idTipoRelLab"]);
            }

            if (idRelLaboral == 2) {//OBLIGATORIO PARA EMPLEADOS, NO DIRECTIVOS, NI PRACTICANTES
                    if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue)==3)
                    {
                        MessageBox.Show("Debe seleccionar un Tipo de Régimen válido, dato obligatorio para los Empleados Activos", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 0;
                        cboTipoRegimenPens1.Focus();
                        return false;
                    }                   
                    if (dFecIniReg.Value.Date > DateTime.Now.Date)
                    {
                        MessageBox.Show("La fecha de registro no puede posterior a la Fecha de Hoy, dato obligatorio para los Empleados Activos", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 0;
                        cboRegimenPens.Focus();
                        return false;
                    }
                    if (txtRegistroReg.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el numero de Registro al Sist. de Pensiones, dato obligatorio para los Empleados Activos", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 0;
                        cboRegimenPens.Focus();
                        return false;
                    }
                    if (cboEsqComAFP1.Text.Trim() == "" && cboEsqComAFP1.Enabled==true)
                    {
                        MessageBox.Show("Debe seleccionar el Esquema de Comisión de la AFP, dato obligatorio para los Empleado Activos", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 0;
                        cboEsqComAFP1.Focus();
                        return false;
                    }
            }
            //DATOS DE LAS CUENTAS DE AHORRO Y CTS
            if (Convert.ToInt32(clsVarApl.dicVarGen["nIndParametrizacion"]) == 1)
            {
                if (CBDepPropioSalario.Checked==true)
                {
                    if (txtCodCta.Text == "")
                    {
                        MessageBox.Show("Debe Indicar el Nro de Cuenta para el Depósito del salario del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        btnBuscarCta.Focus();
                        return false;
                    }                    
                }
                if (CBDepPropioSalario.Checked == false)
                {
                    if (cboEntidad1.Text == "")
                    {
                        MessageBox.Show("Debe Indicar la Institución Financiera donde se depositará el salario del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        cboEntidad1.Focus();
                        return false;
                    }
                    if (txtCtaAhorroExterno.Text == "")
                    {
                        MessageBox.Show("Debe Indicar el Nro de Cuenta para el Depósito del salario del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        txtCtaAhorroExterno.Focus();
                        return false;
                    }
                            
                }
                if (CBDepPropioCTS.Checked == true)
                {                    
                    if (txtCodCtaCTS.Text == "")
                    {
                        MessageBox.Show("Debe Indicar el Nro de Cuenta para el Depósito del CTS del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        btnBuscarCtaCTS.Focus();
                        return false;
                    }
                }
                if (CBDepPropioCTS.Checked == false)
                {
                    if (cboEntidad2.Text == "")
                    {
                        MessageBox.Show("Debe Indicar la Institución Financiera donde se depositará el CTS del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        cboEntidad2.Focus();
                        return false;
                    }                    
                    if (txtCtaCTSExterno.Text == "")
                    {
                        MessageBox.Show("Debe Indicar el Nro de Cuenta para el Depósito del CTS del Personal", "Registro de Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcBase1.SelectedIndex = 1;
                        txtCtaCTSExterno.Focus();
                        return false;
                    }
                }


            }
            return true;
        }

        private void CleanData()
        {
            this.cboAgencia1.SelectedIndex = -1;
            this.cboEstablecimiento1.SelectedIndex = -1; 
            this.cboArea1.SelectedIndex = -1;            
            this.cboCargoPersonal.SelectedIndex = -1;
            this.conBusCli.Focus();
            this.txtidUsuario.Clear();
            this.cboTipContratoPersonal1.SelectedIndex = -1;
            this.cboTipoContratoTiempo.SelectedValue = -1;
            this.txtEmailInst.Clear();
            this.txtTelCelPer.Clear();
            this.cboTipoRegimenPens1.SelectedIndex = -1;
            this.cboEsqComAFP1.SelectedIndex = -1;
            this.cboRegimenPens.SelectedIndex = -1;
            this.txtRegistroReg.Text = "";
            this.dFecIniReg.Value = clsVarGlobal.dFecSystem;
            this.txtNroAutogenerado.Clear();
            this.cboGrupoSanguineo1.SelectedIndex = -1;
            this.CBDiscapacidad.Checked = false;

            this.CBDepPropioSalario.Checked = false;
            this.CBDepPropioCTS.Checked = false;
            this.txtCodIns.Clear();
            this.txtCodAge.Clear();
            this.txtCodMod.Clear();
            this.txtCodMon.Clear();
            this.txtCodCta.Clear();

            this.txtCodInsCTS.Clear();
            this.txtCodAgeCTS.Clear();
            this.txtCodModCTS.Clear();
            this.txtCodMonCTS.Clear();
            this.txtCodCtaCTS.Clear();

            this.cboTipoEntidad1.SelectedIndex = -1;
            this.cboEntidad1.SelectedIndex = -1;
            this.txtCtaAhorroExterno.Clear();
            this.cboTipoEntidad2.SelectedIndex = -1;
            this.cboEntidad2.SelectedIndex = -1;
            this.txtCtaCTSExterno.Clear();
        }

        private void CleanHistorial()
        {
            this.cboEstPersonal.SelectedIndex = -1;
            this.cboTipoRelacionLaboral.SelectedIndex = -1;
            this.dtpInicioPersonal.Value = clsVarGlobal.dFecSystem;
            this.chcDatosCese.Checked = false;
            this.dtpCesePersonal.Value = clsVarGlobal.dFecSystem;
            this.cboSeguroSalud.SelectedIndex = -1;         
            this.cboMotivoCesePer.SelectedIndex = -1;
            this.txtMotCese.Clear();
            this.CBLiquidacion.Checked = false;            

        }

        private void CleanFamiliares()
        {
            this.cboTipVinculo.SelectedIndex = -1;
            this.cboTipDocumento1.SelectedIndex = -1;
            this.cboProcedPais.SelectedIndex = -1;
            this.txtNroDocumentos1.Clear();
            this.txtApePat.Clear();
            this.txtApeMat.Clear();
            this.txtNom1.Clear();
            this.dFecNacimiento.Value=clsVarGlobal.dFecSystem;
            this.cboSexo1.SelectedIndex = -1;
            this.cboMeses1.SelectedIndex = -1;
            this.txtAnio.Clear();
            this.cboTipDocVinculo.SelectedIndex = -1;
            this.txtNroDocVinculo.Clear();
            this.txtTelefCel1.Clear();
            this.txtEmail1.Clear();
            this.dtALTA.Value = clsVarGlobal.dFecSystem;
            this.dtBAJA.Value = clsVarGlobal.dFecSystem;
            this.CBDadoBaja.Checked = false;
            this.cboMotivoBAJA.SelectedIndex = -1;

            this.conBusUbiCli.cboPais.SelectedIndex = -1;
            this.conBusUbiCli.cboDepartamento.SelectedIndex = -1;
            this.conBusUbiCli.cboProvincia.SelectedIndex = -1;
            this.conBusUbiCli.cboDistrito.SelectedIndex = -1;
            this.cboTipoZona.SelectedIndex = -1;
            this.textZonas.Clear();
            this.cboTipoVia.SelectedIndex = -1;
            this.textVia.Clear();
            this.textNro.Clear();
            this.textDpto.Clear();
            this.textInt.Clear();
            this.textMz.Clear();
            this.textLote.Clear();
            this.textKm.Clear();
            this.textBlock.Clear();
            this.textEtapa.Clear();
            this.textReferencia.Clear();

            this.conBusUbig2.cboPais.SelectedIndex = -1;
            this.conBusUbig2.cboDepartamento.SelectedIndex = -1;
            this.conBusUbig2.cboProvincia.SelectedIndex = -1;
            this.conBusUbig2.cboDistrito.SelectedIndex = -1;          
            this.cboTipoZona2.SelectedIndex = -1;
            this.textZonas2.Clear();
            this.cboTipoVia2.SelectedIndex = -1;
            this.textVia2.Clear();
            this.textNro2.Clear();
            this.textDpto2.Clear();
            this.textInt2.Clear();
            this.textMz2.Clear();
            this.textLote2.Clear();
            this.textKm2.Clear();
            this.textBlock2.Clear();
            this.textEtapa2.Clear();
            this.textReferencia2.Clear();

            this.checkBox1.Checked = false;

        }

        private void asignarNuevoUsuario()
        {
            var dtUsuario = cnguardapersonal.CNRetornarUsuarioParaSistema(this.conBusCli.idCli);
            if (dtUsuario.Rows.Count>0)
            {
                txtidUsuario.Text = dtUsuario.Rows[0][0].ToString();
            }
        }

        #endregion
                
    }
}

#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.Funciones;
using SPL.Presentacion;
using DEP.CapaNegocio;
using SPL.CapaNegocio;
using System.Text.RegularExpressions;
using CLI.Servicio;
using EntityLayer.Bus.Reniec;
using System.Drawing;
using System.Reflection.Emit;
using REN.Servicio;
using EntityLayer.Bus.Response;
#endregion

namespace CLI.Presentacion
{
    public partial class frmRegistroClientes : frmBase
    {

        #region Variable Globales
        int idDirecNueva = 0;
        public DataTable tbDirCli;
        public DataTable tbClienteVinculado;
        public DataTable dtbTipDir;
        public DateTime pdFecSistem = clsVarGlobal.dFecSystem;
        public string pcTipOpe = "O"; //Puede ser N --> Nuevo, A--> Actualizar, O-->Indica ninguna acción
        public String zona, via;
        clsCNDeposito objDeposito = new clsCNDeposito();
        clslisTipoVinculo tbVinculo;
        clsFunUtiles funciones = new clsFunUtiles();
        clsCNCliente Cliente = new clsCNCliente();
        clsCNPep cnpep = new clsCNPep();
        DataTable tbProf = new DataTable();
        clsCNRetDatosCliente RetTipCli = new clsCNRetDatosCliente();
        clsCNListaActivEco ObjActividadEco = new clsCNListaActivEco();
        int filaDir = 0, idMagnitudEmpresarial = 0, idEstadoCli = 0, filaVinc = 0, idCliVinc = 0;
        Boolean lMenoresEdad = false;
        private clsCNScoring _cnScoring;

        int nUbigeoSunatPaisEEUU = 9249;
        //DateTime dFecIniActEcoDefault = Convert.ToDateTime("1753-1-1");
        DateTime dFecIniActEcoDefault = clsVarGlobal.dFecSystem;

        int idProfe = 0;
        int idCarg = 0;

        clsDatosReniecBus objClienteBus;
        clsBusConsultaCliente objConsultaCliente;

        int HabilitarBusReniec = 0;
        private ToolTip tooltip = new ToolTip();
        private string cVerificadoReniec = "Valor obtenido por el servicio RENIEC";
        private string cVerificadoSunat = "Valor obtenido por el servicio SUNAT";
        private string cRestringido = "Solicite su cambio mediante el boton solicitar";
        private int idCli = 0;
        private int idEstadoCivil = 0;
        #endregion


        #region Eventos
        public frmRegistroClientes()
        {
            InitializeComponent();
            _cnScoring = new clsCNScoring();
        }
        public frmRegistroClientes(int idCli)
        {
            InitializeComponent();
            _cnScoring = new clsCNScoring();
            this.idCli = idCli;
        }
        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            CargarCodCiudad();
            CargarDatos();
            CargarDirCli(0);
            CargarVinculados(0);
            CargarSuministro();

            this.cboUbigeoPais.CargarUbigeo(0);
            this.cboEstadoCivil.CargarEstadoCivil(0);
            this.cboEstadoCivilSBS.CargarEstadoCivil(1);
            this.cboZonaRegistral1.CargarZonaRegistral(0);
            this.cboActividadEco.CargarActivEconomica(0);
            this.cboActividadEco2.CargarActivEconomica(0);

            this.cboEstadoCliJur.ListaEstadoCli(2);
            this.cboEstadoCliJur.ListaEstadoCli(2);
            this.cboEstadoCliNat.ListaEstadoCli(1);

            LimpiarControles();
            HabilitarControles_Gen(false);
            HabilitarControles_PerNat(false);
            HabilitarControles_PerJur(false);
            HabilitarControles_Vinculo(false);

            conBusUbiNac.cargar();
            conBusCliVin.btnBusCliente.Enabled = false;
            conBusCliVin.txtCodCli.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;
            txtPorCapSocVot.Enabled = false;
            //corrección iván
            cboEstadoContribNat.Enabled = false;

            cboEstadoContribuyenteJur.Enabled = false;
            cboEstadoCivilSBS.Enabled = false;
            cboTipoCategoriaNat.Enabled = false;
            cboTipoCategoriaJur.Enabled = false;
            cboMagnitudEmpresarial1.SelectedIndex = -1;
            cboMagnitudEmpresarial1.cargarDatos(2);

            cboActividadInternaNatAd.cargarVigenteNinguno();
            cboOcupacion.Visible = false;
            lblBase19.Visible = false;
            btnRegNumTelf.Enabled = false;
            conAutorizacionUsuDatos1.Enabled = clsVarApl.dicVarGen["nIndTrabAutTraDatCli"] == 0 ? false : true;
            if (idCli > 0)
            {
                this.conBusCliente.CargardatosCli(idCli);
                this.Buscar();
            }
        }

        private void AutocompletarUbigeo() 
        { 
            txtDirUbi.AutoCompleteCustomSource = cargaDatosAutoCompletar();
            txtDirUbi.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDirUbi.AutoCompleteSource = AutoCompleteSource.CustomSource;       
        }

        private AutoCompleteStringCollection cargaDatosAutoCompletar()
        {
            clsCNCliente ListaUbigeo = new clsCNCliente();
            DataTable dListaUbigeo = ListaUbigeo.CNListarUbigeo("");

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dListaUbigeo.Rows)
            {
                stringCol.Add(Convert.ToString(row["UBICACION"]));
            }

            return stringCol;

        }

        private void RecuperaUbigeo(string dirUbigeo)
        {
            clsCNCliente ListaUbigeo = new clsCNCliente();
            DataTable dtListaUbigeo = ListaUbigeo.CNObtenerDirUbigeo(dirUbigeo);

            if (dtListaUbigeo.Rows.Count == 0)
            {
                txtDirUbi.Text = "";
                txtCodDirUbi.Text = "";
                return;
            }
            else
            {
                txtCodDirUbi.Text = Convert.ToString(dtListaUbigeo.Rows[0]["UBIGEO"]);
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

        }
        private async void btnGrabar1_Click(object sender, EventArgs e)
        {
            HabilitarBusReniec = 0;
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCliente.idCli, this.conBusCliente.idCli, "Inicio-Mantenimiento de cuenta", this.btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (ValidarDatos_Generales() == "ERROR")
            {
                tbcCliente.SelectedIndex = 0;
                return;
            }


            if (alertaActualizaciondir() == false)
            {
                return;
            }
            else
            {
                if (!ValidarRegDir())
                {
                    return;
                }
                btnMiniActualizar1_Click(sender, e);
            }

            //----------------------------------------------------------------------------------------------------------
            //-- Validar Si el cliente se encuentra en la base negativa, solo cuando se registra el cliente
            //----------------------------------------------------------------------------------------------------------
            if (pcTipOpe == "N")
            {
                string pcNroDoc = "";
                pcNroDoc = txtCBDoc.Text.Trim();

                if (ValidaCliBaseNegativa(pcNroDoc, clsVarGlobal.idModulo, clsVarGlobal.lBaseNegativa))
                {
                    return;
                }
            }
                    
                  
            if (clsVarApl.dicVarGen["nIndTrabAutTraDatCli"] == 1)
            { 
                #region Autorizaciones de uso de datos
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                {
                        if (chcBeneficiario.Checked == false && ValidarDatos_PerNatural() == "ERROR")
                        {
                            tbcCliente.SelectedIndex = 1;
                            return;
                        }
                        if (chcBeneficiario.Checked == true && ValidarDatos_PerNaturalBeneficiario() == "ERROR")
                        {
                            tbcCliente.SelectedIndex = 1;
                            return;
                        }
                        if (pcTipOpe == "N")
                    {
                        string cnombre =  txtNom1.Text + " " + txtApePat.Text + " " + txtApeMat.Text;
                        bool isValid = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1,"" , 0,
                       cnombre, txtCBDoc.Text,
                                             txtDireccion.Text, txtCBNroTel2.Text, Convert.ToInt32(cboTipPersona.SelectedValue), Convert.ToInt32(cboTipDocumento.SelectedValue));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (isValid == false)
                        {
                            MessageBox.Show("Debe registrar la autorización de uso de datos de " + cnombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);
                            return;
                        }
                    }
                    else
                    {
                        bool isValid = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos( 1, conBusCliente.txtCodInst.Text + conBusCliente.txtCodAge.Text + conBusCliente.txtCodCli.Text, 0,
                           conBusCliente.txtNombre.Text, conBusCliente.txtNroDoc.Text,
                                             conBusCliente.txtDireccion.Text, txtCBNroTel2.Text, Convert.ToInt32(cboTipPersona.SelectedValue), Convert.ToInt32(cboTipDocumento.SelectedValue));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (isValid == false)
                        {
                                MessageBox.Show("Debe registrar la autorización de uso de datos de " + conBusCliente.txtNombre.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);
                            return;
                        }
                    }
                    

                }
                else
                {
                    var lstTitulares = tbClienteVinculado.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoVinculo"]) == 10 || Convert.ToInt16(x["idTipoVinculo"]) == 2);

                    /*========================================================================================
                   * VALIDACION DE AUTORIZACION DE USO DE DATOS
                   ========================================================================================*/
                    foreach (var titular in lstTitulares)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        conAutorizacionUsuDatos1.pcNombreJuridico = this.conBusCliente.txtNombre.Text;
                        conAutorizacionUsuDatos1.pcNroDocJuridico = this.conBusCliente.txtNroDoc.Text;
                        bool isValid = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, conBusCliente.txtCodInst.Text + conBusCliente.txtCodAge.Text + conBusCliente.txtCodCli.Text, 0,
                                                titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              "", "", 2,  Convert.ToInt32(cboTipDocumento.SelectedValue));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (isValid == false)
                        {
                                MessageBox.Show("Debe registrar la autorización de uso de datos de " + titular.Field<string>("cNombre"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    /*========================================================================================
                   * FIN VALIDACION DE AUTORIZACION DE USO DE DATOS
                   ========================================================================================*/
                    
                }
                  
            }
                    #endregion
                }

            //======================================================================
            //Obtener Datos Generales
            //======================================================================
            string tcNacionalidad = "";
            if (this.RdBtnNacionPer.Checked)
                tcNacionalidad = "0";
            else if (this.RdBtnNacionExt.Checked)
                tcNacionalidad = "1";
            string tcTipRes = cboTipoResidencia1.SelectedValue.ToString().Trim();
            string tcPaisRes = cboUbigeoPais.SelectedValue.ToString().Trim();
            string tcTipPer = cboTipPersona.SelectedValue.ToString().Trim();
            string tcTipClasif = cboTipClasificacion.SelectedValue.ToString().Trim();
            string tcTipDoc = cboTipDocumento.SelectedValue.ToString().Trim();
            string tcDocIde = txtCBDoc.Text.Trim();
            string tcTipDocAdi = "0";
            if (cboTipDocAdi.SelectedValue != null && txtCBDocAdi.Text != "")
                tcTipDocAdi = cboTipDocAdi.SelectedValue.ToString().Trim();
            string tcDocAdi = txtCBDocAdi.Text.Trim();
            string tcDirCli = txtDireccion.Text.Trim();
            string tcRefer = txtReferencia.Text.Trim();
            string tcTelef = txtCBNroTel.Text.Trim();
            string tcTelef2 = txtCBNroTel2.Text.Trim();
            string tcCorreo = txtCBCorreoElectronico.Text.Trim();
            string tcDigVerificador = txtCBDigVerificador.Text.Trim();


            //===================================================================
            //Validar idMagnitudEmpresarial, depeendiendo del tipo de Clasificacion
            //===================================================================
            if (cboTipClasificacion.SelectedValue.ToString().Trim() == "1")
                {
                    if(txtCBDocAdi.Text=="")
                    {
                        idMagnitudEmpresarial = 1;//Persona natural con negocio sin ruc
                    }
                    else
                        idMagnitudEmpresarial = 2;//Persona natural con negocio y ruc

                }
            else if (cboTipClasificacion.SelectedValue.ToString().Trim() == "2" )
            {
                idMagnitudEmpresarial = 1;//Persona natural sin negocio

            }

            //===================================================================
            //Guardar Datos de Direcciones Mediante XML
            //===================================================================

            DataSet dsDir = new DataSet("dsDireccion");
            foreach (DataRow row in tbDirCli.AsEnumerable())
            {
                int? nAñoConstruccion = Convert.IsDBNull(row["nAñoConstruccion"]) ? (int?)null : Convert.ToInt32(row["nAñoConstruccion"]);
                int? nPisos = Convert.IsDBNull(row["nPisos"]) ? (int?)null : Convert.ToInt32(row["nPisos"]);
                int? nSotanos = Convert.IsDBNull(row["nSotanos"]) ? (int?)null : Convert.ToInt32(row["nSotanos"]);

                if (nAñoConstruccion == 0) row["nAñoConstruccion"] = DBNull.Value;
                if (nPisos == 0) row["nPisos"] = DBNull.Value;
                if (nSotanos == -1) row["nSotanos"] = DBNull.Value;
            }
            dsDir.Tables.Add(tbDirCli);
            string xmlDirec = dsDir.GetXml();
            xmlDirec = clsCNFormatoXML.EncodingXML(xmlDirec);
            Console.WriteLine(xmlDirec);
            dsDir.Tables.Clear();

            //===================================================================
            //Guardar Datos de Vinculos Mediante XML
            //===================================================================
            DataSet dsVin = new DataSet("dsVinculo");
            dsVin.Tables.Add(tbClienteVinculado);
            string xmlVinc = dsVin.GetXml();
            xmlVinc = clsCNFormatoXML.EncodingXML(xmlVinc);
            dsVin.Tables.Clear();
            int idCodCiudad = Convert.ToInt32(cboCodCiudad.SelectedValue);
            string cCorreoAdicional = txtCorreElectronicoAd.Text;
            string cNumTel3 = txtTelefCel1.Text;
            string cCodSBS = txtCodSBS.Text.ToString().Trim();



            //===================================================================
            //Guardar Datos del Cliente
            //===================================================================
            if (cboTipPersona.SelectedValue.ToString().Trim() == "1")
            {
                //ValidarDatos_PerNatural();
                if (chcBeneficiario.Checked == false && ValidarDatos_PerNatural() == "ERROR")
                {
                    tbcCliente.SelectedIndex = 1;
                    return;
                }
                if (chcBeneficiario.Checked == true && ValidarDatos_PerNaturalBeneficiario() == "ERROR")
                {
                    tbcCliente.SelectedIndex = 1;
                    return;
                }

                //=======================================================================
                //Obtener Datos de Persona Natural
                //=======================================================================
                string tcApePat = txtApePat.Text.Trim();
                string tcApeMat = txtApeMat.Text.Trim();
                string tcNom1 = txtNom1.Text.Trim();
                string tcNom2 = txtNom2.Text.Trim();
                string tcNom3 = txtNom3.Text.Trim();
                string tcApeCas = txtApeCasado.Text.Trim();
                string tcNombCliente = tcApePat + " " + tcApeMat + " " + tcApeCas + " " + tcNom1 + " " + tcNom2 + " " + tcNom3;
                tcNombCliente = tcNombCliente.Trim();
                tcNombCliente = Regex.Replace(tcNombCliente, @"\s+", " ");

                string tcSexo = cboSexo.SelectedValue.ToString().Trim();
                string tcEstCiv = null;

                //===================================================================
                //Validar Cliente Homónimos
                //===================================================================
                DataTable dtHomonimos = Cliente.CNValidaHomonimos(tcNombCliente, tcDocIde);
                if (dtHomonimos.Rows.Count > 0 && txtApePat.Enabled == true && txtApeMat.Enabled == true && txtNom1.Enabled == true)
                {
                    frmClientesHomonimos frmHomonimos = new frmClientesHomonimos();
                    frmHomonimos.dtClientesHomonimos = dtHomonimos;
                    frmHomonimos.ShowDialog();
                    if (MessageBox.Show("¿Desea continuar con el registro del cliente?", "Registro de clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                //===================================================================
                if (cboEstadoCivil.SelectedIndex > -1)
                {
                    tcEstCiv = cboEstadoCivil.SelectedValue.ToString().Trim();
                }
                string tcEstCivSBS = null;
                if (cboEstadoCivilSBS.SelectedIndex > -1)
                {
                    tcEstCivSBS = cboEstadoCivilSBS.SelectedValue.ToString().Trim();
                }

                DateTime tdFecNac = dtFecNac.Value;
                string tcNumHijos = txtNroHijos.Text.Trim();
                if (string.IsNullOrEmpty(tcNumHijos))
                    tcNumHijos = "0";
                string tcNumPerDepend = txtNroPerDep.Text.Trim();
                if (string.IsNullOrEmpty(tcNumPerDepend))
                    tcNumPerDepend = "0";
                int tnCodUbi = 0;
                if (conBusUbiNac.cboAnexo.SelectedIndex > -1)
                {
                    tnCodUbi = Convert.ToInt32(conBusUbiNac.cboAnexo.SelectedValue.ToString());
                }
                string tcProf = null;
                tcProf = Convert.ToString(idProfe);
                if (cboProfesion.SelectedIndex > -1)
                {
                    tcProf = cboProfesion.SelectedValue.ToString().Trim();
                }
                string tcNivInst = null;
                if (cboNivInstruc.SelectedIndex > -1)
                {
                    tcNivInst = cboNivInstruc.SelectedValue.ToString().Trim();
                }

                string tcOcup = "117";
                string tcidCargo = null;
                tcidCargo = Convert.ToString(idCarg);
                if (cboClienteCargo1.SelectedIndex > -1)
                {
                    tcidCargo = cboClienteCargo1.SelectedValue.ToString().Trim();
                }
                string tcDesCargo = txtOtrosDesc.Text;
                string tcDesProfesion = txtProfesion.Text;
                string tcIdActEcoN = "0";
                if (cboActividadEco4.Text != "")
                    tcIdActEcoN = cboActividadEco4.SelectedValue.ToString().Trim();
                bool lIndDatBasico = chcBeneficiario.Checked;
                DateTime? dFecIniActEcoNat = dtpFecIniActEcoNat.Value;
                if (dtpFecIniActEcoNat.Text == " ")
                {
                    dFecIniActEcoNat = null;
                }                
                int idEstadoCliNat = Convert.ToInt32(cboEstadoCliNat.SelectedValue);
                int idActividadEcoInt = Convert.ToInt32(cboActividadInternaNat.SelectedValue);
                int idActividadEcoAdic = Convert.ToInt32(cboActividadInternaNatAd.SelectedValue);
                int idRolHogar = 0;
                int idSegmentoSocio = 0;
                int idEstadoContribuyenteNat = Convert.ToInt32(cboEstadoContribNat.SelectedValue);
                int idConDomicilio = Convert.ToInt32(cboCondDomNat.SelectedValue);
                DateTime dFechaEstCon = dtpFechaEstadoConNat.Value;
                //=======================================================================
                //Guardar Datos de Persona Natural
                //=======================================================================
                clsCNGuardaCliPerNat GuardaCliNat = new clsCNGuardaCliPerNat();
                if (pcTipOpe == "N")
                {
                    DataTable dtIdCliente = GuardaCliNat.GuardarCliPerNat(tcNombCliente, Convert.ToInt32(tcTipDoc), Convert.ToInt32(tcTipPer), tcDocIde,
                                                                        tcDocAdi, Convert.ToInt32(tcTipDocAdi), Convert.ToInt32(tcNacionalidad), Convert.ToInt32(tcTipRes),
                                                                        Convert.ToInt32(tcPaisRes), idCodCiudad, tcTelef, tcTelef2,
                                                                        cNumTel3, tcCorreo, cCorreoAdicional,
                                                                        Convert.ToInt32(tcIdActEcoN), xmlDirec, tcApePat, tcApeMat,
                                                                        tcApeCas, tcNom1, tcNom2, tcNom3,
                                                                        tdFecNac, tnCodUbi, Convert.ToInt32(tcSexo), Convert.ToInt32(tcEstCiv),
                                                                        Convert.ToInt32(tcEstCivSBS), Convert.ToInt32(tcProf), tcDesProfesion, Convert.ToInt32(tcNivInst), Convert.ToInt32(tcOcup),
                                                                        Convert.ToInt32(tcidCargo), tcDesCargo, xmlVinc, Convert.ToInt32(tcNumHijos),
                                                                        Convert.ToInt32(tcNumPerDepend), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,
                                                                        clsVarGlobal.nIdAgencia, Convert.ToInt32(tcTipClasif), lIndDatBasico, dFecIniActEcoNat,
                                                                        idEstadoCliNat, idActividadEcoInt, idActividadEcoAdic, idRolHogar, idSegmentoSocio, idMagnitudEmpresarial,
                                                                        idEstadoContribuyenteNat, idConDomicilio, dFechaEstCon, tcDigVerificador);

                    MessageBox.Show("Los Datos del Cliente se Registraron Correctamente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.conBusCliente.txtCodInst.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(0, 3);
                    this.conBusCliente.txtCodAge.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(3, 3);
                    this.conBusCliente.txtCodCli.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(6);
                    this.conBusCliente.txtNroDoc.Text = dtIdCliente.Rows[0]["cDocumentoID"].ToString();
                    this.conBusCliente.txtNombre.Text = dtIdCliente.Rows[0]["cNombre"].ToString();
                    this.conBusCliente.txtDireccion.Text = dtIdCliente.Rows[0]["cDireccion"].ToString();
                    this.conBusCliente.txtCodCli.Enabled = false;
                    

                    // Validar la existencia en Lista de PEP (En Base de Datos)
                    if (!chcBeneficiario.Checked)
                    {
                        conSplaf1.validaClientePep(Convert.ToInt32(tcTipDoc), tcDocIde, 0);
                        if (conSplaf1.Text.Length > 4)//Es cliente PEP, Entonces Actualizar Datos PEP
                        {
                            ActualizarDatosPEP();
                        }
                        else
                        {
                            //if (conSplaf1.Text.Length <= 2 && rbtnTrue.Checked == true)//EL cliente señala que es PEP, pero no existe en la Base de Datos
                            if (conSplaf1.Text.Length <= 2 && checkPep.Checked)
                            {
                                ActualizarDatosPEP();
                            }
                        }

                        // EVALUACION SCORING NUEVOS naturales
                        frmEvaluacionClientes evaluacionClientes = new frmEvaluacionClientes(Convert.ToInt32(conBusCliente.txtCodCli.Text), 1);
                        evaluacionClientes.ShowDialog();
                    }
                }
                else if (pcTipOpe == "A")
                {
                    int xidCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);
                    DateTime dFechaFallecimiento = clsVarGlobal.dFecSystem;
                    if (idEstadoCliNat == 2)//Estado:Fallecido
                    {
                        dFechaFallecimiento = dtpFecFallec.Value;
                    }
                    if (conBusCliente.txtCodCli.Text.Trim() == "")
                    {
                        MessageBox.Show("Primero debe Buscar los Datos del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dsDir.Dispose();
                        dsVin.Dispose();
                        return;
                    }
                    //=====================================================================
                    //--Actualizar Datos del Cliente (NATURAL)
                    //=====================================================================
                    GuardaCliNat.ActualizarCliPerNat(xidCli, tcNombCliente, Convert.ToInt32(tcTipDoc), Convert.ToInt32(tcTipPer),
                                                     tcDocIde, tcDocAdi, Convert.ToInt32(tcTipDocAdi), Convert.ToInt32(tcNacionalidad),
                                                     Convert.ToInt32(tcTipRes), Convert.ToInt32(tcPaisRes), idCodCiudad, tcTelef, tcTelef2,
                                                     cNumTel3, tcCorreo, cCorreoAdicional, Convert.ToInt32(tcIdActEcoN), xmlDirec, tcApePat,
                                                     tcApeMat, tcApeCas, tcNom1, tcNom2,
                                                     tcNom3, tdFecNac, tnCodUbi, Convert.ToInt32(tcSexo),
                                                     Convert.ToInt32(tcEstCiv), Convert.ToInt32(tcEstCivSBS), Convert.ToInt32(tcProf), tcDesProfesion, Convert.ToInt32(tcNivInst),
                                                     Convert.ToInt32(tcOcup), Convert.ToInt32(tcidCargo), tcDesCargo, dFecIniActEcoNat, xmlVinc,
                                                     Convert.ToInt32(tcNumHijos), Convert.ToInt32(tcNumPerDepend), clsVarGlobal.dFecSystem,
                                                     clsVarGlobal.User.idUsuario, Convert.ToInt32(tcTipClasif), lIndDatBasico, idEstadoCliNat, idActividadEcoInt, idActividadEcoAdic, idRolHogar, idSegmentoSocio, cCodSBS,
                                                     idMagnitudEmpresarial, dFechaFallecimiento, idEstadoContribuyenteNat, idConDomicilio, dFechaEstCon, tcDigVerificador);
                    MessageBox.Show("Los Datos del Cliente se Actualizaron Correctamente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Validar la existencia en Lista de PEP (En Base de Datos)
                     if (!chcBeneficiario.Checked)
                    {
                    conSplaf1.validaClientePep(Convert.ToInt32(tcTipDoc), tcDocIde, xidCli);
                    if (conSplaf1.Text.Length > 4)//Es cliente PEP, Entonces Actualizar Datos PEP
                    {
                        ActualizarDatosPEP();
                    }
                    else
                    {
                        if (conSplaf1.Text.Length <= 2 && checkPep.Checked)
                        {
                            ActualizarDatosPEP();
                        }                            
                    }
                    // EVALUACION SCORING RECURRENTE naturales
                    frmEvaluacionClientes evaluacionClientes = new frmEvaluacionClientes(Convert.ToInt32(conBusCliente.txtCodCli.Text), 3);
                    evaluacionClientes.ShowDialog();
                   }
                }


                //Validacion de Declaracion Jurada de Sujetos Obligados
                if (!chcBeneficiario.Checked)
                {
                    frmDeclaracionJurada declara = new frmDeclaracionJurada(Convert.ToInt32(this.conBusCliente.txtCodCli.Text));
                    this.btnEditar.Focus();
                    this.btnCancelar.Enabled = true;
                }

            }
            else if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
            {
                int nIdEstado = 1; //  1==> Indica OK ,que la zona, oficina y partida registral se ingresaron y no falta nada por regularizar
                //  0==> Indica que esos doc. faltan regularizar


                if (ValidarDatos_PerJuridica() == "ERROR")
                {
                    return;
                }
                if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 1 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 2)
                {
                    if (Convert.ToInt32(cboZonaRegistral1.SelectedValue) == 0)
                    {
                        nIdEstado = 0;
                    }
                }

                //=======================================================================
                //Obtener Datos de Persona Jurídica
                //=======================================================================
                string tcRazSoc = txtRazSocial.Text.Trim();
                string tcNomCom = txtNomComercial.Text.Trim();
                string tcSiglas = txtSiglas.Text.Trim();
                string tcIdActEcoJ = "0";
                if (cboActividadEco3.Text != "")
                    tcIdActEcoJ = cboActividadEco5.SelectedValue.ToString().Trim();
                string tcIdZonaReg = "0";
                if (cboZonaRegistral2.Text != "")
                    tcIdZonaReg = cboZonaRegistral2.SelectedValue.ToString();
                DateTime tdFecConst = dtpFecCons.Value;
                string tcTipIdentif = "1";
                if (cboTipoIdentificacionPerJur.Text != "")
                    tcTipIdentif = cboTipoIdentificacionPerJur.SelectedValue.ToString();
                string tcNumPartReg = txtNumPartReg.Text.Trim();
                string tcEmpleador = "";
                if (this.checkEmpleador.Checked == true)
                    tcEmpleador = "1";
                else
                    tcEmpleador = "0";
                string tcCantEmpleados = txtCantEmpl.Text.Trim();
                DateTime? tdFechaIniAct = dtpFecIniActEco.Value;
                if (dtpFecIniActEco.Text == " ")
                {
                    tdFechaIniAct = null;
                }
                int idActividadEcoIntJur = Convert.ToInt32(cboActividadInternaJur.SelectedValue);
                int idCondDomicilio = Convert.ToInt32(cboCondDomicilio.SelectedValue);
                int idEstadoCliJur = Convert.ToInt32(cboEstadoCliJur.SelectedValue);
                idMagnitudEmpresarial = Convert.ToInt32(cboMagnitudEmpresarial1.SelectedValue);
                int idEstadoContribuyenteJur = Convert.ToInt32(cboEstadoContribuyenteJur.SelectedValue);
                DateTime dFechEstCont = dtpFecEstConJur.Value;

                //=======================================================================
                //Guardar Datos de Persona Jurídica
                //=======================================================================
                clsCNGuardaCliPerJur GuardarCliJur = new clsCNGuardaCliPerJur();
                if (pcTipOpe == "N")
                {
                    DataTable dtIdCliente = GuardarCliJur.GuardarCliPerJur(Convert.ToInt32(tcNacionalidad), Convert.ToInt32(tcTipRes), Convert.ToInt32(tcPaisRes), tcRazSoc,
                                                                           Convert.ToInt32(tcTipDoc), Convert.ToInt32(tcTipPer), tcDocIde, tcTelef,
                                                                           tcTelef2, tcCorreo, Convert.ToInt32(tcIdActEcoJ), xmlDirec,
                                                                           tcRazSoc, tcNomCom, tdFecConst, tdFechaIniAct, tcNumPartReg,
                                                                           Convert.ToInt32(tcIdZonaReg), Convert.ToInt32(tcTipIdentif), tcSiglas, nIdEstado,
                                                                           xmlVinc, Convert.ToInt32(tcEmpleador), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,
                                                                           clsVarGlobal.nIdAgencia, Convert.ToInt32(tcTipClasif), Convert.ToInt32(tcCantEmpleados),
                                                                           idActividadEcoIntJur, idCondDomicilio, cNumTel3, idCodCiudad, cCorreoAdicional, idEstadoCliJur,
                                                                           idMagnitudEmpresarial, idEstadoContribuyenteJur, dFechEstCont);

                    MessageBox.Show("Los Datos del Cliente se Registraron Correctamente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.conBusCliente.txtCodInst.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(0, 3);
                    this.conBusCliente.txtCodAge.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(3, 3);
                    this.conBusCliente.txtCodCli.Text = dtIdCliente.Rows[0]["cCodCliente"].ToString().Substring(6);
                    this.conBusCliente.txtNroDoc.Text = dtIdCliente.Rows[0]["cDocumentoID"].ToString();
                    this.conBusCliente.txtNombre.Text = dtIdCliente.Rows[0]["cNombre"].ToString();
                    this.conBusCliente.txtDireccion.Text = dtIdCliente.Rows[0]["cDireccion"].ToString();
                    this.conBusCliente.txtCodCli.Enabled = false;

                    //CALIFICACION SCORING NUEVOS JURIDICOS
                    if (!chcBeneficiario.Checked)
                    {
                        frmEvaluacionClientes evaluacionClientes = new frmEvaluacionClientes(Convert.ToInt32(conBusCliente.txtCodCli.Text), 2);
                        evaluacionClientes.ShowDialog();
                    }
                }
                else if (pcTipOpe == "A")
                {
                    int xidCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);
                    DateTime dFechaInactiv = clsVarGlobal.dFecSystem; ;
                    if (idEstadoCliJur == 4)//Estado: Inactivo
                    {
                        dFechaInactiv = dtpFecInact.Value;
                    }
                    if (conBusCliente.txtCodCli.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe Primero Buscar los Datos del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dsDir.Dispose();
                        dsVin.Dispose();
                        return;
                    }
                    //=======================================================================
                    //Actualizar Datos de Persona Jurídica
                    //=======================================================================
                    GuardarCliJur.ActualizarCliPerJur(xidCli, Convert.ToInt32(tcNacionalidad), Convert.ToInt32(tcTipRes), Convert.ToInt32(tcPaisRes),
                                                      tcRazSoc, Convert.ToInt32(tcTipDoc), Convert.ToInt32(tcTipPer), tcDocIde,
                                                      tcTelef, tcTelef2, tcCorreo, Convert.ToInt32(tcIdActEcoJ),
                                                      xmlDirec, tcRazSoc, tcNomCom, tdFecConst, tdFechaIniAct,
                                                      tcNumPartReg, Convert.ToInt32(tcIdZonaReg), Convert.ToInt32(tcTipIdentif), tcSiglas,
                                                      nIdEstado, xmlVinc, Convert.ToInt32(tcEmpleador), clsVarGlobal.dFecSystem,
                                                      clsVarGlobal.User.idUsuario, Convert.ToInt32(tcTipClasif), Convert.ToInt32(tcCantEmpleados),
                                                      idActividadEcoIntJur, idCondDomicilio, cNumTel3, idCodCiudad, cCorreoAdicional, idEstadoCliJur, cCodSBS,
                                                      idMagnitudEmpresarial, dFechaInactiv, idEstadoContribuyenteJur, dFechEstCont);

                    MessageBox.Show("Los Datos del Cliente se Actualizaron Correctamente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!chcBeneficiario.Checked)
                    {
                        frmEvaluacionClientes evaluacionClientes = new frmEvaluacionClientes(Convert.ToInt32(conBusCliente.txtCodCli.Text), 4);
                        evaluacionClientes.ShowDialog();
                    }
                }

                //Validacion de Declaracion Jurada de Sujetos Obligados
                frmDeclaracionJurada declara = new frmDeclaracionJurada(Convert.ToInt32(this.conBusCliente.txtCodCli.Text));
                this.btnEditar.Focus();
                this.btnCancelar.Enabled = true;


            }
            if (checkFatca.Checked == true)
            {
                frmRegistroFACTA frmRegistroFACTA = new frmRegistroFACTA();
                frmRegistroFACTA.idCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);
                frmRegistroFACTA.ShowDialog();
            }
            pcTipOpe = "O";
            Buscar();
            //=====================================================
            //--Liberar Variables
            //=====================================================
            dsDir.Clear();
            dsDir.Dispose();
            dsVin.Clear();
            dsVin.Dispose();

            //=====================================================
            //--Habilitar y Desabilitar Controles
            //=====================================================
            conBusCliente.btnBusCliente.Enabled = true;
            HabilitarControles_Gen(false);
            HabilitarControles_PerNat(false);
            HabilitarControles_PerJur(false);
            HabilitarControles_Vinculo(false);
            HabilitarGridDireccion(false);
            conBusCliVin.btnBusCliente.Enabled = false;

            btnSolActualizacion.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = true;
            tbcCliente.SelectedIndex = 0;
            cboEstadoCliJur.Enabled = false;
            cboEstadoCliNat.Enabled = false;
            btnMiniActVinc.Enabled = false;
            btnMiniNueVinc.Enabled = false;
            btnMiniActDir.Enabled = false;
            btnMiniNuevoDir.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnAgrVinc.Enabled = false;
            btnQuiVinc.Enabled = false;
            btnRegNumTelf.Enabled = false;
            cboTipoDir.SelectedIndex = -1;

            this.epVerificado.Clear();
            this.lblActualizacion.Visible = false;

            this.AlertaDatosSencibles();
            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCliente.idCli, this.conBusCliente.idCli, "Fin-Mantenimiento de cuenta", this.btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        /// <summary>
        /// Permite habilitar el formualrio para actualizar los datos PEP del Cliente (Persona Natural) identificado.
        /// </summary>
        private void ActualizarDatosPEP()
        {
            string cCargo = (Convert.ToInt32(cboClienteCargo1.SelectedValue) != 37) ? ((DataTable)cboClienteCargo1.DataSource).Rows[cboClienteCargo1.SelectedIndex]["cClienteCargo"].ToString() : txtOtrosDesc.Text;

            DataTable dtRpta = conSplaf1.MarcarComoRegistroPEPPendiente(Convert.ToInt32(conBusCliente.txtCodCli.Text), conBusCliente.txtNroDoc.Text,
                                                                                   txtApePat.Text, txtApeMat.Text, (txtNom1.Text + " " + txtNom2.Text), dtFecNac.Value, Convert.ToInt32(cboTipDocumento.SelectedValue)
                                                                                   , cCargo);
            if (Convert.ToInt32(dtRpta.Rows[0][0]) == -1)//No se ha logrado insertar
            {
                MessageBox.Show("No se ha podido actualizar a pendiente PEP", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Habilitar formulario para que se actualize estado Registro PEP de Pendiente a Finalizado (1-2)
            frmPep formularioPEP = new frmPep(Convert.ToInt32(cboTipDocumento.SelectedValue), conBusCliente.txtNroDoc.Text);
            formularioPEP.idEstadoRegistro = 2;//para pasar de Pendiente a Finalizado
            formularioPEP.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
            tbDirCli.Rows.Clear();
            tbClienteVinculado.Rows.Clear();
            conBusCliente.txtCodAge.Clear();
            conBusCliente.txtCodInst.Clear();
            conBusCliente.txtCodCli.Clear();
            conBusCliente.txtNroDoc.Clear();
            conBusCliente.txtNombre.Clear();
            conBusCliente.txtDireccion.Clear();
            conBusCliente.txtCodCli.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = false;
            LimpiarControles();
            HabilitarControles_Gen(true);
            HabilitarControles_PerNat(true);
            HabilitarControles_PerJur(true);
            HabilitarControles_Vinculo(true);

            HabilitarGridDireccion(true);

            btnSolActualizacion.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnImprimir.Enabled = false;

            chcBeneficiario.Enabled = true;

            this.RdBtnNacionPer.Checked = true;
            this.cboTipoResidencia1.SelectedValue = 1;
            this.cboTipPersona.SelectedValue = 1;
            this.cboCodCiudad.SelectedValue = 7;
            conBusUbiNac.CambioDeIndex -= conBusUbiNac_CambioDeIndex;
            this.conBusUbiNac.cboPais.SelectedValue = 173;
            conBusUbiNac.CambioDeIndex += conBusUbiNac_CambioDeIndex;
            this.txtCodSBS.Enabled = false;
            txtCBDoc.Focus();
            tbcCliente.SelectedIndex = 0;
            btnAgregar.Enabled = true;
            btnAgrVinc.Enabled = false;
             //Control de objetos al iniciar el evento nuevo
            this.activarControlObjetos(this, EventoFormulario.NUEVO);
            //========================================================

            //Para personas jurídicas
            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
            {
                checkPep.Enabled = false;
                cboEstadoCliJur.Enabled = false;
                cboEstadoCliJur.SelectedIndex = 0;

            }
            //para personas naturales
            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
            {
                checkPep.Enabled = true;

                checkPep.Checked = false;

                grbBase12.Enabled = true;
                checkFatca.Enabled = true;
                checkFatca.Checked = false;
            }
            CargarUbigeobPorDefecto_DomicilioCliente();
            CargarUbigeobPorDefecto_LugarNacCliente();
            btnMiniActVinc.Enabled = true;
            btnMiniNueVinc.Enabled = true;
            conBusCliVin.btnBusCliente.Enabled = true;
            conBusCliVin.txtCodCli.Enabled = true;
            conBusCliVin.Enabled = true;
            txtPorCapSocVot.Enabled = true;
            txtPorCapSocVot.Visible = false;
            lblPorCapSocVot.Visible = false;
            grbBase11.Enabled = true;
            cboTipoCategoriaNat.Enabled = false;
            btnRegNumTelf.Enabled = true;
            habilitarFatca();

            HabilitarBusReniec = 1;
            this.cboTipClasificacion.SelectedValue = 2;
            this.txtProfesion.Enabled = false;
            this.txtOtrosDesc.Enabled = false;
            this.cboClienteCargo1.SelectedValue = 36;

            AutocompletarUbigeo();
        }

        private void CargarUbigeobPorDefecto_DomicilioCliente()
        {
        }

        private void CargarUbigeobPorDefecto_LugarNacCliente()
        {
            //*************************** Cargar por defecto Lima Departamento y Provincia *****************************
            DataTable dtDepartamento = (DataTable)conBusUbiNac.cboDepartamento.DataSource;
            for (int i = 0; i < dtDepartamento.Rows.Count; i++)
            {
                if (dtDepartamento.Rows[i]["cDescipcion"].ToString().ToUpper().TrimStart().TrimEnd().Equals("PUNO"))
                {
                    conBusUbiNac.cboDepartamento.SelectedIndex = i;
                    break;
                }
            }

            DataTable dtProvincia = (DataTable)conBusUbiNac.cboProvincia.DataSource;
            for (int i = 0; i < dtProvincia.Rows.Count; i++)
            {
                if (dtProvincia.Rows[i]["cDescipcion"].ToString().ToUpper().TrimStart().TrimEnd().Equals("PUNO"))
                {
                    conBusUbiNac.cboProvincia.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtpFecIniActEcoNat.ValueChanged -= new System.EventHandler(dtpFecIniActEcoNat_ValueChanged);
            HabilitarBusReniec = 0;

            pcTipOpe = "O";
            HabilitarControles_Gen(false);
            HabilitarControles_PerNat(false);
            HabilitarControles_PerJur(false);
            HabilitarControles_Vinculo(false);
            conBusCliente.txtCodAge.Clear();
            conBusCliente.txtCodInst.Clear();
            conBusCliente.txtCodCli.Clear();
            conBusCliente.txtNroDoc.Clear();
            conBusCliente.txtNombre.Clear();
            conBusCliente.txtDireccion.Clear();
            conBusCliente.btnBusCliente.Enabled = true;

            LimpiarControles();

            cboEstadoContribNat.Enabled = false;
            cboCondDomNat.Enabled = false;
            dtpFechaEstadoConNat.Enabled = false;
            cboEstadoContribuyenteJur.Enabled = false;
            tbDirCli.Rows.Clear();
            tbClienteVinculado.Rows.Clear();
            conBusCliVin.btnBusCliente.Enabled = false;
            conBusCliVin.txtCodCli.Enabled = false;
            btnSolActualizacion.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = false;
            chcBeneficiario.Checked = false;
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.txtCodCli.Focus();
            idDirecNueva = 0;

            conSplaf1.Text = "";
            checkPep.Enabled = false;
            checkPep.Checked = false;
            checkFatca.Enabled = false;
            checkFatca.Checked = false;
            chcBeneficiario.Enabled = false;
            cboEstadoCliJur.Enabled = false;
            cboEstadoCliNat.Enabled = false;
            dtpFecEstConJur.Enabled = false;
            this.txtCodSBS.Enabled = false;
            btnMiniActDir.Enabled = false;
            btnMiniNuevoDir.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnMiniNueVinc.Enabled = false;
            btnMiniActVinc.Enabled = false;
            btnQuiVinc.Enabled = false;
            btnAgrVinc.Enabled = false;
            dtpFecFallec.Enabled = false;
            dtpFecInact.Enabled = false;
            dtpFecFallec.Visible = false;
            dtpFecInact.Visible = false;
            lblBase83.Visible = false;
            lblBase78.Visible = false;
            checkFatca.Checked = false;
            cboClienteCargo1.SelectedIndex = -1;
            cboClienteCargo1.Enabled = false;
            this.btnMiniBusqCargo.Enabled = false;

            conBusCliVin.Enabled = false;
            cboTipVinculo.Enabled = false;
            cboTipVinculo.SelectedIndex = -1;
            dtpFecIni.Enabled = false;
            dtpFecFin.Enabled = false;
            txtPorCapSocVot.Enabled = false;
            btnRegNumTelf.Enabled = false;

            conAutorizacionUsuDatos1.limpiar();
            cboTipoDir.SelectedIndex = -1;
            this.epProtegido.Clear();
            this.epVerificado.Clear();
            this.lblActualizacion.Visible = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
            {
                int CodigoCliente = Convert.ToInt32(conBusCliente.txtCodCli.Text);
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("pnidCli", CodigoCliente.ToString(), false));
                paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

                dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoCliente(CodigoCliente)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsDatosPepCliente", cnpep.DatosPepCliente(CodigoCliente)));


                string reportpath = "rptFichaCli.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            else
            {
                int CodigoCliente = Convert.ToInt32(conBusCliente.txtCodCli.Text);
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idCli", CodigoCliente.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoClienteJur(CodigoCliente)));


                string reportpath = "rptClienteFichaJuri.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }

        }
        private bool ValidarCliVinc()
        {
            if (conBusCliVin.txtCodCli.Text.Trim() == conBusCliente.txtCodCli.Text.Trim())
            {
                MessageBox.Show("Vinculación Inválida, No se puede vincular con uno mismo", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCliVin.Focus();
                return false;
            }


            if (cboTipVinculo.SelectedValue == null || cboTipVinculo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Vínculo", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipVinculo.Focus();
                return false;
            }


            if ((Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3))
            {

                if (dtpFecIni.Value < dtpFecCons.Value)
                {
                    MessageBox.Show("La Fecha de Inicio del Vinculo, NO Puede ser Anterior a la Fecha de Constitución de la Empresa", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFecIni.Focus();
                    return false;
                }
                if (Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()) > Convert.ToDateTime(pdFecSistem.ToShortDateString()))
                {
                    MessageBox.Show("La Fecha de Inicio del Vinculo, NO Puede ser Posterior a la Fecha de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFecIni.Focus();
                    return false;
                }

                if (dtpFecIniActEco.Text != " " && dtpFecIniActEco.Value < dtpFecCons.Value)
                {
                    MessageBox.Show("La Fecha de Inicio de la actividad económica de la persona jurídica, NO Puede ser Anterior a la Fecha de Constitución de la Empresa", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFecIni.Focus();
                    return false;
                }
                if (cboTipVinculo.SelectedValue.ToString().Trim() == "2")
                {
                    if (Convert.ToDateTime(dtpFecFin.Value.ToShortDateString()) < Convert.ToDateTime(pdFecSistem.ToShortDateString()))
                    {
                        MessageBox.Show("El periodo de representación debe estar Vigente, la fecha Final no puede ser Menor a la Fecha de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecIni.Focus();
                        return false;
                    }
                    if (dtpFecIni.Value > dtpFecFin.Value)
                    {
                        MessageBox.Show("La Fecha de Inicio del Vinculo, NO Puede ser Posterior a la Fecha Final", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecIni.Focus();
                        return false;
                    }

                    int DiferfDias = (Convert.ToDateTime(dtpFecFin.Value) - Convert.ToDateTime(dtpFecIni.Value)).Days;

                    if (DiferfDias < 15)
                    {
                        MessageBox.Show("El periodo de Representación de la Empresa no puede ser menor a 15 días", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecIni.Focus();
                        return false;
                    }

                }
                if (cboTipVinculo.SelectedValue.ToString().Trim() == "11")
                {
                    if (txtPorCapSocVot.Text == "0.00" || txtPorCapSocVot.Text == "0" || txtPorCapSocVot.Text == "")
                    {
                        MessageBox.Show("El porcentaje del capital social no puede ser 0.00", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPorCapSocVot.Focus();
                        return false;
                    }
                }

            }


            clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
            string cValidacion = "";
            string idSexo = "";
            if (!string.IsNullOrEmpty(conBusCliVin.txtCodCli.Text.Trim()))
            {
                cValidacion = xRetDatCli.RetDatVal(Convert.ToInt32(conBusCliVin.txtCodCli.Text.Trim()), "", "E", 0);
                idSexo = xRetDatCli.RetDatVal(Convert.ToInt32(conBusCliVin.txtCodCli.Text.Trim()), "", "S", 0);
            }
            //======================================================================
            //--Validar Duplicidad de Clientes (Documentos Duplicado)
            //======================================================================
            if (Convert.ToInt32(cboTipVinculo.SelectedValue.ToString()) == 2)
            {
                if (cValidacion == "ERROR")
                {
                    MessageBox.Show("El Cliente Buscado es Menor de Edad, debe ser mayor de 18 Años", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCliVin.btnBusCliente.Focus();
                    return false;
                }
            }
            //======================================================================
            //--Validar sexo del conyuge
            //======================================================================
            if (Convert.ToInt32(cboTipVinculo.SelectedValue.ToString()) == 1)
            {
                if (cboSexo.Text == "")
                {
                    MessageBox.Show("Seleccione el género del Cliente: Masculino o Femenino, para poder Validar al Cónyugue", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboSexo.Focus();
                    return false;
                }
                if (idSexo == cboSexo.SelectedValue.ToString())
                {
                    MessageBox.Show("No se Puede Vincular a Dos personas del mismo Sexo mediante el Vinculo Cónyugue", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCliVin.btnBusCliente.Focus();
                    return false;
                }
            }
            //======================================================================
            //--Validar sexo del concubino(a)
            //======================================================================
            if (Convert.ToInt32(cboTipVinculo.SelectedValue.ToString()) == 3)
            {
                if (cboSexo.Text == "")
                {
                    MessageBox.Show("Seleccione el género del Cliente: Masculino o Femenino, para poder Validar el Vícnulo Concubino(a)", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboSexo.Focus();
                    return false;
                }
                if (idSexo == cboSexo.SelectedValue.ToString())
                {
                    MessageBox.Show("No se Puede Vincular a Dos personas del mismo Sexo mediante el Vinculo Concubino(a)", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCliVin.btnBusCliente.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnAgrVinc_Click(object sender, EventArgs e)
        {
            if (conBusCliVin.txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe Buscar Primero al Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCliVin.btnBusCliente.Focus();
                return;
            }
            if (!ValidarCliVinc())
            {
                return;
            }
            //Validar Duplicidad de clientes
            int nContIdVinc = 0;
            for (int i = 0; i < dtgVinculo.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgVinculo.Rows[i].Cells["idTipoVinculo"].Value.ToString()) == 1 || Convert.ToInt32(dtgVinculo.Rows[i].Cells["idTipoVinculo"].Value.ToString()) == 3)
                {
                    nContIdVinc++;

                    if (nContIdVinc > 0)
                    {
                        if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 1 || Convert.ToInt32(cboTipVinculo.SelectedValue) == 3)
                        {
                            MessageBox.Show("El Cliente ya tiene Vinculado al Cónyuge o Concubino(a)", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.cboTipVinculo.Focus();
                            return;
                        }
                    }
                }
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)//Personas naturales
                {
                    if (Convert.ToInt32(conBusCliVin.txtCodCli.Text.Trim()) == Convert.ToInt32(dtgVinculo.Rows[i].Cells["idCliVin"].Value))
                    {
                        MessageBox.Show("El Cliente ya se encuentra Vinculado a esta Persona", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCliVin.btnBusCliente.Focus();
                        return;
                    }
                }
                if (Convert.ToInt32(cboTipPersona.SelectedValue) > 1)//Personas juridicas
                {
                    if (Convert.ToInt32(conBusCliVin.txtCodCli.Text.Trim()) == Convert.ToInt32(dtgVinculo.Rows[i].Cells["idCliVin"].Value))
                        if (Convert.ToInt32(cboTipVinculo.SelectedValue) == Convert.ToInt32(dtgVinculo.Rows[i].Cells["idTipoVinculo"].Value))
                        {
                            MessageBox.Show("El Cliente ya se encuentra Vinculado a esta Persona con el mismo Tipo de Vinculo", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conBusCliVin.btnBusCliente.Focus();
                            return;
                        }
                }

            }
            int SumaPorcentaje = 0; 
            for ( int i = 0 ; i < tbClienteVinculado.Rows.Count; i++)
            {
                 SumaPorcentaje = SumaPorcentaje +  Convert.ToInt32(tbClienteVinculado.Rows[i]["nPorCapSocVot"]);
            }

            if (SumaPorcentaje == 100)
            {
                MessageBox.Show("El porcentaje de las acciones de la empresa ya llegaron al 100%", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtPorCapSocVot.Text != "" && txtPorCapSocVot.Visible == true)
            {
                if (SumaPorcentaje + Convert.ToDouble(txtPorCapSocVot.Text) > 100) //aqui el error 
                {
                    MessageBox.Show("El porcentaje de las acciones no puede superar el 100%", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            //agrego hasta aqui la validacion -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           
            if (dtpFecFin.Visible == false)
            {
                dtgVinculo.Columns["dFechaFinal"].Visible = false;
            }
            else
            {
                dtgVinculo.Columns["dFechaFinal"].Visible = true;
            }
            //======================================================================
            //--Agregar Registro de Vinculo al Grid
            //======================================================================
            DataRow dr = tbClienteVinculado.NewRow();

            dr["idCliVin"] = conBusCliVin.txtCodCli.Text.Trim();
            dr["cNombre"] = conBusCliVin.txtNombre.Text.Trim();
            dr["dFechaInicio"] = dtpFecIni.Value;
            dr["dFechaFinal"] = dtpFecFin.Value;
            dr["idTipoVinculo"] = cboTipVinculo.SelectedValue;
            dr["cTipoVinculo"] = cboTipVinculo.Text.Trim();
            dr["nPorCapSocVot"] = txtPorCapSocVot.nDecValor;
            dr["cDocumentoID"] = conBusCliVin.txtNroDoc.Text.Trim();

            dr["Estado"] = "N";
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                dr["idCli"] = 0;
            }
            else
            {
                dr["idCli"] = conBusCliente.txtCodCli.Text.Trim();
            }
            tbClienteVinculado.Rows.Add(dr);
            dtgVinculo.DataSource = tbClienteVinculado;

            btnAgrVinc.Enabled = false;
            btnMiniNueVinc.Enabled = true;
            btnQuiVinc.Enabled = true;
            btnMiniActVinc.Enabled = true;
            conBusCliVin.btnBusCliente.Enabled = false;
            conBusCliVin.txtCodCli.Enabled = false;
            //============================================================
            //--Limpiar Datos
            //============================================================
            LimpiarCamposDir(true);

        }
        private void LimpiarVinculados()
        {
            conBusCliVin.txtCodAge.Text = "";
            conBusCliVin.txtCodInst.Text = "";
            conBusCliVin.txtCodCli.Text = "";
            conBusCliVin.txtNroDoc.Text = "";
            conBusCliVin.txtNombre.Text = "";
            conBusCliVin.txtDireccion.Text = "";
            txtPorCapSocVot.Clear();
            dtpFecIni.Value = pdFecSistem;
            dtpFecFin.Value = pdFecSistem;
            conBusCliVin.txtCodCli.Enabled = true;
            conBusCliVin.btnBusCliente.Focus();
        }
        private void btnQuiVinc_Click(object sender, EventArgs e)
        {
            int nContador;
            nContador = dtgVinculo.Rows.Count;
            if (nContador == 0)
            {
                MessageBox.Show("No Existe Registro a Eliminar", "Registro de Clientes");
                return;
            }
            else
            {
                if (dtgVinculo.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe de seleccionar Registro que desea Eliminar", "Registro de Clientes");
                    return;
                }
                else
                {
                    int nFila = Convert.ToInt32(dtgVinculo.SelectedCells[0].RowIndex);
                    tbClienteVinculado.Columns["Estado"].ReadOnly = false;
                    if (pcTipOpe == "A" && Convert.ToInt32(this.dtgVinculo.SelectedRows[0].Cells["idTipoVinculo"].Value).In(1, 2)) //Conyuge, Representante
                    {
                        MessageBox.Show("La desvinculación mediante Solicitud del Tipo Vinculo: " + this.dtgVinculo.SelectedRows[0].Cells["cTipoVinculo"].Value, "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtgVinculo.Rows[nFila].Cells["Estado"].Value.ToString() == "N")
                    {
                        ((DataTable)dtgVinculo.DataSource).Rows[nFila].Delete();
                        ((DataTable)dtgVinculo.DataSource).AcceptChanges();
                    }
                    else
                    {
                        dtgVinculo.Rows[nFila].Cells["Estado"].Value = "E";
                    }
                    if (dtgVinculo.Rows.Count == 0)
                    {
                        btnMiniActVinc.Enabled = false;
                        btnMiniNueVinc.Enabled = false;
                        btnAgrVinc.Enabled = true;
                    }
                }

            }
            ProcessTabKey(true);
            this.btnQuiVinc.Focus();
            LimpiarVinculados();
            btnMiniNueVinc.Enabled = true;

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBusReniec = 0;

            if (idEstadoCli == 2 || idEstadoCli == 4)
            {

                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                {
                    dtpFecFallec.Visible = true;
                    dtpFecFallec.Enabled = true;
                    lblBase83.Visible = true;
                }
                else
                {
                    pcTipOpe = "A";
                    cboEstadoCliJur.Enabled = true;
                    dtpFecInact.Visible = true;
                    dtpFecInact.Enabled = true;
                    lblBase78.Visible = true;
                }
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnNuevo.Enabled = false;
            }
            else
            {
                pcTipOpe = "A";
                conBusCliente.btnBusCliente.Enabled = false;
                HabilitarControles_Gen(true);
                HabilitarControles_PerNat(true);
                HabilitarControles_PerJur(true);
                HabilitarControles_Vinculo(true);
                HabilitarGridDireccion(true);
                if (cboTipPersona.Text != "")
                {
                    if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                    {
                        chcBeneficiario.Enabled = true;
                    }
                }
                btnSolActualizacion.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
                btnGrabar.Enabled = true;
                btnImprimir.Enabled = false;

                txtCBDoc.Enabled = false;
                cboTipDocumento.Enabled = false;
                cboTipPersona.Enabled = false;

                //Datos de la dirección
                if (Convert.ToInt32(cboTipoZonas.SelectedValue) == 1)
                    this.textZonas.Enabled = false;
                if (Convert.ToInt32(cboTipoVia.SelectedValue) == 1)
                    this.textVia.Enabled = false;
                //Direccion
                btnMiniActDir.Enabled = true;
                btnMiniNuevoDir.Enabled = true;
                btnQuitar.Enabled = true;
                //Vinculados
                btnMiniActVinc.Enabled = true;
                btnMiniNueVinc.Enabled = true;
                btnQuiVinc.Enabled = true;
                btnAgrVinc.Enabled = false;

                //Para tipo de residencia
                if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 1 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 2)
                {
                    this.cboUbigeoPais.Enabled = false;
                }

                //Para personas jurídicas
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
                {
                    this.cboTipVinculo.SelectedValue = 2;
                    this.txtCantEmpl.Enabled = checkEmpleador.Checked;
                    if (Convert.ToInt32(cboZonaRegistral1.SelectedValue) == 0)
                    {
                        this.cboZonaRegistral2.Enabled = false;
                        this.cboTipoIdentificacionPerJur.Enabled = false;
                        this.txtNumPartReg.Enabled = false;
                    }
                    if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 4)
                    {
                        this.cboZonaRegistral1.Enabled = false;
                    }

                    this.cboEstadoCliJur.Enabled = true;
                    checkPep.Enabled = false;
                }
                //para personas naturales
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                {
                    if (Convert.ToInt32(cboClienteCargo1.SelectedValue) != 37)
                        this.txtOtrosDesc.Enabled = false;
                    if (Convert.ToInt32(cboProfesion.SelectedValue) != 145)
                        this.txtProfesion.Enabled = false;

                    this.dtpFecIni.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecIni.Visible = false;
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecFin.Visible = false;

                    checkPep.Enabled = true;
                    cboEstadoCliNat.Enabled = true;
                }
                RdBtnNacionPer.Enabled = false;
                RdBtnNacionExt.Enabled = false;

                // Control de objetos al iniciar el evento nuevo
                this.activarControlObjetos(this, EventoFormulario.EDITAR);


                //========================================================
                //Edicion de tipo de documento en caso del cliente que cumple la mayoría de edad
                //========================================================

                int idCli = Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim());
                DataTable dtValActCli = objDeposito.CNValidarActDatCli(idCli);
                if (Convert.ToBoolean(dtValActCli.Rows[0]["lReqUpdate"]))
                {
                    cboTipDocumento.Enabled = true;
                    txtCBDoc.Enabled = true;
                }
                //en caso de las direcciones
                if (dtgDireccion.Rows.Count > 0)
                {
                    btnMiniActDir.Enabled = true;
                    dtgDireccion.Focus();
                }
                else
                {
                    btnMiniActDir.Enabled = false;
                    btnMiniNuevoDir.Enabled = true;

                }
            }
            btnRegNumTelf.Enabled = true;
            txtPorCapSocVot.Enabled = true;
            grbBase11.Enabled = true;
            cboTipoCategoriaNat.Enabled = false;
            //verificaTipoDocumentoMenorDeEdad();
            habilitarFatca();
            AutocompletarUbigeo();
            this.BloquearDatosSensibles(false);
            // Control de objetos al iniciar el evento nuevo
            this.activarControlObjetos(this, EventoFormulario.EDITAR);
            this.AlertaDatosSencibles();
        }


        private bool alertaActualizaciondir()
        {
            List<string> PendientesAct = new List<string>();
            if (cboTipoDir.Text.Trim() != "") 
            {
                if (cboTipoDir.SelectedValue.ToString().Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idTipoDireccion"].Value).Trim())
                {
                    PendientesAct.Add("Tipo Dirección: " + cboTipoDir.Text);
                }            
            }
            if (cboSector1.Text.Trim() != "") 
            {
                if (cboSector1.SelectedValue.ToString().Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idSector"].Value).Trim())
                {
                    PendientesAct.Add("Sector: " + cboSector1.Text);
                }           
            }
            if (cboTipViviendas.Text.Trim() != "") 
            {
                if (cboTipViviendas.SelectedValue.ToString().Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idTipoVivienda"].Value).Trim())
                {
                    PendientesAct.Add("Tipo Vivienda: " + cboTipViviendas.Text);
                }            
            }

            if (cboTipoZonas.Text.Trim() != "") 
            {
                if (cboTipoZonas.SelectedValue.ToString().Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idTipoZona"].Value).Trim())
                {
                    PendientesAct.Add("Tipo Zona: " + cboTipoZonas.Text);
                }           
            }

            if (cboTipoZonas.Text.Trim() != "")
            { 
                if (textZonas.Text.Trim().Equals(Convert.ToString(dtgDireccion.CurrentRow.Cells["cDesZona"].Value).Trim(),StringComparison.OrdinalIgnoreCase) == false )
                {
                    PendientesAct.Add("Zona: " + textZonas.Text);
                }           
            }

            if (cboTipoVia.Text.Trim() != "") 
            {
                if (cboTipoVia.SelectedValue.ToString().Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idTipoVia"].Value).Trim())
                {
                    PendientesAct.Add("Tipo Vía: " + cboTipoVia.Text);
                }            
            }

            if (textVia.Text.Trim() != "")
            {
                if (textVia.Text.Trim().Equals(Convert.ToString(dtgDireccion.CurrentRow.Cells["cDesVia"].Value).Trim(), StringComparison.OrdinalIgnoreCase) == false)
                {
                    PendientesAct.Add("Vía: " + textVia.Text);
                }           
            }

            if (txtResidencia.Text.Trim() != "")
            {
                if (txtResidencia.Text.Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["nAñoReside"].Value).Trim())
                {
                    PendientesAct.Add("Años Residencia: " + txtResidencia.Text);
                }           
            }

            if (txtCodDirUbi.Text.Trim() != "")
            {
                if (txtCodDirUbi.Text.Trim() != Convert.ToString(dtgDireccion.CurrentRow.Cells["idUbigeo"].Value).Trim())
                {
                    PendientesAct.Add("Dirección Ubi.: " + txtDirUbi.Text);
                }           
            }

            if (txtReferencia.Text.Trim() != "")
            {
                if (txtReferencia.Text.Trim().Equals(Convert.ToString(dtgDireccion.CurrentRow.Cells["cReferenciaDireccion"].Value).Trim(), StringComparison.OrdinalIgnoreCase) == false)
                {
                    PendientesAct.Add("Referencia: " + txtReferencia.Text);
                }          
            }

            if (txtReferencia.Text.Trim() != "")
            { 
                string idGeo;
                if (txtidGeo.Text.Trim() == "")
                {
                    idGeo = "0";
                }
                else
                {
                    idGeo = txtidGeo.Text;
                }

                if (idGeo != Convert.ToString(dtgDireccion.CurrentRow.Cells["idGeolocalizacion"].Value))
                {
                    PendientesAct.Add("Geolocalización: [" + txtLatitud.Text + "] - [" + txtLongitud.Text + "]");
                }           
            }


            if (PendientesAct.Count == 0)
            {
                return true;
            }
            else 
            {
                string message;
                string listaPendientes = string.Join(Environment.NewLine, PendientesAct);
                if (idDirecNueva != 0)
                {
                    message = "Hay Registros que no se ACTUALIZARON: \n\n" + listaPendientes + "\n\n[SI] para continuar y ACTUALIZAR los cambios.\n[NO] para detener proceso.";
                }
                else 
                {
                    message = "Hay Registros que no se GUARDARON: \n\n" + listaPendientes + "\n\n[SI] para continuar y GUARDAR Nueva Dirección.\n[NO] para detener proceso.";
                }
                DialogResult respMsg = MessageBox.Show(message, "Registrar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                bool retorno = false;               
                if (respMsg == DialogResult.Yes)
                {
                    retorno = true;
                }
                else if (respMsg == DialogResult.No)
                {
                    retorno =  false;
                }
                return retorno;
            }
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            this.epProtegido.Clear();
            this.Buscar();
            if(conBusCliente.txtCodCli.Text.Trim() != "")
            {
                this.AlertaDatosSencibles();
            }
        }
        private void cboTipClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipClasificacion.SelectedIndex != -1)
            {
                //Con negocio con ruc
                if ((int)cboTipClasificacion.SelectedValue == 11)
                {
                    cboTipDocAdi.SelectedValue = 4;
                    cboTipDocAdi.Enabled = false;                    
                }
                else
                {
                    //Con negocio sin ruc | Sin negocio 
                    cboTipDocAdi.SelectedIndex = -1;
                    cboTipDocAdi.Enabled = true;                    
                }
            }
        }
        private void RdBtnNacionPer_CheckedChanged(object sender, EventArgs e)
        {
            habilitarFatca();
            if (cboTipPersona.Text != "")
            {
                this.conBusUbiNac.cboPais.SelectedValue = 173;
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1 && RdBtnNacionPer.Checked)
                {
                    this.cboTipDocumento.CargarDocumentos("N");
                    this.cboTipDocumento.SelectedValue = 1;
                    this.cboTipDocAdi.CargarDocumentos("C");
                    this.cboTipDocAdi.SelectedIndex = -1;

                    this.tbcCliente.Controls["tabPer_Natural"].Enabled = true;
                    this.tbcCliente.Controls["tabPer_Juridica"].Enabled = false;

                    if (Convert.ToInt32(cboTipClasificacion.SelectedValue) == 11)
                    {
                        cboTipDocAdi.SelectedValue = 4;
                        cboTipDocAdi.Enabled = false;
                    }

                }
                else if ((Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3) && RdBtnNacionPer.Checked)
                {
                    this.cboTipDocumento.CargarDocumentos("J");
                    this.cboTipDocumento.SelectedValue = 4;
                    this.cboTipDocAdi.CargarDocumentos("J");
                    this.cboTipDocAdi.SelectedIndex = -1;

                    this.tbcCliente.Controls["tabPer_Natural"].Enabled = false;
                    this.tbcCliente.Controls["tabPer_Juridica"].Enabled = true;
                }
            }
        }
        private void RdBtnNacionExt_CheckedChanged(object sender, EventArgs e)
        {
            habilitarFatca();
            if (cboTipPersona.Text != "")
            {
                this.conBusUbiNac.cboPais.SelectedValue = 0;
                if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1 && RdBtnNacionExt.Checked)
                {
                    this.cboTipDocumento.CargarDocumentos("Z");
                    this.cboTipDocAdi.CargarDocumentos("C");
                    cboTipDocAdi.Enabled = true;

                    this.tbcCliente.Controls["tabPer_Natural"].Enabled = true;
                    this.tbcCliente.Controls["tabPer_Juridica"].Enabled = false;

                    if (Convert.ToInt32(cboTipClasificacion.SelectedValue) == 11)
                    {
                        cboTipDocAdi.SelectedValue = 4;
                        cboTipDocAdi.Enabled = false;
                    }

                }
                else if ((Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3) && RdBtnNacionExt.Checked)
                {
                    this.cboTipDocumento.CargarDocumentos("J");
                    this.cboTipDocumento.SelectedValue = 7;
                    this.cboTipDocAdi.CargarDocumentos("J");
                    this.cboTipDocAdi.SelectedIndex = -1;

                    this.tbcCliente.Controls["tabPer_Natural"].Enabled = false;
                    this.tbcCliente.Controls["tabPer_Juridica"].Enabled = true;
                }
            }
        }
        private void cboTipoResidencia1_SelectedIndexChanged_1(object sender, EventArgs e)
        {            
            if (cboTipoResidencia1.Text != "")
            {
                if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3)
                {
                    this.RdBtnNacionExt.Enabled = false;
                    this.RdBtnNacionExt.Checked = false;
                    this.RdBtnNacionPer.Checked = true;
                }
                else
                {
                    this.RdBtnNacionExt.Enabled = true;
                }

                if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 1 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 2)
                {
                    this.cboUbigeoPais.SelectedValue = 173;
                    this.cboUbigeoPais.Enabled = false;
                    this.txtDirUbi.Enabled = true;
                    this.txtDirUbi.Text = string.Empty;

                    if (cboTipPersona.Text != "")
                        if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
                        {
                            this.cboTipoIdentificacionPerJur.SelectedValue = 1;
                            this.cboZonaRegistral1.Enabled = true;
                            this.cboZonaRegistral2.Enabled = true;
                            this.cboTipoIdentificacionPerJur.Enabled = true;
                            this.txtNumPartReg.Enabled = true;
                        }
                }
                else if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 4)
                {

                    this.cboUbigeoPais.Enabled = true;
                    this.txtDirUbi.Enabled = false;
                    this.txtDirUbi.Text = string.Empty;

                    if (cboTipPersona.Text != "")
                        if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
                        {
                            this.cboZonaRegistral1.SelectedValue = 0;
                            this.cboZonaRegistral1.Enabled = false;
                            this.cboZonaRegistral2.Enabled = false;
                            this.cboTipoIdentificacionPerJur.SelectedValue = 0;
                            this.cboTipoIdentificacionPerJur.Enabled = false;
                            this.txtNumPartReg.Clear();
                            this.txtNumPartReg.Enabled = false;
                        }
                    this.cboUbigeoPais.SelectedValue = -1;
                }
            }
        }
        private void cboTipDocumento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.txtCBDoc.ValidarTipoDoc(Convert.ToString(this.cboTipDocumento.SelectedValue));
            if (cboTipDocumento.Text != "")
                lblDocumento.Text = cboTipDocumento.Text + ":";
            else
                lblDocumento.Text = "Nro Documento:";

            CambiarEstadoDigitoVerificador();
            verificaTipoDocumentoMenorDeEdad();
        }
        private void verificaTipoDocumentoMenorDeEdad()
        {
            /* -- Si es menor de edad DNI Menor de Edad -- */
            int idTipoDoc = Convert.ToInt32(this.cboTipDocumento.SelectedValue);
            if (idTipoDoc.In(11, 14))
            {
                lMenoresEdad = true;
                desactivarMenorEdad(false);
            }
            else
            {
                //if (pcTipOpe != "O" && pcTipOpe != "A")
                //{
                    lMenoresEdad = false;
                    desactivarMenorEdad(true);
                //}
            }
            /* -- Si es menor de edad DNI Menor de Edad -- */
        }
        private void desactivarMenorEdad(Boolean lBol)
        {
            if (!lBol)
            {
                cboActividadInternaNat.SelectedIndex = -1;
                cboActividadInternaNatAd.SelectedIndex = -1;
                dtpFecIniActEcoNat.CustomFormat = " ";
                cboEstadoContribNat.SelectedIndex = -1;
                dtpFechaEstadoConNat.Value = clsVarGlobal.dFecSystem;
                cboCondDomNat.SelectedIndex = -1;
                checkPep.Checked = false;
            }
            else if (cboActividadInternaNat.SelectedIndex != -1)
            {
                dtpFecIniActEcoNat.CustomFormat = "dd/MM/yyyy";
            }
            
            cboActividadInternaNat.Enabled = lBol;
            btnMiniBusq1.Enabled = lBol;
                        
            cboActividadInternaNatAd.Enabled = lBol;
            btnMiniBusq2.Enabled = lBol;
            
            dtpFecIniActEcoNat.Enabled = lBol;            
            
            cboEstadoContribNat.Enabled = lBol;
            dtpFechaEstadoConNat.Enabled = lBol;
            cboCondDomNat.Enabled = lBol;

            grbBase11.Enabled = lBol;
        }
        private void cboTipDocAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarControles_Contribuyente(false);
            this.txtCBDocAdi.ValidarTipoDoc(Convert.ToString(this.cboTipDocAdi.SelectedValue));
            if (cboTipDocAdi.SelectedIndex == -1)
            {
                txtCBDocAdi.Clear();
                lblDocAdicional.Text = "Nro Doc. Adicional:";
            }
            else if ((int)cboTipDocAdi.SelectedValue == 4)
            {
                if (btnGrabar.Enabled == true && !chcBeneficiario.Checked && (int)cboTipClasificacion.SelectedValue != 11)
                {
                    MessageBox.Show("No corresponde registrar un RUC según la clasificación del Tipo Persona", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipDocAdi.SelectedIndex = -1;
                    txtCBDocAdi.Clear();
                    return;
                }
                else
                {
                    HabilitarControles_Contribuyente(true);
                }
                txtCBDocAdi.Clear();
                lblDocAdicional.Text = cboTipDocAdi.Text + ":";
            }
            else
            {
                if (cboTipDocAdi.Text != "")
                    lblDocAdicional.Text = cboTipDocAdi.Text + ":";
                else
                    lblDocAdicional.Text = "Nro Doc. Adicional:";
            }
            
        }
        private void txtCBDoc_Validating_1(object sender, CancelEventArgs e)
        {
            if (!ValidarDNI())
            {
                return;
            }
        }

        private bool ValidarDNI()
        {
            if (!string.IsNullOrEmpty(txtCBDoc.Text))
            {

                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 1 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 11)
                    if (txtCBDoc.TextLength < 8)
                    {
                        MessageBox.Show("El numero de DNI debe tener 8 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 2 )
                    if (!(txtCBDoc.TextLength == 9))
                    {
                        MessageBox.Show("El número de Carnet de Extranjería debe tener 9 dígitos.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCBDoc.Focus();
                        return false;
                    }
                int Result = 0;
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 2)
                    if (!int.TryParse(txtCBDoc.Text, out Result))
                    {
                        MessageBox.Show("Solo se permiten números para Carnet de Extranjería.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCBDoc.Focus();
                        return false;
                    }


                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 4)
                {

                    Regex valid = new Regex(@"^\d{11}?$");
                    if (!valid.IsMatch(txtCBDoc.Text.Trim()))
                    {
                        MessageBox.Show("El numero de RUC debe tener 11 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDoc.SelectAll();
                        txtCBDoc.Focus();
                        return false;
                    }                    
                    else
                    {
                        if (!funciones.validarNumeroRUC(txtCBDoc.Text.Trim()))
                        {
                            MessageBox.Show("Por Favor ingresar un RUC Válido", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBDoc.SelectAll();
                            txtCBDoc.Focus();
                            return false;
                        }
                    }
                }
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 3)
                    if (txtCBDoc.TextLength < 9)
                    {
                        MessageBox.Show("El numero de PASAPORTE debe tener por lo menos 9 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }


                if (pcTipOpe == "N")
                {
                    string tcDocIde = this.txtCBDoc.Text.Trim();
                    if (tcDocIde != "")
                    {
                        clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                        string cValidacion = xRetDatCli.RetDatVal(0, tcDocIde, "D", Convert.ToInt32(cboTipDocumento.SelectedValue));
                        if (cValidacion == "ERROR")
                        {
                            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                            {
                                MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtCBDoc.SelectAll();
                                //txtCBDoc.Focus();
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtCBDoc.SelectAll();
                                //txtCBDoc.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private bool ValidarDocAdicional()
        {
            if (!string.IsNullOrEmpty(txtCBDocAdi.Text) && cboTipDocAdi.SelectedValue != null)
            {                
                
                if (Convert.ToInt32(cboTipDocAdi.SelectedValue) == 4)
                {
                    Regex valid = new Regex(@"^\d{11}?$");
                    if (!valid.IsMatch(txtCBDocAdi.Text.Trim()))
                    {
                        MessageBox.Show("El numero de RUC debe tener 11 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDocAdi.SelectAll();
                        return false;
                    }
                    else
                    {
                        if (!funciones.validarNumeroRUC(txtCBDocAdi.Text.Trim()))
                        {
                            MessageBox.Show("Por favor ingresar un RUC válido", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBDocAdi.SelectAll();
                            return false;
                        }
                    }
                }
                if (Convert.ToInt32(cboTipDocAdi.SelectedValue) == 3)
                {
                    if (txtCBDocAdi.TextLength < 9)
                    {
                        MessageBox.Show("El numero de PASAPORTE debe tener por lo menos 9 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            if (pcTipOpe == "N")
            {
                string tcDocIde = this.txtCBDocAdi.Text.Trim();
                if (!string.IsNullOrEmpty(tcDocIde))
                {
                    clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                    string cValidacion = xRetDatCli.RetDatVal(0, tcDocIde, "D", Convert.ToInt32(cboTipDocAdi.SelectedValue));
                    if (cValidacion == "ERROR")
                    {
                        if (Convert.ToInt32(cboTipDocAdi.SelectedValue) == 4)
                        {
                            MessageBox.Show("Ya existe un Cliente registrado con ese Número de RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBDocAdi.Clear();
                            return false;
                        }
                        else
                        {
                            MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBDocAdi.SelectAll();
                            return false;
                        }
                    }
                    return true;
                }
            }
            return true;
        }
        private void txtCBDocAdi_Validating_1(object sender, CancelEventArgs e)
        {
            if (!ValidarDocAdicional())
            {
                e.Cancel = true;
                return;
            }
        }
        private void dtFecNac_Validating_1(object sender, CancelEventArgs e)
        {
            if (pcTipOpe != "O")
            {

                int nEdad = Convert.ToInt32(pdFecSistem.Year) - Convert.ToInt32(dtFecNac.Value.Year);
                int DifMeses = Convert.ToInt32(pdFecSistem.Month) - Convert.ToInt32(dtFecNac.Value.Month);
                int DifDias = Convert.ToInt32(pdFecSistem.Day) - Convert.ToInt32(dtFecNac.Value.Day);

                if (Convert.ToDateTime(dtFecNac.Value.ToShortDateString()) > Convert.ToDateTime(pdFecSistem.ToShortDateString()))
                {
                    MessageBox.Show("La fecha de Nacimiento, es posterior a la fecha de hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFecNac.Value = pdFecSistem;
                    return;
                }

                if (Convert.ToDateTime(dtFecNac.Value.ToShortDateString()) == Convert.ToDateTime(pdFecSistem.ToShortDateString()))
                {
                    MessageBox.Show("Fecha de Nacimiento no Válida", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFecNac.Value = pdFecSistem;
                    return;
                }

                if (Convert.ToInt32(Convert.ToInt32(cboTipDocumento.SelectedValue)) == 1)
                {
                    if (nEdad < 18)
                    {
                        MessageBox.Show("El Cliente es Menor de Edad, por favor seleccione como tipo de Documento: DNI Menor de edad ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFecNac.Value = pdFecSistem;
                        return;
                    }
                    else if (nEdad == 18)
                    {
                        if (DifMeses < 0)
                        {
                            MessageBox.Show("El Cliente es Menor de Edad,  por favor seleccione como tipo de Documento: DNI Menor de edad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFecNac.Value = pdFecSistem;
                            return;
                        }
                        if (DifMeses == 0)
                            if (DifDias < 0)
                            {
                                MessageBox.Show("El Cliente es Menor de Edad,  por favor seleccione como tipo de Documento: DNI Menor de edad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtFecNac.Value = pdFecSistem;
                                return;
                            }
                    }
                }

                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 11)
                {
                    if (nEdad > 18)
                    {
                        MessageBox.Show("A seleccionado DNI de menor de edad y el Cliente es Mayor de Edad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFecNac.Value = pdFecSistem;
                        return;
                    }
                    if (nEdad == 18)
                    {
                        if (DifMeses > 0)
                        {
                            MessageBox.Show("A seleccionado DNI de menor de edad y el Cliente es Mayor de Edad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFecNac.Value = pdFecSistem;
                            return;
                        }
                        if (DifMeses == 0)
                            if (DifDias >= 0)
                            {
                                MessageBox.Show("A seleccionado DNI de menor de edad y el Cliente es Mayor de Edad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtFecNac.Value = pdFecSistem;
                                return;
                            }
                    }
                }
            }
        }
        private void dtFecCons_Validating_1(object sender, CancelEventArgs e)
        {

            if (Convert.ToDateTime(dtpFecCons.Value.ToShortDateString()) > Convert.ToDateTime(pdFecSistem.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Constitucion de Empresa, no puede ser posterior a la Fecha de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecCons.Value = pdFecSistem;
                return;
            }
            this.dtpFecIni.Value = dtpFecCons.Value;
        }
        private void cboNivInstruc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboNivInstruc.SelectedValue) > -1)
            {
                cboProfesion.Enabled = true;
                this.btnMiniBusqProf.Enabled = true;
            }
            else
            {
                cboProfesion.Enabled = false;
                this.btnMiniBusqProf.Enabled = false;
                txtProfesion.Enabled = false;
                txtProfesion.Clear();
                cboProfesion.SelectedValue = 1;
            }
        }
        private void txtCBDigVerificador_Validating_1(object sender, CancelEventArgs e)
        {
            if (!ValidarDigVerificador())
            {
                return;
            }
        }
        private bool ValidarDigVerificador()
        {
            if (!String.IsNullOrEmpty(txtCBDigVerificador.Text))
            {
                // Validar El Algorimo de Validacion de Digito Verificador
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 1 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 11)
                {
                    if (txtCBDigVerificador.TextLength < 1)
                    {
                        MessageBox.Show("Debe Ingresar el Codigo Verificador del DNI", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }

        private void cboClienteCargo1_SelectedIndexChanged_1(object sender, EventArgs e)
        {            
            if (cboClienteCargo1.SelectedIndex >= 0)
            {
                if (Convert.ToInt32(cboClienteCargo1.SelectedValue.ToString().Trim()) == 37)
                {
                    this.txtOtrosDesc.Text = "";
                    this.txtOtrosDesc.Enabled = true;
                }
                else
                {
                    this.txtOtrosDesc.Text = "";
                    this.txtOtrosDesc.Enabled = false;
                }

                if (Convert.ToBoolean(((DataTable)cboClienteCargo1.DataSource).Rows[cboClienteCargo1.SelectedIndex]["lPep"]))
                {
                    activarPep(true);
                }
                else
                {
                    activarPep(false);
                }
            }
        }
        private void activarPep(Boolean lBol)
        {
            grbBase11.Enabled = !lBol;
            checkPep.Checked = lBol;
        }
        private void cboZonaRegistral1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZonaRegistral1.SelectedIndex > 0)
            {
                cboZonaRegistral2.CargarZonaRegistral((int)cboZonaRegistral1.SelectedValue);
                cboZonaRegistral2.Enabled = true;
                cboTipoIdentificacionPerJur.SelectedValue = 1;
                cboTipoIdentificacionPerJur.Enabled = true;
                txtNumPartReg.Enabled = true;
            }
            else
            {
                cboZonaRegistral2.SelectedValue = 0;
                cboZonaRegistral2.Enabled = false;
                cboTipoIdentificacionPerJur.SelectedValue = 0;
                cboTipoIdentificacionPerJur.Enabled = false;
                txtNumPartReg.Clear();
                txtNumPartReg.Enabled = false;

            }
        }
        private void cboTipoIdentificacionPerJur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboTipoIdentificacionPerJur.SelectedValue) == 1)
                lblParRegistral.Text = "Partida Registral:";
            if (Convert.ToInt32(this.cboTipoIdentificacionPerJur.SelectedValue) == 2)
                lblParRegistral.Text = "Ficha Registral:";
        }
        private void checkEmpleador_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCantEmpl.Enabled = checkEmpleador.Checked;
            if (checkEmpleador.Checked == false)
            {
                txtCantEmpl.Text = "0";
            }
            else
            {
                this.txtCantEmpl.Focus();
                txtCantEmpl.Select();
            }
        }
        private void cboTipVinculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3)
            {
                if ((cboTipVinculo.SelectedValue).In(10, 11, 12, 13, 14))
                {
                    this.lblBase24.Visible = true;
                    this.dtpFecIni.Value = pdFecSistem;
                    this.dtpFecIni.Visible = true;
                    this.lblBase25.Visible = false;
                    this.dtpFecFin.Visible = false;
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                }
                if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 2)
                {
                    this.lblBase24.Visible = true;
                    this.dtpFecIni.Value = pdFecSistem;
                    this.dtpFecIni.Visible = true;
                    this.lblBase25.Visible = true;
                    this.dtpFecFin.Visible = true;
                    this.dtpFecFin.Value = pdFecSistem;
                }
                if (Convert.ToInt32(cboTipVinculo.SelectedValue) == 11)
                {
                    txtPorCapSocVot.Text = "0.00";
                    lblPorCapSocVot.Visible = true;
                    txtPorCapSocVot.Visible = true;
                }
                if (Convert.ToInt32(cboTipVinculo.SelectedValue) != 11)
                {
                    txtPorCapSocVot.Text = "0.00";
                    lblPorCapSocVot.Visible = false;
                    txtPorCapSocVot.Visible = false;
                }
            }

            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
            {
                if (cboTipVinculo.SelectedValue != null && (cboTipVinculo.SelectedValue.ToString().Trim() == "1" || cboTipVinculo.SelectedValue.ToString().Trim() == "3"))
                {
                    this.lblBase24.Visible = true;
                    this.dtpFecIni.Value = pdFecSistem;
                    this.dtpFecIni.Visible = true;
                    this.lblBase25.Visible = false;
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecFin.Visible = false;
                }
                else if (cboTipVinculo.SelectedValue != null && (cboTipVinculo.SelectedValue.ToString().Trim() != "1" || cboTipVinculo.SelectedValue.ToString().Trim() != "3"))
                {
                    this.lblBase24.Visible = false;
                    this.dtpFecIni.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecIni.Visible = false;
                    this.lblBase25.Visible = false;
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecFin.Visible = false;
                }
            }

        }

        private void textZonas_TextChanged(object sender, EventArgs e)
        {
            string cfiltroTexto = textofiltradoViZona(textZonas.Text);
            if (textZonas.Text != cfiltroTexto)
            {
                textZonas.Text = cfiltroTexto;
                textZonas.SelectionStart = cfiltroTexto.Length;
            } 

            String cadZona = "";
            if (textZonas.Text == "")
            {
                cadZona = "";
                Direccion(cadZona, "textZona");
            }
            else
            {
                if (cboTipoVia.Text == "**NINGUNO**")
                {
                   cadZona = cboTipoZonas.Text + " " + textZonas.Text + " ";
                   Direccion(cadZona, "textZona");
                }
                else
                {
                    cadZona = cboTipoZonas.Text + " " + textZonas.Text + " - ";
                    Direccion(cadZona, "textZona");
                }
            }
        }
        private void txtVia_TextChanged(object sender, EventArgs e)
        {
            textZonas_TextChanged(sender, e);

            string cfiltroTexto = textofiltradoViZona(textVia.Text);
            if (textVia.Text != cfiltroTexto)
            {
                textVia.Text = cfiltroTexto;
                textVia.SelectionStart = cfiltroTexto.Length;
            }

            String cadVia = "";
            if (textVia.Text == "")
            {
                cadVia = "";
                Direccion(cadVia, "textVia");
            }
            else
            {
                cadVia = cboTipoVia.Text + " " + textVia.Text;
                Direccion(cadVia, "textVia");
            }

            if (textVia.Enabled == true)
            {
                txtBase element = (txtBase)textVia;
                tooltip = new ToolTip();
                tooltip.IsBalloon = true;
                tooltip.ShowAlways = false;
                tooltip.UseAnimation = true;
                tooltip.Show("SECUENCIA: Nombre Via - Nro. - Mz. - Lt. - Int. - Dpto. - Bloque - Etapa -Km. \n EJEMPLO: LAS PALMERAS NRO 348 INTERIOR A DTPO 202 ", element, 0, -element.Height * 3, 2000);
            }
        }
        private void textZonas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == ':' || e.KeyChar == '/' || e.KeyChar == ' ' || e.KeyChar == ';' || e.KeyChar == '\'')
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }

            if (e.KeyChar == ' ')
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && textBox.Text[selectionStart - 1] == ' ')
                {
                    e.Handled = true;
        }
            }

            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                TextBox textBox = (TextBox)sender;
                int currentLineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                string currentLineText = textBox.Lines[currentLineIndex];

                if (string.IsNullOrWhiteSpace(currentLineText))
                {
                    e.Handled = true;
                }
            }            
            

        }
        private void txtVia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == ':' || e.KeyChar == '/' || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == ';' || e.KeyChar == '\'')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyChar == ' ')
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && textBox.Text[selectionStart - 1] == ' ')
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                TextBox textBox = (TextBox)sender;
                int currentLineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                string currentLineText = textBox.Lines[currentLineIndex];

                if (string.IsNullOrWhiteSpace(currentLineText))
                {
                    e.Handled = true;
                }
            }
        }
        private void cboTipoZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoZonas.Text != "" && btnGrabar.Enabled == true)//si grabar esta activo indica que está en editando o creando un nuevo registro
            {
                if (cboTipoZonas.SelectedValue.ToString().Trim() == "1")
                {
                    textZonas.Clear();
                    textZonas.Enabled = false;
                }
                if (cboTipoZonas.SelectedValue.ToString().Trim() != "1")
                    textZonas.Enabled = true;
            }
            string cadZona = "";
            if (cboTipoZonas.Text.Trim() == "**NINGUNO**")
            {
                cadZona = cboTipoZonas.Text + " " + textZonas.Text + " ";
                Direccion(cadZona, "textZona");  
            }            
            if (textZonas.Text == "")
            {
                cadZona = "";
                Direccion(cadZona, "textZona");  
            }
            else 
            {
                if (cboTipoVia.Text.Trim() != "**NINGUNO**")
                {
                    cadZona = cboTipoZonas.Text + " " + textZonas.Text + " - ";
                    Direccion(cadZona, "textZona");
                }
                else 
                {
                    cadZona = cboTipoZonas.Text + " " + textZonas.Text + " ";
                    Direccion(cadZona, "textZona");             
                }
            }
            textZonas_TextChanged(sender, e);
        }
        private void cboTipoVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoVia.Text != "" && btnGrabar.Enabled == true)//si grabar esta activo indica que está en editando o creando un nuevo registro
            {
                if (cboTipoVia.SelectedValue.ToString().Trim() == "1")
                {
                    textVia.Clear();
                    textVia.Enabled = false;
                }
                if (cboTipoVia.SelectedValue.ToString().Trim() != "1")
                    textVia.Enabled = true;
            }
            string cadVia = "";
            if (cboTipoVia.Text.Trim() == "**NINGUNO**")
            {
                cadVia = cboTipoZonas.Text + " " + textZonas.Text + " ";
                Direccion(cadVia, "textVia");
            } 
            if (textVia.Text == "")
            {       
                cadVia = "";
                Direccion(cadVia, "textVia");
            }
            else 
            { 
                cadVia = cboTipoVia.Text + " " + textVia.Text + " ";
                Direccion(cadVia, "textVia");          
            }

            textZonas_TextChanged(sender, e);
        }
        private void cboTipPersona_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTipPersona.SelectedIndex != -1)
            {
                var idTipoPersona = Convert.ToInt32(cboTipPersona.SelectedValue);                                
                tbClienteVinculado.Rows.Clear();
                if (idTipoPersona == 1)
                {
                    var lisVinPerNat = from item in tbVinculo
                                       where item.nTipVinPer == 1 || item.nTipVinPer == 0
                                       select item;

                    cboTipVinculo.DataSource = lisVinPerNat.ToList();
                    cboTipVinculo.ValueMember = "idTipoVinculo";
                    cboTipVinculo.DisplayMember = "cTipoVinculo";
                    cboTipVinculo.Refresh();

                    this.lblBase24.Visible = true;
                    this.dtpFecIni.Value = pdFecSistem;
                    this.dtpFecIni.Visible = true;
                    this.lblBase25.Visible = false;
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                    this.dtpFecFin.Visible = false;
                    this.cboTipVinculo.SelectedIndex = -1;
                    chcBeneficiario.Enabled = true;
                    dtpFecEstConJur.Enabled = false;
                    if (RdBtnNacionPer.Checked)
                    {
                        this.cboTipDocumento.CargarDocumentos("N");
                        this.cboTipDocumento.Enabled = true;
                        this.cboTipDocAdi.CargarDocumentos("C");
                        this.cboTipClasificacion.CargarClasificacion((int)cboTipPersona.SelectedValue);

                        this.tbcCliente.Controls["tabPer_Natural"].Enabled = true;
                        this.tbcCliente.Controls["tabPer_Juridica"].Enabled = false;

                        this.cboTipDocumento.SelectedValue = 1;
                    } else if (RdBtnNacionExt.Checked)
                    {
                        this.cboTipDocumento.CargarDocumentos("Z");
                        this.cboTipDocumento.Enabled = true;
                        this.cboTipDocAdi.CargarDocumentos("C");
                        this.cboTipClasificacion.CargarClasificacion((int)cboTipPersona.SelectedValue);

                        this.tbcCliente.Controls["tabPer_Natural"].Enabled = true;
                        this.tbcCliente.Controls["tabPer_Juridica"].Enabled = false;
                    }

                    //-------- Sólo activo para clientes naturales ------->
                    checkPep.Enabled = false;
                    checkPep.Checked = false;
                    tabPer_Natural.Show();
                    tabPer_Juridica.Hide();

                }
                else if (idTipoPersona.In(2, 3))
                {
                    this.cboTipClasificacion.CargarClasificacion((int)cboTipPersona.SelectedValue);
                    var lisVinPerNat = from item in tbVinculo
                                       where item.nTipVinPer == 2 || item.nTipVinPer == 0
                                       select item;

                    cboTipVinculo.DataSource = lisVinPerNat.ToList();
                    cboTipVinculo.ValueMember = "idTipoVinculo";
                    cboTipVinculo.DisplayMember = "cTipoVinculo";
                    cboTipVinculo.Refresh();
                    chcBeneficiario.Enabled = false;
                    chcBeneficiario.Checked = false;
                    this.lblBase24.Visible = true;
                    this.dtpFecIni.Value = pdFecSistem;
                    this.dtpFecIni.Visible = true;
                    this.lblBase25.Visible = true;
                    this.dtpFecFin.Value = pdFecSistem;
                    this.dtpFecFin.Visible = true;

                    this.cboTipDocumento.CargarDocumentos("J");

                    if (RdBtnNacionExt.Checked == true)
                        this.cboTipDocumento.SelectedValue = 7;
                    if (RdBtnNacionPer.Checked == true)
                        this.cboTipDocumento.SelectedValue = 4;


                    this.cboTipDocumento.Enabled = false;
                    this.cboTipDocAdi.CargarDocumentos("J");
                    this.cboTipDocAdi.SelectedIndex = -1;

                    this.tbcCliente.Controls["tabPer_Natural"].Enabled = false;
                    this.tbcCliente.Controls["tabPer_Juridica"].Enabled = true;

                    this.cboZonaRegistral1.SelectedValue = 0;
                    this.cboTipVinculo.SelectedIndex= -1;

                    this.txtCantEmpl.Enabled = checkEmpleador.Checked;
                    cboEstadoContribuyenteJur.Enabled = true;
                    dtpFecEstConJur.Enabled = true;
                    if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 4)
                    {
                        this.cboZonaRegistral1.SelectedValue = 0;
                        this.cboTipoIdentificacionPerJur.SelectedValue = 0;
                        this.txtNumPartReg.Clear();
                        this.cboZonaRegistral1.Enabled = false;
                        this.cboZonaRegistral2.Enabled = false;
                        this.cboTipoIdentificacionPerJur.Enabled = false;
                        this.txtNumPartReg.Enabled = false;
                    }

                    //-------- Sólo activo para clientes naturales ------->
                    checkPep.Enabled = false;
                    checkPep.Checked = false;
                    //--------------------------------------------------->
                    tabPer_Natural.Hide();
                    tabPer_Juridica.Show();
                }

            }
        }
        private void dtgDireccion_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (pcTipOpe != "O")
            {
                int FilaSeleccionada = e.RowIndex;
                tbDirCli.Columns["idTipoDireccion"].ReadOnly = false;
                int CantDirPrincipal = 0;

                if (tbDirCli.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgDireccion.Rows.Count; i++)
                    {
                        //No debe existir mas de 1 direccion principal
                        if (Convert.ToBoolean(dtgDireccion.Rows[i].Cells["lDirPrincipal"].Value) == true)
                        {
                            CantDirPrincipal = CantDirPrincipal + 1;
                            if (CantDirPrincipal == 2)
                            {
                                MessageBox.Show("No puede haber mas de 01 Dirección Principal ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tbcCliente.SelectedIndex = 0;
                                dtgDireccion.Rows[FilaSeleccionada].Cells["lDirPrincipal"].Value = false;
                                return;
                            }
                        }
                        //No debe existir ningún Tipo de Dirección Vacia
                        if (dtgDireccion.Rows[i].Cells["cmb"].FormattedValue.ToString().Trim() == "")
                        {
                            MessageBox.Show("Debe seleccionar el tipo de Dirección", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcCliente.SelectedIndex = 0;
                            return;
                        }
                        if (Convert.ToInt32(dtgDireccion.Rows[i].Cells["cmb"].Value) == 0)
                        {
                            MessageBox.Show("Debe seleccionar el tipo de Dirección", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcCliente.SelectedIndex = 0;
                            return;
                        }
                    }
                }
            }
        }
        private void dtgDireccion_SelectionChanged_1(object sender, EventArgs e)
        {
        }
        private void txtCantEmpl_TextChanged(object sender, EventArgs e)
        {
            if (txtCantEmpl.Text == "")
            {
                txtCantEmpl.Text = "0";
            }
        }
        #endregion

        #region Metodos
        private void AlertaProtegido(Control objControl)
        {
            if(!objControl.Enabled && this.btnSolActualizacion.Visible)
            {
                this.epProtegido.SetError(objControl, this.cRestringido);
                this.lblActualizacion.Visible = true;
            }
            else
            {
                this.epProtegido.SetError(objControl, "");
            }
        }
        private void AlertaDatosSencibles()
        {
            this.AlertaProtegido(this.cboTipDocumento);
            this.AlertaProtegido(this.txtCBDoc);
            this.AlertaProtegido(this.txtApePat);
            this.AlertaProtegido(this.txtApeMat);
            this.AlertaProtegido(this.txtNom1);
            this.AlertaProtegido(this.txtNom2);
            this.AlertaProtegido(this.txtNom3);
            this.AlertaProtegido(this.txtApeCasado);
            this.AlertaProtegido(this.cboEstadoCivil);
            this.AlertaProtegido(this.dtFecNac);
            this.AlertaProtegido(this.cboEstadoCliNat);
            this.AlertaProtegido(this.cboSexo);
        }
        private void BloquearDatosSensibles(bool lNuevo)
        {
            if (lNuevo)
            {
                if (Convert.ToInt32(this.cboTipPersona.SelectedValue) == 1) // Natural
                {
                    this.cboTipDocumento.Enabled = false;
                    this.txtCBDigVerificador.Enabled = false;
                    this.cboEstadoCivil.Enabled = false;
                    this.cboEstadoCivilSBS.Enabled = false;
                    this.cboSexo.Enabled = false;
                    this.dtFecNac.Enabled = false;
                    this.conBusUbiNac.cboPais.Enabled = this.RdBtnNacionExt.Checked;
                    this.conBusUbiNac.cboDepartamento.Enabled = false;
                    this.conBusUbiNac.cboProvincia.Enabled = false;
                    this.conBusUbiNac.cboDistrito.Enabled = false;
                    this.conBusUbiNac.cboAnexo.Enabled = this.RdBtnNacionPer.Checked;

                    this.cboTipPersona.Enabled = false;
                }
                else
                {
                }
            } 
            else
            {
                if (Convert.ToInt32(this.cboTipPersona.SelectedValue) == 1) // Natural
                {
                    this.cboTipDocumento.Enabled = false;
                    this.txtCBDoc.Enabled = false;

                    this.txtApePat.Enabled = false;
                    this.txtApeMat.Enabled = false;
                    this.txtNom1.Enabled = false;
                    this.txtNom2.Enabled = false;
                    this.txtNom3.Enabled = false;
                    this.txtApeCasado.Enabled = false;

                    this.cboSexo.Enabled = false;
                    if(!(Convert.ToInt32(cboEstadoCivil.SelectedValue).In(1, 3, 4)))
                    {
                        this.cboEstadoCivil.Enabled = false;
                    }
                    this.dtFecNac.Enabled = false;

                    this.conBusUbiNac.cboPais.Enabled = this.RdBtnNacionExt.Checked;
                    this.conBusUbiNac.cboDepartamento.Enabled = false;
                    this.conBusUbiNac.cboProvincia.Enabled = false;
                    this.conBusUbiNac.cboDistrito.Enabled = false;
                    this.conBusUbiNac.cboAnexo.Enabled = this.RdBtnNacionPer.Checked;

                    this.cboEstadoCliNat.Enabled = false;

                    this.cboTipPersona.Enabled = false;
                }
                else
                {
                }
            }
        }
        private void CargarCodCiudad()
        {
            DataTable dtCodCiudad = Cliente.CNListaCodCiudad();
            cboCodCiudad.DataSource = dtCodCiudad;
            cboCodCiudad.DisplayMember = dtCodCiudad.Columns["cDescripcion"].ToString();
            cboCodCiudad.ValueMember = dtCodCiudad.Columns["idCodCiudad"].ToString();
        }
        private void CargarDatos()
        {
            //-----------------------------------------------
            // Carga datos de los Profesion
            //-----------------------------------------------
            clsCNProfesion listaProf = new clsCNProfesion();
            tbProf = listaProf.ListarProfesion();
            cboProfesion.DataSource = tbProf;
            cboProfesion.ValueMember = tbProf.Columns[0].ToString();
            cboProfesion.DisplayMember = tbProf.Columns[1].ToString();

            //-----------------------------------------------
            // Carga Datos deNivel de Instruccion
            //----------------------------------------------
            //quitar evento al cargar combo
            cboNivInstruc.SelectedIndexChanged -= new
            EventHandler(cboNivInstruc_SelectedIndexChanged);

            clsCNNivInstruccion listaNivInst = new clsCNNivInstruccion();
            DataTable tbNivInst = listaNivInst.ListarNivInstruccion();
            cboNivInstruc.DataSource = tbNivInst;
            cboNivInstruc.ValueMember = tbNivInst.Columns[0].ToString();
            cboNivInstruc.DisplayMember = tbNivInst.Columns[1].ToString();

            //añadir evento al cargar combo
            cboNivInstruc.SelectedIndexChanged += new
            EventHandler(cboNivInstruc_SelectedIndexChanged);

            //-----------------------------------------------
            // Carga Datos de Ocupacion
            //-----------------------------------------------
            //quitar evento al cargar combo
            //cboOcupacion.SelectedIndexChanged -= new
            //EventHandler(cboOcupacion_SelectedIndexChanged);

            clsCNOcupacion ListaOcu = new clsCNOcupacion();
            DataTable tbOcup = ListaOcu.ListarOcupacion();
            //cboOcupacion.DataSource = tbOcup;
            //cboOcupacion.ValueMember = tbOcup.Columns[0].ToString();
            //cboOcupacion.DisplayMember = tbOcup.Columns[1].ToString();

            //añadir evento al cargar combo
            //cboOcupacion.SelectedIndexChanged += new
            //EventHandler(cboOcupacion_SelectedIndexChanged);


            //-----------------------------------------------
            // Carga Datos de Vinculacion
            //-----------------------------------------------
            clsCNTipVinculo ListaVin = new clsCNTipVinculo();
            tbVinculo = ListaVin.ListarTipVinculo();

            var lisVinPerNat = from item in tbVinculo
                               where item.nTipVinPer == 1 || item.nTipVinPer == 0
                               select item;

            cboTipVinculo.DataSource = tbVinculo;
            cboTipVinculo.ValueMember = "idTipoVinculo";
            cboTipVinculo.DisplayMember = "cTipoVinculo";
            //-----------------------------------------------
            // Carga Datos de Vinculacion
            //-----------------------------------------------
            clsCNTipoDireccion objTipDir = new clsCNTipoDireccion();
            dtbTipDir = objTipDir.ListaTipDireccion();
            //-----------------------------------------------
            // Carga Datos Tipo Dirección - vivienda
            //-----------------------------------------------
            listarTipoDireccion();
            listarTipoVivienda();
        }
        private void CargarSuministro()
        {
            clsCNDirecCli ListaDirCli = new clsCNDirecCli();
            DataTable dtSuministro = ListaDirCli.ListaSuministro();

        }
        public void LimpiarControles()
        {
            /*Quitar eventos*/
            this.cboTipDocumento.SelectedIndexChanged -= this.cboTipDocumento_SelectedIndexChanged_1;
            this.dtpFecIniActEcoNat.ValueChanged -= new System.EventHandler(dtpFecIniActEcoNat_ValueChanged);

            //-----------------------------------------------
            // Limpiar Datos Generales
            //-----------------------------------------------            

            this.txtCBDoc.Clear();
            this.txtCBDocAdi.Clear();
            this.txtCBNroTel.Clear();
            this.txtCBNroTel2.Clear();
            this.txtTelefCel1.Clear();
            txtCorreElectronicoAd.Clear();

            this.txtCBCorreoElectronico.Clear();
            this.dtgDireccion.ClearSelection();

            this.cboTipoZonas.SelectedValue = 0;
            this.cboTipoVia.SelectedValue = 0;
            this.textZonas.Text = "";
            this.textVia.Text = "";
            this.txtDireccion.Clear();
            this.txtReferencia.Text = "";
            cboSector1.SelectedIndex = -1;
            txtResidencia.Clear();
            txtCodSBS.Clear();
            this.txtLatitud.Text = "";
            this.txtLongitud.Text = "";
            this.txtidGeo.Text = "";

            txtAnioConstruccion.Clear();
            txtNumPisos.Clear();
            txtNumSotanos.Clear();
            cboTipoEstructuraPredominante1.SelectedIndex = 0;
            cboTipoUsoDelPredio1.SelectedIndex = 0;

            this.RdBtnNacionPer.Checked = false;
            this.RdBtnNacionExt.Checked = false;

            this.cboTipoResidencia1.SelectedValue = 0;
            this.cboUbigeoPais.SelectedValue = 0;
            this.cboTipPersona.SelectedValue = 0;
            this.cboTipClasificacion.SelectedValue = 0;
            this.cboTipDocumento.SelectedValue = 0;
            this.cboTipDocAdi.SelectedIndex = -1;

            this.cboTipViviendas.SelectedValue = 0;


            this.txtCBDigVerificador.Text = "";

            //-----------------------------------------------
            // Limpiar Datos Persona Natural
            //-----------------------------------------------
            this.txtApePat.Clear();
            this.txtApeMat.Clear();
            this.txtApeCasado.Clear();
            this.txtNom1.Clear();
            this.txtNom2.Clear();
            this.txtNom3.Clear();
            this.txtNroHijos.Clear();
            this.txtNroPerDep.Clear();
            this.txtOtrosDesc.Clear();
            this.txtProfesion.Clear();
            dtFecNac.Value = pdFecSistem;
            this.cboSexo.SelectedValue = 0;
            this.cboEstadoCivil.SelectedValue = 0;
            this.cboEstadoCivilSBS.SelectedValue = 0;
            this.cboNivInstruc.SelectedValue = 1;
            this.cboProfesion.SelectedValue = 0;
            this.cboClienteCargo1.SelectedValue = 0;
            this.cboActividadEco.SelectedValue = -1;
            cboEstadoCliNat.SelectedIndex = 0;

            cboActividadEco4.SelectedIndex = -1;
            cboActividadInternaNat.SelectedIndex = -1;
            cboActividadInternaNatAd.SelectedIndex = -1;

            cboEstadoContribNat.SelectedIndex = -1; ;
            cboCondDomNat.SelectedIndex = -1; ;

            conBusUbiNac.cboPais.SelectedValue = 0;
            conBusUbiNac.cboDepartamento.SelectedValue = 0;
            conBusUbiNac.cboProvincia.SelectedValue = 0;
            conBusUbiNac.cboDistrito.SelectedValue = 0;
            txtUbigeoNac.Clear();
            //- Iván--
            cboSexo.SelectedIndex = -1;
            cboEstadoCivil.SelectedIndex = -1;
            cboEstadoCivilSBS.SelectedIndex = -1;
            dtFecNac.Value = clsVarGlobal.dFecSystem;

            checkPep.Checked = false;
            checkFatca.Checked = false;
            //--
            //-----------------------------------------------
            // Limpiar Datos Persona Jurídica
            //-----------------------------------------------
            this.txtRazSocial.Clear();
            this.txtNomComercial.Clear();
            this.txtSiglas.Clear();
            this.txtNumPartReg.Clear();

            this.dtpFecCons.Value = pdFecSistem;
            this.cboActividadEco2.SelectedValue = -1;
            this.cboZonaRegistral1.SelectedValue = -1;
            this.cboTipoIdentificacionPerJur.SelectedValue = 0;

            this.checkEmpleador.Checked = false;
            this.txtCantEmpl.Clear();
            this.lblIndEstado.Text = "";
            cboActividadEco5.SelectedIndex = -1;
            cboActividadInternaJur.SelectedIndex = -1;
            cboCondDomicilio.SelectedIndex = -1;
            cboEstadoCliJur.SelectedIndex = 0;
            cboMagnitudEmpresarial1.SelectedIndex = -1;

            //--Iván
            dtpFecCons.Value = clsVarGlobal.dFecSystem;
            dtpFecEstConJur.Value = clsVarGlobal.dFecSystem;
            dtpFecInact.Value = clsVarGlobal.dFecSystem;

            //--
            //-----------------------------------------------
            // Limpiar Datos Vinculados
            //-----------------------------------------------
            this.dtgVinculo.ClearSelection();
            this.dtpFecIni.Value = pdFecSistem;
            this.dtpFecFin.Value = pdFecSistem;
            conBusCliVin.txtCodAge.Clear();
            conBusCliVin.txtCodInst.Clear();
            conBusCliVin.txtCodCli.Clear();
            conBusCliVin.txtNombre.Clear();
            conBusCliVin.txtNroDoc.Clear();
            conBusCliVin.txtDireccion.Clear();

            this.dtpFecIniActEcoNat.Value = dFecIniActEcoDefault;
            this.dtpFecIniActEcoNat.CustomFormat = " ";

            this.dtpFecIniActEco.Value = dFecIniActEcoDefault;
            this.dtpFecIniActEco.CustomFormat = " ";

            /*Restaurar evento*/
            this.cboTipDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipDocumento_SelectedIndexChanged_1);
        }
        private void CargarDirCli(int cCodCli)
        {
            clsCNDirecCli ListaDirCli = new clsCNDirecCli();
            tbDirCli = ListaDirCli.ListaDirCli(cCodCli);
            for (int i = 0; i < tbDirCli.Columns.Count; i++)
            {
                tbDirCli.Columns[i].ReadOnly = false;
            }
            if (dtgDireccion.ColumnCount > 0)
            {
                dtgDireccion.Columns.Clear();
            }

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "TIPO DE DIRECCION";
            cmb.Name = "cmb";
            cmb.FillWeight = 60;
            cmb.MaxDropDownItems = 4;
            cmb.DataSource = dtbTipDir;
            cmb.DisplayMember = dtbTipDir.Columns["cTipoDir"].ToString();
            cmb.ValueMember = dtbTipDir.Columns["idTipoDireccion"].ToString();
            cmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            dtgDireccion.Columns.Add(cmb);
            tbDirCli.DefaultView.RowFilter = ("Estado <> 'E'");
            dtgDireccion.DataSource = tbDirCli.DefaultView;

            //
            int nNumDir = tbDirCli.Rows.Count;
            if (nNumDir > 0)
            {
                for (int i = 0; i < nNumDir; i++)
                {
                    dtgDireccion.Rows[i].Cells["cmb"].Value = Convert.ToInt32(tbDirCli.Rows[i]["idTipoDireccion"].ToString());
                }

            }

            FormatoGridCli();
            HabilitarGridDireccion(false);

        }
        private void FormatoGridCli()
        {
            foreach (DataGridViewColumn item in dtgDireccion.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgDireccion.Columns["cDireccion"].Visible = true;
            dtgDireccion.Columns["cReferenciaDireccion"].Visible = true;
            dtgDireccion.Columns["cmb"].Visible = true;
            dtgDireccion.Columns["lDirPrincipal"].Visible = true;

            dtgDireccion.Columns["cDireccion"].HeaderText = "DIRECCION";
            dtgDireccion.Columns["cReferenciaDireccion"].HeaderText = "REFERENCIA";
            dtgDireccion.Columns["cmb"].HeaderText = "TIPO DIRECCION";
            dtgDireccion.Columns["lDirPrincipal"].HeaderText = "DIR.PRINC.";

            dtgDireccion.Columns["cDireccion"].Width = 180;
            dtgDireccion.Columns["cReferenciaDireccion"].Width = 200;
            dtgDireccion.Columns["cmb"].Width = 100;
            dtgDireccion.Columns["lDirPrincipal"].Width = 67;

        }
        public void HabilitarGridDireccion(Boolean bVal)
        {

            dtgDireccion.ReadOnly = !bVal;
            dtgDireccion.Columns["cmb"].ReadOnly = bVal;
            dtgDireccion.Columns["cDireccion"].ReadOnly = bVal;
            dtgDireccion.Columns["cReferenciaDireccion"].ReadOnly = bVal;

            foreach (DataGridViewRow row in dtgDireccion.Rows)
            {
                if (Convert.ToBoolean(row.Cells["lDirPrincipal"].Value))
                {
                    row.Cells["lDirPrincipal"].ReadOnly = true;
                }
            }
        }
        private void CargarVinculados(int nIdCliente)
        {
            clsCNClienteVinculado ListaClienteVinculado = new clsCNClienteVinculado();
            tbClienteVinculado = ListaClienteVinculado.ListaClienteVinculado(nIdCliente);
            if (dtgVinculo.ColumnCount > 0)
            {
                dtgVinculo.Columns.Remove("idCli");
                dtgVinculo.Columns.Remove("idCliVin");
                dtgVinculo.Columns.Remove("cNombre");
                dtgVinculo.Columns.Remove("dFechaInicio");
                dtgVinculo.Columns.Remove("dFechaFinal");
                dtgVinculo.Columns.Remove("cTipoVinculo");
                dtgVinculo.Columns.Remove("Estado");
                dtgVinculo.Columns.Remove("nPorCapSocVot");
            }

            tbClienteVinculado.DefaultView.RowFilter = ("Estado <> 'E'");

            if (tbClienteVinculado.Rows.Count > 0)
            {
                //agrego esta parte para mostrar solo  las fechas que tienen fecha final, las que no tienen fecha final se muestran en campo vacio.
                for (int i = 0; i < tbClienteVinculado.Rows.Count; i++)
                {
                    if (  tbClienteVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900 12:00:00 a. m." || tbClienteVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900")
                    {
                        tbClienteVinculado.Rows[i]["dFechaFinal"] = DBNull.Value;
                    }
                }
                //
            }
            dtgVinculo.DataSource = tbClienteVinculado.DefaultView;
            formatoGridVin();
            dtgVinculo.Focus();

        }
        private void formatoGridVin()
        {
            dtgVinculo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dtgVinculo.Columns["idCli"].Visible = false;
            dtgVinculo.Columns["idCliVin"].Visible = false;
            dtgVinculo.Columns["idTipoVinculo"].Visible = false;
            dtgVinculo.Columns["Estado"].Visible = false;
            dtgVinculo.Columns["nPorCapSocVot"].Visible = false;
            if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
            {
                dtgVinculo.Columns["dFechaFinal"].Visible = false;
            }
            else
            {
                dtgVinculo.Columns["dFechaFinal"].Visible = true;

            }
            dtgVinculo.Columns["cNombre"].Width = 250;
            dtgVinculo.Columns["cTipoVinculo"].Width = 100;
            dtgVinculo.Columns["dFechaInicio"].Width = 80;

            dtgVinculo.Columns["cDocumentoID"].HeaderText = "N° Documento";
            dtgVinculo.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgVinculo.Columns["cTipoVinculo"].HeaderText = "Vinculo";
            dtgVinculo.Columns["dFechaInicio"].HeaderText = "Fec. Ini";
            dtgVinculo.Columns["dFechaFinal"].HeaderText = "Fec. Fin";
        }
        private string ValidarDatos_Generales()
        {
            /*validar tipo clasificacion del tipo de persona*/
            if ((int)cboTipClasificacion.SelectedIndex == -1)
            {
                MessageBox.Show("Selecccione la clasificacion del cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                cboTipClasificacion.Focus();
                return "ERROR";
            }

            /*VALIDAR DOCUMENTO
            ===========================================================*/
            //if (txtCBDoc.Text.Trim() == "" && Convert.ToInt32(((DataRowView)cboTipPersona.SelectedItem).Row["idTipoPersona"].ToString()) != 3)
            if (txtCBDoc.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Número de Documento ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                txtCBDoc.Focus();
                return "ERROR";
            }

            if ((Convert.ToInt32(cboTipDocumento.SelectedValue) == 11 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 1))
            {
                if (txtCBDigVerificador.Text.Trim() == "")
                {
                    MessageBox.Show("Debe Registrar el Dígito Verificador del DNI ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDigVerificador.Focus();
                    return "ERROR";
                }
                if (CalcularDigitoVerificador(txtCBDoc.Text.Trim()) != Convert.ToInt32(txtCBDigVerificador.Text.Trim()))
                {
                    MessageBox.Show("El Digito Verificador es incorrecto, por favor ingrese nuevamente el Digito Verificador", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDigVerificador.Focus();
                    return "ERROR";
                }
            }

            if (cboTipDocumento.SelectedValue == cboTipDocAdi.SelectedValue)
                if (txtCBDocAdi.Text.Trim() != "")
                {
                    MessageBox.Show("El Tipo de Documento Principal y el Adicional no pueden ser iguales, Ambos son: " + cboTipDocumento.Text, "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    cboTipDocAdi.Focus();
                    return "ERROR";
                }


            //if (txtCBDocAdi.Text == "")
            //{
            //    
            //} 


            /*validar documento adicional comboBox*/
            if (Convert.ToInt32(cboTipDocAdi.SelectedIndex) == -1)
            {
                if (txtCBDocAdi.Text != "")
                {
                    MessageBox.Show("Seleccione el Tipo de Documento Adicional", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDocAdi.Focus();
                    return "ERROR";
                }

                if (Convert.ToInt32(cboTipClasificacion.SelectedValue) == 11)
                {
                    MessageBox.Show("Debe Registrar el RUC del cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    cboTipDocAdi.Focus();
                    return "ERROR";
                }
            }
            else if (Convert.ToInt32(cboTipDocAdi.SelectedValue) == 4)
            {
                if (!chcBeneficiario.Checked && Convert.ToInt32(cboTipClasificacion.SelectedValue) != 11)
                {
                    MessageBox.Show("No corresponde registrar un RUC según la clasificación del Tipo Persona", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    cboTipDocAdi.SelectedIndex = -1;
                    return "ERROR";
                }
            }

            /*validar documento adicional textField*/
            if (txtCBDocAdi.Text == "")
            {
                if (cboTipDocAdi.SelectedIndex != -1)
                {
                    MessageBox.Show("Debe Registrar el Número de Documento Adicional", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDocAdi.Focus();
                    return "ERROR";
                }
            }

            if (!ValidarDNI())
            {
                return "ERROR";
            }
            if (!ValidarDocAdicional())
            {
                return "ERROR";
            }

            //Valida datos de la dirección
            if (RdBtnNacionExt.Checked && Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
            {
                if (txtCBDocAdi.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Nro de Documento Adicional, para las Personas Extranjeras es Obligatorio ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDocAdi.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3)
                {
                    MessageBox.Show("El Tipo de residencia " + cboTipoResidencia1.Text.Trim() + " no es válido para las personas extranjeras", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    cboTipoResidencia1.Focus();
                    return "ERROR";
                }
            }


            if (cboUbigeoPais.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Pais de Residencia", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                cboUbigeoPais.Focus();
                return "ERROR";
            }

            //if (txtCBNroTel2.Text.Trim() == "" && chcBeneficiario.Checked == false && String.IsNullOrEmpty(txtTelefCel1.Text.Trim()))
            if (txtCBNroTel2.Text.Trim() == "" && chcBeneficiario.Checked == false)
            {
                MessageBox.Show("Debe Registrar al menos un número de Teléfono Celular", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                txtCBNroTel2.Focus();
                return "ERROR";
            }


            if (dtgDireccion.RowCount == 0)
            {
                MessageBox.Show("Debe Registrar la Dirección del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                return "ERROR";
            }


            //Actualizamos la Tabla de Direcciones
            tbDirCli.Columns["idTipoDireccion"].ReadOnly = false;
            int c = 0;
            for (int i = 0; i < tbDirCli.Rows.Count; i++)
            {
                if (tbDirCli.Rows[i]["Estado"].ToString() != "E")
                {

                    tbDirCli.Rows[i]["idTipoDireccion"] = Convert.ToInt32(dtgDireccion.Rows[c].Cells["cmb"].Value);
                    c++;
                }
            }
            //Validamos la Direccion Principal
            int cont = 0;
            for (int i = 0; i < tbDirCli.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbDirCli.Rows[i]["lDirPrincipal"]) == true && tbDirCli.Rows[i]["Estado"].ToString() != "E")
                {
                    cont = cont + 1;
                }
            }
            if (cont < 1)
            {
                MessageBox.Show("Debe de Seleccionar cual es la Direccion Principal", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 0;
                return "ERROR";
            }

            tbDirCli.Columns["idTipoDireccion"].ReadOnly = false;
            int CantDirPrincipal = 0;
            if (tbDirCli.Rows.Count > 0)
            {
                for (int i = 0; i < dtgDireccion.Rows.Count; i++)
                {
                    //No debe existir ningún Tipo de Dirección Vacia
                    if (dtgDireccion.Rows[i].Cells["cmb"].FormattedValue.ToString().Trim() == "")
                    {
                        MessageBox.Show("Debe seleccionar el tipo de Dirección", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbcCliente.SelectedIndex = 0;
                        return "ERROR";
                    }
                    //No debe existir mas de 1 direccion principal
                    if (Convert.ToInt32(dtgDireccion.Rows[i].Cells["cmb"].Value) == 1)
                    {
                        CantDirPrincipal = CantDirPrincipal + 1;
                        if (CantDirPrincipal == 2)
                        {
                            MessageBox.Show("No puede haber mas de 01 Dirección Principal ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcCliente.SelectedIndex = 0;
                            return "ERROR";
                        }
                    }
                }
            }
            //Validando el registro de por lo menos un número telefónico
            //===========================================================//
            if (string.IsNullOrEmpty(txtCBNroTel2.Text)) //&& string.IsNullOrEmpty(txtTelefCel1.Text))
            {
                MessageBox.Show("Se debe de registrar como mínimo un número de Teléfono Celular", "Validación de registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCBNroTel2.Focus();
                return "ERROR";
            }
            //if (txtCBNroTel.Text.Length > 0 && txtCBNroTel.Text.Length < 6)
            //{
            //    MessageBox.Show("Registre un valor correcto para el Teléfono (1) Fijo", "Validación de registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtCBNroTel.Focus();
            //    txtCBNroTel.SelectAll();
            //    return "ERROR";
            //}
            if (txtCBNroTel2.Text.Length > 0 && txtCBNroTel2.Text.Length < 6)
            {
                MessageBox.Show("Registre un valor correcto para el Teléfono Principal", "Validación de registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCBNroTel2.Focus();
                txtCBNroTel2.SelectAll();
                return "ERROR";
            }
            //if (txtTelefCel1.Text.Length > 0 && txtTelefCel1.Text.Length < 9)
            //{
            //    MessageBox.Show("Registre un valor correcto para el Teléfono(3) Celular", "Validación de registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtTelefCel1.Focus();
            //    txtTelefCel1.SelectAll();
            //    return "ERROR";
            //}

            //===========================================================//
            //Validando los Vinculados
            if (this.dtgVinculo.RowCount <= 0 && (Convert.ToInt32(cboTipPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipPersona.SelectedValue) == 3))
            {
                MessageBox.Show("Debe Registrar vinculados del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 3;
                conBusCliVin.btnBusCliente.Focus();
                return "ERROR";
            }
            if (txtCantEmpl.Text.Trim() == "" && checkEmpleador.Checked)
            {
                MessageBox.Show("Ingrese un valor correcto para el número de empleados", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtCantEmpl.Focus();
                txtCantEmpl.Text = "0";
                txtCantEmpl.SelectAll();
                return "ERROR";
            }
            //
            // VALIDANDO LA CONSISTENCIA ENTRE LA FECHA DE NACIMIENTO Y EL TIPO DE DOCUMENTO
            //
            if (((DataRowView)cboTipDocumento.SelectedItem).Row["cNomCorto"].ToString().Trim().ToUpper() == "DNI Menor".Trim().ToUpper())
            {
                // validar que el cliente sea menor de edad
                TimeSpan tsResta = clsVarGlobal.dFecSystem.Subtract(dtFecNac.Value);
                int nDias = tsResta.Days;
                decimal nAnios = nDias / 365;
                if (nAnios >= 18)
                {
                    MessageBox.Show("La fecha de nacimiento del cliente no concuerda con su tipo de Documento 'DNI Menor'", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
            }
            //
            // VALIDANDO LA CONSISTENCIA ENTRE LA FECHA DE NACIMIENTO Y EL TIPO DE DOCUMENTO
            //
            if (((DataRowView)cboTipDocumento.SelectedItem).Row["cNomCorto"].ToString().Trim().ToUpper() == "DNI".Trim().ToUpper())
            {
                // validar que el cliente sea mayor de edad
                TimeSpan tsResta = clsVarGlobal.dFecSystem.Subtract(dtFecNac.Value);
                int nDias = tsResta.Days;
                decimal nAnios = nDias / 365;
                if (nAnios < 18)
                {
                    MessageBox.Show("La fecha de nacimiento del cliente no concuerda con su tipo de Documento 'DNI'", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
            }
            return "OK";
        }
        private void HabilitarDir()
        {

        }
        private string ValidarDatos_PerNatural()
        {

            if (txtApePat.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Apellido Paterno ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtApePat.Focus();
                return "ERROR";
            }

            if (txtNom1.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Nombre del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtNom1.Focus();
                return "ERROR";
            }
            if (cboSexo.SelectedValue == null)
            {
                MessageBox.Show("Debe Seleccionar el Sexo del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboSexo.Focus();
                return "ERROR";
            }

            if (cboEstadoCivil.SelectedValue == null)
            {
                MessageBox.Show("Debe Seleccionar el Estado Civil del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboEstadoCivil.Focus();
                return "ERROR";
            }

            if (cboEstadoCivilSBS.SelectedValue == null)
            {
                MessageBox.Show("Debe Seleccionar el Estado Civil SBS del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboEstadoCivil.Focus();
                return "ERROR";
            }

            if (Convert.ToDateTime(dtFecNac.Value.ToShortDateString()) == Convert.ToDateTime(pdFecSistem.ToShortDateString()))
            {
                MessageBox.Show("Fecha de Nacimiento no válida", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                dtFecNac.Focus();
                return "ERROR";
            }

            if (conBusUbiNac.cboPais.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de Nacimiento del Cliente: Pais", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                conBusUbiNac.cboPais.Focus();
                return "ERROR";
            }
            if (conBusUbiNac.cboDepartamento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de Nacimiento del Cliente: Departamento", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                conBusUbiNac.cboDepartamento.Focus();
                return "ERROR";
            }
            if (conBusUbiNac.cboProvincia.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de Nacimiento del Cliente: Provincia", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                conBusUbiNac.cboProvincia.Focus();
                return "ERROR";
            }

            if (conBusUbiNac.cboDistrito.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de Nacimiento del Cliente: Distrito", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                conBusUbiNac.cboDistrito.Focus();
                return "ERROR";
            }

            if (conBusUbiNac.cboAnexo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de Nacimiento del Cliente: Comunidad", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                conBusUbiNac.cboAnexo.Focus();
                return "ERROR";
            }

            if (cboNivInstruc.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Nivel de Instrucción del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboNivInstruc.Focus();
                return "ERROR";
            }
            if (cboProfesion.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la Profesión de cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboProfesion.Focus();
                return "ERROR";
            }
            int? idProfesion = (int?)cboProfesion.SelectedValue;
            if (idProfesion != null && idProfesion.In(1, 144))
            {
                MessageBox.Show("La profesión del cliente tiene que ser diferente de NO DECLARA y NINGUNO.", "Registro de Clientes",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboProfesion.Focus();
                return "ERROR";
            }
            if (idProfesion != null && idProfesion == 145 && string.IsNullOrEmpty(txtProfesion.Text))
            {
                MessageBox.Show("Si seleccionó 'Otros' en Profesión de cliente, Debe especificarlo en la Parte Inferior", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtProfesion.Focus();
                return "ERROR";
            }

            if (cboClienteCargo1.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Cargo del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboNivInstruc.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboClienteCargo1.SelectedValue) == 37 && txtOtrosDesc.Text == "")
            {
                MessageBox.Show("Si seleccionó 'Otros' en Cargo de cliente, Debe especificarlo en la Parte Inferior", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtOtrosDesc.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboProfesion.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar la Profesión de cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboProfesion.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboProfesion.SelectedValue) == 145 && string.IsNullOrEmpty(txtProfesion.Text))
            {
                MessageBox.Show("Si seleccionó 'Otros' en Profesión de cliente, Debe especificarlo en la Parte Inferior", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtProfesion.Focus();
                return "ERROR";
            }

            /*validar actividad economica*/
            if (cboActividadInternaNat.SelectedIndex == -1)
            {                
                if (!lMenoresEdad)
                {
                    MessageBox.Show("Se debe indicar la Actividad Económica Interna", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboActividadInternaNat.Focus();
                    return "ERROR";
                }
            }
            
            /*validar fecha de inicio de actividad economica*/
            if (dtpFecIniActEcoNat.Text == " ")
            {
                if (cboActividadInternaNat.SelectedIndex != -1)
                {
                    MessageBox.Show("Debe seleccionar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
            }
            else
            {
                if (cboActividadInternaNat.SelectedIndex == -1)
                {
                    MessageBox.Show("No corresponde registrar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
                if (Convert.ToDateTime(dtpFecIniActEcoNat.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
                {
                    MessageBox.Show("La Fecha de inicio de la actividad económica no puede ser posterior a la de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
            }

            /*validar estado contribuyente*/
            if (cboEstadoContribNat.SelectedIndex == -1)
            {
                if (!lMenoresEdad)
                {
                    MessageBox.Show("Debe de indicar el estado del contribuyente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboEstadoContribNat.Focus();
                    return "ERROR";
                }
            }
            else if (Convert.ToInt32(cboEstadoContribNat.SelectedValue) == 1)
            {

                if ( Convert.ToInt32( cboTipDocAdi.SelectedValue ) == 4 )
                {
                    MessageBox.Show( "El estado: " + cboEstadoContribNat.Text + " sólo aplica para las personas naturales SIN RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    tbcCliente.SelectedIndex = 1;
                    cboEstadoContribNat.Focus();
                    return "ERROR";
                }
            }

            /*estado domicilio contribuyente*/
            if (cboCondDomNat.SelectedIndex == -1)
            {
                if (!lMenoresEdad)
                {
                    MessageBox.Show("Debe de indicar la Condición Domicilio del contribuyente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboCondDomNat.Focus();
                    return "ERROR";
                }
            }
            else if (Convert.ToInt32(cboCondDomNat.SelectedValue) == 1)
            {

                if (Convert.ToInt32(cboTipDocAdi.SelectedValue) == 4)
                {
                    MessageBox.Show("La Condición Domicilio: " + cboCondDomNat.Text + " sólo aplica para las personas naturales SIN RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboCondDomNat.Focus();
                    return "ERROR";
                }
            }

            /*estado del cliente*/
            if (cboEstadoCliNat.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el estado del cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboEstadoCliNat.Focus();
                return "ERROR";
            }            

            DateTime dFechaNac = dtFecNac.Value;
            DataTable dtValEdad = Cliente.CNValidaEdadCliente(dFechaNac, clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtValEdad.Rows[0]["Rpta"]) == 0)
            {
                if (MessageBox.Show("La edad de la persona en registro es de " + dtValEdad.Rows[0]["nEdad"].ToString() + " años. ¿Desea Continuar?", "Registro de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return "OK";
                }
                else
                {
                    return "ERROR";
                }

            }
            return "OK";
        }
        private string ValidarDatos_PerNaturalBeneficiario()
        {

            if (txtApePat.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Apellido Paterno ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtApePat.Focus();
                return "ERROR";
            }

            if (txtNom1.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Nombre del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                txtNom1.Focus();
                return "ERROR";
            }
            if (cboSexo.SelectedValue == null)
            {
                MessageBox.Show("Debe Seleccionar el Sexo del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboSexo.Focus();
                return "ERROR";
            }
            if (cboEstadoCivil.SelectedValue == null)
            {
                MessageBox.Show("Debe Seleccionar el Estado Civil del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                cboEstadoCivil.Focus();
                return "ERROR";
            }

            if (Convert.ToDateTime(dtFecNac.Value.ToShortDateString()) == Convert.ToDateTime(pdFecSistem.ToShortDateString()))
            {
                MessageBox.Show("Fecha de Nacimiento no válida", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 1;
                dtFecNac.Focus();
                return "ERROR";
            }

            /*validar actividad economica*/
            if (cboActividadInternaNat.SelectedIndex == -1)
            {
                if (!lMenoresEdad && (Convert.ToInt32(cboTipClasificacion.SelectedValue) == 11 || Convert.ToInt32(cboTipClasificacion.SelectedValue) == 12))
                {
                    MessageBox.Show("Para las personas con Negocio, se debe indicar la Actividad Económica y CIIU", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    cboActividadInternaNat.Focus();
                    return "ERROR";
                }
            }

            /*validar fecha de inicio de actividad economica*/
            if (dtpFecIniActEcoNat.Text == " ")
            {
                if (cboActividadInternaNat.SelectedIndex != -1)
                {
                    MessageBox.Show("Debe seleccionar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
            }
            else
            {
                if (cboActividadInternaNat.SelectedIndex == -1)
                {
                    MessageBox.Show("No corresponde registrar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
                if (Convert.ToDateTime(dtpFecIniActEcoNat.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
                {
                    MessageBox.Show("La Fecha de inicio de la actividad económica no puede ser posterior a la de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return "ERROR";
                }
            }       

            return "OK";
        }
        private string ValidarDatos_PerJuridica()
        {

            if (txtRazSocial.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar la Razon Social de la persona jurídica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtRazSocial.Focus();
                return "ERROR";
            }

            if (txtNomComercial.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar el Nombre Comercial de la persona jurídica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtNomComercial.Focus();
                return "ERROR";
            }

            if (txtSiglas.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar las Siglas de la persona jurídica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtSiglas.Focus();
                return "ERROR";
            }
            if (cboActividadEco3.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar la Actividad Económica y CIIU", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                cboActividadEco3.Focus();
                return "ERROR";
            }

            if (cboActividadInternaJur.SelectedIndex != -1)
            {
                if (dtpFecIniActEco.Text == " ")
                {
                    MessageBox.Show("Debe seleccionar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 2;
                    dtpFecIniActEco.Focus();
                    return "ERROR";
                }
                else if (Convert.ToDateTime(dtpFecIniActEco.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
                {
                    MessageBox.Show("La Fecha de inicio de la actividad económica no puede ser posterior a la de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 2;
                    dtpFecIniActEco.Focus();
                    return "ERROR";
                }
            }
            else
            {
                if (dtpFecIniActEco.Text != " ")
                {
                    MessageBox.Show("No corresponde registrar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 2;
                    dtpFecIniActEco.Focus();
                    return "ERROR";
                }
            }      

            if (txtNumPartReg.Text.Trim() == "" && cboZonaRegistral1.SelectedValue.ToString().Trim() != "0")
            {
                MessageBox.Show("Ingrese el Número de Partida Registral, de lo contrario Seleccione NINGUNO en Zona Registral", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtNumPartReg.Focus();
                return "ERROR";
            }

            if (Convert.ToDateTime(dtpFecCons.Value.ToShortDateString()) > Convert.ToDateTime(pdFecSistem.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Constitución de la Empresa no puede ser posterior a la de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                dtpFecCons.Focus();
                return "ERROR";
            }

            if (checkEmpleador.Checked == true && txtCantEmpl.Text.Trim() == "")
            {
                MessageBox.Show("Debe indicar la Cantidad de Empleados", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                txtCantEmpl.Focus();
                return "ERROR";
            }

            if (dtgVinculo.RowCount == 0)
            {
                MessageBox.Show("Debe Registrar al Representante de la persona jurídica, en la Sección de Vínculo", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 3;
                dtgVinculo.Focus();
                // btnAgrVinc.Focus();
                return "ERROR";
            }

            if (cboCondDomicilio.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la condición del domicilio de la persona jurídica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                cboCondDomicilio.Focus();
                // btnAgrVinc.Focus();
                return "ERROR";
            }

            if (cboEstadoCliJur.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el estado del cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCliente.SelectedIndex = 2;
                cboEstadoCliJur.Focus();
                // btnAgrVinc.Focus();
                return "ERROR";
            }
            return "OK";
        }
        public void HabilitarControles_Gen(Boolean Val)
        {
            //====================================================
            //--Datos Generales
            //====================================================
            this.RdBtnNacionPer.Enabled = Val;
            this.RdBtnNacionExt.Enabled = Val;
            this.cboTipoResidencia1.Enabled = Val;
            this.cboUbigeoPais.Enabled = Val;
            this.cboTipPersona.Enabled = Val;
            this.cboTipClasificacion.Enabled = Val;
            this.cboTipDocumento.Enabled = Val;
            this.cboTipDocAdi.Enabled = Val;
            this.txtCBDoc.Enabled = Val;
            this.txtCBDocAdi.Enabled = Val;
            this.txtCBNroTel.Enabled = Val;
            //this.txtCBNroTel2.Enabled = Val;
            this.txtCBCorreoElectronico.Enabled = Val;
            this.cboCodCiudad.Enabled = Val;
            txtTelefCel1.Enabled = Val;
            txtCorreElectronicoAd.Enabled = Val;
            if (Convert.ToInt32(this.cboTipDocumento.SelectedValue) == 1 || Convert.ToInt32(this.cboTipDocumento.SelectedValue) == 11)
            {
                if (String.IsNullOrEmpty(this.txtCBDoc.Text))
                {
                    this.txtCBDigVerificador.Enabled = Val;
                }
                else
                {
                    if (!String.IsNullOrEmpty(this.txtCBDigVerificador.Text) && CalcularDigitoVerificador(this.txtCBDoc.Text).ToString() == this.txtCBDigVerificador.Text)
                    {
                        this.txtCBDigVerificador.Enabled = false;
                    }
                    else
                    {
                        this.txtCBDigVerificador.Enabled = Val;
                    }
                }

            }
            else
            {
                this.txtCBDigVerificador.Enabled = false;
            }


            this.cboTipoZonas.Enabled = Val;
            this.cboTipoVia.Enabled = Val;
            this.textZonas.Enabled = Val;
            this.textVia.Enabled = Val;
            this.txtReferencia.Enabled = Val;
            this.cboTipoDir.Enabled = Val;
            cboSector1.Enabled = Val;
            txtResidencia.Enabled = Val;
            txtAnioConstruccion.Enabled = Val;
            txtNumPisos.Enabled = Val;
            txtNumSotanos.Enabled = Val;
            cboTipoUsoDelPredio1.Enabled = Val;
            cboTipoEstructuraPredominante1.Enabled = Val;
            checkPep.Enabled = Val;
            checkFatca.Enabled = Val;
            this.txtDirUbi.Enabled = Val;
            this.btnGeolocalizacion.Enabled = Val;
            this.cboTipViviendas.Enabled = Val;
        }
        public void HabilitarControles_PerNat(Boolean Val)
        {
            //====================================================
            //--Datos Persona Natural
            //====================================================
            this.txtApePat.Enabled = Val;
            this.txtApeMat.Enabled = Val;
            this.txtApeCasado.Enabled = Val;
            this.txtNom1.Enabled = Val;
            this.txtNom2.Enabled = Val;
            this.txtNom3.Enabled = Val;
            this.txtNom1.Enabled = Val;
            this.txtNroHijos.Enabled = Val;
            this.txtNroPerDep.Enabled = Val;
            this.conBusUbiNac.cboPais.Enabled = Val;
            this.conBusUbiNac.cboDepartamento.Enabled = Val;
            this.conBusUbiNac.cboProvincia.Enabled = Val;
            this.conBusUbiNac.cboDistrito.Enabled = Val;
            this.conBusUbiNac.cboAnexo.Enabled = Val;
            this.txtUbigeoNac.Enabled = Val;
            this.dtFecNac.Enabled = Val;
            this.cboEstadoCivil.Enabled = Val;
            this.cboSexo.Enabled = Val;
            this.cboNivInstruc.Enabled = Val;
            this.cboProfesion.Enabled = Val;
            this.btnMiniBusqProf.Enabled = Val;

            this.cboClienteCargo1.Enabled = Val;
            this.btnMiniBusqCargo.Enabled = Val;

            //this.txtOtrosDesc.Enabled = Val;
            //this.txtProfesion.Enabled = Val;
            this.dtpFecIniActEcoNat.Enabled = Val;
            cboEstadoCliNat.Enabled = Val;

            cboEstadoContribNat.Enabled = Val;
            dtpFechaEstadoConNat.Enabled = Val;            
            cboCondDomNat.Enabled = Val;
            dtpFecFallec.Enabled = Val;


            cboActividadInternaNat.Enabled = Val;            
            cboActividadInternaNatAd.Enabled = Val;
            btnMiniBusq1.Enabled = Val;
            btnMiniBusq2.Enabled = Val;
            cboProfesion.Enabled = Val;
            this.btnMiniBusqProf.Enabled = Val;
            
            //if (pcTipOpe == "A" && Convert.ToInt32(cboNivInstruc.SelectedValue) > 4)
            //{
            //    cboProfesion.Enabled = true;

            //}
            //else
            //{
            //    cboProfesion.Enabled = false;
            //    txtProfesion.Enabled = false;
            //}
            //if (pcTipOpe == "N")
            //{
            //    cboProfesion.Enabled = false;
            //    txtProfesion.Enabled = false;
            //}

        }
        public void HabilitarControles_PerJur(Boolean Val)
        {
            //====================================================
            //--Datos Persona Jurídica
            //====================================================
            this.txtRazSocial.Enabled = Val;
            this.txtNomComercial.Enabled = Val;
            this.txtSiglas.Enabled = Val;
            this.dtpFecCons.Enabled = Val;
            this.dtpFecIniActEco.Enabled = Val;
            //   this.cboActividadEco2.Enabled = Val;
            //  this.cboActividadEco3.Enabled = Val;
            this.cboZonaRegistral1.Enabled = Val;
            this.cboZonaRegistral2.Enabled = Val;
            this.cboTipoIdentificacionPerJur.Enabled = Val;
            this.txtNumPartReg.Enabled = Val;
            this.checkEmpleador.Enabled = Val;
            this.txtCantEmpl.Enabled = Val;
            //          cboActividadEco5.Enabled = Val;
            cboActividadInternaJur.Enabled = Val;
            cboCondDomicilio.Enabled = Val;
            btnMiniBusqJur.Enabled = Val;
            cboMagnitudEmpresarial1.Enabled = Val;
            //cboTipoCategoriaJur.Enabled = Val;
            cboEstadoContribNat.Enabled = Val;
            dtpFecEstConJur.Enabled = Val;
            cboEstadoCliJur.Enabled = Val;
            dtpFecInact.Enabled = Val;
        }
        public void HabilitarControles_Vinculo(Boolean Val)
        {
            //====================================================
            //--Datos de Vinculo
            //====================================================
            this.cboTipVinculo.Enabled = Val;
            this.dtpFecIni.Enabled = Val;
            this.dtpFecFin.Enabled = Val;
            this.txtPorCapSocVot.Enabled = Val;
            //this.btnAgrVinc.Enabled = Val;
            //this.btnQuiVinc.Enabled = Val;
        }
        public void Buscar()
        {
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                //pcTipOpe = "N";
                conBusCliente.txtCodAge.Clear();
                conBusCliente.txtCodInst.Clear();
                conBusCliente.txtCodCli.Clear();
                conBusCliente.txtNroDoc.Clear();
                conBusCliente.txtNombre.Clear();
                conBusCliente.txtDireccion.Clear();
                conBusCliente.btnBusCliente.Enabled = true;

                LimpiarControles();

                tbDirCli.Rows.Clear();
                tbClienteVinculado.Rows.Clear();
                conBusCliVin.btnBusCliente.Enabled = false;
                conBusCliVin.txtCodCli.Enabled = false;

                HabilitarControles_Gen(false);
                HabilitarControles_PerNat(false);
                HabilitarControles_PerJur(false);
                HabilitarControles_Vinculo(false);

                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                btnImprimir.Enabled = false;
                chcBeneficiario.Checked = false;
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.txtCodCli.Focus();
                idDirecNueva = 0;

                conSplaf1.Text = "";
                //rbtnTrue.Enabled = false;
                //rbtnFalse.Enabled = false;
                checkPep.Enabled = false;

                //rbtnTrue.Checked = false;
                //rbtnFalse.Checked = false;
                checkPep.Checked = false;
                chcBeneficiario.Enabled = false;
                return;
            }

            LimpiarControles();
            tbDirCli.Rows.Clear();
            tbClienteVinculado.Rows.Clear();
            //  pcTipOpe = "A";
            //========================================================================
            //--Traer los datos del Cliente Buscado
            //========================================================================
            int nidCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);

            DataTable DatosTipCli = RetTipCli.ListarDatosCli(nidCli, "O");
            if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                DataTable DatosCliNat = RetTipCli.ListarDatosCli(nidCli, "N");

                //===================================================================================Q:\Core Bank20092013\ADM.Presentacion\frmAprobacionSolicitud.cs
                //--Asignando Valores: Datos Generales
                //===================================================================================

                String nacionalidad = Convert.ToString(DatosCliNat.Rows[0]["idNacionalidad"].ToString());

                if (nacionalidad == "0")
                    RdBtnNacionPer.Checked = true;
                else if (nacionalidad == "1")
                    RdBtnNacionExt.Checked = true;

                cboTipoResidencia1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idResiddencia"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idResiddencia"].ToString());
                cboUbigeoPais.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idPaisResidencia"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idPaisResidencia"].ToString());
                cboTipPersona.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["IdTipoPersona"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["IdTipoPersona"].ToString());
                int tmpCboTipClasificacion = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idTipoPerClasifica"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idTipoPerClasifica"].ToString());
                cboTipClasificacion.SelectedValue = tmpCboTipClasificacion == 1 ? 11 : tmpCboTipClasificacion;                
                cboTipDocumento.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idTipoDocumento"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idTipoDocumento"].ToString());
                txtCBDoc.Text = DatosCliNat.Rows[0]["cDocumentoID"].ToString();
                cboTipDocAdi.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["IdtipoDocAdicional"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["IdtipoDocAdicional"].ToString());
                txtCBDocAdi.Text = DatosCliNat.Rows[0]["cDocumentoAdicional"].ToString();
                cboCodCiudad.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idCodTelFijo"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idCodTelFijo"].ToString());
                txtCBNroTel.Text = DatosCliNat.Rows[0]["nNumeroTelefono"].ToString();
                txtCBNroTel2.Text = DatosCliNat.Rows[0]["cNumeroTelefono2"].ToString();
                txtTelefCel1.Text = DatosCliNat.Rows[0]["cNumeroTelefono3"].ToString();
                txtCBCorreoElectronico.Text = DatosCliNat.Rows[0]["cCorreoCli"].ToString();
                txtCorreElectronicoAd.Text = DatosCliNat.Rows[0]["cCorreoCliAdicional"].ToString();
                chcBeneficiario.Checked = Convert.ToBoolean(DatosCliNat.Rows[0]["lIndDatosBasic"]);
                txtCodSBS.Text = DatosCliNat.Rows[0]["cCodigoSBS"].ToString();
                cboEstadoContribNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoContribuyente"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoContribuyente"]);
                cboCondDomNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idCondDomicilio"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idCondDomicilio"]);
                txtCBDigVerificador.Text = DatosCliNat.Rows[0]["cDigitoVerificador"].ToString();

                //---cagar Datos de Direcciones
                CargarDirCli(nidCli);

                #region Autorizaciones de uso de datos
                conAutorizacionUsuDatos1.cCodCliente =conBusCliente.txtCodInst.Text +conBusCliente.txtCodAge.Text + conBusCliente.txtCodCli.Text;
                conAutorizacionUsuDatos1.idSolicitud = 0; 
                conAutorizacionUsuDatos1.pcNombre = conBusCliente.txtNombre.Text;
                conAutorizacionUsuDatos1.pcDireccion = conBusCliente.txtDireccion.Text;
                conAutorizacionUsuDatos1.pIdTipoPersona = conBusCliente.nidTipoPersona;
                conAutorizacionUsuDatos1.pcDocumentoID = conBusCliente.txtNroDoc.Text;
                conAutorizacionUsuDatos1.pcTelefono = conBusCliente.cTelefono;

                conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, Convert.ToInt32(cboTipDocumento.SelectedValue));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES       
       
                #endregion

                //===================================================================================
                //--Asignando Valores: Datos Persona Natural
                //===================================================================================
                TabPage t = tbcCliente.TabPages[0];
                tbcCliente.SelectedTab = t;
                txtApePat.Text = DatosCliNat.Rows[0]["cApellidoPaterno"].ToString();
                txtApeMat.Text = DatosCliNat.Rows[0]["cApellidoMaterno"].ToString();
                txtApeCasado.Text = DatosCliNat.Rows[0]["cApellidoCasado"].ToString();
                txtNom1.Text = DatosCliNat.Rows[0]["cNombre"].ToString();
                txtNom2.Text = DatosCliNat.Rows[0]["CNombreSeg"].ToString();
                txtNom3.Text = DatosCliNat.Rows[0]["cNombreOtros"].ToString();
                cboSexo.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idSexo"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idSexo"].ToString());
                cboEstadoCivil.SelectedValue = this.idEstadoCivil = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoCivil"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCivil"].ToString());
                cboEstadoCivilSBS.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoCivilSBS"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCivilSBS"].ToString());
                dtFecNac.Value = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["dFechaNacimiento"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaNacimiento"].ToString());
                txtNroHijos.Text = DatosCliNat.Rows[0]["nNumHijos"].ToString();
                txtNroPerDep.Text = DatosCliNat.Rows[0]["nNumPerDepend"].ToString();
                cboNivInstruc.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idNivelInstruccion"].ToString())) ? 1 : Convert.ToInt32(DatosCliNat.Rows[0]["idNivelInstruccion"].ToString());
                cboProfesion.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idProfesion"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idProfesion"].ToString());
                //cboOcupacion.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idOcupacion"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idOcupacion"].ToString());
                txtOtrosDesc.Text = DatosCliNat.Rows[0]["cDescCargo"].ToString();
                txtProfesion.Text = DatosCliNat.Rows[0]["cDescProfesion"].ToString();
                cboClienteCargo1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idCargo"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idCargo"].ToString());
                cboActividadEco.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idPadreActividad"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idPadreActividad"].ToString());
                cboActividadEco1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["nIdActivEco"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["nIdActivEco"].ToString());
                //if (Convert.ToInt32(DatosCliNat.Rows[0]["idTipoDocumento"]).In(11, 14) && Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaIniActEcoAlt"]).ToShortDateString() == Convert.ToDateTime("1753-1-1").ToShortDateString())
                if (Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaIniActEcoAlt"]).ToShortDateString() == Convert.ToDateTime("1753-1-1").ToShortDateString())
                {
                    this.dtpFecIniActEcoNat.Value = dFecIniActEcoDefault;
                    this.dtpFecIniActEcoNat.CustomFormat = " ";                    
                }
                else
                {
                    this.dtpFecIniActEcoNat.CustomFormat = "dd/MM/yyyy";
                    this.dtpFecIniActEcoNat.Value = Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaIniActEco"].ToString());
                }
                cboEstadoCliNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCli"].ToString());
                idEstadoCli = Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCli"].ToString());
                cboActividadInternaNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idActivEcoInterna"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idActivEcoInterna"].ToString());
                cboActividadInternaNatAd.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idActivEcoAdicional"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idActivEcoAdicional"].ToString());
                //cboTipoRolHogar1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idRolHogar"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idRolHogar"].ToString());
                //cboSegmentoSocio1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idSegmentoSocioEc"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idSegmentoSocioEc"].ToString());
                cboMagnitudEmpresarial1.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idMagnitudEmpresarial"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idMagnitudEmpresarial"].ToString());
                cboEstadoContribNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoContribuyente"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoContribuyente"].ToString());
                dtpFechaEstadoConNat.Value = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["dFechaEstadoCont"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaEstadoCont"].ToString());
                cboCondDomNat.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idCondDomicilio"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idCondDomicilio"].ToString());

                //===============================================================================
                //---Retorna Ubigeo
                //===============================================================================

                int idUbigeo = Convert.ToInt32(DatosCliNat.Rows[0]["idUbigeoNacimiento"]);
                RetornaUbigeo(idUbigeo);
                //conBusUbiNac.cargarUbigeo(idUbigeo);
                this.txtUbigeoNac.Text = conBusUbiNac.ObtenerUbigeoReniec();
                conBusUbiNac.cboAnexo.Enabled = false;


                if (idEstadoCli == 2)//Estado Fallecido
                {
                    dtpFecFallec.Visible = true;
                    dtpFecFallec.Value = Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaFallecimiento"].ToString());
                    lblBase83.Visible = true;
                }
                //---cagar Datos VINCULOS
                CargarVinculados(nidCli);
                //---Liberar Variables
                DatosCliNat.Dispose();


                //============================ IDENTIFICAR SI ES PEP ====================================>
                conSplaf1.validaClientePep(Convert.ToInt32(cboTipDocumento.SelectedValue), txtCBDoc.Text, 0);//Buscará por número de Documento
                if (conSplaf1.Text.Length > 2)//Se identificó como cliente PEP
                {
                    //rbtnTrue.Checked = true;
                    //rbtnFalse.Checked = false;
                    checkPep.Checked = true;
                }
                else
                {
                    //rbtnTrue.Checked = false;
                    //rbtnFalse.Checked = true;
                    checkPep.Checked = false;
                }

                //=======================================================================================>
            }
            else if (Convert.ToInt32(DatosTipCli.Rows[0]["idTipoPersona"]) == 2 || Convert.ToInt32(DatosTipCli.Rows[0]["idTipoPersona"]) == 3)
            {
                clsCNRetDatosCliente RetCliJur = new clsCNRetDatosCliente();
                DataTable DatosCliJur = RetTipCli.ListarDatosCli(nidCli, "J");

                //===============================================================================
                //--Asignando Valores: Datos Generales
                //===============================================================================
                String nacionalidad = Convert.ToString(DatosCliJur.Rows[0]["idNacionalidad"].ToString());

                if (nacionalidad == "0")
                    RdBtnNacionPer.Checked = true;
                else if (nacionalidad == "1")
                    RdBtnNacionExt.Checked = true;

                cboTipoResidencia1.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idResiddencia"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idResiddencia"].ToString());
                cboUbigeoPais.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idPaisResidencia"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idPaisResidencia"].ToString());
                cboTipPersona.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["IdTipoPersona"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["IdTipoPersona"].ToString());
                cboTipClasificacion.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idTipoPerClasifica"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idTipoPerClasifica"].ToString());
                cboTipDocumento.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idTipoDocumento"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idTipoDocumento"].ToString());
                txtCBDoc.Text = DatosCliJur.Rows[0]["cDocumentoID"].ToString();
                cboCodCiudad.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idCodTelFijo"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idCodTelFijo"].ToString());
                txtCBNroTel.Text = DatosCliJur.Rows[0]["nNumeroTelefono"].ToString();
                txtCBNroTel2.Text = DatosCliJur.Rows[0]["cNumeroTelefono2"].ToString();
                txtTelefCel1.Text = DatosCliJur.Rows[0]["cNumeroTelefono3"].ToString();
                txtCBCorreoElectronico.Text = DatosCliJur.Rows[0]["cCorreoCli"].ToString();
                txtCorreElectronicoAd.Text = DatosCliJur.Rows[0]["cCorreoCliAdicional"].ToString();
                //---cagar Datos de Direcciones
                CargarDirCli(nidCli);
                //===============================================================================
                //--Asignando Valores: Datos Persona Juridica
                //===============================================================================
                TabPage t = tbcCliente.TabPages[0];
                tbcCliente.SelectedTab = t;
                txtRazSocial.Text = DatosCliJur.Rows[0]["cRazonSocial"].ToString();
                txtNomComercial.Text = DatosCliJur.Rows[0]["cNombreComercial"].ToString();
                txtSiglas.Text = DatosCliJur.Rows[0]["cSiglas"].ToString();

                dtpFecCons.Value = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["dFechaConstitucion"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaConstitucion"].ToString());
                //dtpFecIniActEco.Value = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["dFechaIniActEco"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaIniActEco"].ToString());
                if (Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaIniActEcoAlt"]).ToShortDateString() == Convert.ToDateTime("1753-1-1").ToShortDateString())
                {
                    this.dtpFecIniActEco.Value = dFecIniActEcoDefault;
                    this.dtpFecIniActEco.CustomFormat = "dd/MM/yyyy";
                }
                else
                {
                    this.dtpFecIniActEco.CustomFormat = "dd/MM/yyyy";
                    this.dtpFecIniActEco.Value = Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaIniActEco"].ToString());
                }
                cboZonaRegistral1.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idUbigeoPadre"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idUbigeoPadre"].ToString());
                cboZonaRegistral2.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["nIdZonaReg"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["nIdZonaReg"].ToString());
                cboTipoIdentificacionPerJur.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idIdentificacion"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idIdentificacion"].ToString());
                txtNumPartReg.Text = DatosCliJur.Rows[0]["nNumPartReg"].ToString();
                cboActividadEco2.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idPadreActividad"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idPadreActividad"].ToString());
                cboActividadEco3.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["nIdActivEco"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["nIdActivEco"].ToString());

                checkEmpleador.Checked = Convert.ToBoolean(DatosCliJur.Rows[0]["lEmpleador"]);
                chcBeneficiario.Checked = Convert.ToBoolean(DatosCliJur.Rows[0]["lIndDatosBasic"]);
                txtCantEmpl.Text = DatosCliJur.Rows[0]["cCantEmpl"].ToString();
                cboEstadoCliJur.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idEstadoCli"].ToString());
                idEstadoCli = Convert.ToInt32(DatosCliJur.Rows[0]["idEstadoCli"]);
                cboActividadInternaJur.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idActivEcoInterna"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idActivEcoInterna"]);
                cboCondDomicilio.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idCondDomicilio"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idCondDomicilio"]);
                txtCodSBS.Text = DatosCliJur.Rows[0]["cCodigoSBS"].ToString();
                cboMagnitudEmpresarial1.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idMagnitudEmpresarial"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idMagnitudEmpresarial"]);
                cboEstadoContribuyenteJur.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idEstadoContribuyente"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idEstadoContribuyente"]);
                dtpFecEstConJur.Value = Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaEstadoCont"]);
                if ((int)DatosCliJur.Rows[0]["nIdEstado"] == 0)
                {
                    this.lblIndEstado.Text = "El Cliente Cuenta con Documentos Pendientes para Regularizar (Zona y Oficina Registral y/o Partida Registral)";
                }
                if (idEstadoCli == 4)//Estado Inactivo
                {
                    dtpFecInact.Visible = true;
                    dtpFecInact.Value = Convert.ToDateTime(DatosCliJur.Rows[0]["dFechaInactividad"].ToString());
                    lblBase78.Visible = true;
                }
                //---cagar Datos de Vinculados
                CargarVinculados(nidCli);
                //---Liberar Variables
                DatosCliJur.Dispose();

                //-------- Sólo activo para clientes naturales ------->
                //rbtnTrue.Enabled = false;
                //rbtnFalse.Enabled = false;
                //rbtnTrue.Checked = false;
                //rbtnFalse.Checked = false;
                checkPep.Enabled = false;
                checkPep.Checked = false;
                //--------------------------------------------------->
            }

            //---Liberar Variables
            DatosTipCli.Dispose();

            //=====================================================
            //--Habilitar y Desabilitar Controles
            //=====================================================
            conBusCliente.btnBusCliente.Enabled = true;
            HabilitarControles_Gen(false);
            HabilitarControles_PerNat(false);
            HabilitarControles_PerJur(false);
            HabilitarControles_Vinculo(false);
            conBusCliVin.btnBusCliente.Enabled = false;
            conBusCliVin.txtCodCli.Enabled = false;
            //deshabilitando los controles de estado del contribuyente
            cboEstadoContribuyenteJur.Enabled = false;
            dtpFecEstConJur.Enabled = false;

            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = true;
            chcBeneficiario.Enabled = false;
            grbBase11.Enabled = false;
            //verificaTipoDocumentoMenorDeEdad();
        }
        private void RetornaUbigeo(int idUbigeo)
        {
            conBusUbiNac.cargarUbigeo(idUbigeo);
        }
        private void RetornaUbigeo(string cUbigeoRENIEC)
        {
            conBusUbiNac.cargarUbigeo(cUbigeoRENIEC);
        }
        private void Direccion(string letras, string Tipo)
        {

            String direccion;

            if (Tipo == "textZona")
                zona = letras;
            if (Tipo == "textVia")
                via = letras;

            if (cboTipoZonas.Text.Trim() == "**NINGUNO**")
            {
                zona = "";
            }
            if (cboTipoVia.Text.Trim() == "**NINGUNO**")
            {
                via = "";
            }

            direccion = zona + via;
            txtDireccion.Text = direccion;
        }
        private void habilitarFatca()
        {

            if (RdBtnNacionPer.Checked == true)
            {
                if (cboUbigeoPais.SelectedItem == null)
                    return;

                if (Convert.ToInt32(((DataRowView)cboUbigeoPais.SelectedItem)["nUbigeoSUNAT"]) == nUbigeoSunatPaisEEUU)
                {
                    //rbtnTrueFatca.Enabled = true;
                    //rbtnFalseFatca.Enabled = true;
                    checkFatca.Enabled = true;
                }
                else
                {
                    //rbtnTrueFatca.Enabled = false;
                    //rbtnFalseFatca.Enabled = true;
                    checkFatca.Enabled = true;
                }
                //rbtnTrueFatca.Checked = false;
                //rbtnFalseFatca.Checked = true;
                checkFatca.Checked = false;
            }
            else
            {
                //rbtnTrueFatca.Enabled = true;
                //rbtnFalseFatca.Enabled = true;
                checkFatca.Enabled = true;
            }

        }
        private void CambiarEstadoDigitoVerificador()
        {
            int idTipoDoc = Convert.ToInt32(this.cboTipDocumento.SelectedValue);
            if (idTipoDoc == 1 || idTipoDoc == 11) //DNI y DNI Menor
            {
                if (String.IsNullOrEmpty(this.txtCBDigVerificador.Text))
                {
                    this.txtCBDigVerificador.Enabled = true;
                }
                else
                {
                    this.txtCBDigVerificador.Enabled = false;
                }

            }
            else
            {
                this.txtCBDigVerificador.Clear();
                this.txtCBDigVerificador.Enabled = false;
            }
        }
        private int CalcularDigitoVerificador(string cDNI)
        {
            const string cNumeroEstablecido = "89456789";
            const string cSecuenciaCaracteres = "FGHIJKABCDE";
            string cNumeroDNI = cDNI;
            int nSumaTotal = 0, nProductoDigito = 0, nValorCaracter = 0, nPosicionCaracter = -1;
            char cCaracterCalculado;

            for (int i = 0; i < cNumeroEstablecido.Length; i++)
            {
                nProductoDigito = Convert.ToInt32(cNumeroDNI.Substring(i, 1)) * Convert.ToInt32(cNumeroEstablecido.Substring(i, 1));
                nSumaTotal += nProductoDigito;
            }

            nValorCaracter = (nSumaTotal % 11 == 0) ? 11 : nSumaTotal % 11;
            cCaracterCalculado = Convert.ToChar(Convert.ToInt32('A') + nValorCaracter - 1);
            nPosicionCaracter = cSecuenciaCaracteres.IndexOf(cCaracterCalculado) + 1;

            return nPosicionCaracter % 10;
        }
        #endregion

        private void dtgDireccion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDireccion.SelectedRows.Count > 0)
            {
                filaDir = e.RowIndex;
                idDirecNueva = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idDireccion"].Value.ToString());
                cboSector1.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idSector"].Value.ToString());
                cboTipoZonas.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idTipoZona"].Value.ToString());
                cboTipoVia.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idTipoVia"].Value.ToString());
                textZonas.Text = dtgDireccion.Rows[filaDir].Cells["cDesZona"].Value.ToString();
                textVia.Text = dtgDireccion.Rows[filaDir].Cells["cDesVia"].Value.ToString();
                cboTipoDir.SelectedValue = dtgDireccion.Rows[filaDir].Cells["idTipoDireccion"].Value.ToString();
                txtResidencia.Text = dtgDireccion.Rows[filaDir].Cells["nAñoReside"].Value.ToString();
                txtReferencia.Text = dtgDireccion.Rows[filaDir].Cells["cReferenciaDireccion"].Value.ToString();
                cboTipViviendas.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idTipoVivienda"].Value.ToString());
                txtAnioConstruccion.Text = dtgDireccion.Rows[filaDir].Cells["nAñoConstruccion"].Value.ToString() == "0" ? "" : dtgDireccion.Rows[filaDir].Cells["nAñoConstruccion"].Value.ToString();
                txtNumPisos.Text = dtgDireccion.Rows[filaDir].Cells["nPisos"].Value.ToString() == "0" ? "" : dtgDireccion.Rows[filaDir].Cells["nPisos"].Value.ToString();
                txtNumSotanos.Text = dtgDireccion.Rows[filaDir].Cells["nSotanos"].Value.ToString() == "-1" ? "" : dtgDireccion.Rows[filaDir].Cells["nSotanos"].Value.ToString();
                cboTipoEstructuraPredominante1.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["nIdTipoEstructura"].Value.ToString());
                cboTipoUsoDelPredio1.SelectedValue = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["nIdUsoDelPredio"].Value.ToString());

                txtDireccion.Text = dtgDireccion.Rows[filaDir].Cells["cDireccion"].Value.ToString();


                if (pcTipOpe == "N")
                { 
                    int idGeolocalizacion = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idGeolocalizacion"].Value.ToString());
                    if (idGeolocalizacion != 0)
                    {
                        clsCNCliente ObtenerGeolo = new clsCNCliente();
                        DataTable dtObtenerGeolo = ObtenerGeolo.CNListarDireccionGeolocalizacion(idGeolocalizacion);

                        txtLatitud.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["cLatitud"]);
                        txtLongitud.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["cLongitud"]);
                        txtidGeo.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["idGeolocalizacion"]);
                    }
                    else 
                    {
                        this.txtLatitud.Text = "";
                        this.txtLongitud.Text = "";
                        this.txtidGeo.Text = ""; 
                    }              
                }
                if (pcTipOpe == "A" || pcTipOpe == "O")
                {
                    int idGeolocalizacion = Convert.ToInt32(dtgDireccion.Rows[filaDir].Cells["idGeolocalizacion"].Value.ToString());
                    if (idGeolocalizacion != 0)
                    {
                        clsCNCliente ObtenerGeolo = new clsCNCliente();
                        DataTable dtObtenerGeolo = ObtenerGeolo.CNListarDireccionGeolocalizacion(idGeolocalizacion);

                        if (dtObtenerGeolo.Rows.Count > 0)
                        { 
                            txtLatitud.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["cLatitud"]);
                            txtLongitud.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["cLongitud"]);
                            txtidGeo.Text = Convert.ToString(dtObtenerGeolo.Rows[0]["idGeolocalizacion"]);                       
                        }
                    }
                    else 
                    {
                        this.txtLatitud.Text = "";
                        this.txtLongitud.Text = "";
                        this.txtidGeo.Text = "";                    
                    }              
                }

                if (!String.IsNullOrEmpty(dtgDireccion.Rows[filaDir].Cells["idUbigeo"].Value.ToString()))
                {
                    clsCNCliente ListaUbigeo = new clsCNCliente();
                    DataTable dListaUbigeo = ListaUbigeo.CNListarUbigeo(dtgDireccion.Rows[filaDir].Cells["idUbigeo"].Value.ToString());

                    if (dListaUbigeo.Rows.Count == 0) 
                    {
                        MessageBox.Show("No se encontró Ubigeo.", "Obtener Ubigeo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    txtDirUbi.Text = Convert.ToString(dListaUbigeo.Rows[0]["UBICACION"]);
                    txtCodDirUbi.Text = Convert.ToString(dListaUbigeo.Rows[0]["UBIGEO"]);

                }

                if (btnEditar.Enabled)
                {

                }
                else
                {
                    btnMiniActDir.Enabled = true;
                }

                if (btnGrabar.Enabled == true && btnMiniActDir.Enabled == true)
                {
                    lanzarTooltipDir();
                }
            }
            else
            {
                this.cboTipoZonas.SelectedValue = 0;
                this.cboTipoVia.SelectedValue = 0;
                this.textZonas.Text = "";
                this.textVia.Text = "";
                this.txtDireccion.Text = "";
                this.txtReferencia.Text = "";
                this.cboTipViviendas.SelectedValue = 0;
                this.txtLatitud.Text = "";
                this.txtLongitud.Text = "";
                this.txtidGeo.Text = ""; 
            }
            if (pcTipOpe == "O")
            {
                if (txtLatitud.Text.Trim() == "" || txtLongitud.Text.Trim() == "")
                {
                    btnGeolocalizacion.Enabled = false;
                }
                else 
                {
                    btnGeolocalizacion.Enabled = true;
                }

            }
        }

        private void cboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pcTipOpe == "A" && this.idEstadoCivil.In(1, 3, 4) && !Convert.ToInt32(this.cboEstadoCivil.SelectedValue).In(2, 5, this.idEstadoCivil) && !this.cboEstadoCliNat.Enabled)
            {
                MessageBox.Show("Modificación mediante solicitud para Cambio de Estado Civil a " + this.cboEstadoCivil.Text.ToString(), "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboEstadoCivil.SelectedIndexChanged -= cboEstadoCivil_SelectedIndexChanged;
                this.cboEstadoCivil.SelectedValue = this.idEstadoCivil;
                this.cboEstadoCivil.SelectedIndexChanged += cboEstadoCivil_SelectedIndexChanged;
            }
            if (pcTipOpe != "O")
            {
                if (cboEstadoCivilSBS.tbEstCivil.Rows.Count > 0)
                {
                    if (cboEstadoCivil.SelectedIndex >= 0)
                    {
                        cboEstadoCivilSBS.SelectedIndex = -1;
                        for (int i = 0; i < cboEstadoCivilSBS.tbEstCivil.Rows.Count; i++)
                        {
                            if (cboEstadoCivilSBS.tbEstCivil.Rows[i]["idEstadoCivil"].ToString().Trim().ToUpper() == cboEstadoCivil.tbEstCivil.Rows[cboEstadoCivil.SelectedIndex]["idEstadoRelacionSBS"].ToString().Trim().ToUpper())
                            {
                                cboEstadoCivilSBS.SelectedValue = cboEstadoCivilSBS.tbEstCivil.Rows[i]["idEstadoCivil"];
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dtFecNac_ValueChanged(object sender, EventArgs e)
        {
            if (dtFecNac.Value < clsVarGlobal.dFecSystem)
            {
                this.dtpFecIniActEcoNat.ValueChanged -= new System.EventHandler(dtpFecIniActEcoNat_ValueChanged);
                this.dtpFecIniActEcoNat.ValueChanged += new System.EventHandler(dtpFecIniActEcoNat_ValueChanged);
            }
        }

        private void txtCBDoc_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 2)
                this.txtCBDoc.MaxLength = 9;
        }

        private void dtpFecIniActEco_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDateTime(dtpFecIniActEco.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de inicio de actividad económica, no puede ser posterior a la Fecha de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecIniActEco.Focus();
                return;
            }
        }

        private void dtpFecIniActEcoNat_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDateTime(dtpFecIniActEcoNat.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de inicio de actividad económica, no puede ser posterior a la Fecha de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                this.dtpFecIniActEcoNat.Focus();
                return;
            }
        }

        private void cboProfesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProfesion.SelectedIndex > 0)
            {
                if (Convert.ToInt32(cboProfesion.SelectedValue) == 145)
                {
                    txtProfesion.Enabled = true;
                }
                else
                {
                    txtProfesion.Enabled = false;
                    txtProfesion.Clear();
                }
            }
        }

        private void lblBase54_Click(object sender, EventArgs e)
        {

        }

        private void txtPropVivienda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboEstadoCliNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstadoCliNat.SelectedIndex > -1)
            {
                if (pcTipOpe == "A")
                {
                    if (Convert.ToInt32(cboEstadoCliNat.SelectedValue) == 2)//Estado Fallecido
                    {
                        dtpFecFallec.Visible = true;
                        lblBase83.Visible = true;
                        dtpFecFallec.Enabled = true;
                    }
                    else
                    {
                        dtpFecFallec.Visible = false;
                        lblBase83.Visible = false;
                        dtpFecFallec.Enabled = false;
                    }
                }

            }
        }

        private void cboActividadInternaNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadInternaNat.SelectedIndex >= 0)
            {
                if (cboActividadInternaNat.dtActividadInt.Rows[cboActividadInternaNat.SelectedIndex]["idActividad"] == DBNull.Value)
                {
                    cboActividadEco1.SelectedValue = 0;
                    limpiarCombosCIIU();
                    return;
                }
                dtpFecIniActEcoNat.CustomFormat = "dd/MM/yyyy";
                int idActividad = Convert.ToInt32(cboActividadInternaNat.dtActividadInt.Rows[cboActividadInternaNat.SelectedIndex]["idActividad"]);
                int idCategoria = Convert.ToInt32((DBNull.Value != cboActividadInternaNat.dtActividadInt.Rows[cboActividadInternaNat.SelectedIndex]["idCategoria"]) ? cboActividadInternaNat.dtActividadInt.Rows[cboActividadInternaNat.SelectedIndex]["idCategoria"] : -1);
                cboTipoCategoriaNat.SelectedValue = idCategoria;


                int idActividadAnterior = 0;
                int nNivel = 0;
                while (idActividad != 0)
                {
                    idActividadAnterior = idActividad;
                    DataTable dtPadre = ObjActividadEco.BuscarPadre(idActividad);
                    idActividad = Convert.ToInt32(dtPadre.Rows[0]["idPadreActividad"].ToString());
                    if (nNivel == 0)
                    {
                        this.cboActividadEco4.CargarActivEconomica(idActividad);
                        // cboActividadEco4.Enabled = true;
                        cboActividadEco4.SelectedValue = idActividadAnterior;
                    }
                    if (nNivel == 1)
                    {
                        this.cboActividadEco1.CargarActivEconomica(idActividad);
                        //   cboActividadEco1.Enabled = true;
                        cboActividadEco1.SelectedValue = idActividadAnterior;
                    }
                    nNivel++;
                }
                cboActividadEco.SelectedValue = idActividadAnterior;
            }
            else
            {
                cboActividadEco1.SelectedValue = 0;
                //  cboActividadEco1.Enabled = false;
                limpiarCombosCIIU();
            }
        }

        private void limpiarCombosCIIU()
        {
            cboActividadInternaNat.SelectedIndex = -1;
            cboActividadEco.SelectedIndex = -1;
            cboActividadEco1.SelectedIndex = -1;
            cboActividadEco4.SelectedIndex = -1;
            cboTipoCategoriaNat.SelectedIndex = -1;
            dtpFecIniActEcoNat.CustomFormat = " ";
        }

        private void limpiarCombosCIIUJUR()
        {
            cboActividadInternaJur.SelectedIndex = -1;
            cboActividadEco2.SelectedIndex = -1;
            cboActividadEco3.SelectedIndex = -1;
            cboActividadEco5.SelectedIndex = -1;
            cboTipoCategoriaJur.SelectedIndex = -1;
        }

        private void cboActividadEco_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboActividadEco2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboActividadInternaJur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadInternaJur.SelectedIndex >= 0)
            {
                int idActividad = Convert.ToInt32(cboActividadInternaJur.dtActividadInt.Rows[cboActividadInternaJur.SelectedIndex]["idActividad"]);
                int idCategoria = Convert.ToInt32((DBNull.Value != cboActividadInternaJur.dtActividadInt.Rows[cboActividadInternaJur.SelectedIndex]["idCategoria"]) ? cboActividadInternaJur.dtActividadInt.Rows[cboActividadInternaJur.SelectedIndex]["idCategoria"] : -1);
                cboTipoCategoriaJur.SelectedValue = idCategoria;


                int idActividadAnterior = 0;
                int nNivel = 0;
                while (idActividad != 0)
                {
                    idActividadAnterior = idActividad;
                    DataTable dtPadre = ObjActividadEco.BuscarPadre(idActividad);
                    idActividad = Convert.ToInt32(dtPadre.Rows[0]["idPadreActividad"].ToString());
                    if (nNivel == 0)
                    {
                        this.cboActividadEco5.CargarActivEconomica(idActividad);
                        //   cboActividadEco5.Enabled = true;
                        cboActividadEco5.SelectedValue = idActividadAnterior;
                    }
                    if (nNivel == 1)
                    {
                        this.cboActividadEco3.CargarActivEconomica(idActividad);
                        // cboActividadEco3.Enabled = true;
                        cboActividadEco3.SelectedValue = idActividadAnterior;
                    }
                    nNivel++;
                }
                cboActividadEco2.SelectedValue = idActividadAnterior;
            }
            else
            {
                cboActividadEco3.SelectedValue = 0;
                limpiarCombosCIIUJUR();
                //   cboActividadEco3.Enabled = false;
            }
        }

        private void cboActividadEco3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSector1.SelectedIndex > -1)
            {
                if (Convert.ToInt32(cboSector1.SelectedValue) == 1 || Convert.ToInt32(cboSector1.SelectedValue) == 2 || Convert.ToInt32(cboSector1.SelectedValue) == 3)//Validación para el SECTOR URBANO
                {
                    if (pcTipOpe != "O")
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }

                listarZonaSector();
                cboTipoZonas.SelectedValue = -1;
            }
        }

        private void cboActividadEco1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboActividadEco4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBase1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            frmListaActivEcoInterna frmActivEco = new frmListaActivEcoInterna();
            frmActivEco.ShowDialog();
            if (frmActivEco.aceptado)
            {
                cboActividadInternaNat.SelectedValue = frmActivEco.idActivEcoInt;
            }
            else
            {
                limpiarCombosCIIU();
            }

        }

        private void txtBusActivEco_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnMiniBusq2_Click(object sender, EventArgs e)
        {
            frmListaActivEcoInterna frmActivEco = new frmListaActivEcoInterna();
            frmActivEco.ShowDialog();
            if (frmActivEco.aceptado)
            {
                cboActividadInternaNatAd.SelectedValue = frmActivEco.idActivEcoInt;
            }
            else
            {
                cboActividadInternaNatAd.SelectedIndex = -1;
            }
        }

        private bool ValidarRegDir()
        {
            //=============================================================
            //--Validar Datos de Ingreso de Dirección
            //=============================================================

            if (cboTipoDir.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar Tipo Dirección.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDir.Focus();
                return false;
            }

            if (txtCodDirUbi.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar la Ubicación del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDirUbi.Focus();
                return false;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar la Dirección del Cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDireccion.Focus();
                return false;
            }
            if (cboTipoZonas.Text == "")
            {
                MessageBox.Show("Especifique el Tipo de Zona", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoZonas.Focus();
                return false;
            }
            if (cboTipoVia.Text == "")
            {
                MessageBox.Show("Especifique el Tipo de Via", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoVia.Focus();
                return false;
            }
            if (cboTipoVia.SelectedValue.ToString().Trim() == "1" && cboTipoZonas.SelectedValue.ToString().Trim() == "1")
            {
                MessageBox.Show("Debe especificar al menos el Tipo y Nombre de la Zona o de la Vía", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoZonas.Focus();
                return false;
            }

            if (textZonas.Enabled == true && string.IsNullOrEmpty(textZonas.Text.Trim()))
            {
                MessageBox.Show("Indique el nombre de la Zona", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textZonas.Focus();
                return false;
            }
            if (textVia.Enabled == true && string.IsNullOrEmpty(textVia.Text.Trim()))
            {
                MessageBox.Show("Indique el nombre de la Via", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textVia.Focus();
                return false;
            }
            if (cboSector1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el tipo de sector", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSector1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtResidencia.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el(los) año(s) de residencia", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResidencia.Focus();
                return false;
            }
            //=====================================
            //Validación del código de suministro
            //=====================================
            if (Convert.ToInt32(cboSector1.SelectedValue) == 1)//Validación para el SECTOR URBANO
            {

            }
            else
            {

            }

            if (string.IsNullOrEmpty(txtReferencia.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Referencia de la Dirección", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReferencia.Focus();
                return false;
            }

            if (cboTipViviendas.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Vivienda", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipViviendas.Focus();
                return false;
            }

            //if (txtOtrosVivienda.Enabled == true && string.IsNullOrEmpty(txtOtrosVivienda.Text.Trim()))
            //{
            //    MessageBox.Show("Si Seleccionó OTROS en Tipo de Vivienda, debe Especificarlo", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtOtrosVivienda.Focus();
            //    return false;
            //}

            //if (txtPropVivienda.Enabled == true && string.IsNullOrEmpty(txtPropVivienda.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese el Nombre del Propietario del Domicilio del Cliente ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtPropVivienda.Focus();
            //    return false;
            //}

            if (txtAnioConstruccion.Enabled && !string.IsNullOrEmpty(txtAnioConstruccion.Text.Trim()) && int.Parse(txtAnioConstruccion.Text) > clsVarGlobal.dFecSystem.Year)
            {
                MessageBox.Show("El año de construcción no puede ser mayor al año actual.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnioConstruccion.Focus();
                return false;
            }

            if (txtAnioConstruccion.Enabled && !string.IsNullOrEmpty(txtAnioConstruccion.Text.Trim()) && int.Parse(txtAnioConstruccion.Text) < Convert.ToInt32(clsVarApl.dicVarGen["nAnioMinimoConstruccion"]))
            {
                MessageBox.Show("El año mínimo permitido es: " + clsVarApl.dicVarGen["nAnioMinimoConstruccion"], "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnioConstruccion.Focus();
                return false;
            }

            if (txtNumPisos.Enabled && !string.IsNullOrEmpty(txtNumPisos.Text.Trim()) && int.Parse(txtNumPisos.Text) <= 0)
            {
                MessageBox.Show("Ingresa un número de pisos correcto.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumPisos.Focus();
                return false;
            }

            if (txtAnioConstruccion.Text.Trim() == "" || txtNumPisos.Text.Trim() == "" || txtNumSotanos.Text.Trim() == "" || cboTipoEstructuraPredominante1.SelectedIndex == 0 || cboTipoUsoDelPredio1.SelectedIndex == 0)
                return validarReglasMultiriesgo();

            return true;
        }

        private void btnMiniBusqJur_Click(object sender, EventArgs e)
        {
            frmListaActivEcoInterna frmActivEco = new frmListaActivEcoInterna();
            frmActivEco.ShowDialog();
            if (frmActivEco.aceptado)
            {
                cboActividadInternaJur.SelectedValue = frmActivEco.idActivEcoInt;
            }
            else
            {
                limpiarCombosCIIUJUR();
                cboTipoCategoriaJur.SelectedIndex = -1;
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (!ValidarRegDir())
            {
                return;
            }

            if (pcTipOpe == "N" || pcTipOpe == "A")
            { 
                foreach (DataGridViewRow row in dtgDireccion.Rows)
                {
                    if (row.Cells["cmb"].Value.ToString() == cboTipoDir.SelectedValue.ToString())
                    {
                        MessageBox.Show("Ya existe Tipo de Dirección: \"" + cboTipoDir.Text + "\" registrado.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }           
            }

            string textoIdGeo;
            if (txtidGeo.Text == "")
            {
                textoIdGeo = "0";
            }
            else 
            {
                textoIdGeo = txtidGeo.Text;
            }

            DataRow dr = tbDirCli.NewRow();
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                dr["idCli"] = 0;
            }
            else
            {
                dr["idCli"] = conBusCliente.txtCodCli.Text.Trim();
            }
            dr["idUbigeo"] = txtCodDirUbi.Text;
            dr["cDireccion"] = txtDireccion.Text.Trim();
            dr["cReferenciaDireccion"] = txtReferencia.Text.Trim();
            dr["idTipoDireccion"] = cboTipoDir.SelectedValue.ToString().Trim();
            dr["idDireccion"] = 0;
            dr["Estado"] = 'N';
            dr["idTipoZona"] = cboTipoZonas.SelectedValue.ToString().Trim();
            dr["cDesZona"] = textZonas.Text;
            dr["idTipoVia"] = cboTipoVia.SelectedValue.ToString().Trim();
            dr["cDesVia"] = textVia.Text;
            dr["cNumero"] = "";
            dr["cDepartamento"] = "";
            dr["cInterior"] = "";
            dr["cKilometro"] = "";
            dr["cManzana"] = "";
            dr["cLote"] = "";
            dr["cBlock"] = "";
            dr["cEtapa"] = "";
            dr["idTipoVivienda"] = cboTipViviendas.SelectedValue.ToString().Trim();
            dr["cdescOtros"] = "";
            dr["cNombrePropietario"] = "";
            dr["idSector"] = cboSector1.SelectedValue.ToString();
            dr["cCodSuministro"] = "";
            dr["idTipoConstruccion"] = "0";
            dr["nAñoReside"] = txtResidencia.Text;
            dr["lDirPrincipal"] = false;
            dr["idSuministro"] = "0";
            dr["nIdUsoDelPredio"] = 0;
            dr["nIdTipoEstructura"] = 0;
            dr["nAñoConstruccion"] = string.IsNullOrEmpty(txtAnioConstruccion.Text) ? 0 : int.Parse(txtAnioConstruccion.Text);
            dr["nPisos"] = string.IsNullOrEmpty(txtNumPisos.Text) ? 0 : int.Parse(txtNumPisos.Text);
            dr["nSotanos"] = string.IsNullOrEmpty(txtNumSotanos.Text) ? -1 : int.Parse(txtNumSotanos.Text);
            dr["idGeolocalizacion"] = textoIdGeo;
            tbDirCli.Rows.Add(dr);


            //Mostrar Nombre en grilla
            int filaReg = 0;
            if (dtgDireccion.Rows.Count > 1)
            {
                filaReg = dtgDireccion.Rows.Count - 1;
            }
            dtgDireccion.Rows[filaReg].Cells["cmb"].Value = Convert.ToInt32(cboTipoDir.SelectedValue.ToString());
            

            btnAgregar.Enabled = false;
            btnMiniNuevoDir.Enabled = true;
            btnQuitar.Enabled = true;
            btnMiniActDir.Enabled = true;
            dtgDireccion.Enabled = true;
            //Limpiar los campos de la dirección
            LimpiarCamposDir(false);
        }

        private void LimpiarCamposDir(Boolean bDirReset)
        {
            if (bDirReset)
            {
                CargarUbigeobPorDefecto_DomicilioCliente();
            }
            this.cboTipoZonas.SelectedValue = 0;
            this.cboTipoVia.SelectedValue = 0;
            this.textZonas.Clear();
            this.textVia.Clear();
            this.txtDireccion.Clear();
            this.txtReferencia.Clear();
            this.cboSector1.SelectedIndex = -1;
            this.txtResidencia.Clear();
            this.txtAnioConstruccion.Clear();
            this.txtNumPisos.Clear();
            this.txtNumSotanos.Clear();
            this.cboTipoUsoDelPredio1.SelectedIndex = -1;
            this.cboTipoEstructuraPredominante1.SelectedIndex = -1;
            this.cboTipoDir.SelectedValue = -1;
            this.cboTipViviendas.SelectedValue = -1;
            this.txtidGeo.Clear();
            this.txtLatitud.Clear();
            this.txtLongitud.Clear();
            this.txtDirUbi.Clear();
            this.txtCodDirUbi.Clear();
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgDireccion.SelectedRows.Count > 0)
            {
                DataTable a = tbDirCli;
                int nFila = Convert.ToInt32(this.dtgDireccion.SelectedCells[0].RowIndex);
                if (dtgDireccion.Rows[nFila].Cells["Estado"].Value.ToString() == "N")
                {
                    // dtgDireccion.Rows.RemoveAt(nFila);
                    tbDirCli.Rows.RemoveAt(nFila);
                    //int i = 0;
                    //foreach (DataRow fila in tbDirCli.Rows)
                    //{
                    //    if (Convert.ToInt32(tbDirCli.Rows[i]["idDireccion"]) == Convert.ToInt32(dtgDireccion.Rows[nFila].Cells["idDireccion"].Value))
                    //    {
                    //        tbDirCli.Rows.RemoveAt(i);
                    //        LimpiarCamposDir();
                    //        return;
                    //    }
                    //    i = i + 1;
                    //}
                    LimpiarCamposDir(true);
                    //dtgDireccion.ClearSelection();
                    ProcessTabKey(true);

                    foreach (DataGridViewRow row in dtgDireccion.Rows)
                    {
                        row.Cells["lDirPrincipal"].ReadOnly = Convert.ToBoolean(row.Cells["lDirPrincipal"].Value);
                }
                }
                else
                {
                    if (Convert.ToBoolean(dtgDireccion.Rows[nFila].Cells["lDirPrincipal"].Value))
                    {
                        MessageBox.Show("No se puede eliminar la Dirección Principal", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                    // dtgVinculo.Rows[nFila].Cells["Estado"].Value = "E";
                        //tbDirCli.Columns["Estado"].ReadOnly = false;
                        //tbDirCli.Rows[nFila]["Estado"] = "E";
                        //        tbDirCli.Rows[i]["Estado"] = "E";

                        foreach (DataRow row in tbDirCli.Rows)
                        {                            
                            if (Convert.ToInt32(row["idDireccion"]) == Convert.ToInt32(dtgDireccion.Rows[nFila].Cells["idDireccion"].Value))
                            {
                    tbDirCli.Columns["Estado"].ReadOnly = false;
                                row["Estado"] = "E";
                                break;
                            }                            
                        }

                        //LimpiarCamposDir(true);
                        //dtgDireccion.ClearSelection();
                        //ProcessTabKey(true);

                        foreach (DataGridViewRow row in dtgDireccion.Rows)
                        {
                            row.Cells["lDirPrincipal"].ReadOnly = Convert.ToBoolean(row.Cells["lDirPrincipal"].Value);
                        }
                    }                    
                }

            }
            else
            {
                MessageBox.Show("No se ha seleccionado un Registro para Eliminar", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCamposDir(true);
            }
            if (dtgDireccion.Rows.Count == 0)
            {
                btnMiniActDir.Enabled = false;
                btnMiniNueVinc.Enabled = false;
                btnAgregar.Enabled = true;
            }
            this.btnQuitar.Focus();
        }

        private void btnMiniNuevo1_Click(object sender, EventArgs e)
        {
            LimpiarCamposDir(true);
            idDirecNueva = 0;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnMiniActDir.Enabled = false;
            dtgDireccion.Enabled = false;
        }

        private void btnMiniActualizar1_Click(object sender, EventArgs e)
        {
            string idGeoloc;
            if(txtidGeo.Text.Trim() == "")
            {
                idGeoloc = "0";
            }
            else
            {
                idGeoloc = txtidGeo.Text;
            }            
            if (!ValidarRegDir())
            {
                return;
            }
            tbDirCli.Rows[filaDir]["idUbigeo"] = txtCodDirUbi.Text;
            tbDirCli.Rows[filaDir]["cDireccion"] = txtDireccion.Text.Trim();
            tbDirCli.Rows[filaDir]["cReferenciaDireccion"] = txtReferencia.Text.Trim();
            tbDirCli.Rows[filaDir]["idTipoZona"] = cboTipoZonas.SelectedValue.ToString().Trim();
            tbDirCli.Rows[filaDir]["cDesZona"] = textZonas.Text;
            tbDirCli.Rows[filaDir]["idTipoVia"] = cboTipoVia.SelectedValue.ToString().Trim();
            tbDirCli.Rows[filaDir]["cDesVia"] = textVia.Text;
            tbDirCli.Rows[filaDir]["cNumero"] = ""; 
            tbDirCli.Rows[filaDir]["cDepartamento"] = "";
            tbDirCli.Rows[filaDir]["cInterior"] = "";
            tbDirCli.Rows[filaDir]["cKilometro"] = "";
            tbDirCli.Rows[filaDir]["cManzana"] = "";
            tbDirCli.Rows[filaDir]["cLote"] = "";
            tbDirCli.Rows[filaDir]["cBlock"] = "";
            tbDirCli.Rows[filaDir]["cEtapa"] = "";
            tbDirCli.Rows[filaDir]["idTipoVivienda"] = cboTipViviendas.SelectedValue.ToString().Trim();
            tbDirCli.Rows[filaDir]["cdescOtros"] = "";
            tbDirCli.Rows[filaDir]["cNombrePropietario"] = "";
            tbDirCli.Rows[filaDir]["idSector"] = cboSector1.SelectedValue.ToString();
            tbDirCli.Rows[filaDir]["cCodSuministro"] = "";
            tbDirCli.Rows[filaDir]["idSuministro"] = "0";
            tbDirCli.Rows[filaDir]["idTipoConstruccion"] = "0";
            tbDirCli.Rows[filaDir]["nAñoReside"] = txtResidencia.Text;
            tbDirCli.Rows[filaDir]["nAñoConstruccion"] = txtAnioConstruccion.Text.Trim() == "" ? "0" : txtAnioConstruccion.Text.ToString().Trim();
            tbDirCli.Rows[filaDir]["nPisos"] = txtNumPisos.Text.Trim() == "" ? "0" : txtNumPisos.Text.ToString().Trim();
            tbDirCli.Rows[filaDir]["nSotanos"] = txtNumSotanos.Text.Trim() == "" ? "-1" : txtNumSotanos.Text.ToString().Trim();
            tbDirCli.Rows[filaDir]["nIdTipoEstructura"] = (cboTipoEstructuraPredominante1.SelectedItem == null ? 0 : cboTipoEstructuraPredominante1.SelectedValue);
            tbDirCli.Rows[filaDir]["nIdUsoDelPredio"] = (cboTipoUsoDelPredio1.SelectedItem == null ? 0 : cboTipoUsoDelPredio1.SelectedValue);
            tbDirCli.Rows[filaDir]["idTipoDireccion"] = cboTipoDir.SelectedValue.ToString();
            tbDirCli.Rows[filaDir]["idGeolocalizacion"] = idGeoloc;

            //Mostrar en grilla
            dtgDireccion.Rows[filaDir].Cells["cmb"].Value = Convert.ToInt32(cboTipoDir.SelectedValue.ToString());
        }

        private bool validarReglasMultiriesgo()
        {
            if (conBusCliente.txtCodCli.Text.Trim() == "")
                return true;
            DataTable dtLsSeguros = new CRE.CapaNegocio.clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(Convert.ToInt32(this.conBusCliente.txtCodCli.Text.ToString()));
            DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                          where fila.Field<bool>("lVigente") == true && fila.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"])
                          select fila).FirstOrDefault();
            if (dr != null)
                MessageBox.Show("El cliente cuenta con un seguro multiriesgo vigente, Los campos del grupo Multiriesgo son obligatorios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return dr == null;
        }

        private void cboEstadoCliJur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstadoCliJur.SelectedIndex > -1)
            {
                if (pcTipOpe == "A")
                {
                    if (Convert.ToInt32(cboEstadoCliJur.SelectedValue) == 4)//Estado baja de oficio
                    {
                        dtpFecInact.Visible = true;
                        lblBase78.Visible = true;
                        cboEstadoContribuyenteJur.SelectedValue = 4;//Baja de Oficio-->Estado de contribuyente
                        cboEstadoContribuyenteJur.Enabled = false;
                        dtpFecInact.Enabled = true;
                    }
                    else
                    {
                        dtpFecInact.Visible = false;
                        lblBase78.Visible = false;
                        dtpFecInact.Enabled = false;
                    }
                }

            }
        }

        private void dtgVinculo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgVinculo.Rows.Count > 0)
            {
                filaVinc = e.RowIndex;
                cboTipVinculo.SelectedValue = Convert.ToInt32(tbClienteVinculado.Rows[filaVinc]["idTipoVinculo"]);
                dtpFecIni.Value = (tbClienteVinculado.Rows[filaVinc]["dFechaInicio"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(tbClienteVinculado.Rows[filaVinc]["dFechaInicio"]);
                dtpFecFin.Value = (tbClienteVinculado.Rows[filaVinc]["dFechaFinal"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(tbClienteVinculado.Rows[filaVinc]["dFechaFinal"]);
                conBusCliVin.CargardatosCli(Convert.ToInt32(tbClienteVinculado.Rows[filaVinc]["idCliVin"]));
                txtPorCapSocVot.Text = tbClienteVinculado.Rows[filaVinc]["nPorCapSocVot"].ToString();
                btnAgrVinc.Enabled = false;
            }

        }

        private void btnMiniNueVinc_Click(object sender, EventArgs e)
        {
            cboTipVinculo.SelectedIndex = -1;
            idCliVinc = 0;
            conBusCliVin.Enabled = true;
            conBusCliVin.btnBusCliente.Enabled = true;
            conBusCliVin.txtCodCli.Enabled = true;
            btnAgrVinc.Enabled = true;
            LimpiarVinculados();
        }

        private void btnMiniActVinc_Click(object sender, EventArgs e)
        {

            if (dtgVinculo.RowCount == 0)
            {
                MessageBox.Show("No hay Vinculados para actualización", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (pcTipOpe == "A" && cboTipVinculo.SelectedValue != null && Convert.ToInt32(cboTipVinculo.SelectedValue).In(1, 2)) //Conyuge, Representante
            {
                MessageBox.Show("Modificación mediante solicitud para Tipo Vinculo: " + cboTipVinculo.Text, "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(pcTipOpe == "A" && Convert.ToInt32(this.dtgVinculo.SelectedRows[0].Cells["idTipoVinculo"].Value).In(1, 2))
            {
                MessageBox.Show("Modificación mediante solicitud para Tipo Vinculo: " + this.dtgVinculo.SelectedRows[0].Cells["cTipoVinculo"].Value, "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!ValidarCliVinc())
            {
                return;
            }
            //e.RowIndex
            int SumaPorcentaje = 0; //agrego esta validacion -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            for (int i = 0; i < tbClienteVinculado.Rows.Count; i++)
            {
                if ( filaVinc !=  i )
                {
                    SumaPorcentaje = SumaPorcentaje + Convert.ToInt32(tbClienteVinculado.Rows[i]["nPorCapSocVot"]);
                }else
                {
                    if (tbClienteVinculado.Rows[i]["idTipoVinculo"].ToString().Trim() == "11")
                    {
                        SumaPorcentaje = SumaPorcentaje + Convert.ToInt32(txtPorCapSocVot.Text);
                    }
                       //SumaPorcentaje = SumaPorcentaje + Convert.ToInt32(txtPorCapSocVot.Text);
                }
            }

            if (SumaPorcentaje > 100)
            {
                MessageBox.Show("El porcentaje de las acciones no puede superar el 100%", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            tbClienteVinculado.Rows[filaVinc]["idTipoVinculo"] = Convert.ToInt32(cboTipVinculo.SelectedValue);
            tbClienteVinculado.Rows[filaVinc]["cTipoVinculo"] = ((clsTipoVinculo)cboTipVinculo.SelectedItem).cTipoVinculo;
            tbClienteVinculado.Rows[filaVinc]["dFechaInicio"] = dtpFecIni.Value;
            tbClienteVinculado.Rows[filaVinc]["dFechaFinal"] = dtpFecFin.Value;


            
            if (tbClienteVinculado.Rows.Count > 0)
            {
               for (int i = 0; i < tbClienteVinculado.Rows.Count; i++)
                {
                    if (tbClienteVinculado.Rows[i]["idTipoVinculo"].ToString().Trim() == "11")
                        {
                            tbClienteVinculado.Rows[i]["dFechaFinal"] = DBNull.Value;
                        }
                }
            }


            tbClienteVinculado.Rows[filaVinc]["nPorCapSocVot"] = txtPorCapSocVot.nDecValor;
            btnAgrVinc.Enabled = false;
            btnQuiVinc.Enabled = true;
            LimpiarVinculados();
        }

        private void cboEstadoContribNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idEstadoCli != 2 || idEstadoCli != 4)
            {
                cboEstadoContribNat.Enabled = false;
            }
        }

        private void cboCondDomNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* @todo verificar si se tiene que hacer esta validación
             * if (idEstadoCli != 2 || idEstadoCli != 4)
            {
                cboCondDomNat.Enabled = false;
            }
             * */
        }

        private void conBusCliVin_ClicBuscar(object sender, EventArgs e)
        {
            cboTipVinculo.Enabled = true;
            if (Convert.ToInt32(conBusCliVin.nidTipoPersona) != 1)
            {
                if (Convert.ToInt32(conBusCliente.nidTipoPersona) != 1)
                {
                   // if (Convert.ToInt32(cboTipVinculo.SelectedValue) != 11)
                   // {
                        MessageBox.Show("Una persona juridica solo puede ser vinculado como Accionista", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboTipVinculo.SelectedValue = 11;
                        cboTipVinculo.Enabled = false;
                        txtPorCapSocVot.Text = "0.00";
                        //conBusCliVin.limpiarControles();
                        //return;
                    //}
                }
                else
                {
                    MessageBox.Show("Una persona juridica no puede ser vinculado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCliVin.limpiarControles();
                    return;
                }
            }

        }

        private void conBusUbiNac_CambioDeIndex(object sender, EventArgs e)
        {
            if (RdBtnNacionExt.Checked == true && Convert.ToInt32(((DataRowView)conBusUbiNac.cboPais.SelectedItem).Row["idUbigeo"]) == 173)
            {
                MessageBox.Show("No puede seleccionar esta opción para persona EXTRANJERA.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusUbiNac.cboPais.SelectedValue = -1;
            }
            
            if (Convert.ToInt32(((DataRowView)conBusUbiNac.cboPais.SelectedItem).Row["idUbigeo"]) == 230)
            {
                checkFatca.Checked = true;
                grbBase12.Enabled = true;
            }
            else
            {
                checkFatca.Checked = false;
                grbBase12.Enabled = true;
            }
        }

        private void cboCodCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(((DataRowView)cboCodCiudad.SelectedItem).Row["idCodCiudad"]) != 1
                && Convert.ToInt32(((DataRowView)cboCodCiudad.SelectedItem).Row["idCodCiudad"]) != 2)
                txtCBNroTel.MaxLength = 6;
            else
                txtCBNroTel.MaxLength = 7;

            txtCBNroTel.Clear();
        }

        private void txtUbigeoNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtUbigeoNac.Text) && this.RdBtnNacionPer.Checked)
                {
                    RetornaUbigeo(txtUbigeoNac.Text.ToString());
                }
            }
        }

        private void txtUbigeoNac_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUbigeoNac.Text) && this.RdBtnNacionPer.Checked)
            {
                RetornaUbigeo(txtUbigeoNac.Text.ToString());
            }
        }

        private void txtApePat_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void validarSoloLetras(txtBase txt, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 209 || e.KeyChar == 241)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtApeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void txtNom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void txtNom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void txtNom3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void txtApeCasado_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void cboUbigeoPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarFatca();

            if ((RdBtnNacionPer.Checked == true || RdBtnNacionExt.Checked == true) && Convert.ToInt32(cboUbigeoPais.SelectedValue) == 173 && (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 4))
            {
                MessageBox.Show("No puede seleccionar esta opción por el tipo de RESIDENCIA.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboUbigeoPais.SelectedValue = -1;
            }

            else if (Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 3 || Convert.ToInt32(cboTipoResidencia1.SelectedValue) == 4)
            {
                txtDirUbi.Text = cboUbigeoPais.Text;
            }

        }

        private void chcBeneficiario_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chcBeneficiario.Checked)
            {
                checkPep.Checked = false;
                grbBase11.Enabled = false;
            }
            else
            {
                grbBase11.Enabled = true;
            }      
        }

        private void cboOcupacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboClienteCargo1_key(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        
        private void tooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();            
        }

        private void txtNroHijos_Enter(object sender, EventArgs e)
        {
            TextBox element = (TextBox)sender;
            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            //tooltip.ToolTipIcon = ToolTipIcon.Info;            
            tooltip.ShowAlways = false;
            tooltip.UseAnimation = true;
            tooltip.Show("Total de hijos del cliente", element, 0, -element.Height * 2, 3000);
        }

        private void txtNroHijos_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtNroPerDep_GotFocus(object sender, EventArgs e)
        {
            TextBox element = (TextBox)sender;
            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.ShowAlways = false;
            tooltip.UseAnimation = true;
            tooltip.Show("Personas que dependen económicamente del cliente o la Unidad familiar del cliente", element, 0, -element.Height * 2, 4000);
        }

        private void txtNroHijos_Leave(object sender, EventArgs e)
        {
            tooltip.Dispose();            
        }

        private void txtNroPerDep_Leave(object sender, EventArgs e)
        {
            tooltip.Dispose();
        }

        private void HabilitarControles_Contribuyente(bool activar)
        {
            if (activar)
            {
                this.cboEstadoContribNat.Enabled = true;
                this.cboEstadoContribNat.SelectedIndex = -1;
                this.dtpFechaEstadoConNat.Enabled = true;
                this.cboCondDomNat.Enabled = true;
                this.cboCondDomNat.SelectedIndex = -1;                
            }
            else 
            {

                this.cboEstadoContribNat.Enabled = false;
                this.cboEstadoContribNat.SelectedValue = 1;
                this.dtpFechaEstadoConNat.Enabled = false;
                this.cboCondDomNat.Enabled = false;
                this.cboCondDomNat.SelectedValue = 1;                
            }
        }

        private void dtpFecIniActEcoNat_ValueChanged(object sender, EventArgs e)
        {
            int nEdadMayor = 18;
            DateTime dFechaMayorEdad = dtFecNac.Value.AddYears(nEdadMayor);

            if (dtpFecIniActEcoNat.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de inicio de la Actividad Económica debe ser menor o igual a la fecha del sistema (" + clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy") + ").\n" +
                    "¡Corrija la fecha para continuar!",
                    "FECHA INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtpFecIniActEcoNat.Value < dFechaMayorEdad)
            {
                MessageBox.Show("El cliente cumplió(ra) la mayoría de edad (18 años) en la fecha " + dFechaMayorEdad.ToString("dd/MM/yyyy") + ".\n" +
                "* El inicio de Actividad Económica debe ser como mínimo la fecha de cumplimiento de mayoría de edad.", "FECHA NO ADMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpFecIniActEcoNat.Value = dFechaMayorEdad;
            }
        }

        private void dtpFecIniActEcoNat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.dtpFecIniActEcoNat.Value = dFecIniActEcoDefault;
                this.dtpFecIniActEcoNat.CustomFormat = " ";                
            }

            e.Handled = true;
        }        

        private void dtpFecIniActEco_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecIniActEco.Value > clsVarGlobal.dFecSystem)
                this.dtpFecIniActEco.CustomFormat = "";
            else
                this.dtpFecIniActEco.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFecIniActEco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.dtpFecIniActEco.Value = dFecIniActEcoDefault;
                this.dtpFecIniActEco.CustomFormat = " ";
            }

            e.Handled = true;
        }

        private void btnMiniActDir_MouseHover(object sender, EventArgs e)
        {
            lanzarTooltipDir();
        }

        private void lanzarTooltipDir()
        {
            if (btnGrabar.Enabled == true && btnMiniActDir.Enabled == true)
            {
                Button element = (Button)btnMiniActDir;
                tooltip = new ToolTip();
                tooltip.IsBalloon = true;
                tooltip.ShowAlways = false;
                tooltip.UseAnimation = true;
                tooltip.Show("Validar y Actualizar la dirección seleccionada", element, 0, -element.Height * 2, 4000);
            }            
        }

        private void btnMiniActDir_MouseLeave(object sender, EventArgs e)
        {
            tooltip.Dispose();
        }

        private void dtgDireccion_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            tooltip.Dispose();
        }

        private void btnRegNumTelf_Click(object sender, EventArgs e)
        {
            string cDocumentoID;
            string cNombre;
            string idCli;
          
            if (string.IsNullOrEmpty(this.conBusCliente.txtCodCli.Text.ToString()))
            {
                cDocumentoID = this.txtCBDoc.Text.ToString();
                idCli = "0";
                cNombre = this.txtApePat.Text.ToString() + " " + this.txtApeMat.Text.ToString() + " " + this.txtNom1.Text.ToString();

                if (!(cDocumentoID.Length > 7))
                {
                    return;
                }


            }
            else
            {
                 cDocumentoID = this.conBusCliente.txtNroDoc.Text.ToString();
                 cNombre = this.conBusCliente.txtNombre.Text.ToString();

                 idCli = Convert.ToString(Convert.ToInt32(this.conBusCliente.txtCodCli.Text.ToString()));


                Cliente.CNPrepararDatosTelefono(Convert.ToInt32(idCli));

            }

            frmRegistroNumerosTelf RegNum = new frmRegistroNumerosTelf(idCli,cDocumentoID,cNombre);
            RegNum.ShowDialog();
            String cNroPrincipal = RegNum.cNumeroPrincipal;

            txtCBNroTel2.Text = cNroPrincipal;
            
        }

        private void btnMiniBusqueda2_Click(object sender, EventArgs e)
        {
            frmListaDatosCompletar frmProfesiones = new frmListaDatosCompletar(1);
            frmProfesiones.ShowDialog();
            int idProfesion = frmProfesiones.idDato;
            idProfe = idProfesion;
            this.cboProfesion.SelectedValue = idProfe;
            //MessageBox.Show(Convert.ToString(idProfesion));
        }

        private void btnMiniBusqueda1_Click(object sender, EventArgs e)
        {
            frmListaDatosCompletar frmCargos = new frmListaDatosCompletar(2);
            frmCargos.ShowDialog();
            int idCargo = frmCargos.idDato;
            idCarg = idCargo;
            this.cboClienteCargo1.SelectedValue = idCarg;
            //MessageBox.Show(Convert.ToString(idCargo));

        }

        private bool GestionarConsultaCliente(string cIdTipoDoc, string cDocumentoID)
        {
            clsConsultaCliente objConsulta = new clsConsultaCliente();
            if(objConsulta.Autenticacion() == 0)
            {
                MessageBox.Show("Servicio sin respuesta por credenciales.\nProceda con el llenado manual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            objConsultaCliente = objConsulta.Consulta(cIdTipoDoc, cDocumentoID, Convert.ToString(clsVarGlobal.User.idUsuario));

            if (objConsultaCliente == null)
            {
                MessageBox.Show("Servicio sin respuesta.\nProceda con el llenado manual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (objConsultaCliente.success != 1)
            {
                MessageBox.Show("Respuesta del servicio no exitosa.\nProceda con el llenado manual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cIdTipoDoc.Equals("1") && string.IsNullOrEmpty(objConsultaCliente.data.primerNombre) ||
                cIdTipoDoc.Equals("4") && string.IsNullOrEmpty(objConsultaCliente.data.razonSocialClienteJuridico))
            {
                MessageBox.Show("Respuesta del servicio sin datos.\nProceda con el llenado manual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool GestionarConsultaReniec(string cDocumento)
        {
            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDocumento, clsVarGlobal.User.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
            clsReniec obj = new clsReniec(objParam, objReniec);
            obj.SetUrlReniecBus(clsVarApl.dicVarGen["cUrlReniecBus"]);
            objClienteBus = obj.GetReniecBus(1, cDocumento, clsVarGlobal.User.idUsuario);
            if (obj.objRespuesta == null)
            {
                MessageBox.Show("Servicio RENIEC sin respuesta.\nProceda con el llenado manual.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (obj.objRespuesta.success == 0)
            {
                MessageBox.Show("La consulta RENIEC tiene errores.\nProceda con el llenado manual.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private DateTime ConvertirFecha(string cFecha)
        {
            int nAnio = Convert.ToInt32(cFecha.Substring(0, 4));
            int nMes = Convert.ToInt32(cFecha.Substring(4, 2));
            int nDia = Convert.ToInt32(cFecha.Substring(6, 2));
            DateTime date1 = new DateTime(nAnio, nMes, nDia, 0, 0, 0);
            return date1;
        }

        private bool AsignarDatos()
        {
            this.epVerificado.Clear();
            if (this.objConsultaCliente == null)
            {
                MessageBox.Show("No se obtuvo la consulta de RENIEC.\nProceda con el llenado manual.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(this.cboTipDocumento.SelectedValue) == 1)
            {
                this.txtCBDigVerificador.Text = this.objConsultaCliente.data.digitoVerificadorPersonaNatural.Trim();
                this.epVerificado.SetError(this.txtCBDigVerificador, this.cVerificadoReniec);

                RellenaUbiDir(Convert.ToInt32(this.objConsultaCliente.data.codigoDistritoDomicilio));
                if (int.TryParse(this.objConsultaCliente.data.codigoZona, out int idZona))
                {
                    this.cboTipoZonas.SelectedValue = idZona;
                }
                if (int.TryParse(this.objConsultaCliente.data.codigoVia, out int idTipoVia))
                {
                    this.cboTipoVia.SelectedValue = idTipoVia;
                }
                this.textZonas.Text = this.objConsultaCliente.data.nombreZona.Trim();
                this.txtDireccion.Text = this.objConsultaCliente.data.direccionDomicilio.Trim();

                this.txtApePat.Text = this.objConsultaCliente.data.apellidoPaterno.Trim();
                this.epVerificado.SetError(this.txtApePat, this.cVerificadoReniec);
                this.txtApeMat.Text = this.objConsultaCliente.data.apellidoMaterno.Trim();
                this.epVerificado.SetError(this.txtApeMat, this.cVerificadoReniec);
                this.txtNom1.Text = this.objConsultaCliente.data.primerNombre.Trim();
                this.epVerificado.SetError(this.txtNom1, this.cVerificadoReniec);
                this.txtNom2.Text = this.objConsultaCliente.data.segundoNombre.Trim();
                this.epVerificado.SetError(this.txtNom2, this.cVerificadoReniec);
                this.txtNom3.Text = this.objConsultaCliente.data.otrosNombres.Trim();
                this.epVerificado.SetError(this.txtNom3, this.cVerificadoReniec);
                this.txtApeCasado.Text = this.objConsultaCliente.data.apellidosCasada.Trim();
                this.epVerificado.SetError(this.txtApeCasado, this.cVerificadoReniec);

                this.cboNivInstruc.SelectedValue = Convert.ToInt32(this.objConsultaCliente.data.nivelInstruccion);
                this.epVerificado.SetError(this.cboNivInstruc, this.cVerificadoReniec);

                RellenaUbiNac(Convert.ToInt32(this.objConsultaCliente.data.codigoUbigeoNacimiento));
                this.txtUbigeoNac.Text = this.conBusUbiNac.ObtenerUbigeoReniec();
                this.epVerificado.SetError(this.txtUbigeoNac, this.cVerificadoReniec);

                this.cboSexo.SelectedValue = Convert.ToInt32(this.objConsultaCliente.data.generoCliente);
                this.epVerificado.SetError(this.cboSexo, this.cVerificadoReniec);
                this.cboEstadoCivil.SelectedValue = Convert.ToInt32(this.objConsultaCliente.data.estadoCivilInstitucionCliente);
                this.epVerificado.SetError(this.cboEstadoCivil, this.cVerificadoReniec);
                if (DateTime.TryParseExact(this.objConsultaCliente.data.fechaNacimientoCliente, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dFechaNac))
                {
                    this.dtFecNac.Value = dFechaNac;
                    this.epVerificado.SetError(this.dtFecNac, this.cVerificadoReniec);
                }

                // SUNAT
                if (int.TryParse(this.objConsultaCliente.data.clasificacionTipoPersona, out int nTipClasificacion) &&
                    !string.IsNullOrEmpty(this.objConsultaCliente.data.documentoAdicionalRUC.Trim()))
                {
                    this.cboTipClasificacion.SelectedValue = nTipClasificacion;
                    this.cboTipDocAdi.SelectedValue = string.IsNullOrEmpty(this.objConsultaCliente.data.documentoAdicionalRUC.Trim()) ? -1 : 4;
                    this.txtCBDocAdi.Text = this.objConsultaCliente.data.documentoAdicionalRUC;
                }
                if (int.TryParse(this.objConsultaCliente.data.codigoCIIUInternoSunat, out int nActividadInternaNat))
                {
                    this.cboActividadInternaNat.SelectedValue = nActividadInternaNat;
                }
                if (DateTime.TryParse(this.objConsultaCliente.data.fechaInicioActividadSunat, out DateTime dFechaIniActEcoNat))
                {
                    this.dtpFecIniActEcoNat.Value = dFechaIniActEcoNat;
                }
                if (int.TryParse(this.objConsultaCliente.data.codigoEstadoContribuyenteSunat, out int nEstadoContribNat))
                {
                    this.cboEstadoContribNat.SelectedValue = nEstadoContribNat;
                }
                if (int.TryParse(this.objConsultaCliente.data.codigoCondicionDomicilioSunat, out int cbnCondDomNat))
                {
                    this.cboCondDomNat.SelectedValue = cbnCondDomNat;
                }
                return true;
            }
            if(Convert.ToInt32(this.cboTipDocumento.SelectedValue) == 4)
            {
                this.txtRazSocial.Text = this.objConsultaCliente.data.razonSocialClienteJuridico;
                this.txtNomComercial.Text = this.objConsultaCliente.data.nombreComercialClienteJuridico;
                this.txtSiglas.Text = this.objConsultaCliente.data.siglasJuridico;

                if (int.TryParse(this.objConsultaCliente.data.condicionDomicilioJuridico, out int nIdCondicionDomicilio))
                {
                    this.cboCondDomicilio.SelectedValue = nIdCondicionDomicilio;
                }

                if (int.TryParse(this.objConsultaCliente.data.codigoCIIUInternoJuridico, out int nidACtividadInterna))
                {
                    this.cboActividadInternaJur.SelectedValue = nidACtividadInterna;
                }

                if (DateTime.TryParse(this.objConsultaCliente.data.inicioActividadEconomicaJuridico, out DateTime dInicioActEconomica))
                {
                    this.dtpFecIniActEco.Value = dInicioActEconomica;
                }
                if (int.TryParse(this.objConsultaCliente.data.numeroEmpleadosJuridico, out int nCantEmpleados))
                {
                    this.txtCantEmpl.Text = nCantEmpleados.ToString();
                }
                if (int.TryParse(this.objConsultaCliente.data.estadoContribuyenteJuridico, out int idEstadoContribuyente))
                {
                    this.cboEstadoContribuyenteJur.SelectedValue = idEstadoContribuyente;
                }
                if(DateTime.TryParse(this.objConsultaCliente.data.fechaEstadoJuridico, out DateTime dEstadoCon))
                {
                    this.dtpFecEstConJur.Value = dEstadoCon;
                }
                return true;
            }
            return false;
        }

        private void RellenaUbiDir(int nIdUbigeoDir)
        {
            clsCNCliente ListaUbigeo = new clsCNCliente();
            DataTable dListaUbigeo = ListaUbigeo.CNListarUbigeo(Convert.ToString(nIdUbigeoDir));
            if (dListaUbigeo.Rows.Count > 0)
            {
                txtDirUbi.Text = Convert.ToString(dListaUbigeo.Rows[0]["UBICACION"]);
                txtCodDirUbi.Text = Convert.ToString(dListaUbigeo.Rows[0]["UBIGEO"]);
            }
        }

        private void RellenaUbiNac(int nIdUbigeoNac)
        {
            clsCNRetDatosCliente RetdDirUbi = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetdDirUbi.RetUbiCli(nIdUbigeoNac);
            if (tbDatUbi.Rows.Count > 0)
            {
                conBusUbiNac.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                conBusUbiNac.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                conBusUbiNac.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                conBusUbiNac.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                //conBusUbiNac.cboAnexo.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
            }
        }

        private bool GestionarConsultaSunat(string cDocumento)
        {
            if (cDocumento.Length != 8)
            {
                MessageBox.Show("Formato de DNI incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            clsSunat objSunat = new clsSunat(clsVarApl.dicVarGen["cUrlSunatBus"]);
            clsDatosSunatBus ojbDatosSunat = objSunat.GetSunatBus(1, cDocumento);

            if (objSunat.objResp != null)
            {
                if (objSunat.objResp.success == 0)
                {
                    MessageBox.Show("La consulta SUNAT tiene errores, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if(ojbDatosSunat == null)
                {
                    MessageBox.Show("No existen datos de la consulta SUNAT, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (ojbDatosSunat.idClasificacionTipoPersona == 2 && this.chcBeneficiario.Checked == false)
                {
                    MessageBox.Show("No existen datos de la consulta SUNAT, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    this.cboTipClasificacion.SelectedValue = ojbDatosSunat.idClasificacionTipoPersona;
                    this.epVerificado.SetError(this.cboTipClasificacion, this.cVerificadoSunat);
                    this.cboTipDocAdi.SelectedValue = string.IsNullOrEmpty(ojbDatosSunat.cNumeroRuc) ? -1 : 4;
                    this.epVerificado.SetError(this.cboTipDocAdi, this.cVerificadoSunat);
                    this.txtCBDocAdi.Text = ojbDatosSunat.cNumeroRuc;
                    this.epVerificado.SetError(this.txtCBDocAdi, this.cVerificadoSunat);
                    //this.cboActividadInternaNat.SelectedValue = Convert.ToInt32(dtSunat.Rows[0]["cCIIU"].ToString());
                    this.dtpFecIniActEcoNat.Value = ojbDatosSunat.dFechaInicioActividad;
                    this.epVerificado.SetError(this.dtpFecIniActEcoNat, this.cVerificadoSunat);
                    this.cboEstadoContribNat.SelectedValue = ojbDatosSunat.idEstadoContribuyente;
                    this.epVerificado.SetError(this.cboEstadoContribNat, this.cVerificadoSunat);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Servicio SUNAT sin respuesta, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool GestionarConsultaSunatJur(string cDocumento)
        {
            if (cDocumento.Length != 11)
            {
                MessageBox.Show("Formato de RUC incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            clsSunat objSunat = new clsSunat(clsVarApl.dicVarGen["cUrlSunatBus"]);
            clsDatosSunatBus ojbDatosSunat = objSunat.GetSunatBus(4, cDocumento);

            if (objSunat.objResp != null)
            {
                if (objSunat.objResp.success == 0)
                {
                    MessageBox.Show("La consulta SUNAT tiene errores, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (ojbDatosSunat == null)
                {
                    MessageBox.Show("No existen datos de la consulta SUNAT, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                this.dtpFecIniActEco.Value = ojbDatosSunat.dFechaInicioActividad;
                //this.epVerificado.SetError(this.dtpFecIniActEco, this.cVerificadoSunat);
                this.cboEstadoContribuyenteJur.SelectedValue = ojbDatosSunat.idEstadoContribuyente;
                //this.epVerificado.SetError(this.cboEstadoContribuyenteJur, this.cVerificadoSunat);

                this.cboTipoZonas.SelectedValue = ojbDatosSunat.idTipoZona;
                //this.epVerificado.SetError(this.cboTipoZonas, this.cVerificadoSunat);
                this.cboTipoVia.SelectedValue = ojbDatosSunat.idTipoVia;
                //this.epVerificado.SetError(this.cboTipoVia, this.cVerificadoSunat);

                this.txtDireccion.Text = ojbDatosSunat.cDireccion;
                //this.epVerificado.SetError(this.txtDireccion, this.cVerificadoSunat);

                this.txtRazSocial.Text = ojbDatosSunat.cRazonSocial;
                //this.epVerificado.SetError(this.txtRazSocial, this.cVerificadoSunat);
                this.txtSiglas.Text = ojbDatosSunat.cSiglas;
                //this.epVerificado.SetError(this.txtSiglas, this.cVerificadoSunat);
                RellenaUbiDir(ojbDatosSunat.idUbigeo);

                return true;
            }
            else
            {
                MessageBox.Show("No existen datos, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }

        private void txtCBDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && HabilitarBusReniec == 1 && Convert.ToInt32(cboTipDocumento.SelectedValue.ToString()) == 1)
            {
                clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                string cValidacion = xRetDatCli.RetDatVal(0, Convert.ToString(txtCBDoc.Text.Trim()), "D", Convert.ToInt32(cboTipDocumento.SelectedValue));

                if (cValidacion == "ERROR")
                {
                    if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                    {
                        MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDoc.SelectAll();
                        txtCBDoc.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDoc.SelectAll();
                        txtCBDoc.Focus();
                    }
                }
                else if (RdBtnNacionPer.Checked == true && Convert.ToInt32(cboTipPersona.SelectedValue) == 1 && Convert.ToInt32(cboTipDocumento.SelectedValue) == 1)
                {
                    if (txtCBDoc.Text.Trim().Length != 8)
                    {
                        MessageBox.Show("Formato de DNI incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (this.GestionarConsultaCliente(Convert.ToString(this.cboTipDocumento.SelectedValue), Convert.ToString(txtCBDoc.Text.Trim())))
                    {
                        if(this.AsignarDatos())
                        {
                            this.BloquearDatosSensibles(true);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else if (e.KeyChar == 13 && HabilitarBusReniec == 1 && Convert.ToInt32(cboTipDocumento.SelectedValue.ToString()) == 4)
            {
                clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                string cValidacion = xRetDatCli.RetDatVal(0, Convert.ToString(txtCBDoc.Text.Trim()), "D", Convert.ToInt32(cboTipDocumento.SelectedValue));
                if (cValidacion == "ERROR")
                {
                    if (Convert.ToInt32(cboTipPersona.SelectedValue) == 1)
                    {
                        MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDoc.SelectAll();
                        txtCBDoc.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBDoc.SelectAll();
                        txtCBDoc.Focus();

                    }
                }
                else if (RdBtnNacionPer.Checked == true && Convert.ToInt32(cboTipDocumento.SelectedValue) == 4)
                {

                    if (this.GestionarConsultaCliente(Convert.ToString(this.cboTipDocumento.SelectedValue), Convert.ToString(txtCBDoc.Text.Trim())))
                    {
                        if (this.AsignarDatos())
                        {
                            this.BloquearDatosSensibles(true);
                        }
                    }
                }
                else
                {
                    return;
                }

            }
        }

        private void btnMiniBusqueda1_Click_1(object sender, EventArgs e)
        {
            string cDocumentoID;
            string cNombre="";
            string idCli;

            if (string.IsNullOrEmpty(this.conBusCliente.txtCodCli.Text.ToString()))
            {
                cDocumentoID = this.txtCBDoc.Text.ToString();
                idCli = "0";
               
                if (Convert.ToInt32(cboTipPersona.SelectedValue.ToString()) == 1)
                {
                    cNombre = this.txtApePat.Text.ToString() + " " + this.txtApeMat.Text.ToString() + " " + this.txtNom1.Text.ToString();
                }
                else if (Convert.ToInt32(cboTipPersona.SelectedValue.ToString()) != 1)
                {
                    cNombre = this.txtRazSocial.Text.ToString();
                }

                if (!(cDocumentoID.Length > 7))
                {
                    return;
                }


            }
            else
            {
                cDocumentoID = this.conBusCliente.txtNroDoc.Text.ToString();
                cNombre = this.conBusCliente.txtNombre.Text.ToString();

                idCli = Convert.ToString(Convert.ToInt32(this.conBusCliente.txtCodCli.Text.ToString()));


                Cliente.CNPrepararDatosTelefono(Convert.ToInt32(idCli));

            }

            frmRegistroNumerosTelf RegNum = new frmRegistroNumerosTelf(idCli, cDocumentoID, cNombre);
            RegNum.ShowDialog();
            String cNroPrincipal = RegNum.cNumeroPrincipal;
            conBusCliente.cTelefono = cNroPrincipal;
            this.txtCBNroTel2.Text = cNroPrincipal;
        }

        private void listarZonaSector()
        {
            int idSector;
            if (Convert.ToInt32(cboSector1.SelectedValue.ToString()) == 2)
            {
                idSector = 2;
            }
            else
            {
                idSector = 1;
            }

            clsCNTipoZona ListaZona = new clsCNTipoZona();
            DataTable tbZona = ListaZona.ListaZonasSector(idSector);
            cboTipoZonas.DataSource = tbZona;
            cboTipoZonas.ValueMember = tbZona.Columns[0].ToString();
            cboTipoZonas.DisplayMember = tbZona.Columns[1].ToString();
        }

        private void listarTipoDireccion()
        {
            clsCNDirecCli ListaTipoDir = new clsCNDirecCli();
            DataTable tbTipoDir = ListaTipoDir.ListaTipoDireccion();
            cboTipoDir.DataSource = tbTipoDir;
            cboTipoDir.ValueMember = tbTipoDir.Columns[0].ToString();
            cboTipoDir.DisplayMember = tbTipoDir.Columns[1].ToString();
            cboTipoDir.SelectedValue = -1;
        }

        private void listarTipoVivienda()
        {
            clsCNTipoVivienda ListaVivienda = new clsCNTipoVivienda();
            DataTable tbVivienda = ListaVivienda.ListaViviendas();
            cboTipViviendas.DataSource = tbVivienda;
            cboTipViviendas.ValueMember = tbVivienda.Columns[0].ToString();
            cboTipViviendas.DisplayMember = tbVivienda.Columns[1].ToString();
            cboTipViviendas.SelectedValue = -1;
        }

        private void btnMapa1_Click(object sender, EventArgs e)
        {
            if (pcTipOpe == "N")
            {

                frmMapGeolocalizacion objMapGeolocalizacion = new frmMapGeolocalizacion();
                objMapGeolocalizacion.txtDireccion.Text = txtDireccion.Text;

                double cLatitud; double cLongitud;
                if (txtidGeo.Text.Trim() == "")
                {
                    clsCNCliente ListaAgeDir = new clsCNCliente();
                    DataTable dtListarAgeDir = ListaAgeDir.CNListarAgenciaGeolocalizacion(clsVarGlobal.nIdAgencia);

                    if (dtListarAgeDir.Rows.Count == 0)
                    {
                        MessageBox.Show("No se tiene Geolocalización de esta agencia.", "Ver Mapa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        cLatitud = Convert.ToDouble(dtListarAgeDir.Rows[0]["cLatitud"]);
                        cLongitud = Convert.ToDouble(dtListarAgeDir.Rows[0]["cLongitud"]);
                        objMapGeolocalizacion.btnRegistrar.Enabled = true;
                        objMapGeolocalizacion.btnActualizar1.Enabled = false;
                        objMapGeolocalizacion.cDireccionOficina = clsVarGlobal.cNomAge;
                    }
                }
                else 
                {
                    cLatitud = Convert.ToDouble(txtLatitud.Text);
                    cLongitud = Convert.ToDouble(txtLongitud.Text);
                    objMapGeolocalizacion.btnRegistrar.Enabled = false;
                    objMapGeolocalizacion.btnActualizar1.Enabled = true;
                    objMapGeolocalizacion.cDireccionOficina = txtDireccion.Text;
                    objMapGeolocalizacion.txtIdGeo.Text = txtidGeo.Text;
                    objMapGeolocalizacion.nZoom = 18;
                }
                objMapGeolocalizacion.nLatInicial = cLatitud;
                objMapGeolocalizacion.nLngInicial = cLongitud;
                if (objMapGeolocalizacion.ShowDialog() == DialogResult.OK)
                {
                    txtLatitud.Text = objMapGeolocalizacion.cliLatitud;
                    txtLongitud.Text = objMapGeolocalizacion.cliLongitud;
                    txtidGeo.Text = objMapGeolocalizacion.cliIdGeo;
                }
            }
            if (pcTipOpe == "A")
            {
                frmMapGeolocalizacion objMapGeolocalizacion = new frmMapGeolocalizacion();
                objMapGeolocalizacion.txtDireccion.Text = txtDireccion.Text;
                if (txtLatitud.Text == string.Empty)
                {
                    clsCNCliente ListaAgeDir = new clsCNCliente();
                    DataTable dtListarAgeDir = ListaAgeDir.CNListarAgenciaGeolocalizacion(clsVarGlobal.nIdAgencia);

                    if (dtListarAgeDir.Rows.Count == 0)
                    {
                        MessageBox.Show("No se tiene Geolocalización de esta agencia.", "Ver Mapa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    objMapGeolocalizacion.nLatInicial = Convert.ToDouble(dtListarAgeDir.Rows[0]["cLatitud"]);
                    objMapGeolocalizacion.nLngInicial = Convert.ToDouble(dtListarAgeDir.Rows[0]["cLongitud"]);  
                }
                else 
                { 
                    objMapGeolocalizacion.nLatInicial = Convert.ToDouble(txtLatitud.Text);
                    objMapGeolocalizacion.nLngInicial = Convert.ToDouble(txtLongitud.Text);
                    objMapGeolocalizacion.nZoom = 18;
                }

                objMapGeolocalizacion.cDireccionOficina = txtDireccion.Text;
                objMapGeolocalizacion.txtIdGeo.Text = txtidGeo.Text;
                objMapGeolocalizacion.btnRegistrar.Enabled = false;
                objMapGeolocalizacion.btnActualizar1.Enabled = true;
                if (objMapGeolocalizacion.ShowDialog() == DialogResult.OK)
                {
                    txtLatitud.Text = objMapGeolocalizacion.cliLatitud;
                    txtLongitud.Text = objMapGeolocalizacion.cliLongitud;
                    txtidGeo.Text = objMapGeolocalizacion.cliIdGeo;
                }

            }
            if (pcTipOpe == "O")
            {
                if (txtLatitud.Text == string.Empty || txtLongitud.Text == string.Empty) 
                {
                    return;
                }

                frmMapGeolocalizacion objMapGeolocalizacion = new frmMapGeolocalizacion();
                objMapGeolocalizacion.txtDireccion.Text = txtDireccion.Text;
                objMapGeolocalizacion.nLatInicial = Convert.ToDouble(txtLatitud.Text);
                objMapGeolocalizacion.nLngInicial = Convert.ToDouble(txtLongitud.Text);
                objMapGeolocalizacion.cDireccionOficina = txtDireccion.Text;
                objMapGeolocalizacion.nZoom = 18;
                objMapGeolocalizacion.btnRegistrar.Enabled = false;
                objMapGeolocalizacion.btnActualizar1.Enabled = false;
                objMapGeolocalizacion.ShowDialog();

            }
        }

        private void txtBase1_Leave(object sender, EventArgs e)
        {
            if (txtDirUbi.Text.Trim() != "") 
            { 
            RecuperaUbigeo(txtDirUbi.Text);
        }
        }
        private void tbcCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsgSegMultiR.Visible = tbcCliente.SelectedIndex == 0;
        }

        private void txtBase1_Click(object sender, EventArgs e)
        {
            if (txtDirUbi.Text.Trim() == "")
            {
                this.txtDirUbi.Clear();
                this.txtCodDirUbi.Clear();
            }
            else 
            { 
                DialogResult respMsg = MessageBox.Show("Desea actualizar dirección Ubigeo?", "Actualizar dirección Ubigeo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respMsg == DialogResult.Yes)
                {
                    this.txtDirUbi.Clear();
                    this.txtCodDirUbi.Clear();
                }            
            }
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && textBox.Text[selectionStart - 1] == ' ')
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                TextBox textBox = (TextBox)sender;
                int currentLineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                string currentLineText = textBox.Lines[currentLineIndex];

                if (string.IsNullOrWhiteSpace(currentLineText))
                {
                    e.Handled = true;
                }
            } 
        }

        private void txtDirUbi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == ':' || e.KeyChar == '/' || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == ' ')
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && textBox.Text[selectionStart - 1] == ' ')
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                TextBox textBox = (TextBox)sender;
                int currentLineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                string currentLineText = textBox.Lines[currentLineIndex];

                if (string.IsNullOrWhiteSpace(currentLineText))
                {
                    e.Handled = true;
                }
            } 
        }

        private void btnSolActualizacion_Click(object sender, EventArgs e)
        {
            if (this.conBusCliente.idCli == 0)
            {
                frmRegSolActCliente frm = new frmRegSolActCliente();
                frm.ShowDialog();
            }
            else
            {
                frmRegSolActCliente frm = new frmRegSolActCliente(this.conBusCliente.idCli);
                frm.ShowDialog();
            }

        }

        private void txtDirUbi_TextChanged(object sender, EventArgs e)
        {
            string cfiltroTexto = textofiltrado(txtDirUbi.Text);
            if (txtDirUbi.Text != cfiltroTexto)
            {
                txtDirUbi.Text = cfiltroTexto;
                txtDirUbi.SelectionStart = cfiltroTexto.Length;
            }
        }
        private string textofiltrado(string input)
        {
            StringBuilder textofiltrado = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == '-' || c == ' ')
                {
                    textofiltrado.Append(c);
                }
            }
            return textofiltrado.ToString();
        }
        private string textofiltradoViZona(string input)
        {
            StringBuilder textofiltrado = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || char.IsNumber(c) || char.IsControl(c) || c == '.' || c == '-' || c == ':' || c == '/' || c == ' ' || c == ',' || c == ';' || c == '\'')
                {
                    textofiltrado.Append(c);
                }
            }
            return textofiltrado.ToString();
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            string cfiltroTexto = textofiltradoViZona(txtReferencia.Text);
            if (txtReferencia.Text != cfiltroTexto)
            {
                txtReferencia.Text = cfiltroTexto;
                txtReferencia.SelectionStart = cfiltroTexto.Length;
            }
        }

        private void textVia_MouseHover(object sender, EventArgs e)
        {
            if (textVia.Enabled == true)
            {
                txtBase element = (txtBase)textVia;
                tooltip = new ToolTip();
                tooltip.IsBalloon = true;
                tooltip.ShowAlways = false;
                tooltip.UseAnimation = true;
                tooltip.Show("SECUENCIA: Nombre Via - Nro. - Mz. - Lt. - Int. - Dpto. - Bloque - Etapa -Km. \n EJEMPLO: LAS PALMERAS NRO 348 INTERIOR A DTPO 202 ", element, 0, -element.Height * 3, 2000);
            }
        }

    }
}

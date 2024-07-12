using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using CLI.CapaNegocio;
using CLI.Servicio;
using System.Runtime.CompilerServices;

namespace CLI.Presentacion
{
    public partial class frmReferidosClie : frmBase
    {
        #region Variables Globales        
        clsCNCliReferidos cliReferidos;
        clsCNProgFidelizacionClie cnProgFidelizacionClie;        
        clsCNCliente cliente;        
        CRE.CapaNegocio.clsCNCredito credito;
        clsUtils utils = new clsUtils();

        string cTitulo = "Mantenimiento de Referidos";
        public int nMode = 0; // 1=Registrar 2=Editar
        public int idCli = 0;
        public int idCliRef = 0;
        public int idAgencia = 0;
        public int idUsuAsesor = 0;

        //Variables para el uso del servicio reniec
        string cIdUsu = clsVarGlobal.User.idUsuario.ToString().Trim();
        string nIdMod = clsVarGlobal.idModulo.ToString().Trim();
        string cDocAutorizado = "";
        clsProcesaDatosRen dataRen;

        public DataTable tbDirCli;
        #endregion

        #region Eventos
        
        private void txtNroDoc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarCliente();
            }            
        }

        private void txtCelular_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) == false)
            {
                e.Handled = true;
            }
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.nMode = 1;
            LimpiarControles();
            HabilitarControles(true);
        }
        #endregion

        #region Métodos

        public frmReferidosClie()
        {
            InitializeComponent();
            LimpiarControles();
            HabilitarControles(true);
        }

        public frmReferidosClie(int idCli, int idCliRef, int idAgencia, int idUsuAsesor, int nMode)
        {
            InitializeComponent();

            LimpiarControles();            

            this.idCli = idCli;
            this.idCliRef = idCliRef;
            this.idAgencia = idAgencia;
            this.idUsuAsesor = idUsuAsesor;
            this.nMode = nMode; //1=Nuevo 2=Modificar            

            HabilitarControles(true);

            if (this.nMode == 2)
            {
                ObtenerReferido(this.idCli, this.idCliRef);
            }
        }       

        public void LimpiarControles()
        {
            idCliRef = 0;
            this.txtNroDoc.Clear();
            this.txtNombre.Clear();
            this.txtCelular.Clear();
            this.txtCorreo.Clear();            
        }

        public void HabilitarControles(bool lestado) 
        {
            bool lModifica = (this.nMode == 2) ? true : false;

            txtNroDoc.Enabled = !lModifica && lestado;
            txtCelular.Enabled = true;
            txtCorreo.Enabled = true;
            btnGrabar.Enabled = (this.nMode == 2) ? lestado : !lestado;
            btnCancelar.Enabled = true;
            btnBuscarDni.Enabled = !lModifica && lestado;
        }

        public bool EsNumero(string valor)
        {
            try
            {
                Convert.ToInt32(valor);
                return true;
            }
            catch { return false; }
        }

        public bool EsCorreo(string valor)
        {
            try
            {
                Regex xrEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                if (!xrEmail.IsMatch(valor) || String.IsNullOrEmpty(valor.Trim()))
                {                    
                    return false;
                }
                return true;
            }
            catch { return false; }
        }

        public bool EsCelular(string valor)
        {
            try
            {
                Regex xrTelefono = new Regex(@"^9\d{8}$");
                if (!xrTelefono.IsMatch((valor)) || String.IsNullOrEmpty(valor.Trim()))
                {                    
                    return false;
                }
                return true;
            }
            catch { return false; }
        }

        public void Grabar() 
        {
            if (!ValidaNroDoc())
            {
                return;
            }

            if (!Validaciones()) 
            {
                return;
            }

            if (this.nMode == 1)
            {
                if (!ValidacionesReniec())
                {
                    return;
                }

                if (idCliRef == 0) 
                { 
                    idCliRef = GrabarCliente();
                }

                if (idCliRef == 0)
                {
                    MessageBox.Show("Error al intentar registrar al referido del cliente.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                             
            }
           
            try
            {                
                
                cliReferidos = new clsCNCliReferidos();
                DataTable result = cliReferidos.CNRegistrarReferidoClie(idCli, idCliRef, idAgencia, idUsuAsesor, clsVarGlobal.User.idUsuario, txtCelular.Text.Trim(), txtCorreo.Text.Trim());

                if (result == null)
                {
                    MessageBox.Show("Error al intentar registrar al referido del cliente.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToInt32(result.Rows[0]["lResult"]) == 1)
                {                    
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {                    
                    HabilitarControles(false);
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error al intentar registrar al referido del cliente.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            

        }

        public bool ValidaNroDoc()
        {
            if (!EsNumero(txtNroDoc.Text.Trim()))
            {
                MessageBox.Show("Ingrese el número de documento con un formato válido.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtNroDoc.Text.Trim().Length != 8)
            {
                MessageBox.Show("Ingrese el número de documento con un formato válido.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public bool Validaciones() 
        {            
            if (!EsCelular(txtCelular.Text.Trim())) 
            {
                MessageBox.Show("Ingrese el número de celular con un formato válido.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtCorreo.Text.Trim() != "")
            {
                if (!EsCorreo(txtCorreo.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el correo electrónico con un formato válido.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        public bool ValidacionesReniec() 
        {
            if (this.idCli == this.idCliRef)
            {
                MessageBox.Show("El cliente referido no puede ser el mismo que el cliente referente.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ExisteReferido())
            {
                MessageBox.Show("El Nro. de Documento no puede ser registrado como Referido, porque ya existe como referido.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ExisteBaseNegativa())
            {
                MessageBox.Show("El Nro. de Documento no puede ser registrado como Referido, por encontrarse con deuda castigada.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (ExisteColaborador())
            {
                MessageBox.Show("El Nro. de Documento no puede ser registrado como Referido, porque es colaborador de la entidad.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            String cEstClieCred = EstClieCreditosNoActivos();

            if (cEstClieCred == "ACTIVO")
            {
                MessageBox.Show("El Nro. de Documento no puede ser registrado como Referido, porque ha sido cliente activo hace menos de 6 meses.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;                
            }

            if (cEstClieCred == "VIGENTE")
            {
                MessageBox.Show("El Nro. de Documento no puede ser registrado como Referido, porque ya existe como cliente activo.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public bool ExisteCliente() {
            cliente = new clsCNCliente();
            var result = cliente.CNObtenerClientePorDocumento(1, txtNroDoc.Text.Trim());
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;                       
        }        

        private void ObtenerDniAut()
        {
            clsCNConsultaDatos ConsultaDNI = new clsCNConsultaDatos();
            DataTable dtDniAut = ConsultaDNI.CNConsultaDatosDniAut(Convert.ToInt32(nIdMod));
            cDocAutorizado = dtDniAut.Rows[0]["cDocumentoID"].ToString();
        }

        public bool consultarReniec(string cNroDni) {
            try
            {
                dataRen = new clsProcesaDatosRen();

                clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cNroDni, clsVarGlobal.User.idUsuario, 1);
                clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
                clsReniec obj = new clsReniec(objParam, objReniec);
                dataRen = obj.GetReniec();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public int nMayorEdad()
        {
            //Valida si existe la variable
             bool lExiste = clsVarApl.dicVarGen.ContainsKey("nMayorEdad");
            if (lExiste)
            {
                return Convert.ToInt32(clsVarApl.dicVarGen["nMayorEdad"]);                
            }
            else
            {
                return 0;
            }            
        }

        public int GrabarCliente() 
        {            
            return registrarClienteReniec(dataRen);
        }

        public int registrarClienteReniec(clsProcesaDatosRen dataren)
        {
            //Cliente
            clsAWCliente objAWCliente = new clsAWCliente();
            //this.objAWCliente.idCli
            objAWCliente.cNombre += dataren.cNombres.Trim() + " " + dataren.cApellidoPater.Trim() + " " + dataren.cApellidoMater.Trim();
            objAWCliente.idTipoDocumento = 1; //DNI
            objAWCliente.IdTipoPersona = 1; //Natural
            objAWCliente.nIdActivEco = 0; //Ninguno
            objAWCliente.cDocumentoID = dataren.cDniF;
            objAWCliente.cDocumentoAdicional = "";
            objAWCliente.nNumeroTelefono = "";
            objAWCliente.cNumeroTelefono2 = txtCelular.Text.Trim(); //Telefono Principal
            objAWCliente.cNumeroTelefono3 = "";
            objAWCliente.cCorreoCli = txtCorreo.Text.Trim(); //Correo Principal    
            objAWCliente.IdtipoDocAdicional = 0; //NA
            objAWCliente.idResiddencia = 1; //Reside en Perú
            objAWCliente.idPaisResidencia = 173; //Perú
            objAWCliente.idMagnitudEmpresarial = 0; //NA    
            objAWCliente.idNacionalidad = 0; //Peruana
            objAWCliente.idTipoPerClasifica = 2; //Sin Negocio
            objAWCliente.lIndDatosBasic = true;
            objAWCliente.idCodTelFijo = 0; //NA   
            objAWCliente.cCorreoCliAdicional = "";
            objAWCliente.idEstadoCli = 1; //Activo
            objAWCliente.idActivEcoInterna = 0; //NA
            objAWCliente.idActivEcoAdicional = 0; //NA    
            objAWCliente.idEstadoContribuyente = 1; //No Aplica
            objAWCliente.idCondDomicilio = 0; //NA
            objAWCliente.dFechaEstadoCont = null;
            objAWCliente.cDigitoVerificador = Convert.ToChar(dataren.cDigitoVerif.Trim());
            objAWCliente.idTipoCliente = 1;

            string cUbiNac = dataren.cUbigeoDepNac.Trim() + dataren.cUbigeoProvNac.Trim() + dataren.cUbigeoDistNac.Trim();
            int nUbiNac = 0;
            
            if (EsNumero(cUbiNac))
            {
                clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
                DataTable tbDatUbi = RetCliNat.RetUbiCliPorCodigoReniec(cUbiNac);
                if (tbDatUbi.Rows.Count > 0)
                { nUbiNac = Convert.ToInt32(tbDatUbi.Rows[0]["idUbigeo"]); }                    
            }
            
            //Cliente Natural
            clsAWClienteNatural objAWClienteNatural = new clsAWClienteNatural();
            objAWClienteNatural.cApellidoPaterno = dataren.cApellidoPater.Trim();
            objAWClienteNatural.cApellidoMaterno = dataren.cApellidoMater.Trim();
            objAWClienteNatural.cNombre = dataren.cNombres.Trim();
            objAWClienteNatural.cApellidoCasada = dataren.cApellidoCasada.Trim();
            objAWClienteNatural.dFechaNacimiento = utils.TextoToFecha(dataren.cFechaNac);
            objAWClienteNatural.idUbigeoNacimiento = nUbiNac;
            objAWClienteNatural.idSexo = (dataren.cSexo == "2") ? 1 : 2; //1=Femenino 2=Masculino                
            objAWClienteNatural.idEstadoCivil = Convert.ToInt32(dataren.cEstadoCivil); //Revisar
            objAWClienteNatural.idProfesion = 1; //Ninguno                   
            objAWClienteNatural.idNivelInstruccion = 0; //NA
            objAWClienteNatural.idOcupacion = 117; //No Declara
            objAWClienteNatural.nNumHijos = 0;
            objAWClienteNatural.nNumPerDepend = 0;
            objAWClienteNatural.idEstadoCivilSBS = 0;
            objAWClienteNatural.idCargo = 1; //En blanco
            objAWClienteNatural.cDescCargo = "";
            objAWClienteNatural.CNombreSeg = "";
            objAWClienteNatural.cNombreOtros = "";
            objAWClienteNatural.dFechaIniActEco = null;
            objAWClienteNatural.cDescProfesion = "";
            objAWClienteNatural.idRolHogar = null;
            objAWClienteNatural.idSegmentoSocioEc = null;

            DateTime dFechaNacimiento = Convert.ToDateTime(utils.TextoToFecha(dataren.cFechaNac));

            ////Dirección                  
          
            string cDirUbigeo = dataren.cNomDist.Trim() + " - " + dataren.cNomProv.Trim() + " - " + dataren.cNomDep.Trim() + " - " + "PERÚ";

            int nUbi = 0;

            clsCNCliente ListaUbigeo = new clsCNCliente();
            DataTable dtListaUbigeo = ListaUbigeo.CNObtenerDirUbigeo(cDirUbigeo);
            if (dtListaUbigeo.Rows.Count > 0)
            {
                nUbi = Convert.ToInt32(dtListaUbigeo.Rows[0]["Ubigeo"]);
            }

            tbDirCli = new DataTable();

            clsCNDirecCli ListaDirCli = new clsCNDirecCli();
            tbDirCli = ListaDirCli.ListaDirCli(0);

            DataRow dr = tbDirCli.NewRow();            
            dr["idCli"] = 0;
            dr["idUbigeo"] = nUbi;
            dr["cDireccion"] = (dataren.cDireccion.Trim() == "") ? dataren.cManzana.Trim() + dataren.cLote.Trim() + dataren.cEtapa.Trim() + dataren.cUrbanizacion.Trim() + dataren.cNomDist.Trim() + dataren.cNomProv.Trim() : dataren.cDireccion.Trim() + dataren.cUrbanizacion.Trim() + dataren.cNomDist.Trim() + dataren.cNomProv.Trim();
            dr["cReferenciaDireccion"] = (dataren.cDireccion.Trim() == "") ? dataren.cManzana.Trim() + dataren.cLote.Trim() + dataren.cEtapa.Trim() + dataren.cUrbanizacion.Trim() : dataren.cDireccion.Trim() + dataren.cUrbanizacion.Trim();
            dr["idTipoDireccion"] = 5;
            dr["idDireccion"] = 0;
            dr["Estado"] = 'N';
            dr["idTipoZona"] = 2;
            dr["cDesZona"] = dataren.cNomDist.Trim();
            dr["idTipoVia"] = 1;
            dr["cDesVia"] = "";
            dr["cNumero"] = dataren.cNumDireccion.Trim();
            dr["cDepartamento"] = "";
            dr["cInterior"] = dataren.cInterior.Trim();
            dr["cKilometro"] = "";
            dr["cManzana"] = dataren.cManzana.Trim();
            dr["cLote"] = dataren.cLote.Trim();
            dr["cBlock"] = dataren.cBlock.Trim();
            dr["cEtapa"] = dataren.cEtapa.Trim();
            dr["idTipoVivienda"] = 3;
            dr["cdescOtros"] = "";
            dr["cNombrePropietario"] = "";
            dr["idSector"] = 1;
            dr["cCodSuministro"] = "";
            dr["idTipoConstruccion"] = "0";
            dr["nAñoReside"] = 0;
            dr["lDirPrincipal"] = true;
            dr["idSuministro"] = "0";
            dr["nIdUsoDelPredio"] = 0;
            dr["nIdTipoEstructura"] = 0;
            dr["nAñoConstruccion"] = 0;
            dr["nPisos"] = 0;
            dr["nSotanos"] = 0;
            dr["idGeolocalizacion"] = "0";
            tbDirCli.Rows.Add(dr);

            DataSet dsDir = new DataSet("dsDireccion");

            dsDir.Tables.Add(tbDirCli);

            string xmlDirec = dsDir.GetXml();
            xmlDirec = clsCNFormatoXML.EncodingXML(xmlDirec);
            Console.WriteLine(xmlDirec);
            dsDir.Tables.Clear();

           
            //Vinculados
            List<clsAWVinculado> lstAWVinculado = new List<clsAWVinculado>();
            string xmlAWVinculados = lstAWVinculado.ListObjectToXml<clsAWVinculado>("Table1", "dsVinculo");

            List<string> nombres = new List<string>();
            if (!string.IsNullOrEmpty(dataren.cApellidoPater.Trim())) nombres.Add(dataren.cApellidoPater.Trim());
            if (!string.IsNullOrEmpty(dataren.cApellidoMater.Trim())) nombres.Add(dataren.cApellidoMater.Trim());
            if (!string.IsNullOrEmpty(dataren.cApellidoCasada.Trim())) nombres.Add(dataren.cApellidoCasada.Trim());
            if (!string.IsNullOrEmpty(dataren.cNombres.Trim())) nombres.Add(dataren.cNombres.Trim());
            string cNombreCliente = string.Join(" ", nombres);
            clsCNGuardaCliPerNat GuardaCliNat = new clsCNGuardaCliPerNat();

            DataTable dtIdCliente = GuardaCliNat.GuardarCliPerNat(
                            cNombreCliente,
                            objAWCliente.idTipoDocumento,
                            objAWCliente.IdTipoPersona,
                            objAWCliente.cDocumentoID,
                            objAWCliente.cDocumentoAdicional,
                            0, //objAWCliente.IdtipoDocAdicional,
                            objAWCliente.idNacionalidad,
                            objAWCliente.idResiddencia,
                            objAWCliente.idPaisResidencia,
                            objAWCliente.idCodTelFijo,
                            objAWCliente.nNumeroTelefono,
                            objAWCliente.cNumeroTelefono2,
                            objAWCliente.cNumeroTelefono3,
                            objAWCliente.cCorreoCli,
                            objAWCliente.cCorreoCliAdicional,
                            objAWCliente.idActivEcoInterna,
                            xmlDirec,
                            objAWClienteNatural.cApellidoPaterno,
                            objAWClienteNatural.cApellidoMaterno,
                            objAWClienteNatural.cApellidoCasada,
                            objAWClienteNatural.cNombre,
                            objAWClienteNatural.CNombreSeg,
                            objAWClienteNatural.cNombreOtros,
                            dFechaNacimiento,
                            objAWClienteNatural.idUbigeoNacimiento,
                            objAWClienteNatural.idSexo,
                            objAWClienteNatural.idEstadoCivil,
                            0, //objAWClienteNatural.idEstadoCivilSBS,
                            objAWClienteNatural.idProfesion,
                            objAWClienteNatural.cDescProfesion,
                            objAWClienteNatural.idNivelInstruccion,
                            117, //objAWClienteNatural.idOcupacion,
                            1, //objAWClienteNatural.idCargo,
                            objAWClienteNatural.cDescCargo,
                            xmlAWVinculados,
                            0, //objAWClienteNatural.nNumHijos,
                            0, //objAWClienteNatural.nNumPerDepend,
                            clsVarGlobal.dFecSystem,
                            clsVarGlobal.User.idUsuario,
                            clsVarGlobal.nIdAgencia,
                            2, //objAWCliente.idTipoPerClasifica,
                            objAWCliente.lIndDatosBasic,
                            objAWClienteNatural.dFechaIniActEco,
                            objAWCliente.idEstadoCli,
                            objAWCliente.idActivEcoInterna,
                            0, //objAWCliente.idActivEcoAdicional,
                            0, //objAWClienteNatural.idRolHogar,
                            0, //objAWClienteNatural.idSegmentoSocioEc,
                            0, //objAWCliente.idMagnitudEmpresarial,
                            1, //objAWCliente.idEstadoContribuyente,
                            1, //objAWCliente.idCondDomicilio,
                            clsVarGlobal.dFecSystem, // objAWCliente.dFechaEstadoCont,
                            dataren.cDigitoVerif.Trim()
                        );

            cliente = new clsCNCliente();
            var result = cliente.CNObtenerClientePorDocumento(1, objAWCliente.cDocumentoID);

            if (result != null)
            {
                return Convert.ToInt32(result.Rows[0]["idCli"]);
            }
            else
            {
                return 0;
            }            
        }

        public void ObtenerReferido(int idCli, int idCliRef)
        {
            cliReferidos = new clsCNCliReferidos();

            var result = cliReferidos.CNObtieneReferidoClie(idCli, idCliRef);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    txtNroDoc.Text = result.Rows[0]["cDocumentoID"].ToString();
                    txtNombre.Text = result.Rows[0]["cNombre"].ToString();
                    txtCelular.Text = result.Rows[0]["cNumeroTelefono"].ToString();
                    txtCorreo.Text = result.Rows[0]["cCorreoCli"].ToString();                           
                }
            }
        }

        public bool ExisteColaborador()
        {
            cnProgFidelizacionClie = new clsCNProgFidelizacionClie();

            DataTable result = cnProgFidelizacionClie.CNObtenerDatosColaborador(0, txtNroDoc.Text.Trim());
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;
        }

        public bool ExisteReferido()
        {
            cliReferidos = new clsCNCliReferidos();

            DataTable result = cliReferidos.CNObtenerDatosReferido(0, txtNroDoc.Text.Trim());
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;
        }

        public bool ExisteBaseNegativa()
        {
            cliReferidos = new clsCNCliReferidos();

            DataTable result = cliReferidos.CNbtenerDatosBaseNegativa(txtNroDoc.Text.Trim());
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;
        }

        public string EstClieCreditosNoActivos()
        {
            string lEstado = "";            
            credito = new CRE.CapaNegocio.clsCNCredito();

            DataTable result = credito.CNEstClieCreditosNoActivos(0, txtNroDoc.Text.Trim());
            if (result == null) { return lEstado; }
            if (result.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(result.Rows[0]["cEstado"].ToString()))
                {
                    lEstado = result.Rows[0]["cEstado"].ToString();                    
                }
            }

            return lEstado;
        }

        public void BuscarCliente()
        {
            idCliRef = 0;

            if (!ValidaNroDoc())
            {
                return;
            }

            cliente = new clsCNCliente();
            var result = cliente.CNObtenerClientePorDocumento(1, txtNroDoc.Text.Trim());
            if (result.Rows.Count > 0)
            {
                idCliRef = Convert.ToInt32(result.Rows[0]["idCli"].ToString());
                txtNombre.Text = result.Rows[0]["cNombre"].ToString(); ;
                txtCelular.Text = result.Rows[0]["cNumeroTelefono2"].ToString();
                txtCorreo.Text = result.Rows[0]["cCorreoCli"].ToString();

                HabilitarControles(false);
            }
            else
            {
                if (!consultarReniec(txtNroDoc.Text.Trim()))
                {
                    MessageBox.Show("Error al intentar obtener los datos del referido desde el servicio de Reniec.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(dataRen.cNombres.Trim()) || dataRen.cNombres.Trim() == "NA")
                {
                    MessageBox.Show("El Nro. de Documento consultado, no existe en la Reniec.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!string.IsNullOrEmpty(dataRen.cFechaNac.Trim()))
                {
                    var dfecha = utils.TextoToFecha(dataRen.cFechaNac.Trim());
                    if (dfecha != null)
                    {
                        int nEdad = utils.CalcularEdad(Convert.ToDateTime(dfecha), clsVarGlobal.dFecSystem);
                        if (nEdad < nMayorEdad())
                        {
                            MessageBox.Show("El Nro. de Documento consultado, es menor de edad.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }

                txtNombre.Text = dataRen.cApellidoPater.Trim() + ' ' + dataRen.cApellidoMater.Trim() + ' ' + dataRen.cNombres.Trim();

                HabilitarControles(false);
            }
        }
        #endregion        
    }
}

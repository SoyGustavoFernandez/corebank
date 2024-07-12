using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using GEN.AccesoDatos;

namespace CLI.AccesoDatos
{
    public class clsADRetDatosCliente
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        //=============================================================
        //--Retorna el Tipo de Cliente
        //=============================================================
        public DataTable ListaCliente(int nidClient, string cTipBus)
        {
            return objEjeSp.EjecSP("CLI_DatosCliente_sp", nidClient, cTipBus);
        }

        /// <summary>
        /// Retorna la entidad cliente
        /// </summary>
        /// <param name="nidClient">id del cliente</param>
        /// <param name="cTipBus">tipo de busuqeda "N" natural "J" juridica</param>
        /// <returns></returns>
        public clsCliente retornarCliente(int nidClient, string cTipBus)
        {
            clsCliente objcliente = new clsCliente();
            DataTable dtCliente= objEjeSp.EjecSP("CLI_DatosCliente_sp", nidClient, cTipBus);
            if (dtCliente.Rows.Count>0)
            {
                if (dtCliente.Rows[0]["IdTipoPersona"].ToString() == "1")
                {
                    #region Persona Natural
                    foreach (DataRow item in dtCliente.Rows)
                    {
                        objcliente.idCli                = nidClient;
                        objcliente.idNacionalidad       = (String.IsNullOrEmpty(item["idNacionalidad"].ToString()))? 0 : Convert.ToInt32(item["idNacionalidad"]);
                        objcliente.idResiddencia	    = (String.IsNullOrEmpty(item["idResiddencia"].ToString()))? 0 : Convert.ToInt32(item["idResiddencia"]);
                        objcliente.idPaisResidencia	    = (String.IsNullOrEmpty(item["idPaisResidencia"].ToString())) ? 0 : Convert.ToInt32(item["idPaisResidencia"]);
                        objcliente.IdtipoDocAdicional	= (String.IsNullOrEmpty(item["IdtipoDocAdicional"].ToString()))? 0 : Convert.ToInt32(item["IdtipoDocAdicional"]);
                        objcliente.idTipoDocumento	    = (String.IsNullOrEmpty(item["idTipoDocumento"].ToString()))? 0 : Convert.ToInt32(item["idTipoDocumento"]);
                        objcliente.IdTipoPersona	    = (String.IsNullOrEmpty(item["IdTipoPersona"].ToString()))? 0 : Convert.ToInt32(item["IdTipoPersona"]);
                        objcliente.cDocumentoID	        = (String.IsNullOrEmpty(item["cDocumentoID"].ToString()))? "" : Convert.ToString(item["cDocumentoID"]);
                        objcliente.cDocumentoAdicional  = (String.IsNullOrEmpty(item["cDocumentoAdicional"].ToString()))? "": Convert.ToString(item["cDocumentoAdicional"]);
                        objcliente.nNumeroTelefono      = (String.IsNullOrEmpty(item["nNumeroTelefono"].ToString())) ? "": Convert.ToString(item["nNumeroTelefono"]);
                        objcliente.cNumeroTelefono2     = (String.IsNullOrEmpty(item["cNumeroTelefono2"].ToString()))? "":Convert.ToString(item["cNumeroTelefono2"]);
                        objcliente.cCorreoCli           = (String.IsNullOrEmpty(item["cCorreoCli"].ToString()))? "": Convert.ToString(item["cCorreoCli"]);
                        objcliente.nIdActivEco	        = (String.IsNullOrEmpty(item["nIdActivEco"].ToString()))? 0 : Convert.ToInt32(item["nIdActivEco"]);
                        objcliente.idTipoPerClasifica	= (String.IsNullOrEmpty(item["idTipoPerClasifica"].ToString()))? 0:Convert.ToInt32(item["idTipoPerClasifica"]);
                        objcliente.cApellidoPaterno     = (String.IsNullOrEmpty(item["cApellidoPaterno"].ToString()))? "": Convert.ToString(item["cApellidoPaterno"]);
                        objcliente.cApellidoMaterno     = (String.IsNullOrEmpty(item["cApellidoMaterno"].ToString()))? "":Convert.ToString(item["cApellidoMaterno"]);
                        objcliente.cApellidoCasado      = (String.IsNullOrEmpty(item["cApellidoCasado"].ToString()))? "":Convert.ToString(item["cApellidoCasado"]);
                        objcliente.cNombre              = (String.IsNullOrEmpty(item["cNombre"].ToString()))? "":Convert.ToString(item["cNombre"]);
                        objcliente.cNombreSeg           = (String.IsNullOrEmpty(item["cNombreSeg"].ToString()))? "" : Convert.ToString(item["cNombreSeg"]);
                        objcliente.cNombreOtros         = (String.IsNullOrEmpty(item["cNombreOtros"].ToString()))? "": Convert.ToString(item["cNombreOtros"]);
                        objcliente.dFechaNacimiento	    = (String.IsNullOrEmpty(item["dFechaNacimiento"].ToString()))? clsVarGlobal.dFecSystem : Convert.ToDateTime(item["dFechaNacimiento"]);
                        objcliente.idEstadoCivil	    = (String.IsNullOrEmpty(item["idEstadoCivil"].ToString()))? 0 : Convert.ToInt32(item["idEstadoCivil"]);
                        objcliente.idSexo	            = (String.IsNullOrEmpty(item["idSexo"].ToString()))? 0 : Convert.ToInt32(item["idSexo"]);
                        objcliente.idNivelInstruccion	= (String.IsNullOrEmpty(item["idNivelInstruccion"].ToString()))? 0 : Convert.ToInt32(item["idNivelInstruccion"]);
                        objcliente.idProfesion	        = (String.IsNullOrEmpty(item["idProfesion"].ToString()))? 0: Convert.ToInt32(item["idProfesion"]);
                        objcliente.idOcupacion	        = (String.IsNullOrEmpty(item["idOcupacion"].ToString()))? 0: Convert.ToInt32(item["idOcupacion"]);
                        objcliente.idUbigeoNacimiento	= (String.IsNullOrEmpty(item["idUbigeoNacimiento"].ToString()))? 0 : Convert.ToInt32(item["idUbigeoNacimiento"]);
                        objcliente.nNumPerDepend	    = (String.IsNullOrEmpty(item["nNumPerDepend"].ToString()))? 0 : Convert.ToInt32(item["nNumPerDepend"]);
                        objcliente.nNumHijos	        = (String.IsNullOrEmpty(item["nNumHijos"].ToString()))? 0 : Convert.ToInt32(item["nNumHijos"]);
                        objcliente.idEstadoCivilSBS	    = (String.IsNullOrEmpty(item["idEstadoCivilSBS"].ToString()))? 0: Convert.ToInt32(item["idEstadoCivilSBS"]);
                        objcliente.idCargo	            = (String.IsNullOrEmpty(item["idCargo"].ToString()))? 0 : Convert.ToInt32(item["idCargo"]);
                        objcliente.cDescCargo           = (String.IsNullOrEmpty(item["cDescCargo"].ToString()))? "" : Convert.ToString(item["cDescCargo"]);
                        objcliente.idPadreActividad     = (String.IsNullOrEmpty(item["idPadreActividad"].ToString()))? 0 : Convert.ToInt32(item["idPadreActividad"]);
                        objcliente.cNomCli              = (String.IsNullOrEmpty(item["cNomCli"].ToString()))? "": Convert.ToString(item["cNomCli"]);
                        objcliente.cCodCliente          = (String.IsNullOrEmpty(item["cCodCliente"].ToString()))? "": Convert.ToString(item["cCodCliente"]);
                        objcliente.cCantEmpl            = (String.IsNullOrEmpty(item["cCantEmpl"].ToString()))? 0 : Convert.ToInt32(item["cCantEmpl"]);
                        objcliente.idActivEcoInt        = (String.IsNullOrEmpty(item["idActivEcoInterna"].ToString()))? 0 : Convert.ToInt32(item["idActivEcoInterna"]);
                    }
                    #endregion
                }

                //if (dtCliente.Rows[0]["IdTipoPersona"].ToString().In("2","3"))
                else
                {
                    #region Persona Juridica
                    foreach (DataRow item in dtCliente.Rows)
                    {
                        objcliente.idCli                = nidClient;
                        objcliente.idNacionalidad       = (String.IsNullOrEmpty(item["idNacionalidad"].ToString()))? 0 : Convert.ToInt32(item["idNacionalidad"]);
                        objcliente.idResiddencia        = (String.IsNullOrEmpty(item["idResiddencia"].ToString()))? 0 : Convert.ToInt32(item["idResiddencia"]);
                        objcliente.idPaisResidencia     = (String.IsNullOrEmpty(item["idPaisResidencia"].ToString()))? 0 : Convert.ToInt32(item["idPaisResidencia"]);
                        objcliente.idTipoDocumento      = (String.IsNullOrEmpty(item["idTipoDocumento"].ToString()))? 0 : Convert.ToInt32(item["idTipoDocumento"]);
                        objcliente.IdTipoPersona        = (String.IsNullOrEmpty(item["IdTipoPersona"].ToString()))? 0 : Convert.ToInt32(item["IdTipoPersona"]);
                        objcliente.cDocumentoID         = (String.IsNullOrEmpty(item["cDocumentoID"].ToString()))? "" : Convert.ToString(item["cDocumentoID"]);
                        objcliente.nNumeroTelefono      = (String.IsNullOrEmpty(item["nNumeroTelefono"].ToString()))? "" : Convert.ToString(item["nNumeroTelefono"]);
                        objcliente.cNumeroTelefono2     = (String.IsNullOrEmpty(item["cNumeroTelefono2"].ToString()))? "" :Convert.ToString(item["cNumeroTelefono2"]);
                        objcliente.cCorreoCli           = (String.IsNullOrEmpty(item["cCorreoCli"].ToString()))? "" : Convert.ToString(item["cCorreoCli"]);
                        objcliente.nIdActivEco          = (String.IsNullOrEmpty(item["nIdActivEco"].ToString()))? 0 :Convert.ToInt32(item["nIdActivEco"]);
                        objcliente.idTipoPerClasifica   = (String.IsNullOrEmpty(item["idTipoPerClasifica"].ToString()))? 0:Convert.ToInt32(item["idTipoPerClasifica"]);
                        objcliente.cRazonSocial         = (String.IsNullOrEmpty(item["cRazonSocial"].ToString()))? "":Convert.ToString(item["cRazonSocial"]);
                        objcliente.cNombreComercial     = (String.IsNullOrEmpty(item["cNombreComercial"].ToString()))? "":Convert.ToString(item["cNombreComercial"]);
                        objcliente.cSiglas              = (String.IsNullOrEmpty(item["cSiglas"].ToString())) ? "" : Convert.ToString(item["cSiglas"]);
                        objcliente.dFechaConstitucion   = (String.IsNullOrEmpty(item["dFechaConstitucion"].ToString()))? clsVarGlobal.dFecSystem:Convert.ToDateTime(item["dFechaConstitucion"]);
                        objcliente.nNumPartReg          = (String.IsNullOrEmpty(item["nNumPartReg"].ToString()))? "" : Convert.ToString(item["nNumPartReg"]);
                        objcliente.nIdZonaReg           = (String.IsNullOrEmpty(item["nIdZonaReg"].ToString()))? 0 : Convert.ToInt32(item["nIdZonaReg"]);
                        objcliente.nIdEstado            = (String.IsNullOrEmpty(item["nIdEstado"].ToString()))? 0 : Convert.ToInt32(item["nIdEstado"]);
                        objcliente.idIdentificacion     = (String.IsNullOrEmpty(item["idIdentificacion"].ToString())) ? 0 : Convert.ToInt32(item["idIdentificacion"]);
                        objcliente.lEmpleador           = (String.IsNullOrEmpty(item["lEmpleador"].ToString()))? false : Convert.ToBoolean(item["lEmpleador"]);
                        objcliente.idUbigeoPadre        = (String.IsNullOrEmpty(item["idUbigeoPadre"].ToString()))? 0 :Convert.ToInt32(item["idUbigeoPadre"]);
                        objcliente.idPadreActividad     = (String.IsNullOrEmpty(item["idPadreActividad"].ToString()))? 0 : Convert.ToInt32(item["idPadreActividad"]);
                        objcliente.cNomCli              = (String.IsNullOrEmpty(item["cNomCli"].ToString()))? "" : Convert.ToString(item["cNomCli"]);
                        objcliente.cCodCliente          = (String.IsNullOrEmpty(item["cCodCliente"].ToString()))? "": Convert.ToString(item["cCodCliente"]);
                        objcliente.cCantEmpl            = (String.IsNullOrEmpty(item["cCantEmpl"].ToString()))? 0:Convert.ToInt32(item["cCantEmpl"]);
                        objcliente.idActivEcoInt        = (String.IsNullOrEmpty(item["idActivEcoInterna"].ToString()))? 0: Convert.ToInt32(item["idActivEcoInterna"]);
                    }
                    #endregion
                }                
            }
            return objcliente;
        }

        /// <summary>
        /// retorna datos basicos de un cliente, idcli,nombre y documento
        /// </summary>
        /// <param name="nidClient"></param>
        /// <returns></returns>
        public clsCliente retornarCliente(int nidClient)
        {
            clsCliente objcliente = new clsCliente();
            DataTable dtCliente = objEjeSp.EjecSP("CLI_DatoClientexIdCli_SP", nidClient);
            if (dtCliente.Rows.Count > 0)
            {
                    foreach (DataRow item in dtCliente.Rows)
                    {
                        objcliente.idCli = Convert.ToInt32(item["idCli"]);
                        objcliente.cDocumentoID = Convert.ToString(item["cDocumentoID"]);
                        objcliente.cNomCli = Convert.ToString(item["cNombre"]);
                        objcliente.IdTipoPersona = Convert.ToInt32(item["IdTipoPersona"]);
                    }
            }
            return objcliente;
        }
        
        //=============================================================
        //--Retorna Ubigeo
        //=============================================================
        public DataTable RetUbigeoCli(int nIdUbigeo)
        {
            return objEjeSp.EjecSP("CLI_DatosUbigeo_Sp", nIdUbigeo);
        }
        // CREA METODO PARA BUSCARUBIGEO POR CODIGO DE RENIEC
        public DataTable RetUbiCliPorCodigoReniec(string cUbigeoRENIEC)
        {
            return objEjeSp.EjecSP("CLI_DatosUbigeoPorCodRENIEC_Sp", cUbigeoRENIEC);
        }
        //=============================================================
        //--Retorna datos para Validación
        //=============================================================
        public DataTable RetDatValidar(int nidClient, string xcNroDoc, string xcTipOpe, int TipDoc)
        {
            return objEjeSp.EjecSP("CLI_ValidaDatosCli_Sp", nidClient, xcNroDoc, xcTipOpe, TipDoc);
        }

        //=============================================================
        //--Retorna Listado de Clientes Juridicos
        //=============================================================
        public DataTable ListaClientesJuridicos()
        {
            return objEjeSp.EjecSP("CLI_ListaClientesJuridicos_sp");
        }

        public DataTable BuscaClientesAgencia(int idAgencia, int idUsuario)
        {
            return objEjeSp.EjecSP("CLI_BuscaClientesAgencia_sp", idAgencia, idUsuario);
        }
   }
}



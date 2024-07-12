using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADGuardaCliPerNat
    {
        IntConexion objEjeSp;
        //clsGENEjeSP objEjeSp = new clsGENEjeSP();        
       
        public clsADGuardaCliPerNat(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADGuardaCliPerNat()
        {
            objEjeSp = new clsGENEjeSP();
        }

        //===============================================================
        //Método para Guardar Datos del Cliente en la BD
        //===============================================================
        public DataTable GuardarCliPerNat(string pcNombreCli, int pnTipDoc, int pnTipPer,string pcDocIde,
                                          string pcDocAdic, int pcTipDocAdic, int pcNacionalidad, int pcTipRes, 
                                          int pcPaisRes, int idCodCiudad,string pcNumTel, string pcNumTel2, 
                                          string pcNumTel3,string pcCorreo,string pcCorreoAdicional,
                                          int pnIdActEco, string xmlDir, string pcApePat, string pcApeMat,
                                          string pcApeCas, string pcNom1, string pcNom2, string pcNom3,
                                          DateTime pdFecNac, int pnUbiNac, int pnSexo, int pnEstCivil,
                                          int pnEstCivSBS, int pnProf, string cDesProfesion, int pnNivInst, int pnOcupac, 
                                          int pnIdCargo, string pcDesCargo, string xmlVinc, int pnNroHijod,
                                          int pnNroPerDepend, DateTime dFecSystem, int idUsuario, int IdAgencia, int tcTipClasif, bool lIndDatBasico,
                                          DateTime? dFechaIniActEco, int idEstadoCli, int idActivEcoInterna, int idActivEcoAdicional,
                                          int idRolHogar, int idSegmentoSocioEc,int idMagnitudEmpresarial, int idEstadoContribuyente, 
                                          int idConDomicilio, DateTime dFechastCont, string pcDigVerificador)
        {
                      
            return objEjeSp.EjecSP("Gen_GuardarCliPerNat_Sp", pcNombreCli, pnTipDoc, pnTipPer, pcDocIde,
                                                            pcDocAdic, pcTipDocAdic, pcNacionalidad, pcTipRes,
                                                            pcPaisRes, idCodCiudad, pcNumTel, pcNumTel2, 
                                                            pcNumTel3, pcCorreo,pcCorreoAdicional,
                                                            pnIdActEco, xmlDir, pcApePat, pcApeMat, 
                                                            pcApeCas, pcNom1, pcNom2, pcNom3,
                                                            pdFecNac, pnUbiNac, pnSexo, pnEstCivil,
                                                            pnEstCivSBS, pnProf, cDesProfesion, pnNivInst, pnOcupac,
                                                            pnIdCargo, pcDesCargo, xmlVinc, pnNroHijod,
                                                            pnNroPerDepend,dFecSystem,  idUsuario,
                                                            IdAgencia, tcTipClasif, lIndDatBasico, dFechaIniActEco == null ? (object)DBNull.Value : dFechaIniActEco,
                                                            idEstadoCli, idActivEcoInterna, idActivEcoAdicional, idRolHogar,
                                                            idSegmentoSocioEc, idMagnitudEmpresarial, idEstadoContribuyente,
                                                            idConDomicilio, dFechastCont, pcDigVerificador);
           
            //catch (Exception e)
            //{
            //    return = e.Message.ToString();
            //}
        }

        //===============================================================
        //Método para Actualizar Datos del Cliente en la BD
        //===============================================================
        public void ActualizarCliPerNat(int idCli, string pcNombreCli, int pnTipDoc, int pnTipPer,
                                        string pcDocIde, string pcDocAdic, int pcTipDocAdic, int pcNacionalidad,
                                        int pcTipRes, int pcPaisRes, int idCodCiudad,string pcNumTel, string pcNumTel2,
                                        string cNroTel3,string pcCorreo, string pcCorreoAdicional,
                                        int pnIdActEco, string xmlDir, string pcApePat,
                                        string pcApeMat, string pcApeCas,string pcNom1, string pcNom2, 
                                        string pcNom3,DateTime pdFecNac, int pnUbiNac, int pnSexo,
                                        int pnEstCivil, int pnEstCivSBS, int pnProf, string cDesProfesion, int pnNivInst,
                                        int pnOcupac, int pnIdCargo, string pcDesCargo, DateTime? dFecIniActEcoNat, string xmlVinc,
                                        int pnNroHijos, int pnNroPerDepend, DateTime dFecSystem, int idUsuario, int tcTipClasif, bool lIndDatBasico,
                                        int idEstadoCli, int idActivEcoInterna, int idActivEcoAdicional, int idRolHogar, 
                                        int idSegmentoSocioEc, string cCodSBS,int idMagnitudEmpresarial, DateTime dFechaFallecimiento,
                                        int idEstadoContribuyente, int idConDomicilio,DateTime dFechaEstContri, string pcDigVerificador)
        {
            //--Ejecutar Procedimiento Almacenado
            objEjeSp.EjecSP("CLI_ActualizarCliPerNat_Sp", idCli,pcNombreCli, pnTipDoc, pnTipPer,
                                                          pcDocIde,pcDocAdic, pcTipDocAdic, pcNacionalidad,
                                                          pcTipRes, pcPaisRes, idCodCiudad,pcNumTel, pcNumTel2,
                                                          cNroTel3, pcCorreo, pcCorreoAdicional,
                                                          pnIdActEco, xmlDir, pcApePat,
                                                          pcApeMat, pcApeCas, pcNom1, pcNom2,
                                                          pcNom3,pdFecNac, pnUbiNac, pnSexo,
                                                          pnEstCivil, pnEstCivSBS, pnProf, cDesProfesion, pnNivInst,
                                                          pnOcupac, pnIdCargo, pcDesCargo, dFecIniActEcoNat == null ? (object)DBNull.Value : dFecIniActEcoNat, xmlVinc,
                                                          pnNroHijos, pnNroPerDepend, dFecSystem, idUsuario, tcTipClasif,
                                                          lIndDatBasico, idEstadoCli, idActivEcoInterna, idActivEcoAdicional, idRolHogar,
                                                          idSegmentoSocioEc, cCodSBS, idMagnitudEmpresarial, dFechaFallecimiento,
                                                          idEstadoContribuyente, idConDomicilio, dFechaEstContri, pcDigVerificador);
        }

        public DataTable ActualizarCliPerNatPreAptAhorroWeb(int idCli, string pcNumTel, string pcCorreo, string pcDigitoVerif, int pnTipPersona, int pnIdActEco,
                                            int pnUbiNac, int pnEstCivil, int pnEstCivilSBS, int pnNivInst, int pnIdCargo, int pnProf, int pnOcupac, DateTime pcdFechaIniActEco,
                                            string xmlDirec)
        {
            //--Ejecutar Procedimiento Almacenado
            return objEjeSp.EjecSP("CLI_ActualizarCliPerNatPreAptAhorroWeb_SP", idCli, pcNumTel, pcCorreo, pcDigitoVerif, pnTipPersona, pnIdActEco,
                                                                        pnUbiNac, pnEstCivil, pnEstCivilSBS, pnNivInst, pnIdCargo, pnProf, pnOcupac, pcdFechaIniActEco,
                                                                        xmlDirec);
        }

        public DataTable ActualizarCliPerNatPostAptAhorroWeb(int idCli, int idTipoPerClasifica, int idTipoDocAdicional, string cDocumentoAdicional, int idActivEcoInt,
                                                                        int idDireccion, int idSector, int idTipoVivienda, int idTipoConstruccion, int nAñoReside,
                                                                        int nNumHijos, int nNumPerDepend, DateTime? dFechaIniActEco, int idProfesion, int idCargo)
        {
            return objEjeSp.EjecSP("CLI_ActualizarCliPerNatPostAptAhorroWeb_SP", idCli, idTipoPerClasifica, idTipoDocAdicional, cDocumentoAdicional, idActivEcoInt,
                                                                        idDireccion, idSector, idTipoVivienda, idTipoConstruccion, nAñoReside,
                                                                        nNumHijos, nNumPerDepend, dFechaIniActEco, idProfesion, idCargo);
        }
    }
}

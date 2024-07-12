using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNGuardaCliPerNat
    {
        clsADGuardaCliPerNat objGuardaCliNat;        

        public clsCNGuardaCliPerNat()
        {
            objGuardaCliNat = new clsADGuardaCliPerNat();             
        }

        public clsCNGuardaCliPerNat(bool cConex)
        {
            objGuardaCliNat = new clsADGuardaCliPerNat(cConex);
        }

        
        //=========================================================================
        //--Metodo Que Valida y Envia los Datos para Guardar
        //=========================================================================
        public DataTable GuardarCliPerNat(string pcNombreCli, int pnTipDoc, int pnTipPer, string pcDocIde,
                                          string pcDocAdic, int pcTipDocAdic, int pcNacionalidad, int pcTipRes,
                                          int pcPaisRes, int idCodCiudad,string pcNumTel, string pcNumTel2, 
                                           string pcNumTel3 ,string pcCorreo,string pcCorreoAdicional,
                                          int pnIdActEco, string xmlDir, string pcApePat, string pcApeMat, 
                                          string pcApeCas,string pcNom1, string pcNom2, string pcNom3, 
                                          DateTime pdFecNac, int pnUbiNac, int pnSexo, int pnEstCivil,
                                          int pnEstCivSBS, int pnProf, string cDesProfesion, int pnNivInst, int pnOcupac,
                                          int pnIdCargo, string pcDesCargo, string xmlVinc, int pnNroHijos,
                                          int pnNroPerDepend, DateTime dFecSystem, int idUsuario, int IdAgencia,int tcTipClasif, bool lIndDatBasico,
                                           DateTime? dFechaIniActEco, int idEstadoCli, int idActivEcoInterna, int idActivEcoAdicional,
                                           int idRolHogar, int idSegmentoSocioEc, int idMagnitudEmpresarial,
                                            int idEstadoContribuyente, int idConDomicilio, DateTime dFechEstCont, string pcDigVerificador)
        {
             return objGuardaCliNat.GuardarCliPerNat(pcNombreCli, pnTipDoc, pnTipPer, pcDocIde,
                                                     pcDocAdic, pcTipDocAdic, pcNacionalidad, pcTipRes,
                                                     pcPaisRes, idCodCiudad, pcNumTel, pcNumTel2,
                                                     pcNumTel3, pcCorreo, pcCorreoAdicional,
                                                     pnIdActEco, xmlDir, pcApePat, pcApeMat,
                                                     pcApeCas, pcNom1, pcNom2, pcNom3,
                                                     pdFecNac, pnUbiNac, pnSexo, pnEstCivil,
                                                     pnEstCivSBS, pnProf, cDesProfesion, pnNivInst, pnOcupac,
                                                     pnIdCargo, pcDesCargo, xmlVinc, pnNroHijos,
                                                     pnNroPerDepend, dFecSystem, idUsuario, IdAgencia, tcTipClasif, lIndDatBasico,
                                                     dFechaIniActEco,idEstadoCli, idActivEcoInterna, idActivEcoAdicional, idRolHogar,
                                                     idSegmentoSocioEc, idMagnitudEmpresarial, idEstadoContribuyente, idConDomicilio, dFechEstCont, pcDigVerificador);
        }

        //=========================================================================
        //--Metodo Que Valida y Envia los Datos para Actualizar
        //=========================================================================
        public void ActualizarCliPerNat(int idCli, string pcNombreCli, int pnTipDoc, int pnTipPer,
                                        string pcDocIde,string pcDocAdic, int pcTipDocAdic, int pcNacionalidad,
                                        int pcTipRes, int pcPaisRes, int idCodCiudad,string pcNumTel, string pcNumTel2,
                                        string pcNumTel3,string pcCorreo, string cCorreAdicional,
                                        int pnIdActEco, string xmlDir, string pcApePat,
                                        string pcApeMat, string pcApeCas,string pcNom1, string pcNom2,
                                        string pcNom3, DateTime pdFecNac, int pnUbiNac, int pnSexo,
                                        int pnEstCivil, int pnEstCivSBS, int pnProf, string cDesProfesion, int pnNivInst,
                                        int pnOcupac, int pnIdCargo, string pcDesCargo, DateTime? dFecIniActEcoNat, string xmlVinc,
                                        int pnNroHijos, int pnNroPerDepend, DateTime dFecSystem, int idUsuario, int tcTipClasif,
                                        bool lIndDatBasico, int idEstadoCli, int idActivEcoInterna, int idActivEcoAdicional, int idRolHogar,
                                        int idSegmentoSocioEc, string cCodSBS, int idMagnitudEmpresarial, DateTime dFechaFallecimiento,
                                        int idEstadoContribuyente, int idConDomicilio, DateTime dFechEstCont, string pcDigVerificador)
        {
            objGuardaCliNat.ActualizarCliPerNat(idCli,pcNombreCli, pnTipDoc, pnTipPer, 
                                                pcDocIde, pcDocAdic, pcTipDocAdic, pcNacionalidad,
                                                pcTipRes, pcPaisRes,idCodCiudad ,pcNumTel, pcNumTel2,
                                                pcNumTel3,pcCorreo, cCorreAdicional,
                                                pnIdActEco, xmlDir, pcApePat,
                                                pcApeMat, pcApeCas, pcNom1, pcNom2,
                                                pcNom3,pdFecNac, pnUbiNac, pnSexo,
                                                pnEstCivil, pnEstCivSBS, pnProf, cDesProfesion, pnNivInst,
                                                pnOcupac, pnIdCargo, pcDesCargo, dFecIniActEcoNat, xmlVinc,
                                                pnNroHijos, pnNroPerDepend, dFecSystem,  idUsuario, tcTipClasif,
                                                lIndDatBasico, idEstadoCli, idActivEcoInterna, idActivEcoAdicional, idRolHogar,
                                                idSegmentoSocioEc, cCodSBS, idMagnitudEmpresarial, dFechaFallecimiento,
                                                idEstadoContribuyente, idConDomicilio, dFechEstCont, pcDigVerificador);
        }
    }
}

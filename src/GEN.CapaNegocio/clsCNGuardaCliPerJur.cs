using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNGuardaCliPerJur
    {
        clsADGuardaCliPerJur objGuardaCliJur = new clsADGuardaCliPerJur(); 

        //=============================================================================
        // Crear metodo para Enviar datos en del Cliente
        //=============================================================================
        public DataTable GuardarCliPerJur( int pcNacionalidad,int pcTipRes, int pcPaisRes,string pcNombreCli,
                                           int pnTipDoc, int pnTipPer, string pcDocIde,string pcNumTel, 
                                           string pcNumTel2, string pcCorreo, int pnIdActEco, string xmlDir,
                                           string pcRazSoc, string pcNomCom, DateTime pdFecConst, DateTime? dFecIniActEco, String nNumPartReg,
                                           Int32 nIdZonaReg, Int32 pcTipIdentif, string pcSiglas, int nIdEstado,
                                           string xmlVinc, int pcEmpleador,DateTime dFecSystem, int idUsuario,
                                           int nIdAgencia, int tcTipClasif, int tcCantEmpleados,
                                            int idActividadEcoInt, int idCondDomicilio, string cNroTelef3, int idCodTel,
                                            string cCorreoAdicional, int idEstadoCli, int idMagnitudEmpresarial, int idEstadoContribuyente, DateTime dFechEstCont)
        {
            return objGuardaCliJur.GuardarCliPerJur( pcNacionalidad,pcTipRes, pcPaisRes,pcNombreCli,
                                                     pnTipDoc, pnTipPer, pcDocIde,pcNumTel,
                                                     pcNumTel2, pcCorreo, pnIdActEco, xmlDir,
                                                     pcRazSoc, pcNomCom, pdFecConst, dFecIniActEco, nNumPartReg,
                                                     nIdZonaReg, pcTipIdentif, pcSiglas, nIdEstado,
                                                     xmlVinc,pcEmpleador, dFecSystem,  idUsuario,
                                                     nIdAgencia, tcTipClasif, tcCantEmpleados, 
                                                     idActividadEcoInt, idCondDomicilio, cNroTelef3, idCodTel,
                                                            cCorreoAdicional, idEstadoCli, idMagnitudEmpresarial, idEstadoContribuyente, dFechEstCont);
        }

        //=============================================================================
        // Crear metodo para Enviar datos en del Cliente
        //=============================================================================
        public void ActualizarCliPerJur(int idCli, int pcNacionalidad,int pcTipRes, int pcPaisRes,
                                        string pcNombreCli, int pnTipDoc, int pnTipPer, string pcDocIde,
                                        string pcNumTel, string pcNumTel2, string pcCorreo, int pnIdActEco,
                                        string xmlDir, string pcRazSoc, string pcNomCom, DateTime pdFecConst,DateTime? pdFecIniActEco,
                                        String nNumPartReg, Int32 nIdZonaReg, Int32 pcTipIdentif, string pcSiglas,
                                        int nIdEstado, string xmlVinc, int pcEmpleador, DateTime dFecSystem,
                                        int idUsuario, int tcTipClasif, int tcCantEmpleados,
                                        int idActividadEcoInt, int idCondDomicilio, string cNroTelef3, int idCodTel,
                                        string cCorreoAdicional, int idEstadoCli, string cCodSBS,
                                           int idMagnitudEmpresarial, DateTime dFechaInactiv, int idEstadoContribuyente, DateTime dFechaEstCon)
        {
             objGuardaCliJur.ActualizarCliPerJur(idCli, pcNacionalidad,pcTipRes, pcPaisRes,
                                                 pcNombreCli, pnTipDoc, pnTipPer, pcDocIde,
                                                 pcNumTel, pcNumTel2, pcCorreo, pnIdActEco, 
                                                 xmlDir, pcRazSoc, pcNomCom, pdFecConst,pdFecIniActEco,
                                                 nNumPartReg, nIdZonaReg, pcTipIdentif, pcSiglas,
                                                 nIdEstado, xmlVinc, pcEmpleador,dFecSystem,
                                                 idUsuario, tcTipClasif, tcCantEmpleados,idActividadEcoInt,
                                                 idCondDomicilio, cNroTelef3, idCodTel, cCorreoAdicional, idEstadoCli, cCodSBS,
                                                 idMagnitudEmpresarial, dFechaInactiv, idEstadoContribuyente, dFechaEstCon);
        }
    }
}

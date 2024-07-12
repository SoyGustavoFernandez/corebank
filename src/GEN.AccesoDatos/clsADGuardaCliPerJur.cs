using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADGuardaCliPerJur
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
                
        //===============================================================
        //Método para Guardar Datos del Cliente en la BD
        //===============================================================
        public DataTable GuardarCliPerJur(int pcNacionalidad, int pcTipRes, int pcPaisRes, string pcNombreCli, 
                                          int pnTipDoc, int pnTipPer, string pcDocIde, string pcNumTel,
                                          string pcNumTel2, string pcCorreo, int pnIdActEco, string xmlDir,
                                          string pcRazSoc, string pcNomCom, DateTime pdFecConst, DateTime? dFecIniActEco, String nNumPartReg, 
                                          Int32 nIdZonaReg, Int32 pcTipIdentif, string pcSiglas, int nIdEstado, 
                                          string xmlVin, int pcEmpleador, DateTime dFecSystem, int idUsuario,
                                          int nIdAgencia, int tcTipClasif, int tcCantEmpleados,
                                        int idActividadEcoInt, int idCondDomicilio, string cNroTelef3, int idCodTel,
                                        string cCorreoAdicional, int idEstadoCli, int idMagnitudEmpresarial, int idEstadoContribuyente, DateTime dFechEstCont)
        {
            //--Ejecutar Procedimiento Almacenado
            return objEjeSp.EjecSP("Gen_GuardarCliPerJur_Sp",pcNacionalidad, pcTipRes,  pcPaisRes,pcNombreCli, 
                                                            pnTipDoc, pnTipPer, pcDocIde, pcNumTel, 
                                                            pcNumTel2, pcCorreo, pnIdActEco, xmlDir, 
                                                            pcRazSoc, pcNomCom, pdFecConst,  dFecIniActEco	,nNumPartReg,
                                                            nIdZonaReg, pcTipIdentif, pcSiglas, nIdEstado, 
                                                            xmlVin, pcEmpleador, dFecSystem, idUsuario,
                                                            nIdAgencia, tcTipClasif, tcCantEmpleados,
                                                            idActividadEcoInt,idCondDomicilio,cNroTelef3,idCodTel,
                                                            cCorreoAdicional, idEstadoCli, idMagnitudEmpresarial, idEstadoContribuyente, dFechEstCont);
        }

        //===============================================================
        //Método para Actualizar Datos del Cliente (Juridica) en la BD
        //===============================================================
        public void ActualizarCliPerJur(int idCli, int pcNacionalidad, int pcTipRes, int pcPaisRes, 
                                        string pcNombreCli, int pnTipDoc, int pnTipPer, string pcDocIde,
                                        string pcNumTel, string pcNumTel2, string pcCorreo, int pnIdActEco,
                                        string xmlDir, string pcRazSoc, string pcNomCom,DateTime pdFecConst,DateTime? pdFecIniActEco,
                                        String nNumPartReg, Int32 nIdZonaReg, Int32 pcTipIdentif, string pcSiglas,
                                        int nIdEstado, string xmlVin, int pcEmpleador, DateTime dFecSystem,
                                        int idUsuario, int tcTipClasif, int tcCantEmpleados,
                                        int idActividadEcoInt, int idCondDomicilio, string cNroTelef3, int idCodTel,
                                        string cCorreoAdicional, int idEstadoCli, string cCodSBS, int idMagnitudEmpresarial,
                                        DateTime dFechaInactiv, int idEstadoContribuyente, DateTime dFechaEstCont)
        {
            //--Ejecutar Procedimiento Almacenado
            objEjeSp.EjecSP("CLI_ActualizarCliPerJur_Sp", idCli, pcNacionalidad, pcTipRes, pcPaisRes,
                                                          pcNombreCli, pnTipDoc, pnTipPer, pcDocIde,
                                                          pcNumTel, pcNumTel2, pcCorreo, pnIdActEco,
                                                          xmlDir, pcRazSoc, pcNomCom, pdFecConst,pdFecIniActEco,
                                                          nNumPartReg, nIdZonaReg, pcTipIdentif, pcSiglas, 
                                                          nIdEstado, xmlVin, pcEmpleador, dFecSystem,
                                                          idUsuario, tcTipClasif, tcCantEmpleados,idActividadEcoInt,
                                                          idCondDomicilio, cNroTelef3, idCodTel, cCorreoAdicional, idEstadoCli, cCodSBS,
                                                           idMagnitudEmpresarial, dFechaInactiv, idEstadoContribuyente, dFechaEstCont);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADRastreo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void insertarRastreo(clsRastreo objrastreo)
        {
            objEjeSp.EjecSPAlm("GEN_InsertaRastreo_sp", objrastreo.idCli     ,   objrastreo.idCuenta        ,
                                                        objrastreo.idModulo     ,   objrastreo.idAgencia    , 
                                                        objrastreo.idMenu       ,   objrastreo.idUsuReg     , 
                                                        objrastreo.cNomTerminal ,   objrastreo.cCodMac      , 
                                                        objrastreo.cFormulario  ,   objrastreo.cControl     , 
                                                        objrastreo.cAccion      ,   objrastreo.dFechaSis    ,
                                                        objrastreo.cDocumentoID,    objrastreo.cIPUsuarioNET);
        }
        public void insertarRastreoPosicionConsolidada(clsRastreo objrastreo)
        {
            objEjeSp.EjecSPAlm("GEN_InsertaRastreoPosicionConsolidada_sp", objrastreo.idCli, objrastreo.idCuenta,
                                                        objrastreo.idModulo, objrastreo.idAgencia,
                                                        objrastreo.idMenu, objrastreo.idUsuReg,
                                                        objrastreo.cNomTerminal, objrastreo.cCodMac,
                                                        objrastreo.cFormulario, objrastreo.cControl,
                                                        objrastreo.cAccion, objrastreo.dFechaSis,
                                                        objrastreo.cDocumentoID, objrastreo.cIPUsuarioNET);
        }

    }
}

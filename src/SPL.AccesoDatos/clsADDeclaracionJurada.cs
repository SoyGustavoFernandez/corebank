using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace SPL.AccesoDatos
{
    public class clsADDeclaracionJurada
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable validarSujetoObligado(int idCli)
        {
            return objEjeSp.EjecSP("SPL_ValidaSujetoObligado_sp", idCli);
        }

        public void insertaDeclaracionJurada(clsDeclaracionJurada declaracion, string cOcupaciones)
        {
            objEjeSp.EjecSP("SPL_InsDecJurSujObligado_sp", declaracion.idCli                    ,   declaracion.lSujetoObligado , 
                                                            declaracion.lOficialCumplimiento    ,   declaracion.idActividad     ,
                                                            declaracion.cActividad              ,   declaracion.idDireccion     ,
                                                            declaracion.cDireccion              ,   declaracion.idUbigeo        ,   
                                                            declaracion.cDistrito               ,   declaracion.cProvincia      ,  
                                                            declaracion.cDepartamento           ,   declaracion.cAnexo          ,   
                                                            declaracion.dFechaReg       ,   
                                                            declaracion.idUsuReg                ,   declaracion.idEstado,
                                                            declaracion.cOtraOcupacion          ,   declaracion.nIngresosMensuales,
                                                            cOcupaciones);
        }

        public DataTable retDatDecJurSujObli(int idCli)
        {
            return objEjeSp.EjecSP("SPL_RetDatDeclaracionJur_sp", idCli, clsVarGlobal.nIdAgencia);
        }

        public DataTable retDatDeclaracionJurada(int idDeclaracion)
        {
            return objEjeSp.EjecSP("SPL_RptDeclaracionJuradaSO_SP", idDeclaracion);
        }
        public DataTable retDatOcupacionesDecla(int idDeclaracion)
        {
            return objEjeSp.EjecSP("GEN_ListaOcupacionPorIdDeclaracion_SP", idDeclaracion);
        }
        public DataTable ADListaActividadSujetoObligado()
        {
            return objEjeSp.EjecSP("SPL_ListaActividadSujetoObligado_SP");
        }
        public DataTable ADInsertaActSujetoOb(string cXml)
        {
            return objEjeSp.EjecSP("SPL_GuardarActividadSujetoObligado_SP", cXml);
        }
    }
}

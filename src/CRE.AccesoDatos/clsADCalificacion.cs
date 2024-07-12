using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADCalificacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarCalificacion()
        {
            return objEjeSp.EjecSP("CRE_ListarCalificacion_SP");            
        }

        public DataTable retornaCalificacionEspCli(int idCli,DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_RetornaCalificacionEspCli_SP", idCli, dFecha);            
        }

        public clsDBResp ADReclasificaCliente(int idCli , int idClasifIni , int idClasifFin, int idMotReclasifCli,	        
                                                string cObservacion, DateTime dFecReclasif, DateTime dFecRegistro, int idUsuario)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ReclasifCli_Sp", idCli, idClasifIni, idClasifFin, idMotReclasifCli,
                                                                        cObservacion,dFecReclasif,dFecRegistro,idUsuario);
            return new clsDBResp(dtResult);
        }
    }
}

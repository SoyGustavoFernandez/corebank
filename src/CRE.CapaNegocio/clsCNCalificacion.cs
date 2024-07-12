using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNCalificacion
    {
        clsADCalificacion adcalificacion = new clsADCalificacion();

        public DataTable listarCalificacion()
        {
            return adcalificacion.listarCalificacion();
        }

        public DataTable retornaCalificacionEspCli(int idCli, DateTime dFecha)
        {
            return adcalificacion.retornaCalificacionEspCli(idCli, dFecha);
        }

        public clsDBResp CNReclasificaCliente(int idCli, int idClasifIni, int idClasifFin, int idMotReclasifCli,
                                                string cObservacion, DateTime dFecReclasif, DateTime dFecRegistro, int idUsuario)
        {
            return adcalificacion.ADReclasificaCliente(idCli, idClasifIni, idClasifFin, idMotReclasifCli,
                                                        cObservacion, dFecReclasif, dFecRegistro, idUsuario);
        }
    }
}

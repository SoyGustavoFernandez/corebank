using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNProcesosGenerales
    {
        clsADProcesosGenerales LitaHorarios = new clsADProcesosGenerales();
        public DataTable ConsultaConsolidacion(int idPeriodo)
        {
            return LitaHorarios.ConsultaConsolidacion(idPeriodo);
        }
        public void Consolidar(int TipoProceso,int idPeriodo, int idUsuario, DateTime dFecRegistro)
        {
            LitaHorarios.Consolidar(TipoProceso,idPeriodo, idUsuario, dFecRegistro);
        }
    }
}

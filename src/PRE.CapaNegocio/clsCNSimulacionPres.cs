using PRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.CapaNegocio
{
    public class clsCNSimulacionPres
    {
        clsADSimulacionPres clsadsimulacionpres = new clsADSimulacionPres();
        public DataTable ListarPresuSimulados(int idPeriodo)
        {
            return clsadsimulacionpres.ListarPresuSimulados(idPeriodo);
        }
        public DataTable ListarValoresSimulados(int idPeriodo, int idSimulacion)
        {
            return clsadsimulacionpres.ListarValoresSimulados(idPeriodo, idSimulacion);
        }
        public DataTable InsertarValoresSimulados(string descripcion, int idPeriodo, int idUsuReg, DateTime dFechaReg, bool lVigente, string xmlValoresSimulados)
        {
            return clsadsimulacionpres.InsertarValoresSimulados(descripcion, idPeriodo, idUsuReg, dFechaReg, lVigente, xmlValoresSimulados);
        }
        public DataTable ActualizarValoresSimulados(int idSimulacion, string descripcion, int idPeriodo, int idUsuMod, DateTime dFechaMod, bool lVigente, string xmlValoresSimulados)
        {
            return clsadsimulacionpres.ActualizarValoresSimulados(idSimulacion, descripcion, idPeriodo, idUsuMod, dFechaMod, lVigente, xmlValoresSimulados);
        }
        public DataTable EliminarValoresSimulados(int idSimulacion, int idUsuMod, DateTime dFechaMod)
        {
            return clsadsimulacionpres.EliminarValoresSimulados(idSimulacion, idUsuMod, dFechaMod);
        }
    }
}

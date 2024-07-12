using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RSG.AccesoDatos
{
    public class clsADMantenimiento
    {
        clsGENEjeSP clsGenEjeSp = new clsGENEjeSP();
        public DataTable listarAnalistasRsg()
        {
            return clsGenEjeSp.EjecSP("RSG_ListarAnalistaRsg_sp");
        }
        public DataTable guardarAnalistaRsgZona(int idZona, int idUsuarioAnalista, int idUsuarioReg)
        {
            return clsGenEjeSp.EjecSP("RSG_RegZonaAnalistaRsg_sp", idZona, idUsuarioAnalista, idUsuarioReg);
        }
        public DataTable quitarAnalistaRsgZona(int idAnalistaRsgZona, int idUsuarioReg)
        {
            return clsGenEjeSp.EjecSP("RSG_QuitarZonaAnalistaRsg_sp", idAnalistaRsgZona, idUsuarioReg);
        }
        public DataSet listarAnalistaRsgYZona()
        {
            return clsGenEjeSp.DSEjecSP("RSG_ListarAnalistaRsgYZona_sp");
        }

        public DataTable obtenerZonaAgencia(int idAgencia)
        {
            return clsGenEjeSp.EjecSP("CRE_NombreZona_SP", idAgencia);
        }

        public DataTable listaParamClasifCreditos(int idParametro)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaParamClasifCreditos_SP", idParametro);
        }

        public DataTable guardaParamClasifCreditos(int idParametro, int nCuotasPagadas, int nMinDiasAtraso, int nMaxDiasAtraso ,int nNivelMejora)
        {
            return new clsGENEjeSP().EjecSP("RSG_GuardaParamClasifCreditos_SP", idParametro, nCuotasPagadas, nMinDiasAtraso, nMaxDiasAtraso, nNivelMejora);
        }
        
    }
}

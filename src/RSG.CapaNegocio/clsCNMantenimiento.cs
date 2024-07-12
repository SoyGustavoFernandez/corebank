using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RSG.AccesoDatos;
using GEN.Funciones;

namespace RSG.CapaNegocio
{
    public class clsCNMantenimiento
    {
        clsADMantenimiento clsAdMantenimiento = new clsADMantenimiento();
        public DataTable listarAnalistasRsg()
        {
            return clsAdMantenimiento.listarAnalistasRsg();
        }
        public DataTable guardarAnalistaRsgZona(int idZona, int idUsuarioAnalista, int idUsuarioReg)
        {
            return clsAdMantenimiento.guardarAnalistaRsgZona(idZona, idUsuarioAnalista, idUsuarioReg);
        }
        public DataTable quitarAnalistaRsgZona(int idAnalistaRsgZona, int idUsuarioReg)
        {
            return clsAdMantenimiento.quitarAnalistaRsgZona(idAnalistaRsgZona, idUsuarioReg);
        }
        public List<clsAnalistaRsgZona> listarAnalistaRsgYZona()
        {
            List<clsAnalistaRsgZona> listAnalistaRsgZona  = new List<clsAnalistaRsgZona>();
            DataSet ds = this.clsAdMantenimiento.listarAnalistaRsgYZona();
            DataTable dt = ds.Tables[0];
            
            listAnalistaRsgZona = DataTableToList.ConvertTo<clsAnalistaRsgZona>(ds.Tables[0]) as List<clsAnalistaRsgZona>;

            return listAnalistaRsgZona;
        }

        public DataTable obtenerZonaAgencia(int idAgencia)
        {
            return clsAdMantenimiento.obtenerZonaAgencia(idAgencia);
        }
        
        public DataTable listaParamClasifCreditos(int idParametro)
        {
            return clsAdMantenimiento.listaParamClasifCreditos(idParametro);
        }
        public DataTable guardaParamClasifCreditos(int idParametro, int nCuotasPagadas, int nMinDiasAtraso, int nMaxDiasAtraso, int nNivelMejora)
        {
            return clsAdMantenimiento.guardaParamClasifCreditos(idParametro, nCuotasPagadas, nMinDiasAtraso, nMaxDiasAtraso, nNivelMejora);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADAgenciaUsu
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsAgencia> ADListarAgenciasUsuario(int idUsuario)
        {
            DataTable dtResult = objEjeSp.EjecSP("GEN_ListAgenciasUsu_Sp", idUsuario);
            return MapeaTablaEntidad(dtResult);
        }

        private List<clsAgencia> MapeaTablaEntidad(DataTable dtResult)
        {
            List<clsAgencia> lstAgencias = new List<clsAgencia>();
            foreach (DataRow row in dtResult.Rows)
            {
                lstAgencias.Add
                (
                    new clsAgencia()
                    {
                        idAgencia = Convert.ToInt32(row["idAgencia"]),
                        cNombreAge =  Convert.ToString(row["cNombreAge"]),
                        cCategoria = Convert.ToString(row["cCategoria"])
                    }
                );
            }

            return lstAgencias;
        } 
    }
}
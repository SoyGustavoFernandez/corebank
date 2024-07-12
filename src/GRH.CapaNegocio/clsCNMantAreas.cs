using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantAreas
    {
        clsADMantAreas ListaAreas = new clsADMantAreas();

        public DataTable ListarAreas()
        {
            return ListaAreas.ListarAreas();
        }
        public DataTable ActualizarAreas(int idArea,string cNomArea,int lVigente)
        {
            return ListaAreas.ActualizarAreas(idArea, cNomArea, lVigente);
        }
        public int GuardarAreas(string cNomArea,int lVigente)
        {
            DataTable dtResp= ListaAreas.GuardarAreas(cNomArea, lVigente);
            int idNuevo=Convert.ToInt32(dtResp.Rows[0][0]);
            return idNuevo;
        }
    }
}

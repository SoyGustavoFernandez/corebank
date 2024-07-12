using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
     public class clsUbigeo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public static DataTable dtUbigeo;
        public DataTable ListarUbigeo(Int32 nIdNodo)
        {
            return objEjeSp.EjecSP("Gen_ListaUbigeo_sp", nIdNodo);
        }

        public DataTable ListarUbigeoXml(Int32 nIdNodo)
        {
            if (dtUbigeo == null)
            {
                dtUbigeo = cnadtabla.retonarTablaXml("SI_FinUbigeo");
            }
            return dtUbigeo;
        }

        public DataTable ListarNombresUbig(int IdPais, int nIdDepartamento, int nIdProvincia, int nIdDistrito)
        {
            return objEjeSp.EjecSP("GEN_ListarNombresUbig", IdPais, nIdDepartamento, nIdProvincia, nIdDistrito);
        }

    }


}

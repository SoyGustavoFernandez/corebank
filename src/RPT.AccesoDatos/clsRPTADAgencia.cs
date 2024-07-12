using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADAgencia
    {
        public DataTable ADDatoAgencia(int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_BusAgencia_SP", idAgencia);
        }
        public DataTable ADAgenciaUsuario(int idAgencia, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("GEN_BusDatosReporte_SP", idAgencia, idUsuario);
        }
        public DataTable ADRutaLogo()
        {
            return new clsGENEjeSP().EjecSP("GEN_RetornaValorVariable_sp","CRUTALOGO");
        }
        public DataTable ADDepartamento()
        {
            return new clsGENEjeSP().EjecSP("GEN_Departamentos_sp");
        }
        public DataTable ADProvincia(string cCodDpto)
        {
            return new clsGENEjeSP().EjecSP("GEN_Provincias_sp", cCodDpto);
        }
        public DataTable ADRutaImgLimite()
        {
            return new clsGENEjeSP().EjecSP("GEN_RetornaValorVariable_sp", "cRutaImgLimite");
        }
    }
}

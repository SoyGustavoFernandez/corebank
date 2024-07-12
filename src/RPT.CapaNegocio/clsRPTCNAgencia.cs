using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RPT.AccesoDatos;

namespace RPT.CapaNegocio
{
    public class clsRPTCNAgencia
    {
        clsRPTADAgencia ADAgencia = new clsRPTADAgencia();

        public DataTable CNDatoAgencia(int idAgencia)
        {
            return ADAgencia.ADDatoAgencia(idAgencia);
        }
        public DataTable CNAgenciaUsuario(int idAgencia, int idUsuario)
        {
            return ADAgencia.ADAgenciaUsuario(idAgencia, idUsuario);
        }
        public DataTable CNRutaLogo()
        {
            return ADAgencia.ADRutaLogo();
        }
        public DataTable CNDepartamento()
        {
            return ADAgencia.ADDepartamento();
        }
        public DataTable CNProvincia(string cCodDpto)
        {
            return ADAgencia.ADProvincia(cCodDpto);
        }
        public DataTable CNRutaImgLimite()
        {
            return ADAgencia.ADRutaImgLimite();
        }
    }
}

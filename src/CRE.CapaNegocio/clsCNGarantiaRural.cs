using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNGarantiaRural
    {
        clsADGarantiaRural garantiaRural = new clsADGarantiaRural();

        public DataTable ListarGarantiaRuralid(int idEvalCred)
        {
            return garantiaRural.ListarGarantiaRuralid(idEvalCred);
        }

        public DataTable InsertarGarantiaRural(int idEvalCred, string cDescripcion, string cTipoDocumento, decimal nValor, int idUsuarioReg, DateTime dFechaHoraReg)
        {
            return garantiaRural.InsertarGarantiaRural(idEvalCred, cDescripcion, cTipoDocumento, nValor, idUsuarioReg, dFechaHoraReg);
        }

        public DataTable ActualizarGarantiaRural(int idGarantia, int idEvalCred, string cDescripcion, string cTipoDocumento, decimal nValor, int idUsuarioMod, DateTime dfechaUltimaMod)
        {
            return garantiaRural.ActualizarGarantiaRural(idGarantia, idEvalCred, cDescripcion, cTipoDocumento, nValor, idUsuarioMod, dfechaUltimaMod);
        }
    }
}

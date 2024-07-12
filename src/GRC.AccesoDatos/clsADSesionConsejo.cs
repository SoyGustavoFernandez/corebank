using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADSesionConsejo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarSesionConsejo()
        {
            return objEjeSp.EjecSP("RCP_ListarSesionConsejo_SP");
        }

        public DataTable ListarSesionConsejoid(int idSesionConsejo)
        {
            return objEjeSp.EjecSP("RCP_ListarSesionConsejoidSesionConsejo_SP", idSesionConsejo);
        }

        public DataTable InsertarSesionConsejo(string cSesionConsejo, int idConsejo, int idTipoSesion, DateTime dFecReg, int idUsuReg, string cAsunto, string cAcuerdos, string cObservaciones, bool lVigente, string xmlAsistentes)
        {
            return objEjeSp.EjecSP("RCP_InsertarSesionConsejo_SP",cSesionConsejo, idConsejo, idTipoSesion, dFecReg, idUsuReg, cAsunto, cAcuerdos, cObservaciones, lVigente, xmlAsistentes);
        }

        public DataTable ActualizarSesionConsejo(string cSesionConsejo, int idConsejo, int idTipoSesion, DateTime dFecReg, int idUsuReg, string cAsunto, string cAcuerdos, string cObservaciones, bool lVigente, int idSesionConsejo)
        {
            return objEjeSp.EjecSP("RCP_ActualizarSesionConsejo_SP", cSesionConsejo, idConsejo, idTipoSesion, dFecReg, idUsuReg, cAsunto, cAcuerdos, cObservaciones, lVigente, idSesionConsejo);
        }

        public DataTable ListarDetalleSesionidSesionConsejo(int idSesionConsejo)
        {
            return objEjeSp.EjecSP("RCP_ListarDetalleSesionidSesionConsejo_SP", idSesionConsejo);
        }

        public DataTable InsertarDetalleSesion(int idSesionConsejo, int idCli)
        {
            return objEjeSp.EjecSP("RCP_InsertarDetalleSesion_SP",idSesionConsejo, idCli);
        }

        public DataTable ActualizarDetalleSesion(int idSesionConsejo, int idCli)
        {
            return objEjeSp.EjecSP("RCP_ActualizarDetalleSesion_SP", idSesionConsejo, idCli);
        }

        public DataTable ListarDocumentosSesionid(int idSesion)
        {
            return objEjeSp.EjecSP("RCP_ListarDocumentosSesionidSesion_SP", idSesion);
        }

        public DataTable InsertarDocumentosSesion(int idSesion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension)
        {
            return objEjeSp.EjecSP("RCP_InsertarDocumentosSesion_SP", idSesion, cDocumentoSesion, vDocumentoSesion.ToArray(), cExtension);            
        }

        public DataTable BusquedaSesiones(int idTipoSesion, int idConsejo, DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RCP_BusquedaSesiones_SP", idTipoSesion, idConsejo, dFecIni, dFecFin);            
        }
    }
}

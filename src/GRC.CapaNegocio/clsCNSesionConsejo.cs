using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public class clsCNSesionConsejo
    {
        clsADSesionConsejo sesionconsejo = new clsADSesionConsejo();

        public DataTable ListarSesionConsejo()
        {
            return sesionconsejo.ListarSesionConsejo();
        }

        public DataTable ListarSesionConsejoid(int idSesionConsejo)
        {
            return sesionconsejo.ListarSesionConsejoid(idSesionConsejo);
        }

        public DataTable InsertarSesionConsejo(string cSesionConsejo, int idConsejo, int idTipoSesion, DateTime dFecReg, int idUsuReg, string cAsunto, string cAcuerdos, string cObservaciones, bool lVigente, string xmlAsistentes)
        {
            return sesionconsejo.InsertarSesionConsejo(cSesionConsejo, idConsejo, idTipoSesion, dFecReg, idUsuReg, cAsunto, cAcuerdos, cObservaciones, lVigente, xmlAsistentes);
        }

        public DataTable ActualizarSesionConsejo(string cSesionConsejo, int idConsejo, int idTipoSesion, DateTime dFecReg, int idUsuReg, string cAsunto, string cAcuerdos, string cObservaciones, bool lVigente, int idSesionConsejo)
        {
            return sesionconsejo.ActualizarSesionConsejo(cSesionConsejo, idConsejo, idTipoSesion, dFecReg, idUsuReg, cAsunto, cAcuerdos, cObservaciones, lVigente, idSesionConsejo);
        }

        public DataTable ListarDetalleSesionidSesionConsejo(int idSesionConsejo)
        {
            return sesionconsejo.ListarDetalleSesionidSesionConsejo(idSesionConsejo);
        }

        public DataTable InsertarDetalleSesion(int idSesionConsejo, int idCli)
        {
            return sesionconsejo.InsertarDetalleSesion(idSesionConsejo, idCli);
        }

        public DataTable ActualizarDetalleSesion(int idSesionConsejo, int idCli)
        {
            return sesionconsejo.ActualizarDetalleSesion(idSesionConsejo, idCli);
        }

        public DataTable ListarDocumentosSesionid(int idSesion)
        {
            return sesionconsejo.ListarDocumentosSesionid( idSesion);
        }

        public DataTable InsertarDocumentosSesion(int idSesion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension)
        {
            return sesionconsejo.InsertarDocumentosSesion(idSesion, cDocumentoSesion, vDocumentoSesion.ToArray(), cExtension);
        }

        public DataTable BusquedaSesiones(int idTipoSesion, int idConsejo, DateTime dFecIni, DateTime dFecFin)
        {
            return sesionconsejo.BusquedaSesiones(idTipoSesion, idConsejo, dFecIni, dFecFin);
        }
    }
}

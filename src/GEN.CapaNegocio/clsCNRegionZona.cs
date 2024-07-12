using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNRegionZona
    {
        clsADRegionZona cnregionzona = new clsADRegionZona();

        public DataTable CNActualizarZona(int idZona, string cDesZona, bool lVigente)
        {
            return cnregionzona.ADActualizarZona(idZona, cDesZona, lVigente);
        }

        public DataTable CNEliminarZona(int idZona)
        {
            return cnregionzona.ADEliminarZona(idZona);
        }

        public DataTable CNInsertarZona(string cDesZona, bool lVigente)
        {
            return cnregionzona.ADInsertarZona(cDesZona, lVigente);
        }

        public DataTable CNListarZona()
        {
            return cnregionzona.ADListarZona();
        }

        public DataTable CNListarOficinaByZona(int idZona)
        {
            return cnregionzona.ADListarOficinaByZona(idZona);
        }

        public DataTable CNListarOficinaSinZona()
        {
            return cnregionzona.ADListarOficinaSinZona();
        }

        public DataTable CNVincularRegionZonaOficina(string xmlAgeZona)
        {
            return cnregionzona.ADVincularRegionZonaOficina(xmlAgeZona);
        }
        //Tipo Zona
        public DataTable CNListarTipoZona()
        {
            return cnregionzona.ADListarTipoZona();
        }

        public DataTable CNCambiaOrdenAscTipoZona(int nOrden)
        {
            return cnregionzona.ADCambiaOrdenAscTipoZona(nOrden);
        }

        public DataTable CNCambiaOrdenDescTipoZona(int nOrden)
        {
            return cnregionzona.ADCambiaOrdenDescTipoZona(nOrden);
        }

        public DataTable CNRegistraTipoZona(string cZona, string cCodSunat, int idSector)
        {
            return cnregionzona.ADRegistraTipoZona(cZona, cCodSunat, idSector);
        }

        public DataTable CNActualizarTipoZona(int idTipoVia, string cVia, string cCodSunat, bool lVigente, int idSector)
        {
            return cnregionzona.ADActualizarTipoZona(idTipoVia, cVia, cCodSunat, lVigente, idSector);
        }
        public DataTable CNEliminarTipoZona(int idTipoZona)
        {
            return cnregionzona.ADEliminarTipoZona(idTipoZona);
        }

        //Tipo Via
        public DataTable CNListarTipoVia()
        {
            return cnregionzona.ADListarTipoVia();
        }

        public DataTable CNCambiaOrdenAscTipoVia(int nOrden)
        {
            return cnregionzona.ADCambiaOrdenAscTipoVia(nOrden);
        }

        public DataTable CNCambiaOrdenDescTipoVia(int nOrden)
        {
            return cnregionzona.ADCambiaOrdenDescTipoVia(nOrden);
        }

        public DataTable CNRegistraTipoVia(string cZona, string cCodSunat)
        {
            return cnregionzona.ADRegistraTipoVia(cZona, cCodSunat);
        }

        public DataTable CNActualizarTipoVia(int idTipoVia, string cVia, string cCodSunat, bool lVigente)
        {
            return cnregionzona.ADActualizarTipoVia(idTipoVia, cVia, cCodSunat, lVigente);
        }
        public DataTable CNEliminarTipoVia(int idTipoVia)
        {
            return cnregionzona.ADEliminarTipoVia(idTipoVia);
        }
    }
}

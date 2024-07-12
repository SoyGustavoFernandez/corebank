using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;   

namespace GEN.AccesoDatos
{
    public class clsADRegionZona
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADActualizarZona(int idZona, string cDesZona, bool lVigente)
        {
            return objEjeSp.EjecSP("ADM_ActualizarZona_SP", idZona, cDesZona, lVigente);
        }

        public DataTable ADEliminarZona(int idZona)
        {
            return objEjeSp.EjecSP("ADM_EliminarZona_SP", idZona);
        }

        public DataTable ADInsertarZona(string cDesZona, bool lVigente)
        {
            return objEjeSp.EjecSP("ADM_InsertarZona_SP", cDesZona, lVigente);
        }

        public DataTable ADListarZona()
        {
            return objEjeSp.EjecSP("ADM_ListarZona_SP");
        }

        public DataTable ADListarOficinaByZona(int idZona)
        {
            return objEjeSp.EjecSP("ADM_ListarOficinaByZona_SP", idZona);
        }

        public DataTable ADListarOficinaSinZona()
        {
            return objEjeSp.EjecSP("ADM_ListarOficinaSinZona_SP");
        }

        public DataTable ADVincularRegionZonaOficina(string xmlAgeZona)
        {
            return objEjeSp.EjecSP("ADM_VincularRegionZonaOficina_SP", xmlAgeZona);
        }

        //Tipo Zona
        public DataTable ADListarTipoZona()
        {
            return objEjeSp.EjecSP("ADM_ListarTipoZona_SP");
        }

        public DataTable ADCambiaOrdenAscTipoZona(int nOrden)
        {
            return objEjeSp.EjecSP("ADM_CambiaOrdenAscTipoZona_SP", nOrden);
        }

        public DataTable ADCambiaOrdenDescTipoZona(int nOrden)
        {
            return objEjeSp.EjecSP("ADM_CambiaOrdenDescTipoZona_SP", nOrden);
        }

        public DataTable ADRegistraTipoZona(string cZona, string cCodSunat, int idSector)
        {
            return objEjeSp.EjecSP("ADM_RegistrarTipoZona_SP", cZona, cCodSunat, idSector);
        }

        public DataTable ADActualizarTipoZona(int idTipoVia, string cVia, string cCodSunat, bool lVigente, int idSector)
        {
            return objEjeSp.EjecSP("ADM_ActualizarTipoZona_SP", idTipoVia, cVia, cCodSunat, lVigente, idSector);
        }
        public DataTable ADEliminarTipoZona(int idTipoZona)
        {
            return objEjeSp.EjecSP("ADM_EliminarTipoZona_SP", idTipoZona);
        }

        //Tipo Via
        public DataTable ADListarTipoVia()
        {
            return objEjeSp.EjecSP("ADM_ListarTipoVia_SP");
        }

        public DataTable ADCambiaOrdenAscTipoVia(int nOrden)
        {
            return objEjeSp.EjecSP("ADM_ActualizaOrdenAscTipoVia_SP", nOrden);
        }

        public DataTable ADCambiaOrdenDescTipoVia(int nOrden)
        {
            return objEjeSp.EjecSP("ADM_ActualizaOrdenDescTipoVia_SP", nOrden);
        }

        public DataTable ADRegistraTipoVia(string cVia, string cCodSunat)
        {
            return objEjeSp.EjecSP("ADM_RegistrarTipoVia_SP", cVia, cCodSunat);
        }

        public DataTable ADActualizarTipoVia(int idTipoVia, string cVia, string cCodSunat, bool lVigente)
        {
            return objEjeSp.EjecSP("ADM_ActualizarTipoVia_SP", idTipoVia, cVia, cCodSunat, lVigente);
        }
        public DataTable ADEliminarTipoVia(int idTipoVia)
        {
            return objEjeSp.EjecSP("ADM_EliminarTipoVia_SP", idTipoVia);
        }
    }
}

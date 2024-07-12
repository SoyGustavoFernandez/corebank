using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace GEN.AccesoDatos
{
    public class clsADEstadoSolic
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarEstadoSolic()
        {
            return objEjeSp.EjecSP("Gen_ListarEstadoSolic_sp");
        }

        public DataTable listarEstadoSolicXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoSolicitud");
        }

        //Lista el estado de la Solicitudes

        public DataTable ADlistarEstSolic(int idEstadoSol)
        {
            return objEjeSp.EjecSP("GEN_ListaEstadoSolicitud_SP", idEstadoSol);
        }

        public DataTable ADlistaEstSolicitudPermiso()
        {
            return objEjeSp.EjecSP("GEN_ListaEstadoSolicitudPermiso_SP");
        }

    }
}

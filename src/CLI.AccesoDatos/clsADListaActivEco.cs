using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.AccesoDatos;

namespace CLI.AccesoDatos
{
    public class clsADListaActivEco
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ListaAtivEco()
        {
            return objEjeSp.EjecSP("Cli_ListaActividadEconomica_Sp");
        }

        public DataTable ListaAtivEco(int idActivEco)
        {
            return objEjeSp.EjecSP("Cli_ListaActividadEconomica_Sp", idActivEco);
        }

        public DataTable BuscarPadre(int buscPa)
        {
            return objEjeSp.EjecSP("GEN_PadreActividadEconomica", buscPa);
        }

        public DataTable ListaAtivEcoXml(int idActivEco)
        {
            return cnadtabla.retonarTablaXml("SI_FinActividad");
        }
        //LISTA LAS ACTIVIDADES INTERNAS POR NOMBRE
        public DataTable ADListaActivEcoByNombre(string cNombre)
        {
            return objEjeSp.EjecSP("GEN_ListaActividadEcoInternaByNombre_sp", cNombre);    
        }

        #region Mantenimiento de Actividad Interna        

        public DataTable ADListaActividadInternaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FINActividadInterna");
        }

        public DataTable ADListarActividadesInternas()
        {
            return objEjeSp.EjecSP("GEN_ListarActividadesInternas_SP");
        }

        public DataTable ADListarActividadInternaId(int idActividadInterna)
        {
            return objEjeSp.EjecSP("GEN_ListarActividadInternaId_SP", idActividadInterna);
        }

        public DataTable ADEliminarActividadInterna(int idActividadInterna)
        {
            return objEjeSp.EjecSP("GEN_EliminarActividadInterna_SP", idActividadInterna);
        }

        public DataTable ADInsertarActividadInterna(string cActividadInterna, int idActividad, int idUsuReg, bool lVigente, int idCategoria)
        {
            return objEjeSp.EjecSP("GEN_InsertarActividadInterna_SP", cActividadInterna, idActividad, idUsuReg, lVigente, idCategoria);
        }

        public DataTable ADActualizarActividadInterna(int idActividadInterna, string cActividadInterna, int idActividad, int idUsuReg, bool lVigente, int idCategoria)
        {
            return objEjeSp.EjecSP("GEN_ActualizarActividadInterna_SP", idActividadInterna, cActividadInterna, idActividad, idUsuReg, lVigente, idCategoria);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLI.AccesoDatos;
using System.Data;

namespace CLI.CapaNegocio
{
    public class clsCNListaActivEco
    {
        clsADListaActivEco objListaActEco = new clsADListaActivEco();

        public DataTable ListaActividadEco()
        {
            return objListaActEco.ListaAtivEco();
        }

        public DataTable ListaActividadEco(int idActivEco)
        {
            var dtActividadAux = objListaActEco.ListaAtivEcoXml(idActivEco);
            dtActividadAux.Columns.Add("cActividadCompuesto", typeof(string));

            dtActividadAux.AsEnumerable().ToList().ForEach(x => x["cActividadCompuesto"] ="["+ x["cCodSbs"].ToString().Trim() + "] - " + x["cActividad"].ToString());
            dtActividadAux.AcceptChanges();

            DataTable dtActividad = dtActividadAux.Clone();

            (from item in dtActividadAux.AsEnumerable()
             where (bool)item["lVigente"] == true
                    && (item["idPadreActividad"]==DBNull.Value ? 0 : (int)item["idPadreActividad"]) == idActivEco
             orderby item.Field<String>("cActividad") ascending
             select item).CopyToDataTable(dtActividad, LoadOption.OverwriteChanges);

            return dtActividad;
        }

        public DataTable BuscarPadre(Int32 buscPa)
        {
            return objListaActEco.BuscarPadre(buscPa);
        }
        //LISTA LAS ACTIVIDADES INTERNAS POR NOMBRE
        public DataTable CNListaActivEcoByNombre(string cNombre)
        {
            return objListaActEco.ADListaActivEcoByNombre( cNombre);
        }

        public DataTable CNListaActividadEspecifica(int idActividad)
        {
            var dt = objListaActEco.ListaAtivEcoXml(idActividad);

            DataTable dtActividad = dt.Clone();

            (from item in dt.AsEnumerable()
             where (item["idActividad"] == DBNull.Value ? 0 : (int)item["idActividad"]) == idActividad
             select item).CopyToDataTable(dtActividad, LoadOption.OverwriteChanges);

            return dtActividad;
        }

        #region Mantenimiento de Actividad Interna
        
        public DataTable CNListarActividadesInternasTodo()
        {
            return objListaActEco.ADListaActividadInternaXml();
        }

        public DataTable CNListarActividadesInternasVigentes()
        {
            var dt = objListaActEco.ADListaActividadInternaXml();

            DataTable dtActividad = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtActividad, LoadOption.OverwriteChanges);

            return dtActividad;
        }

        public DataTable CNListarActividadInternaId(int idActividadInterna)
        {
            var dt = objListaActEco.ADListaActividadInternaXml();

            DataTable dtActividad = dt.Clone();

            (from item in dt.AsEnumerable()
             where (int)item["idActividadInterna"] == idActividadInterna
             select item).CopyToDataTable(dtActividad, LoadOption.OverwriteChanges);

            return dtActividad;
        }

        public DataTable CNEliminarActividadInterna(int idActividadInterna)
        {
            return objListaActEco.ADEliminarActividadInterna(idActividadInterna);
        }

        public DataTable CNInsertarActividadInterna(string cActividadInterna, int idActividad, int idUsuReg, bool lVigente, int idCategoria)
        {
            return objListaActEco.ADInsertarActividadInterna(cActividadInterna, idActividad, idUsuReg, lVigente, idCategoria);
        }

        public DataTable CNActualizarActividadInterna(int idActividadInterna, string cActividadInterna, int idActividad, int idUsuReg, bool lVigente, int idCategoria)
        {
            return objListaActEco.ADActualizarActividadInterna(idActividadInterna, cActividadInterna, idActividad, idUsuReg, lVigente, idCategoria);
        }

        #endregion
    }
}


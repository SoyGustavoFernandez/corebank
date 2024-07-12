using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADTasador
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        /// <summary>
        /// retorna el listado de tasadores vigentes
        /// </summary>
        /// <returns>coleccion de tasadores</returns>
        public List<clsTasador> listarTasador()
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ListaTasadores_sp");

            return MapeaTablaEntidadTasador(dtResult);
        }

        public clsDBResp ADGuardarTasador(clsTasador objTasador)
        {
            List<clsTasador> lstTasador = new List<clsTasador>();
            lstTasador.Add(objTasador);
            string xmlTasador = lstTasador.GetXml<clsTasador>();
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsActTasador_sp", xmlTasador);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        private List<clsTasador> MapeaTablaEntidadTasador(DataTable dtResult)
        {
            List<clsTasador> lstTasadores = new List<clsTasador>();
            foreach (DataRow row in dtResult.Rows)
            {
                lstTasadores.Add(new clsTasador()
                {
                    idTasador = Convert.ToInt32(row["idTasador"]),
                    cTasador = Convert.ToString(row["cTasador"]),
                    cPaterno = Convert.ToString(row["cPaterno"]),
                    cMaterno = Convert.ToString(row["cMaterno"]),
                    cNombres = Convert.ToString(row["cNombres"]),
                    cResolSBS = Convert.ToString(row["cResolSBS"]),
                    dFecResolucion = Convert.ToDateTime(row["dFecResolucion"]),
                    dFinResolucion = Convert.ToDateTime(row["dFinResolucion"]),
                    cDireccion = Convert.ToString(row["cDireccion"]),
                    cDirEstudio = Convert.ToString(row["cDirEstudio"]),
                    idUbigeo =  Convert.ToInt32(row["idUbigeo"]),
                    cTelefFijo =  Convert.ToString(row["cTelefFijo"]),
                    cTelefCel = Convert.ToString(row["cTelefCel"]),
                    cEspecialidad = Convert.ToString(row["cEspecialidad"]),
                    dFechaReg = Convert.ToDateTime(row["dFechaReg"]),
                    cDocumento = Convert.ToString(row["cDocumento"]),
                    lVigente = Convert.ToBoolean(row["lVigente"])
                });
            }
            return lstTasadores;
        }
    }
}

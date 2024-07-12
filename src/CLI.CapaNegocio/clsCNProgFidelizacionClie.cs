using System.Data;
using CLI.AccesoDatos;
using System.Collections.Generic;
using System;

namespace CLI.CapaNegocio
{
    public class clsCNProgFidelizacionClie
    {
        clsADProgFidelizacionClie objProgFidelizacionClie = new clsADProgFidelizacionClie();

        //===============================================================
        // Registrar programa de fidelización del cliete.
        //===============================================================
        public DataTable CNRegistrarProgFidelizacionClie(int idCliente, int idEstado, int idUsuario)
        {
            return objProgFidelizacionClie.ADRegistrarProgFidelizacionClie(idCliente, idEstado, idUsuario);
        }

        //===============================================================
        // Obtener programa de fidelización del cliete.
        //===============================================================
        public DataTable CNObtenerProgFidelizacionClie(int idCliente)
        {
            return objProgFidelizacionClie.ADObtenerProgFidelizacionClie(idCliente);
        }

        //===============================================================
        // Obtener estados del programa de fidelización.
        //===============================================================
        public Dictionary<int, string> CNObtEstProgFidelizacion()
        {
            Dictionary<int, string> EstProgFid = new Dictionary<int, string>();
            DataTable dt = objProgFidelizacionClie.ADObtEstProgFidelizacion();
            foreach (DataRow dr in dt.Rows)
            {
                int idEstado = (int)dr["idEstado"];
                string cEstado = (string)dr["cEstado"];
                EstProgFid.Add(idEstado, cEstado);
            }

            return EstProgFid;
        }

        //===============================================================
        // Obtiene los datos del colaborador.
        //===============================================================
        public DataTable CNObtenerDatosColaborador(int idCliente, string cDocumentoID = "")
        {
            return objProgFidelizacionClie.ADObtenerDatosColaborador(idCliente, cDocumentoID);
        }

        //===============================================================
        // Registrar el log de estados del programa de fidelización del cliete.
        //===============================================================
        public DataTable CNRegistrarLogEstClieProgFid(int idCliente, int idEstado, int idUsuario)
        {
            return objProgFidelizacionClie.ADRegistrarLogEstClieProgFid(idCliente, idEstado, idUsuario);
        }
        
    }
}

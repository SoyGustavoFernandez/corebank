using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNConfiguracionImpresionContratos
    {
        clsADConfiguracionImpresionContratos clsConfiguracion = new clsADConfiguracionImpresionContratos();

        public clsCNConfiguracionImpresionContratos(bool cConex)
        {
            clsConfiguracion = new clsADConfiguracionImpresionContratos(cConex);
        }

        public clsCNConfiguracionImpresionContratos()
        {
            clsConfiguracion = new clsADConfiguracionImpresionContratos();
        }

        public DataTable listarConfiguracion()
        {
            return clsConfiguracion.listarConfiguracion();
        }

        public DataTable actualizarVariableConfiguracion(int idVariable, string cValor) 
        {
            return clsConfiguracion.actualizarVariableConfiguracion(idVariable, cValor);
        }

        public DataTable obtenerVariableConfiguracion()
        {
            return clsConfiguracion.obtenerVariableConfiguracion();
        }

        public DataTable listarIntervinientes(int idModulo, int idSolicitud)
        {
            return clsConfiguracion.listarIntervinientes(idModulo, idSolicitud);
        }

        public DataTable listarIntervinientesImprimir(int idModulo, int idSolicitud)
        {
            DataTable dtInterv = clsConfiguracion.listarIntervinientesImprimir(idModulo, idSolicitud);

            return separarNombres(dtInterv);
        }

        public DataTable retornaIntervinientesImprimirBlanco(DataTable dtVariable, int idModulo)
        {
            int nFilasDefault = 0;
            if (dtVariable.Rows.Count > 0) {
                nFilasDefault = (
                    idModulo == 0 ? Convert.ToInt32(dtVariable.Rows[0]["nFilasDefualtGrupoSolidario"])
                    : (idModulo == 1 ? Convert.ToInt32(dtVariable.Rows[0]["nFilasDefualtCredito"]) 
                    : Convert.ToInt32(dtVariable.Rows[0]["nFilasDefualtAhorros"])
                    ));
            }

            return generarDataTableParticipantes(nFilasDefault, idModulo);
        }

        public DataTable retornaTestigosRuego()
        {
            return generarDataTableParticipantes(1,0);
        }

        public DataTable generarDataTableParticipantes(int nFilas, int idModulo)
        {
            DataTable dtIntervinientes = new DataTable();
            dtIntervinientes.Columns.Add("idTipoInterv", typeof(int));
            dtIntervinientes.Columns.Add("cNombre_A1", typeof(String));
            dtIntervinientes.Columns.Add("cNombre_A2", typeof(String));
            dtIntervinientes.Columns.Add("cDocumentoID_A", typeof(String));
            dtIntervinientes.Columns.Add("cDireccion_A", typeof(String));
            dtIntervinientes.Columns.Add("cNombre_B1", typeof(String));
            dtIntervinientes.Columns.Add("cNombre_B2", typeof(String));
            dtIntervinientes.Columns.Add("cDocumentoID_B", typeof(String));
            dtIntervinientes.Columns.Add("cDireccion_B", typeof(String));

            for (int i = 0; i < nFilas; i++)
            {
                int idTipoInterv = 1;
                if(idModulo == 1 && i>=2)
                    idTipoInterv = 3;

                DataRow row = dtIntervinientes.NewRow();
                row["idTipoInterv"] = idTipoInterv;
                row["cNombre_A1"] = "";
                row["cNombre_A2"] = "";
                row["cDocumentoID_A"] = "";
                row["cDireccion_A"] = "";
                row["cNombre_B1"] = "";
                row["cNombre_B2"] = "";
                row["cDocumentoID_B"] = "";
                row["cDireccion_B"] = "";
                dtIntervinientes.Rows.Add(row);
            }

            return dtIntervinientes;
        }

        public DataTable guardarRegistroImpresion(int nModulo, int idSolicitud, int idPerfil, int idUsuario, string cCadenaEncriptada)
        {
            return clsConfiguracion.guardarRegistroImpresion(nModulo, idSolicitud, idPerfil, idUsuario, cCadenaEncriptada);
        }

        public DataTable obtenerNumeroImpresiones(int nModulo, int idSolicitud)
        {
            return clsConfiguracion.obtenerNumeroImpresiones(nModulo, idSolicitud);
        }

        public DataTable obtenerFechaCuenta(int nModulo, int idSolicitud)
        {
            return clsConfiguracion.obtenerFechaCuenta(nModulo, idSolicitud);
        }

        public DataTable obtenerDocumentoPlantilla(string cNombre)
        {
            return clsConfiguracion.obtenerDocumentoPlantilla(cNombre);
        }

        private DataTable separarNombres(DataTable dtInterv)
        {
            foreach (System.Data.DataColumn col in dtInterv.Columns) col.ReadOnly = false;

            int nSizeMax = 12;
            foreach (DataRow row in dtInterv.Rows)
            {
                /*primer Interviniente*/
                string[] palabras = row["cNombre_A1"].ToString().Split(' ');
                string cNombre1 = "";
                string cNombre2 = "";
                int i;
                for (i= 0; i < palabras.Length; i++)
                {
                    if (cNombre1.Length + palabras[i].Length <= nSizeMax)
                        cNombre1 = cNombre1 + " " + palabras[i];
                    else
                        break;
                }

                for (; i < palabras.Length; i++)
                {
                    cNombre2 = cNombre2 + " " + palabras[i];
                }

                row["cNombre_A1"] = cNombre1;
                row["cNombre_A2"] = cNombre2;
                /*Segudo Interviniente*/
                string[] palabrasB = row["cNombre_B1"].ToString().Split(' ');
                string cNombreB1 = "";
                string cNombreB2 = "";
                
                for (i = 0; i < palabrasB.Length; i++)
                {
                    if (cNombreB1.Length + palabrasB[i].Length <= nSizeMax)
                        cNombreB1 = cNombreB1 + " " + palabrasB[i];
                    else
                        break;
                }

                for (; i < palabrasB.Length; i++)
                {
                    cNombreB2 = cNombreB2 + " " + palabrasB[i];
                }

                row["cNombre_B1"] = cNombreB1;
                row["cNombre_B2"] = cNombreB2;
            }
            return dtInterv;
        }
    }
}

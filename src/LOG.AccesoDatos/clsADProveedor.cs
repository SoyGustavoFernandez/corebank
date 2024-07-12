using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace LOG.AccesoDatos
{
    public class clsADProveedor
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADMostrarDatosProveedorIdCli(int idCli)
        {
            return objEjeSp.EjecSP("LOG_MostrarDatosProveedorIdCli_SP", idCli);
        }

        public DataTable ADInsertarProveedor(int idCli, string cCtaDetraccion, int idUsuarioReg, DateTime dFechaReg, string cCuentaCorriente)
        {
            return objEjeSp.EjecSP("LOG_InsertarProveedor_SP", idCli, cCtaDetraccion, idUsuarioReg, dFechaReg, cCuentaCorriente);
        }

        public DataTable ADActualizarProveedor(int idProveedor, string cCtaDetraccion, int idUsuarioMod, DateTime dFechaMod, string cCeuntaCorriente)
        {
            return objEjeSp.EjecSP("LOG_ActualizarProveedor_SP", idProveedor, cCtaDetraccion, idUsuarioMod, dFechaMod, cCeuntaCorriente);
        }

        public DataTable ADEliminarProveedor(int idProveedor, int idUsuarioMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("LOG_EliminarProveedor_SP", idProveedor, idUsuarioMod, dFechaMod);
        }

        public List<clsProveedores> ADBusProveedor(string cCriterio, string cDatoCriterio)
        {
            List<clsProveedores> LstProveedores;
            DataTable dtResult = objEjeSp.EjecSP("LOG_BusProveedor_SP", cCriterio, cDatoCriterio);
            LstProveedores = MapeaTablaEntidadProveedor(dtResult);
            return LstProveedores;

        }

        private List<clsProveedores> MapeaTablaEntidadProveedor(DataTable dtResult)
        {
            List<clsProveedores> LstProveedores = new List<clsProveedores>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsProveedores objProveedor = new clsProveedores();
                objProveedor.idProveedor = Convert.ToInt32(row["idProveedor"]);
                objProveedor.idCli = Convert.ToInt32(row["idCli"]);
                objProveedor.cCtaDetraccion = Convert.ToString(row["cCtaDetraccion"]);
                objProveedor.cCuentaCorriente = Convert.ToString(row["cCuentaCorriente"]);
                objProveedor.cNombre = Convert.ToString(row["cNombre"]);
                objProveedor.cNombreComercial = Convert.ToString(row["cNombreComercial"]);
                objProveedor.cDocumentoID = Convert.ToString(row["cDocumentoID"]);
                objProveedor.cDireccion = Convert.ToString(row["cDireccion"]);
                objProveedor.IdTipoPersona = Convert.ToInt32(row["IdTipoPersona"]);
                objProveedor.cCodCliente = Convert.ToString(row["cCodCliente"]);
                objProveedor.idTipoDocumento = Convert.ToInt32(row["idTipoDocumento"]);
                LstProveedores.Add(objProveedor);
            }
            return LstProveedores;
        }

        public clsDBResp CalificarProveedor(int idVinculoProveedor, int idUsuario, DateTime dFechaSis)
        {
            var dtResult = objEjeSp.EjecSP("LOG_CalificarProveedor_SP", idVinculoProveedor, idUsuario, dFechaSis);
            return new clsDBResp(dtResult);
        }

        public clsListaProveedores buscarProveedorXid(int idProveedor)
        {
            clsListaProveedores VinProv = new clsListaProveedores();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarProveedorXid_SP", idProveedor);
            int i = 0;
            foreach (DataRow item in ds.Rows)
            {
                VinProv.Add(new clsProveedores()
                {
                    cDocumentoID = ds.Rows[i]["cNroDocumento"].ToString(),
                    cNombre = ds.Rows[i]["cProveedor"].ToString(),
                    idProveedor = Convert.ToInt32(ds.Rows[i]["idProveedor"].ToString()),
                });
                i += 1;
            }
            return VinProv;
        }

        public clsListaProveedores buscaProveedores(string dniRuc, string nombreProvedor)
        {
            clsListaProveedores listProve = new clsListaProveedores();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarProveedor_SP", dniRuc, nombreProvedor);
            int i = 0;
            foreach (DataRow item in ds.Rows)
            {
                listProve.Add(new clsProveedores()
                {
                    cDocumentoID = item["cDocumentoID"].ToString(),
                    cNombre = item["cNombre"].ToString(),
                    cNombreComercial = item["cNombreComercial"].ToString(),
                    //cRubro = item["cRubro"].ToString(),
                    idProveedor = Convert.ToInt32(item["idProveedor"].ToString()),
                }
                );
                i += 1;
            }
            return listProve;
        }

        public clslistaVinculoProveedor buscarVinculoProveedor(int idProcesoAdj, int idGrupo)
        {
            clslistaVinculoProveedor VinProv = new clslistaVinculoProveedor();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarVinculoProveedor_SP", idProcesoAdj, idGrupo);
            foreach (DataRow item in ds.Rows)
            {
                clsVinculoProveedor objVinculoProveedor = new clsVinculoProveedor();
                objVinculoProveedor.cNroDocumento = item["cNroDocumento"].ToString();
                objVinculoProveedor.cProveedor = item["cProveedor"].ToString();
                objVinculoProveedor.dFechaReg = Convert.ToDateTime(item["dFechaReg"].ToString());
                objVinculoProveedor.idProcesoAdj = (item["idProcesoAdj"] == DBNull.Value) ? null : (int?)Convert.ToInt32(item["idProcesoAdj"]);
                objVinculoProveedor.idProveedor = Convert.ToInt32(item["idProveedor"].ToString());
                objVinculoProveedor.nGrupo = Convert.ToInt32(item["nGrupo"].ToString());
                objVinculoProveedor.idUsuReg = Convert.ToInt32(item["idUsuReg"].ToString());
                objVinculoProveedor.idVinculoProveedor = Convert.ToInt32(item["idVinculoProveedor"].ToString());
                objVinculoProveedor.lvigente = Convert.ToBoolean(item["lvigente"].ToString());
                objVinculoProveedor.idEstadoEvaProveedor = Convert.ToInt32(item["idEstadoEvaProveedor"].ToString());
                objVinculoProveedor.nValRef = (item["nValRef"] == DBNull.Value) ? null : (decimal?)Convert.ToDecimal(item["nValRef"].ToString());
                objVinculoProveedor.cEstadoEvaProveedor = item["cEstadoEvaProveedor"].ToString();
                objVinculoProveedor.lContinuar = Convert.ToBoolean(item["lContinuar"].ToString());
                objVinculoProveedor.nPuntFacEco = (item["nPuntFacEco"] == DBNull.Value) ? 0 : (decimal?)Convert.ToDecimal(item["nPuntFacEco"].ToString());
                objVinculoProveedor.nPuntFacTec = (item["nPuntFacTec"] == DBNull.Value) ? 0 : (decimal?)Convert.ToDecimal(item["nPuntFacTec"].ToString());
                objVinculoProveedor.nPuntaje = (item["nPuntaje"] == DBNull.Value) ? 0 : (decimal?)Convert.ToDecimal(item["nPuntaje"].ToString());
                objVinculoProveedor.lGanadorTemp = (item["lGanadorTemp"] ==DBNull.Value) ? false : (bool?)Convert.ToBoolean(item["lGanadorTemp"].ToString());
                objVinculoProveedor.nCalificacion = (item["nCalificacion"] == DBNull.Value) ? 0 : Convert.ToInt32(item["nCalificacion"].ToString());

                VinProv.Add(objVinculoProveedor);
            }
            return VinProv;
        }
        public DataTable ADActualizarGanador(int idProcesoAdj, int idGrupo, int idProveedorGanador, int idEstado)
        {
            return objEjeSp.EjecSP("LOG_ActualizarGanadorProceso_SP", idProcesoAdj, idGrupo, idProveedorGanador, idEstado, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }

        public List<clsVinculoProveedor> ListaVinculoProveedor(int idProceso)
        {
            var lstVincProv = new List<clsVinculoProveedor>();
            var dtResult = objEjeSp.EjecSP("LOG_ListaProveedoresProcesoAdj_Sp", idProceso);
            foreach (DataRow item in dtResult.Rows)
            {
                clsVinculoProveedor objVinculoProveedor = new clsVinculoProveedor();

                objVinculoProveedor.idVinculoProveedor = Convert.ToInt32(item["idVinculoProveedor"]);
                objVinculoProveedor.cNroDocumento = item["cDocumentoID"].ToString();
                objVinculoProveedor.cProveedor = item["cNombre"].ToString();
                objVinculoProveedor.idProcesoAdj = item["idProceso"] == DBNull.Value ? null : (int?)Convert.ToInt32(item["idProceso"]);
                objVinculoProveedor.idProveedor = Convert.ToInt32(item["idProveedor"]);
                objVinculoProveedor.nGrupo = Convert.ToInt32(item["nGrupo"]);
                objVinculoProveedor.lvigente = Convert.ToBoolean(item["lvigente"]);
                objVinculoProveedor.idEstadoEvaProveedor = Convert.ToInt32(item["idEstadoEvaProveedor"]);
                objVinculoProveedor.nValRef = item["nValRef"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(item["nValRef"]);
                objVinculoProveedor.lContinuar = Convert.ToBoolean(item["lContinuar"].ToString());
                objVinculoProveedor.nPuntFacEco = item["nValPuntajeEco"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nValPuntajeEco"]);
                objVinculoProveedor.nPuntFacTec = item["nValPuntajeFac"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nValPuntajeFac"]);
                objVinculoProveedor.nPuntaje = item["nPuntajeTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nPuntajeTotal"]);
                objVinculoProveedor.lGanadorTemp = item["lGanadorTemp"] == DBNull.Value ? false : Convert.ToBoolean(item["lGanadorTemp"]);
                objVinculoProveedor.nCalificacion = item["nCalificacion"] == DBNull.Value ? 0 : Convert.ToInt32(item["nCalificacion"]);

                lstVincProv.Add(objVinculoProveedor);
            }
            return lstVincProv;
        }

        public clsVinculoProveedor ObtieneVinculoProveedor(int idVinculoProveedor)
        {
            var lstVincProv = new List<clsVinculoProveedor>();
            var dtResult = objEjeSp.EjecSP("LOG_ObtieneProveedoresProcesoAdj_Sp", idVinculoProveedor);
            foreach (DataRow item in dtResult.Rows)
            {
                clsVinculoProveedor objVinculoProveedor = new clsVinculoProveedor();

                objVinculoProveedor.idVinculoProveedor = Convert.ToInt32(item["idVinculoProveedor"]);
                objVinculoProveedor.cNroDocumento = item["cDocumentoID"].ToString();
                objVinculoProveedor.cProveedor = item["cNombre"].ToString();
                objVinculoProveedor.idProcesoAdj = item["idProceso"] == DBNull.Value ? null : (int?)Convert.ToInt32(item["idProceso"]);
                objVinculoProveedor.idProveedor = Convert.ToInt32(item["idProveedor"]);
                objVinculoProveedor.nGrupo = Convert.ToInt32(item["nGrupo"]);
                objVinculoProveedor.lvigente = Convert.ToBoolean(item["lvigente"]);
                objVinculoProveedor.idEstadoEvaProveedor = Convert.ToInt32(item["idEstadoEvaProveedor"]);
                objVinculoProveedor.nValRef = item["nValRef"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(item["nValRef"]);
                objVinculoProveedor.lContinuar = Convert.ToBoolean(item["lContinuar"].ToString());
                objVinculoProveedor.nPuntFacEco = item["nValPuntajeEco"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nValPuntajeEco"]);
                objVinculoProveedor.nPuntFacTec = item["nValPuntajeFac"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nValPuntajeFac"]);
                objVinculoProveedor.nPuntaje = item["nPuntajeTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(item["nPuntajeTotal"]);
                objVinculoProveedor.lGanadorTemp = item["lGanadorTemp"] == DBNull.Value ? false : Convert.ToBoolean(item["lGanadorTemp"]);
                objVinculoProveedor.nCalificacion = item["nCalificacion"] == DBNull.Value ? 0 : Convert.ToInt32(item["nCalificacion"]);

                lstVincProv.Add(objVinculoProveedor);
            }
            return lstVincProv.First();
        }

    }
}

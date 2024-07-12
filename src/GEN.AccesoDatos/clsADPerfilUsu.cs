using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.Funciones;

namespace GEN.AccesoDatos
{
    public class clsADPerfilUsu
    {
        #region Variables

        clsGENEjeSP objEjecSP = new clsGENEjeSP();

        #endregion

        public List<clsPerfilUsu> ListarPerUsu(int idUsuario)
        {
            List<clsPerfilUsu> lisPerUsu = new List<clsPerfilUsu>();
            try
            {
                var query = objEjecSP.EjecSP("GEN_LisPerUsu_sp", idUsuario,DateTime.Now, 0);
                foreach (DataRow dr in query.Rows)
                {
                    lisPerUsu.Add(new clsPerfilUsu()
                    {
                        idPerfilUsu = (int)dr["idPerfilUsu"],
                        idUsuario = (int)dr["idUsuario"],
                        idPerfil = (int)dr["idPerfil"],
                        cPerfil = (string)dr["cPerfil"],
                        lVigente = (bool)dr["lVigente"],         
                        lResVentanilla = (bool)dr["lResVentanilla"],
                        cEmailInst = (string)dr["cEmailInst"],
                    });
                }
                return lisPerUsu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<clsPerfil> ListarPerfil()
        {
            List<clsPerfil> lisPerUsu = new List<clsPerfil>();
            try
            {
                var query = objEjecSP.EjecSP("GEN_LisPerfil_sp");
                foreach (DataRow dr in query.Rows)
                {
                    lisPerUsu.Add(new clsPerfil()
                    {
                        idPerfil = (int)dr["idPerfil"],
                        cPerfil = (string)dr["cPerfil"],
                        lVigente = (bool)dr["lVigente"],
                    });
                }
                return lisPerUsu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsPerfil> listarPerfil(int idUsuario, string cIdsPerfiles)
        {
            return this.objEjecSP.LOEjecutar<clsPerfil>("GEN_ListarPerfil_SP", idUsuario, cIdsPerfiles);
        }

        public List<clsLimCobertura> ListLimCober(int idPerfil,int idAgencia)
        {
            List<clsLimCobertura> listLimCob=new List<clsLimCobertura>();
            try
            {
                var query = objEjecSP.EjecSP("Gen_LimCoverturaXPerfil_sp", idPerfil, idAgencia);
                foreach (DataRow dr in query.Rows)
                {
                    listLimCob.Add(new clsLimCobertura(){
                        nMonMinCobertura = (decimal)dr["nlimMenor"],
                        nMonIntCobertura = (decimal)dr["nlimMedio"],
                        nMonMaxCobertura = (decimal)dr["nlimMayor"],
                        idControlTipMon = (int)dr["idControLimTipMon"],
                        nMonMinCoberturaDol = (decimal)dr["nlimMenorDol"],
                        nMonIntCoberturaDol = (decimal)dr["nlimMedioDol"],
                        nMonMaxCoberturaDol = (decimal)dr["nlimMayorDol"]
                    });
                }
                return listLimCob ;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ReportePerfilesPorUsuario(int idUsuario, DateTime dFecLimIni, DateTime dFecLimFin, int nVigente)
        {
            return objEjecSP.EjecSP("RPT_ReportePerfilesPorUsuario_SP", idUsuario, dFecLimIni, dFecLimFin, nVigente);
        }

        public DataTable ReporteMenuPorPerfil(int idPerfil)
        {
            return objEjecSP.EjecSP("RPT_ReporteMenuPorPerfil_SP", idPerfil);
        }

        public DataTable RetRespVentanilla(int idUsuario, DateTime dFecSis, int idAgencia)
        {
            return objEjecSP.EjecSP("CAJ_RetRespVentanilla_Sp", idUsuario, dFecSis, idAgencia);
        }

        public List<clsPerfil> ListarPerfilRecuperadores()
        {
            List<clsPerfil> lisPerUsu = new List<clsPerfil>();
            try
            {
                var query = objEjecSP.EjecSP("GEN_LisPerfilRecuperadores_sp");
                foreach (DataRow dr in query.Rows)
                {
                    lisPerUsu.Add(new clsPerfil()
                    {
                        idPerfil = (int)dr["idPerfil"],
                        cPerfil = (string)dr["cPerfil"],
                        lVigente = (bool)dr["lVigente"],
                    });
                }
                return lisPerUsu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsPerfil> buscarPerfil(string cValorBusqueda)
        {
            DataTable dtPerfil = this.objEjecSP.EjecSP("GEN_BuscarPerfil_SP", cValorBusqueda);
            return (dtPerfil.Rows.Count > 0) ? dtPerfil.ToList<clsPerfil>() as List<clsPerfil> :
                new List<clsPerfil>();
        }
        public DataTable ADListarPerfilOrdenadoAsc()
        {
            return objEjecSP.EjecSP("GEN_LisPerfilOrdenadoAsc_SP");
        }
    }
}

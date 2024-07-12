using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantCargos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarCargos()
        {
            return objEjeSp.EjecSP("GRH_ListarCargos_SP");
        }
        public DataTable ActualizarCargos(int idCargo, string NombCargo, int idArea, int idNivelPersonal,int idTipoCargo, int nPorcentaje, int lVigente, string cGrupoCorreo)
        
        {
            return objEjeSp.EjecSP("GRH_ActualizarCargos_SP", idCargo, NombCargo, idArea, idNivelPersonal, idTipoCargo, nPorcentaje, lVigente, cGrupoCorreo);
        }
        public DataTable GuardarCargos(string NombCargo, int idArea, int idNivelPersonal, int idTipoCargo, int nPorcentaje, int lVigente, string cGrupoCorreoB)
        {
            return objEjeSp.EjecSP("GRH_GuardarCargos_SP", NombCargo, idArea, idNivelPersonal, idTipoCargo, nPorcentaje, lVigente, cGrupoCorreoB);
        }
        public DataTable ListarTipoCargo()
        {
            return objEjeSp.EjecSP("GRH_ListarTipoCargo_sp");
        }

        #region Mantenimiento de Categorías por personal

        public DataTable ADInsertarCategoriaPersonal(string cCategoria, int idCargoPersonal, bool lVigente)
        {
            return objEjeSp.EjecSP("GRH_InsertarCategoriaPersonal_SP",cCategoria, idCargoPersonal,  lVigente);
        }

        public DataTable ADActualizarCategoriaPersonal(int idCategoria, string cCategoria, int idCargoPersonal, bool lVigente)
        {
            return objEjeSp.EjecSP("GRH_ActualizarCategoriaPersonal_SP", idCategoria,cCategoria, idCargoPersonal, lVigente);
        }

        public DataTable ADEliminarCategoriaPersonal(int idCategoria)
        {
            return objEjeSp.EjecSP("GRH_EliminarCategoriaPersonal_SP", idCategoria);
        }

        public DataTable ADListarCategoriaPersonalidCargo(int idCargoPersonal)
        {
            return objEjeSp.EjecSP("GRH_ListarCategoriaPersonalidCargo_SP", idCargoPersonal);
        }

        #endregion

    }
}

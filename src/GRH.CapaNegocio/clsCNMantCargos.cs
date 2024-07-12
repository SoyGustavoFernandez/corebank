using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantCargos
    {
        clsADMantCargos cncargo = new clsADMantCargos();

        public DataTable ListarCargos()
        {
            return cncargo.ListarCargos();
        }
        public DataTable ActualizarCargos(int idCargo,string NombCargo,int idArea,int idNivelPersonal,int idTipoCargo, int nPorcentaje,int lVigente, string cGrupoCorreoB)
        {
            return cncargo.ActualizarCargos(idCargo, NombCargo, idArea, idNivelPersonal, idTipoCargo, nPorcentaje, lVigente, cGrupoCorreoB);
        }
        public int GuardarCargos(string NombCargo, int idArea, int idNivelPersonal, int idTipoCargo, int nPorcentaje, int lVigente, string cGrupoCorreoB)
        {
            DataTable dtResul= cncargo.GuardarCargos(NombCargo, idArea, idNivelPersonal,idTipoCargo, nPorcentaje, lVigente, cGrupoCorreoB);
            int idCargo=Convert.ToInt32(dtResul.Rows[0][0]);
            return idCargo;
        }
        public DataTable ListarTipoCargo()
        {
            return cncargo.ListarTipoCargo();
        }

        #region Mantenimiento de Categorías por personal

        public DataTable CNInsertarCategoriaPersonal(string cCategoria, int idCargoPersonal, bool lVigente)
        {
            return cncargo.ADInsertarCategoriaPersonal(cCategoria, idCargoPersonal, lVigente);
        }

        public DataTable CNActualizarCategoriaPersonal(int idCategoria, string cCategoria, int idCargoPersonal, bool lVigente)
        {
            return cncargo.ADActualizarCategoriaPersonal( idCategoria, cCategoria, idCargoPersonal, lVigente);
        }

        public DataTable CNEliminarCategoriaPersonal(int idCategoria)
        {
            return cncargo.ADEliminarCategoriaPersonal( idCategoria);
        }

        public DataTable CNListarCategoriaPersonalidCargo(int idCargoPersonal)
        {
            return cncargo.ADListarCategoriaPersonalidCargo(idCargoPersonal);
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNGrupoEconomico
    {
        clsADGrupoEconomico objgrueco = new clsADGrupoEconomico();
        public clslisTipoGrupoEconomico listartipoGrupoEco()
        {
            return objgrueco.listartipoGrupoEco();
        }

        public clslisGrupoEconomico listarGrupoEco()
        {
            return objgrueco.listarGrupoEco();
        }

        public void insertarGrupoEco(clsGrupoEconomico grupo, clsLisCliente participantes)
        {
            objgrueco.insertarGrupoEco(grupo, participantes);
        }

        public DataTable listarparticipantes(int idGrupoEconomico)
        {
            return objgrueco.listarparticipantes(idGrupoEconomico);
        }

        public void actualizarGrupoEco(int idGrupoEconomico, string cGrupoEconomico, bool lVigente, clsLisCliente participantes)
        {
            objgrueco.actualizarGrupoEco(idGrupoEconomico, cGrupoEconomico, lVigente, participantes);
        }

        public DataTable CNListaGrupoEc(int idTipoGrupoEco)
        {
            return objgrueco.ADListaGrupoEc(idTipoGrupoEco);
        }
    }
}

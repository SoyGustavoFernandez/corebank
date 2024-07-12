using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;

namespace LOG.CapaNegocio
{
    public class clsCNProveedor
    {
        clsADProveedor objProveedor = new clsADProveedor();

        public DataTable CNMostrarDatosProveedorIdCli(int idCli)
        {
            return objProveedor.ADMostrarDatosProveedorIdCli(idCli);
        }

        public DataTable CNInsertarProveedor(int idCli, string cCtaDetraccion, int idUsuarioReg, DateTime dFechaReg, string cCuentaCorriente)
        {
            return objProveedor.ADInsertarProveedor(idCli, cCtaDetraccion, idUsuarioReg, dFechaReg, cCuentaCorriente);
        }

        public DataTable CNActualizarProveedor(int idProveedor, string cCtaDetraccion, int idUsuarioMod, DateTime dFechaMod, string cCuentaCorriente)
        {
            return objProveedor.ADActualizarProveedor(idProveedor, cCtaDetraccion, idUsuarioMod, dFechaMod, cCuentaCorriente);
        }

        public DataTable CNEliminarProveedor(int idProveedor, int idUsuarioMod, DateTime dFechaMod)
        {
            return objProveedor.ADEliminarProveedor(idProveedor, idUsuarioMod, dFechaMod);
        }

        public List<clsProveedores> CNBusProveedor(string cCriterio, string cDatoCriterio)
        {
            return objProveedor.ADBusProveedor(cCriterio, cDatoCriterio);
        }

        public clsListaProveedores buscaProveedores(string dniRuc, string nombreProvedor)
        {
            return objProveedor.buscaProveedores(dniRuc, nombreProvedor);
        }

        public clsListaProveedores CNBuscarProveedorXid(int idProveedor)
        {
            return objProveedor.buscarProveedorXid(idProveedor);
        }

        public clslistaVinculoProveedor buscarVinculoProveedor(int idProcesoAdj, int idGrupo)
        {
            return objProveedor.buscarVinculoProveedor(idProcesoAdj, idGrupo);
        }

        public DataTable CNActualizarGanador(int idProcesoAdj, int idGrupo, int idProveedorGanador, int idEstado)
        {
            return objProveedor.ADActualizarGanador(idProcesoAdj, idGrupo, idProveedorGanador, idEstado);
        }

        public List<clsVinculoProveedor> ListaVinculoProveedor(int idProceso)
        {
            return objProveedor.ListaVinculoProveedor(idProceso);
        }

        public clsVinculoProveedor ObtieneVinculoProveedor(int idVinculoProveedor)
        {
            return objProveedor.ObtieneVinculoProveedor(idVinculoProveedor);
        }

        public clsDBResp CalificarProveedor(int idVinculoProveedor, int idUsuario, DateTime dFechaSis)
        {
            return objProveedor.CalificarProveedor(idVinculoProveedor, idUsuario, dFechaSis);
        }
    }
}

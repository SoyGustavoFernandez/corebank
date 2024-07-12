using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNBuscaPersonal
    {
        clsADBuscarPersonal objBuscaPersonal = new clsADBuscarPersonal();
        public DataTable BuscaCliente(Int32 nIdCliente)
        {
            return objBuscaPersonal.BuscaPersonal(nIdCliente);
        }
        public DataTable DatosHistorial(Int32 nIdCliente)
        {
            return objBuscaPersonal.DatosHistorial(nIdCliente);
        }
        public DataTable DatosFamiliares(Int32 nIdCliente)
        {
            return objBuscaPersonal.DatosFamiliares(nIdCliente);
        }
        public DataTable BusPerByDNIName(string cCriterio, string cDato, int idEstado)
        {
            return objBuscaPersonal.BusPerByDNIName(cCriterio, cDato, idEstado);
        }
        public DataTable ListarUsuariosAprob(string cCriBus, string cDniNom)
        {
            return objBuscaPersonal.BuscarUsuarioAprobador(cCriBus, cDniNom);
        }
        public DataTable BusPerByCod(int idUsuario, int idEstado, bool lMinDat = false)
        {
            return objBuscaPersonal.BusPerByCod(idUsuario, idEstado, lMinDat);
        }
        public DataTable ListarTipoVinculo()
        {
            return objBuscaPersonal.ListarTipoVinculo();
        }
        public DataTable ListarDocAcrediteVinc(int idVinculo)
        {
            return objBuscaPersonal.ListarDocAcrediteVinc(idVinculo);
        }
        public DataTable ListarTipoContrato()
        {
            return objBuscaPersonal.ListarTipoContrato();
        }
        public DataTable ListarSeguroSalud()
        {
            return objBuscaPersonal.ListarSeguroSalud();
        }
        public DataTable ListarMotivosBAJAS()
        {
            return objBuscaPersonal.ListarMotivosBAJAS();
        }
        public DataTable ListarMotivosCese()
        {
            return objBuscaPersonal.ListarMotivosCese();
        }
        public DataTable ListarEstadoContrato()
        {
            return objBuscaPersonal.ListarEstadoContrato();
        }
        /*= LISTA ESTADO CONTRATO, CON OPCION A VER O NO TODOS =================================================================*/
        public DataTable ListarEstadoContratoTodos(int incluyeTodos)
        {
            return objBuscaPersonal.ListarEstadoContratoTodos(incluyeTodos);
        }
        public DataTable ListarContratos(int idRelacionLab)
        {
            return objBuscaPersonal.ListarContratos(idRelacionLab);
        }
        public DataTable ListarContratosRegistrados(DateTime dFechaIni, DateTime dFechaFin, int idEstContrato)
        {
            return objBuscaPersonal.ListarContratosRegistrados(dFechaIni, dFechaFin, idEstContrato);
        }
        public DataTable ListarVencimientoContratos(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objBuscaPersonal.ListarVencimientoContratos(dFechaIni, dFechaFin);
        }
        public DataTable ListarCertificados(int idUsuario, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objBuscaPersonal.ListarCertificados(idUsuario, dFechaIni, dFechaFin);
        }
    }
}

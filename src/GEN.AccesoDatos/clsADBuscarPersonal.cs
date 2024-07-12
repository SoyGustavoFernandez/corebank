using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADBuscarPersonal
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable BuscaPersonal(Int32 nIdCliente)
        {
            return objEjeSp.EjecSP("Gen_BuscaPersonal_sp", nIdCliente);
        }

        public DataTable DatosHistorial(Int32 nIdCliente)
        {
            return objEjeSp.EjecSP("GRH_HistorialPersonal_sp", nIdCliente);
        }

        public DataTable DatosFamiliares(Int32 nIdCliente)
        {
            return objEjeSp.EjecSP("GRH_FamiliaresUsuario_sp", nIdCliente);
        }

        public DataTable BuscarUsuarioAprobador(string cCriBus, string cDatosCli)
        {
            return objEjeSp.EjecSP("Gen_BuscarCliAprobador_sp", cCriBus,cDatosCli);
        }

        public DataTable BusPerByDNIName(string cCriterio, string cDato, int idEstado)
        {
            return objEjeSp.EjecSP("Gen_BusPerByDNIName_sp", cCriterio, cDato, idEstado);
        }

        public DataTable BusPerByCod(int idUsuario, int idEstado, bool lMinDat = false)
        {
            return objEjeSp.EjecSP("Gen_BusPerByCod_sp", idUsuario, idEstado, lMinDat);
        }

        public DataTable ListarTipoVinculo()
        {
            return objEjeSp.EjecSP("GRH_ListarVinculoHabientes_sp");
        }

        public DataTable ListarDocAcrediteVinc(int idVinculo)
        {
            return objEjeSp.EjecSP("GRH_ListarDocAcrediteVinculo_sp", idVinculo);
        }

        public DataTable ListarTipoContrato()
        {
            return objEjeSp.EjecSP("GRH_listarTipoContratoPer_sp");
        }
        public DataTable ListarSeguroSalud()
        {
            return objEjeSp.EjecSP("GRH_listarSeguroSalud_sp");
        }
        public DataTable ListarMotivosBAJAS()
        {
            return objEjeSp.EjecSP("GRH_listarMotivosBAJA_sp");
        }
        public DataTable ListarMotivosCese()
        {
            return objEjeSp.EjecSP("GRH_listarMotivosCese_sp");
        }
        public DataTable ListarEstadoContrato()
        {
            return objEjeSp.EjecSP("GRH_listarEstadoContratoPer_sp");
        }
        /*= LISTA ESTADO CONTRATO, CON OPCION A VER O NO TODOS =================================================================*/
        public DataTable ListarEstadoContratoTodos(int incluyeTodos)
        {
            return objEjeSp.EjecSP("GEN_listaEstadoContratoPerTodos_SP", incluyeTodos);
        }
        public DataTable ListarContratos(int idRelacionLab)
        {
            return objEjeSp.EjecSP("GRH_listarContratos_sp", idRelacionLab);
        }
        public DataTable ListarContratosRegistrados(DateTime dFechaIni, DateTime dFechaFin, int idEstContrato)
        {
            return objEjeSp.EjecSP("GRH_listarContratosRegistrados_sp", dFechaIni, dFechaFin, idEstContrato);
        }
        public DataTable ListarVencimientoContratos(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("GRH_listarVencimientoContratos_sp", dFechaIni, dFechaFin);
        }
        public DataTable ListarCertificados(int idUsuario, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("GRH_listarCertificados_sp", idUsuario, dFechaIni, dFechaFin);
        }
    }
}

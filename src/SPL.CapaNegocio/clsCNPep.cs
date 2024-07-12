using EntityLayer;
using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SPL.CapaNegocio
{
    public class clsCNPep
    {
        clsADPep adpep = new clsADPep();

        public void GuardarPep(clsPep pep, int idEstadoRegistro, int idUsuario, int idAgeCol)
        {
            adpep.guardarPep(pep, idEstadoRegistro, idUsuario, idAgeCol);
        }

        public clsPep BuscarPersonaPep(int idTipoDoc, string nNumDoc,int idCli)
        {
            return adpep.BuscarPersonaPep(idTipoDoc, nNumDoc, idCli);
        }

        public DataTable ActualizarPep(clsPep pep, string XmlNuevosFamiliares, string XmlFamiliaresEliminados, int idEstadoRegistro, int idUsuario, int idAgeCol)
        {
            return adpep.actualizarPep(pep, XmlNuevosFamiliares, XmlFamiliaresEliminados, idEstadoRegistro, idUsuario, idAgeCol);
        }
        public DataTable buscarDatosClientes(int nNroDoc)
        {
            return adpep.buscarDaTosCliente(nNroDoc);
        }

        public DataTable EliminarPesonaListaPEP(int idPep)
        {
            return adpep.EliminarPesonaListaPEP(idPep);
        }

        public DataTable DatosPepCliente(int idCli)
        {
            return adpep.DatosPepCliente(idCli);
        }

        //--=====================================================================
        //-----Lista Solicitudes Pendientes por Aprobar (PEP)
        //--=====================================================================
        public DataTable CNListarPepPorAprobar()
        {
            return adpep.ADListarPepPorAprobar();
        }

        //--=====================================================================
        //------Registra Aprobacion (PEP)
        //--=====================================================================
        public DataTable CNActualizarAprPep(int idPep, bool lIsApr, string cSustento, int idUsuario, int idAgencia, DateTime dFecRegistro)
        {
            return adpep.ADActualizarAprPep(idPep, lIsApr, cSustento, idUsuario, idAgencia, dFecRegistro);
        }
        public DataTable CNCargarClientesPEP(string cXml, DateTime dFechaReg)
        {
            return adpep.ADCargarClientesPEP(cXml, dFechaReg);
        }
        public DataTable CNImprimirFichaPEP(int idPep, DateTime dFechaSis)
        {
            return adpep.ADImprimirFichaPEP(idPep, dFechaSis);
        }

        public DataTable CNObtenerPepNroDocumento(string cDocumento)
        {
            return adpep.ADObtenerPepNroDocumento(cDocumento);
        }
    }
}

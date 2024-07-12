using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNSiniestros
    {
        clsADSiniestros objADSiniestros = new clsADSiniestros();

        public DataTable ValidaPermisosEnForm(int idPerfil)
        {
            return objADSiniestros.ValidaPermisosEnForm(idPerfil);
        }

        public DataTable InsUpdSiniestros(clsSiniestros objSiniestros)
        {
            return objADSiniestros.InsUpdSiniestros(objSiniestros);
        }

        public DataTable CargarEstadosSiniestro()
        {
            return objADSiniestros.CargarEstadosSiniestro();
        }

        public DataTable ListarSiniestrosPorCliente(int idCli)
        {
            return objADSiniestros.ListarSiniestrosPorCliente(idCli);
        }

        public DataTable CargarDatosSeguroIndividual(int idSeguro, int idCli)
        {
            return objADSiniestros.CargarDatosSeguroIndividual(idSeguro, idCli);
        }

        public DataTable CargarDetalleSiniestro(int idSiniestro)
        {
            return objADSiniestros.CargarDetalleSiniestro(idSiniestro);
        }

        public DataTable RPTSiniestros_SP(int idCli)
        {
            return objADSiniestros.RPTSiniestros_SP(idCli);
        }
    }
}
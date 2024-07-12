using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADSiniestros
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ValidaPermisosEnForm(int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ValidaPermisosEnForm_SP", idPerfil);
        }

        public DataTable InsUpdSiniestros(clsSiniestros objSiniestros)
        {
            return objEjeSp.EjecSP("CRE_InsUpdSiniestros_SP", objSiniestros.nIdSeguroSiniestro, objSiniestros.nTipoSeguro, objSiniestros.idSeguro, objSiniestros.idAgencia, objSiniestros.idCli, objSiniestros.idRecibo, objSiniestros.idCuenta, objSiniestros.saldoCapital, objSiniestros.dFecIniCobertura, objSiniestros.dFecFinCobertura, objSiniestros.idEstadoSiniestro, objSiniestros.dFechaSiniestro, objSiniestros.idUsuReg, objSiniestros.idUsuMod, objSiniestros.dFecReg, objSiniestros.dFecMod, objSiniestros.lVigente);
        }

        public DataTable CargarEstadosSiniestro()
        {
            return objEjeSp.EjecSP("CRE_ListaEstadoSiniestro_SP");
        }

        public DataTable ListarSiniestrosPorCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ListarSiniestrosPorCliente_SP", idCli);
        }

        public DataTable CargarDatosSeguroIndividual(int idSeguro, int idCli)
        {
            return objEjeSp.EjecSP("CRE_CargarDatosSeguroIndividual_SP", idSeguro, idCli);
        }

        public DataTable CargarDetalleSiniestro(int idSiniestro)
        {
            return objEjeSp.EjecSP("CRE_CargarDetalleSiniestro_SP", idSiniestro);
        }

        public DataTable RPTSiniestros_SP(int idCli)
        {
            return objEjeSp.EjecSP("CRE_RPTSiniestros_SP", idCli);
        }
    }
}
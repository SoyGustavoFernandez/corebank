using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;
using CAJ.AccesoDatos;
using EntityLayer;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper.Interface;


namespace GEN.CapaNegocio
{
    public class clsCNReciboProvicional
    {
        public clsADRecibosProvicional objRecProv = new clsADRecibosProvicional();

        public DataTable listar(int nIdUsu, int nEstado, int idHojaRuta = 0)
        {
            return objRecProv.listar(nIdUsu, nEstado, idHojaRuta);
        }

        public DataTable buscar(int nIdReciboProvisional, int lSms = 0)
        {
            return objRecProv.buscar(nIdReciboProvisional, lSms);
        }

        public DataTable registrar(
                int idCuenta,
                int idCli,
                int idUsuReg,
                int idReciboProvisional,
                int idHojaRuta,
                int idMoneda,
                int idTipoPersona, 
                string cDocumentoID,
                string cNombres,
                string cNumeroCelular,
                decimal nMonto,
                int idTipoVinculo,
                int nEstado,
                string cCodigoConfirmacion,
                string cSustento)
        {
            return objRecProv.registrar(
                    idCuenta,
                    idCli,
                    idUsuReg,
                    idReciboProvisional,
                    idHojaRuta,
                    idMoneda,
                    idTipoPersona,
                    cDocumentoID,
                    cNombres,
                    cNumeroCelular,
                    nMonto,
                    idTipoVinculo,
                    nEstado,
                    cCodigoConfirmacion,
                    cSustento
            );
        }
    }
}

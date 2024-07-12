using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper.Interface;

namespace CAJ.AccesoDatos
{
    public class clsADRecibosProvicional
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listar(int nIdUsu, int nEstado, int idHojaRuta = 0)
        {
            return objEjeSp.EjecSP("CAJ_listarReciboProvisional", nIdUsu, nEstado, idHojaRuta); 
        }

        public DataTable buscar(int nIdReciboProvisional, int lSms = 0)
        {
            return objEjeSp.EjecSP("CAJ_BuscarReciboProvisional", nIdReciboProvisional, lSms); 
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
            return objEjeSp.EjecSP("CAJ_RegistroReciboProvisional",
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
                    cSustento);
        }
    }
}

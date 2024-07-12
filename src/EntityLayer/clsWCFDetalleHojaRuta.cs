using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFDetalleHojaRuta
    {
        public string cNombreGestion { get; set; }
        public string cTipoIntervencion { get; set; }
        public string cTipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public int cCodigoCliente { get; set; }
        public string cUbigeo { get; set; }
        public string cDireccion { get; set; }
        public int idSexo { get; set; }
        public int idCuenta { get; set; }
        public string cNombreTitular { get; set; }
        public string cSimbolo { get; set; }
        public string cMoneda { get; set; }
        public decimal nMontoDesembolsado { get; set; }
        public decimal nSaldoCapitalTotal { get; set; }
        public decimal nSaldoCapitalVencido { get; set; }
        public int nAtraso { get; set; }
        public string dFechaPago { get; set; }
        public int nCuotasAtrasadas { get; set; }
        public int nCuotasTotal { get; set; }
        public string cEstadoCredito { get; set; }
        public decimal nCuotaSaldoCapital { get; set; }
        public decimal nCuotaSaldoInteres { get; set; }
        public decimal nCuotaSaldoCompensatorio { get; set; }
        public decimal nCuotaSaldoMora { get; set; }
        public decimal nCuotaSaldoOtros { get; set; }
        public decimal nCuotaSaldoTotal { get; set; }
        public int idDetalleHojaRuta { get; set; }
        public int idResultadoUlt { get; set; }
        public string cAgencia { get; set; }
        public string cTelefono { get; set; }

        public string cAccion { get; set; }
        public string dFechaGestion { get; set; }
        public string cAccionAnterios { get; set; }
        public string cAccionResultado { get; set; }
        public string cObservacionUlt { get; set; }


        public int idResultado { get; set; }
        public int idMotivoMora { get; set; }
        public int idTipoCliente { get; set; }
        public bool lRecuperable { get; set; }
        public string cObservacion { get; set; }
        public string dFechaPromesa { get; set; }
        public decimal nMontoPromesa { get; set; }
        public string cObservacionPromesa { get; set; }
        public string cLatitud { get; set; }
        public string cLongitud { get; set; }
        public bool lDomVerificado { get; set; }
        public bool lNotificacionEntregada { get; set; }
        

    }
}

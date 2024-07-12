using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsProducto
    {
        public int IdProducto{get; set;}
        public string cCuentaContable{get; set;}
        public string cProducto{get; set;} 
        public int IdProductoPadre{get; set;}
        public bool lVigente{get; set;}
        public int idModulo	{get; set;}
        public string cCodSBS { get; set; }
        public string cProductoPadre { get; set; }
        public string cProductoDetalle { get; set; }
        public string cProductoAbuelo { get; set; }
        public string cProductoBisAbuelo { get; set; } 
    }

    public class clsSubProducto
    {
        public int IdProducto { get; set; }
        public string cProducto { get; set; }
        public int IdProductoPadre { get; set; }
        public bool lVigente { get; set; }
        public int idModulo { get; set; }
        public string cCodSBS { get; set; }
        public string cProductoPadre { get; set; }
        public string cProductoDetalle { get; set; }
        public string cProductoAbuelo { get; set; }
        public string cProductoBisAbuelo { get; set; }
    }

    public class clsCreditoCliente
    {
        public int idCuenta { get; set; }
        public int idIntervCre { get; set; }
        public int idPlanPagos { get; set; }
        public string cEstado { get; set; }
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public string cCodCliente { get; set; }
        public string cNombre { get; set; }
        public int idDireccion { get; set; }
        public string cDireccion { get; set; }
        public string dFechaDesembolso { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public int nCuotas { get; set; }
        public decimal nMontoCuota { get; set; }
        public bool lCoberSegDesg { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public decimal nSaldoCredito { get; set; }
        public decimal nSaldoCapital { get; set; }
        public decimal nSaldoInteres { get; set; }
        public decimal nSaldoInteresCompensatorio { get; set; }
        public decimal nSaldoMora { get; set; }
        public decimal nSaldoOtros { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public int nAtraso { get; set; }
    }

    public class clsVinculadoCredito
    {
        public int idIntervCre { get; set; }
        public string cTipoModif { get; set; }
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int idTipoInterv { get; set; }
        public string cTipoIntervencion { get; set; }
        public int idModulo { get; set; }
    }

    public class clsClienteVincular
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public string cDocumentoID { get; set; }
        public int idTipoDocumento { get; set; }
        public string cTipoDoc { get; set; }
    }

    public class clsProductoAgricolaCultivo
    {
        public int idCultivoEval { get; set; }
        public string cCultivoEval { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsProductoAgricolaCultivoVariedad
    {
        public int idVariedadCultivoEval { get; set; }
        public int idCultivoEval { get; set; }
        public string cVariedadCultivoEval { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsProductoAgricolaCultivoVariedadSeleccionado
    {
        public bool lAgricola { get; set; }
        public int idCultivoEval { get; set; }
        public int idVariedadCultivoEval { get; set; }
    }
}

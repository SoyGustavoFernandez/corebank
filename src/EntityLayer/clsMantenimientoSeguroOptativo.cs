using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsMantenimientoSeguroOptativo
    {
        public int idTipoSeguro                                         { set; get; }
        public string cTipoSeguro                                       { set; get; }
        public decimal nValor                                           { set; get; }
        public int idTipoValSegOptativo                                 { set; get; }
        public string cTipoValSegOptativo                               { set; get; }
        public int idConcepto                                           { set; get; }
        public string cConcepto                                         { set; get; }
        public int idTipoPagoSeguroOptativo                             { set; get; }
        public string cTipoPagoSeguroOptativo                           { set; get; }
        public bool lvigente                                            { set; get; }
        public int idConfigSeguroProducto                               { set; get; }
        public int idTipoCredito                                        { set; get; }
        public int idSubTipo                                            { set; get; }
        public int idProducto                                           { set; get; }
        public int idSubProducto                                        { set; get; }
        public bool lAutorizadoProducto                                 { set; get; }
        public int nEstado                                              { set; get; }
        public int nEstadoProducto                                      { set; get; }
        public int idPerfil                                             { set; get; }
        public bool lAutorizadoPerfil                                   { set; get; }
        public int nEstadoPerfil                                        { set; get; }
        public int idAgencia                                            { set; get; }
        public int idZona                                               { set; get; }
        public bool lAutorizadoAgencia                                  { set; get; }
        public int nEstadoAgencia                                       { set; get; }
        public bool lEsPaqueteSeguro                                    { set; get; }
        public List <clsMantenimientoPlanSeguroVida> listaValseguro    { set; get; }

        public clsMantenimientoSeguroOptativo()
        {
            idTipoSeguro             = 0;
            cTipoSeguro              = String.Empty;
            nValor                   = 0;
            idTipoValSegOptativo     = 0;
            cTipoValSegOptativo      = String.Empty;
            idConcepto               = 0;
            cConcepto                = String.Empty;
            idTipoPagoSeguroOptativo = 0;
            cTipoPagoSeguroOptativo  = String.Empty;
            lvigente                 = false;
            idConfigSeguroProducto   = 0; 
            idTipoCredito            = 0; 
            idSubTipo                = 0; 
            idProducto               = 0; 
            idSubProducto            = 0;
            lAutorizadoProducto      = false;
            nEstado                  = 0; 
            nEstadoProducto          = 0; 
            idPerfil                 = 0;
            lAutorizadoPerfil        = false;
            nEstadoPerfil            = 0; 
            idAgencia                = 0; 
            idZona                   = 0;
            lAutorizadoAgencia       = false;
            nEstadoAgencia           = 0;
            lEsPaqueteSeguro         = false;
        }
    }

    public class clsMantenimientoPlanSeguroVida
    {
        public decimal nPrecioMensual   { set; get; }
        public int nMeses               { set; get; }
        public string cDescripcion      { set; get; }
        public int idTipoPlan           { set; get; }
        public int idTipoSeguro         { set; get; }
        public int idConcepto           { set; get; }
        public int nMinMes { get; set; }
        public int nMaxMes { get; set; }
        public bool lFijo { get; set; }
        public bool lSolicitud { get; set; }
        public bool lRedondear { get; set; }
        public decimal nPrecioTotal { set; get; }
        public string cTipoSeguro { get; set; }

        public clsMantenimientoPlanSeguroVida()
        {
            nPrecioMensual  = 0;
            nMeses          = 0;
            cDescripcion    = String.Empty;
            idTipoPlan      = 0;
            idTipoSeguro    = 0;
            idConcepto      = 0;
            nMinMes         = 0;    
            nMaxMes         = 0;
            lFijo           = false;
            lSolicitud      = false;
            lRedondear      = false;
            nPrecioTotal  = 0;
            cTipoSeguro     = String.Empty;
        }
    }

    public class clsBooleanPlanSeguro
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
}
}
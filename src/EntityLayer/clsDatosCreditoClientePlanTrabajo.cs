using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDatosCreditoClientePlanTrabajo : clsDatosCreditoCliente
    {
        public int idPlanTrabajoRecuperacion { get; set; }
        public int idPlanTrabajoDetalleAccion { get; set; }
        public int idPlanTrabajoObjetivoGeneral { get; set; }
        public int idPlanTrabajoObjetivoEspecifico { get; set; }
        public DateTime dFechaAccion { get; set; }

        public clsDatosCreditoClientePlanTrabajo()
        {
            this.idCuenta                               = 0;
            this.idEstado                               = 0;
            this.cEstado                                = String.Empty;
            this.cNombre                                = String.Empty;
            this.idCliente                              = 0;
            this.dFechaDesembolso                       = clsVarGlobal.dFecSystem;
            this.nFrecuencia                            = 0;
            this.nMonto                                 = 0;
            this.nCuotas                                = 0;
            this.idMoneda                               = 0;
            this.idProducto                             = 0;
            this.cProducto                              = String.Empty;
            this.nMontoCuota                            = 0;
            this.nAtraso                                = 0;
            this.cDocumentoID                           = String.Empty;
            this.cDireccion                             = String.Empty;
            this.cCodCliente                            = String.Empty;
            this.cMoneda                                = String.Empty;
            this.idTipoDocumento                        = 0;
            this.lCoberturaSegDesg                      = false;
            this.lSeleccionado                          = false;

            this.idPlanTrabajoRecuperacion              = 0;
            this.idPlanTrabajoDetalleAccion             = 0;
            this.idPlanTrabajoObjetivoGeneral           = 0;
            this.idPlanTrabajoObjetivoEspecifico        = 0;
            this.dFechaAccion                           = clsVarGlobal.dFecSystem;

        }

        public clsDatosCreditoClientePlanTrabajo(clsDatosCreditoCliente _clsDatosCreditoCliente)
        {
            this.idCuenta                =  _clsDatosCreditoCliente.idCuenta          ;
            this.idEstado                =  _clsDatosCreditoCliente.idEstado          ;
            this.cEstado                 =  _clsDatosCreditoCliente.cEstado           ;
            this.cNombre                 =  _clsDatosCreditoCliente.cNombre           ;
            this.idCliente               =  _clsDatosCreditoCliente.idCliente         ;
            this.dFechaDesembolso        =  _clsDatosCreditoCliente.dFechaDesembolso  ;
            this.nFrecuencia             =  _clsDatosCreditoCliente.nFrecuencia       ;
            this.nMonto                  =  _clsDatosCreditoCliente.nMonto            ;
            this.nCuotas                 =  _clsDatosCreditoCliente.nCuotas           ;
            this.idMoneda                =  _clsDatosCreditoCliente.idMoneda          ;
            this.idProducto              =  _clsDatosCreditoCliente.idProducto        ;
            this.cProducto               =  _clsDatosCreditoCliente.cProducto         ;
            this.nMontoCuota             =  _clsDatosCreditoCliente.nMontoCuota       ;
            this.nAtraso                 =  _clsDatosCreditoCliente.nAtraso           ;
            this.cDocumentoID            =  _clsDatosCreditoCliente.cDocumentoID      ;
            this.cDireccion              =  _clsDatosCreditoCliente.cDireccion        ;
            this.cCodCliente             =  _clsDatosCreditoCliente.cCodCliente       ;
            this.cMoneda                 =  _clsDatosCreditoCliente.cMoneda           ;
            this.idTipoDocumento         =  _clsDatosCreditoCliente.idTipoDocumento   ;
            this.lCoberturaSegDesg       =  _clsDatosCreditoCliente.lCoberturaSegDesg ;
            this.lSeleccionado           =  _clsDatosCreditoCliente.lSeleccionado     ;

            this.idPlanTrabajoRecuperacion              = 0;
            this.idPlanTrabajoDetalleAccion             = 0;
            this.idPlanTrabajoObjetivoGeneral           = 0;
            this.idPlanTrabajoObjetivoEspecifico        = 0;
            this.dFechaAccion                           = clsVarGlobal.dFecSystem;
        }
    }

    public class clsClientePlanTrabajoComparer : IEqualityComparer<clsDatosCreditoClientePlanTrabajo>
    {
        public bool Equals(clsDatosCreditoClientePlanTrabajo x, clsDatosCreditoClientePlanTrabajo y)
        {
            bool lValida = false;
            if (Object.ReferenceEquals(x, y)) return true;

            lValida = x != null && y != null && x.idPlanTrabajoRecuperacion.Equals(y.idPlanTrabajoRecuperacion) && x.idCuenta.Equals(y.idCuenta) && x.idCliente.Equals(x.idCliente);

            return lValida;
        }

        public int GetHashCode(clsDatosCreditoClientePlanTrabajo obj)
        {
            int hashIdPlanTrabajoRecuperacion   = obj.idPlanTrabajoRecuperacion.GetHashCode();
            int hashIdCliente                   = obj.idCliente.GetHashCode();
            int hashIdCuenta                    = obj.idCuenta.GetHashCode();

            return hashIdPlanTrabajoRecuperacion ^ hashIdCliente ^ hashIdCuenta;
                
        }
    }

}

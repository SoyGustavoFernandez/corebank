using GEN.WCFLogistica.CapaNegocio;
using WCFLogistica.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Logistica.Services
{    
    public class FuenteDatos : IFuenteDatos
    {
        private clsCNFuenteDatos cnFuenteDatos;

        public FuenteDatos()
        {
            this.cnFuenteDatos = new clsCNFuenteDatos();
        }

        public IList<clsConceptoRecibo> ObtenerConceptosRecibo(int idTipRec, int idPerfil)
        {
            return this.cnFuenteDatos.obtenerConceptosRecibo(idTipRec, idPerfil);
        }

        public IList<clsConfigTipoComprobante> ObtenerConfigTipoComprobante()
        {
            return this.cnFuenteDatos.obtenerConfigTipoComprobante();
        }
    }
}

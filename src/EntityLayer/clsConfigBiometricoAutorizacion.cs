using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigBiometricoAutorizacion : ICloneable
    {
        public int idConfigBiometricoAutorizacion { get; set; }
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        public decimal nMontoUmbral { get; set; }
        public int nMinimoAprobadores { get; set; }
        public int idTipoOperacion { get; set; }
        public bool lVigente { get; set; }
        public List<clsConfigBioPerfilAutorizacion> lstConfigBioPerfil { get; set; }

        public clsConfigBiometricoAutorizacion()
        {
            idConfigBiometricoAutorizacion  = 0;
            idAgencia                       = 0;
            idEstablecimiento               = 0;
            nMontoUmbral                    = 0;
            nMinimoAprobadores              = 0;
            idTipoOperacion                 = 0;
            lVigente                        = false;
            lstConfigBioPerfil              = new List<clsConfigBioPerfilAutorizacion>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}

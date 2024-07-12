using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigBioPerfilAutorizacion : ICloneable
    {
        public int idConfigBioPerfilAutorizacion { get;  set; }
        public int idConfigBiometricoAutorizacion { get; set; }
        public int idPerfil { get; set; }
        public bool lVigente { get; set; }

        public clsConfigBioPerfilAutorizacion()
        {
            idConfigBioPerfilAutorizacion   = 0;
            idConfigBiometricoAutorizacion  = 0;
            idPerfil                        = 0;
            lVigente                        = false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

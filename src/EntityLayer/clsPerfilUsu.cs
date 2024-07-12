using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsPerfilUsu:ICloneable
    {
        public int idPerfilUsu { get; set; }
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
        public bool lVigente { get; set; }
        public bool lLimCobertura { get; set; }
        public bool lResVentanilla { get; set; }
        public string cEmailInst { get; set; }

        public object Clone()
        {
            clsPerfilUsu p = (clsPerfilUsu)this.MemberwiseClone();
            return p;
        }
    }
    
    public class clsPerfil:ICloneable
    {
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
        public bool lVigente { get; set; }

        public object Clone()
        {
            clsPerfil p = (clsPerfil)this.MemberwiseClone();
            return p;
        }
    }
}

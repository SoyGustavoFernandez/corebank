using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsAutenticarLogin:IAutenticable
    {
        private clsAutenticacion _IAutenticacion;
        public string cUser { get; set; }
        public string cPass { get; set; }

        public clsAutenticarLogin()
        {
            _IAutenticacion = new clsAutenticacion();
        }
        public bool Autenticar()
        {
            if (String.IsNullOrEmpty(cUser) || String.IsNullOrEmpty(cPass))
                return false;

            return _IAutenticacion.ValidarCredenciales(cUser, cPass);
        }
    }
}

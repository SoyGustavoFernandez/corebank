using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace WCF.CoreBank.Interface
{
    interface IntConexionWebService
    {
        void setConectionString();

        clsWCFUsuario IdentificarUsuario(clsWCFUsuario objWCFUsuario);
    }
}

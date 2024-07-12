using System;
using Microsoft.SqlServer.Server;


namespace EntityLayer
{
    public class clsAgenByUsu
    {

        public int idAgenByUsu { get; set; }

        public int  idAgencia { get; set; }

        public string cAgencia { get; set; }

        public int idUsuAsig { get; set; }

        public bool lPrincipal { get; set; }

        public int idUsuario { get; set; }

        public DateTime dFecha { get; set; }

        public bool lVigente { get; set; }

        public clsAgenByUsu()
        {
            idAgenByUsu = 0;
            idAgencia = 0;
            cAgencia = String.Empty;
            idUsuAsig = 0;
            lPrincipal = false;
            idUsuario = clsVarGlobal.User.idUsuario;
            dFecha = clsVarGlobal.dFecSystem.Date;
            lVigente = true;
        }

    }
}

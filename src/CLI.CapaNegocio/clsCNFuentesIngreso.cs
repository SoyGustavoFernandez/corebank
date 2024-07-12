using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;

namespace CLI.CapaNegocio
{
    public class clsCNFuentesIngreso
    {
        clsADFuentesIngreso objfuenteing= new clsADFuentesIngreso();
        
        public clslisFuentesIngreso retornaFuentesIngreso(int idCli)
        {
            return objfuenteing.retornaFuentesIngreso(idCli);
        }

        public void insactFuentesIngreso(clslisFuentesIngreso lisfuentesIngreso)
        {
            objfuenteing.insactFuentesIngreso(lisfuentesIngreso);
        }

        public DataTable CNListarCondicionLaboralCliente()
        {
            return objfuenteing.ADListarCondicionLaboralCliente();
        }
        public DataTable CNListarTipoMedTiempo()
        {
            return objfuenteing.ADListarTipoMedTiempo();
        }
        public DataTable CNValidaColByEmpresa(int idCli, int idCliJur)
        {
            return objfuenteing.ADValidaColByEmpresa(idCli, idCliJur);
        }
    }
}

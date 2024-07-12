using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;

namespace CLI.CapaNegocio
{
    public class clsCNFondoMortuorio
    {
        clsADFondoMortuorio adfondo = new clsADFondoMortuorio();

        public clsFondoMortuorio retornardatosfondo(int idFondo)
        {
            return adfondo.retornardatosfondo(idFondo);
        }

        public clslisDetalleFondo listardetallefondo(int idFondo)
        {
            return adfondo.listardetallefondo(idFondo);
        }
    }
}

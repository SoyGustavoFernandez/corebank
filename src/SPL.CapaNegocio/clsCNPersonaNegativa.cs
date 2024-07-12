using EntityLayer;
using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNPersonaNegativa
    {
        public void InsertarListaNegativa(clsListaPersonaNegativa listaNegativa)
        {
            new clsADPersonaNegativa().InsertarListaNegativa(listaNegativa);
        }

        public clsListaPersonaNegativa ListarPersonasNegativas()
        {
            return new clsADPersonaNegativa().ListarPersonaNegativa();
        }
    }
}

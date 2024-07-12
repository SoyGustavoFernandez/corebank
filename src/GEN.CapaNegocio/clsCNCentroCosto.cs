using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;
using EntityLayer;



namespace GEN.CapaNegocio
{
    public class clsCNCentroCosto
    {
        public clsLstCentroCosto CNListCentroCosto(int idPadre)
        {
            return new clsADCentroCosto().ADListCentroCosto(idPadre);
        }
    }
}

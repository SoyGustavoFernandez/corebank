using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNConcepto
    {
        public clsADConcepto objdocide = new clsADConcepto();

        public DataTable CNListarConcepto(int idGrupoCon)
        {
            return objdocide.ADListarConcepto(idGrupoCon);
        }

        public DataTable CNListarConcepTipPag(int idTipPagCanal)
        {
            return objdocide.ADListarConcepTipPag(idTipPagCanal);
        }
        public DataTable CNListarConcepRecTipPag(int idTipPagCanal)
        {
            return objdocide.ADListarConcepRecTipPag(idTipPagCanal);
        }
    }
}

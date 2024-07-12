using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNMantOperaciones
    {
        clsADMantOperaciones Operaciones = new clsADMantOperaciones();
        public DataTable Listaroperaciones(int idModulo)
        {
            return Operaciones.Listaroperaciones(idModulo);
        }
        public int ActualizarOperaciones(int idTipoOperacion, String Tipo, int idModulo, string NombOper,
                                         int Modalidad, int Moneda,int Producto,int Extractocta,
                                        string CodigoSBS, int idTipoAsiento, int lVigente, int CantImpres,bool lisSplaft,
                                        bool lImprimir, int nNumDiasVcto)
        {
            DataTable dtResul=Operaciones.ActualizarOperaciones(idTipoOperacion,  Tipo,  idModulo,  NombOper,
                                                    Modalidad, Moneda,  Producto,
                                                    Extractocta, CodigoSBS, idTipoAsiento, lVigente, CantImpres, lisSplaft,
                                                    lImprimir, nNumDiasVcto);
            int idOpe=0;
            return idOpe = Convert.ToInt32(dtResul.Rows[0][0]);
        }

        public DataTable ListarTipoOperaciones()
        {
            return Operaciones.ListarTipoOperaciones();
        }
    }
}

using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNCalifInt
    {
        private clsADCalifInt objADCalifInt = new clsADCalifInt();
        public DataTable CNGetClasifInt()
        {
            return objADCalifInt.ADGetClasifInt();
        }

        public DataTable CNGetClasifIntCli(int idCli)
        {
            return objADCalifInt.ADGetClasifIntCli(idCli);
        }

        public clsDBResp CNGuardarClasifIntCli(int idCli, int idClasif, string cObservacion, 
                                                    DateTime dFecRegistro, int idUsuario)
        {
            return objADCalifInt.ADGuardarClasifIntCli(idCli, idClasif, cObservacion, dFecRegistro, idUsuario);
        }
    }
}

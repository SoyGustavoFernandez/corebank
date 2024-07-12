using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNClasifCli
    {
        public DataTable CNLstMotReclasifCli()
        {
            return new clsADClasifCli().ADLstMotReclasifCli();
        }
    }
}

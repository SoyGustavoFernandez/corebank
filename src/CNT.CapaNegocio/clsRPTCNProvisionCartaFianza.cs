using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNProvisionCartaFianza
    {
        public DataTable CNProvisionCartaFianza(DateTime dfecha, int idAgencia)
        {
            return new clsRPTADProvisionCartaFianza().ADProvisionCartaFianza(dfecha,idAgencia);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNTipoPeriodo
    {
        clsADTipoPeriodo objTipoPeriodo = new clsADTipoPeriodo();
        public DataTable dtListaTipoPeriodo()
        {
            return objTipoPeriodo.ListaTipoPeriodo();
        }
        public List<clsPeriodoCredito> listarPeriodoCredito()
        {
            return objTipoPeriodo.listarPeriodoCredito();
        }
    }
}

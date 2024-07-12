using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;

namespace LOG.CapaNegocio
{
    public class CNTipoActividades
    {
        clsADTipoActividades objTipAct = new clsADTipoActividades();

        public DataTable CNMostrarTipoActividades()
        {
            return objTipAct.ADMostrarTipoActividades();
        }

        public DataTable CNGrabarActividadLogistica(int idActivLog, int idAgencia, int idArea, int idTipActLog, string descripcion, bool lvigente)
        {
            return objTipAct.ADGrabarActividadLogistica(idActivLog, idAgencia, idArea, idTipActLog, descripcion, lvigente);
        }
    }
}

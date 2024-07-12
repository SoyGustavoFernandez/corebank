using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNAccionistasEmp
    {
        public clsADAccionistaEmp ObjAcc= new clsADAccionistaEmp();

        public DataTable CNListaAccionesRegistrasdas(int idCuentaPadre)
        {
            return ObjAcc.ADListaAccionesRegistrasdas(idCuentaPadre);
        }
        public DataTable CNRegistraAccionesEmp(int idAccioneEmp, int idCli, int idTipoAccionesEmp, int idTipoAccionEmp, decimal nNroAcciones,
            decimal nValNominal, string cObservaciones, int idUsuario,DateTime dFecAdquisicion, DateTime dFechaOpe, bool lVigente,int nNroFolio, 
              string cCodAccionista,string  DescAccionista,            decimal PorcParticipacion,     int nTipoEmision,int idTipoOperacionAccion)
        {
            return ObjAcc.ADRegistraAccionesEmp( idAccioneEmp, idCli, idTipoAccionesEmp, idTipoAccionEmp, nNroAcciones, nValNominal,
                cObservaciones, idUsuario, dFecAdquisicion, dFechaOpe, lVigente, nNroFolio, cCodAccionista, DescAccionista, PorcParticipacion, nTipoEmision, idTipoOperacionAccion);
        }
        public DataTable CNListaTipoEmisionAccione()
        {
            return ObjAcc.ADListaTipoEmisionAccione();
        }
        public DataTable CNListaTipoOperacionAcciones()
        {
            return ObjAcc.ADListaTipoOperacionAccion();
        }

        public DataTable CNListaAccionistas()
        {
            return ObjAcc.ADListaAccionistas();
        }
    }
}

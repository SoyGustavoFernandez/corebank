using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMotivoInasistencia
    {
        clsADMotivoInasistencia objMotivoInasistencia = new clsADMotivoInasistencia();

        public DataTable CNListarMotivosPermisoUsuario()
        {
            return objMotivoInasistencia.ADListarMotivosPermisoUsuario();
        }

        public DataTable CNListarMotivosPermisoRRHH()
        {
            return objMotivoInasistencia.ADListarMotivosPermisoRRHH();
        }

        public DataTable CNListarMotivosJustificacion()
        {
            return objMotivoInasistencia.ADListarMotivosJustificacion();
        }
        public DataTable ListarMotivos()
        {
            return objMotivoInasistencia.ListarMotivos();
        }

        public DataTable ActualizarMotivos(int TipOpe,int idMotivoAux,string cNombreMot,int lLaborable, int lFalta,
                                            int lDescuento, int lPermiso,int lJustificacion,int lPermRRHH)
        {
            return objMotivoInasistencia.ActualizarMotivos(TipOpe, idMotivoAux, cNombreMot, lLaborable, lFalta, lDescuento, lPermiso,
                                                  lJustificacion, lPermRRHH);
        }
        public int GuardarMotivos( string cNombreMot, int lLaborable, int lFalta,
                                            int lDescuento, int lPermiso, int lJustificacion, int lPermRRHH)
        {
            DataTable a = objMotivoInasistencia.GuardarMotivos(cNombreMot, lLaborable, lFalta, lDescuento, lPermiso,
                                                  lJustificacion, lPermRRHH);
            int nuevoId = 0;
            return nuevoId=Convert.ToInt32(a.Rows[0][0]);
        }
        public DataTable EliminarMotivo(int idMotivo)
        {
            return objMotivoInasistencia.EliminarMotivo(idMotivo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNProvisionesProc
    {
        clsADProvisionesProc Provisiones = new clsADProvisionesProc();
        public DataTable ListarPeriodosProv()
        {
            return Provisiones.ListarPeriodosProv();
        }
        public DataTable ListarTasasProv()
        {
            return Provisiones.ListarTasasProv();
        }

        public DataTable ActualizarProvisiones(string xmlPeriodo, string xmlTasa, DateTime dFecha, int idUsuario,
                                                decimal nMontoTasaMen,int idPeriodo, int idTasaTipoCredito, int idMes)
        {
            return Provisiones.ActualizarProvisiones(xmlPeriodo, xmlTasa, dFecha, idUsuario,
                                                    nMontoTasaMen, idPeriodo, idTasaTipoCredito, idMes);
        }
        public decimal CargarTasaMensual(int idPeriodo, int idTasaTipoCredito, int idMes)
        {
            DataTable dt= Provisiones.CargarTasaMensual( idPeriodo, idTasaTipoCredito, idMes);
            decimal nMontoMensual = Convert.ToDecimal(0.00);
            
            if(dt.Rows.Count > 0)
                nMontoMensual = Convert.ToDecimal(dt.Rows[0][0]);
            return nMontoMensual;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADAporte
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsAporte retornardatosaporte(int idAporte)
        {
            clsAporte aporte = null;
            DataTable dt = objEjeSp.EjecSP("CLI_RetDatAporte_sp", idAporte);

            if (dt.Rows.Count>0)
            {
                aporte = new clsAporte();

                aporte.idAporte     = (int)dt.Rows[0]["idAporte"];
                aporte.nMonTotApor  = (decimal)dt.Rows[0]["nMonTotApor"];
                aporte.nUtilidad = (decimal)dt.Rows[0]["nUtilidad"];
                aporte.nMonAporte = (decimal)dt.Rows[0]["nMonAporte"];
                aporte.idTipoPago   = (int)dt.Rows[0]["idTipoPago"];
                aporte.lAfectaCta   = (bool)dt.Rows[0]["lAfectaCta"];
                aporte.idAgencia    = (int)dt.Rows[0]["idAgencia"];
                aporte.dFechaAporte = (DateTime)dt.Rows[0]["dFechaAporte"];
                aporte.dFecCancela  = (dt.Rows[0]["dFecCancela"] == DBNull.Value) ? null : (DateTime?)(dt.Rows[0]["dFecCancela"]);
                aporte.idMoneda     = (int)dt.Rows[0]["idMoneda"];
                aporte.dFecRegSoc   = (DateTime)dt.Rows[0]["dFecRegSoc"];
                aporte.idUsuRegSoc  = (int)dt.Rows[0]["idUsuRegSoc"];
                aporte.dFecModSoc   = (dt.Rows[0]["dFecModSoc"] == DBNull.Value) ? null : (DateTime?)(dt.Rows[0]["dFecModSoc"]);
                aporte.idUsuModSoc  = (int)dt.Rows[0]["idUsuModSoc"];
                aporte.idEstado     = (int)dt.Rows[0]["idEstado"];
                aporte.nMonAporteDevuelto = (decimal)dt.Rows[0]["nTotalDevuelto"];
                aporte.objDetalleAportes = listardetalleaporte(aporte.idAporte);
            }

            return aporte;
        }

        public clslisDetalleAporte listardetalleaporte(int idAporte)
        {
            clslisDetalleAporte lista = new clslisDetalleAporte();

            DataTable dt = objEjeSp.EjecSP("CLI_RetDetalleAporte_sp", idAporte);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte    = (int)item["idAporte"]         ,
                        idDetAporte = (int)item["idDetAporte"]      ,
                        cPeriodo    = item["cPeriodo"].ToString()   ,
                        dFecVenApo  = (DateTime)item["dFecVenApo"]  ,
                        idEstado    = (int)item["idEstado"]         ,
                        nMonApoPac  = (decimal)item["nMonApoPac"]   ,
                        nMonApoPag  = (decimal)item["nMonApoPag"]   ,
                        nMonApoPac1 = (decimal)item["nMonApoPac1"]   
                    });
                                                      
                }
            }
            return lista;
        }

        public DataTable RegistraExtornoDevolucAportes(int idKar, int pidCuenta, int idUsuario, int nIdAgencia, DateTime dFecSystem, Decimal nMontoOpe, int idTipOpe, int pidTipPago, bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objEjeSp.EjecSP("CLI_ExtornoDevolAportes_sp", idKar, pidCuenta, idUsuario, nIdAgencia, dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        public DataTable RegistraExtornoPagoAportes(int idKar, int pidPago, int idUsuario, int nIdAgencia, DateTime dFecSystem, Decimal nMontoOpe, int idTipOpe, int pidTipPago, bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objEjeSp.EjecSP("CLI_ExtornoPagoAportes_sp", idKar, pidPago, idUsuario, nIdAgencia, dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        public DataTable retornarDatosOpeApoFon(int idKardex)
        {
            return objEjeSp.EjecSP("CLI_DetalleTrx_sp", idKardex);
        }

    }
}

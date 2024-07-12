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
    public class clsADFondoMortuorio
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsFondoMortuorio retornardatosfondo(int idFondo)
        {
            clsFondoMortuorio fondo = null;
            DataTable dt = objEjeSp.EjecSP("CLI_RetDatFondoMortuorio_sp", idFondo);

            if (dt.Rows.Count > 0)
            {
                fondo = new clsFondoMortuorio();

                fondo.idFondo = (int)dt.Rows[0]["idFondo"];
                fondo.nMonFondo = (decimal)dt.Rows[0]["nMonFondo"];
                fondo.nMonTotFon = (decimal)dt.Rows[0]["nMonTotFon"];
                fondo.idTipoPago = (int)dt.Rows[0]["idTipoPago"];
                fondo.lAfectaCta = (bool)dt.Rows[0]["lAfectaCta"];
                fondo.idAgencia = (int)dt.Rows[0]["idAgencia"];
                fondo.dFechaPago = (DateTime)dt.Rows[0]["dFechaPago"];
                fondo.dFecCancela = (dt.Rows[0]["dFecCancela"] == DBNull.Value) ? null : (DateTime?)(dt.Rows[0]["dFecCancela"]);
                fondo.idMoneda = (int)dt.Rows[0]["idMoneda"];
                fondo.dFecRegSoc = (DateTime)dt.Rows[0]["dFecRegSoc"];
                fondo.idUsuRegSoc = (int)dt.Rows[0]["idUsuRegSoc"];
                fondo.dFecModSoc = (dt.Rows[0]["dFecModSoc"] == DBNull.Value) ? null : (DateTime?)(dt.Rows[0]["dFecModSoc"]);
                fondo.idUsuModSoc = (int)dt.Rows[0]["idUsuModSoc"];
                fondo.idEstado = (int)dt.Rows[0]["idEstado"];
                
                fondo.objDetalleFondo = listardetallefondo(fondo.idFondo);
            }

            return fondo;
        }

        public clslisDetalleFondo listardetallefondo(int idFondo)
        {
            clslisDetalleFondo lista = new clslisDetalleFondo();

            DataTable dt = objEjeSp.EjecSP("CLI_RetDetalleFondo_sp", idFondo);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsDetalleFondo()
                    {
                        idDetFondo = (int)item["idDetFondo"],
                        idFondo = (int)item["idFondo"],
                        cPeriodo = item["cPeriodo"].ToString(),
                        dFecVenApo = (DateTime)item["dFecVenApo"],
                        idEstado = (int)item["idEstado"],
                        nMontoPac = (decimal)item["nMontoPac"],
                        nMontoPag = (decimal)item["nMontoPag"],
                        nMontoPac1 = (decimal)item["nMontoPac1"],
                        cTipoFondoSeguro = item["cTipoFondoSeguro"].ToString(),
                        dFechaPagPen = (item["dFechPagPen"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(item["dFechPagPen"])
                    });
                    
                }
            }
            return lista;
        }
    }
}

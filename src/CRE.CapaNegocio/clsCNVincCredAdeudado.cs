using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNVincCredAdeudado
    {
        private clsADVincCredAdeudado objCN = new clsADVincCredAdeudado();

        public DataTable CNGetCtasPosiblesAdeudos(int idProducto, int idMoneda, int nAtrasoMin, int nAtrasoMax)
        {
            return objCN.ADGetCtasPosiblesAdeudos(idProducto, idMoneda, nAtrasoMin, nAtrasoMax);
        }

        public DataTable CNGetCtasAdeudado(int idAdeudado)
        {
            return objCN.ADGetCtasAdeudado(idAdeudado);
        }

        public clsDBResp CNVincularCredAdeudado(string xmlAdeudado, int idAdeudado, int lHistorico, DateTime dFechaHistorico)
        {
            return objCN.ADVincularCredAdeudado(xmlAdeudado, idAdeudado, lHistorico, dFechaHistorico);
        }
    }
}

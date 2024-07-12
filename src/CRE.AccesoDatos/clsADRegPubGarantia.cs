using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADRegPubGarantia
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRegPub"></param>
        public void insertaactRegPubGarantia(clsRegPubGarantia objRegPub)
        {
            objEjeSp.EjecSPAlm("CRE_InsActRegPubGar_sp",    objRegPub.idRegPub,       objRegPub.idGarantia,   objRegPub.idOfiRegis,
                                                            objRegPub.idSedeRegis,    objRegPub.dFecInsBlo,   objRegPub.dFecConsGar,
                                                            objRegPub.cPartidIns,     objRegPub.cAsiento,     objRegPub.cFicha,
                                                            objRegPub.cRubro,         objRegPub.cTomo,        objRegPub.cFolio,
                                                            objRegPub.idTipoCober,    objRegPub.cFojas,       objRegPub.cCodPredio,
                                                            objRegPub.cPreferente,    objRegPub.dFechaReg,    objRegPub.idUsuReg,
                                                            objRegPub.dFechaMod,      objRegPub.idUsuMod,     objRegPub.idEstado,
                                                            objRegPub.lPrimeraVenta , objRegPub.cTituloInscripcion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsRegPubGarantia retornadatRegPubGar(int idGarantia)
        {
            clsRegPubGarantia regpubgar = null;
            DataTable dt = objEjeSp.EjecSP("CRE_RetDatRegPubGar_sp", idGarantia);

            if (dt.Rows.Count > 0)
            {
                regpubgar = new clsRegPubGarantia();

                regpubgar.idRegPub      = (int)dt.Rows[0]["idRegPub"];
                regpubgar.idGarantia    = (int)dt.Rows[0]["idGarantia"];
                regpubgar.idOfiRegis    = (int)dt.Rows[0]["idOfiRegis"];
                regpubgar.idSedeRegis   = (int)dt.Rows[0]["idSedeRegis"];
                regpubgar.dFecInsBlo    = (DateTime)dt.Rows[0]["dFecInsBlo"];
                regpubgar.dFecConsGar   = (DateTime)dt.Rows[0]["dFecConsGar"];
                regpubgar.cPartidIns    = (string)dt.Rows[0]["cPartidIns"];
                regpubgar.cAsiento      = (string)dt.Rows[0]["cAsiento"];
                regpubgar.cFicha        = (string)dt.Rows[0]["cFicha"];
                regpubgar.cRubro        = (string)dt.Rows[0]["cRubro"];
                regpubgar.cTomo         = (string)dt.Rows[0]["cTomo"];
                regpubgar.cFolio        = (string)dt.Rows[0]["cFolio"];
                regpubgar.idTipoCober   = (int)dt.Rows[0]["idTipoCober"];
                regpubgar.cFojas        = (string)dt.Rows[0]["cFojas"];
                regpubgar.cCodPredio    = (string)dt.Rows[0]["cCodPredio"];
                regpubgar.cPreferente   = (string)dt.Rows[0]["cPreferente"];
                regpubgar.dFechaReg     = (DateTime)dt.Rows[0]["dFechaReg"];
                regpubgar.idUsuReg	    = (int)dt.Rows[0]["idUsuReg"];
                regpubgar.dFechaMod	    = dt.Rows[0]["dFechaMod"]==System.DBNull.Value?clsVarGlobal.dFecSystem:(DateTime)dt.Rows[0]["dFechaMod"];
                regpubgar.idUsuMod	    = dt.Rows[0]["idUsuMod"]==System.DBNull.Value?0: (int)dt.Rows[0]["idUsuMod"];
                regpubgar.idEstado	    = (int)dt.Rows[0]["idEstado"];
                regpubgar.lPrimeraVenta = (bool)dt.Rows[0]["lIndPriVenta"];
                regpubgar.cTituloInscripcion = (string)dt.Rows[0]["cTituloInscripcion"];
            }

            return regpubgar;
        }

    }
}

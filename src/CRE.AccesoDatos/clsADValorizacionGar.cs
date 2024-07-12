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
    public class clsADValorizacionGar
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void insertaactValorizacion(clsValorizacionGar objvaloriza)
        {
            objEjeSp.EjecSPAlm("CRE_InsActValorizacion_sp", objvaloriza.idValorizacion      ,   objvaloriza.idGarantia  ,   objvaloriza.dFecUltVal      ,
                                                            objvaloriza.dFecVenVal          ,   objvaloriza.idTasador   ,   objvaloriza.idCondiInmueble ,
                                                            objvaloriza.idEstadoConservacion,   objvaloriza.idMatPared  ,   objvaloriza.idMatTecho      ,
                                                            objvaloriza.idMatVenPuer        ,   objvaloriza.nNumPisos   ,   objvaloriza.nAreaTerreno    ,
                                                            objvaloriza.nAreaContru         ,   objvaloriza.idUsuReg    ,   objvaloriza.dFecRegistro    ,
                                                            objvaloriza.idUsuMod            ,   objvaloriza.dFecMod     ,   objvaloriza.idEstado,
                                                            objvaloriza.nValorEdifica       ,   objvaloriza.nValorComercial, objvaloriza.nValorMercado,
                                                            objvaloriza.nValorNuevo         ,   objvaloriza.nValorVenta ,   objvaloriza.nValorRealiza,
                                                            objvaloriza.dValorContable      ,   objvaloriza.dValorConstituido);
        }

        public clsValorizacionGar retornaDatValoriza(int idGarantia)
        {
            clsValorizacionGar objvaloriza=null ;
            DataTable dt = objEjeSp.EjecSP("CRE_RetDatValorizacion_sp", idGarantia);

            if (dt.Rows.Count>0)
            {
                objvaloriza = new clsValorizacionGar();

                if (dt.Rows[0]["idValorizacion"]!=System.DBNull.Value)
                {
                    objvaloriza.idValorizacion          = (int)dt.Rows[0]["idValorizacion"];
                    objvaloriza.idGarantia              = (int)dt.Rows[0]["idGarantia"];
                    objvaloriza.dFecUltVal              = (DateTime)dt.Rows[0]["dFecUltVal"];
                    objvaloriza.dFecVenVal              = (DateTime)dt.Rows[0]["dFecVenVal"];
                    objvaloriza.idTasador               = (int)dt.Rows[0]["idTasador"];
                    objvaloriza.idCondiInmueble         = (int)dt.Rows[0]["idCondiInmueble"];
                    objvaloriza.idEstadoConservacion    = (int)dt.Rows[0]["idEstadoConservacion"];
                    objvaloriza.idMatPared              = (int)dt.Rows[0]["idMatPared"];
                    objvaloriza.idMatTecho              = (int)dt.Rows[0]["idMatTecho"];
                    objvaloriza.idMatVenPuer            = (int)dt.Rows[0]["idMatVenPuer"];
                    objvaloriza.nNumPisos               = (int)dt.Rows[0]["nNumPisos"];
                    objvaloriza.nAreaTerreno            = (decimal)dt.Rows[0]["nAreaTerreno"];
                    objvaloriza.nAreaContru             = (decimal)dt.Rows[0]["nAreaContru"];
                    objvaloriza.idUsuReg                = (int)dt.Rows[0]["idUsuReg"];
                    objvaloriza.dFecRegistro            = (DateTime)dt.Rows[0]["dFecRegistro"];
                    objvaloriza.idEstado                = (int)dt.Rows[0]["idEstado"];
                }
                objvaloriza.nValorRealiza = dt.Rows[0]["nValorRealiza"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorRealiza"];
                objvaloriza.nValorEdifica = dt.Rows[0]["nValorEdifica"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorEdifica"];
                objvaloriza.nValorComercial = dt.Rows[0]["nValorComercial"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorComercial"];
                objvaloriza.nValorMercado = dt.Rows[0]["nValorMercado"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorMercado"];
                objvaloriza.nValorNuevo = dt.Rows[0]["nValorNuevo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorNuevo"];
                objvaloriza.nValorVenta = dt.Rows[0]["nValorVenta"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["nValorVenta"];
                objvaloriza.dValorContable = dt.Rows[0]["dValorContable"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["dValorContable"];
                objvaloriza.dValorConstituido = dt.Rows[0]["dValorConstituido"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["dValorConstituido"];

            }

            return objvaloriza;
        }
    }
}

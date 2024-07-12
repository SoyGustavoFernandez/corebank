using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data; 


namespace GEN.AccesoDatos
{
    public class clsADProductos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();


        public DataTable ListaProductos(String TipFiltro, int filtro)
        {
            return objEjeSp.EjecSP("Gen_ListaParamProd_Sp", TipFiltro, filtro);
        }
        public DataTable RetDatosprod(int idproduc)
        {
            return objEjeSp.EjecSP("ADM_DatosProducto_SP", idproduc);
        }

        public void ActualizarProd(int idProducto, int idMoneda, Boolean inactividad, int PlazoInact,
                                                         int PlazoCancel, Decimal MonminApe, Decimal MonMinSaldo, Decimal MonMinOpe,
                                                         int PlazoMinProd, int PlazoMaxProd, int plazoProd, Boolean Renovprod,
                                                         Boolean RequCert, Boolean AfectoITF, Boolean ReqPagInt, Boolean DepTipPagInt,
                                                         Boolean ReqEmpl, Boolean ProdTransf, Boolean ProdCTS, Boolean DepAhoProg,
                                                         int TipCalcul, int PerCapit, Boolean OpeRet, Boolean OpeDep,
                                                         Boolean CtaCte, Boolean Estado, int idProdTasCanc, Boolean OrdenPago, int ClasifProd,
                                                         String xmlTipPer, String xmlTipCta, String xmlTipRenov, String xmlTipPago, Boolean AplicaMenEdad,
                                                         int nTipoCap, Boolean lGarCre, Boolean RenovprodTasa, int idProdTasaRenov)
        {
            objEjeSp.EjecSP("ADM_ActuaParamProd_Sp", idProducto, idMoneda, inactividad, PlazoInact,
                                                         PlazoCancel, MonminApe, MonMinSaldo, MonMinOpe,
                                                         PlazoMinProd, PlazoMaxProd, plazoProd, Renovprod,
                                                         RequCert, AfectoITF, ReqPagInt, DepTipPagInt,
                                                         ReqEmpl, ProdTransf, ProdCTS, DepAhoProg,
                                                         TipCalcul, PerCapit, OpeRet, OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, nTipoCap, lGarCre, RenovprodTasa, idProdTasaRenov);
        }

        public DataTable GuardarProd(int idProducto, int idMoneda, Boolean inactividad, int PlazoInact,
                                                         int PlazoCancel, Decimal MonminApe, Decimal MonMinSaldo, Decimal MonMinOpe,
                                                         int PlazoMinProd, int PlazoMaxProd, int plazoProd, Boolean Renovprod,
                                                         Boolean RequCert, Boolean AfectoITF, Boolean ReqPagInt, Boolean DepTipPagInt,
                                                         Boolean ReqEmpl, Boolean ProdTransf, Boolean ProdCTS, Boolean DepAhoProg,
                                                         int TipCalcul, int PerCapit, Boolean OpeRet, Boolean OpeDep,
                                                         Boolean CtaCte, Boolean Estado, int idProdTasCanc, Boolean OrdenPago, int ClasifProd,
                                                         String xmlTipPer, String xmlTipCta, String xmlTipRenov, String xmlTipPago, Boolean AplicaMenEdad,
                                                         int nTipoCap, Boolean lGarCre,Boolean RenovprodTasa, int idProdTasaRenov)
        {
            return objEjeSp.EjecSP("ADM_GuardarParamProd_Sp", idProducto, idMoneda, inactividad, PlazoInact,
                                                         PlazoCancel, MonminApe, MonMinSaldo, MonMinOpe,
                                                         PlazoMinProd, PlazoMaxProd, plazoProd, Renovprod,
                                                         RequCert, AfectoITF, ReqPagInt, DepTipPagInt,
                                                         ReqEmpl, ProdTransf, ProdCTS, DepAhoProg,
                                                         TipCalcul, PerCapit, OpeRet, OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, nTipoCap, lGarCre, RenovprodTasa, idProdTasaRenov);

        }
        public DataTable ValidarDup(int idProducto, int idMoneda)
        {

            return objEjeSp.EjecSP("ADM_ParamProdDup_Sp", idProducto, idMoneda);
        }


        public DataTable TipoPersXprod(int idProducto)
        {
            return objEjeSp.EjecSP("DEP_RetTipoPerProd_Sp", idProducto);

        }
        public DataTable TipoCtaXprod(int idProducto)
        {
            return objEjeSp.EjecSP("DEP_RetTipoCtaProd_Sp", idProducto);

        }
        public DataTable TipoRenovXprod(int idProducto)
        {
            return objEjeSp.EjecSP("DEP_RetTipoRenovacionProd_Sp", idProducto);

        }
        public DataTable TipoPagoIntXprod(int idProducto)
        {
            return objEjeSp.EjecSP("DEP_RetPagoInteresProd_Sp", idProducto);

        }

        public DataTable TipoCapitalizacion()
        {
            return objEjeSp.EjecSP("DEP_RetornaTipoCapitalizacion_Sp");

        }

    }
}

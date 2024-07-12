using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNProductos
    {
        clsADProductos objListaProd = new clsADProductos();

        public DataTable ListarProductos(String TipFiltro, int filtro)
        {
            return objListaProd.ListaProductos(TipFiltro, filtro);
        }

        public DataTable RetDatosProducto(int idproduc)
        {
            return objListaProd.RetDatosprod(idproduc);
        }


        public void ActualizarProd(int idProducto,int idMoneda,Boolean inactividad, int PlazoInact,
                                                         int PlazoCancel,Decimal MonminApe, Decimal MonMinSaldo,Decimal MonMinOpe,
                                                         int PlazoMinProd, int PlazoMaxProd, int plazoProd, Boolean Renovprod,
                                                         Boolean RequCert, Boolean AfectoITF, Boolean ReqPagInt, Boolean DepTipPagInt,
                                                         Boolean ReqEmpl, Boolean ProdTransf, Boolean ProdCTS, Boolean DepAhoProg,
                                                         int TipCalcul, int PerCapit, Boolean OpeRet, Boolean OpeDep,
                                                         Boolean CtaCte, Boolean Estado, int idProdTasCanc, Boolean OrdenPago, int ClasifProd,
                                                         String xmlTipPer, String xmlTipCta, String xmlTipRenov, String xmlTipPago, Boolean AplicaMenEdad,
                                                         int nTipoCap, Boolean lGarCre, Boolean RenovprodTasa, int idProdTasaRenov)
        {
            objListaProd.ActualizarProd(idProducto, idMoneda, inactividad, PlazoInact,
                                                         PlazoCancel, MonminApe, MonMinSaldo, MonMinOpe,
                                                         PlazoMinProd, PlazoMaxProd, plazoProd, Renovprod,
                                                         RequCert, AfectoITF, ReqPagInt, DepTipPagInt,
                                                         ReqEmpl, ProdTransf, ProdCTS, DepAhoProg,
                                                         TipCalcul, PerCapit, OpeRet, OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, nTipoCap, lGarCre, RenovprodTasa, idProdTasaRenov);
        }

        public void GuardarProd(int idProducto, int idMoneda, Boolean inactividad, int PlazoInact,
                                                         int PlazoCancel, Decimal MonminApe, Decimal MonMinSaldo, Decimal MonMinOpe,
                                                         int PlazoMinProd, int PlazoMaxProd, int plazoProd, Boolean Renovprod,
                                                         Boolean RequCert, Boolean AfectoITF, Boolean ReqPagInt, Boolean DepTipPagInt,
                                                         Boolean ReqEmpl, Boolean ProdTransf, Boolean ProdCTS, Boolean DepAhoProg,
                                                         int TipCalcul, int PerCapit, Boolean OpeRet, Boolean OpeDep,
                                                         Boolean CtaCte, Boolean Estado, int idProdTasCanc, Boolean OrdenPago, int ClasifProd,
                                                         String xmlTipPer, String xmlTipCta, String xmlTipRenov, String xmlTipPago, Boolean AplicaMenEdad,
                                                         int nTipoCap, Boolean lGarCre, Boolean RenovprodTasa, int idProdTasaRenov)
        {
            objListaProd.GuardarProd(idProducto, idMoneda, inactividad, PlazoInact,
                                                         PlazoCancel, MonminApe, MonMinSaldo, MonMinOpe,
                                                         PlazoMinProd, PlazoMaxProd, plazoProd, Renovprod,
                                                         RequCert, AfectoITF, ReqPagInt, DepTipPagInt,
                                                         ReqEmpl, ProdTransf, ProdCTS, DepAhoProg,
                                                         TipCalcul, PerCapit, OpeRet, OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, nTipoCap, lGarCre, RenovprodTasa, idProdTasaRenov);         

        }
        public int ControlDuplicidad(int idProducto, int idMoneda)
        {
            DataTable tbProdDup = objListaProd.ValidarDup(idProducto, idMoneda);
            int idProdDup = Convert.ToInt32(tbProdDup.Rows[0][0]);
            return idProdDup;

        }

        public DataTable TipoPersXprod(int idProducto)
        {
            return objListaProd.TipoPersXprod(idProducto);           

        }
        public DataTable TipoCtaXprod(int idProducto)
        {
            return objListaProd.TipoCtaXprod(idProducto);

        }
        public DataTable TipoRenovXprod(int idProducto)
        {
            return objListaProd.TipoRenovXprod(idProducto);

        }
        public DataTable TipoPagoIntXprod(int idProducto)
        {
            return objListaProd.TipoPagoIntXprod(idProducto);

        }

        public DataTable TipoCapitalizacion()
        {
            return objListaProd.TipoCapitalizacion();

        }

    }
}

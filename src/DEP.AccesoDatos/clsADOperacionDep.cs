using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper.Interface;

namespace DEP.AccesoDatos
{
    public class clsADOperacionDep
    {        
        IntConexion objEjeSP; 
       
        public clsADOperacionDep(bool lConexion)
        {
            objEjeSP = new clsWCFEjeSP();
        }

        public clsADOperacionDep()
        {
            objEjeSP = new clsGENEjeSP();
        }

        public DataTable GuardarApertura(string xmlDatosDeposito, int idcli)
        {
            return objEjeSP.EjecSP("CRE_InsUpdDeposito_SP", xmlDatosDeposito, idcli);
        }
        public DataTable BuscarCuenta(Int32 idCuenta)
        {
            return objEjeSP.EjecSP("DEP_BusCueDep_sp",idCuenta);
        }

        public DataTable GuardarAperturaPlazo(string xmlDatosDeposito, string xmlInterv, int nPlazo, int nNumFirmas, decimal nTasa, int idUsuAsig, decimal nITF, decimal nComision, decimal nMonFavCli)
        {
            return objEjeSP.EjecSP("DEP_InsDepositoPlazo_SP", xmlDatosDeposito, xmlInterv, nPlazo, nNumFirmas, nTasa, idUsuAsig, nITF, nComision, nMonFavCli);
        }

        public DataTable retornarDatOpe(int idCuenta,int idKardex,int idModulo)
        {
            return objEjeSP.EjecSP("GEN_DatosOperacion_sp",idKardex ,idCuenta , idModulo);
        }
        public DataTable retornarDatCtaCtb(int idcuenta)
        {
            return objEjeSP.EjecSP("DEP_DatCtaReimp_sp", idcuenta);
        }
        //============================================================================
        //---lISTADO DE TIPOS DE cUENTA POR PRODUCTO
        //============================================================================
        public DataTable LisTipCtaProd(int idProd)
        {
            return objEjeSP.EjecSP("DEP_RetTipoCtaProd_Sp", idProd);
        }

        //============================================================================
        //---lISTADO DE PARAMETROS DEL PRODUCTO
        //============================================================================
        public DataTable LisParamProd(int idProd, int idMon, int idOpc)
        {
            return objEjeSP.EjecSP("DEP_RetornaParamProd_Sp", idProd, idMon, idOpc);
        }

        //============================================================================
        //---lISTADO DE COMISIONES DEL PRODUCTO
        //============================================================================
        public DataTable LisComisionProd(int idProd, int idMon)
        {
            return objEjeSP.EjecSP("DEP_ListaComisionProd_Sp", idProd, idMon);
        }

        //============================================================================
        //---Listado de Tipos de Persona Por Producto
        //============================================================================
        public DataTable LisTipPerProd(int idProd)
        {
            return objEjeSP.EjecSP("DEP_RetTipoPerProd_Sp", idProd);
        }

        //============================================================================
        //---Listado de Tipos de Renovación Por Producto
        //============================================================================
        public DataTable LisTipRenovacionProd(int idProd)
        {
            return objEjeSP.EjecSP("DEP_RetTipoRenovacionProd_Sp", idProd);
        }

        //============================================================================
        //---Listado de Tipos de Pago de Interes Por Producto
        //============================================================================
        public DataTable LisTipPagoInteresProd(int idProd)
        {
            return objEjeSP.EjecSP("DEP_RetPagoInteresProd_Sp", idProd);
        }

        //============================================================================
        //---Listado de Tipos de Pago de Interes
        //============================================================================
        public DataTable LisTipPagoInt()
        {
            return objEjeSP.EjecSP("DEP_RetTipPagoInteres_Sp");
        }

        //============================================================================
        //---Listado de Tipos de Renovaciones
        //============================================================================
        public DataTable LisTipRenovacion()
        {
            return objEjeSP.EjecSP("DEP_RetTipRenovacion_Sp");
        }

        //============================================================================
        //---Listado de Modalidades de Pago
        //============================================================================
        public DataTable LisModPago( int ntipOpe)
        {
            return objEjeSP.EjecSP("DEP_RetModalidadPago_Sp", ntipOpe);
        }

        //============================================================================
        //---Listado de Tipos Pago de Interes por Producto
        //============================================================================
        public DataTable LisPagIntProd(int idProd)
        {
            return objEjeSP.EjecSP("DEP_RetPagoInteresProd_Sp", idProd);
        }

        //============================================================================
        //---Retorna Bloqueos de Cuenta
        //============================================================================
        public DataTable RetBloqueoCta(int idCta)
        {
            return objEjeSP.EjecSP("DEP_RetBloqueosCta_sp", idCta);
        }

        //============================================================================
        //---Retorna Comisiones de la Cuenta
        //============================================================================
        public DataTable RetornaComisionesCta(int idProd,int idTipOpe,int idTipPer,int idMon,int idCta,
                                                int idCanal, int idAge, Decimal nMonto, int nPlazo, int x_idTipoPago)
        {
            return objEjeSP.EjecSP("DEP_RetornaComisiones_SP", idProd, idTipOpe, idTipPer, idMon, idCta,
                                                    idCanal, idAge, nMonto, nPlazo, x_idTipoPago);
        }

        //============================================================================
        //---Registra Extorno de Operaciones
        //============================================================================
        public DataTable RegExtornoOpe(int idKardex, int idCuenta, int idUsu, int idAge, DateTime dFechaOpe,
                                        Decimal nMonOpe, int idTipOpe, int idTippago,
                                        bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objEjeSP.EjecSP("DEP_RegistraExtornoOpeAho_SP", idKardex, idCuenta, idUsu, idAge, dFechaOpe,
                                        nMonOpe, idTipOpe, idTippago,
                                        lModificaSaldoLinea, idTipoTransac, idMon);

        }

        //============================================================================
        //---Lista Documentos Valorados
        //============================================================================
        public DataTable ListaDocsValorados(int idTipVal, int idAge)
        {
            return objEjeSP.EjecSP("DEP_ListaValorados_sp", idTipVal, idAge);
        }

        //============================================================================
        //---Lista Tipo de Valorados
        //============================================================================
        public DataTable ListaTipoValorados()
        {
            return objEjeSP.EjecSP("DEP_ListaTipoValorados_sp");
        }

        //============================================================================
        //---Validar Operaciones Posteriores: Apertura
        //============================================================================
        public DataTable ListaNroOPePosterioresApe(int idKardex,int idCuenta)
        {
            return objEjeSP.EjecSP("DEP_VerificaOPeCtaExt_sp", idKardex, idCuenta);
        }
        //============================================================================
        //---Listado de Modalidades de Pago con las operaciones respectivas
        //============================================================================
        public DataTable LisModPagoOperaciones()
        {
            return objEjeSP.EjecSP("DEP_LisModPagoOperacion_SP"); 
        }
        //============================================================================
        //---Grabar Modalidad de Pago con las operaciones respectivas
        //============================================================================
        public DataTable GrabarModPagoOperaciones(string xmlModPago)
        {
            return objEjeSP.EjecSP("DEP_ActModPagoXOperacion_Sp", xmlModPago);
        }

    }
}

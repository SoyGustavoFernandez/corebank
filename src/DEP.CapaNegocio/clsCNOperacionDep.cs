using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEP.AccesoDatos;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace DEP.CapaNegocio
{
    public class clsCNOperacionDep
    {
        #region Variables Globales

        private Word.Application oWord;
        private Word.Document oDoc;
        private object objMissing = Missing.Value;
        private object objFalse = false;

        #endregion

        clsADOperacionDep objADOpeDep;
       
        clsCNRetDatosCliente objDatCli = new clsCNRetDatosCliente();
        clsCNDirecCli objDirCli = new clsCNDirecCli();

        public clsCNOperacionDep()
        {
            objADOpeDep = new clsADOperacionDep();
        }

        public clsCNOperacionDep(bool cConex)
        {
            objADOpeDep = new clsADOperacionDep(cConex);
        }

        public DataTable GuardarDeposito(string xmlDatosDeposito, int idcli)
        {
            return objADOpeDep.GuardarApertura(xmlDatosDeposito, idcli);
        }
        public DataTable BuscarCuenta(Int32 idCuenta)
        {
            return objADOpeDep.BuscarCuenta(idCuenta);
        }
        public DataTable GuardarDepositoPlazo(string xmlDatosDeposito, string xmlInterv, int nPlazo, int nNumFirmas, decimal nTasa, int idUsuAsig,decimal nITF, decimal nComision, decimal nMonFavCli)
        {
            return objADOpeDep.GuardarAperturaPlazo(xmlDatosDeposito, xmlInterv, nPlazo, nNumFirmas, nTasa, idUsuAsig,  nITF,  nComision,  nMonFavCli);
        }
        public bool ImpTarJuntaDiario(int idCuenta, int IdCli, Decimal nImporte, Decimal nAporte, DateTime dFecIni, DateTime dFecFin, string cRutArchivo)
        {
           

            bool lestadoImp = false;
            try
            {

                DataTable dtDatCli = objDatCli.ListarDatosCli(IdCli, "N");
                DataTable dtDirCli = objDirCli.ListaDirCli(IdCli);

                this.oWord = new Word.Application();
                this.oWord.Visible = false;

                oDoc = oWord.Documents.Add(cRutArchivo);

                #region Intervinientes

                oDoc.Bookmarks["cNombres"].Range.Text = dtDatCli.Rows[0]["cApellidoPaterno"].ToString().Trim() + " " +
                                                        (dtDatCli.Rows[0]["cApellidoMaterno"].ToString().Trim() + " " +
                                                        dtDatCli.Rows[0]["cApellidoCasado"].ToString().Trim()).Trim() + ", " +
                                                        dtDatCli.Rows[0]["cNombre"].ToString().Trim();

                oDoc.Bookmarks["cDocumento"].Range.Text = dtDatCli.Rows[0]["cDocumentoID"].ToString().Trim();

                oDoc.Bookmarks["cNumTel"].Range.Text = dtDatCli.Rows[0]["nNumeroTelefono"].ToString().Trim();

                oDoc.Bookmarks["cDireccion"].Range.Text = dtDirCli.Rows[0]["cDireccion"].ToString().Trim();

                oDoc.Bookmarks["dFecIni"].Range.Text = dFecIni.ToShortDateString();

                oDoc.Bookmarks["dFecFin"].Range.Text = dFecFin.ToShortDateString();

                oDoc.Bookmarks["nAporte"].Range.Text = nAporte.ToString();

                oDoc.Bookmarks["nImporte"].Range.Text = nImporte.ToString();


                oDoc.Bookmarks["cNombres2"].Range.Text = dtDatCli.Rows[0]["cApellidoPaterno"].ToString().Trim() + " " +
                                                        (dtDatCli.Rows[0]["cApellidoMaterno"].ToString().Trim() + " " +
                                                        dtDatCli.Rows[0]["cApellidoCasado"].ToString().Trim()).Trim() + ", " +
                                                        dtDatCli.Rows[0]["cNombre"].ToString().Trim();

                oDoc.Bookmarks["cDocumento2"].Range.Text = dtDatCli.Rows[0]["cDocumentoID"].ToString().Trim();

                oDoc.Bookmarks["cNumTel2"].Range.Text = dtDatCli.Rows[0]["nNumeroTelefono"].ToString().Trim();

                oDoc.Bookmarks["cDireccion2"].Range.Text = dtDirCli.Rows[0]["cDireccion"].ToString().Trim();

                oDoc.Bookmarks["dFecIni2"].Range.Text = dFecIni.ToShortDateString();

                oDoc.Bookmarks["dFecFin2"].Range.Text = dFecFin.ToShortDateString();

                oDoc.Bookmarks["nAporte2"].Range.Text = nAporte.ToString();

                oDoc.Bookmarks["nImporte2"].Range.Text = nImporte.ToString();



                oDoc.Bookmarks["nIdCuenta"].Range.Text = idCuenta.ToString();


                #endregion

                oDoc.PrintOut();
                oDoc.Close(ref objFalse, ref objMissing, ref objMissing);

                this.oWord.Quit(ref objMissing, ref objMissing, ref objMissing);
                lestadoImp = true;
            }
            catch (Exception)
            {

                throw;
            }
            return lestadoImp;
        }

        public bool ImpCertInver(int idCuenta, DataTable dtInterv, Decimal nAporte, Decimal nPlazo, 
                                Decimal nInteres,Decimal nTasa,string cTipCta,string cCuenta,string cDesCert,
                                DateTime dFecIni, DateTime dFecFin, string cRutArchivo,bool lIndint)
        {


            bool lestadoImp = false;
            try
            {
                this.oWord = new Word.Application();
                this.oWord.Visible = false;

                oDoc = oWord.Documents.Add(cRutArchivo);

                #region Intervinientes

                string cTitulares="",cNumtel="";

                foreach (DataRow item in dtInterv.Rows)
                {
                    DataTable dtDatCli = objDatCli.ListarDatosCli(Convert.ToInt32(item["codigo"]), "N");

                    cTitulares = cTitulares + (dtDatCli.Rows[0]["cApellidoPaterno"].ToString().Trim() + " " +
                                                        (dtDatCli.Rows[0]["cApellidoMaterno"].ToString().Trim() + " " +
                                                        dtDatCli.Rows[0]["cApellidoCasado"].ToString().Trim()).Trim() + ", " +
                                                        dtDatCli.Rows[0]["cNombre"].ToString().Trim()) + Environment.NewLine;

                    cNumtel = cNumtel + (dtDatCli.Rows[0]["nNumeroTelefono"].ToString().Trim()) + Environment.NewLine;                    
                }

                oDoc.Bookmarks["cTitulares"].Range.Text = cTitulares.ToString();

                oDoc.Bookmarks["nNumTel"].Range.Text = cNumtel.ToString();

                oDoc.Bookmarks["dFechaApe"].Range.Text = dFecIni.ToShortDateString();

                oDoc.Bookmarks["dFechaFin"].Range.Text = dFecFin.ToShortDateString();


                oDoc.Bookmarks["nMonto"].Range.Text = "S/. " + string.Format("{0:0.00}",nAporte);

                if (Convert.ToInt32(nPlazo)==1)
                {
                    oDoc.Bookmarks["nPlazo"].Range.Text = nPlazo.ToString() + " mes";
                }
                else
                {
                    oDoc.Bookmarks["nPlazo"].Range.Text = nPlazo.ToString() + " meses"; 
                }
                

                if (lIndint)
                {
                    oDoc.Bookmarks["nInteres"].Range.Text = "RETIRO DE INTERES: S/. " + nInteres.ToString();
                }                

                oDoc.Bookmarks["nTasa"].Range.Text = string.Format("{0:0.00}",nTasa) +"%";


                oDoc.Bookmarks["cAgencia"].Range.Text = clsVarGlobal.cNomAge.Trim();

                oDoc.Bookmarks["cCuenta"].Range.Text = cCuenta.ToString();

                oDoc.Bookmarks["cTipCta"].Range.Text = cTipCta.ToString();

                oDoc.Bookmarks["cDesCert"].Range.Text = cDesCert.ToString();


                #endregion

                oDoc.PrintOut();
                oDoc.Close(ref objFalse, ref objMissing, ref objMissing);

                this.oWord.Quit(ref objMissing, ref objMissing, ref objMissing);
                lestadoImp = true;
            }
            catch (Exception)
            {

                throw;
            }
            return lestadoImp;
        }

        public bool imprimirVoucherDep(int idCuenta, int idKardex, int idModulo, string cRutArchivo)
        {



           DataTable dtDatOpe= objADOpeDep.retornarDatOpe(idCuenta, idKardex, idModulo);

           bool lestadoImp = false;
           try
           {
               this.oWord = new Word.Application();
               this.oWord.Visible = false;

               oDoc = oWord.Documents.Add(cRutArchivo);

               oDoc.Bookmarks["cAgencia"].Range.Text = dtDatOpe.Rows[0]["cNombreAge"].ToString().Trim();
               oDoc.Bookmarks["cNombre"].Range.Text = dtDatOpe.Rows[0]["cNombre"].ToString().Trim();
               oDoc.Bookmarks["cOperacion"].Range.Text = dtDatOpe.Rows[0]["cTipoOperacion"].ToString().Trim();
               oDoc.Bookmarks["cUsuario"].Range.Text = dtDatOpe.Rows[0]["cWinUser"].ToString().Trim();
               oDoc.Bookmarks["dFecha"].Range.Text = dtDatOpe.Rows[0]["dFecha"].ToString().Trim();
               oDoc.Bookmarks["dHora"].Range.Text = dtDatOpe.Rows[0]["fHora"].ToString().Trim();
               oDoc.Bookmarks["idCuenta"].Range.Text = dtDatOpe.Rows[0]["idCuenta"].ToString().Trim();
               oDoc.Bookmarks["nMonto"].Range.Text = dtDatOpe.Rows[0]["cMoneda"].ToString().Trim() + string.Format("{0:0.00}", Convert.ToDecimal (dtDatOpe.Rows[0]["nMonTotal"])).Trim();

               oDoc.Bookmarks["cAgencia2"].Range.Text = dtDatOpe.Rows[0]["cNombreAge"].ToString().Trim();
               oDoc.Bookmarks["cNombre2"].Range.Text = dtDatOpe.Rows[0]["cNombre"].ToString().Trim();
               oDoc.Bookmarks["cOperacion2"].Range.Text = dtDatOpe.Rows[0]["cTipoOperacion"].ToString().Trim();
               oDoc.Bookmarks["cUsuario2"].Range.Text = dtDatOpe.Rows[0]["cWinUser"].ToString().Trim();
               oDoc.Bookmarks["dFecha2"].Range.Text = dtDatOpe.Rows[0]["dFecha"].ToString().Trim();
               oDoc.Bookmarks["dHora2"].Range.Text = dtDatOpe.Rows[0]["fHora"].ToString().Trim();
               oDoc.Bookmarks["idCuenta2"].Range.Text = dtDatOpe.Rows[0]["idCuenta"].ToString().Trim();
               oDoc.Bookmarks["nMonto2"].Range.Text = dtDatOpe.Rows[0]["cMoneda"].ToString().Trim() + string.Format("{0:0.00}", Convert.ToDecimal (dtDatOpe.Rows[0]["nMonTotal"])).Trim();
               

               oDoc.PrintOut();
               oDoc.Close(ref objFalse, ref objMissing, ref objMissing);

               this.oWord.Quit(ref objMissing, ref objMissing, ref objMissing);
               lestadoImp = true;
           }
           catch (Exception)
           {

               throw;
           }
           return lestadoImp;
        }

        public DataTable retornarDatCtaCtb(int idcuenta)
        {
            return objADOpeDep.retornarDatCtaCtb(idcuenta);
        }
        //============================================================================
        //---lISTADO DE TIPOS DE cUENTA POR PRODUCTO
        //============================================================================
        public DataTable ListaTipoCtaProd(int idProd)
        {
            return objADOpeDep.LisTipCtaProd(idProd);
        }

        //============================================================================
        //---lISTADO DE PARAMETROS DEL PRODUCTO
        //============================================================================
        public DataTable ListaParametrosProd(int idProd, int idMon, int idOpc)
        {
            return objADOpeDep.LisParamProd(idProd, idMon, idOpc);
        }

        //============================================================================
        //---lISTADO DE COMISIONES DEL PRODUCTO
        //============================================================================
        public DataTable ListaComisionProd(int idProd, int idMon)
        {
            return objADOpeDep.LisComisionProd(idProd, idMon);
        }

        //============================================================================
        //---Listado de Tipos de Persona Por Producto
        //============================================================================
        public DataTable ListaTipPersonaProd(int idProd)
        {
            return objADOpeDep.LisTipPerProd(idProd);
        }

        //============================================================================
        //---Listado de Tipos de Renovación Por Producto
        //============================================================================
        public DataTable ListaTipRenovacionProd(int idProd)
        {
            return objADOpeDep.LisTipRenovacionProd(idProd);
        }

        //============================================================================
        //---Listado de Tipos de Tipo Pago Interes Por Producto
        //============================================================================
        public DataTable ListaTipPagoInteresProd(int idProd)
        {
            return objADOpeDep.LisTipPagoInteresProd(idProd);
        }

        //============================================================================
        //---Listado de Tipos de Pago de Interes
        //============================================================================
        public DataTable LisTiposPagoInteres()
        {
            return objADOpeDep.LisTipPagoInt();
        }

        //============================================================================
        //---Listado de Tipos de Renovaciones
        //============================================================================
        public DataTable ListaTipoRenovacion()
        {
            return objADOpeDep.LisTipRenovacion();
        }

        //============================================================================
        //---Listado de Modalidades de Pago
        //============================================================================
        public DataTable ListaModalidadesPago(int ntipOpe)
        {
            return objADOpeDep.LisModPago(ntipOpe);
        }

        //============================================================================
        //---Listado de Pago de Interes por Producto
        //============================================================================
        public DataTable ListaPagoInteresProd(int idProd)
        {
            return objADOpeDep.LisPagIntProd(idProd);
        }

        //============================================================================
        //---Validar Bloqueo para Validacion
        //============================================================================
        public bool ValidarBloqueoCta(int idCta, int idTipOpe, ref string cMensaje)
        {
            bool lVal=true;
            DataTable tb = objADOpeDep.RetBloqueoCta(idCta);
            if (tb.Rows.Count>0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (Convert.ToInt32(tb.Rows[i]["idCaracteristicaBloq"])==2)  //--BLOQUEO TOTAL
                    {
                        cMensaje="LA CUENTA TIENE BLOQUEO TOTAL";
                        lVal=false;
                        break;
                    }

                    if (Convert.ToInt32(tb.Rows[i]["idTipoOperacion"]) == idTipOpe) //--BLOQUEO POR OPERACIÓN
                    {
                        
                        cMensaje = "LA CUENTA SE ENCUENTRA BLOQUEADA : " + tb.Rows[i]["cDescripcion"].ToString()+"\n";
                        if (Convert.ToInt32(tb.Rows[i]["idBloqueo"]) == 5 && Convert.ToInt32(tb.Rows[i]["idCaracteristicaBloq"]) == 4 && idTipOpe==11)//SOLO PARA RETIROS
                        {
                            cMensaje = cMensaje + tb.Rows[i]["cDesMotivo"].ToString();
                        }
                        lVal = false;
                        break;
                    }
                   
                    if (Convert.ToInt32(tb.Rows[i]["idBloqueo"]).In(1,2,3,4,6,7))
                    {
                        cMensaje = cMensaje + "LA CUENTA SE ENCUENTRA BLOQUEADA, POR MOTIVO : " + tb.Rows[i]["cDesMotivo"].ToString()+"\n";
                        lVal = true;
                        //break;
                    }
                } 
            }
            return lVal;
        }

        //============================================================================
        //---Retorna Comisiones de la Cuenta para la operacion
        //============================================================================
        public DataTable RetornaComisionesCtaOpe(int idProd, int idTipOpe, int idTipPer, int idMon, int idCta,
                                                int idCanal, int idAge, Decimal nMonto, int nPlazo, int x_idTipoPago)
        {
            return objADOpeDep.RetornaComisionesCta(idProd, idTipOpe, idTipPer, idMon, idCta,
                                                    idCanal, idAge, nMonto, nPlazo, x_idTipoPago);
        }

        //============================================================================
        //---Registra Extorno de Operaciones
        //============================================================================
        public DataTable RegistraExtornoOpe(int idKardex, int idCuenta, int idUsu, int idAge, DateTime dFechaOpe,
                                            Decimal nMonOpe, int idTipOpe, int idTippago,
                                           bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objADOpeDep.RegExtornoOpe(idKardex, idCuenta, idUsu, idAge, dFechaOpe,
                                            nMonOpe, idTipOpe, idTippago,
                                            lModificaSaldoLinea, idTipoTransac, idMon);
        }

        //============================================================================
        //---Lista Documentos Valorados
        //============================================================================
        public DataTable ListaDocsValorados(int idTipVal, int idAge)
        {
            return objADOpeDep.ListaDocsValorados(idTipVal, idAge);
        }

        //============================================================================
        //---Lista Tipo de Valorados
        //============================================================================
        public DataTable ListaTipoValorados()
        {
            return objADOpeDep.ListaTipoValorados();
        }

        //============================================================================
        //---Retorna Nro Operaciones Posteriores a la Apertura
        //============================================================================
        public DataTable RetornaNroOpePostExt(int idKardex, int idCuenta)
        {
            return objADOpeDep.ListaNroOPePosterioresApe(idKardex, idCuenta);
        }
        //============================================================================
        //---Retorna la lsita de modalidades de operacion con los tipos de operación
        //============================================================================
        public clsListaModPagoOperacion ListaModPagoOperacion()
        {
            DataTable dtModOpe = objADOpeDep.LisModPagoOperaciones();
            clsListaModPagoOperacion lstModPago = new clsListaModPagoOperacion();
            foreach (DataRow nRow in dtModOpe.Rows)
            {
                lstModPago.Add(new clsModPagoOperacion()
                {
                    idTipoPago = Convert.ToInt32(nRow["idTipoPago"]),
                    cDesTipoPago = nRow["cDesTipoPago"].ToString(),
                    lOpeApertura = Convert.ToBoolean(nRow["lOpeApertura"]),
                    lOpePagoComPago = Convert.ToBoolean(nRow["lOpePagoComPago"]),
                    lOpeRetiro = Convert.ToBoolean(nRow["lOpeRetiro"]),
                    lPagoCredito = Convert.ToBoolean(nRow["lPagoCredito"]),
                    lOpeDeposito = Convert.ToBoolean(nRow["lOpeDeposito"]),
                    lOpeCancelacion = Convert.ToBoolean(nRow["lOpeCancelacion"])
                });
            }
            return lstModPago;
        }
        //============================================================================
        //---Graba la Modalidade de pago por tipos de operación
        //============================================================================
        public DataTable GrabarModPagoOperacion(string xmlModPagOperacion)
        {

            return new clsADOperacionDep().GrabarModPagoOperaciones(xmlModPagOperacion);
        }
    }
}

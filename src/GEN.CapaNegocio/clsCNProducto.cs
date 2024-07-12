using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsCNProducto
    {
        public clsADProducto objProducto;

        public clsCNProducto()
        {
            objProducto = new clsADProducto();
        }

        public clsCNProducto(bool lWS)
        {
            objProducto = new clsADProducto(lWS);
        }


        public static DataTable dtProducto;
        public static DataTable dtNivelProducto;

        /// <summary>
        /// Lista los productos
        /// </summary>
        /// <param name="cCodPro">codigo del producto</param>
        /// <param name="lVigente">en el caso que se requiera los productos vigentes lVigente debe tener el valor de true, en caso contrario se lista los parametros que son configurables</param>
        /// <returns></returns>
        public DataTable listarProducto(Int32 cCodPro, bool lVigente, bool lConfigurable = true, int idOperacion = 0)
        {
            if (dtProducto == null)
            {
                dtProducto = objProducto.ListarProductoXml();
                dtProducto.AsEnumerable().ToList().Where(X => X["IdProductoPadre"] == DBNull.Value).ToList().ForEach(y => y["IdProductoPadre"] = 0);
            }

            var dt = dtProducto;

            DataTable dtProductoAux = dt.Clone();
            DataRow drTodas = dtProductoAux.NewRow();

            drTodas["IdProducto"] = 0;
            drTodas["cCuentaContable"] = "";
            drTodas["cProducto"] = "";
            drTodas["IdProductoPadre"] = 0;
            drTodas["lVigente"] = true;
            drTodas["idModulo"] = 0;
            drTodas["cCodSBS"] = "";

            dtProductoAux.Rows.Add(drTodas);
            if(idOperacion.In(3)) //REPROGRAMACION
            {
                (from item in dt.AsEnumerable()
                 where (int)item["IdProductoPadre"] == cCodPro
                 orderby item["cProducto"]
                 select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);

 

            }
            else if (lVigente)
            {
                (from item in dt.AsEnumerable()
                 where (bool)item["lVigente"] == true
                 && (int)item["IdProductoPadre"] == cCodPro
                 orderby item["cProducto"]
                 select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges); 
            }
            else
            {
                if (lConfigurable)
                {
                    (from item in dt.AsEnumerable()
                     where (bool)item["lConfigurable"] == true
                     && (int)item["IdProductoPadre"] == cCodPro
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
                else
                {
                    (from item in dt.AsEnumerable()
                     where (int)item["IdProductoPadre"] == cCodPro
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
            }
            return dtProductoAux;
        }
        /// <summary>
        /// Lista Tipo credito - Sub Productos
        /// </summary>
        /// <param name="cCodPro">codigo del producto</param>
        /// <param name="lVigente">en el caso que se requiera los productos vigentes lVigente debe tener el valor de true, en caso contrario se lista los parametros que son configurables</param>
        /// <returns></returns>
        public DataTable listarTipoCreditoProducto(Int32 cCodPro, bool lVigente, bool lConfigurable = true, int idOperacion = 0)
        {
            if (dtProducto == null)
            {
                dtProducto = objProducto.ListarProductoXml();
                dtProducto.AsEnumerable().ToList().Where(X => X["IdProductoPadre"] == DBNull.Value).ToList().ForEach(y => y["IdProductoPadre"] = 0);
            }

            var dt = dtProducto;

            DataTable dtProductoAux = dt.Clone();
            DataRow drTodas = dtProductoAux.NewRow();

            drTodas["IdProducto"] = 0;
            drTodas["cCuentaContable"] = "";
            drTodas["cProducto"] = "";
            drTodas["IdProductoPadre"] = 0;
            drTodas["lVigente"] = true;
            drTodas["idModulo"] = 0;
            drTodas["cCodSBS"] = "";

            dtProductoAux.Rows.Add(drTodas);
            if (idOperacion.In(3)) //REPROGRAMACION
            {
                (from item in dt.AsEnumerable()
                 where (int)item["IdProductoPadre"] == cCodPro
                 orderby item["cProducto"]
                 select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);



            }
            else if (lVigente)
            {
     

                var results = from TipCre in dt.AsEnumerable()
                              join SubTipCre in dt.AsEnumerable() on (int)TipCre["IdProducto"] equals (int)SubTipCre["IdProductoPadre"]
                              join Producto in dt.AsEnumerable() on (int)SubTipCre["IdProducto"] equals (int)Producto["IdProductoPadre"]
                              join SubProducto in dt.AsEnumerable() on (int)Producto["IdProducto"] equals (int)SubProducto["IdProductoPadre"]
                              where (int)TipCre["IdProductoPadre"] == cCodPro && Convert.ToBoolean(SubProducto["lVigente"].ToString()) == true
                              orderby TipCre["cProducto"]
                              select new
                              {
                                  IdProducto = SubProducto["IdProducto"],
                                  cCuentaContable = "",
                                  cProducto = (TipCre["cProducto"] + " - " + Producto["cProducto"] + " - " + SubProducto["cProducto"]),
                                  IdProductoPadre = (int)TipCre["IdProducto"],
                                  lVigente = SubProducto["lVigente"],
                                  idModulo = SubProducto["idModulo"],
                                  cCodSBS = SubProducto["cCodSBS"]
                              };

                dtProductoAux = results.ToDataTable();




                //     return results;  

            }
            else
            {
                if (lConfigurable)
                {
                    (from item in dt.AsEnumerable()
                     where (bool)item["lConfigurable"] == true
                     && (int)item["IdProductoPadre"] == cCodPro
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
                else
                {
                    (from item in dt.AsEnumerable()
                     where (int)item["IdProductoPadre"] == cCodPro
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
            }
            return dtProductoAux;
        }
        /// <summary>
        /// Lista los productos
        /// </summary>
        /// <param name="cCodPro">codigo del producto</param>
        /// <param name="lVigente">en el caso que se requiera los productos vigentes lVigente debe tener el valor de true, en caso contrario se lista los parametros que son configurables</param>
        /// <returns></returns>
        public DataTable listarProductos(List<int> CodProductos, bool lVigente, bool lConfigurable = true, int idOperacion = 0)
        {
            if (dtProducto == null)
            {
                dtProducto = objProducto.ListarProductoXml();
                dtProducto.AsEnumerable().ToList().Where(X => X["IdProductoPadre"] == DBNull.Value).ToList().ForEach(y => y["IdProductoPadre"] = 0);
            }

            var dt = dtProducto;

            DataTable dtProductoAux = dt.Clone();
            DataRow drTodas = dtProductoAux.NewRow();

            drTodas["IdProducto"] = 0;
            drTodas["cCuentaContable"] = "";
            drTodas["cProducto"] = "";
            drTodas["IdProductoPadre"] = 0;
            drTodas["lVigente"] = true;
            drTodas["idModulo"] = 0;
            drTodas["cCodSBS"] = "";

            dtProductoAux.Rows.Add(drTodas);
             
            if (idOperacion.In(3)) //REPROGRAMACION
            {
                (from item in dt.AsEnumerable()
                 where CodProductos.Contains((int)item["IdProductoPadre"])
                 orderby item["cProducto"]
                 select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
            }
            else if (lVigente)
            {
                (from item in dt.AsEnumerable()
                 where (bool)item["lVigente"] == true
                 && CodProductos.Contains((int)item["IdProductoPadre"])  
                 orderby item["cProducto"]
                 select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
            }
            else
            {
                if (lConfigurable)
                {
                    (from item in dt.AsEnumerable()
                     where (bool)item["lConfigurable"] == true
                     && CodProductos.Contains((int)item["IdProductoPadre"])   
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
                else
                {
                    (from item in dt.AsEnumerable()
                     where CodProductos.Contains((int)item["IdProductoPadre"])
                     orderby item["cProducto"]
                     select item).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
                }
            }
            return dtProductoAux;
        }
        public DataTable CNListarProductoAbonoMasivo()
        {
            //return objProducto.ListarProductoAbonoMasivo();
            var dt = objProducto.ListarProductoAbonoMasivoXml();

            DataTable dtProucto = dt.Clone();
            DataRow drTodas = dtProucto.NewRow();

            drTodas["IdProducto"] = 0;
            drTodas["cCuentaContable"] = "";
            drTodas["cProducto"] = "";
            drTodas["IdProductoPadre"] = 0;
            drTodas["lVigente"] = true;
            drTodas["idModulo"] = 0;
            drTodas["cCodSBS"] = "";


            dtProucto.Rows.Add(drTodas);

            foreach (DataRow item in dt.Rows)
            {
                if (item["IdProductoPadre"] == DBNull.Value)
                {
                    item["IdProductoPadre"] = 0;
                }
            }

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             && ((int)item["IdProductoPadre"]).In(17, 25)
             orderby item["cProducto"]
             select item).CopyToDataTable(dtProucto, LoadOption.OverwriteChanges);

            return dtProucto;
        }

        public DataTable ListarNivelProducto()
        {
            if (dtNivelProducto == null)
            {
                dtNivelProducto = objProducto.ListarNivelProductoXml();
            }

            var dt = dtNivelProducto;
            DataTable dtProucto = dt.Clone();
            (from item in dt.AsEnumerable()
             select item).CopyToDataTable(dtProucto, LoadOption.OverwriteChanges);

            return dtProucto;
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin en los campos de listar
        /// </summary>
        /// <param name="idModulo"></param>
        /// <param name="idNivelProd"></param>
        /// <returns></returns>
        public DataTable ListarProductoModNivel(Int32 idModulo, Int32 idNivelProd, String cIdsProductos = "")
        {
            return objProducto.ListarProductoModNivel(idModulo, idNivelProd, cIdsProductos);
        }

        public DataTable ListarProductoModNivelRec(Int32 idModulo, Int32 idNivelProd)
        {

            return objProducto.ListarProductoModNivelRec(idModulo, idNivelProd);
        }
        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin para la insercion en la tabla
        /// </summary>
        /// <param name="cProducto"></param>
        /// <param name="IdProductoPadre"></param>
        /// <param name="lVigente"></param>
        /// <param name="idModulo"></param>
        /// <param name="dVigenciaInicio"></param>
        /// <param name="dVigenciaFin"></param>
        /// <returns></returns>
        public DataTable CNInsertarProducto(string cProducto, int IdProductoPadre, bool lVigente, int idModulo, string dVigenciaInicio, string dVigenciaFin,
                                            bool lConfigurable, int idFuenteCalcMora)
        {
            return objProducto.ADInsertarProducto(cProducto, IdProductoPadre, lVigente, idModulo, dVigenciaInicio, dVigenciaFin,
                                                lConfigurable, idFuenteCalcMora);
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin para la actualizacion adicional de estos campos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="cProducto"></param>
        /// <param name="lVigente"></param>
        /// <param name="dVigenciaInicio"></param>
        /// <param name="dVigenciaFin"></param>
        /// <returns></returns>
        public DataTable CNActualizarproducto(int IdProducto, string cProducto, bool lVigente, string dVigenciaInicio, string dVigenciaFin,
                                            bool lConfigurable, int idFuenteCalcMora)
        {
            return objProducto.ADActualizarproducto(IdProducto, cProducto, lVigente, dVigenciaInicio, dVigenciaFin,
                                                    lConfigurable, idFuenteCalcMora);
        }

        public DataTable CNListarProductoNivelesSup(int idProducto)
        {
            return objProducto.ADListarProductoNivelesSup(idProducto);
        }

        public DataTable CNListarProductoxNivel(string xmlProductos, int nNivel, int idModulo)
        {
            return objProducto.ADListarProductoxNivel(xmlProductos, nNivel, idModulo);
        }

        public DataTable CNListaNivelesSupProductos(int idModulo, int idProducto, int lResultado = 0)
        {
            return objProducto.ADListaNivelesSupProductos(idModulo, idProducto, lResultado);
        }

        public DataTable CNListarProductoPorCampana(int idGrupoCamp)
        {
            return objProducto.ADListarProductoPorCampana(idGrupoCamp);
        }

        public DataTable CNListarSubProducto()
        {
            return objProducto.ADListarSubProducto();
        }

        public DataTable CNListaProductos()
        {
            return objProducto.ADListaProductos();
        }

        public DataTable CNComprobarProductCamp(int idProducto)
        {
            return objProducto.ADComprobarProductCamp(idProducto);
        }
        public DataTable SubProductoxTipoCredito(int idTipoCredito, int idModulo)
        {
            return objProducto.SubProductoxTipoCredito(idTipoCredito, idModulo);
        }

        public clsProductoCredSimp CNRecuperarProductoDetalle(int idProducto)
        {
            DataTable dtProductoDetalle = objProducto.CNRecuperarProductoDetalle(idProducto);
            List<clsProductoCredSimp> lstProducto = (dtProductoDetalle.Rows.Count > 0) ? dtProductoDetalle.ToList<clsProductoCredSimp>() as List<clsProductoCredSimp> : new List<clsProductoCredSimp>();

            return (lstProducto.Count > 0) ? lstProducto[0] : new clsProductoCredSimp();
        }

        public DataTable CNlistarIdProducto(string cCodigosPro)
        {
            DataTable dtListProductos = new DataTable();
            dtListProductos.Columns.Add("idProducto", typeof(String));
            dtListProductos.Columns.Add("cProducto", typeof(String));

            string[] cProductos = cCodigosPro.Split(',');
            string cExpresion = "";

            for (int i = 0; i < cProductos.Count() ; i++ )
            {
                if(i != 0)
                {
                    cExpresion += " OR ";
                }
                cExpresion += "IdProducto = '" + cProductos[i] + "'";
            }

            if (dtProducto == null)
            {
                dtProducto = objProducto.ListarProductoXml();
            }

            DataRow[] drListProductos;
            drListProductos = dtProducto.Select(cExpresion);

            for (int i = 0; i < drListProductos.Length; i++)
            {
                dtListProductos.Rows.Add(drListProductos[i]["IdProducto"].ToString(), drListProductos[i]["cProducto"].ToString());
            }

            return dtListProductos;

        }

        public DataTable CNCargarProductoNivelTipEvalCred(string cIDsTipEvalCred, int nNivel, int idProducto)
        {
            DataTable dtProducto = objProducto.ADCargarProductoNivelTipEvalCred(cIDsTipEvalCred, nNivel, idProducto);

            var dt = dtProducto;

            DataTable dtProductoAux = dt.Clone();
            DataRow drTodas = dtProductoAux.NewRow();

            drTodas["IdProducto"] = 0;
            drTodas["cProducto"] = "";

            dtProductoAux.Rows.Add(drTodas);
            
            (dt.AsEnumerable()).CopyToDataTable(dtProductoAux, LoadOption.OverwriteChanges);
            
            return dtProductoAux;
        }
    }
}

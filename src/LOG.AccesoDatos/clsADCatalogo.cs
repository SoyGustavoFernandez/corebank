using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADCatalogo
    {

        public clsLstGrupoActivo buscarGrupoActivo(int idTipoBien, int idPadre)
        {
            clsLstGrupoActivo lstActivo = new clsLstGrupoActivo();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarGrupoActivo_SP", idTipoBien, idPadre);

            foreach (DataRow item in ds.Rows)
            {
                lstActivo.Add(new clsGrupoActivo()
                {
                    cNombreGrupo = item["cNombreGrupo"].ToString(),
                    idGrupoActivo = Convert.ToInt32(item["idGrupoActivo"].ToString()),
                    idPadre = Convert.ToInt32(item["idPadre"].ToString()),
                    idTipoBien = Convert.ToInt32(item["idTipoBien"].ToString()),
                    lvigente = Convert.ToBoolean(item["lvigente"].ToString()),
                    nOrden = Convert.ToInt32(item["nOrden"].ToString()),
                    cContable = item["cCuentaContable"].ToString()
                });
            }
            return lstActivo;
        }

        public DataTable ADBuscarCatalogoxId(int idCatalogo)
        {
            return new clsGENEjeSP().EjecSP("LOG_BuscarCatalogoXId_sp", idCatalogo);
        }

        public DataTable ADGrabarNuevoCatalogo(string cProducto, int idTipoBien, int idGrupo, bool lVigente,
                                               int idUnidadCompra, int idUnidadAlmacenaje, decimal nValConversion,
                                               int idUsuReg, DateTime dFechaReg, bool lIndActivo, int idEstado)
        {
            return new clsGENEjeSP().EjecSP("LOG_InsCatalogo_Sp", cProducto, idTipoBien, idGrupo, lVigente,
                                                                  idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                                  idUsuReg, dFechaReg, lIndActivo, idEstado);
        }

        public DataTable ADGrabarEdicionCatalogo(int idCatalogo, string cProducto, int idTipoBien, int idGrupo, bool lVigente,
                                              int idUnidadCompra, int idUnidadAlmacenaje, decimal nValConversion,
                                              int idUsuMod, DateTime dFechaMod, bool lIndActivo, int idEstado)
        {
            return new clsGENEjeSP().EjecSP("LOG_UpdCatalogo_Sp", idCatalogo, cProducto, idTipoBien, idGrupo, lVigente,
                                                                  idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                                  idUsuMod, dFechaMod, lIndActivo, idEstado);
        }

        public DataTable ADGrabarGrupoCatalogo(int idGrupoActivo, string cNombreGrupo, int idPadre,
                                             int idTipoBien, bool lvigente, string cCuentaContable)
        {
            return new clsGENEjeSP().EjecSP("LOG_GrabaGrupoActivo_Sp", idGrupoActivo, cNombreGrupo, idPadre,
                                                                idTipoBien, lvigente, cCuentaContable);
        }

        public List<clsCatalogo> ADBuscarCatalogoxGrupo(string cFiltro, int idAlmacen, int idTipoBien, int idSubTipo, int idGrupo, int idSubGrupo, int idMoneda)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_BuscarCatalogo_sp", cFiltro,idAlmacen, idTipoBien, idSubTipo, idGrupo, idSubGrupo, idMoneda);
            List<clsCatalogo> LstCatalogo = MapeaTablaEntidadCatalogo(dtResult);
            return LstCatalogo;
        }

        private List<clsCatalogo> MapeaTablaEntidadCatalogo(DataTable dtResult)
        {
            List<clsCatalogo> LstCatalogo = new List<clsCatalogo>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsCatalogo objCatalogo = new clsCatalogo();
                objCatalogo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objCatalogo.cNombreGrupo = Convert.ToString(row["cNombreGrupo"]);
                objCatalogo.cProducto = Convert.ToString(row["cProducto"]);
                objCatalogo.idGrupo = Convert.ToInt32(row["idGrupo"]);
                objCatalogo.idTipoBien = Convert.ToInt32(row["idTipoBien"]);
                objCatalogo.nValConversion = Convert.ToDecimal(row["nValConversion"]);
                objCatalogo.idUnidadAlmacenaje = Convert.ToInt32(row["idUnidadAlmacenaje"]);
                objCatalogo.cUnidAlmacenaje = Convert.ToString(row["cUnidAlmacenaje"]);
                objCatalogo.idUnidadCompra = Convert.ToInt32(row["idUnidadCompra"]);
                objCatalogo.cUnidCompra = Convert.ToString(row["cUnidCompra"]);
                objCatalogo.nPrecioUnit = row["nPrecioUnit"] == DBNull.Value ? 0m : Convert.ToDecimal(row["nPrecioUnit"]);
                objCatalogo.nCantidadTotal = Convert.ToDecimal(row["nCantidad"]);
                objCatalogo.nCantidadFisico = Convert.ToDecimal(row["nCantidadFisico"]);
                objCatalogo.nCantidadVirtual = Convert.ToDecimal(row["nCantidadVirtual"]);
                LstCatalogo.Add(objCatalogo);
            }

            return LstCatalogo;
        }


        public DataTable RetornaCuentaCtbGrupoBien(int idGrupoActivo)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaCuentaCtbGrupoBien_SP", idGrupoActivo);
        }

        public DataTable InsActCuentaCtbGrupoBien(int idGrupoActivo, string cDescripcion, int idTipoOperacion, int idTipoIngresoEgreso, int idTipoBien, int idDestino, int idEstado, string cDebe, string cHaber)
        {
            return new clsGENEjeSP().EjecSP("LOG_InsActCuentaCtbGrupoBien_SP", idGrupoActivo,cDescripcion, idTipoOperacion, idTipoIngresoEgreso, idTipoBien, idDestino, idEstado, cDebe, cHaber);
        }

        public DataTable ADCambiarFamiliaBienes(int idGrupoActivo, clsNotaSalida objBienes)
        {
            return new clsGENEjeSP().EjecSP("LOG_CambiarFamiliaBienes_SP", idGrupoActivo, objBienes.LstDetNotSalida.GetXml<clsDetNotaSalida>());
        }
    }
}

using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNCatalogo
    {
        public clsLstGrupoActivo buscaGrupoActivo(int idTipoBien, int idPadre)
        {
            return new clsADCatalogo().buscarGrupoActivo(idTipoBien, idPadre);
        }
        public DataTable buscarDatosCatalogoXid(int idCatalogo)
        {
            return new clsADCatalogo().ADBuscarCatalogoxId(idCatalogo);
        }
        public DataTable GrabarNuevoCatalogo(string cProducto, int idTipoBien, int idGrupo, bool lVigente,
                                             int idUnidadCompra, int idUnidadAlmacenaje, decimal nValConversion,
                                             int idUsuReg, DateTime dFechaReg, bool lIndActivo, int idEstado)
        {
            return new clsADCatalogo().ADGrabarNuevoCatalogo(cProducto, idTipoBien, idGrupo, lVigente,
                                                               idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                               idUsuReg, dFechaReg, lIndActivo, idEstado);
        }
        public DataTable GrabarEdicionCatalogo(int idCatalogo, string cProducto, int idTipoBien, int idGrupo, bool lVigente,
                                            int idUnidadCompra, int idUnidadAlmacenaje, decimal nValConversion,
                                            int idUsuMod, DateTime dFechaMod, bool lIndActivo, int idEstado)
        {
            return new clsADCatalogo().ADGrabarEdicionCatalogo(idCatalogo, cProducto, idTipoBien, idGrupo, lVigente,
                                                               idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                               idUsuMod, dFechaMod, lIndActivo, idEstado);
        }
        public DataTable GrabarGrupoCatalogo(int idGrupoActivo, string cNombreGrupo, int idPadre,
                                              int idTipoBien, bool lvigente, string cCuentaContable)
        {
            return new clsADCatalogo().ADGrabarGrupoCatalogo(idGrupoActivo, cNombreGrupo, idPadre,
                                                                 idTipoBien, lvigente, cCuentaContable);
        }

        public List<clsCatalogo> CNBuscarCatalogoxGrupo(string cFiltro, int idAlmacen, int idTipoBien, int idSubTipo, int idGrupo, int idSubGrupo, int idMoneda)
        {
            return new clsADCatalogo().ADBuscarCatalogoxGrupo(cFiltro,idAlmacen, idTipoBien, idSubTipo, idGrupo, idSubGrupo, idMoneda);
        }

        public DataTable RetornaCuentaCtbGrupoBien(int idGrupoActivo)
        {
            return new clsADCatalogo().RetornaCuentaCtbGrupoBien(idGrupoActivo);
        }

        public DataTable InsActCuentaCtbGrupoBien(int idGrupoActivo, string cDescripcion, int idTipoOperacion, int idTipoIngresoEgreso, int idTipoBien, int idDestino, int idEstado, string cDebe, string cHaber)
        {
            return new clsADCatalogo().InsActCuentaCtbGrupoBien(idGrupoActivo, cDescripcion, idTipoOperacion, idTipoIngresoEgreso, idTipoBien, idDestino, idEstado, cDebe, cHaber);
        }

        public DataTable CNCambiarFamiliaBienes(int idGrupoActivo, clsNotaSalida objBienes)
        {
            return new clsADCatalogo().ADCambiarFamiliaBienes(idGrupoActivo, objBienes);
        }
    }
}

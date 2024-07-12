using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityLayer
{
    public class clsHistoricoSegurosOptativos
    {
        public List<clsFrmEditarSeguroOptativo> objSeguroOptativoAnterior { get; set; }
        public List<clsFrmEditarSeguroOptativo> objSeguroOptativoNuevo { get; set; }
    }

    public class clsFrmEditarSeguroOptativo
    {
        public int nTipoSeguro { get; set; }
        public string cTipoSeguro { get; set; }
        public decimal nPrimaSeguro { get; set; }
        public int nTipoValor { get; set; }
        public string cTipoValor { get; set; }
        public int nConceptoRecibo { get; set; }
        public string cConceptoRecibo { get; set; }
        public int nTipoPago { get; set; }
        public string cTipoPago { get; set; }
        public bool lVigente { get; set; }
        public string cModificacion { get; set; }
        public AccionHistorico idAccion { get; set; }
        public List<PlanesSeguroOptativo> lstPlanSeguroOptativo { get; set; }
        public List<Productos> lstProducto { get; set; }
        public List<Perfiles> lstPerfil { get; set; }
        public List<Agencias> lstAgencia { get; set; }

        public clsFrmEditarSeguroOptativo()
        {
            cModificacion = string.Empty;
        }

        public clsFrmEditarSeguroOptativo Clonar()
        {
            return new clsFrmEditarSeguroOptativo
            {
                nTipoSeguro = this.nTipoSeguro,
                cTipoSeguro = this.cTipoSeguro,
                nPrimaSeguro = this.nPrimaSeguro,
                nTipoValor = this.nTipoValor,
                cTipoValor = this.cTipoValor,
                nConceptoRecibo = this.nConceptoRecibo,
                cConceptoRecibo = this.cConceptoRecibo,
                nTipoPago = this.nTipoPago,
                cTipoPago = this.cTipoPago,
                lVigente = this.lVigente,
                cModificacion = this.cModificacion,
                idAccion = this.idAccion,
                lstPlanSeguroOptativo = this.lstPlanSeguroOptativo != null ? this.lstPlanSeguroOptativo.Select(plan => plan.Clonar()).ToList() : null,
                lstProducto = this.lstProducto != null ? this.lstProducto.Select(producto => producto.Clonar()).ToList() : null,
                lstPerfil = this.lstPerfil != null ? this.lstPerfil.Select(perfil => perfil.Clonar()).ToList() : null,
                lstAgencia = this.lstAgencia != null ? this.lstAgencia.Select(agencia => agencia.Clonar()).ToList() : null
            };
        }

    }
    public class PlanesSeguroOptativo
    {
        public int nTipoPlan { get; set; }
        public int nTipoSeguro { get; set; }
        public decimal nPrecio { get; set; }
        public int nMeses { get; set; }
        public string cFijo { get; set; }
        public string cSolicitud { get; set; }
        public string cRedondear { get; set; }
        public string cDescripcion { get; set; }
        public string cModificacion { get; set; }

        public PlanesSeguroOptativo()
        {
            cModificacion = string.Empty;
        }

        public PlanesSeguroOptativo Clonar()
        {
            return new PlanesSeguroOptativo
            {
                nTipoPlan = this.nTipoPlan,
                nTipoSeguro = this.nTipoSeguro,
                nPrecio = this.nPrecio,
                nMeses = this.nMeses,
                cFijo = this.cFijo,
                cSolicitud = this.cSolicitud,
                cRedondear = this.cRedondear,
                cDescripcion = this.cDescripcion,
                cModificacion = this.cModificacion,
            };
        }
    }

    public class Productos
    {
        public int nTipoSeguro { get; set; }
        public int nSubProducto { get; set; }
        public string cAutorizado { get; set; }
        public string cModificacion { get; set; }
        
        public Productos()
        {
            cModificacion = string.Empty;
        }

        public Productos Clonar()
        {
            return new Productos
            {
                nTipoSeguro = this.nTipoSeguro,
                nSubProducto = this.nSubProducto,
                cAutorizado = this.cAutorizado,
                cModificacion = this.cModificacion
            };
        }
    }

    public class Perfiles
    {
        public int nTipoSeguro { get; set; }
        public int nPerfil { get; set; }
        public string cAutorizado { get; set; }
        public string cModificacion { get; set; }
        
        public Perfiles()
        {
            cModificacion = string.Empty;
        }

        public Perfiles Clonar()
        {
            return new Perfiles
            {
                nTipoSeguro = this.nTipoSeguro,
                nPerfil = this.nPerfil,
                cAutorizado = this.cAutorizado,
                cModificacion = this.cModificacion
            };
        }
    }

    public class Agencias
    {
        public int nTipoSeguro { get; set; }
        public int nAgencia { get; set; }
        public string cAutorizado { get; set; }
        public string cModificacion { get; set; }

        public Agencias()
        {
            cModificacion = string.Empty;
        }

        public Agencias Clonar()
        {
            return new Agencias
            {
                nTipoSeguro = this.nTipoSeguro,
                nAgencia = this.nAgencia,
                cAutorizado = this.cAutorizado,
                cModificacion = this.cModificacion
            };
        }
    }

    public enum AccionHistorico : int
    {
        NINGUNA = 0,
        AGREGAR = 1,
        EDITAR = 2,
        ELIMINAR = 3
    }

    #region Entidades de BD - Se utilizará para mapear el xml
    public class SI_FINHSeguroOptativoCabecera
    {
        public int? nTipoSeguro { get; set; }
        public string cTipoSeguro { get; set; }
        public string cTipoSeguroMod { get; set; }
        public decimal? nPrimaSeguro { get; set; }
        public decimal? nPrimaSeguroMod { get; set; }
        public int? nTipoValor { get; set; }
        public int? nTipoValorMod { get; set; }
        public int? nConceptoRecibo { get; set; }
        public int? nConceptoReciboMod { get; set; }
        public int? nTipoPago { get; set; }
        public int? nTipoPagoMod { get; set; }
        public bool? lVigente { get; set; }
        public bool? lVigenteMod { get; set; }
        public string cModificacion { get; set; }
        public int? idAccion { get; set; }
        public int? idUsuario { get; set; }
        public List<SI_FINDSeguroOptativoProductos> lstProductos { get; set; }
        public List<SI_FINDSeguroOptativoPerfiles> lstPerfiles { get; set; }
        public List<SI_FINDSeguroOptativoAgencias> lstAgencias { get; set; }
        public List<SI_FINDSeguroOptativoPlanes> lstPlanes { get; set; }
    }

    public class SI_FINDSeguroOptativoProductos
    {
        public int? nTipoSeguro { get; set; }
        public int? nSubProducto { get; set; }
        public int? nSubProductoMod { get; set; }
        public string cAutorizado { get; set; }
        public string cAutorizadoMod { get; set; }
    }

    public class SI_FINDSeguroOptativoPerfiles
    {
        public int? nTipoSeguro { get; set; }
        public int? nPerfil { get; set; }
        public int? nPerfilMod { get; set; }
        public string cAutorizado { get; set; }
        public string cAutorizadoMod { get; set; }
    }

    public class SI_FINDSeguroOptativoAgencias
    {
        public int? nTipoSeguro { get; set; }
        public int? nAgencia { get; set; }
        public int? nAgenciaMod { get; set; }
        public string cAutorizado { get; set; }
        public string cAutorizadoMod { get; set; }
    }

    public class SI_FINDSeguroOptativoPlanes
    {
        public int? nTipoPlan { get; set; }
        public int? nTipoSeguro { get; set; }
        public decimal? nPrecio { get; set; }
        public decimal? nPrecioMod { get; set; }
        public string cFijo { get; set; }
        public string cFijoMod { get; set; }
        public string cSolicitud { get; set; }
        public string cSolicitudMod { get; set; }
        public string cRedondear { get; set; }
        public string cRedondearMod { get; set; }
        public int? nMeses { get; set; }
        public int? nMesesMod { get; set; }
        public string cDescripcion { get; set; }
        public string cDescripcionMod { get; set; }
    }

    #endregion
}
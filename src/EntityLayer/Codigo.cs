using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EEFF
    {
        public static int TotalActivo = 2;
        public static int TotalAcCorriente = 3;
        public static int Caja = 4;

        public static int Inventario = 8;
        public static int TotalAcNoCorriente = 9;
        public static int Inmuebles = 10;
        public static int MaqEquipos = 11;
        public static int HerramOtros = 12;
        public static int TotalPasivo = 13;
        public static int TotalPaCorriente = 14;

        public static int PrestamosCP = 18;
        public static int TotalPaNoCorriente = 19;
        public static int PrestamosLP = 20;
        public static int TotalPatrimonio = 21;
        public static int TotalPasivoPatrimonio = 22;
        public static int VentasNetas = 24;
        public static int CostoVentas = 25;
        public static int UtilidadBruta = 26;
        public static int GastosNegocio = 27;
        public static int UtilidadOperativa = 28;
        public static int GastosFinancieros = 29;
        public static int UtilidadNeta = 30;
        public static int OtrosIngresos = 31;
        public static int OtrosEgresos = 32;
        public static int GastosFamiliares = 33;
        public static int UtilidadDisponible = 34;

        // detalle de consumo
        public static int IngNetTitular = 35;
        public static int IngNetConyuge = 36;
        public static int CanastaFamiliar = 37;
        public static int ServBasicos = 38;
        public static int AlquilerePensiones = 39;
        public static int CuotaOtroPrestamos = 40;
        // detalle pyme
        public static int GastosOperativos = 41;
        public static int GastosPersonales = 42;

        public static int VariacionGFamiliares = 43;
        public static int CicloVentas = 44;
        public static int Reinversiones = 45;

        // detalle convenio
        public static int DescuentoJudicial = 46;
        public static int DescuentoLegales = 47;
        public static int CuotaCredDirectos = 48;
        public static int ProvCredInDirectos = 49;
        public static int CuotaMaxEndeuda = 50;

        //consumo cambios
        public static int TotalIngNetos = 51;
        public static int SaldoNeto = 52;
        public static int SaldoDisponible = 53;
        public static int CuotaMaxEndeudaConsumo = 54;
        public static int CuotaCredDir = 55;
        public static int ProvCredIndir = 56;
        public static int CuotaMaxDiponible = 57;
        public static int IngresoDisponible = 58;

        //BBGG - Agricola
        public static int AdelantoProv = 60;
        public static int OtrosAC = 61;
        public static int ActBiologico = 62;
        public static int Vehiculos = 63;
        public static int OtrosANC = 64;
        public static int OtrosPC = 65;
        public static int OtrosPNC = 66;
        public static int Efectivo = 69;
        public static int Aporte = 70;
        public static int Insumos = 71;
        public static int ProductosProceso = 72;
        public static int ProductosTerminado = 73;
        public static int OtrasDeudasCortoPlazo = 74;
        public static int PatrimonioFamiempresa = 75;

        //EERR - CrediJornal
        public static int IngresoJrnlTitular    = 67;
        public static int IngresoJrnlCónyuge    = 68;
        public static int GastosJrnlFinancieros = 29;
        public static int GastosJrnlFamiliares  = 33;

        //EERR - Pyme Estacional 
        public static int LuzAguaTelefono = 69;
        public static int Transporte = 70;
        public static int Impuestos = 71;
        public static int AlquilerLocal = 72;
        public static int OtrosGastos = 73;
        public static int GastosDelPersonal = 74;
        public static int ExcedenteMensualFamiliar = 75;
    }

    public class DEINGREGRE
    {
        public static int Titular = 1;
        public static int Conyuge = 2;
        public static int CanastaFamiliar = 3;
        public static int ServBasicos = 4;
        public static int AlquilerePensiones = 5;
        public static int OtrosEgresos = 6;
        public static int OtrosIngresos = 7;

        public static int IngresosBrutos = 8;
        public static int DescuentosJudiciales = 9;
        public static int DescuentosLegales = 10;
    }

    public class DetalleEstRes
    {
        public static int ActividadPecuario = 3;
        public static int ActividadComercial = 4;
        public static int OtrosIngresos = 5;
        public static int AportePropio = 6;
        public static int PrestamoCracLasa = 7;

        public static int OtrosCostos = 8;
        public static int PagoCreditoCracLasa = 9;
        public static int PagoOtrasDeudas = 10;
        public static int GastosFamiliares = 11;
        public static int ActividadAgricola = 12;
    }

    public class RCC
    {
        public static int IngresosMN = 1;
        public static int IngresosME = 2;
        public static int EgresosMN = 3;
        public static int EgresosME = 4;
        public static int Disponible = 5;
        public static int CapacidadPago = 6;
    }

    public class IFN
    {
        public static int PtjeEvalCualitativa = 1;

        public static int EndeudamientoTotal = 3;
        public static int RentabilidadInver = 4;
        public static int RotacionInventarios = 5;
        public static int CapacidadPago = 6;
        public static int IncrementoCapital = 7;
        public static int EndSegunHato = 8;
        public static int CapitalTrabajo = 9;
        public static int EndeudamientoPatrimonial = 10;
        public static int EndeudamientoPatrimonialProy = 3;
        public static int DependenciaOtrosIngresos = 11;
        public static int CuotaMaximaPropuesta = 12;
        public static int CoberturaDeCuota = 13;
        public static int PorcentajeFinanciamiento = 14;
        public static int EndeudamientoSinInmueble = 16;
        public static int CuotaExcedente = 17;
        public static int CoberturaDeGarantia = 18;
        public static int FinanciamientoCapital = 19;
        public static int CoberturaPrestamo = 20;
    }

    public class Evaluacion
    {
        public static int CapitalTrabajo = 1;   // ID capital de trabajo
        public static string MonedaSimbolo = "S/.";
        public static int idMoneda = 1;

        public static decimal TipoCambio = 1.0000m;
        public static Nullable<DateTime> FechaUltimaEval = null;
        public static Nullable<DateTime> FechaActualEval = DateTime.Now;
        public static int PlazoEval = 12;

        public static int Pyme = 1;
        public static int Agropecuario = 2;

        public static int MinReferencias = 2;
        public static int MaxReferencias = 10;

        public static DataTable DataTableMoneda = new DataTable();
        public static DataTable DataTipoFrecuencia = new DataTable();
        public static DataTable DataFechasFlujo = new DataTable();
        public static List<clsMesFechasEval> listMesFechasEval = new List<clsMesFechasEval>();
    }

    public class GridViewStyle
    {
        public static Color GridViewBackColorEditable = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        public static Color GridViewBackColorTotal = System.Drawing.SystemColors.GradientActiveCaption;
        public static Font GridViewFontTotal = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    }

    public class TipoDeuda
    {
        public static int Directo = 1;
        public static int Indirecto = 2;
    }

    public class TipoActividad
    {
        public static int Dependiente = 1;
        public static int Independiente = 1;
    }

    public class TipoIngresoPorActividad
    {
        //Evaluacion Pyme
        public static int Comercio = 1;
        public static int Produccion = 2;
        public static int Servicio = 3;

        //Evaluacion Agrop
        public static int Recria = 4;
        public static int Engorde = 5;
        public static int ComercioAgro = 6;
        public static int MixtoRecriaComercio = 7;
        public static int MixtoComercioRecria = 8;
    }

    public class Ayuda
    {
        public static string ActEconomica = @"- Antecedentes y descripción del negocio.
- Personas que trabajan en el negocio.
- Mercados, clientes, proveedores.
- Equipamiento e infraestructura.
- Productos de mayor rotación.
- Formalización y acumulación patrimonial.
- Actividad principal, actividades complementarias 
  y actividades secundarias de la unidad familiar.
- Sobre los Ingresos con los que cuenta el cónyuge.";

        public static string ActEconomicaPri = @"- Antecedentes y descripción del negocio.
- Personas que trabajan en el negocio.
- Mercados, clientes, proveedores.
- Equipamiento e infraestructura.
- Productos de mayor rotación.
- Formalización y acumulación patrimonial.
- Sobre los Ingresos con los que cuenta el cónyuge.";

        public static string EntFamiliar = @"Información del entorno familiar y conyugal.";

        public static string DestPrestamo = @"Detallar destino, especificar adquisición y los beneficios 
para el negocio. Caso activo fijo indicar aporte propio, 
capacidad de ahorro y/o fuente de financiamiento.";

        public static string Antecedentes = @"Comentar experiencia crediticia, niveles máximos de 
endeudamiento, destino de los créditos, calificación.";

        public static string IndFinancieros = @"Criterios tomados para evaluación, margen de ventas, 
análisis de Balance General, EGyP, indicadores.
variaciones en análisis horizontal.";

        public static string Garantias = @"Comentar aspectos cualitativos de la Garantía 
(patrimonio personal y avales con capacidad de 
pago, solvencia moral y respaldo patrimonial).";

        public static string Conclusiones = @"Opinión de la factibilidad del crédito, principales 
riesgos identificados y su mitigación de los mismos. 
Fortalezas del cliente y aspectos más relevantes.";

        public static string SustentoCredito = @"Comentar el sustento que propone el cliente en caso fallara
algo durante el periodo del Credito.";

        public static string DetalleActPrincipal = @"Lugar del Trabajo
Referencia
Experiencia
Modalidad de Trabajo
etc.";

        public static string DetalleCliente = @"Referencias
antecedentes Crediticios
historial en el sistema
etc.";

        public static string DetalleCredito = @"Plan de Inversión
Evaluación
Riesgos
Garantía Presentada
etc.";
    }

    public class ElemEvalCred
    {
        public static int BalanceGeneral = 1;
        public static int EstadoResultados = 2;
        public static int FlujoCaja = 3;
        public static int UltEvaluacion = 4;
        public static int DetalleDeudas = 5;
        public static int DetalleBBGG = 6;
        public static int DetalleEERR = 7;
        public static int ActSecundaria = 8;
        public static int EntFamiliar = 9;
        public static int DesPrestamo = 10;
        public static int AntCrediticios = 11;
        public static int AnaIndicadores = 12;
        public static int DesGarantias = 13;
        public static int Conclusiones = 14;
        public static int DetalleCliente = 15;
        public static int DetalleCredito = 16;
        public static int DetalleIngresoEgresostacional = 17;
        public static int DetalleFlujoCaja = 18;

    }

    public class TipoDescripcion
    {
        public static int IngresoVentas = 1;
        public static int IngresoProduccion = 2;
        public static int IngresoServicios = 3;
        public static int CosteoProduccion = 4;
        public static int CosteoServicios = 5;
        public static int Inventario = 6;
        public static int MaqEquHerramientas = 7;
        public static int GastosPersonal = 8;
        public static int GastosOperativos = 9;
        public static int OtrosIngresos = 10;
        public static int OtrosEgresos = 11;
        public static int GastosFamiliares = 12;
    }

    public class clsAcciones
    {
        public const int DEFECTO = 0;
        public const int EDITAR = 1;
        public const int GRABAR = 2;
        public const int ENVIAR = 3;
        public const int BUSCAR = 4;
        public const int NUEVO = 5;
        public const int DENEGAR = 6;
        public const int CANCELAR = 7;
        public const int FINALIZAR = 8;
        public const int RESOLVER = 9;
        public const int REVISAR = 10;
        public const int RECUPERAR = 11;
        public const int SELECCIONAR = 12;
        public const int CONTINUAR = 13;
        public const int VISTA = 14;
        public const int INICIAR = 15;
    }

    public class TipRefEval
    {
        public static int RefComercial = 1;
        public static int RefPersonal = 2;
        public static int RefLaboral = 3;
    }

    public class TipDeudasCA
    {
        public static int Normal = 1;
        public static int CompraDeuda = 2;
        public static int Ampliacion = 3;
        public static int Reprogramacion = 4;
        public static int Refinanciamiento = 5;
    }

    public class TipoInventario
    {
        public static int PlantelFijo = 10;
        public static int SemovientesComercio = 1;
        public static int SemovientesEngorde = 2;
        public static int AnimalesMenores = 3;
        public static int InsumosMateriasPrimas = 4;
        public static int ProductosProceso = 5;
        public static int ProductosTerminados = 6;
        public static int PlantacionesAgrícolasForestales = 7;
        public static int ExistenciasAcuícolas = 8;
        public static int Otros = 9;
    }

    #region Niveles Aprobacion

    public class EstadoAprobacion
    {
        public static int Solicitado = 1;
        public static int VoBo = 2;
        public static int Aprobado = 3;
        public static int Denegado = 4;
        public static int Ejecutado = 5;
        public static int Pagado = 6;
        public static int DenegadoAlCierre = 7;
        public static int EnvioDirecto = 8;
        public static int SolicitadoAfectacion = 9;
    }

    public class TiposGrupoAfectacion
    {
        public static int AfectacionIndividual = 1;
        public static int AfectacionGrupal = 2;
    }

    public class cuentaSelect
    {
        public int idCuenta;
        public string tipoOperacion;
        public int idTipoOperacion;
        public int idSolicitud;
    }

    public class TipoOperacionRecuperacion
    {
        public static int condonacion = 1;
        public static int afectacion = 2;
    }
    public class OperacionSolCred
    {
        public static int  AMPLIACION =4;
        public static int  OTORGAMIENTO=1;
        public static int  REFINANCIACION=2;
        public static int  REPROGRAMACION=3;
        public static int  CARTA_FIANZA=5;
        public static int REFINANCIACION_POR_NOVACION = 6;
    }

    public class Moneda
    {
        public static int MonedaNacional = 1;
        public static int MonedaExtranjera = 2;
    }

    #endregion


    public class clsAccionSol
    {
        public const int SOL_DEFECTO    = 20;
        public const int SOL_EDITAR     = 21;
        public const int SOL_GRABAR     = 22;
        public const int SOL_ENVIAR     = 23;
        public const int SOL_BUSCAR     = 24;
        public const int SOL_NUEVO      = 25;
        public const int SOL_CANCELAR   = 26;
        public const int SOL_RECUPERAR  = 27;
    }
}


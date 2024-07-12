using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public enum Etapa : int
    {
        NINGUNO = 1,
        PROMOCION = 2,
        SOLICITUD = 3,
        EVALUACION = 4,
        RESOLUCION = 5,
        DESEMBOLSO = 6,
        SEGUIMIENTO = 7
    }

    public enum Estado : int
    {
        NINGUNO = 1,
        REGISTRADO = 2,
        ENVIADO = 3,
        DERIVADO = 4,
        DEVUELTO = 5,
        REINGRESO = 6,
        APROBADO = 7,
        DENEGADO = 8,
        PREDESEMBOLSADO = 9,
        DESEMBOLSADO = 10,
        PRESOLICITADO = 11,
        SOLICITADO = 12,
        PENDIENTE = 13,
        EJECUTADO = 14,
        ACTIVO = 15,
        CANCELADO = 16,
        NORMAL = 17,
        OBSERVADO = 18,
        CREADO = 19,
        ELIMINADO = 20,
        TRANSFERIDO = 21,
        ANULADO = 22,
        EXTORNADO = 23,
        BLOQUEADO = 24,
        DESBLOQUEADO = 25,
        HABILITADO = 26,
        DESHABILITADO = 27,
        INICIADO = 28,
        FINALIZADO = 29,
        VIGENTE = 30,
        EXPIRADO = 31,
        PAGADO = 32,
        COBRADO = 33,
        EMITIDO = 34,
        ENTREGADO = 35,
        GENERADO = 36,
        PLANIFICADO = 37
    }

    public enum EtapaEvalCred : int
    {
        NINGUNO = 1,
        SOLICITUD = 2,
        EVALUACION = 3,
        COMITE = 4,
        APROBACION = 5,
        REVISION = 6,
        DESEMBOLSO = 7
    }

    public enum EstadoEvalCred : int
    {
        NINGUNO = 1,
        REGISTRADO = 2,
        ENVIADO = 3,
        CANCELADO = 4,
        APROBADO = 5,
        DERIVADO = 6,
        DENEGADO = 7,
        DEVOLVER = 8,
        DEVUELTO = 9,
        REINGRESO = 10,
        DESEMBOLSADO = 11,
        ANULADO = 12
    }

    public enum Accion : int
    {
        NINGUNO = 1,
        REGISTRAR = 2,
        ENVIAR = 3,
        CANCELAR = 4,
        APROBAR = 5,
        DERIVAR = 6,
        DENEGAR = 7,
        DEVOLVER = 8,
        AJUSTAR = 9,
        REINGRESAR = 10,
        DESEMBOLSAR = 11,
        ANULAR = 12
    }

    public enum OperacionCredito : int
    {
        Ampliacion = 4,
        Otorgamiento = 1,
        Refinanciacion = 2,
        ReprogramacionCambioFecha = 3,
        CartaFianza = 5,
        RefinanciacionNovacion = 6,
        ReprogramacionPadre = 9,
        ReprogramacionCambioMoneda = 12,
        ReprogramacionCuotaBalon = 13,
        ReprogramacionUnicuota = 14,
        ReprogramacionCapitalFinal = 15,
        ReprogramacionSBS = 16
    }

    public enum TipoPeriodo : int
    {
        FechaFija = 1,
        PeriodoFijo = 2,
        CuotasLibres = 3
    }

    public enum AccionCuota : int
    {
        CuotaBalon = 1,
        UnificarCuotas = 2,
        CuotaDoble = 3,
        ModificarCuota = 4,
        CuotasGracia = 5,
        CuotasLibres = 6
    }

    public enum EstadoCredito : int
    {
        IngresadoSolicitud = 0,
        SolicitadoEvaluacion = 1,
        Aprobado = 2,
        Activo = 5,
        Cancelado = 6,
        Observado = 11,
        EnviadoEvaluacion = 13,
        EnviadoAprobacion = 15
    }

    public enum RecuperacionComisionTipo : int
    {
        GestorRecuperacion = 1,
        SupervisorRecuperacion = 2,
        SupervisorJudicial = 3,
        CarteraCastigada = 4,
        JefeRecuperacion = 5,
        CallCenter = 6
    }

    public enum EstadoRegistro : int
    {
        Creado = 1,
        Nuevo = 2,
        Editado = 3,
        Eliminado = 4
    }

    public enum NegocioIncentivoTipo : int
    { 
        AsesorNegocios = 1,
        JefeOficina = 2,
        CoordinadorInclusionSocial = 3,
        CoordinadorConvenio = 4,
        Oficina = 5,
        GerenteRegional = 6,
        JefeInclusionSocial = 7
    }

    public enum ResultadoServidor : int
    {
        Error = 0,
        Correcto = 1
    }

    public enum Busqueda : int
    {
        Solicitud = 1,
        Evaluacion = 2,
        Creditos = 3,
        Ahorros = 4,
        Todos = 100
    }
    public enum AprobacionSolicitudTipo : int
    {
        BonoGrupoSolidario = 1,
        TiempoComiteCredito = 2
    }

    public enum GrupoSolidarioCargo : int
    {
        Presidente = 1,
        Tesorero = 2,
        Socio = 3
    }
    public enum Monedas : int
    {
        Ninguno = -1,
        Integrado = 0,
        Soles = 1,
        Dolares = 2
    }
    public enum TipoRecibo : int
    {
        ReciboIngreso = 1,
        ReciboEgreso = 2,
        RegistroCompras = 3,
        GastosSinComprobantes = 4,
        RegistroVentas = 5,
        DescuestosRegCompras = 6,
        ComisionesRegCompras = 7
    }
    public enum Perfil : int
    {
        JefeOficina = 85,
        AsesorGruposSolidarios = 118
    }

    public enum ModalidadDesembolso : int
    {
        Efectivo = 1,
        TransferenciaCuenta = 2,
        ChequeGerencia = 3
    }
    public enum ModalidadPagoCredito : int
    {
        PagoNormal = 1,
        CancelacionAnticipada = 2,
        CondonacionDeuda = 3,
        PrePago = 4,
        Refinanciación = 5,
        CancelacionAmpliación = 6
    }
    public enum TipoGrupoSolidario : int
    {
        GrupoSolidario = 1,
        BancaComunal = 2
    }

    public enum TipoOperacion : int
    {
        Apertura = 9,
        Deposito = 10,
        Retiro = 11,
        CONDONACION = 7
    }
    public enum TipoPersona : int
    {
        Natural = 1,
        JuridicaConFinesLucro = 2,
        JuridicaSinFinesLucro = 3
    }

    public enum TipoPago : int
    {
        Efectivo = 1,
        TransferenciaInterna = 2,
        ChequesExterno= 3,
        Interbancarios = 4,
        OrdenDePago = 5
    }
    public enum MotivoOperacion : int
    {
        AperturaNormal = 1,
        DepositoNormal = 2,
        RetiroNormal = 3,
        CancelacionNormal = 4,
        CobranzaNormal = 5,
        CancelacionAnticipada = 6,
        RetiroEspecial = 7
    }
    public enum Bloqueo : int
    {
        PorMandatoJudicial = 1,
        PorMandatoSunat = 2,
        PorGarantia = 3,
        PorDesembolso = 4,
        PorOperacion = 5,
        PorOrdenAdministrativa = 6,
        SolicitudCliente = 7,
        CompraDeuda = 8,
        ClienteSinExpediente = 9,
        ClienteConCuentaInactiva = 10,
        DesembolsoGrupoSolidario = 11
    }

    public enum CaracteristicaBloqueo : int
    {
        BloqueoParcial = 1,
        BloqueoTotal = 2,
        BloqueoDeposito = 3,
        BloqueoRetiro = 4,
        BloqueoCancelacion = 5
    }
    public enum TipoSolicitanteBloq : int
    {
        Interno = 1,
        Externo = 2
    }
    public enum TipoResolucion : int
    {
        Ninguno = 0,
        Favorable = 1,
        Desfavorable = 2
    }
    public enum TipoPlanPago : int
    {
        ValorCuotaConstante = 1,
        ValorCuotaInicial = 2,
        ReprogPerdonDias = 3,
        ReprogCuotaConstante = 4,
        ReprogModifCalendario = 5,
        CalendarioInteresComp = 6,
        CambioTasa = 7

    }
    public enum TipoExcepcion : int
    {
        Excepcion = 1,
        Regularizacion = 2
    }
    public enum ModalidadCredito : int
    {
        Principal = 1,
        Paralelo = 2,
        Estacional = 3
    }

    /// <summary>
    /// Para mapear la cobertura del seguro de vida
    /// </summary>
    public enum PlazoSeguroVida : int
    {
        SEIS_MESES = 6,
        DOCE_MESES = 12,
        DIECIOCHO_MESES = 18
    }

    /// <summary>
    /// Match plazo seguro vida con item de combo
    /// </summary>
    public enum ValorComboSeguroVida : int
    {
        SEIS_MESES = 1,
        DOCE_MESES = 2,
        DIECIOCHO_MESES = 3
    }


    /// <summary>
    /// Para mapear la cobertura del seguro oncológico
    /// </summary>
    public enum PlazoSeguroOncologico : int
    {
        DOCE_MESES = 12,
        VEINTICUATRO_MESES = 24
    }

    /// <summary>
    /// Match plazo seguro vida con item de combo
    /// </summary>
    public enum ValorComboSeguroOncologico : int
    {
        DOCE_MESES = 1,
        VEINTICUATRO_MESES = 2
    }

    /// <summary>
    /// De la tabla SI_FinTipoValSegOptativo
    /// </summary>
    public enum TipoValorSeguroOptativo : int
    {
        PORCENTAJE = 1,
        MONTO_FIJO = 2,
    }

    /// <summary>
    /// De la tabla SI_FinTipoPagoSeguroOptativo
    /// </summary>
    public enum TipoPagoSeguroOptativo : int
    {
        DISTRIBUIDO_POR_CUOTA = 1,
        PAGO_UNICO = 2
    }
}

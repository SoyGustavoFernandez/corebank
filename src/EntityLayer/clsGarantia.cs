using System;
using System.Collections.Generic;
using System.Data;

namespace EntityLayer
{
    /// <summary>
    /// clase de la entidad garantia
    /// </summary>
    [Serializable]
    public class clsGarantia
    {
        public int idGarantia { get; set; }
        public string cGarantia { get; set; }
        public int idTipoGarantia { get; set; }
        public int idClaseGarantia { get; set; }
        public int  idGrupoGarantia { get; set; }
        public int idMoneda { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecRegistro { get; set; }
        public decimal nTipoCambio { get; set; }
        public decimal nMonGravamenSol { get; set; }
        public decimal nMonGravamen { get; set; }
        public decimal nMonGarantia { get; set; }
        public decimal nValorComercial { get; set; }
        public decimal nValorMercado { get; set; }
        public decimal nValorEdifica { get; set; }
        public decimal nValorNuevo { get; set; }
        public decimal nValorRealiza { get; set; }
        public decimal nValorVenta { get; set; }
        public decimal nMaxGarantia { get; set; }
        public string cDesObserva { get; set; }
        public int idUbigeo { get; set; }
        public string cDireccion { get; set; }
        public string cReferencia { get; set; }
        public clsListDetGarantia lisDetGarantia { get; set; }
        public clsLisEspecificacioGarantia lisEspecificacion { get; set; }
        public bool lIndSabana { get; set; }
        public bool lIndPriVenta { get; set; }
        public DataTable dtGarPerAval { get; set; }

        public decimal dValorContable { get; set; }
        public decimal dValorConstituido { get; set; }
        

        public int idSituacion { get; set; }
        public string cTipoEmisor { get; set; }

        public override string ToString()
        {
            return cGarantia;
        }
        public clsGarantia()
        {
            dtGarPerAval = IniDtGarPerEval();
            lisDetGarantia = new clsListDetGarantia();
        }

        private DataTable IniDtGarPerEval()
        {
            DataTable dtGarPerAvalNue = new DataTable();
            dtGarPerAvalNue.Columns.Add("idGarantia", typeof(int));
            dtGarPerAvalNue.Columns.Add("idCli", typeof(int));
            dtGarPerAvalNue.Columns.Add("lVigente", typeof(bool));
            dtGarPerAvalNue.Columns.Add("cNombre", typeof(string));
            dtGarPerAvalNue.Columns.Add("cDocumentoID", typeof(string));
            dtGarPerAvalNue.Columns.Add("idTipoDocumento", typeof(int));
            dtGarPerAvalNue.Columns.Add("cTipoDocumento", typeof(string));
            return dtGarPerAvalNue;
        }

    }

    /// <summary>
    /// clase coleccion de la entidad garantia
    /// </summary>
    [Serializable]
    public class clsListGarantia:List<clsGarantia>
    {
       
    }

    public class clsDetGarantia
    {
        public int idCliGarantia { get; set; }
        public int idGarantia { get; set; }
        public int idCli { get; set; }
        public decimal nMonGravado { get; set; }
        public decimal nPorcentaje { get; set; }
        public decimal nMonGarantia { get; set; }
        public decimal nMonSaldoGrav { get; set; }
        public decimal nMonGravadoSol { get; set; }
        public decimal nMonSaldoGravSol { get; set; }
        public bool lPropietario { get; set; }
        public string cGarantia { get; set; }
        public bool lReqCtaDep { get; set; }
    }

    /// <summary>
    /// clase coleccion de la entidad detalle garantia
    /// </summary>
    [Serializable]
    public class clsListDetGarantia : List<clsDetGarantia>
    {

    }

    /// <summary>
    /// Especificaciones de la gararantia como datos del inmueble
    /// </summary>
    public class clsEspecificacioGarantia
    {
        public int idGarantia { get; set; }
        public string cCampo { get; set; }
        public string cValCampo { get; set; }
        public string cTipoDato { get; set; }
    }

    /// <summary>
    /// Coleccion de la entidad especificaciongarantia
    /// </summary>
    public class clsLisEspecificacioGarantia:List<clsEspecificacioGarantia>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class clsGarantiaPreferida
    {
        public DateTime dFecUltVal { get; set; }
        public DateTime dFecVenGar { get; set; }
        public int idPeritoVal { get; set; }
        public int idConInmueble { get; set; }
        public int idEstConserva { get; set; }
        public int idMatParedes { get; set; }
        public int idMatTechos { get; set; }
        public int idMatPuertas { get; set; }
        public int nNumPisos { get; set; }
        public decimal nAreTerreno { get; set; }
        public decimal nAreConstru { get; set; }

        public int idComPolSeg { get; set; }
        public string cNumPoliza { get; set; }
        public string cNumCerti { get; set; }
        public decimal nMonCobertu { get; set; }
        public DateTime dFecIniPol { get; set; }
        public DateTime dFecVenPol { get; set; }
        public decimal nIndiSeguro { get; set; }

        public DateTime dFecInsBlo { get; set; }
        public string  cCodFicReg { get; set; }

        public int idOfiRegistral { get; set; }
        public int idSedeRegistral { get; set; }
        public string cAsiento { get; set; }
        public string cFicha { get; set; }
        public string cRubro { get; set; }
        public string cTomo { get; set; }
        public string cFolio { get; set; }
        public string cFojas { get; set; }
        public string cCodPredio { get; set; }
        public string cTipoCober { get; set; }
        public string cPreferente { get; set; }

        public int idDesPrestamo { get; set; }
        public int idEstInmueble { get; set; }
        public int idTipInmueble { get; set; }
        public int idClaseGarantia { get; set; }
        public decimal nRangoGrava { get; set; }
        public string cManzana { get; set; }
        public string cDptoLote { get; set; }

        public string cCodIsin { get; set; }
        public int idTipoEmisor { get; set; }
        public int idIndDeuVin { get; set; }
        public int idIndGarCom { get; set; }
        public DateTime dFecConGar { get; set; }
        public DateTime dFecVenGar2 { get; set; }
        public int idPlaLiquida { get; set; }
        public int idMonIdxGar { get; set; }

        public int idEmpClaRgoExt { get; set; }
        public int idPlaClaRgoExt { get; set; }
        public string cClaRiesgo { get; set; }
        public DateTime dFecUltClaRgoExt { get; set; }
    }

}

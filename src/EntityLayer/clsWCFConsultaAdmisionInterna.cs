using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFConsultaAdmisionInterna
    {
        public Int32 idCli {get; set;}
        public string cNombre {get; set;}
        public string cDocumentoID { get; set; }
        public int idTipoDocumento { get; set; }

        public string cCodsbs { get; set; }

        //cliente
        public string cTipoCliente { get; set; }
        public int idEstadoCivil { get; set; }
        public string cEstadoCivil { get; set; }
        public string cTipoDocumento { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cNumeroTelefono2 { get; set; }

        //edad
        public int nAniosNac { get; set; }
        public int nDiasNac { get; set; }

       // Financiera
        public bool lBaseNegativa { get; set; }

        public bool lPep { get; set; }
        public bool lSolitudesDenegadas { get; set; }
        public decimal nSaldoCapSF { get; set; }
        public string cClasifInterna { get; set; }
        public string cCalificacionSF { get; set; }
        public string cCalificacionSFMax12 { get; set; }
        public decimal cEndeudamientoMax { get; set; }
        public int nEntidades { get; set; }
        public bool lCajaAndes { get; set; }
        public string dFecUltActRCC { get; set; }

        //Ultimos creditos
        public IList<clsUltimosCreditos> ultimosCreditos { get; set; }

        //Relación Conyuge
        public clsRelacionConyuge relacionConyuge = new clsRelacionConyuge();

        //Lista para Direcciones cliente 
        public IList<clsDirecciones> direcciones { get; set; }

        //Deudas Directas
        public IList<clsDeudasDirectas> DeudasDirectas { get; set; }

        //Deudas Indirectas
        public IList<clsDeudasIndirectas> lineasCreditoNoUtlizadas { get; set; }

        //Campañas y pr...
        public IList<clsCredCampanha> credCampanha { get; set; }

        //Avalados Caja los Andes 
        public IList<clsAvaladosCajaAndes> avaladosCajaLosAndes { get; set; }

        //Avalados SF
        public IList<clsAvaladosSF> avaladosSF { get; set; }

        //Cartas Fianza
        public IList<clsCartaFianzas> cartasFianza { get; set; }
    }

    public class clsCartaFianzas
    {
        public decimal nMonto { get; set; }
        public string cNombre { get; set; }
        public string cTipoCartaFianza { get; set; }
    }

    public class clsDeudasIndirectas
    {
        public string cDesCalifiRCC { get; set; }
        public decimal saldo { get; set;}
        public int codEmpresa { get; set;}
        public string cNombreCorto { get; set;}
    }

    public class clsAvaladosSF
    {
        public int codSBSEntidad { get; set; }
        public decimal nSaldo { get; set; }
        public string cNombreCorto { get; set; }
        public string cCalificacion { get; set; }
    }

    public class clsAvaladosCajaAndes {
        public decimal nMonto { get; set; }
        public string cNombre { get; set; }
        public string cCalificacion {get; set; }
        public int idMoneda { get; set; }
    }
    public class clsCredCampanha
    {
        public decimal nMontoPreAprobado { get; set;}
        public string cNombreCampanha { get; set;}
        public string cMoneda { get; set;}
    }

    public class clsRelacionConyuge
    {
        public string cDocumentoID { get; set; }
        public int idTipoDocumento { get; set; }
        public int idCli { get; set; }
    }

    public class clsDeudasDirectas
    {
        public string cDesCalifiRCC { get; set; }
        public decimal saldo { get; set;}
        public int codEmpresa { get; set;}
        public string cNombreCorto { get; set;}
    }

    public class clsUltimosCreditos
    {
        public int nAtrasoProm { get; set; }
        public string cMoneda { get; set; }
        public int nCuotas { get; set; }
        public int nCuotasPagadas { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public int nAtraso { get; set; }
        public string cEstado { get; set; }
        public string cProducto { get; set; }
		public decimal nSalCap {get; set;}
        public int nAtrasoUltCuPag { get; set; }
        public int idEstado { get; set; }
        public decimal nDiasAtrPro { get; set; }
        public int nAtrasoMaximo { get; set; }
        public DateTime dFechaProg { get; set; }
        public string cFechaUltMov {
            get {
                return dFechaUltMov.ToString("dd/MM/yyyy");
            }
            set {
                this.cFechaUltMov = dFechaProg.ToString();
            }
        }
        public DateTime dFechaUltMov { get; set; }
        public string cFechaProg {
            get {
                return dFechaProg.ToString("dd/MM/yyyy");
            }
            set {
                this.cFechaProg = dFechaUltMov.ToString();
            }
        }
    }

    public class clsDirecciones
    {
        public string cTipoDir { get; set; }
        public string cReferenciaDireccion { get; set; }
        public string cPar { get; set; }
        public string cDireccion { get; set; }
    } 
}

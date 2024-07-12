using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EntityLayer
{
    public static class clsVarGlobal
    {
        public static DateTime dFecSystem;
        public static clsUsuario User;
        public static string cURLReport;
        public static string cNomImpTer;
        public static Int32 nIdAgencia;
        public static clsPerfilUsu PerfilUsu;
        public static bool lEstLogeado;
        public static string cNomAge;
        public static string cCategoria;

        public static string cConexString;
        public static int nTipoAute;
        public static int nTipoConexion;

        public static string cRutPathApp;
        public static int idCanal;
        public static decimal nITF;
        public static int idModulo;
        public static clsLimCobertura montoCobertura;
        public static List<clsVarGen> lisVars = new List<clsVarGen>();
        public static bool lFlagPermiteOperacion;
        public static int idMenu;
        public static IConectionGen IConectionGen = new ConnectionWindows();
        public static int nVersion = 0;
        public static bool lTicketeraMatricial;
        public static int idRegistroPC;
        public static int idTipoPlantillaImpresion;

        public static bool lBaseNegativa { get; set; }
    }

    public class clsVarGlobalClone
    {
        public DateTime dFecSystem;
        public clsUsuario User;
        public string cURLReport;
        public string cNomImpTer;
        public Int32 nIdAgencia;
        public clsPerfilUsu PerfilUsu;
        public bool lEstLogeado;
        public string cNomAge;

        public string cConexString;
        public int nTipoAute;
        public int nTipoConexion;

        public string cRutPathApp;
        public int idCanal;
        public decimal nITF;
        public int idModulo;
        public clsLimCobertura montoCobertura;
        public List<clsVarGen> lisVars = new List<clsVarGen>();
        public bool lFlagPermiteOperacion;
        public int idMenu;

        public clsVarGlobalClone obtnerClase()
        {
            clsVarGlobalClone clone = new clsVarGlobalClone();

            clone.dFecSystem = clsVarGlobal.dFecSystem;
            clone.User = clsVarGlobal.User;
            clone.cURLReport = clsVarGlobal.cURLReport;
            clone.cNomImpTer = clsVarGlobal.cNomImpTer;
            clone.nIdAgencia = clsVarGlobal.nIdAgencia;
            clone.PerfilUsu = clsVarGlobal.PerfilUsu;
            clone.lEstLogeado = clsVarGlobal.lEstLogeado;
            clone.cNomAge = clsVarGlobal.cNomAge;
            clone.cConexString = clsVarGlobal.cConexString;
            clone.nTipoAute = clsVarGlobal.nTipoAute;
            clone.nTipoConexion = clsVarGlobal.nTipoConexion;
            clone.cRutPathApp = clsVarGlobal.cRutPathApp;
            clone.idCanal = clsVarGlobal.idCanal;
            clone.nITF = clsVarGlobal.nITF;
            clone.idModulo = clsVarGlobal.idModulo;
            clone.montoCobertura = clsVarGlobal.montoCobertura;
            clone.lisVars = clsVarGlobal.lisVars;
            clone.lFlagPermiteOperacion = clsVarGlobal.lFlagPermiteOperacion;
            clone.idMenu = clsVarGlobal.idMenu;
            return clone;
        }
    }

    public interface IConectionGen
    {
        string GetConnectionString();
        void SetConnectionString(string cConnectionString);
    }

    public class ConnectionWindows : IConectionGen
    {
        public string GetConnectionString()
        {
            return clsVarGlobal.cConexString;
        }


        public void SetConnectionString(string cConnectionString)
        {
            clsVarGlobal.cConexString = cConnectionString;
        }
    }

    public class ConnectionWeb : IConectionGen
    {
        public string GetConnectionString()
        {
            string cConnectionString = HttpContext.Current.Session["cConectionString"] as string;
            if (!string.IsNullOrEmpty(cConnectionString))
                return cConnectionString;

            return clsVarGlobal.cConexString;
        }

        public void SetConnectionString(string cConnectionString)
        {
            HttpContext.Current.Session["cConectionString"] = cConnectionString;
        }
    }

    public class ConnectionWCF : IConectionGen
    {

        public string GetConnectionString()
        {
            return String.Empty;
        }

        public void SetConnectionString(string cConnectionString)
        {

        }
    }


}

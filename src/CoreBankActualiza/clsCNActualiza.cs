using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CoreBankActualiza
{
    public class clsCNActualiza
    {
        ArrayList arlConexion = new ArrayList();

        public ArrayList leerXML(string cUsuario, string cClave)
        {
            ArrayList arlConexion = new ArrayList();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"conexion.xml"); //la ubicación del archivo XML con el que vamos a trabajar
            XmlNodeList conexion = xDoc.GetElementsByTagName("conexion");
            XmlNodeList listaDatos = ((XmlElement)conexion[0]).GetElementsByTagName("datos");
            string cadenaConexion = "";

            foreach (XmlElement nodo in listaDatos) //obtenemos el valor de cada uno de los nodos en la lista
            {
                XmlNodeList cserver = nodo.GetElementsByTagName("server");
                XmlNodeList cdatabase = nodo.GetElementsByTagName("database");
                XmlNodeList cautenticacion = nodo.GetElementsByTagName("autenticacion");

                //AUTENT. WINDOWS 
                if (Convert.ToInt32(cautenticacion[0].InnerText) == 1)
                {
                    cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security = SSPI;Pooling = False; Connection Timeout=30", cserver[0].InnerText, cdatabase[0].InnerText);
                }
                //AUTENT. SQL
                else if (Convert.ToInt32(cautenticacion[0].InnerText) == 2)
                {
                    cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; User={2}; Password={3}; Connection Timeout=60", cserver[0].InnerText, cdatabase[0].InnerText, cUsuario, cClave);
                }
                arlConexion.Add(cadenaConexion);
                arlConexion.Add("App_Fin");
                arlConexion.Add("123456789");
                arlConexion.Add("1");
                arlConexion.Add(cautenticacion[0].InnerText);
            }
            return arlConexion;
        }

        public bool AutenticarUsuActualiza(string cUsuario, string cClave)
        {
            bool res = false;
            arlConexion = leerXML(cUsuario, cClave);
            clsVariableGlobal.cConexString = (string)arlConexion[0];
            clsVariableGlobal.nIdAgencia = Convert.ToInt32(arlConexion[3]);
            clsVariableGlobal.nTipoAute = Convert.ToInt32(arlConexion[4]);
            clsVariableGlobal.cRutPathApp = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            clsVariableGlobal.idCanal = 1;

            if (clsVariableGlobal.nTipoAute == 2)
            {
                if (ValiUsuSQL(cUsuario, cClave))
                {
                    res = true;
                }
                else
                {
                    MessageBox.Show("Ingrese un Usuario y Contraseña Válidas", "Información");
                }
            }
            clsVariableGlobal.lEstLogeado = res;
            return res;
        }

        private bool ValiUsuSQL(string cUsuario, string cClave)
        {
            try
            {
                using (SqlConnection Conexion = new SqlConnection())
                {
                    Conexion.ConnectionString = leerXML(cUsuario, cClave)[0].ToString();
                    Conexion.Open();
                    Conexion.Close();
                    Conexion.Dispose();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            } 
        }
    }

    public class clsConector
    {
        #region Listas
        Dictionary<string, SqlDbType> dicSQLDBType = new Dictionary<string, SqlDbType>
            {   { "bit", SqlDbType.Bit},
                { "bigint", SqlDbType.BigInt}, 
                { "binary", SqlDbType.Binary}, 
                { "char", SqlDbType.Char},
                { "date", SqlDbType.Date}, 
                { "datetime", SqlDbType.DateTime},
                { "datetime2", SqlDbType.DateTime2},
                { "datetimeoffset", SqlDbType.DateTimeOffset},
                { "decimal", SqlDbType.Decimal},
                { "numeric", SqlDbType.Decimal},
                { "float", SqlDbType.Float},
                { "image", SqlDbType.Image},                 
                { "int", SqlDbType.Int}, 
                { "money", SqlDbType.Money},                 
                { "nchar", SqlDbType.NChar},                
                { "nvarchar", SqlDbType.NVarChar},
                { "ntext", SqlDbType.NText},
                { "real", SqlDbType.Real},
                { "smalldatetime", SqlDbType.SmallDateTime}, 
                { "smallint", SqlDbType.SmallInt},
                { "time", SqlDbType.Time}, 
                { "timestamp", SqlDbType.Timestamp}, 
                { "tinyint", SqlDbType.TinyInt}, 
                { "uniqueidentifier", SqlDbType.UniqueIdentifier}, 
                { "text", SqlDbType.Text},
                { "varbinary", SqlDbType.VarBinary}, 
                { "varchar", SqlDbType.VarChar},
                { "xml", SqlDbType.Xml} };

        Dictionary<string, ParameterDirection> dicParamDir = new Dictionary<string, ParameterDirection> 
            {   { "IN", ParameterDirection.Input}, 
                { "INOUT", ParameterDirection.Output}};
        #endregion

        private List<clsGENParams> lstParametros = new List<clsGENParams>();
        
        public DataTable EjecSP(string NombreSP, params object[] parametros)
        {

            DataTable dt = new DataTable();
            using (SqlConnection Conexion = new SqlConnection())
            {
                try
                {
                    if (string.IsNullOrEmpty(clsVariableGlobal.cConexString))
                    {
                        return estructuraVacia();
                    }

                    Conexion.ConnectionString = clsVariableGlobal.cConexString;
                    SqlCommand RoleCommand = new SqlCommand();
                    RoleCommand.CommandType = CommandType.Text;
                    RoleCommand.CommandText = "SP_SETAPPROLE";
                    RoleCommand.Parameters.Add(new SqlParameter("rolename", "App_Fin"));
                    RoleCommand.Parameters.Add(new SqlParameter("password", "123456789"));
                    RoleCommand.CommandType = CommandType.StoredProcedure;
                    RoleCommand.Connection = Conexion;
                    Conexion.Open();
                    //RoleCommand.ExecuteNonQuery(); 
                    lstParametros = CargaParametroSP(NombreSP, Conexion);
                    SqlCommand ComandoSP = new SqlCommand();
                    ComandoSP.CommandText = NombreSP;
                    ComandoSP.CommandType = CommandType.StoredProcedure;
                    ComandoSP.Connection = Conexion;
                    ComandoSP.CommandTimeout = 600;
                    for (int i = 0; i < lstParametros.Count; i++)
                    {
                        if (lstParametros[i].Parametro.SqlDbType == SqlDbType.Xml)
                            lstParametros[i].Parametro.Value = new SqlXml(new XmlTextReader(parametros[i].ToString(), XmlNodeType.Document, null));
                        else
                            lstParametros[i].Parametro.Value = parametros[i];
                        ComandoSP.Parameters.Add(lstParametros[i].Parametro);
                    }
                    SqlDataReader reader = ComandoSP.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                    RoleCommand.Dispose();
                    Conexion.Close();
                    Conexion.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return dt;
        }

        public List<clsGENParams> CargaParametroSP(string NombreSP, SqlConnection con)
        {
            List<clsGENParams> lstParamsSP = new List<clsGENParams>();
            using (SqlCommand lstParams = new SqlCommand())
            {
                lstParams.Connection = con;

                lstParams.CommandText = "GEN_LstParamsxSP_SP";
                lstParams.CommandType = CommandType.StoredProcedure;
                lstParams.Parameters.Add(new SqlParameter("@x_cNombreSP", NombreSP));
                SqlDataReader parametersReader = lstParams.ExecuteReader();

                {
                    while (parametersReader.Read())
                    {
                        clsGENParams ParamSP = new clsGENParams();
                        SqlParameter Parametro = new SqlParameter();
                        string paramInfo = string.Format(
                          "Orden: {0} NombreParametro: {1} Tipo: {2} Longitud: {3} Modo: {4} ",
                          parametersReader["ORDINAL_POSITION"],
                          parametersReader["PARAMETER_NAME"],
                          parametersReader["DATA_TYPE"],
                          parametersReader["CHARACTER_MAXIMUM_LENGTH"],
                          parametersReader["PARAMETER_MODE"]);

                        ParamSP.nPosicion = Convert.ToInt32(parametersReader["ORDINAL_POSITION"]);
                        ParamSP.Tipodatos = parametersReader["DATA_TYPE"].ToString();
                        Parametro.ParameterName = parametersReader["PARAMETER_NAME"].ToString();
                        Parametro.SqlDbType = dicSQLDBType[parametersReader["DATA_TYPE"].ToString()];
                        Parametro.Direction = dicParamDir[parametersReader["PARAMETER_MODE"].ToString()];
                        if (parametersReader["DATA_TYPE"].ToString() == "char")
                            Parametro.Size = Convert.ToInt32(parametersReader["CHARACTER_MAXIMUM_LENGTH"]);
                        ParamSP.Parametro = Parametro;
                        lstParamsSP.Add(ParamSP);
                    }
                }
                lstParams.Dispose();
                parametersReader.Close();
                return lstParamsSP;
            }
        }
        
        private DataTable estructuraVacia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");
            dt.Columns.Add("col4");
            dt.Columns.Add("col5");
            return dt;
        }
    }

    public class clsGENParams
    {
        public int nPosicion { get; set; }
        public string Tipodatos { get; set; }
        public SqlParameter Parametro { get; set; }
    }

    public static class clsVariableGlobal
    {
        public static DateTime dFecSystem;
        public static string cURLReport;
        public static string cNomImpTer;
        public static Int32 nIdAgencia;
        public static bool lEstLogeado;
        public static string cNomAge;
        public static string cConexString;
        public static int nTipoAute;
        public static string cRutPathApp;
        public static int idCanal;
        public static decimal nITF;
        public static int idModulo;
        public static bool lFlagPermiteOperacion;
        public static int idMenu;
    }
}

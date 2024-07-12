using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADUsuario
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsUsuario lUser = new clsUsuario();

        public clsUsuario ValidarLogin(string x_User)
        {
            try
            {
                var query = objEjeSp.EjecSP("GEN_ValUsu_sp", x_User,clsVarGlobal.nIdAgencia);

                foreach (DataRow dr in query.Rows)
                {
                    try
                    {
                        lUser.idUsuario = (int)dr["idUsuario"];
                        lUser.cWinUser = (string)dr["cWinUser"];
                        lUser.cNomUsu = Convert.ToString(dr["cNomUsu"]);
                        lUser.idCli = (int)dr["idCli"];
                        lUser.dFechaIngreso = (DateTime)dr["dFechaIngreso"];
                        lUser.idEstado = (int)dr["idEstado"];
                        lUser.idCargo = (int)dr["idCargo"];
                        lUser.dFechaCese = dr["dFechaCese"].ToString()==""? null:(Nullable<DateTime>)dr["dFechaCese"];
                        lUser.lChangePass = (bool)dr["lChangePass"];
                        lUser.idAgeCol = (int)dr["idAgencia"];

                        lUser.idEstablecimiento = (int)dr["idEstablecimiento"];
                        lUser.cEstablecimiento = (string)dr["cEstablecimiento"];
                        lUser.idTipoEstablec = (int)dr["idTipoEstablec"];
                        lUser.cTipoEstablec = (string)dr["cTipoEstablec"];
                        lUser.lAutBiometricaAgencia = (bool)dr["lAutBiometricaAgencia"];
                        lUser.lAutBiometricaComite = (bool)dr["lAutBiometricaComite"];

                        lUser.nDiasExpiracionSQL = dr["nDiasExpiracionSQL"] == DBNull.Value ? null : (int?)dr["nDiasExpiracionSQL"];
                        lUser.lVerificacionSMS = dr["lVerificacionSMS"] == DBNull.Value ? false : (bool)dr["lVerificacionSMS"];

                        lUser.cVersion = (string)dr["cVersion"];
                        //lUser.dFechaCese = dr["dFechaCese"] == null ? DateTime.Today : (DateTime)dr["dFechaCese"];
                        //lUser.dFechaCese = (Nullable<DateTime>)dr["dFechaCese"];// (Nullable<DateTime>)dr["dFechaCese"]==null ? null:System.DateTime.Now.Date;
                        //lUser.cCodPerfil = item.cCodPerfil;

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lUser;
        }

        public DataTable ChangePassword(string cUsu, string cPassOld, string cPassNew)
        {            
            clsGENEjeSP objEjeSp = new clsGENEjeSP();            
            return objEjeSp.EjecSP("GEN_ChangePassword_sp", cUsu, cPassOld, cPassNew);            
        }

        public string retornarLicencia()
        {
            return objEjeSp.EjecSP("GEN_ObtenerLicencia_SP").Rows[0][0].ToString();
        }

        public DataTable listarUsuarioSupervisores()
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("RCP_ListarUsuarioSupervisores_SP");
        }

        public DataTable ObtenerZonasUsuario(int idUsuario)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("GEN_ObtieneUsuarioZonas_sp", idUsuario);
        }

        public DataTable agregarZona(int idUsuario, int idZona, int idUsuReg)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("GEN_AgregarZonaUsuario_SP", idUsuario, idZona, idUsuReg);
        }

        public DataTable quitarZona(int idZonaUsuario, int idUsuReg)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("GEN_QuitarZonaUsuario_SP", idZonaUsuario, idUsuReg);
        }

        public clsUsuario ValidarLoginClone(string x_User)
        {
            throw new NotImplementedException();
        }

        public clsUsuario ValidarLoginWCF(string x_User)
        {
            try
            {
                var query = new clsWCFEjeSP().EjecSP("GEN_ValUsu_sp", x_User, clsVarGlobal.nIdAgencia);

                foreach (DataRow dr in query.Rows)
                {
                    try
                    {
                        lUser.idUsuario = (int)dr["idUsuario"];
                        lUser.cWinUser = (string)dr["cWinUser"];
                        lUser.cNomUsu = Convert.ToString(dr["cNomUsu"]);
                        lUser.idCli = (int)dr["idCli"];
                        lUser.dFechaIngreso = (DateTime)dr["dFechaIngreso"];
                        lUser.idEstado = (int)dr["idEstado"];
                        lUser.idCargo = (int)dr["idCargo"];
                        lUser.dFechaCese = dr["dFechaCese"].ToString() == "" ? null : (Nullable<DateTime>)dr["dFechaCese"];
                        lUser.lChangePass = (bool)dr["lChangePass"];
                        lUser.idAgeCol = (int)dr["idAgencia"];

                        lUser.idEstablecimiento = (int)dr["idEstablecimiento"];
                        lUser.cEstablecimiento = (string)dr["cEstablecimiento"];
                        lUser.idTipoEstablec = (int)dr["idTipoEstablec"];
                        lUser.cTipoEstablec = (string)dr["cTipoEstablec"];

                        lUser.cVersion = (string)dr["cVersion"];
                        //lUser.dFechaCese = dr["dFechaCese"] == null ? DateTime.Today : (DateTime)dr["dFechaCese"];
                        //lUser.dFechaCese = (Nullable<DateTime>)dr["dFechaCese"];// (Nullable<DateTime>)dr["dFechaCese"]==null ? null:System.DateTime.Now.Date;
                        //lUser.cCodPerfil = item.cCodPerfil;

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lUser;
        }

        public DataTable ObtenerDatosClienteBiometrico(int idCliente)
        {
            return objEjeSp.EjecSP("GEN_ObtenerDatosClienteBiometrico_SP", idCliente);
        }
    }
}

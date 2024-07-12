using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADPcUsuario
    {
        public void validarDatosPc(string cNomPc, string cMacPc, string cDatSo, ref bool lIndActivo, string cIdentificadorPC = "")
        {
            List<clsGENParams> lisParametros;
            try
            {
                lisParametros = new clsGENEjeSP().EjecSPOut("GEN_RegValDatPcUsu_sp", cNomPc, cMacPc, cDatSo, clsVarGlobal.User.idUsuario, lIndActivo, cIdentificadorPC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            lIndActivo= Convert.ToBoolean(lisParametros[0].Parametro.Value);
      
        }

        public void validarDatosPc(int idUsuario,string cNomPc, string cMacPc, string cDatSo, ref bool lIndActivo)
        {
            List<clsGENParams> lisParametros;
            try
            {
                lisParametros = new clsGENEjeSP().EjecSPOut("GEN_RegValDatPcUsu_sp", cNomPc, cMacPc, cDatSo, idUsuario, lIndActivo,"Equipo-Movil");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            lIndActivo = Convert.ToBoolean(lisParametros[0].Parametro.Value);

        }

        public DataTable listarDatosPc(int nTipoActivo)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_ListarDatPcUsu_sp", nTipoActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void actualizarRegDatPc(string xmlDatPc, string xmlNocheckedDatPc)
        {
            try
            {
                new clsGENEjeSP().EjecSP("GEN_ActRegPcUsu_SP", xmlDatPc, xmlNocheckedDatPc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.Funciones;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsPcUsuario
    {
        clsADPcUsuario objpcusu = new clsADPcUsuario();
        public bool validarDatosPc()
        {
            clsFunUtiles objFuncion=new clsFunUtiles();
            string cMacPc = objFuncion.obtenerMac();
            string cNomPc = objFuncion.obtenerNomPc();
            string cDatSo = objFuncion.obtenerDatSO();
            string cIdentificadorPC = objFuncion.obtenerIdentificadorPC();
            bool lIndActivo=false;

            objpcusu.validarDatosPc(cNomPc, cMacPc, cDatSo, ref lIndActivo, cIdentificadorPC);

            return lIndActivo;
        }

        public bool validarDatosPc(int idUsuario,string cMacPc, string cNomPc, string cDatSo)
        {
            clsFunUtiles objFuncion = new clsFunUtiles();            
            bool lIndActivo = false;

            objpcusu.validarDatosPc(idUsuario, cNomPc, cMacPc, cDatSo, ref lIndActivo);

            return lIndActivo;
        }

        public DataTable listarDatosPc(int nTipoActivo)
        {
            try
            {
                return objpcusu.listarDatosPc(nTipoActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void actualizarRegDatPc(string xmlDatPc, string xmlNocheckedDatPc)
        {
            objpcusu.actualizarRegDatPc(xmlDatPc, xmlNocheckedDatPc);
        }
    }
}

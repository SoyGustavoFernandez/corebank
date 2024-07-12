using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SPL.AccesoDatos
{
    public class clsADRegistroOperacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();


        public void insertarRegistroOperaciones(clsRegistroOperacion regope)
        {
            try
            {
                int s = 2;
                s = s + 3;

                XDocument xmldetalle = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                   new XElement("dsdataset",
                                   from item in regope.detalle
                                   select new XElement("dsdatatable",
                                    new XAttribute("idRol", item.nTipoRol == null ? 0 : item.nTipoRol), 
                                    new XAttribute("idRelacion", item.nTipoRelacion == null ? 0 : item.nTipoRelacion),
                                    new XAttribute("idTipoPersona", item.nTipoPersona == null ? 0 : item.nTipoPersona),
                                    new XAttribute("idTipoDocIdentidad", item.nTipoDocumento == null ? 0 : item.nTipoDocumento),
                                    new XAttribute("idTipoDocSPLAF", item.nTipoDocSPLAFT == null ? 0 : item.nTipoDocSPLAFT),
                                    new XAttribute("nDocIdentidad", item.cNumeroDocumento == null ? "" : item.cNumeroDocumento),
                                    new XAttribute("nRuc", item.cNumeroRuc == null ? "" : item.cNumeroRuc)                         ,
                                    new XAttribute("cApellidoPaterno", item.cApellidoPaterno == null ? "" : item.cApellidoPaterno),
                                    new XAttribute("cApellidoMaterno", item.cApellidoMaterno == null ? "" : item.cApellidoMaterno),
                                    new XAttribute("CNombres", item.cNombres == null ? "" : item.cNombres),
                                    new XAttribute("idOcupacion", item.nTipoOcupacion == null ? 0 : item.nTipoOcupacion),
                                    new XAttribute("codigoCIIU", item.nCodCIUU == null ? 0 : item.nCodCIUU),
                                    new XAttribute("cDescripcionOcupacion", item.cDescripcionOcupacion == null ? "" : item.cDescripcionOcupacion),
                                    new XAttribute("idCargo", item.nTipoCargo == null ? 0 : item.nTipoCargo),
                                    new XAttribute("idUbigeo", item.NIdUbigeo == null ? 0 : item.NIdUbigeo),
                                    new XAttribute("cDireccion", item.cDireccion == null ? "" : item.cDireccion),
                                    new XAttribute("nCodPais", item.codPais == null ? "" : item.codPais),
                                    new XAttribute("cPais", item.cPais == null ? "" : item.cPais),
                                    new XAttribute("nCodDepartamento", item.codDepartamento == null ? "" : item.codDepartamento),
                                    new XAttribute("cDepartamento", item.cDepartamento == null ? "" : item.cDepartamento),
                                    new XAttribute("nCodProvincia", item.codProvincia == null ? "" : item.codProvincia),
                                    new XAttribute("cProvincia", item.cProvincia == null ? "" : item.cProvincia),
                                    new XAttribute("nCodDistrito", item.codDistrito == null ? "" : item.codDistrito),
                                    new XAttribute("cDistrito", item.cDistrito == null ? "" : item.cDistrito),
                                    new XAttribute("cTelefono", item.cTelefono == null ? "" : item.cTelefono),
                                    new XAttribute("idResidencia", item.nCondicionResidencia == null ? 0 : item.nCondicionResidencia),
                                    new XAttribute("cOcupacion", item.cOcupacion==null ? "":item.cOcupacion),   
                                    new XAttribute("cCargo", item.cCargo == null ? "" : item.cCargo),
                                    new XAttribute("dFecNac", item.dFecNac)                         ,  
                                    new XAttribute("cCodPostal", item.cCodPostal == null ? "" : item.cCodPostal),
                                    new XAttribute("cApellidoCasado", item.cApellidoCasado == null ? "" : item.cApellidoCasado),
                                    new XAttribute("idNacionalidad", item.nidNacionalidad == null ? 0 : item.nidNacionalidad),
                                    new XAttribute("lSocio", item.lSocio),
                                    new XAttribute("cObjetoJuridico",""),
                                    new XAttribute("cCorreo", item.cCorreoCli == null ? "" : item.cCorreoCli),
                                    new XAttribute("idCli",item.nCodCli == null? 0 : item.nCodCli),
                                    new XAttribute("cOcupacionOtros", item.cOcupacionOtros == null ? "" : item.cOcupacionOtros),
                                    new XAttribute("nRucAlterno", item.nRucAlterno == null ? "" : item.nRucAlterno)
                                    )));
                

                string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmldetalle.ToString();


                ds = objEjeSp.EjecSP("GEN_InsertarDetalleSPL", regope.nidKardex         , regope.dfechaOperacion    , 
                                                                regope.dhoraOperacion   , regope.ncodEmpresa        , 
                                                                regope.cdescripcion     , regope.idInusual          , 
                                                                regope.idDetalleInusual , regope.corigen            , 
                                                                regope.cdestino         , regope.dMontoOperacion    , 
                                                                regope.nCuenta          , regope.nCodMoneda         , 
                                                                regope.nModulo          , regope.nidModalidad       , 
                                                                xmldetalle              , regope.nidDetalleRO       ,
                                                                clsVarGlobal.idCanal    , regope.idTipoOperacion,
                                                                clsVarGlobal.nIdAgencia , regope.idTipoPago         ,
                                                                clsVarGlobal.User.idUsuario
                                                                , regope.idSplaftDetOrdenPago
                                                                , regope.cSplaftDetOrdenPago);
                       

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public clsRegistroOperacion DevolverRegOpe(int idkardex)
        {
            clsRegistroOperacion registro = null;
            ds = objEjeSp.EjecSP("GEN_RecuperarRegOpe", idkardex);

            if (ds.Rows.Count>0)
            {
                registro = new clsRegistroOperacion();
                registro.cdescripcion = Convert.ToString(ds.Rows[0]["descripcion"]);
                registro.corigen = Convert.ToString(ds.Rows[0]["origen"]);
                registro.cdestino = Convert.ToString(ds.Rows[0]["destino"]);
                registro.idInusual = Convert.ToInt32(ds.Rows[0]["idInusual"]);
                registro.idDetalleInusual = Convert.ToInt32(ds.Rows[0]["idDetalleInusual"]);
                registro.idSplaftDetOrdenPago = Convert.ToInt32(ds.Rows[0]["idSplaftDetOrdenPago"]);
                registro.cSplaftDetOrdenPago = Convert.ToString(ds.Rows[0]["cSplaftDetOrdenPago"]);
            }            
            
            return registro;
        }



        public DataTable DevolverRegOpeDataTable(int idkardex)
        {          
            ds = objEjeSp.EjecSP("GEN_RecuperarRegOpe", idkardex);
            return ds;
        }




        public void actualizarReOpPe(clsRegistroOperacion regope)
        {
            try
            {
                ds = objEjeSp.EjecSP("GEN_ActualizarRegOpe", regope.nidKardex, regope.cdescripcion, regope.idInusual, regope.idDetalleInusual, regope.corigen, regope.cdestino);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ExisteRegistro(int kardex)
        {            
            ds = objEjeSp.EjecSP("GEN_BuscarRegOpe", kardex);
            if (ds.Rows.Count==0)
            {
                return false;
            }
            return true;
        }

        public DataTable ADListarSplaftDetNotaPedido()
        {
            return objEjeSp.EjecSP("SPL_ListaDetSplaftOrdenPago_SP");
        }


    }
}

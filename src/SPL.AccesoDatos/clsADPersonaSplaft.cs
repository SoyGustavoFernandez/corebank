using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace SPL.AccesoDatos
{
    public class clsADPersonaSplaft
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public clsListaPersonaSplaft ListarPersonaSPLAFT(int idKardex, int idModulo)
        {
            clsListaPersonaSplaft lista = new clsListaPersonaSplaft();

            switch (idModulo)
            {
                case 1:  //--Créditos
                    ds = objEjeSp.EjecSP("GEN_ListarSPL_Credito", idKardex, idModulo);
                    foreach (DataRow item in ds.Rows)
                    {
                        lista.Add(new clsPersonaSplaft()
                        {
                            nCodCli                 = Convert.ToInt32(item["idCli"]),
                            nTipoRelacion           = Convert.ToInt32(item["tipoRelacion"]),
                            nCondicionResidencia    = Convert.ToInt32(item["idResiddencia"]),
                            nTipoPersona            = Convert.ToInt32(item["IdTipoPersona"]),
                            nTipoDocumento          = Convert.ToInt32(item["idTipoDocumento"]),
                            nTipoDocSPLAFT          = Convert.ToInt32(item["cCodSPLAF"]),
                            cNumeroDocumento        = Convert.ToString(item["cDocumentoID"]),
                            cNumeroRuc              = Convert.ToString(item["cDocumentoAdicional"]),
                            cApellidoPaterno        = Convert.ToString(item["cApellidoPat"]),
                            cApellidoMaterno        = Convert.ToString(item["cApellidoMat"]),
                            cApellidoCasado         = Convert.ToString(item["cApellidoCas"]),
                            cNombres                = Convert.ToString(item["cNombre"]),
                            nTipoOcupacion          = Convert.ToInt32(item["idOcupacion"]),
                            nCodCIUU                = Convert.ToInt32(item["nIdActivEco"]),
                            nTipoCargo              = Convert.ToInt32(item["idCargo"]),
                            NIdUbigeo               = Convert.ToInt32(item["idUbigeo"]),
                            cDireccion              = Convert.ToString(item["cDireccion"]),
                            cTelefono               = Convert.ToString(item["nNumeroTelefono"]),
                            bPresencia              = Convert.ToBoolean(item["presencia"]),
                            nTipoPerClas            = Convert.ToInt32(item["idTipoPerClasifica"]),
                            dFecNac                 = Convert.ToDateTime(item["dFechaNacRe"]),
                            cDescripcionOcupacion   = Convert.ToString(item["cOcupacion"]),
                            cRazonSocial            = Convert.ToString(item["cRazonSocial"]),
                            lSocio                  = Convert.ToBoolean(item["lSocio"]),
                            nidNacionalidad         = Convert.ToInt32(item["idNacionalidad"]),
                            cNacionalidad           = Convert.ToString(item["cNacionalidad"]),
                            cNombreComercial        = Convert.ToString(item["cNombreComercial"]),
                            cPartidaRegistral       = Convert.ToString(item["nNumPartReg"]),
                            cNombreCompleto         = Convert.ToString(item["cNombreCompleto"]),
                            cCorreoCli              = Convert.ToString(item["cCorreoCli"]),
                            cCargo                  = Convert.ToString(item["cCargo"])
                        
                        }

                        );
                    }    
                break;


                case 2: //--Ahorros
                    ds = objEjeSp.EjecSP("GEN_ListarSPL_Ahoro", idKardex, idModulo);
                    foreach (DataRow item in ds.Rows)
                    {
                        lista.Add(new clsPersonaSplaft()
                        {
                            nCodCli                 = Convert.ToInt32(item["idCli"]),
                            nTipoRelacion           = Convert.ToInt32(item["tipoRelacion"]),
                            nCondicionResidencia    = Convert.ToInt32(item["idResiddencia"]),
                            nTipoPersona            = Convert.ToInt32(item["IdTipoPersona"]),
                            nTipoDocumento          = Convert.ToInt32(item["idTipoDocumento"]),
                            nTipoDocSPLAFT          = Convert.ToInt32(item["cCodSPLAF"]),
                            cNumeroDocumento        = Convert.ToString(item["cDocumentoID"]),
                            cNumeroRuc              = Convert.ToString(item["cDocumentoAdicional"]),
                            cApellidoPaterno        = Convert.ToString(item["cApellidoPat"]),
                            cApellidoMaterno        = Convert.ToString(item["cApellidoMat"]),
                            cApellidoCasado         = Convert.ToString(item["cApellidoCas"]),
                            cNombres                = Convert.ToString(item["cNombre"]),
                            nTipoOcupacion          = Convert.ToInt32(item["idOcupacion"]),
                            nCodCIUU                = Convert.ToInt32(item["nIdActivEco"]),
                            nTipoCargo              = Convert.ToInt32(item["idCargo"]),
                            NIdUbigeo               = Convert.ToInt32(item["idUbigeo"]),
                            cDireccion              = Convert.ToString(item["cDireccion"]),
                            cTelefono               = Convert.ToString(item["nNumeroTelefono"]),
                            bPresencia              = Convert.ToBoolean(item["presencia"]),
                            nTipoPerClas            = Convert.ToInt32(item["idTipoPerClasifica"]),
                            dFecNac                 = Convert.ToDateTime(item["dFechaNacRe"]),
                            cDescripcionOcupacion   = Convert.ToString(item["cOcupacion"]),
                            cRazonSocial            = Convert.ToString(item["cRazonSocial"]),
                            lSocio                  = Convert.ToBoolean(item["lSocio"]),
                            nidNacionalidad         = Convert.ToInt32(item["idNacionalidad"]),
                            cNacionalidad           = Convert.ToString(item["cNacionalidad"]),
                            cNombreComercial        = Convert.ToString(item["cNombreComercial"]),
                            cPartidaRegistral       = Convert.ToString(item["nNumPartReg"]),
                            cNombreCompleto         = Convert.ToString(item["cNombreCompleto"]),
                            cCorreoCli              = Convert.ToString(item["cCorreoCli"]),
                            cCargo                  = Convert.ToString(item["cCargo"])
                        }
                        );
                    }  

                break;

                case 9: //--Sevicios CV
                ds = objEjeSp.EjecSP("GEN_ListarSPLCompraVenta_SP", idKardex, idModulo);
                foreach (DataRow item in ds.Rows)
                {
                    lista.Add(new clsPersonaSplaft()
                    {
                        nCodCli = Convert.ToInt32(item["idCli"]),
                        nTipoRelacion = Convert.ToInt32(item["tipoRelacion"]),
                        nCondicionResidencia = Convert.ToInt32(item["idResiddencia"]),
                        nTipoPersona = Convert.ToInt32(item["IdTipoPersona"]),
                        nTipoDocumento = Convert.ToInt32(item["idTipoDocumento"]),
                        nTipoDocSPLAFT = Convert.ToInt32(item["cCodSPLAF"]),
                        cNumeroDocumento = Convert.ToString(item["cDocumentoID"]),
                        cNumeroRuc = Convert.ToString(item["cDocumentoAdicional"]),
                        cApellidoPaterno = Convert.ToString(item["cApellidoPat"]),
                        cApellidoMaterno = Convert.ToString(item["cApellidoMat"]),
                        cApellidoCasado = Convert.ToString(item["cApellidoCas"]),
                        cNombres = Convert.ToString(item["cNombre"]),
                        nTipoOcupacion = Convert.ToInt32(item["idOcupacion"]),
                        nCodCIUU = Convert.ToInt32(item["nIdActivEco"]),
                        nTipoCargo = Convert.ToInt32(item["idCargo"]),
                        NIdUbigeo = Convert.ToInt32(item["idUbigeo"]),
                        cDireccion = Convert.ToString(item["cDireccion"]),
                        cTelefono = Convert.ToString(item["nNumeroTelefono"]),
                        bPresencia = Convert.ToBoolean(item["presencia"]),
                        nTipoPerClas = Convert.ToInt32(item["idTipoPerClasifica"]),
                        dFecNac = Convert.ToDateTime(item["dFechaNacRe"]),
                        cDescripcionOcupacion = Convert.ToString(item["cOcupacion"]),
                        cRazonSocial = Convert.ToString(item["cRazonSocial"]),
                        lSocio = Convert.ToBoolean(item["lSocio"]),
                        nidNacionalidad = Convert.ToInt32(item["idNacionalidad"]),
                        cNacionalidad = Convert.ToString(item["cNacionalidad"]),
                        cNombreComercial = Convert.ToString(item["cNombreComercial"]),
                        cPartidaRegistral = Convert.ToString(item["nNumPartReg"]),
                        cNombreCompleto = Convert.ToString(item["cNombreCompleto"]),
                        cCorreoCli = Convert.ToString(item["cCorreoCli"]),
                        cCargo = Convert.ToString(item["cCargo"])

                    }

                    );
                }
                break;

                default:
                break;
            }

            

            return lista;
        }

        public clsPersonaSplaft BuscarPersona(int idCliente) 
        {
            //GEN_BuscarPersonaSPL
            clsPersonaSplaft objPerso=null;
            ds = objEjeSp.EjecSP("GEN_BuscarPersonaSPL", idCliente);
            if (ds.Rows.Count > 0)
            {
                objPerso = new clsPersonaSplaft();
                objPerso.nCodCli = Convert.ToInt32(ds.Rows[0]["idCli"]);
                objPerso.nCondicionResidencia = Convert.ToInt32(ds.Rows[0]["idResiddencia"]);
                objPerso.nTipoPersona = Convert.ToInt32(ds.Rows[0]["IdTipoPersona"]);
                objPerso.nTipoDocumento = Convert.ToInt32(ds.Rows[0]["idTipoDocumento"]);
                objPerso.cNumeroDocumento = Convert.ToString(ds.Rows[0]["cDocumentoID"]);
                objPerso.cNumeroRuc = Convert.ToString(ds.Rows[0]["cDocumentoAdicional"]);
                objPerso.cApellidoPaterno = Convert.ToString(ds.Rows[0]["cApellidoPat"]);
                objPerso.cApellidoMaterno = Convert.ToString(ds.Rows[0]["cApellidoMat"]);
                objPerso.cApellidoCasado = Convert.ToString(ds.Rows[0]["cApellidoCas"]);
                objPerso.cNombres = Convert.ToString(ds.Rows[0]["cNombre"]);
                objPerso.nTipoOcupacion = Convert.ToInt32(ds.Rows[0]["idOcupacion"]);
                objPerso.nCodCIUU = Convert.ToInt32(ds.Rows[0]["nIdActivEco"]);
                objPerso.nTipoCargo = Convert.ToInt32(ds.Rows[0]["idCargo"]);
                objPerso.NIdUbigeo = Convert.ToInt32(ds.Rows[0]["idUbigeo"]);
                objPerso.cDireccion = Convert.ToString(ds.Rows[0]["cDireccion"]);
                objPerso.cTelefono = Convert.ToString(ds.Rows[0]["nNumeroTelefono"]);
                objPerso.cRazonSocial = Convert.ToString(ds.Rows[0]["cApellidoPat"]);
                objPerso.cPartidaRegistral = Convert.ToString(ds.Rows[0]["nNumPartReg"]);
                objPerso.cNombreComercial = Convert.ToString(ds.Rows[0]["cNombre"]);
                objPerso.dFecNac = Convert.ToDateTime(ds.Rows[0]["dFechaNacRe"]);
                objPerso.cCodPostal = "";
                objPerso.nTipoRelacion = Convert.ToInt32(ds.Rows[0]["tipoRelacion"]);
                objPerso.cDescripcionOcupacion = Convert.ToString(ds.Rows[0]["cOcupacion"]);
                objPerso.lSocio = Convert.ToBoolean(ds.Rows[0]["lSocio"]);
                objPerso.nidNacionalidad = Convert.ToInt32(ds.Rows[0]["idNacionalidad"]);
                objPerso.cNacionalidad = Convert.ToString(ds.Rows[0]["cNacionalidad"]);
                objPerso.cNombreCompleto = Convert.ToString(ds.Rows[0]["cNombreCompleto"]);
                objPerso.cCorreoCli = Convert.ToString(ds.Rows[0]["cCorreoCli"]);
            }
            return objPerso;
        }
        
        public DataTable DevolverPersonaDT(int idkardex)
        {          
            ds = objEjeSp.EjecSP("GEN_RecuperarPersonas", idkardex);
            return ds;
        }
        
        public clsListaPersonaSplaft DevolverPersonas(int idkardex)
        {
            clsListaPersonaSplaft lista = new clsListaPersonaSplaft();
            ds = objEjeSp.EjecSP("GEN_RecuperarPersonas", idkardex);


            foreach (DataRow item in ds.Rows)
            {
                lista.Add(new clsPersonaSplaft()
                {        
			        nCodOperacion=Convert.ToInt32(item["idCodOperacion"]),			
			        nTipoRol=Convert.ToInt32(item["idRol"]),					
			        nTipoRelacion=Convert.ToInt32(item["idRelacion"]),	
			        nTipoPersona=Convert.ToInt32(item["idTipoPersona"]),
			        nTipoDocumento=Convert.ToInt32(item["idTipoDocIdentidad"]),		
			        nTipoDocSPLAFT=Convert.ToInt32(item["idTipoDocSPLAF"]),			
			        cNumeroDocumento=Convert.ToString(item["nDocIdentidad"]),	
			        cNumeroRuc=Convert.ToString(item["nRuc"]),					
			        cApellidoPaterno=Convert.ToString(item["cApellidoPaterno"]),		
			        cApellidoMaterno=Convert.ToString(item["cApellidoMaterno"]),		
			        cNombres=Convert.ToString(item["CNombres"]),				
			        nTipoOcupacion=Convert.ToInt32(item["idOcupacion"]),	
			        nCodCIUU=Convert.ToInt32(item["codigoCIIU"]),	
			        idCIIUNivel1 = Convert.ToInt32(item["codigoCIIU1"]),
                    idCIIUNivel2 = Convert.ToInt32(item["codigoCIIU2"]),	
			        cDescripcionOcupacion=Convert.ToString(item["cDescripcionOcupacion"]),	
			        nTipoCargo=Convert.ToInt32(item["idCargo"]),		
                    NIdUbigeo = Convert.ToInt32(item["idUbigeo"]),
			        cDireccion=Convert.ToString(item["cDireccion"]),	
			        cDepartamento=Convert.ToString(item["cDepartamento"]),	
			        cProvincia=Convert.ToString(item["cProvincia"]),		
			        cDistrito=Convert.ToString(item["cDistrito"]),
			        cTelefono=Convert.ToString(item["cTelefono"]),
                    cNombreCompleto = Convert.ToString(item["cNombre"]),
                    cOcupacionOtros = Convert.ToString(item["cOcupacionOtros"]),
                    cRazonSocial = Convert.ToString(item["cRazonSocial"]),
                    cNombreComercial = Convert.ToString(item["cNombreComercial"])
                }
                );
            }    


            return lista;
        }
        
        public void actualizarPersonaSPL(clsListaPersonaSplaft regope, int idKardex)
        { 
            try
            {
                XDocument xmldetalle = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                   new XElement("dsdataset",
                                   from item in regope
                                   select new XElement("dsdatatable",
                                                    new XAttribute("nidKardex", idKardex),
                                                    new XAttribute("nDocIndentidad", item.cNumeroDocumento),
                                                    new XAttribute("idOcupacion", item.nTipoOcupacion),
                                                    new XAttribute("codigoCIIU", item.nCodCIUU),
                                                    new XAttribute("cDescripcionOcupacion", item.cDescripcionOcupacion),
                                                    new XAttribute("idCargo", item.nTipoCargo),
                                                    new XAttribute("idUbigeo", item.NIdUbigeo),
                                                    new XAttribute("cDireccion", item.cDireccion),
                                                    new XAttribute("cPais", item.cPais),
                                                    new XAttribute("cDepartamento", item.cDepartamento),
                                                    new XAttribute("cProvincia", item.cProvincia),
                                                    new XAttribute("cDistrito", item.cDistrito),
                                                    new XAttribute("cTelefono", item.cTelefono))
                                                    )
                                  );


                string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmldetalle.ToString();
                ds = objEjeSp.EjecSP("GEN_ActualizarPersonaSPL", idKardex, xmldetalle);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public clsListaPersonaSplaft ListarRepresentanteSPLAFT(int idCli)
        {
            clsListaPersonaSplaft lista = new clsListaPersonaSplaft();

            ds = objEjeSp.EjecSP("GEN_ListarSPL_RepresentatePersoJuri_SP", idCli);
            foreach (DataRow item in ds.Rows)
            {
                lista.Add(new clsPersonaSplaft()
                {
                    nCodCli = Convert.ToInt32(item["idCli"]),
                    nTipoRelacion = Convert.ToInt32(item["tipoRelacion"]),
                    nCondicionResidencia = Convert.ToInt32(item["idResiddencia"]),
                    nTipoPersona = Convert.ToInt32(item["IdTipoPersona"]),
                    nTipoDocumento = Convert.ToInt32(item["idTipoDocumento"]),
                    nTipoDocSPLAFT = Convert.ToInt32(item["cCodSPLAF"]),
                    cNumeroDocumento = Convert.ToString(item["cDocumentoID"]),
                    cNumeroRuc = Convert.ToString(item["cDocumentoAdicional"]),
                    cApellidoPaterno = Convert.ToString(item["cApellidoPat"]),
                    cApellidoMaterno = Convert.ToString(item["cApellidoMat"]),
                    cApellidoCasado = Convert.ToString(item["cApellidoCas"]),
                    cNombres = Convert.ToString(item["cNombre"]),
                    nTipoOcupacion = Convert.ToInt32(item["idOcupacion"]),
                    nCodCIUU = Convert.ToInt32(item["nIdActivEco"]),
                    nTipoCargo = Convert.ToInt32(item["idCargo"]),
                    NIdUbigeo = Convert.ToInt32(item["idUbigeo"]),
                    cDireccion = Convert.ToString(item["cDireccion"]),
                    cTelefono = Convert.ToString(item["nNumeroTelefono"]),
                    bPresencia = Convert.ToBoolean(item["presencia"]),
                    nTipoPerClas = Convert.ToInt32(item["idTipoPerClasifica"]),
                    dFecNac = Convert.ToDateTime(item["dFechaNacRe"]),
                    cDescripcionOcupacion = Convert.ToString(item["cOcupacion"]),
                    cRazonSocial = Convert.ToString(item["cRazonSocial"]),
                    lSocio = Convert.ToBoolean(item["lSocio"]),
                    nidNacionalidad = Convert.ToInt32(item["idNacionalidad"]),
                    cNacionalidad = Convert.ToString(item["cNacionalidad"]),
                    cNombreComercial = Convert.ToString(item["cNombreComercial"]),
                    cPartidaRegistral = Convert.ToString(item["nNumPartReg"]),
                    cNombreCompleto = Convert.ToString(item["cNombreCompleto"]),
                    cCorreoCli = Convert.ToString(item["cCorreoCli"]),
                    cCargo = Convert.ToString(item["cCargo"])

               }
               );
            }

            return lista;
        }


    }
}

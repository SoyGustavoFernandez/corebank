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
    public class clsADPep
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public clsListaPep listarPep() 
        {
            clsListaPep listPep = new clsListaPep();

            return listPep;
        }

        public void guardarPep(clsPep pep, int idEstadoRegistro, int idUsuario, int idAgeCol) 
        {
            try
            {
                XDocument xmldetalle = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                   new XElement("dsdataset",
                                   from item in pep.familiares
                                   select new XElement("dsdatatable",
                                                    new XAttribute("cNombres", item.cNombres),
                                                    new XAttribute("cPaterno", item.cApePaterno),
                                                    new XAttribute("cMaterno", item.cApeMaterno),
                                                    new XAttribute("idTipoDoc", item.idTipoDoc),
                                                    new XAttribute("nDocumento", item.nNumDoc),
                                                    new XAttribute("nIdVinculo", item.nIdVinculo),
                                                    new XAttribute("cDescripcion", item.cDescripcion),
                                                    new XAttribute("cDireccion", item.cDireccion)
                                                    )
                                                    )
                                  );

                string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmldetalle.ToString();
                ds = objEjeSp.EjecSP("GEN_InsertarPep_sp", pep.cNombres, pep.cApePaterno, 
                                                        pep.cApeMaterno, pep.cCargo, 
                                                        pep.nDocumento, pep.idTipoDoc, pep.dFechaNac,
                                                        pep.cInstitucion,
                                                        pep.dFecIni, pep.dFecFin, pep.bEstadoPercent,
                                                        pep.cEmpresa, pep.bEstadoAprob, pep.cObservaciones,
                                                        pep.idcli, xmldetalle, idEstadoRegistro, idUsuario, idAgeCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public clsPep BuscarPersonaPep(int idTipoDoc, string nNumDoc, int idCli)
        {
            clsPep pers = new clsPep();
            ds = objEjeSp.EjecSP("GEN_BuscarPersonaPep_sp", idTipoDoc, nNumDoc, idCli);
            clsListaFamiliar lista = new clsListaFamiliar();
            try
            {
                pers.idPep          = Convert.ToInt32(ds.Rows[0]["idPep"]);
                pers.cApePaterno    = ds.Rows[0]["cPaterno"] == System.DBNull.Value ? "" :Convert.ToString(ds.Rows[0]["cPaterno"]);
                pers.cApeMaterno    = ds.Rows[0]["cMaterno"] == System.DBNull.Value ? "" :Convert.ToString(ds.Rows[0]["cMaterno"]);
                pers.cNombres       = ds.Rows[0]["cNombres"] == System.DBNull.Value ? "" :Convert.ToString(ds.Rows[0]["cNombres"]);
                pers.cInstitucion   = ds.Rows[0]["cInstitucion"] == System.DBNull.Value ? "" :Convert.ToString(ds.Rows[0]["cInstitucion"]);
                pers.cCargo         = ds.Rows[0]["cCargo"] == System.DBNull.Value ? "" : Convert.ToString(ds.Rows[0]["cCargo"]);
                pers.nDocumento     = ds.Rows[0]["nDocumento"] == System.DBNull.Value ? "" : Convert.ToString(ds.Rows[0]["nDocumento"]);
                pers.bEstadoAprob   = ds.Rows[0]["bEstadoAprobacion"] == System.DBNull.Value ? false :Convert.ToBoolean(ds.Rows[0]["bEstadoAprobacion"]);
                pers.bEstadoPercent = ds.Rows[0]["bPorcentaje"] == System.DBNull.Value ? false : Convert.ToBoolean(ds.Rows[0]["bPorcentaje"]);
                pers.dFechaNac      = ds.Rows[0]["dFechaNac"] == System.DBNull.Value ? clsVarGlobal.dFecSystem  : Convert.ToDateTime(ds.Rows[0]["dFechaNac"]);
                pers.dFecFin        = ds.Rows[0]["dFecFin"] == System.DBNull.Value ? clsVarGlobal.dFecSystem : Convert.ToDateTime(ds.Rows[0]["dFecFin"]);
                pers.dFecIni        = ds.Rows[0]["dFecIni"] == System.DBNull.Value ? clsVarGlobal.dFecSystem : Convert.ToDateTime(ds.Rows[0]["dFecIni"]);
                pers.cObservaciones = ds.Rows[0]["cObservaciones"] == System.DBNull.Value ? "":Convert.ToString(ds.Rows[0]["cObservaciones"]);
                pers.cEstado        = Convert.ToString(ds.Rows[0]["cEstado"]);
                pers.idTipoDoc      = ds.Rows[0]["idTipoDocumento"] == System.DBNull.Value ? 0 : Convert.ToInt32(ds.Rows[0]["idTipoDocumento"]);
                
                if (Convert.ToBoolean(pers.bEstadoPercent))
                {
                     pers.cEmpresa = Convert.ToString(ds.Rows[0]["cEmpresa"]);
                }
                else
                {
                    pers.cEmpresa = "";
                }

                ds = null;
                
                ds = objEjeSp.EjecSP("GEN_RecuperarFamiliaresSPL_sp", pers.idPep);
                int i = 0;   
                foreach (DataRow item in ds.Rows)                     
                {
                    lista.Add(new clsFamiliar()          
                        {   idFam       = Convert.ToInt32(ds.Rows[i]["idFam"]),   
                            cApeMaterno = Convert.ToString(ds.Rows[i]["cApeMaterno"]),
                            cApePaterno = Convert.ToString(ds.Rows[i]["cApePaterno"]),
                            cNombres    = Convert.ToString(ds.Rows[i]["cNombres"]),
                            nNumDoc     = Convert.ToString(ds.Rows[i]["nNumDoc"]),
                            cDescripcion     = Convert.ToString(ds.Rows[i]["cDescripcion"]),
                            idTipoDoc = Convert.ToInt32(ds.Rows[i]["idTipoDocumento"]),
                            cTipoDoc = Convert.ToString(ds.Rows[i]["cTipoDoc"])
                        }
                    );
                    i += 1;
                }

                pers.familiares = lista;

                return pers;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



        public DataTable actualizarPep(clsPep pep, string XmlNuevosFamiliares, string XmlFamiliaresEliminados, int idEstadoRegistro, int idUsuario, int idAgeCol) 
        {
            try
            {               

                /*XDocument xmldetalle = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                   new XElement("dsdataset",
                                   from item in pep.familiares
                                   select new XElement("dsdatatable",
                                                    new XAttribute("cNombres", item.cNombres),
                                                    new XAttribute("cPaterno", item.cApePaterno),
                                                    new XAttribute("cMaterno", item.cApeMaterno),
                                                    new XAttribute("nDocumento", item.nNumDoc),
                                                    new XAttribute("nIdVinculo", item.nIdVinculo))
                                                    )
                                  );*/

                //string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmldetalle.ToString();
                return objEjeSp.EjecSP("GEN_ActualizarPep_sp", pep.idPep, pep.cNombres, pep.cApePaterno, 
                                                        pep.cApeMaterno, pep.cCargo, 
                                                        pep.nDocumento, pep.idTipoDoc,  pep.dFechaNac,
                                                        pep.cInstitucion,
                                                        pep.dFecIni, pep.dFecFin, pep.bEstadoPercent,
                                                        pep.cEmpresa, pep.bEstadoAprob, pep.cObservaciones,
                                                        pep.idcli, XmlNuevosFamiliares, XmlFamiliaresEliminados, idEstadoRegistro, idUsuario, idAgeCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable buscarDaTosCliente(int nNumDoc)
        {
            clsPep pers = new clsPep();
            ds = objEjeSp.EjecSP("GEN_BuscarDatosCliente", nNumDoc);
            return ds;
        }


        public DataTable EliminarPesonaListaPEP(int idPep)
        {
            return objEjeSp.EjecSP("GEN_EliminarPesonaListaPEP_SP", idPep);
        }

        public DataTable DatosPepCliente(int idCli)
        {
            return objEjeSp.EjecSP("SPL_DatosPepCliente_SP", idCli);
        }

        //--=====================================================================
        //-----Lista Solicitudes Pendientes por Aprobar (PEP)
        //--=====================================================================
        public DataTable ADListarPepPorAprobar()
        {
            return objEjeSp.EjecSP("SPL_ListarSolAprPEP_sp");
        }

        //--=====================================================================
        //-----Registra Aprobacion (PEP)
        //--=====================================================================
        public DataTable ADActualizarAprPep(int idPep, bool lIsApr, string cSustento, int idUsuario, int idAgencia, DateTime dFecRegistro)
        {
            return objEjeSp.EjecSP("SPL_ActualizaAprPepSPL_SP",idPep, lIsApr, cSustento, idUsuario, idAgencia, dFecRegistro);
        }

        public DataTable ADCargarClientesPEP(string cXml, DateTime dFechaReg)
        {
            return objEjeSp.EjecSP("SPL_GuardarCargaClientePEP_SP", cXml, dFechaReg);
        }

        public DataTable ADImprimirFichaPEP(int idPep, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("SPL_FichaClientePEP_SP", idPep, dFechaSis);
        }

        public DataTable ADObtenerPepNroDocumento(string cDocumento)
        {
            return objEjeSp.EjecSP("SPL_ObtenPepPorDocumento_SP", cDocumento);
        }
    }
}

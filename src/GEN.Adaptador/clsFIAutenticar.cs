using EntityLayer;
using GEN.CapaNegocio;
using GEN.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GEN.Funciones;
using System.Xml;

namespace GEN.Adaptador
{
    public partial class clsFAAutenticar : IAutenticacion
    {
        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        string cPlantillaRpta =
                   "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                   "<resultado><respuesta><idEstado>{0}</idEstado><cMensaje>{1}</cMensaje><cToken>{2}</cToken></respuesta>" +
                    "<data>{3}</data></resultado>";

        public string WSValidarUsuario(string cUsuario, string cClave, string cImei, string cNombEquipo, string cCaracteristicas)
        {
            clsVarGlobal.IConectionGen = new ConnectionWeb();
            clsAutenticacion autenticacion = new clsAutenticacion();
            string cRespuestaXML = String.Empty;
            usuario.CodigoAD = cUsuario.Trim();
            usuario.clave = cClave.Trim();
            clsUsuario user = null;
            IList<clsAgencia> lstAgencias = null;
            IList<clsPerfilUsu> lstPerfiles = null;
            clsVarGlobalClone objVarGlobal = null;
            clsDatosToken datosToken = null;

            if (autenticacion.AutenticarWeb(usuario.CodigoAD, usuario.clave, ref user))
            {
                if (new clsPcUsuario().validarDatosPc(user.idUsuario, cImei, cNombEquipo, cCaracteristicas))
                {
                    objVarGlobal = new clsVarGlobalClone();
                    lstAgencias = new clsCNAgenciaUsu().CNListarAgenciasUsuario(user.idUsuario);
                    lstPerfiles = new clsCNPerfilUsu().ListarPerUsu(user.idUsuario);
                    new clsCNVarGen().GetVarGlobal(1,objVarGlobal);

                    datosToken = new clsDatosToken();
                    datosToken.dFechaSistema = objVarGlobal.dFecSystem;
                    datosToken.dInicioSession = DateTime.UtcNow;
                    datosToken.idUsuario = user.idUsuario;
                    datosToken.guidUser = Guid.NewGuid();
                    datosToken.cImei = cImei;

                    string cListados = String.Empty;

                    if (lstAgencias.Count == 0)
                    {
                        cRespuestaXML = String.Format(cPlantillaRpta, 404, "El usuario no tiene acceso a ninguna agencia.", 
                                                    String.Empty, String.Empty);
                        return cRespuestaXML;
                    }
                    else
                    {
                        if (lstAgencias.Count == 1)
                        {
                            datosToken.idAgencia = lstAgencias.First().idAgencia;
                        }
                        else
                        {
                            string xmlAgencias = lstAgencias.GetXml();
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(xmlAgencias);
                            foreach (XmlNode node in xmlDoc)
                            {
                                if (node.NodeType == XmlNodeType.XmlDeclaration)
                                {
                                    xmlDoc.RemoveChild(node);
                                }
                            }
                            XmlNodeList nodes = xmlDoc.SelectNodes("/ArrayOfClsAgencia/clsAgencia");
                            for (int i = nodes.Count - 1; i >= 0; i--)
                            {
                                for (int j = nodes[i].ChildNodes.Count - 1; j >= 0; j--)
                                {
                                    if (nodes[i].ChildNodes[j].Name != "idAgencia" && nodes[i].ChildNodes[j].Name != "cNombreAge")
                                    {
                                        nodes[i].ChildNodes[j].ParentNode.RemoveChild(nodes[i].ChildNodes[j]);
                                    }
                                }
                            }
                            cListados += xmlDoc.OuterXml;
                        }
                    }

                    if (lstPerfiles.Count == 0)
                    {

                        cRespuestaXML = String.Format(cPlantillaRpta, 404, "El usuario no tiene perfiles asignados.", 
                                                    String.Empty, String.Empty);
                        return cRespuestaXML;
                    }
                    else
                    {
                        if (lstPerfiles.Count == 1)
                        {
                            datosToken.idAgencia = lstPerfiles.First().idPerfil;
                        }
                        else
                        {
                            string xmlPerfiles = lstPerfiles.GetXml();
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(xmlPerfiles);
                            foreach (XmlNode node in xmlDoc)
                            {
                                if (node.NodeType == XmlNodeType.XmlDeclaration)
                                {
                                    xmlDoc.RemoveChild(node);
                                }
                            }
                            XmlNodeList nodes = xmlDoc.SelectNodes("/ArrayOfClsPerfilUsu/clsPerfilUsu");
                            for (int i = nodes.Count - 1; i >= 0; i--)
                            {
                                for (int j = nodes[i].ChildNodes.Count - 1; j >= 0; j--)
                                {
                                    if (nodes[i].ChildNodes[j].Name != "idPerfil" && nodes[i].ChildNodes[j].Name != "cPerfil")
                                    {
                                        nodes[i].ChildNodes[j].ParentNode.RemoveChild(nodes[i].ChildNodes[j]);
                                    }
                                }
                            }
                            
                            cListados += xmlDoc.OuterXml;
                        }
                    }

                    if (!String.IsNullOrEmpty(cListados))
                    {
                        cRespuestaXML = String.Format(cPlantillaRpta, 202, String.Empty, usuario.GeneraToken(datosToken), 
                                                    cListados);
                        return cRespuestaXML;
                    }

                    cRespuestaXML = String.Format(cPlantillaRpta, 202, String.Empty, usuario.GeneraToken(datosToken), cListados);
                }
                else
                {
                    cRespuestaXML = String.Format(cPlantillaRpta, 404, "El equipo no está autorizado.", 
                                                                String.Empty,String.Empty);
                }
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, "Usuario y/o contraseña no son correctas.", 
                                                             String.Empty, String.Empty);
            }
            return cRespuestaXML;
        }

        public string WSAsignarAgenPerfil(string cToken, int idAgencia, int idPerfil)
        {
            string cRespuestaXML = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (datosToken == null)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 404, "Token inválido.",
                                                    String.Empty, String.Empty);
                return cRespuestaXML;
            }

            if (idAgencia <= 0)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 404, "La agencia enviada no es válida.",
                                                    String.Empty, String.Empty);
                return cRespuestaXML;
            }

            if (idPerfil <= 0)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 404, "El perfil enviado no es válido.",
                                                    String.Empty, String.Empty);
                return cRespuestaXML;
            }

            
            datosToken.idAgencia = idAgencia;
            datosToken.idPerfil = idPerfil;

            if (usuario.validaToken(cToken))
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 200, "Datos asignados correctamente.",
                                                    usuario.GeneraToken(datosToken), String.Empty);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, "Token invalido o expiró.",
                                                    String.Empty, String.Empty);
                
            }
            return cRespuestaXML;
        }
    }
}
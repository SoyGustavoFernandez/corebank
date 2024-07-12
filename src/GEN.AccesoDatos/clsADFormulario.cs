using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADFormulario
    {
        clsGENEjeSP objEjec = new clsGENEjeSP();

        public ArrayList validarRegFormulario(string cNombreForm)
        {
            ArrayList parametrosSalida = new ArrayList();
            int IndExiste = 0, idEstado=0;

            var listaparams = objEjec.EjecSPOut("GEN_ValidaExiRegForm_sp", cNombreForm, 0, 0);

            IndExiste = (int)listaparams[0].Parametro.Value;
            idEstado = (int)listaparams[1].Parametro.Value;

            parametrosSalida.Add(IndExiste);
            parametrosSalida.Add(idEstado);

            return parametrosSalida;
        }

        public void insertarControles(clsFormulario formulario)
        {
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dscontroles",
                                          from item in formulario.lisControles
                                          select new XElement("dtcontroles",
                                                              new XAttribute("cControl", item.cControl)))).ToString();

            objEjec.EjecSPAlm("GEN_InsCtrform_sp", formulario.cFormulario, formulario.idModulo, cxml, formulario.idTipoForm);
        }

        public clslisControl listarcontrolesByPerfil(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            clslisControl liscontroles = new clslisControl();
            DataTable dtControles = objEjec.EjecSP("GEN_lisObjByPerfil_sp", cNombreForm, idPerfil, idTipoEvento);
            foreach (DataRow item in dtControles.Rows)
            {
                liscontroles.Add(new clsControl()
                {
                    cControl = item["cControl"].ToString(),
                    idEstado = Convert.ToInt32(item["idEstado"]),
                    idFormulario = Convert.ToInt32(item["idFormulario"])
                });
            }

            return liscontroles;
        }

        public clslisFormulario listarFormularios(int idModulo)
        {
            clslisFormulario listaforms = new clslisFormulario();

            DataTable dtControles = objEjec.EjecSP("GEN_lisFormsByModulo_sp", idModulo);
            foreach (DataRow item in dtControles.Rows)
            {
                listaforms.Add(new clsFormulario()
                {
                    cFormulario = item["cFormulario"].ToString(),
                    idModulo = Convert.ToInt32(item["idModulo"]),
                    idEstado = Convert.ToInt32(item["idEstado"]),
                    idFormulario = Convert.ToInt32(item["idFormulario"])
                });
            }

            return listaforms;
        }

        public clslisControl listarcontrolesByForm(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            clslisControl liscontroles = new clslisControl();
            DataTable dtControles = objEjec.EjecSP("GEN_lisObjForm_sp", cNombreForm, idPerfil, idTipoEvento);
            foreach (DataRow item in dtControles.Rows)
            {
                liscontroles.Add(new clsControl()
                {
                    idControl = Convert.ToInt32(item["idControl"]),
                    cControl = item["cControl"].ToString(),
                    idEstado = Convert.ToInt32(item["idEstado"]),
                    idFormulario = Convert.ToInt32(item["idFormulario"]),
                    dFechaRegistro = Convert.ToDateTime(item["dFechaRegistro"])
                });
            }

            return liscontroles;
        }

        public void insertarCrontorlByPerfil(clslisControl listacontroles, int idPerfil, int idTipoEvento)
        {
            
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dscontroles",
                                          from item in listacontroles
                                          select new XElement("dtcontroles",
                                                              new XAttribute("idControl", item.idControl),
                                                              new XAttribute("idPerfil", idPerfil),
                                                              new XAttribute("idEstado", item.idEstado),
                                                              new XAttribute("idTipoEvento", idTipoEvento),
                                                              new XAttribute("idUsuReg", clsVarGlobal.User.idUsuario)))).ToString();            
      
            objEjec.EjecSPAlm("GEN_InsCtrByPerfil_sp", cxml);
        }

        public void actualizarControles(clsFormulario formulario)
        {
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dscontroles",
                                          from item in formulario.lisControles
                                          select new XElement("dtcontroles",
                                                              new XAttribute("cControl", item.cControl)))).ToString();

            objEjec.EjecSPAlm("GEN_ActCtrform_sp", formulario.cFormulario, formulario.idModulo, cxml, formulario.idTipoForm);
        }
    }
}

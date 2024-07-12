using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolIntEls.Web.utiles
{
    public class clsUtilitarios
    {
        public void Mensaje(string mensaje)
        {
            // Cleans the message to allow single quotation marks 
            string cleanMessage = mensaje.Replace("'", "\'");
            string script = "<script type='text/javascript'>alert('" + cleanMessage + "');</script>";

            // Gets the executing web page 
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page 
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", script);
            }
        }

        public void registrarRastreo(int idModulo,int idMenu,clsUsuario Usuario,int idCli, int idCuenta, string cDescripcion, Control control, string cDocumentoID = "")
        {
            clsFunUtiles funcion = new clsFunUtiles();

            clsRastreo objrastreo = new clsRastreo();

            objrastreo.idCuenta = idCuenta;
            objrastreo.idCli = idCli;
            objrastreo.idMenu = idMenu;
            objrastreo.idModulo = idModulo;
            objrastreo.idUsuReg = Usuario.idUsuario;
            objrastreo.cAccion = cDescripcion;
            objrastreo.cCodMac = "";
            objrastreo.cControl = control.ID;
            objrastreo.cNomTerminal = "";
            objrastreo.dFechaSis = clsVarGlobal.dFecSystem;
            objrastreo.dFechaReg = DateTime.Now;
            objrastreo.cFormulario = control.Page.ToString();
            objrastreo.idAgencia = Usuario.idAgeCol;
            objrastreo.cDocumentoID = cDocumentoID;

            new clsCNRastreo().insertarRastreo(objrastreo);
        }
    }
}
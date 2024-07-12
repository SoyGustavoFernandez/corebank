using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCF.Reniec
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    //[ServiceBehavior(Namespace = "http://elGuerre.loc/Service1/")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioReniec : IServicioReniec
    {
        ConsultaReniec objConsReniec = new ConsultaReniec();

        public clsProcesaDatosRen ConsultaIndInfPerReniec(string cNroDni, string cDocAutorizado, string cCodEmp, string cIdUsu)
        {
            clsObtenerDatosRen objObnDatRen = new clsObtenerDatosRen();
            clsProcesaDatosRen objProcesaDatosRen = new clsProcesaDatosRen();
            //objProcesaDatosRen = objObnDatRen.BuscarDocumento(cNroDni, "08715701", "DE2089",cIdUsu);
            objProcesaDatosRen = objObnDatRen.BuscarDocumento(cNroDni, cDocAutorizado, cIdUsu);

            //Persona persona;
            //persona = objConsReniec.ConsultaIndirectaReniec(cNroDni);

            return objProcesaDatosRen;
        }

        public clsProcesaDatosRen ConsultaIndInfPerReniecDirecta(string cNroDni, string cDocAutorizado, string cCodEmp, string cIdUsu, string cIdConsultaDirecta)
        {
            clsObtenerDatosRen objObnDatRen = new clsObtenerDatosRen();
            clsProcesaDatosRen objProcesaDatosRen = new clsProcesaDatosRen();
            //objProcesaDatosRen = objObnDatRen.BuscarDocumento(cNroDni, "08715701", "DE2089",cIdUsu);
            objProcesaDatosRen = objObnDatRen.BuscarDocumentoConsultaDirecta(cNroDni, cDocAutorizado, cIdUsu, cIdConsultaDirecta);

            //Persona persona;
            //persona = objConsReniec.ConsultaIndirectaReniec(cNroDni);

            return objProcesaDatosRen;
        }

        public Persona ConsultaIndInfPerFirmReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaIndirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaIndInfPerFotoReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaIndirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaIndInfPerFirmFotoReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaIndirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaDirInfPerReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaDirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaDirInfPerFirmReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaDirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaDirInfPerFotoReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaDirectaReniec(cNroDni);

            return persona;
        }

        public Persona ConsultaDirInfPerFirmFotoReniec(string cNroDni)
        {
            Persona persona;
            persona = objConsReniec.ConsultaDirectaReniec(cNroDni);

            return persona;
        }

        //Listado Personas
        /*public List<Persona_> ListadoPersonas() {
            var qry = from p in BDUsuario.Personas

            select new Persona_
            {

            Id = p.id_Persona,
            Nombres = p.Nombre_Persona,
            Apellidos = p.Apellido_Persona,

            };
            return qry.ToList();
        }

        //Buscar por ID
        public List<Persona_> FiltradoPorid(string id)
        {
            var qryC = from p in BDUsuario.Personas
            where p.id_Persona == Convert.ToInt32(id)
            select new Persona_
            {

            Nombres = p.Nombre_Persona,
            Apellidos = p.Apellido_Persona,

            };

            return qryC.ToList();
        }
        //Guardar un registro

        public wsSQLResult CrearUsuario(Stream JSONdataStream)
        {
        wsSQLResult result = new wsSQLResult();
        try
        {

        StreamReader reader = new StreamReader(JSONdataStream);

        string JSONdata = reader.ReadToEnd();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Persona_ cust = jss.Deserialize<Persona_>(JSONdata);
        if (cust == null)
        {
        result.WasSuccessful = 0;
        result.Exception = “Unable to deserialize the JSON data.”;
        return result;
        }
        Personas newCustomer = new Personas
        {

        Nombre_Persona = cust.Nombres,
        Apellido_Persona = cust.Apellidos,
        Login_Persona = cust.Login,
        Pass_Persona = cust.Pass
        };

        BDUsuario.Personas.InsertOnSubmit(newCustomer);
        BDUsuario.SubmitChanges();

        result.WasSuccessful = 1;
        result.Exception = “”;
        return result;
        }
        catch (Exception ex)
        {
        result.WasSuccessful = 0;
        result.Exception = ex.Message;
        return result;
        }
        }*/
    }
}

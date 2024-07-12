using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase.Model;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class conAutorizacionUsuDatos : UserControl
    {
        public int idCliente { get; set; }
        public string cCodCliente { get; set; }
        public int idSolicitud { get; set; }

        public int pIdTipoDocumento { get; set; }
        public int pIdTipoPersona { get; set; }
        public string pcDocumentoID { get; set; } 
        public string pcNombre { get; set; }
        public string pcDireccion { get; set; }
        public string pcTelefono { get; set; } 
        
        public bool lVisibleAutorizaUsoDatos=false;

        public string pcNombreJuridico  { get; set; }  
        public string pcNroDocJuridico  { get; set; } 
        BindingList<AutorizaTratamientoUsoDatos> lstData = new BindingList<AutorizaTratamientoUsoDatos>();

        public conAutorizacionUsuDatos()
        {
            InitializeComponent();
            ttpToolTipAutorizacion.SetToolTip(this.btnAutorizaDatos, "Tratamiento de datos"); 

             
         }

         private void picBox3_Click(object sender, EventArgs e)
         {
          
         }
         public async Task<bool> obtenerAutorizacionDatos(int idTipoAprobacion, int idTipoDocumento)
         {
             if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0 )
             {
                 MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", "Autorización uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return false;
             } 
             bool lEstadoAutorizacion = await Task.Run(() => BuscarAutTratamientoDatos(pcDocumentoID, idTipoAprobacion, idTipoDocumento));
             lVisibleAutorizaUsoDatos = lEstadoAutorizacion;
             return lEstadoAutorizacion; 
         }

         public async Task<bool> obtenerAutorizacionDatos( int idTipoAprobacion, string cCodCliente, int nNumSolicitud, string cNombre, string cNroDocumento, string cDireccion, string cTelefono, int idTipoPersona, int idTipoDocumento)
         {
             if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
             {
                 MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", "Autorización uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return false;
             }
             this.cCodCliente = cCodCliente;
             this.idSolicitud = nNumSolicitud;
             this.pcNombre = cNombre;
             this.pcDocumentoID = cNroDocumento;
             this.pcDireccion = cDireccion;
             this.pcTelefono = cTelefono;
             this.pIdTipoPersona = idTipoPersona;
            this.pIdTipoDocumento = idTipoDocumento;
             bool lEstadoAutorizacion = await Task.Run(() => BuscarAutTratamientoDatos(pcDocumentoID, idTipoAprobacion, idTipoDocumento));
             lVisibleAutorizaUsoDatos = lEstadoAutorizacion;
             return lEstadoAutorizacion;
         }
         private async void btnAutorizaDatos_Click(object sender, EventArgs e)
         {  

             this.MostrarRegistroAutorizacion(0);
         }
        public async void MostrarRegistroAutorizacion(int nOpcion ){
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
             {
                 MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", "Autorización uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return ;
             }
             if (string.IsNullOrEmpty(pcDocumentoID) || pcDocumentoID == null)
             {
                 MessageBox.Show("Debe seleccionar a un cliente.", "Autorización uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
             else
             {
                 idCliente = cCodCliente != "" ? Convert.ToInt32(cCodCliente.Substring(6)):0;
                 frmAutorizoUsoDatosCli frmAutoriza = new frmAutorizoUsoDatosCli(this.pIdTipoDocumento,idCliente, idSolicitud,
                     this.pcNombre        ,
                     this.pcDireccion     ,
                     this.pIdTipoPersona  ,
                     this.pcDocumentoID,
                     this.pcTelefono,
                     this.pcNombreJuridico,
                     this.pcNroDocJuridico,
                     this.cCodCliente,
                     nOpcion
                     );
                 frmAutoriza.ShowDialog(); 
              }
        }
         private async Task<bool> BuscarAutTratamientoDatos(string cNroDocumento, int idTipoAprobacion, int idTipoDocumento)
         { 
              try
                { 
                    string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "AutTratamientoUsoDatos?id=" + cNroDocumento + "&idEstado=10" + "&idTipoDoc=" + idTipoDocumento.ToString();

                    //Creamos el listado de Posts a llenar
                    FiltroReporteAutorizacion dataFiltro = new FiltroReporteAutorizacion();
                    //Instanciamos un objeto Reply
                    clsApiRespuesta oRespuesta = new clsApiRespuesta();
                    //poblamos el objeto con el método generic Execute
                    oRespuesta = await clsApiConsumer.Execute<RespLisAutorizacionTraDatos>(Uri, methodHttp.GET, dataFiltro);
                    //Poblamos el datagridview
                    RespLisAutorizacionTraDatos respuesta = (RespLisAutorizacionTraDatos)oRespuesta.Data;

                    //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
                    if (oRespuesta.StatusCode == "OK")
                    {
                        if (respuesta != null)
                        {
                            foreach (var item in respuesta.LisAutorizacion)
                            {
                                if (item.idTipoAutorizacion == idTipoAprobacion)
                                {

                                    return true;

                                }
                            }

                        }

                    }
                }
                catch // TODO: Catch more specific exceptions
                {
                    return false;
                }
                 
                return false;

         }

         private async void conAutorizacionUsuDatos_Load(object sender, EventArgs e)
         {
             if (pcDocumentoID != null)
             {
                 lVisibleAutorizaUsoDatos = await this.obtenerAutorizacionDatos(1,this.pIdTipoDocumento);
             }
           
         }
         public void limpiar()
         {
             this.cCodCliente = "";
             this.idSolicitud = 0;
             this.pcNombre = string.Empty;
             this.pIdTipoPersona = 0;
             this.pcDocumentoID = string.Empty;
             this.pcDireccion = string.Empty;
             this.pcTelefono = string.Empty; 
             this.lVisibleAutorizaUsoDatos = false;
         }
    }
}

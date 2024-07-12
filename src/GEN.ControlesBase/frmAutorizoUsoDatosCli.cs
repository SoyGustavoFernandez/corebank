using CLI.Servicio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase.Model;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace GEN.ControlesBase
{
    public partial class frmAutorizoUsoDatosCli : frmBase
    {
        #region variables
        //private int idMaestroAutorizacionOrigen = 0;
        BindingList<AutorizaTratamientoUsoDatosDTO> lstData = new BindingList<AutorizaTratamientoUsoDatosDTO>(); 

        private int pIdSolicitud;
        private int pIdCliente;

        private string pcNombre           ;
        private string pcDireccion;
        private int pIdTipoPersona;
        private int pIdTipoDocumento;
        private string pcDocumentoID;
        private string pcTelefono;
        private string pcNombreJuridico;
        private string pcNroDocJuridico;
        private string pcCodCliente;
        private int pnOpcion=0;

        AutorizaTratamientoUsoDatosDTO dataselFila;

        #endregion  
        
        #region eventos
        public frmAutorizoUsoDatosCli()
        {
            InitializeComponent();
        }
        public frmAutorizoUsoDatosCli(int idTipoDocumento,int idCliente,int idSolicitud,
            string cNombre        ,
            string cDireccion     ,
            int IdTipoPersona     , 
            string cDocumentoID   ,
            string cTelefono , 
            string  cNombreJuridico,
            string  cNroDocJuridico ,
            string cCodCliente,
            int nOpcion
            )
        {
            InitializeComponent();
            this.pIdCliente = idCliente;
            this.pIdSolicitud = idSolicitud;

            this.pcNombre = cNombre;
            this.pcDireccion = cDireccion;
            this.pIdTipoPersona = IdTipoPersona;
            this.pIdTipoDocumento = idTipoDocumento;
            this.pcDocumentoID = cDocumentoID;
            this.pcTelefono = cTelefono;
            this.pcNombreJuridico = cNombreJuridico;
            this.pcNroDocJuridico = cNroDocJuridico;
            this.pcCodCliente     = cCodCliente;
            this.pnOpcion = nOpcion;
         
        }
         
        private async void frmAutorizoUsoDatosCli_Load(object sender, EventArgs e)
        {
            this.conAutDatosBase1.titulo = this.Text;
            this.conAutDatosBase1.cargarCanal();
            this.txtNroDoc.Text = this.pcDocumentoID;
            this.txtNombre.Text = this.pcNombre;
            this.txtDireccion.Text = this.pcDireccion;
            this.txtTelefono.Text = this.pcTelefono;

             this.conAutDatosBase1.txtComentario.Visible = false;
             this.conAutDatosBase1.lblBase5.Visible = false;
             this.btnNuevo1.Enabled = true;
            if (this.pnOpcion == 1)
            {
                btnNuevo1.Visible = false;
                this.btnNuevo1_Click(sender, e);
            }
            else
            {
              this.conAutDatosBase1.esOpcionGestionAutUsoDatos = false;
              bool lResultado = await this.conAutDatosBase1.BuscarAutTratamientoDatos(this.pIdTipoDocumento,this.pcDocumentoID, sender, e);
              if (lResultado)
              {
                  if (this.conAutDatosBase1.dataMaestro == null)
                  {
                      btnNuevo1.Visible = false;
                      this.btnNuevo1_Click(sender, e);
                  }
                  else
                  {
                      this.btnImprimir.Enabled = true;
                      this.conAutDatosBase1.habilitarControlesEdicion(); 
                  }
                
              }
            }

        }
  
        
 

        private async void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            this.btnGrabar1.Enabled = false;
            bool respuesta =await conAutDatosBase1.grabarAutorizacionDatos(pIdTipoDocumento,pIdTipoPersona,txtNroDoc.Text.Trim(),
                txtNombre.Text.Trim(),
                txtDireccion.Text.Trim(),
                txtTelefono.Text.Trim(),
                pcCodCliente,
                pIdCliente,
                false,
                this.conAutDatosBase1.dataMaestro.idMaestroAutOrigen
                );
            if (respuesta)
            {
                this.btnGrabar1.Enabled = false;
                if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
                {
                    this.btnImprimir.Enabled = true;
                }
            }
            else
            {
                this.btnGrabar1.Enabled = true;
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {


            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            } 

            if (!string.IsNullOrEmpty(this.txtNroDoc.Text.Trim()) && (this.pIdTipoDocumento ==1 && this.txtNroDoc.Text.Trim().Length == 8 || this.pIdTipoDocumento == 2 || this.pIdTipoDocumento == 3))
            {
                
                conAutDatosBase1.cargarDatosNuevo();

            }
            else
            {
                MessageBox.Show("Debe elegir a un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
            activar(false);
   
        }
     
   
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validaEspacioInicio((txtBase)sender, e);
        }
        #endregion
        #region metodos
       
        private void activar(bool lActivo)
        {
            btnNuevo1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
        }
        private void validaEspacioInicio(txtBase txt, KeyPressEventArgs e)
        {
            if (txt.Text.Trim().Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
       
        #endregion

       
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
            {
                frmVerPdf frmdoc = new frmVerPdf();
                frmdoc.cArchivo = conAutDatosBase1.dataMaestro.cArchivo;
                frmdoc.bArchivoBinary = clsAuditoria.String2ByteArray(conAutDatosBase1.dataMaestro.cArchivoBinary);
                frmdoc.ShowDialog();
            }
        }

        private void conAutDatosBase1_ClicCargarDatos(object sender, EventArgs e)
        {

        }

        private void conAutDatosBase1_ClicEditarDatos(object sender, EventArgs e)
        {
            this.btnImprimir.Enabled = false;
           // this.idMaestroAutorizacionOrigen = conAutDatosBase1.dataMaestro.idMaestroAutorizacion;
            btnGrabar1.Enabled = true;

        }
    }
}

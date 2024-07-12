
using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
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
    public partial class frmSolDesistimientoAutTraDatosBase : frmBase
    {
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        AutorizaTratamientoUsoDatos datasel;
        public int nidTipoPersona;
        public int nidTipoDocumento;
        public string pcDistrito, pcProvincia, pcDepartamento, pcCorreoCli;

        ListaAutorizaTratamientoUsoDatos lstDataAutorizaciones = new ListaAutorizaTratamientoUsoDatos();
        public MaestroAutorizacion dataMaestro;

        public int idAgencia = 0; // permite el filtrado por agencia
        public int idCli { get; set; }
        

        public frmSolDesistimientoAutTraDatosBase()
        {
            InitializeComponent();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";

            HabilitarControles(true);
            this.habilitarBotones(false);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pcTipOpe = "N";
            clsCNMantenimiento mantenimiento = new clsCNMantenimiento();
            var dataregio = mantenimiento.CNObtenerZonasAgenciaGeneral(clsVarGlobal.nIdAgencia);
          
            cboRegion1.SelectedValue = dataregio.Rows[0]["idZona"].ToString();
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            cboCanal1.SelectedValue = 1;
            this.HabilitarControles(false);
            this.cboMotivoDesistimiento1.Enabled = true;
            this.habilitarBotones(false);
            this.cboMotivoDesistimiento1.SelectedIndex=-1;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Text = string.Empty;
            this.btnNuevo1.Enabled = false;
            this.btnImprimir1.Enabled = false;
            this.btnBusCliente.Enabled = false;


            string cNombreArchivo = this.txtNroDoc.Text.Trim() + "desistimiento";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombre", this.txtNombre.Text, false));
            paramlist.Add(new ReportParameter("cDireccion", this.txtDireccion.Text, false));
            paramlist.Add(new ReportParameter("IdTipoPersona", this.nidTipoPersona.ToString(), false));
            paramlist.Add(new ReportParameter("cDocumentoID", this.txtNroDoc.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("NroTelefono", this.txtTelefono.Text, false));
            paramlist.Add(new ReportParameter("cCorreo", "", false));
             
            //Generar documento 

            DataTable mytable = new DataTable();
            mytable.Columns.Add("dia", typeof(int));
            mytable.Columns.Add("mes", typeof(string));
            mytable.Columns.Add("anio", typeof(string));
            mytable.Columns.Add("cliente", typeof(string));
            mytable.Columns.Add("nrodocumento", typeof(string));
            mytable.Columns.Add("telefono", typeof(string));
            mytable.Columns.Add("celular", typeof(string));
            mytable.Columns.Add("direccion", typeof(string));
            mytable.Columns.Add("correo", typeof(string));
            mytable.Columns.Add("distrito", typeof(string));
            mytable.Columns.Add("provincia", typeof(string));
            mytable.Columns.Add("departamento", typeof(string));
            mytable.Columns.Add("opcionrevocacion1", typeof(string));
            mytable.Columns.Add("opcionrevocacion2", typeof(string));
            mytable.Columns.Add("opcionrevocacion3", typeof(string));
            mytable.Columns.Add("clienteahorros", typeof(string));
            mytable.Columns.Add("clientecreditos", typeof(string));
            mytable.Columns.Add("clienteotro", typeof(string));
            mytable.Columns.Add("cResponsable", typeof(string));
            mytable.Columns.Add("descripcionclienteotro", typeof(string));
            mytable.Columns.Add("medioenviosolicitud", typeof(string));


            DataRow dr1 = mytable.NewRow();
            DateTime datevalue = (Convert.ToDateTime(datasel.dFechaInicio.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            dr1["dia"] = dy;
            dr1["mes"] = mn;
            dr1["anio"] = yy;
            dr1["cliente"] = txtNombre.Text;
            dr1["nrodocumento"] = txtNroDoc.Text;
            dr1["telefono"] = txtTelefono.Text;
            dr1["celular"] = string.Empty;
            dr1["direccion"] = txtDireccion.Text;
            dr1["correo"] = pcCorreoCli;
            dr1["distrito"] = pcDistrito;
            dr1["provincia"] = pcProvincia;
            dr1["departamento"] = pcDepartamento;
            dr1["opcionrevocacion1"] = lstDataAutorizaciones.FirstOrDefault(x => x.idTipoAutorizacion == 1).lIndicadorConcentimiento ? "1" : "0";
            dr1["opcionrevocacion2"] = lstDataAutorizaciones.FirstOrDefault(x => x.idTipoAutorizacion == 2).lIndicadorConcentimiento ? "1" : "0";
            dr1["opcionrevocacion3"] = lstDataAutorizaciones.FirstOrDefault(x => x.idTipoAutorizacion == 3).lIndicadorConcentimiento ? "1" : "0";
            dr1["clienteahorros"] = "1";
            dr1["clientecreditos"] = "0";
            dr1["clienteotro"] = "1";
            dr1["cResponsable"] = string.Empty;
            dr1["descripcionclienteotro"] = string.Empty;
            dr1["medioenviosolicitud"] = string.Empty;

            mytable.Rows.Add(dr1);


            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "dsDatoAutoCliente";
            reportDataSource.Value = mytable;

            dtslist.Add(reportDataSource);
            string carchivo = "";
            byte[] bArchivoBinary = null; 
            bArchivoBinary = ToolAutorizacion.GenerarDocumento("rptFormatoDesistimientoAutUsoDatos.rdlc", cNombreArchivo, paramlist, dtslist, ref carchivo);
          
            datasel.cArchivoBinary=clsAuditoria.ByteArray2String(bArchivoBinary);
            datasel.cArchivo = carchivo;
        }

        private async void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            if (nidTipoDocumento == 1)
            {
                if (ToolAutorizacion.validarHuella(0,0,txtNroDoc.Text.Trim(),txtNombre.Text))
                {
                
                    this.guardar();
                }
                else
                {
                    datasel.idModalidad = 2;
                    frmMotivoAutUsoDatos frmMotAut = new frmMotivoAutUsoDatos(datasel.cArchivo, datasel.bArchivoBinary);

                    frmMotAut.ShowDialog();
                    if (frmMotAut.lAceptar)
                    {
                        datasel.idMotivo = frmMotAut.idMotivo;
                        datasel.cArchivo = frmMotAut.cNombreDocumento;
                        datasel.cArchivoBinary = clsAuditoria.ByteArray2String((byte[])frmMotAut.bArchivoBinary);
                        //datasel.bArchivoBinary = (byte[])frmMotAut.bArchivoBinary;
                        this.guardar();
                    }

                }
            }
            else
            {
                datasel.idModalidad = 2;
                frmMotivoAutUsoDatos frmMotAut = new frmMotivoAutUsoDatos(datasel.cArchivo, datasel.bArchivoBinary);

                frmMotAut.ShowDialog();
                if (frmMotAut.lAceptar)
                {
                    datasel.idMotivo = frmMotAut.idMotivo;
                    datasel.cArchivo = frmMotAut.cNombreDocumento;
                    datasel.cArchivoBinary = clsAuditoria.ByteArray2String((byte[])frmMotAut.bArchivoBinary);
                    //datasel.bArchivoBinary = (byte[])frmMotAut.bArchivoBinary;
                    this.guardar();
                }
            }

         
        }
        public async void guardar()
        {
            this.cprogressbar1.Visible = true;
            this.btnGrabar1.Enabled = false;
            SolDesistimientoUsoDatosDTO dato = new SolDesistimientoUsoDatosDTO();
            dato.idMotivoDesistimiento = Convert.ToInt32(cboMotivoDesistimiento1.SelectedValue);
            dato.cDescripcion = txtDescripcion.Text.Trim();
            dato.idCli = this.idCli;
            dato.idTipoAutorizacion = (int)cboTipoAutorizacion1.SelectedValue;
            dato.idRegion = (int)cboRegion1.SelectedValue;
            dato.idOficina = (int)cboAgencias1.SelectedValue;
            dato.idCanalRegistro = 1;// ventanilla
            dato.cArchivo = datasel.cArchivo;
            dato.cArchivoBinary = clsAuditoria.ByteArray2String(datasel.bArchivoBinary);   
            dato.idModalidad = datasel.idModalidad;
            dato.idMotivoNoFirma = datasel.idMotivo;
            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "SolicitudDesistimiento";

            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();

            if (pcTipOpe == "A")
            {
                dato.idAutTraDatos = datasel.idAutTraDatos;
                dato.dFecModifica = clsVarGlobal.dFecSystem.Date;
                dato.idUsuModifica = clsVarGlobal.User.idUsuario;
                //poblamos el objeto con el método generic Execute
                oRespuesta = await clsApiConsumer.Execute<RespuestaAutTraDatos>(Uri, methodHttp.POST, dato);
                //Poblamos el datagridview
                RespuestaAutTraDatos respuesta = (RespuestaAutTraDatos)oRespuesta.Data;
                //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
                if (oRespuesta.StatusCode == "OK")
                {

                    this.cprogressbar1.Visible = false;
                    this.txtCodCli.Enabled = true;
                    MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargar de nuevo y seleccionar el registro modificado
                }
                else
                {
                    this.cprogressbar1.Visible = false;
                    this.btnGrabar1.Enabled = true;
                    MessageBox.Show("Error al actualizar los datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (pcTipOpe == "N")
            {
                dato.idAutTraDatos = datasel.idAutTraDatos;
                dato.dFecRegistro = clsVarGlobal.dFecSystem.Date;
                dato.idUsuRegistro = clsVarGlobal.User.idUsuario;
                //poblamos el objeto con el método generic Execute
                oRespuesta = await clsApiConsumer.Execute<RespuestaAutTraDatos>(Uri, methodHttp.POST, dato);
                //Poblamos el datagridview
                RespuestaAutTraDatos respuesta = (RespuestaAutTraDatos)oRespuesta.Data;
                //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
                if (oRespuesta.StatusCode == "OK")
                {
                    dato.idSolDesentimiento = Convert.ToInt32(respuesta.nCodigo);
                    this.cprogressbar1.Visible = false;
                    this.cboMotivoDesistimiento1.Enabled = false;
                    this.txtDescripcion.Enabled = false; 
                    this.habilitarBotones(true);

                    this.btnImprimir1.Enabled = false;
                    if (respuesta.nCodigo.Equals("0"))
                    {
                        MessageBox.Show(respuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnImprimir1.Enabled = true;
                    }
  
                }
                else
                {
                    this.cprogressbar1.Visible = false;
                    this.btnGrabar1.Enabled = true;
                    MessageBox.Show("Error al registrar los datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            Limpiar();
            btnNuevo1.Enabled = false;
            this.cboMotivoDesistimiento1.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.btnImprimir1.Enabled = false;
            this.txtCodCli.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.txtCodCli.Enabled = true;
            this.btnBusCliente.Enabled = true;
        }

        private void habilitarBotones(bool lActivo)
        {
            this.btnGrabar1.Enabled = !lActivo;
            this.btnCancelar1.Enabled = !lActivo;

            this.btnImprimir1.Enabled = !lActivo;
        }
        private void Limpiar()
        {
            this.cboMotivoDesistimiento1.SelectedIndex = -1;
            this.cboTipoAutorizacion1.SelectedIndex = -1;
            this.cboRegion1.SelectedIndex = -1;
            this.cboAgencias1.SelectedIndex = -1;
            this.cboCanal1.SelectedIndex = -1;
            this.txtDescripcion.Clear();
            this.txtCodAutorizacion.Clear();
            this.limpiarControles();
        }
        private void HabilitarControles(Boolean Val)
        {
            this.cboMotivoDesistimiento1.Enabled = Val;
            this.txtDescripcion.Enabled = Val;
            this.cboTipoAutorizacion1.Enabled = Val;
            this.cboRegion1.Enabled = Val;
            this.cboAgencias1.Enabled = Val;
            this.cboCanal1.Enabled = Val; 
        }
         
      
        private string ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNroDoc.Text.Trim()))
            {
                MessageBox.Show("Seleccione al cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDoc.Focus();
                return "ERROR";
            }
            if (cboMotivoDesistimiento1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione motivo de desistimiento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoDesistimiento1.Focus();
                return "ERROR";
            }
            if (cboMotivoDesistimiento1.Text.Trim().ToUpper().Equals("OTROS") && txtDescripcion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese descripción del motivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboTipoAutorizacion1.Text.Trim()) || cboTipoAutorizacion1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese el tipo de autorización.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoAutorizacion1.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboRegion1.Text.Trim()) || cboRegion1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese región.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboRegion1.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboAgencias1.Text.Trim()) || cboAgencias1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese la oficina.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias1.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboCanal1.Text.Trim()) || cboCanal1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese canal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCanal1.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            { 
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            
        }

        private void frmSolDesentimientoAutTraDatos_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            HabilitarControles(false);
            this.habilitarBotones(true);
            cboCanal1.cargarCanalRegistro();
         

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (datasel != null && datasel.cArchivo != "" && datasel.cArchivo != null)
            {
                frmVerPdf frmdoc = new frmVerPdf();
                frmdoc.cArchivo = datasel.cArchivo;
                frmdoc.bArchivoBinary = (byte[])datasel.bArchivoBinary;
                frmdoc.ShowDialog();
            }
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            this.buscar();
        }
        public void buscar()
        {


            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                FrmBusCliAutUsoDatos frmbuscarcli = new FrmBusCliAutUsoDatos();
                frmbuscarcli.ShowDialog();

                if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo) || !string.IsNullOrEmpty(frmbuscarcli.pcNroDoc))
                {
                    if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo))
                    {
                        txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                        txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                        txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                    }
                    txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                    txtNombre.Text = frmbuscarcli.pcNomCli;
                    txtDireccion.Text = frmbuscarcli.pcDireccion;
                    nidTipoPersona = frmbuscarcli.pnTipoPersona;
                    nidTipoDocumento = frmbuscarcli.pnTipoDocumento;
                    txtTelefono.Text = frmbuscarcli.pcTelefono;
                    pcDistrito       = frmbuscarcli.pcDistrito       ;
                    pcProvincia      = frmbuscarcli.pcProvincia      ;
                    pcDepartamento = frmbuscarcli.pcDepartamento;
                    pcCorreoCli = frmbuscarcli.pcCorreoCli;
                    cboTipDocumento.SelectedValue = frmbuscarcli.pnTipoDocumento;

                    txtCodCli.Enabled = false;
                    if (nidTipoPersona == 2 || nidTipoPersona == 3)// PERSONA JURIDICO
                    {
                        //CARGAR DATOS DE REPRESETANTE

                        this.limpiarControles();
                        MessageBox.Show("Una persona juridica no tiene autorización de uso de datos, ingresa datos de una persona natural.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
                {
                    txtCodInst.Text = string.Empty;
                    txtCodAge.Text = string.Empty;
                    txtCodCli.Text = string.Empty;
                    txtNroDoc.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    nidTipoPersona = 1;
                    nidTipoDocumento = -1;
                    txtCodCli.Enabled = true;
                    txtCodCli.Focus();
                    Limpiar();
                    pcDistrito      = string.Empty;
                    pcProvincia     = string.Empty;
                    pcDepartamento = string.Empty;
                    pcCorreoCli = string.Empty;
                    cboTipDocumento.SelectedIndex = -1;
                }

                idCli = txtCodCli.Text.Trim().Equals("") ? 0 : Convert.ToInt32(txtCodCli.Text);
                if ((nidTipoDocumento == 1 && txtNroDoc.Text.Trim().Length == 8) || nidTipoDocumento == 2 || nidTipoDocumento == 3)
                {
                    BuscarAutTratamientoDatos(this.txtNroDoc.Text.Trim(), nidTipoDocumento);
                     
                }
            }
            else
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void seleccionarTratamientoDatos()
        {
            frmSelAutTratamientoDatosBase frmSel = new frmSelAutTratamientoDatosBase(lstDataAutorizaciones);

            frmSel.ShowDialog();
            if (frmSel.lAceptar)
            {
                txtCodAutorizacion.Text = frmSel.datasel.idAutTraDatos.ToString();
                cboTipoAutorizacion1.SelectedValue = frmSel.datasel.idTipoAutorizacion;
                datasel = frmSel.datasel; 

                this.btnNuevo1.Enabled = true;
            }
            else
            {
                Limpiar();
            }
        }
        public void limpiarControles()
        {
            txtCodInst.Clear();
            txtCodAge.Clear();
            txtCodCli.Clear();
            txtNroDoc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCodInst.Clear();
            nidTipoPersona = 0;

            idCli = 0;
            txtCodCli.Enabled = true;
            txtCodCli.Focus();
            cboTipDocumento.SelectedIndex = -1;
        }
        private void CargardatosCli(int codCliente){ 
            clsCNBuscarCli listarCli = new clsCNBuscarCli();

            DataTable tablaCli = listarCli.ListarClixIdCliAutUsoDatos(codCliente);

            if (tablaCli.Rows.Count > 0)
            {
                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);

                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cNroDocumento"]);
                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombres"]);
                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
       
                txtCodCli.Enabled = false;
                this.idCli = txtCodCli.Text.Trim().Equals("") ? 0 : Convert.ToInt32(txtCodCli.Text);
                this.txtTelefono.Text = tablaCli.Rows[0]["cTelefono"].ToString();

                 if (txtNroDoc.Text.Trim().Length == 8)
                {
                    this.seleccionarTratamientoDatos();

                }
            }
            else if (tablaCli.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Registro.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodInst.Text = string.Empty;
                txtCodAge.Text = string.Empty;
                txtCodCli.Text = string.Empty;
                txtNroDoc.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCodCli.Enabled = true;
                 txtCodCli.Focus();
                this.idCli = 0;
                this.txtTelefono.Text = string.Empty;
                this.Limpiar();
            }
        }
        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false; 
                if (e.KeyChar == 13)
                {
                    Int32 nCifras = txtCodCli.TextLength;

                    if (nCifras == 0)
                    {
                        MessageBox.Show("Valor de Búsqueda Incorrecto.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCodCli.Focus();
                        txtCodInst.Text = string.Empty;
                        txtCodAge.Text = string.Empty;
                        txtCodCli.Text = string.Empty;
                        txtNroDoc.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtCodCli.Enabled = true;
                        txtCodCli.Focus();
                        idCli = 0;
                        this.txtTelefono.Text = string.Empty;
                        this.Limpiar();
                    }
                    else
                    {
                        if (Convert.ToInt32(this.txtCodCli.Text) <= 0)
                        {
                            MessageBox.Show("Ingrese un código de cliente válido.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtCodCli.Focus();
                            this.txtCodCli.SelectAll();
                            idCli = 0;
                            return;
                        }

                        CargardatosCli(Convert.ToInt32(txtCodCli.Text));
                    }
                }
            }
            else
            {
                e.Handled = true;
            }    
        }

        private void cboMotivoDesistimiento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivoDesistimiento1.Text.ToUpper() == "OTROS")
            {
                this.txtDescripcion.Enabled = true;
            }
            else
            {
                this.txtDescripcion.Enabled = false;
                this.txtDescripcion.Text = string.Empty;
            }
        }
        private void validaEspacioInicio(txtBase txt, KeyPressEventArgs e)
        {
            if (txt.Text.Trim().Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validaEspacioInicio((txtBase)sender, e);
        }

       

        public async void BuscarAutTratamientoDatos(string nroDocumento, int idTipoDoc)
        {
            cprogressbar1.Visible = true;
            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "SolicitudDesistimiento?id=" + nroDocumento + "&idEstado=0" + "&idTipoDoc="+ idTipoDoc.ToString();

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
                lstDataAutorizaciones.Clear();

                if (respuesta.MaestroAutTratamientoDatos != null)
                {
                    dataMaestro = respuesta.MaestroAutTratamientoDatos;
                    foreach (var item in respuesta.MaestroAutTratamientoDatos.detalleAutorizacion)
                    {
                        AutorizaTratamientoUsoDatos objDataFinal = new AutorizaTratamientoUsoDatos();
                        objDataFinal.idAutTraDatos = item.idAutTraDatos;
                        objDataFinal.nTiempoVigencia = item.nTiempoVigencia;

                        objDataFinal.idTipoAutorizacion = item.idTipoAutorizacion;
                        objDataFinal.cTipoAutorizacion = item.cTipoAutorizacion;
                        objDataFinal.lIndicadorConcentimiento = item.lIndicadorConcentimiento;
                        objDataFinal.dFechaInicio = item.dFechaInicio;
                        objDataFinal.dFechaFin = item.dFechaFin;
                        objDataFinal.idEstado = item.idEstado;
                        objDataFinal.cEstado = item.cEstado;
                        objDataFinal.cResponsable = item.cResponsable;
                        objDataFinal.lVigente = item.lVigente;
                        objDataFinal.idUsuRegistro = item.idUsuRegistro;
                        objDataFinal.dFecRegistro = item.dFecRegistro;
                        objDataFinal.idUsuModifica = item.idUsuModifica;
                        objDataFinal.dFecModifica = item.dFecModifica;
                        lstDataAutorizaciones.Add(objDataFinal);
                    }
                    if (dataMaestro.nTieneCuentasActivas == 0)
                    {
                        this.seleccionarTratamientoDatos();
                    }
                    else
                    {
                        MessageBox.Show("Cliente tiene cuentas activas, no se puede realizar el desistimiento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (respuesta.EstadoRpt.lResultado)
                    {
                        MessageBox.Show("Cliente no tiene autorización de uso de datos por desistir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
               
                cprogressbar1.Visible = false;
        

            }
            else
            {
                MessageBox.Show("Error al buscar los datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cprogressbar1.Visible = false;
   
        }

    }
}

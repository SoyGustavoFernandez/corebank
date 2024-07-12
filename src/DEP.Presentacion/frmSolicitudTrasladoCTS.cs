using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmSolicitudTrasladoCTS : frmBase
    {
        DataTable tbDatosSolicitud;
        clsCNFuentesIngreso cnfuenteingreso = new clsCNFuentesIngreso();
        public frmSolicitudTrasladoCTS()
        {
            InitializeComponent();
        }

        private void cboTipoEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidad.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad.SelectedValue);
                cboEntidad.CargarEntidades(nTipEnt);
            }
        }

        private void cboTipoEntida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntida.SelectedIndex > 0)
            {
                int nTipEnti = Convert.ToInt32(this.cboTipoEntida.SelectedValue);
                cboEntida.CargarEntidades(nTipEnti);
                cboEntida.SelectedValue = 77;
                cboEntida.Enabled = false;
                cboTipoEntida.Enabled = false;
                //cboEntidad.CargarEntidades(77);
            }

        }

        private void frmSolicitudTrasladoCTS_Load(object sender, EventArgs e)
        {            
            Limpiar();
            this.conBusCliente.txtCodCli.Focus();
            this.conBusCol.idUsu = "";
            cboTipoEntidad.SelectedValue = 4;
            cboTipoEntida.SelectedValue = 6;
            conBusCol.txtCod.Enabled = false;
            var controls = conBusCol.Controls.Find("grbBase1",true);

            if (controls.Count() > 0)
            {
                grbBase grb = controls[0] as grbBase;
                if (grb != null)
                {
                    grb.Text =  "Datos del Promotor";
                }
            }
            
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.btnBusCliente.Enabled = true;
            chcNuevaSolicitud.Visible = false;
            chcNuevaSolicitud.Checked = false;
            btnEnviar.Enabled = false;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = false;
            conBusCliente.limpiarControles();
            Limpiar();
        }

        private void Limpiar(){
            this.lblEstado.Text = "";

            this.lblFecha.Visible = false;
            this.lblFecha.Text = "";
            this.lblFecSol.Visible = false;

            this.lblUsuarioSol.Visible = false;
            this.lblUsuarioSol.Text = "";
            this.lblUsuario.Visible = false;

            this.cboMonOrigen.SelectedIndex = -1;
            this.cboTipoEntidad.SelectedIndex = -1;
            this.cboEntidad.SelectedIndex = -1;

            this.cboMonDestino.SelectedIndex = -1;
            this.cboAgencias.SelectedIndex = -1;   
            this.conBusCol.LimpiarDatos();            

            this.conBusCliEmpleador.txtCodCli.Enabled = true;
            this.conBusCliEmpleador.txtCodInst.Text = "";
            this.conBusCliEmpleador.txtCodAge.Text = "";
            this.conBusCliEmpleador.txtCodCli.Text="";
            this.conBusCliEmpleador.txtNombre.Text="";
            this.conBusCliEmpleador.txtNroDoc.Text = "";
            this.conBusCliEmpleador.txtDireccion.Text = "";  
        }
        
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                MessageBox.Show("Debe asignar un Cliente Válido", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim())==clsVarGlobal.User.idCli)
            {
                MessageBox.Show("No se puede enviar una solicitud donde el involucrado sea Ud. mismo, ello lo deberá realizar otro Personal", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Validar que el cliente colaborador de CRAC LOS ANDES
            if (clsVarApl.dicVarGen["cRUC"]==conBusCliEmpleador.txtNroDoc.Text.Trim())
            {
                //VALIDACION SI PERTENECE A LA CRAC LOS ANDES
                int idCliCol = Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim());
                int idcli = Convert.ToInt32(conBusCliEmpleador.txtCodCli.Text.Trim());

                DataTable dtValidaCol = cnfuenteingreso.CNValidaColByEmpresa(idCliCol, idcli);
                if (Convert.ToInt32(dtValidaCol.Rows[0]["Rpta"]) == 0)
                {
                    MessageBox.Show("El cliente no es colaborador de la " + clsVarApl.dicVarGen["cNomEmpresa"], "Fuentes de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }     
            
            if (cboMonOrigen.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Moneda de la Cuenta de Origen", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }  
            if (cboTipoEntidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboEntidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Entidad Financiera", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMonDestino.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Moneda de la Cuenta de Destino", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }       

            if (cboAgencias.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCol.txtCod.Text))
            {
                MessageBox.Show("Debe seleccionar un Promotor", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(conBusCol.idUsu) == 0 || conBusCol.txtCargo.Text.Trim() == "" || conBusCol.txtNom.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un Promotor", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (conBusCliEmpleador.txtCodCli.Text.Trim() == "" || conBusCliEmpleador.txtNombre.Text.Trim()=="")
            {
                MessageBox.Show("Debe indicar el Centro Laboral del Cliente", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboEntidad.Text.Trim() == cboEntida.Text.Trim())
            {
                MessageBox.Show("El tipo de entidad financiera debe ser diferente al destino", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            clsCNSolicCTS solicitud = new clsCNSolicCTS();

            DataTable CuentaCTS= solicitud.CtaDuplicado(Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim()), Convert.ToInt32(conBusCliEmpleador.txtCodCli.Text.Trim()));

            if (CuentaCTS.Rows.Count > 0)
            {
                MessageBox.Show("El Cliente ya cuenta con una Cuenta CTS relacionada a éste empleador ", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (CuentaCTS.Rows.Count == 0)
            {
                solicitud.EnviarSolicitud(0, Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim()), Convert.ToInt32(cboTipoEntidad.SelectedValue),
                                           Convert.ToInt32(cboEntidad.SelectedValue), Convert.ToInt32(cboMonOrigen.SelectedValue),
                                           Convert.ToInt32(cboAgencias.SelectedValue), Convert.ToInt32(conBusCol.idUsu),
                                           Convert.ToInt32(cboMonDestino.SelectedValue), Convert.ToInt32(conBusCliEmpleador.txtCodCli.Text.Trim()),
                                           clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, 1);

                MessageBox.Show("Su solicitud fue enviada correctamente", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //lVigente=0, para la solicitud Rechazada anteriormente
                if (chcNuevaSolicitud.Checked == true && chcNuevaSolicitud.Visible == true)
                {
                    solicitud.AnularSol(Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolCTS"]));
                }
                Buscar();
                btnEnviar.Enabled = false;
                conBusCliente.btnBusCliente.Enabled = false;
            }
        }
        private void Buscar()
        {
            HabilitarControles(false);

            chcNuevaSolicitud.Visible = false;
            chcNuevaSolicitud.Checked = false;
            btnEnviar.Enabled = false;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = false;
            Limpiar();
            
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.txtCodCli.Focus();

                return;
            }

            if (Convert.ToInt32(conBusCliente.nidTipoPersona) == 2)
            {
                MessageBox.Show("No se puede asignar una Cuenta CTS a una Persona Jurídica", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.conBusCliente.txtCodCli.Enabled = true;
                this.conBusCliente.txtCodCli.Focus();
                
                this.conBusCliente.txtCodInst.Text = "";
                this.conBusCliente.txtCodAge.Text = "";
                this.conBusCliente.txtCodCli.Text = "";
                this.conBusCliente.txtNombre.Text = "";
                this.conBusCliente.txtNroDoc.Text = "";
                this.conBusCliente.txtDireccion.Text = "";

                return;
            }
                       
            clsCNSolicCTS BuscarDatosSol = new clsCNSolicCTS();
            
            //--Validar si cliente ya tiene una cuenta de CTS
            if (BuscarDatosSol.CNValidaCTSCli(conBusCliente.txtCodCli.Text.Trim()))
            {
                MessageBox.Show("El Cliente tiene una Cuenta de CTS en estado Vigente o Solicitado...Verificar", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCliente.txtCodCli.Enabled = true;
                
                this.conBusCliente.txtCodInst.Text = "";
                this.conBusCliente.txtCodAge.Text = "";
                this.conBusCliente.txtCodCli.Text = "";
                this.conBusCliente.txtNombre.Text = "";
                this.conBusCliente.txtNroDoc.Text = "";
                this.conBusCliente.txtDireccion.Text = "";
                this.conBusCliente.txtCodCli.Focus();

                return;
            }

            //--Obtener datos de la solicitud de CTS
            tbDatosSolicitud = BuscarDatosSol.DatosSolici(Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim()),1);

            if (tbDatosSolicitud.Rows.Count == 0)
            {
                HabilitarControles(true);

                lblEstado.Text = "SIN SOLICITUD";
                lblUsuarioSol.Visible = false;
                lblUsuario.Visible = false;
                lblFecha.Visible = false;
                lblFecSol.Visible = false;

                btnEnviar.Enabled = true;
                btnImprimir.Enabled = false;
                
                if (Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil) == 5)
                {
                    cboAgencias.Enabled = true;
                }
                else
                {
                    cboAgencias.SelectedValue = Convert.ToInt32(clsVarGlobal.nIdAgencia);
                    cboAgencias.Enabled = false;                    
                    conBusCol.LimpiarDatos();
                }
                cboTipoEntidad.SelectedValue = 4;
            }
            else
            {
                HabilitarControles(false);

                lblFecha.Visible = true;
                lblFecSol.Visible = true;
                lblUsuario.Visible = true;
                lblUsuarioSol.Visible = true;
                
                lblEstado.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                lblFecha.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());
                lblUsuarioSol.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);

                cboMonOrigen.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaOri"]);
                cboTipoEntidad.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idTipoEntidad"]);
                cboEntidad.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadFinan"]);


                cboMonDestino.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaDest"]);
                cboAgencias.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idAgencia"]);                
                conBusCol.txtCod.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["idPromotor"]);
                conBusCol.BusPerByCod();                                

                conBusCliEmpleador.txtCodInst.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(0, 3);
                conBusCliEmpleador.txtCodAge.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(3, 3);
                conBusCliEmpleador.txtCodCli.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(6);
                conBusCliEmpleador.txtNroDoc.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cDocumentoID"]);
                conBusCliEmpleador.txtNombre.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cNombre"]);
                conBusCliEmpleador.txtDireccion.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["DireccionTrabajo"]);

                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 2 || Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 4)
                    chcNuevaSolicitud.Visible = true;
                else 
                    chcNuevaSolicitud.Visible = false;
                
                //if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 1)
                btnImprimir.Enabled = true;
            }
            this.conBusCliente.txtCodCli.Enabled = false;
           // conBusCliente.btnBusCliente.Enabled = false;
            btnCancelar.Enabled = true;
           
        }
                
        private void HabilitarControles(Boolean var) {
            
            this.cboTipoEntidad.Enabled = var;
            this.cboEntidad.Enabled = var;
            this.cboMonOrigen.Enabled = var;
            this.cboMonDestino.Enabled = var;
            this.cboAgencias.Enabled = var;            
            this.conBusCol.HabilitarControles(var);
            this.conBusCol.txtCod.Enabled = false;

            this.conBusCliEmpleador.btnBusCliente.Enabled = var;
            this.conBusCliEmpleador.txtCodCli.Enabled = var;            
        }

        private void conBusCliente_ClicBuscar_1(object sender, EventArgs e)
        {
            Buscar();
        }

        private void conBusCliEmpleador_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCliEmpleador.idCli != 0 && conBusCliEmpleador.nidTipoPersona == 1)
            {
                MessageBox.Show("El empleador sólo puede ser una Persona Jurídica", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.conBusCliEmpleador.txtCodCli.Enabled = true;
                this.conBusCliEmpleador.txtCodCli.Focus();
                this.conBusCliEmpleador.txtCodInst.Text = "";
                this.conBusCliEmpleador.txtCodAge.Text = "";
                this.conBusCliEmpleador.txtCodCli.Text = "";
                this.conBusCliEmpleador.txtNombre.Text = "";
                this.conBusCliEmpleador.txtNroDoc.Text = "";
                this.conBusCliEmpleador.txtDireccion.Text = "";
            }
        }

        private void CBNewSol_CheckedChanged(object sender, EventArgs e)
        {
            if (chcNuevaSolicitud.Checked == true && chcNuevaSolicitud.Visible==true) {
                
                Limpiar();
                lblEstado.Text = "NUEVA SOLICITUD";
                lblUsuarioSol.Visible = false;
                lblUsuario.Visible = false;
                lblFecha.Visible = false;
                lblFecSol.Visible = false;
                HabilitarControles(true);
                btnImprimir.Enabled = false;
                btnEnviar.Enabled = true;              
            }
            else if (chcNuevaSolicitud.Checked == false && chcNuevaSolicitud.Visible == true)
            {                
                HabilitarControles(false);
                lblUsuarioSol.Visible = true;
                lblUsuario.Visible = true;
                lblFecha.Visible = true;
                lblFecSol.Visible = true;
                lblEstado.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                lblUsuarioSol.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);
                lblFecha.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());

                cboTipoEntidad.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idTipoEntidad"]);
                cboEntidad.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadFinan"]);
                cboMonOrigen.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaOri"]);
                cboAgencias.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idAgencia"]);                
                conBusCol.txtCod.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["idPromotor"]);
                conBusCol.BusPerByCod();                
                cboMonDestino.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaDest"]);

                conBusCliEmpleador.txtCodInst.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(0, 3);
                conBusCliEmpleador.txtCodAge.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(3, 3);
                conBusCliEmpleador.txtCodCli.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]).Substring(6);

                conBusCliEmpleador.txtNroDoc.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cDocumentoID"]);
                conBusCliEmpleador.txtNombre.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cNombre"]);
                conBusCliEmpleador.txtDireccion.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["DireccionTrabajo"]);
                                
                btnEnviar.Enabled = false;
                btnImprimir.Enabled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {               
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cNombreCliente = Convert.ToString(conBusCliente.txtNombre.Text.Trim());
            string cDNI = Convert.ToString(conBusCliente.txtNroDoc.Text.Trim());
            string cDireccionCliente = Convert.ToString(conBusCliente.txtDireccion.Text.Trim());

            if (tbDatosSolicitud.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_cNombreCliente", cNombreCliente, false));
                paramlist.Add(new ReportParameter("x_cDocumentoDNI", cDNI, false));
                paramlist.Add(new ReportParameter("x_cDirecCliente", cDireccionCliente, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsSolicTraslCTS", tbDatosSolicitud));

                string reportpath = "rptSolicTraslCTS.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusCol.idUsu == null)
            {
                MessageBox.Show("Debe elegir al colaborador", "Solicitud de Traslado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCol.LimpiarDatos();
                return;
            }
            if (string.IsNullOrEmpty(this.conBusCol.idUsu))
            {
                return;
            }
            if (this.cboAgencias.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una agencia", "Solicitud de Traslado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.conBusCol.LimpiarDatos();
                return;
            }

            if (this.conBusCol.idAgencia != Convert.ToString(this.cboAgencias.SelectedValue))
            {
                MessageBox.Show("El colaborador seleccionado pertenece a otra agencia", "Solicitud de Traslado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.conBusCol.LimpiarDatos();
                return;
            }

        }

        

           
    }
}

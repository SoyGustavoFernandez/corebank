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

namespace DEP.Presentacion
{
    public partial class frmAprobSolTraslCTS : frmBase
    {
        DataTable tbDatosSolicitud;
        int nTipoTraslado = 0;

        public frmAprobSolTraslCTS()
        {
            InitializeComponent();
        }

        private void frmAprobSolTraslCTS_Load(object sender, EventArgs e)
        {
            Limpiar();
            this.conBusCliente.txtCodCli.Focus();
            this.tabControl1.Appearance = TabAppearance.FlatButtons; 
            tabControl1.ItemSize = new Size(0, 1); 
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }
                
        private void cboTipoEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidad1.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad1.SelectedValue);
                cboEntidad1.CargarEntidades(nTipEnt);
            }
        }
        private void Limpiar()
        {
            //Parte 1
            this.lblEstado1.Text = "";
            this.lblFecha1.Text = "";            
            this.lblUsuarioSol1.Text = "";

            //Parte 2
            this.lblEstado2.Text = "";
            this.lblFecha2.Text = "";
            this.lblUsuarioSol2.Text = "";

            //Parte 1
            this.cboTipoEntidad1.SelectedIndex = -1;
            this.cboEntidad1.SelectedIndex = -1;
            this.cboMonOrigen1.SelectedIndex = -1;
            this.cboMonDestino1.SelectedIndex = -1;
            this.cboAgencias1.SelectedIndex = -1;
            this.cboPersonalGen1.SelectedIndex = -1;
            this.cboEntidadDes.SelectedIndex = -1;
            this.cboTipoEntidadDes.SelectedIndex = -1;
            //Parte 2
            this.txtNroCta2.Text = "";
            this.cboMonOrigen2.SelectedIndex = -1;
            this.cboTipoEntidadOri2.SelectedIndex = -1;
            this.cboEntidadOri2.SelectedIndex = -1;

            this.cboMonDestino2.SelectedIndex = -1;
            this.cboTipoEntidadDes2.SelectedIndex = -1;
            this.cboEntidadDes2.SelectedIndex = -1;

            //Parte 1
            this.txtcod1.Text = "";
            this.txtRUC1.Text = "";
            this.txtRazonSocial1.Text = "";
            this.txtDireccion1.Text = "";

            //Parte 2
            this.txtcod2.Text = "";
            this.txtRUC2.Text = "";
            this.txtRazonSocial2.Text = "";
            this.txtDireccion2.Text = "";
        }

        private void Buscar()
        {
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                Limpiar();
                conBusCliente.btnBusCliente.Focus();
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.txtCodCli.Focus();
                return;
            }
                        
            clsCNSolicCTS BuscarDatosSol = new clsCNSolicCTS();
            tbDatosSolicitud = BuscarDatosSol.DatosSolici(Convert.ToInt32(conBusCliente.txtCodCli.Text.Trim()),0);            

            if (tbDatosSolicitud.Rows.Count == 0)
            {
                Limpiar();
                lblEstado1.Text = "SIN SOLICITUD";
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.txtCodCli.Focus();
                btnAceptar1.Enabled = false;
                btnRechazar1.Enabled = false;
            }
            else
            {
                Limpiar();
                this.nTipoTraslado = Convert.ToInt32(tbDatosSolicitud.Rows[0]["nTipoTraslado"]);

                if (this.nTipoTraslado == 1)
                {
                    //tabControl1.SelectedIndex = 1;
                    this.tabControl1.SelectedTab = this.tabControl1.TabPages[0];                    
                    //tabControl1.Enabled = false;

                    lblEstado1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                    lblUsuarioSol1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);
                    lblFecha1.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());

                    cboTipoEntidad1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idTipoEntidad"]);
                    cboEntidad1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadFinan"]);

                    cboMonOrigen1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaOri"]);
                    cboAgencias1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idAgencia"]);
                    cboPersonalGen1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idPromotor"]);
                    cboMonDestino1.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaDest"]);

                    cboTipoEntidadDes.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["TipoEntidadDes"]);
                    cboEntidadDes.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadDes"]);

                    txtcod1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]);
                    txtRUC1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cDocumentoID"]);
                    txtRazonSocial1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cNombre"]);
                    txtDireccion1.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["DireccionTrabajo"]);   
                }
                
                if (this.nTipoTraslado == 2)
                {
                    //tabControl1.SelectedIndex = 2;
                    this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
                    //tabControl1.Enabled = false;

                    lblEstado2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                    lblUsuarioSol2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);
                    lblFecha2.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());

                    cboMonOrigen2.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaOri"]);
                    cboTipoEntidadOri2.SelectedValue = 6;
                    cboEntidadOri2.SelectedValue = 77;

                    txtNroCta2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cNroCuenta"]);
                    cboMonDestino2.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaDest"]);

                    cboTipoEntidadDes2.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["TipoEntidadDes"]);
                    cboEntidadDes2.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadDes"]);                    

                    txtcod2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cCodCliente"]);
                    txtRUC2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cDocumentoID"]);
                    txtRazonSocial2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cNombre"]);
                    txtDireccion2.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["DireccionTrabajo"]);
                }                

                this.conBusCliente.txtCodCli.Enabled = false;
                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 1)
                {
                    btnAceptar1.Enabled = true;
                    btnRechazar1.Enabled = true;
                }
                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) != 1)
                {
                    btnAceptar1.Enabled = false;
                    btnRechazar1.Enabled = false;
                }
            }            
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            frmListSolicitudCTS frmLiSolApr = new frmListSolicitudCTS();
            frmLiSolApr.ShowDialog();
            if (frmLiSolApr.idCliente != 0)
            {
                this.conBusCliente.txtCodInst.Text = frmLiSolApr.cCodCliente.Substring(0, 3);
                this.conBusCliente.txtCodAge.Text = frmLiSolApr.cCodCliente.Substring(3, 3);
                this.conBusCliente.txtCodCli.Text = frmLiSolApr.cCodCliente.Substring(6);
                this.conBusCliente.txtNroDoc.Text = frmLiSolApr.cDocumentoDNI;
                this.conBusCliente.txtNombre.Text = frmLiSolApr.cNomCliente;
                this.conBusCliente.txtDireccion.Text = frmLiSolApr.cDireccion;

                Buscar();
            }
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text))
            {
                MessageBox.Show("No existen datos válidos para la aprobación","Validación de aprobación de Traslado de CTS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCliente.txtNombre.Text))
            {
                MessageBox.Show("No existen datos válidos para la aprobación","Validación de aprobación de Traslado de CTS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 1)
            {
                clsCNSolicCTS Aprob = new clsCNSolicCTS();
                Aprob.AprobRechaz(2, Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolCTS"]), clsVarGlobal.User.idUsuario, Convert.ToDateTime(clsVarGlobal.dFecSystem), txtobservacion.Text);
                MessageBox.Show("La solicitud fue APROBADA", "Aprobación de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.conBusCliente.txtCodCli.Enabled = true;
            this.conBusCliente.txtCodCli.Focus();
            this.conBusCliente.txtCodInst.Text = "";
            this.conBusCliente.txtCodAge.Text = "";
            this.conBusCliente.txtCodCli.Text = "";
            this.conBusCliente.txtNombre.Text = "";
            this.conBusCliente.txtNroDoc.Text = "";
            this.conBusCliente.txtDireccion.Text = "";
            btnAceptar1.Enabled = false;
            btnRechazar1.Enabled = true;
        }

        private void btnRechazar3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text))
            {
                MessageBox.Show("No existen datos válidos para la aprobación", "Validación de aprobación de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCliente.txtNombre.Text))
            {
                MessageBox.Show("No existen datos válidos para la aprobación", "Validación de aprobación de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtobservacion.Text))
            {
                MessageBox.Show("Debe escribir motivo de rechazo de la solicitud", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtobservacion.Focus();
                return;
            }

            if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 1)
            {
                clsCNSolicCTS Aprob = new clsCNSolicCTS();
                Aprob.AprobRechaz(4, Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolCTS"]), clsVarGlobal.User.idUsuario, Convert.ToDateTime(clsVarGlobal.dFecSystem), txtobservacion.Text);
                MessageBox.Show("La solicitud fue RECHAZADA", "Aprobación de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar();
            }
        }

        private void cboTipoEntidadOri2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidadOri2.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidadOri2.SelectedValue);
                cboEntidadOri2.CargarEntidades(nTipEnt);
            }
        }

        private void cboTipoEntidadDes2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidadDes2.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidadDes2.SelectedValue);
                cboEntidadDes2.CargarEntidades(nTipEnt);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //e.Cancel = true;
        }

        private void cboTipoEntidadDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidadDes.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidadDes.SelectedValue);
                cboEntidadDes.CargarEntidades(nTipEnt);
            }
        }
    }
}

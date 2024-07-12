using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRegistraCaractCartaFianza : frmBase
    {
        enum Modo { Lectura, Editar, Bloqueado };
        int modoFormulario;
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza = 0;
        int idEstado = 0;
        private int idPadre = 0;
        public frmRegistraCaractCartaFianza()
        {
            InitializeComponent();
        }

        private void frmRegistraCaractCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[1,13]";            
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro Solicitud: ";
            controles((int)Modo.Bloqueado);        
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private bool estaEnDatos(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');
            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }

        public void cargarDatos()
        {
            limpiarControles();

            int idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);

            if (idSolicitud != 0)
            {

                DataTable dtResultado = cnCartaFianza.obtenerCaracteristicasCartaFianza(idSolicitud);
                if (dtResultado.Rows.Count > 0)                
                {   
                    if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(dtResultado.Rows[0]["idProducto"]))) //carta fianza
                    {
                        MessageBox.Show("La solicitud no corresponde a un producto de carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }
                    if (Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]) != 2)
                    {
                        MessageBox.Show("La carta fianza no se encuentra en estado SOLICITADO", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }
                    this.idCartaFianza = Convert.ToInt32(dtResultado.Rows[0]["idCartaFianza"]);
                    this.idEstado = Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]);
                    idPadre = Convert.ToInt32(dtResultado.Rows[0]["idPadre"]);   
                    if (Convert.ToInt32(dtResultado.Rows[0]["idUsuBeneficiario"]) > 0)
                    {
                        this.conBusCli1.CargardatosCli(Convert.ToInt32(dtResultado.Rows[0]["idUsuBeneficiario"]));
                        this.conBusCli1.idCli = Convert.ToInt32(dtResultado.Rows[0]["idUsuBeneficiario"]);
                        this.txtCodigoProceso.Text = dtResultado.Rows[0]["cProcesoSelec"].ToString();
                        this.cboTipoCartaFianza.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["idTipoCartaFianza"]);
                    }
                    controles((int)Modo.Lectura);
                    btnEditar1.Enabled=!(idPadre>0);
                }
                else
                {
                    controles((int)Modo.Editar);
                }
            }
            else
            {
                controles((int)Modo.Bloqueado);
            }            
        }

        public void controles(int estado)
        {
            modoFormulario = estado;
            switch (estado)
            { 
                case (int)Modo.Bloqueado:
                    this.conBusCli1.txtCodCli.Enabled = false;
                    this.conBusCli1.btnBusCliente.Enabled = false;
                    this.txtCodigoProceso.Enabled = false;
                    this.cboTipoCartaFianza.Enabled = false;                    
                    this.btnCancelar1.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = false;
                    this.cboTipoCartaFianza.SelectedIndex = -1;
                    this.conBusCuentaCli1.limpiarControles();
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    this.conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnCargarFile1.Enabled = true;
                    limpiarControles();
                    break;
                case (int)Modo.Lectura:
                    this.conBusCli1.txtCodCli.Enabled = false;
                    this.conBusCli1.btnBusCliente.Enabled = false;
                    this.txtCodigoProceso.Enabled = false;
                    this.cboTipoCartaFianza.Enabled = false;                    
                    this.btnCancelar1.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = true;
                    btnCargarFile1.Enabled = true;
                    break;                
                case (int)Modo.Editar:
                    this.conBusCli1.txtCodCli.Enabled = true;
                    this.conBusCli1.btnBusCliente.Enabled = true;
                    this.txtCodigoProceso.Enabled = true;
                    this.cboTipoCartaFianza.Enabled = true;                    
                    this.btnCancelar1.Enabled = true;
                    this.btnGrabar1.Enabled = true;
                    this.btnEditar1.Enabled = false;
                    btnCargarFile1.Enabled = false;
                    break;                
            }
        }

        public void limpiarControles()
        {
            this.conBusCli1.limpiarControles();
            this.cboTipoCartaFianza.SelectedIndex = -1;
            this.txtCodigoProceso.Text = "";
        }

        public bool validar()
        {
            if (this.conBusCli1.idCli <= 0)
            {
                MessageBox.Show("Debe seleccionar beneficiario", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCartaFianza.Focus();
                return false;
            }
            if (conBusCli1.idCli==conBusCuentaCli1.nIdCliente)
            {
                MessageBox.Show("El beneficiario debe ser diferente al cliente solicitante", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCartaFianza.Focus();
                return false;
            }
            if (this.cboTipoCartaFianza.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCartaFianza.Focus();
                return false;
            }

            if (this.txtCodigoProceso.Text.Trim().Length <= 0) 
            {
                MessageBox.Show("Debe ingresar el codigo de proceso", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoProceso.Focus();
                return false;
            }
            if (idEstado > 2)
            {
                MessageBox.Show("La carta fianza no puede ser editada dado que esta aprobada o denegada", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarControles();
                controles((int)Modo.Bloqueado);
                return false;
            }
            return true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            controles((int)Modo.Editar);
            
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())               
            {
                int idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);
                DataTable dtResultado = new DataTable();
                dtResultado = cnCartaFianza.actualizarCaracteristicasCartaFianza(idCartaFianza, idSolicitud, Convert.ToInt32(cboTipoCartaFianza.SelectedValue), conBusCli1.idCli, txtCodigoProceso.Text.Trim());                    

                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
                {
                    MessageBox.Show("Se actualizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    controles((int)Modo.Lectura);
                }
                else
                {
                    MessageBox.Show((this.idCartaFianza > 0) ? "Error al actualizar la carta fianza" : "Error al registrar la carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                                
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            switch (modoFormulario)
            { 
                case (int)Modo.Lectura:
                    controles((int)Modo.Bloqueado);
                    break;
                case (int)Modo.Editar:
                    cargarDatos();
                    controles((int)Modo.Lectura);
                    break;
            }
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            frmBuscarCartasFianza frmBuscarCartasFianza = new frmBuscarCartasFianza();
            frmBuscarCartasFianza.cargarCartasFianza(2);
            frmBuscarCartasFianza.ShowDialog();
            if (frmBuscarCartasFianza.idSolicitud > 0 && frmBuscarCartasFianza.lAceptar)
            {
                this.conBusCuentaCli1.txtNroBusqueda.Text = frmBuscarCartasFianza.idSolicitud.ToString();
                this.conBusCuentaCli1.consultar();
            }
        }

    }
}

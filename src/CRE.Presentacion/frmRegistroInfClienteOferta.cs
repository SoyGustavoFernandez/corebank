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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using GEN.BotonesBase;

namespace CRE.Presentacion
{
    public partial class frmRegistroInfClienteOferta : frmBase
    {

        #region Variables Globales
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        int idCli = 0;
        string cDocumentoID = "";
        int idUsuario = clsVarGlobal.User.idUsuario;
        int idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
        int idAgencia = clsVarGlobal.nIdAgencia;
        string cTituloMsj = "Registro de información de cliente de Oferta";

        #endregion



        #region Eventos
        public frmRegistroInfClienteOferta()
        {
            InitializeComponent();
            this.CargaComboBoxTipContacto();
            this.CargaComboBoxDetalleTipContacto();
            this.dtpCorto1.Value = clsVarGlobal.dFecSystem;
            
        }

        public frmRegistroInfClienteOferta(int idCliente, string cDni)
        {
            InitializeComponent();
            this.CargaComboBoxTipContacto();
            this.CargaComboBoxDetalleTipContacto();
            this.dtpCorto1.Value = clsVarGlobal.dFecSystem;

            this.idCli = idCliente;
            this.cDocumentoID = cDni;

            this.cboDetTipContacto.SelectedIndex = -1;
            this.cboTipContacto.SelectedIndex = -1;
        }


        private void cboDetTipContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDetTipContacto.SelectedIndex == 1)
            {
                lblBase4.Visible = true;
                lblBase5.Visible = true;
                dtpCorto1.Visible = true;
            }
            else
            {
                lblBase4.Visible = false;
                lblBase5.Visible = false;
                dtpCorto1.Visible = false;
            }

            if (cboDetTipContacto.SelectedIndex == 10)
            {
                lblBase3.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                lblBase3.Visible = false;
                richTextBox1.Visible = false;
            }


        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            grabarDatos();
        }

        #endregion


        #region Métodos
        
        public void CargaComboBoxTipContacto()
        {
            DataTable dtCargaCboTipCont = new DataTable();


            dtCargaCboTipCont = objCE.CNObtenerDatosTipContacto();
                      
            this.cboTipContacto.DataSource = dtCargaCboTipCont;
            this.cboTipContacto.ValueMember = "id";
            this.cboTipContacto.DisplayMember = "cDetalle";
        }

        public void CargaComboBoxDetalleTipContacto()
        {
            DataTable dtCargaCboDetTipCont = new DataTable();


            dtCargaCboDetTipCont = objCE.CNObtenerDatosDetRegContacto();

            this.cboDetTipContacto.DataSource = dtCargaCboDetTipCont;
            this.cboDetTipContacto.ValueMember = "id";
            this.cboDetTipContacto.DisplayMember = "cDetalle";
        }

        public void grabarDatos()
        {
            DataTable dtCargaCboDetTipCont = new DataTable();
            int idTipoContacto = Convert.ToInt32(cboTipContacto.SelectedValue);
            int idDetTipoContacto = Convert.ToInt32(cboDetTipContacto.SelectedValue);
            string cDetalleOtros = Convert.ToString(richTextBox1.Text);
            DateTime dFechaSel = Convert.ToDateTime(dtpCorto1.Value);

            if (cboTipContacto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de contacto.", cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboDetTipContacto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el detalle del tipo de contacto.", cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (String.IsNullOrEmpty(richTextBox1.Text) && idDetTipoContacto == 11 || String.IsNullOrWhiteSpace(richTextBox1.Text) && idDetTipoContacto == 11)
            {
                MessageBox.Show("Por favor escriba la respuesta del cliente en el cuadro de texto.", cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            dtCargaCboDetTipCont = objCE.CNGuardarDatosDetRegContacto(idTipoContacto, idDetTipoContacto, cDetalleOtros, Convert.ToString(dFechaSel), idUsuario, idEstablecimiento, idAgencia, idCli, cDocumentoID);

            if(dtCargaCboDetTipCont.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtCargaCboDetTipCont.Rows[0]["nIdMsj"]) == 1)
                {
                    MessageBox.Show(dtCargaCboDetTipCont.Rows[0]["cMensaje"].ToString(), cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(dtCargaCboDetTipCont.Rows[0]["cMensaje"].ToString(), cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un problema al registrar la información.", cTituloMsj, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            this.cboTipContacto.Enabled = false;
            this.cboDetTipContacto.Enabled = false;
            this.richTextBox1.Enabled = false;
            this.dtpCorto1.Enabled = false;


        }
        
        
        #endregion
            


    }
}

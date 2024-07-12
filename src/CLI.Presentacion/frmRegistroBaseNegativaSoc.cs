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
using CLI.CapaNegocio;
using EntityLayer;
namespace CLI.Presentacion
{
    public partial class frmRegistroBaseNegativaSoc : frmBase
    {
        
        clsCNSocio cnBaseNegSoc = new clsCNSocio();

        public int nopcion;
        public frmRegistroBaseNegativaSoc()
        {
            InitializeComponent();
        }
        private bool validar()
        {
            if (conBusSocio1.txtCodCli.Text.Trim() == "")
            {
                MessageBox.Show("Debe Selecccionar un Socio", "Registro de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtMotivo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un Motivo", "Registro de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (chcBaja.Checked == true && txtSustento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el Sustento", "Registro de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            
            clsBaseNegaSocio bsNegtiva = new clsBaseNegaSocio();
            bsNegtiva.idCli = conBusSocio1.idCli;
            bsNegtiva.cMotivo = txtMotivo.Text;
            bsNegtiva.dFechaReg = clsVarGlobal.dFecSystem;
            bsNegtiva.idUsuReg = clsVarGlobal.User.idUsuario;
            bsNegtiva.idAgencia = clsVarGlobal.nIdAgencia;
            bsNegtiva.idEstado = 1;
            bsNegtiva.cSustento = txtSustento.Text;
            if ((nopcion==2))
            {
                if (chcBaja.Checked)
                {
                    bsNegtiva.idEstado = 2;
                }
                
            }
           
            bsNegtiva.idUsuMod = clsVarGlobal.User.idUsuario;
            bsNegtiva.dFechaMod = clsVarGlobal.dFecSystem;
            bsNegtiva.idBaseNegSoc = 0;

            cnBaseNegSoc.insertarActBaseNegativSocio(nopcion, bsNegtiva);

            MessageBox.Show("Se Grabo Correctamente", "Base Negativa de Socios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            habilitarObj(false);
            txtMotivo.ReadOnly = true;           
            chcBaja.Enabled = false;
            txtSustento.Enabled = false;
            txtMotivo.Clear();
            conBusSocio1.Enabled = true;
            conBusSocio1_ClicBuscar(sender, e);
            if (txtMotivo.Text.Trim() == "")
            {
                chcBaja.Checked = false;
                chcBaja_CheckedChanged(sender,e);
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (conBusSocio1.txtCodCli.Text.Trim()=="" || conBusSocio1.txtNroDoc.Text.Trim()=="" )
            {
                MessageBox.Show("Seleccionar un Socio", "Base Negativa de Socios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            nopcion = 1;
            conBusSocio1.Enabled = false;
            habilitarObj(true);
            chcBaja.Enabled = false;
            txtMotivo.ReadOnly = false;
        }
        void habilitarObj(bool lactivo)
        {
            btnGrabar1.Enabled = lactivo;
            btnEditar1.Enabled = !lactivo;
            btnNuevo1.Enabled = !lactivo;
            btnCancelar1.Enabled = lactivo;           
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (txtMotivo.Text.Trim() != "")
            {
                nopcion = 2;
                habilitarObj(true);               
                chcBaja.Enabled = true;           
                txtMotivo.ReadOnly = true;
                conBusSocio1.Enabled = false;
            }else{
                MessageBox.Show("Debe Seleccionar un Socio que esté \n en la Base Negativa", "Base Negativa de Socios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }
        }

        private void frmRegistroBaseNegativaSoc_Load(object sender, EventArgs e)
        {
            ValoresIniciales();
            chcBaja.Enabled = false;
            txtMotivo.ReadOnly = true;
            chcBaja_CheckedChanged(sender, e);
        }
        void ValoresIniciales()
        {
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            dtpFechaReg.Value = clsVarGlobal.dFecSystem;
            chcBaja.Checked = false;
            txtMotivo.Clear();
            txtSustento.Clear();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            chcBaja.Enabled = false;
            chcBaja.Checked = false;
            txtSustento.Clear();
            txtMotivo.ReadOnly = true;
            habilitarObj(false);
            conBusSocio1.txtCodCli.Enabled = true;
            
            nopcion = 0;

            conBusSocio1.txtCodInst.Text = "";
            conBusSocio1.txtCodAge.Text = "";
            conBusSocio1.txtCodCli.Text = "";
            conBusSocio1.txtNroDoc.Text = "";
            conBusSocio1.txtNombre.Text = "";
            conBusSocio1.txtDireccion.Text = "";
            conBusSocio1.txtCodCli.Enabled = true;
            conBusSocio1.txtCodCli.Focus();
            ValoresIniciales();
            conBusSocio1.Enabled = true;

        }

        private void chcBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBaja.Checked)
            {
                txtSustento.Visible = true;
                lblBase4.Visible = true;
                txtSustento.Enabled = true;
            }
            else
            {
                txtSustento.Visible=false;
                lblBase4.Visible = false;
            }
        }

        private void conBusSocio1_ClicBuscar(object sender, EventArgs e)
        {   
           
            if(cnBaseNegSoc.validarSocioXidCli(conBusSocio1.idCli)<=0)
            {   
                
                conBusSocio1.txtCodInst.Text = "";
                conBusSocio1.txtCodAge.Text = "";
                conBusSocio1.txtCodCli.Text = "";
                conBusSocio1.txtNroDoc.Text = "";
                conBusSocio1.txtNombre.Text = "";
                conBusSocio1.txtDireccion.Text = "";
                conBusSocio1.txtCodCli.Enabled = true;
                conBusSocio1.txtCodCli.Focus();
                ValoresIniciales();
                if ((conBusSocio1.idCerrado == 1 && conBusSocio1.idCli == 0) || conBusSocio1.idCli == 0)
                {
                    conBusSocio1.txtCodCli.Enabled = true;
                    return;
                }
                MessageBox.Show("Cliente no es Socio, Debe Asignar en la \n opción de 'Mantenimiento de Socios'","Busqueda de Socios",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                conBusSocio1.txtCodCli.Enabled = true;
                return;
            }
            int idPertenece=0;
            var fuentesdepen = from item in cnBaseNegSoc.retornarBaseNegativaSocio(conBusSocio1.idCli, ref idPertenece)
                               select item;

            if (idPertenece == 1)
            {
                ValoresIniciales();
                btnNuevo1.Enabled = false;
            }

            foreach (var item in fuentesdepen.ToList())
            {   
                txtMotivo.Text = item.cMotivo;
                cboAgencias1.SelectedValue = item.idAgencia;
                dtpFechaReg.Value = item.dFechaReg;
                txtSustento.Text = item.cSustento;
                chcBaja.Checked = (item.idEstado == 2) ? true : false;
            }
            btnNuevo1.Enabled=(txtMotivo.Text.Trim() != "")?false:true;
            btnEditar1.Enabled = (txtMotivo.Text.Trim() != "") ? true : false;
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            txtMotivo.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtSustento_TextChanged(object sender, EventArgs e)
        {
            txtSustento.CharacterCasing = CharacterCasing.Upper;
        }
    }
}

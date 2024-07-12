using EntityLayer;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmRegistroFamiliar : frmBase
    {
        private clsFamiliar newFamiliar = new clsFamiliar();
        private bool validado=false;
        public bool agregar = false;
        public frmRegistroFamiliar()
        {
            InitializeComponent();

            clsCNTipoFamiliar tiposfam = new clsCNTipoFamiliar();
            DataTable dtbfamiliar = tiposfam.ListarTipoFamiliar();

            cboVinculo.DataSource = dtbfamiliar;
            cboVinculo.ValueMember = dtbfamiliar.Columns[0].ToString();
            cboVinculo.DisplayMember = dtbfamiliar.Columns[1].ToString();
            cboTipDocumento1.CargarDocumentosSplaftPep();
        }

        public clsFamiliar DevolverFamiliar()
        {   
            return newFamiliar;
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                newFamiliar.cApeMaterno = txtMaterno.Text;
                newFamiliar.cApePaterno = txtPaterno.Text;
                newFamiliar.cNombres = txtNombres.Text;
                newFamiliar.nNumDoc = txtDocumento.Text;
                newFamiliar.nIdVinculo = Convert.ToInt32(cboVinculo.SelectedValue);
                newFamiliar.idTipoDoc = Convert.ToInt32(cboTipDocumento1.SelectedValue);
                newFamiliar.cTipoDoc = ((DataTable)cboTipDocumento1.DataSource).Rows[cboTipDocumento1.SelectedIndex]["cTipoDocumento"].ToString();
                newFamiliar.cDescripcion = cboVinculo.Text;
                newFamiliar.cDireccion = txtDireccion.Text;
                agregar = true;
                this.Close();
            }
        }

        private bool ValidarCampos() 
        {
            if (cboTipDocumento1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de documento", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (Convert.ToInt32(cboTipDocumento1.SelectedValue) == 1)
            {
                //if (txtDocumento.Text.Length < 8)
                //{
                //    MessageBox.Show("Nro de DNI debe tener 8 dígitos", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //   return false;
                //}
            }

            foreach (Control _textbox in this.Controls)
            {
                if (_textbox is TextBox && string.IsNullOrEmpty(_textbox.Text))
                {
                    if (_textbox.Tag != txtDocumento.Tag)
                    {
                        MessageBox.Show("El campo " + _textbox.Tag + " esta vacio", "Registro Familiares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return validado;
                    }
                }
            }

            return validado = true;
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            txtNombres.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtPaterno_TextChanged(object sender, EventArgs e)
        {
            txtPaterno.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtMaterno_TextChanged(object sender, EventArgs e)
        {
            txtMaterno.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTipDocumento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipDocumento1.SelectedValue.GetType().FullName == "System.Data.DataRowView")
            {
                return;
            }
            txtDocumento.Clear();
            txtDocumento.Focus();
            if (Convert.ToInt32(cboTipDocumento1.SelectedValue).In(1, 4, 11))
            {
                txtDocumento.lSoloNumeros = false;
            }
            else
            {
                txtDocumento.lSoloNumeros = true;
            }

            if (Convert.ToInt32(cboTipDocumento1.SelectedValue).In(1, 11))
            {
                txtDocumento.MaxLength = 8;

            }
            else if (Convert.ToInt32(cboTipDocumento1.SelectedValue) == 4)
            {
                txtDocumento.MaxLength = 11;
            }
            else
            {
                txtDocumento.MaxLength = 15;
            }
        }
    }
}

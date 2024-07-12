using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using System.Text.RegularExpressions;
using GEN.ControlesBase;
using CLI.Presentacion;
using CLI.Servicio;

namespace GEN.ControlesBase
{
    public partial class conBusPersonSplaft : UserControl
    {
        #region Variable Globales

        public Boolean EsCliente { get; set; }
        private Boolean lEditar = false;
        public int RolCliente { get; set; }
        public int idT { get; set; }        
        public Boolean JuridicoHabilitado { get; set; }
        clsCNListaActivEco cnactividad = new clsCNListaActivEco();
        clsCNTipoDocumento cntipodocumento = new clsCNTipoDocumento();
        int tipoPersonaSPL=1, idCli;

        //Padron RUC Persona Natural
        string cPatron = "^10";
        clsProcesaDatosRen objCliente;
        clsCNCliente Cliente = new clsCNCliente();
        int idProfe = 0;
        int idCarg = 0;

        #endregion

        public conBusPersonSplaft()
        {
            InitializeComponent();
            JuridicoHabilitado = true;

            clsCNProfesion listaProf = new clsCNProfesion();
            DataTable tbOcup = listaProf.ListarProfesion();

            cboOcupacion.ValueMember = tbOcup.Columns[0].ToString();
            cboOcupacion.DisplayMember = tbOcup.Columns[1].ToString();
            cboOcupacion.DataSource = tbOcup;
            cboOcupacion.SelectedValue = -1;


            //------------------------COMBO CIUU------------------------//
            clsCNListaActivEco objActEco = new clsCNListaActivEco();
            DataTable dtbActEco = objActEco.ListaActividadEco(0);
            cboCIUU.ValueMember = dtbActEco.Columns[0].ToString();
            cboCIUU.DisplayMember = dtbActEco.Columns[1].ToString();
            cboCIUU.DataSource = dtbActEco;



            cboCIUU2.ValueMember = dtbActEco.Columns[0].ToString();
            cboCIUU2.DisplayMember = dtbActEco.Columns[1].ToString();
            cboCIUU2.DataSource = dtbActEco;

            //-------------------------COMBO DETALLE ACTIVIDAD--------------------/
            clsCNListaActivEco detAct = new clsCNListaActivEco();
            DataTable detActS = detAct.ListaActividadEco(1);
            cboActividadDetalle1.ValueMember = detActS.Columns[0].ToString();
            cboActividadDetalle1.DisplayMember = detActS.Columns[1].ToString();
            cboActividadDetalle1.DataSource = detActS;
            cboActividadDetalle1.SelectedValue = 1;

            cboActividadDetalle2.ValueMember = detActS.Columns[0].ToString();
            cboActividadDetalle2.DisplayMember = detActS.Columns[1].ToString();
            cboActividadDetalle2.DataSource = detActS;
            cboActividadDetalle2.SelectedValue = 1;
        }

        #region Eventos
                        
        private void conBusPersonSplaft_Load(object sender, EventArgs e)
        {
        }
        
        private void rbtnPjuridica_CheckedChanged(object sender, EventArgs e)
        {
            grbJuridica.Visible = true;
            grbNatural.Visible = false;
            grbJuridica.Location = grbNatural.Location;
            txtNumRuc.Enabled = true;
            tipoPersonaSPL = 3;
            lblFecNac.Text = "Fec.Cons.";
            
            string cCodigoRUC = "4";
            string cCodigoSwift = "7";
            
            if (rbtnPjuridica.Checked && RdBtnNacionPer.Checked)
            {
                cambiarCombo(cCodigoRUC);
            }
            if (rbtnPjuridica.Checked && RdBtnNacionExt.Checked)
            {
                cambiarCombo(cCodigoSwift);
            }

            
            
        }
        
        private void rbtnPnatural_CheckedChanged(object sender, EventArgs e)
        {
            grbNatural.Visible = true;
            grbJuridica.Visible = false;
            tipoPersonaSPL = 1;
            lblFecNac.Text = "Fec.Nac.";

            string cCodigoDNI = "1";
            string cCodigoExtra = "2";
            
            if (RdBtnNacionPer.Checked)
            {
                cambiarCombo(cCodigoDNI);
            }
            else if (RdBtnNacionExt.Checked)
            {
                cambiarCombo(cCodigoExtra);
            }
            
        }
        
        private void chcNegocio_CheckedChanged(object sender, EventArgs e)
        {
            
            //cboActividadDetalle1.Enabled = chcNegocio.Checked;
            //cboGrupoCiiu.Enabled = chcNegocio.Checked;
            //cboCIUU.Enabled = chcNegocio.Checked;
            if (chcNegocio.Enabled)
            {
                if (!chcNegocio.Checked)
                {
                    txtNumRuc.Clear();
                    txtNumRuc.Enabled = false;
                }
                else
                {
                    txtNumRuc.Enabled = chcNegocio.Checked;
                    tipoPersonaSPL = 1;
                    txtNumRuc.Focus();
                    //txtNumRuc.Text = "10";
                    //txtNumRuc.Select(2, 1);
                }
            }
            
        }
        
        private void cboCIUU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCIUU.SelectedIndex > 0)
            {
                this.cboGrupoCiiu.CargarActivEconomica((int)cboCIUU.SelectedValue);
            }
            else
            {
                this.cboGrupoCiiu.DataSource = null;
                this.cboGrupoCiiu.Items.Clear();
            }
        }

        private void cboGrupoCiiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoCiiu.SelectedIndex > -1)
            {
                if (cboGrupoCiiu.SelectedValue is DataRowView) return;

                this.cboActividadDetalle1.CargarActivEconomica((int)cboGrupoCiiu.SelectedValue);
            }
            else
            {
                this.cboActividadDetalle1.DataSource = null;
                this.cboActividadDetalle1.Items.Clear();
            }
        }

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCargo.SelectedIndex >-1)
            {
                if (this.cboCargo.SelectedValue is DataRowView) return;

                var idCargo = (int)this.cboCargo.SelectedValue;
                if (idCargo==37)
                {
                    txtDescripcion.Enabled = true;
                    txtDescripcion.Focus();
                }
                else
                {
                    txtDescripcion.Clear();
                    txtDescripcion.Enabled = false;
                }
            }
        }

        private void cboCIUU2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCIUU2.SelectedIndex > 0)
            {
                this.cboGrupoCiiu2.CargarActivEconomica((int)cboCIUU2.SelectedValue);
            }
        }

        private void cboGrupoCiiu2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoCiiu2.SelectedIndex > -1)
            {
                if (cboGrupoCiiu2.SelectedValue is DataRowView) return;

                this.cboActividadDetalle2.CargarActivEconomica((int)cboGrupoCiiu2.SelectedValue);
            }
        }

        private void cboTipoDocu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocu.SelectedValue.GetType().FullName == "System.Data.DataRowView")
            {
                return;
            }
            txtNumDoc.Clear();
            txtNumDoc.Focus();
            if (Convert.ToInt32(cboTipoDocu.SelectedValue).In(1, 4, 11, 2))
            {
                txtNumDoc.lSoloNumeros = false;
            }
            else
            {
                txtNumDoc.lSoloNumeros = true;
            }

            if (Convert.ToInt32(cboTipoDocu.SelectedValue).In(1, 11))
            {
                txtNumDoc.MaxLength = 8;

            }
            else if (Convert.ToInt32(cboTipoDocu.SelectedValue) == 4)
            {
                txtNumDoc.MaxLength = 11;
            }
            else if (Convert.ToInt32(cboTipoDocu.SelectedValue) == 2)
            {
                txtNumDoc.MaxLength = 9;
            }
            else
            {
                txtNumDoc.MaxLength = 15;
            }
        }

        private void cboOcupacion_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cboOcupacion.SelectedValue == null)
                 return;
            if (cboOcupacion.SelectedValue.GetType().FullName == "System.Data.DataRowView")
            {
                return;
            }
            
            txtOcupacionOtros.Clear();
            if (Convert.ToInt32(cboOcupacion.SelectedValue) == 145)
            {
                txtOcupacionOtros.Enabled = true;
            }
            else
            {
                txtOcupacionOtros.Enabled = false;
            }
        }

        #endregion

        #region Métodos

        public bool validar(bool lBeneficiario = false)
        {
            var lValida = false;

            if (cboTipoDocu.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDocu.Focus();
                return lValida;
            }

            switch (tipoPersonaSPL)
            {
                #region Caso 1 Persona Natural
                case 1:
                    if (txtNumDoc.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un número de documento válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumDoc.Focus();
                        return lValida;
                    }
                    else
                    {
                        if (Convert.ToInt32(cboTipoDocu.SelectedValue).In(1,4,11))
                        {
                            try
                            {
                                Convert.ToInt64(txtNumDoc.Text);
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("El número de documento es un campo numérico", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumDoc.Text = "";
                                txtNumDoc.Focus();
                                return lValida;
                                throw;
                            }
                        }
                        if ((Convert.ToInt32(cboTipoDocu.SelectedValue) == 1 || Convert.ToInt32(cboTipoDocu.SelectedValue) == 11) && txtNumDoc.Text.Length < 8)
                        {
                            MessageBox.Show("El DNI. consta de 8 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumDoc.Focus();
                            return lValida;
                        }
                        if (Convert.ToInt32(cboTipoDocu.SelectedValue) == 4 && txtNumDoc.Text.Length < 11)
                        {
                            MessageBox.Show("El RUC. consta de 11 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumDoc.Focus();
                            return lValida;
                        }
                    }

                    if (chcNegocio.Checked && rbtnPnatural.Checked)
                    {
                        if (!String.IsNullOrEmpty(txtNumRuc.Text))
                        {
                            if (txtNumRuc.Text.Length < 11)
                            {
                                MessageBox.Show("El RUC. alternativo consta de 11 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumDoc.Focus();
                                return lValida;
                            }

                            if (!Regex.IsMatch(txtNumRuc.Text, cPatron))
                            {
                                MessageBox.Show("El RUC. alternativo de una persona natural debe empezar con 10", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumRuc.Focus();
                                return lValida;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ud. ha seleccionado que la persona tiene negocio, debe registrar el RUC. Alternativo", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumRuc.Focus();
                            return lValida;
                        }
                    }

                    

                    if (string.IsNullOrEmpty(txtApePaterno.Text) && string.IsNullOrEmpty(txtApeMaterno.Text))
                    {
                        MessageBox.Show("El cliente debe tener al menos un apellido paterno o materno", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtApePaterno.Focus();
                        return lValida;
                    }

                    if (idCli == 0)
                    {
                        clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                        string cValidacion = xRetDatCli.RetDatVal(0, txtNumDoc.Text, "D", Convert.ToInt32(cboTipoDocu.SelectedValue));
                        if (cValidacion == "ERROR")
                        {
                            if (rbtnPnatural.Checked)
                            {
                                MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumDoc.Focus();
                                return lValida;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumDoc.Focus();
                                return lValida;
                            }
                        }
                    }
                    // if (string.IsNullOrEmpty(txtApePaterno.Text) && string.IsNullOrEmpty(txtApeCasada.Text) && string.IsNullOrEmpty(txtApeMaterno.Text) )
                    // {
                    //     MessageBox.Show("El cliente debe tener al menos un apellido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     txtApePaterno.Focus();
                    //     return lValida;
                    // }


                    // if (string.IsNullOrEmpty(txtApeCasada.Text))
                    // {
                    //     if (string.IsNullOrEmpty(txtApeMaterno.Text) && !RdBtnNacionExt.Checked)
                    //     {
                    //         MessageBox.Show("Debe ingresar un apellido materno válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //         txtApeMaterno.Focus();
                    //         return lValida;
                    //     }
                    // }                    

                    if (string.IsNullOrEmpty(txtNombres.Text))
                    {
                        MessageBox.Show("Debe ingresar un nombre válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombres.Focus();
                        return lValida;
                    }

                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        if (Convert.ToInt32(this.cboCargo.SelectedValue) == 37)
                        {
                            MessageBox.Show("Debe ingresar una descripción de la cargo", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDescripcion.Focus();
                            return lValida;
                        }   
                    }

                    if (Convert.ToInt32(conBusUB.cboAnexo.SelectedValue) == 0)
                    {
                        MessageBox.Show("Se debe ingresar el ubigeo de la persona", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conBusUB.Focus();
                        return lValida;
                    }

                    if (txtDireccion.Text.Length < 5)
                    {
                        MessageBox.Show("La dirección debe tener al menos 5 caracteres", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                        return lValida;
                    }

                    if (dtpFecNac.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de nacimiento incorrecta", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtpFecNac.Focus();
                        return lValida;
                    }

                    //if (RolCliente == 1) //Validaciones solamente para la persona física
                    //{
                    if (!lBeneficiario)
                    {
                        if (dtpFecNac.Value > clsVarGlobal.dFecSystem.AddYears(-18).Date)
                        {
                            MessageBox.Show("La fecha de nacimiento es incorrecta, la persona debe ser mayor de edad", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtpFecNac.Focus();
                            return lValida;
                        }
                    }
                        if (cboOcupacion.SelectedIndex < 0)
                        {
                            MessageBox.Show("Seleccione la ocupación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboOcupacion.Focus();
                            return lValida;
                        }

                        if (chcNegocio.Checked)
                        {
                            if (cboActividadDetalle1.SelectedIndex < 0)
                            {
                                MessageBox.Show("Seleccione el CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboActividadDetalle1.Focus();
                                return lValida;
                            }
                        }
                        if (cboCargo.SelectedIndex < 0)
                        {
                            MessageBox.Show("Seleccione el cargo", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboCargo.Focus();
                            return lValida;
                        }
                    //}

                    if (Convert.ToInt32(cboOcupacion.SelectedValue) == 145)
                    {
                        if (String.IsNullOrEmpty(txtOcupacionOtros.Text.Trim()))
                        {
                            MessageBox.Show("Debe ingresar la ocupación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtOcupacionOtros.Focus();
                            return lValida;
                        }
                        
                    }

                    if (cboOcupacion.SelectedIndex < 0)
                    {
                        MessageBox.Show("Debe seleccionar su profesión u ocupación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboOcupacion.Focus();
                        return lValida;
                    }

                    if (chcNegocio.Checked)
                    {
                        if (String.IsNullOrEmpty(txtNumRuc.Text))
                        {
                            MessageBox.Show("Ud. ha seleccionado que la persona tiene negocio con RUC, debe ingresar en el campo documento adicional el ruc del negocio", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumRuc.Focus();
                            return lValida;
                        }

                        if (txtNumRuc.Text.Length != 11)
                        {
                            MessageBox.Show("El documento adicional (RUC) del negocio debe tener 11 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumRuc.Focus();
                            return lValida;
                        }
                    }

                    if (dtpFecNac.Value < clsVarGlobal.dFecSystem.AddYears(-18).Date)
                    {
                        if (cboCIUU.SelectedValue != null)
                        {
                            if (Convert.ToInt32(this.cboCIUU.SelectedValue) == 0)
                            {
                                MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cboCIUU.Focus();
                                return lValida;
                            }
                        }

                        if (cboGrupoCiiu.SelectedValue != null)
                        {
                            if (Convert.ToInt32(this.cboGrupoCiiu.SelectedValue) == 0)
                            {
                                MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cboGrupoCiiu.Focus();
                                return lValida;
                            }
                        }

                        if (this.cboActividadDetalle1.SelectedValue != null)
                        {
                            if (Convert.ToInt32(this.cboActividadDetalle1.SelectedValue) == 0)
                            {
                                MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cboActividadDetalle1.Focus();
                                return lValida;
                            }
                        }

                        if (this.cboCIUU.SelectedValue == null)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboCIUU.Focus();
                            return lValida;
                        }

                        if (this.cboGrupoCiiu.SelectedValue == null)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboGrupoCiiu.Focus();
                            return lValida;
                        }

                        if (this.cboActividadDetalle1.SelectedValue == null)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboActividadDetalle1.Focus();
                            return lValida;
                        }
                    }
                    break;
                #endregion
                #region Caso 2 Persona Juridica 
                case 2:

                    if (string.IsNullOrEmpty(txtApeCasada.Text))
                    {
                        if (string.IsNullOrEmpty(txtApeMaterno.Text))
                        {
                            MessageBox.Show("Debe ingresar un apellido materno válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtApeMaterno.Focus();
                            return lValida;
                        }
                    }

                    if (string.IsNullOrEmpty(txtApePaterno.Text))
                    {
                        MessageBox.Show("Debe ingresar un apellido paterno válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtApePaterno.Focus();
                        return lValida;
                    }

                    if (string.IsNullOrEmpty(txtNombres.Text))
                    {
                        MessageBox.Show("Debe ingresar un nombre válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombres.Focus();
                        return lValida;
                    }

                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Debe ingresar una descripción de la ocupación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcion.Focus();
                        return lValida;
                    }

                    if (txtNumDoc.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un número de documento válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumDoc.Focus();
                        return lValida;
                    }
                    if (dtpFecNac.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de nacimiento incorrecta", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtpFecNac.Focus();
                        return lValida;
                    }
                    else
                    {
                        if (Convert.ToInt32(cboTipoDocu.SelectedValue).In(1, 4, 11))
                        {
                            try
                            {
                                Convert.ToInt64(txtNumDoc.Text);
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("El número de documento es un campo numérico", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNumDoc.Text = "";
                                txtNumDoc.Focus();
                                return lValida;
                                throw;
                            }
                        }
                        if ((Convert.ToInt32(cboTipoDocu.SelectedValue) == 1 || Convert.ToInt32(cboTipoDocu.SelectedValue) == 11) && txtNumDoc.Text.Length < 8)
                        {
                            MessageBox.Show("El DNI. consta de 8 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumDoc.Focus();
                            return lValida;
                        }
                        if (Convert.ToInt32(cboTipoDocu.SelectedValue) == 4 && txtNumDoc.Text.Length < 11)
                        {
                            MessageBox.Show("El RUC. consta de 11 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNumDoc.Focus();
                            return lValida;
                        }
                    }

                    if (txtNumRuc.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un número de RUC válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumRuc.Focus();
                        return lValida;
                    }

                    if (cboCIUU2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboCIUU2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboCIUU2.Focus();
                            return lValida;
                        }
                    }

                    if (cboGrupoCiiu2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboGrupoCiiu2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboGrupoCiiu2.Focus();
                            return lValida;
                        }
                    }
                    
                    if (this.cboActividadDetalle2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboActividadDetalle2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboActividadDetalle2.Focus();
                            return lValida;
                        }
                    }

                    if (this.cboCIUU2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCIUU2.Focus();
                        return lValida;
                    }

                    if (this.cboGrupoCiiu2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboGrupoCiiu2.Focus();
                        return lValida;
                    }

                    if (this.cboActividadDetalle2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCIUU2.Focus();
                        return lValida;
                    }
                    break;
                #endregion
                #region Caso 3 Persona Juridica
                case 3:

                    if (string.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                        MessageBox.Show("Debe ingresar una razón social válida", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRazonSocial.Focus();
                        return lValida;
                    }
                    if (string.IsNullOrEmpty(txtNombreComercial.Text))
                    {
                        MessageBox.Show("Debe ingresar una nombre comercial válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreComercial.Focus();
                        return lValida;
                    }
                    if (this.txtNumDoc.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un número de RUC válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumRuc.Focus();
                        return lValida;
                    }

                    if (cboCIUU2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboCIUU2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboCIUU2.Focus();
                            return lValida;
                        }
                    }

                    if (cboGrupoCiiu2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboGrupoCiiu2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboGrupoCiiu2.Focus();
                            return lValida;
                        }
                    }
                    
                    if (this.cboActividadDetalle2.SelectedValue != null)
                    {
                        if (Convert.ToInt32(this.cboActividadDetalle2.SelectedValue) == 0)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboActividadDetalle2.Focus();
                            return lValida;
                        }
                    }

                    if (this.cboCIUU2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCIUU2.Focus();
                        return lValida;
                    }

                    if (this.cboGrupoCiiu2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboGrupoCiiu2.Focus();
                        return lValida;
                    }

                    if (this.cboActividadDetalle2.SelectedValue == null)
                    {
                        MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboActividadDetalle2.Focus();
                        return lValida;
                    }
                    break;
                #endregion
                default:
                    break;
            }
            #region Validaciones generales
            
            if (string.IsNullOrEmpty(txtNumTelefono.Text))
            {
                MessageBox.Show("Debe ingresar un número de teléfono válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumTelefono.Focus();
                return lValida;
            }

            if (txtNumTelefono.Text.Length < 6)
            {
                MessageBox.Show("el número de teléfono debe tener al menos 6 dígitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumTelefono.Focus();
                return lValida;
            }

            if (Convert.ToInt64(txtNumTelefono.Text) == 0)
            {
                MessageBox.Show("El teléfono ingresado es 0, favor de cambiar por uno válido", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumTelefono.Focus();
                return lValida;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe ingresar una dirección válida", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return lValida;
            }

            if (cboResidencia.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un valor para la residencia", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboResidencia.Focus();
                return lValida;
            }
            
            #endregion
            lValida = true;
            return lValida;
        }

        public bool validarListaPersonas(List<clsPersonaSplaft> listaPersonasSplaft, string cTipoRolPersona, int nRolCli)
        {
            bool lResultado = true;
            int nTipPersonaSplaft;
            foreach (clsPersonaSplaft item in listaPersonasSplaft)
            {
                nTipPersonaSplaft = (item.nTipoPersona ==  1)? 1 : 3;
                switch (nTipPersonaSplaft)
                {
                    case 1:
                        #region Validar Persona 1 Natural
                        if (String.IsNullOrEmpty(item.cNumeroDocumento))
                        {
                            MessageBox.Show("Debe ingresar el nro de documento de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }


                        if (String.IsNullOrEmpty(item.cApellidoPaterno) && String.IsNullOrEmpty(item.cApellidoCasado) && String.IsNullOrEmpty(item.cApellidoMaterno))
                        {
                            MessageBox.Show("Ingrese al menos un apellido de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }
                        
                        // if (String.IsNullOrEmpty(item.cApellidoCasado))
                        // {
                        //     if (String.IsNullOrEmpty(item.cApellidoMaterno))
                        //     {
                        //         MessageBox.Show("Ingrese el apellido materno de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //         lResultado = false;
                        //         break;
                        //     }
                        // }

                        if (String.IsNullOrEmpty(item.cNombres))
                        {
                            MessageBox.Show("Ingrese el apellido materno de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (item.NIdUbigeo == null)
                        {
                            MessageBox.Show("Registrar el ubigeo " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (item.dFecNac > clsVarGlobal.dFecSystem)
                        {
                            MessageBox.Show("Ingrese la dirección de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (item.bNegocio && item.nTipoPersona == 1)
                        {
                            if (!String.IsNullOrEmpty(item.nRucAlterno))
                            {
                                if (item.nRucAlterno.Length < 11)
                                {
                                    MessageBox.Show("El RUC. alternativo consta de 11 digitos", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    lResultado = false;
                                    break;
                                }

                                if (!Regex.IsMatch(item.nRucAlterno, cPatron))
                                {
                                    MessageBox.Show("El RUC. alternativo de una persona natural debe empezar con 10", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    lResultado = false;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ud. ha seleccionado que la persona tiene negocio, debe registrar el RUC. Alternativo", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lResultado = false;
                                break;
                            }
                        }

                        if (nRolCli == 1) //Validaciones solamente para la persona física
                        {
                            if (item.dFecNac > clsVarGlobal.dFecSystem.AddYears(-18).Date)
                            {
                                MessageBox.Show("La fecha de nacimiento es incorrecta, la persona "+ cTipoRolPersona + ": " + item.cNombreCompleto+" debe ser mayor de edad " , "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }

                            if (item.nTipoOcupacion == 1 || item.nTipoOcupacion == null)
                            {
                                MessageBox.Show("Seleccione la ocupación de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }

                            // if (String.IsNullOrEmpty(item.cDescripcionOcupacion) && String.IsNullOrEmpty(item.cOcupacionOtros))
                            // {
                            //     MessageBox.Show("Seleccione la ocupación de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //     lResultado = false;
                            //     break;
                            // }

                            if (item.idCIIUNivel1 <= 0 || item.idCIIUNivel1 == null)
                            {
                                MessageBox.Show("Seleccione el CIIU de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }

                            if (item.idCIIUNivel2 <= 0 || item.idCIIUNivel2 == null)
                            {
                                MessageBox.Show("Seleccione el CIIU de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }
                            if (item.nCodCIUU <=0 || item.nCodCIUU == null)
                            {
                                MessageBox.Show("Seleccione el CIIU de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }

                            

                            if (item.nTipoCargo <=0)
                            {
                                MessageBox.Show("Seleccione el cargo de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lResultado = false;
                                break;
                            }
                            
                        }

                        if (item.bNegocio)
                        {
                            if (String.IsNullOrEmpty(item.cNumeroRuc))
                            {
                                MessageBox.Show("Ud. ha seleccionado que la persona tiene negocio con RUC, debe ingresar en el campo documento adicional el ruc del negocio de la " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lResultado = false;
                                break;
                            }

                            if (item.cNumeroRuc.Length != 11)
                            {
                                MessageBox.Show("El documento adicional (RUC) del negocio debe tener 11 digitos de la " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lResultado = false;
                                break;
                            }
                        }
                        break;

                        #endregion
                    case 3:
                        #region Validar Person 3 Juridica
                        if (String.IsNullOrEmpty(item.cRazonSocial))
                        {
                            MessageBox.Show("Ingrese la razón social de la persona juridica " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (String.IsNullOrEmpty(item.cNombreComercial))
                        {
                            MessageBox.Show("Ingrese el nombre comercial de la persona juridica " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (String.IsNullOrEmpty(item.cNumeroDocumento))
                        {
                            MessageBox.Show("Debe ingresar un número de RUC válido de la persona juridica " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lResultado = false;
                            break;
                        }

                        if (item.nCodCIUU == null)
                        {
                            MessageBox.Show("Se debe registrar los 3 niveles del CIIU", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lResultado = false;
                            break; 
                        }
                        break;
                        #endregion
                    default:
                        break;
                }
                #region Validaciones Generales
                if (String.IsNullOrEmpty(item.cTelefono))
                {
                    MessageBox.Show("Debe ingresar un número de teléfono válido de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lResultado = false;
                    break;
                }

                if (item.cTelefono.Length < 6)
                {
                    MessageBox.Show("Debe ingresar un número de teléfono válido de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lResultado = false;
                    break;
                }

                if (String.IsNullOrEmpty(item.cDireccion))
                {
                    MessageBox.Show("Ingrese la dirección de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lResultado = false;
                    break;
                }

                if (item.nCondicionResidencia< 0)
                {
                    MessageBox.Show("Debe seleccionar un valor para la residencia de la persona " + cTipoRolPersona + ": " + item.cNombreCompleto, "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lResultado = false;
                    break;
                }
                #endregion
            }

            return lResultado;
        }
        public void limpiarControles()
        {
            txtNumDoc.Clear();
            txtDireccion.Clear();
            txtNombres.Clear();
            txtNumRuc.Clear();
            txtPartidaRegistral.Clear();
            txtRazonSocial.Clear();
            txtNumTelefono.Clear();
            txtApeCasada.Clear();
            txtApeMaterno.Clear();
            txtApePaterno.Clear();
            txtNombreComercial.Clear();
            txtCodPostal.Clear();

            // cboCargo.SelectedItem = 0;
            // cboCIUU.SelectedItem = 0;
            // cboActividadDetalle1.SelectedItem = 0;
            // cboCIUU2.SelectedItem = 0;
            // cboActividadDetalle2.SelectedItem = 0;
            // cboTipoDocu.SelectedItem = 0;
            cboCargo.SelectedIndex = -1;
            cboCIUU.SelectedIndex = -1;
            cboActividadDetalle1.SelectedIndex = -1;
            cboCIUU2.SelectedIndex = -1;
            cboActividadDetalle2.SelectedIndex = -1;
            cboOcupacion.SelectedIndex = -1;
            cboGrupoCiiu.SelectedIndex = -1;
            
            
            txtCorreoCli.Clear();
            txtOcupacionOtros.Clear();
            conBusUB.nIdNodo = 0;
            
            habilitarControles(true);

            if (!EsCliente)
            {
                chcEsCliente.Enabled = false;
                chcEsCliente.Checked = false;
                chcSocio.Checked = false;
            }
            else
            {
                chcEsCliente.Enabled = false;
                chcEsCliente.Checked = false;
                chcSocio.Checked = false;
            }

            txtDescripcion.Text = "";
            rbtnPnatural.Checked = true;
            grbNatural.Visible = true;
            grbJuridica.Visible = false;
            rbtnPnatural.Enabled = true;
            rbtnPjuridica.Enabled = true;

            idCli = 0;
            switch (RolCliente)
            {
                case 1:
                    if (chcNegocio.Checked)
                    {
                        txtNumRuc.Enabled = true;
                    }
                    else
                    {
                        txtNumRuc.Enabled = false;
                    }
                    

                    lblFecNac.Text = "Fec.Nac.";
                    break;

                case 2:
                    chcNegocio.Checked = false;

                    if (chcNegocio.Checked)
                    {
                        txtNumRuc.Enabled = true;
                    }
                    else
                    {
                        txtNumRuc.Enabled = false;
                    }
                    break;

                case 3:
                    lblFecNac.Text = "Fec.Cons.";
                    if (chcNegocio.Checked)
                    {
                        txtNumRuc.Enabled = true;
                    }
                    else
                    {
                        txtNumRuc.Enabled = false;
                    }
                    break;

                default:
                    break;
            }
        }

        public clsPersonaSplaft obtenerPersona()
        {
            clsPersonaSplaft personaspl = new clsPersonaSplaft();

            if (chcEsCliente.Checked)
            {
                personaspl.nTipoRelacion = 1;

                if (chcNegocio.Checked)
                {
                    personaspl.nTipoRelacion = 2;
                }
            }
            else
            {
                personaspl.nTipoRelacion = 3;
            }
            personaspl.nCondicionResidencia = Convert.ToInt32(cboResidencia.SelectedValue);
            personaspl.nTipoPersona = tipoPersonaSPL;
            personaspl.nTipoDocumento = Convert.ToInt32(cboTipoDocu.SelectedValue);         
            

            switch (tipoPersonaSPL)
            {
                case 1:
                    
                    personaspl.nTipoDocSPLAFT = cntipodocumento.BuscarDocumento(personaspl.nTipoDocumento);
                    personaspl.cNumeroDocumento = txtNumDoc.Text;
                    personaspl.cRazonSocial = "";
                    personaspl.cNombreComercial = "";
                    personaspl.cPartidaRegistral = "";
                    personaspl.cApellidoPaterno = txtApePaterno.Text;
                    personaspl.cApellidoMaterno = txtApeMaterno.Text;
                    personaspl.cApellidoCasado = txtApeCasada.Text;
                    personaspl.cNombres = txtNombres.Text;
                    personaspl.cNumeroRuc = txtNumRuc.Text;
                    personaspl.nTipoCargo = Convert.ToInt32(cboCargo.SelectedValue);
                    personaspl.nTipoOcupacion = Convert.ToInt32(cboOcupacion.SelectedValue);
                    personaspl.cCargo = this.cboCargo.Text.Trim();
                    personaspl.cOcupacion = this.cboOcupacion.Text;
                    personaspl.cNombreCompleto = (txtApePaterno.Text.Trim() + " " + txtApeMaterno.Text.Trim() + " " + txtApeCasada.Text.Trim()).Trim() + ", " + txtNombres.Text.Trim();
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu.SelectedValue);
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle1.SelectedValue);
                    personaspl.nRucAlterno = txtNumRuc.Text;
                    break;

                case 2:

                    personaspl.nTipoDocSPLAFT = cntipodocumento.BuscarDocumento(personaspl.nTipoDocumento);
                    personaspl.cNumeroDocumento = txtNumDoc.Text;
                    personaspl.cRazonSocial = "";
                    personaspl.cNombreComercial = "";
                    personaspl.cPartidaRegistral = "";
                    personaspl.cApellidoPaterno = txtApePaterno.Text;
                    personaspl.cApellidoMaterno = txtApeMaterno.Text;
                    personaspl.cApellidoCasado = txtApeCasada.Text;
                    personaspl.cNombres = txtNombres.Text;
                    personaspl.cNumeroRuc = txtNumRuc.Text;
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle1.SelectedValue);
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu.SelectedValue);
                    personaspl.nTipoCargo = Convert.ToInt32(cboCargo.SelectedValue);
                    personaspl.cCargo = cboCargo.Text.Trim();
                    personaspl.nTipoOcupacion = Convert.ToInt32(cboOcupacion.SelectedValue);
                    personaspl.cOcupacion = this.cboOcupacion.Text;
                    personaspl.nRucAlterno = txtNumRuc.Text;
                    break;

                case 3:
                    personaspl.cRazonSocial = txtRazonSocial.Text;
                    personaspl.cNombreComercial = txtNombreComercial.Text;
                    personaspl.cPartidaRegistral = txtPartidaRegistral.Text;
                    personaspl.cApellidoPaterno = txtRazonSocial.Text;
                    personaspl.cApellidoMaterno = txtNombreComercial.Text;
                    personaspl.cApellidoCasado = "";
                    personaspl.cNombres = "";
                    personaspl.cNumeroRuc = txtNumRuc.Text;
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU2.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu2.SelectedValue);
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle2.SelectedValue);
                    personaspl.cNombreCompleto = txtRazonSocial.Text.Trim();
                    personaspl.cNumeroDocumento = txtNumDoc.Text;
                    personaspl.nRucAlterno = txtNumRuc.Text;
                    break;

                default:
                    break;
            }

            personaspl.cDescripcionOcupacion = this.cboOcupacion.Text;
            personaspl.cCargo = txtDescripcion.Text;
            personaspl.cOcupacionOtros = txtOcupacionOtros.Text.Trim();
            personaspl.NIdUbigeo = Convert.ToInt32(this.conBusUB.cboAnexo.SelectedValue);
            personaspl.nTipoOcupacion = Convert.ToInt32(this.cboOcupacion.SelectedValue);
            personaspl.cOcupacion = this.cboOcupacion.Text;
            personaspl.cDireccion = txtDireccion.Text;
            personaspl.cPais = conBusUB.cboPais.Text;
            personaspl.cDepartamento = conBusUB.cboDepartamento.Text;
            personaspl.cProvincia = conBusUB.cboProvincia.Text;
            personaspl.cDistrito = conBusUB.cboDistrito.Text;
            personaspl.codPais = (conBusUB.cboPais.SelectedValue).ToString();
            personaspl.codDepartamento = (conBusUB.cboDepartamento.SelectedValue).ToString();
            personaspl.codProvincia = (conBusUB.cboProvincia.SelectedValue).ToString();
            personaspl.codDistrito = (conBusUB.cboDistrito.SelectedValue).ToString();
            personaspl.cTelefono = txtNumTelefono.Text;
            personaspl.idLista = idT;
            personaspl.nCodCli = idCli;

            if (!EsCliente)
            {
                personaspl.nCodCli = 0;
            }
            personaspl.dFecNac = dtpFecNac.Value;
            personaspl.cCodPostal = txtCodPostal.Text.Trim();
            personaspl.nidNacionalidad = RdBtnNacionPer.Checked == true ? 0 : 1;
            personaspl.cNacionalidad = RdBtnNacionPer.Checked ? "PERUANA" : "EXTRANJERA";
            personaspl.lSocio = chcSocio.Checked;
            personaspl.cCorreoCli = txtCorreoCli.Text.Trim();
            personaspl.bNegocio = chcNegocio.Checked;

            return personaspl;
        }

        public void habilitarControles(bool lEstado)
        {
            txtApePaterno.Enabled = lEstado;
            txtApeMaterno.Enabled = lEstado;
            txtApeCasada.Enabled = lEstado;
            txtNombres.Enabled = lEstado;
            txtDireccion.Enabled = lEstado;
            conBusUB.Enabled = lEstado;
            txtNumTelefono.Enabled = lEstado;
            btnRegNumTelf.Enabled = lEstado;
            txtNumDoc.Enabled = lEstado;
            txtRazonSocial.Enabled = lEstado;
            cboTipoDocu.Enabled = lEstado;
            cboOcupacion.Enabled = lEstado;
            cboCIUU.Enabled = lEstado;
            cboActividadDetalle1.Enabled = lEstado;
            cboActividadDetalle2.Enabled = lEstado;
            cboCIUU2.Enabled = lEstado;
            cboGrupoCiiu.Enabled = lEstado;
            cboGrupoCiiu2.Enabled = lEstado;
            cboActividadDetalle2.Enabled = lEstado;
            //txtDescripcion.Enabled = lEstado;
            txtNombreComercial.Enabled = lEstado;
            txtPartidaRegistral.Enabled = lEstado;
            txtNumRuc.Enabled = lEstado;
            chcEsCliente.Enabled = lEstado;
            cboResidencia.Enabled = lEstado;
            chcNegocio.Enabled = lEstado;
            dtpFecNac.Enabled = lEstado;
            txtCodPostal.Enabled = lEstado;
            rbtnPjuridica.Enabled = lEstado;
            rbtnPnatural.Enabled = lEstado;
            RdBtnNacionPer.Enabled = lEstado;
            RdBtnNacionExt.Enabled = lEstado;
            txtCorreoCli.Enabled = lEstado;
            cboCargo.Enabled = lEstado;
            //txtOcupacionOtros.Enabled = lEstado;
        }

        public void activarEspeciales(bool lEstado)
        {
            txtDireccion.Enabled = lEstado;
            conBusUB.Enabled = lEstado;
            txtNumTelefono.Enabled = lEstado;
            btnRegNumTelf.Enabled = lEstado;
            txtDescripcion.Enabled = lEstado;
            cboCIUU2.Enabled = lEstado;
            cboActividadDetalle2.Enabled = lEstado;
            cboGrupoCiiu2.Enabled = lEstado;
            cboOcupacion.Enabled = lEstado;
            cboCIUU.Enabled = lEstado;
            cboActividadDetalle1.Enabled = lEstado;
            cboActividadDetalle2.Enabled = lEstado;
            txtCodPostal.Enabled = lEstado;
            txtCorreoCli.Enabled = lEstado;
            cboCargo.Enabled = lEstado;
            cboGrupoCiiu.Enabled = lEstado;
            chcNegocio.Enabled = lEstado;

            lEditar = lEstado;
        }

        public void cargar(bool lBenef = false)
        {
            habilitarControles(true);
            //tipoPersonaSPL = 1;

            if (!lBenef)
            {
                //------------------------COMBO TIPO DE DOCUMENTO------------------------//
                clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
                string cCodigosPer = "1,4";
                string cCodigosExt = "2";
                string cCodigosRuc = "4";
                string cCodigosDni = "1";

                DataTable dt;
                if (RdBtnNacionPer.Checked)
                {
                    dt = ListadoTipoDocumento.listarTipDocEsp(cCodigosPer); ;
                }
                else if (RdBtnNacionExt.Checked)
                {
                    dt = ListadoTipoDocumento.listarTipDocEsp(cCodigosExt); ;
                }
                else
                {
                    dt = ListadoTipoDocumento.CNListaDocSunatSplaft();
                }

                if (rbtnPnatural.Checked)
                {
                    dt = ListadoTipoDocumento.listarTipDocEsp(cCodigosDni); ;
                }
                else if (rbtnPjuridica.Checked)
                {
                    dt = ListadoTipoDocumento.listarTipDocEsp(cCodigosRuc); ;
                }
                else
                {
                    dt = ListadoTipoDocumento.CNListaDocSunatSplaft();
                }

                cboTipoDocu.ValueMember = dt.Columns[0].ToString();
                cboTipoDocu.DisplayMember = dt.Columns[1].ToString();
                this.cboTipoDocu.DataSource = dt;
            
                this.conBusUB.cargar();

                //------------------------COMBO TIPO DE OCUPACION------------------------//
                // clsCNOcupacion ListaOcu = new clsCNOcupacion();
                // DataTable tbOcup = ListaOcu.ListarOcupacion();          
                //clsCNProfesion listaProf = new clsCNProfesion();
                //DataTable tbOcup = listaProf.ListarProfesion();

                //cboOcupacion.ValueMember = tbOcup.Columns[0].ToString();
                //cboOcupacion.DisplayMember = tbOcup.Columns[1].ToString();
                //cboOcupacion.DataSource = tbOcup;
            

                //------------------------COMBO CARGO------------------------//
                clsCNClienteCargo objClienteCargo = new clsCNClienteCargo();
                DataTable dtcargo = objClienteCargo.CNListaClienteCargos();            
                cboCargo.ValueMember = dtcargo.Columns["idCliCargo"].ToString();
                cboCargo.DisplayMember = dtcargo.Columns["cClienteCargo"].ToString();
                cboCargo.DataSource = dtcargo;

                //------------------------COMBO RESIDENCIA------------------------//
                clsCNTipoResidencia objTipoResidencia = new clsCNTipoResidencia();
                DataTable dtTipoResidencia = objTipoResidencia.CNListaTipoResidencia();            
                cboResidencia.ValueMember = dtTipoResidencia.Columns[0].ToString();
                cboResidencia.DisplayMember = dtTipoResidencia.Columns[1].ToString();
                cboResidencia.DataSource = dtTipoResidencia;
            }
            if (!EsCliente)
            {
                chcEsCliente.Enabled = false;
            }
            else
            {
                chcEsCliente.Enabled = true;
            }
            
            if (tipoPersonaSPL == 1)
            {
                txtNumRuc.Enabled = false;
            }
            else
            {
                txtNumRuc.Enabled = true;
            }
        }

        public void cargar(clsPersonaSplaft persona)
        {
            txtOcupacionOtros.Enabled = false;
            if (RolCliente == 1)
            {
                if (persona.nTipoPersona > 1)
                {
                    MessageBox.Show("Una persona jurídica no puede ser la persona física", "Registro Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                    
            }

            if (EsCliente)
            {
                idCli = persona.nCodCli;
                chcEsCliente.Checked = true;
            }
            else
            {
                idCli = 0;
                chcEsCliente.Checked = false;
            }

            habilitarControles(false);
            activarEspeciales(true);

            if (persona.nTipoPersona == 1)
            {
                grbNatural.Visible = true;
                rbtnPjuridica.Enabled = false;
                rbtnPnatural.Select();
                tipoPersonaSPL = 1;
                txtNumRuc.Text = "";

                this.chcNegocio.Checked = persona.bNegocio;
                if (persona.bNegocio)
                {
                    txtNumRuc.Text = persona.cNumeroRuc;
                }
                if (cboCIUU.SelectedIndex > 0)
                {
                    cboCIUU.Enabled = false;
                    cboGrupoCiiu.Enabled = false;
                    cboActividadDetalle1.Enabled = false;
                }

            }
            else if (persona.nTipoPersona > 1)
            {
                grbJuridica.Location = grbNatural.Location;
                grbJuridica.Visible = true;
                grbNatural.Visible = false;
                rbtnPnatural.Enabled = false;
                rbtnPjuridica.Select();
                tipoPersonaSPL = 3;
                txtNumRuc.Text = persona.cNumeroRuc;
                if (cboCIUU2.SelectedIndex > 0)
                {
                    cboCIUU2.Enabled = false;
                    cboGrupoCiiu2.Enabled = false;
                    cboActividadDetalle2.Enabled = false;
                }
            }

            /**Inicio */
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.listarTipoDocumento();            
            cboTipoDocu.ValueMember = dt.Columns[0].ToString();
            cboTipoDocu.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoDocu.DataSource = dt;

            //clsCNOcupacion ListaOcu = new clsCNOcupacion();
            //DataTable tbOcup = ListaOcu.ListarOcupacion();
            //cboOcupacion.ValueMember = tbOcup.Columns[0].ToString();
            //cboOcupacion.DisplayMember = tbOcup.Columns[1].ToString();
            //cboOcupacion.DataSource = tbOcup;
            if (persona.nTipoPersona==1)
            {
                cboOcupacion.SelectedValue = persona.nTipoOcupacion; 
            }
            

            //------------------------COMBO CIUU------------------------//
            cargarActividad(persona.nCodCIUU);

            //------------------------COMBO CARGO------------------------//
            clsCNClienteCargo objClienteCargo = new clsCNClienteCargo();
            DataTable dtcargo = objClienteCargo.CNListaClienteCargos();            
            cboCargo.ValueMember = dtcargo.Columns["idCliCargo"].ToString();
            cboCargo.DisplayMember = dtcargo.Columns["cClienteCargo"].ToString();
            cboCargo.DataSource = dtcargo;
            if (persona.nTipoPersona == 1)
            {
                cboCargo.SelectedValue = persona.nTipoCargo;
            }

            //------------------------COMBO RESIDENCIA------------------------//
            clsCNTipoResidencia objTipoResidencia = new clsCNTipoResidencia();
            DataTable dtTipoResidencia = objTipoResidencia.CNListaTipoResidencia();            
            cboResidencia.ValueMember = dtTipoResidencia.Columns[0].ToString();
            cboResidencia.DisplayMember = dtTipoResidencia.Columns[1].ToString();
            cboResidencia.DataSource = dtTipoResidencia;

            txtApePaterno.Text = persona.cApellidoPaterno;
            txtApeMaterno.Text = persona.cApellidoMaterno;
            txtApeCasada.Text = persona.cApellidoCasado;
            txtNombres.Text = persona.cNombres;
            txtDireccion.Text = persona.cDireccion;
            txtNumTelefono.Text = persona.cTelefono;

            cboTipoDocu.SelectedValue = persona.nTipoDocumento;

            txtNumDoc.Text = persona.cNumeroDocumento;
            cboResidencia.SelectedValue = persona.nCondicionResidencia;
            txtPartidaRegistral.Text = persona.cPartidaRegistral;
            txtNombreComercial.Text = persona.cNombreComercial;
            txtRazonSocial.Text = persona.cRazonSocial;
            dtpFecNac.Value = persona.dFecNac;
            idT = persona.idLista;
            txtCodPostal.Text = persona.cCodPostal;
            chcSocio.Checked = persona.lSocio;
            txtCorreoCli.Text = persona.cCorreoCli;
            txtOcupacionOtros.Text = persona.cOcupacionOtros;

            RdBtnNacionPer.Checked = persona.nidNacionalidad == 0 ? true : false;
            this.RdBtnNacionExt.Checked = persona.nidNacionalidad == 0 ? false : true;
            txtDescripcion.Text = persona.nTipoCargo==37?persona.cCargo:"";
             
            conBusUB.cargarUbigeo(persona.NIdUbigeo);
            txtNumDoc.Text = persona.cNumeroDocumento;
            /** End **/

            
        }

        private void cargarActividad(int idActividad)
        {
            this.cboCIUU.CargarActivEconomica(0);
            this.cboCIUU2.CargarActivEconomica(0);
            var dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);
            var idPadreActividad = 0;
            var idPadreActividad2 = 0;

            if (dtActividad.Rows.Count > 0)
            {
                var dtActividad2 = cnactividad.CNListaActividadEspecifica(Convert.ToInt32((dtActividad.Rows[0]["idPadreActividad"] == DBNull.Value)? 0: dtActividad.Rows[0]["idPadreActividad"]));
                
                if(dtActividad2.Rows.Count > 0)
                {
                    idPadreActividad = Convert.ToInt32(dtActividad2.Rows[0]["idActividad"]);
                    idPadreActividad2 = (dtActividad2.Rows[0]["idPadreActividad"] == DBNull.Value)? 0 :  Convert.ToInt32(dtActividad2.Rows[0]["idPadreActividad"]);
	            }
                //CIIU persona natural
                this.cboCIUU.SelectedValue = idPadreActividad2;
                this.cboGrupoCiiu.SelectedValue = idPadreActividad;
                this.cboActividadDetalle1.SelectedValue = idActividad;
                this.cboCIUU.Enabled = true;
                this.cboGrupoCiiu.Enabled = true;
                this.cboActividadDetalle1.Enabled = true;

                //CIIU persona jurídica
                this.cboCIUU2.SelectedValue = idPadreActividad2;
                this.cboGrupoCiiu2.SelectedValue = idPadreActividad;
                this.cboActividadDetalle2.SelectedValue = idActividad;
                this.cboCIUU2.Enabled = true;
                this.cboGrupoCiiu2.Enabled = true;
                this.cboActividadDetalle2.Enabled = true;
            }
        }
        
        public void conNegocio(bool valB)
        {
            chcNegocio.Enabled = valB;
        }

        public clsPersonaSplaft obtenerPersonaModificada()
        {
            clsPersonaSplaft personaspl = new clsPersonaSplaft();

            personaspl.nTipoOcupacion = Convert.ToInt32(this.cboOcupacion.SelectedValue);
            personaspl.cDescripcionOcupacion = txtDescripcion.Text;

            switch (tipoPersonaSPL)
            {
                case 1:
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu.SelectedValue);
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle1.SelectedValue);
                    break;

                case 2:
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu.SelectedValue);
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle1.SelectedValue);
                    break;

                case 3:
                    personaspl.idCIIUNivel1 = Convert.ToInt32(cboCIUU2.SelectedValue);
                    personaspl.idCIIUNivel2 = Convert.ToInt32(cboGrupoCiiu2.SelectedValue);
                    personaspl.nCodCIUU = Convert.ToInt32(cboActividadDetalle2.SelectedValue);
                    break;

                default:
                    break;
            }

            personaspl.NIdUbigeo = Convert.ToInt32(conBusUB.cboAnexo.SelectedValue);
            personaspl.cDireccion = txtDireccion.Text;
            personaspl.cPais = conBusUB.cboPais.Text;
            personaspl.cDepartamento = conBusUB.cboDepartamento.Text;
            personaspl.cProvincia = conBusUB.cboProvincia.Text;
            personaspl.cDistrito = conBusUB.cboDistrito.Text;
            personaspl.cTelefono = txtNumTelefono.Text;
            personaspl.idLista = idT;
            personaspl.nCodCli = idCli;
            personaspl.cNumeroDocumento = txtNumDoc.Text;
            return personaspl;
        }

        #endregion

        private void cambiarCombo(string cCodigos)
        {
            //------------------------COMBO TIPO DE DOCUMENTO------------------------//
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.listarTipDocEsp(cCodigos);
            cboTipoDocu.ValueMember = dt.Columns[0].ToString();
            cboTipoDocu.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoDocu.DataSource = dt;
            
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            if (idCli != 0)
            { return; }

            if (String.IsNullOrEmpty(txtNumDoc.Text))
            { return; }

            int nTipoDoc = Convert.ToInt32(cboTipoDocu.SelectedValue.ToString()); 

            if (txtNumDoc.Text.Length >= 8)
            {
                string tcDocIde = this.txtNumDoc.Text.Trim();
                if (tcDocIde != "")
                {
                    clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
                    string cValidacion = xRetDatCli.RetDatVal(0, tcDocIde, "D", Convert.ToInt32(cboTipoDocu.SelectedValue));
                    if (cValidacion == "ERROR")
                    {
                        if (rbtnPnatural.Checked)
                        {
                            MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado, busquelo como cliente", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            limpiarControles();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC, busquelo como cliente", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            limpiarControles();
                        }
                    }
                    else
                    {
                        //if (rbtnPnatural.Checked)
                        //{
                        //    BuscarDNI();
                        //}

                    }
                }
            }

        }

        private void RdBtnNacionPer_CheckedChanged(object sender, EventArgs e)
        {
            string cCodigo = "1,4";
            string cCodigoDNI = "1";
            string cCodigoRUC = "4";

            if (rbtnPnatural.Checked)
            {
                cambiarCombo(cCodigoDNI);
            }
            else if (rbtnPjuridica.Checked)
            {
                cambiarCombo(cCodigoRUC);
            }

        }

        private void RdBtnNacionExt_CheckedChanged(object sender, EventArgs e)
        {
            string cCodigoExtranje = "2";
            string cCodigoSwift = "7";

            if (rbtnPnatural.Checked)
            {
                cambiarCombo(cCodigoExtranje);
            }
            if (rbtnPjuridica.Checked)
            {
                cambiarCombo(cCodigoSwift);
            }
        }
        public void ActualizarNroTelefono(string cNroTelNuevo)
        {
            this.txtNumTelefono.Text = cNroTelNuevo;
        }
        public string ExtraerDocumento()
        {
            string cDocumento = Convert.ToString(this.txtNumDoc.Text);
            return cDocumento;
        }
        public string ExtraerNombre()
        {
            string cNombre="";
            if (rbtnPnatural.Checked)
            {
                cNombre = Convert.ToString(this.txtApePaterno.Text) + " " + Convert.ToString(this.txtApeMaterno.Text) + " " + Convert.ToString(this.txtApeCasada.Text)
                                       + " " + Convert.ToString(this.txtNombres.Text);
            }
            else if (rbtnPjuridica.Checked)
            {
                cNombre = Convert.ToString(this.txtRazonSocial.Text);
            }
      
            return cNombre.Trim();
        }
        public string ExtraerTipoDoc()
        {
            string cTipoDoc = this.cboTipoDocu.SelectedValue.ToString();
            return cTipoDoc.Trim();
        }

        private void btnRegNumTelf_Click(object sender, EventArgs e)
        {
            string idCli = "0";
            string cTipoDoc = ExtraerTipoDoc();
            string cDocumentoID = ExtraerDocumento();
            string cNombre = ExtraerNombre();

            if (String.IsNullOrEmpty(cDocumentoID))
            {
                MessageBox.Show("No existe un Documento de Identidad al cuál poder vincular los números de teléfono", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmRegistroNumerosTelf RegNum = new frmRegistroNumerosTelf(idCli, cDocumentoID, cNombre);
            RegNum.ShowDialog();
            String cNroPrincipal = RegNum.cNumeroPrincipal;

            ActualizarNroTelefono(cNroPrincipal);
                
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (rbtnPnatural.Checked)
                {
                    BuscarDNI();
                }
                else if (rbtnPjuridica.Checked)
                {
                    BuscarRUC();
                }
                else
                {
                    return;
                }
            }

        }
        private void BuscarDNI()
        {
            if (Convert.ToInt32(this.cboTipoDocu.SelectedValue.ToString()) == 1)
            {
                if (MessageBox.Show("¿Desea realizar una consulta a RENIEC para este número de DNI?", "Mantenimiento de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    GestionarConsultaReniec(Convert.ToString(txtNumDoc.Text.Trim()));
                    AsignarDatos();

                    MessageBox.Show("Se obtuvieron los siguientes datos: \n-Dígito verificador\n-Domicilio y Ubigeo\n-Nombres y Apellidos\n-Ubigeo de Nacimiento\n-Sexo\n-Estado Civil\n-Fecha de Nacimiento\n-Nivel de instrucción.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Se realizará una consulta a SUNAT para obtener datos.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GestionarConsultaSunat(Convert.ToString(txtNumDoc.Text.Trim()));

                }
                else
                {
                    MessageBox.Show("Porfavor continúe con el registro de Datos del Cliente.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        
        }
        private void BuscarRUC()
        {
            string tcDocIde = this.txtNumDoc.Text.Trim();
            clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();
            string cValidacion = xRetDatCli.RetDatVal(0, tcDocIde, "D", Convert.ToInt32(cboTipoDocu.SelectedValue));
            if (cValidacion == "ERROR")
            {
                if (rbtnPnatural.Checked)
                {
                    MessageBox.Show("Ya Existe un Cliente Registrado con el Número de Documento Ingresado, busquelo como cliente", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("Ya existe una Empresa Registrada con ese Número de RUC, busquelo como cliente", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarControles();
                }
            }
            else
            {
                if (Convert.ToInt32(this.cboTipoDocu.SelectedValue.ToString()) == 4)
                {
                    if (MessageBox.Show("¿Desea realizar una consulta a SUNAT para este número de RUC?", "Mantenimiento de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        GestionarConsultaSunatJur(Convert.ToString(txtNumDoc.Text.Trim()));

                    }
                    else
                    {
                        MessageBox.Show("Porfavor continúe con el registro de Datos del Cliente.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

        }
        private void GestionarConsultaSunatJur(string cDocumento)
        {
            if (cDocumento.Length != 11)
            {
                MessageBox.Show("Formato de RUC incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtSunat = Cliente.CNDevuelveSunatJur(cDocumento);

            if (dtSunat.Rows.Count > 0)
            {
                //this.cboTipClasificacion.SelectedValue = Convert.ToInt32(dtSunat.Rows[0]["idTipoClasifPersona"].ToString());

                this.dtpFecNac.Value = Convert.ToDateTime(dtSunat.Rows[0]["dINICIO"].ToString());

                RellenaUbiDir(Convert.ToInt32(dtSunat.Rows[0]["cUBIGEO"].ToString()));

                string cNomZona = Convert.ToString(dtSunat.Rows[0]["cNOMZON"].ToString());
                string cNomVia = Convert.ToString(dtSunat.Rows[0]["cNOMVIA"].ToString());
                string cNumero = Convert.ToString(dtSunat.Rows[0]["cNUMER1"].ToString());


                this.txtDireccion.Text = cNomZona + " " + cNomVia + " " + cNumero;
                this.txtRazonSocial.Text = Convert.ToString(dtSunat.Rows[0]["razon_social"].ToString());
                this.txtNombreComercial.Text = Convert.ToString(dtSunat.Rows[0]["nombre_comercial"].ToString());
                this.txtNumRuc.Text = dtSunat.Rows[0]["CNUMRUC"].ToString();

                MessageBox.Show("Se obtuvieron los siguientes datos: \n-Fecha de Inicio de Act. Eco.\n-Razón Social.\n-Nombre Comercial\n-Ubigeo de Dirección\n-Dirección", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("No existen datos, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void GestionarConsultaSunat(string cDocumento)
        {
            if (cDocumento.Length != 8)
            {
                MessageBox.Show("Formato de DNI incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtSunat = Cliente.CNDevuelveSunat(cDocumento);

            if (dtSunat.Rows.Count > 0)
            {
                  int nTipClasifi = Convert.ToInt32(dtSunat.Rows[0]["idTipoClasifPersona"].ToString());

                  if (nTipClasifi == 2)
                  {
                      MessageBox.Show("No existen datos, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  else
                  {
                      this.txtNumRuc.Text = dtSunat.Rows[0]["CNUMRUC"].ToString();
                      this.chcNegocio.Checked = true;
                      MessageBox.Show("Se obtuvieron los siguientes datos: \n-Nro de RUC", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
            }
            else
            {
                MessageBox.Show("No existen datos, porfavor continuar con el registro.", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void GestionarConsultaReniec(string cDocumento)
        {

            if (cDocumento.Length != 8)
            {
                MessageBox.Show("Formato de DNI incorrecto", "Mantenimiento de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDocumento, clsVarGlobal.User.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);

            clsReniec obj = new clsReniec(objParam, objReniec);

            objCliente = obj.GetReniec();

        }

        private DateTime ConvertirFecha(string cFecha)
        {
            int nAnio = Convert.ToInt32(cFecha.Substring(0, 4));
            int nMes = Convert.ToInt32(cFecha.Substring(4, 2));
            int nDia = Convert.ToInt32(cFecha.Substring(6, 2));
            DateTime date1 = new DateTime(nAnio, nMes, nDia, 0, 0, 0);
            return date1;
        }
        private void RellenaUbiDir(int nIdUbigeoDir)
        {
            clsCNRetDatosCliente RetdDirUbi = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetdDirUbi.RetUbiCli(nIdUbigeoDir);
            if (tbDatUbi.Rows.Count > 0)
            {
                conBusUB.cboPais.SelectedValue = tbDatUbi.Rows[4]["idUbigeo"].ToString();
                conBusUB.cboDepartamento.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                conBusUB.cboProvincia.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                conBusUB.cboDistrito.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                conBusUB.cboAnexo.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
            }
        }

        private void AsignarDatos()
        {
            /****
             * 
             * datos Generales
             * 
             * *****/
            string UbiDir = objCliente.cUbigeoDep + objCliente.cUbigeoProv + objCliente.cUbigeoDist;
            string UbiNac = objCliente.cUbigeoDepNac + objCliente.cUbigeoProvNac + objCliente.cUbigeoDistNac;

            DataTable dtCodigosCore = Cliente.CNDevuelveCodCore(objCliente.cGradoInstr.Trim(), objCliente.cSexo.Trim(),
                                                                objCliente.cEstadoCivil.Trim(), objCliente.cPrefiUrba.Trim(),
                                                                objCliente.cPrefijoDireccion.Trim(), UbiDir, UbiNac);
                        
            //this.txtCBDigVerificador.Text = objCliente.cDigitoVerif.Trim();
            
            //Direccion
            RellenaUbiDir(Convert.ToInt32(dtCodigosCore.Rows[0]["ubiDirCore"].ToString()));

            this.txtDireccion.Text = objCliente.cUrbanizacion.Trim() + " " + objCliente.cEtapa.Trim() + " " + objCliente.cManzana.Trim() + " " + objCliente.cLote.Trim() + " " + objCliente.cDireccion.Trim() + " " + objCliente.cNumDireccion.Trim();

            /**
             * Personal Natural
             * ***/
            this.txtApePaterno.Text = objCliente.cApellidoPater.Trim();
            this.txtApeMaterno.Text = objCliente.cApellidoMater.Trim();
            this.txtApeCasada.Text = objCliente.cApellidoCasada.Trim();
            this.txtNombres.Text = objCliente.cNombres.Trim();

            this.dtpFecNac.Value = ConvertirFecha(objCliente.cFechaNac.Trim());
            this.cboCargo.SelectedValue = 36;
        }

        private void btnMiniBusqProf_Click(object sender, EventArgs e)
        {
            frmListaDatosCompletar frmProfesiones = new frmListaDatosCompletar(1);
            frmProfesiones.ShowDialog();
            int idProfesion = frmProfesiones.idDato;
            idProfe = idProfesion;
            this.cboOcupacion.SelectedValue = idProfe;
        }

        private void btnMiniBusqCargo_Click(object sender, EventArgs e)
        {
            frmListaDatosCompletar frmCargos = new frmListaDatosCompletar(2);
            frmCargos.ShowDialog();
            int idCargo = frmCargos.idDato;
            idCarg = idCargo;
            this.cboCargo.SelectedValue = idCarg;
            //MessageBox.Show(Convert.ToString(idCargo));
        }





    }
}
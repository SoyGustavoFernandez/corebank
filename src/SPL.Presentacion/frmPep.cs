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
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmPep : frmBase
    {
        private clsListaFamiliar listaFamilia   = new clsListaFamiliar();    
        clsCNPep personaPep     = new clsCNPep();
        private clsPep pesPep   = new clsPep();
        private bool modoEdicion = false;
        frmRegistroFamiliar regFam = new frmRegistroFamiliar();

        DataTable dtNuevosFamiliares        = new DataTable("dtNuevosFamiliares");
        DataTable dtFamiliaresEliminados    = new DataTable("dtFamiliaresEliminados");

        public int idEstadoRegistro = 0;//Estado Registro PEP 0: Normal, 1:Pendiente, 2:Finalizado

        public frmPep()
        {
            InitializeComponent();
            cargarTipoDocumento();
        }

        /*
         * Se usará cuando el formulario se llame desde otro Formulario (precargar éste formlario) 
         * 
         */
        public frmPep(int idTipoDoc, string nNumDoc)
        {
            InitializeComponent();
            cargarTipoDocumento();
            cargarPep(idTipoDoc, nNumDoc);
            idEstadoRegistro = 1;
        }
        
        private void cargarTipoDocumento()
        {
            cboTipDocumento1.CargarDocumentosSplaftPep();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            frmRegistroFamiliar regFam = new frmRegistroFamiliar();
            regFam.ShowDialog();
            if (regFam.agregar)
            {
                clsFamiliar pNuevoFam=new clsFamiliar();
                pNuevoFam = regFam.DevolverFamiliar();

                listaFamilia.Add(pNuevoFam);

                AgrearListaNuevosFamiliares(pNuevoFam);

                dtgFamiliares.DataSource = null;
                dtgFamiliares.DataSource = listaFamilia.ToList();
                dtgFamiliares.Refresh();
            }
        }

        private void AgrearListaNuevosFamiliares(clsFamiliar pNuevoFam)
        {
            DataRow fila = dtNuevosFamiliares.NewRow();
            fila["idFam"]       = 0;
            fila["cNombres"]    = pNuevoFam.cNombres;
            fila["cApePaterno"] = pNuevoFam.cApePaterno;
            fila["cApeMaterno"] = pNuevoFam.cApeMaterno;
            fila["cTipoDoc"]    = pNuevoFam.cTipoDoc;
            fila["idTipoDoc"]   = pNuevoFam.idTipoDoc;
            fila["nNumDoc"]     = pNuevoFam.nNumDoc;
            fila["nIdVinculo"]  = pNuevoFam.nIdVinculo;
            fila["cDescripcion"] = pNuevoFam.cDescripcion;
            fila["cDireccion"] = pNuevoFam.cDireccion;
            dtNuevosFamiliares.Rows.Add(fila); 
        }

        private void AgrearListaFamiliaresEliminados(int idFam)
        {
            DataRow fila    = dtFamiliaresEliminados.NewRow();
            fila["idFam"]   = idFam;
            dtFamiliaresEliminados.Rows.Add(fila); 
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Quitar?","Quitar Familiar",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                if (dtgFamiliares.CurrentRow != null)
                {
                    AgrearListaFamiliaresEliminados(Convert.ToInt32(dtgFamiliares.Rows[dtgFamiliares.CurrentRow.Index].Cells["idFam"].Value));

                    var itemselec = (clsFamiliar)dtgFamiliares.CurrentRow.DataBoundItem;
                    listaFamilia.Remove(itemselec);
                    dtgFamiliares.DataSource = null;
                    dtgFamiliares.DataSource = listaFamilia.ToList();
                    dtgFamiliares.Refresh();
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable newDt=personaPep.buscarDatosClientes(Convert.ToInt32(txtDocumento.Text));
            int PidCli =0;
            if (newDt.Rows.Count>0)
            {
               PidCli = Convert.ToInt32(newDt.Rows[0].ItemArray[1].ToString());
            }
            if (modoEdicion)
            {
                if (CamposValidos() == false) return;               

                clsPep perpep = new clsPep();
                perpep.idPep        = pesPep.idPep;
                perpep.cNombres     = txtNombres.Text;
                perpep.cApePaterno  = txtPaterno.Text;
                perpep.cApeMaterno  = txtMaterno.Text;
                perpep.dFechaNac    = dtFecNac.Value.Date;
                perpep.nDocumento   = txtDocumento.Text;
                perpep.cInstitucion = txtInstitucion.Text;
                perpep.cCargo       = txtCargo.Text;
                perpep.dFecIni      = Convert.ToDateTime(dtFechaIni.Text).Date;
                perpep.dFecFin      = Convert.ToDateTime(dtFechaFin.Text).Date;
                perpep.familiares   = listaFamilia;
                perpep.cObservaciones = txtObservaciones.Text;
                perpep.cEmpresa     = txtPorcentaje.Text;
                perpep.bEstadoPercent = chConfirm.Checked;
                perpep.idcli        = PidCli;
                perpep.idTipoDoc    = Convert.ToInt32(cboTipDocumento1.SelectedValue);

                DataSet dsNuevosFamiliares  = new DataSet("dsNuevosFamiliares");
                dsNuevosFamiliares.Tables.Add(dtNuevosFamiliares);
                String XmlNuevosFamiliares  = dsNuevosFamiliares.GetXml();
                XmlNuevosFamiliares         = clsCNFormatoXML.EncodingXML(XmlNuevosFamiliares);

                DataSet dsFamiliaresEliminados  = new DataSet("dsFamiliaresEliminados");
                dsFamiliaresEliminados.Tables.Add(dtFamiliaresEliminados);
                String XmlFamiliaresEliminados  = dsFamiliaresEliminados.GetXml();
                XmlFamiliaresEliminados         = clsCNFormatoXML.EncodingXML(XmlFamiliaresEliminados);

                clsCNPep newpep     = new clsCNPep();
                DataTable dtRpta = newpep.ActualizarPep(perpep, XmlNuevosFamiliares, XmlFamiliaresEliminados, idEstadoRegistro, clsVarGlobal.User.idUsuario, clsVarGlobal.User.idAgeCol);

                if (dtRpta.Rows.Count==0 || Convert.ToInt32(dtRpta.Rows[0][0]) == -1)
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar los datos", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                }
                else
                {
                    MessageBox.Show("Los datos se han actualizado correctamente", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }


                dsFamiliaresEliminados.Tables.Clear();
                dsNuevosFamiliares.Tables.Clear();

                dtNuevosFamiliares.Clear();
                dtFamiliaresEliminados.Clear();
                
                EstadoControles(false);
                cargarPep(Convert.ToInt32(cboTipDocumento1.SelectedValue), txtDocumento.Text);
                ControlBotones(EventoFormulario.GRABAR);
                
            }
            else
            {
                if (CamposValidos() == false) return;

                clsPep perpep       = new clsPep();
                perpep.cNombres     = txtNombres.Text;
                perpep.cApePaterno  = txtPaterno.Text;
                perpep.cApeMaterno  = txtMaterno.Text;
                perpep.dFechaNac    = dtFecNac.Value.Date;
                perpep.nDocumento   = txtDocumento.Text;
                perpep.cInstitucion = txtInstitucion.Text;
                perpep.cCargo       = txtCargo.Text;
                perpep.dFecIni      = dtFechaIni.Value.Date;
                perpep.dFecFin      = dtFechaFin.Value.Date;
                perpep.familiares   = listaFamilia;
                perpep.cObservaciones = txtObservaciones.Text;
                perpep.cEmpresa     = txtPorcentaje.Text;
                perpep.bEstadoPercent = chConfirm.Checked;
                perpep.bEstadoAprob = false;
                perpep.idcli        = PidCli;
                perpep.idTipoDoc    = Convert.ToInt32(cboTipDocumento1.SelectedValue);

                clsCNPep newpep = new clsCNPep();
                newpep.GuardarPep(perpep, idEstadoRegistro, clsVarGlobal.User.idUsuario, clsVarGlobal.User.idAgeCol);
                
                MessageBox.Show("Los datos se ha guardado correctamente", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pesPep = null;//Limpiar los datos de la clase

                if (dtNuevosFamiliares.Rows.Count>0)
                {
                    dtNuevosFamiliares.Clear();
                }
                if (dtFamiliaresEliminados.Rows.Count>0)
                {
                    dtFamiliaresEliminados.Clear();
                }                

                EstadoControles(false);
                cargarPep(Convert.ToInt32(cboTipDocumento1.SelectedValue), txtDocumento.Text);
                ControlBotones(EventoFormulario.GRABAR);
                
            }
        }

        private void EstadoControles(bool estado)
        {
            txtNombres.Enabled      = estado;
            txtPaterno.Enabled      = estado;
            txtMaterno.Enabled      = estado;
            dtFechaFin.Enabled      = estado;
            dtFechaIni.Enabled      = estado;
            dtFecNac.Enabled        = estado;
            txtObservaciones.Enabled= estado;
            dtgFamiliares.Enabled   = estado;
            txtCargo.Enabled        = estado;
            txtInstitucion.Enabled  = estado;
            chConfirm.Enabled       = estado;
            txtPorcentaje.Enabled   = estado;
            btnAgregar1.Enabled = estado;
            btnQuitar1.Enabled = estado;
            //txtDocumento.Enabled = estado;
        }
        private void LimpiarCotrol()
        {
            txtNombres.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            dtFechaFin.Value = clsVarGlobal.dFecSystem;
            dtFechaIni.Value = clsVarGlobal.dFecSystem;
            dtFecNac.Value = clsVarGlobal.dFecSystem;
            txtObservaciones.Clear();
            dtgFamiliares.DataSource=null;
            listaFamilia = new clsListaFamiliar();
            txtCargo.Clear();
            txtInstitucion.Clear();
            chConfirm.Checked = false;
            txtPorcentaje.Clear();

            regFam = new frmRegistroFamiliar();
        }
        private void cargarPep(int idTipoDoc, string nNumDoc)
        {
            pesPep = personaPep.BuscarPersonaPep(idTipoDoc, nNumDoc,0);
            if (pesPep == null)
            {
                MessageBox.Show("La persona no existe en la lista PEP.", "Buscar PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCotrol();
                EstadoControles(false);
                ControlBotones(EventoFormulario.CANCELAR);
            }
            else
            {
                //MessageBox.Show("La persona ya ha sido registrada en la lista Pep", "Buscar PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                cboTipDocumento1.SelectedValue = pesPep.idTipoDoc;
                txtNombres.Text = pesPep.cNombres.ToString().ToUpper();
                txtPaterno.Text = pesPep.cApePaterno.ToString().ToUpper();
                txtMaterno.Text = pesPep.cApeMaterno.ToString().ToUpper();
                txtDocumento.Text = Convert.ToString(pesPep.nDocumento);
                dtFecNac.Value = pesPep.dFechaNac;
                
                txtInstitucion.Text = pesPep.cInstitucion.ToString().ToUpper();
                txtCargo.Text = pesPep.cCargo.ToString().ToUpper();

                dtFechaIni.Value = pesPep.dFecIni;
                dtFechaFin.Value = pesPep.dFecFin;
                
                txtPorcentaje.Text = pesPep.cEmpresa.ToString().ToUpper();
                chConfirm.Checked = Convert.ToBoolean(pesPep.bEstadoPercent);
                txtObservaciones.Text = pesPep.cObservaciones;
                listaFamilia = pesPep.familiares;
                dtgFamiliares.DataSource = listaFamilia.ToList();
                EstadoControles(false);


                string cEstado = pesPep.cEstado.Split(' ')[0];
                switch (cEstado)
                {
                    case "Vigente":
                        lblEstado.ForeColor = Color.Green;
                        break;
                    case "Vencido":
                        lblEstado.ForeColor = Color.Red;
                        break;
                }

                lblEstado.Text = pesPep.cEstado;
                txtDocumento.Enabled = false;
                cboTipDocumento1.Enabled = false;
                lblEstado.Enabled       = false;
                lblBase14.Enabled       = false;
                ControlBotones(EventoFormulario.INICIO);

            } 
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
        }

        private void frmPep_Load(object sender, EventArgs e)
        {
            //=============== Cargar estructura de Datatable para familiares que se añadiran/eliminarán ============>
            dtNuevosFamiliares.Columns.Add("idFam", typeof(int));
            //dtNuevosFamiliares.Columns.Add("idPep", typeof(int));
            dtNuevosFamiliares.Columns.Add("cNombres", typeof(string));
            dtNuevosFamiliares.Columns.Add("cTipoDoc", typeof(string));
            dtNuevosFamiliares.Columns.Add("idTipoDoc", typeof(int));
            dtNuevosFamiliares.Columns.Add("cApePaterno", typeof(string));
            dtNuevosFamiliares.Columns.Add("cApeMaterno", typeof(string));
            dtNuevosFamiliares.Columns.Add("nNumDoc", typeof(string));
            dtNuevosFamiliares.Columns.Add("nIdVinculo", typeof(int));
            dtNuevosFamiliares.Columns.Add("cDescripcion", typeof(string));
            dtNuevosFamiliares.Columns.Add("cDireccion", typeof(string));

            dtFamiliaresEliminados.Columns.Add("idFam", typeof(int));
            //======================================================================================================>

            if (idEstadoRegistro == 0)//el ingreso a este formulario se hizo de forma directa y no desde otro foprmulario
            {
                EstadoControles(false);
                ControlBotones(EventoFormulario.CANCELAR);
            }
            else//éste formulario fué precargado, entonces no permitir la edición del número de documento. Y mostrarlo para que actualice los datos faltantes.
            {
                txtDocumento.Enabled = false;
                btnEditar.PerformClick();
                txtInstitucion.Focus();
                ControlBotones(EventoFormulario.EDITAR);
            }
            // if (!string.IsNullOrEmpty(txtDocumento.Text))
            // {
            //     ControlBotones(EventoFormulario.CANCELAR);
            // }
        }

        public void ControlBotones(EventoFormulario EventoFrm)
        {
            switch (EventoFrm)
            { 
                case EventoFormulario.INICIO:
                    btnImprimir1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSalir1.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    break;
                case EventoFormulario.EDITAR:
                    btnImprimir1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnSalir1.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    break;
                case EventoFormulario.IMPRIMIR:
                    btnImprimir1.Enabled = true;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnSalir1.Enabled = true;
                    btnBusqueda1.Enabled = false;
                    break;
                case EventoFormulario.GRABAR:
                    btnImprimir1.Enabled = true;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSalir1.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    break;
                case EventoFormulario.NUEVO:
                    btnImprimir1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnSalir1.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    break;
                case EventoFormulario.CANCELAR:
                    btnImprimir1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSalir1.Enabled = true;
                    btnBusqueda1.Enabled = true;
                    break;
            }
        }

        private Boolean CamposValidos()
        {
            if (string.IsNullOrEmpty(txtPaterno.Text))
            {
                MessageBox.Show("Ingrese el Apellido Paterno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPaterno.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaterno.Text))
            {
                MessageBox.Show("Ingrese el Apellido Materno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMaterno.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                MessageBox.Show("Ingrese el(los) nombre(s)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombres.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtInstitucion.Text))
            {
                MessageBox.Show("Ingrese el nombre de la Institución", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Ingrese el cargo que ocupó u ocupa en la Institución", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtInstitucion.Focus();
                return false;
            }
            if (chConfirm.Checked)
            {
                if (string.IsNullOrEmpty(txtPorcentaje.Text))
                {
                    MessageBox.Show("Ingrese el nombre de la empresa en la que tiene acciones.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (dtFechaIni.Value >= dtFechaFin.Value)
            {
                MessageBox.Show("la FECHA INICIO no puede ser >= que la FECHA FIN", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFechaIni.Focus();
                return false;
            }
            if (dtgFamiliares.RowCount < 1)
            {
                MessageBox.Show("Debe ingresar por lo menos 1 familiar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            } 
            return true;
        }
  
        private void chConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chConfirm.Checked)
            {
                txtPorcentaje.Enabled = true;
            }
            else
            {
                txtPorcentaje.Enabled = false;
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            frmInsertarBaseNegativa baseNega = new frmInsertarBaseNegativa();
            baseNega.Show();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim().Length < 8)
            {
                MessageBox.Show("Nro de Documento debe tener 8 digitos", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCotrol();
                return;
            }
            cargarPep(Convert.ToInt32(cboTipDocumento1.SelectedValue), txtDocumento.Text.Trim());
            ControlBotones(EventoFormulario.INICIO);
        }        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDocumento.Text.Trim()) || txtDocumento.Text.Trim().Length != 8)
            {
                MessageBox.Show("Ingrese Nro de Documento Correcto", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            modoEdicion = true;
            EstadoControles(true);

            if (chConfirm.Checked)
                txtPorcentaje.Enabled = true;
            else
                txtPorcentaje.Enabled = false;

            txtDocumento.Enabled    = false;
            lblEstado.Enabled = true;
            lblBase14.Enabled = true;
            ControlBotones(EventoFormulario.EDITAR);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim().Length<8 && Convert.ToInt32(cboTipDocumento1.SelectedValue) == 1)
            {
                MessageBox.Show("Para crear un nuevo registro PEP debe ingresar un Nro de Documento de 8 digitos", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pesPep = personaPep.BuscarPersonaPep(Convert.ToInt32(cboTipDocumento1.SelectedValue), txtDocumento.Text, 0);
            if (pesPep == null)
            {
                modoEdicion = false;
                EstadoControles(true);
                LimpiarCotrol();
                txtDocumento.Enabled = false;
                txtPaterno.Focus();
                txtPorcentaje.Enabled = false;
                cboTipDocumento1.Enabled = false;
                ControlBotones(EventoFormulario.NUEVO);
            }
            else
            {
                MessageBox.Show("La persona aparece en la lista PEP, A continuación se cargarán sus datos", "Buscar PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                txtNombres.Text = pesPep.cNombres.ToString().ToUpper();
                txtPaterno.Text = pesPep.cApePaterno.ToString().ToUpper();
                txtMaterno.Text = pesPep.cApeMaterno.ToString().ToUpper();
                txtDocumento.Text = Convert.ToString(pesPep.nDocumento);
                dtFecNac.Value = pesPep.dFechaNac;
                cboTipDocumento1.SelectedValue = pesPep.idTipoDoc;

                txtInstitucion.Text = pesPep.cInstitucion.ToString().ToUpper();
                txtCargo.Text = pesPep.cCargo.ToString().ToUpper();

                dtFechaIni.Value = pesPep.dFecIni;
                dtFechaFin.Value = pesPep.dFecFin;

                txtPorcentaje.Text = pesPep.cEmpresa.ToString().ToUpper();
                chConfirm.Checked = Convert.ToBoolean(pesPep.bEstadoPercent);
                txtObservaciones.Text = pesPep.cObservaciones;
                listaFamilia = pesPep.familiares;
                dtgFamiliares.DataSource = listaFamilia.ToList();
                EstadoControles(false);
                txtPorcentaje.Enabled = false;

                ControlBotones(EventoFormulario.INICIO);
            }         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCotrol();
            EstadoControles(false);
            txtPorcentaje.Enabled = false;
            lblEstado.Enabled = false;
            lblBase14.Enabled = false;
            txtDocumento.Text       = "";
            cboTipDocumento1.SelectedValue = 1;
            cboTipDocumento1.Enabled = true;
            txtDocumento.Enabled    = true;
            txtDocumento.Focus();
            lblEstado.Text = "";

            ControlBotones(EventoFormulario.CANCELAR);
        }
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean lBol = true;
          if (e.KeyChar==(char)Keys.Return)
            {
                if (cboTipDocumento1.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el tipo de documento", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lBol = false;
                }
                else if (Convert.ToInt32(cboTipDocumento1.SelectedValue) == 1)
                {
                    if (txtDocumento.Text.Length < 8)
                    {
                        MessageBox.Show("Nro de DNI debe tener 8 digitos", "Valida Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lBol = false;
                    }
                }

                if (lBol)
                {
                    cargarPep(Convert.ToInt32(cboTipDocumento1.SelectedValue), txtDocumento.Text);                    
                }
                    
            }
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
            txtObservaciones.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            txtPorcentaje.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            txtCargo.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtInstitucion_TextChanged(object sender, EventArgs e)
        {
            txtInstitucion.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtPaterno_TextChanged(object sender, EventArgs e)
        {
            txtPaterno.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            txtNombres.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtMaterno_TextChanged(object sender, EventArgs e)
        {
            txtMaterno.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Length == 8)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea Eliminar a ésta persona de la lista PEP?", "Eliminar de lista PEP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable dtRpta = new clsCNPep().EliminarPesonaListaPEP(pesPep.idPep);
                    if (Convert.ToInt32(dtRpta.Rows[0][0]) == -1)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar de la lista PEP", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Se ha eliminado correctamente de la lista PEP", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    btnCancelar.PerformClick();
                }
            }
        }

        private void btnImprimir1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pesPep.idPep.ToString()))
            {
                MessageBox.Show("No se ha encontrado a un cliente pep", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int idPep = Convert.ToInt32(pesPep.idPep);
            String AgenEmision = clsVarApl.dicVarGen["cNomAge"];
            DataTable dtSource = personaPep.CNImprimirFichaPEP(idPep, clsVarGlobal.dFecSystem);
            if (dtSource.Rows.Count == 0)
            {
                MessageBox.Show("Antes de imprimir la ficha PEP, debe registrar al PEP como cliente", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ControlBotones(EventoFormulario.IMPRIMIR);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsFichaPEP", dtSource));

            string reportpath = "rptFichaCliPEP.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            ControlBotones(EventoFormulario.IMPRIMIR);
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

        private void frmPep_Shown(object sender, EventArgs e)
        {
            if (idEstadoRegistro == 0)//el ingreso a este formulario se hizo de forma directa y no desde otro foprmulario
            {
                EstadoControles(false);
                ControlBotones(EventoFormulario.CANCELAR);
            }
            else//éste formulario fué precargado, entonces no permitir la edición del número de documento. Y mostrarlo para que actualice los datos faltantes.
            {
                txtDocumento.Enabled = false;
                btnEditar.PerformClick();
                txtInstitucion.Focus();
                ControlBotones(EventoFormulario.EDITAR);
            }
        }
    }
}

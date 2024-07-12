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
using GEN.CapaNegocio;
using SPL.CapaNegocio;
using EntityLayer;

namespace SPL.Presentacion
{
    public partial class frmAprobarPep : frmBase
    {
        private int nIdPep=0;
        private clsListaFamiliar listaFamilia = new clsListaFamiliar();  
        clsCNPep personaPep = new clsCNPep();
        private clsPep pesPep = new clsPep();

        DataTable dtNuevosFamiliares = new DataTable("dtNuevosFamiliares");

        public frmAprobarPep()
        {
            InitializeComponent();
            cboTipDocumento1.CargarDocumentosSplaftPep();
        }

        private void frmAprobarPep_Load(object sender, EventArgs e)
        {
            EstadoControles(false);
            txtDocumento.Enabled = false;
        }

        private void btnBusSolicitud1_Click(object sender, EventArgs e)
        {
            txtSustento.Enabled = false;
            btnAprobar.Enabled = false;
            btnDenegar.Enabled = false;
            LimpiarCotrol();
            frmBuscarAprPep frmBusSolPep = new frmBuscarAprPep();
            frmBusSolPep.ShowDialog();
            nIdPep = frmBusSolPep.pidPep;
            if (nIdPep > 0)
            {
                cargarPep(frmBusSolPep.idTipoDocumento, frmBusSolPep.pcNroDocumento);
            }
        }

        private void cargarPep(int idTipoDoc, string nNumDoc)
        {           
            pesPep = personaPep.BuscarPersonaPep(idTipoDoc, nNumDoc, 0);
            if (pesPep == null)
            {
                MessageBox.Show("La Persona no existe en la lista PEP.", "Buscar PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
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
                dtgFamiliares.DataSource = listaFamilia;
                FormatoGrid();
                txtSustento.Enabled = true;
                btnAprobar.Enabled = true;
                btnDenegar.Enabled = true;
                txtSustento.Focus();
            }
        }

        private void FormatoGrid()
        {
            this.dtgFamiliares.Columns["idFam"].Visible = false;
            this.dtgFamiliares.Columns["nidVinculo"].Visible = false;
            this.dtgFamiliares.Columns["idTipoDoc"].Visible = false;
            
            this.dtgFamiliares.Columns["cNombres"].HeaderText = "Nombres";
            this.dtgFamiliares.Columns["cNombres"].Width = 120;
            this.dtgFamiliares.Columns["cApePaterno"].HeaderText = "Apellido Paterno";
            this.dtgFamiliares.Columns["cApePaterno"].Width = 120;
            this.dtgFamiliares.Columns["cApeMaterno"].HeaderText = "Apellido Materno";
            this.dtgFamiliares.Columns["cApeMaterno"].Width = 120;
            this.dtgFamiliares.Columns["idTipoDoc"].HeaderText = "Tipo Documento";
            this.dtgFamiliares.Columns["nNumDoc"].HeaderText = "Nro Documento";
            this.dtgFamiliares.Columns["nNumDoc"].Width = 120;
            this.dtgFamiliares.Columns["cDescripcion"].HeaderText = "Tipo Familiar";
            this.dtgFamiliares.Columns["cDescripcion"].Width = 120;
        }


        private void EstadoControles(bool estado)
        {
            txtNombres.Enabled = estado;
            txtPaterno.Enabled = estado;
            txtMaterno.Enabled = estado;
            dtFechaFin.Enabled = estado;
            dtFechaIni.Enabled = estado;
            dtFecNac.Enabled = estado;
            txtObservaciones.Enabled = estado;
            dtgFamiliares.Enabled = estado;
            txtCargo.Enabled = estado;
            txtInstitucion.Enabled = estado;
            chConfirm.Enabled = estado;
            txtPorcentaje.Enabled = estado;
        }
        private void LimpiarCotrol()
        {
            txtDocumento.Clear();
            txtNombres.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            dtFechaFin.Value = clsVarGlobal.dFecSystem;
            dtFechaIni.Value = clsVarGlobal.dFecSystem;
            dtFecNac.Value = clsVarGlobal.dFecSystem;
            txtObservaciones.Clear();
            dtgFamiliares.DataSource = null;
            listaFamilia = new clsListaFamiliar();
            txtCargo.Clear();
            txtInstitucion.Clear();
            txtSustento.Clear();
            chConfirm.Checked = false;
            txtPorcentaje.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCotrol();
            nIdPep = 0;
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            RegistraOperacion(true);
        }

        private void RegistraOperacion(bool lIsApr)
        {
            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MessageBox.Show("Debe Ingresar el Sustento de la Aprobación o Rechazo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSustento.Focus();
                return;
            }

            clsCNPep clsPep = new clsCNPep();
            DataTable dtActApr = clsPep.CNActualizarAprPep(nIdPep, lIsApr, txtSustento.Text, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtActApr.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show("La Operación se Registro Correctamente", "Aprobación de PEPs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSustento.Enabled = false;
                btnAprobar.Enabled = false;
                btnDenegar.Enabled = false;
                btnBusSolicitud1.Focus();
            }
            else
            {
                MessageBox.Show("Error en el Registro de la Aprobación/Rechazo de PEP", "Aprobación de Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            RegistraOperacion(false);
        }

    }
}

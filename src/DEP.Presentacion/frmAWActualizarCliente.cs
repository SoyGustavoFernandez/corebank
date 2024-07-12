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
using CLI.CapaNegocio;
using EntityLayer;
using System.Text.RegularExpressions;
using GEN.Funciones;
using DEP.CapaNegocio.AhorroWeb;

namespace DEP.Presentacion
{
    public partial class frmAWActualizarCliente : frmBase
    {
        #region Variables Privadas
        private clsCNRetDatosCliente datosCliente = new clsCNRetDatosCliente();
        private clsCNDirecCli datosDireccion = new clsCNDirecCli();
        private clsAWCliente objAWCliente;
        private clsAWClienteNatural objAWClienteNatural;
        private clsAWDireccion objAWDireccion;
        private clsCNAWPostApertura objCNAWPostApertura = new clsCNAWPostApertura();

        private int idCli;
        private DateTime dFecIniActEcoDefault = clsVarGlobal.dFecSystem.AddDays(1);
        #endregion

        #region Variables Públicas
        public bool lCancelado = false;
        #endregion

        #region Constructores
        public frmAWActualizarCliente(int idCli)
        {
            InitializeComponent();

            this.idCli = idCli;            
            DataTable dtCliente = datosCliente.ListarDatosCli(this.idCli, "N");
            objAWCliente = dtCliente.Rows[0].ToObject<clsAWCliente>();
            objAWClienteNatural = dtCliente.Rows[0].ToObject<clsAWClienteNatural>();
            objAWDireccion = objCNAWPostApertura.obtenerDireccionPrincipal(this.idCli);
            if (objAWDireccion == null)
            {
                MessageBox.Show("El cliente no cuenta con una dirección principal", "Validar Datos");
                this.lCancelado = true;
                this.Close();
            }

            cboTipClasificacion.Enabled = true;
            txtCBDocAdi.Enabled = true;

            cboSector1.Enabled = true;
            cboTipVivienda.Enabled = true;
            cboTipoConst1.Enabled = true;
            txtResidencia.Enabled = true;

            txtNroHijos.Enabled = true;
            txtNroPerDep.Enabled = true;            
            dtpFecIniActEcoNat.Enabled = true;

            btnGrabar.Enabled = true;
        }
        #endregion

        #region Métodos Privados
        private void frmAWActualizarCliente_Load(object sender, EventArgs e)
        {
            DataTable dtCargos = (DataTable)cboClienteCargo1.DataSource;
            dtCargos.DefaultView.RowFilter = "lPep = false";
            this.cboClienteCargo1.DataSource = dtCargos;
            this.cboTipClasificacion.CargarClasificacion(1);
            this.cboTipClasificacion.SelectedValue = objAWCliente.idTipoPerClasifica > 0 ? objAWCliente.idTipoPerClasifica : -1;
            clsCNProfesion listaProf = new clsCNProfesion();
            DataTable dtProfesion = listaProf.ListarProfesion();
            this.cboProfesion.DataSource = dtProfesion;
            cboProfesion.ValueMember = dtProfesion.Columns[0].ToString();
            cboProfesion.DisplayMember = dtProfesion.Columns[1].ToString();

            this.txtCBDocAdi.Text = string.IsNullOrEmpty(objAWCliente.cDocumentoAdicional) ? "" : objAWCliente.cDocumentoAdicional;

            this.cboSector1.SelectedValue = objAWDireccion.idSector > 0 ? objAWDireccion.idSector : -1;
            this.cboTipVivienda.SelectedValue = objAWDireccion.idTipoVivienda > 0 ? objAWDireccion.idTipoVivienda : -1;
            this.cboTipoConst1.SelectedValue = objAWDireccion.idTipoConstruccion > 0 ? objAWDireccion.idTipoConstruccion : -1;
            this.txtResidencia.Text = objAWDireccion.nAñoReside.ToString();
            
            this.txtNroHijos.Text = objAWClienteNatural.nNumHijos.ToString();
            this.txtNroPerDep.Text = objAWClienteNatural.nNumPerDepend.ToString();

            this.cboProfesion.SelectedValue = objAWClienteNatural.idProfesion > 0 ? objAWClienteNatural.idProfesion : -1;
            this.cboClienteCargo1.SelectedValue = objAWClienteNatural.idCargo > 0 ? objAWClienteNatural.idCargo : -1;

            this.cboActividadInternaNat.SelectedValue = objAWCliente.idActivEcoInterna > 0 ? objAWCliente.idActivEcoInterna : -1;
            DateTime dTmp = objAWClienteNatural.dFechaIniActEco == null ? Convert.ToDateTime("1753-1-1") : (DateTime)objAWClienteNatural.dFechaIniActEco;
            if (dTmp.ToShortDateString() == Convert.ToDateTime("1753-1-1").ToShortDateString())
            {
                this.dtpFecIniActEcoNat.Value = dFecIniActEcoDefault;
                this.dtpFecIniActEcoNat.CustomFormat = " ";
            }
            else
            {
                this.dtpFecIniActEcoNat.CustomFormat = "dd/MM/yyyy";
                this.dtpFecIniActEcoNat.Value = Convert.ToDateTime(dTmp.ToString());
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.cboTipClasificacion.SelectedIndex == -1)
            {                
                MessageBox.Show("Debe registrar la Clasificación del Cliente", "Validar Datos");
                tbcCliente.SelectedIndex = 0;
                this.cboTipClasificacion.Focus();
                return;
            }
            
            if ((int)this.cboTipClasificacion.SelectedValue == 11 && txtCBDocAdi.Text == "")
            {
                MessageBox.Show("Debe registrar el Número de RUC", "Validar Datos");
                tbcCliente.SelectedIndex = 0;
                this.txtCBDocAdi.Focus();
                return;
            }


            if (!string.IsNullOrEmpty(txtCBDocAdi.Text))
            {
                Regex valid = new Regex(@"^\d{11}?$");
                if (!valid.IsMatch(txtCBDocAdi.Text.Trim()))
                {
                    MessageBox.Show("El número de RUC debe tener 11 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 0;
                    txtCBDocAdi.Focus();
                    return;
                }
            }

            if (this.cboSector1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe registrar el Sector", "Validar Datos");
                tbcCliente.SelectedIndex = 0;
                this.cboSector1.Focus();
                return;
            }
            if (this.cboTipVivienda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe registrar el Tipo de Vivienda", "Validar Datos");
                tbcCliente.SelectedIndex = 0;
                this.cboTipVivienda.Focus();
                return;
            }
            if (this.cboTipoConst1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe registrar el Tipo de Construcción", "Validar Datos");
                tbcCliente.SelectedIndex = 0;
                this.cboTipoConst1.Focus();
                return;
            }
            if (this.cboProfesion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe registrar la Profesión u Ocupación", "Validar Datos");
                this.cboProfesion.Focus();
                return;
            }
            if (this.cboClienteCargo1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe registrar el Cargo", "Validar Datos");
                tbcCliente.SelectedIndex = 1;
                this.cboClienteCargo1.Focus();
                return;
            }

            if (dtpFecIniActEcoNat.Text == " ")
            {
                if (cboActividadInternaNat.SelectedIndex != -1)
                {
                    MessageBox.Show("Debe seleccionar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return;
                }
            }
            else
            {
                if (cboActividadInternaNat.SelectedIndex == -1)
                {
                    MessageBox.Show("No corresponde registrar La Fecha de inicio de la actividad económica", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return;
                }
                if (Convert.ToDateTime(dtpFecIniActEcoNat.Value.ToShortDateString()) > Convert.ToDateTime(clsVarGlobal.dFecSystem.ToShortDateString()))
                {
                    MessageBox.Show("La Fecha de inicio de la actividad económica no puede ser posterior a la de Hoy", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcCliente.SelectedIndex = 1;
                    dtpFecIniActEcoNat.Focus();
                    return;
                }
            }
            
            int idTipoPerClasifica = Int32.Parse(cboTipClasificacion.SelectedValue.ToString());
            int idTipoDocAdicional = txtCBDocAdi.Text != "" ? 4 : 0;
            string cDocumentoAdicional = txtCBDocAdi.Text.Trim();
            int idActivEcoInt = Int32.Parse(cboActividadInternaNat.SelectedValue.ToString());

            int idDireccion = objAWDireccion.idDireccion;
            int idSector = Int32.Parse(cboSector1.SelectedValue.ToString());
            int idTipoVivienda = Int32.Parse(cboTipVivienda.SelectedValue.ToString());
            int idTipoConstruccion = Int32.Parse(cboTipoConst1.SelectedValue.ToString());
            int nAñoReside = Int32.Parse(txtResidencia.Text.Trim());

            int nNumHijos = Int32.Parse(txtNroHijos.Text.Trim());
            int nNumPerDepend = Int32.Parse(txtNroPerDep.Text.Trim());            
            DateTime? dFecIniActEcoNat = dtpFecIniActEcoNat.Value;
            if (dtpFecIniActEcoNat.Text == " ")
            {
                dFecIniActEcoNat = null;
            }

            int idProfesion = Int32.Parse(cboProfesion.SelectedValue.ToString());
            int idCargo = Int32.Parse(cboClienteCargo1.SelectedValue.ToString());

            clsCNGuardaCliPerNat GuardaCliNat = new clsCNGuardaCliPerNat();

            try
            {
                DataTable dtIdCliente = objCNAWPostApertura.actualizarCliente(idCli, idTipoPerClasifica, idTipoDocAdicional, cDocumentoAdicional, idActivEcoInt,
                                                                                        idDireccion, idSector, idTipoVivienda, idTipoConstruccion, nAñoReside,
                                                                                        nNumHijos, nNumPerDepend, dFecIniActEcoNat, idProfesion, idCargo);
                MessageBox.Show("Datos actualizados correctamente!");
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("No se pudo actualizar los datos!" + exc.ToString());
            }              
        }

        private void dtpFecIniActEcoNat_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecIniActEcoNat.Value > clsVarGlobal.dFecSystem)
                this.dtpFecIniActEcoNat.CustomFormat = "";
            else
                this.dtpFecIniActEcoNat.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFecIniActEcoNat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.dtpFecIniActEcoNat.Value = dFecIniActEcoDefault;
                this.dtpFecIniActEcoNat.CustomFormat = " ";
            }

            e.Handled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.lCancelado = true;
            this.Close();
        }
        #endregion
    }
}

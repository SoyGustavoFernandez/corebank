using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmBandejaComiteVirtual : frmBase
    {
        public clsUsuComite objUsuComite = null;
        public bool lUsuAutBiometrico = false;

        private clsCNComiteCreditos objCNComiteCreditos = new clsCNComiteCreditos();
        private List<clsComiteVirtual> lstBandejaComiteVirtual = new List<clsComiteVirtual>();
        private clsComiteVirtual objGrabarDecisionVirtual = new clsComiteVirtual();
        private int idUsuario;
        private bool lValidaSalir = true;
        private bool lValidaUsuario = true;

        public frmBandejaComiteVirtual()
        {
            InitializeComponent();
        }
        public frmBandejaComiteVirtual(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.listarComiteVirtual(this.idUsuario);
        }

        private void listarComiteVirtual(int idUsuario)
        {
            this.lstBandejaComiteVirtual.Clear();
            this.lstBandejaComiteVirtual.AddRange(this.objCNComiteCreditos.listarBandejaComiteVirtual(idUsuario));
            this.bsBandejaComiteVirtual.DataSource = this.lstBandejaComiteVirtual;
            if (this.bsBandejaComiteVirtual.Count == 0)
            {
                this.btnRechazar1.Enabled = false;
                this.btnAceptar1.Enabled = false;
            }
            else
            {
                this.btnRechazar1.Enabled = true;
                this.btnAceptar1.Enabled = true;
            }
        }

        private void validarUsuario()
        {
            clsCNUsuComite objCNUsuComite = new clsCNUsuComite();
            this.lValidaUsuario = true;

            DataTable dtRes = objCNUsuComite.CNBuscarUsuarioExoneradoLoginComiteCred(Convert.ToString(clsVarGlobal.User.cWinUser));

            if (dtRes.Rows.Count == 0) //cliente no exonerado
            {
                string cNomCorto = "Ha sido invitado a participar en el comité " + dtgBandejaComiteVirtual.SelectedRows[0].Cells["cNomCorto"].Value.ToString().Trim() + ", ingrese su contraseña para confirmar su participación e ingresar al comité.";
                frmCredenciales frmCred = new frmCredenciales(cNomCorto, false, clsVarGlobal.User.lAutBiometricaComite, true);
                frmCred.cWinUser = Convert.ToString(clsVarGlobal.User.cWinUser);
                frmCred.ShowDialog();

                if (!frmCred.lValido)
                {
                    MessageBox.Show("No se ha ingresado las credenciales del participante, no se puede incluir al participante en el comité de créditos.", "BÚSQUEDA DE COLABORADOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lValidaSalir = false;
                    return;
                }
                lUsuAutBiometrico = frmCred.lUsuAutBiometrico;
                this.lValidaSalir = true;
                if (dtgBandejaComiteVirtual.SelectedRows.Count > 0)
                {
                    int idComiteCredSelec = (Int32)dtgBandejaComiteVirtual.SelectedRows[0].Cells["idComiteCred"].Value;
                    List<clsComiteVirtual> lstObtenerComiteVirtual = new List<clsComiteVirtual>();
                    lstObtenerComiteVirtual.Clear();
                    lstObtenerComiteVirtual.AddRange(this.objCNComiteCreditos.listarBandejaComiteVirtual(idUsuario));
                    clsComiteVirtual objComiteVirtual = new clsComiteVirtual();
                    objComiteVirtual = lstObtenerComiteVirtual.FirstOrDefault(x => x.idComiteCred == idComiteCredSelec);
                    if (objComiteVirtual == null)
                    {
                        MessageBox.Show("Ha sido retirado del comité " + dtgBandejaComiteVirtual.SelectedRows[0].Cells["cNomComite"].Value.ToString() + ".", "COMITÉ VIRTUAL", 
                                                                                                                                                            MessageBoxButtons.OK, 
                                                                                                                                                            MessageBoxIcon.Information);
                        this.lValidaUsuario = false;
                        return;
                    }
                    this.objGrabarDecisionVirtual = objCNComiteCreditos.grabarDecisionVirtual(clsVarGlobal.User.idUsuario, true, idComiteCredSelec);
                    objUsuComite = new clsUsuComite();
                    objUsuComite.idComiteCred = idComiteCredSelec;
                    objUsuComite.idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario);
                    objUsuComite.cNombre = Convert.ToString(clsVarGlobal.User.cNomUsu);
                    objUsuComite.idCargo = Convert.ToInt32(clsVarGlobal.User.idCargo);
                    objUsuComite.idTipoParticip = Convert.ToInt32(3);
                    objUsuComite.cTipoParticip = "VIRTUAL";
                    objUsuComite.lConfirmAsis = false;
                    objUsuComite.lInvitacion = lUsuAutBiometrico;
                }
                else
                {
                    objUsuComite = null;
                }
            }
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            this.listarComiteVirtual(this.idUsuario);
            this.bsBandejaComiteVirtual.ResetBindings(false);
            this.dtgBandejaComiteVirtual.Refresh();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dtgBandejaComiteVirtual.SelectedRows[0].Cells["lInvitacion"].Value) == false)
            {
                if (Convert.ToBoolean(dtgBandejaComiteVirtual.SelectedRows[0].Cells["lConfirmAsis"].Value) == true)
                {
                    this.validarUsuario();
                    if (this.lValidaUsuario == false)
                    {
                        this.listarComiteVirtual(this.idUsuario);
                        this.bsBandejaComiteVirtual.ResetBindings(false);
                        this.dtgBandejaComiteVirtual.Refresh();
                        return;
                    }

                    if (this.lValidaSalir == true)
                    {
                        this.Dispose();
                    }

                }
                else if (Convert.ToBoolean(dtgBandejaComiteVirtual.SelectedRows[0].Cells["lConfirmAsis"].Value) == false)
                {
                    MessageBox.Show("La invitación ya fue RECHAZADA.", "INVITACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                this.validarUsuario();
                if (this.lValidaUsuario == false)
                {
                    this.listarComiteVirtual(this.idUsuario);
                    this.bsBandejaComiteVirtual.ResetBindings(false);
                    this.dtgBandejaComiteVirtual.Refresh();
                    return;
                }
                if (this.lValidaSalir == true)
                {
                    string cNomComite = dtgBandejaComiteVirtual.SelectedRows[0].Cells["cNomComite"].Value.ToString();
                    MessageBox.Show("Invitación del comité " + cNomComite + " aceptado correctamente.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro que desea RECHAZAR la invitación?", "INVITACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int idComiteCred = (Int32)dtgBandejaComiteVirtual.SelectedRows[0].Cells["idComiteCred"].Value;
                List<clsComiteVirtual> lstObtenerComiteVirtual = new List<clsComiteVirtual>();
                lstObtenerComiteVirtual.Clear();
                lstObtenerComiteVirtual.AddRange(this.objCNComiteCreditos.listarBandejaComiteVirtual(idUsuario));
                clsComiteVirtual objComiteVirtual = new clsComiteVirtual();
                objComiteVirtual = lstObtenerComiteVirtual.FirstOrDefault(x => x.idComiteCred == idComiteCred);
                if (objComiteVirtual == null)
                {
                    MessageBox.Show("Ha sido retirado del comité " + dtgBandejaComiteVirtual.SelectedRows[0].Cells["cNomComite"].Value.ToString() + ".", "COMITÉ VIRTUAL",
                                                                                                                                                        MessageBoxButtons.OK,
                                                                                                                                                        MessageBoxIcon.Information);
                    this.listarComiteVirtual(this.idUsuario);
                    this.bsBandejaComiteVirtual.ResetBindings(false);
                    this.dtgBandejaComiteVirtual.Refresh();
                    return;
                }
                if (Convert.ToBoolean(dtgBandejaComiteVirtual.SelectedRows[0].Cells["lInvitacion"].Value) == true)
                {
                    int idComiteCredSelec = (Int32)dtgBandejaComiteVirtual.SelectedRows[0].Cells["idComiteCred"].Value;
                    this.objGrabarDecisionVirtual = objCNComiteCreditos.grabarDecisionVirtual(clsVarGlobal.User.idUsuario, false, idComiteCredSelec);
                    this.listarComiteVirtual(this.idUsuario);
                    this.dtgBandejaComiteVirtual.Refresh();
                }
                else
                {
                    if (Convert.ToBoolean(dtgBandejaComiteVirtual.SelectedRows[0].Cells["lConfirmAsis"].Value) == true)
                    {
                        MessageBox.Show("La invitación ya fue ACEPTADA.", "INVITACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("La invitación ya fue RECHAZADA.", "INVITACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}

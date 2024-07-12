using System;
using System.Data;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmObsAprobacion : frmBase
    {

        #region Variables Globales
        public int idOrigenObs = 0;
        //public clsObservacion objObservacion = null;
        public clsObservacionAprobador objObservacion = null;
        public bool lAceptado = false;
        private const string cTituloMsjes = "Validación de campos.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            if (objObservacion != null)
            {
                cboTipObs.SelectedValue = objObservacion.idTipObservacion;
                txtDetObservacion.Text = objObservacion.cObservacion;
                if (objObservacion.idEtapaEvalCred > 0)
                {
                    cboTipObs.LisTipObs(0, 0, (objObservacion.lEdit ? (objObservacion.lEditEstado || objObservacion.lEditObserv ? objObservacion.idEtapaEvalCred : 0) : objObservacion.idEtapaEvalCred));
                    if (objObservacion.lEdit)
                    {
                        CargarEstObserv(objObservacion.idEstado);
                        lblBase3.Text = "Cambiar estado:";
                        cboGrupoObs.Visible = false;
                        cboEstadosObs.Visible = true;
                        cboEstadosObs.Enabled = objObservacion.lEditEstado;
                        //cboEstadosObs.SelectedValue = objObservacion.idEstado;
                        if (objObservacion.lEditEstado)
                        {
                            lblBase1.Text = "Detalle referente al cambio de estado:";
                            cboTipObs.Visible = false;
                            lblBase2.Visible = false;
                            txtDetObservacion.Text = "";
                            txtDetObservacion.Location = new System.Drawing.Point(cboTipObs.Location.X, cboTipObs.Location.Y);
                            txtDetObservacion.Size = new System.Drawing.Size(406, 120);
                        }
                        else
                        {
                            cboEstadosObs.SelectedValue = objObservacion.idEstado;
                            cboTipObs.Enabled = objObservacion.lEditObserv;
                            btnAceptar.Visible = (objObservacion.lEditEstado || objObservacion.lEditObserv ? true : false );
                            txtDetObservacion.Enabled = objObservacion.lEditObserv;
                        }
                        
                        cboEstadosObs.DropDownStyle = ComboBoxStyle.DropDownList;
                        cboEstadosObs.Location = new System.Drawing.Point(cboGrupoObs.Location.X, cboGrupoObs.Location.Y);
                    }
                    else // REGISTRO DE OBSERVACIONES
                    {
                        cboGrupoObs.Visible = false;
                        lblBase3.Visible = false;
                        cboTipObs.Location = new System.Drawing.Point(cboTipObs.Location.X, cboTipObs.Location.Y - 45);
                        lblBase1.Location = new System.Drawing.Point(lblBase1.Location.X, lblBase1.Location.Y - 45);
                        lblBase2.Location = new System.Drawing.Point(lblBase2.Location.X, lblBase2.Location.Y - 40);
                        txtDetObservacion.Location = new System.Drawing.Point(txtDetObservacion.Location.X, txtDetObservacion.Location.Y - 40);
                        txtDetObservacion.Size = new System.Drawing.Size(406, 120);
                    }
                }
                else
                {
                    cboGrupoObs.CargarTodos();
                    cboGrupoObs.SelectedValue = objObservacion.idGrupoObs;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            objObservacion.lModif = (
                                        (
                                            Convert.ToInt32(this.cboEstadosObs.SelectedValue) != objObservacion.idEstado &&
                                            this.txtDetObservacion.Text != objObservacion.cObservacion
                                        ) 
                                        ||                     
                                        (
                                            (Convert.ToInt32(this.cboTipObs.SelectedValue) != objObservacion.idTipObservacion || 
                                            this.txtDetObservacion.Text != objObservacion.cObservacion) &&
                                            this.objObservacion.lEditEstado != true
                                        )
                                        ? 
                                        true : 
                                        false 
                                    );

            objObservacion.idGrupoObs = (objObservacion.idEtapaEvalCred == 0 ? Convert.ToInt32(this.cboGrupoObs.SelectedValue) : 0);
            objObservacion.idEstado = (objObservacion.idEtapaEvalCred != 0 ? Convert.ToInt32(this.cboEstadosObs.SelectedValue) : 0);
            objObservacion.idTipObservacion = Convert.ToInt32(cboTipObs.SelectedValue);
            objObservacion.cTipObservacion = cboTipObs.Text;
            objObservacion.cObservacion = txtDetObservacion.Text;
            objObservacion.cComentario = (
                                            objObservacion.lEditEstado
                                            ? 
                                            txtDetObservacion.Text
                                            :
                                            ""
                                        );
            objObservacion.idUsuReg = clsVarGlobal.User.idUsuario;
            
            //objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;

            lAceptado = true;

            this.Dispose();
        }

        private void cboGrupoObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoObs.SelectedValue != null && objObservacion.idEtapaEvalCred == 0)
            {
                DataRowView dr = cboGrupoObs.SelectedItem as DataRowView;
                int idGrupoObs = Convert.ToInt32(dr["idGrupoObs"]);
                cboTipObs.LisTipObs(idOrigenObs, idGrupoObs, 0);
            }
        }

        #endregion

        #region Metodos

        public frmObsAprobacion()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboTipObs.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDetObservacion.Text.Trim()))
            {
                MessageBox.Show("Ingrese el detalle de la observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarEstObserv(int idEstado) 
        {
            DataTable dtEstObs = new clsCNObservaciones().CNGetEstObs(idEstado);
            cboEstadosObs.ValueMember = "idEstado";
            cboEstadosObs.DisplayMember = "cEstado";
            cboEstadosObs.DataSource = dtEstObs;
        }

        private void RetirarOpcion(string cOpcion) { 
            
        }

        #endregion

    }
}

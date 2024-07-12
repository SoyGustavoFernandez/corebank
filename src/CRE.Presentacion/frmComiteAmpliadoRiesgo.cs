#region Referencias
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
using EntityLayer;
using GEN.Funciones;
#endregion

namespace CRE.Presentacion
{
    public partial class frmComiteAmpliadoRiesgo : frmBase
    {
        #region Variables Globales
        public int idSolicitud = 0;
        public int idSolInformeRiesgo = 0;
        private clsCNInformeRiesgos objCNInformeRiesgos { get; set; }
        private clsComiteAmpRiesgo objComiteAmp { get; set; }
        private BindingSource bsParticipante { get; set; }
        private List<clsUsuarioComiteAmpRsg> lstParticipante { get; set; }
        public bool lReferencia = false;
        public bool lEdicion = false;
        #endregion

        #region Constructores
        public frmComiteAmpliadoRiesgo()
        {
            InitializeComponent();
            conBusCuentaCli.cTipoBusqueda = "S";
            conBusCuentaCli.cEstado = "[0,1,13]";

        }
        #endregion

        #region Metodos
        private void CargarComponentesFormulario()
        {
            objCNInformeRiesgos = new clsCNInformeRiesgos();
            objComiteAmp = new clsComiteAmpRiesgo();
            bsParticipante = new BindingSource();
            lstParticipante = new List<clsUsuarioComiteAmpRsg>();
        }

        private void CargarDatosComite(int idSolicitudSel, int idSolInformeRiesgoSel)
        {
            objComiteAmp = objCNInformeRiesgos.CNRecuperarComiteAmpliadoRiesgo(idSolicitudSel, idSolInformeRiesgoSel);

            if (lReferencia)
            {
                conBusCuentaCli.asignarCuenta(idSolicitudSel);
            }

            lblSolInformeRiesgo.Text = idSolInformeRiesgo.ToString();

            AsignarDatosComiteAmpliado();
            HabilitarControlesForm(EstadoForm.RECUPERADO);
        }

        private void AsignarDatosComiteAmpliado()
        {
            txtNombreComite.Text = objComiteAmp.cNombreComite;
            txtMotivo.Text = objComiteAmp.cMotivoComite;

            lstParticipante = objComiteAmp.lstParticipanteComite;
            bsParticipante.DataSource = lstParticipante;
            dtgParticipantes.DataSource = bsParticipante;
            bsParticipante.ResetBindings(false);
            FormatearGridParticipantes();
            dtgParticipantes.Refresh();
        }
        private void LimpiarFormulario()
        {
            if (lReferencia)
            {
                CargarDatosComite(idSolicitud, idSolInformeRiesgo);
                HabilitarControlesForm(EstadoForm.CANCELAR);
            }
            else
            {
                conBusCuentaCli.limpiarControles();
            }
        }

        private void HabilitarControlesForm(EstadoForm eEstado)
        {
            switch (eEstado)
            {
                case EstadoForm.DEFECTO:
                case EstadoForm.RECUPERADO:
                case EstadoForm.CANCELAR:
                case EstadoForm.GRABADO:
                    grbDatosComite.Enabled  = false;
                    btnEditar.Enabled       = true;
                    btnGrabar.Enabled       = false;
                    btnCancelar.Enabled     = (lReferencia) ? false: true;
                    break;
                case EstadoForm.EDITAR:
                    grbDatosComite.Enabled  = true;
                    btnEditar.Enabled       = false;
                    btnGrabar.Enabled       = true;
                    btnCancelar.Enabled     = true;
                    break;
                default:
                    grbDatosComite.Enabled  = false;
                    btnEditar.Enabled       = false;
                    btnGrabar.Enabled       = false;
                    btnCancelar.Enabled     = false;
                    break;
            }
        }
        private void FormatearGrid()
        {
            this.dtgParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParticipantes.Margin = new System.Windows.Forms.Padding(0);
            this.dtgParticipantes.MultiSelect = false;
            this.dtgParticipantes.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantes.RowHeadersVisible = false;
            this.dtgParticipantes.ReadOnly = true;
        }

        private void FormatearGridParticipantes()
        {
            foreach (DataGridViewColumn column in this.dtgParticipantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgParticipantes.Columns["idUsuarioComite"].DisplayIndex = 0;
            this.dtgParticipantes.Columns["cNombre"].DisplayIndex = 1;
            this.dtgParticipantes.Columns["cWinUser"].DisplayIndex = 2;

            this.dtgParticipantes.Columns["idUsuarioComite"].Visible = true;
            this.dtgParticipantes.Columns["cNombre"].Visible = true;
            this.dtgParticipantes.Columns["cWinUser"].Visible = true;

            this.dtgParticipantes.Columns["idUsuarioComite"].HeaderText = "Cod.";
            this.dtgParticipantes.Columns["cNombre"].HeaderText = "Nombre";
            this.dtgParticipantes.Columns["cWinUser"].HeaderText = "Cod. Usuario";

            this.dtgParticipantes.Columns["idUsuarioComite"].FillWeight = 30;
            this.dtgParticipantes.Columns["cNombre"].FillWeight = 200;
            this.dtgParticipantes.Columns["cWinUser"].FillWeight = 75;

            this.dtgParticipantes.Columns["idUsuarioComite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buscarDatosInformeRiesgo()
        {
            int idSol = Convert.ToInt32(conBusCuentaCli.nValBusqueda);

            DataTable dtResultado = objCNInformeRiesgos.ObtenerInformeRiesgo(idSol);

            if (dtResultado.Rows.Count > 0)
            {
                idSolicitud = idSol;
                idSolInformeRiesgo = Convert.ToInt32(dtResultado.Rows[0]["idSolInfRiesgo"]);
                CargarDatosComite(idSolicitud, idSolInformeRiesgo);
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Eventos

        private void frmComiteAmpliadoRiesgo_Load(object sender, EventArgs e)
        {
            CargarComponentesFormulario();
            FormatearGrid();

            if (lReferencia)
            {
                CargarDatosComite(idSolicitud, idSolInformeRiesgo);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControlesForm(EstadoForm.EDITAR);
            txtNombreComite.Focus();
            lEdicion = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombreComite.Text))
            {
                MessageBox.Show("El nombre del Comite no debe estar vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("El motivo del Comite no debe estar cacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (objComiteAmp.lstParticipanteComite.Count < 2)
            {
                MessageBox.Show("Se debe registrar por lo menos 2 participantes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string xmlComiteAmpliadoRiesgo = String.Empty;
            objComiteAmp.lstParticipanteComite = new List<clsUsuarioComiteAmpRsg>();
            objComiteAmp.lstParticipanteComite.AddRange(lstParticipante);
            objComiteAmp.cNombreComite = txtNombreComite.Text.ToString();
            objComiteAmp.cMotivoComite = txtMotivo.Text.ToString();
            xmlComiteAmpliadoRiesgo = objComiteAmp.GetXml();
            DataTable dtResultado = objCNInformeRiesgos.CNGrabarActualizarComiteAmpliadoRiesgo(xmlComiteAmpliadoRiesgo, idSolicitud, idSolInformeRiesgo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

            if (dtResultado.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarControlesForm(EstadoForm.GRABADO);
                }
                else
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HabilitarControlesForm(EstadoForm.EDITAR);
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un error al momento del registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HabilitarControlesForm(EstadoForm.EDITAR);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (lEdicion)
            {
                CargarDatosComite(idSolicitud, idSolInformeRiesgo);
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void tsmAgrParticipantes_Click(object sender, EventArgs e)
        {
            FrmBusUsuComite frmBusCol = new FrmBusUsuComite();
            frmBusCol.lComiteVirtual = true;
            frmBusCol.ShowDialog();

            if (frmBusCol.objUsuComite == null) return;

            clsUsuComite objUser = frmBusCol.objUsuComite;
            clsUsuarioComiteAmpRsg objParticipante = new clsUsuarioComiteAmpRsg()
            {
                idUsuarioComiteAmpRsg = 0,
                idComiteAmpRiesgo = objComiteAmp.idComiteAmpRiesgo,
                idUsuarioComite = objUser.idUsuario,
                cNombre = objUser.cNombre,
                cWinUser = objUser.cWinUser,
                lVigente = true
            };

            if (this.lstParticipante.Count(x => x.idUsuarioComite == objParticipante.idUsuarioComite) > 0)
            {
                MessageBox.Show("El colaborador ya se encuentra registrado como participante.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lstParticipante.Add(objParticipante);
            bsParticipante.ResetBindings(false);
            dtgParticipantes.Refresh();

        }

        private void tsmQuiParticipantes_Click(object sender, EventArgs e)
        {
            if (this.dtgParticipantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a quitar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsUsuarioComiteAmpRsg participante = this.dtgParticipantes.SelectedRows[0].DataBoundItem as clsUsuarioComiteAmpRsg;

            this.lstParticipante.Remove((clsUsuarioComiteAmpRsg)dtgParticipantes.SelectedRows[0].DataBoundItem);

            bsParticipante.ResetBindings(false);
            dtgParticipantes.Refresh();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            buscarDatosInformeRiesgo();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            buscarDatosInformeRiesgo();
        }

        #endregion

        #region Enumeradores
        private enum EstadoForm
        {
            DEFECTO = 1,
            RECUPERADO = 2,
            EDITAR = 3,
            CANCELAR = 4,
            GRABADO = 5
        }


        #endregion

    }
}

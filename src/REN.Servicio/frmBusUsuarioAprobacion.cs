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
using EntityLayer;

namespace CLI.Servicio
{
    public partial class frmBusUsuarioAprobacion : Form
    {
        #region Variables Globales
        public List<clsUsuAprobBiometrico> lstUsuAprobBiometrico { get; set; }
        BindingSource bsColaborador { get; set; }
        public clsUsuAprobBiometrico objUsuSeleccionado { get; set; }
        public bool lUsuarioVerificado { get; set; }
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        public int idTipoOperacion { get; set; }
        #endregion

        #region Constructores
        public frmBusUsuarioAprobacion()
        {
            InitializeComponent();
            cargarComponentes();
        }

        #endregion

        #region Eventos
        private void frmBusUsuarioAprobacion_Load(object sender, EventArgs e)
        {
            
        }

        private void cboCriBusCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCriterioBusqueda;
            idCriterioBusqueda = Convert.ToInt32(cboCriBusCol.SelectedValue);
            if (idCriterioBusqueda == 1)
            {
                lblCriterioBusqueda.Text = "DNI:";
            }
            else if (idCriterioBusqueda == 2)
            {
                lblCriterioBusqueda.Text = "Ape. y Nombres:";
            }
            txtDniNom.Text = String.Empty;
            txtDniNom.Focus();
        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarColaborador();
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            buscarColaborador();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void dtgColaborador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
        }

        #endregion

        #region Metodos

        private void cargarComponentes()
        {
            objUsuSeleccionado = new clsUsuAprobBiometrico();
            lstUsuAprobBiometrico = new List<clsUsuAprobBiometrico>();
            lUsuarioVerificado = false;
            cargarDatosCriterioBusqueda(false);
            cargarDataGridColaborador();
            dtgColaborador.AutoGenerateColumns = false;
            lblCriterioBusqueda.Text = "Ape. y Nombres:";
            txtDniNom.Focus();
            txtDniNom.Select();
        }

        private void cargarDatosCriterioBusqueda(bool lBloqueaBusquedaNombre = false)
        {
            cboCriBusCol.SelectedIndexChanged -= new System.EventHandler(cboCriBusCol_SelectedIndexChanged);
            clsCNCriBusCli ListaCriBusCli = new clsCNCriBusCli();
            DataTable TablaCriBus = ListaCriBusCli.ListarCriBusCli();
            DataTable dtCriBus = TablaCriBus.Clone();
            foreach (DataRow item in TablaCriBus.Rows)
            {
                if (Convert.ToBoolean(item["lVigente"]) && !(Convert.ToInt32(item["idCriBusCli"]) == 2 && lBloqueaBusquedaNombre))
                {
                    dtCriBus.ImportRow(item);
                }
            }

            this.cboCriBusCol.DataSource = dtCriBus;
            this.cboCriBusCol.ValueMember = dtCriBus.Columns[0].ToString();
            this.cboCriBusCol.DisplayMember = dtCriBus.Columns[1].ToString();
            cboCriBusCol.SelectedIndexChanged += new System.EventHandler(cboCriBusCol_SelectedIndexChanged);
        }

        private void cargarDataGridColaborador()
        {
            bsColaborador = new BindingSource();
            bsColaborador.DataSource = lstUsuAprobBiometrico;
            dtgColaborador.DataSource = bsColaborador;


            formatearDataGridColaborador();
        }

        private void formatearDataGridColaborador()
        {
            this.dtgColaborador.AllowUserToAddRows          = false;
            this.dtgColaborador.AllowUserToDeleteRows       = false;
            this.dtgColaborador.AllowUserToResizeRows       = false;
            this.dtgColaborador.MultiSelect                 = false;
            this.dtgColaborador.ReadOnly                    = true;
            this.dtgColaborador.RowHeadersVisible           = false;
            this.dtgColaborador.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgColaborador.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgColaborador.AllowUserToResizeColumns    = false;
            this.dtgColaborador.AllowUserToResizeRows       = false;

            foreach (DataGridViewColumn columna in dtgColaborador.Columns)
            {
                columna.Visible = false;
                columna.HeaderText = columna.Name;
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //this.dtgColaborador.Columns["idUsuario"].Visible = true;
            this.dtgColaborador.Columns["cDocumentoID"].Visible = true;
            this.dtgColaborador.Columns["cNombres"].Visible = true;
            this.dtgColaborador.Columns["cPerfil"].Visible = true;

            this.dtgColaborador.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            this.dtgColaborador.Columns["cNombres"].HeaderText = "Nombres";
            this.dtgColaborador.Columns["cPerfil"].HeaderText = "Perfil";

            //this.dtgColaborador.Columns[""].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buscarColaborador()
        {
            int idCriteriobusqueda;
            string cValorIngresado;
            lstUsuAprobBiometrico.Clear();
            bsColaborador.ResetBindings(true);
            idCriteriobusqueda = Convert.ToInt32(cboCriBusCol.SelectedValue);
            cValorIngresado = txtDniNom.Text.Trim();

            if (cboCriBusCol.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el criterio de búsqueda", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCol.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(cValorIngresado))
            {
                MessageBox.Show("Debe ingresar los datos a buscar", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            clsCNAprobacion objCNAprobacion = new clsCNAprobacion();
            List<clsUsuAprobBiometrico> lstUsuarioConsulta = objCNAprobacion.CNObtenerUsuarioBiometrico(idCriteriobusqueda, cValorIngresado, idAgencia, idEstablecimiento, idTipoOperacion);
            

            if (lstUsuarioConsulta.Count == 0)
            {
                MessageBox.Show("No existen datos con el criterio de busqueda", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            lstUsuAprobBiometrico.AddRange(lstUsuarioConsulta);
            bsColaborador.ResetBindings(true);
            dtgColaborador.Refresh();
            dtgColaborador.Focus();
        }

        private void aceptar()
        {
            if (dtgColaborador.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar a un colaborador.", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsUsuAprobBiometrico objUsuarioSeleccionado = (clsUsuAprobBiometrico)dtgColaborador.SelectedRows[0].DataBoundItem;


            frmCredencialesBiometrico frmCredenciales = new frmCredencialesBiometrico(clsVarGlobal.User.lAutBiometricaAgencia);
            frmCredenciales.cWinUser = objUsuarioSeleccionado.cWinUser;
            frmCredenciales.cMensaje = "He validado plenamente la identidad del cliente bajo responsabilidad, autorizo la presente operación.";
            frmCredenciales.lMostrarMensaje = true;
            frmCredenciales.ShowDialog();

            if (!frmCredenciales.lValido)
            {
                MessageBox.Show("No se ha validado las credenciales del Colaborador, no se puede incluir al participante en la validación", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objUsuSeleccionado = objUsuarioSeleccionado;
            lUsuarioVerificado = true;
            this.Dispose();
        }

        #endregion

        
    }
}

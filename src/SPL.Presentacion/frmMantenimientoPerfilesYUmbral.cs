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
    public partial class frmMantenimientoPerfilesYUmbral : frmBase
    {
        #region Variables globales        
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        String cTituloMensajes = "Mantenimiento de umbral por perfil";
        int idPErfil = 0;
        #endregion
        public frmMantenimientoPerfilesYUmbral()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMantenimientoPerfilesYUmbral_Load(object sender, EventArgs e)
        {
            cargarGrillaPerfiles();
            habilitarControles(false);
        }
        private void dtgPerfiles_SelectionChanged(object sender, EventArgs e)
        {
            verDetalles();
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {            
            if (ValidarDatos())
	        {
                return;
	        }
            DataTable dtPerfil = cnmapeoriesgoyopeinusual.insertaUmbralXPerfil(idPErfil, Convert.ToDecimal(this.txtUmbral.Text), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            MessageBox.Show(dtPerfil.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtPerfil.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            habilitarControles(false);
            cargarGrillaPerfiles();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            verDetalles();
            habilitarControles(false);
        }

        #endregion
        #region Metodos
        private void cargarGrillaPerfiles()
        {
            DataTable dtPerfiles = cnmapeoriesgoyopeinusual.listaPerfilCli(0);
            this.dtgPerfiles.DataSource = dtPerfiles;
            formatoGrillaPerfiles();            
        }
        private void formatoGrillaPerfiles()
        {
            foreach (DataGridViewColumn item in this.dtgPerfiles.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgPerfiles.Columns["cPerfilCliOpeInusual"].Visible = true;
            this.dtgPerfiles.Columns["nMontoUmbral"].Visible = true;

            this.dtgPerfiles.Columns["cPerfilCliOpeInusual"].HeaderText = "Perfil";
            this.dtgPerfiles.Columns["nMontoUmbral"].HeaderText = "Monto Umbral (Dólares)";
        }
        private void verDetalles()
        {
            if (this.dtgPerfiles.SelectedRows.Count > 0)
            {
                this.idPErfil = Convert.ToInt32(this.dtgPerfiles.SelectedRows[0].Cells["idPerfilCliOpeInusual"].Value);
                this.txtPerfil.Text = Convert.ToString(this.dtgPerfiles.SelectedRows[0].Cells["cPerfilCliOpeInusual"].Value);
                this.txtUmbral.Text = Convert.ToString(this.dtgPerfiles.SelectedRows[0].Cells["nMontoUmbral"].Value);
            }            
        }
        private void habilitarControles(Boolean Val)
        {                      
            this.txtUmbral.Enabled = Val;
            this.dtgPerfiles.Enabled = !Val;
            
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;
        }
        private Boolean ValidarDatos() 
        {
            if (String.IsNullOrEmpty(this.txtUmbral.Text))
            {
                MessageBox.Show("Ingrese monto para Umbral", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUmbral.Focus();
                return true;
            }
            Decimal d;
            if (!Decimal.TryParse(this.txtUmbral.Text, out d))
            {
                MessageBox.Show("Ingrese un monto de umbral correcto", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUmbral.Focus();
                return true;
            }
            return false;
        }
        #endregion   
    }
}

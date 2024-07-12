#region Directivas
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using System.Globalization;
#endregion

namespace GEN.ControlesBase
{
    public partial class frmVisitaSupervision : frmBase
    {
        #region Variables
        clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        string cTipoSupervisionTexto = "";
        #endregion

        #region Metodos
        public frmVisitaSupervision()
        {
            InitializeComponent();
        }

        public void mostrarVisitas(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin)
        {
            DataTable dtVisitas = clsVisita.listarVisitaSupervisionOperacion( idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoSupervision, dFechaIni, dFechaFin);

            dtgVisita.DataSource = null;
            dtgVisita.Rows.Clear();
            dtgVisita.Refresh();
            dtgVisita.DataSource = dtVisitas;
            formatoDtg();
            if (dtVisitas.Rows.Count > 0)
            {
                btnRevisar1.Enabled = true;
                btnEliminar1.Enabled = true;
            }
            else
            {
                btnRevisar1.Enabled = false;
                btnEliminar1.Enabled = false;
            }
        }

        public void mostrarVisitas()
        {
            DataTable dtVisitas = clsVisita.listarVisitaSupervisionOperacion(
                this.conFiltroSupervision1.getZonaSelect(),
                this.conFiltroSupervision1.getAgenciaSelect(),
                this.conFiltroSupervision1.getEstablecimientoSelect(),
                this.conFiltroSupervision1.getSupervisorSelect(),
                this.conFiltroSupervision1.getEstadoSelect(),
                this.conFiltroSupervision1.getTipoSupervisionSelect(),
                this.conFiltroSupervision1.getFechaIni(),
                this.conFiltroSupervision1.getFechaFin()
                );

            dtgVisita.DataSource = null;
            dtgVisita.Rows.Clear();
            dtgVisita.Refresh();
            dtgVisita.DataSource = dtVisitas;
            formatoDtg();
            if (dtVisitas.Rows.Count > 0)
            {
                btnRevisar1.Enabled = true;
                btnEliminar1.Enabled = true;
            }
            else
            {
                btnRevisar1.Enabled = false;
                btnEliminar1.Enabled = false;
            }
        }

        public void formatoDtg()
        {
            foreach (DataGridViewColumn item in dtgVisita.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = true;
            }

            dtgVisita.Columns["idVisita"].HeaderText = "ID";
            dtgVisita.Columns["cTipoVisita"].HeaderText = "Tipo";
            dtgVisita.Columns["cZona"].HeaderText = "Región";
            dtgVisita.Columns["cAgencia"].HeaderText = "EOB/Oficina";
            dtgVisita.Columns["cSupervisor"].HeaderText = "Supervisor";
            dtgVisita.Columns["dFecha"].HeaderText = "Registro";
            dtgVisita.Columns["dFechaFin"].HeaderText = "Finalizado";

            dtgVisita.Columns["idVisita"].FillWeight = 4;
            dtgVisita.Columns["cTipoVisita"].FillWeight = 16;
            dtgVisita.Columns["cZona"].FillWeight = 16;
            dtgVisita.Columns["cAgencia"].FillWeight = 22;
            dtgVisita.Columns["cSupervisor"].FillWeight = 26;
            dtgVisita.Columns["dFecha"].FillWeight = 8;
            dtgVisita.Columns["dFechaFin"].FillWeight = 8;

            dtgVisita.Columns["idTipoVisita"].Visible = false;
            dtgVisita.Columns["idEstablecimiento"].Visible = false;
            dtgVisita.Columns["idSupervisor"].Visible = false;
        }

        private void limpiarVisitas(bool lSupervisores = true)
        {
            dtgVisita.DataSource = null;
            btnRevisar1.Enabled = false;
            btnEliminar1.Enabled = false;
        }

        public DataGridViewRow getDatosRowSeleccionado()
        {
            return dtgVisita.CurrentRow;
        }

        public void setearDatosIniciales(string cPerfilSupervisionOficina, int idPerfil, bool lVertical, string cTipoSupervision)
        {
            conFiltroSupervision1.setearDatos(clsVarApl.dicVarGen["cPerfilSupervisionOficina"], clsVarGlobal.PerfilUsu.idPerfil, false, cTipoSupervision);

            Dictionary<string, object> dConfig = null;
            dConfig = parseConfig(clsVarApl.dicVarGen["cPerfilSupervisionOficina"]);
            string[] supervisorOperaciones = (string[])dConfig["supervisorOperaciones"];
            string[] supervisorRecuperaciones = (string[])dConfig["supervisorRecuperaciones"];
            string[] jefeOficina = (string[])dConfig["jefeOficina"];
            string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
            string[] jefeOperaciones = (string[])dConfig["jefeOperaciones"];
            string[] jefeRecuperaciones = (string[])dConfig["jefeRecuperaciones"];
            string[] monitorCorporativo = (string[])dConfig["monitorCorporativo"];

            if (Array.IndexOf(supervisorOperaciones, idPerfil.ToString()) != -1
                || Array.IndexOf(supervisorRecuperaciones, idPerfil.ToString()) != -1
                || Array.IndexOf(jefeOficina, idPerfil.ToString()) != -1
                || Array.IndexOf(gerenteRegional, idPerfil.ToString()) != -1
                || Array.IndexOf(jefeOperaciones, idPerfil.ToString()) != -1
                || Array.IndexOf(jefeRecuperaciones, idPerfil.ToString()) != -1
                || Array.IndexOf(monitorCorporativo, idPerfil.ToString()) != -1)
            {
                btnNuevo1.Visible = true;
            }
            else {
                btnNuevo1.Visible = false;
            }

            cTipoSupervisionTexto = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.conFiltroSupervision1.getTextoTipoSupervision());
        }

        public Dictionary<string, object> parseConfig(string sConfig)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            string[] configs = sConfig.Split(';');
            for (int i = 0; i < configs.Length; i++)
            {
                string[] parts = configs[i].Split(':');
                if (parts.Length == 2)
                {
                    config.Add(parts[0], parts[1].Split(','));
                }
            }
            return config;
        }
        #endregion

        #region Eventos

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (this.conFiltroSupervision1.getZonaSelect() == -1)
            {
                MessageBox.Show("Se debe seleccionar una Región", "Mostrar "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            mostrarVisitas(
                this.conFiltroSupervision1.getZonaSelect(),
                this.conFiltroSupervision1.getAgenciaSelect(),
                this.conFiltroSupervision1.getEstablecimientoSelect(),
                this.conFiltroSupervision1.getSupervisorSelect(),
                this.conFiltroSupervision1.getEstadoSelect(),
                this.conFiltroSupervision1.getTipoSupervisionSelect(),
                this.conFiltroSupervision1.getFechaIni(),
                this.conFiltroSupervision1.getFechaFin()
                );
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            frmBuscaEstablecimiento frmAgencia = new frmBuscaEstablecimiento();
            frmAgencia.idAgencia = this.conFiltroSupervision1.getIdAgenciaUsuario();
            frmAgencia.lFiltroZona = true;
            frmAgencia.ShowDialog();
            int idEstablecimientoSelect = frmAgencia.pnidEstablecimiento;

            if (idEstablecimientoSelect != 0)
            {
                DataTable dtRes = clsVisita.guardarNuevaVisita(clsVarGlobal.User.idUsuario, idEstablecimientoSelect, this.conFiltroSupervision1.getTipoSupervisionSelect(), clsVarGlobal.PerfilUsu.idPerfil);

                if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Nuevo Registro de "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarVisitas();
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Nuevo Registro de " + cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                mostrarVisitas(
                    0,
                    0,
                    idEstablecimientoSelect,
                    clsVarGlobal.User.idUsuario,
                    1,
                    this.conFiltroSupervision1.getTipoSupervisionSelect(),
                    this.conFiltroSupervision1.getFechaFin(),
                    this.conFiltroSupervision1.getFechaFin()
                    );
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dtgVisita.CurrentRow.Cells["idSupervisor"].Value) != clsVarGlobal.PerfilUsu.idUsuario)
            {
                MessageBox.Show("No se puede eliminar, "+cTipoSupervisionTexto+" fue registrado por otro usuario", "Eliminar "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (dtgVisita.CurrentRow.Cells["dFechaFin"].Value.ToString() != "")
            {
                MessageBox.Show("No se puede eliminar, "+cTipoSupervisionTexto+" ya está finalizada", "Eliminar "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (MessageBox.Show("Seguro que desea Eliminar "+cTipoSupervisionTexto+" ?", "Eliminar "+cTipoSupervisionTexto, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idVisita = Convert.ToInt32(dtgVisita.CurrentRow.Cells["idVisita"].Value);
                DataTable dtRes = clsVisita.eliminarVisitaSupervisionOperacion(idVisita);
                if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Eliminar "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mostrarVisitas(
                        this.conFiltroSupervision1.getZonaSelect(),
                        this.conFiltroSupervision1.getAgenciaSelect(),
                        this.conFiltroSupervision1.getEstablecimientoSelect(),
                        this.conFiltroSupervision1.getSupervisorSelect(),
                        this.conFiltroSupervision1.getEstadoSelect(),
                        this.conFiltroSupervision1.getTipoSupervisionSelect(),
                        this.conFiltroSupervision1.getFechaIni(),
                        this.conFiltroSupervision1.getFechaFin()
                        );
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Eliminar "+cTipoSupervisionTexto, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void conFiltroSupervision1_FiltroChanged(object sender, EventArgs e)
        {
            limpiarVisitas();
        }
        #endregion
    }
}

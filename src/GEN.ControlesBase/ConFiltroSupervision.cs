using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConFiltroSupervision : UserControl
    {
        #region Variables
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        Dictionary<string, object> dConfig = null;
        private int idAgenciaUsuario = 0;
        private int idEstablecimiento = 0;
        private int idAgencia = 0;
        private string cPerfiles = "";
        private bool lSupervisor = false;
        private string cTipoSupervision = "";
        public event EventHandler FiltroChanged;
        #endregion

        #region Metodos
        public ConFiltroSupervision()
        {
            InitializeComponent();
        }

        public void setearDatos(string cPerfiles_, int idPerfil_, bool lVertical, string cTipoSupervision_)
        {
            cPerfiles = cPerfiles_;
            cTipoSupervision = cTipoSupervision_;
            DataTable dtTipo = clsVisita.obtenerTipoSupervision(cTipoSupervision);
            if (dtTipo.Rows.Count > 0)
            {
                txtTipoSupervision.Text = dtTipo.Rows[0]["cTipoVisita"].ToString();
            }

            if (cTipoSupervision == "ArqueoBoveda" || cTipoSupervision == "ArqueoVentanilla")
            {
                lblBase4.Text = "Colaborador";
            }
            
            mostrarEnDireccion(lVertical);
            habilitarControles(idPerfil_);
        }

        public void mostrarEnDireccion(bool lVertical)
        {
            if (lVertical)
            {
                this.Size = new Size(433, 205);
                this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            }
            else
            {
                this.Size = new Size(864, 90);
                this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void habilitarControles(int idPerfil)
        {
            if (cPerfiles != "")
            {
                this.dConfig = parseConfig(cPerfiles);
                string[] supervisorOperaciones = (string[])dConfig["supervisorOperaciones"];
                string[] supervisorRecuperaciones = (string[])dConfig["supervisorRecuperaciones"];
                string[] jefeOficina = (string[])dConfig["jefeOficina"];
                string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
                string[] jefeOperaciones = (string[])dConfig["jefeOperaciones"];
                string[] jefeRecuperaciones = (string[])dConfig["jefeRecuperaciones"];
                string[] monitorCorporativo = (string[])dConfig["monitorCorporativo"];

                if (Array.IndexOf(supervisorOperaciones, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("supervisor", 1);
                }
                else if (Array.IndexOf(supervisorRecuperaciones, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("supervisor", 2);
                }
                else if (Array.IndexOf(jefeOficina, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("jefeOficina", 0);
                }
                else if (Array.IndexOf(gerenteRegional, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("gerenteRegional", 0);
                }
                else if (Array.IndexOf(jefeOperaciones, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("jefeAreaCorporativo", 1);
                }
                else if (Array.IndexOf(jefeRecuperaciones, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("jefeAreaCorporativo", 2);
                }
                else if (Array.IndexOf(monitorCorporativo, idPerfil.ToString()) != -1)
                {
                    habilitarFiltros("jefeAreaCorporativo", 0);
                }
                else
                {
                    habilitarFiltros("noCorresponde", -1);
                }
            }
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

        private void habilitarFiltros(string cPerfil, int idTipoSupervision)
        {
            idAgenciaUsuario = 0;
            cboZona1.SelectedIndexChanged -= cboZona1_SelectedIndexChanged;

            if (cPerfil == "supervisor")
            {
                cboZona1.cargarZonasAsignadas(clsVarGlobal.User.idUsuario);
                cboSupervisorOperacion1.mostrarSoloTodos();
            }
            else if (cPerfil == "gerenteRegional")
            {
                cboZona1.cargarZonasAsignadas(clsVarGlobal.User.idUsuario);
                cboSupervisorOperacion1.mostrarSoloTodos();
            }
            else if (cPerfil == "jefeOficina")
            {
                cboSupervisorOperacion1.Enabled = true;
                cboZona1.cargarZona(true, false);
                DataTable dtRes = clsVisita.getZonaUsuario(clsVarGlobal.User.idUsuario);
                int idZona = Convert.ToInt32(dtRes.Rows[0]["idZona"]);
                cboZona1.SelectedValue = (int)idZona;
                cboZona1.Enabled = false;

                txtAgencia.Text = "TODOS : " + clsVarGlobal.cNomAge;
                btnAbrirEstab.Enabled = true;

                idAgenciaUsuario = clsVarGlobal.nIdAgencia;
                cboSupervisorOperacion1.mostrarSoloTodos();
            }
            else if (cPerfil == "jefeAreaCorporativo")
            {
                cboZona1.cargarZona(true, false);
                cboZona1.Enabled = true;
                cboSupervisorOperacion1.Enabled = true;
                cboZona1.SelectedValue = 0;
                cboSupervisorOperacion1.mostrarSoloTodos();
            }
            else
            {
                cboZona1.SelectedIndex = -1;
                cboZona1.Enabled = false;
                cboSupervisorOperacion1.SelectedIndex = -1;
                cboSupervisorOperacion1.Enabled = false;
                cboEstadoSupervision1.SelectedIndex = -1;
                cboEstadoSupervision1.Enabled = false;
                MessageBox.Show("Perfil No Configurado", "Nueva Visita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cboZona1.SelectedIndexChanged += cboZona1_SelectedIndexChanged;
        }

        private void listarSupervisor(bool lSupervisor)
        {
            if (cboZona1.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha Seleccionado una Región/Zona", "Listar Supervisores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboEstadoSupervision1.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha Seleccionado el Estado de Supervisión", "Listar Supervisores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cboSupervisorOperacion1.cargarSupervisor(cTipoSupervision, dtpFechaDesde.Value, dtpFechaHasta.Value, Convert.ToInt32(cboZona1.SelectedValue), idAgencia, idEstablecimiento, Convert.ToInt32(cboEstadoSupervision1.SelectedValue));
        }

        public string getTipoSupervisionSelect()
        {
            return cTipoSupervision;
        }

        public string getTextoTipoSupervision()
        {
            return txtTipoSupervision.Text;
        }

        public int getZonaSelect()
        {
            int idValor = -1;
            if (cboZona1.SelectedIndex >= 0)
            {
                idValor = Convert.ToInt32(cboZona1.SelectedValue);
            }
            return idValor;
        }

        public int getAgenciaSelect()
        {
            if (idAgenciaUsuario == 0)
            {
                return idAgencia;
            }
            else
            {
                return idAgenciaUsuario;
            }
        }

        public int getEstablecimientoSelect()
        {
            return idEstablecimiento;
        }

        public int getEstadoSelect()
        {
            int idValor = -1;
            if (cboEstadoSupervision1.SelectedIndex >= 0)
            {
                idValor = Convert.ToInt32(cboEstadoSupervision1.SelectedValue);
            }
            return idValor;
        }

        public int getSupervisorSelect()
        {
            int idValor = -1;
            if (cboSupervisorOperacion1.SelectedIndex >= 0)
            {
                idValor = Convert.ToInt32(cboSupervisorOperacion1.SelectedValue);
            }
            else if(lSupervisor)
            {
                idValor = clsVarGlobal.PerfilUsu.idUsuario;
            }
            return idValor;
        }

        public DateTime getFechaIni()
        {
            return dtpFechaDesde.Value;
        }

        public DateTime getFechaFin()
        {
            return dtpFechaHasta.Value;
        }

        public int getIdAgenciaUsuario()
        {
            return idAgenciaUsuario;
            
        }

        private void abrirFormularioEstablecimientos()
        {
            if (cboZona1.SelectedIndex >= 0)
            {
                frmBuscaEstablecimiento frmAgencia = new frmBuscaEstablecimiento();
                frmAgencia.idAgencia = idAgenciaUsuario;
                frmAgencia.idZona = Convert.ToInt32(cboZona1.SelectedValue);
                frmAgencia.lFiltroZona = true;
                frmAgencia.lSelectAgencia = true;
                frmAgencia.ShowDialog();

                if (frmAgencia.pnIdEstablecimientoPadre != 0 && frmAgencia.pnidEstablecimiento != 0)//Eob
                {
                    idEstablecimiento = frmAgencia.pnidEstablecimiento;
                    idAgencia = frmAgencia.pnIdEstablecimientoPadre / 1000;
                    txtAgencia.Text = frmAgencia.pcNombreEstablecimiento;
                }
                else if (frmAgencia.pnIdEstablecimientoPadre == 0 && frmAgencia.pnidEstablecimiento != 0)//Agencia
                {
                    idAgencia = frmAgencia.pnidEstablecimiento / 1000;
                    idEstablecimiento = 0;
                    txtAgencia.Text = frmAgencia.pcNombreEstablecimiento;
                }

                if (!lSupervisor)
                    cboSupervisorOperacion1.mostrarSoloTodos();
            }
            else
            {
                MessageBox.Show("No se ha Seleccionado una Región/Zona", "Mostrar Agencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Eventos
        private void ConFiltroSupervision_Load(object sender, EventArgs e)
        {
            DateTime dFecha = Convert.ToDateTime(clsVarGlobal.dFecSystem.Year + "-" + clsVarGlobal.dFecSystem.Month + "-01");
            DateTime dFechaSys = Convert.ToDateTime(clsVarGlobal.dFecSystem.Year + "-" + clsVarGlobal.dFecSystem.Month + "-" + clsVarGlobal.dFecSystem.Day);

            dtpFechaHasta.Value = dFechaSys;
            dtpFechaHasta.MinDate = dFecha;
            dtpFechaHasta.MaxDate = dFechaSys;

            dtpFechaDesde.Value = dFecha;
            dtpFechaDesde.MinDate = DateTime.MinValue;
            dtpFechaDesde.MaxDate = Convert.ToDateTime(dtpFechaHasta.Value);

        }

        private void btnAbrirEstab_Click(object sender, EventArgs e)
        {
            abrirFormularioEstablecimientos();
            
            if (lSupervisor && FiltroChanged != null)
            {
                FiltroChanged(sender, e);
            }
        }

        private void btnEstabTodos_Click(object sender, EventArgs e)
        {
            idEstablecimiento = 0;
            txtAgencia.Text = "-* TODOS *-";
            idAgencia = 0;
            cboSupervisorOperacion1.mostrarSoloTodos();

            if (lSupervisor && FiltroChanged != null)
            {
                FiltroChanged(sender, e);
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
            cboSupervisorOperacion1.mostrarSoloTodos();

            if (lSupervisor && FiltroChanged != null)
            {
                FiltroChanged(sender, e);
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.MaxDate = dtpFechaHasta.Value;
            cboSupervisorOperacion1.mostrarSoloTodos();

            if (lSupervisor && FiltroChanged != null)
            {
                FiltroChanged(sender, e);
            }
        }

        private void btnMiniActualizar1_Click(object sender, EventArgs e)
        {
            listarSupervisor(lSupervisor);
        }

        private void cboTipoVisitaSupervision1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!lSupervisor)
                cboSupervisorOperacion1.mostrarSoloTodos();
        }

        private void cboEstadoSupervision1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSupervisorOperacion1.mostrarSoloTodos();
            
            if (FiltroChanged != null)
                FiltroChanged(sender, e);
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSupervisorOperacion1.mostrarSoloTodos();

            if (FiltroChanged != null)
                FiltroChanged(sender, e);
        }

        private void cboSupervisorOperacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroChanged != null)
                FiltroChanged(sender, e);
        }

        private void txtAgencia_DoubleClick(object sender, EventArgs e)
        {
            abrirFormularioEstablecimientos();

            if (lSupervisor && FiltroChanged != null)
            {
                FiltroChanged(sender, e);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class ConBusGrupoSol : UserControl
    {
        private clsCNGrupoSolidario objCNGrupoSolidario = new clsCNGrupoSolidario();

        public int idGrupoSolidario;
        public string cGrupoSolidario;
        public string cDireccion;
        public DateTime dFechaCreacion;

        public int idSolicitudCredGrupoSol;
        public int idEstado;

        public DataTable dtGrupo = null;
        public DataTable dtIntegrantes = null;

        public event EventHandler ClicBuscar;

        public bool lResultado = false;

        public ConBusGrupoSol()
        {
            this.idGrupoSolidario = 0;
            this.cGrupoSolidario = string.Empty;
            this.cDireccion = string.Empty;
            this.dFechaCreacion = DateTime.Now;

            this.idSolicitudCredGrupoSol = 0;
            this.idEstado = 0;

            InitializeComponent();
            this.Habilitar(clsAcciones.DEFECTO);
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            Buscar("");

            if (ClicBuscar != null)
                ClicBuscar(sender, e);
        }

        public void Buscar(string cNombreGrupoSol)
        {
            btnBusqueda.Focus();

            FrmBusGrupoSol frmBusGrupoSol = new FrmBusGrupoSol(cNombreGrupoSol);
            frmBusGrupoSol.ShowDialog();

            this.idGrupoSolidario = frmBusGrupoSol.idGrupoSolidario;

            if (this.idGrupoSolidario == 0) { this.lResultado = false; this.LimpiarControl(); return; }
            ObtenerSolCredGrupoSolidario(this.idGrupoSolidario);
        }

        public void ObtenerSolCredGrupoSolidario(int idGrupoSolidario)
        {
            this.Habilitar(clsAcciones.BUSCAR);
            lResultado = true;
            DataSet ds = objCNGrupoSolidario.ObtenerSolCredGrupoSolidario(idGrupoSolidario,0);

            if (ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Los datos del grupo estan incompletos, por favor revisar", "BUSQUEDA DE GRUPO SOLIDARIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lResultado = false;
                return;
            }   

            dtGrupo = ds.Tables[0];

            this.idGrupoSolidario = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]);
            this.idSolicitudCredGrupoSol = Convert.ToInt32(dtGrupo.Rows[0]["idSolicitudCredGrupoSol"]);
            this.idEstado = Convert.ToInt32(dtGrupo.Rows[0]["idEstado"]);
            this.cboGrupoSolidarioCiclo1.SelectedValue = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidarioCiclo"]);
            this.cboTipoGrupoSolidario1.SelectedValue = Convert.ToInt32(dtGrupo.Rows[0]["idTipoGrupoSolidario"]);

            dtIntegrantes = ds.Tables[1];

            this.txtIdGrupoSolidario.Text = dtGrupo.Rows[0]["idGrupoSolidario"].ToString();
            this.txtNombreGrupo.Text = dtGrupo.Rows[0]["cNombre"].ToString();
            this.txtDireccion.Text = dtGrupo.Rows[0]["cDireccion"].ToString();

            this.idGrupoSolidario = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]);
            this.cGrupoSolidario = dtGrupo.Rows[0]["cNombre"].ToString();
            this.cDireccion = dtGrupo.Rows[0]["cDireccion"].ToString();

            this.txtIdGrupoSolidario.Enabled = false;
            this.txtNombreGrupo.Enabled = false;

            this.cboGrupoSolidarioCiclo1.Enabled = false;
            this.cboTipoGrupoSolidario1.Enabled = false;
        }
        public List<clsCreditoGrupoSolInt> listaSolicitudIntegrante()
        {
            return (this.dtIntegrantes.Rows.Count > 0) ?
                this.dtIntegrantes.ToList<clsCreditoGrupoSolInt>() as List<clsCreditoGrupoSolInt> :
                new List<clsCreditoGrupoSolInt>();
        }

        public void LimpiarControl()
        {
            this.txtIdGrupoSolidario.Text = string.Empty;
            this.txtNombreGrupo.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;

            this.idGrupoSolidario = 0;
            this.cGrupoSolidario = string.Empty;
            this.cDireccion = string.Empty;
            this.dFechaCreacion = DateTime.Now;

            this.txtIdGrupoSolidario.Enabled = true;
            this.txtNombreGrupo.Enabled = true;

            this.cboGrupoSolidarioCiclo1.SelectedIndex = -1;
            this.cboTipoGrupoSolidario1.SelectedIndex = -1;
        }

        public void Habilitar(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.txtIdGrupoSolidario.Enabled = true;
                    this.txtNombreGrupo.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    break;
                case clsAcciones.BUSCAR:
                    this.txtIdGrupoSolidario.Enabled = false;
                    break;
                case clsAcciones.NUEVO:
                    this.txtIdGrupoSolidario.Enabled = true;
                    break;
                case clsAcciones.CANCELAR:
                    this.txtIdGrupoSolidario.Enabled = true;
                    break;
            }
        }

        public int obtenerTipoGrupoSol()
        {
            return Convert.ToInt32(cboTipoGrupoSolidario1.SelectedValue);
        }

        private void txtIdGrupoSolidario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.idGrupoSolidario = 0;
                bool lEntero = int.TryParse(this.txtIdGrupoSolidario.Text, out this.idGrupoSolidario);

                if (!lEntero)
                {
                    MessageBox.Show("¡El valor buscado (N° de Grupo) debe ser un número entero positivo!","VALOR DE BUSQUEDA INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(this.idGrupoSolidario == 0) return;
                ObtenerSolCredGrupoSolidario(this.idGrupoSolidario);

                if (ClicBuscar != null)
                    ClicBuscar(sender, e);
            }
        }

        private void txtNombreGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(this.txtNombreGrupo.Text)) return;

                Buscar(this.txtNombreGrupo.Text);

                if (ClicBuscar != null)
                    ClicBuscar(sender, e);
            }
        }

        public void HabilitarBusqueda()
        {
            this.txtIdGrupoSolidario.Enabled = true;
            this.txtNombreGrupo.Enabled = true;
        }

        public void HabilitarEdicion()
        {
            this.txtIdGrupoSolidario.Enabled = false;
            this.txtNombreGrupo.Enabled = true;
            this.btnBusqueda.Enabled = false;
        }
    }
}

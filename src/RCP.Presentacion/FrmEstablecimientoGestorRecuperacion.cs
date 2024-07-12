using GEN.ControlesBase;
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
using RCP.CapaNegocio;
using System.Xml.Serialization;
namespace RCP.Presentacion
{
    public partial class FrmEstablecimientoGestorRecuperacion : frmBase
    {
        #region Variables Globales
        private clsCNRecuperador objCNRecuperador;
        private clsGestorRecuperacion objGestorRecuperacion;
        private clsAgenciaEstablecimiento objAgenciaEstablecimiento;

        private List<clsGestorRecuperacion> lstGestorRecuperacion;
        private List<clsAgenciaEstablecimiento> lstAgenciaEstablecimiento;
        private List<clsAgenciaEstablecimiento> lstAgenciaEstabDisponible;
        private List<clsAgenciaEstablecimiento> lstAgenciaEstabAsignado;
        private List<clsEstablecimientoGestorRecuperacion> lstEstablecimientoGestorRecuperacion;
        private BindingSource bsGestorRecuperacion;
        private BindingSource bsEstabAgenciaDisponible;
        private BindingSource bsEstabAgenciaAsignado;
        #endregion
        public FrmEstablecimientoGestorRecuperacion()
        {
            InitializeComponent();
            this.InicializarDatos();
        }
        #region Metodos
        private void InicializarDatos()
        {
            this.objCNRecuperador = new clsCNRecuperador();
            this.objGestorRecuperacion = new clsGestorRecuperacion();


            this.lstGestorRecuperacion = new List<clsGestorRecuperacion>();
            this.lstAgenciaEstablecimiento = new List<clsAgenciaEstablecimiento>();
            this.lstAgenciaEstabDisponible = new List<clsAgenciaEstablecimiento>();
            this.lstAgenciaEstabAsignado = new List<clsAgenciaEstablecimiento>();
            this.lstEstablecimientoGestorRecuperacion = new List<clsEstablecimientoGestorRecuperacion>();
            this.bsGestorRecuperacion = new BindingSource();
            this.bsEstabAgenciaDisponible = new BindingSource();
            this.bsEstabAgenciaAsignado = new BindingSource();

            this.bsGestorRecuperacion.DataSource = lstGestorRecuperacion;
            this.dtgGestorRecuperacion.DataSource = this.bsGestorRecuperacion;

            this.bsEstabAgenciaDisponible.DataSource = this.lstAgenciaEstabDisponible;
            this.dtgEstablecimientoAgencia.DataSource = this.bsEstabAgenciaDisponible;

            this.bsEstabAgenciaAsignado.DataSource = lstAgenciaEstabAsignado;
            this.dtgEstabAgenciaAsignado.DataSource = this.bsEstabAgenciaAsignado;

            this.FormatearGestorRecuperacion();
            this.FormatearEstablecimientoAgencia();
            this.FormatearEstabAgenciaAsignado();

            this.ListarRegionAgenciaEstabs(0);
            this.LstGestRecuperaEstablecimiento();
            this.ListarEstablecimientoGestorRecuperacion();
        }
        private void LstGestRecuperaEstablecimiento()
        {
            this.lstGestorRecuperacion.Clear();
            this.lstGestorRecuperacion.AddRange(this.objCNRecuperador.LstGestRecuperaEstablecimiento());
            this.bsGestorRecuperacion.ResetBindings(false);
            this.dtgGestorRecuperacion.Refresh();
        }
        private void ListarRegionAgenciaEstabs(int idRegion)
        {
            this.lstAgenciaEstablecimiento = this.objCNRecuperador.ListarRegionAgenciaEstabs(idRegion);

            if (this.lstAgenciaEstablecimiento.Count ==  0)
            {
                this.lstAgenciaEstablecimiento = new List<clsAgenciaEstablecimiento>();
            }
        }

        private void FiltrarRegionAgenciaEstabs(int idRegion)
        {
            this.lstAgenciaEstabDisponible.Clear();
            this.lstAgenciaEstabDisponible.AddRange(this.lstAgenciaEstablecimiento.FindAll(x => x.idRegion == idRegion));
            this.bsEstabAgenciaDisponible.ResetBindings(false);
            this.dtgEstablecimientoAgencia.Refresh();
        }

        private void ListarEstablecimientoGestorRecuperacion()
        {
            this.lstEstablecimientoGestorRecuperacion = this.objCNRecuperador.ListarEstablecGestorRecuperacion();
        }
        public void FormatearGestorRecuperacion()
        {
            foreach (DataGridViewColumn dtgColumn in dtgGestorRecuperacion.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.HeaderText = dtgColumn.Name;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgGestorRecuperacion.Columns["idUsuario"].Visible = true;
            dtgGestorRecuperacion.Columns["idCli"].Visible = true;
            dtgGestorRecuperacion.Columns["cNombre"].Visible = true;
            dtgGestorRecuperacion.Columns["nEstablecimientos"].Visible = true;

            dtgGestorRecuperacion.Columns["idUsuario"].HeaderText = "Cod.Usu";
            dtgGestorRecuperacion.Columns["idCli"].HeaderText = "Cod.Cli";
            dtgGestorRecuperacion.Columns["cNombre"].HeaderText = "Nombre";
            dtgGestorRecuperacion.Columns["nEstablecimientos"].HeaderText = "Establs";

            dtgGestorRecuperacion.Columns["idUsuario"].Width = 80;
            dtgGestorRecuperacion.Columns["idCli"].Width = 80;
            dtgGestorRecuperacion.Columns["cNombre"].Width = 440;
            dtgGestorRecuperacion.Columns["nEstablecimientos"].Width = 80;
        }
        public void FormatearEstablecimientoAgencia()
        {
            foreach( DataGridViewColumn dtgColumn in dtgEstablecimientoAgencia.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.HeaderText = dtgColumn.Name;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgEstablecimientoAgencia.Columns["idEstablecimiento"].Visible = true;
            dtgEstablecimientoAgencia.Columns["cEstablecimiento"].Visible = true;

            dtgEstablecimientoAgencia.Columns["idEstablecimiento"].HeaderText = "Codigo";
            dtgEstablecimientoAgencia.Columns["cEstablecimiento"].HeaderText = "Establecimiento";

            dtgEstablecimientoAgencia.Columns["idEstablecimiento"].Width = 50;
            dtgEstablecimientoAgencia.Columns["cEstablecimiento"].Width = 270;
        }
        private void FormatearEstabAgenciaAsignado()
        {
            foreach (DataGridViewColumn dtgColumn in dtgEstabAgenciaAsignado.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.HeaderText = dtgColumn.Name;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgEstabAgenciaAsignado.Columns["idEstablecimiento"].Visible = true;
            dtgEstabAgenciaAsignado.Columns["cEstablecimiento"].Visible = true;

            dtgEstabAgenciaAsignado.Columns["idEstablecimiento"].HeaderText = "Codigo";
            dtgEstabAgenciaAsignado.Columns["cEstablecimiento"].HeaderText = "Establecimiento";

            dtgEstabAgenciaAsignado.Columns["idEstablecimiento"].Width = 50;
            dtgEstabAgenciaAsignado.Columns["cEstablecimiento"].Width = 290;
        }
        #endregion        
        #region Eventos
        private void cboRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.FiltrarRegionAgenciaEstabs(Convert.ToInt32(this.cboRegion.SelectedValue));
        }
        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            if(this.lstEstablecimientoGestorRecuperacion.Exists(x => x.idUsuRecuperador == this.objGestorRecuperacion.idUsuario &&
                x.idEstablecimiento == this.objAgenciaEstablecimiento.idEstablecimiento && x.lVigente == false))
            {
                this.lstEstablecimientoGestorRecuperacion.Find(
                x => x.idEstablecimiento == this.objAgenciaEstablecimiento.idEstablecimiento &&
                    x.idUsuRecuperador == this.objGestorRecuperacion.idUsuario).lVigente = true;

                return;
            }
            else if (this.lstEstablecimientoGestorRecuperacion.Exists(x => x.idUsuRecuperador == this.objGestorRecuperacion.idUsuario &&
                x.idEstablecimiento == this.objAgenciaEstablecimiento.idEstablecimiento)) return;

            this.lstEstablecimientoGestorRecuperacion.Add(
                new clsEstablecimientoGestorRecuperacion { 
                    idUsuRecuperador = this.objGestorRecuperacion.idUsuario,
                    idEstablecimiento = this.objAgenciaEstablecimiento.idEstablecimiento}
                );
            this.lstAgenciaEstabAsignado.Add(this.objAgenciaEstablecimiento);
            this.bsEstabAgenciaAsignado.ResetBindings(false);
            this.dtgEstabAgenciaAsignado.Refresh();
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgEstabAgenciaAsignado.SelectedRows.Count == 0) return;

            int nIndice = this.dtgEstabAgenciaAsignado.SelectedRows[0].Index;
            this.objAgenciaEstablecimiento = this.lstAgenciaEstabAsignado[nIndice];

            this.lstEstablecimientoGestorRecuperacion.Find(
                x => x.idEstablecimiento == this.objAgenciaEstablecimiento.idEstablecimiento &&
                    x.idUsuRecuperador == this.objGestorRecuperacion.idUsuario).lVigente = false;


            this.lstAgenciaEstabAsignado.RemoveAt(nIndice);
            this.bsEstabAgenciaAsignado.ResetBindings(false);
            this.dtgEstabAgenciaAsignado.Refresh();
        }
        private void dtgGestorRecuperacion_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgGestorRecuperacion.SelectedRows.Count == 0) return;
            this.lstAgenciaEstabAsignado.Clear();
            this.bsEstabAgenciaAsignado.ResetBindings(false);
            this.dtgEstabAgenciaAsignado.Refresh();

            int nIndice = this.dtgGestorRecuperacion.SelectedRows[0].Index;

            this.objGestorRecuperacion = this.lstGestorRecuperacion[nIndice];

            List<clsEstablecimientoGestorRecuperacion> lstEstabGestRecuperador =
                this.lstEstablecimientoGestorRecuperacion.FindAll(x => x.idUsuRecuperador == this.objGestorRecuperacion.idUsuario);

            if (lstEstabGestRecuperador.Count == 0) return;

            foreach(clsEstablecimientoGestorRecuperacion objEstabGestRecuperador in lstEstabGestRecuperador)
            {
                if(objEstabGestRecuperador.lVigente)
                this.lstAgenciaEstabAsignado.AddRange(this.lstAgenciaEstablecimiento.FindAll(x => x.idEstablecimiento == objEstabGestRecuperador.idEstablecimiento));
            }
            this.bsEstabAgenciaAsignado.ResetBindings(false);
            this.dtgEstabAgenciaAsignado.Refresh();
        }
        private void dtgEstablecimientoAgencia_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgEstablecimientoAgencia.SelectedRows.Count == 0) return;

            int nIndice = this.dtgEstablecimientoAgencia.SelectedRows[0].Index;
            this.objAgenciaEstablecimiento = this.lstAgenciaEstabDisponible[nIndice];
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dtRespuestaServidor = this.objCNRecuperador.GrabarEstablecGestorRecuperacion(this.lstEstablecimientoGestorRecuperacion);

            if (Convert.ToInt32(dtRespuestaServidor.Rows[0]["idResultado"]) == 1)
            {
                MessageBox.Show("" + dtRespuestaServidor.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRespuestaServidor.Rows[0]["cMensaje"].ToString(), "Error de Grabado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

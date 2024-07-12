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
using EntityLayer;
using CRE.CapaNegocio;
using ADM.CapaNegocio;
namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioBono : frmBase
    {
        #region Variables Globales
        private clsCNGrupoSolidario objCNGrupoSolidario;
        private clsCNAprobacion objCNAprobacion;
        private List<clsGrupoSolidarioBono> lstGrupoSolidarioBono;
        private clsGrupoSolidarioBono objGrupoSolidarioBono;
        private BindingSource bsGrupoSolidarioBono;

        private clsAprobacionSolicitud objAprobacionSolicitud;

        private int idGrupoSolidario;
        private int idSolicitudCredGrupoSol;
        private int nIndiceFila;
        private decimal nBonoTotal;
        private decimal nMaxAtraso;
        private decimal nPromedioAtraso;
        private decimal nPromedioMeses;

        #endregion
        public frmGrupoSolidarioBono()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        public frmGrupoSolidarioBono(int idSolicitudCredGrupoSol)
        {
            InitializeComponent();
            this.inicializarDatos();
            this.idSolicitudCredGrupoSol = idSolicitudCredGrupoSol;
            DataTable dtSolCredGrupoSol = (new clsCNGrupoSolidario()).obtenerSolicitudCredGrupoSol(idSolicitudCredGrupoSol);
            if (dtSolCredGrupoSol.Rows.Count > 0)
            {
                this.idGrupoSolidario = Convert.ToInt32(dtSolCredGrupoSol.Rows[0]["idGrupoSolidario"]);
            }
            else
            {
                this.idGrupoSolidario = -1;
            }            
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNGrupoSolidario = new clsCNGrupoSolidario();
            this.objCNAprobacion = new clsCNAprobacion();
            this.lstGrupoSolidarioBono = new List<clsGrupoSolidarioBono>();
            this.objGrupoSolidarioBono = new clsGrupoSolidarioBono();
            this.bsGrupoSolidarioBono = new BindingSource();

            this.objAprobacionSolicitud = new clsAprobacionSolicitud();

            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.nIndiceFila = -1;
            this.nBonoTotal = decimal.Zero;
            this.nMaxAtraso = decimal.Zero;
            this.nPromedioAtraso = decimal.Zero;
            this.nPromedioMeses = decimal.Zero;

            this.bsGrupoSolidarioBono.DataSource = this.lstGrupoSolidarioBono;
            this.dtgBonoEstimado.DataSource = this.bsGrupoSolidarioBono;

            this.formatearBonoEstimado();
            this.habilitarControles(clsAcciones.DEFECTO);
            this.tsstNombreFormulario.Text = this.Name;
        }
        private void formatearBonoEstimado()
        {
            foreach(DataGridViewColumn dgvColumn in this.dtgBonoEstimado.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dtgBonoEstimado.Columns["idCuenta"].Visible = true;
            this.dtgBonoEstimado.Columns["idSolicitud"].Visible = true;
            this.dtgBonoEstimado.Columns["cEstado"].Visible = true;
            this.dtgBonoEstimado.Columns["cCliente"].Visible = true;
            this.dtgBonoEstimado.Columns["cDocumento"].Visible = true;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].Visible = true;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].Visible = true;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].Visible = true;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].Visible = true;
            this.dtgBonoEstimado.Columns["nBono"].Visible = true;
            this.dtgBonoEstimado.Columns["cObservacion"].Visible = true;

            int i = 0;
            this.dtgBonoEstimado.Columns["idCuenta"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["idSolicitud"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cEstado"].DisplayIndex = i++;
            
            this.dtgBonoEstimado.Columns["cCliente"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cDocumento"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nBono"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cObservacion"].DisplayIndex = i++;

            this.dtgBonoEstimado.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgBonoEstimado.Columns["idSolicitud"].HeaderText = "Solicitud";
            this.dtgBonoEstimado.Columns["cEstado"].HeaderText = "Estado";
            this.dtgBonoEstimado.Columns["cCliente"].HeaderText = "Cliente";
            this.dtgBonoEstimado.Columns["cDocumento"].HeaderText = "Documento";
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].HeaderText = "Monto Desembolso";
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].HeaderText = "Meses";
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].HeaderText = "Atraso Max.";
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].HeaderText = "Factor";
            this.dtgBonoEstimado.Columns["nBono"].HeaderText = "Monto Bono";
            this.dtgBonoEstimado.Columns["cObservacion"].HeaderText = "Observación";

            this.dtgBonoEstimado.Columns["idCuenta"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["idSolicitud"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["cEstado"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["cCliente"].FillWeight = 150;
            this.dtgBonoEstimado.Columns["cDocumento"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].FillWeight = 50;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].FillWeight = 20;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].FillWeight = 20;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].FillWeight = 30;
            this.dtgBonoEstimado.Columns["nBono"].FillWeight = 50;
            this.dtgBonoEstimado.Columns["cObservacion"].FillWeight = 50;
        }
        private void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.txtJustificacion.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    this.gbxSolicitudExcepcion.Visible = ((int)Perfil.AsesorGruposSolidarios == clsVarGlobal.PerfilUsu.idPerfil);
                    this.btnCancelar.Visible = ((int)Perfil.AsesorGruposSolidarios == clsVarGlobal.PerfilUsu.idPerfil);
                    break;
                case clsAcciones.BUSCAR:
                    this.txtJustificacion.Enabled = true;
                    this.btnSolicitar.Visible = true;
                    break;
                case clsAcciones.GRABAR:
                    this.txtJustificacion.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    break;
                case clsAcciones.REVISAR:
                    this.gbxBuscador.Visible = false;
                    this.gbxBuscador.Enabled = false;
                    this.gbxSolicitudExcepcion.Visible = true;
                    this.gbxSolicitudExcepcion.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    this.btnCancelar.Visible = false;
                    break;
            }
        }
        private void limpiarControles(bool lLimpiarBuscador = true)
        {
            this.nudProbabilidadBono.Value = decimal.Zero;
            this.nudMaxAtraso.Value = decimal.Zero;
            this.nudPromedioAtraso.Value = decimal.Zero;
            this.nudPromedioMeses.Value = decimal.Zero;
            this.nudBonoTotal.Value = decimal.Zero;

            this.pgbProbabilidadBono.Value = 0;

            this.txtEstado.Text = string.Empty;
            this.txtFechaSolicitud.Text = string.Empty;
            this.txtJustificacion.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;

            this.lstGrupoSolidarioBono.Clear();
            this.bsGrupoSolidarioBono.ResetBindings(false);
            this.dtgBonoEstimado.Refresh();

            if(lLimpiarBuscador)this.conBusGrupoSol.LimpiarControl();
        }

        private void listarGrupoSolidarioBonoEstimado()
        {
            this.lstGrupoSolidarioBono.Clear();
            this.lstGrupoSolidarioBono.AddRange(this.objCNGrupoSolidario.listarGrupoSolidarioBonoEstimado(this.idGrupoSolidario, 0, 0));

            if (this.lstGrupoSolidarioBono.Count > 0 && this.lstGrupoSolidarioBono.Exists(x=>x.lEntregado == false))
            {
                this.habilitarControles(clsAcciones.BUSCAR);
                this.calcularIndicadores();

                this.idSolicitudCredGrupoSol = this.lstGrupoSolidarioBono[0].idSolicitudCredGrupoSol;

                this.obtenerAprobacionSolicitud();
            }
            else
            {
                MessageBox.Show("El grupo solidario no tiene créditos activos o cancelados pendientes de bonificación",
                    "GRUPO SIN CREDITO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.habilitarControles(clsAcciones.DEFECTO);
                this.limpiarControles();
            }
            this.bsGrupoSolidarioBono.ResetBindings(false);
            this.dtgBonoEstimado.Refresh();
            this.dtgBonoEstimado.ClearSelection();
            this.colorearGrupoSolidarioBono();
        }
        private void calcularIndicadores()
        {
            decimal nLimiteAtraso = 3.0M;
            decimal nLimiteMeses = 6.0M;
            decimal nProbabilidadBono = decimal.Zero;


            this.nBonoTotal = this.lstGrupoSolidarioBono.Sum(x => x.nBono);
            this.nMaxAtraso = this.lstGrupoSolidarioBono.Max(x => x.nAtrasoMaximo);
            this.nPromedioAtraso = (decimal)this.lstGrupoSolidarioBono.Average(x => x.nAtrasoMaximo);
            this.nPromedioMeses = (decimal)this.lstGrupoSolidarioBono.Average(x => x.nMesesCancelacion);

            this.nudBonoTotal.Value = this.nBonoTotal;
            this.nudMaxAtraso.Value = this.nMaxAtraso;
            this.nudPromedioAtraso.Value = this.nPromedioAtraso;
            this.nudPromedioMeses.Value = this.nPromedioMeses;

            this.nPromedioAtraso = (this.nPromedioAtraso>3)? 3.0M:this.nPromedioAtraso;
            this.nPromedioMeses = (this.nPromedioMeses > 6) ? 6.0M : this.nPromedioMeses;

            this.nPromedioAtraso = this.nPromedioAtraso / nLimiteAtraso;
            this.nPromedioMeses = this.nPromedioMeses / nLimiteMeses;

            this.nPromedioAtraso = (this.nMaxAtraso > 3) ? this.nudPromedioAtraso.Value : this.nPromedioAtraso;

            nProbabilidadBono =  100M * (this.nPromedioMeses / ((this.nPromedioAtraso == decimal.Zero) ? 1 : this.nPromedioAtraso));
            if (nProbabilidadBono < decimal.Zero)
            {
                nProbabilidadBono = decimal.Zero;
            }
            else if (nProbabilidadBono > 100M)
            {
                nProbabilidadBono = 100M;
            }

            this.nudProbabilidadBono.Value = nProbabilidadBono;
            this.pgbProbabilidadBono.Value = (int)nProbabilidadBono;
            this.pgbProbabilidadBono.Refresh();

            this.lblMensaje.Text = (this.nMaxAtraso > 3 || this.lstGrupoSolidarioBono.Min(x=>x.nMesesCancelacion) < 6) ?
                "*Las filas marcadas en ROJO o NARANJA no cumplen las condiciones de bonificación." :
                string.Empty;
        }
        private void grabarAprobacionSolicitud()
        {
            clsRespuestaServidor objRespuestaServidor = this.objCNAprobacion.grabarAprobacionSolicitud(
                (int)AprobacionSolicitudTipo.BonoGrupoSolidario,
                this.idSolicitudCredGrupoSol,
                1,//Canal de aprobación de excepciones de bono de grupo solidario
                this.lstGrupoSolidarioBono.Find(x=>x.idGrupoSolidarioCargo == (int)GrupoSolidarioCargo.Presidente).idCli,
                this.nudBonoTotal.Value.ToString(),
                this.nudBonoTotal.Value,
                this.txtJustificacion.Text
                );

            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "RESULTADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFechaSolicitud.Text = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                this.txtEstado.Text = "REGISTRADO";
                this.habilitarControles(clsAcciones.GRABAR);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void obtenerAprobacionSolicitud()
        {
            this.objAprobacionSolicitud = this.objCNAprobacion.obtenerAprobacionSolicitud((int)AprobacionSolicitudTipo.BonoGrupoSolidario, this.idSolicitudCredGrupoSol);
            if (this.objAprobacionSolicitud.idAprobacionSolicitud > 0)
            {
                this.txtJustificacion.Text = this.objAprobacionSolicitud.cSustento;
                this.txtFechaSolicitud.Text = this.objAprobacionSolicitud.dFecha.ToString("dd/MM/yyyy");
                this.txtEstado.Text = this.objAprobacionSolicitud.cEstado;

                if (this.objAprobacionSolicitud.idEstado == (int)Estado.APROBADO)
                {
                    this.lblMensaje.Text = "";
                }

                this.habilitarControles(clsAcciones.GRABAR);
            }
            else
            {
                this.txtEstado.Text = "SIN SOLICITUD";
            }
        }
        public void colorearGrupoSolidarioBono()
        {
            foreach (DataGridViewRow dtgRow in this.dtgBonoEstimado.Rows)
            {
                clsGrupoSolidarioBono objBono = (clsGrupoSolidarioBono)dtgRow.DataBoundItem;

                if(objBono.lEntregado)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.SkyBlue;
                    this.sstFormularioNombre.BackColor = Color.SkyBlue;
                }
                else if (objBono.lExcepcionado)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.YellowGreen;
                    this.sstFormularioNombre.BackColor = Color.Green;
                }
                else if (objBono.nAtrasoMaximo > 3)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.OrangeRed;
                    this.sstFormularioNombre.BackColor = Color.OrangeRed;
                }
                else if (objBono.nMesesCancelacion < 6)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.Orange;
                    this.sstFormularioNombre.BackColor = Color.Orange;
                }
                
            }
        }
        #endregion        
        #region Eventos
        private void frmGrupoSolidarioBono_Shown(object sender, EventArgs e)
        {
            if (this.idGrupoSolidario == -1)
            {
                MessageBox.Show("Los datos de la solicitud de crédito de grupo solidario no se han recuperado correctamente.\n"+
                "* Se cerrará el formulario, ¡comuníquese con el Departamento de Gestión de Sistemas y Aplicaciones!", "SOLICITUD DE CREDITO DE GRUPO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            else if (this.idGrupoSolidario > 0)
            {
                this.listarGrupoSolidarioBonoEstimado();
                this.habilitarControles(clsAcciones.REVISAR);
            }
        }
        private void conBusGrupoSol_ClicBuscar(object sender, EventArgs e)
        {
            this.idGrupoSolidario = this.conBusGrupoSol.idGrupoSolidario;
            this.limpiarControles(false);
            if (!this.conBusGrupoSol.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", "RESULTADO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.conBusGrupoSol.LimpiarControl();
                return;
            }
            
            this.listarGrupoSolidarioBonoEstimado();
        }
        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            this.grabarAprobacionSolicitud();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarControles();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

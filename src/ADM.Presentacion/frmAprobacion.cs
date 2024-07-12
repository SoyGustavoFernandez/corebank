using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ADM.CapaNegocio;
using CRE.Presentacion;
using EntityLayer;
using GEN.ControlesBase;

namespace ADM.Presentacion
{
    public partial class frmAprobacion : frmBase
    {
        #region Variables Globales
        private clsCNAprobacion objCNAprobacion;
        private List<clsAprobacionSolicitud> lstAprobacionSolicitud;
        private clsAprobacionSolicitud objAprobacionSolicitud; 
        private BindingSource bsAprobacionSolicitud;

        private int nIndiceFila;
        private bool lSolicitudRevisada;
        #endregion
        public frmAprobacion()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNAprobacion = new clsCNAprobacion();
            this.lstAprobacionSolicitud = new List<clsAprobacionSolicitud>();
            this.objAprobacionSolicitud = new clsAprobacionSolicitud();
            this.bsAprobacionSolicitud = new BindingSource();

            this.bsAprobacionSolicitud.DataSource = this.lstAprobacionSolicitud;
            this.dtgAprobacionSolicitud.DataSource = this.bsAprobacionSolicitud;

            this.nIndiceFila = -1;
            this.lSolicitudRevisada = false;

            this.formatearAprobacionSolicitud();
            this.habilitarControles(clsAcciones.DEFECTO);
        }
        private void formatearAprobacionSolicitud()
        {
            foreach (DataGridViewColumn dgvColumn in this.dtgAprobacionSolicitud.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            this.dtgAprobacionSolicitud.Columns["cAprobacionSolicitudTipo"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["idRegistro"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cEstado"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cEtapa"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cAprobacionCanal"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cEstablecimiento"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cClienteBeneficiario"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cUsuarioSolicitante"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["nMonto"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["dFecha"].Visible = true;
            this.dtgAprobacionSolicitud.Columns["cSustento"].Visible = true;

            int i = 0;
            this.dtgAprobacionSolicitud.Columns["cAprobacionSolicitudTipo"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["idRegistro"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cClienteBeneficiario"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cUsuarioSolicitante"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["nMonto"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["dFecha"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cEstado"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cEtapa"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cAprobacionCanal"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cEstablecimiento"].DisplayIndex = i++;
            this.dtgAprobacionSolicitud.Columns["cSustento"].DisplayIndex = i++;

            this.dtgAprobacionSolicitud.Columns["cAprobacionSolicitudTipo"].HeaderText = "Tipo Solicitud";
            this.dtgAprobacionSolicitud.Columns["idRegistro"].HeaderText = "Registro";
            this.dtgAprobacionSolicitud.Columns["cEstado"].HeaderText = "Estado";
            this.dtgAprobacionSolicitud.Columns["cEtapa"].HeaderText = "Etapa";
            this.dtgAprobacionSolicitud.Columns["cAprobacionCanal"].HeaderText = "Canal";
            this.dtgAprobacionSolicitud.Columns["cEstablecimiento"].HeaderText = "Establecimiento";
            this.dtgAprobacionSolicitud.Columns["cClienteBeneficiario"].HeaderText = "Cliente";
            this.dtgAprobacionSolicitud.Columns["cUsuarioSolicitante"].HeaderText = "Solicitante";
            this.dtgAprobacionSolicitud.Columns["nMonto"].HeaderText = "Monto";
            this.dtgAprobacionSolicitud.Columns["dFecha"].HeaderText = "Fecha Sol.";
            this.dtgAprobacionSolicitud.Columns["cSustento"].HeaderText = "Sustento";


            this.dtgAprobacionSolicitud.Columns["nMonto"].DefaultCellStyle.Format = "###,###,##0.00";
            this.dtgAprobacionSolicitud.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    this.btnRevisar.Enabled = false;

                    this.lblComentario.Visible = false;
                    this.txtComentario.Visible = false;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    break;
                case clsAcciones.RECUPERAR:
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    this.btnRevisar.Enabled = true;
                    break;
                case clsAcciones.REVISAR:
                    this.btnAprobar.Enabled = true;
                    this.btnDenegar.Enabled = true;
                    this.btnRevisar.Enabled = false;

                    this.lblComentario.Visible = true;
                    this.txtComentario.Visible = true;
                    this.btnAprobar.Visible = true;
                    this.btnDenegar.Visible = true;
                    break;
                case clsAcciones.SELECCIONAR:
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    this.btnRevisar.Enabled = true;

                    this.lblComentario.Visible = false;
                    this.txtComentario.Visible = false;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    break;
                case clsAcciones.GRABAR:
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    this.btnRevisar.Enabled = (this.lstAprobacionSolicitud.Count>0);

                    this.lblComentario.Visible = false;
                    this.txtComentario.Visible = false;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    break;

            }
        }
        private void limpiarControles()
        {
            this.txtComentario.Text = string.Empty;
        }
        private void listarAprobacionSolicitud()
        {
            this.lstAprobacionSolicitud.Clear();
            this.lstAprobacionSolicitud.AddRange(this.objCNAprobacion.listarAprobacionSolicitud());
            if (this.lstAprobacionSolicitud.Count > 0)
            {
                this.habilitarControles(clsAcciones.RECUPERAR);
            }
            this.bsAprobacionSolicitud.ResetBindings(false);
            this.dtgAprobacionSolicitud.Refresh();
        }
        private void gestionarRevision()
        {
            switch ((AprobacionSolicitudTipo)this.objAprobacionSolicitud.idAprobacionSolicitudTipo)
            {
                //Se comenta por el pase de Horarios para el comite, por que los pases estan amarrados y este cambio es para Bonos
                //case AprobacionSolicitudTipo.BonoGrupoSolidario:
                //    frmGrupoSolidarioBono objFrmGrupoSolidarioBono = new frmGrupoSolidarioBono(this.objAprobacionSolicitud.idRegistro);
                //    objFrmGrupoSolidarioBono.ShowDialog();
                //    this.lSolicitudRevisada = true;
                //    break;
                case AprobacionSolicitudTipo.TiempoComiteCredito:
                    frmComiteCreditoTiempoAdicional objFrmComiteCredTiempo = new frmComiteCreditoTiempoAdicional(this.objAprobacionSolicitud.idRegistro, true);
                    objFrmComiteCredTiempo.ShowDialog();
                    this.lSolicitudRevisada = true;
                    break;
            }

            if (this.lSolicitudRevisada)
            {
                this.habilitarControles(clsAcciones.REVISAR);
            }
        }
        private void gestionarAprobacionBasica()
        {
            clsAprobacionGestion objAprobacionGestion = this.objCNAprobacion.gestionarAprobacionBasica(
                this.objAprobacionSolicitud.idAprobacionNivel,
                this.objAprobacionSolicitud.idAprobacionCanal
                );

            if (objAprobacionGestion.idResultado == ResultadoServidor.Correcto)
            {
                DialogResult idResultado = MessageBox.Show(objAprobacionGestion.cMensaje, objAprobacionGestion.cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (idResultado == DialogResult.Yes)
                {
                    this.grabarResolucionAprobacion(
                        objAprobacionGestion.idAprobacionNivel,
                        objAprobacionGestion.idEtapa,
                        objAprobacionGestion.idEstado,
                        this.txtComentario.Text
                        );
                }
            }
            else
            {
                MessageBox.Show(objAprobacionGestion.cMensaje, objAprobacionGestion.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grabarResolucionAprobacion(int idAprobacionNivel, int idEtapa, int idEstado, string cComentario)
        {
            clsRespuestaServidor objRespuestaServidor = this.objCNAprobacion.grabarResolucionAprobacion(
                this.objAprobacionSolicitud.idAprobacionSolicitud,
                this.objAprobacionSolicitud.idAprobacionSolicitudTipo,
                this.objAprobacionSolicitud.idRegistro,
                idEstado,
                idEtapa,
                this.objAprobacionSolicitud.idAprobacionNivel,
                idAprobacionNivel,
                this.objAprobacionSolicitud.idAprobacionCanal,
                this.objAprobacionSolicitud.idEstablecimiento,
                this.objAprobacionSolicitud.idClienteBeneficiario,
                this.objAprobacionSolicitud.idUsuarioSolicitante,
                clsVarGlobal.User.idUsuario,
                this.objAprobacionSolicitud.nMonto,
                clsVarGlobal.dFecSystem,
                this.txtComentario.Text
                );

            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.lstAprobacionSolicitud.RemoveAt(this.nIndiceFila);
                this.bsAprobacionSolicitud.ResetBindings(false);
                this.dtgAprobacionSolicitud.Refresh();

                this.habilitarControles(clsAcciones.GRABAR);
                this.limpiarControles();
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion       
        #region Eventos
        private void frmAprobacion_Shown(object sender, EventArgs e)
        {
            this.listarAprobacionSolicitud();
        }
        private void dtgAprobacionSolicitud_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAprobacionSolicitud.SelectedRows.Count == 0) { this.nIndiceFila = -1; return; }
            this.lSolicitudRevisada = false;
            this.nIndiceFila = this.dtgAprobacionSolicitud.SelectedRows[0].Index;
            this.objAprobacionSolicitud = lstAprobacionSolicitud[this.nIndiceFila];

            this.habilitarControles(clsAcciones.SELECCIONAR);
        }
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.gestionarRevision();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            this.gestionarAprobacionBasica();
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            this.grabarResolucionAprobacion(
                this.objAprobacionSolicitud.idAprobacionNivel,
                (int)Etapa.RESOLUCION,
                (int)Estado.DENEGADO,
                this.txtComentario.Text
                );
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

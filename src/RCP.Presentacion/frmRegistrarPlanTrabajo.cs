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
using EntityLayer;
using RCP.CapaNegocio;
using GEN.Funciones;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
#endregion

namespace RCP.Presentacion
{
    public partial class frmRegistrarPlanTrabajo : frmBase
    {
        #region Variables 

        private clsPlanTrabajoRecuperacion objPlanTrabajoRecuperacion { get; set; }
        private clsPlanTrabajoRecuperacion objPlanTrabajoRecuperacionRevisor { get; set; }
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }

        private List<clsPlanTrabajoObjetivo> lstObjetivoGeneral { get; set; }
        private BindingSource bsObjetivoGeneral { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoEspecifico { get; set; }
        private BindingSource bsObjetivoEspecifico { get; set; }
        private List<clsPlanTrabajoDetalleAccion> lstDetalleAccion { get; set; }
        private BindingSource bsDetalleAccion { get; set; }
        private List<clsPlanTrabajoZonaVisita> lstZonaVisita { get; set; }
        private BindingSource bsZonaVisita { get; set; }
        private clsFlujoPlanTrabajoRecuperacion objFlujoPlanTrabajoActual { get; set; }
        private DataTable dtDatosUsuarioZona { get; set; }
        private List<clsDatosCreditoClientePlanTrabajo> lstDatosClientePlanTrabajo { get; set; }
        private List<clsResumenObjetivoSemana> lstResumenObjetivoSemana { get; set; }

        private int idUsuarioPlanTrabajo { get; set; }
        private int idUsuarioRevisionPlanTrabajo { get; set; }

        private RolFormularioUsuario eRolActivo { get; set; }
        private int nDiasDisponibles { get; set; }
        private bool lEdicion { get; set; }
        #endregion

        public frmRegistrarPlanTrabajo()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmRegistrarPlanTrabajo_Load(object sender, EventArgs e)
        {
            cargarDatosPorDefecto();
            cargarDatosPlanTrabajo();
            formatearGrid();
            validarDias();
        }
        private void conBusColaborador_BuscarUsuario(object sender, EventArgs e)
        {
            int idUsuarioBusqueda = Convert.ToInt32(conBusColaborador.idUsu);
            idUsuarioBusqueda = (idUsuarioBusqueda == 0) ? clsVarGlobal.User.idUsuario : idUsuarioBusqueda;
            objFlujoPlanTrabajoActual = objCNPlanTrabajo.CNListarPlanTrabajoElaborador(idUsuarioBusqueda);

            if (objFlujoPlanTrabajoActual.idPlanTrabajoRecuperacion != 0)
            {
                cargarDatosPlanTrabajo();
            }
            else
            {
                limpiar();
                if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                }
                else
                {
                    activarControles(AccionFormulario.REV_DEFECTO);
                }
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtDetallePlanTrabajo = objCNPlanTrabajo.CNObtenerPlanTrabajoDetalle(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
            DataTable dtResumenPlanTrabajo = objCNPlanTrabajo.CNObtenerResumenPlanTrabajo(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
            DataTable dtVistoBueno = objCNPlanTrabajo.CNObtenerPlanTrabajoVistoBueno(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));


            dtslist.Add(new ReportDataSource("dsResumenPlanTrabajo", dtResumenPlanTrabajo));
            dtslist.Add(new ReportDataSource("dsDetallePlanTrabajo", dtDetallePlanTrabajo));
            dtslist.Add(new ReportDataSource("dsFirmaPlanTrabajo", dtVistoBueno));


            string reportpath = "rptPlanTrabajoRecuperacion.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(!Validar())
            {
                return;
            }

            if(eRolActivo == RolFormularioUsuario.ELABORADOR)
            {
                activarControles(AccionFormulario.ELB_GRABADO);
            }
            else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                activarControles(AccionFormulario.ELBREV_GRABADO);
            }
            else
            {
                activarControles(AccionFormulario.REV_GRABADO);
            }
            lEdicion = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                activarControles(AccionFormulario.ELBREV_EDITADO);
            }
            else
            {
                if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.PRESOLICITADO || objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.RECHAZADO)
                {
                    activarControles(AccionFormulario.ELB_EDITADO);
                }
            }
            lEdicion = true;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (eRolActivo == RolFormularioUsuario.ELABORADOR)
            {
                if (lEdicion == true)
                {
                    cargarDatosPlanTrabajo();
                    activarControles(AccionFormulario.ELB_RECUPERADO);
                }
                else
                {
                    limpiar();
                    cargarDatosPlanTrabajo();
                    activarControles(AccionFormulario.ELB_DEFECTO);
                }
            }
            else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                if(lEdicion == true)
                {
                    cargarDatosPlanTrabajo();
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
                else
                {
                    limpiar();
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                }
            }
            else
            {
                limpiar();
                activarControles(AccionFormulario.REV_DEFECTO);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(!Validar())
            {
                return;
            }
            
            DataTable dtResultado = new DataTable();
            dtResultado = objCNPlanTrabajo.CNEnviarPlanTrabajoRecuperacion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);
            
            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if(eRolActivo == RolFormularioUsuario.ELABORADOR)
                {
                    activarControles(AccionFormulario.ELB_SOLICITADO);
                }
                else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELB_SOLICITADO);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                {
                    activarControles(AccionFormulario.ELB_GRABADO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_GRABADO);
                }
                
            }
        }
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();
            dtResultado = objCNPlanTrabajo.CNAprobarPlanTrabajoRecuperacion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RESUELTO);
                }
                else if(eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RESUELTO);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if(eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RECUPERADO);
                }
                else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
                
            }
        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();
            dtResultado = objCNPlanTrabajo.CNDenegarPlanTrabajoRecuperacion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if (eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RESUELTO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RESUELTO);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RECUPERADO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
            }
        }
        private void btnListarSolicitud_Click(object sender, EventArgs e)
        {
            frmPlanTrabajoListaSolicitud frmPlanTrabajoSolicitud = new frmPlanTrabajoListaSolicitud();
            frmPlanTrabajoSolicitud.ShowDialog();

            objFlujoPlanTrabajoActual = frmPlanTrabajoSolicitud.objPlanTrabajoSolicitud;
            if(objFlujoPlanTrabajoActual.idPlanTrabajoRecuperacion != 0)
            {
                
                if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
                else if(eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RECUPERADO);
                }
                cargarDatosPlanTrabajo();
                formatearGrid();
            }
            else
            {
                formatearGrid();
                activarControles(AccionFormulario.REV_DEFECTO);
                if(eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_DEFECTO);
                }
                else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DialogResult drRespuesta = MessageBox.Show("¿Está seguro que desea comenzar a registrar el plan de trabajo del presente mes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drRespuesta == DialogResult.No)
            {
                return;
            }

            DataTable dtResultado = objCNPlanTrabajo.CNRegistrarPlanTrabajoRecuperacion(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);

            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                {
                    int idPlanTrabajoNuevo = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajo"]);
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objPlanTrabajoRecuperacion = (idPlanTrabajoNuevo != 0) ? objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacionCompleto(idPlanTrabajoNuevo) : new clsPlanTrabajoRecuperacion();
                    cargarDatosPlanTrabajo();
                    if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                    {
                        activarControles(AccionFormulario.ELBREV_RECUPERADO);
                    }
                    else if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                    {
                        activarControles(AccionFormulario.ELB_RECUPERADO);
                    }
                    lEdicion = false;
                }
                else
                {
                    objPlanTrabajoRecuperacion = new clsPlanTrabajoRecuperacion();
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                    {
                        activarControles(AccionFormulario.ELBREV_DEFECTO);
                    }
                    else if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                    {
                        activarControles(AccionFormulario.ELB_DEFECTO);
                    }
                    lEdicion = false;
                }

            }
            else
            {
                objPlanTrabajoRecuperacion = new clsPlanTrabajoRecuperacion();
                MessageBox.Show("Ocurrió un error al momento de registrar el plan de trabajo inténtelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnMiniAgregarGeneral_Click(object sender, EventArgs e)
        {
            frmPlanTrabajoObjetivoGeneral frmObjetivoGeneral = new frmPlanTrabajoObjetivoGeneral(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstResumenObjetivoSemana);
            clsPlanTrabajoObjetivo objObjetivoGeneral = new clsPlanTrabajoObjetivo();
            frmObjetivoGeneral.ShowDialog();

            if(frmObjetivoGeneral.objPlanTrabajoObjetivoGeneral.idPlanTrabajoResumenObjetivo != 0)
            {
                objObjetivoGeneral = frmObjetivoGeneral.objPlanTrabajoObjetivoGeneral;
                agregarObjetivoGeneral(objObjetivoGeneral);
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }
        private void btnMiniEditarGeneral_Click(object sender, EventArgs e)
        {
            int nIndex = (dtgObjetivoGeneral.SelectedRows.Count > 0) ? dtgObjetivoGeneral.SelectedRows[0].Index : -1 ;

            if (nIndex != -1)
            {
                frmPlanTrabajoObjetivoGeneral frmObjetivoGeneral = new frmPlanTrabajoObjetivoGeneral( objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstResumenObjetivoSemana);
                clsPlanTrabajoObjetivo objObjetivoGeneral = (clsPlanTrabajoObjetivo)dtgObjetivoGeneral.SelectedRows[0].DataBoundItem;
                frmObjetivoGeneral.cargarDatos(objObjetivoGeneral);
                frmObjetivoGeneral.ShowDialog();

                if (objObjetivoGeneral.idPlanTrabajoObjetivo == frmObjetivoGeneral.objPlanTrabajoObjetivoGeneral.idPlanTrabajoObjetivo)
                {
                    editarObjetivoGeneral(frmObjetivoGeneral.objPlanTrabajoObjetivoGeneral, nIndex);
                }
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }
        private void btnMiniQuitarGeneral_Click(object sender, EventArgs e)
        {
            eliminarObjetivoGeneral();
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }

        private void btnMiniAgregarEspecifico_Click(object sender, EventArgs e)
        {
            frmPlanTrabajoObjetivoEspecifico frmObjetivoEspecifico  = new frmPlanTrabajoObjetivoEspecifico(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoGeneral, idUsuarioPlanTrabajo, (int)eRolActivo);
            clsPlanTrabajoObjetivo objObjetivoEspecifico            = new clsPlanTrabajoObjetivo();
            clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion = new clsPlanTrabajoDetalleAccion();
            clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita       = new clsPlanTrabajoZonaVisita();
            frmObjetivoEspecifico.ShowDialog();

            if(frmObjetivoEspecifico.objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo != 0)
            {
                objObjetivoEspecifico           = frmObjetivoEspecifico.objPlanTrabajoObjetivoEspecifico;
                objPlanTrabajoDetalleAccion     = frmObjetivoEspecifico.objPlanTrabajoDetalleAccion;
                objPlanTrabajoZonaVisita        = frmObjetivoEspecifico.objPlanTrabajoZonaVisita;
                agregarObjetivoEspecifico(objObjetivoEspecifico, objPlanTrabajoDetalleAccion, objPlanTrabajoZonaVisita);
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();

        }
        private void btnMiniEditarEspecifico_Click(object sender, EventArgs e)
        {
            int nIndex = (dtgObjetivoEspecifico.SelectedRows.Count > 0) ? dtgObjetivoEspecifico.SelectedRows[0].Index : -1 ;

            if(nIndex != -1)
            {
                frmPlanTrabajoObjetivoEspecificoSimple frmObjetivoEspecifico = new frmPlanTrabajoObjetivoEspecificoSimple(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoGeneral);
                clsPlanTrabajoObjetivo objObjetivoEspecifico = (clsPlanTrabajoObjetivo)((clsPlanTrabajoObjetivo)dtgObjetivoEspecifico.SelectedRows[0].DataBoundItem).Clone();
                frmObjetivoEspecifico.cargarDatos(objObjetivoEspecifico);
                frmObjetivoEspecifico.ShowDialog();

                if (objObjetivoEspecifico.idPlanTrabajoObjetivo == frmObjetivoEspecifico.objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo)
                {
                    editarObjetivoEspecifico(frmObjetivoEspecifico.objPlanTrabajoObjetivoEspecifico, nIndex);
                }
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();

        }
        private void btnMiniQuitarEspecifico_Click(object sender, EventArgs e)
        {
            eliminarObjetivoEspecifico();
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }

        private void btnMiniAgregarAccion_Click(object sender, EventArgs e)
        {
            frmPlanTrabajoDetalleAccion frmDetalleAccion = new frmPlanTrabajoDetalleAccion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, idUsuarioPlanTrabajo, idUsuarioRevisionPlanTrabajo, lstObjetivoGeneral);
            clsPlanTrabajoDetalleAccion objDetalleAccion = new clsPlanTrabajoDetalleAccion();
            frmDetalleAccion.ShowDialog();

            if(frmDetalleAccion.objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion != 0)
            {
                objDetalleAccion = frmDetalleAccion.objPlanTrabajoDetalleAccion;
                agregarDetalleAccion(objDetalleAccion);
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }
        private void btnMiniEditarAccion_Click(object sender, EventArgs e)
        {
            int nIndex = (dtgDetalleAccion.SelectedRows.Count > 0) ? dtgDetalleAccion.SelectedRows[0].Index : -1 ;

            if(nIndex != -1)
            {
                frmPlanTrabajoDetalleAccion frmDetalleAccion = new frmPlanTrabajoDetalleAccion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, idUsuarioPlanTrabajo, idUsuarioRevisionPlanTrabajo, lstObjetivoGeneral);
                clsPlanTrabajoDetalleAccion objDetalleAccion = (clsPlanTrabajoDetalleAccion)((clsPlanTrabajoDetalleAccion)dtgDetalleAccion.SelectedRows[0].DataBoundItem).Clone();
                objDetalleAccion.lstDatosCreditoCliente = lstDatosClientePlanTrabajo.Where(item => item.idPlanTrabajoDetalleAccion == objDetalleAccion.idPlanTrabajoDetalleAccion).Select( item => (clsDatosCreditoCliente)item).ToList();
                frmDetalleAccion.cargarDatos(objDetalleAccion);
                frmDetalleAccion.ShowDialog();

                if(objDetalleAccion.idPlanTrabajoDetalleAccion == frmDetalleAccion.objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion)
                {
                    editarDetalleAccion(objDetalleAccion, nIndex);
                }
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }
        private void btnMiniQuitarAccion_Click(object sender, EventArgs e)
        {
            eliminarDetalleAccion();
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }


        private void btnMiniAgregarVisita_Click(object sender, EventArgs e)
        {
            frmPlanTrabajoZonaVisita frmPlanTrabajoZonaVisita = new frmPlanTrabajoZonaVisita(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, (int)eRolActivo);
            frmPlanTrabajoZonaVisita.dtDatosUsuarioZona = dtDatosUsuarioZona;
            clsPlanTrabajoZonaVisita objZonaVisita = new clsPlanTrabajoZonaVisita();
            frmPlanTrabajoZonaVisita.ShowDialog();

            if (frmPlanTrabajoZonaVisita.objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita != 0)
            {
                objZonaVisita = frmPlanTrabajoZonaVisita.objPlanTrabajoZonaVisita;
                agregarZonaVisita(objZonaVisita);
            }
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }
        private void btnMiniEditarVisita_Click(object sender, EventArgs e)
        {
            int nIndex = (dtgZonaVisita.SelectedRows.Count > 0) ? dtgZonaVisita.SelectedRows[0].Index : -1 ;

            if(nIndex != -1)
            {
                frmPlanTrabajoZonaVisita frmZonaVisita = new frmPlanTrabajoZonaVisita(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, (int)eRolActivo);
                clsPlanTrabajoZonaVisita objZonaVisita = (clsPlanTrabajoZonaVisita)((clsPlanTrabajoZonaVisita)dtgZonaVisita.SelectedRows[0].DataBoundItem).Clone();
                frmZonaVisita.cargarDatos(objZonaVisita);
                frmZonaVisita.ShowDialog();

                if(objZonaVisita.idPlanTrabajoZonaVisita == frmZonaVisita.objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita)
                {
                    editarZonaVisita(frmZonaVisita.objPlanTrabajoZonaVisita, nIndex);
                }
                objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
            }
        }
        private void btnMiniQuitarVisita_Click(object sender, EventArgs e)
        {
            eliminarZonaVisita();
            objPlanTrabajoRecuperacion = obtenerPlanTrabajoRecuperaciones();
        }

        private void dtgZonaVisita_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIndex = (dtgZonaVisita.SelectedRows.Count > 0) ? dtgZonaVisita.SelectedRows[0].Index : -1;

            if (nIndex != -1)
            {
                frmPlanTrabajoZonaVisita frmZonaVisita = new frmPlanTrabajoZonaVisita(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, (int)eRolActivo, true);
                clsPlanTrabajoZonaVisita objZonaVisita = (clsPlanTrabajoZonaVisita)dtgZonaVisita.SelectedRows[0].DataBoundItem;
                frmZonaVisita.cargarDatos(objZonaVisita);
                frmZonaVisita.ShowDialog();
            }
        }
        private void dtgDetalleAccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIndex = (dtgDetalleAccion.SelectedRows.Count > 0) ? dtgDetalleAccion.SelectedRows[0].Index : -1;

            if (nIndex != -1)
            {
                frmPlanTrabajoDetalleAccion frmDetalleAccion = new frmPlanTrabajoDetalleAccion(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoEspecifico, idUsuarioPlanTrabajo, idUsuarioRevisionPlanTrabajo, lstObjetivoGeneral, true);
                clsPlanTrabajoDetalleAccion objDetalleAccion = (clsPlanTrabajoDetalleAccion)dtgDetalleAccion.SelectedRows[0].DataBoundItem;
                objDetalleAccion.lstDatosCreditoCliente = lstDatosClientePlanTrabajo.Where(item => item.idPlanTrabajoDetalleAccion == objDetalleAccion.idPlanTrabajoDetalleAccion).Select(item => (clsDatosCreditoCliente)item).ToList();
                frmDetalleAccion.cargarDatos(objDetalleAccion);
                frmDetalleAccion.ShowDialog();
            }
        }
        private void dtgObjetivoEspecifico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIndex = (dtgObjetivoEspecifico.SelectedRows.Count > 0) ? dtgObjetivoEspecifico.SelectedRows[0].Index : -1;

            if (nIndex != -1)
            {
                frmPlanTrabajoObjetivoEspecificoSimple frmObjetivoEspecifico = new frmPlanTrabajoObjetivoEspecificoSimple(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstObjetivoGeneral, true);
                clsPlanTrabajoObjetivo objObjetivoEspecifico = (clsPlanTrabajoObjetivo)dtgObjetivoEspecifico.SelectedRows[0].DataBoundItem;
                frmObjetivoEspecifico.cargarDatos(objObjetivoEspecifico);
                frmObjetivoEspecifico.ShowDialog();
            }
        }
        private void dtgObjetivoGeneral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIndex = (dtgObjetivoGeneral.SelectedRows.Count > 0) ? dtgObjetivoGeneral.SelectedRows[0].Index : -1;

            if (nIndex != -1)
            {
                frmPlanTrabajoObjetivoGeneral frmObjetivoGeneral = new frmPlanTrabajoObjetivoGeneral(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, lstResumenObjetivoSemana, true);
                clsPlanTrabajoObjetivo objObjetivoGeneral = (clsPlanTrabajoObjetivo)dtgObjetivoGeneral.SelectedRows[0].DataBoundItem;
                frmObjetivoGeneral.cargarDatos(objObjetivoGeneral);
                frmObjetivoGeneral.ShowDialog();
            }
        }

        #endregion

        #region Metodos

        private void cargarDatosPorDefecto()
        {
            eRolActivo                          = determinarTipoUsuario();
            idUsuarioPlanTrabajo                = (eRolActivo == RolFormularioUsuario.REVISOR) ? 0 : clsVarGlobal.User.idUsuario;
            idUsuarioRevisionPlanTrabajo        = (eRolActivo == RolFormularioUsuario.REVISOR) ? clsVarGlobal.User.idUsuario : 0 ;

            DateTime dInicioMes                 = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFechaInicio.Value                = dInicioMes;
            dtpFechaFin.Value                   = dInicioMes.AddMonths(1).AddDays(-1);
            dtpFechaResolucion.Value            = clsVarGlobal.dFecSystem;
            cboEstadoSolicitud.SelectedIndex    = -1;
            objCNPlanTrabajo                    = new clsCNPlanTrabajo();

            dtDatosUsuarioZona                  = objCNPlanTrabajo.CNObtenerDatosUsuarioZona(idUsuarioPlanTrabajo);

            objPlanTrabajoRecuperacion          = new clsPlanTrabajoRecuperacion();
            objPlanTrabajoRecuperacionRevisor   = new clsPlanTrabajoRecuperacion();
            lstObjetivoGeneral                  = new List<clsPlanTrabajoObjetivo>();
            lstObjetivoEspecifico               = new List<clsPlanTrabajoObjetivo>();
            lstDetalleAccion                    = new List<clsPlanTrabajoDetalleAccion>();
            lstZonaVisita                       = new List<clsPlanTrabajoZonaVisita>();
            lstDatosClientePlanTrabajo          = new List<clsDatosCreditoClientePlanTrabajo>();
            lstResumenObjetivoSemana            = objCNPlanTrabajo.CNObtenerResumenObjetivoSemana();

            objFlujoPlanTrabajoActual            = new clsFlujoPlanTrabajoRecuperacion();

            nDiasDisponibles                    = obtenerDiasDisponibles();

            bsObjetivoGeneral                   = new BindingSource();
            bsObjetivoGeneral.DataSource        = lstObjetivoGeneral;
            dtgObjetivoGeneral.DataSource       = bsObjetivoGeneral;

            bsObjetivoEspecifico                = new BindingSource();
            bsObjetivoEspecifico.DataSource     = lstObjetivoEspecifico;
            dtgObjetivoEspecifico.DataSource    = bsObjetivoEspecifico;

            bsDetalleAccion                     = new BindingSource();
            bsDetalleAccion.DataSource          = lstDetalleAccion;
            dtgDetalleAccion.DataSource         = bsDetalleAccion;

            bsZonaVisita                        = new BindingSource();
            bsZonaVisita.DataSource             = lstZonaVisita;
            dtgZonaVisita.DataSource            = bsZonaVisita;

            lEdicion = false;

            formatearGrid();

        }

        private void cargarDatosPlanTrabajo()
        {
            if(eRolActivo == RolFormularioUsuario.ELABORADOR )
            {
                conBusColaborador.CargarColaboradorxUsuario(clsVarGlobal.User.idUsuario);
                objPlanTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacion(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idAgeCol, clsVarGlobal.dFecSystem);

                if(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    activarControles(AccionFormulario.ELB_DEFECTO);
                    limpiar();
                }
                else
                {
                    clsPlanTrabajoRecuperacion _planTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacionCompleto(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
                    objPlanTrabajoRecuperacion = (_planTrabajoRecuperacion.idPlanTrabajoRecuperacion != 0) ? _planTrabajoRecuperacion : objPlanTrabajoRecuperacion ;
                    lstDatosClientePlanTrabajo = objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo;
                    asignarDatosPlanTrabajo();
                    formatearGrid();
                    if(objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.ELB_APROBADO);
                    }
                    else if(objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.VISTO_BUENO)
                    {
                        activarControles(AccionFormulario.ELB_SOLICITADO);
                    }
                    else if(objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.PRESOLICITADO)
                    {
                        activarControles(AccionFormulario.ELB_RECUPERADO);
                    }
                    else if(objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.RECHAZADO)
                    {
                        activarControles(AccionFormulario.ELB_DEVUELTO);
                    }
                    else
                    {
                        activarControles(AccionFormulario.ELB_DEFECTO);
                    }
                }
            }
            else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                int idUsuarioBusqueda = (objFlujoPlanTrabajoActual.idUsuario != 0) ? objFlujoPlanTrabajoActual.idUsuario : clsVarGlobal.User.idUsuario;
                int idAgenciaBusqueda = (objFlujoPlanTrabajoActual.idAgencia != 0) ? objFlujoPlanTrabajoActual.idAgencia : clsVarGlobal.nIdAgencia ;
                conBusColaborador.CargarColaboradorxUsuario(idUsuarioBusqueda);

                objPlanTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacion(idUsuarioBusqueda, idAgenciaBusqueda, clsVarGlobal.dFecSystem);
                objPlanTrabajoRecuperacionRevisor = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? objPlanTrabajoRecuperacion : new clsPlanTrabajoRecuperacion() ;

                if (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                    limpiar();
                }
                else
                {
                    clsPlanTrabajoRecuperacion _planTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacionCompleto(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
                    objPlanTrabajoRecuperacion = (_planTrabajoRecuperacion.idPlanTrabajoRecuperacion != 0) ? _planTrabajoRecuperacion : objPlanTrabajoRecuperacion;

                    asignarDatosPlanTrabajo();
                    if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.ELBREV_RESUELTO);
                    }
                    else if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.VISTO_BUENO)
                    {
                        activarControles(AccionFormulario.ELBREV_SOLICITADO);
                    }
                    else if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.PRESOLICITADO)
                    {
                        activarControles(AccionFormulario.ELBREV_RECUPERADO);
                    }
                    else if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.RECHAZADO)
                    {
                        activarControles(AccionFormulario.ELBREV_DEVUELTO);
                    }
                    else
                    {
                        activarControles(AccionFormulario.ELBREV_DEFECTO);
                    }
                }
            }
            else if(eRolActivo == RolFormularioUsuario.REVISOR )
            {
                conBusColaborador.CargarColaboradorxUsuario(objFlujoPlanTrabajoActual.idUsuario);

                objPlanTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacion(objFlujoPlanTrabajoActual.idUsuario, objFlujoPlanTrabajoActual.idAgencia, clsVarGlobal.dFecSystem);

                if (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    activarControles(AccionFormulario.REV_DEFECTO);
                    limpiar();
                }
                else
                {
                    clsPlanTrabajoRecuperacion _planTrabajoRecuperacion = objCNPlanTrabajo.CNObtenerPlanTrabajoRecuperacionCompleto(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
                    objPlanTrabajoRecuperacion = (_planTrabajoRecuperacion.idPlanTrabajoRecuperacion != 0) ? _planTrabajoRecuperacion : objPlanTrabajoRecuperacion;

                    asignarDatosPlanTrabajo();
                    if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.REV_RESUELTO);
                    }
                    else if (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.VISTO_BUENO)
                    {
                        activarControles(AccionFormulario.REV_RECUPERADO);
                    }
                    else if(objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.PRESOLICITADO)
                    {
                        MessageBox.Show("El plan de trabajo seleccionado no fue solicitado para su aprobación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        activarControles(AccionFormulario.REV_DEFECTO);
                        limpiar();
                    }
                    else
                    {
                        activarControles(AccionFormulario.REV_DEFECTO);
                    }
                }
            }
        }

        private void activarControles(AccionFormulario eAccionFormulario)
        {

            switch(eAccionFormulario)
            {
                case AccionFormulario.ELB_DEFECTO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = true;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_EDITADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = true;
                    btnMiniEditarGeneral.Enabled        = true;
                    btnMiniQuitarGeneral.Enabled        = true;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = true;
                    btnMiniEditarEspecifico.Enabled     = true;
                    btnMiniQuitarEspecifico.Enabled     = true;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = true;
                    btnMiniEditarAccion.Enabled         = true;
                    btnMiniQuitarAccion.Enabled         = true;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = true;
                    btnMiniEditarVisita.Enabled         = true;
                    btnMiniQuitarVisita.Enabled         = true;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;

                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = true;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELB_GRABADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;

                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = true;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_RECUPERADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = true;
                    btnNuevo.Enabled                    = false;
                    btnGrabar.Enabled                   = false;
                    btnEditar.Enabled                   = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? false : true ;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_SOLICITADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_DEVUELTO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = true;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_APROBADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnEnviar.Enabled                   = false;
                    btnImprimir.Enabled                 = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELB_RESUELTO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;

                case AccionFormulario.ELBREV_DEFECTO:
                    #region
                    conBusColaborador.Enabled           = true;
                    conBusColaborador.HabilitarControles(true);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = true;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = (objPlanTrabajoRecuperacionRevisor.idPlanTrabajoRecuperacion == 0) ? true: false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_RECUPERADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnAprobar.Visible                  = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnRechazar.Enabled                 = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnRechazar.Visible                 = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? true : false;
                    btnEnviar.Visible                   = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? true : false;
                    btnNuevo.Enabled                    = false;
                    btnGrabar.Enabled                   = false;
                    btnEditar.Enabled                   = ( (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.SOLICITADO || 
                                                            objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO ||
                                                            objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.VISTO_BUENO) &&
                                                            objPlanTrabajoRecuperacion.idUsuario != clsVarGlobal.User.idUsuario) ? false : true ;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_EDITADO:
                    #region 
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = true;
                    btnMiniEditarGeneral.Enabled        = true;
                    btnMiniQuitarGeneral.Enabled        = true;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = true;
                    btnMiniEditarEspecifico.Enabled     = true;
                    btnMiniQuitarEspecifico.Enabled     = true;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = true;
                    btnMiniEditarAccion.Enabled         = true;
                    btnMiniQuitarAccion.Enabled         = true;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = true;
                    btnMiniEditarVisita.Enabled         = true;
                    btnMiniQuitarVisita.Enabled         = true;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;

                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = true;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_GRABADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;

                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = true;
                    btnEnviar.Visible                   = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = true;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_SOLICITADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnAprobar.Visible                  = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnRechazar.Enabled                 = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnRechazar.Visible                 = (objPlanTrabajoRecuperacion.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_APROBADO:
                    #region 
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnEnviar.Enabled                   = false;
                    btnImprimir.Enabled                 = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_DEVUELTO:
                    #region 
                    conBusColaborador.Enabled           = false;
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible          = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = true;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = true;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_RESUELTO:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_PENDIENTE:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;


                case AccionFormulario.REV_DEFECTO:
                    #region
                    conBusColaborador.Enabled           = true;
                    conBusColaborador.HabilitarControles(true);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = true;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
                case AccionFormulario.REV_RECUPERADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = true;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = true;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.REV_EDITADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = true;
                    btnMiniEditarGeneral.Enabled        = true;
                    btnMiniQuitarGeneral.Enabled        = true;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = true;
                    btnMiniEditarEspecifico.Enabled     = true;
                    btnMiniQuitarEspecifico.Enabled     = true;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = true;
                    btnMiniEditarAccion.Enabled         = true;
                    btnMiniQuitarAccion.Enabled         = true;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = true;
                    btnMiniEditarVisita.Enabled         = true;
                    btnMiniQuitarVisita.Enabled         = true;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = true;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.REV_GRABADO:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = true;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = true;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.REV_RESUELTO:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = true;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                case AccionFormulario.REV_PENDIENTE:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = true;
                    lblFechaResolucion.Visible          = true;

                    dtgObjetivoGeneral.Enabled          = true;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = true;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = true;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = true;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = true;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = true;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = true;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = true;
                    #endregion
                    break;
                default:
                    #region
                    conBusColaborador.Enabled           = false;
                    conBusColaborador.HabilitarControles(false);
                    cboEstadoSolicitud.Enabled          = false;
                    dtpFechaInicio.Enabled              = false;
                    dtpFechaFin.Enabled                 = false;
                    dtpFechaResolucion.Enabled          = false;
                    dtpFechaResolucion.Visible          = false;
                    lblFechaResolucion.Visible          = false;

                    dtgObjetivoGeneral.Enabled          = false;
                    btnMiniAgregarGeneral.Enabled       = false;
                    btnMiniEditarGeneral.Enabled        = false;
                    btnMiniQuitarGeneral.Enabled        = false;

                    dtgObjetivoEspecifico.Enabled       = false;
                    btnMiniAgregarEspecifico.Enabled    = false;
                    btnMiniEditarEspecifico.Enabled     = false;
                    btnMiniQuitarEspecifico.Enabled     = false;

                    dtgDetalleAccion.Enabled            = false;
                    btnMiniAgregarAccion.Enabled        = false;
                    btnMiniEditarAccion.Enabled         = false;
                    btnMiniQuitarAccion.Enabled         = false;

                    dtgZonaVisita.Enabled               = false;
                    btnMiniAgregarVisita.Enabled        = false;
                    btnMiniEditarVisita.Enabled         = false;
                    btnMiniQuitarVisita.Enabled         = false;

                    btnListarSolicitud.Enabled          = false;
                    btnListarSolicitud.Visible          = false;
                    btnAprobar.Enabled                  = false;
                    btnAprobar.Visible                  = false;
                    btnRechazar.Enabled                 = false;
                    btnRechazar.Visible                 = false;
                    btnImprimir.Enabled                 = false;
                    btnEnviar.Enabled                   = false;
                    btnEnviar.Visible                   = false;
                    btnGrabar.Enabled                   = false;
                    btnNuevo.Enabled                    = false;
                    btnEditar.Enabled                   = false;
                    btnCancelar.Enabled                 = false;
                    #endregion
                    break;
            }
        }

        private RolFormularioUsuario determinarTipoUsuario()
        {
            clsVarGen varGenElaborador          = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilElaboradorPlanTrabajo"));
            clsVarGen varGenElaboradorRevisor   = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilElaboradorRevisorPlanTrabajo"));
            clsVarGen varGenRevisor             = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilRevisorPlanTrabajo"));

            List<int> lstPerfilRevisorPermitidos = varGenRevisor.cValVar.Split(',').Select(Int32.Parse).ToList();
            List<int> lstPerfilElaboradorRevisorPermitidos = varGenElaboradorRevisor.cValVar.Split(',').Select(Int32.Parse).ToList();
            List<int> lstPerfilElaboradorPermitidos = varGenElaborador.cValVar.Split(',').Select(Int32.Parse).ToList();

            int idPerfilElaboradorPermitido = lstPerfilElaboradorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);
            int idPerfilRevisorPermitido =  lstPerfilRevisorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);
            int idPerfilElaboradorRevisorPermitido = lstPerfilElaboradorRevisorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);

            if (idPerfilElaboradorRevisorPermitido != 0)
                return RolFormularioUsuario.ELABORADOR_REVISOR;
            else if (idPerfilRevisorPermitido != 0)
                return RolFormularioUsuario.REVISOR;
            else if (idPerfilElaboradorPermitido != 0)
                return RolFormularioUsuario.ELABORADOR;
            else
                return RolFormularioUsuario.ELABORADOR;
        }
        private void asignarDatosPlanTrabajo()
        {

            cboEstadoSolicitud.SelectedValue    = objPlanTrabajoRecuperacion.idEstado;
            dtpFechaInicio.Value                = objPlanTrabajoRecuperacion.dFechaInicio;
            dtpFechaFin.Value                   = objPlanTrabajoRecuperacion.dFechaFin;
            dtpFechaResolucion.Value            = (objPlanTrabajoRecuperacion.idEstado == (int)EstadoSolicitud.APROBADO) ? objPlanTrabajoRecuperacion.dFechaResolucion : clsVarGlobal.dFecSystem ;

            asignarObjetivoGeneral();
            asignarObjetivoEspecifico();
            asignarDetalleAccion();
            asignarZonaVisita();

        }

        private void asignarObjetivoGeneral()
        {
            lstObjetivoGeneral = new List<clsPlanTrabajoObjetivo>();
            lstObjetivoGeneral.AddRange(objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral);
            bsObjetivoGeneral.DataSource    = lstObjetivoGeneral;
            dtgObjetivoGeneral.DataSource   = bsObjetivoGeneral;
            bsObjetivoGeneral.ResetBindings(false);
            formatearGridObjetivosGeneral();
            dtgObjetivoGeneral.Refresh();
        }

        private void asignarObjetivoEspecifico()
        {
            lstObjetivoEspecifico = new List<clsPlanTrabajoObjetivo>();
            lstObjetivoEspecifico.AddRange(objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico);
            bsObjetivoEspecifico.DataSource     = lstObjetivoEspecifico;
            dtgObjetivoEspecifico.DataSource    = bsObjetivoEspecifico;
            bsObjetivoEspecifico.ResetBindings(false);
            formatearGridObjetivoEspecifico();
            dtgObjetivoEspecifico.Refresh();
        }

        private void asignarDetalleAccion()
        {
            lstDetalleAccion = new List<clsPlanTrabajoDetalleAccion>();
            lstDetalleAccion.AddRange(objPlanTrabajoRecuperacion.lstPlanTrabajoAccion);
            bsDetalleAccion.DataSource      = lstDetalleAccion;
            dtgDetalleAccion.DataSource     = bsDetalleAccion;
            bsDetalleAccion.ResetBindings(true);
            formatearGridDetalleAccion();
            dtgDetalleAccion.Refresh();
        }

        private void asignarZonaVisita()
        {
            lstZonaVisita = new List<clsPlanTrabajoZonaVisita>();
            lstZonaVisita.AddRange(objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita);
            bsZonaVisita.DataSource     = lstZonaVisita;
            dtgZonaVisita.DataSource    = bsZonaVisita.DataSource;
            bsZonaVisita.ResetBindings(false);
            formatearGridZonaVisita();
            dtgZonaVisita.Refresh();
        }

        private int obtenerDiasDisponibles()
        {
            clsVarGen varDiasDisponibles = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("nDiasPlazoPlanTrabajo"));

            return Convert.ToInt32(varDiasDisponibles.cValVar);
        }
        private clsPlanTrabajoRecuperacion obtenerPlanTrabajoRecuperaciones()
        {
            objPlanTrabajoRecuperacion.idUsuario                           = (objPlanTrabajoRecuperacion.idUsuario == 0) ? clsVarGlobal.User.idUsuario : objPlanTrabajoRecuperacion.idUsuario ;
            objPlanTrabajoRecuperacion.idPerfil                            = (objPlanTrabajoRecuperacion.idUsuario == 0) ? clsVarGlobal.PerfilUsu.idPerfilUsu : 0;
            objPlanTrabajoRecuperacion.idEstado                            = (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0) ? -1 : Convert.ToInt32(cboEstadoSolicitud.SelectedValue) ;
            objPlanTrabajoRecuperacion.idAgencia                           = (objPlanTrabajoRecuperacion.idAgencia == 0) ? clsVarGlobal.User.idAgeCol : objPlanTrabajoRecuperacion.idAgencia;
            objPlanTrabajoRecuperacion.nAnio                               = clsVarGlobal.dFecSystem.Year;
            objPlanTrabajoRecuperacion.nMes                                = clsVarGlobal.dFecSystem.Month;
            objPlanTrabajoRecuperacion.dFechaInicio                        = dtpFechaInicio.Value;
            objPlanTrabajoRecuperacion.dFechaFin                           = dtpFechaFin.Value;
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral       = lstObjetivoGeneral;
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico    = lstObjetivoEspecifico;
            objPlanTrabajoRecuperacion.lstPlanTrabajoAccion                = lstDetalleAccion;
            objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita            = lstZonaVisita;
            objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo      = lstDatosClientePlanTrabajo;
            return objPlanTrabajoRecuperacion;
        }

        private void limpiar()
        {
            DateTime dInicioMes = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            objPlanTrabajoRecuperacion          = new clsPlanTrabajoRecuperacion();
            objPlanTrabajoRecuperacionRevisor   = new clsPlanTrabajoRecuperacion();
            conBusColaborador.LimpiarDatos();
            cboEstadoSolicitud.Text     = String.Empty;
            dtpFechaInicio.Value        = dInicioMes;
            dtpFechaFin.Value           = dInicioMes.AddMonths(1).AddDays(-1);
            dtpFechaResolucion.Value    = clsVarGlobal.dFecSystem;

            lstObjetivoGeneral.Clear();
            asignarObjetivoGeneral();


            lstObjetivoEspecifico.Clear();
            asignarObjetivoEspecifico();

            lstDetalleAccion.Clear();
            asignarDetalleAccion();

            lstZonaVisita.Clear();
            asignarZonaVisita();

            lstDatosClientePlanTrabajo.Clear();

            idUsuarioPlanTrabajo = 0;
            idUsuarioRevisionPlanTrabajo = 0;

            lEdicion = false;

            if (eRolActivo == RolFormularioUsuario.ELABORADOR)
            {
                conBusColaborador.CargarColaboradorxUsuario(clsVarGlobal.User.idUsuario);
            }
        }
        private bool Validar()
        {
            bool lValida = true;

            if (lstObjetivoGeneral.Count == 0)
            {
                MessageBox.Show("Debe registrar por lo menos un objetivo general", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida = false;
            }

            if (lstObjetivoEspecifico.Count == 0)
            {
                MessageBox.Show("Debe registrar por lo menos un objetivo específico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida = false;
            }

            if (lstDetalleAccion.Count == 0)
            {
                MessageBox.Show("Debe registrar por lo menos un detalle de acción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida = false;
            }

            return lValida;
        }
        private void validarDias()
        {
            int nDiaMaximoRegistro = Convert.ToInt32(clsVarApl.dicVarGen["nDiasPlazoPlanTrabajo"]);
            if ((clsVarGlobal.dFecSystem.Day >= nDiaMaximoRegistro))
            {
                MessageBox.Show("El plazo para el registro del plan de trabajo ha pasado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
        }
        private void formatearGrid()
        {
            formatearGridObjetivosGeneral();
            formatearGridObjetivoEspecifico();
            formatearGridDetalleAccion();
            formatearGridZonaVisita();
        }
        private void formatearGridObjetivosGeneral()
        {
            dtgObjetivoGeneral.ReadOnly = true;

            foreach (DataGridViewColumn dgvColumna in dtgObjetivoGeneral.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgObjetivoGeneral.Columns["cPlanTrabajoResumenObjetivo"].Visible       = true;
            dtgObjetivoGeneral.Columns["cDescripcionPlanTrabajoObjetivo"].Visible   = true;
            dtgObjetivoGeneral.Columns["cObjetivoTipo"].Visible                     = true;
            dtgObjetivoGeneral.Columns["cSemana"].Visible                           = true;

            dtgObjetivoGeneral.Columns["cPlanTrabajoResumenObjetivo"].HeaderText        = "Objetivo";
            dtgObjetivoGeneral.Columns["cDescripcionPlanTrabajoObjetivo"].HeaderText    = "Descripción";
            dtgObjetivoGeneral.Columns["cObjetivoTipo"].HeaderText                      = "Tipo Objetivo";
            dtgObjetivoGeneral.Columns["cSemana"].HeaderText                            = "Semana";

            dtgObjetivoGeneral.Columns["cObjetivoTipo"].Width                           = 65;
            dtgObjetivoGeneral.Columns["cSemana"].Width                                 = 200;
            dtgObjetivoGeneral.Columns["cPlanTrabajoResumenObjetivo"].Width             = 275;
            dtgObjetivoGeneral.Columns["cDescripcionPlanTrabajoObjetivo"].Width         = 275;

            dtgObjetivoGeneral.Columns["cObjetivoTipo"].DisplayIndex                      = 1;
            dtgObjetivoGeneral.Columns["cSemana"].DisplayIndex                            = 2;
            dtgObjetivoGeneral.Columns["cPlanTrabajoResumenObjetivo"].DisplayIndex        = 3;
            dtgObjetivoGeneral.Columns["cDescripcionPlanTrabajoObjetivo"].DisplayIndex    = 4;

        }
        private void formatearGridObjetivoEspecifico()
        {
            dtgObjetivoEspecifico.ReadOnly = true;

            foreach(DataGridViewColumn dgvColumna in dtgObjetivoEspecifico.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgObjetivoEspecifico.Columns["cObjetivoTipo"].Visible                          = true;
            dtgObjetivoEspecifico.Columns["cSemana"].Visible                                = true;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivo"].Visible            = true;
            dtgObjetivoEspecifico.Columns["dFechaEspecifica"].Visible                       = true;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivoPadre"].Visible       = true;
            dtgObjetivoEspecifico.Columns["nDia"].Visible                                   = true;
            dtgObjetivoEspecifico.Columns["cDescripcionPlanTrabajoObjetivo"].Visible        = true;
            
            dtgObjetivoEspecifico.Columns["cObjetivoTipo"].HeaderText                       = "Tipo Objetivo";
            dtgObjetivoEspecifico.Columns["cSemana"].HeaderText                             = "Semana";
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivo"].HeaderText         = "Objetivo Específico";
            dtgObjetivoEspecifico.Columns["dFechaEspecifica"].HeaderText                    = "Fecha Programada";
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivoPadre"].HeaderText    = "Objetivo General";
            dtgObjetivoEspecifico.Columns["nDia"].HeaderText                                = "Día Programado";
            dtgObjetivoEspecifico.Columns["cDescripcionPlanTrabajoObjetivo"].HeaderText     = "Descripción";

            dtgObjetivoEspecifico.Columns["cObjetivoTipo"].DisplayIndex                         = 0;
            dtgObjetivoEspecifico.Columns["cSemana"].DisplayIndex                               = 1;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivo"].DisplayIndex           = 2;
            dtgObjetivoEspecifico.Columns["dFechaEspecifica"].DisplayIndex                      = 3;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivoPadre"].DisplayIndex      = 4;
            dtgObjetivoEspecifico.Columns["nDia"].DisplayIndex                                  = 5;
            dtgObjetivoEspecifico.Columns["cDescripcionPlanTrabajoObjetivo"].DisplayIndex       = 6;

            dtgObjetivoEspecifico.Columns["cObjetivoTipo"].Width                         = 70;
            dtgObjetivoEspecifico.Columns["cSemana"].Width                               = 200;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivo"].Width           = 250;
            dtgObjetivoEspecifico.Columns["dFechaEspecifica"].Width                      = 75;
            dtgObjetivoEspecifico.Columns["cPlanTrabajoResumenObjetivoPadre"].Width      = 275;
            dtgObjetivoEspecifico.Columns["nDia"].Width                                  = 75;
            dtgObjetivoEspecifico.Columns["cDescripcionPlanTrabajoObjetivo"].Width       = 275;
        }
        private void formatearGridDetalleAccion()
        {
            dtgDetalleAccion.ReadOnly = true;

            foreach(DataGridViewColumn dgvColumna in dtgDetalleAccion.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgDetalleAccion.Columns["cPlanTrabajoDetalleAccion"].Visible       = true;
            dtgDetalleAccion.Columns["cPlanTrabajoObjetivo"].Visible            = true;
            dtgDetalleAccion.Columns["cPlanTrabajoAccion"].Visible              = true;
            dtgDetalleAccion.Columns["dFechaAccion"].Visible                    = true;

            dtgDetalleAccion.Columns["cPlanTrabajoDetalleAccion"].HeaderText    = "Descripción";
            dtgDetalleAccion.Columns["cPlanTrabajoObjetivo"].HeaderText         = "Objetivo Específico";
            dtgDetalleAccion.Columns["cPlanTrabajoAccion"].HeaderText           = "Detalle de Acción";
            dtgDetalleAccion.Columns["dFechaAccion"].HeaderText                 = "Fecha de Acción";

            dtgDetalleAccion.Columns["cPlanTrabajoDetalleAccion"].Width         = 275;
            dtgDetalleAccion.Columns["cPlanTrabajoObjetivo"].Width              = 275;
            dtgDetalleAccion.Columns["cPlanTrabajoAccion"].Width                = 120;
            dtgDetalleAccion.Columns["dFechaAccion"].Width                      = 60;

            dtgDetalleAccion.Columns["dFechaAccion"].DisplayIndex                      = 0;
            dtgDetalleAccion.Columns["cPlanTrabajoObjetivo"].DisplayIndex              = 1;
            dtgDetalleAccion.Columns["cPlanTrabajoAccion"].DisplayIndex                = 2;
            dtgDetalleAccion.Columns["cPlanTrabajoDetalleAccion"].DisplayIndex         = 3;

        }
        private void formatearGridZonaVisita()
        {
            dtgZonaVisita.ReadOnly = true;

            foreach(DataGridViewColumn dgvColumna in dtgZonaVisita.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgZonaVisita.Columns["cZona"].Visible                      = true;
            dtgZonaVisita.Columns["cAgencia"].Visible                   = true;
            dtgZonaVisita.Columns["cDescripcionZonaVisita"].Visible     = true;
            dtgZonaVisita.Columns["cDistrito"].Visible                  = true;
            dtgZonaVisita.Columns["dFechaVisita"].Visible               = true;

            dtgZonaVisita.Columns["cZona"].HeaderText                   = "Región";
            dtgZonaVisita.Columns["cAgencia"].HeaderText                = "Agencia";
            dtgZonaVisita.Columns["cDescripcionZonaVisita"].HeaderText  = "Descripción";
            dtgZonaVisita.Columns["cDistrito"].HeaderText               = "Distrito";
            dtgZonaVisita.Columns["dFechaVisita"].HeaderText            = "Fecha de Visita";

            dtgZonaVisita.Columns["dFechaVisita"].Width                 = 75;
            dtgZonaVisita.Columns["cZona"].Width                        = 175;
            dtgZonaVisita.Columns["cAgencia"].Width                     = 175;
            dtgZonaVisita.Columns["cDistrito"].Width                    = 175;
            dtgZonaVisita.Columns["cDescripcionZonaVisita"].Width       = 275;

            dtgZonaVisita.Columns["dFechaVisita"].DisplayIndex              = 0;
            dtgZonaVisita.Columns["cZona"].DisplayIndex                     = 1;
            dtgZonaVisita.Columns["cAgencia"].DisplayIndex                  = 2;
            dtgZonaVisita.Columns["cDistrito"].DisplayIndex                 = 3;
            dtgZonaVisita.Columns["cDescripcionZonaVisita"].DisplayIndex    = 4;
        }

        private void agregarObjetivoGeneral(clsPlanTrabajoObjetivo objPlanTrabajoObjetivoGeneral)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral.Add(objPlanTrabajoObjetivoGeneral);
            asignarObjetivoGeneral();
        }
        private void editarObjetivoGeneral(clsPlanTrabajoObjetivo objPlanTrabajoObjetivoGeneral, int nIndex)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral = objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral.Select(item => { return (item.idPlanTrabajoObjetivo == objPlanTrabajoObjetivoGeneral.idPlanTrabajoObjetivo) ? objPlanTrabajoObjetivoGeneral : item; }).ToList();
            asignarObjetivoGeneral();
        }
        private void eliminarObjetivoGeneral()
        {
            if(dtgObjetivoGeneral.SelectedRows.Count > 0)
            {
                int idPlanTrabajoObjetivoGeneral = ((clsPlanTrabajoObjetivo)(dtgObjetivoGeneral.SelectedRows[0].DataBoundItem)).idPlanTrabajoObjetivo;

                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro y todos los demás asociados a este.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }
                DataTable dtResultado = objCNPlanTrabajo.CNEliminarObjetivoGeneralPlanTrabajo(objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, idPlanTrabajoObjetivoGeneral);
                if(dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral = lstObjetivoGeneral.Where(item => item.idPlanTrabajoObjetivo != idPlanTrabajoObjetivoGeneral).ToList();
                        asignarObjetivoGeneral();

                        List<clsPlanTrabajoObjetivo> lstObjetivoEspecificosEliminados   = objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico.Where(item => item.idPlanTrabajoObjetivoPadre == idPlanTrabajoObjetivoGeneral).ToList();
                        objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico     = objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico.Where(item => item.idPlanTrabajoObjetivoPadre != idPlanTrabajoObjetivoGeneral).ToList();
                        asignarObjetivoEspecifico();
                        objPlanTrabajoRecuperacion.lstPlanTrabajoAccion                 = objPlanTrabajoRecuperacion.lstPlanTrabajoAccion.Where(item => item.idPlanTrabajoObjetivoGeneral != idPlanTrabajoObjetivoGeneral).ToList();
                        asignarDetalleAccion();
                        objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita             = objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita.Where(item => !lstObjetivoEspecificosEliminados.Any(item2 => item2.idPlanTrabajoObjetivo == item.idPlanTrabajoObjetivo)).ToList();
                        asignarZonaVisita();
                        objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo       = objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo.Where(item => item.idPlanTrabajoObjetivoGeneral != idPlanTrabajoObjetivoGeneral).ToList();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["idRegistro"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al tratar de eliminar el objetivo general, intente de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void agregarObjetivoEspecifico(clsPlanTrabajoObjetivo objPlanTrabajoObjetivoEspecifico, clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion, clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico.Add(objPlanTrabajoObjetivoEspecifico);
            asignarObjetivoEspecifico();

            objPlanTrabajoRecuperacion.lstPlanTrabajoAccion.Add(objPlanTrabajoDetalleAccion);
            asignarDetalleAccion();

            objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita.Add(objPlanTrabajoZonaVisita);
            asignarZonaVisita();

            List<clsDatosCreditoCliente> lstCliente = objPlanTrabajoDetalleAccion.lstDatosCreditoCliente;

            List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculado = lstCliente.OfType<clsDatosCreditoCliente>().Select(item => new clsDatosCreditoClientePlanTrabajo
            {
                    idCuenta                            = item.idCuenta,
                    idCliente                           = item.idCliente,
                    idPlanTrabajoRecuperacion           = objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion,
                    idPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                    idPlanTrabajoObjetivoGeneral        = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral,
                    idPlanTrabajoObjetivoEspecifico     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                    dFechaAccion                        = objPlanTrabajoDetalleAccion.dFechaAccion,

                    idEstado                            = item.idEstado,
                    cEstado                             = item.cEstado,
                    cNombre                             = item.cNombre,
                    dFechaDesembolso                    = item.dFechaDesembolso,
                    nFrecuencia                         = item.nFrecuencia,
                    nMonto                              = item.nMonto,
                    nCuotas                             = item.nCuotas,
                    idMoneda                            = item.idMoneda,
                    idProducto                          = item.idProducto,
                    cProducto                           = item.cProducto,
                    nMontoCuota                         = item.nMontoCuota,
                    nAtraso                             = item.nAtraso,
                    cDocumentoID                        = item.cDocumentoID,
                    cDireccion                          = item.cDireccion,
                    cCodCliente                         = item.cCodCliente,
                    cMoneda                             = item.cMoneda,
                    idTipoDocumento                     = item.idTipoDocumento,
                    lCoberturaSegDesg                   = item.lCoberturaSegDesg,
                    lSeleccionado                       = item.lSeleccionado,
                
            }).ToList();
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteFiltrado = lstClienteVinculado.Except(lstDatosClientePlanTrabajo, new clsClientePlanTrabajoComparer()).ToList();
            
            lstDatosClientePlanTrabajo.AddRange(lstClienteFiltrado);
        }
        private void editarObjetivoEspecifico(clsPlanTrabajoObjetivo objPlanTrabajoObjetivoEspecifico, int nIndex)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico = objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico.Select(item => { return (item.idPlanTrabajoObjetivo == objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo) ? objPlanTrabajoObjetivoEspecifico : item; }).ToList();
            asignarObjetivoEspecifico();
        }
        private void eliminarObjetivoEspecifico()
        {
            if(dtgObjetivoEspecifico.SelectedRows.Count > 0)
            {
                int idPlanTrabajoObjetivoEspecifico = ((clsPlanTrabajoObjetivo)dtgObjetivoEspecifico.SelectedRows[0].DataBoundItem).idPlanTrabajoObjetivo;

                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro y todos los demás asociados a este.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }

                DataTable dtResultado = objCNPlanTrabajo.CNEliminarObjetivoEspecificoPlanTrabajo(idPlanTrabajoObjetivoEspecifico, objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);
                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objPlanTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico = lstObjetivoEspecifico.Where(item => item.idPlanTrabajoObjetivo == idPlanTrabajoObjetivoEspecifico).ToList();
                        asignarObjetivoEspecifico();
                        objPlanTrabajoRecuperacion.lstPlanTrabajoAccion                 = objPlanTrabajoRecuperacion.lstPlanTrabajoAccion.Where(item => item.idPlanTrabajoObjetivo != idPlanTrabajoObjetivoEspecifico).ToList();
                        asignarDetalleAccion();
                        objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita             = objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita.Where(item => item.idPlanTrabajoObjetivo != idPlanTrabajoObjetivoEspecifico).ToList();
                        asignarZonaVisita();
                        objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo       = objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo.Where(item => item.idPlanTrabajoObjetivoEspecifico != idPlanTrabajoObjetivoEspecifico).ToList();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["idRegistro"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al tratar de eliminar el objetivo específico, intente de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void agregarDetalleAccion(clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoAccion.Add(objPlanTrabajoDetalleAccion);
            asignarDetalleAccion();

            List<clsDatosCreditoCliente> lstCliente = objPlanTrabajoDetalleAccion.lstDatosCreditoCliente;
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculado = lstCliente.OfType<clsDatosCreditoCliente>().Select(item => new clsDatosCreditoClientePlanTrabajo
            {
                    idCuenta                            = item.idCuenta,
                    idCliente                           = item.idCliente,
                    idPlanTrabajoRecuperacion           = objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion,
                    idPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                    idPlanTrabajoObjetivoGeneral        = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral,
                    idPlanTrabajoObjetivoEspecifico     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                    dFechaAccion                        = objPlanTrabajoDetalleAccion.dFechaAccion,

                    idEstado                            = item.idEstado,
                    cEstado                             = item.cEstado,
                    cNombre                             = item.cNombre,
                    dFechaDesembolso                    = item.dFechaDesembolso,
                    nFrecuencia                         = item.nFrecuencia,
                    nMonto                              = item.nMonto,
                    nCuotas                             = item.nCuotas,
                    idMoneda                            = item.idMoneda,
                    idProducto                          = item.idProducto,
                    cProducto                           = item.cProducto,
                    nMontoCuota                         = item.nMontoCuota,
                    nAtraso                             = item.nAtraso,
                    cDocumentoID                        = item.cDocumentoID,
                    cDireccion                          = item.cDireccion,
                    cCodCliente                         = item.cCodCliente,
                    cMoneda                             = item.cMoneda,
                    idTipoDocumento                     = item.idTipoDocumento,
                    lCoberturaSegDesg                   = item.lCoberturaSegDesg,
                    lSeleccionado                       = item.lSeleccionado,

            }).ToList();
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteFiltrado = lstClienteVinculado.Except(lstDatosClientePlanTrabajo, new clsClientePlanTrabajoComparer()).ToList();
            
            lstDatosClientePlanTrabajo.AddRange(lstClienteFiltrado);
        }
        private void editarDetalleAccion(clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion, int nIndex)
        {

            objPlanTrabajoRecuperacion.lstPlanTrabajoAccion = objPlanTrabajoRecuperacion.lstPlanTrabajoAccion.Select(item => { return (item.idPlanTrabajoDetalleAccion == objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion) ? objPlanTrabajoDetalleAccion : item; }).ToList();
            asignarDetalleAccion();

            List<clsDatosCreditoCliente> lstCliente = objPlanTrabajoDetalleAccion.lstDatosCreditoCliente;
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculado = lstCliente.OfType<clsDatosCreditoCliente>().Select(item => new clsDatosCreditoClientePlanTrabajo
            {
                    idCuenta                            = item.idCuenta,
                    idCliente                           = item.idCliente,
                    idPlanTrabajoRecuperacion           = objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion,
                    idPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                    idPlanTrabajoObjetivoGeneral        = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral,
                    idPlanTrabajoObjetivoEspecifico     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                    dFechaAccion                        = objPlanTrabajoDetalleAccion.dFechaAccion,

                    idEstado                            = item.idEstado,
                    cEstado                             = item.cEstado,
                    cNombre                             = item.cNombre,
                    dFechaDesembolso                    = item.dFechaDesembolso,
                    nFrecuencia                         = item.nFrecuencia,
                    nMonto                              = item.nMonto,
                    nCuotas                             = item.nCuotas,
                    idMoneda                            = item.idMoneda,
                    idProducto                          = item.idProducto,
                    cProducto                           = item.cProducto,
                    nMontoCuota                         = item.nMontoCuota,
                    nAtraso                             = item.nAtraso,
                    cDocumentoID                        = item.cDocumentoID,
                    cDireccion                          = item.cDireccion,
                    cCodCliente                         = item.cCodCliente,
                    cMoneda                             = item.cMoneda,
                    idTipoDocumento                     = item.idTipoDocumento,
                    lCoberturaSegDesg                   = item.lCoberturaSegDesg,
                    lSeleccionado                       = item.lSeleccionado,

            }).ToList();
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteFiltrado = lstClienteVinculado.Except(lstDatosClientePlanTrabajo, new clsClientePlanTrabajoComparer()).ToList();
            
            lstDatosClientePlanTrabajo.AddRange(lstClienteFiltrado);

        }
        private void eliminarDetalleAccion()
        {
            if (dtgDetalleAccion.SelectedRows.Count > 0)
            {
                int idPlanTrabajoDetalleAccion = ((clsPlanTrabajoDetalleAccion)dtgDetalleAccion.SelectedRows[0].DataBoundItem).idPlanTrabajoDetalleAccion;
                int idPlanTrabajoObjetivoEspecifico = ((clsPlanTrabajoDetalleAccion)dtgDetalleAccion.SelectedRows[0].DataBoundItem).idPlanTrabajoObjetivo;

                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }

                DataTable dtResultado = objCNPlanTrabajo.CNEliminarDetalleAccionPlanTrabajo(idPlanTrabajoObjetivoEspecifico, idPlanTrabajoDetalleAccion, objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);

                if(dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        objPlanTrabajoRecuperacion.lstPlanTrabajoAccion = lstDetalleAccion.Where(item => item.idPlanTrabajoDetalleAccion != idPlanTrabajoDetalleAccion).ToList();
                        asignarDetalleAccion();
                        objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo = objPlanTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo.Where(item => item.idPlanTrabajoDetalleAccion != idPlanTrabajoDetalleAccion).ToList();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al tratar de eliminar  el detalle de acción, intente de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void agregarZonaVisita(clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita.Add(objPlanTrabajoZonaVisita);
            asignarZonaVisita();

        }
        private void editarZonaVisita(clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita, int nIndex)
        {
            objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita = objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita.Select(item => { return (item.idPlanTrabajoZonaVisita == objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita) ? objPlanTrabajoZonaVisita : item; }).ToList();
            asignarZonaVisita();
        }
        private void eliminarZonaVisita()
        {
            if (dtgZonaVisita.SelectedRows.Count > 0)
            {
                int idPlanTrabajoZonaVisita = ((clsPlanTrabajoZonaVisita)dtgZonaVisita.SelectedRows[0].DataBoundItem).idPlanTrabajoZonaVisita;
                int idPlanTrabajoObjetivoEspecifico = ((clsPlanTrabajoZonaVisita)dtgZonaVisita.SelectedRows[0].DataBoundItem).idPlanTrabajoObjetivo;

                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }

                DataTable dtResultado = objCNPlanTrabajo.CNEliminarZonaVisitaPlanTrabajo(idPlanTrabajoObjetivoEspecifico, objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion, idPlanTrabajoZonaVisita);

                if(dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objPlanTrabajoRecuperacion.lstPlanTrabajoZonaVisita = lstZonaVisita.Where(item => item.idPlanTrabajoZonaVisita != idPlanTrabajoZonaVisita).ToList();
                        asignarZonaVisita();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al tratar de eliminar la zona de visita, intente de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        #endregion

        #region Enumeradores
        private enum EstadoSolicitud
        {
            PRESOLICITADO   = 0,
            SOLICITADO      = 1,
            APROBADO        = 2,
            VISTO_BUENO     = 3,
            RECHAZADO       = 4,
            ANULADO         = 5,
        }

        private enum AccionFormulario
        {
            ELB_DEFECTO         = 0,
            ELB_RECUPERADO      = 1,
            ELB_EDITADO         = 2,
            ELB_GRABADO         = 3,
            ELB_SOLICITADO      = 4,
            ELB_APROBADO        = 5,
            ELB_DEVUELTO        = 6,
            ELB_RESUELTO        = 7,

            REV_DEFECTO         = 10,
            REV_RECUPERADO      = 11,
            REV_EDITADO         = 12,
            REV_GRABADO         = 13,
            REV_RESUELTO        = 14,
            REV_PENDIENTE       = 15,

            ELBREV_DEFECTO      = 16,
            ELBREV_RECUPERADO   = 17,
            ELBREV_EDITADO      = 18,
            ELBREV_GRABADO      = 19,
            ELBREV_SOLICITADO   = 20,
            ELBREV_APROBADO     = 21,
            ELBREV_DEVUELTO     = 22,
            ELBREV_RESUELTO     = 23,
            ELBREV_PENDIENTE    = 29,
        }

        private enum RolFormularioUsuario
        {
            ELABORADOR                  = 1,
            ELABORADOR_REVISOR          = 2,
            REVISOR                     = 3
        }

        private enum PerfilUsuario
        {
            GESTOR_RECUPERACIONES           = 77,

            JEFE_OFICINA                    = 85,
            GERENTE_REGIONAL                = 75,

            SUPERVISOR_RECUPERACIONES       = 59,
            JEFE_RECUPERACIONES             = 88
        }
        #endregion

    }
}
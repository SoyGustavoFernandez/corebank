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
using RCP.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
#endregion

namespace RCP.Presentacion
{
    public partial class frmRegistrarPlanillaMovilidad : frmBase
    {
        #region Variables Globales
        private clsPlanillaMovilidad objPlanillaMovilidad { get; set; }
        private clsPlanTrabajoRecuperacion objPlanTrabajoRecuperacion { get; set; }
        private clsCNPlanillaMovilidad objCNPlanillaMovilidad { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoEspecifico { get; set; }
        private List<clsPlanillaMovilidadResumen> lstResumenPlanillaMovilidad { get; set; }
        private BindingSource bsResumenPlanillaMovilidad { get; set; }
        private RolFormularioUsuario eRolActivo { get; set; }
        private clsFlujoPlanillaMovilidad objPlanillaMovilidadSolicitado { get; set; }
        private bool lEdicion { get; set; }

        #endregion
        public frmRegistrarPlanillaMovilidad()
        {
            InitializeComponent();
        }

        #region Eventos


        private void frmRegistroPlanillaMovilidad_Load(object sender, EventArgs e)
        {
            cargarComponentes();
            cargarDatosDefecto();
            cargarDatosPlanillaMovilidad();
            validarDias();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtDetallePlanillaMovilidad    = objCNPlanillaMovilidad.CNObtenerPlanillaMovilidadDetalle(objPlanillaMovilidad.idPlanillaMovilidad);
            DataTable dtResumenPlanillaMovilidad    = objCNPlanillaMovilidad.CNObtenerResumenPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad);
            DataTable dtVistoBuenoPlanillaMovilidad = objCNPlanillaMovilidad.CNObtenerVistoBuenoPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad);

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cRuc", clsVarApl.dicVarGen["cRUC"], false));


            dtslist.Add(new ReportDataSource("dsResumenPlanillaMovilidad", dtResumenPlanillaMovilidad));
            dtslist.Add(new ReportDataSource("dsDetallePlanillaMovilidad", dtDetallePlanillaMovilidad));
            dtslist.Add(new ReportDataSource("dsFirmaPlanillaMovilidad", dtVistoBuenoPlanillaMovilidad));

            string reportpath = "rptPlanillaMovilidadIndividual.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();

            dtResultado = objCNPlanillaMovilidad.CNAprobarPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
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
                if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
                else if (eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RECUPERADO);
                }
                
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();
            dtResultado = objCNPlanillaMovilidad.CNDenegarPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RESUELTO);
                }
                else if (eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RESUELTO);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                }
                else if (eRolActivo == RolFormularioUsuario.REVISOR)
                {
                    activarControles(AccionFormulario.REV_RECUPERADO);
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();
            dtResultado = objCNPlanillaMovilidad.CNEnviarPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idEstadoPlanTrabajo = Convert.ToInt32(dtResultado.Rows[0]["idEstadoFinal"]);
                cboEstadoSolicitud.SelectedValue = idEstadoPlanTrabajo;
                if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                {
                    activarControles(AccionFormulario.ELB_SOLICITADO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_SOLICITADO);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            objPlanillaMovilidad = obtenerPlanillaMovilidad();
            string xmlPlanillaMovilidad = objPlanillaMovilidad.GetXml();

            DataTable dtResultado = new DataTable();

            if (objPlanillaMovilidad.idPlanillaMovilidad == 0)
            {
                dtResultado = objCNPlanillaMovilidad.CNRegistrarPlanillaMovilidad(xmlPlanillaMovilidad, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);
                limpiar();

                cargarComponentes();
                cargarDatosDefecto();
                cargarDatosPlanillaMovilidad();
            }
            else
            {
                dtResultado = objCNPlanillaMovilidad.CNActualizarPlanillaMovilidad(objPlanillaMovilidad.idPlanillaMovilidad,  xmlPlanillaMovilidad, objPlanillaMovilidad.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            }

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lEdicion = false;
                if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                {
                    activarControles(AccionFormulario.ELB_GRABADO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_GRABADO);
                }
                dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].ReadOnly = true;
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (eRolActivo == RolFormularioUsuario.ELABORADOR)
                {
                    activarControles(AccionFormulario.ELB_EDITADO);
                }
                else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
                {
                    activarControles(AccionFormulario.ELBREV_EDITADO);
                }
                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(eRolActivo == RolFormularioUsuario.REVISOR)
            {
                activarControles(AccionFormulario.REV_EDITADO);
                
                
            }
            else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.PRESOLICITADO || objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.RECHAZADO)
                {
                    activarControles(AccionFormulario.ELBREV_EDITADO);
                }
            }
            else
            {
                if(objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.PRESOLICITADO || objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.RECHAZADO)
                {
                    activarControles(AccionFormulario.ELB_EDITADO);
                }
            }
            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].ReadOnly = false;
            lEdicion = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(eRolActivo == RolFormularioUsuario.ELABORADOR)
            {
                cargarDatosPlanillaMovilidad();
                activarControles(AccionFormulario.ELB_DEFECTO);
            }
            else if(eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                if(lEdicion)
                {
                    cargarDatosPlanillaMovilidad();
                    activarControles(AccionFormulario.ELBREV_RECUPERADO);
                    lEdicion = false;
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
            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].ReadOnly = true;
        }

        private void btnListaAprobado_Click(object sender, EventArgs e)
        {
            frmPlanillaMovilidadListaSolicitud frmPlanillaMovilidadSolicitud = new frmPlanillaMovilidadListaSolicitud();
            frmPlanillaMovilidadSolicitud.ShowDialog();

            objPlanillaMovilidadSolicitado = frmPlanillaMovilidadSolicitud.objFlujoPlanillaMovilidad;
            if(objPlanillaMovilidadSolicitado.idPlanillaMovilidad != 0)
            {
                cargarDatosPlanillaMovilidad();
            }
            else
            {
                limpiar();
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

        private void conBuscarColaborador_BuscarUsuario(object sender, EventArgs e)
        {
            int idUsuarioBusqueda = Convert.ToInt32(conBuscarColaborador.idUsu);
            idUsuarioBusqueda = (idUsuarioBusqueda == 0) ? clsVarGlobal.User.idUsuario : idUsuarioBusqueda;
            objPlanillaMovilidadSolicitado = objCNPlanillaMovilidad.CNListarPlanillaMovilidadElaborador(idUsuarioBusqueda);

            if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                if(idUsuarioBusqueda == clsVarGlobal.User.idUsuario)
                {
                    cargarDatosPlanillaMovilidad();
                }
                else if (objPlanillaMovilidadSolicitado.idPlanillaMovilidad != 0 && (objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.SOLICITADO || objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.VISTO_BUENO))
                {
                    cargarDatosPlanillaMovilidad();
                }
                else
                {
                    if(objPlanillaMovilidadSolicitado.idPlanillaMovilidad == 0)
                    {
                        MessageBox.Show("El usuario no registró la planilla de movilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.PRESOLICITADO || objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.RECHAZADO)
                    {
                        MessageBox.Show("El usuario no solicitó la aprobación de la planilla de movilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    limpiar();
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                }
            }
            else
            {
                if (objPlanillaMovilidadSolicitado.idPlanillaMovilidad != 0)
                {
                    cargarDatosPlanillaMovilidad();
                }
                else
                {
                    limpiar();
                    if (objPlanillaMovilidadSolicitado.idPlanillaMovilidad == 0)
                    {
                        MessageBox.Show("El usuario no registró la planilla de movilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.PRESOLICITADO || objPlanillaMovilidadSolicitado.idEstadoFinal == (int)EstadoSolicitud.RECHAZADO)
                    {
                        MessageBox.Show("El usuario no solicitó la aprobación de la planilla de movilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    activarControles(AccionFormulario.REV_DEFECTO);
                }
            }
        }

        #endregion


        #region Metodos
        private void cargarComponentes()
        {
            objPlanillaMovilidad            = new clsPlanillaMovilidad();
            objPlanTrabajoRecuperacion      = new clsPlanTrabajoRecuperacion();
            objPlanillaMovilidadSolicitado  = new clsFlujoPlanillaMovilidad();
            objCNPlanillaMovilidad          = new clsCNPlanillaMovilidad();
            lstObjetivoEspecifico           = new List<clsPlanTrabajoObjetivo>();
            lstResumenPlanillaMovilidad     = new List<clsPlanillaMovilidadResumen>();
            bsResumenPlanillaMovilidad      = new BindingSource();

            bsResumenPlanillaMovilidad.DataSource = lstResumenPlanillaMovilidad;
            dtgPlanillaMovilidadDetalle.DataSource = bsResumenPlanillaMovilidad;
            dtgPlanillaMovilidadDetalle.Refresh();
            formatoPlanillaMovilidad();
        }

        private void cargarDatosDefecto()
        {
            eRolActivo  = determinarTipoUsuario();
            lEdicion    = false;
        }

        private void cargarDatosPlanillaMovilidad()
        {
            if (eRolActivo == RolFormularioUsuario.ELABORADOR )
            {
                conBuscarColaborador.CargarColaboradorxUsuario(clsVarGlobal.User.idUsuario);
                objPlanTrabajoRecuperacion = objCNPlanillaMovilidad.CNObtenerPlanTrabajoAprobado(clsVarGlobal.User.idUsuario);

                if (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    if (eRolActivo != RolFormularioUsuario.REVISOR)
                    {
                        MessageBox.Show("El colaborador no posee un plan de trabajo aprobado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Dispose();
                    }

                    activarControles(AccionFormulario.ELB_DEFECTO);
                }
                else
                {
                    asignarDatosPlanillaMovilidad();
                    if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.ELB_APROBADO);
                    }
                    else if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.SOLICITADO)
                    {
                        activarControles(AccionFormulario.ELB_SOLICITADO);
                    }
                    else if(objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.PRESOLICITADO &&  objPlanillaMovilidad.idPlanillaMovilidad != 0)
                    {
                        activarControles(AccionFormulario.ELB_RECUPERADO);
                    }
                    else
                    {
                        activarControles(AccionFormulario.ELB_DEFECTO);
                    }
                }
            }
            else if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                int idUsuarioBusqueda = (objPlanillaMovilidadSolicitado.idUsuario != 0) ? objPlanillaMovilidadSolicitado.idUsuario : clsVarGlobal.User.idUsuario ;
                int idAgenciaBusqueda = (objPlanillaMovilidadSolicitado.idAgencia != 0) ? objPlanillaMovilidadSolicitado.idAgencia : clsVarGlobal.nIdAgencia;

                conBuscarColaborador.CargarColaboradorxUsuario(idUsuarioBusqueda);
                objPlanTrabajoRecuperacion = objCNPlanillaMovilidad.CNObtenerPlanTrabajoAprobado(idUsuarioBusqueda);

                if (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    limpiar();
                    activarControles(AccionFormulario.ELBREV_DEFECTO);
                }
                else
                {
                    asignarDatosPlanillaMovilidad();
                    if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.ELBREV_APROBADO);
                    }
                    else if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.VISTO_BUENO)
                    {
                        activarControles(AccionFormulario.ELBREV_SOLICITADO);
                    }
                    else if ((objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.PRESOLICITADO) && objPlanillaMovilidad.idPlanillaMovilidad != 0)
                    {
                        if(objPlanillaMovilidad.idUsuario != clsVarGlobal.User.idUsuario)
                        {
                            MessageBox.Show("La Planilla de Movilidad seleccionada no fue solicitada para su aprobación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        activarControles(AccionFormulario.ELBREV_RECUPERADO);
                    }
                    else
                    {
                        activarControles(AccionFormulario.ELBREV_DEFECTO);
                    }
                }
            }
            else if (eRolActivo == RolFormularioUsuario.REVISOR)
            {
                conBuscarColaborador.CargarColaboradorxUsuario(objPlanillaMovilidadSolicitado.idUsuario);
                objPlanTrabajoRecuperacion = objCNPlanillaMovilidad.CNObtenerPlanTrabajoAprobado(objPlanillaMovilidadSolicitado.idUsuario);

                if (objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion == 0)
                {
                    limpiar();
                    activarControles(AccionFormulario.REV_DEFECTO);
                }
                else
                {
                    objPlanillaMovilidad.idPlanillaMovilidad = objPlanillaMovilidadSolicitado.idPlanillaMovilidad;

                    asignarDatosPlanillaMovilidad();
                    if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO)
                    {
                        activarControles(AccionFormulario.REV_RESUELTO);
                    }
                    else if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.VISTO_BUENO)
                    {
                        activarControles(AccionFormulario.REV_RECUPERADO);
                    }
                    else if (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.PRESOLICITADO && objPlanillaMovilidad.idPlanillaMovilidad != 0)
                    {
                        MessageBox.Show("La Planilla de Movilidad seleccionada no fue solicitada para su aprobación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        activarControles(AccionFormulario.REV_PENDIENTE);
                    }
                    else
                    {
                        activarControles(AccionFormulario.REV_DEFECTO);
                    }
                }
            }
        }

        private void asignarDatosPlanillaMovilidad()
        {
            objPlanillaMovilidad = objCNPlanillaMovilidad.CNObtenerDatosPlanillaMovilidadCompleto(objPlanillaMovilidad.idPlanillaMovilidad, objPlanTrabajoRecuperacion.idPlanTrabajoRecuperacion);

            cboEstadoSolicitud.SelectedValue    = objPlanillaMovilidad.idEstado;
            dtpFechaInicio.Value                = objPlanillaMovilidad.dFechaInicio;
            dtpFechaFin.Value                   = objPlanillaMovilidad.dFechaFin;
            dtpFechaResolucion.Value            = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? objPlanillaMovilidad.dFechaResolucion : clsVarGlobal.dFecSystem;

            lstResumenPlanillaMovilidad = new List<clsPlanillaMovilidadResumen>();
            lstResumenPlanillaMovilidad.AddRange(objPlanillaMovilidad.lstPlanillaMovilidadResumen);

            bsResumenPlanillaMovilidad.DataSource = lstResumenPlanillaMovilidad;
            dtgPlanillaMovilidadDetalle.DataSource = bsResumenPlanillaMovilidad;
            bsResumenPlanillaMovilidad.ResetBindings(false);
            formatoPlanillaMovilidad();
            dtgPlanillaMovilidadDetalle.Refresh();
        }

        private clsPlanillaMovilidad obtenerPlanillaMovilidad()
        {
            objPlanillaMovilidad.idUsuario      = (objPlanillaMovilidad.idUsuario == 0) ? clsVarGlobal.User.idUsuario : objPlanillaMovilidad.idUsuario ;
            objPlanillaMovilidad.idPerfil       = (objPlanillaMovilidad.idPerfil == 0) ? clsVarGlobal.PerfilUsu.idPerfil : objPlanillaMovilidad.idPerfil ;
            objPlanillaMovilidad.idEstado       = (objPlanillaMovilidad.idPlanillaMovilidad == 0) ? -1 : objPlanillaMovilidad.idEstado;
            objPlanillaMovilidad.idAgencia      = clsVarGlobal.User.idAgeCol;
            objPlanillaMovilidad.nAnio          = clsVarGlobal.dFecSystem.Year;
            objPlanillaMovilidad.nMes           = clsVarGlobal.dFecSystem.Month;
            objPlanillaMovilidad.dFechaInicio   = clsVarGlobal.dFecSystem;
            objPlanillaMovilidad.dFechaFin      = clsVarGlobal.dFecSystem;
            objPlanillaMovilidad.lstPlanillaMovilidadResumen = lstResumenPlanillaMovilidad;

            return this.objPlanillaMovilidad;
        }

        private void limpiar()
        {
            DateTime dInicioMes = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            conBuscarColaborador.LimpiarDatos();
            cboEstadoSolicitud.SelectedIndex = -1;
            dtpFechaInicio.Value = dInicioMes;
            dtpFechaFin.Value = dInicioMes.AddMonths(1).AddDays(-1);
            dtpFechaResolucion.Value = clsVarGlobal.dFecSystem;
            objPlanillaMovilidad = new clsPlanillaMovilidad();
            objPlanillaMovilidadSolicitado = new clsFlujoPlanillaMovilidad();
            objPlanTrabajoRecuperacion = new clsPlanTrabajoRecuperacion();

            limpiarDetallePlanillaMovilidad();

            if (eRolActivo == RolFormularioUsuario.ELABORADOR)
            {
                conBuscarColaborador.CargarColaboradorxUsuario(clsVarGlobal.User.idUsuario);
            }
        }

        public void limpiarDetallePlanillaMovilidad()
        {
            lstResumenPlanillaMovilidad.Clear();
            bsResumenPlanillaMovilidad.ResetBindings(false);
        }

        private void validarDias()
        {
            int nDiaMaximoRegistro = Convert.ToInt32(clsVarApl.dicVarGen["nDiasPlazoPlanillaMovilidad"]);
            if ((clsVarGlobal.dFecSystem.Day >= nDiaMaximoRegistro))
            {
                MessageBox.Show("El plazo para el registro de la planilla de movilidad ha pasado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
        }

        private bool validar()
        {
            decimal nMontoDiarioPermitido = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoDiarioPlanillaMovilidad"]);
            decimal nMontoTotalPermitido = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaximoPlanillaMovilidad"]);
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            DateTime dFechaFinMes = new DateTime(dFechaSistema.Year, dFechaSistema.Month, 1).AddMonths(1).AddDays(-1);
            int nInicioMes = 1;
            int nFinMes = dFechaFinMes.Day;
            bool lValida = true;
            decimal nMontoTotalRegistrado = lstResumenPlanillaMovilidad.Sum(item => item.nMontoAsignado);

            if (nMontoTotalRegistrado > nMontoTotalPermitido && lValida)
            {
                MessageBox.Show("Los gastos registrados del mes exceden el monto mensual permitido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            List<clsPlanillaMovilidadResumen> lstDiasExcedidos = lstResumenPlanillaMovilidad.GroupBy(item => item.dFechaAccion).Select(item => new clsPlanillaMovilidadResumen {
                                                                                                                                                dFechaAccion = item.Key,
                                                                                                                                                nMontoAsignado = item.Sum(item2 => item2.nMontoAsignado)
                                                                                                                                        }).Where(item => item.nMontoAsignado > nMontoDiarioPermitido).ToList();
            if(lstDiasExcedidos.Count > 0)
            {
                string cMensaje = "";
                foreach (clsPlanillaMovilidadResumen objResumenDia in lstDiasExcedidos)
                {
                    cMensaje += "\t" + objResumenDia.dFechaAccion.ToShortDateString() + ": " + objResumenDia.nMontoAsignado.ToString("N2") + "\n";
                }
                string cMensajeDia = "";
                if (lstDiasExcedidos.Count == 1)
                    cMensajeDia += "Los gastos registrados del día:\n";
                else if (lstDiasExcedidos.Count > 1)
                    cMensajeDia += "Los gastos registrados de los días:\n";
                else
                    cMensajeDia += "";

                cMensajeDia += cMensaje + "exceden el monto diario permitido.";
                MessageBox.Show(cMensajeDia, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return lValida;
        }

        private void formatoPlanillaMovilidad()
        {
            dtgPlanillaMovilidadDetalle.ReadOnly = false;
            foreach(DataGridViewColumn dgvColumna in dtgPlanillaMovilidadDetalle.Columns)
            {
                dgvColumna.Visible      = false;
                dgvColumna.HeaderText   = dgvColumna.Name;
                dgvColumna.ReadOnly     = true;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvColumna.Frozen       = false;
            }

            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoEspecifico"].Visible       = true;
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoGeneral"].Visible          = true;
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoAccion"].Visible                   = true;
            dtgPlanillaMovilidadDetalle.Columns["dFechaAccion"].Visible                         = true;
            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].Visible                       = true;

            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoEspecifico"].HeaderText        = "Objetivo Específico";
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoGeneral"].HeaderText           = "Objetivo General";
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoAccion"].HeaderText                    = "Acción";
            dtgPlanillaMovilidadDetalle.Columns["dFechaAccion"].HeaderText                          = "Fecha de Acción";
            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].HeaderText                        = "Monto total";

            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].ReadOnly                      = true;

            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoGeneral"].Width           = 180;
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoObjetivoEspecifico"].Width        = 180;
            dtgPlanillaMovilidadDetalle.Columns["cPlanTrabajoAccion"].Width                    = 180;
            dtgPlanillaMovilidadDetalle.Columns["dFechaAccion"].Width                          = 75;
            dtgPlanillaMovilidadDetalle.Columns["nMontoAsignado"].Width                        = 75;

            dtgPlanillaMovilidadDetalle.ReadOnly = false;
            dtgPlanillaMovilidadDetalle.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void activarControles(AccionFormulario eAccionFormulario)
        {
            switch(eAccionFormulario)
            {
                case AccionFormulario.ELB_DEFECTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = (objPlanillaMovilidad.idPlanillaMovilidad != 0) ? true : false ;

                    btnEnviar.Enabled                       = (objPlanillaMovilidad.idPlanillaMovilidad != 0) ? true : false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = true;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_EDITADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = true;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELB_GRABADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = true;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = true;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_RECUPERADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = true;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.SOLICITADO || objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? false : true;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_SOLICITADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_DEVUELTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = true;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_APROBADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Visible                     = false;
                    btnRechazar.Enabled                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.ELB_RESUELTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = false;
                    #endregion
                    break;

                case AccionFormulario.ELBREV_DEFECTO:
                    #region
                    conBuscarColaborador.Enabled            = true;
                    conBuscarColaborador.HabilitarControles((objPlanillaMovilidad.idPlanillaMovilidad == 0) ? true : false);
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = (objPlanillaMovilidad.idPlanillaMovilidad == 0 ) ? true : false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = (objPlanillaMovilidad.idPlanillaMovilidad == 0) ? false : true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = (objPlanillaMovilidad.lstPlanillaMovilidadResumen.Count > 0) ? true : false;
                    btnCancelar.Enabled                     = (objPlanillaMovilidad.lstPlanillaMovilidadResumen.Count > 0) ? true : false;
                    #endregion
                break;
                case AccionFormulario.ELBREV_RECUPERADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = (objPlanillaMovilidad.idPlanillaMovilidad != 0) ? true : false; ;

                    btnEnviar.Enabled                       = (objPlanillaMovilidad.idUsuario == clsVarGlobal.User.idUsuario && objPlanillaMovilidad.idPlanillaMovilidad != 0) ? true : false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = ((objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.SOLICITADO ||
                                                                objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.VISTO_BUENO ||
                                                                objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) &&
                                                                objPlanillaMovilidad.idUsuario != clsVarGlobal.User.idUsuario) ? false : true;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_EDITADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = true;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_GRABADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = true;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = true;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_SOLICITADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = (objPlanillaMovilidad.idUsuario == clsVarGlobal.User.idUsuario) ? false : true ;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = (objPlanillaMovilidad.idUsuario == clsVarGlobal.User.idUsuario) ? false : true;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_APROBADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Visible                     = false;
                    btnRechazar.Enabled                     = false;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_DEVUELTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false ;
                    lblFechaResolucion.Visible              = (objPlanillaMovilidad.idEstado == (int)EstadoSolicitud.APROBADO) ? true : false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = true;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_RESUELTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;
                    lblFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = true;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;
                case AccionFormulario.ELBREV_PENDIENTE:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;
                    lblFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;
                    #endregion
                    break;

                case AccionFormulario.REV_DEFECTO:
                    #region
                    conBuscarColaborador.Enabled            = true;
                    conBuscarColaborador.HabilitarControles(true);
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = true;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
                case AccionFormulario.REV_RECUPERADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = true;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = true;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;

                    #endregion
                    break;
                case AccionFormulario.REV_EDITADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = true;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;

                    #endregion
                    break;
                case AccionFormulario.REV_GRABADO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = true;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = true;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = true;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;

                    #endregion
                    break;
                case AccionFormulario.REV_RESUELTO:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = true;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = true;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;

                    #endregion
                    break;
                case AccionFormulario.REV_PENDIENTE:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = true;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = true;
                    btnListaAprobado.Visible                = true;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = true;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = true;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = true;

                    #endregion
                    break;
                default:
                    #region
                    conBuscarColaborador.Enabled            = false;
                    cboEstadoSolicitud.Enabled              = false;
                    dtpFechaInicio.Enabled                  = false;
                    dtpFechaFin.Enabled                     = false;
                    dtpFechaResolucion.Enabled              = false;
                    dtpFechaResolucion.Visible              = false;
                    lblFechaResolucion.Visible              = false;

                    dtgPlanillaMovilidadDetalle.Enabled     = true;

                    btnListaAprobado.Enabled                = false;
                    btnListaAprobado.Visible                = false;
                    
                    btnAprobar.Enabled                      = false;
                    btnAprobar.Visible                      = false;
                    btnRechazar.Enabled                     = false;
                    btnRechazar.Visible                     = false;
                    btnImprimir.Enabled                     = false;

                    btnEnviar.Enabled                       = false;
                    btnGrabar.Enabled                       = false;
                    btnEditar.Enabled                       = false;
                    btnCancelar.Enabled                     = false;

                    #endregion
                    break;
            }
        }

        private RolFormularioUsuario determinarTipoUsuario()
        {
            clsVarGen varGenElaborador          = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilElaboradorPlanTrabajo"));
            clsVarGen varGenElaboradorRevisor   = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilElaboradorRevisorPlanTrabajo"));
            clsVarGen varGenRevisor             = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("cIdPerfilRevisorPlanTrabajo"));

            List<int> lstPerfilRevisorPermitidos            = varGenRevisor.cValVar.Split(',').Select(Int32.Parse).ToList();
            List<int> lstPerfilElaboradorRevisorPermitidos  = varGenElaboradorRevisor.cValVar.Split(',').Select(Int32.Parse).ToList();
            List<int> lstPerfilElaboradorPermitidos         = varGenElaborador.cValVar.Split(',').Select(Int32.Parse).ToList();

            int idPerfilElaboradorPermitido         = lstPerfilElaboradorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);
            int idPerfilRevisorPermitido            =  lstPerfilRevisorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);
            int idPerfilElaboradorRevisorPermitido  = lstPerfilElaboradorRevisorPermitidos.Find(item => item == clsVarGlobal.PerfilUsu.idPerfil);

            if (idPerfilElaboradorRevisorPermitido != 0)
                return RolFormularioUsuario.ELABORADOR_REVISOR;
            else if (idPerfilRevisorPermitido != 0)
                return RolFormularioUsuario.REVISOR;
            else if (idPerfilElaboradorPermitido != 0)
                return RolFormularioUsuario.ELABORADOR;
            else
                return RolFormularioUsuario.ELABORADOR;
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
            ELABORADOR          = 1,
            ELABORADOR_REVISOR  = 2,
            REVISOR             = 3
        }

        private enum PerfilUsuario
        {
            GESTOR_RECUPERACIONES       = 77,

            JEFE_OFICINA                = 85,
            GERENTE_REGIONAL            = 75,

            SUPERVISOR_RECUPERACIONES   = 59,
            JEFE_RECUPERACIONES         = 88
        }

        #endregion

    }
}

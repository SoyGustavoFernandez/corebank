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
using GEN.ControlesBase;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoAprobacionGenerica : frmBase
    {
        private clsCNMantmtoAprobacionGen objCNMantAprobacion;
        private List<clsAprobacionCanal> lstAprobacionCanal;
        private List<clsAprobacionSolicitudTipo> lstAprobacionSolTipo;
        private List<clsAprobacionNivel> lstAprobacionNivel;
        private List<clsPerfil> lstPerfil;

        private clsAprobacionCanal objAprobacionCanal;
        private clsAprobacionSolicitudTipo objAprobacionSolTipo;
        private clsAprobacionNivel objAprobacionNivel;
        private clsPerfil objPerfil;

        private bool lEditCanal;
        private bool lEditTipoSol;
        private bool lEditNivel;
        private bool lAddNivel;
        private bool lAddPerfil;

        public frmMantenimientoAprobacionGenerica()
        {
            InitializeComponent();
            this.inicializarDatos();
        }

        public void inicializarDatos()
        {
            this.objCNMantAprobacion = new clsCNMantmtoAprobacionGen();
            this.lstAprobacionCanal = new List<clsAprobacionCanal>();
            this.lstAprobacionSolTipo = new List<clsAprobacionSolicitudTipo>();
            this.lstAprobacionNivel = new List<clsAprobacionNivel>();
            this.lstPerfil = new List<clsPerfil>();

            this.objAprobacionCanal = new clsAprobacionCanal();
            this.objAprobacionSolTipo = new clsAprobacionSolicitudTipo();
            this.objAprobacionNivel = new clsAprobacionNivel();
            this.objPerfil = new clsPerfil();

            this.lEditCanal = false;
            this.lEditNivel = false;
            this.lEditTipoSol = false;
            this.lAddNivel = false;
            this.lAddPerfil = false;

            this.bsAprobacionCanal.DataSource = this.lstAprobacionCanal;
            this.bsAprobacionSolTipo.DataSource = this.lstAprobacionSolTipo;
            this.bsAprobacionNivel.DataSource = this.lstAprobacionNivel;
            this.bsPerfilAprobador.DataSource = this.lstPerfil;

            this.habilitarCanalEdit(clsAcciones.DEFECTO);
            this.habilitarAproSolTipoEdit(clsAcciones.DEFECTO);
            this.habilitarNivelEdit(clsAcciones.DEFECTO);
        }
              

        #region Canal Aprobacion
        private void listarAprobacionCanal()
        {
            this.lstAprobacionCanal.Clear();
            this.lstAprobacionCanal.AddRange(this.objCNMantAprobacion.listarAprobacionCanal());

            this.bsAprobacionCanal.ResetBindings(false);
            this.dtgAprobacionCanal.Refresh();
        }
        private void grabarAprobacionCanal()
        {
            clsRespuestaServidor objRespuestaServ = this.objCNMantAprobacion.grabarAprobacionCanal(this.extraerCanalEdit());
            if (objRespuestaServ.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarAprobacionCanal();
                this.limpiarCanalEdit();
                this.habilitarCanalEdit(clsAcciones.GRABAR);
                this.lEditCanal = false;
            }
            else
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private clsAprobacionCanal extraerCanalEdit()
        {
            clsAprobacionCanal objAprobacionCanalEdit;
            if (this.lEditCanal)
            {
                objAprobacionCanalEdit = (clsAprobacionCanal)this.objAprobacionCanal.Clone();
            }
            else
            {
                objAprobacionCanalEdit = new clsAprobacionCanal();
            }
            objAprobacionCanalEdit.cAprobacionCanal = this.txtAprobacionCanal.Text;
            objAprobacionCanalEdit.cAcronimo = this.txtAcronimoCanal.Text.Trim().ToUpper();
            objAprobacionCanalEdit.lVigente = this.chkVigenteCanal.Checked;

            return objAprobacionCanalEdit;
        }
        private void distribuirCanalEdit()
        {
            this.txtAprobacionCanal.Text = this.objAprobacionCanal.cAprobacionCanal;
            this.txtAcronimoCanal.Text = this.objAprobacionCanal.cAcronimo;
            this.chkVigenteCanal.Checked = this.objAprobacionCanal.lVigente;
        }
        private void limpiarCanalEdit()
        {
            this.txtAprobacionCanal.Text = string.Empty;
            this.txtAcronimoCanal.Text = string.Empty;
            this.chkVigenteCanal.Checked = true;
        }
        private void habilitarCanalEdit(int idAccion)
        {
           switch(idAccion)
           {
               case clsAcciones.DEFECTO:
                   this.txtAprobacionCanal.Enabled = false;
                   this.txtAcronimoCanal.Enabled = false;
                   this.chkVigenteCanal.Enabled = false;

                   this.btnAceptarCanal.Visible = false;
                   this.btnCancelarCanal.Visible = false;
                   this.tsbNuevoCanal.Visible = true;
                   this.tsbEditarCanal.Visible = true;
                   break;
               case clsAcciones.NUEVO:
                   this.txtAprobacionCanal.Enabled = true;
                   this.txtAcronimoCanal.Enabled = true;
                   this.chkVigenteCanal.Enabled = true;
                   
                   this.btnAceptarCanal.Visible = true;
                   this.btnCancelarCanal.Visible = true;
                   this.tsbNuevoCanal.Visible = false;
                   this.tsbEditarCanal.Visible = false;
                   break;
               case clsAcciones.GRABAR:
                   this.txtAprobacionCanal.Enabled = false;
                   this.txtAcronimoCanal.Enabled = false;
                   this.chkVigenteCanal.Enabled = false;

                   this.btnAceptarCanal.Visible = false;
                   this.btnCancelarCanal.Visible = false;
                   this.tsbNuevoCanal.Visible = true;
                   this.tsbEditarCanal.Visible = true;
                   break;
               case clsAcciones.CANCELAR:
                   this.txtAprobacionCanal.Enabled = false;
                   this.txtAcronimoCanal.Enabled = false;
                   this.chkVigenteCanal.Enabled = false;

                   this.btnAceptarCanal.Visible = false;
                   this.btnCancelarCanal.Visible = false;
                   this.tsbNuevoCanal.Visible = true;
                   this.tsbEditarCanal.Visible = true;
                   break;
               case clsAcciones.EDITAR:
                   this.txtAprobacionCanal.Enabled = true;
                   this.txtAcronimoCanal.Enabled = true;
                   this.chkVigenteCanal.Enabled = true;
                   
                   this.btnAceptarCanal.Visible = true;
                   this.btnCancelarCanal.Visible = true;
                   this.tsbNuevoCanal.Visible = false;
                   this.tsbEditarCanal.Visible = false;
                   break;
           }
        }
        private void btnAceptarCanal_Click(object sender, EventArgs e)
        {
            if (this.txtAprobacionCanal.Text.Trim().Equals(string.Empty) || this.txtAcronimoCanal.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Los campos CANAL y SIGLA no pueden estar vacíos.", "SELECCIONE...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.grabarAprobacionCanal();
        }

        private void btnCancelarCanal_Click(object sender, EventArgs e)
        {
            this.limpiarCanalEdit();
            this.habilitarCanalEdit(clsAcciones.DEFECTO);
        }
        
        private void tsbNuevoCanal_Click(object sender, EventArgs e)
        {
            this.habilitarCanalEdit(clsAcciones.EDITAR);
            this.lEditCanal = false;
            this.limpiarCanalEdit();
        }

        private void tsbEditarCanal_Click(object sender, EventArgs e)
        {
            if(this.objAprobacionCanal.idAprobacionCanal == 0)
            {
                MessageBox.Show("Debe seleccionar un canal para editar","SELECCIONE...",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.distribuirCanalEdit();
            this.habilitarCanalEdit(clsAcciones.EDITAR);
            this.lEditCanal = true;
        }

        private void tsbQuitarCanal_Click(object sender, EventArgs e)
        {
            if (this.objAprobacionCanal.idAprobacionCanal == 0)
            {
                MessageBox.Show("Debe seleccionar un canal para deshabilitar", "SELECCIONE...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.objAprobacionCanal.lVigente = false;
        }
        private void dtgAprobacionCanal_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAprobacionCanal.SelectedRows.Count == 0)
            {
                this.objAprobacionCanal = new clsAprobacionCanal();
            }
            else
            {
                int nIndice = this.dtgAprobacionCanal.SelectedRows[0].Index;
                this.objAprobacionCanal = this.lstAprobacionCanal[nIndice];
                this.listarAprobacionNivel();
            }
            if (this.lEditCanal)
            {
                this.lEditCanal = false;
                this.limpiarCanalEdit();
            }
            if (this.lEditNivel)
            {
                this.limpiarNivelEdit();
                this.lEditNivel = false;
            }
        }
        #endregion

        #region Tipo Solicitud Aprobacion
        private void listarAprobacionSolTipo()
        {
            this.lstAprobacionSolTipo.Clear();
            this.lstAprobacionSolTipo.AddRange(this.objCNMantAprobacion.listarAprobacionSolTipo());

            this.bsAprobacionSolTipo.ResetBindings(false);
            this.dtgAprobacionSolTipo.Refresh();
        }
        private void grabarAprobacionSolTipo()
        {
            clsRespuestaServidor objRespuestaServ = this.objCNMantAprobacion.grabarAprobacionSolTipo(this.extraerAproSolTipoEdit());
            if (objRespuestaServ.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarAprobacionSolTipo();
                this.limpiarAproSolTipoEdit();
                this.lEditTipoSol = false;
                this.habilitarAproSolTipoEdit(clsAcciones.DEFECTO);
            }
            else
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private clsAprobacionSolicitudTipo extraerAproSolTipoEdit()
        {
            clsAprobacionSolicitudTipo objAproSolTipoEdit;
            if (this.lEditTipoSol)
            {
                objAproSolTipoEdit = (clsAprobacionSolicitudTipo)this.objAprobacionSolTipo.Clone();
            }
            else
            {
                objAproSolTipoEdit = new clsAprobacionSolicitudTipo();
            }
            objAproSolTipoEdit.cAprobacionSolicitudTipo = this.txtAprobacionSolicitudTipo.Text;
            objAproSolTipoEdit.cAcronimo = this.txtAcronimoAproSolTipo.Text.Trim().ToUpper();

            return objAproSolTipoEdit;
        }
        private void distribuirAproSolTipoEdit()
        {
            this.txtAprobacionSolicitudTipo.Text = this.objAprobacionSolTipo.cAprobacionSolicitudTipo;
            this.txtAcronimoAproSolTipo.Text = this.objAprobacionSolTipo.cAcronimo;
        }
        private void limpiarAproSolTipoEdit()
        {
            this.txtAprobacionSolicitudTipo.Text = string.Empty;
            this.txtAcronimoAproSolTipo.Text = string.Empty;
        }
        private void habilitarAproSolTipoEdit(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.txtAprobacionSolicitudTipo.Enabled = false;
                    this.txtAcronimoAproSolTipo.Enabled = false;

                    this.tsbNuevoTipoSol.Visible = true;
                    this.tsbEditarTipoSol.Visible = true;
                    this.btnAceptarTipoSol.Visible = false;
                    this.btnCancelarTipoSol.Visible = false;
                    break;
                case clsAcciones.EDITAR:
                    this.txtAprobacionSolicitudTipo.Enabled = true;
                    this.txtAcronimoAproSolTipo.Enabled = true;

                    this.tsbNuevoTipoSol.Visible = false;
                    this.tsbEditarTipoSol.Visible = false;
                    this.btnAceptarTipoSol.Visible = true;
                    this.btnCancelarTipoSol.Visible = true;
                    break;
            }
        }
        private void btnAceptarTipoSol_Click(object sender, EventArgs e)
        {
            if (this.txtAprobacionSolicitudTipo.Text.Trim().Equals(string.Empty) ||
                this.txtAcronimoAproSolTipo.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("¡Los campos de NOMBRE y SIGLA del tipo de solicitud no pueden estar vacios!",
                    "CAMPOS VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.grabarAprobacionSolTipo();
        }

        private void btnCancelarTipoSol_Click(object sender, EventArgs e)
        {
            this.limpiarAproSolTipoEdit();
            this.habilitarAproSolTipoEdit(clsAcciones.DEFECTO);
        }

        private void tsbNuevoTipoSol_Click(object sender, EventArgs e)
        {
            this.limpiarAproSolTipoEdit();
            this.habilitarAproSolTipoEdit(clsAcciones.EDITAR);
        }

        private void tsbEditarTipoSol_Click(object sender, EventArgs e)
        {
            if (this.objAprobacionSolTipo.idAprobacionSolicitudTipo == 0)
            {
                MessageBox.Show("¡Debe seleccionar un tipo de solicitud para editar!","SELECCION VACIA",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.distribuirAproSolTipoEdit();
            this.lEditTipoSol = true;
            this.habilitarAproSolTipoEdit(clsAcciones.EDITAR);
        }
        private void dtgAprobacionSolTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAprobacionSolTipo.SelectedRows.Count == 0)
            {
                this.objAprobacionSolTipo = new clsAprobacionSolicitudTipo();
            }
            else
            {
                int nIndice = this.dtgAprobacionSolTipo.SelectedRows[0].Index;
                this.objAprobacionSolTipo = this.lstAprobacionSolTipo[nIndice];
            }
        }
        #endregion

        #region Nivel Aprobacion
        private void listarAprobacionNivel()
        {
            if (this.objAprobacionCanal.idAprobacionCanal == 0)
            {
                MessageBox.Show("¡Debe seleccionar un canal de aprobación para listar niveles!","SELECCIONE CANAL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.lstAprobacionNivel.Clear();
            this.lstAprobacionNivel.AddRange(this.objCNMantAprobacion.listarAprobacionNivel(this.objAprobacionCanal.idAprobacionCanal));
            if (this.lstAprobacionNivel.Count == 0)
            {
                this.lstPerfil.Clear();
                this.tsbAgregarPerfil.Visible = false;
                this.tsbQuitarPerfil.Visible = false;
                this.bsPerfilAprobador.ResetBindings(false);
                this.dtgPerfilAprobador.Refresh();
            }
            else
            {
                this.tsbAgregarPerfil.Visible = true;
                this.tsbQuitarPerfil.Visible = true;
            }

            this.bsAprobacionNivel.ResetBindings(false);
            this.dtgAprobacionNivel.Refresh();
        }
        private void grabarAprobacionNivel()
        {
            List<int> lstOrdenes = new List<int>();
            foreach (clsAprobacionNivel objNivel in this.lstAprobacionNivel)
            {
                if (objNivel.cIdsPerfil.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("¡El nivel de aprobación \""+
                        objNivel.cAprobacionNivel + "\", no tiene perfiles de aprobador asignados!\n\n"
                        +"*No se grabaran los cambios realizados.","",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lstOrdenes.Exists(x=>x == objNivel.nOrden))
                {
                    MessageBox.Show("¡El valor de ORDEN \"" + objNivel.nOrden.ToString() + "\" se repite mas de un vez.\n\n" +
                         "*No se permiten valores de ORDEN repetidos.\n" +
                         "**No se grabaran los cambios realizados.",
                        "VALOR REPETIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lstOrdenes.Add(objNivel.nOrden);
            }
            clsRespuestaServidor objRespuestaServ = this.objCNMantAprobacion.grabarAprobacionNivel(this.lstAprobacionNivel);
            if (objRespuestaServ.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarAprobacionNivel();
                this.limpiarNivelEdit();
                this.lEditNivel = false;
                this.lAddNivel = false;
                this.lAddPerfil = false;
                this.habilitarNivelEdit(clsAcciones.DEFECTO);
                this.actualizarNivelIniFin();
            }
            else
            {
                MessageBox.Show(objRespuestaServ.cMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void agregarNivel()
        {
            if (!this.validarNivelEdit()) return;
            if (this.lEditNivel)
            {
                this.objAprobacionNivel.cAprobacionNivel = this.txtAprobacionNivel.Text;
                this.objAprobacionNivel.cAcronimo = this.txtAcronimoNivel.Text.Trim().ToUpper();
                this.objAprobacionNivel.nOrden = Convert.ToInt32(this.txtOrden.Text);
                this.objAprobacionNivel.cDescripcion = this.txtNivelDescripcion.Text;
                this.objAprobacionNivel.lVigente = this.chkVigenteNivel.Checked;
            }
            else
            {
                clsAprobacionNivel objAproNivelEdit = new clsAprobacionNivel();
                objAproNivelEdit.idAprobacionCanal = this.objAprobacionCanal.idAprobacionCanal;
                objAproNivelEdit.cAprobacionNivel = this.txtAprobacionNivel.Text;
                objAproNivelEdit.cAcronimo = this.txtAcronimoNivel.Text.Trim().ToUpper();
                objAproNivelEdit.nOrden = Convert.ToInt32(this.txtOrden.Text);
                objAproNivelEdit.cDescripcion = this.txtNivelDescripcion.Text;
                objAprobacionNivel.lVigente = this.chkVigenteNivel.Checked;
                this.lstAprobacionNivel.Add(objAproNivelEdit);
            }

            this.bsAprobacionNivel.ResetBindings(false);
            this.dtgAprobacionNivel.Refresh();
            this.limpiarNivelEdit();
            this.habilitarNivelEdit(clsAcciones.DEFECTO);
            this.lAddNivel = true;
            this.lEditNivel = false;
            
        }
        private void distribuirNivelEdit()
        {
            this.txtVistaCanal.Text = this.objAprobacionCanal.cAprobacionCanal;
            this.txtAprobacionNivel.Text = this.objAprobacionNivel.cAprobacionNivel;
            this.txtAcronimoNivel.Text = this.objAprobacionNivel.cAcronimo;
            this.txtOrden.Text = this.objAprobacionNivel.nOrden.ToString();
            this.txtNivelDescripcion.Text = this.objAprobacionNivel.cDescripcion;
            this.chkVigenteNivel.Checked = this.objAprobacionNivel.lVigente;

            this.lEditNivel = true;
        }
        private bool validarNivelEdit()
        {
            if (this.txtAprobacionNivel.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("El NOMBRE del nivel no puede estar vacío", "DATO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtAcronimoNivel.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("La SIGLA del nivel no puede estar vacío", "DATO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtOrden.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("El ORDEN del nivel no puede estar vacío", "DATO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!this.lEditNivel && this.lstAprobacionNivel.Exists(x => x.nOrden == Convert.ToInt32(this.txtOrden.Text)))
            {
                MessageBox.Show("El ORDEN \""+
                    this.txtOrden.Text +"\" ya existe en uno de los niveles.\n\n" +
                "*No se permite repetir el ORDEN de los niveles.", "VALOR INCORRECTO",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(this.txtOrden.Text) == 0)
            {
                if (MessageBox.Show("El Orden CERO se considera como valor IRRELEVANTE, solo se utiliza para niveles solicitantes como referencia.\n\n" +
                "*Si desea que el nivel \"" + this.objAprobacionNivel.cAprobacionNivel + "\" sea considerado como nivel de aprobador, el valor del campo ORDEN debe ser mayor a CERO.\n" +
                "**Los niveles con ORDEN CERO no pueden ser considerados como niveles iniciales ni finales de un canal.\n\n" +
                "¿Está seguro de establecer el valor ORDEN igual a CERO?",
                    "VALOR IRRELEVANTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            if (this.txtNivelDescripcion.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("La DESCRIPCIÓN del nivel no puede estar vacío", "DATO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void limpiarNivelEdit()
        {
            this.txtVistaCanal.Text = string.Empty;
            this.txtAprobacionNivel.Text = string.Empty;
            this.txtAcronimoNivel.Text = string.Empty;
            this.txtOrden.Text = string.Empty;
            this.txtNivelDescripcion.Text = string.Empty;
            this.chkVigenteNivel.Checked = true;
        }
        private void habilitarNivelEdit(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.txtAprobacionNivel.Enabled = false;
                    this.txtAcronimoNivel.Enabled = false;
                    this.txtOrden.Enabled = false;
                    this.txtNivelDescripcion.Enabled = false;
                    this.chkVigenteNivel.Enabled = false;

                    this.tsbGrabarNivel.Visible = (this.lEditNivel || this.lAddNivel);
                    this.tsbDeshacer.Visible = (this.lEditNivel || this.lAddNivel);
                    this.tsbNuevoNivel.Visible = true;
                    this.tsbEditarNivel.Visible = true;
                    this.tsbQuitarNivel.Visible = true;

                    this.btnAceptarNivel.Visible = false;
                    this.btnCancelarNivel.Visible = false;
                    break;
                case clsAcciones.EDITAR:
                    this.txtAprobacionNivel.Enabled = true;
                    this.txtAcronimoNivel.Enabled = true;
                    this.txtOrden.Enabled = true;
                    this.txtNivelDescripcion.Enabled = true;
                    this.chkVigenteNivel.Enabled = true;

                    this.tsbGrabarNivel.Visible = false;
                    this.tsbDeshacer.Visible = false;
                    this.tsbNuevoNivel.Visible = false;
                    this.tsbEditarNivel.Visible = false;
                    this.tsbQuitarNivel.Visible = false;

                    this.btnAceptarNivel.Visible = true;
                    this.btnCancelarNivel.Visible = true;
                    break;
                case clsAcciones.NUEVO:
                    this.txtAprobacionNivel.Enabled = true;
                    this.txtAcronimoNivel.Enabled = true;
                    this.txtOrden.Enabled = true;
                    this.txtNivelDescripcion.Enabled = true;
                    this.chkVigenteNivel.Enabled = true;

                    this.tsbGrabarNivel.Visible = false;
                    this.tsbDeshacer.Visible = false;
                    this.tsbNuevoNivel.Visible = false;
                    this.tsbEditarNivel.Visible = false;
                    this.tsbQuitarNivel.Visible = false;

                    this.btnAceptarNivel.Visible = true;
                    this.btnCancelarNivel.Visible = true;
                    break;
            }
        }
        private void btnAceptarNivel_Click(object sender, EventArgs e)
        {
            this.agregarNivel();
        }
        private void btnCancelarNivel_Click(object sender, EventArgs e)
        {
            this.limpiarNivelEdit();
            this.lEditNivel = false;
            this.habilitarNivelEdit(clsAcciones.DEFECTO);
        }
        private void tsbGrabarNivel_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("¿Esta seguro de grabar los cambios realizados?","COMFIRMACION",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((this.lEditNivel || this.lAddNivel || this.lAddPerfil) && DialogResult.Yes == dResult)
            {
                this.grabarAprobacionNivel();
            }
        }

        private void tsbNuevoNivel_Click(object sender, EventArgs e)
        {
            this.limpiarNivelEdit();
            this.habilitarNivelEdit(clsAcciones.NUEVO);
            this.txtVistaCanal.Text = this.objAprobacionCanal.cAprobacionCanal;
            this.lEditNivel = false;
        }

        private void tsbDeshacer_Click(object sender, EventArgs e)
        {
            this.listarAprobacionNivel();
            this.lAddNivel = false;
            this.lEditNivel = false;
            this.habilitarNivelEdit(clsAcciones.DEFECTO);
        }

        private void tsbEditarNivel_Click(object sender, EventArgs e)
        {
            if (this.dtgAprobacionNivel.SelectedRows.Count == 0)
            {
                MessageBox.Show("¡Debe seleccionar un nivel de aprobación para editar!",
                    "SELECCIONE NIVEL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.distribuirNivelEdit();
            this.habilitarNivelEdit(clsAcciones.EDITAR);
            this.lEditNivel = true;
        }

        private void tsbQuitarNivel_Click(object sender, EventArgs e)
        {
            if (this.dtgAprobacionNivel.SelectedRows.Count == 0)
            {
                MessageBox.Show("¡Debe seleccionar un nivel de aprobación para deshabilitar!",
                    "SELECCIONE NIVEL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.objAprobacionNivel.idAprobacionNivel == 0)
            {
                this.lstAprobacionNivel.Remove(this.objAprobacionNivel);
            }
            else
            {
                this.objAprobacionNivel.lVigente = false;
                this.tsbGrabarNivel.Visible = true;
                this.lAddNivel = true;
            }
            this.bsAprobacionNivel.ResetBindings(false);
            this.dtgAprobacionNivel.Refresh();
        }
        private void dtgAprobacionNivel_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAprobacionNivel.SelectedRows.Count == 0)
            {
                this.objAprobacionNivel = new clsAprobacionNivel();
            }
            else
            {
                int nIndice = this.dtgAprobacionNivel.SelectedRows[0].Index;
                this.objAprobacionNivel = this.lstAprobacionNivel[nIndice];
                this.listarPerfilAprobador();
            }
        }
        #endregion

        #region Perfil Aprobador
        private void listarPerfilAprobador()
        {
            this.lstPerfil.Clear();
            if (this.objAprobacionNivel.lIdsPerfilModif)
            {
                if (this.objAprobacionNivel.lstPerfil != null)
                {
                    this.lstPerfil.AddRange(this.objAprobacionNivel.lstPerfil.FindAll(x => x.idPerfil > 0));
                }
            }
            else
            {
                this.lstPerfil.AddRange(this.objCNMantAprobacion.listarPerfilAprobador(this.objAprobacionNivel.idAprobacionNivel));
            }
            if (this.lstPerfil.Count == 0)
            {
                MessageBox.Show("El nivel \"" + this.objAprobacionNivel.cAprobacionNivel +
                "\", no tiene perfiles de aprobador asignados.\n\n" +
                "* Debe agregar al menos un aprobador para que el nivel sea activado",
                "RESULTADO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.tsbAgregarPerfil.Visible = true;
            }

            this.bsPerfilAprobador.ResetBindings(false);
            this.dtgPerfilAprobador.Refresh();
        }
        private void actualizarNivelIniFin()
        {
            int idNivelIni = 0;
            int idNivelFin = 0;
            int nCantNiveles = this.lstAprobacionNivel.Count;
            if (nCantNiveles > 0)
            {
                if (this.lstAprobacionNivel[0].nOrden == 0)
                {
                    if (nCantNiveles > 1)
                    {
                        idNivelIni = this.lstAprobacionNivel[1].idAprobacionNivel;
                        idNivelFin = this.lstAprobacionNivel[nCantNiveles - 1].idAprobacionNivel;
                    }
                }
                else
                {
                    idNivelIni = this.lstAprobacionNivel[0].idAprobacionNivel;
                    idNivelFin = this.lstAprobacionNivel[nCantNiveles - 1].idAprobacionNivel;
                }
            }

            this.objAprobacionCanal.idAprobacionNivelInicio = idNivelIni;
            this.objAprobacionCanal.idAprobacionNivelFin =  idNivelFin;
            this.dtgAprobacionCanal.SelectionChanged -= this.dtgAprobacionCanal_SelectionChanged;
            this.bsAprobacionCanal.ResetBindings(false);
            this.dtgAprobacionCanal.Refresh();
            this.dtgAprobacionCanal.SelectionChanged += this.dtgAprobacionCanal_SelectionChanged;
            
        }
        private void actualizarNivelIdsPerfil()
        {
            string cIdsPerfil = string.Empty;
            foreach (clsPerfil objPerfil in this.lstPerfil)
            {
                cIdsPerfil += string.Concat(objPerfil.idPerfil.ToString(), ",");
            }

            if (cIdsPerfil.Length > 0)
            {
                cIdsPerfil = cIdsPerfil.Substring(0, cIdsPerfil.Length - 1);
                this.objAprobacionNivel.lstPerfil = this.lstPerfil.FindAll(x => x.idPerfil > 0);
            }
            else
            {
                this.objAprobacionNivel.lstPerfil = new List<clsPerfil>();
            }
            this.objAprobacionNivel.cIdsPerfil = cIdsPerfil;
            this.objAprobacionNivel.lIdsPerfilModif = true;
            this.dtgAprobacionNivel.SelectionChanged-= this.dtgAprobacionNivel_SelectionChanged;
            this.bsAprobacionNivel.ResetBindings(false);
            this.dtgAprobacionNivel.Refresh();
            this.dtgAprobacionNivel.SelectionChanged += this.dtgAprobacionNivel_SelectionChanged;
            this.tsbGrabarNivel.Visible = true;
        }
        private void agregarPerfil()
        {
            frmPerfilBuscador objPerfilBuscador = new frmPerfilBuscador();
            objPerfilBuscador.ShowDialog();

            if (objPerfilBuscador.objPerfil != null && objPerfilBuscador.objPerfil.idPerfil > 0)
            {
                clsPerfil objPerfilNuevo = (clsPerfil)objPerfilBuscador.objPerfil.Clone();
                this.lstPerfil.Add(objPerfilNuevo);
                this.bsPerfilAprobador.ResetBindings(false);
                this.dtgPerfilAprobador.Refresh();

                this.actualizarNivelIdsPerfil();
                this.lAddPerfil = true;
            }
        }
        private void tsbAgregarPerfil_Click(object sender, EventArgs e)
        {
            this.agregarPerfil();
        }

        private void tsbQuitarPerfil_Click(object sender, EventArgs e)
        {
            if(this.objPerfil.idPerfil == 0)
            {
                MessageBox.Show("¡Debe seleccionar un perfil para quitar!","SELECCION VACIA",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dResult =  MessageBox.Show("¿Esta seguro de quitar el perfil "+
                this.objPerfil.cPerfil +"?","CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dResult == DialogResult.Yes)
            {
                this.lstPerfil.Remove(this.objPerfil);
                
                this.bsPerfilAprobador.ResetBindings(false);
                this.dtgPerfilAprobador.Refresh();
                this.actualizarNivelIdsPerfil();

                this.lAddPerfil = true;
            }
        }
        private void dtgPerfilAprobador_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPerfilAprobador.SelectedRows.Count == 0)
            {
                this.objPerfil = new clsPerfil();
            }
            else
            {
                int nIndice = this.dtgPerfilAprobador.SelectedRows[0].Index;
                this.objPerfil = this.lstPerfil[nIndice];
            }
        }
        #endregion

        #region Eventos General
        private void frmMantenimientoAprobacionGenerica_Load(object sender, EventArgs e)
        {
            this.listarAprobacionCanal();
            this.listarAprobacionSolTipo();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

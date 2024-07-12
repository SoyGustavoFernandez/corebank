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
using CRE.CapaNegocio;
using EntityLayer;
using System.Text.RegularExpressions;

namespace CRE.Presentacion
{
    public partial class frmEvalCredAlertaVariable : frmBase
    {
        #region Variables Globales
        private clsCNAlertaVariable objCNAlertaVariable;
        private clsEvalCredAlertaVarResumen objEvalCredAlertaVarResumen;
        private List<clsEvalCredAlertaVariable> lstEvalCredAlertaVariable;

        private clsEvalCredAlertaVariable objEvalCredAlertaVariable;
        private int nIndiceFila;
        private bool lModoVista;
        private bool lModoComformidad = false;

        public bool lGrabado;
        public bool lComforme;
        public bool lDenegadoSolEvalCred;
        public bool lConformeCheck = false;
        public bool lValidaFormulario = false;

        private int idEvalCred;
        private int idSolicitud;
        private int idFormulario;

        public int nRecdDesfavorable;
        public int nDesfavorable;
        public int nSinResolucion;
        #endregion

        public frmEvalCredAlertaVariable()
        {
            InitializeComponent();
            this.lModoVista = false;
            this.idSolicitud = 0;
            this.idEvalCred = 0;

            this.lDenegadoSolEvalCred = false;
            this.inicializarDatos();
        }

        public frmEvalCredAlertaVariable(int idSolicitud, int idEvalCred)
        {
            InitializeComponent();
            this.lModoVista = false;
            this.lModoComformidad = true;
            this.idSolicitud = idSolicitud;
            this.idEvalCred = idEvalCred;

            this.lDenegadoSolEvalCred = false;
            this.inicializarDatos();
        }

        public frmEvalCredAlertaVariable(int idSolicitud, int idEvalCred, int idFormulario)
        {
            InitializeComponent();
            this.lModoVista = false;
            this.lModoComformidad = true;
            this.lValidaFormulario = true;
            this.idSolicitud = idSolicitud;
            this.idEvalCred = idEvalCred;
            this.idFormulario = idFormulario;

            this.lDenegadoSolEvalCred = false;
            this.inicializarDatos();
        }

        public frmEvalCredAlertaVariable(List<clsEvalCredAlertaVariable> lstEvalCredAlertaVariable)
        {
            InitializeComponent();
            this.lModoVista = true;
            this.idSolicitud = 0;
            this.idEvalCred = 0;

            this.lDenegadoSolEvalCred = false;
            this.inicializarDatos();
            this.lstEvalCredAlertaVariable.Clear();
            this.lstEvalCredAlertaVariable.AddRange(lstEvalCredAlertaVariable);

            lGrabado = !this.lstEvalCredAlertaVariable.Exists(x=>x.lReqVistoBueno && x.cSustento.Equals(string.Empty));
        }
        public frmEvalCredAlertaVariable(List<clsEvalCredAlertaVariable> lstEvalCredAlertaVariable, int idSolicitud)
        {
            InitializeComponent();
            this.lModoVista = true;
            this.idSolicitud = idSolicitud;
            this.idEvalCred = 0;

            this.lDenegadoSolEvalCred = false;
            this.inicializarDatos();
            this.lstEvalCredAlertaVariable.Clear();
            this.lstEvalCredAlertaVariable.AddRange(lstEvalCredAlertaVariable);

            lGrabado = !this.lstEvalCredAlertaVariable.Exists(x => x.lReqVistoBueno && x.cSustento.Equals(string.Empty));
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNAlertaVariable = new clsCNAlertaVariable();
            this.lstEvalCredAlertaVariable = new List<clsEvalCredAlertaVariable>();
            this.objEvalCredAlertaVariable = new clsEvalCredAlertaVariable();

            this.bsEvalCredAlertaVariable.DataSource = this.lstEvalCredAlertaVariable;
            this.nIndiceFila = -1;
            this.lGrabado = false;
            this.lComforme = false;

            this.nRecdDesfavorable = 0;
            this.nDesfavorable = 0;
            this.nSinResolucion = 0;

            this.habilitarControles(clsAcciones.DEFECTO);
        }
        private void gestionarModoVista()
        {
            this.gbxEvalCred.Visible = false;
            this.bsEvalCredAlertaVariable.ResetBindings(false);
            this.dtgEvalCredAlertaVariable.Refresh();
            this.habilitarControles(clsAcciones.VISTA);
            this.formatoColorSustento();
        }
        private void listarEvalCredAlerta(int idEvalCred)
        {
            this.lstEvalCredAlertaVariable.Clear();
            this.lstEvalCredAlertaVariable.AddRange(this.objCNAlertaVariable.listarEvalCredAlertaVariable(idEvalCred));

            if (this.lstEvalCredAlertaVariable.Count(x => x.cResulEval == null) > 0)
            {
                foreach (clsEvalCredAlertaVariable alertaEvaluacion in this.lstEvalCredAlertaVariable)
                {
                    bool lvalor = Regex.IsMatch(alertaEvaluacion.cValor, "[A-Z]");
                    if (lvalor == true)
                    {
                        alertaEvaluacion.cResulEval = alertaEvaluacion.cValor;
                    }
                    else 
                    {
                        alertaEvaluacion.cResulEval = (decimal.Round(this.calcularValor(alertaEvaluacion.cValor) * 100, 2).ToString() + '%').ToString();
                    }
                }
                clsRespuestaServidor objRespuestaServidor = objCNAlertaVariable.grabarEvalCredAlertaVariable(lstEvalCredAlertaVariable);
            }

            if (this.lModoComformidad && this.lstEvalCredAlertaVariable.Count == 0)
            {
                if(this.lValidaFormulario == true)
                {
                    MessageBox.Show("Para este crédito no existe ninguna Alerta de Evaluación.", "ALERTAS DE EVALUACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.lValidaFormulario = false;
                }
                this.lComforme = true;
                this.Close();
            }
            
            this.bsEvalCredAlertaVariable.ResetBindings(false);
            this.dtgEvalCredAlertaVariable.Refresh();

            if (this.lstEvalCredAlertaVariable.Count > 0)
            {
                this.habilitarControles(clsAcciones.RECUPERAR);
                this.formatoColorEvalCredAlertaVariable();
            }
            else
            {
                this.habilitarControles(clsAcciones.DEFECTO);
            }
        }
        private decimal calcularValor(string cCondicion)
        {
            int nIndiceSigno = 0;
            if (cCondicion.Contains(">") == true)
            {
                nIndiceSigno = cCondicion.IndexOf(">");
                cCondicion = cCondicion.Substring(0, nIndiceSigno);
            }
            else if (cCondicion.Contains("<") == true)
            {
                nIndiceSigno = cCondicion.IndexOf("<");
                cCondicion = cCondicion.Substring(0, nIndiceSigno);
            }
            else if (cCondicion.Contains("=") == true)
            {
                nIndiceSigno = cCondicion.IndexOf("=");
                cCondicion = cCondicion.Substring(0, nIndiceSigno);
            }
            decimal nNumero = 0;
            char cOperador = '+';
            decimal nTemporal = 0;
            decimal nResultado = 0;

            var lResultado = decimal.TryParse(cCondicion, out nResultado);
            if (lResultado)
            {
                return decimal.Round(nResultado, 4);
            }

            for (int i = 0; i < cCondicion.Length; i++)
            {
                char cCaracter = cCondicion[i];
                if (cCaracter == '(')
                {
                    int nContParentesis = 0;
                    int nTemporal2 = i;
                    for (; i < cCondicion.Length; i++)
                    {
                        if (cCondicion[i] == '(') nContParentesis++;
                        if (cCondicion[i] == ')') nContParentesis--;
                        if (nContParentesis == 0)
                        {
                            break;
                        }
                    }
                    nNumero = calcularValor(cCondicion.Substring(nTemporal2 + 1, i - nTemporal2));
                }
                if (Char.IsDigit(cCaracter))
                {
                    nNumero = nNumero * 10 + cCaracter - 48;
                }
                if (cCaracter == '+' || cCaracter == '-' || cCaracter == '*' || cCaracter == '/' || i == cCondicion.Length - 1)
                {
                    switch (cOperador)
                    {
                        case '+': nTemporal += nNumero; break;
                        case '-': nTemporal -= nNumero; break;
                        case '*': nTemporal *= nNumero; break;
                        case '/': nTemporal /= nNumero; break;
                    }
                    if (cCaracter == '+' || cCaracter == '-' || i == cCondicion.Length - 1)
                    {
                        nResultado += nTemporal;
                        nTemporal = 0;
                    }
                    nNumero = 0;
                    cOperador = cCaracter;
                }
            }
            return decimal.Round(nResultado, 4);
        }
        private void mostrarDatosCredito()
        {
            this.txtAsesor.Text = this.objEvalCredAlertaVarResumen.cAsesor;
            this.txtCliente.Text = this.objEvalCredAlertaVarResumen.cCliente;
            this.txtProducto.Text = this.objEvalCredAlertaVarResumen.cProducto;
            this.nudCapitalPropuesto.Value = this.objEvalCredAlertaVarResumen.nCapitalPropuesto;
            this.nudCuotas.Value = (decimal)this.objEvalCredAlertaVarResumen.nCuotas;
            this.nudPlazoCuota.Value = (decimal)this.objEvalCredAlertaVarResumen.nPlazoCuota;
        }
        private void limpiarControlesTodo()
        {
            this.txtAsesor.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.nudCapitalPropuesto.Value = decimal.Zero;
            this.nudCuotas.Value = decimal.Zero;
            this.nudPlazoCuota.Value = decimal.Zero;

            this.lstEvalCredAlertaVariable.Clear();
            this.bsEvalCredAlertaVariable.ResetBindings(false);
            this.dtgEvalCredAlertaVariable.Refresh();

            this.txtValor.Text = string.Empty;
            this.txtAlertaVariable.Text = string.Empty;
            this.txtSustento.Text = string.Empty;
            this.txtComentario.Text = string.Empty;
        }
        private void gestionarControles()
        {
            if (this.objEvalCredAlertaVariable.idTipoResolucionRecd > 0)
            {
                this.habilitarControles(clsAcciones.FINALIZAR);
            }
            else if (this.objEvalCredAlertaVariable.idTipoResolucion == 0)
            {
                this.habilitarControles(clsAcciones.NUEVO);
            }
            else if (this.objEvalCredAlertaVariable.idTipoResolucion.In(1,2))
            {
                this.habilitarControles(clsAcciones.EDITAR);
            }
        }
        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.dtgEvalCredAlertaVariable.ClearSelection();
                    this.dtgEvalCredAlertaVariable.Enabled = false;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = true;
                    this.btnAtender.Visible = false;

                    this.pnlEditor.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.VISTA:
                    this.dtgEvalCredAlertaVariable.ClearSelection();
                    this.dtgEvalCredAlertaVariable.Enabled = true;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = false;
                    this.btnAtender.Visible = false;

                    this.pnlEditor.Visible = true;
                    this.btnAgregar.Visible = false;
                    this.btnEditar.Visible = false;
                    this.btnQuitar.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.RECUPERAR:
                    this.dtgEvalCredAlertaVariable.ClearSelection();
                    this.dtgEvalCredAlertaVariable.Enabled = (this.lModoComformidad)?this.lModoComformidad:false;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = (!this.lModoVista && !this.lModoComformidad);
                    this.btnAtender.Visible = (!this.lModoVista && !this.lModoComformidad);

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    if (this.idFormulario == 1569 || this.idFormulario == 1567)
                    {
                        this.btnAgregar2.Visible = true;
                        this.btnGrabar2.Visible = true;
                        this.btnAgregar2.Enabled = false;
                        this.btnGrabar2.Enabled = false;
                        this.pnlComenRevision.Visible = true;
                    }
                    break;
                case clsAcciones.RESOLVER:
                    this.dtgEvalCredAlertaVariable.ClearSelection();
                    this.dtgEvalCredAlertaVariable.Enabled = true;
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = (!this.lModoVista && !this.lModoComformidad);
                    this.btnAtender.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.NUEVO:
                    this.btnAprobar.Visible = true;
                    this.btnDenegar.Visible = true;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = false;
                    this.btnAtender.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.EDITAR:
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = true;

                    this.btnBuzon.Visible = false;
                    this.btnAtender.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.FINALIZAR:
                    this.btnAprobar.Visible = false;
                    this.btnDenegar.Visible = false;
                    this.btnReconsiderar.Visible = false;

                    this.btnBuzon.Visible = (!this.lModoVista && !this.lModoComformidad);
                    this.btnAtender.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
            }
        }
        private void habilitarControlesAprobador()
        {
            this.btnAceptar.Visible = true;

            this.gbxEvalCred.Visible = false;

            this.dtgEvalCredAlertaVariable.Enabled = true;
            this.btnAprobar.Visible = false;
            this.btnDenegar.Visible = false;
            this.btnReconsiderar.Visible = false;

            this.btnBuzon.Visible = false;
            this.btnAtender.Visible = false;
            this.pnlEditor.Visible = false;

            this.btnSalir.Visible = false;

            this.btnAgregar2.Visible = false;
            this.btnGrabar2.Visible = false;
            
            if(this.idFormulario == 1569 || this.idFormulario == 1567)
            {
                this.pnlComenRevision.Visible = true;
                this.btnAceptar.Visible = false;
                this.btnAgregar2.Visible = true;
                this.btnGrabar2.Visible = true;
                this.btnAgregar2.Enabled = true;
                this.btnGrabar2.Enabled = true;
                this.txtComentario.Enabled = true;
                this.btnSalir.Visible = true;
            }
        }
        private void formatoColorEvalCredAlertaVariable()
        {
            foreach(DataGridViewRow dtRow in this.dtgEvalCredAlertaVariable.Rows)
            {
                clsEvalCredAlertaVariable objAlerta = (clsEvalCredAlertaVariable)dtRow.DataBoundItem;
                if (objAlerta.idTipoResolucionRecd == (int)TipoResolucion.Favorable)
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (objAlerta.idTipoResolucionRecd == (int)TipoResolucion.Desfavorable)
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                else if (objAlerta.idTipoResolucion == (int)TipoResolucion.Favorable)
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (objAlerta.idTipoResolucion == (int)TipoResolucion.Desfavorable)
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
                else if (objAlerta.idTipoResolucion == (int)TipoResolucion.Ninguno)
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        private void formatoColorSustento()
        {
            bool lMensaje = false;
            foreach (DataGridViewRow dtRow in this.dtgEvalCredAlertaVariable.Rows)
            {
                clsEvalCredAlertaVariable objAlerta = (clsEvalCredAlertaVariable)dtRow.DataBoundItem;
                if (objAlerta.lReqVistoBueno && objAlerta.cSustento.Equals(string.Empty))
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                    lMensaje = true;
                }
            }
            if (lMensaje) MessageBox.Show("Todas las alertas marcadas en color Naranja requieren que se ingrese un sustento para solicitar su Visto Bueno.\n"
                + "*Ingrese los sustentos requeridos.\n\n**No se le permitirá enviar a aprobación sin los sustentos requeridos.", "SUSTENTO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void emitirResolucionEvalCredAlerta(TipoResolucion idTipoResolucion, TipoResolucion idTipoResolucionRecd)
        {
            if (this.nIndiceFila < 0)
            {
                MessageBox.Show("Seleccione un ítem para resolver","ITEM NO SELECCIONADO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.emitirResolucionEvalCredAlerta(
                this.objEvalCredAlertaVariable.idEvalCred,
                this.objEvalCredAlertaVariable.idAlertaVariable,
                (int)idTipoResolucion,
                (int)idTipoResolucionRecd);

            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje,"RESOLUCION EMITIDA",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lstEvalCredAlertaVariable[this.nIndiceFila].idTipoResolucion = (int)idTipoResolucion;
                this.lstEvalCredAlertaVariable[this.nIndiceFila].idTipoResolucionRecd = (int)idTipoResolucionRecd;
                this.formatoColorEvalCredAlertaVariable();
                this.habilitarControles(clsAcciones.FINALIZAR);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iniciarResolucionEvalCredAlerta()
        {
            clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.iniciarResolucionEvalCredAlerta(this.objEvalCredAlertaVarResumen.idEvalCred);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "ATENCION INICIADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.RESOLVER);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje,"EXEPCION",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void habilitarSustentoControl(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.NUEVO:
                    this.txtSustento.Enabled = false;

                    this.btnAgregar.Visible = false;
                    this.btnEditar.Visible = true;
                    this.btnQuitar.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.EDITAR:
                    this.txtSustento.Enabled = true;

                    this.btnAgregar.Visible = true;
                    this.btnEditar.Visible = false;
                    this.btnQuitar.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.GRABAR:
                    this.txtSustento.Enabled = false;

                    this.btnAgregar.Visible = false;
                    this.btnEditar.Visible = true;
                    this.btnQuitar.Visible = true;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.CANCELAR:
                    this.txtSustento.Enabled = false;

                    this.btnAgregar.Visible = false;
                    this.btnEditar.Visible = true;
                    this.btnQuitar.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
                case clsAcciones.FINALIZAR:
                    this.txtSustento.Enabled = false;

                    this.btnAgregar.Visible = false;
                    this.btnEditar.Visible = false;
                    this.btnQuitar.Visible = false;

                    this.btnAgregar2.Visible = false;
                    this.btnGrabar2.Visible = false;
                    this.txtComentario.Enabled = false;
                    this.pnlComenRevision.Visible = false;
                    break;
            }
        }
        private void gestionarSustentoControl()
        {
            this.txtSustento.Text = this.objEvalCredAlertaVariable.cSustento;
            if (this.objEvalCredAlertaVariable.lReqVistoBueno && this.objEvalCredAlertaVariable.idTipoResolucion == 0)
            {
                if (this.objEvalCredAlertaVariable.cSustento.Length > 0)
                {
                    this.habilitarSustentoControl(clsAcciones.CANCELAR);
                }
                else
                {
                    this.habilitarSustentoControl(clsAcciones.NUEVO);
                }
            }
            else if (this.objEvalCredAlertaVariable.idTipoResolucion.In(1, 2))
            {
                this.habilitarSustentoControl(clsAcciones.FINALIZAR);
            }
        }
        public void grabarEvalCredAlertaVariable()
        {
            List<clsEvalCredAlertaVariable> objEvalCredAlertaVB = this.lstEvalCredAlertaVariable.FindAll(x => x.lReqVistoBueno == true);

            if (objEvalCredAlertaVB == null) { this.lGrabado = true; return; }

            if (this.lstEvalCredAlertaVariable.Count(x => x.cResulEval == null) > 0)
            {
                foreach (clsEvalCredAlertaVariable alertaEvaluacion in objEvalCredAlertaVB)
                {
                    bool lvalor = Regex.IsMatch(alertaEvaluacion.cValor, "[A-Z]");
                    if (lvalor == true)
                    {
                        alertaEvaluacion.cResulEval = alertaEvaluacion.cValor;
                    }
                    else
                    {
                        alertaEvaluacion.cResulEval = (decimal.Round(this.calcularValor(alertaEvaluacion.cValor) * 100, 2).ToString() + '%').ToString();
                    }
                }
            }

            if (this.lstEvalCredAlertaVariable.Count(x => x.idTipoResolucion == 1) > 0)
            {
                foreach (clsEvalCredAlertaVariable alertaEvaluacion in objEvalCredAlertaVB)
                {
                    alertaEvaluacion.idUsuResolucion = clsVarGlobal.User.idUsuario;
                }
            }

            clsRespuestaServidor objRespuestaServidor = objCNAlertaVariable.grabarEvalCredAlertaVariable(objEvalCredAlertaVB);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                DataTable dtMontoMin = this.objCNAlertaVariable.montoMinAlertaEval(this.idSolicitud);
                if (Convert.ToInt32(dtMontoMin.Rows[0]["nAlertasEval"]) == 1)
                {
                    if(objEvalCredAlertaVB.Count > 0)
                    {
                        MessageBox.Show(objRespuestaServidor.cMensaje, "ALERTAS GRABADAS CORRECTAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.lGrabado = true;
            }
            else
            {
                    MessageBox.Show(objRespuestaServidor.cMensaje, "ERROR DE GRABADO DE ALERTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lGrabado = false;
            }
        }
        private bool existeEvalCredAlertaDesfavorable()
        {
            if (this.lstEvalCredAlertaVariable == null)
            {
                return false;
            }

            List<clsEvalCredAlertaVariable> lstAlertasDesfavorables = this.lstEvalCredAlertaVariable.FindAll(x => x.idTipoResolucion == (int)TipoResolucion.Desfavorable);

            if(lstAlertasDesfavorables != null && lstAlertasDesfavorables.Exists(x=>x.idTipoResolucionRecd.In((int)TipoResolucion.Desfavorable,(int)TipoResolucion.Ninguno)))
            {
                return true;
            }
            return false;
        }
        private void contarTipoResolucion()
        {
            this.nSinResolucion = this.lstEvalCredAlertaVariable.Count(x=>x.idTipoResolucion == (int)TipoResolucion.Ninguno);
            this.nDesfavorable = this.lstEvalCredAlertaVariable.Count(x => x.idTipoResolucionRecd == (int)TipoResolucion.Ninguno && x.idTipoResolucion == (int)TipoResolucion.Desfavorable);
            this.nRecdDesfavorable = this.lstEvalCredAlertaVariable.Count(x=>x.idTipoResolucionRecd == (int)TipoResolucion.Desfavorable);
        }
        public void validarResolucionDesfavorable()
        {
            bool lExisteDesfavorable = this.existeEvalCredAlertaDesfavorable();
            this.lComforme = true;

            if (lExisteDesfavorable)
            {
                DialogResult idResultado = MessageBox.Show("¡La propuesta de crédito actual tiene visto(s) bueno(s) desfavorable(s)!\n\n" +
                    "¿Desea detener la aprobación para comunicarse con el área de riesgos y solicitar una reconsideración de visto bueno?\n\n" +
                    "**Si hace clic sobre el botón 'NO' el crédito será denegado automáticamente.",
                    "COMFIRMACION DE DENEGADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (idResultado == DialogResult.Yes)
                {
                    this.lComforme = false;
                    this.lDenegadoSolEvalCred = false;
                }
                else
                {
                    clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.denegarSolicitudCredDesfavorable(this.idSolicitud, this.idEvalCred);
                    if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                    {
                        MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.lDenegadoSolEvalCred = true;
                    }
                    else
                    {
                        MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.lDenegadoSolEvalCred = false;
                        this.lComforme = false;
                    }
                }
            }
        }
        public void validarCheck()
        {
            this.listarEvalCredAlerta(this.idEvalCred);
            if (this.lstEvalCredAlertaVariable.Count(x => x.idTipoResolucion == (int)TipoResolucion.Ninguno) > 0)
            {
                this.lConformeCheck = true;
            }
            this.validarResolucionDesfavorable();
        }
        #endregion
        #region Eventos
        private void frmEvalCredAlertaVariable_Shown(object sender, EventArgs e)
        {
            if (this.lstEvalCredAlertaVariable.Count > 0)
                this.gestionarModoVista();
            else if (this.lModoComformidad)
            {
                this.habilitarControlesAprobador();
                this.listarEvalCredAlerta(this.idEvalCred);
            }
        }
        private void dtgEvalCredAlertaVariable_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgEvalCredAlertaVariable.SelectedRows.Count == 0) return;

            this.nIndiceFila = this.dtgEvalCredAlertaVariable.SelectedRows[0].Index;
            this.objEvalCredAlertaVariable = this.lstEvalCredAlertaVariable[nIndiceFila];

            this.txtAlertaVariable.Text = this.objEvalCredAlertaVariable.cAlertaVariable;
            this.txtValor.Text = this.objEvalCredAlertaVariable.cValor;
            this.txtSustento.Text = this.objEvalCredAlertaVariable.cSustento;
            this.txtComentario.Text = this.objEvalCredAlertaVariable.cComenRevision;

            if (this.lModoComformidad)
            {
                this.habilitarControlesAprobador();
            }
            else if (this.lModoVista)
            {
                this.gestionarSustentoControl();
            }
            else
            {
                this.gestionarControles();
            }
        }
        private void btnBuzon_Click(object sender, EventArgs e)
        {
            frmEvalCredAlertaVarBuzon objFrmEvalCredAlertaVarBuzon = new frmEvalCredAlertaVarBuzon();
            objFrmEvalCredAlertaVarBuzon.ShowDialog();
            if (objFrmEvalCredAlertaVarBuzon.objEvalCredAlertaVarResumen != null)
            {
                this.objEvalCredAlertaVarResumen = objFrmEvalCredAlertaVarBuzon.objEvalCredAlertaVarResumen;
                this.mostrarDatosCredito();
                this.listarEvalCredAlerta(this.objEvalCredAlertaVarResumen.idEvalCred);
            }
            else
            {
                this.limpiarControlesTodo();
                this.habilitarControles(clsAcciones.DEFECTO);
            }
        }
        private void btnAtender_Click(object sender, EventArgs e)
        {
            this.iniciarResolucionEvalCredAlerta();
        }
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            this.emitirResolucionEvalCredAlerta(TipoResolucion.Favorable, TipoResolucion.Ninguno);
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            this.emitirResolucionEvalCredAlerta(TipoResolucion.Desfavorable, TipoResolucion.Ninguno);
        }

        private void btnReconsiderar_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("¡La emisión de reconsideración se permite una sola vez por ítem!\n\n" +
            "¿está seguro de emitir la reconsideración para este ítem?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult != DialogResult.Yes) return;

            frmEvalCredAlertaReconsideracion objAlertaReconsideracion = new frmEvalCredAlertaReconsideracion();
            objAlertaReconsideracion.ShowDialog();

            TipoResolucion idResolucion = objAlertaReconsideracion.idTipoResolucion;

            if (idResolucion == TipoResolucion.Desfavorable)
            {
                DialogResult idRecomfirmacion = MessageBox.Show("¡Con una reconsideración DESFAVORABLE el crédito será DENEGADO!\n\n" +
                "¿Está seguro de emitir una RECONSIDERACION DESFAVORABLE?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (idRecomfirmacion == DialogResult.No) return;
            }

            this.emitirResolucionEvalCredAlerta((TipoResolucion)this.objEvalCredAlertaVariable.idTipoResolucion, idResolucion);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.txtSustento.Text.Length <= 0)
            {
                MessageBox.Show("El campo Sustento no puede estar vacío.\n¡Ingrese el contenido del sustento para solicitar un visto bueno!", "SUSTENTO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.objEvalCredAlertaVariable.cSustento = this.txtSustento.Text;
            this.habilitarSustentoControl(clsAcciones.GRABAR);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitarSustentoControl(clsAcciones.EDITAR);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult idResultado = MessageBox.Show("Se requerirá el sustento para ser enviado a aprobación, ¿Esta seguro de borrar el sustento?", "BORRADO DE SUSTENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (idResultado == DialogResult.Yes)
            {
                this.objEvalCredAlertaVariable.cSustento = string.Empty;
                this.txtSustento.Text = string.Empty;
                this.habilitarSustentoControl(clsAcciones.CANCELAR);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.grabarEvalCredAlertaVariable();
        }
        private void frmEvalCredAlertaVariable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.contarTipoResolucion();
            if (this.lModoVista && !this.lModoComformidad && !this.lGrabado)
            {
                MessageBox.Show("No se han grabado los sustentos requeridos de las alerta de evaluación.\n\n" +
                "¡No se le permitirá salir de este formulario hasta que grabe los sustentos!", "SUSTENTO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.validarCheck();
            this.validarResolucionDesfavorable();
            this.Close();
        }
        #endregion

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se agregó el comentario correctamente.", "COMENTARIO AGREGADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.objEvalCredAlertaVariable.cComenRevision = this.txtComentario.Text;
            this.dtgEvalCredAlertaVariable.Refresh();
            this.txtComentario.Enabled = false;
        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            this.grabarEvalCredAlertaVariable();
            this.habilitarControles(clsAcciones.RECUPERAR);
            this.txtComentario.Text = "";
        }

        private void dtgEvalCredAlertaVariable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (this.idFormulario == 1569 || this.idFormulario == 1567)
            {
                if (this.dtgEvalCredAlertaVariable.Columns[e.ColumnIndex].Name == "lCheck")
                {
                    DataGridViewRow lFila = this.dtgEvalCredAlertaVariable.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell lCelda = lFila.Cells["lCheck"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(lCelda.Value) == true)
                    {
                        this.objEvalCredAlertaVariable.idTipoResolucion = 0;
                        this.formatoColorEvalCredAlertaVariable();
                    }
                    else
                    {
                        this.objEvalCredAlertaVariable.idTipoResolucion = 1;
                        this.formatoColorEvalCredAlertaVariable();
                    }
                    this.dtgEvalCredAlertaVariable.Refresh();
                }
            }
        }
    }
}

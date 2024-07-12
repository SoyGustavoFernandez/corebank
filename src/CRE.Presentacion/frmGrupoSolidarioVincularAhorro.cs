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
namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioVincularAhorro : frmBase
    {
        #region Variables Globales
        private clsCNGrupoSolidario objCNGrupoSolidario;
        private List<clsGrupoSolidarioAhorro> lstGrupoSolidarioAhorro;
        private List<clsGrupoSolIntegranteCtaAhorro> lstGrupoSolIntegranteCtaAhorro;

        private int idGrupoSolidario;
        private int idSolicitudCredGrupoSol;
        private int idOperacion;
        private int nIndiceFila;

        private int idCuentaAhorroSeleccion;
        private bool lDesembolso;
        public int nAhorroSuficiente;

        public int nCuentasVinculadas;
        public int nCuentasSinValidar;
        
        #endregion
        public frmGrupoSolidarioVincularAhorro()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        public frmGrupoSolidarioVincularAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            InitializeComponent();
            this.idGrupoSolidario = idGrupoSolidario;
            this.idSolicitudCredGrupoSol = idSolicitudCredGrupoSol;
            this.lDesembolso = false;
            this.inicializarDatos();
        }
        public frmGrupoSolidarioVincularAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol, int idOperacion)
        {
            InitializeComponent();
            this.idGrupoSolidario = idGrupoSolidario;
            this.idSolicitudCredGrupoSol = idSolicitudCredGrupoSol;
            this.idOperacion = idOperacion;
            this.lDesembolso = false;
            this.inicializarDatos();
        }
        public frmGrupoSolidarioVincularAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol, int idOperacion, bool lDesembolso)
        {
            InitializeComponent();
            this.idGrupoSolidario = idGrupoSolidario;
            this.idSolicitudCredGrupoSol = idSolicitudCredGrupoSol;
            this.idOperacion = idOperacion;
            this.lDesembolso = lDesembolso;
            this.inicializarDatos();
        }
        #region Metodos
        public List<clsGrupoSolidarioAhorro> obtenerGrupoSolidarioAhorro()
        {
            return (this.lstGrupoSolidarioAhorro != null )? this.lstGrupoSolidarioAhorro : new List<clsGrupoSolidarioAhorro>();
        }
        private void inicializarDatos()
        {
            this.objCNGrupoSolidario = new clsCNGrupoSolidario();
            this.lstGrupoSolidarioAhorro = new List<clsGrupoSolidarioAhorro>();
            this.lstGrupoSolIntegranteCtaAhorro = new List<clsGrupoSolIntegranteCtaAhorro>();

            this.bsGrupoSolidarioAhorro.DataSource = this.lstGrupoSolidarioAhorro;

            this.idOperacion = 0;
            this.nIndiceFila = -1;
            this.idCuentaAhorroSeleccion = 0;
            this.nCuentasVinculadas = 0;
            this.nCuentasSinValidar = 0;
            this.nAhorroSuficiente = 0;
            this.habilitarControles(clsAcciones.DEFECTO);
        }
        public void formatearSegunEstado()
        {
            if (lDesembolso)
            {
                foreach (DataGridViewRow dtgColumn in this.dtgGrupoSolidarioAhorro.Rows)
                {
                    clsGrupoSolidarioAhorro objMeta = (clsGrupoSolidarioAhorro)dtgColumn.DataBoundItem;

                    if (objMeta.idEstado == Estado.APROBADO)
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.DarkGreen;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (objMeta.idEstado == Estado.REGISTRADO)
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.Yellow;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.DarkRed;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dtgColumn in this.dtgGrupoSolidarioAhorro.Rows)
                {
                    clsGrupoSolidarioAhorro objMeta = (clsGrupoSolidarioAhorro)dtgColumn.DataBoundItem;

                    if (objMeta.idEstado == Estado.REGISTRADO)
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.DarkGreen;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (objMeta.idEstado == Estado.PLANIFICADO)
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.Yellow;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (objMeta.idEstado == Estado.NINGUNO)
                    {
                        dtgColumn.DefaultCellStyle.BackColor = Color.DarkRed;
                        dtgColumn.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
        private void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.btnContinuar.Visible = false;
                    this.btnDepositar.Visible = false;
                    this.gbxIntegrantes.Enabled = false;
                    this.gbxCuentaAhorro.Enabled = false;

                    this.btnCambiar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case clsAcciones.GRABAR:
                    this.gbxIntegrantes.Enabled = false;
                    this.gbxCuentaAhorro.Enabled = false;

                    this.btnCambiar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case clsAcciones.CANCELAR:
                    this.gbxIntegrantes.Enabled = false;
                    this.gbxCuentaAhorro.Enabled = false;

                    this.btnCambiar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case clsAcciones.BUSCAR:
                    this.gbxCuentaAhorro.Visible = !this.lDesembolso;
                    this.btnContinuar.Visible = this.lDesembolso;
                    this.btnDepositar.Visible = this.lDesembolso;
                    this.btnGrabar.Visible = !this.lDesembolso;
                    this.btnCancelar.Visible = !this.lDesembolso;
                    this.btnSalir.Visible = !this.lDesembolso;

                    this.gbxIntegrantes.Enabled = true;
                    this.gbxCuentaAhorro.Enabled = true;

                    this.btnCambiar.Enabled = true;
                    this.btnCambiar.Visible = false;
                    this.btnGrabar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    break;
            }
        }
        
        private void listarGrupoSolidarioAhorro()
        {
            this.dtgGrupoSolidarioAhorro.SelectionChanged -= dtgGrupoSolidarioAhorro_SelectionChanged;
            this.lstGrupoSolidarioAhorro.Clear();
            this.lstGrupoSolidarioAhorro.AddRange(this.objCNGrupoSolidario.listarGrupoSolidarioAhorro(this.idGrupoSolidario, this.idSolicitudCredGrupoSol));

            if (this.lstGrupoSolidarioAhorro.Count > 0)
            {                
                this.habilitarControles(clsAcciones.BUSCAR);
                this.listarGrupoSolIntegranteCtaAhorro();
            }
            this.bsGrupoSolidarioAhorro.ResetBindings(false);
            this.dtgGrupoSolidarioAhorro.Refresh();

            this.formatearSegunEstado();
            this.dtgGrupoSolidarioAhorro.ClearSelection();
            this.dtgGrupoSolidarioAhorro.SelectionChanged += dtgGrupoSolidarioAhorro_SelectionChanged;
        }
        private void listarGrupoSolIntegranteCtaAhorro()
        {
            this.lstGrupoSolIntegranteCtaAhorro.Clear();
            this.lstGrupoSolIntegranteCtaAhorro.AddRange(this.objCNGrupoSolidario.listarGrupoSolIntegranteCtaAhorro(
                this.idGrupoSolidario,
                this.idSolicitudCredGrupoSol,
                this.idOperacion));

            this.nCuentasVinculadas = 0;
            this.nAhorroSuficiente = 0;
            foreach (clsGrupoSolidarioAhorro objGSAhorro in this.lstGrupoSolidarioAhorro)
            {
                if (objGSAhorro.idGrupoSolidarioAhorro> 0 && objGSAhorro.idCuentaAhorro > 0)
                {
                    objGSAhorro.idEstado = Estado.REGISTRADO;
                    this.nCuentasVinculadas++;
                    if (objGSAhorro.lAhorroBloqueado)
                    {
                        objGSAhorro.idEstado = Estado.APROBADO;
                        this.nAhorroSuficiente++;
                    }                    
                    else if (this.lDesembolso && objGSAhorro.nMontoPendiente <= decimal.Zero)
                    {
                        objGSAhorro.idEstado = Estado.APROBADO;
                        this.nAhorroSuficiente++;
                    }
                    continue;
                }
                if (this.lDesembolso) continue;
                clsGrupoSolIntegranteCtaAhorro objGSICtaAhorro = this.lstGrupoSolIntegranteCtaAhorro.Find(x => x.idCliente == objGSAhorro.idCliente);
                if (objGSICtaAhorro != null)
                {
                    objGSAhorro.idCuentaAhorro = objGSICtaAhorro.idCuentaAhorro;
                    objGSAhorro.nMontoAhorro = objGSICtaAhorro.nSaldoDisponible;
                    objGSAhorro.idEstado = Estado.PLANIFICADO;
                }
                else
                {
                    this.lblMensaje.Visible = true;
                }
            }
        }
        private void grabarGrupoSolidarioAhorro()
        {
            if (this.nCuentasSinValidar > 0)
            {
                MessageBox.Show("Se ha identificado " + this.nCuentasSinValidar +
                    " Cuenta(s) vinculada(s) pero Sin Validar (documentos contractuales sin firmar y otras observaciones).\n\n"+
                    "* Intente grabar nuevamente y se le mostrará el formulario de validación para cada caso.",
                    "VALIDACION INCOMPLETA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsRespuestaServidor objRespuestaServidor = this.objCNGrupoSolidario.grabarGrupoSolidarioAhorro(this.lstGrupoSolidarioAhorro);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "RESULTADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<clsGrupoSolidarioAhorro> lstGSAhorroRegistrado = this.lstGrupoSolidarioAhorro.FindAll(x => x.idCuentaAhorro > 0);
                lstGSAhorroRegistrado.ForEach(y => { y.idEstado = Estado.REGISTRADO; });

                this.nCuentasVinculadas = lstGSAhorroRegistrado.Count;

                this.dtgGrupoSolidarioAhorro.Refresh();
                this.formatearSegunEstado();
                this.habilitarControles(clsAcciones.GRABAR);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "ERROR DE GRABADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int validarCuentas()
        {
            /*========================================================================================
            * INICO - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
            ========================================================================================*/
            this.nCuentasSinValidar = 0;
            DEP.CapaNegocio.clsCNDeposito clsDeposito = new DEP.CapaNegocio.clsCNDeposito();

            foreach (clsGrupoSolidarioAhorro objGSAhorro in this.lstGrupoSolidarioAhorro)
            {
                if (objGSAhorro.idCuentaAhorro == 0) continue;

                DataTable dtResValidacionCuenta = clsDeposito.CNAWValidarCuentaAperturada(objGSAhorro.idCuentaAhorro);
                if (dtResValidacionCuenta.Rows.Count == 1)
                {
                    frmAWValidarCuenta frmAWValidarCuenta = new frmAWValidarCuenta(objGSAhorro.idCuentaAhorro, (int)Modulo.AHORROS, objGSAhorro.cDocumento, dtResValidacionCuenta);

                    if (!frmAWValidarCuenta.validarCuentaAperturada())
                    {
                        DialogResult drResult = MessageBox.Show("¿El cliente es titular de la cuenta?", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (drResult == DialogResult.Yes)
                        {
                            frmAWValidarCuenta.ShowDialog();
                            if (frmAWValidarCuenta.lCancelado)
                            {
                                nCuentasSinValidar++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cuenta aperturada en línea. El cliente titular aún no ha efectuado la firma de los documentos contractuales.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nCuentasSinValidar++;
                        }
                    }
                }
            }
            return nCuentasSinValidar;
        }
        private void desplegarCuentasAhorro()
        {
            clsGrupoSolidarioAhorro objGSAhorro = this.lstGrupoSolidarioAhorro[this.nIndiceFila];
            List<clsGrupoSolIntegranteCtaAhorro> lstCuentasCliente = this.lstGrupoSolIntegranteCtaAhorro.FindAll(x => x.idCliente == objGSAhorro.idCliente);

            int nCuentasAhorro = lstCuentasCliente.Count;
            if (nCuentasAhorro > 1 && !this.lDesembolso)
            {
                MessageBox.Show("El cliente seleccionado tiene múltiples cuentas de ahorro, si desea cambiar la cuenta vinculada siga las siguientes instrucciones:\n" +
                "1.- En el desplegable N° Cuenta Ahorro seleccione la cuenta que el cliente desee vincular.\n"+
                "2.- Haga clic en el botón Cambiar para establecer el vínculo con dicha cuenta.", "SELECCIONE UNA CUENTA DE AHORRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCambiar.Visible = true;
            }
            else
            {
                this.btnCambiar.Visible = false;
            }

            if (nCuentasAhorro > 0)
            {
                this.cboCuentaAhorro.DataSource = lstCuentasCliente;
                this.cboCuentaAhorro.DisplayMember = "idCuentaAhorro";
                this.cboCuentaAhorro.ValueMember = "idCuentaAhorro";

                this.cboCuentaAhorro.SelectedIndex = -1;

                if (objGSAhorro.idCuentaAhorro > 0)
                {
                    this.cboCuentaAhorro.SelectedValue = objGSAhorro.idCuentaAhorro;
                    this.nudSaldoDisponible.Value = objGSAhorro.nMontoAhorro;
                }
            }
            else
            {
                this.cboCuentaAhorro.DataSource = null;
                this.nudSaldoDisponible.Value = decimal.Zero;
            }
        }
        private void cambiarCuentaAhorro()
        {
            if (this.idCuentaAhorroSeleccion <= 0)
            {
                MessageBox.Show("No puede vincular la solicitud a una cuenta de ahorro inexistente.", "CUENTA INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro == this.idCuentaAhorroSeleccion)
            {
                MessageBox.Show("Seleccione una cuenta diferente a: " + this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro,
                    "SIN CAMBIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("La cuenta de ahorro será cambiada de: " + this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro.ToString() +
            " a: " + this.idCuentaAhorroSeleccion.ToString(), "CAMBIO DE CUENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro = this.idCuentaAhorroSeleccion;
            this.lstGrupoSolidarioAhorro[this.nIndiceFila].nMontoAhorro = this.nudSaldoDisponible.Value;
            this.lstGrupoSolidarioAhorro[this.nIndiceFila].idEstado = Estado.PLANIFICADO;
            this.dtgGrupoSolidarioAhorro.Refresh();
        }

        private void depositarAhorro()
        {
            if (this.nIndiceFila < 0) { MessageBox.Show("*Debe seleccionar un integrante.","REQUIERE SELECCION", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro > 0)
            {
                if (this.lstGrupoSolidarioAhorro[this.nIndiceFila].nMontoPendiente == decimal.Zero)
                {
                    MessageBox.Show(this.lstGrupoSolidarioAhorro[this.nIndiceFila].cCliente +
                        " tiene saldo suficiente en su cuenta de ahorro vinculada.\n\n"+
                        "* No se le permitirá realizar depósitos adicionales por este medio para este cliente.",
                        "AHORRO SUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmGrupoSolidarioDeposito objFrmGrupoSolidarioDeposito = new frmGrupoSolidarioDeposito(
                    this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCuentaAhorro,
                    this.lstGrupoSolidarioAhorro[this.nIndiceFila].idCliente,
                    this.lstGrupoSolidarioAhorro[this.nIndiceFila].cDocumento,
                    this.lstGrupoSolidarioAhorro[this.nIndiceFila].cCliente,
                    this.lstGrupoSolidarioAhorro[this.nIndiceFila].nMontoPendiente);
                objFrmGrupoSolidarioDeposito.ShowDialog();

                this.listarGrupoSolidarioAhorro();
            }
            else
            {
                MessageBox.Show("El integrante seleccionado no tiene vinculado una cuenta de ahorro a su solicitud de crédito grupal.\n"+
                "*No se puede hacer depósito sin una cuenta.",
                "SIN CUENTA VINCULADA",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void limpiarControles()
        {
            this.cboCuentaAhorro.SelectedIndex = -1;
            this.nudSaldoDisponible.Value = decimal.Zero;
        }
        private bool validarCuentasVinculadas()
        {
            if (this.nAhorroSuficiente < this.lstGrupoSolidarioAhorro.Count)
            {
                MessageBox.Show("Queda(n) " + (this.lstGrupoSolidarioAhorro.Count - this.nAhorroSuficiente) +
                " integrante(s) que no dispone(n) de monto ahorrado suficiente.\n" +
                "*No se permitirá ejecutar el desembolso hasta que todos los integrantes cumplan con la condición de monto ahorrado.",
                "AHORRO INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        #endregion
        
        #region Eventos
        private void frmGrupoSolidarioVincularAhorro_Shown(object sender, EventArgs e)
        {
            this.listarGrupoSolidarioAhorro();
        }
        private void dtgGrupoSolidarioAhorro_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dtgGrupoSolidarioAhorro.SelectedRows.Count == 0){dtgGrupoSolidarioAhorro.ClearSelection(); return;}
            this.nIndiceFila = this.dtgGrupoSolidarioAhorro.SelectedRows[0].Index;
            if (this.lstGrupoSolidarioAhorro[this.nIndiceFila].idOperacion != (int)OperacionCredito.Ampliacion)
            {
                this.desplegarCuentasAhorro();
            }
            else
            {
                this.lblNroCuenta.Visible = false;
                this.cboCuentaAhorro.Visible = false;
            }
        }
        private void cboCuentaAhorro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboCuentaAhorro.SelectedIndex < 0) { this.nudSaldoDisponible.Value = decimal.Zero; return; }
            this.idCuentaAhorroSeleccion = Convert.ToInt32(this.cboCuentaAhorro.SelectedValue);
            this.nudSaldoDisponible.Value = this.lstGrupoSolIntegranteCtaAhorro.Find(x => x.idCuentaAhorro == this.idCuentaAhorroSeleccion).nSaldoDisponible;
        }
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            this.cambiarCuentaAhorro();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.grabarGrupoSolidarioAhorro();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitarControles(clsAcciones.CANCELAR);
            this.limpiarControles();
            this.listarGrupoSolidarioAhorro();
        }
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            this.depositarAhorro();
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (this.validarCuentasVinculadas())
            {
                this.Close();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

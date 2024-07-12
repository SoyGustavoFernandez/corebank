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
using GEN.ControlesBase;
using RSG.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RSG.Presentacion
{
    public partial class frmRegistroVisitas : frmBase
    {
        #region Variable Globales
        clsCNVisita cnVisita;
        const string Inicio = "Inicio";
        const string Nuevo = "Nuevo";
        const string Guardado = "Guardado";
        const string Impreso = "Impreso";
        const string Buscando = "Buscando";
        public const string Editar = "Editar";
        public string Estado = Inicio;
        string cTitulo = "Registro de Visitas - Riesgos";

        private int idAgencia = 0;
        public DateTime dFechaPeriodoVisitaInicio;
        public DateTime dFechaPeriodoVisitaFin;
        public DataTable dtVisitasClientes;
        private DataRow drFormulario;
        
        #endregion

        public frmRegistroVisitas()
        {
            InitializeComponent();
        }

        public frmRegistroVisitas(int idAge)
        {
            InitializeComponent();
            idAgencia = idAge;
            conBusCli1.idAgencia = idAgencia;
            cnVisita = new clsCNVisita();
            limpiar();
            controlBotones(Inicio);
            activarFormulario(false);
            dtVisitasClientes = cnVisita.CNListarVisitaClientesPodIdVisita(-1);
            foreach (DataColumn column in dtVisitasClientes.Columns)
            {
                column.AllowDBNull = true;
            }
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);

            if (Estado != Editar)
            {
                limpiar();
                controlBotones(Inicio);
                activarFormulario(false);
            }
            else
            {
                controlBotones(Nuevo);
                activarFormulario(true);
                cargaFormulario();
                conBusCli1.btnBusCliente.Enabled = false;

            }
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(conBusCli1.txtCodCli.Text.Trim())) 
            {
                MessageBox.Show("Seleccione a un cliente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtAgencia = cnVisita.CNClienteAgencia(Convert.ToInt32(conBusCli1.txtCodCli.Text));
            if(dtAgencia.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la agencia del cliente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(dtAgencia.Rows[0]["idAgencia"]) != idAgencia) 
            {
                MessageBox.Show("EL cliente no pertenece a la agencia seleccionada de visita", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCli1.limpiarControles();
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodCli.Focus();
                activarFormulario(false);
                controlBotones(Inicio);
                limpiar();
                return;
            }
            DataTable dtCreditos = cnVisita.CNClienteCreditosVigentes(Convert.ToInt32(conBusCli1.txtCodCli.Text));
            if (dtCreditos.Rows.Count == 0)
            {
                MessageBox.Show("EL cliente no tiene créditos vigentes", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCli1.limpiarControles();
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodCli.Focus();
                activarFormulario(false);
                controlBotones(Inicio);
                limpiar();
                return;
            }
            activarFormulario(true);
            controlBotones(Nuevo);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            activarFormulario(false);
            controlBotones(Inicio);
            if (Estado == Editar) {
                this.Close();
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiar();
            conBusCli1.txtCodCli.Enabled = true;
            activarFormulario(false);
            controlBotones(Inicio);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            DataRow drVisita = dtVisitasClientes.NewRow();

            drVisita["idVisita"] = 0;
            drVisita["idCli"] = Convert.ToInt32(conBusCli1.txtCodCli.Text);
            drVisita["idRelacionAsesor"] = Convert.ToInt32(cboRelacionAsesor.SelectedValue);
            drVisita["idEntornoFamiliar"] = Convert.ToInt32(cboEntornoFamilia.SelectedValue);
            drVisita["idEntornoTrabajo"] = Convert.ToInt32(cboEntornoTrabajo.SelectedValue);
            drVisita["idReferencias"] = Convert.ToInt32(cboReferencias.SelectedValue);
            drVisita["idVerificaNegocioAse"] = Convert.ToInt32(cboTipoVerificacionAsesor1.SelectedValue);
            drVisita["idNivelAutonomia"] = Convert.ToInt32(cboTipoVerificaAutonomia1.SelectedValue);
            drVisita["idRiesgoOperacional"] = Convert.ToInt32(cboTipoRiesgoOperacional1.SelectedValue);
            drVisita["idMotivoMora"] = Convert.ToInt32(cboMotivoMoraRiesgos1.SelectedValue);
            drVisita["idUbicaNegocio"] = Convert.ToInt32(cboUbicaVisitaNegocio.SelectedValue);
            drVisita["idUbicaCliente"] = Convert.ToInt32(cboUbicaVisitaCliente.SelectedValue);
            drVisita["idTipoOpe"] = Convert.ToInt32(cboTipoOperacionRiesgos1.SelectedValue);
            drVisita["idResultado"] = Convert.ToInt32(cboResultadoVisitaRiesgos1.SelectedValue);
            drVisita["nOrden"] = 0;
            
            drVisita["cNombreCliente"] = conBusCli1.txtNombre.Text;
            drVisita["dFechaVisita"] = dtpVisita.Value;
            drVisita["lConoceAsesor"] = rbtnConoceAsesSi.Checked;
            drVisita["cRelacionAsesor"] = ((DataTable)cboRelacionAsesor.DataSource).Rows[cboRelacionAsesor.SelectedIndex]["cEscala"].ToString();
            drVisita["cEntornoFamiliar"] = ((DataTable)cboEntornoFamilia.DataSource).Rows[cboEntornoFamilia.SelectedIndex]["cEscala"].ToString();
            drVisita["cEntornoTrabajo"] = ((DataTable)cboEntornoTrabajo.DataSource).Rows[cboEntornoTrabajo.SelectedIndex]["cEscala"].ToString();
            drVisita["cReferencias"] = ((DataTable)cboReferencias.DataSource).Rows[cboReferencias.SelectedIndex]["cEscala"].ToString();
            drVisita["cVerificaNegocioAse"] = ((DataTable)cboTipoVerificacionAsesor1.DataSource).Rows[cboTipoVerificacionAsesor1.SelectedIndex]["cTipo"].ToString();
            drVisita["cNivelAutonomia"] = ((DataTable)cboTipoVerificaAutonomia1.DataSource).Rows[cboTipoVerificaAutonomia1.SelectedIndex]["cTipo"].ToString();
            drVisita["cRiesgoOperacional"] = ((DataTable)cboTipoRiesgoOperacional1.DataSource).Rows[cboTipoRiesgoOperacional1.SelectedIndex]["cTipo"].ToString();
            drVisita["cMotivoMora"] = ((DataTable)cboMotivoMoraRiesgos1.DataSource).Rows[cboMotivoMoraRiesgos1.SelectedIndex]["cMotivo"].ToString();
            drVisita["cUbicaNegocio"] = ((DataTable)cboUbicaVisitaNegocio.DataSource).Rows[cboUbicaVisitaNegocio.SelectedIndex]["cUbica"].ToString();
            drVisita["cUbicaCliente"] = ((DataTable)cboUbicaVisitaCliente.DataSource).Rows[cboUbicaVisitaCliente.SelectedIndex]["cUbica"].ToString();
            drVisita["cTipoOpe"] = ((DataTable)cboTipoOperacionRiesgos1.DataSource).Rows[cboTipoOperacionRiesgos1.SelectedIndex]["cDescripcion"].ToString();
            drVisita["cResultado"] = ((DataTable)cboResultadoVisitaRiesgos1.DataSource).Rows[cboResultadoVisitaRiesgos1.SelectedIndex]["cDescripcion"].ToString();
            drVisita["cProducto"] = "";
            drVisita["cActividadInterna"] = "";

            MessageBox.Show("La visita al cliente se agregó correctamente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtVisitasClientes.Rows.Add(drVisita);
            limpiar();
            activarFormulario(false);
            controlBotones(Inicio);
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Focus();
            conBusCli1.txtCodCli.Enabled = true;
            if (Estado == Editar)
            {
                this.Close();
            }
        }
        #endregion

        #region Métodos

        private bool validar()
        {
            if (string.IsNullOrEmpty(conBusCli1.txtCodCli.Text.Trim()))
            {
                MessageBox.Show("Busque un cliente por favor", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCli1.txtCodCli.Focus();
                return false;
            }
            if (dtpVisita.Value > dFechaPeriodoVisitaFin || dtpVisita.Value < dFechaPeriodoVisitaInicio)
            {
                MessageBox.Show("La fecha de visita debe estar dentro del rango: " + dFechaPeriodoVisitaInicio.ToString("dd/MM/yyyy") + " - " + dFechaPeriodoVisitaFin.ToString("dd/MM/yyyy"), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpVisita.Focus();
                return false;
            }
            if (dtpVisita.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de visita no puede ser mayor a la fecha del sistema", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpVisita.Focus();
                return false;
            }
            if (cboTipoOperacionRiesgos1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de operación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (cboResultadoVisitaRiesgos1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el resultado de la visita", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboTipoOperacionRiesgos1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de operación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboResultadoVisitaRiesgos1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de operación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!rbtnConoceAsesNo.Checked && !rbtnConoceAsesSi.Checked)
            {
                MessageBox.Show("Seleccione si conoce al asesor", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboRelacionAsesor.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione relación con el asesor", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboEntornoFamilia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione entorno familiar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboEntornoTrabajo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione entorno de trabajo", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboReferencias.SelectedIndex < 0) 
            {
                MessageBox.Show("Seleccione la referencia", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboTipoVerificacionAsesor1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la verificación del negocio por el asesor", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboTipoVerificaAutonomia1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la verificación del nivel de autonomía", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboTipoRiesgoOperacional1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el riesgo operacional", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboUbicaVisitaNegocio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la ubicabilidad del negocio", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboUbicaVisitaCliente.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la ubicabilidad del cliente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboMotivoMoraRiesgos1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de mora", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void cargarDatosFormulario(DataRow dr)
        {
            drFormulario = dr;
            
        }
        private void cargaFormulario()
        {
            dtpVisita.Value = Convert.ToDateTime(drFormulario["dFechaVisita"]);
            conBusCli1.CargardatosCli(Convert.ToInt32(drFormulario["idCLi"]));
            cboTipoOperacionRiesgos1.SelectedValue = Convert.ToInt32(drFormulario["idTipoOpe"]);
            cboResultadoVisitaRiesgos1.SelectedValue = Convert.ToInt32(drFormulario["idResultado"]);
            rbtnConoceAsesSi.Checked = Convert.ToBoolean(drFormulario["lConoceAsesor"]);
            rbtnConoceAsesNo.Checked = !Convert.ToBoolean(drFormulario["lConoceAsesor"]);
            cboRelacionAsesor.SelectedValue = Convert.ToInt32(drFormulario["idRelacionAsesor"]);
            cboEntornoFamilia.SelectedValue = Convert.ToInt32(drFormulario["idEntornoFamiliar"]);
            cboEntornoTrabajo.SelectedValue = Convert.ToInt32(drFormulario["idEntornoTrabajo"]);
            cboReferencias.SelectedValue = Convert.ToInt32(drFormulario["idReferencias"]);
            cboTipoVerificacionAsesor1.SelectedValue = Convert.ToInt32(drFormulario["idVerificaNegocioAse"]);
            cboTipoVerificaAutonomia1.SelectedValue = Convert.ToInt32(drFormulario["idNivelAutonomia"]);
            cboTipoRiesgoOperacional1.SelectedValue = Convert.ToInt32(drFormulario["idRiesgoOperacional"]);
            cboMotivoMoraRiesgos1.SelectedValue = Convert.ToInt32(drFormulario["idMotivoMora"]);
            cboUbicaVisitaNegocio.SelectedValue = Convert.ToInt32(drFormulario["idUbicaNegocio"]);
            cboUbicaVisitaCliente.SelectedValue = Convert.ToInt32(drFormulario["idUbicaCliente"]);
        }

        private void limpiar()
        {
            dtpVisita.Value = clsVarGlobal.dFecSystem;
            cboTipoOperacionRiesgos1.SelectedIndex = -1;
            cboResultadoVisitaRiesgos1.SelectedIndex = -1;
            rbtnConoceAsesSi.Checked = false;
            rbtnConoceAsesNo.Checked = false;
            cboRelacionAsesor.SelectedIndex = -1;
            cboEntornoFamilia.SelectedIndex = -1;
            cboEntornoTrabajo.SelectedIndex = -1;
            cboReferencias.SelectedIndex = -1;
            cboTipoVerificacionAsesor1.SelectedIndex = -1;
            cboTipoVerificaAutonomia1.SelectedIndex = -1;
            cboTipoRiesgoOperacional1.SelectedIndex = -1;
            cboMotivoMoraRiesgos1.SelectedIndex = -1;
            cboUbicaVisitaNegocio.SelectedIndex = -1;
            cboUbicaVisitaCliente.SelectedIndex = -1;
           
        }

        private void activarFormulario(Boolean lBol)
        {
            dtpVisita.Enabled = lBol;
            cboTipoOperacionRiesgos1.Enabled = lBol;
            cboResultadoVisitaRiesgos1.Enabled = lBol;
            rbtnConoceAsesSi.Enabled = lBol;
            rbtnConoceAsesNo.Enabled = lBol;
            cboRelacionAsesor.Enabled = lBol;
            cboEntornoFamilia.Enabled = lBol;
            cboEntornoTrabajo.Enabled = lBol;
            cboReferencias.Enabled = lBol;
            cboTipoVerificacionAsesor1.Enabled = lBol;
            cboTipoVerificaAutonomia1.Enabled = lBol;
            cboTipoRiesgoOperacional1.Enabled = lBol;
            cboMotivoMoraRiesgos1.Enabled = lBol;
            cboUbicaVisitaNegocio.Enabled = lBol;
            cboUbicaVisitaCliente.Enabled = lBol;
        }

        private void controlBotones(string estado)
        {
            switch (estado)
            { 
                case Inicio :
                    btnNuevo1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnSalir1.Enabled = true;
                    break;
                case Nuevo:
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    btnSalir1.Enabled = true;
                    break;
                case Guardado:
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnSalir1.Enabled = false;
                    break;
                case Impreso:
                    btnNuevo1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnSalir1.Enabled = true;
                    break;
            }
        }

        #endregion           
    }
}

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
    public partial class frmRegistroVisitasRiesgos : frmBase
    {
        #region Variable Globales

        clsCNVisita cnVisita;
        const string Inicio = "Inicio";
        const string Nuevo  = "Nuevo";
        const string Editar = "Editar";
        const string ParaEditar = "Para Editar";
        const string Guardado = "Guardado";
        string cTitulo = "Registro de visitas - riesgos";
        DataRow drEditar;
        int idVisita = 0;

        #endregion
       
        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }
        
        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (dtpPeriodoVisitaInicio.Value > dtpPeriodoVisitaFin.Value)
            {
                MessageBox.Show("La fecha 'Desde' del periodo de visita no puede ser mayor que la fecha 'Al'", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dtResultado = cnVisita.CNBuscarVisita(dtpPeriodoVisitaInicio.Value, dtpPeriodoVisitaFin.Value);
            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron visitas para el periodo : " + dtpPeriodoVisitaInicio.Value.ToString("dd/MM/yyyy") + " Al " + dtpPeriodoVisitaFin.Value.ToString("dd/MM/yyyy"), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtgVisitas.DataSource = dtResultado;
            formatoGridVisitas();
        }

        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            drEditar = null;
            DataTable dt = ((DataTable)dtgVisitasClientes.DataSource);
            if (dt == null)
            {
                MessageBox.Show("No hay datos para editar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para editar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtVisitaEdita = ((DataTable)dtgVisitasClientes.DataSource);
            drEditar = dtVisitaEdita.Rows[dtgVisitasClientes.SelectedRows[0].Index];
            cargarFormularioVisitas();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiarFiltro();
            limpiarVisita();
            activarFormFiltros(false);
            activarFormVisita(true);
            activarBotonesPrincipales(Nuevo);
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            drEditar = null;
            cargarFormularioVisitas();
        }
        
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            DateTime dFechaInicio = dtpVisitaPerInicio.Value;
            DateTime dFechaFin = dtpVisitaPerFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            int idZona = Convert.ToInt32(cboZona1.SelectedValue);

            DataTable dtGuardar = ((DataTable)dtgVisitasClientes.DataSource);

            DataSet dsGuardar = new DataSet("dsGuardar");
            string xml = "";
            if (dtGuardar.DataSet==null)
            {
                dsGuardar.Tables.Add(dtGuardar);
                xml = dsGuardar.GetXml();
            }
            else
            {
                xml = dtGuardar.DataSet.GetXml();
            }

            DataTable dtResultado = cnVisita.CNRegistrarVisita(idVisita, dFechaInicio, dFechaFin, idAgencia, idZona, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, xml);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                idVisita = Convert.ToInt32(dtResultado.Rows[0]["idVisita"]);
            }
            activarFormVisita(false);
            activarBotonesPrincipales(Guardado);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            activarFormVisita(true);
            activarBotonesPrincipales(Editar);
            dtpVisitaPerInicio.Enabled = false;
            dtpVisitaPerFin.Enabled = false;
            cboAgencias1.Enabled = false;
            cboZona1.Enabled = false;
            activarFormFiltros(false);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarVisita();
            limpiarFiltro();
            activarFormVisita(false);
            activarFormFiltros(true);
            activarBotonesPrincipales(Inicio);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (idVisita == 0)
            {
                MessageBox.Show("No hay visita Seleccionada", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            string cNombreAge = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            //Procesar
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cNomAgen", cNombreAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dsListaVisita", cnVisita.CNListarVisitaClientesPodIdVisita(idVisita)));
            dtslist.Add(new ReportDataSource("dsVisitaResumen", cnVisita.CNBuscarResumenVisita(idVisita)));

            string reportpath = "rptActaVisitaRiesgos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir1.Enabled = true;
        }

        private void btnMiniDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
            {
                MessageBox.Show("No hay visitas para ver sus detalles", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idVisita = Convert.ToInt32(dtgVisitas.SelectedRows[0].Cells["idVisita"].Value);
            cboZona1.SelectedValue = Convert.ToInt32(dtgVisitas.SelectedRows[0].Cells["idZona"].Value);
            cboAgencias1.SelectedValue = Convert.ToInt32(dtgVisitas.SelectedRows[0].Cells["idAgencia"].Value);
            dtpVisitaPerInicio.Value = Convert.ToDateTime(dtgVisitas.SelectedRows[0].Cells["dFechaPeriodoVisitaInicio"].Value);
            dtpVisitaPerFin.Value = Convert.ToDateTime(dtgVisitas.SelectedRows[0].Cells["dFechaPeriodoVisitaFin"].Value);

            DataTable dtResultado = cnVisita.CNListarVisitaClientesPodIdVisita(idVisita);
            foreach (DataColumn column in dtResultado.Columns)
            {
                column.AllowDBNull = true;
            }
            dtgVisitasClientes.DataSource = dtResultado;
            formatoGridVisitasClientes();
            activarBotonesPrincipales(ParaEditar);
        }

        private void btnMiniQuitar2_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
            {
                MessageBox.Show("No hay visitas para eliminar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult drResultado = MessageBox.Show("¿Desea eliminar el periodo de visita seleccionada? "
                , cTitulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (drResultado == DialogResult.Cancel)
            {
                return;
            }

            DataTable dt = ((DataTable)dtgVisitas.DataSource);
            DataTable drRes = cnVisita.CNEliminarVisitaRiesgos(Convert.ToInt32(dtgVisitas.SelectedRows[0].Cells["idVisita"].Value));
            int indice = dtgVisitas.SelectedRows[0].Index;


            MessageBox.Show(Convert.ToString(drRes.Rows[0]["cMensaje"]), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Convert.ToInt32(drRes.Rows[0]["nResultado"]) == 0)
                return;

            dt.Rows.RemoveAt(indice);
            dt.AcceptChanges();
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgVisitasClientes.RowCount == 0)
            {
                MessageBox.Show("No hay visitas a clientes para eliminar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult drResultado = MessageBox.Show("¿Desea eliminar la visita al cliente: " + dtgVisitasClientes.SelectedRows[0].Cells["cNombreCliente"].Value + "?", cTitulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (drResultado == DialogResult.Cancel)
            {
                return;
            }

            DataTable dt = ((DataTable)dtgVisitasClientes.DataSource);
            int indice = dtgVisitasClientes.SelectedRows[0].Index;
            dt.Rows.RemoveAt(indice);
            dt.AcceptChanges();
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZona = Convert.ToInt32(cboZona1.SelectedValue);
            cboAgencias1.FiltrarPorZona(idZona);
        }
        
        #endregion

        #region Métodos

        private bool validar()
        {
            if (dtpVisitaPerInicio.Value > dtpVisitaPerFin.Value)
            {
                MessageBox.Show("La fecha de visita 'Desde' del periodo de visita no puede ser mayor que la fecha 'Al'", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboZona1.SelectedIndex <0)
            {
                MessageBox.Show("Seleccione la zona", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboAgencias1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una agencia", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtgVisitasClientes.RowCount == 0)
            {
                MessageBox.Show("Debe registral al menos 1 visita", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void formatoGridVisitas()
        {
            foreach (DataGridViewColumn item in dtgVisitas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            } 

            dtgVisitas.Columns["idVisita"].Visible = false;
            dtgVisitas.Columns["idAgencia"].Visible = false;
            dtgVisitas.Columns["idZona"].Visible = false;
            dtgVisitas.Columns["dFechaPeriodoVisitaInicio"].HeaderText = "Fecha Inicio";
            dtgVisitas.Columns["dFechaPeriodoVisitaFin"].HeaderText = "Fecha Fin";
            dtgVisitas.Columns["cNombreAgencia"].HeaderText = "Oficina";
            dtgVisitas.Columns["cDesZona"].HeaderText = "Zona";
            dtgVisitas.Columns["cWinUser"].HeaderText = "Usuario";

        }

        private void formatoGridVisitasClientes()
        {
            foreach (DataGridViewColumn item in dtgVisitasClientes.Columns)
	        {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
	        } 

            dtgVisitasClientes.Columns["idVisita"].Visible = false;
            dtgVisitasClientes.Columns["nNro"].Visible = false;
            dtgVisitasClientes.Columns["nOrden"].Visible = false;
            dtgVisitasClientes.Columns["idCli"].Visible = false;
            dtgVisitasClientes.Columns["idRelacionAsesor"].Visible = false;
            dtgVisitasClientes.Columns["idEntornoFamiliar"].Visible = false;
            dtgVisitasClientes.Columns["idEntornoTrabajo"].Visible = false;
            dtgVisitasClientes.Columns["idReferencias"].Visible = false;
            dtgVisitasClientes.Columns["idVerificaNegocioAse"].Visible = false;
            dtgVisitasClientes.Columns["idNivelAutonomia"].Visible = false;
            dtgVisitasClientes.Columns["idRiesgoOperacional"].Visible = false;
            dtgVisitasClientes.Columns["idMotivoMora"].Visible = false;
            dtgVisitasClientes.Columns["idUbicaNegocio"].Visible = false;
            dtgVisitasClientes.Columns["idUbicaCliente"].Visible = false;
            dtgVisitasClientes.Columns["idTipoOpe"].Visible = false;
            dtgVisitasClientes.Columns["idResultado"].Visible = false;
            dtgVisitasClientes.Columns["nOrden"].Visible = false;
            dtgVisitasClientes.Columns["IdProducto"].Visible = false;
            dtgVisitasClientes.Columns["cProducto"].Visible = false;
            dtgVisitasClientes.Columns["cActividadInterna"].Visible = false;
            dtgVisitasClientes.Columns["cCodCliente"].Visible = false;
            dtgVisitasClientes.Columns["cNombreAgencia"].Visible = false;
            dtgVisitasClientes.Columns["cWinUser"].Visible = false;

            dtgVisitasClientes.Columns["cNombreCliente"].HeaderText = "Cliente";
            dtgVisitasClientes.Columns["dFechaVisita"].HeaderText = "Fecha Visita";
            dtgVisitasClientes.Columns["lConoceAsesor"].HeaderText = "¿Conoce al Asesor?";
            dtgVisitasClientes.Columns["cRelacionAsesor"].HeaderText = "Relacion Asesor";
            dtgVisitasClientes.Columns["cEntornoFamiliar"].HeaderText = "Entorno Familiar";
            dtgVisitasClientes.Columns["cEntornoTrabajo"].HeaderText = "Entorno Trabajo";
            dtgVisitasClientes.Columns["cReferencias"].HeaderText = "Referencias";
            dtgVisitasClientes.Columns["cVerificaNegocioAse"].HeaderText = "V. del Negocio por el Asesor";
            dtgVisitasClientes.Columns["cNivelAutonomia"].HeaderText = "V. Nivel de autonomia";
            dtgVisitasClientes.Columns["cRiesgoOperacional"].HeaderText = "V. Riesgo Operacional";
            dtgVisitasClientes.Columns["cMotivoMora"].HeaderText = "Motivo Mora";
            dtgVisitasClientes.Columns["cUbicaNegocio"].HeaderText = "Ubicabilidad Negocio";
            dtgVisitasClientes.Columns["cUbicaCliente"].HeaderText = "Ubicabilidad Cliente";
            dtgVisitasClientes.Columns["cTipoOpe"].HeaderText = "Tipo Operación";
            dtgVisitasClientes.Columns["cResultado"].HeaderText = "Resultado";
            dtgVisitasClientes.Columns["cProducto"].HeaderText = "Producto";
            dtgVisitasClientes.Columns["cActividadInterna"].HeaderText = "Actividad";
        }

        private void limpiarFiltro()
        {
            dtpPeriodoVisitaInicio.Value = clsVarGlobal.dFecSystem;
            dtpPeriodoVisitaFin.Value = clsVarGlobal.dFecSystem;
            if (((DataTable)dtgVisitas.DataSource) != null)
                ((DataTable)dtgVisitas.DataSource).Clear();
        }

        private void limpiarVisita()
        { 
            dtpVisitaPerInicio.Value = clsVarGlobal.dFecSystem;
            dtpVisitaPerFin.Value = clsVarGlobal.dFecSystem;
            cboZona1.SelectedIndex = -1;
            cboAgencias1.SelectedIndex = -1;

            if (((DataTable)dtgVisitasClientes.DataSource) != null)
                ((DataTable)dtgVisitasClientes.DataSource).Clear();
        }

        private void activarFormFiltros(Boolean lBol)
        {
            dtpPeriodoVisitaInicio.Enabled = lBol;
            dtpPeriodoVisitaFin.Enabled = lBol;
            dtgVisitas.Enabled = lBol;
            btnMiniBusq1.Enabled = lBol;
            btnMiniDetalle1.Enabled = lBol;
            btnMiniQuitar2.Enabled = lBol;
        }

        private void activarFormVisita(Boolean lBol)
        {
            dtpVisitaPerInicio.Enabled = lBol;
            dtpVisitaPerFin.Enabled = lBol;
            cboZona1.Enabled = lBol;
            cboAgencias1.Enabled = lBol;
            dtgVisitasClientes.Enabled = lBol;
            btnMiniAgregar1.Enabled = lBol;
            btnMiniQuitar1.Enabled = lBol;
            btnMiniEditar1.Enabled = lBol;
        }

        private void activarBotonesPrincipales(string estado)
        {
            switch (estado)
            { 
                case Inicio :
                    btnImprimir1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    break;
                case ParaEditar:
                    btnImprimir1.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    break;
                case Nuevo :
                case Editar:
                    btnImprimir1.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
                case Guardado:
                    btnImprimir1.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    break;
            }
        }

        private void cargar()
        {
            cnVisita = new clsCNVisita();
            limpiarFiltro();
            limpiarVisita();
            activarBotonesPrincipales(Inicio);
            activarFormFiltros(true);
            activarFormVisita(false);
        }
        
        private void actualizarRow(DataRow dr, DataRow drActualiza)
        {
            dr["idCli"] = drActualiza["idCli"];
            dr["idRelacionAsesor"] = drActualiza["idRelacionAsesor"];
            dr["idEntornoFamiliar"] = drActualiza["idEntornoFamiliar"];
            dr["idEntornoTrabajo"] = drActualiza["idEntornoTrabajo"];
            dr["idReferencias"] = drActualiza["idReferencias"];
            dr["idVerificaNegocioAse"] = drActualiza["idVerificaNegocioAse"];
            dr["idNivelAutonomia"] = drActualiza["idNivelAutonomia"];
            dr["idRiesgoOperacional"] = drActualiza["idRiesgoOperacional"];
            dr["idMotivoMora"] = drActualiza["idMotivoMora"];
            dr["idUbicaNegocio"] = drActualiza["idUbicaNegocio"];
            dr["idUbicaCliente"] = drActualiza["idUbicaCliente"];
            dr["idTipoOpe"] = drActualiza["idTipoOpe"];
            dr["idResultado"] = drActualiza["idResultado"];
            dr["nOrden"] = drActualiza["nOrden"];

            dr["cNombreCliente"] = drActualiza["cNombreCliente"];
            dr["dFechaVisita"] = drActualiza["dFechaVisita"];
            dr["lConoceAsesor"] = drActualiza["lConoceAsesor"];
            dr["cRelacionAsesor"] = drActualiza["cRelacionAsesor"];
            dr["cEntornoFamiliar"] = drActualiza["cEntornoFamiliar"];
            dr["cEntornoTrabajo"] = drActualiza["cEntornoTrabajo"];
            dr["cReferencias"] = drActualiza["cReferencias"];
            dr["cVerificaNegocioAse"] = drActualiza["cVerificaNegocioAse"];
            dr["cNivelAutonomia"] = drActualiza["cNivelAutonomia"];
            dr["cRiesgoOperacional"] = drActualiza["cRiesgoOperacional"];
            dr["cMotivoMora"] = drActualiza["cMotivoMora"];
            dr["cUbicaNegocio"] = drActualiza["cUbicaNegocio"];
            dr["cUbicaCliente"] = drActualiza["cUbicaCliente"];
            dr["cTipoOpe"] = drActualiza["cTipoOpe"];
            dr["cResultado"] = drActualiza["cResultado"];
            dr["cProducto"] = drActualiza["cProducto"];
            dr["cActividadInterna"] = drActualiza["cActividadInterna"];
        }

        public frmRegistroVisitasRiesgos()
        {
            InitializeComponent();
            cargar();
        }

        public void cargarFormularioVisitas()
        {
            if (dtpVisitaPerInicio.Value > dtpVisitaPerFin.Value)
            {
                MessageBox.Show("La fecha 'Desde' del periodo de visita no puede ser mayor que la fecha 'Al'", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboAgencias1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            

            frmRegistroVisitas frmVisita = new frmRegistroVisitas(Convert.ToInt32(cboAgencias1.SelectedValue));
            frmVisita.dFechaPeriodoVisitaInicio = dtpVisitaPerInicio.Value;
            frmVisita.dFechaPeriodoVisitaFin = dtpVisitaPerFin.Value;
            if (drEditar != null) 
            {
                frmVisita.Estado = frmRegistroVisitas.Editar;
                frmVisita.cargarDatosFormulario(drEditar);
            }
            frmVisita.ShowDialog();

            if (frmVisita.dtVisitasClientes.Rows.Count == 0)
                return;

            DataTable dtVisitasRegistradas = frmVisita.dtVisitasClientes;
            if (dtgVisitasClientes.RowCount == 0)
            {
                dtgVisitasClientes.DataSource = dtVisitasRegistradas;
                formatoGridVisitasClientes();
                return;
            }

            if (drEditar != null)
            {
                //Actualizando
                DataTable dtTemp = ((DataTable)dtgVisitasClientes.DataSource);
                dtTemp.Rows.RemoveAt(dtgVisitasClientes.SelectedRows[0].Index);
                dtTemp.ImportRow(dtVisitasRegistradas.Rows[0]);
                drEditar = null;
                return;
            }
            
            foreach (DataRow itemNuevos in dtVisitasRegistradas.Rows)
            {
                ((DataTable)dtgVisitasClientes.DataSource).ImportRow(itemNuevos);
            }

        }
        #endregion
    }
}

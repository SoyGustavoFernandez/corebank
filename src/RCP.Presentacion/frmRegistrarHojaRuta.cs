using EntityLayer;
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
using RCP.CapaNegocio;
using GEN.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmRegistrarHojaRuta : frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        DataTable dtCreditos = new DataTable();
        DataTable dtHojaRuta = new DataTable();
        

        public frmRegistrarHojaRuta()
        {
            InitializeComponent();
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (conBusUbig1.cboDepartamento.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar el departamento que desea filtrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusUbig1.cboDepartamento.Focus();
                return;
            }

            if (conBusUbig1.cboProvincia.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar la provincia que desea filtrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusUbig1.cboProvincia.Focus();
                return;
            }

            completarControlesVacios();
            int nAtrazoMin = Convert.ToInt32(txtAtrazoMin.Text);
            int nAtrazoMax = Convert.ToInt32(txtAtrazoMax.Text);
            Decimal nSaldoCapitalMin = Convert.ToDecimal(txtSaldoCapitalMin.Text);
            Decimal nSaldoCapitalMax = Convert.ToDecimal(txtSaldoCapitalMax.Text);
            int idUbigeo = conBusUbig1.nIdNodo;

            dtCreditos = cnHojaRuta.listaCarteraRecuperaciones(clsVarGlobal.PerfilUsu.idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, chbDireccionPrincipal.Checked, (cboTipoIntervCre1.SelectedIndex == -1) ? 0 : Convert.ToInt32(cboTipoIntervCre1.SelectedValue), clsVarGlobal.PerfilUsu.idPerfil);
            if (dtHojaRuta.Rows.Count <= 0)
            {
                dtHojaRuta = dtCreditos.Clone();
                dtHojaRuta.Clear();
                dtHojaRuta.Columns.Add("btnQuitar");                
                dtHojaRuta.Columns.Add("idAccion");
                dtHojaRuta.Columns.Add("cAccion");
                dtHojaRuta.Columns.Add("idTipoNotificacion");
                dtHojaRuta.Columns.Add("cTipoNotificacion");                
                dtgHojaRuta.DataSource = dtHojaRuta;
                ordenarColumnasdtgHojaRuta();
            }
            dtCreditos.Columns.Add("btnAgregar");
            

            foreach (DataRow row in dtCreditos.Rows)
            {
                row["btnAgregar"] = new Button().Text = "+";
                if (dtHojaRuta.Rows.Count > 0 && buscarCuentaSeleccionada(Convert.ToInt32(row["idCuenta"]), Convert.ToInt32(row["idIntervCre"]), Convert.ToInt32(row["idDireccion"]))) 
                {
                    row.Delete();
                }
            }
            dtgCarteraCreditos.DataSource = dtCreditos;
            ordenarColumnasdtgCarteraCreditos();
        }

        private void ordenarColumnasdtgHojaRuta()
        {
            int i = 0;
            dtgHojaRuta.Columns["btnQuitar"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cAccion"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cTipoNotificacion"].DisplayIndex = i++;
            dtgHojaRuta.Columns["idCliHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["idCuentaHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cTipoIntervencionHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cNombreHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cTipoDirHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["lDirPrincipalHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["lDireccionRecupera"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cDireccionHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["nAtrasoHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cSimboloHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["nSaldoCapitalHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cUbigeoHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cDepartamentoHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cProvinciaHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cDistritoHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cAnexoHR"].DisplayIndex = i++;
            dtgHojaRuta.Columns["cObservacionHR"].DisplayIndex = i++;
        }

        private void ordenarColumnasdtgCarteraCreditos()
        {
            int i = 0;
            dtgCarteraCreditos.Columns["btnAgregar"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["idCli"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["idCuenta"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cTipoIntervencion"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cNombre"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cTipoDir"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["lDirPrincipal"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["lDireccionRecuperaCre"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cDireccion"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["nAtraso"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cSimbolo"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["nSaldoCapital"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cUbigeo"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cDepartamento"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cProvincia"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cDistrito"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cAnexo"].DisplayIndex = i++;
            dtgCarteraCreditos.Columns["cObservacion"].DisplayIndex = i++;
            
        }

        private void completarControlesVacios()
        {
            if (txtAtrazoMin.Text.Trim().Length <= 0)
                txtAtrazoMin.Text = "-9999999";
            if (txtAtrazoMax.Text.Trim().Length <= 0)
                txtAtrazoMax.Text = "9999999";
            if (txtSaldoCapitalMin.Text.Trim().Length <= 0)
                txtSaldoCapitalMin.Text = "0.00";
            if (txtSaldoCapitalMax.Text.Trim().Length <= 0)
                txtSaldoCapitalMax.Text = "9999999.99";  
        }

        private void frmRegistrarHojaRuta_Load(object sender, EventArgs e)
        {
            conBusUbig1.cargar();            
            conBusUbig1.cboPais.Enabled = false;
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;            
            limpiarControles();
            valoresPorDefecto();
            habilitarControles(false);
            DateTime dInicioMes = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFechaInicio.MinDate = dInicioMes;
            dtpFechaInicio.MaxDate = dInicioMes.AddMonths(1).AddDays(-1);
            dtpFechaFin.MinDate = dInicioMes;
            dtpFechaFin.MaxDate = dInicioMes.AddMonths(1).AddDays(-1);
        }

        public void valoresPorDefecto()
        {
            conBusUbig1.cargarUbigeo(173);
            txtAtrazoMin.Text = "-9999999";
            txtAtrazoMax.Text = "9999999";
            txtSaldoCapitalMin.Text = "0.00";
            txtSaldoCapitalMax.Text = "9999999.99";
            chbTodosIntervinientes.Checked = true;
            chbDireccionPrincipal.Checked = false;
            cboTipoIntervCre1.Enabled = false;
            cboTipoIntervCre1.SelectedIndex = -1;
        }

        private void dtgCarteraCreditos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgCarteraCreditos.Columns[e.ColumnIndex].HeaderText == "Agregar")
                {
                    frmSeleccionaAccion frmSeleccionaAccion = new frmSeleccionaAccion();
                    frmSeleccionaAccion.idTipoIntev = Convert.ToInt32(dtgCarteraCreditos.CurrentRow.Cells["idTipoInterv"].Value.ToString());
                    frmSeleccionaAccion.txtCodigoCliente.Text = dtgCarteraCreditos.CurrentRow.Cells["idCli"].Value.ToString();
                    frmSeleccionaAccion.txtNombreCliente.Text = dtgCarteraCreditos.CurrentRow.Cells["cNombre"].Value.ToString();
                    frmSeleccionaAccion.txtDiasAtraso.Text = dtgCarteraCreditos.CurrentRow.Cells["nAtraso"].Value.ToString();
                    frmSeleccionaAccion.txtSaldoCapital.Text = dtgCarteraCreditos.CurrentRow.Cells["nSaldoCapital"].Value.ToString();
                    frmSeleccionaAccion.txtMoneda.Text = dtgCarteraCreditos.CurrentRow.Cells["cSimbolo"].Value.ToString();
                    frmSeleccionaAccion.txtIntervencion.Text = dtgCarteraCreditos.CurrentRow.Cells["cTipoIntervencion"].Value.ToString();
                    frmSeleccionaAccion.txtUbigeo.Text = dtgCarteraCreditos.CurrentRow.Cells["cUbigeo"].Value.ToString();
                    frmSeleccionaAccion.txtTipoDireccion.Text = dtgCarteraCreditos.CurrentRow.Cells["cTipoDir"].Value.ToString();
                    frmSeleccionaAccion.chbDirPrincipal.Checked = (bool)dtgCarteraCreditos.CurrentRow.Cells["lDirPrincipal"].Value;
                    frmSeleccionaAccion.txtDireccion.Text = dtgCarteraCreditos.CurrentRow.Cells["cDireccion"].Value.ToString();
                    frmSeleccionaAccion.txtCuenta.Text = dtgCarteraCreditos.CurrentRow.Cells["idCuenta"].Value.ToString();
                    frmSeleccionaAccion.txtTotalPagar.Text = dtgCarteraCreditos.CurrentRow.Cells["nTotalPagar"].Value.ToString();
                    frmSeleccionaAccion.lblObservacion.Text = dtgCarteraCreditos.CurrentRow.Cells["cObservacion"].Value.ToString();
                    

                    frmSeleccionaAccion.ShowDialog();
                    if (frmSeleccionaAccion.lAceptar)
                    {
                        DataRow drNuevo = dtHojaRuta.NewRow();
                        drNuevo["btnQuitar"] = new Button().Text = "-";                        
                        drNuevo["idTipoNotificacion"] = frmSeleccionaAccion.cboTipoNotificacion1.SelectedValue;
                        drNuevo["cTipoNotificacion"] = frmSeleccionaAccion.cboTipoNotificacion1.Text;                                                
                        drNuevo["idAccion"] = frmSeleccionaAccion.cboAccion1.SelectedValue;
                        drNuevo["cAccion"] = frmSeleccionaAccion.cboAccion1.Text;                        
                        drNuevo["idCuenta"] = dtgCarteraCreditos.CurrentRow.Cells["idCuenta"].Value;
                        drNuevo["idCli"] = dtgCarteraCreditos.CurrentRow.Cells["idCli"].Value;
                        drNuevo["cNombre"] = dtgCarteraCreditos.CurrentRow.Cells["cNombre"].Value;
                        drNuevo["cDireccion"] = dtgCarteraCreditos.CurrentRow.Cells["cDireccion"].Value;
                        drNuevo["nAtraso"] = dtgCarteraCreditos.CurrentRow.Cells["nAtraso"].Value;
                        drNuevo["cSimbolo"] = dtgCarteraCreditos.CurrentRow.Cells["cSimbolo"].Value;
                        drNuevo["nSaldoCapital"] = dtgCarteraCreditos.CurrentRow.Cells["nSaldoCapital"].Value;
                        drNuevo["cUbigeo"] = dtgCarteraCreditos.CurrentRow.Cells["cUbigeo"].Value;
                        drNuevo["cTipoIntervencion"] = dtgCarteraCreditos.CurrentRow.Cells["cTipoIntervencion"].Value;
                        drNuevo["cTipoDir"] = dtgCarteraCreditos.CurrentRow.Cells["cTipoDir"].Value;
                        drNuevo["lDirPrincipal"] = dtgCarteraCreditos.CurrentRow.Cells["lDirPrincipal"].Value;
                        drNuevo["nTotalPagar"] = dtgCarteraCreditos.CurrentRow.Cells["nTotalPagar"].Value;
                        drNuevo["cObservacion"] = dtgCarteraCreditos.CurrentRow.Cells["cObservacion"].Value;
                        drNuevo["idIntervCre"] = dtgCarteraCreditos.CurrentRow.Cells["idIntervCre"].Value;
                        drNuevo["idDireccion"] = dtgCarteraCreditos.CurrentRow.Cells["idDireccion"].Value;
                        
                        drNuevo["idDetalleHojaRuta"] = dtgCarteraCreditos.CurrentRow.Cells["idDetalleHojaRutaCre"].Value;
                        drNuevo["lDireccionRecupera"] = dtgCarteraCreditos.CurrentRow.Cells["lDireccionRecuperaCre"].Value;

                        drNuevo["cAnexo"] = dtgCarteraCreditos.CurrentRow.Cells["cAnexo"].Value;
                        drNuevo["cDistrito"] = dtgCarteraCreditos.CurrentRow.Cells["cDistrito"].Value;
                        drNuevo["cProvincia"] = dtgCarteraCreditos.CurrentRow.Cells["cProvincia"].Value;
                        drNuevo["cDepartamento"] = dtgCarteraCreditos.CurrentRow.Cells["cDepartamento"].Value;
                        drNuevo["idTipoInterv"] = dtgCarteraCreditos.CurrentRow.Cells["idTipoInterv"].Value;

                        dtHojaRuta.Rows.Add(drNuevo);
                        dtgCarteraCreditos.Rows.RemoveAt(e.RowIndex);
                        frmSeleccionaAccion.Dispose();
                    }
                }
            }
        }

        private void dtgHojaRuta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dtgHojaRuta.Columns[e.ColumnIndex].HeaderText == "Quitar")
                {
                    DataRow drNuevo = dtCreditos.NewRow();
                    drNuevo["btnAgregar"] = new Button().Text = "+";                    
                    drNuevo["idCuenta"] = dtgHojaRuta.CurrentRow.Cells["idCuentaHR"].Value;
                    drNuevo["idCli"] = dtgHojaRuta.CurrentRow.Cells["idCliHR"].Value;
                    drNuevo["cNombre"] = dtgHojaRuta.CurrentRow.Cells["cNombreHR"].Value;
                    drNuevo["cDireccion"] = dtgHojaRuta.CurrentRow.Cells["cDireccionHR"].Value;
                    drNuevo["nAtraso"] = dtgHojaRuta.CurrentRow.Cells["nAtrasoHR"].Value;
                    drNuevo["cSimbolo"] = dtgHojaRuta.CurrentRow.Cells["cSimboloHR"].Value;
                    drNuevo["nSaldoCapital"] = dtgHojaRuta.CurrentRow.Cells["nSaldoCapitalHR"].Value;
                    drNuevo["cUbigeo"] = dtgHojaRuta.CurrentRow.Cells["cUbigeoHR"].Value;
                    drNuevo["cTipoIntervencion"] = dtgHojaRuta.CurrentRow.Cells["cTipoIntervencionHR"].Value;
                    drNuevo["cTipoDir"] = dtgHojaRuta.CurrentRow.Cells["cTipoDirHR"].Value;
                    drNuevo["lDirPrincipal"] = dtgHojaRuta.CurrentRow.Cells["lDirPrincipalHR"].Value;
                    drNuevo["nTotalPagar"] = dtgHojaRuta.CurrentRow.Cells["nTotalPagarHR"].Value;
                    drNuevo["cObservacion"] = dtgHojaRuta.CurrentRow.Cells["cObservacionHR"].Value;
                    drNuevo["idIntervCre"] = dtgHojaRuta.CurrentRow.Cells["idIntervCreHR"].Value;
                    drNuevo["idDireccion"] = dtgHojaRuta.CurrentRow.Cells["idDireccionHR"].Value;
                    drNuevo["idDetalleHojaRuta"] = dtgHojaRuta.CurrentRow.Cells["idDetalleHojaRuta"].Value;
                    drNuevo["lDireccionRecupera"] = dtgHojaRuta.CurrentRow.Cells["lDireccionRecupera"].Value;

                    drNuevo["cAnexo"] = dtgHojaRuta.CurrentRow.Cells["cAnexoHR"].Value;
                    drNuevo["cDistrito"] = dtgHojaRuta.CurrentRow.Cells["cDistritoHR"].Value;
                    drNuevo["cProvincia"] = dtgHojaRuta.CurrentRow.Cells["cProvinciaHR"].Value;
                    drNuevo["cDepartamento"] = dtgHojaRuta.CurrentRow.Cells["cDepartamentoHR"].Value;
                    drNuevo["idTipoInterv"] = dtgHojaRuta.CurrentRow.Cells["idTipoIntervHR"].Value;

                    dtCreditos.Rows.Add(drNuevo);
                    dtgHojaRuta.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private bool buscarCuentaSeleccionada(int idCuenta, int idIntervCre, int idDireccion)
        {
            foreach (DataRow row in dtHojaRuta.Rows)
            {
                if (Convert.ToInt32(row["idCuenta"]) == idCuenta && Convert.ToInt32(row["idIntervCre"]) == idIntervCre && Convert.ToInt32(row["idDireccion"]) == idDireccion)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFechaInicio.Value) < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de inicio de la hoja de ruta no puede ser menor a la fecha del sistema", "Validar creación hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Focus();
                return;
            }
            if (Convert.ToDateTime(dtpFechaFin.Value) < Convert.ToDateTime(dtpFechaInicio.Value))
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha de inicio de la hoja de ruta.", "Validar creación hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaFin.Focus();
                return;
            }
            DataTable dtResultado = cnHojaRuta.validarHojaDeRutaAnteriores(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.dFecSystem ,
                                                                                Convert.ToDateTime(dtpFechaInicio.Value),Convert.ToDateTime(dtpFechaFin.Value));
            if (Convert.ToInt32(dtResultado.Rows[0][0]) != 0)
            {
                MessageBox.Show("No puede crear hoja de ruta: " + dtResultado.Rows[0][1], "Validar creación hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            valoresPorDefecto();
            limpiarControles();
            habilitarControles(true);
            btnBlanco1.PerformClick();
        }

        private void habilitarControles(bool habilitar)
        {
            dtpFechaInicio.Enabled = !habilitar;
            dtpFechaFin.Enabled = !habilitar;
            conBusUbig1.Enabled = habilitar;
            txtAtrazoMin.Enabled = habilitar;
            txtAtrazoMax.Enabled = habilitar;
            txtSaldoCapitalMin.Enabled = habilitar;
            txtSaldoCapitalMax.Enabled = habilitar;
            btnCancelar1.Enabled = habilitar;
            btnConsultar1.Enabled = habilitar;
            btnGrabar1.Enabled = habilitar;
            btnNuevo1.Enabled = !habilitar;
            dtgCarteraCreditos.Enabled = habilitar;
            dtgHojaRuta.Enabled = habilitar;
            txtKilometrajeInicio.Enabled = habilitar;
            grbFiltros.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            txtKilometrajeInicio.Text = String.Empty;
            dtHojaRuta.Rows.Clear();
            dtCreditos.Rows.Clear();           
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;            
            valoresPorDefecto();
            limpiarControles();
            habilitarControles(false);
        }

        private bool validar()
        {
            if ((DateTime)dtpFechaInicio.Value > (DateTime)dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha inicio no puede ser menor que la fecha final", "Validar hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Focus();
                return false;
            }
            if ((DateTime)dtpFechaInicio.Value < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicio no puede ser menor que la fecha del sistema", "Validar hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Focus();
                return false;
            }
            if (txtKilometrajeInicio.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar el campo kilometraje inicio", "Validar hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtKilometrajeInicio.Focus();
                return false;
            }            
            if (dtHojaRuta.Rows.Count <= 0)
            {
                MessageBox.Show("Debe ingresar al menos un crédito en su hoja de ruta", "Validar hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return false;
            }
            return true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataSet ds = new DataSet();
                DataTable dtHojaRutaCopy = dtHojaRuta.Copy();
                dtHojaRutaCopy.Columns.Remove("cAccion");
                dtHojaRutaCopy.Columns.Remove("cDireccion");
                dtHojaRutaCopy.Columns.Remove("cTipoNotificacion");
                dtHojaRutaCopy.Columns.Remove("cObservacion");
                dtHojaRutaCopy.Columns.Remove("cNombre");
                dtHojaRutaCopy.Columns.Remove("cSimbolo");
                dtHojaRutaCopy.Columns.Remove("cUbigeo");
                dtHojaRutaCopy.Columns.Remove("cTipoIntervencion");
                dtHojaRutaCopy.Columns.Remove("cTipoDir");
                dtHojaRutaCopy.Columns.Remove("lDirPrincipal");
                dtHojaRutaCopy.Columns.Remove("btnQuitar");

                dtHojaRutaCopy.Columns.Remove("cAnexo");
                dtHojaRutaCopy.Columns.Remove("cDistrito");
                dtHojaRutaCopy.Columns.Remove("cProvincia");
                dtHojaRutaCopy.Columns.Remove("cDepartamento");
                ds.Tables.Add(dtHojaRutaCopy);
                
                string xmlHojaRuta = ds.GetXml();                
                DataTable dtResultado = cnHojaRuta.registrarHojaRuta(clsVarGlobal.PerfilUsu.idUsuario,Convert.ToDateTime(dtpFechaInicio.Value), Convert.ToDateTime(dtpFechaFin.Value), Convert.ToInt32(txtKilometrajeInicio.Text), xmlHojaRuta, clsVarGlobal.dFecSystem);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Hoja de ruta registrado correctamente", "Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarControles(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar hoja de ruta: " + dtResultado.Rows[0][1], "Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chbTodosIntervinientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodosIntervinientes.Checked)
            {
                cboTipoIntervCre1.Enabled = false;
                cboTipoIntervCre1.SelectedIndex = -1;
            }
            else
            {
                cboTipoIntervCre1.Enabled = true;
                cboTipoIntervCre1.SelectedIndex = 0;
            }
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            completarControlesVacios();

            dtCreditos = cnHojaRuta.listaCarteraPendiente(clsVarGlobal.PerfilUsu.idUsuario, Convert.ToDateTime(dtpFechaFin.Value));

            if (dtHojaRuta.Rows.Count <= 0)
            {
                dtHojaRuta = dtCreditos.Clone();
                dtHojaRuta.Clear();
                dtHojaRuta.Columns.Add("btnQuitar");
                dtHojaRuta.Columns.Add("idAccion");
                dtHojaRuta.Columns.Add("cAccion");
                dtHojaRuta.Columns.Add("idTipoNotificacion");
                dtHojaRuta.Columns.Add("cTipoNotificacion");
                dtgHojaRuta.DataSource = dtHojaRuta;
            }
            dtCreditos.Columns.Add("btnAgregar");


            foreach (DataRow row in dtCreditos.Rows)
            {
                row["btnAgregar"] = new Button().Text = "+";
                if (dtHojaRuta.Rows.Count > 0 && buscarCuentaSeleccionada(Convert.ToInt32(row["idCuenta"]), Convert.ToInt32(row["idIntervCre"]), Convert.ToInt32(row["idDireccion"])))
                {
                    row.Delete();
                }
            }
            dtgCarteraCreditos.DataSource = dtCreditos;  
        }

    }
}

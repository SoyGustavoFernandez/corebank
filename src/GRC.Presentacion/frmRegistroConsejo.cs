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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GRC.CapaNegocio;
using CLI.CapaNegocio;

namespace GRC.Presentacion
{
    public partial class frmRegistroConsejo : frmBase
    {
        #region Variables

        Transaccion tOpe = Transaccion.Nuevo;
        clsCNConsejo consejo = new clsCNConsejo();
        clsCNIntegranteConsejo integrante = new clsCNIntegranteConsejo();
        DataTable dtIntegrantes;
        clsCNSocio socio = new clsCNSocio();

        #endregion

        public frmRegistroConsejo()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarConsejos();
            if (dtgConsejos.SelectedRows.Count>0)
            {
                cargarDatosConsejo();
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                cargarDatoIntegrante();
            }
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            tOpe = Transaccion.Nuevo;
            habilitarDetalle(true);
            habilitarConsejo(true);
            dtgConsejos.Enabled = false;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;            
            limpiarControles();

            if (dtgConsejos.SelectedRows.Count>0)
            {
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                cargarDatoIntegrante();
            }
            else
            {
                dtIntegrantes = integrante.ListarIntegranteIdConsejo(0);
                dtgIntegrantes.DataSource = dtIntegrantes;
                formatoGridIntegrante();
            }
            
            
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            tOpe = Transaccion.Edita;
            habilitarDetalle(true);
            habilitarConsejo(true);
            dtgConsejos.Enabled = false;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarConsejo(false);
            habilitarDetalle(false);
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            limpiarControles();
            if (dtgConsejos.SelectedRows.Count > 0)
            {
                cargarDatosConsejo();
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                cargarDatoIntegrante();
            }
            dtgIntegrantes.Enabled = true;
            dtgConsejos.Enabled = true;            
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string xmlIntegrante = xmlIntegrantes();

                if (tOpe == Transaccion.Nuevo)
                {
                    consejo.InsertarConsejo(txtConsejo.Text.Trim(), (int)cboTipoConsejo1.SelectedValue, true, xmlIntegrante);
                    MessageBox.Show("Los datos se guardaron correctamente", "Registro de Consejo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (tOpe == Transaccion.Edita)
                {
                    var idConsejo = Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value);
                    consejo.ActualizarConsejo(txtConsejo.Text.Trim(), (int)cboTipoConsejo1.SelectedValue, true, idConsejo, xmlIntegrante);
                    MessageBox.Show("Los datos se actualizaron correctamente", "Registro de Consejo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                habilitarConsejo(false);
                habilitarDetalle(false);
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = true;
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = false;
                limpiarControles();
                cargarConsejos();
                if (dtgConsejos.SelectedRows.Count > 0)
                {
                    cargarDatosConsejo();
                    cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                    cargarDatoIntegrante();
                }
                dtgIntegrantes.Enabled = true;
                dtgConsejos.Enabled = true;  
            }
        }

        private void dtgConsejos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgConsejos.SelectedRows.Count > 0)
            {


            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (validarIntegrante())
           {
               int idConsejoAux = 0;
                if (tOpe == Transaccion.Edita)
                {
                    idConsejoAux = Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value);
                }

                var drIntegrante = dtIntegrantes.NewRow();
                drIntegrante["idConsejo"] = idConsejoAux;
                drIntegrante["idCli"] = conBusCli1.idCli;
                drIntegrante["dFecIni"] = dtpFecIni.Value.Date;
                drIntegrante["dFecfin"] = dtpFecFin.Value.Date;
                drIntegrante["idTipoIntegranteConsejo"] = (int)cboTipoIntegranteConsejo1.SelectedValue;
                drIntegrante["lVigente"] = true;
                drIntegrante["cTipoIntegranteConsejo"] = cboTipoIntegranteConsejo1.Text;
                dtIntegrantes.Rows.Add(drIntegrante);
                conBusCli1.limpiarControles();
            }
        }

        private bool validarIntegrante()
        {
            bool lVal = false;

            if (conBusCli1.idCli == 0)
            {

                MessageBox.Show("Debe seleccionar un socio", "Validación de Socio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }
            if (exiteCargo("PRESIDENTE"))
            {
                MessageBox.Show("Ya existe el cargo de PRESIDENTE", "Validación cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (exiteCargo("VICEPRESIDENTE"))
            {
                MessageBox.Show("Ya existe el cargo de VICEPRESIDENTE", "Validación cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (exiteSocio(conBusCli1.idCli))
            {
                MessageBox.Show("Socio ya esta registrado en el consejo", "Validación de socio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if ((dtpFecIni.Value - dtpFecFin.Value).Ticks > 0)
            {
                MessageBox.Show("La fecha inicial debe ser menor a la final", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }
            lVal = true;
            return lVal;
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgIntegrantes.Rows.Count > 0)
            {
                if (dtgIntegrantes.SelectedRows.Count > 0)
                {
                    dtgIntegrantes.Rows.Remove(dtgIntegrantes.SelectedRows[0]);
                }
            }
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0)
            {
                btnAgregar1.Enabled = false;
            }
            else
            {
                var datsocio = socio.retornardatossocio(conBusCli1.idCli);
                if (datsocio == null)
                {
                    MessageBox.Show("Persona seleccionada debe de ser socio", "Validación socio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conBusCli1.limpiarControles();
                    btnAgregar1.Enabled = false;
                    return;
                }
                else
                {
                    btnAgregar1.Enabled = true;
                }
            }
        }

        private void dtgIntegrantes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cargarDatoIntegrante();
        }

        private void dtgIntegrantes_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatoIntegrante();
        }

        private void dtgConsejos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgConsejos.SelectedRows.Count > 0)
            {
                cargarDatosConsejo();
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                cargarDatoIntegrante();
            }
        }

        #endregion

        #region Metodos

        private string xmlIntegrantes()
        {
            DataSet dsIntegrantes= new DataSet("dsIntegrantes") ;
            dsIntegrantes.Tables.Add(dtIntegrantes);
            var xml = dsIntegrantes.GetXml();
            return xml ;
        }

        private void cargarConsejos()
        {
            var dtConsejos = consejo.ListarConsejo();
            if (dtConsejos.Rows.Count>0)
            {
                dtgConsejos.DataSource = dtConsejos;
                formatoGridConsejos();
            }            
        }
        
        private void formatoGridConsejos()
        {
            foreach (DataGridViewColumn item in dtgConsejos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgConsejos.Columns["cConsejo"].Visible = true;
            dtgConsejos.Columns["lVigente"].Visible = true;

            dtgConsejos.Columns["cConsejo"].HeaderText = "Consejo";
            dtgConsejos.Columns["lVigente"].HeaderText = "Vigente";
        }

        private void habilitarDetalle(bool lEstado)
        {
            dtgIntegrantes.Enabled = lEstado;
            grbDatosIntegrante.Enabled = lEstado;
        }

        private void habilitarConsejo(bool lEstado)
        {
            dtgConsejos.Enabled = lEstado;
            cboTipoConsejo1.Enabled = lEstado;
            txtConsejo.Enabled = lEstado;
            rbtActivo.Enabled = lEstado;
            rbtnInactivo.Enabled = lEstado;
        }
          
        private bool validar()
        {
            bool lVal = false;

            if (txtConsejo.Text=="")
            {
                MessageBox.Show("Debe de ingresa una descripción válida del consejo", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            
            lVal = true;
            return lVal;
        }

        private void cargarDatosConsejo()
        {
            var drConsejo = dtgConsejos.SelectedRows[0];
            cboTipoConsejo1.SelectedValue = (int)drConsejo.Cells["idTipoConsejo"].Value;
            txtConsejo.Text = drConsejo.Cells["cConsejo"].Value.ToString();

            if (Convert.ToBoolean(drConsejo.Cells["lVigente"].Value)==true)
            {
                rbtnInactivo.Checked = false;
                rbtActivo.Checked = true;
            }
            else
            {
                rbtnInactivo.Checked = true;
                rbtActivo.Checked = false;
            }
        }

        private void cargarIntegrantes(int idConsejo)
        {
            var dtIntegranteAux = integrante.ListarIntegranteIdConsejo(idConsejo);
            dtIntegrantes = dtIntegranteAux;
            if (dtIntegranteAux.Rows.Count>0)
            {
                dtgIntegrantes.DataSource = dtIntegranteAux;
                formatoGridIntegrante();
            }
        }

        private void formatoGridIntegrante()
        {
            foreach (DataGridViewColumn item in dtgIntegrantes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            dtgIntegrantes.Columns["idCli"].Visible = true;
            dtgIntegrantes.Columns["dFecIni"].Visible = true;
            dtgIntegrantes.Columns["dFecfin"].Visible = true;
            dtgIntegrantes.Columns["cTipoIntegranteConsejo"].Visible = true;

            dtgIntegrantes.Columns["idCli"].HeaderText = "Código Socio";
            dtgIntegrantes.Columns["dFecIni"].HeaderText = "Fecha Inicio";
            dtgIntegrantes.Columns["dFecfin"].HeaderText = "Fecha Fin";
            dtgIntegrantes.Columns["cTipoIntegranteConsejo"].HeaderText = "Tipo";

            dtgIntegrantes.Columns["dFecIni"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgIntegrantes.Columns["dFecfin"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private bool exiteSocio(int idCli)
        {
            bool lVal = true;
            int nValPre = 0;
            foreach (DataGridViewRow item in dtgIntegrantes.Rows)
            {
                if (item.Cells["idCli"].Value.ToString() == idCli.ToString())
                {
                    nValPre++;
                }
            }
            if (nValPre > 0)
            {
                return lVal;
            }


            lVal = false;
            return lVal;
        }

        private bool exiteCargo(string cCargo)
        {
            bool lVal = true;
            int nValPre = 0;
            foreach (DataGridViewRow item in dtgIntegrantes.Rows)
            {
                if (item.Cells["cTipoIntegranteConsejo"].Value.ToString().ToUpper()==cboTipoIntegranteConsejo1.Text.ToUpper()
                    && cboTipoIntegranteConsejo1.Text.ToUpper() == cCargo.ToUpper())
                {
                    nValPre++;
                }
            }
            if (nValPre>0)
            {                
                return lVal;
            }


            lVal = false;
            return lVal;
        }

        private void cargarDatoIntegrante()
        {
            if (dtgIntegrantes.SelectedRows.Count > 0)
            {
                var drInteg = dtgIntegrantes.SelectedRows[0];
                conBusCli1.CargardatosCli(Convert.ToInt32(drInteg.Cells["idCli"].Value));

                cboTipoIntegranteConsejo1.SelectedValue = Convert.ToInt32(drInteg.Cells["idTipoIntegranteConsejo"].Value);
                dtpFecIni.Value = Convert.ToDateTime(drInteg.Cells["dFecIni"].Value);
                dtpFecFin.Value = Convert.ToDateTime(drInteg.Cells["dFecfin"].Value);
            }
        }

        private void limpiarControles()
        {
            txtConsejo.Text = "";
            rbtActivo.Checked = false;
            rbtnInactivo.Checked = false;
            conBusCli1.limpiarControles();
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        #endregion
    }
}

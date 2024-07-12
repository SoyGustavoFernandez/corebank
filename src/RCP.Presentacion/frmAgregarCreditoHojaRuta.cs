using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmAgregarCreditoHojaRuta : frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        DataTable dtCreditos = new DataTable();
        public int idCuentaSeleccionada = 0;
        public int idAccionSeleccionada = 0;
        public int idNotificacionSeleccionada = 0;
        public int nAtrasoSeleccionado = 0;
        public int idIntervCreSelecionado=0;
        public int idDireccionSeleccionada = 0;
        public bool lDireccionRecupera = false;
        public bool lAceptar = false;
        public DataTable dtHojaRuta = new DataTable();
        
        public frmAgregarCreditoHojaRuta()
        {
            InitializeComponent();
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            completarControlesVacios();
            int nAtrazoMin = Convert.ToInt32(txtAtrazoMin.Text);
            int nAtrazoMax = Convert.ToInt32(txtAtrazoMax.Text);
            Decimal nSaldoCapitalMin = Convert.ToDecimal(txtSaldoCapitalMin.Text);
            Decimal nSaldoCapitalMax = Convert.ToDecimal(txtSaldoCapitalMax.Text);
            int idUbigeo = conBusUbig1.nIdNodo;
            dtCreditos = cnHojaRuta.listaCarteraRecuperaciones(clsVarGlobal.PerfilUsu.idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, chbDireccionPrincipal.Checked, (cboTipoIntervCre1.SelectedIndex == -1) ? 0 : Convert.ToInt32(cboTipoIntervCre1.SelectedValue),clsVarGlobal.PerfilUsu.idPerfil);
            dtgCarteraCreditos.DataSource = dtCreditos;       
        }

        public void valoresPorDefecto()
        {
            conBusUbig1.cargarUbigeo(173);
            txtAtrazoMin.Text = "-9999999";
            txtAtrazoMax.Text = "9999999";
            txtSaldoCapitalMin.Text = "0.00";
            txtSaldoCapitalMax.Text = "9999999.99";
            chbTodosIntervinientes.Checked = true;
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

        private void frmAgregarCreditoHojaRuta_Load(object sender, EventArgs e)
        {
            conBusUbig1.cargar();
            valoresPorDefecto();
            cboAccion1.SelectedIndexChanged -= cboAccion1_SelectedIndexChanged;
            cboAccion1.cargarDatosPorPerfil(clsVarGlobal.PerfilUsu.idPerfil);
            cboAccion1.SelectedIndexChanged += cboAccion1_SelectedIndexChanged;
        }

        private void dtgCarteraCreditos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cboTipoNotificacion1.cargar(nAtrasoSeleccionado, Convert.ToInt32(dtgCarteraCreditos.CurrentRow.Cells["idTipoInterv"].Value));
            cboTipoNotificacion1.Enabled = true;
            cboAccion1_SelectedIndexChanged(cboAccion1, new EventArgs());
            
        }       

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lAceptar = false;
            this.Dispose();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            { 
                lAceptar = true;
                this.Dispose();
            }
        }

        private bool validar()
        {
            if (dtgCarteraCreditos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe de seleccionar un crédito", "Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return false;                
            }
            idCuentaSeleccionada = Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["idCuenta"].Value);
            idNotificacionSeleccionada = Convert.ToInt32(cboTipoNotificacion1.SelectedValue);
            idAccionSeleccionada = Convert.ToInt32(cboAccion1.SelectedValue);
            idIntervCreSelecionado = Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["idIntervCre"].Value);
            idDireccionSeleccionada = Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["idDireccion"].Value);
            nAtrasoSeleccionado = Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["nAtraso"].Value);
            lDireccionRecupera = Convert.ToBoolean(dtgCarteraCreditos.SelectedRows[0].Cells["DireccionRecupera"].Value);
            if (idAccionSeleccionada == 0)
            {
                MessageBox.Show("Debe de seleccionar la acción a realizar", "Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (creditoHojaRuta())
            {
                MessageBox.Show("El crédito ya existe en la hoja de ruta", "Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public bool creditoHojaRuta()
        {
            foreach (DataRow row in dtHojaRuta.Rows)
            {
                if (Convert.ToInt32(row["idCuenta"]) == idCuentaSeleccionada && Convert.ToInt32(row["idIntervCre"]) == idIntervCreSelecionado && Convert.ToInt32(row["idDireccion"]) == idDireccionSeleccionada)
                {
                    return true;
                }
            }
            return false;
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

        private void cboAccion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgCarteraCreditos.SelectedRows.Count == 0) return;
            if (cboAccion1.SelectedIndex >= 0)
            {
                if (cboAccion1.SelectedValue != null && !(cboAccion1.SelectedValue is DataRowView))
                {
                    DataRowView dr = (DataRowView)cboAccion1.SelectedItem;
                    var rowSugerido = ((DataTable)cboTipoNotificacion1.DataSource).AsEnumerable().FirstOrDefault(x => Convert.ToInt32(x["idTipoNotificacionEnRango"]) != 0);
                    int idSugerido = rowSugerido == null ? 0 : Convert.ToInt32(rowSugerido["idTipoNotificacion"]);

                    bool lNotificacion = Convert.ToBoolean(dr["lNotificacion"]);
                    cboTipoNotificacion1.Enabled = lNotificacion;
                    cboTipoNotificacion1.SelectedValue = lNotificacion ? idSugerido : 0;
                }
            }
        }

      

        
    }
}

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
using GEN.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using SPL.CapaNegocio;


namespace SPL.Presentacion
{
    public partial class frmMantenimientoUmbralSplaf : frmBase
    {
        clsCNUmbralSPL cnUmbralSPL = new clsCNUmbralSPL();
        int idUmbral = 0;
        EntityLayer.Transaccion transForm = EntityLayer.Transaccion.Selecciona;
        Point LocTemporal;
        Size SizTemporal;
        public frmMantenimientoUmbralSplaf()
        {
            InitializeComponent();
            LocTemporal = grbBase1.Location;
            SizTemporal = this.Size;
            cboAgencias.AgenciasYTodos();
            bloquearForm();
            limpiarForm();
            cargarOperaciones();
            cargarUmbralesPorAgencia();
            cargarTipoUmbralSplaft();
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void cargarOperaciones() 
        {
            DataTable dtListaOperaciones = cnUmbralSPL.ListarTipoOperacionesUlt();
            foreach (DataColumn item in dtListaOperaciones.Columns)
            {
                item.ReadOnly = false;   
            }
            
            dtgTipoOperacion.DataSource = dtListaOperaciones;
            formatoGridOpe();
        }
        
        private void formatoGridOpe()
        {
            foreach (DataGridViewColumn item in dtgTipoOperacion.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
            }

            dtgTipoOperacion.Columns["cTipoOperacionSplaft"].Visible = true;
            dtgTipoOperacion.Columns["cTipoOperacion"].Visible = true;
            dtgTipoOperacion.Columns["cMotivoOperacion"].Visible = true;
            dtgTipoOperacion.Columns["cProducto"].Visible = true;
            dtgTipoOperacion.Columns["cDesTipoPago"].Visible = true;
            dtgTipoOperacion.Columns["cCodSBS"].Visible = true;
            dtgTipoOperacion.Columns["lSel"].Visible = true;

            dtgTipoOperacion.Columns["cTipoOperacionSplaft"].HeaderText = "Op. Splaft";
            dtgTipoOperacion.Columns["cTipoOperacion"].HeaderText = "Op. Core";
            dtgTipoOperacion.Columns["cMotivoOperacion"].HeaderText = "Motivo Op.";
            dtgTipoOperacion.Columns["cProducto"].HeaderText = "Tipo Producto";
            dtgTipoOperacion.Columns["cDesTipoPago"].HeaderText = "Tipo Pago";
            dtgTipoOperacion.Columns["cCodSBS"].HeaderText = "Cod. SBS";
            dtgTipoOperacion.Columns["lSel"].HeaderText = "V.";

            dtgTipoOperacion.Columns["lSel"].DisplayIndex = 0;
            
        }
        private void cargarUmbralesPorAgencia()
        {
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            DataTable dtListaUmbral = cnUmbralSPL.ListarUmbralIdAgencia(0, idAgencia, 0); // nTipoUmbral 0 todos los umbrales
            
            dtgUmbrales.DataSource = dtListaUmbral;
            formatoGridVin();
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            activarForm();
            limpiarForm();
            dtgUmbrales.Enabled = false;
            cboAgencias.Enabled = false;
            transForm = EntityLayer.Transaccion.Nuevo;
        }
        private void bloquearForm()
        {
            cboTipoUmbral.Enabled = false;
            txtUmbralUSD.Enabled = false;
            btnGrabar1.Enabled = false;
            dtpFechaInicio.Enabled = false;
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            dtpFechaFin.Enabled = false;
        }
        private void activarForm()
        {
            cboTipoUmbral.Enabled = true;
            txtUmbralUSD.Enabled = true;
            //chklbOperaciones.Enabled = true;
            btnGrabar1.Enabled = true;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            dtpFechaInicio.Enabled = true;
            btnCancelar1.Enabled = true;
            dtpFechaFin.Enabled = true;
            ActivaTipoOperaciones(true);            
        }

        private void ActivaTipoOperaciones(Boolean lBol)
        {
            dtgTipoOperacion.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgTipoOperacion.Columns)
            {
                item.ReadOnly = true;
            }
            dtgTipoOperacion.Columns["lSel"].ReadOnly = !lBol;
        }
        private void limpiarForm()
        {
            idUmbral = 0;
            cboTipoUmbral.SelectedIndex = -1;
            txtUmbralUSD.Text = "0";
            // = true;
            for (int i = 0; i < dtgTipoOperacion.RowCount ; i++)
            {
                dtgTipoOperacion.Rows[i].Cells["lSel"].Value = false;
            }
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarForm();
            cargarUmbralesPorAgencia();

            if (Convert.ToInt32(cboAgencias.SelectedValue) == 0)
            {
                btnEditar1.Enabled = false;
                grbBase2.Visible = false;
                LocTemporal = grbBase1.Location;
                grbBase1.Location = grbBase2.Location;
                this.Size = new Size(480, 552);
            }
            else
            {
                this.Size = SizTemporal;
                btnEditar1.Enabled = true;
                grbBase1.Location = LocTemporal;
                grbBase2.Visible = true;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (cboTipoUmbral.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de umbral", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUmbralUSD.Text == "" || txtUmbralUSD.nDecValor == 0)
            {
                MessageBox.Show("Ingrese el monto del umbral", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validarSeleccionTipoOperaciones())
            {
                MessageBox.Show("Seleccione al menos una operación", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La 'Fecha de vigencia inicio' no puede ser mayor que la 'Fecha de vigencia fin'", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nTipoUmbral = Convert.ToInt32(cboTipoUmbral.SelectedValue);
            int idAgencia   = Convert.ToInt32(cboAgencias.SelectedValue);
            decimal nValor  = txtUmbralUSD.nDecValor;
            DateTime dFechaInicio = dtpFechaInicio.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            DataTable dtTipoOperaciones = new DataTable("dtTipoOperaciones");
            dtTipoOperaciones.Columns.Add("idTipoOperacionSplaft", typeof(int));
            DataRow drTipoOperacion;
            foreach (DataGridViewRow item in dtgTipoOperacion.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lSel"].Value))
                {
                    drTipoOperacion = dtTipoOperaciones.NewRow();
                    drTipoOperacion["idTipoOperacionSplaft"] = (int)item.Cells["idTipoOperacionSplaft"].Value;
                    dtTipoOperaciones.Rows.Add(drTipoOperacion);
                }
                
            }
            DataSet dsTipoOperacion = new DataSet("dsTipoOperacion");
            dsTipoOperacion.Tables.Add(dtTipoOperaciones);
            var cTipoOperaciones = dsTipoOperacion.GetXml();

            DataTable dt = cnUmbralSPL.CNValidandoUmbralExistente(idUmbral, nTipoUmbral, idAgencia, dFechaInicio, dFechaFin, cTipoOperaciones);
            
            string cMensaje = "";

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    cMensaje += item["cNombreAge"].ToString() + "\t   " + Convert.ToDateTime(item["dFechaInicio"]).ToString("dd/MM/yyyy") + "\t   " + Convert.ToDateTime(item["dFechaFin"]).ToString("dd/MM/yyyy") + "\n  ";
                }
                
                if (Convert.ToInt32(cboAgencias.SelectedValue) == 0)
                {
                    DialogResult res = MessageBox.Show("( * ) ¿Insertar el umbral para todas las oficinas excluyendo a estas? " + System.Environment.NewLine + "Ya existe Umbral para las siguientes oficinas: \n " + cMensaje, "Mantenimiento umbral - Splaft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Los umbrales no pueden sobreponerse en fecha de vigencia y tipo de operación; cambie las fechas del umbral y revise las operaciones seleccionadas", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            

            
            cnUmbralSPL.insertarUmbral(idUmbral, idAgencia, nTipoUmbral, nValor, dFechaInicio, dFechaFin, cTipoOperaciones);

            MessageBox.Show("Los datos han sido insertados correctamente", "Mantenimiento umbral - Splaft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarUmbralesPorAgencia();
            limpiarForm();
            bloquearForm();
            dtgUmbrales.Enabled = true;
            cboAgencias.Enabled = true;
            transForm = EntityLayer.Transaccion.Selecciona;
        }
        
        public Boolean validarSeleccionTipoOperaciones()
        {
            Boolean lBool = false;
            foreach (DataGridViewRow item in dtgTipoOperacion.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lSel"].Value))
                {
                    lBool = true;
                }
            }
            return lBool;
        }
        
        public void cargarTipoUmbralSplaft()
        {
            DataTable dtTipoUmbral = new DataTable();
            dtTipoUmbral.Columns.Add("idTipoUmbral", typeof(int));
            dtTipoUmbral.Columns.Add("cUmbral", typeof(string));

            dtTipoUmbral.Rows.Add(1, "Operaciones Únicas");
            dtTipoUmbral.Rows.Add(2, "Operaciones Múltiples Mensual");
            dtTipoUmbral.Rows.Add(3, "Operaciones Múltiples Tramo 1 - 3 días");
            cboTipoUmbral.DataSource = dtTipoUmbral;
            cboTipoUmbral.DisplayMember = "cUmbral";
            cboTipoUmbral.ValueMember = "idTipoUmbral";
        }

        private void formatoGridVin()
        {
            foreach (DataGridViewColumn item in dtgUmbrales.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgUmbrales.RowCount == 0)
            {
                dtgUmbrales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else 
            {
                dtgUmbrales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }

            dtgUmbrales.Columns["nValor"].Visible = true;
            dtgUmbrales.Columns["dFechaInicio"].Visible = true;
            dtgUmbrales.Columns["dFechaFin"].Visible = true;
            dtgUmbrales.Columns["cTipoUmbral"].Visible = true;

            dtgUmbrales.Columns["nValor"].HeaderText = "Monto USD (Dólares)";
            dtgUmbrales.Columns["dFechaInicio"].HeaderText = "Fecha de vigencia inicio";
            dtgUmbrales.Columns["dFechaFin"].HeaderText = "Fecha de vigencia fin";
            dtgUmbrales.Columns["cTipoUmbral"].HeaderText = "Tipo Umbral";
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarForm();
            bloquearForm();
            ActivaTipoOperaciones(false);
            dtgUmbrales.Enabled = true;
            cboAgencias.Enabled = true;
        }

        private void dtgUmbrales_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            limpiarForm();
            DataGridViewRow row = dtgUmbrales.Rows[e.RowIndex];
            idUmbral = Convert.ToInt32(row.Cells["idUmbral"].Value);
            DataTable dtUmbral = cnUmbralSPL.retornoUmbralPorId(idUmbral);
            //llenando formulario
            cboTipoUmbral.SelectedValue = Convert.ToInt32(dtUmbral.Rows[0]["nTipoUmbral"].ToString());
            txtUmbralUSD.Text = dtUmbral.Rows[0]["nValor"].ToString();
            dtpFechaInicio.Value = Convert.ToDateTime(dtUmbral.Rows[0]["dFechaInicio"]);
            dtpFechaFin.Value = Convert.ToDateTime(dtUmbral.Rows[0]["dFechaFin"]);
            DataTable dtTipoOperaciones = cnUmbralSPL.ListarTipoOperacionesPorIdUmbralUlt(idUmbral);

            foreach (DataRow item in dtTipoOperaciones.Rows)
            {
                for (int i = 0; i < dtgTipoOperacion.RowCount; i++)
                {
                    if (dtgTipoOperacion.Rows[i].Cells["idTipoOperacionSplaft"].Value.ToString() == item["idTipoOperacionSplaft"].ToString())
                    {
                        dtgTipoOperacion.Rows[i].Cells["lSel"].Value = true;
                    }
                }
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            activarForm();
            
            transForm = EntityLayer.Transaccion.Edita;
            dtgUmbrales.Enabled = false;
            cboAgencias.Enabled = false;
            cboTipoUmbral.Enabled = false;
        }
    }
}
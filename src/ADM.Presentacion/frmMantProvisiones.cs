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
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantProvisiones : frmBase
    {
        clsCNProvision provision = new clsCNProvision();
        string TipoOpe = "N";
        DataTable dtProGenerica;
        DataTable dtProEspecifica;

        public frmMantProvisiones()
        {
            InitializeComponent();
        }
             

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (txtAnioBusq.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Año para realizar la Búsqueda", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnioBusq.Focus();
                return;
            }
            if (Convert.ToInt32(txtAnioBusq.Text.Trim()) < 1900 || Convert.ToInt32(txtAnioBusq.Text.Trim()) > 2100)
            {
                MessageBox.Show("El Año de Búsqueda no se encuentra en el rango permitido (1900 - 2100)", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnioBusq.Focus();
                return;
            }
            if (cboMesBusq.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione un Mes para realizar la Búsqueda", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMesBusq.Focus();
                return;
            }
                                   
            int AnioBusqueda = Convert.ToInt32(txtAnioBusq.Text.Trim()) ;
            int idMesBusq = Convert.ToInt32(cboMesBusq.SelectedValue);

            limpiar();
            CargarProGenérica();
            CargarProEspecifica();

            txtAnioBusq.Enabled = false;
            cboMesBusq.Enabled = false;
            btnConsultar1.Enabled = false;

        }
        private void frmMantProvisiones_Load(object sender, EventArgs e)
        {
            CargarcboTablaActiva();
            limpiar();           
            HabilitarControles(false);

            txtAnioBusq.Clear();
            cboMesBusq.SelectedValue = 0;

        }
        private void CargarcboTablaActiva()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("id");
            tb.Columns.Add("cTabla");

            DataRow row = tb.NewRow();
            row["id"] = 1;
            row["cTabla"] = "TABLA 1";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 2;
            row["cTabla"] = "TABLA 2";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 3;
            row["cTabla"] = "TABLA 3";
            tb.Rows.Add(row);

            cboTablaEspecif.DataSource = tb;
            cboTablaEspecif.ValueMember = Convert.ToString(tb.Columns["id"]);
            cboTablaEspecif.DisplayMember = Convert.ToString(tb.Columns["cTabla"]);

        }
        private void CargarProGenérica() {
            
            dtProGenerica= provision.CNTasProAct();
           
            if (dtgGenerica.ColumnCount > 0)
            {
                dtgGenerica.Columns.Remove("nOrd");
                dtgGenerica.Columns.Remove("cPro");
                dtgGenerica.Columns.Remove("nProvisionT1");
                dtgGenerica.Columns.Remove("idCalificacion");
                dtgGenerica.Columns.Remove("idProducto");

            }
            dtgGenerica.DataSource = dtProGenerica.DefaultView;
               
            dtgGenerica.Columns["nOrd"].HeaderText = "Nro";
            dtgGenerica.Columns["nOrd"].Width = 20;
            dtgGenerica.Columns["nOrd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGenerica.Columns["cPro"].HeaderText = "Tipos de Crédito";
            dtgGenerica.Columns["cPro"].Width = 100;
            dtgGenerica.Columns["cPro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGenerica.Columns["nProvisionT1"].Visible = false;
            dtgGenerica.Columns["idCalificacion"].Visible = false;
            dtgGenerica.Columns["idProducto"].Visible = false;

            dtgGenerica.Columns["nOrd"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgGenerica.Columns["cPro"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    
        }
        private void CargarProEspecifica() {

            dtProEspecifica = provision.CNTasaProEspecifica();

            if (dtgEspecifica.ColumnCount > 0)
            {
                dtgEspecifica.Columns.Remove("idCalif");
                dtgEspecifica.Columns.Remove("cCategRiesgo");
                dtgEspecifica.Columns.Remove("nTabla1");
                dtgEspecifica.Columns.Remove("nTabla2");
                dtgEspecifica.Columns.Remove("nTabla3");
                dtgEspecifica.Columns.Remove("nTablaActiva");
            }
            dtgEspecifica.DataSource = dtProEspecifica.DefaultView;

            dtgEspecifica.Columns["idCalif"].HeaderText = "Código";
            dtgEspecifica.Columns["idCalif"].Width = 20;
            dtgEspecifica.Columns["idCalif"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEspecifica.Columns["cCategRiesgo"].HeaderText = "Categoria de Riesgo";
            dtgEspecifica.Columns["cCategRiesgo"].Width = 100;
            dtgEspecifica.Columns["cCategRiesgo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEspecifica.Columns["nTabla1"].HeaderText = "TABLA 1";
            dtgEspecifica.Columns["nTabla1"].Width = 35;
            dtgEspecifica.Columns["nTabla1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEspecifica.Columns["nTabla2"].HeaderText = "TABLA 2";
            dtgEspecifica.Columns["nTabla2"].Width = 35;
            dtgEspecifica.Columns["nTabla2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEspecifica.Columns["nTabla3"].HeaderText = "TABLA 3";
            dtgEspecifica.Columns["nTabla3"].Width = 35;
            dtgEspecifica.Columns["nTabla3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEspecifica.Columns["nTablaActiva"].Visible = false;

            dtgEspecifica.Columns["idCalif"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgEspecifica.Columns["cCategRiesgo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgEspecifica.Columns["nTabla1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgEspecifica.Columns["nTabla2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgEspecifica.Columns["nTabla3"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgEspecifica.ReadOnly = true;

            cboTablaEspecif.SelectedValue = Convert.ToInt32(dtgEspecifica.Rows[0].Cells["nTablaActiva"].Value);
        
        }
        private void MostrarDatos() {

            if (dtgGenerica.SelectedRows.Count > 0) { 

                Int32 nFila = Convert.ToInt32(dtgGenerica.SelectedCells[1].RowIndex);
                txtTasaGenerica.Text = dtgGenerica.Rows[nFila].Cells["nProvisionT1"].Value.ToString();

                decimal Tasa = provision.BuscarTasaMensual(txtAnioBusq.Text.Trim(), Convert.ToInt32(cboMesBusq.SelectedValue),
                                            Convert.ToInt32(dtgGenerica.Rows[nFila].Cells["idProducto"].Value));
                if (Tasa == 0)
                    txtTasaMesGenerica.Text = "";
                else
                    txtTasaMesGenerica.Text = Tasa.ToString();


                if (TipoOpe == "N")
                {
                    HabilitarControles(false);
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                }
            }             
        }

        private void dtgGenerica_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void HabilitarControles(Boolean val)
        {
            txtTasaGenerica.Enabled = val;
            txtTasaMesGenerica.Enabled = val;

            cboTablaEspecif.Enabled = val;
           
          
        }
        private void limpiar()
        {
            txtTasaGenerica.Clear();
            txtTasaMesGenerica.Clear();

            cboTablaEspecif.SelectedValue=0;
        }
        private String Validaciones()
        {
            if (dtgGenerica.SelectedRows.Count > 0)
            {
                if (txtTasaGenerica.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la Tasa de provisión Genérica ", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaGenerica.Focus();
                    return "ERROR";
                }
                if (txtTasaMesGenerica.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la Tasa Mensual de provisión Genérica ", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMesGenerica.Focus();
                    return "ERROR";
                }
                if (Convert.ToDecimal(txtTasaMesGenerica.Text.Trim()) < Convert.ToDecimal(txtTasaGenerica.Text.Trim()))
                {
                    MessageBox.Show("La tasa de la Provisión del Mes debe ser mayor a " + txtTasaGenerica.Text.Trim(), "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMesGenerica.Focus();
                    return "ERROR";
                }
            }            
            
            if (cboTablaEspecif.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la la Tabla activa para la provisión específica", "Mantenimiento de Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTablaEspecif.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            TipoOpe = "A";
            HabilitarControles(true);
            if (dtgGenerica.SelectedRows.Count == 0)
            {
                txtTasaGenerica.Enabled = false;
                txtTasaMesGenerica.Enabled = false;
            }
            dtgEspecifica.ReadOnly = false;
            dtgEspecifica.Columns["idCalif"].ReadOnly = true;
            dtgEspecifica.Columns["cCategRiesgo"].ReadOnly = true;
            dtgEspecifica.Columns["nTabla1"].ReadOnly = false;
            dtgEspecifica.Columns["nTabla2"].ReadOnly = false;
            dtgEspecifica.Columns["nTabla3"].ReadOnly = false;

            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            TipoOpe = "N";
            limpiar();
            dtProGenerica.Clear();
            dtProEspecifica.Clear();
            HabilitarControles(false);
            txtAnioBusq.Clear();
            cboMesBusq.SelectedValue=0;

            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;

            txtAnioBusq.Enabled = true;
            cboMesBusq.Enabled = true;
            btnConsultar1.Enabled = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validaciones() == "ERROR")
                return;

            int idProductoGen = -1;

            if (dtgGenerica.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgGenerica.SelectedCells[1].RowIndex);                                
                idProductoGen = Convert.ToInt32(dtProGenerica.Rows[nFila]["idProducto"]);
            }
                      

            DataSet dsProEspecifico = new DataSet("dsEspecifico");
            dsProEspecifico.Tables.Add(dtProEspecifica);
            string xmlEspecifico = dsProEspecifico.GetXml();
            xmlEspecifico = clsCNFormatoXML.EncodingXML(xmlEspecifico);



            provision.ActualizarProvisiones( xmlEspecifico, Convert.ToInt32(cboTablaEspecif.SelectedValue),clsVarGlobal.dFecSystem,
                                            clsVarGlobal.PerfilUsu.idUsuario, Convert.ToDecimal(txtTasaGenerica.Text.Trim()), 
                                            Convert.ToDecimal(txtTasaMesGenerica.Text.Trim()),
                                            txtAnioBusq.Text.Trim(), Convert.ToInt32(cboMesBusq.SelectedValue), idProductoGen);

            MessageBox.Show("Los datos han sido Guardados correctamente", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarProGenérica();
            CargarProEspecifica();
            HabilitarControles(false);
            TipoOpe = "N";

            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = true;
        }
    }
}

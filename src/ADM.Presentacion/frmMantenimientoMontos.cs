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
using ADM.CapaNegocio;
using EntityLayer;


namespace ADM.Presentacion
{
    public partial class frmMantenimientoMontos : frmBase
    {
        public DataTable dtMonto;
        int permiso = 0;

        public frmMantenimientoMontos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMontos_Load(object sender, EventArgs e)
        {
            CargarMontos(0);
            CargarModulos();
            cboModulo1.SelectedIndex = -1;
            HabilitarControles(false);
            btnNuevo1.Enabled = false;
            permiso = 1;            
        }
        private void CargarModulos(){
            DataTable tb = new DataTable();
            tb.Columns.Add("id");
            tb.Columns.Add("cModulo");

            DataRow row = tb.NewRow();
            row["id"] = 0;
            row["cModulo"] = "";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 1;
            row["cModulo"] = "CRÉDITOS";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 2;
            row["cModulo"] = "DEPÓSITOS";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 9;
            row["cModulo"] = "SERVICIOS";
            tb.Rows.Add(row);

            cboModulo1.DataSource = tb;
            cboModulo1.ValueMember = Convert.ToString(tb.Columns["id"]);
            cboModulo1.DisplayMember = Convert.ToString(tb.Columns["cModulo"]);
        
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            
            if (Validaciones() == "ERROR") {
                return;
            }                        

            //fORMAR LA FILA Y AÑADIR A LA TABLA
            DataRow dr = dtMonto.NewRow();
            dr["nMontoMinimo"] = Convert.ToDecimal(txtMontoMin.Text.Trim());
            
            String NombreMonto = "";
            if (Convert.ToDecimal(txtMontoMin.Text.Trim()) == 0.00m && CBaMas.Checked == true)
            {
                NombreMonto += "Libre";
                dr["nMontoMaximo"] = 999999999.99;
            }
            else
            {
                if (Convert.ToDecimal(txtMontoMin.Text.Trim()) == 0.00m)
                    NombreMonto += "";
                else
                    NombreMonto += "De " + Convert.ToDecimal(txtMontoMin.Text.Trim()) + " ";

                if (CBaMas.Checked == false)
                {
                    NombreMonto += "Hasta " + Convert.ToDecimal(txtMontoMax.Text.Trim());
                    dr["nMontoMaximo"] = Convert.ToDecimal(txtMontoMax.Text.Trim());
                }
                else
                {
                    NombreMonto += "a más";
                    dr["nMontoMaximo"] = 999999999.99;
                }
            }
            dr["cMonto"] = NombreMonto;
            dr["Estado"] ="N";
            
            dtMonto.Rows.Add(dr);
            dtMonto.DefaultView.RowFilter = ("Estado <> 'NV'");


            int n= dtgMontos.Rows.Count;
            dtgMontos.CurrentCell = dtgMontos.Rows[n - 1].Cells[1];
            HabilitarControles(false);
            btnGrabar1.Enabled = true;

        }
        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgMontos.SelectedRows.Count > 0)
            {               
              
                Int32 nFila = Convert.ToInt32(dtgMontos.SelectedCells[0].RowIndex);
                if (Convert.ToString(dtgMontos.Rows[nFila].Cells["Estado"].Value) == "N")//monto recientemente agregado
                {                   
                    int i = 0;
                    foreach (DataRow fila in dtMonto.Rows)
                    {
                        if (Convert.ToInt32(dtMonto.Rows[i]["idMonto"]) == Convert.ToInt32(dtgMontos.Rows[nFila].Cells["idMonto"].Value))
                        {
                            dtMonto.Rows[i].Delete();
                            btnGrabar1.Enabled = true;
                            return;
                        }

                        i = i + 1;
                    }
                }
                else if (Convert.ToString(dtgMontos.Rows[nFila].Cells["Estado"].Value) == "V")//monto ya existente
                {
                    clsCNMontosXModulo MontosUsados = new clsCNMontosXModulo();
                    DataTable dtMontUso = MontosUsados.UsoMontos(Convert.ToInt32(dtgMontos.Rows[nFila].Cells["idMonto"].Value));
                    if (dtMontUso.Rows.Count == 0)//si no se usa el monto en ninguna configuracion de tarifas
                    {
                        int i = 0;
                        foreach (DataRow fila in dtMonto.Rows)
                        {                            
                            if (Convert.ToInt32(dtMonto.Rows[i]["idMonto"])==Convert.ToInt32(dtgMontos.Rows[nFila].Cells["idMonto"].Value))
                            {
                                dtMonto.Rows[i]["Estado"] = "NV";
                                btnGrabar1.Enabled = true;
                                return;
                            }

                            i = i + 1;
                        }
                        
                    }
                    else if (dtMontUso.Rows.Count > 0)//si esta siendo usado en la configuracion de tarifas
                    {
                        DialogResult dialogResult = MessageBox.Show("Existen " + dtMontUso.Rows.Count + " Tasas configuradas con este Monto, ¿Está seguro que desea eliminarlo?", "Mantenimiento de Montos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int i = 0;
                            foreach (DataRow fila in dtMonto.Rows)
                            {
                                if (Convert.ToInt32(dtMonto.Rows[i]["idMonto"]) == Convert.ToInt32(dtgMontos.Rows[nFila].Cells["idMonto"].Value))
                                {
                                    dtMonto.Rows[i]["Estado"] = "NV";
                                    btnGrabar1.Enabled = true;
                                    return;
                                }

                                i = i + 1;
                            }
                        }
                        if (dialogResult == DialogResult.No)
                            return;
                    }
                }                              

            }
        } 
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiar();
            HabilitarControles(true);
                        
            btnNuevo1.Enabled = false;
            btnAgregar1.Enabled = true;                       
            //btnGrabar1.Enabled = false;           
            btnQuitar1.Enabled = false;

        }        
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (txtMontoMin.Enabled == false) {
                limpiar();
                HabilitarControles(false);
                cboModulo1.SelectedIndex = -1;
                btnGrabar1.Enabled = false;
                btnNuevo1.Enabled = false;
                btnCancelar1.Enabled = false;
                dtMonto.Rows.Clear();
            
            }
            else if (txtMontoMin.Enabled == true)
            {
                limpiar();
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
            }

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtMonto.Rows.Count < 1)
            {
                MessageBox.Show("No hay Información para Actualizar", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DataSet dsMon = new DataSet("dsMontos");
                dsMon.Tables.Add(dtMonto);
                string xmlMontos = dsMon.GetXml();
                xmlMontos = clsCNFormatoXML.EncodingXML(xmlMontos);
                dsMon.Tables.Clear();

                               
                clsCNMontosXModulo ListaMontos = new clsCNMontosXModulo();
                ListaMontos.ActualizarMontos(xmlMontos, Convert.ToInt32(cboModulo1.SelectedValue), clsVarGlobal.User.idUsuario);

                MessageBox.Show("Los Intervalos de Montos han sido Guardados correctamente", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarMontos(Convert.ToInt32(cboModulo1.SelectedValue));
            btnGrabar1.Enabled = false;
                        
        }
                      
        private void dtgMontos_SelectionChanged(object sender, EventArgs e)
        {           
            MostrarDatos();
        }
        private void CBaMas_CheckedChanged(object sender, EventArgs e)
        {
            this.txtMontoMax.Enabled =! CBaMas.Checked;
            this.txtMontoMax.Clear();
        }
        private void txtMontoMin_Validating(object sender, CancelEventArgs e)
        {
            if (txtMontoMin.Text.Trim() != "")
            {
                if (Convert.ToInt32(Convert.ToDecimal(txtMontoMin.Text.Trim())) == 0)
                {
                    txtMontoMin.Text = (0).ToString("0.00");
                }
                if (Convert.ToInt32(Convert.ToDecimal(txtMontoMin.Text.Trim())) > 0)
                {                    
                    txtMontoMin.Text = (Convert.ToInt32(Convert.ToDecimal(txtMontoMin.Text.Trim()))).ToString("#.01");
                }
            }
        }
        private void txtMontoMax_Validating(object sender, CancelEventArgs e)
        {
            if (txtMontoMax.Text.Trim() != "")
            {
                if (Convert.ToInt32(Convert.ToDecimal(txtMontoMax.Text.Trim())) == 0)
                {
                    txtMontoMin.Text = (0).ToString("0.00");
                }
                if (Convert.ToInt32(Convert.ToDecimal(txtMontoMax.Text.Trim())) > 0)
                {
                    int Max = Convert.ToInt32(Convert.ToDecimal(txtMontoMax.Text.Trim()));
                    txtMontoMax.Text = (Max).ToString("#.00");
                }
            }
        }
       
        private void HabilitarControles(Boolean val ){
            txtMontoMin.Enabled = val;
            txtMontoMax.Enabled = val;
            CBaMas.Enabled = val;
                       
            //btnNuevo1.Enabled =! val;
            btnAgregar1.Enabled = val;                                  
            btnQuitar1.Enabled =! val;                   
        }
        private void limpiar() {
            txtMontoMin.Clear();
            txtMontoMax.Clear();
            CBaMas.Checked = false;
        }       
        private void MostrarDatos() {

            if (dtgMontos.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgMontos.SelectedCells[1].RowIndex);
                txtMontoMin.Text = Convert.ToString(dtgMontos.Rows[nFila].Cells["nMontoMinimo"].Value);

                if (Convert.ToString(dtgMontos.Rows[nFila].Cells["nMontoMaximo"].Value).Trim() == "999999999.99")
                    CBaMas.Checked = true;
                else
                {
                    CBaMas.Checked = false;
                    txtMontoMax.Text = Convert.ToString(dtgMontos.Rows[nFila].Cells["nMontoMaximo"].Value);
                }

                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnAgregar1.Enabled = false;
                btnQuitar1.Enabled = true;
            }
        }
        private void CargarMontos(int idModulo) {
            clsCNMontosXModulo ListaMontos = new clsCNMontosXModulo();
            dtMonto=ListaMontos.ListarMontos(idModulo);

            dtMonto.Columns.Add("Estado", typeof(String));
            int nNumFilas = dtMonto.Rows.Count;
            if (nNumFilas > 0)
            {
                for (int i = 0; i < nNumFilas; i++)
                {
                    dtMonto.Rows[i]["Estado"] = "V";
                }
            }  
            if (dtgMontos.ColumnCount > 0)
            {
                dtgMontos.Columns.Remove("idMonto");
                dtgMontos.Columns.Remove("nMontoMinimo");
                dtgMontos.Columns.Remove("nMontoMaximo");
                dtgMontos.Columns.Remove("cMonto");
                dtgMontos.Columns.Remove("Estado");
            }

            dtMonto.DefaultView.RowFilter = ("Estado <> 'NV'");
            dtgMontos.DataSource = dtMonto.DefaultView;
            FormatoGridMontos();


        }
        private void FormatoGridMontos() {
            dtgMontos.Columns["idMonto"].Visible = false;
            dtgMontos.Columns["nMontoMinimo"].HeaderText = "Monto Mínimo";
            dtgMontos.Columns["nMontoMinimo"].Width = 50;
            dtgMontos.Columns["nMontoMinimo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMontos.Columns["nMontoMaximo"].HeaderText = "Monto Máximo";
            dtgMontos.Columns["nMontoMaximo"].Width = 50;
            dtgMontos.Columns["nMontoMaximo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMontos.Columns["cMonto"].HeaderText = "Descripción del Rango de Montos";
            dtgMontos.Columns["cMonto"].Width = 90;
            dtgMontos.Columns["cMonto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMontos.Columns["Estado"].Visible = false;
        }
        private String Validaciones() {

            if (cboModulo1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccionar Módulo", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModulo1.Focus();
                return "ERROR";
            }

            if (txtMontoMin.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese Monto Mínimo", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoMin.Focus();
                return "ERROR";
            }
            
            if (CBaMas.Checked == false)
            {
                if (txtMontoMax.Text.Trim() == "" )
                {
                    MessageBox.Show("Ingrese Monto Máximo", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoMax.Focus();
                    return "ERROR";
                }
                if (Convert.ToDecimal(txtMontoMax.Text.Trim()) < Convert.ToDecimal (txtMontoMin.Text.Trim()))
                {
                    MessageBox.Show("El Monto Máximo es menor que el Mínimo", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoMax.Focus();
                    return "ERROR";
                }
                if (Convert.ToDecimal(txtMontoMax.Text.Trim()) == Convert.ToDecimal (txtMontoMin.Text.Trim()))
                {
                    MessageBox.Show("El Monto Máximo y Mínimo no pueden ser iguales", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoMax.Focus();
                    return "ERROR";
                }                
            }



            decimal Min = Convert.ToDecimal(txtMontoMin.Text.Trim());
            decimal Max = Convert.ToDecimal(999999999.99);
            if (CBaMas.Checked == false)
                Max = Convert.ToDecimal(txtMontoMax.Text.Trim());


            int i = 0;
            foreach (DataRow fila in dtMonto.Rows)
            {
                decimal MinAnt = Convert.ToDecimal(fila["nMontoMinimo"]);
                decimal MaxAnt = Convert.ToDecimal(fila["nMontoMaximo"]);
                if (MinAnt == Min && Max == MaxAnt)
                {
                    MessageBox.Show("El Intervalo ingresado ya pertenece a la Tabla de Montos", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoMin.Focus();
                    return "ERROR";
                }
                
                i = i + 1;
            }
                  

            return "OK";        
        }

        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo1.SelectedIndex >= 0 && permiso==1)
            {
                if (Convert.ToString(cboModulo1.Text.Trim()) == "")
                {
                    CargarMontos(0);
                    HabilitarControles(false);
                    btnGrabar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = false;
                }
                else
                {                   
                    CargarMontos(Convert.ToInt32(cboModulo1.SelectedValue) );
                    HabilitarControles(false);
                    btnNuevo1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                }
                limpiar();
                MostrarDatos();
            }         
        }
                   
                
    }
}

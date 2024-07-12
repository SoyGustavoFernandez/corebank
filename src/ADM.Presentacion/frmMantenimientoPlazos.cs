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
    public partial class frmMantenimientoPlazos : frmBase
    {
        public DataTable dtPlazo;
        int permiso = 0;

        public frmMantenimientoPlazos()
        {
            InitializeComponent();
        }

        private void MantenimientoPlazos_Load(object sender, EventArgs e)
        {
            CargarPlazos(0);
            CargarModulos();
            cboModulo1.SelectedIndex = -1;            
            HabilitarControles(false);
            permiso = 1;
        }
        private void CargarModulos()
        {
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

            cboModulo1.DataSource = tb;
            cboModulo1.ValueMember = Convert.ToString(tb.Columns["id"]);
            cboModulo1.DisplayMember = Convert.ToString(tb.Columns["cModulo"]);

        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgPlazos.SelectedRows.Count > 0)
            {

                Int32 nFila = Convert.ToInt32(dtgPlazos.SelectedCells[0].RowIndex);
                if (Convert.ToString(dtgPlazos.Rows[nFila].Cells["Estado"].Value) == "N")
                {
                    int i = 0;
                    foreach (DataRow fila in dtPlazo.Rows)
                    {
                        if (Convert.ToInt32(dtPlazo.Rows[i]["idPlazo"]) == Convert.ToInt32(dtgPlazos.Rows[nFila].Cells["idPlazo"].Value))
                        {
                            dtPlazo.Rows[i].Delete();
                            btnGrabar1.Enabled = true;
                            return;
                        }

                        i = i + 1;
                    }
                }
                else if (Convert.ToString(dtgPlazos.Rows[nFila].Cells["Estado"].Value) == "V")
                {
                    clsCNPlazosXModulo PlazosUsados = new clsCNPlazosXModulo();
                    DataTable dtPlazoUso = PlazosUsados.UsoPlazos(Convert.ToInt32(dtgPlazos.Rows[nFila].Cells["idPlazo"].Value));
                    if (dtPlazoUso.Rows.Count == 0)
                    {
                        int i = 0;
                        foreach (DataRow fila in dtPlazo.Rows)
                        {
                            if (Convert.ToInt32(dtPlazo.Rows[i]["idPlazo"]) == Convert.ToInt32(dtgPlazos.Rows[nFila].Cells["idPlazo"].Value))
                            {
                                dtPlazo.Rows[i]["Estado"] = "NV";
                                btnGrabar1.Enabled = true;
                                return;
                            }

                            i = i + 1;
                        }

                    }
                    else if (dtPlazoUso.Rows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Existen " + dtPlazoUso.Rows.Count + " Tasas configuradas con este Rango de Plazo, ¿Está seguro que desea eliminarlo?", "Mantenimiento de Plazos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int i = 0;
                            foreach (DataRow fila in dtPlazo.Rows)
                            {
                                if (Convert.ToInt32(dtPlazo.Rows[i]["idPlazo"]) == Convert.ToInt32(dtgPlazos.Rows[nFila].Cells["idPlazo"].Value))
                                {
                                    dtPlazo.Rows[i]["Estado"] = "NV";
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
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (Validaciones() == "ERROR")
            {
                return;
            }

            //fORMAR LA FILA Y AÑADIR A LA TABLA
            DataRow dr = dtPlazo.NewRow();
            dr["nMinPlazo"] = Convert.ToInt32(txtPlazoMin.Text.Trim());

            String NombrePlazo = "";
            if (Convert.ToInt32(txtPlazoMin.Text.Trim()) == 0 && CBaMas.Checked == true)
            {
                NombrePlazo += "Libre";
                dr["nMaxPlazo"] = 999999999;
            }
            else
            {
                
                NombrePlazo += Convert.ToInt32(txtPlazoMin.Text.Trim()) + " ";

                if (CBaMas.Checked == false)
                {
                    NombrePlazo += "- " + Convert.ToInt32(txtPlazoMax.Text.Trim())+ " días";
                    dr["nMaxPlazo"] = Convert.ToInt32(txtPlazoMax.Text.Trim());
                }
                else
                {
                    NombrePlazo += " días a más";
                    dr["nMaxPlazo"] = 999999999;
                }
            }
            dr["cPlazo"] = NombrePlazo;
            dr["Estado"] = "N";

            dtPlazo.Rows.Add(dr);
            dtPlazo.DefaultView.RowFilter = ("Estado <> 'NV'");


            int n = dtgPlazos.Rows.Count;
            dtgPlazos.CurrentCell = dtgPlazos.Rows[n - 1].Cells[1];
            HabilitarControles(false);
            btnGrabar1.Enabled = true;
            btnNuevo1.Enabled = true;

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
            if (txtPlazoMin.Enabled== false)
            {
                limpiar();
                HabilitarControles(false);
                cboModulo1.SelectedIndex = -1;
                btnGrabar1.Enabled = false;
                btnNuevo1.Enabled = false;
                btnCancelar1.Enabled = false;
                dtPlazo.Rows.Clear();

            }
            else if (txtPlazoMin.Enabled == true)
            {
                limpiar();
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
            }
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtPlazo.Rows.Count < 1)
            {
                MessageBox.Show("No hay Información para Actualizar", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DataSet dsPla = new DataSet("dsPlazos");
                dsPla.Tables.Add(dtPlazo);
                string xmlPlazos = dsPla.GetXml();
                xmlPlazos = clsCNFormatoXML.EncodingXML(xmlPlazos);
                dsPla.Tables.Clear();
                              

                clsCNPlazosXModulo ListaPlazos = new clsCNPlazosXModulo();
                ListaPlazos.ActualizarPlazos(xmlPlazos,  Convert.ToInt32(cboModulo1.SelectedValue), clsVarGlobal.User.idUsuario);

                MessageBox.Show("Los Rangos de Plazos han sido Guardados correctamente", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Convert.ToString(cboModulo1.SelectedValue) == "1")
                CargarPlazos(1);
            else
                CargarPlazos(2);
            btnGrabar1.Enabled = false;
        }
        
        private void dtgPlazos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void CBaMas_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPlazoMax.Enabled = !CBaMas.Checked;
            this.txtPlazoMax.Clear();
        }
    
        private void HabilitarControles(Boolean val)
        {
            txtPlazoMin.Enabled = val;
            txtPlazoMax.Enabled = val;
            CBaMas.Enabled = val;

            //btnNuevo1.Enabled = !val;
            btnAgregar1.Enabled = val;           
            btnQuitar1.Enabled = !val;
        }
        private void limpiar()
        {
            txtPlazoMin.Clear();
            txtPlazoMax.Clear();
            CBaMas.Checked = false;
        }
        private void MostrarDatos()
        {
            if (dtgPlazos.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgPlazos.SelectedCells[1].RowIndex);
                txtPlazoMin.Text = Convert.ToString(dtgPlazos.Rows[nFila].Cells["nMinPlazo"].Value);

                if (Convert.ToString(dtgPlazos.Rows[nFila].Cells["nMaxPlazo"].Value).Trim() == "999999999")
                    CBaMas.Checked = true;
                else
                {
                    CBaMas.Checked = false;
                    txtPlazoMax.Text = Convert.ToString(dtgPlazos.Rows[nFila].Cells["nMaxPlazo"].Value);
                }

                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnAgregar1.Enabled = false;
                btnQuitar1.Enabled = true;
            }
        }
        private void CargarPlazos(int idModulo)
        {
            clsCNPlazosXModulo ListaPlazos = new clsCNPlazosXModulo();
            dtPlazo = ListaPlazos.ListarPlazos(idModulo);

            dtPlazo.Columns.Add("Estado", typeof(String));
            int nNumFilas = dtPlazo.Rows.Count;
            if (nNumFilas > 0)
            {
                for (int i = 0; i < nNumFilas; i++)
                {
                    dtPlazo.Rows[i]["Estado"] = "V";
                }
            }
            if (dtgPlazos.ColumnCount > 0)
            {
                dtgPlazos.Columns.Remove("idPlazo");
                dtgPlazos.Columns.Remove("nMinPlazo");
                dtgPlazos.Columns.Remove("nMaxPlazo");
                dtgPlazos.Columns.Remove("cPlazo");
                dtgPlazos.Columns.Remove("Estado");
            }

            dtPlazo.DefaultView.RowFilter = ("Estado <> 'NV'");
            dtgPlazos.DataSource = dtPlazo.DefaultView;
            FormatoGridPlazos();


        }
        private void FormatoGridPlazos()
        {
            dtgPlazos.Columns["idPlazo"].Visible = false;
            dtgPlazos.Columns["nMinPlazo"].HeaderText = "Plazo Mínimo";
            dtgPlazos.Columns["nMinPlazo"].Width = 50;
            dtgPlazos.Columns["nMinPlazo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPlazos.Columns["nMaxPlazo"].HeaderText = "Plazo Máximo";
            dtgPlazos.Columns["nMaxPlazo"].Width = 50;
            dtgPlazos.Columns["nMaxPlazo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPlazos.Columns["cPlazo"].HeaderText = "Descripción del Rango de Plazos ";
            dtgPlazos.Columns["cPlazo"].Width = 90;
            dtgPlazos.Columns["cPlazo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPlazos.Columns["Estado"].Visible = false;
        }
        private String Validaciones()
        {
            if (cboModulo1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccionar Módulo", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModulo1.Focus();
                return "ERROR";
            }
            if (txtPlazoMin.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Plazos Mínimo", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlazoMin.Focus();
                return "ERROR";
            }

            if (CBaMas.Checked == false)
            {
                if (txtPlazoMax.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Plazos Máximo", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoMax.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtPlazoMax.Text.Trim()) < Convert.ToInt32(txtPlazoMin.Text.Trim()))
                {
                    MessageBox.Show("El Plazos Máximo es menor que el Mínimo", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoMax.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtPlazoMax.Text.Trim()) == Convert.ToInt32(txtPlazoMin.Text.Trim()))
                {
                    MessageBox.Show("El Plazos Máximo y Mínimo no pueden ser iguales", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoMax.Focus();
                    return "ERROR";
                }
                
            }

            int Min = Convert.ToInt32(txtPlazoMin.Text.Trim());
            int Max = Convert.ToInt32(999999);
            if (CBaMas.Checked == false)
                Max = Convert.ToInt32(txtPlazoMax.Text.Trim());


            int i = 0;
            foreach (DataRow fila in dtPlazo.Rows)
            {
                int MinAnt = Convert.ToInt32(fila["nMinPlazo"]);
                int MaxAnt = Convert.ToInt32(fila["nMaxPlazo"]);
                if (MinAnt == Min && Max == MaxAnt)
                {
                    MessageBox.Show("El Intervalo ingresado ya pertenece a la Tabla de Plazos", "Mantenimiento de Plazos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoMin.Focus();
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
                    CargarPlazos(0);
                    HabilitarControles(false);
                    btnGrabar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = false;
                }
                else
                {
                    CargarPlazos(Convert.ToInt32(cboModulo1.SelectedValue));                   
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

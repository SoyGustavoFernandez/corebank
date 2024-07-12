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
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using RCP.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmDireccionRecupera : frmBase
    {
        #region Variables

        DataTable dtbTipDir, tbDirCli;
        String zona, via, nro, dpto, inte, km, mz, lote;
        clsCNDireccionRecupera direccionrecupera = new clsCNDireccionRecupera();

        #endregion

        public frmDireccionRecupera()
        {
            InitializeComponent();
        }

        public frmDireccionRecupera(int idCli)
        {
            InitializeComponent();
            conBusCli1.idCli = idCli;
            conBusCli1.CargardatosCli(conBusCli1.idCli);
            CargarDatos();
                        //CargarDirCli(conBusCli1.idCli);
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            CargarDatos();
            CargarDirCli(0);
            LimpiarControles();
            HabilitarControles_Gen(false);
            conBusUbiCli.cargar();

            if (conBusCli1.idCli!=0)
            {
                CargarDirCli(conBusCli1.idCli);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarDir())
            {
                HabilitarGridDireccion(true);
                DataRow dr = tbDirCli.NewRow();
                if (this.conBusCli1.txtCodCli.Text.Trim() == "")
                {
                    dr["idCli"] = 0;
                }
                else
                {
                    dr["idCli"] = conBusCli1.txtCodCli.Text.Trim();
                }
                dr["idUbigeo"] = conBusUbiCli.cboAnexo.SelectedValue.ToString().Trim();
                dr["cDireccion"] = txtDireccion.Text.Trim();
                dr["cReferenciaDireccion"] = txtReferencia.Text.Trim();
                dr["idTipoDireccion"] = 3;
                dr["idDireccionRecupera"] = 0;
                dr["idTipoZona"] = cboTipoZona.SelectedValue.ToString().Trim();
                dr["cDesZona"] = txtZona.Text;
                dr["idTipoVia"] = cboTipoVia.SelectedValue.ToString().Trim();
                dr["cDesVia"] = txtVia.Text;
                dr["cNumero"] = textNro.Text;
                dr["cDepartamento"] = textDpto.Text;
                dr["cInterior"] = textInt.Text;
                dr["cKilometro"] = textKm.Text;
                dr["cManzana"] = textMz.Text;
                dr["cLote"] = textLote.Text;
                dr["idTipoVivienda"] = cboTipVivienda.SelectedValue.ToString().Trim();
                dr["cdescOtros"] = txtOtrosVivienda.Text;
                dr["nNumeroTelefono"] = txtTelefFijo1.Text;
                dr["nNumeroCelular"] = txtTelefCel1.Text;
                dr["lVigente"] = true;

                tbDirCli.Rows.Add(dr);
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli != 0)
            {
                LimpiarControles();
                HabilitarControles_Gen(true);
            }
            else
            {
                MessageBox.Show("Debe seleccionar el cliente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles_Gen(false);
            CargarDirCli(conBusCli1.idCli);
        }

        private void textZonas_TextChanged(object sender, EventArgs e)
        {
            String cadZona = "";
            if (txtZona.Text == "")
                cadZona = "";
            else if (cboTipoZona.Text == "OTROS")
                cadZona = txtZona.Text + " - ";
            else
                cadZona = cboTipoZona.Text + ": " + txtZona.Text + " - ";
            Direccion(cadZona, "textZona");
        }

        private void textVia_TextChanged(object sender, EventArgs e)
        {
            String cadVia = "";
            if (txtVia.Text == "")
                cadVia = "";
            else if (cboTipoVia.Text == "OTROS")
                cadVia = txtVia.Text + "  ";
            else
                cadVia = cboTipoVia.Text + " " + txtVia.Text + "  ";
            Direccion(cadVia, "textVia");
        }

        private void textNro_TextChanged(object sender, EventArgs e)
        {
            String cadNro = "";
            if (textNro.Text != "")
                cadNro += "Nro " + textNro.Text + "   ";
            Direccion(cadNro, "textNro");
        }

        private void textDpto_TextChanged(object sender, EventArgs e)
        {
            String cadDpto = "";
            if (textDpto.Text != "")
                cadDpto += "Dpto " + textDpto.Text + "   ";
            Direccion(cadDpto, "textDpto");
        }

        private void textInt_TextChanged(object sender, EventArgs e)
        {
            String cadInt = "";
            if (textInt.Text != "")
                cadInt += "Int " + textInt.Text + "   ";
            Direccion(cadInt, "textInt");
        }

        private void textKm_TextChanged(object sender, EventArgs e)
        {
            String cadKm = "";
            if (textKm.Text != "")
                cadKm += "Km " + textKm.Text + "   ";
            Direccion(cadKm, "textKm");
        }

        private void textMz_TextChanged(object sender, EventArgs e)
        {
            String cadMz = "";
            if (textMz.Text != "")
                cadMz += "Mz " + textMz.Text + "   ";
            Direccion(cadMz, "textMz");
        }

        private void textLote_TextChanged(object sender, EventArgs e)
        {
            String cadLote = "";
            if (textLote.Text != "")
                cadLote += "Lt " + textLote.Text + "   ";
            Direccion(cadLote, "textLote");
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            CargarDirCli(conBusCli1.idCli);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtgDireccion.RowCount>0)
            {
                if (validar())
                {
                    DataTable dtResultado = direccionrecupera.InsertarDireccionRecupera(crearDireccionesXml());
                    if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Registrar Dirección Recuperaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDirCli(conBusCli1.idCli);
                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar direcciones de recuperaciones", "Registrar Dirección Recuperaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cboTipoZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoZona.SelectedIndex == 0)
            {
                txtZona.Enabled = false;
                txtZona.Clear();
            }
            else
            {
                txtZona.Enabled = cboTipoZona.Enabled;
            }
        }

        private void cboTipoVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoVia.SelectedIndex == 0)
            {
                txtVia.Enabled = false;
                txtVia.Clear();
            }
            else
            {
                txtVia.Enabled = cboTipoVia.Enabled;
            }
        }

        private void cboTipVivienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipVivienda.Text != "" && cboTipVivienda.Enabled == true)
            {
                if (Convert.ToInt32(cboTipVivienda.SelectedValue) == 1 || Convert.ToInt32(cboTipVivienda.SelectedValue) == 2)
                {
                    this.txtOtrosVivienda.Enabled = false;
                    this.txtOtrosVivienda.Text = "";
                    this.txtPropVivienda.Enabled = false;
                    this.txtPropVivienda.Text = "";
                }
                if (Convert.ToInt32(cboTipVivienda.SelectedValue) == 3 || Convert.ToInt32(cboTipVivienda.SelectedValue) == 4)
                {
                    this.txtOtrosVivienda.Enabled = false;
                    this.txtOtrosVivienda.Text = "";
                    this.txtPropVivienda.Enabled = true;
                }
                if (Convert.ToInt32(cboTipVivienda.SelectedValue) == 5)
                {
                    this.txtOtrosVivienda.Enabled = true;
                    this.txtPropVivienda.Enabled = true;
                }
            }



        }
        #endregion

        #region Métodos

        private void CargarDatos()
        {
            clsCNTipoDireccion objTipDir = new clsCNTipoDireccion();
            dtbTipDir = objTipDir.ListaTipDireccion();
        }

        private void CargarDirCli(int cCodCli)
        {

            tbDirCli = direccionrecupera.ListarDireccionRecupera(cCodCli);

            if (dtgDireccion.ColumnCount > 0)
            {
                dtgDireccion.Columns.Clear();
            }

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "TIPO DE DIRECCION";
            cmb.Name = "cmb";
            cmb.FillWeight = 60;
            cmb.MaxDropDownItems = 4;
            cmb.DataSource = dtbTipDir;
            cmb.DisplayMember = dtbTipDir.Columns["cTipoDir"].ToString();
            cmb.ValueMember = dtbTipDir.Columns["idTipoDireccion"].ToString();

            dtgDireccion.Columns.Add(cmb);
            dtgDireccion.DataSource = tbDirCli;
            FormatoGridCli();
            Int32 nNumDir = tbDirCli.Rows.Count;
            if (nNumDir > 0)
            {
                for (int i = 0; i < nNumDir; i++)
                {
                    dtgDireccion.Rows[i].Cells["cmb"].Value = Convert.ToInt32(tbDirCli.Rows[i]["idTipoDireccion"].ToString());
                }
            }

            HabilitarGridDireccion(false);
        }

        private void FormatoGridCli()
        {
            foreach (DataGridViewColumn item in dtgDireccion.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDireccion.Columns["cDireccion"].Visible = true;
            dtgDireccion.Columns["cReferenciaDireccion"].Visible = true;
            dtgDireccion.Columns["cmb"].Visible = true;
            dtgDireccion.Columns["nNumeroTelefono"].Visible = true;
            dtgDireccion.Columns["nNumeroCelular"].Visible = true;

            dtgDireccion.Columns["cDireccion"].Width = 180;
            dtgDireccion.Columns["cReferenciaDireccion"].Width = 200;
            dtgDireccion.Columns["cmb"].Width = 140;
            dtgDireccion.Columns["nNumeroTelefono"].Width = 60;
            dtgDireccion.Columns["nNumeroCelular"].Width = 60;


            dtgDireccion.Columns["cDireccion"].HeaderText = "DIRECCION";
            dtgDireccion.Columns["cReferenciaDireccion"].HeaderText = "REFERENCIA";
            dtgDireccion.Columns["cmb"].HeaderText = "TIPO DE DIRECCION";
            dtgDireccion.Columns["nNumeroTelefono"].HeaderText = "TELEF.";
            dtgDireccion.Columns["nNumeroCelular"].HeaderText = "CELULAR";
        }

        public void HabilitarGridDireccion(Boolean bVal)
        {
            dtgDireccion.ReadOnly = !bVal;
            dtgDireccion.Columns["cmb"].ReadOnly = !bVal;
            dtgDireccion.Columns["cDireccion"].ReadOnly = bVal;
            dtgDireccion.Columns["cReferenciaDireccion"].ReadOnly = bVal;
        }

        private bool validarDir()
        {
            bool lVal = false;

            if (conBusUbiCli.cboAnexo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar la Ubicación del Cliente", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusUbiCli.cboAnexo.Focus();
                return lVal;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar la Dirección del Cliente", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return lVal;
            }
            if (cboTipoZona.Text == "")
            {
                MessageBox.Show("Especifique el Tipo de Zona", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoZona.Focus();
                return lVal;
            }
            if (cboTipoVia.Text == "")
            {
                MessageBox.Show("Especifique el Tipo de Via", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoVia.Focus();
                return lVal;
            }
            if (cboTipoVia.SelectedValue.ToString().Trim() == "1" && cboTipoZona.SelectedValue.ToString().Trim() == "1")
            {
                MessageBox.Show("Debe especificar al menos el Tipo y Nombre de la Zona o de la Vía", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoZona.Focus();
                return lVal;
            }

            if (txtZona.Enabled == true && txtZona.Text.Trim() == "")
            {
                MessageBox.Show("Indique el nombre de la Zona", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZona.Focus();
                return lVal;
            }
            if (txtVia.Enabled == true && txtVia.Text.Trim() == "")
            {
                MessageBox.Show("Indique el nombre de la Via", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVia.Focus();
                return lVal;
            }
            if (txtReferencia.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar la Referencia de la Dirección", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferencia.Focus();
                return lVal;
            }

            if (cboTipVivienda.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Vivienda", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipVivienda.Focus();
                return lVal;
            }

            if (txtOtrosVivienda.Enabled == true && txtOtrosVivienda.Text.Trim() == "")
            {
                MessageBox.Show("Si Seleccionó OTROS en Tipo de Vivienda, debe Especificarlo", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtrosVivienda.Focus();
                return lVal;
            }

            foreach (DataGridViewRow row in dtgDireccion.Rows)
            {
                if (row.Cells["cDireccion"].Value.ToString() == txtDireccion.Text.Trim() && Convert.ToInt32(row.Cells["idUbigeo"].Value) == Convert.ToInt32(conBusUbiCli.cboAnexo.SelectedValue))
                {
                    MessageBox.Show("Dirección ya existe", "Registro de Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return lVal;
                }

            }

            lVal = true;
            return lVal;
        }

        public void HabilitarControles_Gen(Boolean Val)
        {
            cboTipoZona.Enabled = Val;
            cboTipoVia.Enabled = Val;
            cboTipVivienda.Enabled = Val;
            txtZona.Enabled = Val;
            txtVia.Enabled = Val;
            textNro.Enabled = Val;
            textDpto.Enabled = Val;
            textMz.Enabled = Val;
            textKm.Enabled = Val;
            textInt.Enabled = Val;
            textLote.Enabled = Val;
            txtTelefCel1.Enabled = Val;
            txtTelefFijo1.Enabled = Val;
            txtOtrosVivienda.Enabled = Val;
            txtPropVivienda.Enabled = Val;
            txtReferencia.Enabled = Val;
            conBusUbiCli.Enabled = Val;
            btnAgregar.Enabled = Val;
        }

        public void LimpiarControles()
        {
            dtgDireccion.ClearSelection();
            cboTipoZona.SelectedValue = 0;
            cboTipoVia.SelectedValue = 0;
            txtZona.Text = "";
            txtVia.Text = "";
            textNro.Text = "";
            textDpto.Text = "";
            textMz.Text = "";
            textKm.Text = "";
            textInt.Text = "";
            textLote.Text = "";
            txtDireccion.Clear();
            txtReferencia.Text = "";
            txtPropVivienda.Text = "";
            txtOtrosVivienda.Text = "";
            cboTipVivienda.SelectedValue = 0;
            conBusUbiCli.cboPais.SelectedValue = 173;
            conBusUbiCli.cboDepartamento.SelectedValue = 0;
            conBusUbiCli.cboProvincia.SelectedValue = 0;
            conBusUbiCli.cboDistrito.SelectedValue = 0;

            txtTelefCel1.Clear();
            txtTelefFijo1.Clear();
        }

        private void Direccion(string letras, string Tipo)
        {

            String direccion;

            if (Tipo == "textZona")
                zona = letras;
            if (Tipo == "textVia")
                via = letras;
            if (Tipo == "textNro")
                nro = letras;
            if (Tipo == "textDpto")
                dpto = letras;
            if (Tipo == "textInt")
                inte = letras;
            if (Tipo == "textKm")
                km = letras;
            if (Tipo == "textMz")
                mz = letras;
            if (Tipo == "textLote")
                lote = letras;

            direccion = zona + via + nro + dpto + inte + km + mz + lote;
            txtDireccion.Text = direccion;
        }

        private string crearDireccionesXml()
        {
            DataSet dsDir = new DataSet("dsDireccion");
            dsDir.Tables.Add(tbDirCli);
            string xmlDirec = dsDir.GetXml();
            dsDir.Tables.Clear();
            return xmlDirec;
        }

        private bool validar()
        {
            bool lValido = true;
            foreach (DataGridViewRow row in dtgDireccion.Rows)
            {
                DataGridViewComboBoxCell cbTipoDireccion = (DataGridViewComboBoxCell)row.Cells["cmb"];

                if (String.IsNullOrEmpty(cbTipoDireccion.FormattedValue.ToString()))
                {
                    lValido = false;
                }
                else
                {
                    row.Cells["idTipoDireccion"].Value = cbTipoDireccion.Value.ToString();
                }
            }

            if (!lValido)
            {
                MessageBox.Show("Debe seleccionar el tipo de Dirección");
            }
            return lValido;
        }

        #endregion
    }
}

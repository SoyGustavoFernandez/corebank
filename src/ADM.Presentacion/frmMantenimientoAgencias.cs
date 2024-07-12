using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.BotonesBase;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using ADM.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoAgencias : frmBase
    {
        clsCNMantenimiento admAgencias = new clsCNMantenimiento();
        int PidAgencias = 0;
        DataTable dtAreas;
        DataTable dtEstablecimeinto;
        public frmMantenimientoAgencias()
        {
            InitializeComponent();
        }

        private void frmMantenimientoAgencias_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            CagarEsquemaTrabajoCaja();
            cargarTipoOficina();
            conUbigeo.cargar();
            BuscarAreas();
            BuscarEstablecimiento();
            ListaAgencias();
            habilitarObjetos(0);
            habilitarBotones(false);            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            limpiarDatos();
            habilitarObjetos(1);
            PidAgencias = -1;

        }
        private void CagarEsquemaTrabajoCaja()
        {
            cboTipoEsquema.DataSource = admAgencias.CNListaEsquemaCaja();
            cboTipoEsquema.DisplayMember = "cEsquemaCaja";
            cboTipoEsquema.ValueMember = "idEsquema";
            cboTipoEsquema.SelectedIndex = -1;

        }
        private void BuscarAreas()
        {
            dtAreas = admAgencias.ListarAreas(PidAgencias);

            if (dtgAreas.ColumnCount > 0)
            {
                dtgAreas.Columns.Remove("idAreaAgencia");
                dtgAreas.Columns.Remove("idArea");
                dtgAreas.Columns.Remove("cArea");
                dtgAreas.Columns.Remove("lVigente");
                dtgAreas.Columns.Remove("Estado");
            }
            dtgAreas.DataSource = dtAreas.DefaultView;

            dtgAreas.Columns["idAreaAgencia"].Visible = false;
            dtgAreas.Columns["idArea"].Visible = false;
            dtgAreas.Columns["cArea"].Width = 50;
            dtgAreas.Columns["cArea"].HeaderText = "Nombre del Área";
            dtgAreas.Columns["cArea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAreas.Columns["lVigente"].Width = 20;
            dtgAreas.Columns["lVigente"].HeaderText = "Pertenece";
            dtgAreas.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAreas.Columns["Estado"].Visible = false;
        }
        private void BuscarEstablecimiento()
        {
            dtEstablecimeinto = admAgencias.ListarEstablecimiento(PidAgencias);
            if (dtgEstablecimiento.ColumnCount > 0)
            {
                dtgEstablecimiento.Columns.Remove("idEstabAgencia");
                dtgEstablecimiento.Columns.Remove("idEstablecimiento");
                dtgEstablecimiento.Columns.Remove("cNombreEstab");
                dtgEstablecimiento.Columns.Remove("lVigente");
                dtgEstablecimiento.Columns.Remove("Estado");
            }
            dtgEstablecimiento.DataSource = dtEstablecimeinto.DefaultView;

            dtgEstablecimiento.Columns["idEstabAgencia"].Visible = false;
            dtgEstablecimiento.Columns["idEstablecimiento"].Visible = false;
            dtgEstablecimiento.Columns["cNombreEstab"].Width = 50;
            dtgEstablecimiento.Columns["cNombreEstab"].HeaderText = "Nombre del Estab.";
            dtgEstablecimiento.Columns["cNombreEstab"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstablecimiento.Columns["lVigente"].Width = 20;
            dtgEstablecimiento.Columns["lVigente"].HeaderText = "Pertenece";
            dtgEstablecimiento.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstablecimiento.Columns["Estado"].Visible = false;
        }

        private void dtgAgencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgAgencias_SelectionChanged(sender, e);
        }

        private void dtgAgencias_SelectionChanged(object sender, EventArgs e)
        {
            EstablecerDatosVariable();
            habilitarBotones(false);
            habilitarObjetos(0);
        }
        void habilitarObjetos(int idOpcion)
        {
            switch (idOpcion)
            {
                case 1://nuevo
                    txtNomAgencia.ReadOnly = false;
                    txtNomAgeCorto.ReadOnly = false;
                    conUbigeo.cboPais.Enabled = true;
                    conUbigeo.cboDepartamento.Enabled = true;
                    conUbigeo.cboProvincia.Enabled = true;
                    conUbigeo.cboDistrito.Enabled = true;
                    conUbigeo.cboAnexo.Enabled = true;
                    txtDireccionAge.ReadOnly = false;
                    txtReferencia.ReadOnly = false;
                    txtTelefono.ReadOnly = false;
                    txtCodigoSbs.ReadOnly = false;
                    txtNroResolucion.ReadOnly = false;
                    cboTipoOficina.Enabled = true;
                    dtpFechCrea.Enabled = true;
                    cboTipoEsquema.Enabled = true;
                    if (dtgAreas.Rows.Count > 0)
                    {
                        dtgAreas.ReadOnly = false;
                        dtgAreas.Columns["cArea"].ReadOnly = true;
                        dtgAreas.Columns["lVigente"].ReadOnly = false;
                    }
                    if (dtgEstablecimiento.Rows.Count > 0)
                    {
                        dtgEstablecimiento.ReadOnly = false;
                        dtgEstablecimiento.Columns["cNombreEstab"].ReadOnly = true;
                        dtgEstablecimiento.Columns["lVigente"].ReadOnly = false;
                    }

                    break;
                case 2://editar
                    txtNomAgencia.ReadOnly = false;
                    txtNomAgeCorto.ReadOnly = false;
                    conUbigeo.cboPais.Enabled = true;
                    conUbigeo.cboDepartamento.Enabled = true;
                    conUbigeo.cboProvincia.Enabled = true;
                    conUbigeo.cboDistrito.Enabled = true;
                    conUbigeo.cboAnexo.Enabled = true;
                    txtDireccionAge.ReadOnly = false;
                    txtReferencia.ReadOnly = false;
                    txtTelefono.ReadOnly = false;
                    txtCodigoSbs.ReadOnly = false;
                    txtNroResolucion.ReadOnly = false;
                    cboTipoOficina.Enabled = true;
                    dtpFechCrea.Enabled = false;
                    cboTipoEsquema.Enabled = true;
                    if (dtgAreas.Rows.Count > 0)
                    {
                        dtgAreas.ReadOnly = false;
                        dtgAreas.Columns["cArea"].ReadOnly = true;
                        dtgAreas.Columns["lVigente"].ReadOnly = false;
                    }
                    if (dtgEstablecimiento.Rows.Count > 0)
                    {
                        dtgEstablecimiento.ReadOnly = false;
                        dtgEstablecimiento.Columns["cNombreEstab"].ReadOnly = true;
                        dtgEstablecimiento.Columns["lVigente"].ReadOnly = false;
                    }
                    break;
                case 0://x defecto
                    txtNomAgencia.ReadOnly = true;
                    txtNomAgeCorto.ReadOnly = true;
                    conUbigeo.cboPais.Enabled = false;
                    conUbigeo.cboDepartamento.Enabled = false;
                    conUbigeo.cboProvincia.Enabled = false;
                    conUbigeo.cboDistrito.Enabled = false;
                    conUbigeo.cboAnexo.Enabled = false;
                    txtDireccionAge.ReadOnly = true;
                    txtReferencia.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtCodigoSbs.ReadOnly = true;
                    txtNroResolucion.ReadOnly = true;
                    cboTipoOficina.Enabled = false;
                    dtpFechCrea.Enabled = false;
                    cboTipoEsquema.Enabled = false;
                    if (dtgAreas.Rows.Count > 0)
                    {
                        dtgAreas.ReadOnly = true;
                        dtgAreas.Columns["cArea"].ReadOnly = true;
                        dtgAreas.Columns["lVigente"].ReadOnly = true;
                    }
                    if (dtgEstablecimiento.Rows.Count > 0)
                    {
                        dtgEstablecimiento.ReadOnly = true;
                        dtgEstablecimiento.Columns["cNombreEstab"].ReadOnly = true;
                        dtgEstablecimiento.Columns["lVigente"].ReadOnly = true;
                    }
                    break;
            }
        }
        void habilitarBotones(bool lactivo)
        {
            btnEditar.Enabled = !lactivo;
            btnNuevo.Enabled = !lactivo;
            btnGrabar.Enabled = lactivo;
            btnCancelar.Enabled = lactivo;
            btnEliminar.Enabled = !lactivo;
            btnGenerar.Enabled = !lactivo;
        }
        void cargarTipoOficina()
        {
            cboTipoOficina.DataSource = admAgencias.ListarTipoDeOficina();
            cboTipoOficina.ValueMember = "idTipoOficina";
            cboTipoOficina.DisplayMember = "cTipoOficina";
        }
        void EstablecerDatosVariable()
        {
            if (dtgAgencias.RowCount > 0)
            {
                PidAgencias = Convert.ToInt32(dtgAgencias.CurrentRow.Cells["idAgencia"].Value);
                txtNomAgencia.Text = dtgAgencias.CurrentRow.Cells["cNombreAge"].Value.ToString();
                txtNomAgeCorto.Text = dtgAgencias.CurrentRow.Cells["cNomCorto"].Value.ToString();
                txtDireccionAge.Text = dtgAgencias.CurrentRow.Cells["cDirección"].Value.ToString();
                txtReferencia.Text = dtgAgencias.CurrentRow.Cells["cRefDirec"].Value.ToString();
                txtTelefono.Text = dtgAgencias.CurrentRow.Cells["cFono"].Value.ToString();
                txtCodigoSbs.Text = dtgAgencias.CurrentRow.Cells["cCodSBS"].Value.ToString();
                txtNroResolucion.Text = dtgAgencias.CurrentRow.Cells["cNroResolucion"].Value.ToString();
                if (dtgAgencias.CurrentRow.Cells["idTipEsquemaCaja"].Value.ToString() != "")
                {
                    cboTipoEsquema.SelectedValue = Convert.ToInt32(dtgAgencias.CurrentRow.Cells["idTipEsquemaCaja"].Value);
                }
                else
                {
                    cboTipoEsquema.SelectedIndex = -1;
                }
                
                cboTipoOficina.SelectedValue = Convert.ToInt32(dtgAgencias.CurrentRow.Cells["idTipoOficina"].Value.ToString());

                clsCNRetDatosCliente RetdDirUbi = new clsCNRetDatosCliente();
                DataTable tbDatUbi = RetdDirUbi.RetUbiCli(Convert.ToInt32(dtgAgencias.CurrentRow.Cells["idUbigeo"].Value));
                conUbigeo.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                conUbigeo.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                conUbigeo.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                conUbigeo.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();

                if (btnEditar.Enabled == true)
                {
                    conUbigeo.cboPais.Enabled = false;
                    conUbigeo.cboDepartamento.Enabled = false;
                    conUbigeo.cboProvincia.Enabled = false;
                    conUbigeo.cboDistrito.Enabled = false;
                    conUbigeo.cboAnexo.Enabled = false;
                }

                if (String.IsNullOrEmpty(dtgAgencias.CurrentRow.Cells["dfechaCreacion"].Value.ToString()))
                {
                    dtpFechCrea.Value = clsVarGlobal.dFecSystem;
                }
                else
                {
                    dtpFechCrea.Value = Convert.ToDateTime(dtgAgencias.CurrentRow.Cells["dfechaCreacion"].Value.ToString());
                }
                BuscarAreas();
                BuscarEstablecimiento();
            }

        }
        void ListaAgencias()
        {
            dtgAgencias.DataSource = admAgencias.ListarAgencias();
            EstablecerDatosVariable();
        }
        void limpiarDatos()
        {
            txtNomAgencia.Clear();
            txtNomAgeCorto.Clear();
            txtDireccionAge.Clear();
            txtReferencia.Clear();
            txtTelefono.Clear();
            txtCodigoSbs.Clear();
            txtNroResolucion.Clear();
            cboTipoOficina.SelectedValue = -1;
            conUbigeo.cboDepartamento.SelectedValue = -1;
            conUbigeo.cboProvincia.SelectedValue = -1;
            conUbigeo.cboDistrito.SelectedValue = -1;
            cboTipoEsquema.SelectedValue = -1;
            dtAreas.Columns["idAreaAgencia"].ReadOnly = false;
            dtEstablecimeinto.Columns["idEstabAgencia"].ReadOnly = false;

            for (int i = 0; i < dtgAreas.Rows.Count; i++)
            {
                dtgAreas.Rows[i].Cells["idAreaAgencia"].Value = -1;
                dtgAreas.Rows[i].Cells["lVigente"].Value = false;
            }
            for (int i = 0; i < dtgEstablecimiento.Rows.Count; i++)
            {
                dtgEstablecimiento.Rows[i].Cells["idEstabAgencia"].Value = -1;
                dtgEstablecimiento.Rows[i].Cells["lVigente"].Value = false;
            }
            dtgAreas.ReadOnly = true;
            dtgEstablecimiento.ReadOnly = true;

        }
        private bool ValidarRegistro()
        {
            if (txtNomAgencia.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Nombre de la Agencia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomAgencia.Focus();
                return false;
            }
            if (txtNomAgeCorto.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe Ingresar Nombre Corto de la Agencia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomAgeCorto.Focus();
                return false;
            }
            if (conUbigeo.cboPais.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de la Agencia: Pais", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conUbigeo.cboPais.Select();
                conUbigeo.cboPais.Focus();
                return false;
            }
            if (conUbigeo.cboDepartamento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de la Agencia: Departamento", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conUbigeo.cboDepartamento.Select();
                conUbigeo.cboDepartamento.Focus();
                return false;
            }
            if (conUbigeo.cboProvincia.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de la Agencia: Provincia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conUbigeo.cboProvincia.Select();
                conUbigeo.cboProvincia.Focus();
                return false;
            }
            if (conUbigeo.cboDistrito.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Ubigeo de la Agencia: Distrito", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conUbigeo.cboDistrito.Select();
                conUbigeo.cboDistrito.Focus();
                return false;
            }
            if (txtCodigoSbs.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe Ingresar Codigo de SBS", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoSbs.Focus();
                return false;
            }
            if (txtTelefono.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Teléfono de la Agencia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if (Convert.ToInt32(cboTipoOficina.SelectedIndex) == -1)
            {
                MessageBox.Show("Debe Seleccionar Tipo de Oficina", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoOficina.Focus();
                return false;
            }
            if (cboTipoEsquema.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe seleccionar tipo de esquema de trabajo de caja", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEsquema.Focus();
                return false;
            }

            if (txtNroResolucion.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe Ingresar el Nro de Resolución de la Apertura", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroResolucion.Focus();
                return false;
            }
            if (txtDireccionAge.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Dirección de la Agencia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccionAge.Focus();
                return false;
            }
            if (txtReferencia.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar una Referencia de la Agencia", "Registro de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferencia.Focus();
                return false;
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro())
            {
                string cNombreAge = txtNomAgencia.Text;
                string cNomCorto = txtNomAgeCorto.Text;
                int idUbigeo = Convert.ToInt32(conUbigeo.cboDistrito.SelectedValue);
                string cDirección = txtDireccionAge.Text;
                string cRefDirec = txtReferencia.Text;
                string cFono = txtTelefono.Text;
                bool lEstado = true;
                string cCodSBS = txtCodigoSbs.Text;
                DateTime dFechaAprob = Convert.ToDateTime(dtpFechCrea.Value);
                int idTipoOficina = Convert.ToInt32(cboTipoOficina.SelectedValue);
                string cResolucion = txtNroResolucion.Text;
                int idTipEsquemaCaja = Convert.ToInt32(cboTipoEsquema.SelectedValue);
                //XML de las Áreas-----------------------------------------------
                DataSet ds = new DataSet("dsActAreas");
                ds.Tables.Add(dtAreas);
                string XMLActAreas = ds.GetXml();
                XMLActAreas = clsCNFormatoXML.EncodingXML(XMLActAreas);
                ds.Tables.Clear();
                //---------------------------------------------------------------

                //XML de las Establecimeinto-----------------------------------------------
                DataSet ds1 = new DataSet("dsActEstablecimiento");
                ds1.Tables.Add(dtEstablecimeinto);
                string XMLActEstablecimientos = ds1.GetXml();
                XMLActEstablecimientos = clsCNFormatoXML.EncodingXML(XMLActEstablecimientos);
                ds1.Tables.Clear();
                //---------------------------------------------------------------

                int idAgenciaRetorno;
                idAgenciaRetorno = admAgencias.GrabarManAgencias(PidAgencias, cNombreAge, cNomCorto, idUbigeo,
                                              cDirección, cRefDirec, cFono, lEstado,
                                              cCodSBS, idTipoOficina, dFechaAprob, cResolucion,
                                              XMLActAreas, XMLActEstablecimientos, idTipEsquemaCaja);

                MessageBox.Show("Se Registró Correctamente la Agencia", "Registro de Agencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarBotones(false);
                habilitarObjetos(0);
                ListaAgencias();

                int n = 0;
                foreach (DataGridViewRow fila in dtgAgencias.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idAgencia"].Value) == idAgenciaRetorno)
                    {
                        dtgAgencias.CurrentCell = dtgAgencias.Rows[n - 1].Cells[1];
                        EstablecerDatosVariable();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de Eliminar la Agencia?", "Eliminación de Agencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                string cNombreAge = txtNomAgencia.Text;
                string cNomCorto = txtNomAgeCorto.Text;
                int idUbigeo = Convert.ToInt32(conUbigeo.cboDistrito.SelectedValue);
                string cDirección = txtDireccionAge.Text;
                string cRefDirec = txtReferencia.Text;
                string cFono = txtTelefono.Text;
                bool lEstado = false;
                string cCodSBS = txtCodigoSbs.Text;
                DateTime dFechaAprob = Convert.ToDateTime(dtpFechCrea.Value);
                int idTipoOficina = Convert.ToInt32(cboTipoOficina.SelectedValue);
                string cResolucion = txtNroResolucion.Text;
                int idTipEsquemaCaja = Convert.ToInt32(cboTipoEsquema.SelectedValue);
                //XML de las Áreas-----------------------------------------------
                DataSet ds = new DataSet("dsActAreas");
                ds.Tables.Add(dtAreas);
                string XMLActAreas = ds.GetXml();
                XMLActAreas = clsCNFormatoXML.EncodingXML(XMLActAreas);
                ds.Tables.Clear();
                //---------------------------------------------------------------

                //XML de las Establecimeinto-----------------------------------------------
                DataSet ds1 = new DataSet("dsActEstablecimiento");
                ds1.Tables.Add(dtEstablecimeinto);
                string XMLActEstablecimientos = ds1.GetXml();
                XMLActEstablecimientos = clsCNFormatoXML.EncodingXML(XMLActEstablecimientos);
                ds1.Tables.Clear();
                //---------------------------------------------------------------

                admAgencias.GrabarManAgencias(PidAgencias, cNombreAge, cNomCorto, idUbigeo,
                                              cDirección, cRefDirec, cFono, lEstado,
                                              cCodSBS, idTipoOficina, dFechaAprob, cResolucion,
                                              XMLActAreas, XMLActEstablecimientos, idTipEsquemaCaja);
                MessageBox.Show("Se Eliminó Correctamente la Agencia", "Eliminación de Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaAgencias();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            habilitarObjetos(2);
            if (ValidarAgeSinInicioOpe())
            {
                cboTipoEsquema.Enabled = false;
            }
        }
        private bool ValidarAgeSinInicioOpe()
        {
            DataTable dtRes= admAgencias.CNAgeSinInicioOpe(PidAgencias, clsVarGlobal.dFecSystem);
            if (dtRes.Rows.Count<=0)//no inició operaciones
            {
                return false;
            }
            return true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            habilitarObjetos(0);
            EstablecerDatosVariable();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de Genarar Cuentas Contables con código SBS Nro " + txtCodigoSbs.Text + "?", "Generación de Cuentas Contables", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dtGeneraCtas = admAgencias.CNGeneraCtasContablesAgencia(PidAgencias);
                if (dtGeneraCtas.Rows[0]["idRpta"].ToString() == "0")
                    MessageBox.Show(dtGeneraCtas.Rows[0]["cMensage"].ToString(), "Mantenimiento de Agencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(dtGeneraCtas.Rows[0]["cMensage"].ToString(), "Mantenimiento de Agencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 && e.KeyChar != 8 && e.KeyChar != 45) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

    }
}

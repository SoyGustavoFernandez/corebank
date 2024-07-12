using ADM.CapaNegocio;
using CLI.CapaNegocio;
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
using GEN.CapaNegocio;
using CAJ.CapaNegocio;


namespace ADM.Presentacion
{
    public partial class frmMovimientoOficina : frmBase
    {
        clsCNMantenimiento admAgencias = new clsCNMantenimiento();
        int idAgencia, idTipoMovimiento, TipoOficina, Personal;
        DataTable dtListaMov;
        DataTable dtEntidad;
        int i = 0;
        int nFilas1 = 0;
        int nFilas2 = 0;
        public frmMovimientoOficina()
        {
            InitializeComponent();
        }

        private void frmMovimientoOficina_Load(object sender, EventArgs e)
        {
            cargarTipoOficina();
            conBusUbig1.cargar();
            cboAgeSup.AgenciasYNinguno();
            cboAgencias2.SelectedValue = -1;
            cboTipoOficina.SelectedValue = 0;
            cboTipoEntidad1.SelectedValue = 0;

            cboTipoOficina.Enabled = true;
            ListarMovimientos();
            FormatoListaMov();

            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            grbRegistrarMovimiento.Enabled = false;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            grbMovimientos.Enabled = true;

        }

        public void ListarMovimientos()
        {
            dtListaMov = admAgencias.CNListaMovimiento();
            dtListaMov.DefaultView.RowFilter = ("lVigente <> 0");
            dtgMovimientos.DataSource = dtListaMov.DefaultView;

            nFilas1 = dtgMovimientos.RowCount;
        }
        public void FormatoListaMov()
        {

            this.dtgMovimientos.Columns["idAgencia"].Visible = false;
            this.dtgMovimientos.Columns["cNombreAge"].Visible = true;
            this.dtgMovimientos.Columns["cCodSBS"].Visible = false;
            this.dtgMovimientos.Columns["nNroResolucion"].Visible = false; //true
            this.dtgMovimientos.Columns["idTipoOficina"].Visible = false;
            this.dtgMovimientos.Columns["cTipoOficina"].Visible = true;
            this.dtgMovimientos.Columns["idTipoMovimiento"].Visible = false;
            this.dtgMovimientos.Columns["cTipoMovimiento"].Visible = true;
            this.dtgMovimientos.Columns["cDireccion"].Visible = false; //true
            this.dtgMovimientos.Columns["cDireccionAnt"].Visible = true;
            this.dtgMovimientos.Columns["dFechaRegistro"].Visible = true;
            this.dtgMovimientos.Columns["nNroPersonal"].Visible = true;
            this.dtgMovimientos.Columns["dFechaRes"].Visible = false;
            this.dtgMovimientos.Columns["dFechaNot"].Visible = false;
            this.dtgMovimientos.Columns["idTipoOficina"].Visible = false;
            this.dtgMovimientos.Columns["idTipoMovimiento"].Visible = false;
            this.dtgMovimientos.Columns["cTipoMovimiento"].Visible = true;
            this.dtgMovimientos.Columns["idTipoEntidad"].Visible = false;
            this.dtgMovimientos.Columns["cCodEmpCompartida"].Visible = false;
            this.dtgMovimientos.Columns["idUbigeo"].Visible = false;
            this.dtgMovimientos.Columns["cDireccion"].Visible = false;
            this.dtgMovimientos.Columns["idUbigeoAnt"].Visible = false;
            this.dtgMovimientos.Columns["cDireccionAnt"].Visible = true;
            this.dtgMovimientos.Columns["cCorreoElectronico"].Visible = false;
            this.dtgMovimientos.Columns["dFechaRegistro"].Visible = true;
            this.dtgMovimientos.Columns["idUsuarioRegistro"].Visible = false;
            this.dtgMovimientos.Columns["nNroPersonal"].Visible = false;
            this.dtgMovimientos.Columns["nNroCajeros"].Visible = false;
            this.dtgMovimientos.Columns["nNroCajCorresponsal"].Visible = false;
            this.dtgMovimientos.Columns["idOfiDep"].Visible = false;
            this.dtgMovimientos.Columns["lConta"].Visible = false;
            this.dtgMovimientos.Columns["cTelefonoAnt"].Visible = false;
            this.dtgMovimientos.Columns["cTelefono"].Visible = false;
            this.dtgMovimientos.Columns["lVigente"].Visible = false;

            this.dtgMovimientos.Columns["cNombreAge"].HeaderText = "AGENCIA";
            this.dtgMovimientos.Columns["cTipoOficina"].HeaderText = "OFICINA";
            this.dtgMovimientos.Columns["cTipoMovimiento"].HeaderText = "MOVIMIENTO";
            this.dtgMovimientos.Columns["cDireccionAnt"].HeaderText = "DIRECCION ANT";
            this.dtgMovimientos.Columns["dFechaRegistro"].HeaderText = "FECHA REG.";
            
            this.dtgMovimientos.Columns["cNombreAge"].Width = 150;
            this.dtgMovimientos.Columns["cTipoOficina"].Width = 140; ;
            this.dtgMovimientos.Columns["cTipoMovimiento"].Width = 110; ;
            this.dtgMovimientos.Columns["cDireccionAnt"].Width = 250; ;
            this.dtgMovimientos.Columns["dFechaRegistro"].Width = 100;

        }
        void cargarTipoOficina()
        {
            cboTipoOficina.DataSource = admAgencias.ListarTipoDeOficina();
            cboTipoOficina.ValueMember = "idTipoOficina";
            cboTipoOficina.DisplayMember = "cTipoOficina";
        }

        private void cboTipoEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoEntidad1.SelectedIndex>-1)
            {
                cboEntidad1.Enabled = true;
                cboEntidad1.CargarEntidades(Convert.ToInt32(cboTipoEntidad1.SelectedValue));
            }
        }

        private void cboAgencias2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias2.SelectedIndex>-1)
            {
                CargarDatosOficina(Convert.ToInt32(cboAgencias2.SelectedValue));
            }
        }

        private void CargarDatosOficina(int idAgencia)
        {
            DataTable dtAgencia = admAgencias.ListarDatosAgenciaMovimiento(idAgencia);

            cboTipoMovOficina1.CargarTipoMovimiento(idAgencia);
            clsCNRetDatosCliente RetdDirUbi = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetdDirUbi.RetUbiCli(Convert.ToInt32(dtAgencia.Rows[0]["idUbigeo"]));
           if (tbDatUbi.Rows.Count == 5)
            {
                conBusUbig1.cboPais.SelectedValue = tbDatUbi.Rows[4]["idUbigeo"].ToString();
                conBusUbig1.cboDepartamento.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                conBusUbig1.cboProvincia.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                conBusUbig1.cboDistrito.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                conBusUbig1.cboAnexo.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
            }
           else if (tbDatUbi.Rows.Count == 4)
           {
               conBusUbig1.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
               conBusUbig1.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
               conBusUbig1.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
               conBusUbig1.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
           }
            txtResSBS.Text = Convert.ToString(dtAgencia.Rows[0]["cNroResolucion"]);
            txtDireccion.Text = Convert.ToString(dtAgencia.Rows[0]["cDirección"]);
            dtpFecRes.Value = Convert.ToDateTime(dtAgencia.Rows[0]["dfechaCreacion"]);
            cboTipoOficina.SelectedValue = Convert.ToInt32(dtAgencia.Rows[0]["idTipoOficina"]);

            if (Convert.ToInt32(dtAgencia.Rows[0]["idTipoOficina"]) == 4 || Convert.ToInt32(dtAgencia.Rows[0]["idTipoOficina"]) == 6)
            {
                cboTipoEntidad1.Enabled = true;
                cboEntidad1.Enabled = true;
            }
            else
            {
                cboTipoEntidad1.Enabled = false;
                cboEntidad1.Enabled = false;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataSet dsMovimientos = new DataSet("dsMovimiento");
            dsMovimientos.Tables.Add(dtListaMov);
            string xmlMovimientos = dsMovimientos.GetXml();
            xmlMovimientos = clsCNFormatoXML.EncodingXML(xmlMovimientos);
            dsMovimientos.Tables.Clear();

            DataTable dtResultado = admAgencias.InsUpdMovimientoOficina(xmlMovimientos);

            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                MessageBox.Show("Datos guardados correctamente", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en la grabación", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpiar();
        }

        private Boolean Validar()
        {

            if (dtpFecNoti.Value <= dtpFecRes.Value)
            {
                MessageBox.Show("Fecha de Notificación no puede ser menor o igual", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(cboTipoMovOficina1.SelectedValue) != 4)
            {
                if (string.IsNullOrEmpty(txtNroPersonal.Text) || Convert.ToInt32(txtNroPersonal.Text) == 0)
                {
                    MessageBox.Show("Número de personal no puede ser CERO", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (Convert.ToInt32(conBusUbig1.cboAnexo.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar Barrio/Comunidad", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(cboTipoMovOficina1.SelectedValue) == 4)
            {
                txtNroPersonal.Text = "0";
            }

            if (Convert.ToInt32(cboAgencias2.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar una Oficina", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(cboTipoOficina.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de oficina", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtNroCajeros.Text))
            {
                txtNroCajeros.Text = "0";
            }
            if (string.IsNullOrEmpty(txttelefono.Text))
            {
                txttelefono.Text = "";
            }
            if (string.IsNullOrEmpty(txtNroCajCor.Text))
            {
                txtNroCajCor.Text = "0";
            }
            if (txtMail.Enabled && string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("Ingrese correo electronico", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboTipoEntidad1.Enabled && Convert.ToInt32(cboEntidad1.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar una Entidad", "Movimiento Oficina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboEntidad1.Enabled)
            {

                dtEntidad = admAgencias.CNListaEntidades(Convert.ToInt32(cboEntidad1.SelectedValue));
                string cCodigoSBS = dtEntidad.Rows[0][3].ToString();
                if (string.IsNullOrWhiteSpace(cCodigoSBS) || string.IsNullOrEmpty(cCodigoSBS))
                {
                    MessageBox.Show("La entidad no tiene un codigo de SBS valido", "Movimiento de Oficinas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
               
            }
            return true;
        }

        private void cboTipoMovOficina1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoMovOficina1.SelectedValue) == 2)
            {
                txtDireccion.Enabled = true;
                txttelefono.Enabled = true;
                txtMail.Enabled = true;
            }
            else if(Convert.ToInt32(cboTipoMovOficina1.SelectedValue) == 3)
            {
                txtDireccion.Enabled = true;
                txttelefono.Enabled = true;
                txtMail.Enabled = true;
            }
            else if (Convert.ToInt32(cboTipoMovOficina1.SelectedValue) == 1)
            {
                txtMail.Enabled = true;
                txtDireccion.Enabled = false;
                txttelefono.Enabled = true;
            }
            else
            {
                txtDireccion.Enabled = false;
                txttelefono.Enabled = false;
                txtMail.Enabled = true;
            }
        }
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            cboAgencias2.Enabled = false;
            cboTipoOficina.Enabled = false;
            cboTipoMovOficina1.Enabled = false;
            txtResSBS.Text = "";
            dtpFecRes.Text = "";
            dtpFecNoti.Text = "";
            txtDireccion.Text = "";
            conBusUbig1.cboPais.Enabled = false;
            conBusUbig1.cboDepartamento.Enabled = false;
            conBusUbig1.cboProvincia.Enabled = false;
            conBusUbig1.cboAnexo.Enabled = false;

            txtDireccion.Text = "";
            txtNroPersonal.Text = "";
            txtNroCajeros.Text = "";
            txtNroCajCor.Text = "";
            cboAgeSup.Enabled = false;

            cboTipoEntidad1.Enabled = false;
            cboEntidad1.Enabled = false;
            chcCNT.Checked = false;

        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea quitar el movimiento de oficina seleccionado?", "Movimiento de Oficinas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.dtgMovimientos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar el movimiento de agencia que desea eliminar", "Movimiento de Oficinas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DataRowView FilaAct = dtgMovimientos.SelectedRows[0].DataBoundItem as DataRowView;

                    for (int i = 0; i < dtListaMov.Rows.Count; i++ )
                    {
                        idAgencia = Convert.ToInt32(FilaAct.Row["idAgencia"]);
                        idTipoMovimiento = Convert.ToInt32(FilaAct.Row["idTipoMovimiento"]);
                        TipoOficina = Convert.ToInt32(FilaAct.Row["idTipoOficina"]);
                        Personal = Convert.ToInt32(FilaAct.Row["nNroPersonal"]);

                        if (Convert.ToInt32(dtListaMov.Rows[i]["idAgencia"].ToString()) == idAgencia && idTipoMovimiento == Convert.ToInt32(dtListaMov.Rows[i]["idTipoMovimiento"].ToString())  && TipoOficina == Convert.ToInt32(dtListaMov.Rows[i]["idTipoOficina"].ToString()) && Personal==Convert.ToInt32(dtListaMov.Rows[i]["nNroPersonal"].ToString()) )
                        {
                            dtListaMov.Rows[i]["lVigente"] = 0;
                        }
                    }   
                }
            }
            cboTipoEntidad1.Enabled = false;
            cboEntidad1.Enabled = false;

            btnGrabar1.Enabled = true;

            nFilas2 = nFilas1 - 1;
        }

        private void dtgMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtListaMov.Rows.Count > 0)
            {
                DataRowView FilaActual = dtgMovimientos.SelectedRows[0].DataBoundItem as DataRowView;

                if (dtgMovimientos.SelectedRows.Count > 0)
                {

                    idAgencia = Convert.ToInt32(FilaActual["idAgencia"]);
                    idTipoMovimiento = Convert.ToInt32(FilaActual["idTipoMovimiento"]);

                    cboAgencias2.SelectedValue = Convert.ToInt32(FilaActual["idAgencia"]);
                    cboTipoOficina.SelectedValue = Convert.ToInt32(FilaActual["idTipoOficina"]);
                    cboTipoMovOficina1.SelectedValue = Convert.ToInt32(FilaActual["idTipoMovimiento"]);
                    cboEntidad1.SelectedValue = Convert.ToInt32(FilaActual["cCodEmpCompartida"]);
                    int entidad = Convert.ToInt32(FilaActual["cCodEmpCompartida"]);
                    txtResSBS.Text = Convert.ToString(FilaActual["cCodSBS"]);
                    dtpFecRes.Value = Convert.ToDateTime(FilaActual["dFechaRes"]);
                    dtpFecNoti.Value = Convert.ToDateTime(FilaActual["dFechaNot"]);
                    txtDireccion.Text = Convert.ToString(FilaActual["cDireccion"]);

                    txttelefono.Text = Convert.ToString(FilaActual["cTelefono"]);
                    txtMail.Text = Convert.ToString(FilaActual["cCorreoElectronico"]);

                    txtNroPersonal.Text = Convert.ToString(FilaActual["nNroPersonal"]);
                    txtNroCajeros.Text = Convert.ToString(FilaActual["nNroCajeros"]);
                    txtNroCajCor.Text = Convert.ToString(FilaActual["nNroCajCorresponsal"]);
                    chcCNT.Checked = Convert.ToBoolean(FilaActual["lConta"]);

                    conBusUbig1.cboPais.Enabled = false;
                    conBusUbig1.cboDepartamento.Enabled = false;
                    conBusUbig1.cboProvincia.Enabled = false;
                    conBusUbig1.cboAnexo.Enabled = false;

                    cboAgeSup.SelectedValue = Convert.ToInt32(FilaActual["idOfiDep"]);
                    i = 0;

                    cboTipoEntidad1.Enabled = false;
                    cboEntidad1.Enabled = false;
                }
            }
        }

        private void dtgMovimientos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtListaMov.Rows.Count > 0)
            {
                if (dtgMovimientos.SelectedRows.Count > 0)
                {
                    var Listas = dtgMovimientos.SelectedRows[0];
                     if(Listas.Cells["idAgencia"].Value != null)
                     {
                    DataRowView FilaActual = dtgMovimientos.SelectedRows[0].DataBoundItem as DataRowView;


                    idAgencia = Convert.ToInt32(FilaActual.Row["idAgencia"]);
                    idTipoMovimiento = Convert.ToInt32(FilaActual.Row["idTipoMovimiento"]);

                    cboAgencias2.SelectedValue = Convert.ToInt32(FilaActual.Row["idAgencia"]);
                    cboTipoOficina.SelectedValue = Convert.ToInt32(FilaActual.Row["idTipoOficina"]);
                    cboTipoMovOficina1.SelectedValue = Convert.ToInt32(FilaActual.Row["idTipoMovimiento"]);
                    cboTipoEntidad1.SelectedValue = Convert.ToInt32(FilaActual.Row["idTipoEntidad"]);
                    cboEntidad1.CargarEntidades(Convert.ToInt32(cboTipoEntidad1.SelectedValue));
                    cboEntidad1.SelectedValue = Convert.ToInt32(FilaActual.Row["cCodEmpCompartida"]);


                    txtResSBS.Text = Convert.ToString(FilaActual.Row["cCodSBS"]);
                    dtpFecRes.Value = Convert.ToDateTime(FilaActual.Row["dFechaRes"]);
                    dtpFecNoti.Value = Convert.ToDateTime(FilaActual.Row["dFechaNot"]);
                    txtDireccion.Text = Convert.ToString(FilaActual.Row["cDireccion"]);

                    txtNroPersonal.Text = Convert.ToString(FilaActual.Row["nNroPersonal"]);
                    txtNroCajeros.Text = Convert.ToString(FilaActual.Row["nNroCajeros"]);
                    txtNroCajCor.Text = Convert.ToString(FilaActual.Row["nNroCajCorresponsal"]);
                    chcCNT.Checked = Convert.ToBoolean(FilaActual.Row["lConta"]);

                    txttelefono.Text = Convert.ToString(FilaActual["cTelefono"]);
                    txtMail.Text = Convert.ToString(FilaActual["cCorreoElectronico"]);

                    conBusUbig1.cboPais.Enabled = false;
                    conBusUbig1.cboDepartamento.Enabled = false;
                    conBusUbig1.cboProvincia.Enabled = false;
                    conBusUbig1.cboAnexo.Enabled = false;

                    cboAgeSup.SelectedValue = Convert.ToInt32(FilaActual.Row["idOfiDep"]);
                     }
                }
            }

        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DataRow NuevoMov = dtListaMov.NewRow();

                NuevoMov["idAgencia"] = Convert.ToInt32(cboAgencias2.SelectedValue);
                NuevoMov["nNroResolucion"] = txtResSBS.Text;
                NuevoMov["dFechaRes"] = dtpFecRes.Value;
                NuevoMov["idTipoOficina"] = Convert.ToInt32(cboTipoOficina.SelectedValue);
                NuevoMov["idTipoMovimiento"] = Convert.ToInt32(cboTipoMovOficina1.SelectedValue);
                NuevoMov["idTipoEntidad"] = Convert.ToInt32(cboTipoEntidad1.SelectedValue);//cboTipoEntidad1.SelectedValue == null ? (int?)null : Convert.ToInt32(cboTipoEntidad1.SelectedValue);
                NuevoMov["cCodEmpCompartida"] = Convert.ToInt32(cboEntidad1.SelectedValue);//cboEntidad1.SelectedValue == null ? (int?)null : Convert.ToInt32(cboEntidad1.SelectedValue);
                NuevoMov["idUbigeo"] = Convert.ToInt32(conBusUbig1.cboAnexo.SelectedValue);
                NuevoMov["cDireccion"] = txtDireccion.Text;
                NuevoMov["cCorreoElectronico"] = "";
                NuevoMov["dFechaRegistro"] = clsVarGlobal.dFecSystem;
                NuevoMov["idUsuarioRegistro"] = clsVarGlobal.User.idUsuario;
                NuevoMov["dFechaNot"] = dtpFecNoti.Value;
                NuevoMov["nNroPersonal"] = Convert.ToInt32(txtNroPersonal.Text);
                NuevoMov["nNroCajeros"] = Convert.ToInt32(txtNroCajeros.Text);
                NuevoMov["nNroCajCorresponsal"] = Convert.ToInt32(txtNroCajCor.Text);
                NuevoMov["idOfiDep"] = Convert.ToInt32(cboAgeSup.SelectedValue);
                NuevoMov["lConta"] = chcCNT.Checked;
                NuevoMov["cTelefono"] = txttelefono.Text;
                NuevoMov["cCorreoElectronico"] = txtMail.Text;

                NuevoMov["lVigente"] = 1;

                NuevoMov["cNombreAge"] = cboAgencias2.Text;
                NuevoMov["cTipoMovimiento"] = cboTipoMovOficina1.Text;
                NuevoMov["cTipoOficina"] = cboTipoOficina.Text;
                NuevoMov["cDireccionAnt"] = txtDireccion.Text;

                dtListaMov.Rows.Add(NuevoMov);
                txtResSBS.Text = "";
                dtpFecRes.Text = "";
                dtpFecNoti.Text = "";
                txtDireccion.Text = "";

                txtDireccion.Text = "";
                txtNroPersonal.Text = "";
                txtNroCajeros.Text = "";
                txtNroCajCor.Text = "";
                txttelefono.Text = "";
                txtMail.Text = "";

                btnNuevo1.Enabled = true;
                btnMiniAgregar1.Enabled = false;
                btnMiniQuitar1.Enabled = true;
                chcCNT.Checked = false;
                dtgMovimientos.Enabled = true;
                cboTipoEntidad1.Enabled = false;
                cboEntidad1.Enabled = false;
                btnGrabar1.Enabled = true;

                txtDireccion.Enabled = false;
                txtNroPersonal.Enabled = false;
                txtNroCajeros.Enabled = false;
                txtNroCajCor.Enabled = false;
                txttelefono.Enabled = false;
                txtMail.Enabled = false;

            }
            else
            {
                return;
            }
            nFilas2 = nFilas1 + 1;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            dtListaMov = admAgencias.CNListaMovimiento();
            dtListaMov.DefaultView.RowFilter = ("lVigente <> 0");
            dtgMovimientos.DataSource = dtListaMov.DefaultView;
            
        }
        public void limpiar()
        {
            cboAgencias2.SelectedValue = -1;
            btnCancelar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            grbRegistrarMovimiento.Enabled = false;
            grbMovimientos.Enabled = true;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            dtgMovimientos.Enabled = true;
            
            txtResSBS.Text = "";
            dtpFecRes.Text = "";
            dtpFecNoti.Text = "";
            txtDireccion.Text = "";
          

            txtDireccion.Text = "";
            txtNroPersonal.Text = "";
            txtNroCajeros.Text = "";
            txtNroCajCor.Text = "";
            txtMail.Text = "";
            txttelefono.Text = "";
            chcCNT.Checked = false;
            conBusUbig1.cboPais.SelectedValue = 0;
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnNuevo1.Enabled = false;
           
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = true;

            grbRegistrarMovimiento.Enabled = false;
            grbMovimientos.Enabled = true;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            cboAgencias2.SelectedValue = -1;
            cboTipoOficina.SelectedValue = -1;
            cboTipoMovOficina1.SelectedValue = -1;
            cboAgeSup.SelectedValue = -1;
            cboTipoEntidad1.SelectedValue = 0;
            cboEntidad1.SelectedValue = 0;
            cboTipoOficina.Enabled = true;


            grbRegistrarMovimiento.Enabled = true;
            grbMovimientos.Enabled = true;
            dtgMovimientos.Enabled = false;
            btnMiniQuitar1.Enabled = false;

            btnMiniAgregar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = false;

            txtResSBS.Text = "";
            dtpFecRes.Text = "";
            dtpFecNoti.Text = "";
            txtDireccion.Text = "";
            txtNroPersonal.Text = "";
            txtNroCajeros.Text = "";
            txtNroCajCor.Text = "";
            txtMail.Text = "";
            txttelefono.Text = "";
            chcCNT.Checked = false;
            txtDireccion.Enabled = false;
            txtMail.Enabled = false;
            txttelefono.Enabled = false;
            txtNroPersonal.Enabled = true;
            txtNroCajeros.Enabled = true;
            txtNroCajCor.Enabled = true;

            conBusUbig1.cboPais.SelectedValue = 0;

        }

        private void cboTipoOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOficina.SelectedIndex > 0)
            {
                if (Convert.ToInt32(cboTipoOficina.SelectedValue) == 4 || Convert.ToInt32(cboTipoOficina.SelectedValue) == 6)
                {
                    cboTipoEntidad1.Enabled = true;
                }
                else
                    cboTipoEntidad1.Enabled = false; 
            }
            
        }
    }
}

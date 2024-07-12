using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmAdelantoSueldo : frmBase
    {
        clsCNAdelantoSueldo objAdelantoSueldo = new clsCNAdelantoSueldo();
        clsCNPeriodoPlanilla objPeriodoPlanilla = new clsCNPeriodoPlanilla();
        clsCNModalidadPlanilla objModalidadPlanilla = new clsCNModalidadPlanilla();

        string cTipTrxAdelanto = "";
        DataTable dtAdelantoSueldo = new DataTable();
        DataTable dtDescuentoAdelantoSueldo = new DataTable();

        public frmAdelantoSueldo()
        {
            InitializeComponent();
        }

        private void HabilitarControles(bool lHabilitar)
        {
            conBusPersonal.HabilitarControles(!lHabilitar);
            
            dtgAdelantoUsuario.Enabled = !lHabilitar;

            cboTipoPlanilla.Enabled = (cTipTrxAdelanto == "A" ? false : lHabilitar);
            cboPeriodoPlanilla.Enabled = lHabilitar;
            txtMontoAdelanto.Enabled = lHabilitar;
            txtMotivoAdelanto.Enabled = lHabilitar;
            dtgDescuentoAdelantoSueldo.Enabled = lHabilitar;
            btnMiniAgregar.Enabled = lHabilitar;
            btnMiniQuitar.Enabled = lHabilitar;

            btnNuevo.Enabled = !lHabilitar;
            btnEditar.Enabled = (dtAdelantoSueldo.Rows.Count == 0 ? false : !lHabilitar);
            btnEliminar.Enabled = (dtAdelantoSueldo.Rows.Count == 0 ? false : !lHabilitar);
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;
        }

        private void LimpiarControlesDetalle()
        {
            txtMontoAdelanto.Text = "0.00";
            txtMotivoAdelanto.Text = "";
            dtDescuentoAdelantoSueldo.Rows.Clear();
        }

        private void CargarListaAdelantoSueldoPorUsuario(int idUsuario)
        {
            dtAdelantoSueldo = objAdelantoSueldo.CNListarAdelantoSueldoPorUsuario(idUsuario);
            dtgAdelantoUsuario.DataSource = dtAdelantoSueldo;

            HabilitarControles(false);
        }

        private void CargarListaDescuentosAdelantoSueldo(int idAdelantoSueldo)
        {
            dtDescuentoAdelantoSueldo = objAdelantoSueldo.CNListarDescuentosAdelantoSueldo(idAdelantoSueldo);
            dtgDescuentoAdelantoSueldo.DataSource = dtDescuentoAdelantoSueldo;
        }

        private void frmAdelantoSueldo_Load(object sender, EventArgs e)
        {
            cboTipoPlanilla.ListarTipoPlanillaAdelantoRelacionLab(2);
            HabilitarControles(false);
            btnNuevo.Enabled = false;
        }

        private void conBusPersonal_BuscarUsuario(object sender, EventArgs e)
        {
            txtMontoAdelanto.Text = "";
            txtMotivoAdelanto.Text = "";
            if (conBusPersonal.txtCod.Text == "")
            {
                dtAdelantoSueldo.Rows.Clear();
                LimpiarControlesDetalle();
                HabilitarControles(false);
                btnNuevo.Enabled = false;
            }
            else
            {
                CargarListaAdelantoSueldoPorUsuario(Convert.ToInt32(conBusPersonal.idUsu));
            }
            //cboTipoPlanilla.SelectedValue = 0;
            //cboPeriodoPlanilla.SelectedValue = 0;
            //CargarListaDescuentosAdelantoSueldo(0);
        }

        private void dtgAdelantoUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgAdelantoUsuario.RowCount > 0)
            {
                int nFilaSeleccionada = Convert.ToInt32(dtgAdelantoUsuario.CurrentRow.Index);

                cboTipoPlanilla.SelectedValue = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdTipoPlanilla"].Value);
                cboPeriodoPlanilla.SelectedValue = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdPeriodoPlanilla"].Value);
                txtMontoAdelanto.Text = dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmMontoAdelanto"].Value.ToString();
                txtMotivoAdelanto.Text = dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmMotivoAdelanto"].Value.ToString();

                CargarListaDescuentosAdelantoSueldo(Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value));

                if (Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdEstado"].Value) == 1)
                {
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
        }

        private void cboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPlanilla.ValueMember == "" || cboTipoPlanilla.DisplayMember == "")
            {
                return;
            }
            else
            {
                int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
                
                cboPeriodoPlanilla.ListarPeriodoVigenteTipoPlanilla(idTipoPlanilla);

                dtDescuentoAdelantoSueldo.Rows.Clear();

                DataTable dtPeriodo = objPeriodoPlanilla.CNListarPeriodoVigenteTipoPlanilla(idTipoPlanilla);
                dtgcbodIdPeriodoPlanilla.DataSource = dtPeriodo;
                dtgcbodIdPeriodoPlanilla.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
                dtgcbodIdPeriodoPlanilla.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();

                DataTable dtModalidadPlanilla = objModalidadPlanilla.CNListarModalidadDctoAdelantoTipoPlanilla(idTipoPlanilla);
                dtgcbodIdModalidad.DataSource = dtModalidadPlanilla;
                dtgcbodIdModalidad.ValueMember = dtModalidadPlanilla.Columns["idModalidad"].ToString();
                dtgcbodIdModalidad.DisplayMember = dtModalidadPlanilla.Columns["cModalidad"].ToString();
            }
        }

        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            //===========================
            // Validaciones
            //===========================
            if (((DataTable)dtgcbodIdPeriodoPlanilla.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("No existen Periodos para ese Tipo de Planilla", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (((DataTable)dtgcbodIdModalidad.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("No existen Modalidades para ese Tipo de Planilla", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtMontoAdelanto.Text))
            {
                MessageBox.Show("Debe ingresar un monto válido", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (Convert.ToDecimal(txtMontoAdelanto.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar un monto mayor a cero para el descuento", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtMotivoAdelanto.Text))
            {
                MessageBox.Show("Debe ingresar el motivo del adelanto", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idAdelantoSueldo = 0;
            int idTipoPlanilla = 0;
            int idPeriodoPlanilla = 0;

            if (cTipTrxAdelanto == "N")
            {
                int aux = 0;
                idAdelantoSueldo = 0;
                idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
                idPeriodoPlanilla = Convert.ToInt32(cboPeriodoPlanilla.SelectedValue);
                for (int i = 0; i < Convert.ToInt32(dtgAdelantoUsuario.Rows.Count); i++)
                {
                    if (idTipoPlanilla == Convert.ToInt32(dtgAdelantoUsuario.Rows[i].Cells["dtgtxtmIdTipoPlanilla"].Value) && idPeriodoPlanilla == Convert.ToInt32(dtgAdelantoUsuario.Rows[i].Cells["dtgtxtmIdPeriodoPlanilla"].Value))
                    {
                        MessageBox.Show("No puede agregar, un adelanto adicional para el mismo periodo y tipo de planilla", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        aux = aux + 1;
                        break;
                    }
                }
                if (aux > 0)
                {
                    return;
                }
            }

            if (cTipTrxAdelanto == "A")
            {
                int nFilaSeleccionada = Convert.ToInt32(dtgDescuentoAdelantoSueldo.CurrentRow.Index);
                idAdelantoSueldo = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value);
                idTipoPlanilla = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdTipoPlanilla"].Value);
                idPeriodoPlanilla = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdPeriodoPlanilla"].Value);
            }

            DataRow dr = dtDescuentoAdelantoSueldo.NewRow();

            dr["idAdelantoSueldo"] = idAdelantoSueldo;
            dr["idTipoPlanilla"] = idTipoPlanilla;
            dr["idPeriodoPlanilla"] = idPeriodoPlanilla;
            dr["idModalidad"] = 1;
            dr["nMontoDescontar"] = Convert.ToDecimal(txtMontoAdelanto.Text);
            dr["nMontoDescontado"] = 0.00;
            dr["lVigente"] = 1;

            dtDescuentoAdelantoSueldo.Rows.Add(dr);
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDescuentoAdelantoSueldo.CurrentRow != null && dtgDescuentoAdelantoSueldo.Rows.Count > 0)
            {
                if (Convert.ToDecimal(dtgDescuentoAdelantoSueldo.CurrentRow.Cells["dtgtxtdMontoDescontado"].Value) != 0)
                {
                    MessageBox.Show("No puede Eliminar dicho Descuento, monto descontado diferente de cero", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int nFilaSeleccionada = Convert.ToInt32(dtgDescuentoAdelantoSueldo.CurrentRow.Index);
                    dtgDescuentoAdelantoSueldo.Rows.RemoveAt(nFilaSeleccionada);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusPersonal.txtCod.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador, para su registro", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusPersonal.txtCod.Focus();
                return;
            }
            if (string.IsNullOrEmpty(conBusPersonal.txtNom.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador, para su registro", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusPersonal.txtCod.Focus();
                return;
            }
            
            cTipTrxAdelanto = "N";
            CargarListaDescuentosAdelantoSueldo(0);
            LimpiarControlesDetalle();
            HabilitarControles(true);

            dtDescuentoAdelantoSueldo.Columns["idPeriodoPlanilla"].ReadOnly = false;
            dtDescuentoAdelantoSueldo.Columns["idModalidad"].ReadOnly = false;
            dtDescuentoAdelantoSueldo.Columns["nMontoDescontar"].ReadOnly = false;

            dtgDescuentoAdelantoSueldo.ReadOnly = false;

            dtgDescuentoAdelantoSueldo.Columns["dtgtxtdMontoDescontado"].ReadOnly = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgAdelantoUsuario.CurrentRow != null && dtgAdelantoUsuario.Rows.Count > 0)
            {
                int nFilaSeleccionada = Convert.ToInt32(dtgAdelantoUsuario.CurrentRow.Index);
                               
                if (Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdEstado"].Value) == 1)
                {
                    cTipTrxAdelanto = "A";
                    HabilitarControles(true);

                    CargarListaDescuentosAdelantoSueldo(Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value));

                    txtMontoAdelanto.Text = dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmMontoAdelanto"].Value.ToString();
                    txtMotivoAdelanto.Text = dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmMotivoAdelanto"].Value.ToString();

                    //dtDescuentoAdelantoSueldo.Columns["idPeriodoPlanilla"].ReadOnly = false;
                    //dtDescuentoAdelantoSueldo.Columns["idModalidad"].ReadOnly = false;
                    //dtDescuentoAdelantoSueldo.Columns["nMontoDescontar"].ReadOnly = false;

                    //dtgDescuentoAdelantoSueldo.ReadOnly = false;

                    //dtgDescuentoAdelantoSueldo.Columns["dtgtxtdMontoDescontado"].ReadOnly = true;

                    //foreach (DataGridViewRow row in dtgDescuentoAdelantoSueldo.Rows)
                    //{
                    //    decimal nMontoDescontado = Convert.ToDecimal(row.Cells["dtgtxtdMontoDescontado"].Value);
                    //    if (nMontoDescontado != 0)
                    //    {
                    //        row.Cells["dtgcbodIdPeriodoPlanilla"].ReadOnly = true;
                    //        row.Cells["dtgcbodIdModalidad"].ReadOnly = true;
                    //        row.Cells["dtgtxtdMontoDescontar"].ReadOnly = true;
                    //    }
                    //}
                    btnMiniAgregar.Enabled = false;
                    btnMiniQuitar.Enabled = false;
                    txtMontoAdelanto.Enabled = false;
                    txtMontoAdelanto.Focus();
                }
                else
                {
                    MessageBox.Show("No se puede editar el registro, Adelanto ya fue Pagado", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar el Registro a Editar", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cTipTrxAdelanto = "";

            if (dtgAdelantoUsuario.CurrentRow != null && dtgAdelantoUsuario.Rows.Count > 0)
            {
                int nFilaSeleccionada = Convert.ToInt32(dtgAdelantoUsuario.CurrentRow.Index);
                if (Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdEstado"].Value) == 1)
                {
                    int idAdelantoSueldo = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value);
                    DataTable dtEliminarAdelantoSueldo = objAdelantoSueldo.CNEliminarAdelantoSueldo(idAdelantoSueldo, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
                    MessageBox.Show(dtEliminarAdelantoSueldo.Rows[0]["cMensaje"].ToString(), "Adelanto de Sueldo", MessageBoxButtons.OK, ((int)dtEliminarAdelantoSueldo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                    CargarListaAdelantoSueldoPorUsuario(Convert.ToInt32(conBusPersonal.idUsu));
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el registro, Adelanto ya fue Pagado", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cTipTrxAdelanto = "";
            
            CargarListaAdelantoSueldoPorUsuario(0);
            //CargarListaDescuentosAdelantoSueldo(0);
            //CargarListaDescuentosAdelantoSueldo(0);

            //if (dtgAdelantoUsuario.CurrentRow != null && dtgAdelantoUsuario.Rows.Count > 0)
            //{
            //    int nFilaSeleccionada = Convert.ToInt32(dtgAdelantoUsuario.CurrentRow.Index);
            //    int idAdelantoSueldo = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value);
            //    CargarListaDescuentosAdelantoSueldo(Convert.ToInt32(idAdelantoSueldo));
            //    CargarListaDescuentosAdelantoSueldo(Convert.ToInt32(idAdelantoSueldo));
            //}
            LimpiarControlesDetalle();
            HabilitarControles(false);
            conBusPersonal.LimpiarDatos();
            conBusPersonal.txtCod.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int idAdelantoSueldo;
            int idTipoPlanilla;
            int idPeriodoPlanilla;

            int idUsuario = Convert.ToInt32(conBusPersonal.idUsu);
            int idRelacionLab = Convert.ToInt32(conBusPersonal.idRelLab);
            decimal nMontoAdelanto = Convert.ToDecimal(txtMontoAdelanto.Text);
            string cMotivoAdelanto = txtMotivoAdelanto.Text.ToString();

            //===========================
            // Validaciones
            //===========================
            if (dtgDescuentoAdelantoSueldo.Rows.Count<=0)
            {
                MessageBox.Show("Por lo menos debe registrar un descuento...Verificar", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.txtCod.Focus();
                return;
            }

            if (Convert.ToInt32(conBusPersonal.idEstUsu) != 1)
            {
                MessageBox.Show("Colaborador no se encuentra activo", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.Focus();
                return;
            }

            if (nMontoAdelanto <= 0) // Monto de Adelanto
            {
                MessageBox.Show("Monto de Adelanto debe ser mayor a cero", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoAdelanto.Text = "0.00";
                txtMontoAdelanto.Focus();
                return;
            }

            if (cMotivoAdelanto.Length == 0) // Motivo de Adelanto
            {
                MessageBox.Show("Ingrese Motivo de Adelanto", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivoAdelanto.Focus();
                return;
            }

            bool lValidaDcto = true;
            decimal nSumDctos = 0;
            foreach (DataRow dri in dtDescuentoAdelantoSueldo.Rows)
            {
                foreach (DataRow drj in dtDescuentoAdelantoSueldo.Rows)
                {
                    if (dri.Equals(drj) == false && Convert.ToInt32(dri["idPeriodoPlanilla"]) == Convert.ToInt32(drj["idPeriodoPlanilla"]) && Convert.ToInt32(dri["idModalidad"]) == Convert.ToInt32(drj["idModalidad"]))
                    {
                        lValidaDcto = false;
                    }
                }
                nSumDctos += Convert.ToDecimal(dri["nMontoDescontar"]);
            }

            if (lValidaDcto == false)
            {
                MessageBox.Show("Existen descuentos grabados a una misma planilla", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgAdelantoUsuario.Focus();
                return;
            }
            //if (nSumDctos != nMontoAdelanto)
            //{
            //    MessageBox.Show("Los montos a descontar no equivalen el monto de Adelanto", "Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    dtgAdelantoUsuario.Focus();
            //    return;
            //}

            btnGrabar.Enabled = false;

            DataSet ds = new DataSet("dsDescuentoAdelantoSueldo");
            ds.Tables.Add(dtDescuentoAdelantoSueldo.Copy());
            String xmlDescuentoAdelantoSueldo = ds.GetXml();
            xmlDescuentoAdelantoSueldo = clsCNFormatoXML.EncodingXML(xmlDescuentoAdelantoSueldo);

            if (cTipTrxAdelanto == "N")
            {
                idAdelantoSueldo = 0;
                idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
                idPeriodoPlanilla = Convert.ToInt32(cboPeriodoPlanilla.SelectedValue);

                DataTable dtRegistrarAdelantoSueldo = objAdelantoSueldo.CNRegistrarAdelantoSueldo(idTipoPlanilla, idPeriodoPlanilla, idUsuario, idRelacionLab, clsVarGlobal.dFecSystem, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
                MessageBox.Show(dtRegistrarAdelantoSueldo.Rows[0]["cMensaje"].ToString(), "Adelanto de Sueldo", MessageBoxButtons.OK, ((int)dtRegistrarAdelantoSueldo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            if (cTipTrxAdelanto == "A")
            {
                //int nFilaSeleccionada = Convert.ToInt32(dtgDescuentoAdelantoSueldo.CurrentRow.Index);
                
                if (string.IsNullOrEmpty(txtMotivoAdelanto.Text))
                {
                    MessageBox.Show("Debe ingresar el motivo del adelanto", "Descuentos de Adelanto de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int nFilaSeleccionada = Convert.ToInt32(dtgAdelantoUsuario.CurrentRow.Index);
                
                idAdelantoSueldo = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdAdelantoSueldo"].Value);
                idTipoPlanilla = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdTipoPlanilla"].Value);

                if (Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdEstado"].Value) == 1)
                {
                    idPeriodoPlanilla = Convert.ToInt32(cboPeriodoPlanilla.SelectedValue);
                }
                else
                {   
                    idPeriodoPlanilla = Convert.ToInt32(dtgAdelantoUsuario.Rows[nFilaSeleccionada].Cells["dtgtxtmIdPeriodoPlanilla"].Value);
                }

                DataTable dtActualizarAdelantoSueldo = objAdelantoSueldo.CNActualizarAdelantoSueldo(idAdelantoSueldo, idPeriodoPlanilla, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
                MessageBox.Show(dtActualizarAdelantoSueldo.Rows[0]["cMensaje"].ToString(), "Adelanto de Sueldo", MessageBoxButtons.OK, ((int)dtActualizarAdelantoSueldo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            cTipTrxAdelanto = "";
            CargarListaAdelantoSueldoPorUsuario(Convert.ToInt32(conBusPersonal.idUsu));
            conBusPersonal.txtCod.Enabled = false;            
        }
    }
}

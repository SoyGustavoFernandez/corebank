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
using ADM.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmExperienciaClienteConfig : frmBase
    {

        DataTable dtOficinas = new DataTable();
        DataTable dtconfiguraciones = new DataTable();
        DataTable dtPerfiles = new DataTable();

        public frmExperienciaClienteConfig()
        {
            InitializeComponent();
        }

        private void frmExperienciaClienteConfig_Load(object sender, EventArgs e)
        {
            llenarGrillaOficinas();
            formatearGrilla();

            dateFecSys.Value = clsVarGlobal.dFecSystem;
        }

        private void llenarGrillaOficinas() 
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            dtOficinas = cnExpCliente.ListaOficinasExpCliente();

            dtgBaseOficinas.DataSource = dtOficinas;
            dtgBaseOficinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgBaseOficinas.Columns["idAgencia"].HeaderText = "ID";
            dtgBaseOficinas.Columns["idAgencia"].Width = 30;
            dtgBaseOficinas.Columns["cNombreEstab"].HeaderText = "OFICINA";
            dtgBaseOficinas.Columns["cNombreEstab"].Width = 270;
            dtgBaseOficinas.Columns["lEstado"].HeaderText = "ESTADO";
            dtgBaseOficinas.Columns["lEstado"].Width = 80;
            dtgBaseOficinas.Columns["idExOficina"].Visible = false;
            dtgBaseOficinas.Columns["OPCIONES"].Visible = false;

            dtgBaseOficinas.ClearSelection();
        }

        private void llenarGrillaConfiguraciones(int idOficina)
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            dtconfiguraciones = cnExpCliente.ListaParametrosExpCliente(idOficina, dateFecSys.Value);

            dtgBaseConfiguraciones.DataSource = dtconfiguraciones;
            dtgBaseConfiguraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgBaseConfiguraciones.Columns["idExHorario"].Visible = false;
            dtgBaseConfiguraciones.Columns["idAgencia"].Visible = false;
            dtgBaseConfiguraciones.Columns["dfecha"].Visible = false;
            dtgBaseConfiguraciones.Columns["lblock"].Visible = false;
            dtgBaseConfiguraciones.Columns["HORARIO"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["DESEMBOLSO"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["MUESTRA DESEMBOLSO"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["PAGO"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["MUESTRA PAGO"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["APERTURA"].ReadOnly = true;
            dtgBaseConfiguraciones.Columns["MUESTRA APERTURA"].ReadOnly = true;

            formatearGrillaConfiguraciones();

            if (dtconfiguraciones.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtconfiguraciones.Rows[0]["lblock"]) == true)
                {
                    btnGrabar1.Enabled = false;
                }
                else
                {
                    btnGrabar1.Enabled = true;
                }
                lblTextoAviso.Visible = true;
            }
            else
            { 
                lblTextoAviso.Visible = false; 
            }
        }

        private void llenarGrillaPerfiles()
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            dtPerfiles = cnExpCliente.ListaPerfilesExpCliente();

            dtgBasePerfiles.DataSource = dtPerfiles;
            dtgBasePerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgBasePerfiles.Columns["idPerfil"].HeaderText = "ID";
            dtgBasePerfiles.Columns["idPerfil"].Width = 40;
            dtgBasePerfiles.Columns["cDescripcion"].HeaderText = "PERFIL USUARIO";
            dtgBasePerfiles.Columns["cDescripcion"].Width = 280;
            dtgBasePerfiles.Columns["lVigente"].HeaderText = "ESTADO";
            dtgBasePerfiles.Columns["lVigente"].Width = 80;
        }

        private void dtgBaseOficinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                string estadoFila; int estadoBit;
                if (Convert.ToBoolean(dtgBaseOficinas.CurrentRow.Cells[4].Value) == true)
                {
                    estadoFila = "ACTIVO"; estadoBit = 0;
                }
                else
                {
                    estadoFila = "DESACTIVADO"; estadoBit = 1;
                }
                var Msg = MessageBox.Show("Estado actual [" + estadoFila + "], Está Seguro de cambiar de Estado a Oficina?...", "Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.Yes)
                {
                    clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                    DataTable dt = cnExpCliente.ActualizaEstadoOficinaExpCliente(Convert.ToInt32(dtgBaseOficinas.CurrentRow.Cells[1].Value), estadoBit);
                    llenarGrillaOficinas();
                    dtgBaseConfiguraciones.DataSource = "";
                    lblOficina.Text = string.Empty;
                    lblCodOficina.Text = string.Empty;
                }
            }
            else 
            {
                dtgBaseConfiguraciones.DataSource = "";
                lblOficina.Text = string.Empty;
                lblCodOficina.Text = string.Empty;
                if (Convert.ToBoolean(dtgBaseOficinas.CurrentRow.Cells[4].Value) == true)
                {
                    lblOficina.Text = dtgBaseOficinas.CurrentRow.Cells[3].Value.ToString();
                    lblCodOficina.Text = dtgBaseOficinas.CurrentRow.Cells[2].Value.ToString();
                    llenarGrillaConfiguraciones(Convert.ToInt32(dtgBaseOficinas.CurrentRow.Cells[2].Value));
                    dtgBaseConfiguraciones.ClearSelection();
                    lblTextoAviso.Visible = true;
                }
                else
                {
                    lblTextoAviso.Visible = false;
                }
            }
             formatearGrilla();
        }

        private void formatearGrilla()
        {
            if (dtgBaseOficinas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgBaseOficinas.Rows)
                {
                    if (Convert.ToInt32(row.Cells["lEstado"].Value) == 1)
                    {
                        row.Cells["lEstado"].Style.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToInt32(row.Cells["lEstado"].Value) == 0)
                    {
                        row.Cells["lEstado"].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void formatearGrillaPerfil() 
        { 
            if (dtgBasePerfiles.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgBasePerfiles.Rows)
                {
                    if (Convert.ToInt32(row.Cells["lvigente"].Value) == 1)
                    {
                        row.Cells["lvigente"].Style.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToInt32(row.Cells["lvigente"].Value) == 0)
                    {
                        row.Cells["lvigente"].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void formatearGrillaConfiguraciones()
        {
            if (dtgBaseConfiguraciones.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["MUESTRA DESEMBOLSO"].Value) > 0)
                    {
                        row.Cells["MUESTRA DESEMBOLSO"].Style.BackColor = Color.LightGreen;
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["MUESTRA PAGO"].Value) > 0)
                    {
                        row.Cells["MUESTRA PAGO"].Style.BackColor = Color.LightGreen;
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["MUESTRA APERTURA"].Value) > 0)
                    {
                        row.Cells["MUESTRA APERTURA"].Style.BackColor = Color.LightGreen;
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    row.Cells["DESEMBOLSO"].Style.BackColor = Color.LightBlue;
                    row.Cells["PAGO"].Style.BackColor = Color.LightBlue;
                    row.Cells["APERTURA"].Style.BackColor = Color.LightBlue;

                    row.Cells["DESEMBOLSO %"].Style.BackColor = Color.LightYellow;
                    row.Cells["PAGO %"].Style.BackColor = Color.LightYellow;
                    row.Cells["APERTURA %"].Style.BackColor = Color.LightYellow;
                }
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia1.Text == "TODAS LAS AGENCIAS") 
            {
                btnAgregar1.Enabled = false;
            }
            else 
            {
                btnAgregar1.Enabled = true;
            }
        } 

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("Este proceso bloqueará la edición, Seguro Continuar.?...", "Bloquear Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }
            
            if (dtgBaseConfiguraciones.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["DESEMBOLSO"].Value) > 0) 
                    { 
                        if (Convert.ToInt32(row.Cells["MUESTRA DESEMBOLSO"].Value) == 0)
                        {
                            MessageBox.Show("Hay registros pendientes [DESEMBOLSO], REVISAR.", "Bloquear Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }                  
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["PAGO"].Value) > 0)
                    { 
                        if (Convert.ToInt32(row.Cells["MUESTRA PAGO"].Value) == 0)
                        {
                            MessageBox.Show("Hay registros pendientes [PAGO], REVISAR.", "Bloquear Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }                    
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["APERTURA"].Value) > 0)
                    { 
                        if (Convert.ToInt32(row.Cells["MUESTRA APERTURA"].Value) == 0)
                        {
                            MessageBox.Show("Hay registros pendientes [APERTURA], REVISAR.", "Bloquear Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }                   
                    }
                }

                //REGISTRA
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["DESEMBOLSO"].Value) > 0)
                    {
                        clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                        DataTable dtActualizaPorc = cnExpCliente.ActualizaParametrosExpCliente(Convert.ToInt32(row.Cells["idExHorario"].Value), Convert.ToInt32(row.Cells["idAgencia"].Value), 1, Convert.ToDateTime(row.Cells["dfecha"].Value), Convert.ToDecimal(row.Cells["DESEMBOLSO %"].Value), clsVarGlobal.User.cWinUser);
                    }
                }
                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["PAGO"].Value) > 0)
                    {
                        clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                        DataTable dtActualizaPorc = cnExpCliente.ActualizaParametrosExpCliente(Convert.ToInt32(row.Cells["idExHorario"].Value), Convert.ToInt32(row.Cells["idAgencia"].Value), 2, Convert.ToDateTime(row.Cells["dfecha"].Value), Convert.ToDecimal(row.Cells["PAGO %"].Value), clsVarGlobal.User.cWinUser);
                    }
                }

                foreach (DataGridViewRow row in dtgBaseConfiguraciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["APERTURA"].Value) > 0)
                    {
                        clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                        DataTable dtActualizaPorc = cnExpCliente.ActualizaParametrosExpCliente(Convert.ToInt32(row.Cells["idExHorario"].Value), Convert.ToInt32(row.Cells["idAgencia"].Value), 9, Convert.ToDateTime(row.Cells["dfecha"].Value), Convert.ToDecimal(row.Cells["APERTURA %"].Value), clsVarGlobal.User.cWinUser);
                    }
                }
                llenarGrillaConfiguraciones(Convert.ToInt32(lblCodOficina.Text));
            }
            else
            {
                MessageBox.Show("No hay datos para evaluar.", "Bloquear Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgBaseOficinas.Rows)
            {
                if (Convert.ToString(row.Cells["cNombreEstab"].Value).Trim() == cboAgencia1.Text.Trim())
                {
                    MessageBox.Show("Agencia: "+ cboAgencia1.Text.Trim() + ", Ya Existe.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
                clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                DataTable dtRegOficina = cnExpCliente.RegistraOficinaExpCliente(Convert.ToInt32(cboAgencia1.SelectedValue.ToString()));

                if (Convert.ToInt32(dtRegOficina.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtRegOficina.Rows[0]["cMensage"].ToString(), "Registro Oficina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarGrillaOficinas();
                    formatearGrilla();
                }
                else
                {
                    MessageBox.Show(dtRegOficina.Rows[0]["cMensage"].ToString(), "Registro Oficina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            if (dtconfiguraciones.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtconfiguraciones.Rows[0]["lblock"]) == true)
                {
                    MessageBox.Show("No puede Generar, Registro fue Bloqueado", "Generar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No hay datos para evaluar.", "Generar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Msg = MessageBox.Show("Este proceso va a Generar y sobreescribir el consolidado de operaciones, Seguro Continuar.?...", "Generar Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtGeneraConfig = cnExpCliente.GeneraParametrosExpCliente(dateFecSys.Value, Convert.ToInt32(lblCodOficina.Text), clsVarGlobal.User.cWinUser);
            if (Convert.ToInt32(dtGeneraConfig.Rows[0]["idRpta"]) == 1)
            {
                MessageBox.Show(dtGeneraConfig.Rows[0]["cMensage"].ToString(), "Generar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarGrillaConfiguraciones(Convert.ToInt32(lblCodOficina.Text));
            }
            else
            {
                MessageBox.Show(dtGeneraConfig.Rows[0]["cMensage"].ToString(), "Generar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = sender as TabControl;
            if (Convert.ToInt32(tab.SelectedIndex) == 1)
            {
                llenarGrillaPerfiles();
                formatearGrillaPerfil(); 
            }  
        }

        private void dtgBasePerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string estadoFila; int estadoBit;
                if (Convert.ToBoolean(dtgBasePerfiles.CurrentRow.Cells[2].Value) == true)
                {
                    estadoFila = "ACTIVO"; estadoBit = 0;
                }
                else
                {
                    estadoFila = "DESACTIVADO"; estadoBit = 1;
                }
                var Msg = MessageBox.Show("Estado actual [" + estadoFila + "], Está Seguro Cambiar de ESTADO ?", "Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.Yes)
                {
                    clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                    DataTable dt = cnExpCliente.ActualizaPerfilExpCliente(Convert.ToInt32(dtgBasePerfiles.CurrentRow.Cells[0].Value), estadoBit);
                    llenarGrillaPerfiles();
                    formatearGrillaPerfil();
                }                
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (dtconfiguraciones.Rows.Count > 0) 
            { 
                 if (Convert.ToBoolean(dtconfiguraciones.Rows[0]["lblock"]) == true)
                {
                    MessageBox.Show("No puede Cancelar, Registro fue Bloqueado", "Cancelar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }           
            }
            else
            {
                MessageBox.Show("No hay datos para evaluar.", "Cancelar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Msg = MessageBox.Show("Este proceso va a Revertir los % de muestra que fue ingresado, Seguro Continuar.?...", "Cancelar Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtCancelaPorc = cnExpCliente.CancelaParametrosExpCliente(Convert.ToInt32(lblCodOficina.Text), dateFecSys.Value);
            if (Convert.ToInt32(dtCancelaPorc.Rows[0]["idRpta"]) == 1)
            {
                MessageBox.Show(dtCancelaPorc.Rows[0]["cMensage"].ToString(), "Cancelar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarGrillaConfiguraciones(Convert.ToInt32(lblCodOficina.Text));
            }
            else
            {
                MessageBox.Show(dtCancelaPorc.Rows[0]["cMensage"].ToString(), "Cancelar Registro.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgBasePerfiles.Rows)
            {
                if (Convert.ToString(row.Cells["cDescripcion"].Value).Trim() == cboListaPerfil1.Text.Trim())
                {
                    MessageBox.Show("Perfil: " + cboListaPerfil1.Text.Trim() + ", Ya Existe.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (Convert.ToInt32(numericUpDown1.Value) == 0)
            {
                var Msg = MessageBox.Show("La Alerta para este Perfil se mostrará mas de una vez, Seguro Continuar.?...", "Generar Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }
            }
            else 
            {
                var Msg = MessageBox.Show("La Alerta para este Perfil se mostrará solo : [" + numericUpDown1.Value + "] vez/ veces, Seguro Continuar.?...", "Generar Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }            
            }

            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtRegPerfil = cnExpCliente.RegistraPerfilesExpCliente(Convert.ToInt32(cboListaPerfil1.SelectedValue.ToString()), Convert.ToInt32(numericUpDown1.Value));

            if (Convert.ToInt32(dtRegPerfil.Rows[0]["idRpta"]) == 1)
            {
                MessageBox.Show(dtRegPerfil.Rows[0]["cMensage"].ToString(), "Registro Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarGrillaPerfiles();
                formatearGrillaPerfil();
            }
            else
            {
                MessageBox.Show(dtRegPerfil.Rows[0]["cMensage"].ToString(), "Registro Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgBaseConfiguraciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgBaseConfiguraciones.Columns["DESEMBOLSO %"].Index || e.ColumnIndex == dtgBaseConfiguraciones.Columns["PAGO %"].Index || e.ColumnIndex == dtgBaseConfiguraciones.Columns["APERTURA %"].Index)
            { 
                 int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                int resColumnIndex = e.ColumnIndex + 1;

                object newValue = dtgBaseConfiguraciones.Rows[rowIndex].Cells[columnIndex].Value ?? 0;

                if (Convert.ToDecimal(newValue) < 0)
                {
                    dtgBaseConfiguraciones.Rows[rowIndex].Cells[columnIndex].Value = 0;
                    return;
                }

                if (Convert.ToDecimal(newValue) > 50)
                {
                    MessageBox.Show("[%] No puede ser mayor a 50", "Registro ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgBaseConfiguraciones.Rows[rowIndex].Cells[columnIndex].Value = 50;
                    return;
                }
                else 
                {
                    decimal nMuestra = Convert.ToDecimal(dtgBaseConfiguraciones.Rows[rowIndex].Cells[columnIndex - 1].Value);
                    decimal nResMuestra = Convert.ToDecimal((nMuestra * (Convert.ToDecimal(newValue))) / 100);

                    dtgBaseConfiguraciones.Rows[rowIndex].Cells[resColumnIndex].Value = (int)Math.Ceiling((double)nResMuestra);
                }           
            }            
        }

        private void dtgBaseConfiguraciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgBaseConfiguraciones.CurrentCell.ColumnIndex == 5 || dtgBaseConfiguraciones.CurrentCell.ColumnIndex == 8 || dtgBaseConfiguraciones.CurrentCell.ColumnIndex == 11) 
            {
                TextBox textBox = e.Control as TextBox; 

                if (textBox != null)
                {
                    textBox.KeyPress += TextBox_KeyPress; 
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtgBaseConfiguraciones_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        } 
    }
}

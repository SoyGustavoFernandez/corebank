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
using CLI.CapaNegocio;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmGrupoEconomico : frmBase
    {
        Transaccion accion = Transaccion.Selecciona;

        clsCNGrupoEconomico grupoeco = new clsCNGrupoEconomico();
        clsCNRetDatosCliente datoscli = new clsCNRetDatosCliente();
        DataTable dtGrupoEconomico;
        public frmGrupoEconomico()
        {
            InitializeComponent();
        }

        private void frmGrupoEconomico_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            CargarGrupoEconomico();
            

            btnEditar.Enabled = true;
            //btnMiniAgregarGrupo.Enabled = false;
            btnAgregarParticipantes.Enabled = false;
            btnQuitarParticipante.Enabled = false;

            chcVigente.Enabled = false;

            //dtgGrupoEconomico.ClearSelection();

            accion = 0;
        }

        private void CargarGrupoEconomico()
        {
            dtGrupoEconomico = grupoeco.CNListaGrupoEc((int)cboTipoGrupoEco1.SelectedValue);
            if (dtGrupoEconomico.Rows.Count == 0)
            {
                MessageBox.Show("No Existen Grupos Economicos Resgistrados", "Grupos Economicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
            }
            else
            {
                dtgGrupoEconomico.DataSource = dtGrupoEconomico;
                FormatoGridGE();
            }
            
        }

        private void FormatoGridGE()
        {
            dtgGrupoEconomico.Columns[0].HeaderText = "N° Grupo";
            dtgGrupoEconomico.Columns[1].HeaderText = "Descripcion";
            dtgGrupoEconomico.Columns[2].HeaderText = "Vigente";

            dtgGrupoEconomico.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgGrupoEconomico.Columns[0].Width = 11;
            dtgGrupoEconomico.Columns[1].Width = 50;
            dtgGrupoEconomico.Columns[2].Width = 50;
        }
        private void cargarparticipantes(int idGrupoEconomico)
        {
            lstParticipantes.Items.Clear();
            DataTable dtclientes = grupoeco.listarparticipantes(idGrupoEconomico);
            if (dtclientes.Rows.Count > 0)
            {
                foreach (DataRow item in dtclientes.Rows)
                {
                    lstParticipantes.Items.Add(datoscli.retornarCliente((int)item["idCli"]));
                }
                //btnEditar.Enabled = true;
            }
            //else
            //{
            //    btnEditar.Enabled = false;
            //}

        }
        private void cboTipoGrupoEco1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoGrupoEco1.SelectedIndex>=0)
            {
                lstParticipantes.Items.Clear();
                CargarGrupoEconomico();

                if (dtgGrupoEconomico.RowCount > 0)
                {
                    btnEditar.Enabled = true;
                }
                else 
                {
                    btnEditar.Enabled = false;
                }
            }            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            accion = Transaccion.Nuevo;
            habilitarNuevo(true);
            cboTipoGrupoEco1.Enabled = true;
            btnAgregarParticipantes.Enabled = true;
            btnQuitarParticipante.Enabled = true;
            txtGrupoEconomico.Focus();
            chcVigente.Checked = true;
            grbBase2.Enabled = true;
            //chcVigente.Enabled = true;

        }

        private void habilitarNuevo(bool estado)
        {
            btnGrabar.Enabled = estado;
            btnCancelar.Enabled = estado;
            btnNuevo.Enabled = !estado;
            btnEditar.Enabled = !estado;
            txtGrupoEconomico.Enabled = estado;
            lstParticipantes.Items.Clear();
            txtGrupoEconomico.Text = "";

            //btnMiniAgregarGrupo.Enabled = !estado;
            btnAgregarParticipantes.Enabled = !estado;
            btnQuitarParticipante.Enabled = !estado;

            dtgGrupoEconomico.Enabled = !estado;
            cboTipoGrupoEco1.Enabled = !estado;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            accion = Transaccion.Edita;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            cboTipoGrupoEco1.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;




            txtGrupoEconomico.Enabled = true;
            chcVigente.Enabled = true;
            if (chcVigente.Checked)
            {
                btnAgregarParticipantes.Enabled = true;
                btnQuitarParticipante.Enabled = true;
            }
            else
            {
                btnAgregarParticipantes.Enabled = false;
                btnQuitarParticipante.Enabled =false;
            }
            dtgGrupoEconomico.Enabled = false;
            grbBase2.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = Transaccion.Selecciona;

            habilitarNuevo(false);

            btnCancelar.Enabled = false;
            cboTipoGrupoEco1.Enabled = true;
            btnAgregarParticipantes.Enabled = false;
            btnQuitarParticipante.Enabled = false;
            btnEditar.Enabled = true;
            grbBase2.Enabled = false;
            chcVigente.Enabled = false;
            //btnMiniAgregarGrupo.Enabled = false;
        }

        private void txtGrupoEconomico_TextChanged(object sender, EventArgs e)
        {
            //if (txtGrupoEconomico.Text.Length > 0 & accion == Transaccion.Nuevo)
            //{
            //    btnMiniAgregarGrupo.Enabled = true;
            //}
            //else if (accion == Transaccion.Edita)
            //{
            //    btnMiniAgregarGrupo.Enabled = true;
            //}
            //else
            //{
            //    btnMiniAgregarGrupo.Enabled = false;
            //}
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli))
                return;

            int idCli = Convert.ToInt32(frmbuscli.pcCodCli);

            foreach (var item in lstParticipantes.Items)
            {
                if (((clsCliente)item).idCli==idCli)
                {
                    MessageBox.Show("Ya se agregó al cliente seleccionado", "Validación Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            clsCNRetDatosCliente cliente = new clsCNRetDatosCliente();

            clsCliente datoscliente = cliente.retornarCliente(idCli);

            lstParticipantes.Items.Add(datoscliente);
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            lstParticipantes.Items.Remove(lstParticipantes.SelectedItem);
            lstParticipantes.Refresh();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            chcVigente.Enabled = false;
            if (validar())
            {
                clsLisCliente listacli = new clsLisCliente();
                foreach (clsCliente item in lstParticipantes.Items)
                {
                    listacli.Add(item);
                }

                if (accion== Transaccion.Nuevo)
                {
                    grupoeco.insertarGrupoEco(new clsGrupoEconomico() { cGrupoEconomico = txtGrupoEconomico.Text.Trim(), idTipoGrupoEco = (int)cboTipoGrupoEco1.SelectedValue }, listacli);
                    MessageBox.Show("Se grabaron correctamente los datos ingresados", "Registro Grupo Económico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrupoEconomico();
                    grbBase2.Enabled = false;
                    cargarparticipantes(Convert.ToInt32(dtgGrupoEconomico.Rows[dtgGrupoEconomico.Rows.Count - 1].Cells[0].Value));
                }
                if (accion == Transaccion.Edita)
                {
                    bool lVigente = chcVigente.Checked;
                    //Convert.ToInt32(dtgGrupoEconomico.CurrentRow.Cells[2].Value)
                    grupoeco.actualizarGrupoEco(Convert.ToInt32(dtgGrupoEconomico.CurrentRow.Cells[0].Value), txtGrupoEconomico.Text, lVigente, listacli);
                    MessageBox.Show("Se actualizaron correctamente los datos ingresados", "Actualizar Grupo Económico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrupoEconomico();
                    grbBase2.Enabled = false;
                    cargarparticipantes(Convert.ToInt32(dtgGrupoEconomico.CurrentRow.Cells[0].Value));
                    
                }
                txtGrupoEconomico.Text = "";
                cboTipoGrupoEco1.Enabled = true;
                btnNuevo.Enabled = true;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAgregarParticipantes.Enabled = false;
                btnQuitarParticipante.Enabled = false;
                txtGrupoEconomico.Enabled = false;
                //lstParticipantes.Items.Clear();
                dtgGrupoEconomico.Enabled = true;
                //btnMiniAgregarGrupo.Enabled = false;
                accion = 0;
            }

         }

        private bool validar()
        {
            bool lValida = false;        

            var lista = from item in new clsCNGrupoEconomico().listarGrupoEco()
                        where item.idTipoGrupoEco == (int)cboTipoGrupoEco1.SelectedValue
                        select item;
            int nBusca = lista.Where(x => x.cGrupoEconomico.ToUpper() == txtGrupoEconomico.Text.Trim().ToUpper()).Count();

            if (nBusca > 0 && accion == Transaccion.Nuevo)
            {
                MessageBox.Show("Ya existe un grupo económico con el valor ingresado en la descripción", "Validación Grupo Económico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGrupoEconomico.Focus();
                this.txtGrupoEconomico.SelectAll();
                return lValida;
            }

            if (chcVigente.Checked & this.lstParticipantes.Items.Count==0)
            {
                MessageBox.Show("Debe ingresar clientes al grupo económico", "Validación Grupo Económico", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void btnAgregarParticipantes_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli))
                return;

            int idCli = Convert.ToInt32(frmbuscli.pcCodCli);

            foreach (var item in lstParticipantes.Items)
            {
                if (((clsCliente)item).idCli == idCli)
                {
                    MessageBox.Show("Ya se agregó al cliente seleccionado", "Validación Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            clsCNRetDatosCliente cliente = new clsCNRetDatosCliente();

            clsCliente datoscliente = cliente.retornarCliente(idCli);

            lstParticipantes.Items.Add(datoscliente);
        }

        private void btnQuitarParticipante_Click(object sender, EventArgs e)
        {
            lstParticipantes.Items.Remove(lstParticipantes.SelectedItem);
            lstParticipantes.Refresh();
        }

        
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (accion == Transaccion.Edita)
            {
                dtGrupoEconomico.Columns[2].ReadOnly = false;
                int fila = Convert.ToInt32(dtgGrupoEconomico.CurrentRow.Index);
                dtGrupoEconomico.Rows[fila][1] = txtGrupoEconomico.Text;
                dtGrupoEconomico.Rows[fila][2] = chcVigente.Checked ? 1 : 0;

                dtgGrupoEconomico.DataSource = dtGrupoEconomico;

                btnAgregarParticipantes.Enabled = true;
                btnQuitarParticipante.Enabled = false;

                //if (chcVigente.Checked == false)
                //{
                //    lstParticipantes.Items.Clear();
                //}
                
            }
            if (accion == Transaccion.Nuevo)
            {
                DataRow dr = dtGrupoEconomico.NewRow();
                dr["cGrupoEconomico"] = txtGrupoEconomico.Text;
                dr["idEstado"] = chcVigente.Checked ? 1 : 0;
                dtGrupoEconomico.Rows.Add(dr);

                dtgGrupoEconomico.Rows[dtgGrupoEconomico.Rows.Count - 1].Selected = true;

                btnAgregarParticipantes.Enabled = true;

            }

            dtgGrupoEconomico.FirstDisplayedScrollingRowIndex = Convert.ToInt32(dtgGrupoEconomico.Rows[dtgGrupoEconomico.Rows.Count - 1].Index);//dtgGrupoEconomico.CurrentRow.Index;

            //btnMiniAgregarGrupo.Enabled = false;
            txtGrupoEconomico.Enabled = false;
            chcVigente.Enabled = false;
        }

        private void lstParticipantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParticipantes.Items.Count > 0 & accion == Transaccion.Nuevo)
            {
                btnQuitarParticipante.Enabled = true;
            }
            else if (lstParticipantes.Items.Count > 0 & accion == Transaccion.Edita)
            {
                btnQuitarParticipante.Enabled = true;
            }
            else
            {
                btnQuitarParticipante.Enabled = false;
            }
        }

        private void chcVigente_CheckedChanged(object sender, EventArgs e)
        {
           // btnMiniAgregarGrupo.Enabled = true;
            if (chcVigente.Checked)
            {
                btnAgregarParticipantes.Enabled = true;
                btnQuitarParticipante.Enabled = true;
            }
            else
            {
                btnAgregarParticipantes.Enabled = false;
                btnQuitarParticipante.Enabled = false;
            }
            
        }

        private void dtgGrupoEconomico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idGrupoEconomico = Convert.ToInt32(dtgGrupoEconomico.CurrentRow.Cells["idGrupoEconomico"].Value);
            if (dtgGrupoEconomico.SelectedRows.Count > 0)
            {
                cargarparticipantes(idGrupoEconomico);

                txtGrupoEconomico.Text = dtgGrupoEconomico.CurrentRow.Cells[1].Value.ToString();
                chcVigente.Checked = Convert.ToBoolean(dtgGrupoEconomico.CurrentRow.Cells[2].Value);

                grbBase2.Enabled = false;
            }
        }

    }
}

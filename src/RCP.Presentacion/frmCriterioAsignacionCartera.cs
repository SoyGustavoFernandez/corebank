using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmCriterioAsignacionCartera : frmBase
    {
        clsCNCriteriosAsigCartRecu cnCriteriosAsigCartRecu = new clsCNCriteriosAsigCartRecu();
        enum Estado { Bloqueado, Lectura, Nuevo, Edicion }
        int nEstado = 0;
        int idSeleccionado = 0;
        public frmCriterioAsignacionCartera()
        {
            InitializeComponent();
            cboPersonalCreditos.ListarPersonal(0);
        }

        private void frmCriterioAsignacionCartera_Load(object sender, EventArgs e)
        {
            conBusUbig.cargar();
            cboTipoCriterioAsigCartera1.SelectedIndex = -1;                        
            controles((int)Estado.Bloqueado);
            cboAgencia.cargarSoloAgencias();
        }        

        private void cboTipoCriterioAsigCartera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipoCriterioAsigCartera1.SelectedIndex)
            {
                case 0:
                    pnlAgencia.Visible = true;
                    pnlAsesor.Visible = false;
                    pnlUbigeo.Visible = false;
                    break;
                case 1:
                    pnlAgencia.Visible = false;
                    pnlAsesor.Visible = false;
                    pnlUbigeo.Visible = true;
                    break;
                case 2:
                    pnlAgencia.Visible = false;
                    pnlAsesor.Visible = true;
                    pnlUbigeo.Visible = false;
                    break;
                default:
                    pnlAgencia.Visible = false;
                    pnlAsesor.Visible = false;
                    pnlUbigeo.Visible = false;
                    break;
            }            
        }
        
        public void controles(int estado)
        {
            nEstado = estado;
            switch (estado)
            { 
                case (int)Estado.Bloqueado:
                    cboUsuRecuperadores1.Enabled = true;
                    cboUsuRecuperadores1.SelectedIndex = -1;
                    limpiarControles();
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    chbVigente.Enabled = false;
                    cboAgencia.Enabled = false;
                    btnCancelar1.Enabled = false;
                    cboPersonalCreditos.Enabled = false;
                    conBusUbig.Enabled = false;
                    cboTipoCriterioAsigCartera1.Enabled = false;
                    dtgCriterios.Enabled = false;
                    break;
                case (int)Estado.Lectura:                    
                    cboUsuRecuperadores1.Enabled = true;
                    limpiarControles();
                    cargarCriteriosUsuario();
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    chbVigente.Enabled = false;
                    cboAgencia.Enabled = false;
                    btnCancelar1.Enabled = true;
                    cboPersonalCreditos.Enabled = false;
                    conBusUbig.Enabled = false;
                    cboTipoCriterioAsigCartera1.Enabled = false;
                    dtgCriterios.Enabled = true;
                    break;
                case (int)Estado.Nuevo:
                    cboUsuRecuperadores1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    chbVigente.Enabled = false;
                    cboAgencia.Enabled = true;
                    btnCancelar1.Enabled = true;
                    cboPersonalCreditos.Enabled = true;
                    conBusUbig.Enabled = true;
                    cboTipoCriterioAsigCartera1.Enabled = true;
                    dtgCriterios.Enabled = false;
                    limpiarControlesSinGrill();
                    break;
                case (int)Estado.Edicion:
                    cboUsuRecuperadores1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    chbVigente.Enabled = true;
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    dtgCriterios.Enabled = false;
                    break;
            }
        }

        public void limpiarControles()
        {
            this.dtgCriterios.DataSource = null;            
            this.cboTipoCriterioAsigCartera1.SelectedIndex = -1;
            this.cboAgencia.SelectedIndex = -1;
            this.cboPersonalCreditos.SelectedIndex = -1;            
            this.conBusUbig.cargarUbigeo(173);
            this.conBusUbig.cboPais.Enabled = false;
        }

        public void limpiarControlesSinGrill()
        {
            this.cboTipoCriterioAsigCartera1.SelectedIndex = -1;
            this.cboAgencia.SelectedIndex = -1;
            this.cboPersonalCreditos.SelectedIndex = -1;
            this.conBusUbig.cargarUbigeo(173);
        }

        public void formatearGridCriterios()
        {

            foreach (DataGridViewColumn columna in dtgCriterios.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }

            dtgCriterios.Columns["idCriteriosAsigCartRecu"].Visible = false;
            dtgCriterios.Columns["idTipoCriteriosAsigCartRecu"].Visible = false;
            dtgCriterios.Columns["cTipoCriteriosAsigCartRecu"].Visible = true;
            dtgCriterios.Columns["nValor"].Visible = false;
            dtgCriterios.Columns["cValor"].Visible = true;

            dtgCriterios.Columns["cTipoCriteriosAsigCartRecu"].HeaderText = "Criterio";            
            dtgCriterios.Columns["cValor"].HeaderText = "Valor";
        }

        public void cargarCriteriosUsuario() 
        {
            DataTable dtCriterios = cnCriteriosAsigCartRecu.ListarCriteriosAsigCartRecu(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue));
            if (dtCriterios.Rows.Count > 0)
            {
                dtgCriterios.DataSource = dtCriterios;
                formatearGridCriterios();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (nEstado == (int)Estado.Lectura)
            {
                controles((int)Estado.Bloqueado);
            }
            else
            {
                controles((int)Estado.Lectura);
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            controles((int)Estado.Nuevo);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            controles((int)Estado.Edicion);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (nEstado == (int)Estado.Nuevo)
                {
                    int valor = 0;
                    switch (Convert.ToInt32(cboTipoCriterioAsigCartera1.SelectedValue))
                    {
                        case 1:
                            valor = Convert.ToInt32(cboAgencia.SelectedValue);
                            break;
                        case 2:
                            valor = conBusUbig.nIdNodo;
                            break;
                        case 3:
                            valor = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
                            break;
                    }
                    DataTable dtResultado = cnCriteriosAsigCartRecu.registrarCriteriosAsigCartRecu(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), Convert.ToInt32(cboTipoCriterioAsigCartera1.SelectedValue), valor);
                    if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Registrado correctamente", "Criterio de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        controles((int)Estado.Lectura);
                    }
                }
                else
                {
                    DataTable dtResultado = cnCriteriosAsigCartRecu.actualizarCriteriosAsigCartRecu(idSeleccionado, chbVigente.Checked);
                    if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Actualizado correctamente", "Criterio de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        controles((int)Estado.Lectura);
                    }
                }
            }            
        }

        public bool validar()
        {
            if (this.cboTipoCriterioAsigCartera1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de cirterio", "Criterio de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoCriterioAsigCartera1.Focus();
                return false;
            }
            else
            {
                switch (Convert.ToInt32(this.cboTipoCriterioAsigCartera1.SelectedValue))
                {
                    case 1:
                        if (this.cboAgencia.SelectedIndex < 0)
                        {
                            MessageBox.Show("Debe seleccionar la agencia", "Criterio de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.cboAgencia.Focus();
                            return false;
                        }
                        break;
                    case 3:
                        if (this.cboPersonalCreditos.SelectedIndex < 0)
                        {
                            MessageBox.Show("Debe seleccionar la agencia", "Criterio de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.cboAgencia.Focus();
                            return false;
                        }
                        break;
                }
            }

            int valor = 0;
            switch (Convert.ToInt32(cboTipoCriterioAsigCartera1.SelectedValue))
            {
                case 1:
                    valor = Convert.ToInt32(cboAgencia.SelectedValue);
                    break;
                case 2:
                    valor = conBusUbig.nIdNodo;
                    break;
                case 3:
                    valor = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
                    break;
            }
            foreach (DataGridViewRow rows in dtgCriterios.Rows)
            {
                if (Convert.ToInt32(rows.Cells["idTipoCriteriosAsigCartRecu"].Value) == Convert.ToInt32(cboTipoCriterioAsigCartera1.SelectedValue) && valor == Convert.ToInt32(rows.Cells["nValor"].Value) && nEstado == (int)Estado.Nuevo)
                {
                    MessageBox.Show("El criterio seleccionado ya se encuentra asignado al usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void dtgCriterios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.dtgCriterios.Rows.Count > 0)
                {
                    this.cboTipoCriterioAsigCartera1.SelectedValue = dtgCriterios.Rows[e.RowIndex].Cells["idTipoCriteriosAsigCartRecu"].Value;
                    switch (Convert.ToInt32(this.cboTipoCriterioAsigCartera1.SelectedValue))
                    {
                        case 1:
                            this.cboAgencia.SelectedValue = dtgCriterios.Rows[e.RowIndex].Cells["nValor"].Value;
                            break;
                        case 2:
                            this.conBusUbig.cargarUbigeo(Convert.ToInt32(dtgCriterios.Rows[e.RowIndex].Cells["nValor"].Value));
                            break;
                        case 3:
                            this.cboPersonalCreditos.SelectedValue = dtgCriterios.Rows[e.RowIndex].Cells["nValor"].Value;
                            break;
                    }
                    idSeleccionado = Convert.ToInt32(dtgCriterios.Rows[e.RowIndex].Cells["idCriteriosAsigCartRecu"].Value);
                    chbVigente.Checked = true;                    
                    this.btnEditar1.Enabled = true;
                }
                else
                {
                    limpiarControles();
                    this.btnEditar1.Enabled = false;
                }
            }
        }

        private void cboUsuRecuperadores1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadores1.SelectedIndex >= 0)
            {
                controles((int)Estado.Lectura);
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

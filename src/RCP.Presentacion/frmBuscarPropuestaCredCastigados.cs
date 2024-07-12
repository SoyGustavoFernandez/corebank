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
using RCP.CapaNegocio;
using RPT.CapaNegocio;
using RCP.Presentacion;

namespace RCP.Presentacion
{
    public partial class frmBuscarPropuestaCredCastigados : frmBase
    {
        #region Variables Globales
        clsCNCreditoCastigo cnCreditoCastigo = new clsCNCreditoCastigo();
        public  int idPlan = 0;
        #endregion
        #region Métodos
        public frmBuscarPropuestaCredCastigados()
        {
            InitializeComponent();
            btnDetalle1.Enabled = false;
            cargarListaCreditosParaCastigo(0);
        }
        private void cargarListaCreditosParaCastigo(int idList)
        {
            DataTable creditosCast = cnCreditoCastigo.CNListarCredParaCastigo(idList);
            if (creditosCast.Rows.Count == 0)
            {
                MessageBox.Show("No hay Resultado para ese código", "Lista de Propuesta Crétidos Castigados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnDetalle1.Enabled = true;
            dtgListaCredCast.DataSource = creditosCast;
            formatoGridVin(dtgListaCredCast);
        }
        private void formatoGridVin(DataGridView dtgCreditos)
        {
            foreach (DataGridViewColumn item in dtgCreditos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgCreditos.ReadOnly = true;

            dtgCreditos.Columns["idLista"].Visible = true;
            dtgCreditos.Columns["cNombreUsuRegistra"].Visible = false;
            dtgCreditos.Columns["cWinUserReg"].Visible = true;
            dtgCreditos.Columns["cWinUserMod"].Visible = true;
            dtgCreditos.Columns["cCodigo"].Visible = true;
            dtgCreditos.Columns["dFechaRegistro"].Visible = true;
            dtgCreditos.Columns["dFechaCastigo"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;
            dtgCreditos.Columns["cNombreUsuModifica"].Visible = false;

            dtgCreditos.Columns["idLista"].HeaderText = "Id";
            dtgCreditos.Columns["cWinUserReg"].HeaderText = "Usuario Registró";
            dtgCreditos.Columns["cWinUserMod"].HeaderText = "Usuario Modificó";
            dtgCreditos.Columns["cCodigo"].HeaderText = "Código" ;
            dtgCreditos.Columns["dFechaRegistro"].HeaderText = "Fecha Registro";
            dtgCreditos.Columns["dFechaCastigo"].HeaderText = "Fecha Castigo";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
        }
        #endregion

        
        #region Eventos
        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("El Código esta Vacio", "Lista de Propuesta Crétidos Castigados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cargarListaCreditosParaCastigo((int)txtCodigo.nDecValor);
        }
        #endregion

        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgListaCredCast.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se encontraron filas seleccionadas", "Lista de Propuesta Crétidos Castigados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            idPlan = (int) dtgListaCredCast.SelectedRows[0].Cells["idLista"].Value;
            this.Close();
        }
    }
}

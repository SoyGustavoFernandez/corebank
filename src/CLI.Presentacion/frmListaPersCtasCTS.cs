using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using EntityLayer;

namespace CLI.Presentacion
{
    public partial class frmListaPersCtasCTS : frmBase
    {
        public int idCuenta = 0;
        public string cNroCuenta;
        public int idCliente = 0;
        DataTable ListaCtas;

        public frmListaPersCtasCTS()
        {
            InitializeComponent();
        }

        private void frmListaPersCtasCTS_Load(object sender, EventArgs e)
        {
            clsCNGuardaPersonal ListaSolAprob = new clsCNGuardaPersonal();
            ListaCtas = ListaSolAprob.ListarCtasCTS(idCliente);
            dtgBase1.DataSource = ListaCtas;

            dtgBase1.Columns["cNroCuenta"].Width = 45;
            dtgBase1.Columns["cNroCuenta"].HeaderText = "N° de Cuenta";
            dtgBase1.Columns["cNroCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cProducto"].Width = 40;
            dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["cProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cMoneda"].Width = 30;
            dtgBase1.Columns["cMoneda"].HeaderText = "Moneda";
            dtgBase1.Columns["cMoneda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cTipoCuenta"].Width = 30;
            dtgBase1.Columns["cTipoCuenta"].HeaderText = "Tipo de Cuenta";
            dtgBase1.Columns["cTipoCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cTipoIntervencion"].Width = 25;
            dtgBase1.Columns["cTipoIntervencion"].HeaderText = "Intervención";
            dtgBase1.Columns["cTipoIntervencion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["dFechaApertura"].Width = 30;
            dtgBase1.Columns["dFechaApertura"].HeaderText = "Fecha de Apertura";
            dtgBase1.Columns["dFechaApertura"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["idCuenta"].Visible = false;
        }
     
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);

                idCuenta = Convert.ToInt32(ListaCtas.Rows[fila]["idCuenta"].ToString());
                cNroCuenta = ListaCtas.Rows[fila]["cNroCuenta"].ToString();

            }
            this.Dispose();
        }
    }
}

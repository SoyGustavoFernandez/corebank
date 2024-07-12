using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.PrintHelper;
using GEN.Funciones;
using System.Drawing.Printing;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using SPL.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmBandejaCobroCreditos : frmBase
    {
        public int idCuentaSelect;
        private cuentaSelect objCuentaSelect;
        public frmBandejaCobroCreditos()
        {
            InitializeComponent();
            
        }

            
        public cuentaSelect getCuentaSelect()
        {
            return objCuentaSelect;
        }

        private void frmBandejaCobroCreditos_Load(object sender, EventArgs e)
        {
            objCuentaSelect = new cuentaSelect();

            clsCNCredito Credito = new clsCNCredito();
            DataTable cobros = Credito.CNCobrosCreditos(clsVarGlobal.nIdAgencia);
            dtgCobros.DataSource = cobros;
            formatearDTG();
            btnAceptar1.Enabled = false;
            if (dtgCobros.SelectedRows.Count > 0)
                btnAceptar1.Enabled = true;
        }

        private void formatearDTG()
        {
            dtgCobros.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgCobros.Columns["operacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgCobros.Columns["tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgCobros.Columns["tipoOperacion"].Visible = false;

            dtgCobros.Columns["operacion"].HeaderText = "OPERACIÓN";
            dtgCobros.Columns["tipo"].HeaderText = "TIPO";
            dtgCobros.Columns["idSolicitudAproba"].HeaderText = "SOLICITUD";
            dtgCobros.Columns["cNombre"].HeaderText = "NOMBRES Y APELLIDOS";
            dtgCobros.Columns["idCuenta"].HeaderText = "CUENTA";
            dtgCobros.Columns["moneda"].HeaderText = "";
            dtgCobros.Columns["nMonto"].HeaderText = "MONTO";
            

            dtgCobros.Columns["moneda"].Width = 30;
            dtgCobros.Columns["nMonto"].DefaultCellStyle.Format = "#,0.00";
            dtgCobros.Columns["idSolicitudAproba"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            objCuentaSelect.idCuenta = Convert.ToInt32(dtgCobros.SelectedRows[0].Cells["idCuenta"].Value);
            objCuentaSelect.idTipoOperacion = Convert.ToInt32(dtgCobros.SelectedRows[0].Cells["tipoOperacion"].Value);
            objCuentaSelect.idSolicitud = Convert.ToInt32(dtgCobros.SelectedRows[0].Cells["idSolicitudAproba"].Value);
            this.Close();
        }


    }
}

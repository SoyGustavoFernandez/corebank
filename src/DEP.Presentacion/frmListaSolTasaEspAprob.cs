using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmListaSolTasaEspAprob : frmBase
    {
        public int idCuenta = 0;
        public string cNroCuenta;
        public string cNomCliente;
        public string cDocumentoDNI;
        public string cCodCliente;
        DataTable LisSolApr;

        public frmListaSolTasaEspAprob()
        {
            InitializeComponent();
        }

        private void frmListaSolTasaEspAprob_Load(object sender, EventArgs e)
        {
            clsCNAutorTasaEsp ListaSolAprob = new clsCNAutorTasaEsp();

            LisSolApr = ListaSolAprob.ListTasaSoliciAprob();
            dtgBase1.DataSource = LisSolApr;

            dtgBase1.Columns["idSolAproba"].Width = 25;
            dtgBase1.Columns["idSolAproba"].HeaderText = "N° Solicitud";
            dtgBase1.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgBase1.Columns["cNroCuenta"].Width = 50;
            dtgBase1.Columns["cNroCuenta"].HeaderText = "N° de Cuenta";
            dtgBase1.Columns["cNroCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
            dtgBase1.Columns["cNombre"].Width = 100;
            dtgBase1.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgBase1.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["dFecAprSol"].Width = 50;
            dtgBase1.Columns["dFecAprSol"].HeaderText = "Fecha de Aprobación";
            dtgBase1.Columns["dFecAprSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                  
            dtgBase1.Columns["idDocument"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;
            dtgBase1.Columns["idCli"].Visible = false;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);

                idCuenta = Convert.ToInt32(LisSolApr.Rows[fila]["idDocument"].ToString());
                cNroCuenta = LisSolApr.Rows[fila]["cNroCuenta"].ToString();
                cDocumentoDNI = LisSolApr.Rows[fila]["cDocumentoID"].ToString();
                cCodCliente = LisSolApr.Rows[fila]["idCli"].ToString();
                cNomCliente = LisSolApr.Rows[fila]["cNombre"].ToString();
            }
            this.Dispose();
        }
    }
}

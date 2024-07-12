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
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmListSolCancAprob : frmBase
    {
        public Int32 NroCuenta=0;
        public string cNroCuenta;
        public string cNomCliente;
        public string cNomEstado;
        public string cDocumentoDNI;
        public string cCodCliente;
        
        DataTable LisSolApr = new DataTable();

        public frmListSolCancAprob()
        {
            InitializeComponent();
        }

        private void frmListSolCancAprob_Load(object sender, EventArgs e)
        {
            clsCNCondonacion ListaSolAprob = new clsCNCondonacion();

            LisSolApr = ListaSolAprob.ListSoliciAprob();
            dtgBase1.DataSource = LisSolApr;

            dtgBase1.Columns["idSolAproba"].Width = 25;
            dtgBase1.Columns["idSolAproba"].HeaderText = "N° Solicitud";
            dtgBase1.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cNroCuenta"].Width = 45;
            dtgBase1.Columns["cNroCuenta"].HeaderText = "N° de Cuenta";
            dtgBase1.Columns["cNroCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cNombre"].Width = 100;
            dtgBase1.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgBase1.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["nValAproba"].Width = 30;
            dtgBase1.Columns["nValAproba"].HeaderText = "Monto de Condonación";
            dtgBase1.Columns["nValAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                       
            dtgBase1.Columns["cEstado"].Visible = false;
            dtgBase1.Columns["idDocument"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;
            dtgBase1.Columns["cCodCliente"].Visible = false;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);
                NroCuenta = Convert.ToInt32(LisSolApr.Rows[fila]["idDocument"]);
                cNomCliente = LisSolApr.Rows[fila]["cNombre"].ToString();
                cNomEstado = LisSolApr.Rows[fila]["cEstado"].ToString();
                cNroCuenta = LisSolApr.Rows[fila]["cNroCuenta"].ToString();
                cDocumentoDNI= LisSolApr.Rows[fila]["cDocumentoID"].ToString();
                cCodCliente = LisSolApr.Rows[fila]["cCodCliente"].ToString();
            }
            this.Dispose();
        }
    }
}

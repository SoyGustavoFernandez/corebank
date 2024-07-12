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
    public partial class frmListSolicitudCTS : frmBase
    {
        public int idCliente = 0;
        public string cNomCliente;
        public string cDocumentoDNI;
        public string cCodCliente;
        public string cDireccion;
        public int idCodEmpTrabajo = 0;
        public string cCodEmpresa;
        public string cNombreEmp;
        public string cDocumentoEmp;
        public string cDireccionEmp;

        DataTable LisSolApr;

        public frmListSolicitudCTS()
        {
            InitializeComponent();
        }

        private void frmListSolicitCTS_Load(object sender, EventArgs e)
        {
            clsCNSolicCTS ListaSolPend = new clsCNSolicCTS();

            LisSolApr = ListaSolPend.ListSoliciPend();
            dtgBase1.DataSource = LisSolApr;

            dtgBase1.Columns["idSolCTS"].Width = 25;
            dtgBase1.Columns["idSolCTS"].HeaderText = "N° Solicitud";
            dtgBase1.Columns["idSolCTS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cNombre"].Width = 100;
            dtgBase1.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgBase1.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["cNombreCorto"].Width = 50;
            dtgBase1.Columns["cNombreCorto"].HeaderText = "Entidad Financiera";
            dtgBase1.Columns["cNombreCorto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["idCodEmpTrabajo"].Width = 50;
            dtgBase1.Columns["idCodEmpTrabajo"].HeaderText = "N° de Cuenta";
            dtgBase1.Columns["idCodEmpTrabajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBase1.Columns["idCli"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;
            dtgBase1.Columns["cCodCliente"].Visible = false;
            dtgBase1.Columns["cDireccion"].Visible = false;
            dtgBase1.Columns["dFechaSolic"].Visible = false;
            dtgBase1.Columns["cCodEmpresa"].Visible = false;
            dtgBase1.Columns["cNombreEmp"].Visible = false;
            dtgBase1.Columns["cDocumentoEmp"].Visible = false;
            dtgBase1.Columns["cDireccionEmp"].Visible = false;


        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);

                idCliente = Convert.ToInt32(LisSolApr.Rows[fila]["idCli"].ToString());

                cDireccion = LisSolApr.Rows[fila]["cDireccion"].ToString();
                cDocumentoDNI = LisSolApr.Rows[fila]["cDocumentoID"].ToString();
                cCodCliente = LisSolApr.Rows[fila]["cCodCliente"].ToString();
                cNomCliente = LisSolApr.Rows[fila]["cNombre"].ToString();

                idCodEmpTrabajo = Convert.ToInt32(LisSolApr.Rows[fila]["idCodEmpTrabajo"].ToString());

                cDireccionEmp = LisSolApr.Rows[fila]["cDireccionEmp"].ToString();
                cDocumentoEmp = LisSolApr.Rows[fila]["cDocumentoEmp"].ToString();
                cCodEmpresa = LisSolApr.Rows[fila]["cCodEmpresa"].ToString();
                cNombreEmp = LisSolApr.Rows[fila]["cNombreEmp"].ToString();



            }
            this.Dispose();
        }
    }
}

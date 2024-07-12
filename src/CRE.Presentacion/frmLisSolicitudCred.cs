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
    public partial class frmLisSolicitudCred : frmBase
    {
        public Int32 nNumSolicitud = 0;
        public string cNomCliente;
        public string cNomEstado, idCliente, cDocumentoID;
        DataTable LisSolicitudes = new DataTable();

        public frmLisSolicitudCred()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsCNPlanPago PlanPago = new clsCNPlanPago();      
            int idEstado = 1;
            LisSolicitudes = PlanPago.CNdtSolAprobadas(clsVarGlobal.nIdAgencia, idEstado);
            dtgBase1.DataSource = LisSolicitudes;

            dtgBase1.Columns["idSolicitud"].HeaderText = "N° Sol.";
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["nCapitalSolicitado"].HeaderText = "Monto Sol.";
            dtgBase1.Columns["nCuotas"].HeaderText = "Num cuotas";
            dtgBase1.Columns["dFechaRegistro"].HeaderText = "Fech. Sol.";
            dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["cEstado"].HeaderText = "Estado";
            dtgBase1.Columns["cCodCliente"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.CurrentCell != null)
            {
                Int32 fila = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);
                nNumSolicitud = Convert.ToInt32(LisSolicitudes.Rows[fila]["idSolicitud"]);
                cNomCliente = LisSolicitudes.Rows[fila]["cNombre"].ToString();
                cNomEstado = LisSolicitudes.Rows[fila]["cEstado"].ToString();
                idCliente = LisSolicitudes.Rows[fila]["cCodCliente"].ToString();
                cDocumentoID = LisSolicitudes.Rows[fila]["cDocumentoID"].ToString();
                this.Dispose();
            }
            else
            {
                nNumSolicitud = 0;
            }
        }
    }
}

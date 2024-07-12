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
    public partial class frmLisSolReaprob : frmBase
    {
        public Int32 nNumSolicitud = 0;
        public string cNomCliente;
        public string cNomEstado;
        public string cNomAsesor;
        public string cDocumentoID;
        public DateTime dFechaHoraAprob;
        public string idCliente;
        private DataTable LisSolApr = new DataTable();

        public frmLisSolReaprob()
        {
            InitializeComponent();
        }

        private void frmLisSolReaprob_Load(object sender, EventArgs e)
        {
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            clsCNReaprobSol cnReaprobSol = new clsCNReaprobSol();
            int idEstado = 2;

            LisSolApr = cnReaprobSol.obtenerSolReaprob(idEstado, clsVarGlobal.User.idUsuario);
            dtgBase1.DataSource = LisSolApr;

            dtgBase1.Columns["idSolicitud"].HeaderText = "N° Sol.";
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["nCapitalSolicitado"].HeaderText = "Monto Sol.";
            dtgBase1.Columns["cOperacion"].HeaderText = "Tipo Ope.";
            dtgBase1.Columns["nCuotas"].HeaderText = "Num cuotas";
            dtgBase1.Columns["dFechaRegistro"].HeaderText = "Fech. Sol.";
            dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            //dtgBase1.Columns["cEstado"].HeaderText = "Estado";
            //dtgBase1.Columns["cCodCliente"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.SelectedRows.Count > 0)
            {
                DataRowView dr = dtgBase1.SelectedRows[0].DataBoundItem as DataRowView;
                nNumSolicitud = Convert.ToInt32(dr["idSolicitud"]);
                cNomCliente = dr["cNombre"].ToString();
                cNomAsesor = dr["cNomAsesor"].ToString();
                cDocumentoID = dr["cDocumentoID"].ToString();
                dFechaHoraAprob = Convert.ToDateTime(dr["dFechaHoraAprob"]);
                idCliente = dr["cCodCliente"].ToString();
                //idCliente = dr["cCodCliente"].ToString();
                
                this.Dispose();
            }
            else
            {
                nNumSolicitud = 0;
            }
        }

    }
}

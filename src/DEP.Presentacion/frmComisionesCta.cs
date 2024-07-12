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
using EntityLayer;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmComisionesCta : frmBase
    {
        public DataTable dtCom;
        public frmComisionesCta()
        {
            InitializeComponent();
        }

        private void frmComisionesCta_Load(object sender, EventArgs e)
        {
            dtgComisionCta.DataSource = dtCom;
            formatoGrid();
            if (dtCom.Rows.Count>0)
            {
                txtComision.Text = dtCom.Compute("SUM(nValorAplica)", "").ToString();
            }
            else
            {
                txtComision.Text = "0.00";
            }           
        }

        //--===========================================================
        //--Formato Grid
        //--===========================================================
        public void formatoGrid()
        {//idConfigGastComiSeg,idConcepto,cNombreCorto,nValorAplica,lAplicaContable,lAplicaImpreOpe
            dtgComisionCta.Columns["idConfigGastComiSeg"].Visible = false;
            dtgComisionCta.Columns["lAplicaContable"].Visible = false;
            dtgComisionCta.Columns["lAplicaImpreOpe"].Visible = false;

            dtgComisionCta.Columns["idConcepto"].HeaderText = "ID";
            dtgComisionCta.Columns["idConcepto"].Width = 40;
            dtgComisionCta.Columns["cNombreCorto"].HeaderText = "CONCEPTO";
            dtgComisionCta.Columns["cNombreCorto"].Width = 300;
            dtgComisionCta.Columns["nValorAplica"].HeaderText = "MONTO";
            //dtgComisionCta.Columns["nValorAplica"].Width = 300;
        }
    }
}

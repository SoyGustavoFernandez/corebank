using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmReasignarClienteAprobado : frmBase
    {
        String cDocumentoID;
        clsCNCredito cnCredito = new clsCNCredito();
        DataTable dtReasignarCliente = new DataTable();

        ToolTip ttMensaje = new ToolTip();

        public frmReasignarClienteAprobado()
        {
            InitializeComponent();
        }
        public frmReasignarClienteAprobado(String DNICli, String cNombreCli, DataTable dtAsesor)
        {
            InitializeComponent();

            cDocumentoID = DNICli;
            dtAsesor.Rows.RemoveAt(0);

            DataRow row = dtAsesor.NewRow();
            row[0] = 0;
            row[1] = "";
            dtAsesor.Rows.InsertAt(row, 0);

            txtNomCli.Text = cNombreCli;
            txtNomCli.ReadOnly = true;

            cboAsesor.ValueMember = "idUsuario";
            cboAsesor.DisplayMember = "cNombre";
            cboAsesor.DataSource = dtAsesor;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ReasignarCliente();
            cboAsesor.Enabled = false;
        }
        private void ReasignarCliente()
        {
            dtReasignarCliente = cnCredito.CNReasignarCliente(cDocumentoID, Convert.ToInt32(cboAsesor.SelectedValue.ToString()));
        }

        private void txtNomCli_MouseHover(object sender, EventArgs e)
        {
            ttMensaje.Show(txtNomCli.Text, txtNomCli, 0, 25, 3000);
            
        }
    }
}

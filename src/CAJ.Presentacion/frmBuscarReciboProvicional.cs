using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmBuscarReciboProvicional : frmBase
    {
        public String cNombres;
        public String cTitular;
        public String cSustento;
        public String nMonto;
        public int 
                    idReciboProvisional,
                    idTipRecibo,
                    idConceptoRec,
                    idMoneda,
                    idUsu,
                    idCli,
                    idTipoPersona;

        DataTable tabla_CliRecibosProvicional;

        clsCNReciboProvicional listarReciboProvicional = new clsCNReciboProvicional();
         
        public frmBuscarReciboProvicional()
        {
            InitializeComponent();
            txtNroRecibo.Enabled = false;
            btnBusqueda1.Enabled = false;
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCol.idCliPer == null)
            {
                return;
            }

            if (conBusCol.idCliPer.Trim() == "")
            {
                return;
            }            

            int nidUsu = Convert.ToInt32(conBusCol.idUsu);

            tabla_CliRecibosProvicional = listarReciboProvicional.listar(nidUsu, 2);
            dtgClientes.Columns.Clear();

            tabla_CliRecibosProvicional.Columns["idReciboProvisional"].SetOrdinal(0);
            tabla_CliRecibosProvicional.Columns["cDocumentoID"].SetOrdinal(1);
            tabla_CliRecibosProvicional.Columns["cTitular"].SetOrdinal(2);

            dtgClientes.DataSource = tabla_CliRecibosProvicional;
            

            if (dtgClientes.RowCount == 0)
            {
                MessageBox.Show("No se ha encontrado datos");
                return;
            }

            txtNroRecibo.Enabled = true;
            btnBusqueda1.Enabled = true;

            formatDataTableClientes();
            this.dtgClientes.Focus(); 
        }
        
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (txtNroRecibo.Text.Length > 0)
            {
                int r = tabla_CliRecibosProvicional.Select("idReciboProvisional = " + txtNroRecibo.Text, "idReciboProvisional DESC").Length;

                if (r == 0)
                {
                    MessageBox.Show("No se encontró resultados para el número de recibo ingresado.");
                    return;
                }
                DataTable tablaFilter = tabla_CliRecibosProvicional.Select("idReciboProvisional = " + txtNroRecibo.Text, "idReciboProvisional DESC").CopyToDataTable();

                dtgClientes.Columns.Clear();
                dtgClientes.DataSource = tablaFilter;
                formatDataTableClientes();
                this.dtgClientes.Focus();
            }
            else
            {
                return;
            }
        }

        private void formatDataTableClientes()
        {

            foreach (DataGridViewColumn column in dtgClientes.Columns) {
                column.Visible = false;
            }

            dtgClientes.Columns["idReciboProvisional"].Visible = true;
            dtgClientes.Columns["cDocumentoID"].Visible = true;
            dtgClientes.Columns["cTitular"].Visible = true;
            dtgClientes.Columns["cNombres"].Visible = true;
          //  dtgClientes.Columns["cTipoPersona"].Visible = true;
            dtgClientes.Columns["nMonto"].Visible = true;
            dtgClientes.Columns["cMoneda"].Visible = true;

            dtgClientes.Columns["idReciboProvisional"].HeaderText = "Nro. recibo Provisional";
            dtgClientes.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            dtgClientes.Columns["cTitular"].HeaderText = "Nombre del titular";
            dtgClientes.Columns["cNombres"].HeaderText = "Persona que realizó el pago";
            dtgClientes.Columns["nMonto"].HeaderText = "Monto";
            dtgClientes.Columns["cMoneda"].HeaderText = "Moneda";

            dtgClientes.Columns["idReciboProvisional"].Width = 70;
            dtgClientes.Columns["cDocumentoID"].Width = 70;
            dtgClientes.Columns["cTitular"].Width = 250;
            dtgClientes.Columns["cNombres"].Width = 350;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgClientes.CurrentRow != null && dtgClientes.Rows.Count > 0)
            {
                cNombres = Convert.ToString(dtgClientes.CurrentRow.Cells["cNombres"].Value);
                nMonto = Convert.ToString(dtgClientes.CurrentRow.Cells["nMonto"].Value);
                idTipRecibo = Convert.ToInt32(dtgClientes.CurrentRow.Cells["idTipRecibo"].Value);
                idConceptoRec = Convert.ToInt32(dtgClientes.CurrentRow.Cells["idConceptoRec"].Value);
                idMoneda = Convert.ToInt32(dtgClientes.CurrentRow.Cells["idMoneda"].Value);
                idCli = Convert.ToInt32(dtgClientes.CurrentRow.Cells["idCli"].Value);
                idReciboProvisional = Convert.ToInt32(dtgClientes.CurrentRow.Cells["idReciboProvisional"].Value);
                cSustento = Convert.ToString(dtgClientes.CurrentRow.Cells["cSustento"].Value);
                this.DialogResult = DialogResult.OK;
            }            
            this.Dispose();
        }

        private void txtNroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBusqueda1.PerformClick();
            }
        }



       

    }
}

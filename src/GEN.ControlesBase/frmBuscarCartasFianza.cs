using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmBuscarCartasFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        public int idSolicitud { get; set; }
        public bool lAceptar = false;
        public frmBuscarCartasFianza()
        {
            InitializeComponent();
            idSolicitud = 0;
        }

        public void cargarCartasFianza(int idEstado)
        {
            DataTable dtCartasFianza = cnCartaFianza.listarCartasFianza(idEstado);
            dtgCartaFianza.DataSource = dtCartasFianza;

            foreach (DataGridViewColumn columna in dtgCartaFianza.Columns)
            {
                columna.Visible = false;
            }
            dtgCartaFianza.Columns["idSolicitud"].Visible = true;
            dtgCartaFianza.Columns["idCli"].Visible = true;
            dtgCartaFianza.Columns["cNombre"].Visible = true;
            dtgCartaFianza.Columns["idCli"].HeaderText = "Codigo Cliente";
            dtgCartaFianza.Columns["idCli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgCartaFianza.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgCartaFianza.Columns["idSolicitud"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgCartaFianza.Columns["idCli"].Width = 80;
            dtgCartaFianza.Columns["cNombre"].HeaderText = "Nombres";
            dtgCartaFianza.Columns["cNombre"].Width = 180;
            dtgCartaFianza.Columns["idSolicitud"].HeaderText = "N° de Solicitud";
            dtgCartaFianza.Columns["idSolicitud"].Width = 80;
            switch (idEstado)
            {
                case 1:
                    dtgCartaFianza.Columns["cMonedaSolicitud"].Visible = true;
                    dtgCartaFianza.Columns["nMontoSolicitado"].Visible = true;
                    dtgCartaFianza.Columns["cMonedaSolicitud"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["nMontoSolicitado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["cMonedaSolicitud"].HeaderText = "Moneda";
                    dtgCartaFianza.Columns["nMontoSolicitado"].HeaderText = "Monto Solicitado";
                    dtgCartaFianza.Columns["cMonedaSolicitud"].Width = 60;
                    dtgCartaFianza.Columns["nMontoSolicitado"].Width = 80;
                    break;
                case 2:
                    dtgCartaFianza.Columns["cMonedaSolicitud"].Visible = true;
                    dtgCartaFianza.Columns["nMontoPropuesto"].Visible = true;

                    dtgCartaFianza.Columns["cMonedaSolicitud"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["nMontoPropuesto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["cMonedaSolicitud"].HeaderText = "Moneda";
                    dtgCartaFianza.Columns["nMontoPropuesto"].HeaderText = "Monto Propuesto";
                    dtgCartaFianza.Columns["cMonedaSolicitud"].Width = 60;
                    dtgCartaFianza.Columns["nMontoPropuesto"].Width = 80;

                   
                    break;
                case 3:
                case 4:
                    dtgCartaFianza.Columns["cMonedaAprobada"].Visible = true;
                    dtgCartaFianza.Columns["nMontoAprobado"].Visible = true;
                    dtgCartaFianza.Columns["cMonedaAprobada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["nMontoAprobado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["cMonedaAprobada"].HeaderText = "Moneda";
                    dtgCartaFianza.Columns["nMontoAprobado"].HeaderText = "Monto Aprobado";
                    dtgCartaFianza.Columns["cMonedaAprobada"].Width = 60;
                    dtgCartaFianza.Columns["nMontoAprobado"].Width = 80;

                    
                    break;
                case 5:
                    dtgCartaFianza.Columns["cMonedaAprobada"].Visible = true;
                    dtgCartaFianza.Columns["nMontoAprobado"].Visible = true;
                    dtgCartaFianza.Columns["cMonedaAprobada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["nMontoAprobado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dtgCartaFianza.Columns["cMonedaAprobada"].HeaderText = "Moneda";
                    dtgCartaFianza.Columns["nMontoAprobado"].HeaderText = "Monto Aprobado";
                    dtgCartaFianza.Columns["cMonedaAprobada"].Width = 60;
                    dtgCartaFianza.Columns["nMontoAprobado"].Width = 80;
                    break;
            }
            btnAceptar1.Enabled = (dtgCartaFianza.Rows.Count > 0);

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgCartaFianza.Rows.Count <= 0)
            {
                idSolicitud = 0;
            }
            lAceptar = true;
            this.Dispose();
        }

        private void dtgCartaFianza_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idSolicitud = Convert.ToInt32(dtgCartaFianza.Rows[e.RowIndex].Cells["idSolicitud"].Value);
        }
    }
}

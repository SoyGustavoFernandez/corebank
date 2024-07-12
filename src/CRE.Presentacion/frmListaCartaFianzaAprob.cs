using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmListaCartaFianzaAprob : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        DataTable dtCartasFianza = new DataTable();
        public int idCartaFianzaSeleccionada { get; set; }
        public int idSolAproba { get; set; }
        public int idSolicitudCF { get; set; }
        int idTipoAprobacion = 0;
        public bool lAceptar = false;
        public frmListaCartaFianzaAprob()
        {
            InitializeComponent();
        }

        public frmListaCartaFianzaAprob(int idTipoAprobacion)
        {
            InitializeComponent();
            this.idTipoAprobacion = idTipoAprobacion;
        }

        private void frmListaCartaFianzaAprob_Load(object sender, EventArgs e)
        {
            if (idTipoAprobacion == 1)
            {
                dtCartasFianza = cnCartaFianza.listarCartasFianzaAprobadas(clsVarGlobal.PerfilUsu.idUsuario);
            }
            else if (idTipoAprobacion == 2) 
            {
                dtCartasFianza = cnCartaFianza.listarReimpresionCartasFianzaAprobadas(clsVarGlobal.PerfilUsu.idUsuario);
            }
            if (dtCartasFianza.Rows.Count > 0)
            {
                dtgCartasFianza.DataSource = dtCartasFianza;
            }
            else
            {
                btnAceptar1.Enabled = false;
            }     
        }

        private void dtgCartasFianza_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCartaFianzaSeleccionada = Convert.ToInt32(dtgCartasFianza.Rows[e.RowIndex].Cells["idCartaFianza"].Value);
                idSolAproba = Convert.ToInt32(dtgCartasFianza.Rows[e.RowIndex].Cells[0].Value);
                idSolicitudCF = Convert.ToInt32(dtgCartasFianza.Rows[e.RowIndex].Cells["idSolicitud"].Value);
                btnAceptar1.Enabled = (Convert.ToInt32(dtgCartasFianza.Rows[e.RowIndex].Cells["idEstadoSol"].Value)==2);
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            idCartaFianzaSeleccionada = 0;
            idSolAproba = 0;
            this.Dispose();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtCartasFianza.Rows.Count < 0)
            {
                return;
            }
            lAceptar = true;
            this.Dispose();
        }
    }
}

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
using EntityLayer;

namespace ADM.Presentacion
{  
    public partial class frmBuscarSolicitudApr : frmBase
    {
        public int pidMod, pidKardex, pidSolExt,pidTipOpe,pidUsario,pidAgencia;
        public string pcEstKardex,pcSustento="";

        public frmBuscarSolicitudApr()
        {
            InitializeComponent();
        }

        private void frmBuscarSolicitudApr_Load(object sender, EventArgs e)
        {
            CargarDatosSolExt(pidMod, pidTipOpe, pidUsario, 0);  //Parametri 1 --> Id del Modulo, 2--> Tipo Operación del Módulo
            FormatoGrid();
        }

        private void CargarDatosSolExt(int idModulo, int idTipOpe,int idUsario,int idAgencia)
        { 
            clsCNAprobacion objExt = new clsCNAprobacion();
            DataTable tbApr = objExt.LListarSolicitudesAprobadas(idTipOpe, idUsario, idAgencia);
            btnAceptar.Enabled = false;
            this.dtgSolicitudes.DataSource = tbApr;
            if (tbApr.Rows.Count>0)
            {
                btnAceptar.Enabled = true;
            }
        }

        private void FormatoGrid()
        {
            this.dtgSolicitudes.Columns["cEstadoKardex"].Visible = false;
            this.dtgSolicitudes.Columns["cSustento"].Visible = false;
            this.dtgSolicitudes.Columns["idSolAproba"].HeaderText = "Solicitud";
            this.dtgSolicitudes.Columns["idSolAproba"].Width = 10;
            this.dtgSolicitudes.Columns["dFecAprSol"].HeaderText = "Fec.Aprobación";
            this.dtgSolicitudes.Columns["dFecAprSol"].Width = 13;
            this.dtgSolicitudes.Columns["IdKardex"].HeaderText = "Nro Operación";
            this.dtgSolicitudes.Columns["IdKardex"].Width = 10;
            this.dtgSolicitudes.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgSolicitudes.Columns["cMoneda"].Width = 7;
            this.dtgSolicitudes.Columns["nMontoOperacion"].HeaderText = "Monto Operación";
            this.dtgSolicitudes.Columns["nMontoOperacion"].Width = 10;
            this.dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            this.dtgSolicitudes.Columns["cNombre"].Width = 25;
            this.dtgSolicitudes.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgSolicitudes.Columns["cTipoOperacion"].Width = 25;
            this.dtgSolicitudes.Columns["dFecHoraOpe"].Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgSolicitudes.RowCount > 0)
            {
                pidKardex = Convert.ToInt32(dtgSolicitudes.Rows[dtgSolicitudes.SelectedCells[0].RowIndex].Cells["IdKardex"].Value.ToString());
                pidSolExt = Convert.ToInt32(dtgSolicitudes.Rows[dtgSolicitudes.SelectedCells[0].RowIndex].Cells["idSolAproba"].Value.ToString());
                pcEstKardex = dtgSolicitudes.Rows[dtgSolicitudes.SelectedCells[0].RowIndex].Cells["cEstadoKardex"].Value.ToString();
                pcSustento = dtgSolicitudes.Rows[dtgSolicitudes.SelectedCells[0].RowIndex].Cells["cSustento"].Value.ToString();
            }
            else
            {
                pidKardex = 0;
                pidSolExt = 0;
                pcEstKardex = "";
                pcSustento = "";
            }

            this.Dispose();
        }

        private void dtgSolExt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgSolExt_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }
    }
}

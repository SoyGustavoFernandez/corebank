using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmSeleccionarHojaRuta : frmBase
    {
        public int idHojaRutaSeleccinada = -1;
        public bool lAceptar = false;
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        private int _idUsuario;

        public frmSeleccionarHojaRuta()
        {
            InitializeComponent();            
        }

        public frmSeleccionarHojaRuta(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void chbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodos.Checked)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
            else
            {
                dtpDesde.Value = clsVarGlobal.dFecSystem;
                dtpHasta.Value = clsVarGlobal.dFecSystem;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;            
            }
        }

        private void cargar(DateTime dDesde, DateTime dA)
        {
            DataTable dtHojasRuta = cnHojaRuta.ListaHojasRuta(_idUsuario, dDesde, dA);
            dtgCreditos.DataSource = dtHojasRuta;
            idHojaRutaSeleccinada = 0;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (idHojaRutaSeleccinada >= 0)
            {
                idHojaRutaSeleccinada = dtgCreditos.SelectedRows.Count > 0 ? Convert.ToInt32(dtgCreditos.SelectedRows[0].Cells["idHojaRuta"].Value) : 0;
                
                lAceptar = true;
                this.Dispose();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            idHojaRutaSeleccinada = 0;
            lAceptar = false;
            this.Dispose();
        }

        private void frmSeleccionarHojaRuta_Load(object sender, EventArgs e)
        {
            dtgCreditos.AutoGenerateColumns = false;
            chbTodos.Checked = true;
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (chbTodos.Checked)
            {
                cargar(Convert.ToDateTime("2000-01-01"), Convert.ToDateTime("3000-01-01"));                
            }
            else
            {
                cargar(Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
            }           
        }        
    }
}

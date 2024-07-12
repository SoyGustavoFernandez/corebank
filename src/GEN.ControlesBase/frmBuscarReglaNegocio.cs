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
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBuscarReglaNegocio : frmBase
    {
        #region Variables Globales
        private clsCNValidaReglasDinamicas objCNValidarReglaNeg;
        private List<clsReglaNegocio> lstReglaNegocio;
        public clsReglaNegocio objReglaNegocio;

        private string cNombreForm;
        private int idMetodoBusq;
        private List<int> lstIdReglaExclude = new List<int>();
        private int idSolicitud;
        #endregion

        #region Metodos
        public frmBuscarReglaNegocio()
        {
            InitializeComponent();
            this.inicicalizarFormulario();
        }
        
        public frmBuscarReglaNegocio(int idSolicitud, string cNombreForm, int idMetodoBusq = 1/*Reglas del Formulario*/, List<int> lstIdReglaExclude = null)
        {
            InitializeComponent();
            this.idSolicitud = idSolicitud;
            this.cNombreForm = cNombreForm;
            this.idMetodoBusq = idMetodoBusq;
            if (lstIdReglaExclude != null)
                this.lstIdReglaExclude = lstIdReglaExclude;
            this.inicicalizarFormulario();
        }

        public void inicicalizarFormulario()
        {
            this.objCNValidarReglaNeg = new clsCNValidaReglasDinamicas();
            this.lstReglaNegocio = new List<clsReglaNegocio>();
            this.objReglaNegocio = new clsReglaNegocio();
            this.bsReglaNegocio.DataSource = this.lstReglaNegocio;
        }

        private void buscarReglaNegocio(int idRegla)
        {
            this.lstReglaNegocio.Clear();
            List<clsReglaNegocio> lstTmp = this.objCNValidarReglaNeg.buscarReglaNegocio(idRegla, this.cNombreForm, this.idMetodoBusq, this.idSolicitud);
            this.lstReglaNegocio.AddRange(lstTmp.FindAll(x => x.nIdRegla != this.lstIdReglaExclude.Find(e => e == x.nIdRegla)));
            if (this.lstReglaNegocio.Count > 0)
            {
                this.btnAceptar.Enabled = true;
            }
            else
            {
                this.btnAceptar.Enabled = false;
                switch(idMetodoBusq)
                {
                    case 4:
                        MessageBox.Show("¡No se ha encontrado ninguna Regla Manual Excepcionable para agregar a este formulario!\n",
                            "No se encontró ninguna Reglas Excepcionables", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("¡No se ha encontrado ninguna regla con el código para agregar por el método de " + cboMetodoBusqueda.Text
                        + "!\n", "No se encontró ninguna Reglas Excepcionables", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            this.bsReglaNegocio.ResetBindings(false);
            this.dtgReglaNegocio.Refresh();
        }

        private void metodoBusqueda()
        {
            switch (idMetodoBusq)
            {
                case 1:
                    this.txtIdRegla.Visible = true;
                    this.btnBusqueda.Visible = true;
                    this.lblNroRegla.Visible = true;
                    break;
                case 2:
                    this.txtIdRegla.Visible = false;
                    this.btnBusqueda.Visible = false;
                    this.lblNroRegla.Visible = false;
                    this.buscarReglaNegocio(0);
                    break;
                case 3:
                    this.txtIdRegla.Visible = true;
                    this.btnBusqueda.Visible = true;
                    this.lblNroRegla.Visible = true;
                    break;
                case 4:
                    this.lblNroRegla.Visible = false;
                    this.txtIdRegla.Visible = false;
                    this.btnBusqueda.Visible = false;
                    this.lblNroRegla.Visible = false;
                    this.buscarReglaNegocio(0);
                    break;
                default:
                    this.txtIdRegla.Visible = false;
                    this.btnBusqueda.Visible = false;
                    this.lblNroRegla.Visible = false;
                    break;
            }
        }
        #endregion

        #region Eventos
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!this.txtIdRegla.Text.Trim().Equals(string.Empty))
            {
                this.buscarReglaNegocio(Convert.ToInt32(this.txtIdRegla.Text));
            }
        }

        private void dtgReglaNegocio_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgReglaNegocio.SelectedRows.Count > 0)
            {
                int nIndice = this.dtgReglaNegocio.SelectedRows[0].Index;
                this.objReglaNegocio = this.lstReglaNegocio[nIndice];
            }
            else
            {
                this.objReglaNegocio = new clsReglaNegocio();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.objReglaNegocio = new clsReglaNegocio();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdRegla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!this.txtIdRegla.Text.Trim().Equals(string.Empty))
                {
                    this.buscarReglaNegocio(Convert.ToInt32(this.txtIdRegla.Text));
                }
            }
        }      

        private void cboMetodoBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.idMetodoBusq = this.cboMetodoBusqueda.SelectedIndex;
            this.metodoBusqueda();
        }

        private void frmBuscarReglaNegocio_Load(object sender, EventArgs e)
        {
            this.cboMetodoBusqueda.SelectedIndex = this.idMetodoBusq;
            this.metodoBusqueda();
            switch (this.idMetodoBusq)
            {
                case 4: // Reglas delFormulario y Manuales
                    this.cboMetodoBusqueda.Enabled = false;
                    if (this.lstReglaNegocio.Count == 0)
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

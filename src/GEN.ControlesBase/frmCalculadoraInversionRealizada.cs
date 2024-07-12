using EntityLayer;
using GEN.BotonesBase;
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
    public partial class frmCalculadoraInversionRealizada : frmBase
    {
        #region Variables

        private List<clsInversionInsumo> lstInversionInsumo;
        private Guid idIngresosEstacional;

        #endregion


        #region Metodos Publicos

        public frmCalculadoraInversionRealizada(List<clsInversionInsumo> listaInsumo, Guid _idIngresoEstacional)
        {
            this.lstInversionInsumo = new List<clsInversionInsumo>();
            this.lstInversionInsumo = listaInsumo;
            this.idIngresosEstacional = _idIngresoEstacional;

            InitializeComponent();

            this.txtCultivo.Enabled = false;
            this.txtParcela.Enabled = false;
            this.txtVariedad.Enabled= false;
        }

        public void EstablecerDatosInsumo(string cultivo, string variedad, string parcela )
        {
            this.txtCultivo.Text = cultivo;
            this.txtVariedad.Text = variedad;
            this.txtParcela.Text = parcela;
        }

        public List<clsInversionInsumo> ObtenerInversionInsumos()
        {
            return this.lstInversionInsumo;
        }

        #endregion


        #region Metodos Privados

        private void RecuperarDetallInversionRealizada()
        {
            this.conCalculadoraInversionRealizada.AsignarDatos(this.lstInversionInsumo, this.idIngresosEstacional);
        }

        #endregion


        #region Eventos

        private void frmCalculadoraInversionRealizada_Load(object sender, EventArgs e)
        {
            RecuperarDetallInversionRealizada();
        }

        private void btnAceptar_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCalculadoraInversionRealizada_FormClosing(object sender, FormClosingEventArgs e)
        {
            var listaInsumos = this.conCalculadoraInversionRealizada.ObtenerListaInversionesInsumo();
            this.lstInversionInsumo = listaInsumos;
        }

        #endregion

        
    }
}

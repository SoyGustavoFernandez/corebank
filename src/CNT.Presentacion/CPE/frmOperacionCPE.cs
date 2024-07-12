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
using CNT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmOperacionCPE : frmBase
    {

        #region Variable globales

        private const string _titulo = "Búsqueda de comprobante CPE";
        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        #endregion

        #region Constructores

        public frmOperacionCPE()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarBuscar())
                return;

            var idKardex = Convert.ToInt32(NudNroOperacion.Value);

            var res = _cnComprobantePagoElectronico.BuscarOperacionPorKardex(idKardex);

            if (res == null)
            {
                MessageBox.Show("El número de operación no se encuentra vinculado a ningún comprobante CPE", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Habilitar(false);

            TxtSerie.Text = res.Serie;
            TxtNumero.Text = res.Correlativo.ToString();
            TxtEstado.Text = res.DescripcionEstadoCPE;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            NudNroOperacion.Value = 0;
            TxtSerie.Text = string.Empty;
            TxtNumero.Text = string.Empty;
            TxtEstado.Text = string.Empty;

            Habilitar(true);
        }

        #endregion

        #region Metodos

        private bool ValidarBuscar()
        {
            if (NudNroOperacion.Value == 0)
            {
                MessageBox.Show("Ingrese un número mayor a 0", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Habilitar(bool habilitar)
        {
            NudNroOperacion.Enabled = habilitar;
            BtnBuscar.Enabled = habilitar;
            BtnCancelar.Enabled = !habilitar;
        }

        #endregion
    }
}

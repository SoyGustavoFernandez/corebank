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
    public partial class frmFinalizarRegResultadosHojaRuta : frmBase
    {
        public int idHojaRuta = 0;
        public bool lFinalizado = false;
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        public Decimal nKilometroInicial = 0.00M;

        public frmFinalizarRegResultadosHojaRuta()
        {
            InitializeComponent();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = cnHojaRuta.finalizarGestionHojaRuta(idHojaRuta, Convert.ToInt32(txtKilometrajeFinal.Text));
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Finalización registrada correctamente", "Gestión Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lFinalizado = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Error al registrar finalizacion: " + dtResultado.Rows[0][1], "Gestión Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
        private bool validar()
        { 
            if (txtKilometrajeFinal.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar kilometraje final", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtKilometrajeFinal.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtKilometrajeFinal.Text) < nKilometroInicial)
            {
                MessageBox.Show("El kilometraje final no puede ser menor al kilometraje inicial", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtKilometrajeFinal.Focus();
                return false;            
            }
            return true;
        }

        private void frmFinalizarRegResultadosHojaRuta_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}

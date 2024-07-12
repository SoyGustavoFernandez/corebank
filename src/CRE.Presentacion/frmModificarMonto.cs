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

namespace CRE.Presentacion
{
    public partial class frmModificarMonto : frmBase
    {
        public decimal nMontoModificado;
        public decimal nMontoMax = 0;
        public int idFrm = 0;
        public frmModificarMonto(decimal nMonto, decimal _nMontoMax,int _idFrm)
        {
            InitializeComponent();
            this.nudMonto.Value = nMonto;
            nMontoModificado = nMonto;
            nMontoMax = _nMontoMax;
            idFrm = _idFrm;
            lblMontoMaximo.Text = "Monto máximo: " + nMontoMax.ToString("N2");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (this.nudMonto.Value > nMontoMax)
            {
                if (idFrm == 1) //evaluacion
                {
                    MessageBox.Show("El monto ingresado no podrá ser mayor al monto Solicitado.", "Modificación de Monto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (idFrm == 2) // aprobacion
                {
                    MessageBox.Show("El monto ingresado no podrá ser mayor al monto Propuesto.", "Modificación de Monto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            nMontoModificado = this.nudMonto.Value;
            this.Dispose();
        }
    }
}

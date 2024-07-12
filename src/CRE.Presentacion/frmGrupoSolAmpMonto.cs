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
    public partial class frmGrupoSolAmpMonto : Form
    {
        public decimal nMonto;
        private decimal nSaldoCapital;
        public bool lAceptado;
        public frmGrupoSolAmpMonto()
        {
            InitializeComponent();
            this.nMonto = decimal.Zero;
            this.nSaldoCapital = decimal.Zero;
            this.lAceptado = false;
        }
        public frmGrupoSolAmpMonto(decimal nSaldoCapital, decimal nMonto)
        {
            InitializeComponent();
            this.nMonto = nMonto;
            this.nSaldoCapital = nSaldoCapital;
            this.lAceptado = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.nSaldoCapital > this.nudMonto.Value)
            {
                MessageBox.Show("¡El MONTO no puede ser menor al SALDO CAPITAL!","MONTO INCORRECTO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.nMonto = this.nudMonto.Value;
            this.lAceptado = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.lAceptado = false;
            this.Close();
        }

        private void frmGrupoSolAmpMonto_Load(object sender, EventArgs e)
        {
            this.txtSaldoCapital.Text = this.nSaldoCapital.ToString();
            this.nudMonto.Value = this.nMonto;
            this.nudMonto.Focus();            
        }
    }
}

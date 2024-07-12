using GEN.ControlesBase;

namespace SER.Presentacion
{
    public partial class frmGiroIngresoClave : frmBase
    {
        #region Variables
        public bool lAceptar { get; set; }
        public string cClave { get; set; }
        #endregion
        #region Constructor
        public frmGiroIngresoClave()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmGiroIngresoClave_Load(object sender, System.EventArgs e)
        {
            txtClave.Text = string.Empty;
            txtClave.Focus();
        }
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            lAceptar = false;
            Close();
        }
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if(Validar())
            {
                lAceptar = true;
                cClave = txtClave.Text.Trim();
                Close();
            }
        }
        private void txtClave_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Validar())
                {
                    lAceptar = true;
                    cClave = txtClave.Text.Trim();
                    Close();
                }

            }
        }
        #endregion
        #region Metodos privados
        private bool Validar()
        {
            return (txtClave.Text.Trim().Length==4);
        }
        #endregion

        
    }
}

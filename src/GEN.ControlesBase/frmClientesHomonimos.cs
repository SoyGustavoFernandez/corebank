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
    public partial class frmClientesHomonimos : frmBase
    {
        public DataTable dtClientesHomonimos;
        public frmClientesHomonimos()
        {
            InitializeComponent();
        }

        private void frmClientesHomonimos_Load(object sender, EventArgs e)
        {
            dtgClientesHomonimos.DataSource = dtClientesHomonimos;

        }
        private void FormatoGrid()
        {
            dtgClientesHomonimos.Columns["cNombre"].Width=150;
            dtgClientesHomonimos.Columns["cDocumentoID"].Width=70;
            dtgClientesHomonimos.Columns["cDocumentoAdicional"].Width=80;

            dtgClientesHomonimos.Columns["cNombre"].HeaderText="Cliente";
            dtgClientesHomonimos.Columns["cDocumentoID"].HeaderText = "Doc.Indetidad";
            dtgClientesHomonimos.Columns["cDocumentoAdicional"].HeaderText = "Doc.Indetidad Ad.";
        }
    }
}

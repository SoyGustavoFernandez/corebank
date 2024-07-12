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
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmEvalCredAlertaReconsideracion : frmBase
    {
        public TipoResolucion idTipoResolucion;

        public frmEvalCredAlertaReconsideracion()
        {
            InitializeComponent();
            this.idTipoResolucion = TipoResolucion.Desfavorable;
        }

        private void btnFavorable_Click(object sender, EventArgs e)
        {
            this.idTipoResolucion = TipoResolucion.Favorable;
            this.Close();
        }

        private void btnDesfavorable_Click(object sender, EventArgs e)
        {
            this.idTipoResolucion = TipoResolucion.Desfavorable;
            this.Close();
        }
    }
}

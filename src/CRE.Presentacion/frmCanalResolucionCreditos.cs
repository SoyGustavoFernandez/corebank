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

namespace CRE.Presentacion
{
    public partial class frmCanalResolucionCreditos : frmBase
    {
        public int idCanalAproCred = 0;
        private DataTable dtCanalesAprobacionCred;

        public frmCanalResolucionCreditos()
        {
            InitializeComponent();
        }

        public frmCanalResolucionCreditos(DataTable dtCanalesAprobacionCred)
        {
            InitializeComponent();
            this.dtCanalesAprobacionCred = dtCanalesAprobacionCred.Copy();
            if (this.dtCanalesAprobacionCred.Columns.Contains("cCanalAproCred"))
                this.dtCanalesAprobacionCred.Columns.Remove("cCanalAproCred");
            if (this.dtCanalesAprobacionCred.Columns.Contains("cDescripcion"))
                this.dtCanalesAprobacionCred.Columns.Remove("cDescripcion");
        }

        private void frmCanalResolucionCreditos_Load(object sender, EventArgs e)
        {
            //this.cboCanalResolCreditos.SelectedIndexChanged -= new System.EventHandler(this.cboCanalResolCreditos_SelectedIndexChanged);
            if (this.dtCanalesAprobacionCred != null)
                this.cboCanalResolCreditos.ListarCanales(this.dtCanalesAprobacionCred);
            else
            {
                this.cboCanalResolCreditos.SelectedIndex = -1;
                this.cboCanalResolCreditos.SelectedIndex = 1;
            }            
            //this.btnAceptar1.Enabled = false;
            //this.cboCanalResolCreditos.SelectedIndexChanged += new System.EventHandler(this.cboCanalResolCreditos_SelectedIndexChanged);
        }

        private void cboCanalResolCreditos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( this.cboCanalResolCreditos.SelectedIndex >= 0 )
            {
                this.idCanalAproCred = Convert.ToInt32(this.cboCanalResolCreditos.SelectedValue);
                this.btnAceptar1.Enabled = true;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (this.cboCanalResolCreditos.SelectedIndex >= 0)
                this.Close();
            else
                MessageBox.Show("Seleccione un Canal de Aprobación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            idCanalAproCred = 0;
        }
    }
}

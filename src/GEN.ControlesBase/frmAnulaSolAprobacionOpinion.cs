#region Referencias
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
using System.Reflection;
#endregion


namespace GEN.ControlesBase
{
    public partial class frmAnulaSolAprobacionOpinion : frmBase
    {
        #region Variables Globales
        public string cComentarioAprobador { get; set; }
        public bool lValidado { get; set; }
        #endregion

        #region Constructores
        public frmAnulaSolAprobacionOpinion()
        {
            InitializeComponent();

            AnularEventos(btnSalir);
            btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
        }

        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!validar())
            {
                return;
            }
            this.cComentarioAprobador = Convert.ToString(txtOpinionAprobador.Text);
            this.lValidado = true;
            this.Close();
        }

        private void frmAnulaSolAprobacionOpinion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!lValidado)
            {
                DialogResult drResultado = MessageBox.Show("¿Está seguro que quiere salir?\nNo se ejecutará la anulación de la solicitud.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                e.Cancel = (drResultado == DialogResult.No);
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!lValidado)
            {
                this.Close();
            }
        }

        #endregion

        #region Métodos

        public void AnularEventos(Button b)
        {
            
            FieldInfo f1 = typeof(Control).GetField("EventClick",
            BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        public bool validar()
        {
            bool lValida = true;

            if(String.IsNullOrWhiteSpace(txtOpinionAprobador.Text))
            {
                lValida = false;
                MessageBox.Show("Debe registrar el Motivo de la Anulación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValida;
            }

            return lValida;
        }

        #endregion
    }
}

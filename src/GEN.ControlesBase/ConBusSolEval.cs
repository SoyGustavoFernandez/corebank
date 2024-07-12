using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConBusSolEval : UserControl
    {
        public int idSolicitud { get; set; }
        public int idEvalCred { get; set; }

        public string cOperacion { get; set; }
        public string cModalidad { get; set; }
        public ConBusSolEval()
        {
            InitializeComponent();
        }

        public void AsignarDatos(int _idSolicitud, int _idEvalCred, string _cOperacion, string _cModalidaCredito)
        {
            this.idSolicitud = _idSolicitud;
            this.idEvalCred = _idEvalCred;
            this.cOperacion = _cOperacion;
            this.cModalidad = _cModalidaCredito;

            MostrarDatos();
        }
        public void MostrarDatos()
        {
            this.txtSolicitud.Text = Convert.ToString(this.idSolicitud);
            this.txtEvaluacion.Text = Convert.ToString(this.idEvalCred);
            this.txtOperacion.Text = this.cOperacion;
            this.txtModalidad.Text = this.cModalidad;
        }
    }
}

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

namespace ADM.Presentacion
{
    public partial class frmNivelesAprobacion : frmBase
    {
        const int EVENTO_INICIO = 1;
        const int EVENTO_NUEVO = 2;
        const int EVENTO_GUARDADO = 3;
        const int EVENTO_EDICION = 4;
        const int EVENTO_CANCELAR = 5;

        const string CAPA_NIVELAPROBA = "Nivel Aprobacion";
        const string CAPA_PERFILES = "Perfiles";
        const string CAPA_CONDICIONES = "Condiciones";

        private string nCapaNivel = CAPA_NIVELAPROBA;
        private int estado = EVENTO_INICIO;

        public frmNivelesAprobacion()
        {
            InitializeComponent();
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {

        }

        private void cargarControles()
        {
            switch (nCapaNivel)
            {
                case CAPA_NIVELAPROBA:
                    controlesNivelAprobacion();
                    break;
                case CAPA_PERFILES:
                    controlesVinculoPerfiles();
                    break;
                case CAPA_CONDICIONES:
                    controlesCondiciones();
                    break;
            }
        }

        private void controlesCondiciones()
        {
            throw new NotImplementedException();
        }

        private void controlesVinculoPerfiles()
        {
            throw new NotImplementedException();
        }

        private void controlesNivelAprobacion()
        {
            throw new NotImplementedException();
        }
    }
}

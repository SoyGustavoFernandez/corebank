using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.BotonesBase;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class btnVincularVisita : Boton
    {
        public bool lIndividual { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }
        public bool lLectura { get; set; }

        public int idGrupoSolidario { get; set; }
        public int idSolicitudGrupoSol { get; set; }

        public btnVincularVisita()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.mapa;
        }

        public btnVincularVisita(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.BackgroundImage = Properties.Resources.mapa;
            this.Click += btnVincularVisita_Click;
            this.idCli = 0;
            this.idSolicitud = 0;
            this.lLectura = false;
            this.lIndividual = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "Vincular Visita";
        }

        public void btnVincularVisita_Click(object sender, EventArgs e)
        {
            if (this.lIndividual)
            {
                if (this.idCli == 0)
                    MessageBox.Show("No se encontró Codigo de Cliente", "Vinculación de Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (this.idSolicitud == 0)
                    MessageBox.Show("No se encontró Solicitud", "Vinculación de Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    frmVisitaRealizadaSinVinculacion frmVisitas = new frmVisitaRealizadaSinVinculacion(idCli, idSolicitud, lLectura);
                    frmVisitas.ShowDialog();
                }
            }
            else
            {
                if (this.idSolicitudGrupoSol == 0)
                {
                    MessageBox.Show("No se encontró Solicitud", "Vinculación de Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    frmVisitaRealizadaSinVinculacion frmVisitas = new frmVisitaRealizadaSinVinculacion(this.idGrupoSolidario, this.idSolicitudGrupoSol, false, lLectura);
                    frmVisitas.ShowDialog();
                }   
            }
        }
    }
}
